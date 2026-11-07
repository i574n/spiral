fun sp_target_global_0(p0: String) {
    var v0: String = p0
}
fun spiral_main(): Int {
    val v0: String = "SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_same_B64:Ly9Q"
    sp_target_global_0(v0)
    val v1: String = "SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_same_B64:Ly9C"
    sp_target_global_0(v1)
    val v2: String = "SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_same_B64:Ly9Q"
    sp_target_global_0(v2)
    val v3: String = "SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_same_B64:Ly9C"
    sp_target_global_0(v3)
    return 0
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
