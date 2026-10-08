defmodule Spiral.Kino do
  alias Spiral.Kino.{
    Builders,
    Cell,
    CompilerClient,
    Directives,
    Display,
    Mounts,
    ProcessError,
    Result,
    Runner,
    SpiralError,
    Targets,
    TimeoutError,
    Toolchain
  }

  @default_timeout 300_000
  @default_workspace_root Path.expand("../../../..", __DIR__)

  @spec run(String.t(), keyword()) :: {:ok, Result.t()} | {:error, Exception.t()}
  def run(code, opts \\ []) when is_binary(code) do
    if String.trim(code) == "" do
      {:ok, %Result{}}
    else
      timeout = opts[:timeout] || @default_timeout
      validate_timeout!(timeout)
      prepared = code |> Spiral.Kino.Lisp.expand(opts) |> Directives.prepare(opts)

      builders = cell_builders(opts, prepared)

      prepared =
        if Enum.all?(builders, &Builders.host_rust?/1), do: own_main(prepared), else: prepared

      if prepared.skip or Enum.any?(builders, &(&1.tool == :skip)) do
        {:ok, %Result{exit_status: 0, source: code, duration_ms: 0}}
      else
        builders = if builders == [], do: [Builders.default()], else: builders

        timeout = prepared.timeout || timeout
        started = System.monotonic_time(:millisecond)

        deadline =
          case timeout do
            :infinity -> :infinity
            ms -> started + ms
          end

        dir = tmp_dir()
        Process.put(:spiral_kino_deadline, deadline)
        Process.put(:spiral_kino_phases, %{})

        try do
          spi = Path.join(dir, "main.spi")
          exe = Path.join(dir, exe_name())

          with {:ok, names, package_dir} <-
                 mount_packages(dir, prepared.packages, opts[:root], workspace_root(opts)),
               :ok <- write_package(dir, names, package_dir, opts[:real]) do
            run_builders(builders, dir, spi, exe, prepared, opts, timeout, deadline, started)
          end
        after
          Process.put(:spiral_kino_last_phases, phases())
          Process.delete(:spiral_kino_deadline)
          Process.delete(:spiral_kino_queue_ms)
          Process.delete(:spiral_kino_phases)
          unless opts[:keep_files], do: File.rm_rf(dir)
        end
      end
    end
  end

  @spec eval!(String.t(), keyword()) :: Result.t() | atom()
  def eval!(code, opts \\ []) do
    if String.trim(code) == "" do
      Kino.nothing()
    else
      case run(code, opts) do
        {:ok, result} ->
          show(result)
          if result.value, do: result, else: Kino.nothing()

        {:error, %SpiralError{result: result} = error} ->
          if result, do: show(result)
          raise error

        {:error, error} ->
          raise error
      end
    end
  end

  @spec last_phases() :: map()
  def last_phases, do: Process.get(:spiral_kino_last_phases) || %{}

  @spec package_path(String.t(), String.t() | nil, String.t() | nil) :: String.t()
  def package_path(path, root, workspace) when is_binary(path) do
    expanded = expand_package(path, root)

    if package_project?(expanded) do
      expanded
    else
      alt = expand_package(path, workspace)
      if package_project?(alt), do: alt, else: expanded
    end
  end

  @spec workspace_root(keyword()) :: String.t()
  def workspace_root(opts \\ []) do
    opts[:workspace_root] || opts[:polyglot_root] ||
      Application.get_env(:spiral_kino, :workspace_root) ||
      Application.get_env(:spiral_kino, :polyglot_root) ||
      System.get_env("SPIRAL_KINO_WORKSPACE_ROOT") ||
      System.get_env("SPIRAL_KINO_POLYGLOT_ROOT") ||
      @default_workspace_root
  end

  defp show(%Result{stdout: stdout, html: html, displays: displays}) do
    if stdout != "" do
      IO.write(if String.ends_with?(stdout, "\n"), do: stdout, else: stdout <> "\n")
    end

    Enum.each(html, &Kino.render(Kino.HTML.new(&1)))
    Enum.each(displays, &Kino.render(display_kino(&1)))
  end

  @doc false
  def display_kino(%{mime: "text/html", data: data}), do: Kino.HTML.new(data)
  def display_kino(%{mime: "image/" <> _ = mime, data: data}), do: Kino.Image.new(data, mime)
  def display_kino(%{data: data}), do: Kino.Text.new(data)

  defp cell_builders(opts, prepared) do
    if Keyword.has_key?(opts, :builders), do: opts[:builders], else: prepared.builders
  end

  defp run_builders(builders, dir, spi, exe, prepared, opts, timeout, deadline, started) do
    builders
    |> Enum.reduce_while({:ok, []}, fn builder, {:ok, acc} ->
      case run_builder(builder, dir, spi, exe, prepared, opts, timeout, deadline) do
        {:ok, %{exit_status: status} = chunk} when status not in [nil, 0] ->
          {:halt, {:done, acc ++ [chunk]}}

        {:ok, chunk} ->
          {:cont, {:ok, acc ++ [chunk]}}

        {:error, error} ->
          {:halt, {:error, error}}
      end
    end)
    |> case do
      {:ok, chunks} -> {:ok, assemble(chunks, spi, started)}
      {:done, chunks} -> {:ok, assemble(chunks, spi, started)}
      {:error, error} -> {:error, error}
    end
  end

  defp run_builder(builder, dir, spi, exe, prepared, opts, timeout, deadline) do
    output = Path.join(dir, "main" <> Builders.ext(builder))
    backend = Builders.backend(builder)
    host = Builders.host_rust?(builder)
    File.write!(spi, prepared.code)

    with {:ok, text, show_value} <-
           timed(:compile_ms, fn ->
             compile(dir, spi, output, backend, host, builder, prepared, opts, timeout, deadline)
           end) do
      if host do
        in_slot(fn ->
          run_host_rust(text, show_value, output, exe, prepared, opts, timeout, deadline)
        end)
      else
        File.write!(
          output,
          if(backend == "Python + Cuda", do: Cell.patch_python(text), else: text)
        )

        case in_slot(fn ->
               timed(:target_ms, fn -> Targets.run(builder, output, opts, timeout, deadline) end)
             end) do
          {:ok, %{stdout: stdout} = ran} ->
            {displays, stdout} = Display.extract(stdout)

            {:ok,
             chunk(
               builder,
               shown_stdout(prepared, text, stdout),
               Map.get(ran, :value),
               0,
               displays
             )}

          other ->
            other
        end
      end
    end
  end

  defp in_slot(fun) do
    {result, _waited} = Spiral.Kino.Slots.run(fun, on_wait: &add_phase(:slot_wait_ms, &1))
    result
  end

  defp timed(name, fun) do
    started = System.monotonic_time(:millisecond)

    try do
      fun.()
    after
      add_phase(name, System.monotonic_time(:millisecond) - started)
    end
  end

  defp add_phase(name, ms) when is_integer(ms) and ms >= 0 do
    case Process.get(:spiral_kino_phases) do
      %{} = phases ->
        Process.put(:spiral_kino_phases, Map.update(phases, name, ms, &(&1 + ms)))

        if name in [:slot_wait_ms, :queue_ms] do
          case Process.get(:spiral_kino_deadline) do
            deadline when is_integer(deadline) ->
              Process.put(:spiral_kino_deadline, deadline + ms)

            _ ->
              :ok
          end
        end

        :ok

      _ ->
        :ok
    end
  end

  defp add_phase(_name, _ms), do: :ok

  defp run_host_rust(text, show_value, rs, exe, prepared, opts, timeout, deadline) do
    rust = timed(:patch_ms, fn -> Cell.patch_rust(text, show_value) end)

    with :ok <- reject_unpatched(rust),
         :ok <- File.write(rs, rust),
         :ok <- timed(:rustc_ms, fn -> rustc(rs, exe, opts, timeout, deadline) end),
         {:ok, ran} <- timed(:run_ms, fn -> execute(exe, opts, timeout, deadline) end) do
      {value, stdout} = Cell.split_output(ran.output)
      {displays, stdout} = Display.extract(stdout)
      {value, value_displays} = Display.from_value(value, opts)

      {:ok,
       chunk(
         Builders.default(),
         shown_stdout(prepared, rust, stdout),
         value,
         ran.exit_status,
         displays ++ value_displays
       )}
    end
  end

  defp chunk(builder, stdout, value, status, displays) do
    %{
      ext: String.trim_leading(Builders.ext(builder), "."),
      tool: builder.tool,
      stdout: stdout,
      value: value,
      exit_status: status,
      displays: displays
    }
  end

  defp shown_stdout(prepared, generated, stdout) do
    if prepared.print_code do
      generated <> if(stdout == "", do: "", else: "\n" <> stdout)
    else
      stdout
    end
  end

  defp assemble(chunks, spi, started) do
    value =
      Enum.reduce(chunks, nil, fn chunk, acc ->
        if is_nil(chunk.value), do: acc, else: chunk.value
      end)

    status =
      Enum.find_value(chunks, 0, fn chunk ->
        if chunk.exit_status not in [nil, 0], do: chunk.exit_status
      end)

    stdout =
      case chunks do
        [one] ->
          one.stdout

        many ->
          Enum.map_join(many, "\n", fn chunk ->
            ".#{chunk.ext} (#{chunk.tool})\n" <> chunk.stdout
          end)
      end

    %Result{
      value: value,
      stdout: stdout,
      displays: Enum.flat_map(chunks, & &1.displays),
      source: File.read!(spi),
      exit_status: status,
      duration_ms: System.monotonic_time(:millisecond) - started,
      phases: phases()
    }
  end

  defp phases do
    phases = Process.get(:spiral_kino_phases) || %{}

    case phases do
      %{compile_ms: compile, queue_ms: queue} -> %{phases | compile_ms: max(compile - queue, 0)}
      _ -> phases
    end
  end

  defp compile(dir, spi, output, backend, host, builder, prepared, opts, timeout, deadline) do
    compile(
      dir,
      spi,
      output,
      backend,
      host,
      builder,
      prepared,
      opts,
      timeout,
      deadline,
      1,
      not Map.get(prepared, :no_value, false)
    )
  end

  defp compile(
         dir,
         spi,
         output,
         backend,
         host,
         builder,
         prepared,
         opts,
         timeout,
         deadline,
         attempt,
         show_value
       ) do
    case invoke(
           opts[:compile],
           %{
             source: File.read!(spi),
             spi_path: spi,
             rs_path: output,
             output_path: output,
             backend: backend,
             builder: builder,
             attempt: attempt
           },
           fn ->
             compile_default(spi, output, backend, opts, timeout, deadline)
           end
         ) do
      {:ok, text} ->
        {:ok, text, show_value}

      {:error, %TimeoutError{} = error} ->
        {:error, error}

      {:error, %ProcessError{} = error} ->
        {:error, error}

      {:error, output_text} ->
        retry = fn code ->
          File.write!(spi, code)

          compile(
            dir,
            spi,
            output,
            backend,
            host,
            builder,
            prepared,
            opts,
            timeout,
            deadline,
            2,
            false
          )
        end

        cond do
          attempt == 1 and prepared.generated_main and
              Cell.unit_result?(restore_type_lines(output_text)) ->
            retry.(String.trim_trailing(File.read!(spi), "\n") <> "\n    0i32\n")

          attempt == 1 and prepared.generated_main and
              value_result?(output_text, File.read!(spi)) ->
            retry.(show_value_main(File.read!(spi)))

          true ->
            {:error, %SpiralError{message: clean(output_text, dir), details: File.read!(spi)}}
        end
    end
  end

  @main_head "inl main () : i32 =\n"

  @doc false
  def own_main(%{generated_main: false, code: code} = prepared) do
    case Regex.run(~r/^(?:let|inl) main \(\) =[ \t]*$/m, code, return: :index)
         |> last_main(code) do
      nil ->
        prepared

      {at, len} ->
        renamed =
          binary_part(code, 0, at) <>
            "inl spiral_kino_main () =" <> binary_part(code, at + len, byte_size(code) - at - len)

        %{
          prepared
          | code:
              String.trim_trailing(renamed) <> "\n\n" <> @main_head <> "    spiral_kino_main ()\n",
            generated_main: true,
            no_value: false
        }
    end
  end

  def own_main(prepared), do: prepared

  defp last_main(nil, _code), do: nil

  defp last_main(_first, code) do
    [{at, len} | _] =
      ~r/^(?:let|inl) main \(\) =[ \t]*$/m |> Regex.scan(code, return: :index) |> List.last()

    rest = binary_part(code, at + len, byte_size(code) - at - len)

    if rest |> String.split("\n") |> Enum.all?(&(&1 == "" or String.starts_with?(&1, " "))),
      do: {at, len},
      else: nil
  end

  @doc false
  def value_result?(output, code) do
    case :binary.matches(code, @main_head) do
      [] ->
        false

      matches ->
        {at, _} = List.last(matches)

        head = code |> binary_part(0, at) |> String.split("\n") |> length()
        last = code |> String.trim_trailing() |> String.split("\n") |> length()

        case Regex.scan(~r/main\.spi:(\d+):(\d+): (Unification failure\.)?/, output) do
          [[_, line, column, "Unification failure."]] ->
            line = String.to_integer(line)

            line > head and (column == "5" or line == last) and
              (output =~ ~r/Got:\s*i32\b|Expected:\s*i32\b/ or i32_stage?(output))

          _ ->
            false
        end
    end
  end

  defp i32_stage?(output) do
    case Regex.run(~r/Got:\s*(.*?)\s*Expected:\s*([^\n]*)/s, output) do
      [_, got, expected] ->
        same_stage?(String.trim(got), String.trim(expected)) or
          same_stage?(String.trim(expected), String.trim(got))

      _ ->
        false
    end
  end

  defp same_stage?(i32_side, other) do
    if String.ends_with?(i32_side, " -> i32") do
      prefix = String.replace_suffix(i32_side, " -> i32", " -> ")
      String.starts_with?(other, prefix) and other != i32_side
    else
      false
    end
  end

  @doc false
  def show_value_main(code) do
    {at, len} = code |> :binary.matches(@main_head) |> List.last()
    head = binary_part(code, 0, at + len)
    body = binary_part(code, at + len, byte_size(code) - at - len) |> String.trim_trailing()

    indented =
      body
      |> String.split("\n")
      |> Enum.map_join("\n", fn line ->
        if String.trim(line) == "", do: "", else: "    " <> line
      end)

    head <>
      "    inl spiral_kino_value =\n" <>
      indented <> "\n    console.show_value spiral_kino_value\n    0i32\n"
  end

  defp compile_default(spi, output, backend, opts, timeout, deadline) do
    with :ok <- require_tool(Toolchain.dotnet(opts), "dotnet"),
         :ok <- require_file(Toolchain.compiler_dll(opts), "Spiral compiler"),
         :ok <-
           require_file(
             Path.join(Toolchain.package_dir(opts), "core/package.spiproj"),
             "Spiral core package"
           ) do
      if shared_compiler?(opts) do
        shared_compile(spi, output, backend, opts, timeout, deadline)
      else
        one_shot_compile(spi, output, backend, opts, timeout, deadline)
      end
    end
  end

  defp shared_compiler?(opts) do
    System.get_env("SPIRAL_KINO_COMPILER") != "process" and opts[:compiler_dll] == nil and
      opts[:dotnet] == nil and opts[:package_dir] == nil and opts[:workspace] == nil and
      opts[:env] == nil
  end

  defp shared_compile(spi, output, backend, opts, timeout, deadline) do
    case CompilerClient.compile(%{
           spi: spi,
           rs: output,
           timeout: budget(deadline),
           mtime: source_mtime(spi, opts),
           backend: backend
         }) do
      {:ok, _revision} ->
        charge_queue()
        {:ok, File.read!(output)}

      {:error, :timeout} ->
        charge_queue()
        {:error, timeout_error(%{output: ""}, timeout)}

      {:error, %ProcessError{} = error} ->
        charge_queue()
        {:error, error}

      {:error, message} ->
        charge_queue()
        {:error, message}
    end
  end

  defp charge_queue do
    queue = Process.delete(:spiral_kino_queue_ms) || 0

    case Process.get(:spiral_kino_phases) do
      %{} ->
        add_phase(:queue_ms, queue)

      _ ->
        case Process.get(:spiral_kino_deadline) do
          ms when is_integer(ms) -> Process.put(:spiral_kino_deadline, ms + queue)
          _ -> :ok
        end
    end
  end

  defp one_shot_compile(spi, output, backend, opts, timeout, deadline) do
    dotnet = Toolchain.dotnet(opts)

    case Runner.run(dotnet, [Toolchain.compiler_dll(opts), "--backend", backend, spi, output],
           timeout: budget(deadline),
           env: compiler_env(opts, dotnet)
         ) do
      {:ok, %{exit_status: 0}} ->
        {:ok, File.read!(output)}

      {:ok, %{output: text}} ->
        {:error, text}

      {:error, {:timeout, info}} ->
        {:error, timeout_error(info, timeout)}

      {:error, reason} ->
        {:error,
         %ProcessError{message: "could not start the Spiral compiler: #{inspect(reason)}"}}
    end
  end

  defp source_mtime(spi, opts) do
    dirs =
      case File.read(Path.join(Path.dirname(spi), "package.spiproj")) do
        {:ok, text} ->
          case Regex.run(~r/^packageDir:\s*(.+)$/m, text) do
            [_, dir] ->
              dir = String.trim(dir)
              if Path.type(dir) == :absolute, do: [dir], else: []

            _ ->
              []
          end

        _ ->
          []
      end

    Enum.reduce([Path.join(Toolchain.package_dir(opts), "core") | dirs], 0, fn dir, acc ->
      max(acc, Mounts.newest(dir))
    end)
  end

  defp rustc(rs, exe, opts, timeout, deadline) do
    case invoke(opts[:rustc], %{rs_path: rs, exe_path: exe}, fn ->
           rustc_default(rs, exe, opts, timeout, deadline)
         end) do
      :ok -> :ok
      {:error, %TimeoutError{} = error} -> {:error, error}
      {:error, %ProcessError{} = error} -> {:error, error}
      {:error, output} -> {:error, %ProcessError{message: "rustc failed\n\n#{output}"}}
    end
  end

  defp rustc_default(rs, exe, opts, timeout, deadline) do
    with :ok <- require_tool(Toolchain.rustc(opts), "rustc") do
      case Runner.run(Toolchain.rustc(opts), ["--edition", "2021", "-o", exe, rs],
             timeout: budget(deadline),
             env: [{"CARGO_MANIFEST_DIR", Path.dirname(rs)}]
           ) do
        {:ok, %{exit_status: 0}} -> :ok
        {:ok, %{output: output}} -> {:error, output}
        {:error, {:timeout, info}} -> {:error, timeout_error(info, timeout)}
        {:error, reason} -> {:error, "could not start rustc: #{inspect(reason)}"}
      end
    end
  end

  defp execute(exe, opts, timeout, deadline) do
    cwd = opts[:root] || Path.dirname(exe)

    case invoke(opts[:execute], %{exe_path: exe, cwd: cwd}, fn ->
           Runner.run(exe, [], timeout: budget(deadline), cd: cwd)
         end) do
      {:ok, ran} ->
        {:ok, ran}

      {:error, {:timeout, info}} ->
        {:error, timeout_error(info, timeout)}

      {:error, %TimeoutError{} = error} ->
        {:error, error}

      {:error, reason} ->
        {:error, %ProcessError{message: "could not run the cell: #{inspect(reason)}"}}
    end
  end

  defp invoke(nil, _ctx, default), do: default.()
  defp invoke(fun, ctx, _default) when is_function(fun, 1), do: fun.(ctx)

  defp compiler_env(opts, dotnet) do
    [
      {"DOTNET_ROOT", Path.dirname(dotnet)},
      {"DOTNET_NOLOGO", "1"},
      {"DOTNET_CLI_TELEMETRY_OPTOUT", "1"},
      {"SPIRAL_WORKSPACE_ROOT", Toolchain.workspace(opts)},
      {"SPIRAL_COMPILER_PACKAGE_DIR", Toolchain.package_dir(opts)}
      | Keyword.get(opts, :env, [])
    ]
  end

  defp require_tool(nil, name), do: {:error, %ProcessError{message: "`#{name}` was not found"}}
  defp require_tool(path, name) when is_binary(path), do: require_file(path, name)

  defp require_file(path, name) do
    if File.regular?(path),
      do: :ok,
      else: {:error, %ProcessError{message: "#{name} was not found at #{path}"}}
  end

  defp reject_unpatched(rust) do
    if String.contains?(rust, "__spiral_emit_rust") or String.contains?(rust, "emitRustExpr") do
      {:error,
       %ProcessError{message: "generated Rust still holds an emit marker (__spiral_emit_rust)"}}
    else
      :ok
    end
  end

  defp budget(:infinity), do: :infinity

  defp budget(deadline) do
    deadline =
      case Process.get(:spiral_kino_deadline) do
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
      message: "Spiral cell timed out after #{format_ms(timeout)}; the process tree was killed.",
      timeout: timeout,
      output: output
    }
  end

  defp restore_type_lines(output) do
    String.replace(output, ~r/(Got:[^\n]*) Expected:/, "\\1\nExpected:")
  end

  defp clean(output, dir) do
    prefix = String.trim_trailing(Path.expand(dir), "/\\")

    output
    |> String.replace(prefix <> "/", "")
    |> String.replace(prefix <> "\\", "")
    |> String.replace(String.replace(prefix, "\\", "/"), "")
    |> String.trim()
  end

  defp write_package(dir, names, package_dir, real) do
    text = Cell.package_project(names)

    text =
      if package_dir do
        String.replace(text, "packageDir: .", "packageDir: " <> package_dir, global: false)
      else
        text
      end

    text =
      if real in [nil, ""] do
        text
      else
        File.write!(Path.join(dir, "main_real.spir"), String.trim_trailing(real) <> "\n")
        String.replace(text, ~r/^    main$/m, "    main_real*-\n    main", global: false)
      end

    File.write!(Path.join(dir, "package.spiproj"), text)
    File.write!(Path.join(dir, "console.spi"), Cell.console_source())
    :ok
  end

  defp mount_packages(_dir, [], _root, _workspace), do: {:ok, [], nil}

  defp mount_packages(_dir, paths, root, workspace) do
    targets =
      Enum.map(paths, fn path ->
        target = resolve_package(path, root, workspace)
        {target, Path.basename(target)}
      end)

    sibling_names = Enum.map(targets, &elem(&1, 1))

    case mount_entries(targets, sibling_names) do
      {:ok, entries} ->
        case Mounts.ensure(entries) do
          {:ok, package_dir} -> {:ok, Enum.map(entries, & &1.name), package_dir}
          {:error, message} -> {:error, %ProcessError{message: message}}
        end

      error ->
        error
    end
  end

  defp mount_entries(targets, sibling_names) do
    Enum.reduce_while(targets, {:ok, []}, fn {target, name}, {:ok, entries} ->
      cond do
        name in ["", "console", "main", "ready"] ->
          {:halt,
           {:error, %ProcessError{message: "package name #{inspect(name)} clashes with the cell"}}}

        Enum.any?(entries, &(&1.name == name)) ->
          {:halt, {:error, %ProcessError{message: "package #{name} is listed twice"}}}

        not File.regular?(Path.join(target, "package.spiproj")) ->
          {:halt, {:error, %ProcessError{message: "Spiral package was not found at #{target}"}}}

        true ->
          kind = if Mounts.share_mounted_deps?(target, sibling_names), do: :shadow, else: :link
          {:cont, {:ok, entries ++ [%{name: name, target: target, kind: kind}]}}
      end
    end)
  end

  defp resolve_package(path, root, workspace), do: package_path(path, root, workspace)

  defp expand_package(path, root) when is_binary(root), do: Path.expand(path, root)
  defp expand_package(path, _root), do: Path.expand(path)

  defp package_project?(path), do: File.regular?(Path.join(path, "package.spiproj"))

  defp exe_name, do: if(match?({:win32, _}, :os.type()), do: "cell.exe", else: "cell")

  defp tmp_dir do
    dir =
      Path.join([
        System.tmp_dir!(),
        "spiral_kino",
        "#{System.os_time(:millisecond)}-#{System.unique_integer([:positive])}"
      ])

    File.mkdir_p!(dir)
    dir
  end

  defp validate_timeout!(:infinity), do: :ok
  defp validate_timeout!(ms) when is_integer(ms) and ms > 0, do: :ok

  defp validate_timeout!(other) do
    raise ArgumentError,
          "expected :timeout to be a positive integer (ms) or :infinity, got: #{inspect(other)}"
  end

  defp format_ms(:infinity), do: "infinity"
  defp format_ms(ms) when rem(ms, 1000) == 0, do: "#{div(ms, 1000)}s"
  defp format_ms(ms), do: "#{ms}ms"
end
