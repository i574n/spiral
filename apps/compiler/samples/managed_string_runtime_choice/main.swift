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
func sp_choose_0(_ p0: Bool) -> String {
    var v0: Bool = p0
    if (v0) {
        var v1: String = ""
        v1 = "alpha"
        return v1
    } else {
        var v2: String = ""
        v2 = "beta"
        return v2
    }
}
func sp_measure_1(_ p0: String) -> Int32 {
    var v0: String = p0
    var v1: Int32 = 0
    v1 = spiralStringLength(v0)
    return v1
}
func spiral_main() -> Int32 {
    let v0: Bool = true
    var v1: String = ""
    v1 = sp_choose_0(v0)
    var v2: Bool = false
    v2 = false
    let v3: String = sp_choose_0(v2)
    let v4: Int32 = sp_measure_1(v1)
    let v5: Int32 = sp_measure_1(v1)
    let v6: Int32 = (v4 &+ v5)
    let v7: Int32 = sp_measure_1(v3)
    let v8: Int32 = (v6 &+ v7)
    let v9: Int32 = (v8 &- 14)
    return v9
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
