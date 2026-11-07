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
structure M1 where
  l0 : H0
  l1 : H0
end
deriving instance Inhabited for M1
mutual
partial def spiralMain : IO Int32 := do
    let mut v6 : (IO.Ref M1) ← IO.mkRef default
    let mut v7 : (IO.Ref (Array (IO.Ref M1))) ← IO.mkRef #[]
    let mut v14 : (IO.Ref M1) ← IO.mkRef default
    let mut v23 : Bool := default
    let mut v22 : Bool := default
    let mut v25 : Bool := default
    let mut v24 : Bool := default
    let mut v27 : Bool := default
    let mut v26 : Bool := default
    let v0 : Int32 := (1 : Int32)
    let v1 : String := "no"
    let v2 : H0 := (H0.mk v0 v1)
    let v3 : Int32 := (2 : Int32)
    let v4 : String := "zz"
    let v5 : H0 := (H0.mk v3 v4)
    v6 := (← IO.mkRef (M1.mk v2 v5))
    v7 := (← IO.mkRef (← (Array.replicate (spiralIdx (1 : Int32)) ()).mapM (fun _ => IO.mkRef default)))
    v7.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v6)
    let v8 : Int32 := (7 : Int32)
    let v9 : String := "hi"
    let v10 : H0 := (H0.mk v8 v9)
    let v11 : Int32 := (4 : Int32)
    let v12 : String := "yo"
    let v13 : H0 := (H0.mk v11 v12)
    v14 := (← spiralIndex (← v7.get) (spiralIdx (0 : Int32)))
    v14.modify (fun r => { r with l0 := v10, l1 := v13 })
    let v15 : H0 := (← v14.get).l0
    let v16 : H0 := (← v14.get).l1
    let v17 : Int32 := v15.l0
    let v18 : String := v15.l1
    let v19 : Int32 := v16.l0
    let v20 : String := v16.l1
    let v21 : Bool := (v17 == (7 : Int32))
    if v21 then
        v22 := (v18 == "hi")
        v23 := v22
    else
        v23 := false
    if v23 then
        v24 := (v19 == (4 : Int32))
        v25 := v24
    else
        v25 := false
    if v25 then
        v26 := (v20 == "yo")
        v27 := v26
    else
        v27 := false
    if v27 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
