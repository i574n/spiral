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
structure M0 where
  l0 : Int32
  l1 : String
end
deriving instance Inhabited for M0
mutual
partial def f_c0 (p0 : (IO.Ref M0)) (p1 : Int32) : IO (IO.Ref M0) := do
    let mut v0 : (IO.Ref M0) := p0
    let mut v1 : Int32 := p1
    return v0
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : String := default
    let mut v2 : (IO.Ref M0) ← IO.mkRef default
    let mut v3 : (Int32 → IO (IO.Ref M0)) := default
    let mut v4 : (IO.Ref M0) ← IO.mkRef default
    let mut v5 : Int32 := default
    let mut v6 : String := default
    let mut v7 : Int32 := default
    let mut v8 : String := default
    let mut v9 : Bool := default
    let mut v11 : Bool := default
    let mut v10 : Bool := default
    v0 := (3 : Int32)
    v1 := "no"
    v2 := (← IO.mkRef (M0.mk v0 v1))
    v3 := (f_c0 v2)
    v4 := (← v3 (1 : Int32))
    v5 := (7 : Int32)
    v6 := "hi"
    v4.modify (fun r => { r with l0 := v5, l1 := v6 })
    v7 := (← v4.get).l0
    v8 := (← v4.get).l1
    v9 := (v7 == (7 : Int32))
    if v9 then
        v10 := (v8 == "hi")
        v11 := v10
    else
        v11 := false
    if v11 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
