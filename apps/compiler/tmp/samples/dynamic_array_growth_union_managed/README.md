# Managed-union geometric growth

This fixture keeps a zero-length dynamic `i32` array alive across a managed union while reserve requests cross the sequence 1, 2, 3, 5 and 9.

The expected capacities are 1, 2, 4, 8 and 16. It also probes the reference count before the union transfer, inside the union consumer and after ownership returns to the caller.

The program exits zero only when geometric growth and the ownership baselines agree in C, Rust and Delphi.
