fun spiral_main(): Int {
    var v0: Byte = (0).toByte()
    v0 = (100).toByte()
    var v1: Byte = (0).toByte()
    v1 = (3).toByte()
    var v2: Byte = (0).toByte()
    v2 = ((v0 * v1)).toByte()
    var v3: Byte = (0).toByte()
    v3 = (-8).toByte()
    var v4: Byte = (0).toByte()
    v4 = (2).toByte()
    var v5: Byte = (0).toByte()
    v5 = ((v3 / v4)).toByte()
    var v6: Byte = (0).toByte()
    v6 = ((v3 % v1)).toByte()
    var v7: Byte = (0).toByte()
    v7 = ((-(v1))).toByte()
    var v8: Byte = (0).toByte()
    v8 = (((v0).toInt() shl 1)).toByte()
    var v9: UByte = (0).toUByte()
    v9 = (200).toUByte()
    var v10: UByte = (0).toUByte()
    v10 = (3).toUByte()
    var v11: UByte = (0).toUByte()
    v11 = ((v9 / v10)).toUByte()
    var v12: UByte = (0).toUByte()
    v12 = ((v9 % v10)).toUByte()
    var v13: UByte = (0).toUByte()
    v13 = (15).toUByte()
    var v14: UByte = (0).toUByte()
    v14 = (v9 and v13)
    var v15: UByte = (0).toUByte()
    v15 = (v9 or v13)
    var v16: UByte = (0).toUByte()
    v16 = (v9 xor v13)
    var v17: UByte = (0).toUByte()
    v17 = (v13.inv())
    var v18: Short = (0).toShort()
    v18 = (20000).toShort()
    var v19: Short = (0).toShort()
    v19 = (7).toShort()
    var v20: Short = (0).toShort()
    v20 = ((v18 / v19)).toShort()
    var v21: Short = (0).toShort()
    v21 = ((v18 % v19)).toShort()
    var v22: Short = (0).toShort()
    v22 = ((-(v18))).toShort()
    var v23: UShort = (0).toUShort()
    v23 = (40000).toUShort()
    var v24: UShort = (0).toUShort()
    v24 = (((v23).toInt() shl 1)).toUShort()
    var v25: Boolean = false
    v25 = (v2 == (44).toByte())
    var v27: Boolean = false
    if (v25) {
        var v26: Boolean = false
        v26 = (v5 == (-4).toByte())
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Boolean = false
    if (v27) {
        var v28: Boolean = false
        v28 = (v6 == (-2).toByte())
        v29 = v28
    } else {
        v29 = false
    }
    var v31: Boolean = false
    if (v29) {
        var v30: Boolean = false
        v30 = (v7 == (-3).toByte())
        v31 = v30
    } else {
        v31 = false
    }
    var v33: Boolean = false
    if (v31) {
        var v32: Boolean = false
        v32 = (v8 == (-56).toByte())
        v33 = v32
    } else {
        v33 = false
    }
    var v35: Boolean = false
    if (v33) {
        var v34: Boolean = false
        v34 = (v11 == (66).toUByte())
        v35 = v34
    } else {
        v35 = false
    }
    var v37: Boolean = false
    if (v35) {
        var v36: Boolean = false
        v36 = (v12 == (2).toUByte())
        v37 = v36
    } else {
        v37 = false
    }
    var v39: Boolean = false
    if (v37) {
        var v38: Boolean = false
        v38 = (v14 == (8).toUByte())
        v39 = v38
    } else {
        v39 = false
    }
    var v41: Boolean = false
    if (v39) {
        var v40: Boolean = false
        v40 = (v15 == (207).toUByte())
        v41 = v40
    } else {
        v41 = false
    }
    var v43: Boolean = false
    if (v41) {
        var v42: Boolean = false
        v42 = (v16 == (199).toUByte())
        v43 = v42
    } else {
        v43 = false
    }
    var v45: Boolean = false
    if (v43) {
        var v44: Boolean = false
        v44 = (v17 == (240).toUByte())
        v45 = v44
    } else {
        v45 = false
    }
    var v47: Boolean = false
    if (v45) {
        var v46: Boolean = false
        v46 = (v20 == (2857).toShort())
        v47 = v46
    } else {
        v47 = false
    }
    var v49: Boolean = false
    if (v47) {
        var v48: Boolean = false
        v48 = (v21 == (1).toShort())
        v49 = v48
    } else {
        v49 = false
    }
    var v51: Boolean = false
    if (v49) {
        var v50: Boolean = false
        v50 = (v22 == (-20000).toShort())
        v51 = v50
    } else {
        v51 = false
    }
    var v53: Boolean = false
    if (v51) {
        var v52: Boolean = false
        v52 = (v24 == (14464).toUShort())
        v53 = v52
    } else {
        v53 = false
    }
    if (v53) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
