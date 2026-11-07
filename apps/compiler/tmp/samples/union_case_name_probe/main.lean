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
  | Circle : Float → U0
  | Square : Float → U0
  | Dot : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Circle .. => 0
  | .Square .. => 1
  | .Dot .. => 2
mutual
partial def spiralMain : IO Int32 := do
    let mut v11 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v19 : Bool := default
    let mut v15 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v16 : Int32 := default
    let mut v17 : String := default
    let mut v18 : Bool := default
    let mut v24 : Bool := default
    let mut v20 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v21 : Int32 := default
    let mut v22 : String := default
    let mut v23 : Bool := default
    let v0 : Float := (1.5 : Float)
    let v1 : U0 := (U0.Circle v0)
    let v2 : Float := (2.5 : Float)
    let v3 : U0 := (U0.Square v2)
    let v4 : U0 := U0.Dot
    let v8 : String := "Circle"
    let v9 : String := "Square"
    let v10 : String := "Dot"
    v11 := (← IO.mkRef (#[v8, v9, v10] : Array String))
    let v12 : Int32 := (U0.spiralTag v1)
    let v13 : String := (← spiralIndex (← v11.get) (spiralIdx v12))
    let v14 : Bool := (v13 == "Circle")
    if v14 then
        v15 := (← IO.mkRef (#[v8, v9, v10] : Array String))
        v16 := (U0.spiralTag v3)
        v17 := (← spiralIndex (← v15.get) (spiralIdx v16))
        v18 := (v17 == "Square")
        v19 := v18
    else
        v19 := false
    if v19 then
        v20 := (← IO.mkRef (#[v8, v9, v10] : Array String))
        v21 := (U0.spiralTag v4)
        v22 := (← spiralIndex (← v20.get) (spiralIdx v21))
        v23 := (v22 == "Dot")
        v24 := v23
    else
        v24 := false
    if v24 then
        return (42 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
