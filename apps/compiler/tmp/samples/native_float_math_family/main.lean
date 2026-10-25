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
    let mut v0 : Float32 := default
    let mut v1 : Float32 := default
    let mut v2 : Float := default
    let mut v3 : Float := default
    let mut v4 : Float32 := default
    let mut v5 : Bool := default
    let mut v8 : Bool := default
    let mut v6 : Float := default
    let mut v7 : Bool := default
    let mut v11 : Bool := default
    let mut v9 : Float32 := default
    let mut v10 : Bool := default
    let mut v14 : Bool := default
    let mut v12 : Float := default
    let mut v13 : Bool := default
    let mut v17 : Bool := default
    let mut v15 : Float32 := default
    let mut v16 : Bool := default
    let mut v20 : Bool := default
    let mut v18 : Float := default
    let mut v19 : Bool := default
    let mut v23 : Bool := default
    let mut v21 : Float32 := default
    let mut v22 : Bool := default
    let mut v26 : Bool := default
    let mut v24 : Float := default
    let mut v25 : Bool := default
    let mut v29 : Bool := default
    let mut v27 : Float32 := default
    let mut v28 : Bool := default
    let mut v32 : Bool := default
    let mut v30 : Float := default
    let mut v31 : Bool := default
    v0 := (0.0 : Float32)
    v1 := (1.0 : Float32)
    v2 := (0.0 : Float)
    v3 := (1.0 : Float)
    v4 := (Float32.log v1)
    v5 := (v4 == v0)
    if v5 then
        v6 := (Float.log v3)
        v7 := (v6 == v2)
        v8 := v7
    else
        v8 := false
    if v8 then
        v9 := (Float32.exp v0)
        v10 := (v9 == v1)
        v11 := v10
    else
        v11 := false
    if v11 then
        v12 := (Float.exp v2)
        v13 := (v12 == v3)
        v14 := v13
    else
        v14 := false
    if v14 then
        v15 := (Float32.tanh v0)
        v16 := (v15 == v0)
        v17 := v16
    else
        v17 := false
    if v17 then
        v18 := (Float.tanh v2)
        v19 := (v18 == v2)
        v20 := v19
    else
        v20 := false
    if v20 then
        v21 := (Float32.sin v0)
        v22 := (v21 == v0)
        v23 := v22
    else
        v23 := false
    if v23 then
        v24 := (Float.sin v2)
        v25 := (v24 == v2)
        v26 := v25
    else
        v26 := false
    if v26 then
        v27 := (Float32.cos v0)
        v28 := (v27 == v1)
        v29 := v28
    else
        v29 := false
    if v29 then
        v30 := (Float.cos v2)
        v31 := (v30 == v3)
        v32 := v31
    else
        v32 := false
    if v32 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
