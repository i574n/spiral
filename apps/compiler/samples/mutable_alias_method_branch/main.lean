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
end
deriving instance Inhabited for M0
mutual
partial def method0 (p0 : (IO.Ref M0)) : IO Unit := do
    let mut v0 : (IO.Ref M0) := p0
    let v1 : Int32 := (← v0.get).l0
    let v2 : Int32 := (v1 + (5 : Int32))
    v0.modify (fun r => { r with l0 := v2 })
    return ()
partial def method1 (p0 : (IO.Ref M0)) : IO Unit := do
    let mut v0 : (IO.Ref M0) := p0
    return ()
partial def method2 (p0 : (IO.Ref M0)) : IO Unit := do
    let mut v0 : (IO.Ref M0) := p0
    let v1 : Int32 := (← v0.get).l0
    let v2 : Int32 := (v1 + (7 : Int32))
    v0.modify (fun r => { r with l0 := v2 })
    return ()
partial def spiralMain : IO Int32 := do
    let mut v0 : (IO.Ref M0) ← IO.mkRef default
    v0 := (← IO.mkRef (M0.mk (0 : Int32)))
    let _ := (← method0 v0)
    let _ := (← method1 v0)
    let _ := (← method2 v0)
    let v1 : Int32 := (← v0.get).l0
    let v2 : Int32 := (v1 - (12 : Int32))
    return v2
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
