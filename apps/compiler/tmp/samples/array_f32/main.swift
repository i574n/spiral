import CRT
func spiral_main() -> Int32 {
    var v0: Array<Float> = Array<Float>()
    v0 = Array<Float>(repeating: (0.0 as Float), count: Int(1))
    var v1: Float = (0.0 as Float)
    v1 = (1.5 as Float)
    v0[Int(0)] = v1
    var v2: Float = (0.0 as Float)
    v2 = v0[Int(0)]
    var v3: Bool = false
    v3 = (v2 == (1.5 as Float))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
