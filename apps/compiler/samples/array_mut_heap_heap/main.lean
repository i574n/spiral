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
  l1 : String
end
deriving instance Inhabited for H0
mutual
structure H1 where
  l0 : H0
  l1 : Int32
end
deriving instance Inhabited for H1
mutual
structure M2 where
  l0 : H1
end
deriving instance Inhabited for M2
mutual
partial def spiralMain : IO Int32 := do
    let mut v5 : (IO.Ref M2) ← IO.mkRef default
    let mut v6 : (IO.Ref (Array (IO.Ref M2))) ← IO.mkRef #[]
    let mut v12 : (IO.Ref M2) ← IO.mkRef default
    let mut v20 : Bool := default
    let mut v19 : Bool := default
    let mut v22 : Bool := default
    let mut v21 : Bool := default
    let v0 : Int32 := (3 : Int32)
    let v1 : String := "no"
    let v2 : H0 := (H0.mk v0 v1)
    let v3 : Int32 := (1 : Int32)
    let v4 : H1 := (H1.mk v2 v3)
    v5 := (← IO.mkRef (M2.mk v4))
    v6 := (← IO.mkRef (← (Array.replicate (spiralIdx (1 : Int32)) ()).mapM (fun _ => IO.mkRef default)))
    v6.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v5)
    let v7 : Int32 := (7 : Int32)
    let v8 : String := "hi"
    let v9 : H0 := (H0.mk v7 v8)
    let v10 : Int32 := (4 : Int32)
    let v11 : H1 := (H1.mk v9 v10)
    v12 := (← spiralIndex (← v6.get) (spiralIdx (0 : Int32)))
    v12.modify (fun r => { r with l0 := v11 })
    let v13 : H1 := (← v12.get).l0
    let v14 : H0 := v13.l0
    let v15 : Int32 := v13.l1
    let v16 : Int32 := v14.l0
    let v17 : String := v14.l1
    let v18 : Bool := (v16 == (7 : Int32))
    if v18 then
        v19 := (v17 == "hi")
        v20 := v19
    else
        v20 := false
    if v20 then
        v21 := (v15 == (4 : Int32))
        v22 := v21
    else
        v22 := false
    if v22 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
