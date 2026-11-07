import lustre
import lustre/attribute
import lustre/event
import lustre/element/html
import lustre/element
import gleam/string
import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
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
        let v5 = attribute.styles(v4)
        let v6 = []
        let v7 = "flex-direction"
        let v8 = "column"
        let v9 = [ #(v7, v8), ..v6 ]
        let v10 = [ #(v2, v3), ..v9 ]
        let v11 = attribute.styles(v10)
        let v12 = Us0Incr
        let v13 = event.on_click(v12)
        let v14 = "+"
        let v15 = element.text(v14)
        let v16 = "lustre-ui-button"
        let v17 = attribute.class(v16)
        let v18 = "button"
        let v19 = attribute.role(v18)
        let v20 = "tabindex"
        let v21 = "0"
        let v22 = attribute.attribute(v20, v21)
        let v23 = []
        let v24 = [ v13, ..v23 ]
        let v25 = [ v22, ..v24 ]
        let v26 = [ v19, ..v25 ]
        let v27 = [ v17, ..v26 ]
        let v28 = []
        let v29 = [ v15, ..v28 ]
        let v30 = html.button(v27, v29)
        let v31 = []
        let v32 = "text-align"
        let v33 = "center"
        let v34 = [ #(v32, v33), ..v31 ]
        let v35 = attribute.styles(v34)
        let v36 = string.inspect(v0)
        let v37 = element.text(v36)
        let v38 = []
        let v39 = [ v35, ..v38 ]
        let v40 = []
        let v41 = [ v37, ..v40 ]
        let v42 = html.p(v39, v41)
        let v43 = Us0Decr
        let v44 = event.on_click(v43)
        let v45 = "-"
        let v46 = element.text(v45)
        let v47 = attribute.class(v16)
        let v48 = attribute.role(v18)
        let v49 = attribute.attribute(v20, v21)
        let v50 = []
        let v51 = [ v44, ..v50 ]
        let v52 = [ v49, ..v51 ]
        let v53 = [ v48, ..v52 ]
        let v54 = [ v47, ..v53 ]
        let v55 = []
        let v56 = [ v46, ..v55 ]
        let v57 = html.button(v54, v56)
        let v58 = []
        let v59 = [ v11, ..v58 ]
        let v60 = []
        let v61 = [ v57, ..v60 ]
        let v62 = [ v42, ..v61 ]
        let v63 = [ v30, ..v62 ]
        let v64 = html.div(v59, v63)
        let v65 = []
        let v66 = [ v5, ..v65 ]
        let v67 = []
        let v68 = [ v64, ..v67 ]
        let v69 = html.div(v66, v68)
        v69
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
