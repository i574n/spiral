module.exports = grammar({
  name: 'spiral',

  extras: _ => [],

  rules: {
    source_file: $ => seq(
      repeat(seq(optional($._line), $._line_break)),
      optional($._line),
    ),

    _line_break: _ => /\r?\n/,

    _line: $ => choice(
      $.test_header,
      $.target_directive,
      $.doc_comment,
      $.line_comment,
      $.definition_line,
      $.indented_line,
      $.other_line,
    ),

    test_header: $ => seq(
      alias(token(prec(6, /test[ \t]+/)), $.test_keyword),
      field('name', alias(token.immediate(/[^\s=]+/), $.test_name)),
      optional(alias(token.immediate(/[^\r\n]+/), $.test_signature)),
    ),

    target_directive: _ => token(prec(5, /\/\/\/>[^\r\n]*/)),

    doc_comment: _ => token(prec(4, /\/\/\/[^\r\n]*/)),

    line_comment: _ => token(prec(3, /\/\/[^\r\n]*/)),

    definition_line: _ => token(prec(2, /(inl|let|type|union|nominal|prototype|instance|open|and)[ \t][^\r\n]*/)),

    indented_line: _ => token(prec(1, /[ \t]+[^\r\n]*/)),

    other_line: _ => token(prec(0, /[^\r\n]+/)),
  },
});
