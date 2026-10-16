import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Empty: US0 { var tag: Int32 { 0 } }
struct US0_Item: US0 { var f0: String; var f1: SpiralArray<Int32>; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
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
            var v3: SpiralArray<Int32> = SpiralArray<Int32>([])
            v3 = SpiralArray<Int32>(Array(repeating: 0, count: Int(2)))
            v3.items[Int(0)] = v0
            var v4: Int32 = 0
            v4 = (v0 &+ 1)
            v3.items[Int(1)] = v4
            var v5: String = ""
            v5 = "hi"
            return US0_Item(f0: v5, f1: v3)
        }
    }
}
func sp_method0(_ p0: @escaping (Int32) -> US0) -> US0 {
    var v0: (Int32) -> US0 = p0
    return v0(0)
}
func sp_method1(_ p0: @escaping (Int32) -> US0) -> US0 {
    var v0: (Int32) -> US0 = p0
    return v0(4)
}
func spiral_main() -> Int32 {
    var v0: (Int32) -> US0 = { (_: Int32) -> US0 in fatalError("unreachable closure") }
    v0 = closure0()
    var v1: US0 = US0_Empty()
    v1 = sp_method0(v0)
    var v12: Int32 = 0
    switch v1.tag {
        case 0:
            v12 = 3
        case 1:
            var v2: String = (v1 as! US0_Item).f0
            var v3: SpiralArray<Int32> = (v1 as! US0_Item).f1
            var v4: Int32 = 0
            v4 = spiralStringLength(v2)
            var v5: Int32 = 0
            v5 = Int32(v3.items.count)
            var v6: Int32 = 0
            v6 = (v4 &+ v5)
            var v7: Int32 = 0
            v7 = v3.items[Int(0)]
            var v8: Int32 = 0
            v8 = (v6 &+ v7)
            var v9: Int32 = 0
            v9 = v3.items[Int(1)]
            var v10: Int32 = 0
            v10 = (v8 &+ v9)
            v12 = v10
        default:
            fatalError("unreachable union case")
    }
    var v13: US0 = US0_Empty()
    v13 = sp_method1(v0)
    var v24: Int32 = 0
    switch v13.tag {
        case 0:
            v24 = 3
        case 1:
            var v14: String = (v13 as! US0_Item).f0
            var v15: SpiralArray<Int32> = (v13 as! US0_Item).f1
            var v16: Int32 = 0
            v16 = spiralStringLength(v14)
            var v17: Int32 = 0
            v17 = Int32(v15.items.count)
            var v18: Int32 = 0
            v18 = (v16 &+ v17)
            var v19: Int32 = 0
            v19 = v15.items[Int(0)]
            var v20: Int32 = 0
            v20 = (v18 &+ v19)
            var v21: Int32 = 0
            v21 = v15.items[Int(1)]
            var v22: Int32 = 0
            v22 = (v20 &+ v21)
            v24 = v22
        default:
            fatalError("unreachable union case")
    }
    var v25: Int32 = 0
    v25 = (v12 &+ v24)
    var v26: Int32 = 0
    v26 = (v25 &+ 26)
    return v26
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
