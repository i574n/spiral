set_option linter.all false
class SpiralToInt (α : Type) where toI : α → Int
instance : SpiralToInt Int8 := ⟨Int8.toInt⟩
instance : SpiralToInt Int16 := ⟨Int16.toInt⟩
instance : SpiralToInt Int32 := ⟨Int32.toInt⟩
instance : SpiralToInt Int64 := ⟨Int64.toInt⟩
instance : SpiralToInt UInt8 := ⟨fun x => x.toNat⟩
instance : SpiralToInt UInt16 := ⟨fun x => x.toNat⟩
instance : SpiralToInt UInt32 := ⟨fun x => x.toNat⟩
instance : SpiralToInt UInt64 := ⟨fun x => x.toNat⟩
instance : SpiralToInt Float := ⟨fun x => if x < 0 then -(Int.ofNat (Float.toUInt64 (-x)).toNat) else Int.ofNat (Float.toUInt64 x).toNat⟩
instance : SpiralToInt Float32 := ⟨fun x => if x < 0 then -(Int.ofNat (Float32.toUInt64 (-x)).toNat) else Int.ofNat (Float32.toUInt64 x).toNat⟩
def spiralFail {α : Type} (msg : String) : IO α := throw (IO.userError msg)
def spiralIdx {α : Type} [SpiralToInt α] (i : α) : Nat := (SpiralToInt.toI i).toNat
def spiralAbort {α : Type} [Inhabited α] : IO α := do (← IO.getStdout).flush; IO.Process.exit 3
def spiralIsContinuation (b : UInt8) : Bool := b &&& 0xC0 == 0x80
def spiralIndex {α : Type} (xs : Array α) (i : Nat) : IO α := match xs[i]? with
  | some x => pure x
  | none => IO.Process.exit 3
def spiralStringSlice (s : String) (a b : Int) : IO String := do
  let bytes := s.toUTF8
  let length : Int := bytes.size
  if a < 0 || a > length || b < a - 1 || b >= length then spiralAbort
  else if b >= a && (spiralIsContinuation (bytes.get! a.toNat) || (b + 1 < length && spiralIsContinuation (bytes.get! (b + 1).toNat))) then spiralAbort
  else pure (String.Pos.Raw.extract s ⟨a.toNat⟩ ⟨(b + 1).toNat⟩)
def spiralParseInt? (s : String) : Option Int :=
  let u := s.trimAscii.toString
  let v := if u.startsWith "+" then (u.drop 1).toString else u
  v.toInt?

def spiralDigit (c : Char) : Int :=
  if c.isDigit then (c.toNat : Int) - 48
  else if 'a' ≤ c && c ≤ 'z' then (c.toNat : Int) - 87
  else if 'A' ≤ c && c ≤ 'Z' then (c.toNat : Int) - 55
  else 0

def spiralParseIntBase (s : String) (base : Int32) : Int32 :=
  let u := s.trimAscii.toString
  let neg := u.startsWith "-"
  let body := if neg || u.startsWith "+" then (u.drop 1).toString else u
  let v := body.foldl (fun acc c => acc * base.toInt + spiralDigit c) 0
  Int32.ofInt (if neg then -v else v)
mutual
inductive U0 where
  | Some : Int32 → U0
  | None : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Some .. => 0
  | .None .. => 1
