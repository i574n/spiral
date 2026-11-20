fun spiral_main(): Int {
    val v0: String = "hello"
    run { System.out.write((v0.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    val v1: Int = 42
    run { System.out.write((v1.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    val v2: String = "a"
    run { System.out.write(v2.toString().toByteArray(Charsets.UTF_8)); System.out.flush() }
    val v3: String = "b"
    run { System.out.write(v3.toString().toByteArray(Charsets.UTF_8)); System.out.flush() }
    val v4: String = ""
    run { System.out.write((v4.toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush() }
    val v5: Long = -7L
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
