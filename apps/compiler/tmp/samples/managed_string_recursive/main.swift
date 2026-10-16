import CRT
import WinSDK
protocol UH0 { var tag: Int32 { get } }
struct UH0_Empty: UH0 { var tag: Int32 { 0 } }
struct UH0_Node: UH0 { var f0: String; var f1: UH0; var f2: UH0; var tag: Int32 { 1 } }
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
func sp_score_0(_ p0: UH0) -> Int32 {
    var v0: UH0 = p0
    switch v0.tag {
        case 0:
            return 0
        case 1:
            var v1: String = (v0 as! UH0_Node).f0
            var v2: UH0 = (v0 as! UH0_Node).f1
            var v3: UH0 = (v0 as! UH0_Node).f2
            var v4: Int32 = 0
            v4 = spiralStringLength(v1)
            var v5: Int32 = 0
            v5 = sp_score_0(v2)
            var v6: Int32 = 0
            v6 = (v4 &+ v5)
            var v7: Int32 = 0
            v7 = sp_score_0(v3)
            var v8: Int32 = 0
            v8 = (v6 &+ v7)
            return v8
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "ab"
    var v1: String = ""
    v1 = "qwe"
    var v2: UH0 = UH0_Empty()
    v2 = UH0_Empty()
    var v3: UH0 = UH0_Empty()
    v3 = UH0_Node(f0: v1, f1: v2, f2: v2)
    var v4: UH0 = UH0_Empty()
    v4 = UH0_Node(f0: v0, f1: v3, f2: v3)
    var v5: Int32 = 0
    v5 = sp_score_0(v4)
    var v6: UH0 = UH0_Empty()
    v6 = UH0_Empty()
    var v7: UH0 = UH0_Empty()
    v7 = UH0_Node(f0: v1, f1: v6, f2: v6)
    var v8: UH0 = UH0_Empty()
    v8 = UH0_Node(f0: v0, f1: v7, f2: v7)
    var v9: Int32 = 0
    v9 = sp_score_0(v8)
    var v10: Int32 = 0
    v10 = (v5 &+ v9)
    var v11: Int32 = 0
    v11 = (v10 &- 16)
    return v11
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
