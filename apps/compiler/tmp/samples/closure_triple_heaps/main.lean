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
partial def f_c0 (p0 : H0) (p1 : H0) (p2 : H0) (p3 : Int32) : IO (H0 × H0 × H0) := do
    let mut v0 : H0 := p0
    let mut v1 : H0 := p1
    let mut v2 : H0 := p2
    let mut v3 : Int32 := p3
    return (v0, v1, v2)
partial def spiralMain : IO Int32 := do
    let mut v21 : Bool := default
    let mut v20 : Bool := default
    let mut v23 : Bool := default
    let mut v22 : Bool := default
    let mut v25 : Bool := default
    let mut v24 : Bool := default
    let mut v27 : Bool := default
    let mut v26 : Bool := default
    let mut v29 : Bool := default
    let mut v28 : Bool := default
    let v0 : Int32 := (7 : Int32)
    let v1 : String := "hi"
    let v2 : H0 := (H0.mk v0 v1)
    let v3 : Int32 := (4 : Int32)
    let v4 : String := "yo"
    let v5 : H0 := (H0.mk v3 v4)
    let v6 : Int32 := (9 : Int32)
    let v7 : String := "ok"
    let v8 : H0 := (H0.mk v6 v7)
    let v9 : (Int32 → IO (H0 × H0 × H0)) := (f_c0 v2 v5 v8)
    let (r1_0, r1_1, r1_2) := (← v9 (1 : Int32))
    let v10 : H0 := r1_0
    let v11 : H0 := r1_1
    let v12 : H0 := r1_2
    let v13 : Int32 := v10.l0
    let v14 : String := v10.l1
    let v15 : Int32 := v11.l0
    let v16 : String := v11.l1
    let v17 : Int32 := v12.l0
    let v18 : String := v12.l1
    let v19 : Bool := (v13 == (7 : Int32))
    if v19 then
        v20 := (v14 == "hi")
        v21 := v20
    else
        v21 := false
    if v21 then
        v22 := (v15 == (4 : Int32))
        v23 := v22
    else
        v23 := false
    if v23 then
        v24 := (v16 == "yo")
        v25 := v24
    else
        v25 := false
    if v25 then
        v26 := (v17 == (9 : Int32))
        v27 := v26
    else
        v27 := false
    if v27 then
        v28 := (v18 == "ok")
        v29 := v28
    else
        v29 := false
    if v29 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
