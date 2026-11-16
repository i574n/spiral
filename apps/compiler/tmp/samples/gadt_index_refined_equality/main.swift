import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Vowel: US0 { var f0: Int32; var tag: Int32 { 1 } }
protocol UH1 { var tag: Int32 { get } }
struct UH1_Nil: UH1 { var tag: Int32 { 0 } }
struct UH1_Cons: UH1 { var f0: US0; var f1: UH1; var tag: Int32 { 1 } }
func sp_method0(_ p0: UH1, _ p1: UH1) -> Bool {
    var v0: UH1 = p0
    var v1: UH1 = p1
    switch (v1.tag == v0.tag ? v1.tag : -1) {
        case 1:
            var v2: US0 = (v1 as! UH1_Cons).f0
            var v3: UH1 = (v1 as! UH1_Cons).f1
            var v4: US0 = (v0 as! UH1_Cons).f0
            var v5: UH1 = (v0 as! UH1_Cons).f1
            var v9: Bool = false
            switch (v2.tag == v4.tag ? v2.tag : -1) {
                case 1:
                    var v6: Int32 = (v2 as! US0_Vowel).f0
                    var v7: Int32 = (v4 as! US0_Vowel).f0
                    var v8: Bool = false
                    v8 = (v6 == v7)
                    v9 = v8
                default:
                    v9 = false
            }
            if (v9) {
                return sp_method0(v5, v3)
            } else {
                return false
            }
        case 0:
            return true
        default:
            return false
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 1
    let v1: US0 = US0_Vowel(f0: v0)
    let v2: Int32 = 1
    let v3: US0 = US0_Vowel(f0: v2)
    let v4: Int32 = 2
    let v5: US0 = US0_Vowel(f0: v4)
    let v6: UH1 = UH1_Nil()
    let v7: UH1 = UH1_Cons(f0: v5, f1: v6)
    var v8: UH1 = UH1_Nil()
    v8 = UH1_Cons(f0: v1, f1: v7)
    var v9: UH1 = UH1_Nil()
    v9 = UH1_Nil()
    let v10: UH1 = UH1_Cons(f0: v5, f1: v9)
    let v11: UH1 = UH1_Cons(f0: v3, f1: v10)
    let v12: UH1 = UH1_Nil()
    let v13: UH1 = UH1_Cons(f0: v1, f1: v12)
    var v17: Bool = false
    switch (v1.tag == v3.tag ? v1.tag : -1) {
        case 1:
            var v14: Int32 = (v1 as! US0_Vowel).f0
            var v15: Int32 = (v3 as! US0_Vowel).f0
            let v16: Bool = (v14 == v15)
            v17 = v16
        default:
            v17 = false
    }
    var v23: Bool = false
    if (v17) {
        var v21: Bool = false
        switch (v1.tag == v5.tag ? v1.tag : -1) {
            case 1:
                var v18: Int32 = (v1 as! US0_Vowel).f0
                var v19: Int32 = (v5 as! US0_Vowel).f0
                let v20: Bool = (v18 == v19)
                v21 = v20
            default:
                v21 = false
        }
        let v22: Bool = (v21 == false)
        v23 = v22
    } else {
        v23 = false
    }
    var v30: Bool = false
    if (v23) {
        var v27: Bool = false
        switch (v1.tag == v3.tag ? v1.tag : -1) {
            case 1:
                var v24: Int32 = (v1 as! US0_Vowel).f0
                var v25: Int32 = (v3 as! US0_Vowel).f0
                let v26: Bool = (v24 == v25)
                v27 = v26
            default:
                v27 = false
        }
        if (v27) {
            v30 = sp_method0(v11, v8)
        } else {
            v30 = false
        }
    } else {
        v30 = false
    }
    var v38: Bool = false
    if (v30) {
        var v34: Bool = false
        switch (v1.tag == v5.tag ? v1.tag : -1) {
            case 1:
                var v31: Int32 = (v1 as! US0_Vowel).f0
                var v32: Int32 = (v5 as! US0_Vowel).f0
                let v33: Bool = (v31 == v32)
                v34 = v33
            default:
                v34 = false
        }
        var v36: Bool = false
        if (v34) {
            v36 = sp_method0(v13, v8)
        } else {
            v36 = false
        }
        let v37: Bool = (v36 == false)
        v38 = v37
    } else {
        v38 = false
    }
    if (v38) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
