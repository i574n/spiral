import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = 43
    let v1: Int32 = 15
    let v2: Int32 = 2
    let v3: Int32 = 5
    let v4: Int32 = (v0 & v1)
    let v5: Int32 = (v0 | v1)
    let v6: Int32 = (v0 ^ v1)
    let v7: Int32 = (~(v0))
    let v8: Int32 = (v7 & 255)
    let v9: Int32 = (1 << v3)
    let v10: Int32 = (168 >> v2)
    let v11: Int32 = (v4 &- 11)
    let v12: Int32 = (v10 &+ v11)
    let v13: Int32 = (v5 &- 47)
    let v14: Int32 = (v12 &+ v13)
    let v15: Int32 = (v6 &- 36)
    let v16: Int32 = (v14 &+ v15)
    let v17: Int32 = (v8 &- 212)
    let v18: Int32 = (v16 &+ v17)
    let v19: Int32 = (v9 &- 32)
    let v20: Int32 = (v18 &+ v19)
    return v20
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
