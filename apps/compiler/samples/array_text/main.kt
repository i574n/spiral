fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<String> = emptyArray<String>()
    v1 = Array(v0) { "" }
    val v2: String = "hi"
    v1[0] = v2
    val v3: String = "yo"
    v1[1] = v3
    val v4: String = v1[0]
    val v5: Boolean = (v4 == "hi")
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
