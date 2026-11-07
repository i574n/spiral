import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int8 = Int8.min
    let v1: Int16 = Int16.min
    let v2: Int32 = -5
    let v3: Int64 = (-1234567890123 as Int64)
    let v4: UInt8 = UInt8(255)
    let v5: UInt16 = UInt16(65535)
    let v6: UInt32 = UInt32(4294967295)
    let v7: UInt64 = (18446744073709551615 as UInt64)
    let v8: Bool = true
    let v9: Bool = false
    let v10: Int32 = 97
    let v11: String = String(v0)
    let v12: Bool = (v11 == "-128")
    var v13: Int32 = 0
    if (v12) {
        v13 = 0
    } else {
        v13 = 1
    }
    let v14: String = String(v1)
    let v15: Bool = (v14 == "-32768")
    var v16: Int32 = 0
    if (v15) {
        v16 = 0
    } else {
        v16 = 1
    }
    let v17: Int32 = (v13 &+ v16)
    let v18: String = String(v2)
    let v19: Bool = (v18 == "-5")
    var v20: Int32 = 0
    if (v19) {
        v20 = 0
    } else {
        v20 = 1
    }
    let v21: Int32 = (v17 &+ v20)
    let v22: String = String(v3)
    let v23: Bool = (v22 == "-1234567890123")
    var v24: Int32 = 0
    if (v23) {
        v24 = 0
    } else {
        v24 = 1
    }
    let v25: Int32 = (v21 &+ v24)
    let v26: String = String(v4)
    let v27: Bool = (v26 == "255")
    var v28: Int32 = 0
    if (v27) {
        v28 = 0
    } else {
        v28 = 1
    }
    let v29: Int32 = (v25 &+ v28)
    let v30: String = String(v5)
    let v31: Bool = (v30 == "65535")
    var v32: Int32 = 0
    if (v31) {
        v32 = 0
    } else {
        v32 = 1
    }
    let v33: Int32 = (v29 &+ v32)
    let v34: String = String(v6)
    let v35: Bool = (v34 == "4294967295")
    var v36: Int32 = 0
    if (v35) {
        v36 = 0
    } else {
        v36 = 1
    }
    let v37: Int32 = (v33 &+ v36)
    let v38: String = String(v7)
    let v39: Bool = (v38 == "18446744073709551615")
    var v40: Int32 = 0
    if (v39) {
        v40 = 0
    } else {
        v40 = 1
    }
    let v41: Int32 = (v37 &+ v40)
    let v42: String = String(v8)
    let v43: Bool = (v42 == "true")
    var v44: Int32 = 0
    if (v43) {
        v44 = 0
    } else {
        v44 = 1
    }
    let v45: Int32 = (v41 &+ v44)
    let v46: String = String(v9)
    let v47: Bool = (v46 == "false")
    var v48: Int32 = 0
    if (v47) {
        v48 = 0
    } else {
        v48 = 1
    }
    let v49: Int32 = (v45 &+ v48)
    let v50: String = String(UnicodeScalar(UInt8(truncatingIfNeeded: v10)))
    let v51: Bool = (v50 == "a")
    var v52: Int32 = 0
    if (v51) {
        v52 = 0
    } else {
        v52 = 1
    }
    let v53: Int32 = (v49 &+ v52)
    let v54: String = String(UInt8(7))
    let v55: Bool = (v54 == "7")
    var v56: Int32 = 0
    if (v55) {
        v56 = 0
    } else {
        v56 = 1
    }
    let v57: Int32 = (v53 &+ v56)
    let v58: String = String(false)
    let v59: Bool = (v58 == "false")
    var v60: Int32 = 0
    if (v59) {
        v60 = 0
    } else {
        v60 = 1
    }
    let v61: Int32 = (v57 &+ v60)
    let v62: String = String(UnicodeScalar(UInt8(truncatingIfNeeded: 122)))
    let v63: Bool = (v62 == "z")
    var v64: Int32 = 0
    if (v63) {
        v64 = 0
    } else {
        v64 = 1
    }
    let v65: Int32 = (v61 &+ v64)
    let v66: String = String((-3 as Int64))
    let v67: Bool = (v66 == "-3")
    var v68: Int32 = 0
    if (v67) {
        v68 = 0
    } else {
        v68 = 1
    }
    let v69: Int32 = (v65 &+ v68)
    return v69
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
