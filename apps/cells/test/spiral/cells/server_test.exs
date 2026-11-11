defmodule Spiral.Cells.ServerTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Server

  test "a request forwards SPIRAL_* and the caller's PATH, so tools resolve against the caller, not the server's starter" do
    assert Server.forwarded?("SPIRAL_BUN")
    assert Server.forwarded?("SPIRAL_COMPILER_DLL")
    assert Server.forwarded?("PATH")
    assert Server.forwarded?("Path")
    refute Server.forwarded?("HOME")
    refute Server.forwarded?("MIX_ENV")
  end
end
