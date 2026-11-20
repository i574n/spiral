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
class Mut1 {
    var l0: Heap0
    var l1: Heap0
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
    let v0: Int32 = 1
    let v1: String = "no"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 2
    let v4: String = "zz"
    let v5: Heap0 = Heap0(l0: v3, l1: v4)
    let v6: Mut1 = Mut1(l0: v2, l1: v5)
    var v7: SpiralArray<Mut1> = SpiralArray<Mut1>([])
    v7 = SpiralArray<Mut1>(Array(repeating: Mut1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), count: Int(1)))
    v7.items[Int(0)] = v6
    let v8: Int32 = 7
    let v9: String = "hi"
    let v10: Heap0 = Heap0(l0: v8, l1: v9)
    let v11: Int32 = 4
    let v12: String = "yo"
    let v13: Heap0 = Heap0(l0: v11, l1: v12)
    var v14: Mut1 = Mut1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v14 = v7.items[Int(0)]
    v14.l0 = v10
    v14.l1 = v13
    var v15: Heap0 = Heap0(l0: 0, l1: "")
    var v16: Heap0 = Heap0(l0: 0, l1: "")
    v15 = v14.l0
    v16 = v14.l1
    var v17: Int32 = 0
    var v18: String = ""
    v17 = v15.l0
    v18 = v15.l1
    var v19: Int32 = 0
    var v20: String = ""
    v19 = v16.l0
    v20 = v16.l1
    let v21: Bool = (v17 == 7)
    var v23: Bool = false
    if (v21) {
        let v22: Bool = (v18 == "hi")
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Bool = false
    if (v23) {
        let v24: Bool = (v19 == 4)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Bool = false
    if (v25) {
        let v26: Bool = (v20 == "yo")
        v27 = v26
    } else {
        v27 = false
    }
    if (v27) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
