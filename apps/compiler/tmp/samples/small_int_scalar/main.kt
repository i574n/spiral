fun spiral_main(): Int {
    var v0: Byte = (0).toByte()
    v0 = (100).toByte()
    var v1: Byte = (0).toByte()
    v1 = ((v0 + v0)).toByte()
    var v2: UByte = (0).toUByte()
    v2 = (200).toUByte()
    var v3: UByte = (0).toUByte()
    v3 = (100).toUByte()
    var v4: UByte = (0).toUByte()
    v4 = ((v2 + v3)).toUByte()
    var v5: Byte = (0).toByte()
    v5 = (-8).toByte()
    var v6: Byte = (0).toByte()
    v6 = (((v5).toInt() shr 1)).toByte()
    var v7: UByte = (0).toUByte()
    v7 = (((v2).toInt() shr 1)).toUByte()
    var v8: Short = (0).toShort()
    v8 = (20000).toShort()
    var v9: Short = (0).toShort()
    v9 = ((v8 + v8)).toShort()
    var v10: UShort = (0).toUShort()
    v10 = (40000).toUShort()
    var v11: UShort = (0).toUShort()
    v11 = ((v10 + v10)).toUShort()
    var v12: Int = 0
    v12 = 7
    var v13: Byte = (0).toByte()
    v13 = (v12).toByte()
    var v14: Byte = (0).toByte()
    v14 = (9).toByte()
    var v15: Int = 0
    v15 = (v14).toInt()
    var v16: Boolean = false
    v16 = (v1 == (-56).toByte())
    var v18: Boolean = false
    if (v16) {
        var v17: Boolean = false
        v17 = (v4 == (44).toUByte())
        v18 = v17
    } else {
        v18 = false
    }
    var v20: Boolean = false
    if (v18) {
        var v19: Boolean = false
        v19 = (v6 == (-4).toByte())
        v20 = v19
    } else {
        v20 = false
    }
    var v22: Boolean = false
    if (v20) {
        var v21: Boolean = false
        v21 = (v7 == (100).toUByte())
        v22 = v21
    } else {
        v22 = false
    }
    var v24: Boolean = false
    if (v22) {
        var v23: Boolean = false
        v23 = (v9 == (-25536).toShort())
        v24 = v23
    } else {
        v24 = false
    }
    var v26: Boolean = false
    if (v24) {
        var v25: Boolean = false
        v25 = (v11 == (14464).toUShort())
        v26 = v25
    } else {
        v26 = false
    }
    var v28: Boolean = false
    if (v26) {
        var v27: Boolean = false
        v27 = (v13 == (7).toByte())
        v28 = v27
    } else {
        v28 = false
    }
    var v30: Boolean = false
    if (v28) {
        var v29: Boolean = false
        v29 = (v15 == 9)
        v30 = v29
    } else {
        v30 = false
    }
    if (v30) {
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
