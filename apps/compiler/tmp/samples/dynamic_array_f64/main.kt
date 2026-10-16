fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Double> = emptyArray<Double>()
    v1 = Array(v0) { 0.0 }
    v1[0] = 1.5
    v1[1] = 2.5
    var v2: Int = 0
    v2 = 1
    var v3: Double = 0.0
    v3 = v1[v2]
    var v4: Boolean = false
    v4 = (v3 >= 2.0)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
