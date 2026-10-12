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
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "é"
    var v1: String = ""
    v1 = "x"
    var v2: String = ""
    v2 = (v0 + v1)
    var v3: String = ""
    v3 = "éx"
    var v4: String = ""
    v4 = "éy"
    var v5: String = ""
    v5 = ""
    var v6: String = ""
    v6 = spiralStringSlice(v3, 1, 0)
    var v7: Bool = false
    v7 = (v2 == v3)
    var v9: Bool = false
    if (v7) {
        var v8: Bool = false
        v8 = (v2 != v4)
        v9 = v8
    } else {
        v9 = false
    }
    var v11: Bool = false
    if (v9) {
        var v10: Bool = false
        v10 = (v0 != v3)
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Bool = false
    if (v11) {
        var v12: Bool = false
        v12 = (v5 == v6)
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Bool = false
    if (v13) {
        var v14: Bool = false
        v14 = (v5 != v0)
        v15 = v14
    } else {
        v15 = false
    }
    if (v15) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
