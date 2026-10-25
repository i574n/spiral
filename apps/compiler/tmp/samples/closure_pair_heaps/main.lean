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
structure H0 where
  l0 : Int32
  l1 : String
end
deriving instance Inhabited for H0
mutual
partial def f_c0 (p0 : H0) (p1 : H0) (p2 : Int32) : IO (H0 × H0) := do
    let mut v0 : H0 := p0
    let mut v1 : H0 := p1
    let mut v2 : Int32 := p2
    return (v0, v1)
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : String := default
    let mut v2 : H0 := default
    let mut v3 : Int32 := default
    let mut v4 : String := default
    let mut v5 : H0 := default
    let mut v6 : (Int32 → IO (H0 × H0)) := default
    let mut v7 : H0 := default
    let mut v8 : H0 := default
    let mut v9 : Int32 := default
    let mut v10 : String := default
    let mut v11 : Int32 := default
    let mut v12 : String := default
    let mut v13 : Bool := default
    let mut v15 : Bool := default
    let mut v14 : Bool := default
    let mut v17 : Bool := default
    let mut v16 : Bool := default
    let mut v19 : Bool := default
    let mut v18 : Bool := default
    v0 := (7 : Int32)
    v1 := "hi"
    v2 := (H0.mk v0 v1)
    v3 := (4 : Int32)
    v4 := "yo"
    v5 := (H0.mk v3 v4)
    v6 := (f_c0 v2 v5)
    let (r1_0, r1_1) := (← v6 (1 : Int32))
    v7 := r1_0
    v8 := r1_1
    v9 := v7.l0
    v10 := v7.l1
    v11 := v8.l0
    v12 := v8.l1
    v13 := (v9 == (7 : Int32))
    if v13 then
        v14 := (v10 == "hi")
        v15 := v14
    else
        v15 := false
    if v15 then
        v16 := (v11 == (4 : Int32))
        v17 := v16
    else
        v17 := false
    if v17 then
        v18 := (v12 == "yo")
        v19 := v18
    else
        v19 := false
    if v19 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
