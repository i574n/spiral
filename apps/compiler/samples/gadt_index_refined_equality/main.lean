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
  | Vowel : Int32 → U0
end
deriving instance Inhabited for U0
mutual
inductive U1 where
  | Nil : U1
  | Cons : U0 → U1 → U1
end
deriving instance Inhabited for U1
def U0.spiralTag : U0 → Int32
  | .Vowel .. => 1
def U1.spiralTag : U1 → Int32
  | .Nil .. => 0
  | .Cons .. => 1
mutual
partial def method0 (p0 : U1) (p1 : U1) : IO Bool := do
    let mut v0 : U1 := p0
    let mut v1 : U1 := p1
    let mut v2 : U0 := default
    let mut v3 : U1 := default
    let mut v4 : U0 := default
    let mut v5 : U1 := default
    let mut v9 : Bool := default
    let mut v6 : Int32 := default
    let mut v7 : Int32 := default
    let mut v8 : Bool := default
    match v1, v0 with
    | U1.Cons f2 f3, U1.Cons f4 f5 =>
        v2 := f2
        v3 := f3
        v4 := f4
        v5 := f5
        match v2, v4 with
        | U0.Vowel f6, U0.Vowel f7 =>
            v6 := f6
            v7 := f7
            v8 := (v6 == v7)
            v9 := v8
        if v9 then
            return (← method0 v5 v3)
        else
            return false
    | U1.Nil, U1.Nil =>
        return true
    | _, _ =>
        return false
partial def spiralMain : IO Int32 := do
    let mut v17 : Bool := default
    let mut v14 : Int32 := default
    let mut v15 : Int32 := default
    let mut v16 : Bool := default
    let mut v23 : Bool := default
    let mut v21 : Bool := default
    let mut v18 : Int32 := default
    let mut v19 : Int32 := default
    let mut v20 : Bool := default
    let mut v22 : Bool := default
    let mut v30 : Bool := default
    let mut v27 : Bool := default
    let mut v24 : Int32 := default
    let mut v25 : Int32 := default
    let mut v26 : Bool := default
    let mut v38 : Bool := default
    let mut v34 : Bool := default
    let mut v31 : Int32 := default
    let mut v32 : Int32 := default
    let mut v33 : Bool := default
    let mut v36 : Bool := default
    let mut v37 : Bool := default
    let v0 : Int32 := (1 : Int32)
    let v1 : U0 := (U0.Vowel v0)
    let v2 : Int32 := (1 : Int32)
    let v3 : U0 := (U0.Vowel v2)
    let v4 : Int32 := (2 : Int32)
    let v5 : U0 := (U0.Vowel v4)
    let v6 : U1 := U1.Nil
    let v7 : U1 := (U1.Cons v5 v6)
    let v8 : U1 := (U1.Cons v1 v7)
    let v9 : U1 := U1.Nil
    let v10 : U1 := (U1.Cons v5 v9)
    let v11 : U1 := (U1.Cons v3 v10)
    let v12 : U1 := U1.Nil
    let v13 : U1 := (U1.Cons v1 v12)
    match v1, v3 with
    | U0.Vowel f14, U0.Vowel f15 =>
        v14 := f14
        v15 := f15
        v16 := (v14 == v15)
        v17 := v16
    if v17 then
        match v1, v5 with
        | U0.Vowel f18, U0.Vowel f19 =>
            v18 := f18
            v19 := f19
            v20 := (v18 == v19)
            v21 := v20
        v22 := (v21 == false)
        v23 := v22
    else
        v23 := false
    if v23 then
        match v1, v3 with
        | U0.Vowel f24, U0.Vowel f25 =>
            v24 := f24
            v25 := f25
            v26 := (v24 == v25)
            v27 := v26
        if v27 then
            v30 := (← method0 v11 v8)
        else
            v30 := false
    else
        v30 := false
    if v30 then
        match v1, v5 with
        | U0.Vowel f31, U0.Vowel f32 =>
            v31 := f31
            v32 := f32
            v33 := (v31 == v32)
            v34 := v33
        if v34 then
            v36 := (← method0 v13 v8)
        else
            v36 := false
        v37 := (v36 == false)
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