mutual
partial def spiralMain : IO Int32 := do
    let mut v13 : Bool := default
    let mut v10 : Bool := default
    let mut v11 : Bool := default
    let mut v16 : U0 := default
    let mut v18 : String := default
    let mut v17 : Int32 := default
    let mut v26 : Bool := default
    let mut v23 : Bool := default
    let mut v24 : Bool := default
    let mut v29 : U0 := default
    let mut v31 : String := default
    let mut v30 : Int32 := default
    let mut v39 : Bool := default
    let mut v36 : Bool := default
    let mut v37 : Bool := default
    let mut v42 : U0 := default
    let mut v44 : String := default
    let mut v43 : Int32 := default
    let mut v52 : Bool := default
    let mut v49 : Bool := default
    let mut v50 : Bool := default
    let mut v55 : U0 := default
    let mut v57 : String := default
    let mut v56 : Int32 := default
    let v0 : String := "ff"
    let v1 : Int32 := (spiralParseIntBase v0 (16 : Int32))
    IO.println (toString v1)
    let v2 : String := "1011"
    let v3 : Int32 := (spiralParseIntBase v2 (2 : Int32))
    IO.println (toString v3)
    let v4 : String := "-42"
    let v5 : Int32 := (spiralParseIntBase v4 (10 : Int32))
    IO.println (toString v5)
    let v6 : String := " 123 "
    let v7 : Bool := (spiralParseInt? v6).isSome
    let v8 : Int64 := (Int64.ofInt ((spiralParseInt? v6).getD 0))
    let v9 : Int32 := (Int32.ofInt (SpiralToInt.toI v8))
    if v7 then
        v10 := (decide (v8 >= (-2147483648 : Int64)))
        if v10 then
            v11 := (decide (v8 <= (2147483647 : Int64)))
            v13 := v11
        else
            v13 := false
    else
        v13 := false
    if v13 then
        v16 := (U0.Some v9)
    else
        v16 := U0.None
    match v16 with
    | U0.None =>
        v18 := "none"
        IO.println (toString v18)
    | U0.Some f17 =>
        v17 := f17
        IO.println (toString v17)
    let v19 : String := "12x"
    let v20 : Bool := (spiralParseInt? v19).isSome
    let v21 : Int64 := (Int64.ofInt ((spiralParseInt? v19).getD 0))
    let v22 : Int32 := (Int32.ofInt (SpiralToInt.toI v21))
    if v20 then
        v23 := (decide (v21 >= (-2147483648 : Int64)))
        if v23 then
            v24 := (decide (v21 <= (2147483647 : Int64)))
            v26 := v24
        else
            v26 := false
    else
        v26 := false
    if v26 then
        v29 := (U0.Some v22)
    else
        v29 := U0.None
    match v29 with
    | U0.None =>
        v31 := "none"
        IO.println (toString v31)
    | U0.Some f30 =>
        v30 := f30
        IO.println (toString v30)
    let v32 : String := ""
    let v33 : Bool := (spiralParseInt? v32).isSome
    let v34 : Int64 := (Int64.ofInt ((spiralParseInt? v32).getD 0))
    let v35 : Int32 := (Int32.ofInt (SpiralToInt.toI v34))
    if v33 then
        v36 := (decide (v34 >= (-2147483648 : Int64)))
        if v36 then
            v37 := (decide (v34 <= (2147483647 : Int64)))
            v39 := v37
        else
            v39 := false
    else
        v39 := false
    if v39 then
        v42 := (U0.Some v35)
    else
        v42 := U0.None
    match v42 with
    | U0.None =>
        v44 := "none"
        IO.println (toString v44)
    | U0.Some f43 =>
        v43 := f43
        IO.println (toString v43)
    let v45 : String := "+7"
    let v46 : Bool := (spiralParseInt? v45).isSome
    let v47 : Int64 := (Int64.ofInt ((spiralParseInt? v45).getD 0))
    let v48 : Int32 := (Int32.ofInt (SpiralToInt.toI v47))
    if v46 then
        v49 := (decide (v47 >= (-2147483648 : Int64)))
        if v49 then
            v50 := (decide (v47 <= (2147483647 : Int64)))
            v52 := v50
        else
            v52 := false
    else
        v52 := false
    if v52 then
        v55 := (U0.Some v48)
    else
        v55 := U0.None
    match v55 with
    | U0.None =>
        v57 := "none"
        IO.println (toString v57)
    | U0.Some f56 =>
        v56 := f56
        IO.println (toString v56)
    return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
