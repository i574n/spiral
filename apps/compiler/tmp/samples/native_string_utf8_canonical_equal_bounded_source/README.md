# Bounded UTF-8 canonical equivalence

This fixture proves allocation-free canonical equivalence over the explicit 16-pair Latin normalization table in `samples/core/sm.spi`.

The implementation streams both strings as virtual bounded-NFD scalar sequences. Precomposed scalars leave at most one pending combining mark, so no intermediate string, array or callback is created.

Covered cases include exact equality, empty strings, precomposed versus decomposed Portuguese text, consecutive supported marks, uppercase composition, unsupported scalar pass-through, mark-order inequality, base inequality and unequal stream exhaustion.

This is not full Unicode normalization. Combining-class reordering, recursive decomposition, Hangul algorithms and pairs outside the declared table remain unsupported.
