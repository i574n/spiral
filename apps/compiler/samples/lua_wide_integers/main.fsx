let rec lcg_0 (v0 : uint64, v1 : uint64, v2 : int32, v3 : uint64) : uint64 =
    let v4 : bool = v2 = 0
    if v4 then
        v3
    else
        let v5 : int32 = v2 - 1
        let v6 : uint64 = v3 * v0
        let v7 : uint64 = v6 + v1
        lcg_0(v0, v1, v5, v7)
let v0 : uint64 = 42UL
let v1 : uint64 = 6364136223846793005UL
let v2 : uint64 = 1442695040888963407UL
let v3 : int32 = 1000
let v4 : uint64 = lcg_0(v1, v2, v3, v0)
System.Console.Write("lcg " + string (v4) + "\n")
let v5 : int64 = 9223372036854775807L
let v6 : int64 = -9223372036854775807L
let v7 : uint64 = 18446744073709551615UL
let v8 : int64 = v6 - 1L
let v9 : uint64 = v7 + 2UL
System.Console.Write("max " + string (v5) + " min " + string (v8) + " wrap " + string (v9) + "\n")
let v10 : int64 = -9007199254740993L
let v11 : int64 = 7L
let v12 : int64 = v10 / v11
let v13 : int64 = v10 % v11
System.Console.Write("div " + string (v12) + " mod " + string (v13) + "\n")
let v14 : int64 = v10 >>> 3
let v15 : uint64 = v4 >>> 60
System.Console.Write("shl " + string (4611686018427387904L) + " shr " + string (v14) + " ushr " + string (v15) + "\n")
let v16 : uint64 = v4 &&& 18446744069414584320UL
let v17 : int64 = v10 ||| 255L
let v18 : uint64 = v4 ^^^ v1
System.Console.Write("and " + string (v16) + " or " + string (v17) + " xor " + string (v18) + "\n")
let v19 : float = 1E+18
let v20 : int64 = int64 v19
let v21 : uint32 = uint32 v4
let v22 : float = float v10
let v23 : bool = v22 < 0.0
let v24 : int32 =
    if v23 then
        1
    else
        0
System.Console.Write("conv " + string (v20) + " " + string (v21) + " " + string (v24) + "\n")
let v25 : bool = v4 > v1
if v25 then
    1
else
    0
