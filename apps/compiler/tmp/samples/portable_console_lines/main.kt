fun spiral_main(): Int {
    var v0: String = ""
    v0 = "hello"
    run { System.out.write((v0.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    var v1: Int = 0
    v1 = 42
    run { System.out.write((v1.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    var v2: String = ""
    v2 = "a"
    run { System.out.write(v2.toString().toByteArray(Charsets.UTF_8)); System.out.flush() }
    var v3: String = ""
    v3 = "b"
    run { System.out.write(v3.toString().toByteArray(Charsets.UTF_8)); System.out.flush() }
    var v4: String = ""
    v4 = ""
    run { System.out.write((v4.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    var v5: Long = 0L
    v5 = -7L
    run { System.out.write((v5.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    return 0
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
