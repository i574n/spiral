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
  | Circle : Int32 → U0
  | Rect : Int32 → Int32 → U0
  | Empty : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Circle .. => 0
  | .Rect .. => 1
  | .Empty .. => 2
mutual
partial def spiralMain : IO Int32 := do
    let mut v18 : Bool := default
    let mut v8 : Int32 := default
    let mut v9 : Int32 := default
    let mut v10 : Bool := default
    let mut v11 : Int32 := default
    let mut v12 : Int32 := default
    let mut v13 : Int32 := default
    let mut v14 : Int32 := default
    let mut v15 : Bool := default
    let mut v16 : Bool := default
    let mut v19 : Int32 := default
    let mut v28 : Int32 := default
    let mut v20 : Int32 := default
    let mut v21 : Int32 := default
    let mut v22 : Int32 := default
    let mut v23 : Int32 := default
    let mut v24 : Int32 := default
    let mut v25 : Int32 := default
    let mut v37 : Int32 := default
    let mut v29 : Int32 := default
    let mut v30 : Int32 := default
    let mut v31 : Int32 := default
    let mut v32 : Int32 := default
    let mut v33 : Int32 := default
    let mut v34 : Int32 := default
    let mut v47 : Int32 := default
    let mut v39 : Int32 := default
    let mut v40 : Int32 := default
    let mut v41 : Int32 := default
    let mut v42 : Int32 := default
    let mut v43 : Int32 := default
    let mut v44 : Int32 := default
    let v0 : Int32 := (2 : Int32)
    let v1 : U0 := (U0.Circle v0)
    let v2 : Int32 := (3 : Int32)
    let v3 : Int32 := (4 : Int32)
    let v4 : U0 := (U0.Rect v2 v3)
    let v5 : U0 := U0.Empty
    let v6 : Int32 := (2 : Int32)
    let v7 : U0 := (U0.Circle v6)
    match v1, v7 with
    | U0.Circle f8, U0.Circle f9 =>
        v8 := f8
        v9 := f9
        v10 := (v8 == v9)
        v18 := v10
    | U0.Empty, U0.Empty =>
        v18 := true
    | U0.Rect f11 f12, U0.Rect f13 f14 =>
        v11 := f11
        v12 := f12
        v13 := f13
        v14 := f14
        v15 := (v11 == v13)
        if v15 then
            v16 := (v12 == v14)
            v18 := v16
        else
            v18 := false
    | _, _ =>
        v18 := false
    if v18 then
        v19 := (100 : Int32)
    else
        v19 := (0 : Int32)
    match v1 with
    | U0.Circle f20 =>
        v20 := f20
        v21 := ((3 : Int32) * v20)
        v22 := (v21 * v20)
        v28 := v22
    | U0.Empty =>
        v28 := (0 : Int32)
    | U0.Rect f23 f24 =>
        v23 := f23
        v24 := f24
        v25 := (v23 * v24)
        v28 := v25
    match v4 with
    | U0.Circle f29 =>
        v29 := f29
        v30 := ((3 : Int32) * v29)
        v31 := (v30 * v29)
        v37 := v31
    | U0.Empty =>
        v37 := (0 : Int32)
    | U0.Rect f32 f33 =>
        v32 := f32
        v33 := f33
        v34 := (v32 * v33)
        v37 := v34
    let v38 : Int32 := (v28 + v37)
    match v5 with
    | U0.Circle f39 =>
        v39 := f39
        v40 := ((3 : Int32) * v39)
        v41 := (v40 * v39)
        v47 := v41
    | U0.Empty =>
        v47 := (0 : Int32)
    | U0.Rect f42 f43 =>
        v42 := f42
        v43 := f43
        v44 := (v42 * v43)
        v47 := v44
    let v48 : Int32 := (v38 + v47)
    let v49 : Int32 := (v48 + v19)
    return v49
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
