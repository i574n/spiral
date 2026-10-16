import CRT
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
func sp_measure_0(_ p0: String) -> Int32 {
    var v0: String = p0
    var v1: Int32 = 0
    v1 = spiralStringLength(v0)
    return v1
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "qwe"
    var v1: Int32 = 0
    v1 = sp_measure_0(v0)
    var v2: Int32 = 0
    v2 = sp_measure_0(v0)
    var v3: Int32 = 0
    v3 = (v1 &+ v2)
    var v4: Int32 = 0
    v4 = (v3 &- 6)
    return v4
}
exit(spiral_main())
