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
partial def method2 (p0 : Int32) (p1 : String) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : String := p1
    let mut v2 : Int32 := default
    let mut v3 : Bool := default
    let mut v4 : Int32 := default
    v2 := (v0 - (1 : Int32))
    v3 := (v2 == (0 : Int32))
    if v3 then
        v4 := (Int32.ofNat v1.utf8ByteSize)
        return v4
    else
        return (← method1 v2 v1)
partial def method1 (p0 : Int32) (p1 : String) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : String := p1
    let mut v2 : Int32 := default
    let mut v3 : Bool := default
    v2 := (v0 - (1 : Int32))
    v3 := (v2 == (0 : Int32))
    if v3 then
        return (99 : Int32)
    else
        return (← method2 v2 v1)
partial def method0 (p0 : Int32) (p1 : String) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : String := p1
    let mut v2 : Bool := default
    let mut v5 : Int32 := default
    let mut v3 : Int32 := default
    let mut v6 : Int32 := default
    v2 := (v0 == (0 : Int32))
    if v2 then
        v3 := (Int32.ofNat v1.utf8ByteSize)
        v5 := v3
    else
        v5 := (← method1 v0 v1)
    v6 := (v5 - (2 : Int32))
    return v6
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : Int32 := default
    let mut v2 : Bool := default
    let mut v5 : String := default
    let mut v3 : String := default
    let mut v4 : String := default
    v0 := (1000000 : Int32)
    v1 := (v0 % (2 : Int32))
    v2 := (v1 == (0 : Int32))
    if v2 then
        v3 := "ok"
        v5 := v3
    else
        v4 := "go"
        v5 := v4
    return (← method0 v0 v5)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
