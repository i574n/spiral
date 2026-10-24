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
partial def method0 (p0 : String) : IO (String × Int32) := do
    let mut v0 : String := p0
    let v1 : Int32 := (Int32.ofNat v0.utf8ByteSize)
    return (v0, v1)
partial def score_1 (p0 : Int32) (p1 : String) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : String := p1
    let v2 : Int32 := (Int32.ofNat v1.utf8ByteSize)
    let v3 : Int32 := (v2 + v0)
    return v3
partial def spiralMain : IO Int32 := do
    let v0 : String := "qwe"
    let (r1_0, r1_1) := (← method0 v0)
    let v1 : String := r1_0
    let v2 : Int32 := r1_1
    let v3 : Int32 := (← score_1 v2 v1)
    let v4 : Int32 := (← score_1 v2 v1)
    let v5 : Int32 := (v3 + v4)
    let v6 : Int32 := (v5 - (12 : Int32))
    return v6
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
