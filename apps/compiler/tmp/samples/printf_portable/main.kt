fun spiral_main(): Int {
    val v0: Int = 60
    val v1: Long = -9000000000L
    val v2: UByte = (200).toUByte()
    val v3: String = "cube"
    System.out.write((v3 + ": " + (v0).toString() + " frames, checksum " + (970392).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    System.out.write(("big " + (v1).toString() + ", small " + (-5).toString() + ", byte " + (v2).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    System.out.write(("100% {braces} \"quoted\" \\ tab\tend\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    System.out.write(("literal" + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    System.out.write((v3).toByteArray(Charsets.UTF_8)); System.out.flush()
    System.out.write(("\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    return 0
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
