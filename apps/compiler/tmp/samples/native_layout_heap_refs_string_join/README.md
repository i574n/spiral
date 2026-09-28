# Managed string heap references

This typed Spiral fixture proves that a managed string inside `heap_refs` is replaced before the displaced value is dropped, remains visible through an `Rc` or class alias, crosses two joins and is finalized with the heap root. Expected native exit code: 42.
