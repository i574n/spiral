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
  l1 : H0
end
deriving instance Inhabited for H1
mutual
structure H2 where
  l0 : H1
  l1 : Int32
end
deriving instance Inhabited for H2
mutual
structure M3 where
  l0 : H2
end
deriving instance Inhabited for M3
mutual
partial def spiralMain : IO Int32 := do
    let mut v9 : (IO.Ref M3) ← IO.mkRef default
    let mut v10 : (IO.Ref (Array (IO.Ref M3))) ← IO.mkRef #[]
    let mut v20 : (IO.Ref M3) ← IO.mkRef default
    let mut v32 : Bool := default
    let mut v31 : Bool := default
    let mut v34 : Bool := default
    let mut v33 : Bool := default
    let mut v36 : Bool := default
    let mut v35 : Bool := default
    let mut v38 : Bool := default
    let mut v37 : Bool := default
    let v0 : Int32 := (1 : Int32)
    let v1 : String := "no"
    let v2 : H0 := (H0.mk v0 v1)
    let v3 : Int32 := (2 : Int32)
    let v4 : String := "zz"
    let v5 : H0 := (H0.mk v3 v4)
    let v6 : H1 := (H1.mk v2 v5)
    let v7 : Int32 := (3 : Int32)
    let v8 : H2 := (H2.mk v6 v7)
    v9 := (← IO.mkRef (M3.mk v8))
    v10 := (← IO.mkRef (← (Array.replicate (spiralIdx (1 : Int32)) ()).mapM (fun _ => IO.mkRef default)))
    v10.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v9)
    let v11 : Int32 := (7 : Int32)
    let v12 : String := "hi"
    let v13 : H0 := (H0.mk v11 v12)
    let v14 : Int32 := (4 : Int32)
    let v15 : String := "yo"
    let v16 : H0 := (H0.mk v14 v15)
    let v17 : H1 := (H1.mk v13 v16)
    let v18 : Int32 := (2 : Int32)
    let v19 : H2 := (H2.mk v17 v18)
    v20 := (← spiralIndex (← v10.get) (spiralIdx (0 : Int32)))
    v20.modify (fun r => { r with l0 := v19 })
    let v21 : H2 := (← v20.get).l0
    let v22 : H1 := v21.l0
    let v23 : Int32 := v21.l1
    let v24 : H0 := v22.l0
    let v25 : H0 := v22.l1
    let v26 : Int32 := v24.l0
    let v27 : String := v24.l1
    let v28 : Int32 := v25.l0
    let v29 : String := v25.l1
    let v30 : Bool := (v26 == (7 : Int32))
    if v30 then
        v31 := (v27 == "hi")
        v32 := v31
    else
        v32 := false
    if v32 then
        v33 := (v28 == (4 : Int32))
        v34 := v33
    else
        v34 := false
    if v34 then
        v35 := (v29 == "yo")
        v36 := v35
    else
        v36 := false
    if v36 then
        v37 := (v23 == (2 : Int32))
        v38 := v37
    else
        v38 := false
    if v38 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
