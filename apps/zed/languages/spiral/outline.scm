(test_header
  (test_keyword) @context
  name: (test_name) @name) @item

(definition_line
  (definition_keyword) @context
  name: (definition_name) @name
  (#not-match? @context "^open")) @item
