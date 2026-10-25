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
func sp_empty_middle_0(_ p0: String) -> String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 2, 1)
    return v1
}
func sp_empty_end_1(_ p0: String) -> String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 5, 4)
    return v1
}
func sp_empty_source_2(_ p0: String) -> String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 0, -1)
    return v1
}
func spiral_main() -> Int32 {
    let v0: String = "alpha"
    var v1: String = ""
    v1 = sp_empty_middle_0(v0)
    let v2: String = sp_empty_end_1(v0)
    let v3: String = ""
    let v4: String = sp_empty_source_2(v3)
    let v5: String = (v1 + v2)
    let v6: String = (v4 + "ok")
    let v7: String = (v5 + v6)
    let v8: Int32 = spiralStringLength(v1)
    let v9: Bool = (v8 == 0)
    if (v9) {
        let v10: Int32 = spiralStringLength(v2)
        let v11: Bool = (v10 == 0)
        if (v11) {
            let v12: Int32 = spiralStringLength(v4)
            let v13: Bool = (v12 == 0)
            if (v13) {
                let v14: Int32 = spiralStringLength(v7)
                let v15: Bool = (v14 == 2)
                if (v15) {
                    let v16: Int32 = spiralStringIndex(v7, 0)
                    let v17: Bool = (v16 == 111)
                    if (v17) {
                        let v18: Int32 = spiralStringIndex(v7, 1)
                        let v19: Bool = (v18 == 107)
                        if (v19) {
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
            } else {
                return 4
            }
        } else {
            return 5
        }
    } else {
        return 6
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
