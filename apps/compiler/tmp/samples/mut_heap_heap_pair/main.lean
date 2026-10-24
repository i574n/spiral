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
    let mut v30 : Bool := default
    let mut v29 : Bool := default
    let mut v32 : Bool := default
    let mut v31 : Bool := default
    let mut v34 : Bool := default
    let mut v33 : Bool := default
    let mut v36 : Bool := default
    let mut v35 : Bool := default
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
    let v10 : Int32 := (7 : Int32)
    let v11 : String := "hi"
    let v12 : H0 := (H0.mk v10 v11)
    let v13 : Int32 := (4 : Int32)
    let v14 : String := "yo"
    let v15 : H0 := (H0.mk v13 v14)
    let v16 : H1 := (H1.mk v12 v15)
    let v17 : Int32 := (2 : Int32)
    let v18 : H2 := (H2.mk v16 v17)
    v9.modify (fun r => { r with l0 := v18 })
    let v19 : H2 := (← v9.get).l0
    let v20 : H1 := v19.l0
    let v21 : Int32 := v19.l1
    let v22 : H0 := v20.l0
    let v23 : H0 := v20.l1
    let v24 : Int32 := v22.l0
    let v25 : String := v22.l1
    let v26 : Int32 := v23.l0
    let v27 : String := v23.l1
    let v28 : Bool := (v24 == (7 : Int32))
    if v28 then
        v29 := (v25 == "hi")
        v30 := v29
    else
        v30 := false
    if v30 then
        v31 := (v26 == (4 : Int32))
        v32 := v31
    else
        v32 := false
    if v32 then
        v33 := (v27 == "yo")
        v34 := v33
    else
        v34 := false
    if v34 then
        v35 := (v21 == (2 : Int32))
        v36 := v35
    else
        v36 := false
    if v36 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
