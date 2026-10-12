# Native multi-module function boundary

This fixture compiles a package with separate `math.spi` and `main.spi` modules. A three-argument function defined in `math` is called from `main`; C, Rust and Delphi must emit and execute the same native first-order function boundary without ABI adapters or target-specific macros.
