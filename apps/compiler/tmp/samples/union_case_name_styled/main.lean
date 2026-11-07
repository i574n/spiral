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
  | DeepBlue : U0
  | LightGreen : Float → U0
  | Red : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .DeepBlue .. => 0
  | .LightGreen .. => 1
  | .Red .. => 2
mutual
partial def spiralMain : IO Int32 := do
    let mut v7 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v17 : Bool := default
    let mut v11 : String := default
    let mut v12 : String := default
    let mut v13 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v14 : Int32 := default
    let mut v15 : String := default
    let mut v16 : Bool := default
    let mut v23 : Bool := default
    let mut v18 : String := default
    let mut v19 : String := default
    let mut v20 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v21 : String := default
    let mut v22 : Bool := default
    let mut v28 : Bool := default
    let mut v24 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v25 : Int32 := default
    let mut v26 : String := default
    let mut v27 : Bool := default
    let mut v35 : Bool := default
    let mut v29 : String := default
    let mut v30 : String := default
    let mut v31 : String := default
    let mut v32 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v33 : String := default
    let mut v34 : Bool := default
    let v0 : Float := (0.5 : Float)
    let v1 : U0 := (U0.LightGreen v0)
    let v2 : U0 := U0.DeepBlue
    let v3 : U0 := U0.Red
    let v4 : String := "deep_blue"
    let v5 : String := "light_green"
    let v6 : String := "red"
    v7 := (← IO.mkRef (#[v4, v5, v6] : Array String))
    let v8 : Int32 := (U0.spiralTag v1)
    let v9 : String := (← spiralIndex (← v7.get) (spiralIdx v8))
    let v10 : Bool := (v9 == "light_green")
    if v10 then
        v11 := "deep-blue"
        v12 := "light-green"
        v13 := (← IO.mkRef (#[v11, v12, v6] : Array String))
        v14 := (U0.spiralTag v2)
        v15 := (← spiralIndex (← v13.get) (spiralIdx v14))
        v16 := (v15 == "deep-blue")
        v17 := v16
    else
        v17 := false
    if v17 then
        v18 := "deepblue"
        v19 := "lightgreen"
        v20 := (← IO.mkRef (#[v18, v19, v6] : Array String))
        v21 := (← spiralIndex (← v20.get) (spiralIdx v8))
        v22 := (v21 == "lightgreen")
        v23 := v22
    else
        v23 := false
    if v23 then
        v24 := (← IO.mkRef (#[v4, v5, v6] : Array String))
        v25 := (U0.spiralTag v3)
        v26 := (← spiralIndex (← v24.get) (spiralIdx v25))
        v27 := (v26 == "red")
        v28 := v27
    else
        v28 := false
    if v28 then
        v29 := "DeepBlue"
        v30 := "LightGreen"
        v31 := "Red"
        v32 := (← IO.mkRef (#[v29, v30, v31] : Array String))
        v33 := (← spiralIndex (← v32.get) (spiralIdx v8))
        v34 := (v33 == "LightGreen")
        v35 := v34
    else
        v35 := false
    if v35 then
        return (42 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
