import CRT
import WinSDK
protocol UH0 { var tag: Int32 { get } }
struct UH0_Cons: UH0 { var f0: UInt64; var f1: () -> UH0; var tag: Int32 { 0 } }
struct UH0_Nil: UH0 { var tag: Int32 { 1 } }
func closure0(_ v0: UInt64) -> () -> UH0 {
    return { () -> UH0 in
        var v1: UInt64 = (0 as UInt64)
        v1 = (v0 &- (1 as UInt64))
        return sp_build_0(v1)
    }
}
func sp_build_0(_ p0: UInt64) -> UH0 {
    var v0: UInt64 = p0
    var v1: Bool = false
    v1 = (v0 == (0 as UInt64))
    if (v1) {
        return UH0_Nil()
    } else {
        var v3: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v3 = closure0(v0)
        return UH0_Cons(f0: v0, f1: v3)
    }
}
func sp_sum_1(_ p0: UH0, _ p1: UInt64) -> UInt64 {
    var v0: UH0 = p0
    var v1: UInt64 = p1
    switch v0.tag {
        case 0:
            var v2: UInt64 = (v0 as! UH0_Cons).f0
            var v3: () -> UH0 = (v0 as! UH0_Cons).f1
            var v4: UH0 = UH0_Cons(f0: (0 as UInt64), f1: { () -> UH0 in fatalError("unreachable closure") })
            v4 = v3()
            var v5: UInt64 = (0 as UInt64)
            v5 = (v1 &+ v2)
            return sp_sum_1(v4, v5)
        case 1:
            return v1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: UInt64 = (0 as UInt64)
    v0 = (10 as UInt64)
    var v1: UH0 = UH0_Cons(f0: (0 as UInt64), f1: { () -> UH0 in fatalError("unreachable closure") })
    v1 = sp_build_0(v0)
    var v2: UInt64 = (0 as UInt64)
    v2 = (0 as UInt64)
    var v3: UInt64 = (0 as UInt64)
    v3 = sp_sum_1(v1, v2)
    var v4: Int32 = 0
    v4 = 5
    var v5: Int32 = 0
    v5 = Int32(v3)
    var v6: Int32 = 0
    v6 = (v4 &* 2)
    var v7: Int32 = 0
    v7 = (v4 &+ v6)
    var v8: Int32 = 0
    v8 = (v5 &+ v7)
    return v8
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
