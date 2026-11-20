fun sp_lcg_0(p0: ULong, p1: ULong, p2: Int, p3: ULong): ULong {
    var v0: ULong = p0
    var v1: ULong = p1
    var v2: Int = p2
    var v3: ULong = p3
    while (true) {
        var v4: Boolean = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            var v5: Int = 0
            v5 = (v2 - 1)
            var v6: ULong = 0uL
            v6 = (v3 * v0)
            var v7: ULong = 0uL
            v7 = (v6 + v1)
            v2 = v5
            v3 = v7
            continue
        }
    }
    return 0uL
}
fun spiral_main(): Int {
    val v0: ULong = 42uL
    val v1: ULong = 6364136223846793005uL
    var v2: ULong = 0uL
    v2 = 1442695040888963407uL
    var v3: Int = 0
    v3 = 1000
    var v4: ULong = 0uL
    v4 = sp_lcg_0(v1, v2, v3, v0)
    System.out.write(("lcg " + (v4).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    var v5: Long = 0L
    v5 = 9223372036854775807L
    var v6: Long = 0L
    v6 = -9223372036854775807L
    var v7: ULong = 0uL
    v7 = 18446744073709551615uL
    val v8: Long = (v6 - 1L)
    val v9: ULong = (v7 + 2uL)
    System.out.write(("max " + (v5).toString() + " min " + (v8).toString() + " wrap " + (v9).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    val v10: Long = -9007199254740993L
    val v11: Long = 7L
    val v12: Long = (v10 / v11)
    val v13: Long = (v10 % v11)
    System.out.write(("div " + (v12).toString() + " mod " + (v13).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    val v14: Long = (v10 shr 3)
    val v15: ULong = (v4 shr 60)
    System.out.write(("shl " + (4611686018427387904L).toString() + " shr " + (v14).toString() + " ushr " + (v15).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    val v16: ULong = (v4 and 18446744069414584320uL)
    val v17: Long = (v10 or 255L)
    val v18: ULong = (v4 xor v1)
    System.out.write(("and " + (v16).toString() + " or " + (v17).toString() + " xor " + (v18).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    val v19: Double = 1E+18
    val v20: Long = (v19).toLong()
    val v21: UInt = (v4).toUInt()
    val v22: Double = (v10).toDouble()
    val v23: Boolean = (v22 < 0.0)
    var v24: Int = 0
    if (v23) {
        v24 = 1
    } else {
        v24 = 0
    }
    System.out.write(("conv " + (v20).toString() + " " + (v21).toString() + " " + (v24).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    val v25: Boolean = (v4 > v1)
    if (v25) {
        return 1
    } else {
        return 0
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
