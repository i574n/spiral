# Managed tuple ownership fixture

This portable-backend fixture exercises two aliases of one resizable managed array crossing a tuple boundary.

It proves that:

- grouped residual reference-count increments are preserved independently;
- ordinary tuple fields can move into locals instead of being cloned gratuitously;
- tail-return calls transfer their managed parameters;
- terminal drops release aliases at the same semantic point in C, Rust and Delphi;
- geometric reserve remains visible through aliases;
- the measured reference-count sequence is 2 before tuple construction, 7 inside the tuple consumer and 2 after the tuple is consumed.

The expected native exit code is zero for C, Rust and Delphi. The canonical result is computed from capacity 4, two values 7, and the refcount probes 2, 7 and 2.
