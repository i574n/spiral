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
    let mut v0 : Int8 := default
    let mut v1 : Int8 := default
    let mut v2 : UInt8 := default
    let mut v3 : UInt8 := default
    let mut v4 : UInt8 := default
    let mut v5 : Int8 := default
    let mut v6 : Int8 := default
    let mut v7 : UInt8 := default
    let mut v8 : Int16 := default
    let mut v9 : Int16 := default
    let mut v10 : UInt16 := default
    let mut v11 : UInt16 := default
    let mut v12 : Int32 := default
    let mut v13 : Int8 := default
    let mut v14 : Int8 := default
    let mut v15 : Int32 := default
    let mut v16 : Bool := default
    let mut v18 : Bool := default
    let mut v17 : Bool := default
    let mut v20 : Bool := default
    let mut v19 : Bool := default
    let mut v22 : Bool := default
    let mut v21 : Bool := default
    let mut v24 : Bool := default
    let mut v23 : Bool := default
    let mut v26 : Bool := default
    let mut v25 : Bool := default
    let mut v28 : Bool := default
    let mut v27 : Bool := default
    let mut v30 : Bool := default
    let mut v29 : Bool := default
    v0 := (100 : Int8)
    v1 := (v0 + v0)
    v2 := (200 : UInt8)
    v3 := (100 : UInt8)
    v4 := (v2 + v3)
    v5 := (-8 : Int8)
    v6 := (v5 >>> (Int8.ofInt (SpiralToInt.toI (1 : Int32))))
    v7 := (v2 >>> (UInt8.ofInt (SpiralToInt.toI (1 : Int32))))
    v8 := (20000 : Int16)
    v9 := (v8 + v8)
    v10 := (40000 : UInt16)
    v11 := (v10 + v10)
    v12 := (7 : Int32)
    v13 := (Int8.ofInt (SpiralToInt.toI v12))
    v14 := (9 : Int8)
    v15 := (Int32.ofInt (SpiralToInt.toI v14))
    v16 := (v1 == (-56 : Int8))
    if v16 then
        v17 := (v4 == (44 : UInt8))
        v18 := v17
    else
        v18 := false
    if v18 then
        v19 := (v6 == (-4 : Int8))
        v20 := v19
    else
        v20 := false
    if v20 then
        v21 := (v7 == (100 : UInt8))
        v22 := v21
    else
        v22 := false
    if v22 then
        v23 := (v9 == (-25536 : Int16))
        v24 := v23
    else
        v24 := false
    if v24 then
        v25 := (v11 == (14464 : UInt16))
        v26 := v25
    else
        v26 := false
    if v26 then
        v27 := (v13 == (7 : Int8))
        v28 := v27
    else
        v28 := false
    if v28 then
        v29 := (v15 == (9 : Int32))
        v30 := v29
    else
        v30 := false
    if v30 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
