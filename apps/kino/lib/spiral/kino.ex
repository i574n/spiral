defmodule Spiral.Kino do
  alias Spiral.Kino.{
    Cell,
    Directives,
    ProcessError,
    Result,
    Runner,
    SpiralError,
    TimeoutError,
    Toolchain
  }

  @default_timeout 300_000
  @default_polyglot_root Path.expand("../../../../../polyglot", __DIR__)

  @spec run(String.t(), keyword()) :: {:ok, Result.t()} | {:error, Exception.t()}
  def run(code, opts \\ []) when is_binary(code) do
    if String.trim(code) == "" do
      {:ok, %Result{}}
    else
      timeout = opts[:timeout] || @default_timeout
      validate_timeout!(timeout)
      prepared = Directives.prepare(code, opts)
      timeout = opts[:timeout] || prepared.timeout || timeout
      started = System.monotonic_time(:millisecond)

      deadline =
        case timeout do
          :infinity -> :infinity
          ms -> started + ms
        end

      dir = tmp_dir()

      try do
        spi = Path.join(dir, "main.spi")
        rs = Path.join(dir, "main.rs")
        exe = Path.join(dir, exe_name())

        with {:ok, names} <- mount_packages(dir, prepared.packages, opts[:root]),
             :ok <- write_package(dir, names),
             :ok <- File.write(spi, prepared.code),
             {:ok, rust, show_value} <- compile(dir, spi, rs, prepared, opts, timeout, deadline),
             rust = Cell.patch_rust(rust, show_value),
             :ok <- reject_unpatched(rust),
             :ok <- File.write(rs, rust),
             :ok <- rustc(rs, exe, opts, timeout, deadline),
             {:ok, ran} <- execute(exe, opts, timeout, deadline) do
          {value, stdout} = Cell.split_output(ran.output)

          stdout =
            if prepared.print_code do
              rust <> if(stdout == "", do: "", else: "\n" <> stdout)
            else
              stdout
            end

          {:ok,
           %Result{
             value: value,
             stdout: stdout,
             source: File.read!(spi),
             exit_status: ran.exit_status,
             duration_ms: System.monotonic_time(:millisecond) - started
           }}
        end
      after
        unlink_mounted(dir, prepared.packages, opts[:root])
        unless opts[:keep_files], do: File.rm_rf(dir)
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

  @spec polyglot_root(keyword()) :: String.t()
  def polyglot_root(opts \\ []) do
    opts[:polyglot_root] ||
      Application.get_env(:spiral_kino, :polyglot_root) ||
      System.get_env("SPIRAL_KINO_POLYGLOT_ROOT") ||
      @default_polyglot_root
  end

  defp show(%Result{stdout: stdout, html: html}) do
    if stdout != "" do
      IO.write(if String.ends_with?(stdout, "\n"), do: stdout, else: stdout <> "\n")
    end

    Enum.each(html, &Kino.render(Kino.HTML.new(&1)))
  end

  defp compile(dir, spi, rs, prepared, opts, timeout, deadline) do
    compile(dir, spi, rs, prepared, opts, timeout, deadline, 1, true)
  end

  defp compile(dir, spi, rs, prepared, opts, timeout, deadline, attempt, show_value) do
    case invoke(
           opts[:compile],
           %{source: File.read!(spi), spi_path: spi, rs_path: rs, attempt: attempt},
           fn ->
             compile_default(spi, rs, opts, timeout, deadline)
           end
         ) do
      {:ok, rust} ->
        {:ok, rust, show_value}

      {:error, %TimeoutError{} = error} ->
        {:error, error}

      {:error, %ProcessError{} = error} ->
        {:error, error}

      {:error, output} ->
        if attempt == 1 and prepared.generated_main and Cell.unit_result?(output) do
          File.write!(spi, String.trim_trailing(File.read!(spi), "\n") <> "\n    0i32\n")
          compile(dir, spi, rs, prepared, opts, timeout, deadline, 2, false)
        else
          {:error, %SpiralError{message: clean(output, dir), details: File.read!(spi)}}
        end
    end
  end

  defp compile_default(spi, rs, opts, timeout, deadline) do
    with :ok <- require_tool(Toolchain.dotnet(opts), "dotnet"),
         :ok <- require_file(Toolchain.compiler_dll(opts), "Spiral compiler"),
         :ok <-
           require_file(
             Path.join(Toolchain.package_dir(opts), "core/package.spiproj"),
             "Spiral core package"
           ) do
      dotnet = Toolchain.dotnet(opts)

      case Runner.run(dotnet, [Toolchain.compiler_dll(opts), "--backend", "Rust", spi, rs],
             timeout: budget(deadline),
             env: compiler_env(opts, dotnet)
           ) do
        {:ok, %{exit_status: 0}} ->
          {:ok, File.read!(rs)}

        {:ok, %{output: output}} ->
          {:error, output}

        {:error, {:timeout, info}} ->
          {:error, timeout_error(info, timeout)}

        {:error, reason} ->
          {:error,
           %ProcessError{message: "could not start the Spiral compiler: #{inspect(reason)}"}}
      end
    end
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
             timeout: budget(deadline)
           ) do
        {:ok, %{exit_status: 0}} -> :ok
        {:ok, %{output: output}} -> {:error, output}
        {:error, {:timeout, info}} -> {:error, timeout_error(info, timeout)}
        {:error, reason} -> {:error, "could not start rustc: #{inspect(reason)}"}
      end
    end
  end

  defp execute(exe, opts, timeout, deadline) do
    case invoke(opts[:execute], %{exe_path: exe}, fn ->
           Runner.run(exe, [], timeout: budget(deadline), cd: Path.dirname(exe))
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
    if String.contains?(rust, "emitRustExpr") do
      {:error, %ProcessError{message: "generated Rust still calls emitRustExpr"}}
    else
      :ok
    end
  end

  defp budget(:infinity), do: :infinity
  defp budget(deadline), do: max(deadline - System.monotonic_time(:millisecond), 0)

  defp timeout_error(%{output: output}, timeout) do
    %TimeoutError{
      message: "Spiral cell timed out after #{format_ms(timeout)}; the process tree was killed.",
      timeout: timeout,
      output: output
    }
  end

  defp clean(output, dir) do
    prefix = String.trim_trailing(Path.expand(dir), "/\\")

    output
    |> String.replace(prefix <> "/", "")
    |> String.replace(prefix <> "\\", "")
    |> String.replace(String.replace(prefix, "\\", "/"), "")
    |> String.trim()
  end

  defp write_package(dir, names) do
    File.write!(Path.join(dir, "package.spiproj"), Cell.package_project(names))
    File.write!(Path.join(dir, "console.spi"), Cell.console_source())
    :ok
  end

  defp mount_packages(_dir, [], _root), do: {:ok, []}

  defp mount_packages(dir, paths, root) do
    Enum.reduce_while(paths, {:ok, []}, fn path, {:ok, names} ->
      target = resolve_package(path, root)
      name = Path.basename(target)

      cond do
        name in ["", "console", "main"] ->
          {:halt,
           {:error, %ProcessError{message: "package name #{inspect(name)} clashes with the cell"}}}

        name in names ->
          {:halt, {:error, %ProcessError{message: "package #{name} is listed twice"}}}

        not File.regular?(Path.join(target, "package.spiproj")) ->
          {:halt, {:error, %ProcessError{message: "Spiral package was not found at #{target}"}}}

        true ->
          case make_link(Path.join(dir, name), target) do
            :ok -> {:cont, {:ok, names ++ [name]}}
            {:error, message} -> {:halt, {:error, %ProcessError{message: message}}}
          end
      end
    end)
  end

  defp resolve_package(path, nil), do: Path.expand(path)
  defp resolve_package(path, root), do: Path.expand(path, root)

  defp make_link(link, target) do
    case :os.type() do
      {:win32, _} ->
        {out, status} =
          System.cmd("cmd", ["/c", "mklink", "/J", win_path(link), win_path(target)])

        if status == 0, do: :ok, else: {:error, "could not link #{link}: #{String.trim(out)}"}

      _ ->
        case File.ln_s(target, link) do
          :ok -> :ok
          {:error, reason} -> {:error, "could not link #{link}: #{inspect(reason)}"}
        end
    end
  end

  defp unlink_mounted(dir, paths, root) do
    Enum.each(paths, fn path ->
      link = path |> resolve_package(root) |> Path.basename() |> then(&Path.join(dir, &1))
      remove_link(link)
    end)
  end

  defp remove_link(link) do
    case :os.type() do
      {:win32, _} ->
        link = win_path(link)
        if File.dir?(link), do: System.cmd("cmd", ["/c", "rmdir", link])

      _ ->
        File.rm(link)
    end
  end

  defp win_path(path), do: String.replace(path, "/", "\\")

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
