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
structure M1 where
  l0 : H0
  l1 : H0
  l2 : H0
end
deriving instance Inhabited for H0
deriving instance Inhabited for M1
mutual
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : String := default
    let mut v2 : H0 := default
    let mut v3 : Int32 := default
    let mut v4 : String := default
    let mut v5 : H0 := default
    let mut v6 : Int32 := default
    let mut v7 : String := default
    let mut v8 : H0 := default
    let mut v9 : (IO.Ref M1) ← IO.mkRef default
    let mut v10 : Int32 := default
    let mut v11 : String := default
    let mut v12 : H0 := default
    let mut v13 : Int32 := default
    let mut v14 : String := default
    let mut v15 : H0 := default
    let mut v16 : Int32 := default
    let mut v17 : String := default
    let mut v18 : H0 := default
    let mut v19 : H0 := default
    let mut v20 : H0 := default
    let mut v21 : H0 := default
    let mut v22 : Int32 := default
    let mut v23 : String := default
    let mut v24 : Int32 := default
    let mut v25 : String := default
    let mut v26 : Int32 := default
    let mut v27 : String := default
    let mut v28 : Bool := default
    let mut v30 : Bool := default
    let mut v29 : Bool := default
    let mut v32 : Bool := default
    let mut v31 : Bool := default
    let mut v34 : Bool := default
    let mut v33 : Bool := default
    let mut v36 : Bool := default
    let mut v35 : Bool := default
    let mut v38 : Bool := default
    let mut v37 : Bool := default
    v0 := (1 : Int32)
    v1 := "no"
    v2 := (H0.mk v0 v1)
    v3 := (2 : Int32)
    v4 := "zz"
    v5 := (H0.mk v3 v4)
    v6 := (3 : Int32)
    v7 := "aa"
    v8 := (H0.mk v6 v7)
    v9 := (← IO.mkRef (M1.mk v2 v5 v8))
    v10 := (7 : Int32)
    v11 := "hi"
    v12 := (H0.mk v10 v11)
    v13 := (4 : Int32)
    v14 := "yo"
    v15 := (H0.mk v13 v14)
    v16 := (9 : Int32)
    v17 := "ok"
    v18 := (H0.mk v16 v17)
    v9.modify (fun r => { r with l0 := v12, l1 := v15, l2 := v18 })
    v19 := (← v9.get).l0
    v20 := (← v9.get).l1
    v21 := (← v9.get).l2
    v22 := v19.l0
    v23 := v19.l1
    v24 := v20.l0
    v25 := v20.l1
    v26 := v21.l0
    v27 := v21.l1
    v28 := (v22 == (7 : Int32))
    if v28 then
        v29 := (v23 == "hi")
        v30 := v29
    else
        v30 := false
    if v30 then
        v31 := (v24 == (4 : Int32))
        v32 := v31
    else
        v32 := false
    if v32 then
        v33 := (v25 == "yo")
        v34 := v33
    else
        v34 := false
    if v34 then
        v35 := (v26 == (9 : Int32))
        v36 := v35
    else
        v36 := false
    if v36 then
        v37 := (v27 == "ok")
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
