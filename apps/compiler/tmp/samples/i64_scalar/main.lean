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
    let mut v17 : Bool := default
    let mut v16 : Bool := default
    let mut v19 : Bool := default
    let mut v18 : Bool := default
    let mut v21 : Bool := default
    let mut v20 : Bool := default
    let mut v23 : Bool := default
    let mut v22 : Bool := default
    let mut v25 : Bool := default
    let mut v24 : Bool := default
    let mut v27 : Bool := default
    let mut v26 : Bool := default
    let mut v29 : Bool := default
    let mut v28 : Bool := default
    let v0 : Int64 := (5000000000 : Int64)
    let v1 : Int64 := (-4 : Int64)
    let v2 : Int64 := (v0 / v1)
    let v3 : Int64 := (1000000 : Int64)
    let v4 : Int64 := (v3 * v3)
    let v5 : Int64 := (-8 : Int64)
    let v6 : Int64 := (v5 >>> (Int64.ofInt (SpiralToInt.toI (1 : Int32))))
    let v7 : Int32 := (7 : Int32)
    let v8 : Int64 := (Int64.ofInt (SpiralToInt.toI v7))
    let v9 : Int64 := (9 : Int64)
    let v10 : Int32 := (Int32.ofInt (SpiralToInt.toI v9))
    let v11 : UInt64 := (4294967296 : UInt64)
    let v12 : UInt64 := (v11 + (1 : UInt64))
    let v13 : UInt64 := (v11 >>> (UInt64.ofInt (SpiralToInt.toI (1 : Int32))))
    let v14 : UInt64 := (UInt64.ofInt (SpiralToInt.toI v7))
    let v15 : Bool := (v2 == (-1250000000 : Int64))
    if v15 then
        v16 := (v4 == (1000000000000 : Int64))
        v17 := v16
    else
        v17 := false
    if v17 then
        v18 := (v6 == (-4 : Int64))
        v19 := v18
    else
        v19 := false
    if v19 then
        v20 := (v8 == (7 : Int64))
        v21 := v20
    else
        v21 := false
    if v21 then
        v22 := (v10 == (9 : Int32))
        v23 := v22
    else
        v23 := false
    if v23 then
        v24 := (v12 == (4294967297 : UInt64))
        v25 := v24
    else
        v25 := false
    if v25 then
        v26 := (v13 == (2147483648 : UInt64))
        v27 := v26
    else
        v27 := false
    if v27 then
        v28 := (v14 == (7 : UInt64))
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
