; Spiral Syntax Highlighting for Zed
; Keywords
(
  (identifier) @keyword
  (#match? @keyword "^(inl|inm|inb|forall|union|nominal|real|type|open|match|typecase|function|with|without|as|when|let|rec|if|then|elif|else|join|join_backend|prototype|instance|in|and|fun|exists)$")
)

; Built-in primitive types
(
  (identifier) @type.builtin
  (#match? @type.builtin "^(i8|i16|i32|i64|u8|u16|u32|u64|f32|f64|bool|string|char|unit)$")
)

; Type constructors, unions, nominals, and PascalCase types
(
  (identifier) @type
  (#match? @type "^[A-Z][a-zA-Z0-9_]*$")
)

; Booleans
[
  (boolean_literal)
  (
    (identifier) @boolean
    (#match? @boolean "^(true|false)$")
  )
] @boolean

; Comments
[
  (line_comment)
  (block_comment)
] @comment

; Strings & Chars
[
  (string_literal)
  (raw_string_literal)
  (char_literal)
] @string

(escape_sequence) @string.escape

; Numbers & numeric literals
[
  (integer_literal)
  (float_literal)
] @number

; Operators
[
  "="
  "+"
  "-"
  "*"
  "/"
  "%"
  "&"
  "|"
  "^"
  "!"
  "<"
  ">"
  "=="
  "!="
  "<="
  ">="
  "&&"
  "||"
  "<<"
  ">>"
  "->"
  "=>"
  "::"
] @operator

; Delimiters
[
  ";"
  ","
  "."
  ":"
] @punctuation.delimiter

; Brackets
[
  "{"
  "}"
  "["
  "]"
  "("
  ")"
] @punctuation.bracket

; Wildcard
(
  (identifier) @variable.special
  (#match? @variable.special "^_$")
)
