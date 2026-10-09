import gleam/int
import gleam/io
import gleam/string
import gleam/option
pub type Us0 {
    Us0i0(f0i0 : Int)
    Us0i1
}
pub fn main() {
let v0 = "ff"
let #(v1, v2) = case int.base_parse(v0, 16) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v3 = v2 == 0
let v6 =
    case v3 {
        True -> {
            Us0i0(v1)
        }
        False -> {
            Us0i1
        }
    }
let v10 =
    case v6  {
        Us0i1 -> {
            panic as "Option does not have a value."
        }
        Us0i0(v7) -> {
            v7
        }
    }
io.println(int.to_string(v10))
let v67 = "1011"
let #(v68, v69) = case int.base_parse(v67, 2) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v70 = v69 == 0
let v73 =
    case v70 {
        True -> {
            Us0i0(v68)
        }
        False -> {
            Us0i1
        }
    }
let v77 =
    case v73  {
        Us0i1 -> {
            panic as "Option does not have a value."
        }
        Us0i0(v74) -> {
            v74
        }
    }
io.println(int.to_string(v77))
let v91 = "-42"
let #(v92, v93) = case int.base_parse(v91, 10) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v94 = v93 == 0
let v97 =
    case v94 {
        True -> {
            Us0i0(v92)
        }
        False -> {
            Us0i1
        }
    }
let v101 =
    case v97  {
        Us0i1 -> {
            panic as "Option does not have a value."
        }
        Us0i0(v98) -> {
            v98
        }
    }
io.println(int.to_string(v101))
let v138 = " 123 "
let #(v139, v140) = case int.parse(string.trim(v138)) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v141 = v140 == 0
let v161 =
    case v141 {
        True -> {
            Us0i0(v139)
        }
        False -> {
            Us0i1
        }
    }
case v161  {
    Us0i1 -> {
        let v701 = "none"
        io.println(v701)
        Nil
    }
    Us0i0(v700) -> {
        io.println(int.to_string(v700))
        Nil
    }
}
let v705 = "12x"
let #(v706, v707) = case int.parse(string.trim(v705)) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v708 = v707 == 0
let v711 =
    case v708 {
        True -> {
            Us0i0(v706)
        }
        False -> {
            Us0i1
        }
    }
case v711  {
    Us0i1 -> {
        let v713 = "none"
        io.println(v713)
        Nil
    }
    Us0i0(v712) -> {
        io.println(int.to_string(v712))
        Nil
    }
}
let v714 = ""
let #(v715, v716) = case int.parse(string.trim(v714)) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v717 = v716 == 0
let v720 =
    case v717 {
        True -> {
            Us0i0(v715)
        }
        False -> {
            Us0i1
        }
    }
case v720  {
    Us0i1 -> {
        let v722 = "none"
        io.println(v722)
        Nil
    }
    Us0i0(v721) -> {
        io.println(int.to_string(v721))
        Nil
    }
}
let v723 = "+7"
let #(v724, v725) = case int.parse(string.trim(v723)) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v726 = v725 == 0
let v729 =
    case v726 {
        True -> {
            Us0i0(v724)
        }
        False -> {
            Us0i1
        }
    }
case v729  {
    Us0i1 -> {
        let v731 = "none"
        io.println(v731)
        Nil
    }
    Us0i0(v730) -> {
        io.println(int.to_string(v730))
        Nil
    }
}
0
}
