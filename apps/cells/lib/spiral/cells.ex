defmodule Spiral.Cells do
  alias Spiral.Cells.{
    CompilerClient,
    Domain,
    Mounts,
    ProcessError,
    Runner,
    SpiralError,
    Targets,
    TimeoutError
  }

  @default_timeout 300_000
  @default_workspace_root Path.expand("../../../..", __DIR__)
  @external_resource Path.expand("cells/console.spi", __DIR__)
  @console File.read!(Path.expand("cells/console.spi", __DIR__))

  @spec run(String.t(), keyword()) :: {:ok, map()} | {:error, Exception.t()}
  def run(code, opts \\ []) when is_binary(code) do
    Process.put(:spiral_cells_last_targets, [])

    if String.trim(code) == "" do
      {:ok, Domain.result_new(%{exit_status: 0, duration_ms: 0})}
    else
      timeout = opts[:timeout] || Domain.scale_budget(@default_timeout)
      validate_timeout!(timeout)
      prepared = Spiral.Cells.Domain.lisp_transpile(code, Spiral.Cells.Domain.tool("spl2spi", opts) || "") |> Domain.prepare_run(opts)

      case cell_builders(opts, prepared) do
        [] -> {:error, Spiral.Cells.Domain.cells_spiral_error(untargeted_cell_message(), nil, nil)}
        builders -> run_targeted(builders, prepared, opts, timeout)
      end
    end
  end

  @spec untargeted_cell_message() :: String.t()
  def untargeted_cell_message, do: "NoTestTarget: the cell names no target: add a ///> <lang> line to it"

  defp run_targeted(builders, prepared, opts, timeout) do
    prepared =
      if Enum.all?(builders, &Spiral.Cells.Domain.builders_host_rust/1), do: own_main(prepared), else: prepared

    timeout = prepared.timeout || timeout
    started = System.monotonic_time(:millisecond)

    deadline =
      case timeout do
        :infinity -> :infinity
        ms -> started + ms
      end

    dir = tmp_dir()
    Process.put(:spiral_cells_deadline, deadline)
    Process.put(:spiral_cells_phases, %{})
    Process.put(:spiral_cells_targets, [])

    try do
      spi = Path.join(dir, "main.spi")
      exe = Path.join(dir, exe_name())

      with {:ok, names, imports, package_dir} <-
             timed(:mount_ms, fn -> mount_packages(dir, prepared.packages, opts[:root], workspace_root(opts), opts[:patches] || []) end),
           :ok <- timed(:mount_ms, fn -> write_package(dir, names, imports, package_dir, opts[:real]) end) do
        run_builders(builders, dir, spi, exe, prepared, opts, timeout, deadline, started)
      end
    after
      unless opts[:keep_files], do: timed(:cleanup_ms, fn -> File.rm_rf(dir) end)
      Process.put(:spiral_cells_last_phases, phases())
      Process.put(:spiral_cells_last_targets, target_rows(builders, Process.delete(:spiral_cells_targets) || []))
      Process.delete(:spiral_cells_deadline)
      Process.delete(:spiral_cells_queue_ms)
      Process.delete(:spiral_cells_phases)
    end
  end

  @spec eval!(String.t(), keyword()) :: term()
  def eval!(code, opts \\ []) do
    if String.trim(code) == "" do
      Kino.nothing()
    else
      case run(code, opts) do
        {:ok, result} ->
          show(result)
          if result.value, do: Kino.Text.new(result.value, terminal: true), else: Kino.nothing()

        {:error, %SpiralError{result: result} = error} ->
          if result, do: show(result)
          raise error

        {:error, error} ->
          raise error
      end
    end
  end

  @spec last_targets() :: [%{target: String.t(), status: String.t(), ms: non_neg_integer() | nil}]
  def last_targets, do: Process.get(:spiral_cells_last_targets) || []

  defp target_rows(builders, ran) do
    Enum.map(builders, fn builder ->
      Enum.find(ran, &(&1.target == builder.raw)) || %{target: builder.raw, status: "not_run", ms: nil}
    end)
  end

  defp record_target(builder, result, ms), do: Spiral.Cells.Domain.record_target(builder.raw, result, ms)

  @spec last_phases() :: map()
  def last_phases, do: Process.get(:spiral_cells_last_phases) || %{}

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
    opts[:workspace_root] || Application.get_env(:spiral_cells, :workspace_root) ||
      System.get_env("SPIRAL_CELLS_WORKSPACE_ROOT") || @default_workspace_root
  end

  defp show(%{stdout: stdout, html: html, displays: displays}) do
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
    |> Enum.reduce_while({:ok, [], []}, fn builder, {:ok, acc, missing} ->
      begun = System.monotonic_time(:millisecond)

      case record_target(builder, run_builder(builder, dir, spi, exe, prepared, opts, timeout, deadline), System.monotonic_time(:millisecond) - begun) do
        {:ok, %{exit_status: status} = chunk} when status not in [nil, 0] ->
          {:halt, {:done, acc ++ [chunk], missing}}

        {:ok, chunk} ->
          {:cont, {:ok, acc ++ [chunk], missing}}

        {:error, %ProcessError{reason: :tool_missing} = error} ->
          {:cont, {:ok, acc, missing ++ [{builder, error}]}}

        {:error, error} ->
          {:halt, {:error, error}}
      end
    end)
    |> case do
      {_, [], [{_builder, error} | _]} -> {:error, error}
      {:ok, chunks, missing} -> agreed(chunks, prepared, opts, fn -> {:ok, assemble(chunks, missing, spi, started)} end)
      {:done, chunks, missing} -> {:ok, assemble(chunks, missing, spi, started)}
      {:error, error} -> {:error, error}
    end
  end

  defp agreed(chunks, prepared, opts, assembled) do
    case disagreement(chunks, prepared, opts) do
      nil ->
        assembled.()

      {first, other} ->
        Spiral.Cells.Domain.disagree_result(first, other, opts[:reference] != nil)
    end
  end

  defp disagreement(chunks, prepared, opts), do: Spiral.Cells.Domain.disagreement(chunks, prepared.print_code, opts[:agree] == true, opts[:reference])

  @doc false
  def shown(chunk), do: Spiral.Cells.Domain.shown_text(chunk.stdout)

  @doc false
  def canonical_unions(line), do: Spiral.Cells.Domain.canonical_unions(line)

  @doc false
  def canonical_collections(line), do: Spiral.Cells.Domain.canonical_collections(line)

  @doc false
  def target_output(dir, %{tool: :gleam} = builder) do
    source_dir = Path.join([dir, "gleam", "src"])
    File.mkdir_p!(source_dir)
    Path.join(source_dir, "main" <> Domain.builders_ext(builder))
  end

  def target_output(dir, builder), do: Path.join(dir, "main" <> Domain.builders_ext(builder))

  defp run_builder(builder, dir, spi, exe, prepared, opts, timeout, deadline) do
    output = target_output(dir, builder)
    backend = Domain.builders_backend(builder)
    host = Domain.builders_host_rust(builder)
    File.write!(spi, prepared.code)

    with {:ok, text, show_value} <-
           timed(:compile_ms, fn ->
             compile(dir, spi, output, backend, host, builder, prepared, opts, timeout, deadline)
           end) do
      code_parts =
        [builder.raw, backend, host, text, show_value, prepared.print_code, opts[:build_only], opts[:test_cell], opts[:root]] ++
          List.wrap(Targets.tool_stamp(builder, opts))
      looked_up = System.monotonic_time(:millisecond)

      {result, memo} =
        Spiral.Cells.Domain.memo_code_result(opts, code_parts, fn ->
          run_compiled(builder, output, backend, host, text, show_value, exe, prepared, opts, timeout, deadline)
        end)

      if memo == :hit, do: add_phase(:code_memo_hit_ms, System.monotonic_time(:millisecond) - looked_up)
      result
    end
  end

  defp run_compiled(builder, output, backend, host, text, show_value, exe, prepared, opts, timeout, deadline) do
      cond do
        opts[:build_only] == true ->
          in_slot(fn -> build_target(builder, host, text, show_value, output, exe, opts, timeout, deadline) end)

        host ->
          in_slot(fn ->
            run_host_rust(builder, text, show_value, output, exe, prepared, opts, timeout, deadline)
          end)

        true ->
          File.write!(
            output,
            if(backend == "Python + Cuda" and opts[:test_cell] != true, do: Spiral.Cells.Domain.python_patched(text), else: text)
          )

          case in_slot(fn ->
                 timed(:target_ms, fn -> Targets.run(builder, output, opts, timeout, deadline) end)
               end) do
            {:ok, %{stdout: stdout} = ran} ->
              {displays, stdout} = Spiral.Cells.Domain.extract(stdout)
              displays = Spiral.Cells.Domain.display_render_values(displays, opts)

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

  defp build_target(builder, true, text, show_value, rs, exe, opts, timeout, deadline) do
    rust = Spiral.Cells.Domain.patch_rust(text, if(show_value, do: "1", else: "0"))

    with :ok <- reject_unpatched(rust),
         :ok <- File.write(rs, rust),
         :ok <- timed(:rustc_ms, fn -> rustc(rs, exe, opts, timeout, deadline) end) do
      {:ok, chunk(builder, "built", nil, 0, [])}
    end
  end

  defp build_target(builder, false, text, _show_value, output, _exe, opts, timeout, deadline) do
    File.write!(output, text)

    case timed(:target_ms, fn -> Targets.build(builder, output, opts, timeout, deadline) end) do
      {:ok, _} -> {:ok, chunk(builder, "built", nil, 0, [])}
      error -> error
    end
  end

  defp in_slot(fun) do    {result, _waited} = Spiral.Cells.Domain.slots_run(fun, &add_phase(:slot_wait_ms, &1), nil)
    result
  end

  @doc false
  def timed(name, fun) do
    started = System.monotonic_time(:millisecond)

    try do
      fun.()
    after
      add_phase(name, System.monotonic_time(:millisecond) - started)
    end
  end

  defp add_phase(name, ms), do: Spiral.Cells.Domain.add_phase(name, ms)

  defp run_host_rust(builder, text, show_value, rs, exe, prepared, opts, timeout, deadline) do
    rust = timed(:patch_ms, fn -> Spiral.Cells.Domain.patch_rust(text, if(show_value, do: "1", else: "0")) end)

    with :ok <- reject_unpatched(rust),
         :ok <- File.write(rs, rust),
         :ok <- timed(:rustc_ms, fn -> rustc(rs, exe, opts, timeout, deadline) end),
         {:ok, ran} <- timed(:run_ms, fn -> execute(exe, opts, timeout, deadline) end) do
      {value, stdout} = Spiral.Cells.Domain.split_output(ran.output)
      {displays, stdout} = Spiral.Cells.Domain.extract(stdout)
      displays = Spiral.Cells.Domain.display_render_values(displays, opts)
      {value, value_displays} = Spiral.Cells.Domain.display_from_value(value, opts)

      {:ok,
       chunk(
         builder,
         shown_stdout(prepared, rust, stdout),
         value,
         ran.exit_status,
         displays ++ value_displays
       )}
    end
  end

  defp chunk(builder, stdout, value, status, displays) do
    %{
      target: builder.raw,
      ext: String.trim_leading(Domain.builders_ext(builder), "."),
      tool: builder.tool,
      stdout: stdout,
      value: value,
      exit_status: status,
      displays: displays
    }
  end

  defp shown_stdout(prepared, generated, stdout) do
    Spiral.Cells.Domain.shown_stdout(prepared.print_code, generated, stdout)
  end

  defp assemble(chunks, missing, spi, started), do: Spiral.Cells.Domain.with_missing(assemble(chunks, spi, started), missing)

  defp assemble(chunks, spi, started) do
    core = Spiral.Cells.Domain.assemble_core(chunks)

    Domain.result_new(%{
      value: core.value,
      stdout: core.stdout,
      displays: core.displays,
      source: File.read!(spi),
      exit_status: core.exit_status,
      duration_ms: System.monotonic_time(:millisecond) - started,
      phases: phases()
    })
  end

  defp phases do
    phases = Process.get(:spiral_cells_phases) || %{}

    case phases do
      %{compile_ms: compile, queue_ms: queue} -> %{phases | compile_ms: max(compile - queue, 0)}
      _ -> phases
    end
  end

  defp compile(dir, spi, output, backend, host, builder, prepared, opts, timeout, deadline) do
    show_value = not Map.get(prepared, :no_value, false)
    original = File.read!(spi)
    unit_first = Spiral.Cells.Domain.compile_unit_first(opts[:test_cell] == true, prepared.generated_main, original)

    if unit_first do
      File.write!(spi, String.trim_trailing(original, "\n") <> "\n    0i32\n")

      case compile(dir, spi, output, backend, host, builder, prepared, opts, timeout, deadline, 2, false) do
        {:ok, _, _} = compiled ->
          compiled

        {:error, %TimeoutError{}} = timed_out ->
          timed_out

        _ ->
          File.write!(spi, original)
          compile(dir, spi, output, backend, host, builder, prepared, opts, timeout, deadline, 1, show_value)
      end
    else
      compile(dir, spi, output, backend, host, builder, prepared, opts, timeout, deadline, 1, show_value)
    end
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
              Spiral.Cells.Domain.unit_result(restore_type_lines(output_text)) == "1" ->
            retry.(String.trim_trailing(File.read!(spi), "\n") <> "\n    0i32\n")

          attempt == 1 and prepared.generated_main and
              value_result?(output_text, File.read!(spi)) ->
            retry.(show_value_main(File.read!(spi)))

          true ->
            {:error, Spiral.Cells.Domain.cells_spiral_error(clean(output_text, dir), File.read!(spi), nil)}
        end
    end
  end

  @doc false
  def own_main(%{generated_main: false, code: code} = prepared) do
    case Spiral.Cells.Domain.own_main_code(code) do
      "" -> prepared
      owned -> %{prepared | code: owned, generated_main: true, no_value: false}
    end
  end

  def own_main(prepared), do: prepared

  @doc false
  def value_result?(output, code), do: Spiral.Cells.Domain.value_result(output, code)

  @doc false
  def show_value_main(code), do: Spiral.Cells.Domain.show_value_main(code)

  defp compile_default(spi, output, backend, opts, timeout, deadline) do
    with :ok <- require_tool(Domain.tool("dotnet", opts), "dotnet"),
         :ok <- require_file(Domain.tool("compiler_dll", opts), "Spiral compiler"),
         :ok <-
           require_file(
             Path.join(Domain.tool("package_dir", opts), "core/package.spiproj"),
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
    System.get_env("SPIRAL_CELLS_COMPILER") != "process" and opts[:compiler_dll] == nil and
      opts[:dotnet] == nil and opts[:package_dir] == nil and opts[:workspace] == nil and
      opts[:env] == nil
  end

  defp per_test_request(req, opts) do
    source = opts[:test_source]

    if System.get_env("SPIRAL_CELLS_PER_TEST_TRACE") == "1" do
      IO.puts(:stderr, "per-test trace / flag #{Domain.per_test_compile()} name #{inspect(opts[:test_name])} source #{inspect(source)} real #{inspect(opts[:real])} spi #{req.spi}")
    end

    if Domain.per_test_compile() and is_binary(opts[:test_name]) and is_binary(source) and
         String.ends_with?(source, ".spi") and opts[:real] in [nil, ""] and not Spiral.Cells.Domain.static_opens_sibling(File.read!(source), source |> Path.expand() |> Path.dirname() |> Path.join("*.spi") |> Path.wildcard() |> Enum.map_join("\n", &Path.basename(&1, ".spi"))) do
      req |> Map.merge(%{spi: Path.expand(source), mtime: source_mtime(Path.expand(source), opts)}) |> Map.put(:test, opts[:test_name])
    else
      req
    end
  end

  defp shared_compile(spi, output, backend, opts, timeout, deadline) do
    case CompilerClient.compile(per_test_request(%{
           spi: spi,
           rs: output,
           timeout: budget(deadline),
           mtime: source_mtime(spi, opts),
           backend: backend,
           pin: opts[:compiler_pin]
         }, opts)) do
      {:ok, _revision} ->
        charge_queue()
        {:ok, File.read!(output)}

      {:error, :timeout} ->
        charge_queue()
        {:error, Targets.timeout_error(%{output: ""}, timeout)}

      {:error, %ProcessError{} = error} ->
        charge_queue()
        {:error, error}

      {:error, message} ->
        charge_queue()
        {:error, message}
    end
  end

  defp charge_queue, do: Spiral.Cells.Domain.charge_queue()

  defp one_shot_compile(spi, output, backend, opts, timeout, deadline) do
    dotnet = Domain.tool("dotnet", opts)

    case Runner.run(dotnet, [Domain.tool("compiler_dll", opts), "--backend", backend, spi, output],
           timeout: budget(deadline),
           env: compiler_env(opts, dotnet)
         ) do
      {:ok, %{exit_status: 0}} ->
        {:ok, File.read!(output)}

      {:ok, %{output: text}} ->
        {:error, text}

      {:error, {:timeout, info}} ->
        {:error, Targets.timeout_error(info, timeout)}

      {:error, reason} ->
        {:error,
         Spiral.Cells.Domain.process_error("could not start the Spiral compiler: #{inspect(reason)}", nil, nil, nil)}
    end
  end

  defp source_mtime(spi, opts), do: Spiral.Cells.Domain.source_mtime_of(Path.join(Domain.tool("package_dir", opts), "core"), Spiral.Cells.Domain.manifest_read(Path.dirname(spi)))

  defp rustc(rs, exe, opts, timeout, deadline) do
    case invoke(opts[:rustc], %{rs_path: rs, exe_path: exe}, fn ->
           rustc_default(rs, exe, opts, timeout, deadline)
         end) do
      :ok -> :ok
      {:error, %TimeoutError{} = error} -> {:error, error}
      {:error, %ProcessError{} = error} -> {:error, error}
      {:error, output} -> {:error, Spiral.Cells.Domain.process_error("rustc failed\n\n#{output}", nil, nil, nil)}
    end
  end

  defp rustc_default(rs, exe, opts, timeout, deadline) do
    with :ok <- require_tool(Domain.tool("rustc", opts), "rustc"),
         :ok <- ensure_rust_toolchain(Domain.tool("rustc", opts), deadline) do
      case Runner.run(Domain.tool("rustc", opts), rustc_args(Domain.tool("rustc", opts), rs, exe),
             timeout: budget(deadline),
             env: [{"CARGO_MANIFEST_DIR", Path.dirname(rs)}]
           ) do
        {:ok, %{exit_status: 0}} -> :ok
        {:ok, %{output: output}} -> {:error, output}
        {:error, {:timeout, info}} -> {:error, Targets.timeout_error(info, timeout)}
        {:error, reason} -> {:error, "could not start rustc: #{inspect(reason)}"}
      end
    end
  end

  @rust_toolchain_file Path.expand("../../../../rust-toolchain.toml", __DIR__)
  @external_resource @rust_toolchain_file
  @rust_channel (case Regex.run(~r/^\s*channel\s*=\s*"([^"]+)"/m, File.read!(@rust_toolchain_file)) do
                   [_, channel] -> channel
                   _ -> raise "no channel in #{@rust_toolchain_file}"
                 end)
  @rust_toolchain "+" <> @rust_channel

  @spec rust_channel() :: String.t()
  def rust_channel, do: @rust_channel

  @spec rustc_args(String.t(), String.t(), String.t()) :: [String.t()]
  def rustc_args(rustc, rs, exe) do
    Spiral.Cells.Domain.rustc_args(rustup_proxy?(rustc), @rust_toolchain, exe, rs)
  end

  defp ensure_rust_toolchain(rustc, deadline) do
    ready = {__MODULE__, :rust_toolchain_ready}
    rustup = Path.join(Path.dirname(rustc), "rustup" <> Path.extname(rustc))

    cond do
      not rustup_proxy?(rustc) or not File.regular?(rustup) ->
        :ok

      :persistent_term.get(ready, false) ->
        :ok

      true ->
        :global.trans({ready, self()}, fn ->
          if :persistent_term.get(ready, false) do
            :ok
          else
            with :ok <- prepare_rust_toolchain({rustup, []}, budget(deadline)) do
              :persistent_term.put(ready, true)
            end
          end
        end)
    end
  end

  @doc false
  @spec prepare_rust_toolchain({String.t(), [String.t()]}, timeout()) :: :ok | {:error, ProcessError.t()}
  def prepare_rust_toolchain({rustup, prefix}, timeout) do
    version = String.trim_leading(@rust_toolchain, "+")

    with {:ok, listed} <- rustup_step(rustup, prefix ++ ["toolchain", "list"], timeout, "rustup toolchain list") do
      if listed |> String.split(["\r\n", "\n"]) |> Enum.any?(&String.starts_with?(&1, version <> "-")) do
        :ok
      else
        install = prefix ++ ["toolchain", "install", version, "--profile", "minimal", "--no-self-update"]

        with {:ok, _output} <- rustup_step(rustup, install, timeout, "rustup toolchain install #{version}"), do: :ok
      end
    end
  end

  defp rustup_step(rustup, args, timeout, label) do
    case Runner.run(rustup, args, timeout: timeout) do
      {:ok, %{exit_status: 0, output: output}} ->
        {:ok, output}

      {:ok, %{exit_status: status, output: output}} ->
        {:error, Spiral.Cells.Domain.process_error("#{label} failed (exit #{status}); Rust cells need the #{@rust_toolchain} toolchain\n\n#{String.slice(output, -2000, 2000)}", nil, nil, nil)}

      {:error, {:timeout, _info}} ->
        {:error, Spiral.Cells.Domain.process_error("#{label} did not finish within the cell's time budget", nil, nil, nil)}

      {:error, reason} ->
        {:error, Spiral.Cells.Domain.process_error("#{label} could not start: #{inspect(reason)}", nil, nil, nil)}
    end
  end

  defp rustup_proxy?(rustc) do
    path = rustc |> Path.expand() |> String.downcase() |> String.replace("\\", "/")
    String.contains?(path, "/.cargo/bin/") or rustup_beside?(rustc)
  end

  defp rustup_beside?(rustc) do
    dir = rustc |> Path.expand() |> Path.dirname()
    Enum.any?(["rustup", "rustup.exe"], &File.regular?(Path.join(dir, &1)))
  end

  defp execute(exe, opts, timeout, deadline) do
    cwd = opts[:root] || Path.dirname(exe)

    case invoke(opts[:execute], %{exe_path: exe, cwd: cwd}, fn ->
           Runner.run(exe, [], timeout: budget(deadline), cd: cwd)
         end) do
      {:ok, ran} ->
        {:ok, ran}

      {:error, {:timeout, info}} ->
        {:error, Targets.timeout_error(info, timeout)}

      {:error, %TimeoutError{} = error} ->
        {:error, error}

      {:error, reason} ->
        {:error, Spiral.Cells.Domain.process_error("could not run the cell: #{inspect(reason)}", nil, nil, nil)}
    end
  end

  defp invoke(nil, _ctx, default), do: default.()
  defp invoke(fun, ctx, _default) when is_function(fun, 1), do: fun.(ctx)

  defp compiler_env(opts, dotnet) do
    [
      {"DOTNET_ROOT", Path.dirname(dotnet)},
      {"DOTNET_NOLOGO", "1"},
      {"DOTNET_CLI_TELEMETRY_OPTOUT", "1"},
      {"SPIRAL_WORKSPACE_ROOT", Domain.tool("workspace", opts)},
      {"SPIRAL_COMPILER_PACKAGE_DIR", Domain.tool("package_dir", opts)}
      | Keyword.get(opts, :env, [])
    ]
  end

  defp require_tool(nil, name), do: {:error, Spiral.Cells.Domain.process_error("`#{name}` was not found", nil, nil, nil)}
  defp require_tool(path, name) when is_binary(path), do: require_file(path, name)

  defp require_file(path, name) do
    if File.regular?(path),
      do: :ok,
      else: {:error, Spiral.Cells.Domain.process_error("#{name} was not found at #{path}", nil, nil, nil)}
  end

  defp reject_unpatched(rust) do
    if String.contains?(rust, "__spiral_emit_rust") or String.contains?(rust, "emitRustExpr") do
      {:error,
       Spiral.Cells.Domain.process_error("generated Rust still holds an emit marker (__spiral_emit_rust)", nil, nil, nil)}
    else
      :ok
    end
  end

  defp budget(:infinity), do: :infinity

  defp budget(deadline), do: Spiral.Cells.Domain.budget_remaining(deadline, System.monotonic_time(:millisecond))

  defp restore_type_lines(output), do: Spiral.Cells.Domain.type_lines(output)

  defp clean(output, dir), do: Spiral.Cells.Domain.clean_paths(output, dir |> Path.expand() |> String.replace("\\", "/") |> String.trim_trailing("/"))

  @doc false
  def notebook_package_text(names, imports, package_dir), do: Spiral.Cells.Domain.notebook_package_text(names, imports, package_dir || "")

  defp write_package(dir, names, imports, package_dir, real), do: Spiral.Cells.Domain.write_package(dir, names, imports, package_dir || "", real, @console)

  defp mount_packages(_dir, [], _root, _workspace, _patches), do: {:ok, [], [], nil}

  defp mount_packages(_dir, paths, root, workspace, patches) do
    targets =
      Enum.map(paths, fn path ->
        target = resolve_package(path, root, workspace)
        {target, Mounts.mount_name(target)}
      end)

    dependencies = Mounts.dependency_closure(targets)
    sibling_names = Enum.map(targets ++ dependencies, &elem(&1, 1))

    case mount_entries(targets ++ dependencies, sibling_names, patches) do
      {:ok, entries} ->
        case Mounts.ensure(entries) do
          {:ok, package_dir} -> {:ok, Enum.map(targets, &elem(&1, 1)), Mounts.qualified_imports(targets), package_dir}
          {:error, message} -> {:error, Spiral.Cells.Domain.process_error(message, nil, nil, nil)}
        end

      error ->
        error
    end
  end

  defp mount_entries(targets, sibling_names, patches) do
    case Spiral.Cells.Domain.mount_entries(targets, sibling_names, patches, Domain.tool("dotnet", []) || "", Domain.tool("compiler_dll", []) || "") do
      {:ok, entries} -> {:ok, entries}
      {:error, message} -> {:error, Spiral.Cells.Domain.process_error(message, nil, nil, nil)}
    end
  end

  defp resolve_package(path, root, workspace), do: package_path(path, root, workspace)

  defp expand_package(path, root) when is_binary(root), do: Path.expand(path, root)
  defp expand_package(path, _root), do: Path.expand(path)

  defp package_project?(path), do: Spiral.Cells.Domain.manifest_exists(path)

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

  defp validate_timeout!(:infinity), do: :ok
  defp validate_timeout!(ms) when is_integer(ms) and ms > 0, do: :ok

  defp validate_timeout!(other) do
    raise ArgumentError,
          "expected :timeout to be a positive integer (ms) or :infinity, got: #{inspect(other)}"
  end
end

defmodule Spiral.Cells.SpiralError do
  defexception [:message, :details, :result]
end

defmodule Spiral.Cells.TimeoutError do
  defexception [:message, :timeout, :output]
end

defmodule Spiral.Cells.ProcessError do
  defexception [:message, :exit_status, :output, :reason]
end
