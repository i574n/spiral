class Heap0(val l0: UShort, val l1: String)
fun spiral_main(): Int {
    var v0: UShort = (0).toUShort()
    v0 = (40000).toUShort()
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0((0).toUShort(), "")
    v2 = Heap0(v0, v1)
    var v3: UShort = (0).toUShort()
    var v4: String = ""
    v3 = v2.l0
    v4 = v2.l1
    var v5: Boolean = false
    v5 = (v3 == (40000).toUShort())
    var v7: Boolean = false
    if (v5) {
        var v6: Boolean = false
        v6 = (v4 == "hi")
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
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
