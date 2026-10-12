# Package-owned managed-array failure lifecycle

This fixture keeps `Array0` and `Tuple0` in `types/record`, moves the diverging `fail0` routine to `failure/raise`, and exposes `method0` from `consumer/use` through a three-edge package graph.

The canonical C residual drops the consumed array before `PortableFail` and carries a synthetic trailing return. The portable lowering removes only that unreachable return. Rust catches the panic and proves the surviving `Rc` strong count returns from 2 to 1. Delphi catches the exception and proves the manual refcount returns from 2 to 1 before the final drop reaches nil.

This is not general unwinding, RAII synthesis, multi-owner relocation, or recursive package ownership. It is a bounded owner-preserving lifecycle proof using the same managed dynamic-array family already established by earlier fixtures.
