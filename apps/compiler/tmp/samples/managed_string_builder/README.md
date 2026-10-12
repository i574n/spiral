# Managed string builder

Builds `abcabc` through repeated runtime-selected managed concatenation in a tail-recursive loop. The C, Rust and Delphi outputs must preserve ownership across each accumulator handoff and exit zero after checking length and edge bytes.