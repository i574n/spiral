import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Double = (2.7 as Double)
    let v1: Double = (3.2 as Double)
    let v2: Double = (-2.5 as Double)
    let v3: Double = (3.5 as Double)
    let v4: Double = (0.5 as Double)
    let v5: Double = (1.0 as Double)
    let v6: Float = (2.7 as Float)
    let v7: Double = (v0).rounded(.down)
    let v8: Bool = (v7 != (2.0 as Double))
    if (v8) {
        return 1
    } else {
        let v9: Double = (v0).rounded(.up)
        let v10: Bool = (v9 != (3.0 as Double))
        if (v10) {
            return 2
        } else {
            let v11: Double = (v0).rounded(.toNearestOrEven)
            let v12: Bool = (v11 != (3.0 as Double))
            if (v12) {
                return 3
            } else {
                let v13: Double = (v1).rounded(.toNearestOrEven)
                let v14: Bool = (v13 != (3.0 as Double))
                if (v14) {
                    return 4
                } else {
                    let v15: Double = (v2).rounded(.toNearestOrEven)
                    let v16: Bool = (v15 != (-2.0 as Double))
                    if (v16) {
                        return 5
                    } else {
                        let v17: Double = (v3).rounded(.toNearestOrEven)
                        let v18: Bool = (v17 != (4.0 as Double))
                        if (v18) {
                            return 6
                        } else {
                            let v19: Double = (v4).rounded(.toNearestOrEven)
                            let v20: Bool = (v19 != (0.0 as Double))
                            if (v20) {
                                return 7
                            } else {
                                let v21: Double = atan2(v5, v5)
                                let v22: Double = (v21 * (1000.0 as Double))
                                let v23: Double = (v22).rounded(.down)
                                let v24: Bool = (v23 != (785.0 as Double))
                                if (v24) {
                                    return 8
                                } else {
                                    let v25: Float = (v6).rounded(.down)
                                    let v26: Bool = (v25 != (2.0 as Float))
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
