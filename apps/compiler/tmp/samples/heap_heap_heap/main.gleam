pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub fn main() {
let v0 = 7
let v1 = "hi"
let v2 = Heap0(l0: v0, l1: v1)
let v3 = 1
let v4 = Heap1(l0: v2, l1: v3)
let v5 = 2
let v6 = Heap2(l0: v4, l1: v5)
let #(v7, v8) = #(v6.l0, v6.l1)
let #(v9, v10) = #(v7.l0, v7.l1)
let #(v11, v12) = #(v9.l0, v9.l1)
let v13 = v11 == 7
let v15 =
    case v13 {
        True -> {
            let v14 = v12 == "hi"
            v14
        }
        False -> {
            False
        }
    }
let v17 =
    case v15 {
        True -> {
            let v16 = v10 == 1
            v16
        }
        False -> {
            False
        }
    }
let v19 =
    case v17 {
        True -> {
            let v18 = v8 == 2
            v18
        }
        False -> {
            False
        }
    }
case v19 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
