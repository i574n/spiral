import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Double = (0.0 as Double)
    v0 = (2.7 as Double)
    var v1: Double = (0.0 as Double)
    v1 = (3.2 as Double)
    var v2: Double = (0.0 as Double)
    v2 = (-2.5 as Double)
    var v3: Double = (0.0 as Double)
    v3 = (3.5 as Double)
    var v4: Double = (0.0 as Double)
    v4 = (0.5 as Double)
    var v5: Double = (0.0 as Double)
    v5 = (1.0 as Double)
    var v6: Float = (0.0 as Float)
    v6 = (2.7 as Float)
    var v7: Double = (0.0 as Double)
    v7 = (v0).rounded(.down)
    var v8: Bool = false
    v8 = (v7 != (2.0 as Double))
    if (v8) {
        return 1
    } else {
        var v9: Double = (0.0 as Double)
        v9 = (v0).rounded(.up)
        var v10: Bool = false
        v10 = (v9 != (3.0 as Double))
        if (v10) {
            return 2
        } else {
            var v11: Double = (0.0 as Double)
            v11 = (v0).rounded(.toNearestOrEven)
            var v12: Bool = false
            v12 = (v11 != (3.0 as Double))
            if (v12) {
                return 3
            } else {
                var v13: Double = (0.0 as Double)
                v13 = (v1).rounded(.toNearestOrEven)
                var v14: Bool = false
                v14 = (v13 != (3.0 as Double))
                if (v14) {
                    return 4
                } else {
                    var v15: Double = (0.0 as Double)
                    v15 = (v2).rounded(.toNearestOrEven)
                    var v16: Bool = false
                    v16 = (v15 != (-2.0 as Double))
                    if (v16) {
                        return 5
                    } else {
                        var v17: Double = (0.0 as Double)
                        v17 = (v3).rounded(.toNearestOrEven)
                        var v18: Bool = false
                        v18 = (v17 != (4.0 as Double))
                        if (v18) {
                            return 6
                        } else {
                            var v19: Double = (0.0 as Double)
                            v19 = (v4).rounded(.toNearestOrEven)
                            var v20: Bool = false
                            v20 = (v19 != (0.0 as Double))
                            if (v20) {
                                return 7
                            } else {
                                var v21: Double = (0.0 as Double)
                                v21 = atan2(v5, v5)
                                var v22: Double = (0.0 as Double)
                                v22 = (v21 * (1000.0 as Double))
                                var v23: Double = (0.0 as Double)
                                v23 = (v22).rounded(.down)
                                var v24: Bool = false
                                v24 = (v23 != (785.0 as Double))
                                if (v24) {
                                    return 8
                                } else {
                                    var v25: Float = (0.0 as Float)
                                    v25 = (v6).rounded(.down)
                                    var v26: Bool = false
                                    v26 = (v25 != (2.0 as Float))
                                    if (v26) {
                                        return 9
                                    } else {
                                        return 0
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
