pub type Heap0 { Heap0(l0 : Float, l1 : String) }
pub fn f_c0(capt: #(Heap0)) -> fn(Int) -> Heap0 {
    fn (v1) {
        let #(v0) = capt
        v0
    }
}
pub fn main() {
let v0 = 1.5
let v1 = "hi"
let v2 = Heap0(l0: v0, l1: v1)
let v3 = f_c0(#(v2))
let v4 = v3( 1  )
let #(v5, v6) = #(v4.l0, v4.l1)
let v7 = v5 == 1.5
let v9 =
    case v7 {
        True -> {
            let v8 = v6 == "hi"
            v8
        }
        False -> {
            False
        }
    }
case v9 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
