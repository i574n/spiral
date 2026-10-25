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
    let mut v0 : Float32 := default
    let mut v1 : Float := default
    let mut v2 : Float32 := default
    let mut v3 : Float := default
    let mut v4 : Float32 := default
    let mut v5 : Float := default
    let mut v6 : Bool := default
    let mut v8 : Bool := default
    let mut v7 : Bool := default
    let mut v9 : Bool := default
    let mut v11 : Bool := default
    let mut v10 : Bool := default
    let mut v12 : Bool := default
    let mut v14 : Bool := default
    let mut v13 : Bool := default
    v0 := (1.0 / 0.0 : Float32)
    v1 := (1.0 / 0.0 : Float)
    v2 := (-v0)
    v3 := (-v1)
    v4 := (1.0 : Float32)
    v5 := (1.0 : Float)
    v6 := (Float32.isNaN v4)
    if v6 then
        v8 := true
    else
        v7 := (Float.isNaN v5)
        v8 := v7
    if v8 then
        return (3 : Int32)
    else
        v9 := (decide (v0 > v4))
        if v9 then
            v10 := (decide (v1 > v5))
            v11 := v10
        else
            v11 := false
        if v11 then
            v12 := (decide (v2 < (0.0 : Float32)))
            if v12 then
                v13 := (decide (v3 < (0.0 : Float)))
                v14 := v13
            else
                v14 := false
            if v14 then
                return (0 : Int32)
            else
                return (2 : Int32)
        else
            return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
