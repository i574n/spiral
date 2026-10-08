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
        let v47 = "display"
        let v48 = "flex"
        let v49 = [ #(v47, v48)      , ..v1 ]
        let v81 = attribute.style(v49)
        let v82 = []
        let v83 = "flex-direction"
        let v84 = "column"
        let v85 = [ #(v83, v84)      , ..v82 ]
        let v97 = [ #(v47, v48)      , ..v85 ]
        let v123 = attribute.style(v97)
        let v124 = Us0i0
        let v125 = event.on_click(v124)
        let v126 = "+"
        let v127 = element.text(v126)
        let v128 = []
        let v174 = [ v125, ..v128 ]
        let v206 = []
        let v252 = [ v127, ..v206 ]
        let v284 = button.button(v174, v252)
        let v285 = []
        let v286 = "text-align"
        let v287 = "center"
        let v288 = [ #(v286, v287)      , ..v285 ]
        let v319 = attribute.style(v288)
        let v320 = string.inspect(v0)
        let v358 = element.text(v320)
        let v359 = []
        let v360 = [ v319, ..v359 ]
        let v361 = []
        let v362 = [ v358, ..v361 ]
        let v363 = html.p(v360, v362)
        let v364 = Us0i1
        let v365 = event.on_click(v364)
        let v366 = "-"
        let v367 = element.text(v366)
        let v368 = []
        let v369 = [ v365, ..v368 ]
        let v370 = []
        let v371 = [ v367, ..v370 ]
        let v372 = button.button(v369, v371)
        let v373 = []
        let v374 = [ v123, ..v373 ]
        let v375 = []
        let v376 = [ v372, ..v375 ]
        let v377 = [ v363, ..v376 ]
        let v378 = [ v284, ..v377 ]
        let v409 = html.div(v374, v378)
        let v410 = []
        let v411 = [ v81, ..v410 ]
        let v412 = []
        let v413 = [ v409, ..v412 ]
        let v414 = html.div(v411, v413)
        v414
    }
}
pub fn closure0 (capt : Nil) -> fn(Int) -> Nil        {
    fn (v0) {
        let v1 = closure1(Nil) // args: "" / d: Some (DV (L (1, YFun (YPrim Int32T, YPrim Int32T, FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

        let v2 = closure2(Nil) // args: "" / d: Some  (DV     (L (2,         YFun           (YPair (YPrim Int32T, YNominal <tag 248>), YPrim Int32T, FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

        let v3 = closure3(Nil) // args: "" / d: Some  (DV     (L (3,         YFun           (YPrim Int32T, YApply (YNominal <tag 245>, YNominal <tag 248>),            FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

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