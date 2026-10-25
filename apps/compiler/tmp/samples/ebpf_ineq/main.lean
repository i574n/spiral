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
    let v0 : Int32 := (-3 : Int32)
    let v1 : Int32 := (-4 : Int32)
    let v2 : Int32 := (-3 : Int32)
    let v3 : UInt32 := (4294967295 : UInt32)
    let v4 : UInt32 := (0 : UInt32)
    let v5 : UInt32 := (4294967295 : UInt32)
    let v6 : Float32 := (-1.5 : Float32)
    let v7 : Float32 := (-0.5 : Float32)
    let v8 : Float32 := (-1.5 : Float32)
    let v9 : Bool := (v0 != v1)
    let v10 : Bool := (v0 != v2)
    let v11 : Bool := (v3 != v4)
    let v12 : Bool := (v3 != v5)
    let v13 : Bool := (v6 != v7)
    let v14 : Bool := (v6 != v8)
    let v15 : Bool := (v9 && v11)
    let v16 : Bool := (v15 && v13)
    if v16 then
        if v10 then
            return (1 : Int32)
        else
            if v12 then
                return (2 : Int32)
            else
                if v14 then
                    return (3 : Int32)
                else
                    return (0 : Int32)
    else
        return (4 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
