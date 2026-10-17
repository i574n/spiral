import CRT
import WinSDK
func sp_lcg_0(_ p0: UInt64, _ p1: UInt64, _ p2: Int32, _ p3: UInt64) -> UInt64 {
    var v0: UInt64 = p0
    var v1: UInt64 = p1
    var v2: Int32 = p2
    var v3: UInt64 = p3
    while true {
        var v4: Bool = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            var v5: Int32 = 0
            v5 = (v2 &- 1)
            var v6: UInt64 = (0 as UInt64)
            v6 = (v3 &* v0)
            var v7: UInt64 = (0 as UInt64)
            v7 = (v6 &+ v1)
            let t518_0: UInt64 = v0
            let t555_1: UInt64 = v1
            let t592_5: Int32 = v5
            let t628_7: UInt64 = v7
            v0 = t518_0
            v1 = t555_1
            v2 = t592_5
            v3 = t628_7
            continue
        }
    }
    return (0 as UInt64)
}
func spiral_main() -> Int32 {
    var v0: UInt64 = (0 as UInt64)
    v0 = (42 as UInt64)
    var v1: UInt64 = (0 as UInt64)
    v1 = (6364136223846793005 as UInt64)
    var v2: UInt64 = (0 as UInt64)
    v2 = (1442695040888963407 as UInt64)
    var v3: Int32 = 0
    v3 = 1000
    var v4: UInt64 = (0 as UInt64)
    v4 = sp_lcg_0(v1, v2, v3, v0)
    _ = fputs("lcg " + String(v4) + "\n", stdout)
    var v5: Int64 = (0 as Int64)
    v5 = (9223372036854775807 as Int64)
    var v6: Int64 = (0 as Int64)
    v6 = (-9223372036854775807 as Int64)
    var v7: UInt64 = (0 as UInt64)
    v7 = (18446744073709551615 as UInt64)
    var v8: Int64 = (0 as Int64)
    v8 = (v6 &- (1 as Int64))
    var v9: UInt64 = (0 as UInt64)
    v9 = (v7 &+ (2 as UInt64))
    _ = fputs("max " + String(v5) + " min " + String(v8) + " wrap " + String(v9) + "\n", stdout)
    var v10: Int64 = (0 as Int64)
    v10 = (-9007199254740993 as Int64)
    var v11: Int64 = (0 as Int64)
    v11 = (7 as Int64)
    var v12: Int64 = (0 as Int64)
    v12 = (v10 / v11)
    var v13: Int64 = (0 as Int64)
    v13 = (v10 % v11)
    _ = fputs("div " + String(v12) + " mod " + String(v13) + "\n", stdout)
    var v14: Int64 = (0 as Int64)
    v14 = (v10 >> 3)
    var v15: UInt64 = (0 as UInt64)
    v15 = (v4 >> 60)
    _ = fputs("shl " + String((4611686018427387904 as Int64)) + " shr " + String(v14) + " ushr " + String(v15) + "\n", stdout)
    var v16: UInt64 = (0 as UInt64)
    v16 = (v4 & (18446744069414584320 as UInt64))
    var v17: Int64 = (0 as Int64)
    v17 = (v10 | (255 as Int64))
    var v18: UInt64 = (0 as UInt64)
    v18 = (v4 ^ v1)
    _ = fputs("and " + String(v16) + " or " + String(v17) + " xor " + String(v18) + "\n", stdout)
    var v19: Double = (0.0 as Double)
    v19 = (1E+18 as Double)
    var v20: Int64 = (0 as Int64)
    v20 = Int64(v19)
    var v21: UInt32 = UInt32(0)
    v21 = UInt32(truncatingIfNeeded: v4)
    var v22: Double = (0.0 as Double)
    v22 = Double(v10)
    var v23: Bool = false
    v23 = (v22 < (0.0 as Double))
    var v24: Int32 = 0
    if (v23) {
        v24 = 1
    } else {
        v24 = 0
    }
    _ = fputs("conv " + String(v20) + " " + String(v21) + " " + String(v24) + "\n", stdout)
    var v25: Bool = false
    v25 = (v4 > v1)
    if (v25) {
        return 1
    } else {
        return 0
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
