# Python annotations of macro types

A macro type whose text is another backend's (`Result<i32, string>`, `System.Threading.CancellationToken`, as
lib/spiral's types often are) used to be written verbatim into the annotations Python evaluates: a method's
parameters and a union case's NamedTuple fields, a SyntaxError or NameError when the definition runs. A (subscripted)
dotted name is now written as a string (a forward reference) and any other text as `object`. The C row is the oracle:
both exit with 24.