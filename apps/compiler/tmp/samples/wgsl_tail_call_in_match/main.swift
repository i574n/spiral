import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Done: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_More: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_layers_0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    let v1: Bool = (v0 >= 5)
    var v4: US0 = US0_Done(f0: 0)
    if (v1) {
        v4 = US0_Done(f0: v0)
    } else {
        v4 = US0_More(f0: v0)
    }
    switch v4.tag {
        case 0:
            var v8: Int32 = (v4 as! US0_Done).f0
            let v9: Int32 = (v8 &* 2)
            return v9
        case 1:
            var v5: Int32 = (v4 as! US0_More).f0
            let v6: Int32 = (v5 &+ 1)
            return sp_layers_0(v6)
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 0
    return sp_layers_0(v0)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
