fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 65
    var v1: Int = 0
    v1 = 66
    var v2: Boolean = false
    v2 = (v0 == 65)
    if (v2) {
        var v3: Boolean = false
        v3 = (v1 == 66)
        if (v3) {
            var v4: Boolean = false
            v4 = (v0 == v1)
            if (v4) {
                return 2
            } else {
                return 0
            }
        } else {
            return 3
        }
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
