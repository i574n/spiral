# Native stack reference layout

This fixture proves local scalar `stack_refs` semantics in the typed residual bridge. Two aliases share stack-backed `Cell`/pointer storage, writes through either view remain visible, and the final scalar result is 15. The restricted bridge rejects escape from `main`.
