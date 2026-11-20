class Heap0(val l0: Array<Double>)
fun spiral_main(): Int {
    var v0: Array<Double> = emptyArray<Double>()
    v0 = Array(1) { 0.0 }
    val v1: Double = 1.5
    v0[0] = v1
    val v2: Heap0 = Heap0(v0)
    val v3: Array<Double> = v2.l0
    val v4: Double = v3[0]
    val v5: Boolean = (v4 == 1.5)
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
