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
  | First : U0
  | Second : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .First .. => 1
  | .Second .. => 2
mutual
partial def spiralMain : IO Int32 := do
    let mut v6 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v14 : Bool := default
    let mut v10 : (IO.Ref (Array String)) ← IO.mkRef #[]
    let mut v11 : Int32 := default
    let mut v12 : String := default
    let mut v13 : Bool := default
    let v0 : U0 := U0.First
    let v1 : U0 := U0.Second
    let v3 : String := ""
    let v4 : String := "First"
    let v5 : String := "Second"
    v6 := (← IO.mkRef (#[v3, v4, v5] : Array String))
    let v7 : Int32 := (U0.spiralTag v0)
    let v8 : String := (← spiralIndex (← v6.get) (spiralIdx v7))
    let v9 : Bool := (v8 == "First")
    if v9 then
        v10 := (← IO.mkRef (#[v3, v4, v5] : Array String))
        v11 := (U0.spiralTag v1)
        v12 := (← spiralIndex (← v10.get) (spiralIdx v11))
        v13 := (v12 == "Second")
        v14 := v13
    else
        v14 := false
    if v14 then
        return (42 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
