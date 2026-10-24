import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int8 = Int8(100)
    let v1: Int8 = Int8(3)
    let v2: Int8 = (v0 &* v1)
    let v3: Int8 = Int8(-8)
    let v4: Int8 = Int8(2)
    let v5: Int8 = (v3 / v4)
    let v6: Int8 = (v3 % v1)
    let v7: Int8 = (-(v1))
    let v8: Int8 = (v0 << 1)
    let v9: UInt8 = UInt8(200)
    let v10: UInt8 = UInt8(3)
    let v11: UInt8 = (v9 / v10)
    let v12: UInt8 = (v9 % v10)
    let v13: UInt8 = UInt8(15)
    let v14: UInt8 = (v9 & v13)
    let v15: UInt8 = (v9 | v13)
    let v16: UInt8 = (v9 ^ v13)
    let v17: UInt8 = (~(v13))
    let v18: Int16 = Int16(20000)
    let v19: Int16 = Int16(7)
    let v20: Int16 = (v18 / v19)
    let v21: Int16 = (v18 % v19)
    let v22: Int16 = (-(v18))
    let v23: UInt16 = UInt16(40000)
    let v24: UInt16 = (v23 << 1)
    let v25: Bool = (v2 == Int8(44))
    var v27: Bool = false
    if (v25) {
        let v26: Bool = (v5 == Int8(-4))
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Bool = false
    if (v27) {
        let v28: Bool = (v6 == Int8(-2))
        v29 = v28
    } else {
        v29 = false
    }
    var v31: Bool = false
    if (v29) {
        let v30: Bool = (v7 == Int8(-3))
        v31 = v30
    } else {
        v31 = false
    }
    var v33: Bool = false
    if (v31) {
        let v32: Bool = (v8 == Int8(-56))
        v33 = v32
    } else {
        v33 = false
    }
    var v35: Bool = false
    if (v33) {
        let v34: Bool = (v11 == UInt8(66))
        v35 = v34
    } else {
        v35 = false
    }
    var v37: Bool = false
    if (v35) {
        let v36: Bool = (v12 == UInt8(2))
        v37 = v36
    } else {
        v37 = false
    }
    var v39: Bool = false
    if (v37) {
        let v38: Bool = (v14 == UInt8(8))
        v39 = v38
    } else {
        v39 = false
    }
    var v41: Bool = false
    if (v39) {
        let v40: Bool = (v15 == UInt8(207))
        v41 = v40
    } else {
        v41 = false
    }
    var v43: Bool = false
    if (v41) {
        let v42: Bool = (v16 == UInt8(199))
        v43 = v42
    } else {
        v43 = false
    }
    var v45: Bool = false
    if (v43) {
        let v44: Bool = (v17 == UInt8(240))
        v45 = v44
    } else {
        v45 = false
    }
    var v47: Bool = false
    if (v45) {
        let v46: Bool = (v20 == Int16(2857))
        v47 = v46
    } else {
        v47 = false
    }
    var v49: Bool = false
    if (v47) {
        let v48: Bool = (v21 == Int16(1))
        v49 = v48
    } else {
        v49 = false
    }
    var v51: Bool = false
    if (v49) {
        let v50: Bool = (v22 == Int16(-20000))
        v51 = v50
    } else {
        v51 = false
    }
    var v53: Bool = false
    if (v51) {
        let v52: Bool = (v24 == UInt16(14464))
        v53 = v52
    } else {
        v53 = false
    }
    if (v53) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
