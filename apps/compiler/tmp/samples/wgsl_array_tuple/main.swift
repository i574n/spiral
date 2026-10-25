import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: SpiralArray<(Int32, Bool)> = SpiralArray<(Int32, Bool)>([])
    v1 = SpiralArray<(Int32, Bool)>(Array(repeating: (0, false), count: Int(v0)))
    var v2: Int32 = 0
    v2 = 4
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
    var v7: Int32 = 0
    v7 = 2
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
    var v13: Int32 = 0
    v13 = (v3 &+ v5)
    var v14: Int32 = 0
    v14 = (v13 &+ v8)
    var v15: Int32 = 0
    v15 = (v14 &+ v10)
    var v16: Int32 = 0
    v16 = (v15 &+ v11)
    var v17: Int32 = 0
    v17 = (v16 &+ v12)
    return v17
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
