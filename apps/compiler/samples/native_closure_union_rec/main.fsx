type UH0 =
    | UH0_Cons of uint64 * (unit -> UH0)
    | UH0_Nil
let rec closure0 (v0 : uint64) () : UH0 =
    let v1 : uint64 = v0 - 1UL
    build_0(v1)
and build_0 (v0 : uint64) : UH0 =
    let v1 : bool = v0 = 0UL
    if v1 then
        UH0_Nil
    else
        let v3 : (unit -> UH0) = closure0(v0)
        UH0_Cons(v0, v3)
and sum_1 (v0 : UH0, v1 : uint64) : uint64 =
    match v0 with
    | UH0_Cons(v2, v3) -> (* Cons *)
        let v4 : UH0 = v3 ()
        let v5 : uint64 = v1 + v2
        sum_1(v4, v5)
    | UH0_Nil -> (* Nil *)
        v1
let v0 : uint64 = 10UL
let v1 : UH0 = build_0(v0)
let v2 : uint64 = 0UL
let v3 : uint64 = sum_1(v1, v2)
let v4 : int32 = 5
let v5 : int32 = int32 v3
let v6 : int32 = v4 * 2
let v7 : int32 = v4 + v6
let v8 : int32 = v5 + v7
v8
