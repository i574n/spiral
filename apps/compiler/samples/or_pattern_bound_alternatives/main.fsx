type [<Struct>] US0 =
    | US0_Circle of f0_0 : int32
    | US0_Square of f1_0 : int32
    | US0_Triangle of f2_0 : int32
    | US0_Dot
let rec method1 (v0 : int32) : int32 =
    let v1 : int32 = v0 * v0
    let v2 : int32 = 7 * v0
    let v3 : int32 = v1 + v2
    let v4 : int32 = v3 - 3
    v4
and area_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Circle(v1) -> (* Circle *)
        method1(v1)
    | US0_Dot -> (* Dot *)
        0
    | US0_Square(v3) -> (* Square *)
        method1(v3)
    | US0_Triangle(v5) -> (* Triangle *)
        method1(v5)
let v0 : int32 = 4
let v1 : US0 = US0_Square(v0)
area_0(v1)
