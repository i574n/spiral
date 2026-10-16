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
end
deriving instance Inhabited for H0
mutual
partial def f_c0 (p0 : H0) (p1 : H0) (p2 : Int32) : IO (H0 × H0) := do
    let mut v0 : H0 := p0
    let mut v1 : H0 := p1
    let mut v2 : Int32 := p2
    let mut v3 : Bool := default
    v3 := (v2 == (0 : Int32))
    if v3 then
        return (v1, v0)
    else
        return (v0, v1)
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : Int32 := default
    let mut v2 : H0 := default
    let mut v3 : H0 := default
    let mut v4 : (Int32 → IO (H0 × H0)) := default
    let mut v5 : H0 := default
    let mut v6 : H0 := default
    let mut v7 : Int32 := default
    let mut v8 : Int32 := default
    let mut v9 : Int32 := default
    let mut v10 : Bool := default
    v0 := (3 : Int32)
    v1 := (4 : Int32)
    v2 := (H0.mk v0)
    v3 := (H0.mk v1)
    v4 := (f_c0 v2 v3)
    let (r1_0, r1_1) := (← v4 (1 : Int32))
    v5 := r1_0
    v6 := r1_1
    v7 := v5.l0
    v8 := v6.l0
    v9 := (v7 + v8)
    v10 := (v9 == (7 : Int32))
    if v10 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
