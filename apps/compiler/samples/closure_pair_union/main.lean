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
  | None : U0
  | Some : Int32 → U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .None .. => 0
  | .Some .. => 1
mutual
partial def f_c0 (p0 : Int32) (p1 : Int32) : IO (U0 × U0) := do
    let mut v0 : Int32 := p0
    let mut v1 : Int32 := p1
    let mut v3 : U0 := default
    let mut v4 : U0 := default
    let mut v5 : U0 := default
    let mut v6 : U0 := default
    let v2 : Bool := (v1 == (0 : Int32))
    if v2 then
        v3 := U0.None
        v4 := U0.None
        return (v3, v4)
    else
        v5 := (U0.Some v0)
        v6 := U0.None
        return (v5, v6)
partial def spiralMain : IO Int32 := do
    let mut v4 : Int32 := default
    let mut v5 : Bool := default
    let mut v7 : Int32 := default
    let v0 : Int32 := (7 : Int32)
    let v1 : (Int32 → IO (U0 × U0)) := (f_c0 v0)
    let (r1_0, r1_1) := (← v1 (1 : Int32))
    let v2 : U0 := r1_0
    let v3 : U0 := r1_1
    match v2 with
    | U0.None =>
        return (1 : Int32)
    | U0.Some f4 =>
        v4 := f4
        match v3 with
        | U0.None =>
            v5 := (v4 == (7 : Int32))
            if v5 then
                return (0 : Int32)
            else
                return (1 : Int32)
        | U0.Some f7 =>
            v7 := f7
            return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
