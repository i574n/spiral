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
    let v0: String = "é"
    let v1: String = "x"
    let v2: String = (v0 + v1)
    let v3: String = "éx"
    let v4: String = "éy"
    let v5: String = ""
    let v6: String = spiralStringSlice(v3, 1, 0)
    let v7: Bool = (v2 == v3)
    var v9: Bool = false
    if (v7) {
        let v8: Bool = (v2 != v4)
        v9 = v8
    } else {
        v9 = false
    }
    var v11: Bool = false
    if (v9) {
        let v10: Bool = (v0 != v3)
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Bool = false
    if (v11) {
        let v12: Bool = (v5 == v6)
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Bool = false
    if (v13) {
        let v14: Bool = (v5 != v0)
        v15 = v14
    } else {
        v15 = false
    }
    if (v15) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
