fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<String> = emptyArray<String>()
    v1 = Array(v0) { "" }
    var v2: String = ""
    v2 = "hi"
    v1[0] = v2
    var v3: String = ""
    v3 = "yo"
    v1[1] = v3
    var v4: String = ""
    v4 = v1[0]
    var v5: Boolean = false
    v5 = (v4 == "hi")
    if (v5) {
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
