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
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "é"
    var v1: Int32 = 0
    v1 = spiralStringLength(v0)
    var v2: Int32 = 0
    v2 = spiralStringIndex(v0, 0)
    var v3: Int32 = 0
    v3 = spiralStringIndex(v0, 1)
    var v4: String = ""
    v4 = "x"
    var v5: String = ""
    v5 = (v0 + v4)
    var v6: Int32 = 0
    v6 = spiralStringLength(v5)
    var v7: String = ""
    v7 = "ab"
    var v8: Int32 = 0
    v8 = spiralStringIndex(v7, 0)
    var v9: String = ""
    v9 = spiralStringSlice(v7, 0, 0)
    var v10: Int32 = 0
    v10 = spiralStringLength(v9)
    var v11: String = ""
    v11 = spiralStringSlice(v7, 1, 0)
    var v12: Int32 = 0
    v12 = spiralStringLength(v11)
    var v13: String = ""
    v13 = spiralStringSlice(v0, 0, 1)
    var v14: Int32 = 0
    v14 = spiralStringLength(v13)
    var v15: Bool = false
    v15 = (v2 == v3)
    if (v15) {
        return 1
    } else {
        var v16: Bool = false
        v16 = (v1 == 2)
        var v18: Bool = false
        if (v16) {
            var v17: Bool = false
            v17 = (v8 == 97)
            v18 = v17
        } else {
            v18 = false
        }
        var v20: Bool = false
        if (v18) {
            var v19: Bool = false
            v19 = (v6 == 3)
            v20 = v19
        } else {
            v20 = false
        }
        var v22: Bool = false
        if (v20) {
            var v21: Bool = false
            v21 = (v10 == 1)
            v22 = v21
        } else {
            v22 = false
        }
        var v24: Bool = false
        if (v22) {
            var v23: Bool = false
            v23 = (v12 == 0)
            v24 = v23
        } else {
            v24 = false
        }
        var v26: Bool = false
        if (v24) {
            var v25: Bool = false
            v25 = (v14 == 2)
            v26 = v25
        } else {
            v26 = false
        }
        if (v26) {
            return 0
        } else {
            return 1
        }
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
