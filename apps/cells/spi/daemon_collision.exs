[live, copy, root] = System.argv()
alias Spiral.Cells.CompilerDaemon
target = CompilerDaemon.build_port(live, root)
%{mtime: base} = File.stat!(copy, time: :posix)

hit =
  Enum.find(1..200, fn n ->
    File.touch!(copy, base + n)
    CompilerDaemon.build_port(copy, root) == target
  end)

IO.puts("live_port=#{target} copy_mtime_offset=#{hit} copy_port=#{CompilerDaemon.build_port(copy, root)} next_slot=#{CompilerDaemon.slot_port(target, 1)}")
