fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Double> = emptyArray<Double>()
    v1 = Array(v0) { 0.0 }
    var v2: Double = 0.0
    v2 = 1.5
    v1[0] = v2
    v1[1] = 2.5
    var v3: Double = 0.0
    v3 = v1[0]
    var v4: Boolean = false
    v4 = (v3 == 1.5)
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
