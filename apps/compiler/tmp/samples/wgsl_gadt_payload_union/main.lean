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
  | Living : Int32 → Int32 → U1
inductive U2 where
  | Fallen : Int32 → U2
inductive U0 where
  | Survived : U1 → U0
  | Slain : U2 → U0
end
deriving instance Inhabited for U1
deriving instance Inhabited for U2
deriving instance Inhabited for U0
def U1.spiralTag : U1 → Int32
  | .Living .. => 0
def U2.spiralTag : U2 → Int32
  | .Fallen .. => 0
def U0.spiralTag : U0 → Int32
  | .Survived .. => 0
  | .Slain .. => 1
mutual
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : Bool := default
    let mut v6 : U0 := default
    let mut v2 : U1 := default
    let mut v4 : U2 := default
    let mut v13 : U2 := default
    let mut v7 : U1 := default
    let mut v8 : Int32 := default
    let mut v9 : Int32 := default
    let mut v10 : Bool := default
    v0 := (60 : Int32)
    v1 := (decide (v0 > (0 : Int32)))
    if v1 then
        v2 := (U1.Living v0 (100 : Int32))
        v6 := (U0.Survived v2)
    else
        v4 := (U2.Fallen (100 : Int32))
        v6 := (U0.Slain v4)
    match v6 with
    | U0.Slain f13 =>
        v13 := f13
        return (2 : Int32)
    | U0.Survived f7 =>
        v7 := f7
        match v7 with
        | U1.Living f8 f9 =>
            v8 := f8
            v9 := f9
            v10 := (v8 == (60 : Int32))
            if v10 then
                return (0 : Int32)
            else
                return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
