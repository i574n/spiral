pub fn f_c0(capt: #(Bool)) -> fn(Int) -> #(Bool, Bool) {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> {
                #(False, False)
            }
            False -> {
                #(v0, True)
            }
        }
    }
}
pub fn main() {
    let v0 = True
    let v1 = f_c0(#(v0))
    let #(v2, v3) = v1(1)
    let v4 = v2 && v3
    case v4 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
