fun spiral_main(): Int {
    val v0: Byte = (100).toByte()
    val v1: Byte = ((v0 + v0)).toByte()
    val v2: UByte = (200).toUByte()
    val v3: UByte = (100).toUByte()
    val v4: UByte = ((v2 + v3)).toUByte()
    val v5: Byte = (-8).toByte()
    val v6: Byte = (((v5).toInt() shr 1)).toByte()
    val v7: UByte = (((v2).toInt() shr 1)).toUByte()
    val v8: Short = (20000).toShort()
    val v9: Short = ((v8 + v8)).toShort()
    val v10: UShort = (40000).toUShort()
    val v11: UShort = ((v10 + v10)).toUShort()
    val v12: Int = 7
    val v13: Byte = (v12).toByte()
    val v14: Byte = (9).toByte()
    val v15: Int = (v14).toInt()
    val v16: Boolean = (v1 == (-56).toByte())
    var v18: Boolean = false
    if (v16) {
        val v17: Boolean = (v4 == (44).toUByte())
        v18 = v17
    } else {
        v18 = false
    }
    var v20: Boolean = false
    if (v18) {
        val v19: Boolean = (v6 == (-4).toByte())
        v20 = v19
    } else {
        v20 = false
    }
    var v22: Boolean = false
    if (v20) {
        val v21: Boolean = (v7 == (100).toUByte())
        v22 = v21
    } else {
        v22 = false
    }
    var v24: Boolean = false
    if (v22) {
        val v23: Boolean = (v9 == (-25536).toShort())
        v24 = v23
    } else {
        v24 = false
    }
    var v26: Boolean = false
    if (v24) {
        val v25: Boolean = (v11 == (14464).toUShort())
        v26 = v25
    } else {
        v26 = false
    }
    var v28: Boolean = false
    if (v26) {
        val v27: Boolean = (v13 == (7).toByte())
        v28 = v27
    } else {
        v28 = false
    }
    var v30: Boolean = false
    if (v28) {
        val v29: Boolean = (v15 == 9)
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
