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
    let mut v1 : Int32 := default
    let mut v2 : Char := default
    let mut v3 : Char := default
    let mut v4 : String := default
    let mut v5 : String := default
    let mut v6 : Int32 := default
    let mut v7 : String := default
    let mut v8 : Char := default
    let mut v9 : String := default
    let mut v10 : Int32 := default
    let mut v11 : String := default
    let mut v12 : Int32 := default
    let mut v13 : String := default
    let mut v14 : Int32 := default
    let mut v15 : Bool := default
    let mut v16 : Bool := default
    let mut v18 : Bool := default
    let mut v17 : Bool := default
    let mut v20 : Bool := default
    let mut v19 : Bool := default
    let mut v22 : Bool := default
    let mut v21 : Bool := default
    let mut v24 : Bool := default
    let mut v23 : Bool := default
    let mut v26 : Bool := default
    let mut v25 : Bool := default
    v0 := "é"
    v1 := (Int32.ofNat v0.utf8ByteSize)
    v2 := (Char.ofNat (v0.toUTF8.get! (spiralIdx (0 : Int32))).toNat)
    v3 := (Char.ofNat (v0.toUTF8.get! (spiralIdx (1 : Int32))).toNat)
    v4 := "x"
    v5 := (v0 ++ v4)
    v6 := (Int32.ofNat v5.utf8ByteSize)
    v7 := "ab"
    v8 := (Char.ofNat (v7.toUTF8.get! (spiralIdx (0 : Int32))).toNat)
    v9 := (← spiralStringSlice v7 (SpiralToInt.toI (0 : Int32)) (SpiralToInt.toI (0 : Int32)))
    v10 := (Int32.ofNat v9.utf8ByteSize)
    v11 := (← spiralStringSlice v7 (SpiralToInt.toI (1 : Int32)) (SpiralToInt.toI (0 : Int32)))
    v12 := (Int32.ofNat v11.utf8ByteSize)
    v13 := (← spiralStringSlice v0 (SpiralToInt.toI (0 : Int32)) (SpiralToInt.toI (1 : Int32)))
    v14 := (Int32.ofNat v13.utf8ByteSize)
    v15 := (v2 == v3)
    if v15 then
        return (1 : Int32)
    else
        v16 := (v1 == (2 : Int32))
        if v16 then
            v17 := (v8 == 'a')
            v18 := v17
        else
            v18 := false
        if v18 then
            v19 := (v6 == (3 : Int32))
            v20 := v19
        else
            v20 := false
        if v20 then
            v21 := (v10 == (1 : Int32))
            v22 := v21
        else
            v22 := false
        if v22 then
            v23 := (v12 == (0 : Int32))
            v24 := v23
        else
            v24 := false
        if v24 then
            v25 := (v14 == (2 : Int32))
            v26 := v25
        else
            v26 := false
        if v26 then
            return (0 : Int32)
        else
            return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
