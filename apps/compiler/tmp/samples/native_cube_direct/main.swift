import CRT
func sp_method2() -> Int32 {
    return 14
}
func sp_method1() -> Int32 {
    var v0: Int32 = 0
    v0 = sp_method2()
    var v1: Int32 = 0
    v1 = (14 &+ v0)
    return v1
}
func sp_method0() -> Int32 {
    var v0: Int32 = 0
    v0 = sp_method1()
    var v1: Int32 = 0
    v1 = (14 &+ v0)
    return v1
}
func spiral_main() -> Int32 {
    return sp_method0()
}
exit(spiral_main())
