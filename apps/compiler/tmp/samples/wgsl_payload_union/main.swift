import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Circle: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_Rect: US0 { var f0: Int32; var f1: Int32; var tag: Int32 { 1 } }
struct US0_Empty: US0 { var tag: Int32 { 2 } }
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: US0 = US0_Circle(f0: 0)
    v1 = US0_Circle(f0: v0)
    var v2: Int32 = 0
    v2 = 3
    var v3: Int32 = 0
    v3 = 4
    var v4: US0 = US0_Circle(f0: 0)
    v4 = US0_Rect(f0: v2, f1: v3)
    var v5: US0 = US0_Circle(f0: 0)
    v5 = US0_Empty()
    var v6: Int32 = 0
    v6 = 2
    var v7: US0 = US0_Circle(f0: 0)
    v7 = US0_Circle(f0: v6)
    var v18: Bool = false
    switch (v1.tag == v7.tag ? v1.tag : -1) {
        case 0:
            var v8: Int32 = (v1 as! US0_Circle).f0
            var v9: Int32 = (v7 as! US0_Circle).f0
            var v10: Bool = false
            v10 = (v8 == v9)
            v18 = v10
        case 2:
            v18 = true
        case 1:
            var v11: Int32 = (v1 as! US0_Rect).f0
            var v12: Int32 = (v1 as! US0_Rect).f1
            var v13: Int32 = (v7 as! US0_Rect).f0
            var v14: Int32 = (v7 as! US0_Rect).f1
            var v15: Bool = false
            v15 = (v11 == v13)
            if (v15) {
                var v16: Bool = false
                v16 = (v12 == v14)
                v18 = v16
            } else {
                v18 = false
            }
        default:
            v18 = false
    }
    var v19: Int32 = 0
    if (v18) {
        v19 = 100
    } else {
        v19 = 0
    }
    var v28: Int32 = 0
    switch v1.tag {
        case 0:
            var v20: Int32 = (v1 as! US0_Circle).f0
            var v21: Int32 = 0
            v21 = (3 &* v20)
            var v22: Int32 = 0
            v22 = (v21 &* v20)
            v28 = v22
        case 2:
            v28 = 0
        case 1:
            var v23: Int32 = (v1 as! US0_Rect).f0
            var v24: Int32 = (v1 as! US0_Rect).f1
            var v25: Int32 = 0
            v25 = (v23 &* v24)
            v28 = v25
        default:
            fatalError("unreachable union case")
    }
    var v37: Int32 = 0
    switch v4.tag {
        case 0:
            var v29: Int32 = (v4 as! US0_Circle).f0
            var v30: Int32 = 0
            v30 = (3 &* v29)
            var v31: Int32 = 0
            v31 = (v30 &* v29)
            v37 = v31
        case 2:
            v37 = 0
        case 1:
            var v32: Int32 = (v4 as! US0_Rect).f0
            var v33: Int32 = (v4 as! US0_Rect).f1
            var v34: Int32 = 0
            v34 = (v32 &* v33)
            v37 = v34
        default:
            fatalError("unreachable union case")
    }
    var v38: Int32 = 0
    v38 = (v28 &+ v37)
    var v47: Int32 = 0
    switch v5.tag {
        case 0:
            var v39: Int32 = (v5 as! US0_Circle).f0
            var v40: Int32 = 0
            v40 = (3 &* v39)
            var v41: Int32 = 0
            v41 = (v40 &* v39)
            v47 = v41
        case 2:
            v47 = 0
        case 1:
            var v42: Int32 = (v5 as! US0_Rect).f0
            var v43: Int32 = (v5 as! US0_Rect).f1
            var v44: Int32 = 0
            v44 = (v42 &* v43)
            v47 = v44
        default:
            fatalError("unreachable union case")
    }
    var v48: Int32 = 0
    v48 = (v38 &+ v47)
    var v49: Int32 = 0
    v49 = (v48 &+ v19)
    return v49
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
