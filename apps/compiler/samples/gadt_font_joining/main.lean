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
    let v0 : Int32 := (0 : Int32)
    let v1 : Int32 := (v0 + (1 : Int32))
    let v2 : Int32 := (v0 + (2 : Int32))
    let v3 : Int32 := (v0 + (3 : Int32))
    let v4 : Int32 := (v0 + (4 : Int32))
    let v5 : Int32 := (v0 + (10 : Int32))
    let v6 : Int32 := (v0 + (11 : Int32))
    let v7 : Int32 := (v1 + v2)
    let v8 : Int32 := (v7 + v3)
    let v9 : Int32 := (v8 + v4)
    let v10 : Int32 := (v9 + v5)
    let v11 : Int32 := (v10 + v6)
    let v12 : Int32 := (v0 + (20 : Int32))
    let v13 : Int32 := (v12 + v12)
    let v14 : Int32 := (v0 + (30 : Int32))
    let v15 : Int32 := (v13 + v14)
    let v16 : Int32 := (v0 + (40 : Int32))
    let v17 : Int32 := (v15 + v16)
    let v18 : Int32 := (v11 + v17)
    let v19 : Int32 := (v18 + (1 : Int32))
    return v19
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
