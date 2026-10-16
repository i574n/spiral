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
partial def spiralMain : IO Int32 := do
    let mut v0 : String := default
    let mut v1 : String := default
    let mut v2 : String := default
    let mut v3 : String := default
    let mut v4 : String := default
    let mut v5 : Bool := default
    let mut v6 : Bool := default
    let mut v8 : Bool := default
    let mut v7 : Bool := default
    let mut v10 : Bool := default
    let mut v9 : Bool := default
    let mut v12 : Bool := default
    let mut v11 : Bool := default
    let mut v14 : Bool := default
    let mut v13 : Bool := default
    let mut v16 : Bool := default
    let mut v15 : Bool := default
    let mut v18 : Bool := default
    let mut v17 : Bool := default
    let mut v20 : Bool := default
    let mut v19 : Bool := default
    v0 := "a"
    v1 := "b"
    v2 := "é"
    v3 := "éx"
    v4 := ""
    v5 := (decide (v0 < v0))
    if v5 then
        return (1 : Int32)
    else
        v6 := (decide (v0 < v1))
        if v6 then
            v7 := (decide (v1 < v2))
            v8 := v7
        else
            v8 := false
        if v8 then
            v9 := (decide (v2 < v3))
            v10 := v9
        else
            v10 := false
        if v10 then
            v11 := (decide (v4 < v0))
            v12 := v11
        else
            v12 := false
        if v12 then
            v13 := (decide (v0 <= v0))
            v14 := v13
        else
            v14 := false
        if v14 then
            v15 := (decide (v0 >= v0))
            v16 := v15
        else
            v16 := false
        if v16 then
            v17 := (decide (v3 > v2))
            v18 := v17
        else
            v18 := false
        if v18 then
            v19 := (decide (v1 >= v0))
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
