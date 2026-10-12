import lustre
import lustre/attribute
import lustre/internals/vdom
import lustre/event
import lustre/element/html
import lustre/element
import lustre/ui/button
import gleam/string
import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Us0 {
    Us0Incr
    Us0Decr
}
pub fn closure1(capt: Nil) -> fn(Int) -> Int {
    fn (v0) {
        let v1 = v0 < 0
        case v1 {
            True -> {
                0
            }
            False -> {
                v0
            }
        }
    }
}
pub fn closure2(capt: Nil) -> fn(#(Int, Us0)) -> Int {
    fn (dom) {
        let #(v0, v1) = dom
        case v1  {
            Us0Decr -> {
                let v3 = spiral_wrap_signed(v0 - 1, 32)
                v3
            }
            Us0Incr -> {
                let v2 = spiral_wrap_signed(v0 + 1, 32)
                v2
            }
        }
    }
}
pub fn closure3(capt: Nil) -> fn(Int) -> element.Element(Us0) {
    fn (v0) {
        let v1 = []
        let v2 = "display"
        let v3 = "flex"
        let v4 = [ #(v2, v3), ..v1 ]
        let v5 = attribute.style(v4)
        let v6 = []
        let v7 = "flex-direction"
        let v8 = "column"
        let v9 = [ #(v7, v8), ..v6 ]
        let v10 = [ #(v2, v3), ..v9 ]
        let v11 = attribute.style(v10)
        let v12 = Us0Incr
        let v13 = event.on_click(v12)
        let v14 = "+"
        let v15 = element.text(v14)
        let v16 = []
        let v17 = [ v13, ..v16 ]
        let v18 = []
        let v19 = [ v15, ..v18 ]
        let v20 = button.button(v17, v19)
        let v21 = []
        let v22 = "text-align"
        let v23 = "center"
        let v24 = [ #(v22, v23), ..v21 ]
        let v25 = attribute.style(v24)
        let v26 = string.inspect(v0)
        let v27 = element.text(v26)
        let v28 = []
        let v29 = [ v25, ..v28 ]
        let v30 = []
        let v31 = [ v27, ..v30 ]
        let v32 = html.p(v29, v31)
        let v33 = Us0Decr
        let v34 = event.on_click(v33)
        let v35 = "-"
        let v36 = element.text(v35)
        let v37 = []
        let v38 = [ v34, ..v37 ]
        let v39 = []
        let v40 = [ v36, ..v39 ]
        let v41 = button.button(v38, v40)
        let v42 = []
        let v43 = [ v11, ..v42 ]
        let v44 = []
        let v45 = [ v41, ..v44 ]
        let v46 = [ v32, ..v45 ]
        let v47 = [ v20, ..v46 ]
        let v48 = html.div(v43, v47)
        let v49 = []
        let v50 = [ v5, ..v49 ]
        let v51 = []
        let v52 = [ v48, ..v51 ]
        let v53 = html.div(v50, v52)
        v53
    }
}
pub fn closure0(capt: Nil) -> fn(Int) -> Nil {
    fn (v0) {
        let v1 = closure1(Nil)
        let v2 = closure2(Nil)
        let v3 = closure3(Nil)
        let v4 = lustre.simple(v1, fn (a, b) { v2(#(a, b)) }, v3)
        let v5 = "#app_"
        let assert Ok(_) = lustre.start(v4, v5, 0)
        Nil
    }
}
pub fn main() {
let v0 = closure0(Nil)
v0 (0)
Nil
}
