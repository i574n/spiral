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
private unsafe def spiralRefDefaultUnsafe {α : Type} : IO.Ref α := unsafeCast ()
axiom spiralRefNonempty {α : Type} : Nonempty (IO.Ref α)
attribute [instance] spiralRefNonempty
@[implemented_by spiralRefDefaultUnsafe] opaque spiralRefDefault {α : Type} : IO.Ref α
instance {α : Type} : Inhabited (IO.Ref α) := ⟨spiralRefDefault⟩
mutual
inductive U0 where
  | None : U0
  | Held : (IO.Ref (Array Int32)) → Int32 → U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .None .. => 0
  | .Held .. => 1
mutual
partial def score_0 (p0 : U0) : IO Int32 := do
    let mut v0 : U0 := p0
    let mut v1 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v2 : Int32 := default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : Bool := default
    match v0 with
    | U0.Held f1 f2 =>
        v1 := f1
        v2 := f2
        v3 := (← spiralIndex (← v1.get) (spiralIdx (0 : Int32)))
        v4 := (v3 + v2)
        v5 := (v4 == (7 : Int32))
        if v5 then
            return (0 : Int32)
        else
            return (1 : Int32)
    | U0.None =>
        return (1 : Int32)
partial def spiralMain : IO Int32 := do
    let mut v2 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v6 : U0 := default
    let v0 : Int32 := (3 : Int32)
    let v1 : Int32 := (4 : Int32)
    v2 := (← IO.mkRef (Array.replicate (spiralIdx (1 : Int32)) (default : Int32)))
    v2.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v0)
    let v3 : Bool := true
    if v3 then
        v6 := (U0.Held v2 v1)
    else
        v6 := U0.None
    return (← score_0 v6)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
