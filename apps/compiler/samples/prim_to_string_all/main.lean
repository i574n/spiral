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
mutual
partial def spiralMain : IO Int32 := do
    let mut v13 : Int32 := default
    let mut v16 : Int32 := default
    let mut v20 : Int32 := default
    let mut v24 : Int32 := default
    let mut v28 : Int32 := default
    let mut v32 : Int32 := default
    let mut v36 : Int32 := default
    let mut v40 : Int32 := default
    let mut v44 : Int32 := default
    let mut v48 : Int32 := default
    let mut v52 : Int32 := default
    let mut v56 : Int32 := default
    let mut v60 : Int32 := default
    let mut v64 : Int32 := default
    let mut v68 : Int32 := default
    let v0 : Int8 := (-128 : Int8)
    let v1 : Int16 := (-32768 : Int16)
    let v2 : Int32 := (-5 : Int32)
    let v3 : Int64 := (-1234567890123 : Int64)
    let v4 : UInt8 := (255 : UInt8)
    let v5 : UInt16 := (65535 : UInt16)
    let v6 : UInt32 := (4294967295 : UInt32)
    let v7 : UInt64 := (18446744073709551615 : UInt64)
    let v8 : Bool := true
    let v9 : Bool := false
    let v10 : Char := 'a'
    let v11 : String := (toString (v0))
    let v12 : Bool := (v11 == "-128")
    if v12 then
        v13 := (0 : Int32)
    else
        v13 := (1 : Int32)
    let v14 : String := (toString (v1))
    let v15 : Bool := (v14 == "-32768")
    if v15 then
        v16 := (0 : Int32)
    else
        v16 := (1 : Int32)
    let v17 : Int32 := (v13 + v16)
    let v18 : String := (toString (v2))
    let v19 : Bool := (v18 == "-5")
    if v19 then
        v20 := (0 : Int32)
    else
        v20 := (1 : Int32)
    let v21 : Int32 := (v17 + v20)
    let v22 : String := (toString (v3))
    let v23 : Bool := (v22 == "-1234567890123")
    if v23 then
        v24 := (0 : Int32)
    else
        v24 := (1 : Int32)
    let v25 : Int32 := (v21 + v24)
    let v26 : String := (toString (v4))
    let v27 : Bool := (v26 == "255")
    if v27 then
        v28 := (0 : Int32)
    else
        v28 := (1 : Int32)
    let v29 : Int32 := (v25 + v28)
    let v30 : String := (toString (v5))
    let v31 : Bool := (v30 == "65535")
    if v31 then
        v32 := (0 : Int32)
    else
        v32 := (1 : Int32)
    let v33 : Int32 := (v29 + v32)
    let v34 : String := (toString (v6))
    let v35 : Bool := (v34 == "4294967295")
    if v35 then
        v36 := (0 : Int32)
    else
        v36 := (1 : Int32)
    let v37 : Int32 := (v33 + v36)
    let v38 : String := (toString (v7))
    let v39 : Bool := (v38 == "18446744073709551615")
    if v39 then
        v40 := (0 : Int32)
    else
        v40 := (1 : Int32)
    let v41 : Int32 := (v37 + v40)
    let v42 : String := (toString (v8))
    let v43 : Bool := (v42 == "true")
    if v43 then
        v44 := (0 : Int32)
    else
        v44 := (1 : Int32)
    let v45 : Int32 := (v41 + v44)
    let v46 : String := (toString (v9))
    let v47 : Bool := (v46 == "false")
    if v47 then
        v48 := (0 : Int32)
    else
        v48 := (1 : Int32)
    let v49 : Int32 := (v45 + v48)
    let v50 : String := (toString (v10))
    let v51 : Bool := (v50 == "a")
    if v51 then
        v52 := (0 : Int32)
    else
        v52 := (1 : Int32)
    let v53 : Int32 := (v49 + v52)
    let v54 : String := (toString ((7 : UInt8)))
    let v55 : Bool := (v54 == "7")
    if v55 then
        v56 := (0 : Int32)
    else
        v56 := (1 : Int32)
    let v57 : Int32 := (v53 + v56)
    let v58 : String := (toString (false))
    let v59 : Bool := (v58 == "false")
    if v59 then
        v60 := (0 : Int32)
    else
        v60 := (1 : Int32)
    let v61 : Int32 := (v57 + v60)
    let v62 : String := (toString ('z'))
    let v63 : Bool := (v62 == "z")
    if v63 then
        v64 := (0 : Int32)
    else
        v64 := (1 : Int32)
    let v65 : Int32 := (v61 + v64)
    let v66 : String := (toString ((-3 : Int64)))
    let v67 : Bool := (v66 == "-3")
    if v67 then
        v68 := (0 : Int32)
    else
        v68 := (1 : Int32)
    let v69 : Int32 := (v65 + v68)
    return v69
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
