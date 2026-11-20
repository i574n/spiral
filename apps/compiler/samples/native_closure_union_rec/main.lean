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
private unsafe def spiralBoxUnsafe {α : Type} (x : α) : NonScalar := unsafeCast x
@[implemented_by spiralBoxUnsafe] opaque spiralBox {α : Type} (x : α) : NonScalar
private unsafe def spiralUnboxUnsafe {α : Type} [Inhabited α] (x : NonScalar) : α := unsafeCast x
@[implemented_by spiralUnboxUnsafe] opaque spiralUnbox {α : Type} [Inhabited α] (x : NonScalar) : α
mutual
inductive U0 where
  | Cons : UInt64 → NonScalar → U0
  | Nil : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Cons .. => 0
  | .Nil .. => 1
mutual
partial def closure0 (p0 : UInt64) (_ : Unit) : IO U0 := do
    let mut v0 : UInt64 := p0
    let v1 : UInt64 := (v0 - (1 : UInt64))
    return (← build_0 v1)
partial def build_0 (p0 : UInt64) : IO U0 := do
    let mut v0 : UInt64 := p0
    let mut v3 : (Unit → IO U0) := default
    let v1 : Bool := (v0 == (0 : UInt64))
    if v1 then
        return U0.Nil
    else
        v3 := (closure0 v0)
        return (U0.Cons v0 (spiralBox v3))
partial def sum_1 (p0 : U0) (p1 : UInt64) : IO UInt64 := do
    let mut v0 : U0 := p0
    let mut v1 : UInt64 := p1
    let mut v2 : UInt64 := default
    let mut v3 : (Unit → IO U0) := default
    let mut v4 : U0 := default
    let mut v5 : UInt64 := default
    match v0 with
    | U0.Cons f2 f3 =>
        v2 := f2
        v3 := spiralUnbox f3
        v4 := (← v3 ())
        v5 := (v1 + v2)
        return (← sum_1 v4 v5)
    | U0.Nil =>
        return v1
partial def spiralMain : IO Int32 := do
    let v0 : UInt64 := (10 : UInt64)
    let v1 : U0 := (← build_0 v0)
    let v2 : UInt64 := (0 : UInt64)
    let v3 : UInt64 := (← sum_1 v1 v2)
    let v4 : Int32 := (5 : Int32)
    let v5 : Int32 := (Int32.ofInt (SpiralToInt.toI v3))
    let v6 : Int32 := (v4 * (2 : Int32))
    let v7 : Int32 := (v4 + v6)
    let v8 : Int32 := (v5 + v7)
    return v8
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
