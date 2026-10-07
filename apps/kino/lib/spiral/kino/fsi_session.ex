defmodule Spiral.Kino.FsiSession do
  @moduledoc """
  One long-lived `dotnet fsi` per notebook.

  Each F# cell, and each file a cell `#!import`s, is fed on stdin as its own `;;`-terminated submission, the way
  .NET Interactive's F# kernel submits them: a later submission may redefine a type or a value of an earlier one
  (polyglot's `Notebooks.dib` imports `.fsx` files that each define `US0`). A script that concatenates the cells
  can't express that.

  After every submission a sentinel call prints the submission's value (`it`, when the submission set it) and an end
  marker, so the output of one submission is cut from the session's stdout+stderr stream. A submission fails when fsi
  reports `error FS....` or `Stopped due to error`. A submission that outlives its budget kills the process tree and
  ends the session.

  The first submission (the prelude) gives the session what .NET Interactive's F# kernel opens by default:
  `System`, `System.IO`, `System.Text`, and `Microsoft.DotNet.Interactive.Formatting` (the real `Formatter`, from its NuGet
  package, so `Formatter.ListExpansionLimit`, `Formatter.Register` and `x.ToDisplayString ()` work as on the old
  .dib route), plus what that route's runner (dotnet-repl) registered for an fsharp/spiral notebook:
  plain text by default and `%120A` for every object and sequence. Without that dll a small `Formatter` shim stands in
  (`ListExpansionLimit`, `Register`, `ToDisplayString` through `%120A`). `x.Display ()` prints the formatted value.
  """
  use GenServer

  alias Spiral.Kino.{Runner, Toolchain}

  @startup_timeout 300_000

  @type outcome ::
          {:ok, %{output: String.t(), value: String.t() | nil}}
          | {:error, %{output: String.t(), reason: :failed | :timeout | :closed}}

  @doc """
  Starts a session owned by the caller (the session dies with it) and runs the prelude.

  Options: `:dotnet`, `:cd` (fsi's working directory: relative `#r` paths resolve against it), `:env`,
  `:formatting_dll` (`false` forces the shim), `:startup_timeout`.
  """
  @spec start(keyword()) :: {:ok, pid()} | {:error, String.t()}
  def start(opts \\ []) do
    dotnet = opts[:dotnet] || Toolchain.dotnet(opts)

    cond do
      not (is_binary(dotnet) and (File.regular?(dotnet) or System.find_executable(dotnet) != nil)) ->
        {:error, "`dotnet fsi` was not found"}

      true ->
        {:ok, pid} = GenServer.start(__MODULE__, {self(), dotnet, opts})

        case submit(pid, prelude(formatting_dll(opts)),
               timeout: opts[:startup_timeout] || @startup_timeout,
               label: "prelude"
             ) do
          {:ok, _} ->
            {:ok, pid}

          {:error, %{output: output, reason: reason}} ->
            stop(pid)
            {:error, "the F# session did not start (#{reason})\n#{output}"}
        end
    end
  end

  @doc """
  Feeds `code` as one submission. Options: `:timeout` (ms or `:infinity`, default 300 s), `:label` (the file name of
  the submission's positions, `label(line,col)`, numbered from 1 by a `# 1 "label"` line directive).
  """
  @spec submit(pid(), String.t(), keyword()) :: outcome()
  def submit(pid, code, opts \\ []) when is_binary(code) do
    timeout = Keyword.get(opts, :timeout, 300_000)
    label = Keyword.get(opts, :label, "input.fsx")

    try do
      GenServer.call(pid, {:submit, code, timeout, label}, :infinity)
    catch
      :exit, reason ->
        {:error, %{output: "the F# session is gone: #{inspect(reason)}", reason: :closed}}
    end
  end

  @spec stop(pid()) :: :ok
  def stop(pid) do
    GenServer.stop(pid, :normal, 30_000)
  catch
    :exit, _ -> :ok
  end

  @spec alive?(pid()) :: boolean()
  def alive?(pid), do: Process.alive?(pid)

  @doc "The OS pid of the session's `dotnet fsi`."
  @spec os_pid(pid()) :: non_neg_integer() | nil
  def os_pid(pid), do: GenServer.call(pid, :os_pid)

  @doc false
  def formatting_dll(opts) do
    case Keyword.get(opts, :formatting_dll) do
      false ->
        nil

      path when is_binary(path) ->
        path

      nil ->
        System.get_env("SPIRAL_KINO_FORMATTING_DLL") || :nuget
    end
  end

  # The NuGet package fsi restores when no dll is given (its dependency Microsoft.AspNetCore.Html.Abstractions comes along).
  @formatting_package "Microsoft.DotNet.Interactive.Formatting, 1.0.0-beta.26120.1"

  @doc false
  def prelude(dll) do
    formatter =
      if dll do
        # .NET Interactive also references the assembly of IHtmlContent: without it, opening the Formatting namespace
        # makes overload resolution of e.g. `StringBuilder.Append` fail with FS1108 (the package brings it along).
        refs =
          if dll == :nuget do
            ~s|#r "nuget: #{@formatting_package}"|
          else
            html = Path.join(Path.dirname(dll), "Microsoft.AspNetCore.Html.Abstractions.dll")
            html_ref = if File.regular?(html), do: ~s|#r @"#{html}"\n|, else: ""
            html_ref <> ~s|#r @"#{dll}"|
          end

        # What dotnet-repl (the .dib route's runner) sets up for an fsharp/spiral default kernel (KernelBuilder.cs,
        # Repl.cs): plain text by default, and every object and sequence formatted with `%120A`.
        """
        #{refs}
        open Microsoft.DotNet.Interactive.Formatting
        Formatter.DefaultMimeType <- "text/plain"
        Formatter.Register (fun (x: obj) (writer: TextWriter) -> fprintfn writer "%120A" x)
        Formatter.Register (fun (x: System.Collections.IEnumerable) (writer: TextWriter) -> fprintfn writer "%120A" x)
        let __kino_format (value: obj) = value.ToDisplayString ()
        let __kino_display (value: obj) =
            let mime =
                if isNull value then "text/plain"
                else Formatter.GetPreferredMimeTypesFor (value.GetType ()) |> Seq.tryHead |> Option.defaultValue "text/plain"
            value.ToDisplayString mime
        """
      else
        """
        type Formatter () =
            static member val ListExpansionLimit = 20 with get, set
            static member Register<'T> (formatter: System.Func<'T, string>, ?mimeType: string) = ignore (formatter, mimeType)
        let __kino_format (value: obj) = sprintf "%120A" value + Environment.NewLine
        let __kino_display (value: obj) = __kino_format value
        [<System.Runtime.CompilerServices.Extension>]
        type KinoFormatterExtensions =
            [<System.Runtime.CompilerServices.Extension>]
            static member ToDisplayString<'T> (value: 'T, ?mimeType: string) = ignore mimeType; __kino_format (box value)
        """
      end

    """
    open System
    open System.IO
    open System.Text
    #{formatter}
    [<System.Runtime.CompilerServices.Extension>]
    type KinoDisplayExtensions =
        [<System.Runtime.CompilerServices.Extension>]
        static member Display (value: obj, [<ParamArray>] mimeTypes: string[]) =
            ignore mimeTypes
            Console.Out.WriteLine ((__kino_display value).TrimEnd ())
    let __kino_none = obj ()
    let __kino_end (token: string) (n: int) (value: obj) =
        try
            if not (isNull value) && not (obj.ReferenceEquals (value, __kino_none)) then
                let text = __kino_format value
                Console.Out.Write ("@@KINO-" + token + "-VALUE\\n" + text + "\\n")
        with ex -> Console.Error.WriteLine ("(value not shown: " + ex.Message + ")")
        Console.Out.Flush ()
        Console.Error.Flush ()
        Console.Out.Write ("@@KINO-" + token + "-END-" + string n + "\\n")
        Console.Out.Flush ()
    """
  end

  @impl true
  def init({owner, dotnet, opts}) do
    Process.flag(:trap_exit, true)
    owner_ref = Process.monitor(owner)

    token =
      Integer.to_string(:erlang.unique_integer([:positive])) <>
        Integer.to_string(System.os_time(:microsecond), 36)

    env =
      Enum.map(
        [{"DOTNET_NOLOGO", "1"}, {"DOTNET_CLI_TELEMETRY_OPTOUT", "1"} | opts[:env] || []],
        fn {k, v} -> {to_charlist(k), if(v, do: to_charlist(v), else: false)} end
      )

    port_opts =
      [
        :binary,
        :exit_status,
        :stderr_to_stdout,
        :use_stdio,
        :hide,
        args: ["fsi", "--nologo", "--quiet", "--utf8output", "--readline-"],
        env: env
      ] ++ if(opts[:cd], do: [cd: opts[:cd]], else: [])

    port = Port.open({:spawn_executable, resolve(dotnet)}, port_opts)

    os_pid =
      case Port.info(port, :os_pid) do
        {:os_pid, pid} -> pid
        _ -> nil
      end

    {:ok,
     %{
       port: port,
       os_pid: os_pid,
       owner_ref: owner_ref,
       token: token,
       n: 0,
       buffer: "",
       pending: nil,
       first: true
     }}
  end

  defp resolve(exe) do
    if File.regular?(exe), do: exe, else: System.find_executable(exe)
  end

  @impl true
  def handle_call(:os_pid, _from, state), do: {:reply, state.os_pid, state}

  def handle_call({:submit, _code, _timeout, _label}, _from, %{port: nil} = state) do
    {:reply, {:error, %{output: "the F# session has ended", reason: :closed}}, state}
  end

  def handle_call({:submit, code, timeout, label}, from, state) do
    n = state.n + 1
    code = code |> String.replace_prefix("﻿", "") |> String.replace("\r\n", "\n")
    code = if String.ends_with?(code, "\n"), do: code, else: code <> "\n"
    reset = if state.first, do: "", else: "let it = __kino_none\n;;\n"

    # A line directive numbers the submission from 1 under its label, as .NET Interactive does per cell: positions
    # (`input.fsx(3,1): error FS0039`) and closure names (`<fun:it@5-13>`) don't depend on earlier submissions.
    directive = ~s|# 1 "#{String.replace(label, ~s("), "'")}"\n|
    value = if state.first, do: "null", else: "(box it)"

    payload =
      reset <> directive <> code <> ";;\n" <> ~s|__kino_end "#{state.token}" #{n} #{value}\n;;\n|

    Port.command(state.port, payload)

    timer =
      case timeout do
        :infinity -> nil
        ms -> Process.send_after(self(), {:deadline, n}, ms)
      end

    pending = %{from: from, n: n, label: label, timer: timer}
    {:noreply, scan(%{state | n: n, pending: pending, first: false})}
  end

  @impl true
  def handle_info({port, {:data, data}}, %{port: port} = state) do
    {:noreply, scan(%{state | buffer: state.buffer <> data})}
  end

  def handle_info({port, {:exit_status, status}}, %{port: port} = state) do
    state =
      reply_pending(
        state,
        {:error,
         %{output: cut_output(state, "#{state.buffer}\n(fsi exited #{status})"), reason: :closed}}
      )

    {:stop, :normal, %{state | port: nil}}
  end

  def handle_info({:deadline, n}, %{pending: %{n: n}} = state) do
    Runner.kill_tree(state.os_pid)
    output = cut_output(state, state.buffer)
    close(state)
    state = reply_pending(%{state | port: nil}, {:error, %{output: output, reason: :timeout}})
    {:stop, :normal, state}
  end

  def handle_info({:deadline, _}, state), do: {:noreply, state}

  def handle_info({:DOWN, ref, :process, _, _}, %{owner_ref: ref} = state) do
    {:stop, :normal, state}
  end

  def handle_info({:EXIT, _, _}, state), do: {:noreply, state}
  def handle_info(_, state), do: {:noreply, state}

  @impl true
  def terminate(_reason, state) do
    if state.port do
      Runner.kill_tree(state.os_pid)
      close(state)
    end

    :ok
  end

  defp close(%{port: nil}), do: :ok

  defp close(%{port: port}) do
    Port.close(port)
  rescue
    ArgumentError -> :ok
  end

  defp scan(%{pending: nil} = state), do: state

  defp scan(%{pending: pending, token: token} = state) do
    marker = "@@KINO-#{token}-END-#{pending.n}"

    case :binary.match(state.buffer, marker) do
      :nomatch ->
        state

      {at, len} ->
        segment = binary_part(state.buffer, 0, at)
        rest = binary_part(state.buffer, at + len, byte_size(state.buffer) - at - len)
        rest = rest |> String.replace_prefix("\r\n", "") |> String.replace_prefix("\n", "")
        if pending.timer, do: Process.cancel_timer(pending.timer)
        state = reply_pending(%{state | buffer: rest}, outcome(segment, state))
        scan(state)
    end
  end

  defp reply_pending(%{pending: nil} = state, _reply), do: state

  defp reply_pending(%{pending: pending} = state, reply) do
    GenServer.reply(pending.from, reply)
    %{state | pending: nil}
  end

  defp outcome(segment, %{token: token, pending: pending}) do
    segment = String.replace(segment, "\r\n", "\n")

    {text, value} =
      case :binary.split(segment, "@@KINO-#{token}-VALUE\n") do
        [text, value] -> {text, String.trim_trailing(value, "\n")}
        [text] -> {text, nil}
      end

    text = text |> relabel(pending) |> String.trim_trailing()

    if failed?(text),
      do: {:error, %{output: text, reason: :failed}},
      else: {:ok, %{output: text, value: value}}
  end

  defp cut_output(%{pending: nil}, text), do: String.replace(text, "\r\n", "\n")

  defp cut_output(%{pending: pending}, text) do
    text |> String.replace("\r\n", "\n") |> relabel(pending) |> String.trim_trailing()
  end

  @doc false
  def failed?(text) do
    Regex.match?(~r/\(\d+,\d+\): error FS\d+/, text) or
      Regex.match?(~r/^Stopped due to error\s*$/m, text)
  end

  # Stack traces: `at ... in <fsi cwd>\<label>:line 3` (the line directive names the submission; fsi joins it to its
  # working directory).
  defp relabel(text, %{label: label}) do
    label = String.replace(label, ~s("), "'")
    Regex.replace(~r/ in [^\n]*?[\\\/]#{Regex.escape(label)}:line /, text, " in #{label}:line ")
  end
end
