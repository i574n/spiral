pub type Us0 {
    Us0None
    Us0Some(f1i0 : Int)
}
pub type Heap0 { Heap0(l0 : Us0) }
pub fn main() {
    let v0 = 7
    let v1 = True
    let v4 =
        case v1 {
            True -> Us0Some(v0)
            False -> Us0None
        }
    let v5 = Heap0(l0: v4)
    let v6 = v5.l0
    case v6  {
        Us0None -> 1
        Us0Some(v7) -> {
            let v8 = v7 == 7
            case v8 {
                True -> 0
                False -> 1
            }
        }
    }
}
