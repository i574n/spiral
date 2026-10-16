pub type Heap0 { Heap0(l0 : Int) }
pub fn f_c0(capt: #(Heap0)) -> fn(Int) -> Heap0 {
    fn (v1) {
        let #(v0) = capt
        v0
    }
}
pub fn main() {
let v0 = 7
let v1 = Heap0(l0: v0)
let v2 = f_c0(#(v1))
let v3 = v2( 1  )
let v4 = v3.l0
let v5 = v4 == 7
case v5 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
