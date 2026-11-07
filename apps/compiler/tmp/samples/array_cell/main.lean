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
structure H0 where
  l0 : Int32
end
deriving instance Inhabited for H0
mutual
partial def spiralMain : IO Int32 := do
    let mut v1 : (IO.Ref (Array H0)) ← IO.mkRef #[]
    let v0 : Int32 := (2 : Int32)
    v1 := (← IO.mkRef (Array.replicate (spiralIdx v0) (default : H0)))
    let v2 : Int32 := (4 : Int32)
    let v3 : Int32 := (6 : Int32)
    let v4 : H0 := (H0.mk v2)
    v1.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v4)
    let v5 : H0 := (H0.mk v3)
    v1.modify (fun xs => xs.set! (spiralIdx (1 : Int32)) v5)
    let v6 : H0 := (← spiralIndex (← v1.get) (spiralIdx (0 : Int32)))
    let v7 : Int32 := v6.l0
    let v8 : H0 := (← spiralIndex (← v1.get) (spiralIdx (1 : Int32)))
    let v9 : Int32 := v8.l0
    let v10 : Int32 := (v7 + v9)
    let v11 : Bool := (v10 == (10 : Int32))
    if v11 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
