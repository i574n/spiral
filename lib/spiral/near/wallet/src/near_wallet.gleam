import lustre
import lustre/attribute
import lustre/internals/vdom
import lustre/event
import lustre/element/html
import lustre/element
import lustre/ui/button
import gleam/string
pub type Us0 {
    Us0i0
    Us0i1
}
pub fn closure1 (capt : Nil) -> fn(Int) -> Int {
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
pub fn closure2 (capt : Nil) -> fn(#(Int, Us0)) -> Int {
    fn (dom) {
        let #(v0, v1) = dom
        case v1    {
            Us0i1 ->  { // Decr
                let v3 = v0 - 1
                v3
            }  
            Us0i0 ->  { // Incr
                let v2 = v0 + 1
                v2
            }  
        }
    }
}
pub fn closure3 (capt : Nil) -> fn(Int) -> element.Element(Us0) {
    fn (v0) {
        let v1 = []
        let v2 = "display"
        let v3 = "flex"
        let v4 = [ #(v2, v3)      , ..v1 ]
        let v18 = attribute.style(v4)
        let v19 = []
        let v20 = "flex-direction"
        let v21 = "column"
        let v22 = [ #(v20, v21)      , ..v19 ]
        let v36 = [ #(v2, v3)      , ..v22 ]
        let v50 = attribute.style(v36)
        let v51 = Us0i0
        let v52 = event.on_click(v51)
        let v53 = "+"
        let v54 = element.text(v53)
        let v55 = []
        let v56 = [ v52, ..v55 ]
        let v70 = []
        let v71 = [ v54, ..v70 ]
        let v85 = button.button(v56, v71)
        let v86 = []
        let v87 = "text-align"
        let v88 = "center"
        let v89 = [ #(v87, v88)      , ..v86 ]
        let v103 = attribute.style(v89)
        let v104 = string.inspect(v0)
        let v144 = element.text(v104)
        let v145 = []
        let v146 = [ v103, ..v145 ]
        let v160 = []
        let v161 = [ v144, ..v160 ]
        let v175 = html.p(v146, v161)
        let v176 = Us0i1
        let v177 = event.on_click(v176)
        let v178 = "-"
        let v179 = element.text(v178)
        let v180 = []
        let v181 = [ v177, ..v180 ]
        let v195 = []
        let v196 = [ v179, ..v195 ]
        let v210 = button.button(v181, v196)
        let v211 = []
        let v212 = [ v50, ..v211 ]
        let v226 = []
        let v227 = [ v210, ..v226 ]
        let v241 = [ v175, ..v227 ]
        let v255 = [ v85, ..v241 ]
        let v269 = html.div(v212, v255)
        let v270 = []
        let v271 = [ v18, ..v270 ]
        let v285 = []
        let v286 = [ v269, ..v285 ]
        let v300 = html.div(v271, v286)
        v300
    }
}
pub fn closure0 (capt : Nil) -> fn(Int) -> Nil        {
    fn (v0) {
        let v1 = closure1(Nil) // args: "" / d: Some (DV (L (1, YFun (YPrim Int32T, YPrim Int32T, FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

        let v2 = closure2(Nil) // args: "" / d: Some  (DV     (L (2,         YFun           (YPair (YPrim Int32T, YNominal <tag 252>), YPrim Int32T, FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

        let v3 = closure3(Nil) // args: "" / d: Some  (DV     (L (3,         YFun           (YPrim Int32T, YApply (YNominal <tag 249>, YNominal <tag 252>),            FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

        let v4 = lustre.simple(v1, fn (a, b) { v2(#(a, b)) }, v3)
        let v5 = "#app_"
        let assert Ok(_) = lustre.start(v4, v5, 0)
        Nil      
    }
}
pub fn main () { let v0 = closure0(Nil) // args: "" / d: Some (DV (L (0, YFun (YPrim Int32T, YB, FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

v0 (0)
Nil      
 }