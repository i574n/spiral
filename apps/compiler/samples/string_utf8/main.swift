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
    let v1: Int32 = spiralStringLength(v0)
    let v2: Int32 = spiralStringIndex(v0, 0)
    let v3: Int32 = spiralStringIndex(v0, 1)
    let v4: String = "x"
    let v5: String = (v0 + v4)
    let v6: Int32 = spiralStringLength(v5)
    let v7: String = "ab"
    let v8: Int32 = spiralStringIndex(v7, 0)
    let v9: String = spiralStringSlice(v7, 0, 0)
    let v10: Int32 = spiralStringLength(v9)
    let v11: String = spiralStringSlice(v7, 1, 0)
    let v12: Int32 = spiralStringLength(v11)
    let v13: String = spiralStringSlice(v0, 0, 1)
    let v14: Int32 = spiralStringLength(v13)
    let v15: Bool = (v2 == v3)
    if (v15) {
        return 1
    } else {
        let v16: Bool = (v1 == 2)
        var v18: Bool = false
        if (v16) {
            let v17: Bool = (v8 == 97)
            v18 = v17
        } else {
            v18 = false
        }
        var v20: Bool = false
        if (v18) {
            let v19: Bool = (v6 == 3)
            v20 = v19
        } else {
            v20 = false
        }
        var v22: Bool = false
        if (v20) {
            let v21: Bool = (v10 == 1)
            v22 = v21
        } else {
            v22 = false
        }
        var v24: Bool = false
        if (v22) {
            let v23: Bool = (v12 == 0)
            v24 = v23
        } else {
            v24 = false
        }
        var v26: Bool = false
        if (v24) {
            let v25: Bool = (v14 == 2)
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
