fun spiral_main(): Int {
    val v0: Byte = (-128).toByte()
    val v1: Short = (-32768).toShort()
    val v2: Int = -5
    val v3: Long = -1234567890123L
    val v4: UByte = (255).toUByte()
    val v5: UShort = (65535).toUShort()
    val v6: UInt = 4294967295u
    val v7: ULong = 18446744073709551615uL
    val v8: Boolean = true
    val v9: Boolean = false
    val v10: Int = 97
    val v11: String = (v0).toString()
    val v12: Boolean = (v11 == "-128")
    var v13: Int = 0
    if (v12) {
        v13 = 0
    } else {
        v13 = 1
    }
    val v14: String = (v1).toString()
    val v15: Boolean = (v14 == "-32768")
    var v16: Int = 0
    if (v15) {
        v16 = 0
    } else {
        v16 = 1
    }
    val v17: Int = (v13 + v16)
    val v18: String = (v2).toString()
    val v19: Boolean = (v18 == "-5")
    var v20: Int = 0
    if (v19) {
        v20 = 0
    } else {
        v20 = 1
    }
    val v21: Int = (v17 + v20)
    val v22: String = (v3).toString()
    val v23: Boolean = (v22 == "-1234567890123")
    var v24: Int = 0
    if (v23) {
        v24 = 0
    } else {
        v24 = 1
    }
    val v25: Int = (v21 + v24)
    val v26: String = (v4).toString()
    val v27: Boolean = (v26 == "255")
    var v28: Int = 0
    if (v27) {
        v28 = 0
    } else {
        v28 = 1
    }
    val v29: Int = (v25 + v28)
    val v30: String = (v5).toString()
    val v31: Boolean = (v30 == "65535")
    var v32: Int = 0
    if (v31) {
        v32 = 0
    } else {
        v32 = 1
    }
    val v33: Int = (v29 + v32)
    val v34: String = (v6).toString()
    val v35: Boolean = (v34 == "4294967295")
    var v36: Int = 0
    if (v35) {
        v36 = 0
    } else {
        v36 = 1
    }
    val v37: Int = (v33 + v36)
    val v38: String = (v7).toString()
    val v39: Boolean = (v38 == "18446744073709551615")
    var v40: Int = 0
    if (v39) {
        v40 = 0
    } else {
        v40 = 1
    }
    val v41: Int = (v37 + v40)
    val v42: String = (v8).toString()
    val v43: Boolean = (v42 == "true")
    var v44: Int = 0
    if (v43) {
        v44 = 0
    } else {
        v44 = 1
    }
    val v45: Int = (v41 + v44)
    val v46: String = (v9).toString()
    val v47: Boolean = (v46 == "false")
    var v48: Int = 0
    if (v47) {
        v48 = 0
    } else {
        v48 = 1
    }
    val v49: Int = (v45 + v48)
    val v50: String = (v10).toChar().toString()
    val v51: Boolean = (v50 == "a")
    var v52: Int = 0
    if (v51) {
        v52 = 0
    } else {
        v52 = 1
    }
    val v53: Int = (v49 + v52)
    val v54: String = ((7).toUByte()).toString()
    val v55: Boolean = (v54 == "7")
    var v56: Int = 0
    if (v55) {
        v56 = 0
    } else {
        v56 = 1
    }
    val v57: Int = (v53 + v56)
    val v58: String = (false).toString()
    val v59: Boolean = (v58 == "false")
    var v60: Int = 0
    if (v59) {
        v60 = 0
    } else {
        v60 = 1
    }
    val v61: Int = (v57 + v60)
    val v62: String = (122).toChar().toString()
    val v63: Boolean = (v62 == "z")
    var v64: Int = 0
    if (v63) {
        v64 = 0
    } else {
        v64 = 1
    }
    val v65: Int = (v61 + v64)
    val v66: String = (-3L).toString()
    val v67: Boolean = (v66 == "-3")
    var v68: Int = 0
    if (v67) {
        v68 = 0
    } else {
        v68 = 1
    }
    val v69: Int = (v65 + v68)
    return v69
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
