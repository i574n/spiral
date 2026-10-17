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
  l2 : H0
end
deriving instance Inhabited for H1
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
    let mut v9 : H1 := default
    let mut v10 : (IO.Ref (Array H1)) ← IO.mkRef #[]
    let mut v11 : H1 := default
    let mut v12 : H0 := default
    let mut v13 : H0 := default
    let mut v14 : H0 := default
    let mut v15 : Int32 := default
    let mut v16 : String := default
    let mut v17 : Int32 := default
    let mut v18 : String := default
    let mut v19 : Int32 := default
    let mut v20 : String := default
    let mut v21 : Bool := default
    let mut v23 : Bool := default
    let mut v22 : Bool := default
    let mut v25 : Bool := default
    let mut v24 : Bool := default
    let mut v27 : Bool := default
    let mut v26 : Bool := default
    let mut v29 : Bool := default
    let mut v28 : Bool := default
    let mut v31 : Bool := default
    let mut v30 : Bool := default
    v0 := (7 : Int32)
    v1 := "hi"
    v2 := (H0.mk v0 v1)
    v3 := (4 : Int32)
    v4 := "yo"
    v5 := (H0.mk v3 v4)
    v6 := (9 : Int32)
    v7 := "ok"
    v8 := (H0.mk v6 v7)
    v9 := (H1.mk v2 v5 v8)
    v10 := (← IO.mkRef (Array.replicate (spiralIdx (1 : Int32)) (default : H1)))
    v10.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v9)
    v11 := (← spiralIndex (← v10.get) (spiralIdx (0 : Int32)))
    v12 := v11.l0
    v13 := v11.l1
    v14 := v11.l2
    v15 := v12.l0
    v16 := v12.l1
    v17 := v13.l0
    v18 := v13.l1
    v19 := v14.l0
    v20 := v14.l1
    v21 := (v15 == (7 : Int32))
    if v21 then
        v22 := (v16 == "hi")
        v23 := v22
    else
        v23 := false
    if v23 then
        v24 := (v17 == (4 : Int32))
        v25 := v24
    else
        v25 := false
    if v25 then
        v26 := (v18 == "yo")
        v27 := v26
    else
        v27 := false
    if v27 then
        v28 := (v19 == (9 : Int32))
        v29 := v28
    else
        v29 := false
    if v29 then
        v30 := (v20 == "ok")
        v31 := v30
    else
        v31 := false
    if v31 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
