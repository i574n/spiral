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
func sp_method1(_ p0: Int32, _ p1: String) -> String {
    var v0: Int32 = p0
    var v1: String = p1
    while true {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            return v1
        } else {
            var v4: Int32 = 0
            v4 = (v2 % 2)
            var v5: Bool = false
            v5 = (v4 == 0)
            var v8: String = ""
            if (v5) {
                var v6: String = ""
                v6 = "ok"
                v8 = v6
            } else {
                var v7: String = ""
                v7 = "go"
                v8 = v7
            }
            v0 = v2
            v1 = v8
            continue
        }
    }
    return ""
}
func sp_method0() -> String {
    var v0: Int32 = 0
    v0 = 1000000
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = "seed"
        return v2
    } else {
        var v3: Int32 = 0
        v3 = (v0 % 2)
        var v4: Bool = false
        v4 = (v3 == 0)
        var v7: String = ""
        if (v4) {
            var v5: String = ""
            v5 = "ok"
            v7 = v5
        } else {
            var v6: String = ""
            v6 = "go"
            v7 = v6
        }
        return sp_method1(v0, v7)
    }
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = sp_method0()
    var v1: Int32 = 0
    v1 = spiralStringLength(v0)
    var v2: Bool = false
    v2 = (v1 == 2)
    if (v2) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
