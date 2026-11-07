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
  | Text : String → U0
  | Code : Int32 → U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Text .. => 0
  | .Code .. => 1
mutual
partial def score_0 (p0 : U0) : IO Int32 := do
    let mut v0 : U0 := p0
    let mut v4 : Int32 := default
    let mut v1 : String := default
    let mut v2 : Bool := default
    match v0 with
    | U0.Code f4 =>
        v4 := f4
        return v4
    | U0.Text f1 =>
        v1 := f1
        v2 := (v1 == "hi")
        if v2 then
            return (2 : Int32)
        else
            return (3 : Int32)
partial def spiralMain : IO Int32 := do
    let mut v4 : U0 := default
    let mut v7 : U0 := default
    let mut v12 : Bool := default
    let mut v10 : Int32 := default
    let mut v11 : Bool := default
    let v0 : Bool := true
    let v1 : String := "hi"
    if v0 then
        v4 := (U0.Text v1)
    else
        v4 := (U0.Code (1 : Int32))
    if v0 then
        v7 := (U0.Code (5 : Int32))
    else
        v7 := (U0.Text v1)
    let v8 : Int32 := (← score_0 v4)
    let v9 : Bool := (v8 == (2 : Int32))
    if v9 then
        v10 := (← score_0 v7)
        v11 := (v10 == (5 : Int32))
        v12 := v11
    else
        v12 := false
    if v12 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
