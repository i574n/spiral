defmodule Spiral.Kino.FsiChain do
  @moduledoc """
  Runs a notebook's F# cells and `#!import` cells, in order, on one `Spiral.Kino.FsiSession`.

  - An F# cell is one submission.
  - `#!import <file>.fs|.fsx` submits the file's text (what .NET Interactive's `#!import` does), so a file that
    redefines `US0` shadows the previous one instead of clashing with it.
  - `#!import <notebook>.dib` runs the notebook's F# cells and its own `#!import`s, each as its own submission. A
    relative path is resolved against the importing file's directory, then the notebook's directory. Spiral and other
    kernels' cells of an imported notebook are skipped (noted in the output).
  - Each cell holds a job slot (`Spiral.Kino.Slots`) while it runs. The session starts inside the first cell's slot.
  - A cell's budget is the `:timeout` option, else its `///- --timeout <ms>` line, else 300 s (an import cell: per
    submission, i.e. per imported file / imported notebook cell). A cell that times out
    kills the session; the cells after it fail with a note instead of running against a session that lost its
    definitions.
  """
  alias Spiral.Kino.{Document, FsiSession, Slots}

  @default_timeout 300_000
  @max_depth 16

  @type cell :: %{index: non_neg_integer(), kind: :fsharp | :import, source: String.t()}
  @type outcome :: {:ok, %{stdout: String.t(), value: String.t() | nil}} | {:error, String.t()}

  @doc """
  Returns `[{index, outcome, ms}]` in cell order. Options: `:root` (the notebook's directory: fsi's working directory
  and the base of relative imports), `:timeout`, `:session` (FsiSession.start options), `:slots` (`false` runs
  without job slots).
  """
  @spec run([cell()], keyword()) :: [{non_neg_integer(), outcome(), non_neg_integer()}]
  def run(cells, opts \\ []) do
    root = opts[:root] || File.cwd!()
    state = %{session: nil, ended: nil}

    {entries, state} =
      Enum.map_reduce(cells, state, fn cell, state ->
        started = System.monotonic_time(:millisecond)

        {outcome, state} =
          if state.ended do
            {{:error, "skipped: #{state.ended}"}, state}
          else
            with_slot(opts, fn -> run_cell(cell, state, root, opts) end)
          end

        {{cell.index, outcome, System.monotonic_time(:millisecond) - started}, state}
      end)

    if state.session, do: FsiSession.stop(state.session)
    entries
  end

  defp with_slot(opts, fun) do
    if opts[:slots] == false do
      fun.()
    else
      {result, _waited} = Slots.run(fun)
      result
    end
  end

  defp run_cell(cell, state, root, opts) do
    case ensure_session(state, root, opts) do
      {:error, message, state} ->
        {{:error, message}, state}

      {:ok, state} ->
        budget = budget(cell, opts)
        deadline = deadline_for(budget)

        case submissions(cell, root) do
          {:ok, parts} ->
            run_parts(parts, cell, deadline, budget, state)

          {:error, message} ->
            {{:error, message}, state}
        end
    end
  end

  defp ensure_session(%{session: nil} = state, root, opts) do
    session_opts = Keyword.merge([cd: root], opts[:session] || [])

    case FsiSession.start(session_opts) do
      {:ok, pid} -> {:ok, %{state | session: pid}}
      {:error, message} -> {:error, message, %{state | ended: "the F# session did not start"}}
    end
  end

  defp ensure_session(state, _root, _opts), do: {:ok, state}

  defp run_parts(parts, cell, deadline, budget, state) do
    Enum.reduce_while(parts, {{:ok, %{stdout: "", value: nil}}, state}, fn part,
                                                                           {{:ok, acc}, state} ->
      case part do
        {:note, text} ->
          {:cont, {{:ok, %{acc | stdout: join(acc.stdout, text)}}, state}}

        %{label: label, code: code} ->
          # An imported notebook is many submissions (polyglot's Notebooks.dib: 18 files, ~2 MB of F#): each gets the
          # budget, like a cell of its own.
          deadline = if cell.kind == :import, do: deadline_for(budget), else: deadline

          case FsiSession.submit(state.session, code, timeout: remaining(deadline), label: label) do
            {:ok, %{output: output, value: value}} ->
              value = if cell.kind == :fsharp, do: value, else: nil
              {:cont, {{:ok, %{acc | stdout: join(acc.stdout, output), value: value}}, state}}

            {:error, %{output: output, reason: :failed}} ->
              {:halt, {{:error, join(acc.stdout, output)}, state}}

            {:error, %{output: output, reason: :timeout}} ->
              message =
                join(
                  "F# cell timed out after #{format_ms(budget)}; the fsi process tree was killed.",
                  join(acc.stdout, output)
                )

              {:halt,
               {{:error, message},
                %{
                  state
                  | ended: "the F# session was killed when cell #{cell.index + 1} timed out"
                }}}

            {:error, %{output: output, reason: :closed}} ->
              {:halt,
               {{:error, join(acc.stdout, output)},
                %{state | ended: "the F# session ended in cell #{cell.index + 1}"}}}
          end
      end
    end)
  end

  @doc """
  A cell the .dib route's runner skips (dotnet-repl NotebookRunner: contents starting with `///- ` that contain
  `--ignore`). It doesn't run here either; the notebook shows it without output.
  """
  @spec ignored?(String.t()) :: boolean()
  def ignored?(source) do
    source = String.trim_leading(source)
    String.starts_with?(source, "///- ") and String.contains?(source, "--ignore")
  end

  @doc false
  def budget(cell, opts) do
    opts[:timeout] || directive_timeout(cell) || @default_timeout
  end

  defp directive_timeout(%{kind: :fsharp, source: source}) do
    case Regex.run(~r/^\s*\/\/\/-[^\n]*--timeout\s+(\d+)/m, source) do
      [_, ms] -> String.to_integer(ms)
      nil -> nil
    end
  end

  defp directive_timeout(_cell), do: nil

  @doc """
  The submissions of one cell: `{:ok, [%{label, code} | {:note, text}]}` or `{:error, message}`.
  """
  @spec submissions(cell(), String.t()) :: {:ok, list()} | {:error, String.t()}
  def submissions(%{kind: :fsharp, source: source}, _root) do
    {:ok, [%{label: "input.fsx", code: strip_magic(source)}]}
  end

  def submissions(%{kind: :import, source: path}, root), do: expand(path, [root], root, 0)

  defp expand(_path, _bases, _root, depth) when depth > @max_depth do
    {:error, "#!import: nested deeper than #{@max_depth} levels"}
  end

  defp expand(path, bases, root, depth) do
    path = String.trim(path)

    case resolve(path, bases) do
      nil ->
        {:error,
         "#!import: #{path} was not found (looked in #{Enum.join(Enum.uniq(bases), ", ")})"}

      file ->
        case String.downcase(Path.extname(file)) do
          ext when ext in [".fs", ".fsx"] ->
            {:ok, [%{label: Path.basename(file), code: File.read!(file)}]}

          ".dib" ->
            expand_dib(file, root, depth)

          other ->
            {:error, "#!import: #{path}: #{other} files are not supported by the F# session"}
        end
    end
  end

  defp expand_dib(file, root, depth) do
    doc = file |> File.read!() |> String.replace("\r\n", "\n") |> Document.parse_dib()
    name = Path.basename(file)
    bases = [Path.dirname(file), root]

    doc.cells
    |> Enum.with_index(1)
    |> Enum.reduce_while({:ok, []}, fn {cell, n}, {:ok, acc} ->
      case cell do
        %{kind: :fsharp, source: source} ->
          {:cont, {:ok, acc ++ [%{label: "#{name}[#{n}]", code: strip_magic(source)}]}}

        %{kind: :import, source: path} ->
          case expand(path, bases, root, depth + 1) do
            {:ok, parts} -> {:cont, {:ok, acc ++ parts}}
            error -> {:halt, error}
          end

        %{kind: :markdown} ->
          {:cont, {:ok, acc}}

        other ->
          kernel = Map.get(other, :language) || to_string(other.kind)

          {:cont,
           {:ok,
            acc ++
              [
                {:note,
                 "#{name}[#{n}]: #{kernel} cell skipped (only F# cells run in the F# session)"}
              ]}}
      end
    end)
  end

  defp resolve(path, bases) do
    if Path.type(path) == :absolute do
      if File.regular?(path), do: path
    else
      bases
      |> Enum.map(&Path.expand(path, &1))
      |> Enum.find(&File.regular?/1)
    end
  end

  # .NET Interactive magic commands that are not F#; `#!import` lines are already their own cells.
  defp strip_magic(source) do
    source
    |> String.split("\n")
    |> Enum.reject(&Regex.match?(~r/^#!(fsharp|f#|fs)\s*$/, String.trim_trailing(&1)))
    |> Enum.join("\n")
  end

  defp deadline_for(:infinity), do: :infinity
  defp deadline_for(budget), do: System.monotonic_time(:millisecond) + budget

  defp remaining(:infinity), do: :infinity
  defp remaining(deadline), do: max(deadline - System.monotonic_time(:millisecond), 0)

  defp join("", b), do: b
  defp join(a, ""), do: a
  defp join(a, b), do: a <> "\n" <> b

  defp format_ms(:infinity), do: "infinity"
  defp format_ms(ms) when rem(ms, 1000) == 0, do: "#{div(ms, 1000)}s"
  defp format_ms(ms), do: "#{ms}ms"
end
