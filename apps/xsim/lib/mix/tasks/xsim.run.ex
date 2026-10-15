defmodule Mix.Tasks.Xsim.Run do
  use Mix.Task

  @shortdoc "Replay a seeded X-like scenario built from a .spi against an executor and check Kino's invariants"

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("app.start")

    {opts, _} =
      OptionParser.parse!(args,
        strict: [spi: :string, spi_file: :string, cells: :integer, breaking: :integer, frames: :boolean, churn: :integer, save: :string, replay: :string, seed: :integer, users: :integer, edits: :integer, schedules: :integer, executor: :string, max_concurrency: :integer, duplicates: :float, memo: :boolean, personas: :string, evict: :boolean, daemon_memory: :boolean]
      )

    files =
      if opts[:spi_file],
        do: opts[:spi_file] |> File.read!() |> String.split(["\r\n", "\n"], trim: true),
        else: String.split(opts[:spi] || Mix.raise("missing --spi or --spi-file"), ",", trim: true)
    spi = hd(files)
    threads = Enum.map(files, &cells_of(&1, opts[:cells]))
    scenario = Xsim.Scenario.from_corpus(threads, seed: opts[:seed] || 1, users: opts[:users] || 8, edits: opts[:edits] || 3, breaking: opts[:breaking] || 0, churn: opts[:churn] || 0, personas: Xsim.Personas.parse(opts[:personas]))
    scenario = if opts[:frames], do: %{scenario | events: Xsim.Frames.explode_posts(scenario.events)}, else: scenario
    tally = Xsim.Executors.memo_tally()
    executor = executor(opts[:executor] || "fake", spi, memo: Keyword.get(opts, :memo, false), memo_tally: tally)
    baseline = executor(opts[:executor] || "fake", spi, memo: false)
    sampler = if opts[:daemon_memory], do: elem(Xsim.DaemonMemory.start(Spiral.Kino.CompilerDaemon.port()), 1)

    runs =
      for schedule <- 1..(opts[:schedules] || 2) do
        deliveries =
          if opts[:replay],
            do: Xsim.Log.read(opts[:replay]),
            else: Xsim.Scenario.deliveries(scenario, schedule_seed: schedule, duplicates: opts[:duplicates] || 0.1)

        if opts[:save], do: Xsim.Log.write(String.replace(opts[:save], "{schedule}", Integer.to_string(schedule)), deliveries)
        started = System.monotonic_time(:millisecond)
        state = Xsim.Runner.run(deliveries, executor, max_concurrency: opts[:max_concurrency] || 4, evict: Keyword.get(opts, :evict, false))
        ms = System.monotonic_time(:millisecond) - started
        verdicts = Xsim.Invariants.check(state, baseline)
        verdicts = if opts[:executor] == "kino", do: verdicts ++ [{:breaking_edits_fail, Xsim.Invariants.breaking_edits_fail(state, scenario.broken)}], else: verdicts
        memo = Xsim.Executors.memo_counts(tally)
        IO.puts(summary(scenario, deliveries, state, verdicts, schedule, ms))
        if opts[:memo], do: IO.puts("  memo hits=#{memo.hit} misses=#{memo.miss} cumulative_after_schedule=#{schedule}")
        if sampler, do: IO.puts(daemon_line(Xsim.DaemonMemory.peak(sampler), schedule))
        explain(state, verdicts, baseline)
        {state, verdicts}
      end

    commute =
      runs
      |> Enum.map(&elem(&1, 0))
      |> Enum.chunk_every(2, 1, :discard)
      |> Enum.map(fn [a, b] -> Xsim.Invariants.commute(a, b) end)
      |> Enum.find(:ok, &(&1 != :ok))

    if sampler, do: Xsim.DaemonMemory.stop(sampler)
    failed = Enum.any?(runs, fn {_, verdicts} -> Enum.any?(verdicts, fn {_, v} -> v != :ok end) end) or commute != :ok
    IO.puts("XSIM commute=#{verdict_text(commute)} result=#{if failed, do: "fail", else: "pass"}")
    if failed, do: exit({:shutdown, 1})
  end

  defp cells_of(spi, limit) do
    spir = Path.rootname(spi) <> "_real.spir"
    doc = Spiral.Kino.Document.parse_spi(File.read!(spi), if(File.regular?(spir), do: File.read!(spir), else: ""))
    cells = for %{kind: :spiral, source: source} <- doc.cells, do: source
    if limit, do: Enum.take(cells, limit), else: cells
  end

  defp executor("fake", _spi, _memo), do: Xsim.Executors.fake()
  defp executor("fake-leak", _spi, _memo), do: Xsim.Executors.fake(:leak)
  defp executor("kino", spi, memo), do: Xsim.Executors.kino([root: Path.dirname(Path.expand(spi)), spiral_lib: Path.dirname(Path.expand(spi))] ++ memo)

  defp summary(scenario, deliveries, state, verdicts, schedule, ms) do
    fields = [
      seed: scenario.seed,
      schedule: schedule,
      posts: length(scenario.posts),
      events: length(scenario.events),
      deliveries: length(deliveries),
      duplicates: state.world.duplicates,
      buffered: state.world.buffered,
      framed: state.world.framed,
      starts: state.starts |> Map.values() |> Enum.sum(),
      prefixes: map_size(state.results),
      peak_results: state.peak_results,
      evictions: state.evicted |> Map.values() |> Enum.sum(),
      cancels: state.cancels,
      visible: map_size(state.visible),
      peak_inflight: state.peak_inflight,
      peak_beam_mb: state.peak_beam_mb,
      ms: ms
    ]

    checks = Enum.map_join(verdicts, " ", fn {name, v} -> "#{name}=#{verdict_text(v)}" end)
    "XSIM " <> Enum.map_join(fields, " ", fn {k, v} -> "#{k}=#{v}" end) <> " " <> checks
  end

  defp explain(state, verdicts, baseline) do
    case List.keyfind(verdicts, :sequential_equivalence, 0) do
      {_, {:violations, [id | _]}} ->
        {key, result} = state.visible[id]
        ^key = Xsim.World.wanted(state.world)[id]
        sources = Xsim.World.sources(state.world, id)
        fresh = baseline.(sources)
        IO.puts("XSIM explain #{id} cells=#{length(sources)}\n  concurrent=#{String.slice(inspect(result), 0, 900)}\n  sequential=#{String.slice(inspect(fresh), 0, 900)}")

      _ ->
        :ok
    end
  end

  defp daemon_line(reading, schedule) do
    "  daemon pid=#{reading.daemon} peak_mb=#{reading.peak_mb} last_mb=#{reading.last_mb} procs=#{reading.procs} samples=#{reading.samples} cumulative_after_schedule=#{schedule}"
  end

  defp verdict_text(:ok), do: "ok"
  defp verdict_text({:violations, ids}), do: "FAIL[#{Enum.join(ids, ",")}]"
end
