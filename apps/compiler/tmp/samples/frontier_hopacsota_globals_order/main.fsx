// m1
// a1
// c1
// a2
// b1
// m2
let rec leaf_c_1 () : int32 =
    0
and slow_a_0 () : int32 =
    let v0 : int32 = leaf_c_1()
    v0
and fast_b_2 () : int32 =
    0
let v0 : int32 = slow_a_0()
let v1 : int32 = fast_b_2()
let v2 : int32 = v0 + v1
v2
