# Native managed tail recursion

Carries a runtime-selected managed Spiral string through one million direct self-tail calls. Rust must lower the path to a labelled loop with `Rc<str>` temporaries, and Delphi must lower it to `while True` with `AnsiString` temporaries. C, Rust and Delphi must all exit zero without stack growth.
