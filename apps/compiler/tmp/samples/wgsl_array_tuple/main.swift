import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    var v1: SpiralArray<(Int32, Bool)> = SpiralArray<(Int32, Bool)>([])
    v1 = SpiralArray<(Int32, Bool)>(Array(repeating: (0, false), count: Int(v0)))
    let v2: Int32 = 4
    v1.items[Int(0)] = (v2, true)
    v1.items[Int(1)] = (7, false)
    v1.items[Int(2)] = (9, true)
    var v3: Int32 = 0
    var v4: Bool = false
    let spiral_tuple410 = v1.items[Int(0)]
    v3 = spiral_tuple410.0
    v4 = spiral_tuple410.1
    var v5: Int32 = 0
    var v6: Bool = false
    let spiral_tuple559 = v1.items[Int(1)]
    v5 = spiral_tuple559.0
    v6 = spiral_tuple559.1
    let v7: Int32 = 2
    var v8: Int32 = 0
    var v9: Bool = false
    let spiral_tuple743 = v1.items[Int(v7)]
    v8 = spiral_tuple743.0
    v9 = spiral_tuple743.1
    var v10: Int32 = 0
    if (v4) {
        v10 = 1
    } else {
        v10 = 0
    }
    var v11: Int32 = 0
    if (v6) {
        v11 = 10
    } else {
        v11 = 0
    }
    var v12: Int32 = 0
    if (v9) {
        v12 = 100
    } else {
        v12 = 0
    }
    let v13: Int32 = (v3 &+ v5)
    let v14: Int32 = (v13 &+ v8)
    let v15: Int32 = (v14 &+ v10)
    let v16: Int32 = (v15 &+ v11)
    let v17: Int32 = (v16 &+ v12)
    return v17
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
