import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Us0 {
    Us0North
    Us0East
    Us0South
    Us0West
}
pub fn main() {
let v0 = Us0North
let v8 =
    case v0  {
        Us0East -> {
            Us0South
        }
        Us0North -> {
            Us0East
        }
        Us0South -> {
            Us0West
        }
        Us0West -> {
            Us0North
        }
    }
let v16 =
    case v8  {
        Us0East -> {
            Us0South
        }
        Us0North -> {
            Us0East
        }
        Us0South -> {
            Us0West
        }
        Us0West -> {
            Us0North
        }
    }
let v17 = Us0South
let v18 =
    case v16,v17  {
        Us0East,Us0East -> {
            True
        }
        Us0North,Us0North -> {
            True
        }
        Us0South,Us0South -> {
            True
        }
        Us0West,Us0West -> {
            True
        }
        _,_ -> {
            False
        }
    }
let v19 =
    case v18 {
        True -> {
            100
        }
        False -> {
            0
        }
    }
let v21 =
    case v0  {
        Us0East -> {
            2
        }
        Us0North -> {
            1
        }
        _ -> {
            7
        }
    }
let v23 =
    case v8  {
        Us0East -> {
            2
        }
        Us0North -> {
            1
        }
        _ -> {
            7
        }
    }
let v24 = spiral_wrap_signed(v23 * 3, 32)
let v25 = spiral_wrap_signed(v21 + v24, 32)
let v27 =
    case v16  {
        Us0East -> {
            2
        }
        Us0North -> {
            1
        }
        _ -> {
            7
        }
    }
let v28 = spiral_wrap_signed(v27 * 9, 32)
let v29 = spiral_wrap_signed(v25 + v28, 32)
let v30 = spiral_wrap_signed(v29 + v19, 32)
v30
}
