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
partial def spiralMain : IO Int32 := do
    let mut v2 : (IO.Ref M0) ← IO.mkRef default
    let mut v3 : (IO.Ref (Array (IO.Ref M0))) ← IO.mkRef #[]
    let mut v4 : (IO.Ref M0) ← IO.mkRef default
    let mut v11 : Bool := default
    let mut v10 : Bool := default
    let v0 : Int32 := (3 : Int32)
    let v1 : String := "no"
    v2 := (← IO.mkRef (M0.mk v0 v1))
    v3 := (← IO.mkRef (← (Array.replicate (spiralIdx (1 : Int32)) ()).mapM (fun _ => IO.mkRef default)))
    v3.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v2)
    v4 := (← spiralIndex (← v3.get) (spiralIdx (0 : Int32)))
    let v5 : Int32 := (7 : Int32)
    let v6 : String := "hi"
    v4.modify (fun r => { r with l0 := v5, l1 := v6 })
    let v7 : Int32 := (← v4.get).l0
    let v8 : String := (← v4.get).l1
    let v9 : Bool := (v7 == (7 : Int32))
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
