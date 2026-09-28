# ABI callback fixture

Passes a backend-defined cdecl comparator callback to libc qsort. Foreign code invokes the callback, sorts three i32 values, and the wrapper packs the result as 123.
