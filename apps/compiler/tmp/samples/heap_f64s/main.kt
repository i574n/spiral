class Heap0(val l0: Array<Double>)
fun spiral_main(): Int {
    var v0: Array<Double> = emptyArray<Double>()
    v0 = Array(1) { 0.0 }
    var v1: Double = 0.0
    v1 = 1.5
    v0[0] = v1
    var v2: Heap0 = Heap0(emptyArray<Double>())
    v2 = Heap0(v0)
    var v3: Array<Double> = emptyArray<Double>()
    v3 = v2.l0
    var v4: Double = 0.0
    v4 = v3[0]
    var v5: Boolean = false
    v5 = (v4 == 1.5)
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
