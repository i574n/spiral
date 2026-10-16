import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_North: US0 { var tag: Int32 { 0 } }
struct US0_East: US0 { var tag: Int32 { 1 } }
struct US0_South: US0 { var tag: Int32 { 2 } }
struct US0_West: US0 { var tag: Int32 { 3 } }
func spiral_main() -> Int32 {
    var v0: US0 = US0_North()
    v0 = US0_North()
    var v8: US0 = US0_North()
    switch v0.tag {
        case 1:
            v8 = US0_South()
        case 0:
            v8 = US0_East()
        case 2:
            v8 = US0_West()
        case 3:
            v8 = US0_North()
        default:
            fatalError("unreachable union case")
    }
    var v16: US0 = US0_North()
    switch v8.tag {
        case 1:
            v16 = US0_South()
        case 0:
            v16 = US0_East()
        case 2:
            v16 = US0_West()
        case 3:
            v16 = US0_North()
        default:
            fatalError("unreachable union case")
    }
    var v17: US0 = US0_North()
    v17 = US0_South()
    var v18: Bool = false
    switch (v16.tag == v17.tag ? v16.tag : -1) {
        case 1:
            v18 = true
        case 0:
            v18 = true
        case 2:
            v18 = true
        case 3:
            v18 = true
        default:
            v18 = false
    }
    var v19: Int32 = 0
    if (v18) {
        v19 = 100
    } else {
        v19 = 0
    }
    var v21: Int32 = 0
    switch v0.tag {
        case 1:
            v21 = 2
        case 0:
            v21 = 1
        default:
            v21 = 7
    }
    var v23: Int32 = 0
    switch v8.tag {
        case 1:
            v23 = 2
        case 0:
            v23 = 1
        default:
            v23 = 7
    }
    var v24: Int32 = 0
    v24 = (v23 &* 3)
    var v25: Int32 = 0
    v25 = (v21 &+ v24)
    var v27: Int32 = 0
    switch v16.tag {
        case 1:
            v27 = 2
        case 0:
            v27 = 1
        default:
            v27 = 7
    }
    var v28: Int32 = 0
    v28 = (v27 &* 9)
    var v29: Int32 = 0
    v29 = (v25 &+ v28)
    var v30: Int32 = 0
    v30 = (v29 &+ v19)
    return v30
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
