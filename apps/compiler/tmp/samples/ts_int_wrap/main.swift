import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: UInt8 = UInt8(0)
    v0 = UInt8(250)
    var v1: UInt8 = UInt8(0)
    v1 = UInt8(10)
    var v2: UInt32 = UInt32(0)
    v2 = UInt32(4294967295)
    var v3: UInt64 = (0 as UInt64)
    v3 = (18446744073709551615 as UInt64)
    var v4: Int8 = Int8(0)
    v4 = Int8(127)
    var v5: Int8 = Int8(0)
    v5 = Int8(1)
    var v6: Int32 = 0
    v6 = 7
    var v7: Int32 = 0
    v7 = 2
    var v8: Int64 = (0 as Int64)
    v8 = (9223372036854775807 as Int64)
    var v9: Int32 = 0
    v9 = (-(v6))
    var v10: Int64 = (0 as Int64)
    v10 = (-(v8))
    var v11: UInt8 = UInt8(0)
    v11 = (v0 &+ v1)
    var v12: Bool = false
    v12 = (v11 == UInt8(4))
    if (v12) {
        var v13: UInt32 = UInt32(0)
        v13 = (v2 &+ UInt32(1))
        var v14: Bool = false
        v14 = (v13 == UInt32(0))
        if (v14) {
            var v15: UInt32 = UInt32(0)
            v15 = (v2 &* v2)
            var v16: Bool = false
            v16 = (v15 == UInt32(1))
            if (v16) {
                var v17: UInt64 = (0 as UInt64)
                v17 = (v3 &+ (1 as UInt64))
                var v18: Bool = false
                v18 = (v17 == (0 as UInt64))
                if (v18) {
                    var v19: UInt64 = (0 as UInt64)
                    v19 = (v3 &* v3)
                    var v20: Bool = false
                    v20 = (v19 == (1 as UInt64))
                    if (v20) {
                        var v21: UInt64 = (0 as UInt64)
                        v21 = (v3 / (3 as UInt64))
                        var v22: Bool = false
                        v22 = (v21 == (6148914691236517205 as UInt64))
                        if (v22) {
                            var v23: Int8 = Int8(0)
                            v23 = (v4 &+ v5)
                            var v24: Bool = false
                            v24 = (v23 < Int8(0))
                            if (v24) {
                                var v25: Int32 = 0
                                v25 = (v9 / v7)
                                var v26: Bool = false
                                v26 = (v25 == -3)
                                if (v26) {
                                    var v27: Int32 = 0
                                    v27 = (v9 % v7)
                                    var v28: Bool = false
                                    v28 = (v27 == -1)
                                    if (v28) {
                                        var v29: Int64 = (0 as Int64)
                                        v29 = (v10 % (10 as Int64))
                                        var v30: Bool = false
                                        v30 = (v29 == (-7 as Int64))
                                        if (v30) {
                                            var v31: UInt32 = UInt32(0)
                                            v31 = (v2 >> 28)
                                            var v32: Bool = false
                                            v32 = (v31 == UInt32(15))
                                            if (v32) {
                                                var v33: Int32 = 0
                                                v33 = (v9 >> 1)
                                                var v34: Bool = false
                                                v34 = (v33 == -4)
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
