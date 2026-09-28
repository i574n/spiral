# frontier_try_item

Hopac frontier rung 3. `try_item` is copied verbatim from `lib/spiral/listm'.spi`, where the full
`apps/spiral` Hopac build fails (`3006.jsonl`):

    PartEvalTypeError ... "Expected a numberic type (f32,f64,i8,...,u64) as the type of literal. Got: ?
    Compiler: par"  with  EvalReplayTyReturn (YMetavar ...)

The literal `1` in `try_item (i - 1) xs` is typed through `i`'s metavariable; the parallel evaluator
replays the inlined recursion before that metavariable is resolved. The single-flight core compiles this
(the call site supplies `1i32`, as apps/spiral does). `main` returns 0 when item 1 is 42.
