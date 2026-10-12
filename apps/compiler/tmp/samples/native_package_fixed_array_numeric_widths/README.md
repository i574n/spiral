# Native package fixed-array numeric widths

Parity fixture for ordinary owner-local fixed arrays using mature primitive widths already supported by Lua, Gleam, C++, Python/CUDA and CUDA codegen paths. The worker owns one `int64_t` array and one `double` array, performs bounded runtime reads and exactly-once computed writes, and returns 42 in C, Rust and Delphi.

The fixture deliberately does not introduce tuple, closure, managed-string or recursive aggregate scalarization. Those families remain on their dedicated lowering paths.
