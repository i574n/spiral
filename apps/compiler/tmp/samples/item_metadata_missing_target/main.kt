fun sp_target_global_0(p0: String) {
    var v0: String = p0
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "SPIRAL_ITEM_METADATA_TEST_missing-item"
    sp_target_global_0(v0)
    return 0
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
