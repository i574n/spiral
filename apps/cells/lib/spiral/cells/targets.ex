defmodule Spiral.Cells.Targets do
  alias Spiral.Cells.{Domain, ProcessError, Runner, TimeoutError}

  @spec host_key(map()) :: {atom(), String.t()} | nil
  def host_key(cell), do: Spiral.Cells.Domain.host_key(cell)

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
    cc = Domain.tool("cc", opts)
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
    case Domain.builders_dispatch(builder, output_path) do
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
        run_program(Domain.tool("python", opts), "python", [path], opts, timeout, deadline, false)

      {:bun, path} ->
        run_program(Domain.tool("bun", opts), "bun", ["run", path], opts, timeout, deadline, false)

      {:cc, path} ->
        run_cc(path, opts, timeout, deadline)

      {:dcc, path} ->
        run_dcc(path, opts, timeout, deadline)

      {:gleam, path, deps} ->
        run_gleam(path, deps, "erlang", opts, timeout, deadline)


      {:zig, path} ->
        if System.get_env("SPIRAL_CELLS_ZIG_RELEASE") == "1",
          do: run_zig_release(path, opts, timeout, deadline),
          else: run_program(Domain.tool("zig", opts), "zig", zig_run_args(path, opts), opts, timeout, deadline, false)

      {:lean, path} ->
        {lean, args} = Domain.tool_lean(opts)
        run_program(lean, "lean", args ++ ["--run", path], opts, timeout, deadline, false)

      {:wgsl, path} ->
        run_wgsl(path, opts, timeout, deadline)
    end
  end

  @doc false
  def zig_run_args(path, opts), do: zig_args("", path, opts)

  defp zig_args(release_exe, path, opts) do
    arch = to_string(:erlang.system_info(:system_architecture))
    global_cache = Path.join(Domain.tool("cache_dir", opts), "cells-zig-cache")
    local_cache = Path.join(Path.dirname(path), ".zig-cache")
    llvm = System.get_env("SPIRAL_CELLS_ZIG_LLVM") || ""
    String.split(Spiral.Cells.Domain.zig_args(release_exe, arch, llvm, global_cache, local_cache, path), "\n")
  end

  defp run_zig_release(path, opts, timeout, deadline) do
    exe = Path.join(Path.dirname(path), exe_name())
    args = zig_args(exe, path, opts)

    with {:ok, _built} <- Spiral.Cells.timed(:target_build_ms, fn -> run_program(Domain.tool("zig", opts), "zig build-exe", args, opts, timeout, deadline, false) end),
         {:ok, ran} <- Spiral.Cells.timed(:target_run_ms, fn -> run_status(exe, exe_name(), [], opts, timeout, deadline, false) end) do
      {:ok, cell_exit(ran)}
    end
  end

  @spiral_rust_wait_ms 3_600_000

  defp one_spiral_rust(opts, timeout, deadline, fun) do
    started = System.monotonic_time(:millisecond)
    lock = opts[:rust_lock] || Path.join(Path.dirname(Spiral.Cells.Mounts.root()), "cells-spiral-rust.lock")

    result =
      Spiral.Cells.Domain.with_lock(
        lock,
        fn ->
          waited = System.monotonic_time(:millisecond) - started
          Spiral.Cells.Domain.add_wait(:rust_lock_wait_ms, waited)
          {:ran, fun.(if deadline == :infinity, do: :infinity, else: deadline + waited)}
        end,
        @spiral_rust_wait_ms
      )

    case result do
      {:ran, ran} ->
        ran

      {:error, reason} ->
        {:error,
         Spiral.Cells.Domain.process_error(
           "`spiral rust` waited #{div(@spiral_rust_wait_ms, 60_000)} min for #{lock}: #{inspect(reason)} (cell budget #{inspect(timeout)})",
           nil,
           nil,
           nil
         )}
    end
  end

  defp run_host("fsharp", path, opts, timeout, deadline),
    do: run_fsi(path, opts, timeout, deadline)

  defp run_host("python", path, opts, timeout, deadline) do
    run_program(Domain.tool("python", opts), "python", [path], opts, timeout, deadline, false)
  end

  defp run_host("lua", path, opts, timeout, deadline) do
    run_program(Domain.tool("lua", opts), "lua", [path], opts, timeout, deadline, false)
  end

  defp run_host("javascript", path, opts, timeout, deadline) do
    run_program(Domain.tool("bun", opts), "bun", [path], opts, timeout, deadline, false)
  end

  defp run_host("powershell", path, opts, timeout, deadline) do
    run_program(
      Domain.tool("pwsh", opts),
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
    exe = Domain.tool("spiral", opts)

    if is_binary(exe) and File.regular?(exe) do
      run_program(exe, shown, args, opts, timeout, deadline, true)
    else
      {:error, Spiral.Cells.Domain.process_error("`#{shown}` was not found", nil, nil, :tool_missing)}
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
      message -> {:error, Spiral.Cells.Domain.process_error(message, nil, output, nil)}
    end
  end

  defp promote_trace(other), do: other

  defp failure_trace(output) do
    case Spiral.Cells.Domain.builder_failure_trace(output) do
      "" -> nil
      trace -> trace
    end
  end

  defp cpp_exe(path), do: Spiral.Cells.Domain.c_exe_path(path, match?({:win32, _}, :os.type()))

  defp run_fsi(path, opts, timeout, deadline) do
    dotnet = Domain.tool("dotnet", opts)

    cond do
      not (is_binary(dotnet) and File.regular?(dotnet)) ->
        {:error, Spiral.Cells.Domain.process_error("`dotnet fsi` was not found", nil, nil, :tool_missing)}

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
      File.write!(path, Spiral.Cells.Domain.line_directive(dir, Path.basename(path)) <> File.read!(path))
    end

    path
  end

  defp run_cc(path, opts, timeout, deadline) do
    cc = Domain.tool("cc", opts)

    if is_binary(cc) and File.regular?(cc) do
      exe = Path.join(Path.dirname(path), exe_name())
      shown = Path.basename(cc)

      with {:ok, _compiled} <- Spiral.Cells.timed(:target_build_ms, fn -> run_program(cc, shown, c_args(cc, path, exe, opts[:root]), opts, timeout, deadline, false) end),
           {:ok, ran} <- Spiral.Cells.timed(:target_run_ms, fn -> run_status(exe, exe_name(), [], opts, timeout, deadline, false) end) do
        {:ok, cell_exit(ran)}
      end
    else
      {:error, Spiral.Cells.Domain.process_error("`gcc` was not found", nil, nil, :tool_missing)}
    end
  end

  defp run_dcc(path, opts, timeout, deadline) do
    case pascal_compiler(opts) do
      {compiler, shown, args} -> run_pascal(compiler, shown, args ++ [path], path, opts, timeout, deadline)
      nil -> {:error, Spiral.Cells.Domain.process_error("`dcc32` was not found (nor fpc)", nil, nil, :tool_missing)}
    end
  end

  @doc false
  @spec pascal_compiler(keyword()) :: {String.t(), String.t(), [String.t()]} | nil
  def pascal_compiler(opts) do
    dcc = Domain.tool("dcc", opts)
    fpc = Domain.tool("fpc", opts)

    Spiral.Cells.Domain.pascal_choice(
      is_binary(dcc) and File.regular?(dcc),
      dcc || "",
      is_binary(fpc) and File.regular?(fpc),
      fpc || ""
    )
  end

  defp run_pascal(compiler, shown, args, path, opts, timeout, deadline) do
    with {:ok, compiled} <- run_program(compiler, shown, args, opts, timeout, deadline, false) do
      exe = Enum.find(for(s <- [".exe", ""], do: Path.join(Path.dirname(path), Path.basename(path, Path.extname(path)) <> s)), &File.regular?/1)

      if exe do
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
    Spiral.Cells.Domain.gleam_build_only_receipt(package, target, receipt)
    {:ok, %{exit_status: 0, output: ""}}
  end

  @doc false
  def gleam_warm_dir(manifest, slot, opts), do: Spiral.Cells.Domain.gleam_warm_dir(Domain.tool("cache_dir", opts), manifest, slot)

  defp in_warm_gleam_package(package, manifest, opts, fun) do
    Enum.reduce_while(0..(@gleam_warm_slots - 1), :all_slots_busy, fn slot, busy ->
      warm = gleam_warm_dir(manifest, slot, opts)
      claimed = Spiral.Cells.Domain.with_lock(warm <> ".lock", fn -> {:claimed, fun.(Spiral.Cells.Domain.gleam_cell_sources(warm, package, manifest))} end, 0)

      case claimed do
        {:claimed, result} -> {:halt, result}
        _ -> {:cont, busy}
      end
    end)
  end

  defp gleam_build(package, manifest, opts, timeout, deadline) do
    File.write!(Path.join(package, "gleam.toml"), manifest)
    locked = gleam_lock_path(manifest, opts)
    build = fn -> run_program(Domain.tool("gleam", opts), "gleam build", ["build", "--no-print-progress"], Keyword.put(opts, :cwd, package), timeout, deadline, false) end

    if File.regular?(locked) do
      File.cp!(locked, Path.join(package, "manifest.toml"))
      build.()
    else
      :global.trans({{__MODULE__, :gleam_resolve, locked}, self()}, fn ->
        if File.regular?(locked), do: File.cp!(locked, Path.join(package, "manifest.toml"))
        result = build.()
        if match?({:ok, _}, result), do: Spiral.Cells.Domain.gleam_keep_lock(Path.join(package, "manifest.toml"), locked)
        result
      end)
    end
  end

  @doc false
  def gleam_lock_path(manifest, opts), do: Spiral.Cells.Domain.gleam_lock_path(Domain.tool("cache_dir", opts), manifest)

  defp run_gleam_program(package, "javascript", opts, quiet, timeout, deadline) do
    entry = Path.join(package, "kino_entry.mjs")
    File.write!(entry, ~s|import { main } from "./build/dev/javascript/main/main.mjs";\nmain();\n|)
    run_program(Domain.tool("bun", opts), "bun", [entry], quiet, timeout, deadline, false)
  end

  defp run_gleam_program(package, _erlang, opts, quiet, timeout, deadline) do
    paths = package |> Path.join("build/dev/erlang/*/ebin") |> String.replace("\\", "/") |> Path.wildcard()
    entry = "try main:main(), halt(0) catch Class:Reason -> io:format(\"~p: ~p~n\", [Class, Reason]), halt(1) end."
    run_program(Domain.tool("erl", opts), "erl", ["-noshell", "-pa" | paths] ++ ["-eval", entry], quiet, timeout, deadline, false)
  end
  @doc false
  def strip_gleam_warnings(text), do: Spiral.Cells.Domain.gleam_strip_warnings(text)

  @spec tool_stamp(map(), keyword()) :: [term()] | nil
  def tool_stamp(%{tool: :wgsl}, opts), do: [{:wgsl_tools, Enum.map([Domain.tool("wgsl_run", opts), Domain.tool("naga", opts)], &file_stamp/1)}]
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
      case Domain.tool("wgsl_run", opts) do
        nil ->
          {:error, Spiral.Cells.Domain.process_error("`spiral-wgsl` was not found", nil, nil, :tool_missing)}

        runner ->
          runner |> run_status("spiral-wgsl", [path], opts, timeout, deadline, false) |> classified("spiral-wgsl", @wgsl_no_adapter, "found no GPU adapter")
      end
    end
  end

  defp naga_check(path, opts, timeout, deadline) do
    case Domain.tool("naga", opts) do
      nil ->
        :ok

      naga ->
        case run_program(naga, "naga", [path], opts, timeout, deadline, false) do
          {:ok, _} -> :ok
          error -> error
        end
    end
  end

  defp run_program(exe, shown, args, opts, timeout, deadline, spiral?),
    do: exe |> run_status(shown, args, opts, timeout, deadline, spiral?) |> classified(shown, 0, "")

  defp classified({:ok, %{exit_status: status, output: output}}, shown, unsupported, note) do
    case Spiral.Cells.Domain.run_outcome(shown, unsupported, note, status, output) do
      {:ran, _} -> {:ok, %{exit_status: 0, output: output}}
      {:missing, message} -> {:error, Spiral.Cells.Domain.process_error(message, status, output, :tool_missing)}
      {:failed, message} -> {:error, Spiral.Cells.Domain.process_error(message, status, output, nil)}
    end
  end

  defp classified({:error, %ProcessError{reason: :not_found} = error}, _shown, _unsupported, _note), do: {:error, %ProcessError{error | reason: :tool_missing}}
  defp classified(other, _shown, _unsupported, _note), do: other

  defp run_status(exe, shown, args, opts, timeout, deadline, spiral?) do
    cond do
      not is_binary(exe) ->
        {:error, Spiral.Cells.Domain.process_error("`#{shown}` was not found", nil, nil, :not_found)}

      not File.regular?(exe) and is_nil(System.find_executable(exe)) ->
        {:error, Spiral.Cells.Domain.process_error("`#{shown}` was not found at #{exe}", nil, nil, :not_found)}

      true ->
        last = List.last(args)

        cwd =
          case Spiral.Cells.Domain.run_cwd_choice(
                 spiral?,
                 notebook_dir?(opts[:root]),
                 is_binary(opts[:cwd]),
                 args == [],
                 is_binary(last) and File.regular?(last)
               ) do
            0 -> opts[:root]
            1 -> nil
            2 -> opts[:cwd]
            3 -> Path.dirname(exe)
            4 -> Path.dirname(last)
          end

        case Runner.run(exe, args,
               timeout: budget(deadline),
               cd: cwd,
               env: tool_env(opts, spiral?)
             ) do
          {:ok, %{exit_status: status, output: output}} ->
            {:ok, %{exit_status: status, output: output}}

          {:error, {:timeout, info}} ->
            {:error, timeout_error(info, timeout)}

          {:error, reason} ->
            {:error, Spiral.Cells.Domain.process_error("could not start `#{shown}`: #{inspect(reason)}", nil, nil, nil)}
        end
    end
  end

  defp cell_exit(ran) do
    %{exit_status: ran.exit_status, output: ran.output}
  end

  defp normalize({:ok, %{exit_status: 0, output: output} = ran}, present?) do
    text = if present?, do: present(output), else: output
    {:ok, Spiral.Cells.Domain.shown_map(text, ran[:value])}
  end

  defp normalize({:ok, %{stdout: stdout}}, _present?) when is_binary(stdout) do
    {:ok, %{stdout: stdout}}
  end

  defp normalize({:ok, %{exit_status: status, output: output}}, _present?) do
    {:error,
     Spiral.Cells.Domain.process_error(
       Spiral.Cells.Domain.builder_failed_text(Integer.to_string(status), output),
       status,
       output,
       nil
     )}
  end

  defp normalize({:error, {:timeout, info}}, _present?),
    do: {:error, timeout_error(info, info.timeout)}

  defp normalize({:error, %TimeoutError{} = error}, _present?), do: {:error, error}
  defp normalize({:error, %ProcessError{} = error}, _present?), do: {:error, error}

  defp normalize({:error, reason}, _present?) do
    {:error, Spiral.Cells.Domain.process_error("could not run the builder: #{inspect(reason)}", nil, nil, nil)}
  end

  defp present(output), do: Spiral.Cells.Domain.builder_present(output)

  defp tool_env(opts, spiral?), do: Spiral.Cells.Domain.tool_env(test_name(opts), spiral?)

  defp test_name(opts), do: if(is_binary(opts[:test_name]), do: opts[:test_name], else: "")

  @doc false
  def with_test_name(env, opts), do: Spiral.Cells.Domain.env_with_test_name(env, test_name(opts))

  @doc false
  def without_cupy_cuda_path_warning(env), do: Spiral.Cells.Domain.env_without_cupy(env)

  defp read_if(path) do
    case File.read(path) do
      {:ok, text} -> text
      _ -> ""
    end
  end

  defp invoke(nil, _ctx, default), do: default.()
  defp invoke(fun, ctx, _default) when is_function(fun, 1), do: fun.(ctx)

  @spec c_args(String.t(), String.t(), String.t(), String.t() | nil) :: [String.t()]
  def c_args(cc, source, exe, notebook_dir) do
    String.split(Spiral.Cells.Domain.c_args(Path.basename(cc), exe, source, c_shim(notebook_dir)), "\n")
  end

  defp c_shim(nil), do: ""
  defp c_shim(dir), do: if(File.regular?(shim = Path.join(dir, "c-shim.h")), do: shim, else: "")

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

  defp budget(deadline), do: Spiral.Cells.Domain.budget_remaining(deadline, System.monotonic_time(:millisecond))

  @doc false
  def timeout_error(%{output: output}, timeout) do
    message = Spiral.Cells.Domain.cell_timeout_text("Spiral", budget_ms(timeout), Spiral.Cells.Domain.scale_note(), "")
    Spiral.Cells.Domain.timeout_error(message, timeout, output)
  end

  @doc false
  def budget_ms(timeout), do: if(timeout == :infinity, do: -1, else: timeout)
end
