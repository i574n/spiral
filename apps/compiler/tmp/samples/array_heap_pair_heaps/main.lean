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
partial def spiralMain : IO Int32 := do
    let mut v7 : (IO.Ref (Array H1)) ← IO.mkRef #[]
    let mut v17 : Bool := default
    let mut v16 : Bool := default
    let mut v19 : Bool := default
    let mut v18 : Bool := default
    let mut v21 : Bool := default
    let mut v20 : Bool := default
    let v0 : Int32 := (7 : Int32)
    let v1 : String := "hi"
    let v2 : H0 := (H0.mk v0 v1)
    let v3 : Int32 := (4 : Int32)
    let v4 : String := "yo"
    let v5 : H0 := (H0.mk v3 v4)
    let v6 : H1 := (H1.mk v2 v5)
    v7 := (← IO.mkRef (Array.replicate (spiralIdx (1 : Int32)) (default : H1)))
    v7.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v6)
    let v8 : H1 := (← spiralIndex (← v7.get) (spiralIdx (0 : Int32)))
    let v9 : H0 := v8.l0
    let v10 : H0 := v8.l1
    let v11 : Int32 := v9.l0
    let v12 : String := v9.l1
    let v13 : Int32 := v10.l0
    let v14 : String := v10.l1
    let v15 : Bool := (v11 == (7 : Int32))
    if v15 then
        v16 := (v12 == "hi")
        v17 := v16
    else
        v17 := false
    if v17 then
        v18 := (v13 == (4 : Int32))
        v19 := v18
    else
        v19 := false
    if v19 then
        v20 := (v14 == "yo")
        v21 := v20
    else
        v21 := false
    if v21 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
