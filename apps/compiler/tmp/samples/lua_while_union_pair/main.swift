import CRT
import WinSDK
class Mut0 {
    var l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
class Mut1 {
    var l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
class Mut2 {
    var l0: UH0
    init(l0: UH0) {
        self.l0 = l0
    }
}
protocol UH0 { var tag: Int32 { get } }
struct UH0_Nil: UH0 { var tag: Int32 { 0 } }
struct UH0_Cons: UH0 { var f0: Int32; var f1: UH0; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_method0(_ p0: Mut0) -> Bool {
    var v0: Mut0 = p0
    var v1: Int32 = 0
    v1 = v0.l0
    var v2: Bool = false
    v2 = (v1 < 3)
    return v2
}
func sp_method1(_ p0: Mut1) -> Bool {
    var v0: Mut1 = p0
    var v1: Int32 = 0
    v1 = v0.l0
    var v2: Bool = false
    v2 = (v1 < 4)
    return v2
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Int32> = SpiralArray<Int32>([])
    v0 = SpiralArray<Int32>(Array(repeating: 0, count: Int(3)))
    var v1: Mut0 = Mut0(l0: 0)
    v1 = Mut0(l0: 0)
    while true {
        if !(sp_method0(v1)) { break }
        var v3: Int32 = 0
        v3 = v1.l0
        var v4: Int32 = 0
        v4 = (v3 &* 5)
        v0.items[Int(v3)] = v4
        var v5: Int32 = 0
        v5 = (v3 &+ 1)
        v1.l0 = v5
    }
    var v6: Mut1 = Mut1(l0: 0)
    v6 = Mut1(l0: 0)
    var v7: Mut1 = Mut1(l0: 0)
    v7 = Mut1(l0: 0)
    var v8: UH0 = UH0_Nil()
    v8 = UH0_Nil()
    var v9: Mut2 = Mut2(l0: UH0_Nil())
    v9 = Mut2(l0: v8)
    while true {
        if !(sp_method1(v6)) { break }
        var v11: Int32 = 0
        v11 = v6.l0
        var v12: Int32 = 0
        v12 = (v11 % 2)
        var v13: Bool = false
        v13 = (v12 == 1)
        if (v13) {
            var v14: Int32 = 0
            v14 = v7.l0
            var v15: Int32 = 0
            v15 = (v14 &+ 1)
            v7.l0 = v15
        } else {
        }
        var v16: UH0 = UH0_Nil()
        v16 = v9.l0
        var v17: UH0 = UH0_Nil()
        v17 = UH0_Cons(f0: v11, f1: v16)
        v9.l0 = v17
        var v18: Int32 = 0
        v18 = (v11 &+ 1)
        v6.l0 = v18
    }
    var v19: UH0 = UH0_Nil()
    v19 = v9.l0
    var v38: Int32 = 0
    switch v19.tag {
        case 1:
            var v20: Int32 = (v19 as! UH0_Cons).f0
            var v21: UH0 = (v19 as! UH0_Cons).f1
            switch v21.tag {
                case 1:
                    var v22: Int32 = (v21 as! UH0_Cons).f0
                    var v23: UH0 = (v21 as! UH0_Cons).f1
                    switch v23.tag {
                        case 1:
                            var v24: Int32 = (v23 as! UH0_Cons).f0
                            var v25: UH0 = (v23 as! UH0_Cons).f1
                            switch v25.tag {
                                case 1:
                                    var v26: Int32 = (v25 as! UH0_Cons).f0
                                    var v27: UH0 = (v25 as! UH0_Cons).f1
                                    switch v27.tag {
                                        case 0:
                                            var v28: Int32 = 0
                                            v28 = (v20 &* 64)
                                            var v29: Int32 = 0
                                            v29 = (v22 &* 16)
                                            var v30: Int32 = 0
                                            v30 = (v28 &+ v29)
                                            var v31: Int32 = 0
                                            v31 = (v24 &* 4)
                                            var v32: Int32 = 0
                                            v32 = (v30 &+ v31)
                                            var v33: Int32 = 0
                                            v33 = (v32 &+ v26)
                                            v38 = v33
                                        default:
                                            v38 = -1
                                    }
                                default:
                                    v38 = -1
                            }
                        default:
                            v38 = -1
                    }
                default:
                    v38 = -1
            }
        default:
            v38 = -1
    }
    var v39: Int32 = 0
    v39 = v7.l0
    var v40: Int32 = 0
    v40 = (v38 &+ v39)
    var v41: Int32 = 0
    v41 = v0.items[Int(2)]
    var v42: Int32 = 0
    v42 = (v40 &+ v41)
    var v43: Int32 = 0
    v43 = v0.items[Int(1)]
    var v44: Int32 = 0
    v44 = (v42 &- v43)
    return v44
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
