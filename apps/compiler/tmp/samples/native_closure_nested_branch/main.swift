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
func left_c0(_ v0: String, _ v1: Int32) -> (Int32) -> Int32 {
    return { (v2: Int32) -> Int32 in
        var v3: Bool = false
        v3 = (v2 > 0)
        if (v3) {
            var v4: Int32 = 0
            v4 = spiralStringLength(v0)
            var v5: Int32 = 0
            v5 = (v4 &+ v1)
            var v6: Int32 = 0
            v6 = (v5 &+ v2)
            return v6
        } else {
            return 0
        }
    }
}
func right_c1(_ v0: String, _ v1: Int32) -> (Int32) -> Int32 {
    return { (v2: Int32) -> Int32 in
        var v3: Bool = false
        v3 = (v2 > 0)
        if (v3) {
            var v4: Int32 = 0
            v4 = spiralStringLength(v0)
            var v5: Int32 = 0
            v5 = (v4 &+ v1)
            var v6: Int32 = 0
            v6 = (v5 &+ v2)
            var v7: Int32 = 0
            v7 = (v6 &- 1)
            return v7
        } else {
            return -1
        }
    }
}
func sp_method0(_ p0: @escaping (Int32) -> Int32) -> Int32 {
    var v0: (Int32) -> Int32 = p0
    return v0(37)
}
func spiral_main() -> Int32 {
    let v0: String = "abc"
    let v1: String = "wxyz"
    let v2: Int32 = 2
    var v3: Int32 = 0
    v3 = 2
    var v4: Bool = false
    v4 = true
    var v7: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    if (v4) {
        v7 = left_c0(v0, v2)
    } else {
        v7 = right_c1(v1, v3)
    }
    return sp_method0(v7)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
