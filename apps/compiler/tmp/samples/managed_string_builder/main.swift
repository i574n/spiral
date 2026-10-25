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
func sp_method2(_ p0: Int32, _ p1: String, _ p2: String) -> String {
    var v0: Int32 = p0
    var v1: String = p1
    var v2: String = p2
    while true {
        var v3: Int32 = 0
        v3 = (v0 &- 1)
        var v4: String = ""
        v4 = (v1 + v2)
        var v5: Bool = false
        v5 = (v3 == 0)
        if (v5) {
            return v4
        } else {
            var v6: Int32 = 0
            v6 = (v3 % 2)
            var v7: Bool = false
            v7 = (v6 == 0)
            var v10: String = ""
            if (v7) {
                var v8: String = ""
                v8 = "ab"
                v10 = v8
            } else {
                var v9: String = ""
                v9 = "c"
                v10 = v9
            }
            let t773_3: Int32 = v3
            let t809_4: String = v4
            let t846_10: String = v10
            v0 = t773_3
            v1 = t809_4
            v2 = t846_10
            continue
        }
    }
    return ""
}
func sp_method1(_ p0: Int32, _ p1: String) -> String {
    var v0: Int32 = p0
    var v1: String = p1
    var v2: Int32 = 0
    v2 = (v0 &- 1)
    var v3: String = ""
    v3 = ("" + v1)
    var v4: Bool = false
    v4 = (v2 == 0)
    if (v4) {
        return v3
    } else {
        var v5: Int32 = 0
        v5 = (v2 % 2)
        var v6: Bool = false
        v6 = (v5 == 0)
        var v9: String = ""
        if (v6) {
            var v7: String = ""
            v7 = "ab"
            v9 = v7
        } else {
            var v8: String = ""
            v8 = "c"
            v9 = v8
        }
        return sp_method2(v2, v3, v9)
    }
}
func sp_method0() -> String {
    var v0: Int32 = 0
    v0 = 4
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = ""
        return v2
    } else {
        var v3: Int32 = 0
        v3 = (v0 % 2)
        var v4: Bool = false
        v4 = (v3 == 0)
        var v7: String = ""
        if (v4) {
            var v5: String = ""
            v5 = "ab"
            v7 = v5
        } else {
            var v6: String = ""
            v6 = "c"
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
    v2 = (v1 == 6)
    if (v2) {
        var v3: Int32 = 0
        v3 = spiralStringIndex(v0, 0)
        var v4: Bool = false
        v4 = (v3 == 97)
        if (v4) {
            var v5: Int32 = 0
            v5 = spiralStringIndex(v0, 5)
            var v6: Bool = false
            v6 = (v5 == 99)
            if (v6) {
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
