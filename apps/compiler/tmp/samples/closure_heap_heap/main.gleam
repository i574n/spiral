pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub fn f_c0(capt: #(Heap1)) -> fn(Int) -> Heap1 {
    fn (v1) {
        let #(v0) = capt
        v0
    }
}
pub fn main() {
let v0 = 7
let v1 = "hi"
let v2 = Heap0(l0: v0, l1: v1)
let v3 = 1
let v4 = Heap1(l0: v2, l1: v3)
let v5 = f_c0(#(v4))
let v6 = v5( 1  )
let #(v7, v8) = #(v6.l0, v6.l1)
let #(v9, v10) = #(v7.l0, v7.l1)
let v11 = v9 == 7
let v13 =
    case v11 {
        True -> {
            let v12 = v10 == "hi"
            v12
        }
        False -> {
            False
        }
    }
let v15 =
    case v13 {
        True -> {
            let v14 = v8 == 1
            v14
        }
        False -> {
            False
        }
    }
case v15 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
