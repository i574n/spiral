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
pub fn closure1 () -> fn(_) -> fn(       Nil) -> Int { fn(x : #(   Int)) { let #(   v0 ) = x
fn (_) { // free_vars_tys: "" / domain: "x : #(   Int)" / x.domain_args: "[|L (0, YPrim Int32T)|]" / free_vars': "[||]"
    let v1 = v0 < 0
    case v1 {
        True -> {
            0
        }
        False -> {
            v0
        }
    }
}}}
pub fn closure2 () -> fn(_) -> fn(      Nil) -> Int { fn(x : #(#( Int, Us0))) { let #(#(   v0, v1 )) = x
fn (_) { // free_vars_tys: "" / domain: "x : #(#( Int, Us0))" / x.domain_args: "[|L (0, YPrim Int32T);  L (1,     YUnion       Polyglot.spiral_compiler+H`1[<>f__AnonymousType1029616380`5[Microsoft.FSharp.Collections.FSharpMap`2[System.Tuple`2[System.Int32,System.String],Polyglot.spiral_compiler+Ty],System.Boolean,Polyglot.spiral_compiler+UnionLayout,System.Tuple`2[System.String,Polyglot.spiral_compiler+Ty][],System.Collections.Generic.Dictionary`2[System.String,System.Int32]]])|]" / free_vars': "[||]"
    case v1 {
        Us0i1 -> { // Decr
            let v3 = v0 - 1
            v3
        }
        Us0i0 -> { // Incr
            let v2 = v0 + 1
            v2
        }
    }
}}}
pub fn closure3 () -> fn(_) -> fn(       Nil) -> element.Element(Us0) { fn(x : #(   Int)) { let #(   v0 ) = x
fn (_) { // free_vars_tys: "" / domain: "x : #(   Int)" / x.domain_args: "[|L (0, YPrim Int32T)|]" / free_vars': "[||]"
    let v1 = []
    let v2 = "display"
    let v3 = "flex"
    let v4 = [ #(v2, v3) , ..v1 ]
    let v8 = attribute.style(v4)
    let v9 = []
    let v10 = "flex-direction"
    let v11 = "column"
    let v12 = [ #(v10, v11) , ..v9 ]
    let v16 = [ #(v2, v3) , ..v12 ]
    let v20 = attribute.style(v16)
    let v21 = Us0i0
    let v22 = event.on_click(v21)
    let v23 = "+"
    let v24 = element.text(v23)
    let v25 = []
    let v26 = [ v22, ..v25 ]
    let v30 = []
    let v31 = [ v24, ..v30 ]
    let v35 = button.button(v26, v31)
    let v36 = []
    let v37 = "text-align"
    let v38 = "center"
    let v39 = [ #(v37, v38) , ..v36 ]
    let v43 = attribute.style(v39)
    let v44 = string.inspect( v0)
    let v49 = element.text(v44)
    let v50 = []
    let v51 = [ v43, ..v50 ]
    let v55 = []
    let v56 = [ v49, ..v55 ]
    let v60 = html.p(v51, v56)
    let v61 = Us0i1
    let v62 = event.on_click(v61)
    let v63 = "-"
    let v64 = element.text(v63)
    let v65 = []
    let v66 = [ v62, ..v65 ]
    let v70 = []
    let v71 = [ v64, ..v70 ]
    let v75 = button.button(v66, v71)
    let v76 = []
    let v77 = [ v20, ..v76 ]
    let v81 = []
    let v82 = [ v75, ..v81 ]
    let v86 = [ v60, ..v82 ]
    let v90 = [ v35, ..v86 ]
    let v94 = html.div(v77, v90)
    let v95 = []
    let v96 = [ v8, ..v95 ]
    let v100 = []
    let v101 = [ v94, ..v100 ]
    let v105 = html.div(v96, v101)
    v105
}}}
pub fn closure0 () -> fn(_) -> fn(       Nil) -> Nil   { fn(x : #(   Int)) { let #(   v0 ) = x
fn (_) { // free_vars_tys: "" / domain: "x : #(   Int)" / x.domain_args: "[|L (0, YPrim Int32T)|]" / free_vars': "[||]"
    let v1 = fn (x) { closure1()(#(x))(   Nil) } // args: "" / d: Some (DV (L (1, YFun (YPrim Int32T, YPrim Int32T, FT_Vanilla)))) / b': [||] / b: <tag 0>

    let v2 = fn (x) { closure2()(#(x))(   Nil) } // args: "" / d: Some  (DV     (L (2,         YFun           (YPair (YPrim Int32T, YNominal <tag 253>), YPrim Int32T, FT_Vanilla)))) / b': [||] / b: <tag 0>

    let v3 = fn (x) { closure3()(#(x))(   Nil) } // args: "" / d: Some  (DV     (L (3,         YFun           (YPrim Int32T, YApply (YNominal <tag 250>, YNominal <tag 253>),            FT_Vanilla)))) / b': [||] / b: <tag 0>

    let v4 = lustre.simple(v1, fn (a, b) { v2(#(a, b)) }, v3)
    let v5 = "#app_"
    let assert Ok(_) = lustre.start(v4, v5, 0)
    Nil 
}}}
pub fn main () { let v0 = fn (x) { closure0()(#(x))(   Nil) } // args: "" / d: Some (DV (L (0, YFun (YPrim Int32T, YB, FT_Vanilla)))) / b': [||] / b: <tag 0>

v0 (0)
Nil 
 }