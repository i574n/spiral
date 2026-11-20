type UH0 =
    | UH0_Cell of int32
let rec is_odd_1 (v0 : int32) : bool =
    let v1 : UH0 = UH0_Cell(v0)
    match v1 with
    | UH0_Cell(v2) -> (* Cell *)
        let v3 : bool = v2 = 0
        if v3 then
            false
        else
            let v4 : int32 = v2 - 1
            is_even_0(v4)
and is_even_0 (v0 : int32) : bool =
    let v1 : UH0 = UH0_Cell(v0)
    match v1 with
    | UH0_Cell(v2) -> (* Cell *)
        let v3 : bool = v2 = 0
        if v3 then
            true
        else
            let v4 : int32 = v2 - 1
            is_odd_1(v4)
let v0 : int32 = 1000
let v1 : bool = is_even_0(v0)
if v1 then
    0
else
    1
