import CRT
import WinSDK
func right_c1(_ v0: Int32, _ v1: Int32) -> (Int32) -> Int32 {
    return { (v2: Int32) -> Int32 in
        var v3: Bool = false
        v3 = (v1 == 0)
        if (v3) {
            return 0
        } else {
            var v4: Int32 = 0
            v4 = (v2 &+ v0)
            return v4
        }
    }
}
func left_c2(_ v0: Int32, _ v1: Int32) -> (Int32) -> Int32 {
    return { (v2: Int32) -> Int32 in
        var v3: Bool = false
        v3 = (v1 == 0)
        if (v3) {
            return 0
        } else {
            var v4: Int32 = 0
            v4 = (v2 &+ v0)
            return v4
        }
    }
}
func f_c0(_ v0: Int32, _ v1: Int32) -> (Int32) -> ((Int32) -> Int32, (Int32) -> Int32) {
    return { (v2: Int32) -> ((Int32) -> Int32, (Int32) -> Int32) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
            v4 = right_c1(v1, v2)
            var v5: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
            v5 = left_c2(v0, v2)
            return (v4, v5)
        } else {
            var v6: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
            v6 = left_c2(v0, v2)
            var v7: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
            v7 = right_c1(v1, v2)
            return (v6, v7)
        }
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = 4
    let v2: (Int32) -> ((Int32) -> Int32, (Int32) -> Int32) = f_c0(v0, v1)
    var v3: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    var v4: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    let spiral_tuple456 = v2(1)
    v3 = spiral_tuple456.0
    v4 = spiral_tuple456.1
    var v5: Int32 = 0
    v5 = v3(0)
    var v6: Int32 = 0
    v6 = v4(0)
    var v7: Int32 = 0
    v7 = (v5 &+ v6)
    let v8: Bool = (v7 == 7)
    if (v8) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
