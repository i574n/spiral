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
    v8 = (v7 == (2.0 as Double))
    var v9: Bool = false
    v9 = (v8 != true)
    if (v9) {
        return 1
    } else {
        var v10: Double = (0.0 as Double)
        v10 = (v0).rounded(.up)
        var v11: Bool = false
        v11 = (v10 == (3.0 as Double))
        var v12: Bool = false
        v12 = (v11 != true)
        if (v12) {
            return 2
        } else {
            var v13: Double = (0.0 as Double)
            v13 = (v0).rounded(.toNearestOrEven)
            var v14: Bool = false
            v14 = (v13 == (3.0 as Double))
            var v15: Bool = false
            v15 = (v14 != true)
            if (v15) {
                return 3
            } else {
                var v16: Double = (0.0 as Double)
                v16 = (v1).rounded(.toNearestOrEven)
                var v17: Bool = false
                v17 = (v16 == (3.0 as Double))
                var v18: Bool = false
                v18 = (v17 != true)
                if (v18) {
                    return 4
                } else {
                    var v19: Double = (0.0 as Double)
                    v19 = (v2).rounded(.toNearestOrEven)
                    var v20: Bool = false
                    v20 = (v19 == (-2.0 as Double))
                    var v21: Bool = false
                    v21 = (v20 != true)
                    if (v21) {
                        return 5
                    } else {
                        var v22: Double = (0.0 as Double)
                        v22 = (v3).rounded(.toNearestOrEven)
                        var v23: Bool = false
                        v23 = (v22 == (4.0 as Double))
                        var v24: Bool = false
                        v24 = (v23 != true)
                        if (v24) {
                            return 6
                        } else {
                            var v25: Double = (0.0 as Double)
                            v25 = (v4).rounded(.toNearestOrEven)
                            var v26: Bool = false
                            v26 = (v25 == (0.0 as Double))
                            var v27: Bool = false
                            v27 = (v26 != true)
                            if (v27) {
                                return 7
                            } else {
                                var v28: Double = (0.0 as Double)
                                v28 = atan2(v5, v5)
                                var v29: Double = (0.0 as Double)
                                v29 = (v28 * (1000.0 as Double))
                                var v30: Double = (0.0 as Double)
                                v30 = (v29).rounded(.down)
                                var v31: Bool = false
                                v31 = (v30 == (785.0 as Double))
                                var v32: Bool = false
                                v32 = (v31 != true)
                                if (v32) {
                                    return 8
                                } else {
                                    var v33: Float = (0.0 as Float)
                                    v33 = (v6).rounded(.down)
                                    var v34: Bool = false
                                    v34 = (v33 == (2.0 as Float))
                                    var v35: Bool = false
                                    v35 = (v34 != true)
                                    if (v35) {
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
