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
            val t474_0: ULong = v0
            val t510_1: ULong = v1
            val t546_5: Int = v5
            val t580_7: ULong = v7
            v0 = t474_0
            v1 = t510_1
            v2 = t546_5
            v3 = t580_7
            continue
        }
    }
    return 0uL
}
fun spiral_main(): Int {
    var v0: ULong = 0uL
    v0 = 42uL
    var v1: ULong = 0uL
    v1 = 6364136223846793005uL
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
    var v8: Long = 0L
    v8 = (v6 - 1L)
    var v9: ULong = 0uL
    v9 = (v7 + 2uL)
    System.out.write(("max " + (v5).toString() + " min " + (v8).toString() + " wrap " + (v9).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    var v10: Long = 0L
    v10 = -9007199254740993L
    var v11: Long = 0L
    v11 = 7L
    var v12: Long = 0L
    v12 = (v10 / v11)
    var v13: Long = 0L
    v13 = (v10 % v11)
    System.out.write(("div " + (v12).toString() + " mod " + (v13).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    var v14: Long = 0L
    v14 = (v10 shr 3)
    var v15: ULong = 0uL
    v15 = (v4 shr 60)
    System.out.write(("shl " + (4611686018427387904L).toString() + " shr " + (v14).toString() + " ushr " + (v15).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    var v16: ULong = 0uL
    v16 = (v4 and 18446744069414584320uL)
    var v17: Long = 0L
    v17 = (v10 or 255L)
    var v18: ULong = 0uL
    v18 = (v4 xor v1)
    System.out.write(("and " + (v16).toString() + " or " + (v17).toString() + " xor " + (v18).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    var v19: Double = 0.0
    v19 = 1E+18
    var v20: Long = 0L
    v20 = (v19).toLong()
    var v21: UInt = 0u
    v21 = (v4).toUInt()
    var v22: Double = 0.0
    v22 = (v10).toDouble()
    var v23: Boolean = false
    v23 = (v22 < 0.0)
    var v24: Int = 0
    if (v23) {
        v24 = 1
    } else {
        v24 = 0
    }
    System.out.write(("conv " + (v20).toString() + " " + (v21).toString() + " " + (v24).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    var v25: Boolean = false
    v25 = (v4 > v1)
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
