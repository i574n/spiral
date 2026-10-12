# multiline_triple_string

Triple-quoted strings: raw text (no escapes, no interpolation) spanning lines, with quotes, `(*`, `//`, a line
starting with a `$"` macro opener, a column-0 `inl` line and a blank line inside, an empty `""""""`, and a top-level
string whose lines start at column 0. Each value is dynamic, so the backends' string-literal escaping is exercised.
`main` returns 0, or the number of the first failed check.
