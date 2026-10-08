pub type Uh1 {
    Uh1i0(Uh0)
    Uh1i1
}
pub type Uh0 {
    Uh0i0(Uh1)
    Uh0i1
}
pub fn main() {
let v0 = True
let v5 =
    case v0 {
        True -> {
            let v1 = Uh0i1
            let v2 = Uh1i0(v1)
            Uh0i0(v2)
        }
        False -> {
            Uh0i1
        }
    }
case v5  {
    Uh0i0(v6) -> {
        0
    }
    Uh0i1 -> {
        0
    }
}
}
