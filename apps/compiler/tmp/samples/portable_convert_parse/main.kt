sealed interface US0 { val tag: Int }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 0 }
class US0_None : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "ff"
    var v1: Int = 0
    v1 = ((v0).trim().toIntOrNull(16) ?: 0)
    run { System.out.write((v1.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    var v2: String = ""
    v2 = "1011"
    var v3: Int = 0
    v3 = ((v2).trim().toIntOrNull(2) ?: 0)
    run { System.out.write((v3.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    var v4: String = ""
    v4 = "-42"
    var v5: Int = 0
    v5 = ((v4).trim().toIntOrNull(10) ?: 0)
    run { System.out.write((v5.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    var v6: String = ""
    v6 = " 123 "
    var v7: Boolean = false
    v7 = ((v6).trim().toLongOrNull() != null)
    var v8: Long = 0L
    v8 = ((v6).trim().toLongOrNull() ?: 0L)
    var v9: Int = 0
    v9 = (v8).toInt()
    var v13: Boolean = false
    if (v7) {
        var v10: Boolean = false
        v10 = (v8 >= -2147483648L)
        if (v10) {
            var v11: Boolean = false
            v11 = (v8 <= 2147483647L)
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
        v16 = US0_None()
    }
    when (v16.tag) {
        1 -> {
            var v18: String = ""
            v18 = "none"
            run { System.out.write((v18.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        0 -> {
            var v17: Int = (v16 as US0_Some).f0
            run { System.out.write((v17.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        else -> throw RuntimeException()
    }
    var v19: String = ""
    v19 = "12x"
    var v20: Boolean = false
    v20 = ((v19).trim().toLongOrNull() != null)
    var v21: Long = 0L
    v21 = ((v19).trim().toLongOrNull() ?: 0L)
    var v22: Int = 0
    v22 = (v21).toInt()
    var v26: Boolean = false
    if (v20) {
        var v23: Boolean = false
        v23 = (v21 >= -2147483648L)
        if (v23) {
            var v24: Boolean = false
            v24 = (v21 <= 2147483647L)
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
        v29 = US0_None()
    }
    when (v29.tag) {
        1 -> {
            var v31: String = ""
            v31 = "none"
            run { System.out.write((v31.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        0 -> {
            var v30: Int = (v29 as US0_Some).f0
            run { System.out.write((v30.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        else -> throw RuntimeException()
    }
    var v32: String = ""
    v32 = ""
    var v33: Boolean = false
    v33 = ((v32).trim().toLongOrNull() != null)
    var v34: Long = 0L
    v34 = ((v32).trim().toLongOrNull() ?: 0L)
    var v35: Int = 0
    v35 = (v34).toInt()
    var v39: Boolean = false
    if (v33) {
        var v36: Boolean = false
        v36 = (v34 >= -2147483648L)
        if (v36) {
            var v37: Boolean = false
            v37 = (v34 <= 2147483647L)
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
        v42 = US0_None()
    }
    when (v42.tag) {
        1 -> {
            var v44: String = ""
            v44 = "none"
            run { System.out.write((v44.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        0 -> {
            var v43: Int = (v42 as US0_Some).f0
            run { System.out.write((v43.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
        }
        else -> throw RuntimeException()
    }
    var v45: String = ""
    v45 = "+7"
    var v46: Boolean = false
    v46 = ((v45).trim().toLongOrNull() != null)
    var v47: Long = 0L
    v47 = ((v45).trim().toLongOrNull() ?: 0L)
    var v48: Int = 0
    v48 = (v47).toInt()
    var v52: Boolean = false
    if (v46) {
        var v49: Boolean = false
        v49 = (v47 >= -2147483648L)
        if (v49) {
            var v50: Boolean = false
            v50 = (v47 <= 2147483647L)
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
        v55 = US0_None()
    }
    when (v55.tag) {
        1 -> {
            var v57: String = ""
            v57 = "none"
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
