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
partial def right_c1 (p0 : Int32) (p1 : Int32) (p2 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : Int32 := p1
    let mut v2 : Int32 := p2
    let mut v4 : Int32 := default
    let v3 : Bool := (v1 == (0 : Int32))
    if v3 then
        return (0 : Int32)
    else
        v4 := (v2 + v0)
        return v4
partial def left_c2 (p0 : Int32) (p1 : Int32) (p2 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : Int32 := p1
    let mut v2 : Int32 := p2
    let mut v4 : Int32 := default
    let v3 : Bool := (v1 == (0 : Int32))
    if v3 then
        return (0 : Int32)
    else
        v4 := (v2 + v0)
        return v4
partial def f_c0 (p0 : Int32) (p1 : Int32) (p2 : Int32) : IO ((Int32 → IO Int32) × (Int32 → IO Int32)) := do
    let mut v0 : Int32 := p0
    let mut v1 : Int32 := p1
    let mut v2 : Int32 := p2
    let mut v4 : (Int32 → IO Int32) := default
    let mut v5 : (Int32 → IO Int32) := default
    let mut v6 : (Int32 → IO Int32) := default
    let mut v7 : (Int32 → IO Int32) := default
    let v3 : Bool := (v2 == (0 : Int32))
    if v3 then
        v4 := (right_c1 v1 v2)
        v5 := (left_c2 v0 v2)
        return (v4, v5)
    else
        v6 := (left_c2 v0 v2)
        v7 := (right_c1 v1 v2)
        return (v6, v7)
partial def spiralMain : IO Int32 := do
    let v0 : Int32 := (3 : Int32)
    let v1 : Int32 := (4 : Int32)
    let v2 : (Int32 → IO ((Int32 → IO Int32) × (Int32 → IO Int32))) := (f_c0 v0 v1)
    let (r1_0, r1_1) := (← v2 (1 : Int32))
    let v3 : (Int32 → IO Int32) := r1_0
    let v4 : (Int32 → IO Int32) := r1_1
    let v5 : Int32 := (← v3 (0 : Int32))
    let v6 : Int32 := (← v4 (0 : Int32))
    let v7 : Int32 := (v5 + v6)
    let v8 : Bool := (v7 == (7 : Int32))
    if v8 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
