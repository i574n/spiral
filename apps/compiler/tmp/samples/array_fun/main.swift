import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func f_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v1 &+ v0)
        return v2
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: (Int32) -> Int32 = f_c0(v0)
    var v2: Int32 = 0
    v2 = 1
    var v3: SpiralArray<(Int32) -> Int32> = SpiralArray<(Int32) -> Int32>([])
    v3 = SpiralArray<(Int32) -> Int32>(Array(repeating: { (_: Int32) -> Int32 in fatalError("unreachable closure") }, count: Int(v2)))
    v3.items[Int(0)] = v1
    let v4: (Int32) -> Int32 = v3.items[Int(0)]
    let v5: Int32 = v4(4)
    let v6: Bool = (v5 == 7)
    if (v6) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
