defmodule Spiral.Cells.Targets do
  alias Spiral.Cells.{Builders, ProcessError, Runner, TimeoutError, Toolchain}

  @spec host_key(map()) :: {atom(), String.t()} | nil
  def host_key(%{kind: :fsharp}), do: {:fsharp, "fsharp"}

  def host_key(%{kind: :code, language: language}) when is_binary(language) do
    case Spiral.Cells.Domain.host_language(language) do
      "" -> nil
      name -> {String.to_atom(name), name}
    end
  end

  def host_key(_), do: nil

  @spec run(map(), String.t(), keyword(), timeout(), integer() | :infinity) ::
          {:ok, %{stdout: String.t()}} | {:error, Exception.t()}
  def run(builder, output_path, opts, timeout, deadline) do
    if opts[:build_receipt] && builder[:tool] != :gleam do
      {:ok, %{stdout: ""}}
    else
      invoke(
        opts[:target],
        %{builder: builder, source: read_if(output_path), output_path: output_path, flags: builder},
        fn -> run_default(builder, output_path, opts, timeout, deadline) end
      )
      |> normalize(true)
    end
  end

  @spec build(map(), String.t(), keyword(), timeout(), integer() | :infinity) ::
          {:ok, map()} | {:error, Exception.t()}
  def build(%{tool: :gleam} = builder, output_path, opts, timeout, deadline) do
    package = output_path |> Path.dirname() |> Path.dirname()
    gleam_build(package, gleam_manifest(output_path, builder.deps, builder.target || "erlang"), opts, timeout, deadline)
  end

  def build(%{tool: :c}, output_path, opts, timeout, deadline) do
    cc = Toolchain.cc(opts)
    exe = Path.join(Path.dirname(output_path), exe_name())
    run_program(cc, Path.basename(cc || "gcc"), c_args(cc || "gcc", output_path, exe, opts[:root]), opts, timeout, deadline, false)
  end

  def build(_builder, _output_path, _opts, _timeout, _deadline), do: {:ok, %{stdout: ""}}
  @spec host(String.t(), String.t(), keyword(), timeout(), integer() | :infinity) ::
          {:ok, %{stdout: String.t()}} | {:error, Exception.t()}
  def host(language, source, opts, timeout, deadline) do
    if opts[:build_receipt], do: {:ok, %{stdout: ""}}, else: host_run(language, source, opts, timeout, deadline)
  end

  defp host_run(language, source, opts, timeout, deadline) do
    invoke(opts[:host], %{language: language, source: source}, fn ->
      dir = tmp_dir()

      try do
        path = Path.join(dir, "main" <> host_extension(language))
        File.write!(path, source)
        run_host(language, path, opts, timeout, deadline)
      after
        File.rm_rf(dir)
      end
    end)
    |> normalize(false)
  end

  defp run_default(%{tool: :gleam, target: "javascript"} = builder, output_path, opts, timeout, deadline)
       when is_list(opts) do
    if opts[:test_cell] == true,
      do: run_gleam(output_path, builder.deps, "javascript", opts, timeout, deadline),
      else: dispatch_default(builder, output_path, opts, timeout, deadline)
  end

  defp run_default(builder, output_path, opts, timeout, deadline), do: dispatch_default(builder, output_path, opts, timeout, deadline)

  defp dispatch_default(builder, output_path, opts, timeout, deadline) do
    case Builders.dispatch(builder, output_path) do
      {:spiral, ["rust" | _] = args} ->
        one_spiral_rust(opts, timeout, deadline, fn deadline ->
          run_spiral(args, opts, timeout, deadline)
          |> promote_spiral(builder, output_path, opts, timeout, deadline)
        end)

      {:spiral, args} ->
        run_spiral(args, opts, timeout, deadline)
        |> promote_spiral(builder, output_path, opts, timeout, deadline)

      {:fsi, path} ->
        run_fsi(path, opts, timeout, deadline)

      {:python, path} ->
        run_program(Toolchain.python(opts), "python", [path], opts, timeout, deadline, false)

      {:bun, path} ->
        run_program(Toolchain.bun(opts), "bun", ["run", path], opts, timeout, deadline, false)

      {:cc, path} ->
        run_cc(path, opts, timeout, deadline)

      {:dcc, path} ->
        run_dcc(path, opts, timeout, deadline)

      {:gleam, path, deps} ->
        run_gleam(path, deps, "erlang", opts, timeout, deadline)


      {:zig, path} ->
        if System.get_env("SPIRAL_CELLS_ZIG_RELEASE") == "1",
          do: run_zig_release(path, opts, timeout, deadline),
          else: run_program(Toolchain.zig(opts), "zig", zig_run_args(path, opts), opts, timeout, deadline, false)

      {:lean, path} ->
        {lean, args} = Toolchain.lean(opts)
        run_program(lean, "lean", args ++ ["--run", path], opts, timeout, deadline, false)

      {:wgsl, path} ->
        run_wgsl(path, opts, timeout, deadline)
    end
  end

  @doc false
  def zig_run_args(path, opts) do
    global_cache = Path.join(Toolchain.cache_dir(opts), "cells-zig-cache")
    local_cache = Path.join(Path.dirname(path), ".zig-cache")
    backend = if zig_self_hosted?(), do: ["-fno-llvm"], else: []
    ["run"] ++ backend ++ ["--global-cache-dir", global_cache, "--cache-dir", local_cache, path]
  end

  defp run_zig_release(path, opts, timeout, deadline) do
    exe = Path.join(Path.dirname(path), exe_name())
    global_cache = Path.join(Toolchain.cache_dir(opts), "cells-zig-cache")
    local_cache = Path.join(Path.dirname(path), ".zig-cache")
    args = ["build-exe", "-O", "ReleaseFast", "--global-cache-dir", global_cache, "--cache-dir", local_cache, "-femit-bin=" <> exe, path]

    with {:ok, _built} <- Spiral.Cells.timed(:target_build_ms, fn -> run_program(Toolchain.zig(opts), "zig build-exe", args, opts, timeout, deadline, false) end),
         {:ok, ran} <- Spiral.Cells.timed(:target_run_ms, fn -> run_status(exe, exe_name(), [], opts, timeout, deadline, false) end) do
      {:ok, cell_exit(ran)}
    end
  end

  defp zig_self_hosted? do
    System.get_env("SPIRAL_CELLS_ZIG_LLVM") != "1" and
      Regex.match?(~r/x86_64|amd64|win32/i, to_string(:erlang.system_info(:system_architecture)))
  end

  @spiral_rust_wait_ms 3_600_000

  defp one_spiral_rust(opts, timeout, deadline, fun) do
    started = System.monotonic_time(:millisecond)
    lock = opts[:rust_lock] || Path.join(Path.dirname(Spiral.Cells.Mounts.root()), "cells-spiral-rust.lock")

    result =
      Spiral.Cells.FileLock.with_lock(
        lock,
        fn ->
          waited = System.monotonic_time(:millisecond) - started

          case Process.get(:spiral_cells_phases) do
            %{} = phases -> Process.put(:spiral_cells_phases, Map.update(phases, :rust_lock_wait_ms, waited, &(&1 + waited)))
            _ -> :ok
          end

          case Process.get(:spiral_cells_deadline) do
            ms when is_integer(ms) -> Process.put(:spiral_cells_deadline, ms + waited)
            _ -> :ok
          end

          {:ran, fun.(if deadline == :infinity, do: :infinity, else: deadline + waited)}
        end,
        @spiral_rust_wait_ms
      )

    case result do
      {:ran, ran} ->
        ran

      {:error, reason} ->
        {:error,
         %ProcessError{
           message: "`spiral rust` waited #{div(@spiral_rust_wait_ms, 60_000)} min for #{lock}: #{inspect(reason)} (cell budget #{inspect(timeout)})"
         }}
    end
  end

  defp run_host("fsharp", path, opts, timeout, deadline),
    do: run_fsi(path, opts, timeout, deadline)

  defp run_host("python", path, opts, timeout, deadline) do
    run_program(Toolchain.python(opts), "python", [path], opts, timeout, deadline, false)
  end

  defp run_host("lua", path, opts, timeout, deadline) do
    run_program(Toolchain.lua(opts), "lua", [path], opts, timeout, deadline, false)
  end

  defp run_host("javascript", path, opts, timeout, deadline) do
    run_program(Toolchain.bun(opts), "bun", [path], opts, timeout, deadline, false)
  end

  defp run_host("powershell", path, opts, timeout, deadline) do
    run_program(
      Toolchain.pwsh(opts),
      "pwsh",
      ["-NoProfile", "-File", path],
      opts,
      timeout,
      deadline,
      false
    )
  end

  defp run_spiral(args, opts, timeout, deadline) do
    shown = "spiral " <> Enum.join(args, " ")
    exe = Toolchain.spiral(opts)

    if is_binary(exe) and File.regular?(exe) do
      run_program(exe, shown, args, opts, timeout, deadline, true)
    else
      {:error, %ProcessError{message: "`#{shown}` was not found", reason: :tool_missing}}
    end
  end

  defp promote_spiral(
         {:ok, %{output: _output}} = ran,
         %{tool: :cpp},
         output_path,
         opts,
         timeout,
         deadline
       ) do
    exe = cpp_exe(output_path)

    if File.regular?(exe) do
      case run_status(exe, Path.basename(exe), [], opts, timeout, deadline, false) do
        {:ok, built} -> {:ok, cell_exit(built)}
        error -> error
      end
    else
      promote_trace(ran)
    end
  end

  defp promote_spiral(result, _builder, _output_path, _opts, _timeout, _deadline) do
    promote_trace(result)
  end

  defp promote_trace({:ok, %{output: output}} = ran) do
    case failure_trace(output) do
      nil -> ran
      message -> {:error, %ProcessError{message: message, output: output}}
    end
  end

  defp promote_trace(other), do: other

  defp failure_trace(output) do
    case Spiral.Cells.Domain.builder_failure_trace(output) do
      "" -> nil
      trace -> trace
    end
  end

  defp cpp_exe(path) do
    path <> ".out" <> if(match?({:win32, _}, :os.type()), do: ".exe", else: "")
  end

  defp run_fsi(path, opts, timeout, deadline) do
    dotnet = Toolchain.dotnet(opts)

    cond do
      not (is_binary(dotnet) and File.regular?(dotnet)) ->
        {:error, %ProcessError{message: "`dotnet fsi` was not found", reason: :tool_missing}}

      true ->
        run_program(
          dotnet,
          "dotnet fsi",
          ["fsi", "--nologo", "--langversion:preview", "--exec", in_notebook_dir(path, opts[:root])],
          if(notebook_dir?(opts[:root]), do: Keyword.put(opts, :cwd, opts[:root]), else: opts),
          timeout,
          deadline,
          false
        )
    end
  end

  defp notebook_dir?(root), do: is_binary(root) and File.dir?(root)

  defp in_notebook_dir(path, root) do
    if notebook_dir?(root) do
      dir = root |> Path.expand() |> String.replace("\\", "/")
      File.write!(path, ~s(# 1 "#{dir}/#{Path.basename(path)}"\n) <> File.read!(path))
    end

    path
  end

  defp run_cc(path, opts, timeout, deadline) do
    cc = Toolchain.cc(opts)

    if is_binary(cc) and File.regular?(cc) do
      exe = Path.join(Path.dirname(path), exe_name())
      shown = Path.basename(cc)

      with {:ok, _compiled} <- Spiral.Cells.timed(:target_build_ms, fn -> run_program(cc, shown, c_args(cc, path, exe, opts[:root]), opts, timeout, deadline, false) end),
           {:ok, ran} <- Spiral.Cells.timed(:target_run_ms, fn -> run_status(exe, exe_name(), [], opts, timeout, deadline, false) end) do
        {:ok, cell_exit(ran)}
      end
    else
      {:error, %ProcessError{message: "`gcc` was not found", reason: :tool_missing}}
    end
  end

  defp run_dcc(path, opts, timeout, deadline) do
    case pascal_compiler(opts) do
      {compiler, shown, args} -> run_pascal(compiler, shown, args ++ [path], path, opts, timeout, deadline)
      nil -> {:error, %ProcessError{message: "`dcc32` was not found (nor fpc)", reason: :tool_missing}}
    end
  end

  @doc false
  @spec pascal_compiler(keyword()) :: {String.t(), String.t(), [String.t()]} | nil
  def pascal_compiler(opts) do
    dcc = Toolchain.dcc(opts)
    fpc = Toolchain.fpc(opts)

    cond do
      is_binary(dcc) and File.regular?(dcc) -> {dcc, "dcc32", []}
      is_binary(fpc) and File.regular?(fpc) -> {fpc, "fpc", ["-Px86_64", "-O2", "-Mdelphi", "-l-", "-v0w"]}
      true -> nil
    end
  end

  defp run_pascal(compiler, shown, args, path, opts, timeout, deadline) do
    with {:ok, compiled} <- run_program(compiler, shown, args, opts, timeout, deadline, false) do
      exe = Path.join(Path.dirname(path), Path.basename(path, Path.extname(path)) <> ".exe")

      if File.regular?(exe) do
        case run_status(exe, Path.basename(exe), [], opts, timeout, deadline, false) do
          {:ok, ran} -> {:ok, cell_exit(ran)}
          error -> error
        end
      else
        {:ok, compiled}
      end
    end
  end

  @doc false
  def gleam_manifest(path, deps, target \\ "erlang"), do: Spiral.Cells.Domain.gleam_manifest(path, deps, target)

  @gleam_warm_slots 4

  defp run_gleam(path, deps, target, opts, timeout, deadline) do
    package = path |> Path.dirname() |> Path.dirname()
    manifest = gleam_manifest(path, deps, target)
    build_and_run = fn dir -> build_and_run_gleam(dir, manifest, target, opts, timeout, deadline) end

    case if(opts[:build_receipt], do: :all_slots_busy, else: in_warm_gleam_package(package, manifest, opts, build_and_run)) do
      :all_slots_busy -> build_and_run.(package)
      result -> result
    end
  end

  defp build_and_run_gleam(package, manifest, target, opts, timeout, deadline) do
    with {:ok, _built} <- Spiral.Cells.timed(:target_build_ms, fn -> gleam_build(package, manifest, opts, timeout, deadline) end) do
      if opts[:build_receipt],
        do: build_only_receipt(package, target, opts[:build_receipt]),
        else: Spiral.Cells.timed(:target_run_ms, fn -> run_gleam_program(package, target, opts, Keyword.put(opts, :cwd, opts[:root] || package), timeout, deadline) end)
    end
  end

  @doc false
  def build_only_receipt(package, target, receipt) do
    built = package |> Path.join("build/dev/#{target}/*/#{if target == "javascript", do: "", else: "ebin"}")
    paths = built |> String.replace("\\", "/") |> Path.wildcard() |> Enum.sort()
    entry = if target == "javascript", do: "main/main.mjs", else: "main"
    package_line = "cells-build-only package=" <> String.replace(package, "\\", "/")
    lines = [package_line | Enum.map(paths, &"cells-build-only ebin=#{&1}")] ++ ["cells-build-only entry=#{entry}"]
    File.write!(receipt, Enum.join(lines, "\n") <> "\n", [:append])
    {:ok, %{exit_status: 0, output: ""}}
  end

  @doc false
  def gleam_warm_dir(manifest, slot, opts) do
    key = :crypto.hash(:sha256, manifest) |> Base.encode16(case: :lower) |> binary_part(0, 24)
    Path.join(Toolchain.cache_dir(opts), "cells-gleam-warm/#{key}-#{slot}")
  end

  defp in_warm_gleam_package(package, manifest, opts, fun) do
    Enum.reduce_while(0..(@gleam_warm_slots - 1), :all_slots_busy, fn slot, busy ->
      warm = gleam_warm_dir(manifest, slot, opts)
      claimed = Spiral.Cells.FileLock.with_lock(warm <> ".lock", fn -> {:claimed, fun.(with_cell_sources(warm, package, manifest))} end, 0)

      case claimed do
        {:claimed, result} -> {:halt, result}
        _ -> {:cont, busy}
      end
    end)
  end

  defp listed(dir) do
    case File.ls(dir) do
      {:ok, entries} -> entries
      {:error, _} -> []
    end
  end

  defp with_cell_sources(warm, package, manifest) do
    src = Path.join(warm, "src")
    File.rm_rf!(src)
    File.mkdir_p!(src)
    File.cp_r!(Path.join(package, "src"), src)
    {name, _target} = manifest_facts(manifest)
    build = Path.join(warm, "build")
    for mode <- listed(build), target <- listed(Path.join(build, mode)), do: File.rm_rf!(Path.join([build, mode, target, name]))
    warm
  end

  defp gleam_build(package, manifest, opts, timeout, deadline) do
    File.write!(Path.join(package, "gleam.toml"), manifest)
    locked = gleam_lock_path(manifest, opts)
    build = fn -> run_program(Toolchain.gleam(opts), "gleam build", ["build", "--no-print-progress"], Keyword.put(opts, :cwd, package), timeout, deadline, false) end

    if File.regular?(locked) do
      File.cp!(locked, Path.join(package, "manifest.toml"))
      build.()
    else
      :global.trans({{__MODULE__, :gleam_resolve, locked}, self()}, fn ->
        if File.regular?(locked), do: File.cp!(locked, Path.join(package, "manifest.toml"))
        result = build.()
        if match?({:ok, _}, result), do: keep_gleam_lock(Path.join(package, "manifest.toml"), locked)
        result
      end)
    end
  end

  @doc false
  def gleam_lock_path(manifest, opts) do
    requirements = manifest |> String.split("\n") |> Enum.drop_while(&(&1 != "[dependencies]")) |> Enum.join("\n")
    {_name, target} = manifest_facts(manifest)
    key = :crypto.hash(:sha256, :erlang.term_to_binary({target, requirements})) |> Base.encode16(case: :lower) |> binary_part(0, 24)
    Path.join(Toolchain.cache_dir(opts), "cells-gleam-locks/#{key}.toml")
  end

  @doc false
  def manifest_facts(manifest) do
    [name, found, target] = manifest |> Spiral.Cells.Domain.gleam_manifest_facts() |> String.split("\t", parts: 3)
    {name, if(found == "1", do: [target], else: [])}
  end

  defp keep_gleam_lock(manifest_path, locked) do
    with false <- File.regular?(locked),
         {:ok, text} <- File.read(manifest_path),
         :ok <- File.mkdir_p(Path.dirname(locked)) do
      pending = locked <> ".#{System.unique_integer([:positive])}.tmp"
      with :ok <- File.write(pending, text), do: File.rename(pending, locked)
      File.rm(pending)
    end

    :ok
  end

  defp run_gleam_program(package, "javascript", opts, quiet, timeout, deadline) do
    entry = Path.join(package, "kino_entry.mjs")
    File.write!(entry, ~s|import { main } from "./build/dev/javascript/main/main.mjs";\nmain();\n|)
    run_program(Toolchain.bun(opts), "bun", [entry], quiet, timeout, deadline, false)
  end

  defp run_gleam_program(package, _erlang, opts, quiet, timeout, deadline) do
    paths = package |> Path.join("build/dev/erlang/*/ebin") |> String.replace("\\", "/") |> Path.wildcard()
    entry = "try main:main(), halt(0) catch Class:Reason -> io:format(\"~p: ~p~n\", [Class, Reason]), halt(1) end."
    run_program(Toolchain.erl(opts), "erl", ["-noshell", "-pa" | paths] ++ ["-eval", entry], quiet, timeout, deadline, false)
  end
  @doc false
  def strip_gleam_warnings(text), do: Spiral.Cells.Domain.gleam_strip_warnings(text)

  @spec tool_stamp(map(), keyword()) :: [term()] | nil
  def tool_stamp(%{tool: :wgsl}, opts), do: [{:wgsl_tools, Enum.map([Toolchain.wgsl_run(opts), Toolchain.naga(opts)], &file_stamp/1)}]
  def tool_stamp(_builder, _opts), do: nil

  defp file_stamp(nil), do: nil

  defp file_stamp(path) do
    case File.stat(System.find_executable(path) || path) do
      {:ok, %{size: size, mtime: mtime}} -> {path, size, mtime}
      _ -> {path, nil, nil}
    end
  end

  @wgsl_no_adapter 3
  defp run_wgsl(path, opts, timeout, deadline) do
    with :ok <- naga_check(path, opts, timeout, deadline) do
      case Toolchain.wgsl_run(opts) do
        nil ->
          {:error, %ProcessError{message: "`spiral-wgsl` was not found", reason: :tool_missing}}

        runner ->
          case run_status(runner, "spiral-wgsl", [path], opts, timeout, deadline, false) do
            {:ok, %{exit_status: 0} = ran} ->
              {:ok, ran}

            {:ok, %{exit_status: @wgsl_no_adapter, output: output}} ->
              {:error,
               %ProcessError{
                 message: "`spiral-wgsl` found no GPU adapter\n\n#{output}",
                 exit_status: @wgsl_no_adapter,
                 output: output,
                 reason: :tool_missing
               }}

            {:ok, %{exit_status: status, output: output}} ->
              {:error,
               %ProcessError{
                 message: "`spiral-wgsl` failed (exit #{status})\n\n#{output}",
                 exit_status: status,
                 output: output
               }}

            {:error, %ProcessError{reason: :not_found} = error} ->
              {:error, %ProcessError{error | reason: :tool_missing}}

            other ->
              other
          end
      end
    end
  end

  defp naga_check(path, opts, timeout, deadline) do
    case Toolchain.naga(opts) do
      nil ->
        :ok

      naga ->
        case run_program(naga, "naga", [path], opts, timeout, deadline, false) do
          {:ok, _} -> :ok
          error -> error
        end
    end
  end

  defp run_program(exe, shown, args, opts, timeout, deadline, spiral?) do
    case run_status(exe, shown, args, opts, timeout, deadline, spiral?) do
      {:error, %ProcessError{reason: :not_found} = error} ->
        {:error, %ProcessError{error | reason: :tool_missing}}

      {:ok, %{exit_status: 0, output: output}} ->
        {:ok, %{exit_status: 0, output: output}}

      {:ok, %{exit_status: status, output: output}} ->
        {:error,
         %ProcessError{
           message: "`#{shown}` failed (exit #{status})\n\n#{output}",
           exit_status: status,
           output: output
         }}

      other ->
        other
    end
  end

  defp run_status(exe, shown, args, opts, timeout, deadline, spiral?) do
    cond do
      not is_binary(exe) ->
        {:error, %ProcessError{message: "`#{shown}` was not found", reason: :not_found}}

      not File.regular?(exe) and is_nil(System.find_executable(exe)) ->
        {:error, %ProcessError{message: "`#{shown}` was not found at #{exe}", reason: :not_found}}

      true ->
        case Runner.run(exe, args,
               timeout: budget(deadline),
               cd:
                 cond do
                   spiral? and notebook_dir?(opts[:root]) -> opts[:root]
                   spiral? -> nil
                   is_binary(opts[:cwd]) -> opts[:cwd]
                   true -> work_dir(args, exe)
                 end,
               env: tool_env(opts, spiral?)
             ) do
          {:ok, %{exit_status: status, output: output}} ->
            {:ok, %{exit_status: status, output: output}}

          {:error, {:timeout, info}} ->
            {:error, timeout_error(info, timeout)}

          {:error, reason} ->
            {:error, %ProcessError{message: "could not start `#{shown}`: #{inspect(reason)}"}}
        end
    end
  end

  defp cell_exit(ran) do
    %{exit_status: ran.exit_status, output: ran.output}
  end

  defp normalize({:ok, %{exit_status: 0, output: output} = ran}, present?) do
    text = if present?, do: present(output), else: output
    shown = %{stdout: String.trim(text)}
    shown = if is_binary(ran[:value]), do: Map.put(shown, :value, ran.value), else: shown
    {:ok, shown}
  end

  defp normalize({:ok, %{stdout: stdout}}, _present?) when is_binary(stdout) do
    {:ok, %{stdout: stdout}}
  end

  defp normalize({:ok, %{exit_status: status, output: output}}, _present?) do
    {:error,
     %ProcessError{
       message: "builder failed (exit #{status})\n\n#{output}",
       exit_status: status,
       output: output
     }}
  end

  defp normalize({:error, {:timeout, info}}, _present?),
    do: {:error, timeout_error(info, info.timeout)}

  defp normalize({:error, %TimeoutError{} = error}, _present?), do: {:error, error}
  defp normalize({:error, %ProcessError{} = error}, _present?), do: {:error, error}

  defp normalize({:error, reason}, _present?) do
    {:error, %ProcessError{message: "could not run the builder: #{inspect(reason)}"}}
  end

  defp present(output), do: Spiral.Cells.Domain.builder_present(output)

  @cupy_missing_cuda_path_warning "ignore:CUDA path could not be detected:UserWarning"

  defp tool_env(opts, false), do: System.get_env() |> Enum.to_list() |> with_test_name(opts) |> without_cupy_cuda_path_warning()

  defp tool_env(opts, true) do
    System.get_env()
    |> Enum.to_list()
    |> with_test_name(opts)
    |> List.keystore("SPIRAL_JSON", 0, {"SPIRAL_JSON", "1"})
    |> List.keystore("TRACE_LEVEL", 0, {"TRACE_LEVEL", "Info"})
    |> without_cupy_cuda_path_warning()
  end

  @doc false
  def with_test_name(env, opts) do
    case opts[:test_name] do
      name when is_binary(name) and name != "" -> List.keystore(env, "SPIRAL_CELLS_TEST", 0, {"SPIRAL_CELLS_TEST", name})
      _ -> env
    end
  end

  @doc false
  def without_cupy_cuda_path_warning(env) do
    filters =
      case List.keyfind(env, "PYTHONWARNINGS", 0) do
        {_, existing} when existing not in [nil, ""] -> existing <> "," <> @cupy_missing_cuda_path_warning
        _ -> @cupy_missing_cuda_path_warning
      end

    List.keystore(env, "PYTHONWARNINGS", 0, {"PYTHONWARNINGS", filters})
  end

  defp work_dir([], exe), do: Path.dirname(exe)

  defp work_dir(args, exe) do
    case List.last(args) do
      path when is_binary(path) ->
        if File.regular?(path), do: Path.dirname(path), else: Path.dirname(exe)

      _ ->
        Path.dirname(exe)
    end
  end

  defp read_if(path) do
    case File.read(path) do
      {:ok, text} -> text
      _ -> ""
    end
  end

  defp invoke(nil, _ctx, default), do: default.()
  defp invoke(fun, ctx, _default) when is_function(fun, 1), do: fun.(ctx)

  @c_flags ["-std=c11", "-O2", "-w", "-fwrapv"]

  @spec c_args(String.t(), String.t(), String.t(), String.t() | nil) :: [String.t()]
  def c_args(cc, source, exe, notebook_dir) do
    if cl?(cc) do
      ["/nologo", "/O2", "/Fe:#{exe}", source]
    else
      @c_flags ++ c_shim(notebook_dir) ++ ["-o", exe, source, "-lm"]
    end
  end

  defp c_shim(nil), do: []

  defp c_shim(dir) do
    shim = Path.join(dir, "c-shim.h")
    if File.regular?(shim), do: ["-include", shim], else: []
  end

  defp cl?(path), do: Spiral.Cells.Domain.is_cl_compiler(Path.basename(path)) == "true"

  defp host_extension(language), do: Spiral.Cells.Domain.host_extension(language)

  defp exe_name, do: if(match?({:win32, _}, :os.type()), do: "cell.exe", else: "cell")

  defp tmp_dir do
    dir =
      Path.join([
        System.tmp_dir!(),
        "spiral_cells",
        "#{System.os_time(:millisecond)}-#{System.unique_integer([:positive])}"
      ])

    File.mkdir_p!(dir)
    dir
  end

  defp budget(:infinity), do: :infinity

  defp budget(deadline) do
    deadline =
      case Process.get(:spiral_cells_deadline) do
        ms when is_integer(ms) -> ms
        :infinity -> :infinity
        _ -> deadline
      end

    case deadline do
      :infinity -> :infinity
      ms -> max(ms - System.monotonic_time(:millisecond), 0)
    end
  end

  defp timeout_error(%{output: output}, timeout) do
    %TimeoutError{
      message: "Spiral cell timed out after #{format_ms(timeout)}#{Spiral.Cells.Directives.scale_note()}; the process tree was killed.",
      timeout: timeout,
      output: output
    }
  end

  defp format_ms(:infinity), do: "infinity"
  defp format_ms(ms) when is_integer(ms) and rem(ms, 1000) == 0, do: "#{div(ms, 1000)}s"
  defp format_ms(ms), do: "#{ms}ms"
end
