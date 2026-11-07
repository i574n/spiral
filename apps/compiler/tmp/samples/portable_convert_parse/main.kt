sealed interface US0 { val tag: Int }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 0 }
object US0_None : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    val v0: String = "ff"
    val v1: Int = ((v0).trim().toIntOrNull(16) ?: 0)
    run { System.out.write((v1.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    val v2: String = "1011"
    val v3: Int = ((v2).trim().toIntOrNull(2) ?: 0)
    run { System.out.write((v3.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    val v4: String = "-42"
    val v5: Int = ((v4).trim().toIntOrNull(10) ?: 0)
    run { System.out.write((v5.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    val v6: String = " 123 "
    val v7: Boolean = ((v6).trim().toLongOrNull() != null)
    val v8: Long = ((v6).trim().toLongOrNull() ?: 0L)
    val v9: Int = (v8).toInt()
    var v13: Boolean = false
    if (v7) {
        val v10: Boolean = (v8 >= -2147483648L)
        if (v10) {
            val v11: Boolean = (v8 <= 2147483647L)
            v13 = v11
        } else {
            v13 = false
        }
    } else {
        v13 = false
    }
    var v16: US0 = US0_Some(0)
    if (v13) {
        v16 = US0_Some(v9)
    } else {
        v16 = US0_None
    }
    when (v16.tag) {
        1 -> {
            val v18: String = "none"
            run { System.out.write((v18.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        0 -> {
            var v17: Int = (v16 as US0_Some).f0
            run { System.out.write((v17.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        else -> throw RuntimeException()
    }
    val v19: String = "12x"
    val v20: Boolean = ((v19).trim().toLongOrNull() != null)
    val v21: Long = ((v19).trim().toLongOrNull() ?: 0L)
    val v22: Int = (v21).toInt()
    var v26: Boolean = false
    if (v20) {
        val v23: Boolean = (v21 >= -2147483648L)
        if (v23) {
            val v24: Boolean = (v21 <= 2147483647L)
            v26 = v24
        } else {
            v26 = false
        }
    } else {
        v26 = false
    }
    var v29: US0 = US0_Some(0)
    if (v26) {
        v29 = US0_Some(v22)
    } else {
        v29 = US0_None
    }
    when (v29.tag) {
        1 -> {
            val v31: String = "none"
            run { System.out.write((v31.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        0 -> {
            var v30: Int = (v29 as US0_Some).f0
            run { System.out.write((v30.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        else -> throw RuntimeException()
    }
    val v32: String = ""
    val v33: Boolean = ((v32).trim().toLongOrNull() != null)
    val v34: Long = ((v32).trim().toLongOrNull() ?: 0L)
    val v35: Int = (v34).toInt()
    var v39: Boolean = false
    if (v33) {
        val v36: Boolean = (v34 >= -2147483648L)
        if (v36) {
            val v37: Boolean = (v34 <= 2147483647L)
            v39 = v37
        } else {
            v39 = false
        }
    } else {
        v39 = false
    }
    var v42: US0 = US0_Some(0)
    if (v39) {
        v42 = US0_Some(v35)
    } else {
        v42 = US0_None
    }
    when (v42.tag) {
        1 -> {
            val v44: String = "none"
            run { System.out.write((v44.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        0 -> {
            var v43: Int = (v42 as US0_Some).f0
            run { System.out.write((v43.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        else -> throw RuntimeException()
    }
    val v45: String = "+7"
    val v46: Boolean = ((v45).trim().toLongOrNull() != null)
    val v47: Long = ((v45).trim().toLongOrNull() ?: 0L)
    val v48: Int = (v47).toInt()
    var v52: Boolean = false
    if (v46) {
        val v49: Boolean = (v47 >= -2147483648L)
        if (v49) {
            val v50: Boolean = (v47 <= 2147483647L)
            v52 = v50
        } else {
            v52 = false
        }
    } else {
        v52 = false
    }
    var v55: US0 = US0_Some(0)
    if (v52) {
        v55 = US0_Some(v48)
    } else {
        v55 = US0_None
    }
    when (v55.tag) {
        1 -> {
            val v57: String = "none"
            run { System.out.write((v57.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        0 -> {
            var v56: Int = (v55 as US0_Some).f0
            run { System.out.write((v56.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        else -> throw RuntimeException()
    }
    return 0
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
