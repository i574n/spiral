import gleam/int
import gleam/io
import gleam/string
import gleam/option
pub type Us0 {
    Us0Some(f0i0 : Int)
    Us0None
}
pub fn main() {
    let #(v1, v2) = case int.base_parse("ff", 16) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
    let v3 = v2 == 0
    let v6 =
        case v3 {
            True -> Us0Some(v1)
            False -> Us0None
        }
    let v10 =
        case v6  {
            Us0None -> panic as "Option does not have a value."
            Us0Some(v7) -> v7
        }
    io.println(int.to_string(v10))
    let #(v12, v13) = case int.base_parse("1011", 2) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
    let v14 = v13 == 0
    let v17 =
        case v14 {
            True -> Us0Some(v12)
            False -> Us0None
        }
    let v21 =
        case v17  {
            Us0None -> panic as "Option does not have a value."
            Us0Some(v18) -> v18
        }
    io.println(int.to_string(v21))
    let #(v23, v24) = case int.base_parse("-42", 10) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
    let v25 = v24 == 0
    let v28 =
        case v25 {
            True -> Us0Some(v23)
            False -> Us0None
        }
    let v32 =
        case v28  {
            Us0None -> panic as "Option does not have a value."
            Us0Some(v29) -> v29
        }
    io.println(int.to_string(v32))
    let #(v34, v35) = case int.parse(string.trim(" 123 ")) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
    let v36 = v35 == 0
    let v39 =
        case v36 {
            True -> Us0Some(v34)
            False -> Us0None
        }
    case v39  {
        Us0None -> {
            io.println("none")
            Nil
        }
        Us0Some(v40) -> {
            io.println(int.to_string(v40))
            Nil
        }
    }
    let #(v43, v44) = case int.parse(string.trim("12x")) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
    let v45 = v44 == 0
    let v48 =
        case v45 {
            True -> Us0Some(v43)
            False -> Us0None
        }
    case v48  {
        Us0None -> {
            io.println("none")
            Nil
        }
        Us0Some(v49) -> {
            io.println(int.to_string(v49))
            Nil
        }
    }
    let #(v52, v53) = case int.parse(string.trim("")) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
    let v54 = v53 == 0
    let v57 =
        case v54 {
            True -> Us0Some(v52)
            False -> Us0None
        }
    case v57  {
        Us0None -> {
            io.println("none")
            Nil
        }
        Us0Some(v58) -> {
            io.println(int.to_string(v58))
            Nil
        }
    }
    let #(v61, v62) = case int.parse(string.trim("+7")) { Ok(n) -> #(n, 0) Error(Nil) -> #(0, 1) }
    let v63 = v62 == 0
    let v66 =
        case v63 {
            True -> Us0Some(v61)
            False -> Us0None
        }
    case v66  {
        Us0None -> {
            io.println("none")
            Nil
        }
        Us0Some(v67) -> {
            io.println(int.to_string(v67))
            Nil
        }
    }
    0
}
