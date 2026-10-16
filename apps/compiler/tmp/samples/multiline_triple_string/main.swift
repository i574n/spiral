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
    v0 = "a \"b\" c"
    var v1: String = ""
    v1 = ""
    var v2: String = ""
    v2 = "a\\nb"
    var v3: String = ""
    v3 = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
    var v4: String = ""
    v4 = "\ntop\n\nlevel"
    var v5: Int32 = 0
    v5 = spiralStringLength(v0)
    var v6: Bool = false
    v6 = (v5 == 7)
    var v7: Bool = false
    v7 = (v6 != true)
    if (v7) {
        return 1
    } else {
        var v8: Int32 = 0
        v8 = spiralStringIndex(v0, 2)
        var v9: Bool = false
        v9 = (v8 == 34)
        var v10: Bool = false
        v10 = (v9 != true)
        if (v10) {
            return 2
        } else {
            var v11: Int32 = 0
            v11 = spiralStringLength(v1)
            var v12: Bool = false
            v12 = (v11 == 0)
            var v13: Bool = false
            v13 = (v12 != true)
            if (v13) {
                return 3
            } else {
                var v14: Int32 = 0
                v14 = spiralStringLength(v2)
                var v15: Bool = false
                v15 = (v14 == 4)
                var v16: Bool = false
                v16 = (v15 != true)
                if (v16) {
                    return 4
                } else {
                    var v17: Int32 = 0
                    v17 = spiralStringIndex(v2, 1)
                    var v18: Bool = false
                    v18 = (v17 == 92)
                    var v19: Bool = false
                    v19 = (v18 != true)
                    if (v19) {
                        return 5
                    } else {
                        var v20: Int32 = 0
                        v20 = spiralStringLength(v3)
                        var v21: Bool = false
                        v21 = (v20 == 83)
                        var v22: Bool = false
                        v22 = (v21 != true)
                        if (v22) {
                            return 6
                        } else {
                            var v23: Int32 = 0
                            v23 = spiralStringIndex(v3, 5)
                            var v24: Bool = false
                            v24 = (v23 == 10)
                            var v25: Bool = false
                            v25 = (v24 != true)
                            if (v25) {
                                return 7
                            } else {
                                var v26: Int32 = 0
                                v26 = spiralStringIndex(v3, 37)
                                var v27: Bool = false
                                v27 = (v26 == 10)
                                var v28: Bool = false
                                v28 = (v27 != true)
                                if (v28) {
                                    return 8
                                } else {
                                    var v29: Int32 = 0
                                    v29 = spiralStringIndex(v3, 38)
                                    var v30: Bool = false
                                    v30 = (v29 == 10)
                                    var v31: Bool = false
                                    v31 = (v30 != true)
                                    if (v31) {
                                        return 9
                                    } else {
                                        var v32: Int32 = 0
                                        v32 = spiralStringIndex(v3, 39)
                                        var v33: Bool = false
                                        v33 = (v32 == 36)
                                        var v34: Bool = false
                                        v34 = (v33 != true)
                                        if (v34) {
                                            return 10
                                        } else {
                                            var v35: Int32 = 0
                                            v35 = spiralStringIndex(v3, 57)
                                            var v36: Bool = false
                                            v36 = (v35 == 105)
                                            var v37: Bool = false
                                            v37 = (v36 != true)
                                            if (v37) {
                                                return 11
                                            } else {
                                                var v38: Int32 = 0
                                                v38 = spiralStringIndex(v3, 82)
                                                var v39: Bool = false
                                                v39 = (v38 == 100)
                                                var v40: Bool = false
                                                v40 = (v39 != true)
                                                if (v40) {
                                                    return 12
                                                } else {
                                                    var v41: Int32 = 0
                                                    v41 = spiralStringLength(v4)
                                                    var v42: Bool = false
                                                    v42 = (v41 == 11)
                                                    var v43: Bool = false
                                                    v43 = (v42 != true)
                                                    if (v43) {
                                                        return 13
                                                    } else {
                                                        var v44: Int32 = 0
                                                        v44 = spiralStringIndex(v4, 0)
                                                        var v45: Bool = false
                                                        v45 = (v44 == 10)
                                                        var v46: Bool = false
                                                        v46 = (v45 != true)
                                                        if (v46) {
                                                            return 14
                                                        } else {
                                                            var v47: Int32 = 0
                                                            v47 = spiralStringIndex(v4, 5)
                                                            var v48: Bool = false
                                                            v48 = (v47 == 10)
                                                            var v49: Bool = false
                                                            v49 = (v48 != true)
                                                            if (v49) {
                                                                return 15
                                                            } else {
                                                                return 0
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
exit(spiral_main())
