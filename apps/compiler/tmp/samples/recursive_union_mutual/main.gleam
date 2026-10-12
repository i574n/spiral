pub type Uh1 {
    Uh1B(Uh0)
    Uh1StopB
}
pub type Uh0 {
    Uh0A(Uh1)
    Uh0StopA
}
pub fn main() {
let v0 = True
let v5 =
    case v0 {
        True -> {
            let v1 = Uh0StopA
            let v2 = Uh1B(v1)
            Uh0A(v2)
        }
        False -> {
            Uh0StopA
        }
    }
case v5  {
    Uh0A(v6) -> {
        0
    }
    Uh0StopA -> {
        0
    }
}
}
