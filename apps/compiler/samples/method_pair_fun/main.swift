import CRT
import WinSDK
func left_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Bool = false
        v2 = (v0 == 0)
        if (v2) {
            return 0
        } else {
            var v3: Int32 = 0
            v3 = (v1 &+ v0)
            return v3
        }
    }
}
func right_c1(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Bool = false
        v2 = (v0 == 0)
        if (v2) {
            return 0
        } else {
            var v3: Int32 = 0
            v3 = (v1 &+ v0)
            return v3
        }
    }
}
func sp_method0(_ p0: Int32, _ p1: Int32) -> ((Int32) -> Int32, (Int32) -> Int32) {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v2 = left_c0(v0)
    var v3: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v3 = right_c1(v1)
    return (v2, v3)
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = 4
    var v2: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    var v3: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    let spiral_tuple280 = sp_method0(v0, v1)
    v2 = spiral_tuple280.0
    v3 = spiral_tuple280.1
    let v4: Int32 = v2(0)
    let v5: Int32 = v3(0)
    let v6: Int32 = (v4 &+ v5)
    let v7: Bool = (v6 == 7)
    if (v7) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
