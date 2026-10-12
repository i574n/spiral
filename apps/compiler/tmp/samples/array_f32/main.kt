fun spiral_main(): Int {
    var v0: Array<Float> = emptyArray<Float>()
    v0 = Array(1) { 0.0f }
    var v1: Float = 0.0f
    v1 = 1.5f
    v0[0] = v1
    var v2: Float = 0.0f
    v2 = v0[0]
    var v3: Boolean = false
    v3 = (v2 == 1.5f)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
