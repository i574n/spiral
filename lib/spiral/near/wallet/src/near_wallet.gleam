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
        let v63 = attribute.style(v35)
        let v64 = []
        let v65 = "flex-direction"
        let v66 = "column"
        let v67 = [ #(v65, v66)      , ..v64 ]
        let v77 = [ #(v33, v34)      , ..v67 ]
        let v101 = attribute.style(v77)
        let v102 = Us0i0
        let v103 = event.on_click(v102)
        let v104 = "+"
        let v105 = element.text(v104)
        let v106 = []
        let v138 = [ v103, ..v106 ]
        let v166 = []
        let v198 = [ v105, ..v166 ]
        let v226 = button.button(v138, v198)
        let v227 = []
        let v228 = "text-align"
        let v229 = "center"
        let v230 = [ #(v228, v229)      , ..v227 ]
        let v257 = attribute.style(v230)
        let v258 = string.inspect(v0)
        let v300 = element.text(v258)
        let v301 = []
        let v302 = [ v257, ..v301 ]
        let v303 = []
        let v304 = [ v300, ..v303 ]
        let v305 = html.p(v302, v304)
        let v306 = Us0i1
        let v307 = event.on_click(v306)
        let v308 = "-"
        let v309 = element.text(v308)
        let v310 = []
        let v311 = [ v307, ..v310 ]
        let v312 = []
        let v313 = [ v309, ..v312 ]
        let v314 = button.button(v311, v313)
        let v315 = []
        let v316 = [ v101, ..v315 ]
        let v317 = []
        let v318 = [ v314, ..v317 ]
        let v319 = [ v305, ..v318 ]
        let v320 = [ v226, ..v319 ]
        let v349 = html.div(v316, v320)
        let v350 = []
        let v351 = [ v63, ..v350 ]
        let v352 = []
        let v353 = [ v349, ..v352 ]
        let v354 = html.div(v351, v353)
        v354
    }
}
pub fn closure0 (capt : Nil) -> fn(Int) -> Nil        {
    fn (v0) {
        let v1 = closure1(Nil) // args: "" / d: Some (DV (L (1, YFun (YPrim Int32T, YPrim Int32T, FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

        let v2 = closure2(Nil) // args: "" / d: Some  (DV     (L (2,         YFun           (YPair (YPrim Int32T, YNominal <tag 247>), YPrim Int32T, FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

        let v3 = closure3(Nil) // args: "" / d: Some  (DV     (L (3,         YFun           (YPrim Int32T, YApply (YNominal <tag 244>, YNominal <tag 247>),            FT_Vanilla)))) / b': <tag 0> / b: <tag 0>

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