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
            v2 = v5
            v3 = v7
            continue
        }
    }
    return (0 as UInt64)
}
func spiral_main() -> Int32 {
    let v0: UInt64 = (42 as UInt64)
    let v1: UInt64 = (6364136223846793005 as UInt64)
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
    let v8: Int64 = (v6 &- (1 as Int64))
    let v9: UInt64 = (v7 &+ (2 as UInt64))
    _ = fputs("max " + String(v5) + " min " + String(v8) + " wrap " + String(v9) + "\n", stdout)
    let v10: Int64 = (-9007199254740993 as Int64)
    let v11: Int64 = (7 as Int64)
    let v12: Int64 = (v10 / v11)
    let v13: Int64 = (v10 % v11)
    _ = fputs("div " + String(v12) + " mod " + String(v13) + "\n", stdout)
    let v14: Int64 = (v10 >> 3)
    let v15: UInt64 = (v4 >> 60)
    _ = fputs("shl " + String((4611686018427387904 as Int64)) + " shr " + String(v14) + " ushr " + String(v15) + "\n", stdout)
    let v16: UInt64 = (v4 & (18446744069414584320 as UInt64))
    let v17: Int64 = (v10 | (255 as Int64))
    let v18: UInt64 = (v4 ^ v1)
    _ = fputs("and " + String(v16) + " or " + String(v17) + " xor " + String(v18) + "\n", stdout)
    let v19: Double = (1E+18 as Double)
    let v20: Int64 = Int64(v19)
    let v21: UInt32 = UInt32(truncatingIfNeeded: v4)
    let v22: Double = Double(v10)
    let v23: Bool = (v22 < (0.0 as Double))
    var v24: Int32 = 0
    if (v23) {
        v24 = 1
    } else {
        v24 = 0
    }
    _ = fputs("conv " + String(v20) + " " + String(v21) + " " + String(v24) + "\n", stdout)
    let v25: Bool = (v4 > v1)
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
