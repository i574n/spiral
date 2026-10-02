defmodule Spiral.Kino do
  alias Spiral.Kino.{
    Directives,
    Notebook,
    ProcessError,
    Result,
    Runner,
    SpiralError,
    TimeoutError
  }

  @default_timeout 300_000
  @log_tail 4_000
  @default_polyglot_root Path.expand("../../../../../polyglot", __DIR__)

  @spec run(String.t(), keyword()) :: {:ok, Result.t()} | {:error, Exception.t()}
  def run(code, opts \\ []) when is_binary(code) do
    timeout = Keyword.get(opts, :timeout, @default_timeout)
    validate_timeout!(timeout)

    source =
      Directives.apply_options(
        code,
        Keyword.take(opts, [:backend, :builder_args, :print_code, :trace, :kernel_args])
      )

    dib = Notebook.dib(source)
    dir = tmp_dir()
    dib_path = Path.join(dir, "cell.dib")
    ipynb_path = Path.join(dir, "cell.dib.ipynb")

    try do
      File.write!(dib_path, dib)

      with {:ok, {exe, args, cd}} <- command(opts, dib_path, ipynb_path) do
        Runner.run(exe, args, timeout: timeout, cd: cd, env: Keyword.get(opts, :env, []))
        |> to_result(source, ipynb_path)
      end
    after
      unless opts[:keep_files], do: File.rm_rf(dir)
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

  defp show(%Result{stdout: stdout, html: html}) do
    if stdout != "" do
      IO.write(if String.ends_with?(stdout, "\n"), do: stdout, else: stdout <> "\n")
    end

    Enum.each(html, &Kino.render(Kino.HTML.new(&1)))
  end

  defp to_result({:error, {:timeout, %{output: output, timeout: timeout}}}, _source, _ipynb) do
    {:error,
     %TimeoutError{
       message:
         "Spiral cell timed out after #{format_ms(timeout)}; the process tree was killed. " <>
           "Increase the timeout if the toolchain needs longer (a cold `dotnet repl` " <>
           "start takes ~20s; Fable/cargo builds can take minutes).",
       timeout: timeout,
       output: output
     }}
  end

  defp to_result({:error, {:spawn_failed, reason}}, _source, _ipynb) do
    {:error, %ProcessError{message: "could not start the Spiral runner: #{inspect(reason)}"}}
  end

  defp to_result({:error, {:runner_crashed, reason}}, _source, _ipynb) do
    {:error, %ProcessError{message: "the Spiral runner crashed: #{inspect(reason)}"}}
  end

  defp to_result({:ok, run}, source, ipynb_path) do
    log = Notebook.strip_ansi(run.output)

    with {:ok, json} <- read_notebook(ipynb_path, run, log),
         {:ok, outputs} <- parse_notebook(json, run, log) do
      result =
        Result.from_outputs(outputs,
          source: source,
          exit_status: run.exit_status,
          duration_ms: run.duration_ms,
          log: log
        )

      case Enum.find(outputs, &match?({:error, _}, &1)) do
        {:error, error} ->
          {:error, %SpiralError{message: error.message, details: error.details, result: result}}

        nil when run.exit_status != 0 ->
          {:error, process_error("dotnet repl exited with status #{run.exit_status}", run, log)}

        nil ->
          {:ok, result}
      end
    end
  end

  defp read_notebook(path, run, log) do
    case File.read(path) do
      {:ok, json} ->
        {:ok, json}

      {:error, reason} ->
        {:error,
         process_error(
           "dotnet repl (exit status #{run.exit_status}) wrote no notebook output " <>
             "(#{:file.format_error(reason)})",
           run,
           log
         )}
    end
  end

  defp parse_notebook(json, run, log) do
    case Notebook.parse_ipynb(json) do
      {:ok, outputs} ->
        {:ok, outputs}

      {:error, reason} ->
        {:error,
         process_error(
           "could not parse the notebook written by dotnet repl (#{inspect(reason)})",
           run,
           log <> "\n" <> json
         )}
    end
  end

  defp process_error(message, run, log) do
    hint =
      if String.contains?(log, "NoSuitableKernelException") do
        "\n\nNo `spiral` kernel was found: `dotnet repl` resolved to a build without the " <>
          "Spiral kernel. It must run from the polyglot checkout so that the local tool " <>
          "manifest (.config/dotnet-tools.json, dotnet-repl fork) is used; check " <>
          "`:polyglot_root` and run `dotnet tool restore` there."
      else
        ""
      end

    tail = String.slice(log, -@log_tail, @log_tail)

    %ProcessError{
      message: message <> hint <> if(tail != "", do: "\n\nOutput (tail):\n" <> tail, else: ""),
      exit_status: run.exit_status,
      output: log
    }
  end

  defp command(opts, dib_path, ipynb_path) do
    case opts[:command] do
      fun when is_function(fun, 1) ->
        {exe, args} = fun.(%{dib: dib_path, ipynb: ipynb_path})
        {:ok, {exe, args, opts[:cd]}}

      nil ->
        root = polyglot_root(opts)
        manifest = Path.join(root, ".config/dotnet-tools.json")

        cond do
          not File.regular?(manifest) ->
            {:error,
             %ProcessError{
               message:
                 "polyglot checkout not found at #{root} (no .config/dotnet-tools.json). " <>
                   "Set the :polyglot_root option, the :spiral_kino, :polyglot_root app env " <>
                   "or the SPIRAL_KINO_POLYGLOT_ROOT environment variable."
             }}

          dotnet = opts[:dotnet] || System.find_executable("dotnet") ->
            args = [
              "repl",
              "--run",
              dib_path,
              "--output-path",
              ipynb_path,
              "--exit-after-run"
            ]

            {:ok, {dotnet, args, root}}

          true ->
            {:error, %ProcessError{message: "`dotnet` was not found on PATH"}}
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
