import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: UInt8 = UInt8(250)
    let v1: UInt8 = UInt8(10)
    let v2: UInt32 = UInt32(4294967295)
    let v3: UInt64 = (18446744073709551615 as UInt64)
    let v4: Int8 = Int8(127)
    let v5: Int8 = Int8(1)
    let v6: Int32 = 7
    let v7: Int32 = 2
    let v8: Int64 = (9223372036854775807 as Int64)
    let v9: Int32 = (-(v6))
    let v10: Int64 = (-(v8))
    let v11: UInt8 = (v0 &+ v1)
    let v12: Bool = (v11 == UInt8(4))
    if (v12) {
        let v13: UInt32 = (v2 &+ UInt32(1))
        let v14: Bool = (v13 == UInt32(0))
        if (v14) {
            let v15: UInt32 = (v2 &* v2)
            let v16: Bool = (v15 == UInt32(1))
            if (v16) {
                let v17: UInt64 = (v3 &+ (1 as UInt64))
                let v18: Bool = (v17 == (0 as UInt64))
                if (v18) {
                    let v19: UInt64 = (v3 &* v3)
                    let v20: Bool = (v19 == (1 as UInt64))
                    if (v20) {
                        let v21: UInt64 = (v3 / (3 as UInt64))
                        let v22: Bool = (v21 == (6148914691236517205 as UInt64))
                        if (v22) {
                            let v23: Int8 = (v4 &+ v5)
                            let v24: Bool = (v23 < Int8(0))
                            if (v24) {
                                let v25: Int32 = (v9 / v7)
                                let v26: Bool = (v25 == -3)
                                if (v26) {
                                    let v27: Int32 = (v9 % v7)
                                    let v28: Bool = (v27 == -1)
                                    if (v28) {
                                        let v29: Int64 = (v10 % (10 as Int64))
                                        let v30: Bool = (v29 == (-7 as Int64))
                                        if (v30) {
                                            let v31: UInt32 = (v2 >> 28)
                                            let v32: Bool = (v31 == UInt32(15))
                                            if (v32) {
                                                let v33: Int32 = (v9 >> 1)
                                                let v34: Bool = (v33 == -4)
                                                if (v34) {
                                                    return 0
                                                } else {
                                                    return 12
                                                }
                                            } else {
                                                return 11
                                            }
                                        } else {
                                            return 10
                                        }
                                    } else {
                                        return 9
                                    }
                                } else {
                                    return 8
                                }
                            } else {
                                return 7
                            }
                        } else {
                            return 6
                        }
                    } else {
                        return 5
                    }
                } else {
                    return 4
                }
            } else {
                return 3
            }
        } else {
            return 2
        }
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
