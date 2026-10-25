pub type Heap0 { Heap0(l0 : Int) }
pub fn g_c1(capt: #(Heap0, Int)) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v0.l0
        let v4 = v1 == 0
        case v4 {
            True -> {
                0
            }
            False -> {
                v3
            }
        }
    }
}
pub fn f_c0(capt: #(Heap0)) -> fn(Int) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        g_c1(#(v0, v1))
    }
}
pub fn main() {
let v0 = 7
let v1 = Heap0(l0: v0)
let v2 = f_c0(#(v1))
let v3 = v2( 1  )
let v4 = v3( 0  )
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
