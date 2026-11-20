fun spiral_main(): Int {
    val v0: Byte = (100).toByte()
    val v1: Byte = (3).toByte()
    val v2: Byte = ((v0 * v1)).toByte()
    val v3: Byte = (-8).toByte()
    val v4: Byte = (2).toByte()
    val v5: Byte = ((v3 / v4)).toByte()
    val v6: Byte = ((v3 % v1)).toByte()
    val v7: Byte = ((-(v1))).toByte()
    val v8: Byte = (((v0).toInt() shl 1)).toByte()
    val v9: UByte = (200).toUByte()
    val v10: UByte = (3).toUByte()
    val v11: UByte = ((v9 / v10)).toUByte()
    val v12: UByte = ((v9 % v10)).toUByte()
    val v13: UByte = (15).toUByte()
    val v14: UByte = (v9 and v13)
    val v15: UByte = (v9 or v13)
    val v16: UByte = (v9 xor v13)
    val v17: UByte = (v13.inv())
    val v18: Short = (20000).toShort()
    val v19: Short = (7).toShort()
    val v20: Short = ((v18 / v19)).toShort()
    val v21: Short = ((v18 % v19)).toShort()
    val v22: Short = ((-(v18))).toShort()
    val v23: UShort = (40000).toUShort()
    val v24: UShort = (((v23).toInt() shl 1)).toUShort()
    val v25: Boolean = (v2 == (44).toByte())
    var v27: Boolean = false
    if (v25) {
        val v26: Boolean = (v5 == (-4).toByte())
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Boolean = false
    if (v27) {
        val v28: Boolean = (v6 == (-2).toByte())
        v29 = v28
    } else {
        v29 = false
    }
    var v31: Boolean = false
    if (v29) {
        val v30: Boolean = (v7 == (-3).toByte())
        v31 = v30
    } else {
        v31 = false
    }
    var v33: Boolean = false
    if (v31) {
        val v32: Boolean = (v8 == (-56).toByte())
        v33 = v32
    } else {
        v33 = false
    }
    var v35: Boolean = false
    if (v33) {
        val v34: Boolean = (v11 == (66).toUByte())
        v35 = v34
    } else {
        v35 = false
    }
    var v37: Boolean = false
    if (v35) {
        val v36: Boolean = (v12 == (2).toUByte())
        v37 = v36
    } else {
        v37 = false
    }
    var v39: Boolean = false
    if (v37) {
        val v38: Boolean = (v14 == (8).toUByte())
        v39 = v38
    } else {
        v39 = false
    }
    var v41: Boolean = false
    if (v39) {
        val v40: Boolean = (v15 == (207).toUByte())
        v41 = v40
    } else {
        v41 = false
    }
    var v43: Boolean = false
    if (v41) {
        val v42: Boolean = (v16 == (199).toUByte())
        v43 = v42
    } else {
        v43 = false
    }
    var v45: Boolean = false
    if (v43) {
        val v44: Boolean = (v17 == (240).toUByte())
        v45 = v44
    } else {
        v45 = false
    }
    var v47: Boolean = false
    if (v45) {
        val v46: Boolean = (v20 == (2857).toShort())
        v47 = v46
    } else {
        v47 = false
    }
    var v49: Boolean = false
    if (v47) {
        val v48: Boolean = (v21 == (1).toShort())
        v49 = v48
    } else {
        v49 = false
    }
    var v51: Boolean = false
    if (v49) {
        val v50: Boolean = (v22 == (-20000).toShort())
        v51 = v50
    } else {
        v51 = false
    }
    var v53: Boolean = false
    if (v51) {
        val v52: Boolean = (v24 == (14464).toUShort())
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
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
