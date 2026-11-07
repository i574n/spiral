fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<Double> = emptyArray<Double>()
    v1 = Array(v0) { 0.0 }
    v1[0] = 1.5
    v1[1] = 2.5
    val v2: Int = 1
    val v3: Double = v1[v2]
    val v4: Boolean = (v3 >= 2.0)
    if (v4) {
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
