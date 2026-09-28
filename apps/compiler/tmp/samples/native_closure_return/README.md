# Native closure return

This fixture proves that a Spiral function can return a callable value carrying a managed string capture. The returned closure crosses a real function boundary and is invoked later. C, Rust, and Delphi must all exit with code 42.

The portable backends derive the callable from the mature C residual rather than recognizing this fixture by name.
