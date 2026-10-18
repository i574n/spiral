defmodule Spiral.Cells.MountsNameTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Mounts

  test "a hyphenated package directory mounts under a name the package syntax reads as one package" do
    assert Mounts.mount_name("C:/home/git/tibia/target/zig-oracle-c") == "zig_oracle_c"
    assert Mounts.mount_name("/repo/lab/dota-lua-bindings") == "dota_lua_bindings"
  end

  test "valid names stay as they are and a leading digit gets a prefix" do
    assert Mounts.mount_name("/repo/src") == "src"
    assert Mounts.mount_name("/repo/lab/2d.grid") == "_2d_grid"
  end
end
