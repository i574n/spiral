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
  | c0 : U0
  | c1 : String → Int32 → U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .c0 .. => 0
  | .c1 .. => 1
mutual
partial def closure0 (p0 : Int32) : IO U0 := do
    let mut v0 : Int32 := p0
    let mut v1 : Bool := default
    let mut v3 : String := default
    v1 := (v0 == (0 : Int32))
    if v1 then
        return U0.c0
    else
        v3 := "managed"
        return (U0.c1 v3 (32 : Int32))
partial def method0 (p0 : (Int32 → IO U0)) : IO U0 := do
    let mut v0 : (Int32 → IO U0) := p0
    return (← v0 (0 : Int32))
partial def method1 (p0 : (Int32 → IO U0)) : IO U0 := do
    let mut v0 : (Int32 → IO U0) := p0
    return (← v0 (1 : Int32))
partial def spiralMain : IO Int32 := do
    let mut v0 : (Int32 → IO U0) := default
    let mut v1 : U0 := default
    let mut v7 : Int32 := default
    let mut v2 : String := default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    let mut v8 : U0 := default
    let mut v14 : Int32 := default
    let mut v9 : String := default
    let mut v10 : Int32 := default
    let mut v11 : Int32 := default
    let mut v12 : Int32 := default
    let mut v15 : Int32 := default
    v0 := closure0
    v1 := (← method0 v0)
    match v1 with
    | U0.c0 =>
        v7 := (3 : Int32)
    | U0.c1 f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (Int32.ofNat v2.utf8ByteSize)
        v5 := (v4 + v3)
        v7 := v5
    v8 := (← method1 v0)
    match v8 with
    | U0.c0 =>
        v14 := (3 : Int32)
    | U0.c1 f9 f10 =>
        v9 := f9
        v10 := f10
        v11 := (Int32.ofNat v9.utf8ByteSize)
        v12 := (v11 + v10)
        v14 := v12
    v15 := (v7 + v14)
    return v15
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
