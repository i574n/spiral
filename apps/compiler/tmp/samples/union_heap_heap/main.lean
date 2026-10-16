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
structure H1 where
  l0 : H0
  l1 : Int32
inductive U0 where
  | None : U0
  | Held : H1 → U0
end
deriving instance Inhabited for U0
deriving instance Inhabited for H0
deriving instance Inhabited for H1
def U0.spiralTag : U0 → Int32
  | .None .. => 0
  | .Held .. => 1
mutual
partial def score_0 (p0 : U0) : IO Int32 := do
    let mut v0 : U0 := p0
    let mut v1 : H1 := default
    let mut v2 : H0 := default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : String := default
    let mut v6 : Bool := default
    let mut v8 : Bool := default
    let mut v7 : Bool := default
    let mut v10 : Bool := default
    let mut v9 : Bool := default
    match v0 with
    | U0.Held f1 =>
        v1 := f1
        v2 := v1.l0
        v3 := v1.l1
        v4 := v2.l0
        v5 := v2.l1
        v6 := (v4 == (7 : Int32))
        if v6 then
            v7 := (v5 == "hi")
            v8 := v7
        else
            v8 := false
        if v8 then
            v9 := (v3 == (1 : Int32))
            v10 := v9
        else
            v10 := false
        if v10 then
            return (0 : Int32)
        else
            return (1 : Int32)
    | U0.None =>
        return (1 : Int32)
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : String := default
    let mut v2 : H0 := default
    let mut v3 : Int32 := default
    let mut v4 : H1 := default
    let mut v5 : Bool := default
    let mut v8 : U0 := default
    v0 := (7 : Int32)
    v1 := "hi"
    v2 := (H0.mk v0 v1)
    v3 := (1 : Int32)
    v4 := (H1.mk v2 v3)
    v5 := true
    if v5 then
        v8 := (U0.Held v4)
    else
        v8 := U0.None
    return (← score_0 v8)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
