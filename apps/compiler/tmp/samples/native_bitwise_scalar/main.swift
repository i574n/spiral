import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 43
    var v1: Int32 = 0
    v1 = 15
    var v2: Int32 = 0
    v2 = 2
    var v3: Int32 = 0
    v3 = 5
    var v4: Int32 = 0
    v4 = (v0 & v1)
    var v5: Int32 = 0
    v5 = (v0 | v1)
    var v6: Int32 = 0
    v6 = (v0 ^ v1)
    var v7: Int32 = 0
    v7 = (~(v0))
    var v8: Int32 = 0
    v8 = (v7 & 255)
    var v9: Int32 = 0
    v9 = (1 << v3)
    var v10: Int32 = 0
    v10 = (168 >> v2)
    var v11: Int32 = 0
    v11 = (v4 &- 11)
    var v12: Int32 = 0
    v12 = (v10 &+ v11)
    var v13: Int32 = 0
    v13 = (v5 &- 47)
    var v14: Int32 = 0
    v14 = (v12 &+ v13)
    var v15: Int32 = 0
    v15 = (v6 &- 36)
    var v16: Int32 = 0
    v16 = (v14 &+ v15)
    var v17: Int32 = 0
    v17 = (v8 &- 212)
    var v18: Int32 = 0
    v18 = (v16 &+ v17)
    var v19: Int32 = 0
    v19 = (v9 &- 32)
    var v20: Int32 = 0
    v20 = (v18 &+ v19)
    return v20
}
exit(spiral_main())
