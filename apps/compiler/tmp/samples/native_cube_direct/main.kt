fun sp_method2(): Int {
    return 14
}
fun sp_method1(): Int {
    var v0: Int = 0
    v0 = sp_method2()
    var v1: Int = 0
    v1 = (14 + v0)
    return v1
}
fun sp_method0(): Int {
    var v0: Int = 0
    v0 = sp_method1()
    var v1: Int = 0
    v1 = (14 + v0)
    return v1
}
fun spiral_main(): Int {
    return sp_method0()
}
fun main() {
    System.exit(spiral_main())
}
