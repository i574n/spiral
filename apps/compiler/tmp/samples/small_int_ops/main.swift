import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int8 = Int8(0)
    v0 = Int8(100)
    var v1: Int8 = Int8(0)
    v1 = Int8(3)
    var v2: Int8 = Int8(0)
    v2 = (v0 &* v1)
    var v3: Int8 = Int8(0)
    v3 = Int8(-8)
    var v4: Int8 = Int8(0)
    v4 = Int8(2)
    var v5: Int8 = Int8(0)
    v5 = (v3 / v4)
    var v6: Int8 = Int8(0)
    v6 = (v3 % v1)
    var v7: Int8 = Int8(0)
    v7 = (-(v1))
    var v8: Int8 = Int8(0)
    v8 = (v0 << 1)
    var v9: UInt8 = UInt8(0)
    v9 = UInt8(200)
    var v10: UInt8 = UInt8(0)
    v10 = UInt8(3)
    var v11: UInt8 = UInt8(0)
    v11 = (v9 / v10)
    var v12: UInt8 = UInt8(0)
    v12 = (v9 % v10)
    var v13: UInt8 = UInt8(0)
    v13 = UInt8(15)
    var v14: UInt8 = UInt8(0)
    v14 = (v9 & v13)
    var v15: UInt8 = UInt8(0)
    v15 = (v9 | v13)
    var v16: UInt8 = UInt8(0)
    v16 = (v9 ^ v13)
    var v17: UInt8 = UInt8(0)
    v17 = (~(v13))
    var v18: Int16 = Int16(0)
    v18 = Int16(20000)
    var v19: Int16 = Int16(0)
    v19 = Int16(7)
    var v20: Int16 = Int16(0)
    v20 = (v18 / v19)
    var v21: Int16 = Int16(0)
    v21 = (v18 % v19)
    var v22: Int16 = Int16(0)
    v22 = (-(v18))
    var v23: UInt16 = UInt16(0)
    v23 = UInt16(40000)
    var v24: UInt16 = UInt16(0)
    v24 = (v23 << 1)
    var v25: Bool = false
    v25 = (v2 == Int8(44))
    var v27: Bool = false
    if (v25) {
        var v26: Bool = false
        v26 = (v5 == Int8(-4))
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Bool = false
    if (v27) {
        var v28: Bool = false
        v28 = (v6 == Int8(-2))
        v29 = v28
    } else {
        v29 = false
    }
    var v31: Bool = false
    if (v29) {
        var v30: Bool = false
        v30 = (v7 == Int8(-3))
        v31 = v30
    } else {
        v31 = false
    }
    var v33: Bool = false
    if (v31) {
        var v32: Bool = false
        v32 = (v8 == Int8(-56))
        v33 = v32
    } else {
        v33 = false
    }
    var v35: Bool = false
    if (v33) {
        var v34: Bool = false
        v34 = (v11 == UInt8(66))
        v35 = v34
    } else {
        v35 = false
    }
    var v37: Bool = false
    if (v35) {
        var v36: Bool = false
        v36 = (v12 == UInt8(2))
        v37 = v36
    } else {
        v37 = false
    }
    var v39: Bool = false
    if (v37) {
        var v38: Bool = false
        v38 = (v14 == UInt8(8))
        v39 = v38
    } else {
        v39 = false
    }
    var v41: Bool = false
    if (v39) {
        var v40: Bool = false
        v40 = (v15 == UInt8(207))
        v41 = v40
    } else {
        v41 = false
    }
    var v43: Bool = false
    if (v41) {
        var v42: Bool = false
        v42 = (v16 == UInt8(199))
        v43 = v42
    } else {
        v43 = false
    }
    var v45: Bool = false
    if (v43) {
        var v44: Bool = false
        v44 = (v17 == UInt8(240))
        v45 = v44
    } else {
        v45 = false
    }
    var v47: Bool = false
    if (v45) {
        var v46: Bool = false
        v46 = (v20 == Int16(2857))
        v47 = v46
    } else {
        v47 = false
    }
    var v49: Bool = false
    if (v47) {
        var v48: Bool = false
        v48 = (v21 == Int16(1))
        v49 = v48
    } else {
        v49 = false
    }
    var v51: Bool = false
    if (v49) {
        var v50: Bool = false
        v50 = (v22 == Int16(-20000))
        v51 = v50
    } else {
        v51 = false
    }
    var v53: Bool = false
    if (v51) {
        var v52: Bool = false
        v52 = (v24 == UInt16(14464))
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
