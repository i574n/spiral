import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Empty: US0 { var tag: Int32 { 0 } }
struct US0_Item: US0 { var f0: String; var f1: Int32; var tag: Int32 { 1 } }
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
func closure0() -> (Int32) -> US0 {
    return { (v0: Int32) -> US0 in
        var v1: Bool = false
        v1 = (v0 == 0)
        if (v1) {
            return US0_Empty()
        } else {
            var v3: String = ""
            v3 = "managed"
            return US0_Item(f0: v3, f1: 32)
        }
    }
}
func sp_method0(_ p0: @escaping (Int32) -> US0) -> US0 {
    var v0: (Int32) -> US0 = p0
    return v0(0)
}
func sp_method1(_ p0: @escaping (Int32) -> US0) -> US0 {
    var v0: (Int32) -> US0 = p0
    return v0(1)
}
func spiral_main() -> Int32 {
    var v0: (Int32) -> US0 = { (_: Int32) -> US0 in fatalError("unreachable closure") }
    v0 = closure0()
    var v1: US0 = US0_Empty()
    v1 = sp_method0(v0)
    var v7: Int32 = 0
    switch v1.tag {
        case 0:
            v7 = 3
        case 1:
            var v2: String = (v1 as! US0_Item).f0
            var v3: Int32 = (v1 as! US0_Item).f1
            var v4: Int32 = 0
            v4 = spiralStringLength(v2)
            var v5: Int32 = 0
            v5 = (v4 &+ v3)
            v7 = v5
        default:
            fatalError("unreachable union case")
    }
    var v8: US0 = US0_Empty()
    v8 = sp_method1(v0)
    var v14: Int32 = 0
    switch v8.tag {
        case 0:
            v14 = 3
        case 1:
            var v9: String = (v8 as! US0_Item).f0
            var v10: Int32 = (v8 as! US0_Item).f1
            var v11: Int32 = 0
            v11 = spiralStringLength(v9)
            var v12: Int32 = 0
            v12 = (v11 &+ v10)
            v14 = v12
        default:
            fatalError("unreachable union case")
    }
    var v15: Int32 = 0
    v15 = (v7 &+ v14)
    return v15
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
