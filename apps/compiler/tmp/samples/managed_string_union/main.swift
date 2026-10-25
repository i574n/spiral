import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Text: US0 { var f0: String; var tag: Int32 { 0 } }
struct US0_Number: US0 { var f0: Int32; var tag: Int32 { 1 } }
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
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v3: Int32 = (v0 as! US0_Number).f0
            return v3
        case 0:
            var v1: String = (v0 as! US0_Text).f0
            var v2: Int32 = 0
            v2 = spiralStringLength(v1)
            return v2
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    let v0: Bool = false
    var v4: US0 = US0_Text(f0: "")
    if (v0) {
        v4 = US0_Number(f0: 7)
    } else {
        var v2: String = ""
        v2 = "qwe"
        v4 = US0_Text(f0: v2)
    }
    let v5: Int32 = sp_score_0(v4)
    let v6: Int32 = sp_score_0(v4)
    let v7: Int32 = (v5 &+ v6)
    let v8: Int32 = (v7 &- 6)
    return v8
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
