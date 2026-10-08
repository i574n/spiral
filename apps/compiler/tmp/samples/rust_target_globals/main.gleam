import gleam/bit_array
import gleam/string
@external(erlang, "erlang", "halt")
pub fn spiral_halt(code: Int) -> a

pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

pub fn spiral_string_index(text: String, index: Int) -> String {
  case bit_array.slice(bit_array.from_string(text), index, 1) {
    Ok(<<byte>>) ->
      case string.utf_codepoint(byte) {
        Ok(codepoint) -> string.from_utf_codepoints([codepoint])
        Error(_) -> spiral_halt(3)
      }
    _ -> spiral_halt(3)
  }
}

pub fn spiral_string_slice(text: String, from: Int, to: Int) -> String {
  let bytes = bit_array.from_string(text)
  let length = bit_array.byte_size(bytes)
  case from < 0 || from > length || to < from - 1 || to >= length {
    True -> spiral_halt(3)
    False ->
      case to < from {
        True -> ""
        False ->
          case bit_array.slice(bytes, from, to - from + 1) {
            Ok(part) ->
              case bit_array.to_string(part) {
                Ok(slice) -> slice
                Error(_) -> spiral_halt(3)
              }
            Error(_) -> spiral_halt(3)
          }
      }
  }
}

pub fn target_global_0(v0: String) -> Nil {
    let _v1 = spiral_string_length(v0)
    Nil
}
pub fn main() {
let v0 = "SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_pos-p_B64:Ly9Q"
target_global_0(v0)
target_global_0(v0)
let v1 = "SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_pos-b_B64:Ly9C"
target_global_0(v1)
let v2 = "SPIRAL_TARGET_GLOBAL_RUST_AFTER_MAIN_test-item_B64:Zm4gc3BpcmFsX2F0dHJpYnV0ZV9zbW9rZSgpIHsKICAgIGFzc2VydF9lcSEoNiAqIDcsIDQyKTsKfQo="
target_global_0(v2)
let v3 = "SPIRAL_ITEM_METADATA_TEST_test-item"
target_global_0(v3)
let v4 = "SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_pos-p_B64:Ly9Q"
target_global_0(v4)
target_global_0(v4)
let v5 = "SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_pos-b_B64:Ly9C"
target_global_0(v5)
let v6 = "SPIRAL_TARGET_GLOBAL_DELPHI_AFTER_MAIN_test-item_B64:cHJvY2VkdXJlIFNwaXJhbFRhcmdldEdsb2JhbFNtb2tlOwpiZWdpbgogIGlmIDYgKiA3IDw+IDQyIHRoZW4gSGFsdCgxKTsKZW5kOwo="
target_global_0(v6)
0
}
