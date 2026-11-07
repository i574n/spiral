import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    let l1: String
    init(l0: Int32, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
class Heap1 {
    let l0: Heap0
    let l1: Heap0
    init(l0: Heap0, l1: Heap0) {
        self.l0 = l0
        self.l1 = l1
    }
}
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    let v1: String = "hi"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 4
    let v4: String = "yo"
    let v5: Heap0 = Heap0(l0: v3, l1: v4)
    let v6: Heap1 = Heap1(l0: v2, l1: v5)
    var v7: SpiralArray<Heap1> = SpiralArray<Heap1>([])
    v7 = SpiralArray<Heap1>(Array(repeating: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), count: Int(1)))
    v7.items[Int(0)] = v6
    let v8: Heap1 = v7.items[Int(0)]
    var v9: Heap0 = Heap0(l0: 0, l1: "")
    var v10: Heap0 = Heap0(l0: 0, l1: "")
    v9 = v8.l0
    v10 = v8.l1
    var v11: Int32 = 0
    var v12: String = ""
    v11 = v9.l0
    v12 = v9.l1
    var v13: Int32 = 0
    var v14: String = ""
    v13 = v10.l0
    v14 = v10.l1
    let v15: Bool = (v11 == 7)
    var v17: Bool = false
    if (v15) {
        let v16: Bool = (v12 == "hi")
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Bool = false
    if (v17) {
        let v18: Bool = (v13 == 4)
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Bool = false
    if (v19) {
        let v20: Bool = (v14 == "yo")
        v21 = v20
    } else {
        v21 = false
    }
    if (v21) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
