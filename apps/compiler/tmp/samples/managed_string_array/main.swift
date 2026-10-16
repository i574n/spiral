import CRT
import WinSDK
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
func spiral_main() -> Int32 {
    var v0: SpiralArray<String> = SpiralArray<String>([])
    v0 = SpiralArray<String>(Array(repeating: "", count: Int(2)))
    var v1: String = ""
    v1 = "ab"
    v0.items[Int(0)] = v1
    var v2: String = ""
    v2 = "cde"
    v0.items[Int(1)] = v2
    var v3: String = ""
    v3 = v0.items[Int(0)]
    var v4: String = ""
    v4 = v0.items[Int(1)]
    var v5: Int32 = 0
    v5 = spiralStringLength(v3)
    var v6: Int32 = 0
    v6 = spiralStringLength(v4)
    var v7: Int32 = 0
    v7 = (v5 &+ v6)
    var v8: Int32 = 0
    v8 = (v7 &- 5)
    return v8
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
