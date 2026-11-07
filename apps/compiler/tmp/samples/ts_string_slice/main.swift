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
func sp_middle_0(_ p0: String) -> String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 1, 3)
    return v1
}
func spiral_main() -> Int32 {
    let v0: String = "alpha"
    var v1: String = ""
    v1 = sp_middle_0(v0)
    let v2: Int32 = spiralStringLength(v1)
    let v3: Bool = (v2 == 3)
    if (v3) {
        let v4: Int32 = spiralStringIndex(v1, 0)
        let v5: Bool = (v4 == 108)
        if (v5) {
            let v6: Int32 = spiralStringIndex(v1, 2)
            let v7: Bool = (v6 == 104)
            if (v7) {
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
