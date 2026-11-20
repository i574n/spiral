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
    let mut v18 : Bool := default
    let mut v17 : Bool := default
    let mut v20 : Bool := default
    let mut v19 : Bool := default
    let v0 : Int32 := (3 : Int32)
    let v1 : String := "no"
    let v2 : H0 := (H0.mk v0 v1)
    let v3 : Int32 := (1 : Int32)
    let v4 : H1 := (H1.mk v2 v3)
    v5 := (← IO.mkRef (M2.mk v4))
    let v6 : Int32 := (7 : Int32)
    let v7 : String := "hi"
    let v8 : H0 := (H0.mk v6 v7)
    let v9 : Int32 := (4 : Int32)
    let v10 : H1 := (H1.mk v8 v9)
    v5.modify (fun r => { r with l0 := v10 })
    let v11 : H1 := (← v5.get).l0
    let v12 : H0 := v11.l0
    let v13 : Int32 := v11.l1
    let v14 : Int32 := v12.l0
    let v15 : String := v12.l1
    let v16 : Bool := (v14 == (7 : Int32))
    if v16 then
        v17 := (v15 == "hi")
        v18 := v17
    else
        v18 := false
    if v18 then
        v19 := (v13 == (4 : Int32))
        v20 := v19
    else
        v20 := false
    if v20 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
