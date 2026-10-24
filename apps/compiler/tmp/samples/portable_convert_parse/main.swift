import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_None: US0 { var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    let v0: String = "ff"
    let v1: Int32 = (Int32(String((v0).split(separator: " ").first ?? ""), radix: Int(16)) ?? 0)
    print(v1)
    let v2: String = "1011"
    let v3: Int32 = (Int32(String((v2).split(separator: " ").first ?? ""), radix: Int(2)) ?? 0)
    print(v3)
    let v4: String = "-42"
    let v5: Int32 = (Int32(String((v4).split(separator: " ").first ?? ""), radix: Int(10)) ?? 0)
    print(v5)
    let v6: String = " 123 "
    let v7: Bool = ((v6).split(separator: " ").count == 1 && Int64(String((v6).split(separator: " ")[0])) != nil)
    let v8: Int64 = (Int64(String((v6).split(separator: " ").first ?? "")) ?? 0)
    let v9: Int32 = Int32(truncatingIfNeeded: v8)
    var v13: Bool = false
    if (v7) {
        let v10: Bool = (v8 >= (-2147483648 as Int64))
        if (v10) {
            let v11: Bool = (v8 <= (2147483647 as Int64))
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
            let v18: String = "none"
            print(v18)
        case 0:
            var v17: Int32 = (v16 as! US0_Some).f0
            print(v17)
        default:
            fatalError("unreachable union case")
    }
    let v19: String = "12x"
    let v20: Bool = ((v19).split(separator: " ").count == 1 && Int64(String((v19).split(separator: " ")[0])) != nil)
    let v21: Int64 = (Int64(String((v19).split(separator: " ").first ?? "")) ?? 0)
    let v22: Int32 = Int32(truncatingIfNeeded: v21)
    var v26: Bool = false
    if (v20) {
        let v23: Bool = (v21 >= (-2147483648 as Int64))
        if (v23) {
            let v24: Bool = (v21 <= (2147483647 as Int64))
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
            let v31: String = "none"
            print(v31)
        case 0:
            var v30: Int32 = (v29 as! US0_Some).f0
            print(v30)
        default:
            fatalError("unreachable union case")
    }
    let v32: String = ""
    let v33: Bool = ((v32).split(separator: " ").count == 1 && Int64(String((v32).split(separator: " ")[0])) != nil)
    let v34: Int64 = (Int64(String((v32).split(separator: " ").first ?? "")) ?? 0)
    let v35: Int32 = Int32(truncatingIfNeeded: v34)
    var v39: Bool = false
    if (v33) {
        let v36: Bool = (v34 >= (-2147483648 as Int64))
        if (v36) {
            let v37: Bool = (v34 <= (2147483647 as Int64))
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
            let v44: String = "none"
            print(v44)
        case 0:
            var v43: Int32 = (v42 as! US0_Some).f0
            print(v43)
        default:
            fatalError("unreachable union case")
    }
    let v45: String = "+7"
    let v46: Bool = ((v45).split(separator: " ").count == 1 && Int64(String((v45).split(separator: " ")[0])) != nil)
    let v47: Int64 = (Int64(String((v45).split(separator: " ").first ?? "")) ?? 0)
    let v48: Int32 = Int32(truncatingIfNeeded: v47)
    var v52: Bool = false
    if (v46) {
        let v49: Bool = (v47 >= (-2147483648 as Int64))
        if (v49) {
            let v50: Bool = (v47 <= (2147483647 as Int64))
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
            let v57: String = "none"
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
