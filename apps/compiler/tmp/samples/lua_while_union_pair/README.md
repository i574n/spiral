# Lua while loops and pair payloads

lib/spiral sm'.livemd's `to_char_array` test in small, on core only: `am.init` (a while loop writing an array), a second while loop
whose body has a statement-position `if` and ends in a unit return, and a match on the list it builds, whose `Cons`
case carries a pair payload. Lua used to emit each loop as a `loopN(v0, v1)` helper with `return nil` before another
statement (a syntax error), and bound no variable of a pair payload. The C row is the oracle: exit 235.

Lua is not a harness backend; check it by hand (lua 5.1):
`--backend Lua` into `main.lua`, then `lua -e "os.exit(dofile('main.lua'))"` must exit 235 too.