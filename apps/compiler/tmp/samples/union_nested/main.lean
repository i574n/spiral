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
inductive U1 where
  | A : Int32 → U1
  | B : Int32 → U1
inductive U0 where
  | Wrap : U1 → U0
  | Other : Int32 → U0
end
deriving instance Inhabited for U1
deriving instance Inhabited for U0
def U1.spiralTag : U1 → Int32
  | .A .. => 0
  | .B .. => 1
def U0.spiralTag : U0 → Int32
  | .Wrap .. => 0
  | .Other .. => 1
mutual
partial def score_inner_1 (p0 : U1) : IO Int32 := do
    let mut v0 : U1 := p0
    let mut v1 : Int32 := default
    let mut v2 : Int32 := default
    let mut v3 : Int32 := default
    match v0 with
    | U1.A f1 =>
        v1 := f1
        return v1
    | U1.B f2 =>
        v2 := f2
        v3 := (-v2)
        return v3
partial def score_0 (p0 : U0) : IO Int32 := do
    let mut v0 : U0 := p0
    let mut v3 : Int32 := default
    let mut v1 : U1 := default
    match v0 with
    | U0.Other f3 =>
        v3 := f3
        return v3
    | U0.Wrap f1 =>
        v1 := f1
        return (← score_inner_1 v1)
partial def spiralMain : IO Int32 := do
    let mut v0 : Bool := default
    let mut v4 : U0 := default
    let mut v1 : U1 := default
    let mut v8 : U0 := default
    let mut v6 : U1 := default
    let mut v9 : Int32 := default
    let mut v10 : Bool := default
    let mut v13 : Bool := default
    let mut v11 : Int32 := default
    let mut v12 : Bool := default
    v0 := true
    if v0 then
        v1 := (U1.A (7 : Int32))
        v4 := (U0.Wrap v1)
    else
        v4 := (U0.Other (1 : Int32))
    if v0 then
        v8 := (U0.Other (4 : Int32))
    else
        v6 := (U1.B (2 : Int32))
        v8 := (U0.Wrap v6)
    v9 := (← score_0 v4)
    v10 := (v9 == (7 : Int32))
    if v10 then
        v11 := (← score_0 v8)
        v12 := (v11 == (4 : Int32))
        v13 := v12
    else
        v13 := false
    if v13 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
