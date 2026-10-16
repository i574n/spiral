import CRT
import WinSDK
func spiralStringLength(_ value: String) -> Int32 { Int32(value.utf8.count) }
func spiralStringIndex(_ value: String, _ index: Int32) -> Int32 {
    let bytes = Array(value.utf8)
    let i = Int(index)
    if !(i >= 0 && i < bytes.count) {
        _ = fputs("string index out of bounds\n", stderr)
        exit(1)
    }
    return Int32(Int8(bitPattern: bytes[i]))
}
func spiralStringSlice(_ value: String, _ from: Int32, _ to: Int32) -> String {
    let bytes = Array(value.utf8)
    let length = bytes.count
    let f = Int(from)
    let t = Int(to)
    if f < 0 || f > length || t < f - 1 || t >= length {
        _ = fputs("string slice out of bounds\n", stderr)
        exit(3)
    }
    if t < f { return "" }
    let start = Int(bytes[f])
    let follows = t + 1 < length && (Int(bytes[t + 1]) & 192) == 128
    if (start & 192) == 128 || follows {
        _ = fputs("string slice splits a code point\n", stderr)
        exit(3)
    }
    return String(decoding: bytes[f...t], as: UTF8.self)
}
func sp_first_codepoint_0(_ p0: String) -> String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 0, 1)
    return v1
}
func sp_second_codepoint_1(_ p0: String) -> String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 2, 3)
    return v1
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "éλ"
    var v1: String = ""
    v1 = sp_first_codepoint_0(v0)
    var v2: String = ""
    v2 = sp_second_codepoint_1(v0)
    var v3: String = ""
    v3 = (v1 + v2)
    var v4: Int32 = 0
    v4 = spiralStringLength(v1)
    var v5: Bool = false
    v5 = (v4 == 2)
    if (v5) {
        var v6: Int32 = 0
        v6 = spiralStringLength(v2)
        var v7: Bool = false
        v7 = (v6 == 2)
        if (v7) {
            var v8: Int32 = 0
            v8 = spiralStringLength(v3)
            var v9: Bool = false
            v9 = (v8 == 4)
            if (v9) {
                return 0
            } else {
                return 1
            }
        } else {
            return 2
        }
    } else {
        return 3
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
