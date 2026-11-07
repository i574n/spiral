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
    let mut v27 : Bool := default
    let mut v26 : Bool := default
    let mut v29 : Bool := default
    let mut v28 : Bool := default
    let mut v31 : Bool := default
    let mut v30 : Bool := default
    let mut v33 : Bool := default
    let mut v32 : Bool := default
    let mut v35 : Bool := default
    let mut v34 : Bool := default
    let mut v37 : Bool := default
    let mut v36 : Bool := default
    let mut v39 : Bool := default
    let mut v38 : Bool := default
    let mut v41 : Bool := default
    let mut v40 : Bool := default
    let mut v43 : Bool := default
    let mut v42 : Bool := default
    let mut v45 : Bool := default
    let mut v44 : Bool := default
    let mut v47 : Bool := default
    let mut v46 : Bool := default
    let mut v49 : Bool := default
    let mut v48 : Bool := default
    let mut v51 : Bool := default
    let mut v50 : Bool := default
    let mut v53 : Bool := default
    let mut v52 : Bool := default
    let v0 : Int8 := (100 : Int8)
    let v1 : Int8 := (3 : Int8)
    let v2 : Int8 := (v0 * v1)
    let v3 : Int8 := (-8 : Int8)
    let v4 : Int8 := (2 : Int8)
    let v5 : Int8 := (v3 / v4)
    let v6 : Int8 := (v3 % v1)
    let v7 : Int8 := (-v1)
    let v8 : Int8 := (v0 <<< (Int8.ofInt (SpiralToInt.toI (1 : Int32))))
    let v9 : UInt8 := (200 : UInt8)
    let v10 : UInt8 := (3 : UInt8)
    let v11 : UInt8 := (v9 / v10)
    let v12 : UInt8 := (v9 % v10)
    let v13 : UInt8 := (15 : UInt8)
    let v14 : UInt8 := (v9 &&& v13)
    let v15 : UInt8 := (v9 ||| v13)
    let v16 : UInt8 := (v9 ^^^ v13)
    let v17 : UInt8 := (~~~v13)
    let v18 : Int16 := (20000 : Int16)
    let v19 : Int16 := (7 : Int16)
    let v20 : Int16 := (v18 / v19)
    let v21 : Int16 := (v18 % v19)
    let v22 : Int16 := (-v18)
    let v23 : UInt16 := (40000 : UInt16)
    let v24 : UInt16 := (v23 <<< (UInt16.ofInt (SpiralToInt.toI (1 : Int32))))
    let v25 : Bool := (v2 == (44 : Int8))
    if v25 then
        v26 := (v5 == (-4 : Int8))
        v27 := v26
    else
        v27 := false
    if v27 then
        v28 := (v6 == (-2 : Int8))
        v29 := v28
    else
        v29 := false
    if v29 then
        v30 := (v7 == (-3 : Int8))
        v31 := v30
    else
        v31 := false
    if v31 then
        v32 := (v8 == (-56 : Int8))
        v33 := v32
    else
        v33 := false
    if v33 then
        v34 := (v11 == (66 : UInt8))
        v35 := v34
    else
        v35 := false
    if v35 then
        v36 := (v12 == (2 : UInt8))
        v37 := v36
    else
        v37 := false
    if v37 then
        v38 := (v14 == (8 : UInt8))
        v39 := v38
    else
        v39 := false
    if v39 then
        v40 := (v15 == (207 : UInt8))
        v41 := v40
    else
        v41 := false
    if v41 then
        v42 := (v16 == (199 : UInt8))
        v43 := v42
    else
        v43 := false
    if v43 then
        v44 := (v17 == (240 : UInt8))
        v45 := v44
    else
        v45 := false
    if v45 then
        v46 := (v20 == (2857 : Int16))
        v47 := v46
    else
        v47 := false
    if v47 then
        v48 := (v21 == (1 : Int16))
        v49 := v48
    else
        v49 := false
    if v49 then
        v50 := (v22 == (-20000 : Int16))
        v51 := v50
    else
        v51 := false
    if v51 then
        v52 := (v24 == (14464 : UInt16))
        v53 := v52
    else
        v53 := false
    if v53 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
