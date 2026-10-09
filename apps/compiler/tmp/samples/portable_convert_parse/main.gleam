import gleam/int
import gleam/io
import gleam/string
import gleam/option
pub type Us0 {
    Us0Some(f0i0 : Int)
    Us0None
}
pub fn main() {
let v0 = "ff"
let #(v1, v2) = case int.base_parse(v0, 16) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v3 = v2 == 0
let v6 =
    case v3 {
        True -> {
            Us0Some(v1)
        }
        False -> {
            Us0None
        }
    }
let v10 =
    case v6  {
        Us0None -> {
            panic as "Option does not have a value."
        }
        Us0Some(v7) -> {
            v7
        }
    }
io.println(int.to_string(v10))
let v69 = "1011"
let #(v70, v71) = case int.base_parse(v69, 2) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v72 = v71 == 0
let v75 =
    case v72 {
        True -> {
            Us0Some(v70)
        }
        False -> {
            Us0None
        }
    }
let v79 =
    case v75  {
        Us0None -> {
            panic as "Option does not have a value."
        }
        Us0Some(v76) -> {
            v76
        }
    }
io.println(int.to_string(v79))
let v94 = "-42"
let #(v95, v96) = case int.base_parse(v94, 10) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v97 = v96 == 0
let v100 =
    case v97 {
        True -> {
            Us0Some(v95)
        }
        False -> {
            Us0None
        }
    }
let v104 =
    case v100  {
        Us0None -> {
            panic as "Option does not have a value."
        }
        Us0Some(v101) -> {
            v101
        }
    }
io.println(int.to_string(v104))
let v143 = " 123 "
let #(v144, v145) = case int.parse(string.trim(v143)) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v146 = v145 == 0
let v179 =
    case v146 {
        True -> {
            Us0Some(v144)
        }
        False -> {
            Us0None
        }
    }
case v179  {
    Us0None -> {
        let v796 = "none"
        io.println(v796)
        Nil
    }
    Us0Some(v795) -> {
        io.println(int.to_string(v795))
        Nil
    }
}
let v800 = "12x"
let #(v801, v802) = case int.parse(string.trim(v800)) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v803 = v802 == 0
let v806 =
    case v803 {
        True -> {
            Us0Some(v801)
        }
        False -> {
            Us0None
        }
    }
case v806  {
    Us0None -> {
        let v808 = "none"
        io.println(v808)
        Nil
    }
    Us0Some(v807) -> {
        io.println(int.to_string(v807))
        Nil
    }
}
let v809 = ""
let #(v810, v811) = case int.parse(string.trim(v809)) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v812 = v811 == 0
let v815 =
    case v812 {
        True -> {
            Us0Some(v810)
        }
        False -> {
            Us0None
        }
    }
case v815  {
    Us0None -> {
        let v817 = "none"
        io.println(v817)
        Nil
    }
    Us0Some(v816) -> {
        io.println(int.to_string(v816))
        Nil
    }
}
let v818 = "+7"
let #(v819, v820) = case int.parse(string.trim(v818)) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
let v821 = v820 == 0
let v824 =
    case v821 {
        True -> {
            Us0Some(v819)
        }
        False -> {
            Us0None
        }
    }
case v824  {
    Us0None -> {
        let v826 = "none"
        io.println(v826)
        Nil
    }
    Us0Some(v825) -> {
        io.println(int.to_string(v825))
        Nil
    }
}
0
}
