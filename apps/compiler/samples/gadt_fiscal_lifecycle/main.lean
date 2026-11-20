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
inductive U0 where
  | Issued : Int32 → Int32 → U0
end
deriving instance Inhabited for U0
mutual
inductive U1 where
  | Authorized : Int32 → Int32 → Int32 → Int32 → Int32 → U1
end
deriving instance Inhabited for U1
mutual
inductive U2 where
  | Cancelled : Int32 → Int32 → Int32 → Int32 → Int32 → U2
end
deriving instance Inhabited for U2
mutual
inductive U3 where
  | Rejected : Int32 → Int32 → Int32 → U3
end
deriving instance Inhabited for U3
mutual
inductive U4 where
  | Authorized : Int32 → Int32 → Int32 → Int32 → Int32 → U4
end
deriving instance Inhabited for U4
def U0.spiralTag : U0 → Int32
  | .Issued .. => 0
def U1.spiralTag : U1 → Int32
  | .Authorized .. => 1
def U2.spiralTag : U2 → Int32
  | .Cancelled .. => 3
def U3.spiralTag : U3 → Int32
  | .Rejected .. => 2
def U4.spiralTag : U4 → Int32
  | .Authorized .. => 1
mutual
partial def key_of_0 (p0 : U0) : IO Int32 := do
    let mut v0 : U0 := p0
    let mut v1 : Int32 := default
    let mut v2 : Int32 := default
    match v0 with
    | U0.Issued f1 f2 =>
        v1 := f1
        v2 := f2
        return v2
partial def key_of_1 (p0 : U1) : IO Int32 := do
    let mut v0 : U1 := p0
    let mut v1 : Int32 := default
    let mut v2 : Int32 := default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    match v0 with
    | U1.Authorized f1 f2 f3 f4 f5 =>
        v1 := f1
        v2 := f2
        v3 := f3
        v4 := f4
        v5 := f5
        return v2
partial def key_of_2 (p0 : U2) : IO Int32 := do
    let mut v0 : U2 := p0
    let mut v1 : Int32 := default
    let mut v2 : Int32 := default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    match v0 with
    | U2.Cancelled f1 f2 f3 f4 f5 =>
        v1 := f1
        v2 := f2
        v3 := f3
        v4 := f4
        v5 := f5
        return v2
partial def key_of_3 (p0 : U3) : IO Int32 := do
    let mut v0 : U3 := p0
    let mut v1 : Int32 := default
    let mut v2 : Int32 := default
    let mut v3 : Int32 := default
    match v0 with
    | U3.Rejected f1 f2 f3 =>
        v1 := f1
        v2 := f2
        v3 := f3
        return v2
partial def key_of_4 (p0 : U4) : IO Int32 := do
    let mut v0 : U4 := p0
    let mut v1 : Int32 := default
    let mut v2 : Int32 := default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    match v0 with
    | U4.Authorized f1 f2 f3 f4 f5 =>
        v1 := f1
        v2 := f2
        v3 := f3
        v4 := f4
        v5 := f5
        return v2
partial def spiralMain : IO Int32 := do
    let v0 : Int32 := (0 : Int32)
    let v1 : Int32 := (v0 + (7 : Int32))
    let v2 : Int32 := (v0 + (9 : Int32))
    let v3 : Int32 := (v0 + (4 : Int32))
    let v4 : Int32 := (1 : Int32)
    let v5 : U0 := (U0.Issued v4 v1)
    let v6 : Int32 := (← key_of_0 v5)
    let v7 : Int32 := (1 : Int32)
    let v8 : Int32 := (100 : Int32)
    let v9 : Int32 := (3 : Int32)
    let v10 : Int32 := (10 : Int32)
    let v11 : U1 := (U1.Authorized v7 v1 v8 v9 v10)
    let v12 : Int32 := (← key_of_1 v11)
    let v13 : Int32 := (v6 + v12)
    let v14 : Int32 := (1 : Int32)
    let v15 : Int32 := (100 : Int32)
    let v16 : Int32 := (11 : Int32)
    let v17 : Int32 := (200 : Int32)
    let v18 : U2 := (U2.Cancelled v14 v1 v15 v16 v17)
    let v19 : Int32 := (← key_of_2 v18)
    let v20 : Int32 := (v13 + v19)
    let v21 : Int32 := (2 : Int32)
    let v22 : Int32 := (5 : Int32)
    let v23 : U3 := (U3.Rejected v21 v2 v22)
    let v24 : Int32 := (← key_of_3 v23)
    let v25 : Int32 := (v20 + v24)
    let v26 : Int32 := (3 : Int32)
    let v27 : Int32 := (300 : Int32)
    let v28 : Int32 := (0 : Int32)
    let v29 : Int32 := (0 : Int32)
    let v30 : U4 := (U4.Authorized v26 v3 v27 v28 v29)
    let v31 : Int32 := (← key_of_4 v30)
    let v32 : Int32 := (v25 + v31)
    let v33 : Int32 := (v32 + (3 : Int32))
    let v34 : Int32 := (v33 + (11 : Int32))
    let v35 : Int32 := (v34 + (5 : Int32))
    return v35
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
