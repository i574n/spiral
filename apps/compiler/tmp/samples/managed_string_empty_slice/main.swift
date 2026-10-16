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
    var v0: String = ""
    v0 = "alpha"
    var v1: String = ""
    v1 = sp_empty_middle_0(v0)
    var v2: String = ""
    v2 = sp_empty_end_1(v0)
    var v3: String = ""
    v3 = ""
    var v4: String = ""
    v4 = sp_empty_source_2(v3)
    var v5: String = ""
    v5 = (v1 + v2)
    var v6: String = ""
    v6 = (v4 + "ok")
    var v7: String = ""
    v7 = (v5 + v6)
    var v8: Int32 = 0
    v8 = spiralStringLength(v1)
    var v9: Bool = false
    v9 = (v8 == 0)
    if (v9) {
        var v10: Int32 = 0
        v10 = spiralStringLength(v2)
        var v11: Bool = false
        v11 = (v10 == 0)
        if (v11) {
            var v12: Int32 = 0
            v12 = spiralStringLength(v4)
            var v13: Bool = false
            v13 = (v12 == 0)
            if (v13) {
                var v14: Int32 = 0
                v14 = spiralStringLength(v7)
                var v15: Bool = false
                v15 = (v14 == 2)
                if (v15) {
                    var v16: Int32 = 0
                    v16 = spiralStringIndex(v7, 0)
                    var v17: Bool = false
                    v17 = (v16 == 111)
                    if (v17) {
                        var v18: Int32 = 0
                        v18 = spiralStringIndex(v7, 1)
                        var v19: Bool = false
                        v19 = (v18 == 107)
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
exit(spiral_main())
