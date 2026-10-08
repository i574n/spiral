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
partial def choose_left_0 (p0 : Bool) : IO String := do
    let mut v0 : Bool := p0
    let mut v1 : String := default
    let mut v2 : String := default
    if v0 then
        v1 := "spi"
        return v1
    else
        v2 := "bad"
        return v2
partial def choose_right_1 (p0 : Bool) : IO String := do
    let mut v0 : Bool := p0
    let mut v1 : String := default
    let mut v2 : String := default
    if v0 then
        v1 := "bad"
        return v1
    else
        v2 := "ral"
        return v2
partial def spiralMain : IO Int32 := do
    let mut v0 : Bool := default
    let mut v1 : String := default
    let mut v2 : Bool := default
    let mut v3 : String := default
    let mut v4 : String := default
    let mut v5 : Int32 := default
    let mut v6 : Bool := default
    let mut v7 : Char := default
    let mut v8 : Bool := default
    let mut v9 : Char := default
    let mut v10 : Bool := default
    v0 := true
    v1 := (← choose_left_0 v0)
    v2 := false
    v3 := (← choose_right_1 v2)
    v4 := (v1 ++ v3)
    v5 := (Int32.ofNat v4.utf8ByteSize)
    v6 := (v5 == (6 : Int32))
    if v6 then
        v7 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (0 : Int32))).toNat)
        v8 := (v7 == 's')
        if v8 then
            v9 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (5 : Int32))).toNat)
            v10 := (v9 == 'l')
            if v10 then
                return (0 : Int32)
            else
                return (1 : Int32)
        else
            return (2 : Int32)
    else
        return (3 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
