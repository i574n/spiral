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
    let mut v0 : Int32 := default
    let mut v1 : String := default
    let mut v2 : H0 := default
    let mut v3 : Int32 := default
    let mut v4 : H1 := default
    let mut v5 : Int32 := default
    let mut v6 : H2 := default
    let mut v7 : (IO.Ref M3) ← IO.mkRef default
    let mut v8 : Int32 := default
    let mut v9 : String := default
    let mut v10 : H0 := default
    let mut v11 : Int32 := default
    let mut v12 : H1 := default
    let mut v13 : Int32 := default
    let mut v14 : H2 := default
    let mut v15 : H2 := default
    let mut v16 : H1 := default
    let mut v17 : Int32 := default
    let mut v18 : H0 := default
    let mut v19 : Int32 := default
    let mut v20 : Int32 := default
    let mut v21 : String := default
    let mut v22 : Bool := default
    let mut v24 : Bool := default
    let mut v23 : Bool := default
    let mut v26 : Bool := default
    let mut v25 : Bool := default
    let mut v28 : Bool := default
    let mut v27 : Bool := default
    v0 := (3 : Int32)
    v1 := "no"
    v2 := (H0.mk v0 v1)
    v3 := (1 : Int32)
    v4 := (H1.mk v2 v3)
    v5 := (2 : Int32)
    v6 := (H2.mk v4 v5)
    v7 := (← IO.mkRef (M3.mk v6))
    v8 := (7 : Int32)
    v9 := "hi"
    v10 := (H0.mk v8 v9)
    v11 := (4 : Int32)
    v12 := (H1.mk v10 v11)
    v13 := (5 : Int32)
    v14 := (H2.mk v12 v13)
    v7.modify (fun r => { r with l0 := v14 })
    v15 := (← v7.get).l0
    v16 := v15.l0
    v17 := v15.l1
    v18 := v16.l0
    v19 := v16.l1
    v20 := v18.l0
    v21 := v18.l1
    v22 := (v20 == (7 : Int32))
    if v22 then
        v23 := (v21 == "hi")
        v24 := v23
    else
        v24 := false
    if v24 then
        v25 := (v19 == (4 : Int32))
        v26 := v25
    else
        v26 := false
    if v26 then
        v27 := (v17 == (5 : Int32))
        v28 := v27
    else
        v28 := false
    if v28 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
