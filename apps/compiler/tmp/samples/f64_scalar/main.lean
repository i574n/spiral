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
    let mut v0 : Float := default
    let mut v1 : Float := default
    let mut v2 : Float := default
    let mut v3 : Float := default
    let mut v4 : Float := default
    let mut v5 : Float := default
    let mut v6 : Float := default
    let mut v7 : Float := default
    let mut v8 : Int32 := default
    let mut v9 : Float := default
    let mut v10 : Float := default
    let mut v11 : Float := default
    let mut v12 : Int32 := default
    let mut v13 : Int32 := default
    let mut v14 : Float32 := default
    let mut v15 : Float := default
    let mut v16 : Bool := default
    let mut v18 : Bool := default
    let mut v17 : Bool := default
    let mut v21 : Bool := default
    let mut v19 : Float := default
    let mut v20 : Bool := default
    let mut v23 : Bool := default
    let mut v22 : Bool := default
    let mut v25 : Bool := default
    let mut v24 : Bool := default
    let mut v27 : Bool := default
    let mut v26 : Bool := default
    let mut v29 : Bool := default
    let mut v28 : Bool := default
    v0 := (1.5 : Float)
    v1 := (-2.0 : Float)
    v2 := (v0 / v1)
    v3 := (1000000.0 : Float)
    v4 := (v3 * v3)
    v5 := (v4 * v3)
    v6 := (v5 * (10000.0 : Float))
    v7 := (v6 * v6)
    v8 := (3 : Int32)
    v9 := (Float.ofInt (SpiralToInt.toI v8))
    v10 := (2.9 : Float)
    v11 := (-1.9 : Float)
    v12 := (Int32.ofInt (SpiralToInt.toI v10))
    v13 := (Int32.ofInt (SpiralToInt.toI v11))
    v14 := (1.5 : Float32)
    v15 := (Float32.toFloat v14)
    v16 := (v2 == (-0.75 : Float))
    if v16 then
        v17 := (decide (v7 > v6))
        v18 := v17
    else
        v18 := false
    if v18 then
        v19 := (v7 * v6)
        v20 := (decide (v7 < v19))
        v21 := v20
    else
        v21 := false
    if v21 then
        v22 := (v9 == (3.0 : Float))
        v23 := v22
    else
        v23 := false
    if v23 then
        v24 := (v12 == (2 : Int32))
        v25 := v24
    else
        v25 := false
    if v25 then
        v26 := (v13 == (-1 : Int32))
        v27 := v26
    else
        v27 := false
    if v27 then
        v28 := (v15 == (1.5 : Float))
        v29 := v28
    else
        v29 := false
    if v29 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
