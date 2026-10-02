defmodule Spiral.KinoTest do
  use ExUnit.Case, async: false

  import ExUnit.CaptureIO
  import Spiral.Kino.TestHelpers

  alias Spiral.Kino.{ProcessError, Result, SpiralError, TimeoutError}

  setup do
    dir = tmp_dir!("pipeline")

    script =
      script!(dir, "fake_repl", """
      main([Dib, Ipynb, Fixture, ExitCode, DibCopy, Log, Sleep]) ->
          {ok, _} = file:copy(Dib, DibCopy),
          case Fixture of
              "none" -> ok;
              _ -> {ok, _} = file:copy(Fixture, Ipynb)
          end,
          io:format("~s~n", [Log]),
          timer:sleep(list_to_integer(Sleep)),
          halt(list_to_integer(ExitCode)).
      """)

    {:ok, dir: dir, script: script, dib_copy: Path.join(dir, "seen.dib")}
  end

  defp fake(ctx, fixture, opts \\ []) do
    fixture = if fixture == :none, do: "none", else: fixture(fixture)

    fn %{dib: dib, ipynb: ipynb} ->
      {escript(),
       [
         ctx.script,
         dib,
         ipynb,
         fixture,
         Integer.to_string(Keyword.get(opts, :exit, 0)),
         ctx.dib_copy,
         Keyword.get(opts, :log, "fake repl"),
         Integer.to_string(Keyword.get(opts, :sleep, 0))
       ]}
    end
  end

  test "success: value, stdout and the generated .dib", ctx do
    assert {:ok, %Result{} = result} =
             Spiral.Kino.run("console.write_line \"hello from spiral\"\n1i32 + 2i32\n",
               command: fake(ctx, "success.ipynb"),
               backend: "lua",
               print_code: true,
               timeout: 30_000
             )

    assert result.value == "3"
    assert result.stdout == "hello from spiral\n"
    assert result.exit_status == 0
    assert result.log =~ "fake repl"

    assert result.source ==
             "///> lua\n///- --print-code\nconsole.write_line \"hello from spiral\"\n1i32 + 2i32\n"

    assert File.read!(ctx.dib_copy) == Spiral.Kino.Notebook.dib(result.source)
  end

  test "temporary files are removed unless :keep_files", ctx do
    {:ok, _} = Spiral.Kino.run("1i32", command: fake(ctx, "success.ipynb"), timeout: 30_000)
    test_pid = self()

    command = fn paths ->
      send(test_pid, {:paths, paths})
      fake(ctx, "success.ipynb").(paths)
    end

    {:ok, _} = Spiral.Kino.run("1i32", command: command, timeout: 30_000)
    assert_received {:paths, %{dib: dib}}
    refute File.exists?(dib)

    {:ok, _} = Spiral.Kino.run("1i32", command: command, timeout: 30_000, keep_files: true)
    assert_received {:paths, %{dib: dib, ipynb: ipynb}}
    assert File.exists?(dib) and File.exists?(ipynb)
    File.rm_rf!(Path.dirname(dib))
  end

  test "Spiral compile error becomes a SpiralError with a clean message", ctx do
    assert {:error, %SpiralError{message: message, result: %Result{}}} =
             Spiral.Kino.run("1i32 + \"a\"",
               command: fake(ctx, "type_error.ipynb", exit: 2),
               timeout: 30_000
             )

    assert message =~ "main.spi:5:12: Unification failure."
    refute message =~ "spiral_Eval"
  end

  test "nonzero exit without a Spiral error is a ProcessError", ctx do
    assert {:error, %ProcessError{exit_status: 1, message: message}} =
             Spiral.Kino.run("1i32",
               command: fake(ctx, "success.ipynb", exit: 1),
               timeout: 30_000
             )

    assert message =~ "exited with status 1"
    assert message =~ "fake repl"
  end

  test "missing notebook output is a ProcessError", ctx do
    assert {:error, %ProcessError{message: message}} =
             Spiral.Kino.run("1i32", command: fake(ctx, :none, exit: 0), timeout: 30_000)

    assert message =~ "wrote no notebook output"
  end

  test "a missing Spiral kernel gets an actionable hint", ctx do
    log = "Microsoft.DotNet.Interactive.NoSuitableKernelException: No kernel found"

    assert {:error, %ProcessError{message: message}} =
             Spiral.Kino.run("1i32",
               command: fake(ctx, :none, exit: 2, log: log),
               timeout: 30_000
             )

    assert message =~ "No `spiral` kernel was found"
    assert message =~ "dotnet-tools.json"
  end

  test "timeout", ctx do
    assert {:error, %TimeoutError{timeout: 3_000, message: message}} =
             Spiral.Kino.run("1i32",
               command: fake(ctx, "success.ipynb", sleep: 60_000),
               timeout: 3_000
             )

    assert message =~ "timed out after 3s"
  end

  test "invalid options" do
    assert_raise ArgumentError, ~r/:timeout/, fn -> Spiral.Kino.run("1", timeout: 0) end

    assert_raise ArgumentError, ~r/unknown Spiral backend/, fn ->
      Spiral.Kino.run("1", backend: "x")
    end
  end

  test "missing polyglot checkout", _ctx do
    assert {:error, %ProcessError{message: message}} =
             Spiral.Kino.run("1i32",
               polyglot_root: Path.join(System.tmp_dir!(), "no-such-polyglot")
             )

    assert message =~ "polyglot checkout not found"
    assert message =~ "SPIRAL_KINO_POLYGLOT_ROOT"
  end

  describe "eval!/2" do
    test "prints stdout and returns the result", ctx do
      output =
        capture_io(fn ->
          assert %Result{value: "3"} =
                   Spiral.Kino.eval!("1i32",
                     command: fake(ctx, "success.ipynb"),
                     timeout: 30_000
                   )
        end)

      assert output == "hello from spiral\n"
    end

    test "returns Kino.nothing() without a value and for empty code", ctx do
      assert Spiral.Kino.eval!("   \n") == Kino.nothing()

      capture_io(fn ->
        assert Spiral.Kino.eval!("1i32", command: fake(ctx, "lua.ipynb"), timeout: 30_000) !=
                 Kino.nothing()
      end)
    end

    test "raises on Spiral errors", ctx do
      assert_raise SpiralError, ~r/Unification failure/, fn ->
        Spiral.Kino.eval!("x", command: fake(ctx, "type_error.ipynb", exit: 2), timeout: 30_000)
      end
    end

    test "raises on timeout", ctx do
      assert_raise TimeoutError, fn ->
        Spiral.Kino.eval!("x",
          command: fake(ctx, "success.ipynb", sleep: 60_000),
          timeout: 2_000
        )
      end
    end
  end

  test "Kino.Render shows the value" do
    assert %{type: :terminal_text, text: "3"} =
             Kino.Render.to_livebook(%Result{value: "3"})

    assert %{type: :plain_text, text: "(no value)"} = Kino.Render.to_livebook(%Result{})
  end
end
