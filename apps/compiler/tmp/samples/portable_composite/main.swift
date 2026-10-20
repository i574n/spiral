import CRT
import WinSDK
func sp_method5(_ p0: Int32, _ p1: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = (v0 &* v1)
    var v3: Int32 = 0
    v3 = (v2 &+ 5)
    var v4: Int32 = 0
    v4 = (v3 / 3)
    return v4
}
func sp_method4(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = 4
    var v2: Int32 = 0
    v2 = 4
    var v3: Int32 = 0
    v3 = sp_method5(v1, v2)
    var v4: Int32 = 0
    v4 = (v0 &+ v3)
    var v5: Int32 = 0
    v5 = (v4 &- 7)
    return v5
}
func sp_method6(_ p0: UInt32) -> Bool {
    var v0: UInt32 = p0
    var v1: UInt32 = UInt32(0)
    v1 = (v0 &+ UInt32(5))
    var v2: UInt32 = UInt32(0)
    v2 = (v1 % UInt32(4))
    var v3: Bool = false
    v3 = (v2 == UInt32(0))
    return v3
}
func sp_method3(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: UInt32 = UInt32(0)
    v1 = UInt32(7)
    var v2: Bool = false
    v2 = sp_method6(v1)
    if (v2) {
        return sp_method4(v0)
    } else {
        return 1
    }
}
func sp_method7(_ p0: String, _ p1: String) -> Bool {
    var v0: String = p0
    var v1: String = p1
    var v2: Bool = false
    v2 = (v0 == v1)
    return v2
}
func sp_method2(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: String = ""
    v1 = "spiral"
    var v2: Bool = false
    v2 = sp_method7(v1, v1)
    if (v2) {
        return sp_method3(v0)
    } else {
        return 1
    }
}
func sp_method8(_ p0: Float) -> (Bool, Float, Int32) {
    var v0: Float = p0
    var v1: Bool = false
    v1 = (v0 >= (3.5 as Float))
    return (v1, v0, 7)
}
func sp_method9(_ p0: Bool, _ p1: Float, _ p2: Int32) -> Int32 {
    var v0: Bool = p0
    var v1: Float = p1
    var v2: Int32 = p2
    if (v0) {
        var v3: Bool = false
        v3 = (v1 >= (3.5 as Float))
        if (v3) {
            var v4: Int32 = 0
            v4 = (v2 &- 7)
            return v4
        } else {
            return 1
        }
    } else {
        return 2
    }
}
func sp_method1(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Float = (0.0 as Float)
    v1 = (4.0 as Float)
    var v2: Bool = false
    var v3: Float = (0.0 as Float)
    var v4: Int32 = 0
    let spiral_tuple211 = sp_method8(v1)
    v2 = spiral_tuple211.0
    v3 = spiral_tuple211.1
    v4 = spiral_tuple211.2
    var v5: Int32 = 0
    v5 = sp_method9(v2, v3, v4)
    var v6: Int32 = 0
    v6 = (v0 &+ v5)
    return sp_method2(v6)
}
func sp_method10(_ p0: Int32) -> (Int32, Int32, Bool) {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = (v0 &+ 2)
    var v2: Bool = false
    v2 = (v0 > 0)
    return (v0, v1, v2)
}
func sp_method11(_ p0: Int32, _ p1: Int32, _ p2: Bool) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Bool = p2
    if (v2) {
        var v3: Int32 = 0
        v3 = (v0 &+ v1)
        var v4: Int32 = 0
        v4 = (v3 &- 4)
        return v4
    } else {
        return 1
    }
}
func sp_method0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = 1
    var v2: Int32 = 0
    var v3: Int32 = 0
    var v4: Bool = false
    let spiral_tuple172 = sp_method10(v1)
    v2 = spiral_tuple172.0
    v3 = spiral_tuple172.1
    v4 = spiral_tuple172.2
    var v5: Int32 = 0
    v5 = sp_method11(v2, v3, v4)
    var v6: Int32 = 0
    v6 = (v0 &+ v5)
    return sp_method1(v6)
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 0
    return sp_method0(v0)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
