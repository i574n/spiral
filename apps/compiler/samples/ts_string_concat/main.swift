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
func sp_choose_left_0(_ p0: Bool) -> String {
    var v0: Bool = p0
    if (v0) {
        var v1: String = ""
        v1 = "spi"
        return v1
    } else {
        var v2: String = ""
        v2 = "bad"
        return v2
    }
}
func sp_choose_right_1(_ p0: Bool) -> String {
    var v0: Bool = p0
    if (v0) {
        var v1: String = ""
        v1 = "bad"
        return v1
    } else {
        var v2: String = ""
        v2 = "ral"
        return v2
    }
}
func spiral_main() -> Int32 {
    let v0: Bool = true
    var v1: String = ""
    v1 = sp_choose_left_0(v0)
    var v2: Bool = false
    v2 = false
    let v3: String = sp_choose_right_1(v2)
    let v4: String = (v1 + v3)
    let v5: Int32 = spiralStringLength(v4)
    let v6: Bool = (v5 == 6)
    if (v6) {
        let v7: Int32 = spiralStringIndex(v4, 0)
        let v8: Bool = (v7 == 115)
        if (v8) {
            let v9: Int32 = spiralStringIndex(v4, 5)
            let v10: Bool = (v9 == 108)
            if (v10) {
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
