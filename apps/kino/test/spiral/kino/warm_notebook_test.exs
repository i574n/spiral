defmodule Spiral.Kino.WarmNotebookTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.CompilerDaemon

  @root Path.expand("../../..", __DIR__)

  setup do
    previous = :persistent_term.get({CompilerDaemon, :source_stamp}, nil)
    :persistent_term.put({CompilerDaemon, :source_stamp}, CompilerDaemon.source_stamp())

    on_exit(fn ->
      if previous, do: :persistent_term.put({CompilerDaemon, :source_stamp}, previous), else: :persistent_term.erase({CompilerDaemon, :source_stamp})
    end)

    %{dir: Spiral.Kino.TestHelpers.tmp_dir!("warm")}
  end

  defp request(args, root \\ @root), do: JSON.encode!(%{"args" => args, "root" => root})

  test "the notebook verb runs the same CLI in the daemon and ends with its exit code", %{dir: dir} do
    livemd = Path.join(dir, "demo.livemd")
    spi = Path.join(dir, "demo.spi")
    File.write!(livemd, "# demo\n\n```spiral\ninl value () = 1i32\n```\n")

    assert {["end\t0"], :keep} =
             CompilerDaemon.notebook_reply(request(["--path", livemd, "--export-only", "--spi-path", spi]))

    assert File.read!(spi) =~ "inl value () = 1i32"

    assert {["error\t" <> message, "end\t1"], :keep} = CompilerDaemon.notebook_reply(request(["--export-only"]))
    assert JSON.decode!(message) =~ "missing --path"
  end

  test "a request for another checkout or with changed Kino sources is refused as stale" do
    assert {["stale\tthe daemon serves another Kino checkout" <> _], :keep} =
             CompilerDaemon.notebook_reply(request(["--path", "x.spi"], "C:/elsewhere/apps/kino"))

    :persistent_term.put({CompilerDaemon, :source_stamp}, 0)
    assert {["stale\tKino sources changed since the daemon started; retiring"], :retire} = CompilerDaemon.notebook_reply(request(["--path", "x.spi"]))
  end

  test "a malformed request is an error, not a crash" do
    assert {["error\t" <> _, "end\t1"], :keep} = CompilerDaemon.notebook_reply("[1, 2]")
  end
end
