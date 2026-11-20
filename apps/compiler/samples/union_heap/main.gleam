pub type Heap0 { Heap0(l0 : Int) }
pub type Us0 {
    Us0Missing
    Us0Box(f1i0 : Heap0)
}
pub fn main() {
    let v1 = Heap0(l0: 7)
    let v5 =
        case True {
            True -> Us0Box(v1)
            False -> Us0Missing
        }
    case v5  {
        Us0Box(v6) -> {
            let v7 = v6.l0
            let v8 = v7 == 7
            case v8 {
                True -> 0
                False -> 1
            }
        }
        Us0Missing -> 1
    }
}
