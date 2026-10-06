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
        let v33 = "display"
        let v34 = "flex"
        let v35 = [ #(v33, v34)      , ..v1 ]
        let v73 = attribute.style(v35)
        let v74 = []
        let v75 = "flex-direction"
        let v76 = "column"
        let v77 = [ #(v75, v76)      , ..v74 ]
        let v87 = [ #(v33, v34)      , ..v77 ]
        let v125 = attribute.style(v87)
        let v126 = Us0i0
        let v127 = event.on_click(v126)
        let v128 = "+"
        let v129 = element.text(v128)
        let v130 = []
        let v162 = [ v127, ..v130 ]
        let v200 = []
        let v232 = [ v129, ..v200 ]
        let v270 = button.button(v162, v232)
        let v271 = []
        let v272 = "text-align"
        let v273 = "center"
        let v274 = [ #(v272, v273)      , ..v271 ]
        let v311 = attribute.style(v274)
        let v312 = string.inspect(v0)
        let v354 = element.text(v312)
        let v355 = []
        let v356 = [ v311, ..v355 ]
        let v357 = []
        let v358 = [ v354, ..v357 ]
        let v359 = html.p(v356, v358)
        let v360 = Us0i1
        let v361 = event.on_click(v360)
        let v362 = "-"
        let v363 = element.text(v362)
        let v364 = []
        let v365 = [ v361, ..v364 ]
        let v366 = []
        let v367 = [ v363, ..v366 ]
        let v368 = button.button(v365, v367)
        let v369 = []
        let v370 = [ v125, ..v369 ]
        let v371 = []
        let v372 = [ v368, ..v371 ]
        let v373 = [ v359, ..v372 ]
        let v374 = [ v270, ..v373 ]
        let v421 = html.div(v370, v374)
        let v422 = []
        let v423 = [ v73, ..v422 ]
        let v424 = []
        let v425 = [ v421, ..v424 ]
        let v426 = html.div(v423, v425)
        v426
    }
}
pub fn closure0 (capt : Nil) -> fn(Int) -> Nil        {
    fn (v0) {
        let v1 = closure1(Nil) // args: "" / d: Some (DV (L (1, YFun (YPrim Int32T, YPrim Int32T, FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

        let v2 = closure2(Nil) // args: "" / d: Some  (DV     (L (2,         YFun           (YPair (YPrim Int32T, YNominal <tag 258>), YPrim Int32T, FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

        let v3 = closure3(Nil) // args: "" / d: Some  (DV     (L (3,         YFun           (YPrim Int32T, YApply (YNominal <tag 255>, YNominal <tag 258>),            FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

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