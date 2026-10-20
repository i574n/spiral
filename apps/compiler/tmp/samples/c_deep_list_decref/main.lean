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
  | Link : Int32 → U0 → U0
  | End : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Link .. => 0
  | .End .. => 1
mutual
partial def build_0 (p0 : Int32) (p1 : U0) : IO U0 := do
    let mut v0 : Int32 := p0
    let mut v1 : U0 := p1
    let mut v2 : Bool := default
    let mut v3 : Int32 := default
    let mut v4 : U0 := default
    repeat
        v2 := (v0 == (0 : Int32))
        if v2 then
            return v1
        else
            v3 := (v0 - (1 : Int32))
            v4 := (U0.Link v0 v1)
            let t3 := v3
            let t4 := v4
            v0 := t3
            v1 := t4
            continue
partial def sum_1 (p0 : U0) (p1 : Int32) : IO Int32 := do
    let mut v0 : U0 := p0
    let mut v1 : Int32 := p1
    let mut v2 : Int32 := default
    let mut v3 : U0 := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    let mut v6 : Int32 := default
    match v0 with
    | U0.End =>
        return v1
    | U0.Link f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (v1 * (31 : Int32))
        v5 := (v4 + v2)
        v6 := (v5 % (9973 : Int32))
        return (← sum_1 v3 v6)
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : U0 := default
    let mut v2 : U0 := default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    v0 := (1000000 : Int32)
    v1 := U0.End
    v2 := (← build_0 v0 v1)
    v3 := (0 : Int32)
    v4 := (← sum_1 v2 v3)
    v5 := (v4 % (256 : Int32))
    return v5
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
