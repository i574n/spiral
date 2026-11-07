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
func f_c0(_ v0: String) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = spiralStringLength(v0)
        var v3: Int32 = 0
        v3 = (v2 &+ v1)
        return v3
    }
}
func spiral_main() -> Int32 {
    let v0: String = "abc"
    let v1: (Int32) -> Int32 = f_c0(v0)
    var v2: Int32 = 0
    v2 = v1(10)
    var v3: Int32 = 0
    v3 = v1(20)
    let v4: Int32 = v1(3)
    let v5: Int32 = (v2 &+ v3)
    let v6: Int32 = (v5 &+ v4)
    return v6
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
