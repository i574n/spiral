import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_None: US0 { var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "ff"
    var v1: Int32 = 0
    v1 = (Int32(String((v0).split(separator: " ").first ?? ""), radix: Int(16)) ?? 0)
    print(v1)
    var v2: String = ""
    v2 = "1011"
    var v3: Int32 = 0
    v3 = (Int32(String((v2).split(separator: " ").first ?? ""), radix: Int(2)) ?? 0)
    print(v3)
    var v4: String = ""
    v4 = "-42"
    var v5: Int32 = 0
    v5 = (Int32(String((v4).split(separator: " ").first ?? ""), radix: Int(10)) ?? 0)
    print(v5)
    var v6: String = ""
    v6 = " 123 "
    var v7: Bool = false
    v7 = ((v6).split(separator: " ").count == 1 && Int64(String((v6).split(separator: " ")[0])) != nil)
    var v8: Int64 = (0 as Int64)
    v8 = (Int64(String((v6).split(separator: " ").first ?? "")) ?? 0)
    var v9: Int32 = 0
    v9 = Int32(truncatingIfNeeded: v8)
    var v13: Bool = false
    if (v7) {
        var v10: Bool = false
        v10 = (v8 >= (-2147483648 as Int64))
        if (v10) {
            var v11: Bool = false
            v11 = (v8 <= (2147483647 as Int64))
            v13 = v11
        } else {
            v13 = false
        }
    } else {
        v13 = false
    }
    var v16: US0 = US0_Some(f0: 0)
    if (v13) {
        v16 = US0_Some(f0: v9)
    } else {
        v16 = US0_None()
    }
    switch v16.tag {
        case 1:
            var v18: String = ""
            v18 = "none"
            print(v18)
        case 0:
            var v17: Int32 = (v16 as! US0_Some).f0
            print(v17)
        default:
            fatalError("unreachable union case")
    }
    var v19: String = ""
    v19 = "12x"
    var v20: Bool = false
    v20 = ((v19).split(separator: " ").count == 1 && Int64(String((v19).split(separator: " ")[0])) != nil)
    var v21: Int64 = (0 as Int64)
    v21 = (Int64(String((v19).split(separator: " ").first ?? "")) ?? 0)
    var v22: Int32 = 0
    v22 = Int32(truncatingIfNeeded: v21)
    var v26: Bool = false
    if (v20) {
        var v23: Bool = false
        v23 = (v21 >= (-2147483648 as Int64))
        if (v23) {
            var v24: Bool = false
            v24 = (v21 <= (2147483647 as Int64))
            v26 = v24
        } else {
            v26 = false
        }
    } else {
        v26 = false
    }
    var v29: US0 = US0_Some(f0: 0)
    if (v26) {
        v29 = US0_Some(f0: v22)
    } else {
        v29 = US0_None()
    }
    switch v29.tag {
        case 1:
            var v31: String = ""
            v31 = "none"
            print(v31)
        case 0:
            var v30: Int32 = (v29 as! US0_Some).f0
            print(v30)
        default:
            fatalError("unreachable union case")
    }
    var v32: String = ""
    v32 = ""
    var v33: Bool = false
    v33 = ((v32).split(separator: " ").count == 1 && Int64(String((v32).split(separator: " ")[0])) != nil)
    var v34: Int64 = (0 as Int64)
    v34 = (Int64(String((v32).split(separator: " ").first ?? "")) ?? 0)
    var v35: Int32 = 0
    v35 = Int32(truncatingIfNeeded: v34)
    var v39: Bool = false
    if (v33) {
        var v36: Bool = false
        v36 = (v34 >= (-2147483648 as Int64))
        if (v36) {
            var v37: Bool = false
            v37 = (v34 <= (2147483647 as Int64))
            v39 = v37
        } else {
            v39 = false
        }
    } else {
        v39 = false
    }
    var v42: US0 = US0_Some(f0: 0)
    if (v39) {
        v42 = US0_Some(f0: v35)
    } else {
        v42 = US0_None()
    }
    switch v42.tag {
        case 1:
            var v44: String = ""
            v44 = "none"
            print(v44)
        case 0:
            var v43: Int32 = (v42 as! US0_Some).f0
            print(v43)
        default:
            fatalError("unreachable union case")
    }
    var v45: String = ""
    v45 = "+7"
    var v46: Bool = false
    v46 = ((v45).split(separator: " ").count == 1 && Int64(String((v45).split(separator: " ")[0])) != nil)
    var v47: Int64 = (0 as Int64)
    v47 = (Int64(String((v45).split(separator: " ").first ?? "")) ?? 0)
    var v48: Int32 = 0
    v48 = Int32(truncatingIfNeeded: v47)
    var v52: Bool = false
    if (v46) {
        var v49: Bool = false
        v49 = (v47 >= (-2147483648 as Int64))
        if (v49) {
            var v50: Bool = false
            v50 = (v47 <= (2147483647 as Int64))
            v52 = v50
        } else {
            v52 = false
        }
    } else {
        v52 = false
    }
    var v55: US0 = US0_Some(f0: 0)
    if (v52) {
        v55 = US0_Some(f0: v48)
    } else {
        v55 = US0_None()
    }
    switch v55.tag {
        case 1:
            var v57: String = ""
            v57 = "none"
            print(v57)
        case 0:
            var v56: Int32 = (v55 as! US0_Some).f0
            print(v56)
        default:
            fatalError("unreachable union case")
    }
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
