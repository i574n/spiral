# Dynamic array geometric reserve growth

This fixture creates a zero-length dynamic `i32` array and requests capacity three through a residual helper.

The portable runtimes must apply the shared geometric policy and report capacity four. C uses the bounded oracle shim, Rust exercises `Vec::reserve_exact`, and Delphi exercises the resizable class runtime.

The program exits zero only when the observed capacity is exactly four.
