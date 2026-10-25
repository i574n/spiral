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
inductive U0 where
  | Empty : U0
  | Node : String → U0 → U0 → U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Empty .. => 0
  | .Node .. => 1
mutual
partial def score_0 (p0 : U0) : IO Int32 := do
    let mut v0 : U0 := p0
    let mut v1 : String := default
    let mut v2 : U0 := default
    let mut v3 : U0 := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    let mut v6 : Int32 := default
    let mut v7 : Int32 := default
    let mut v8 : Int32 := default
    match v0 with
    | U0.Empty =>
        return (0 : Int32)
    | U0.Node f1 f2 f3 =>
        v1 := f1
        v2 := f2
        v3 := f3
        v4 := (Int32.ofNat v1.utf8ByteSize)
        v5 := (← score_0 v2)
        v6 := (v4 + v5)
        v7 := (← score_0 v3)
        v8 := (v6 + v7)
        return v8
partial def spiralMain : IO Int32 := do
    let mut v0 : String := default
    let mut v1 : String := default
    let mut v2 : U0 := default
    let mut v3 : U0 := default
    let mut v4 : U0 := default
    let mut v5 : Int32 := default
    let mut v6 : U0 := default
    let mut v7 : U0 := default
    let mut v8 : U0 := default
    let mut v9 : Int32 := default
    let mut v10 : Int32 := default
    let mut v11 : Int32 := default
    v0 := "ab"
    v1 := "qwe"
    v2 := U0.Empty
    v3 := (U0.Node v1 v2 v2)
    v4 := (U0.Node v0 v3 v3)
    v5 := (← score_0 v4)
    v6 := U0.Empty
    v7 := (U0.Node v1 v6 v6)
    v8 := (U0.Node v0 v7 v7)
    v9 := (← score_0 v8)
    v10 := (v5 + v9)
    v11 := (v10 - (16 : Int32))
    return v11
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
