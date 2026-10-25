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
    let mut v10 : Int32 := default
    let mut v11 : Bool := default
    let mut v12 : Int32 := default
    let mut v13 : Bool := default
    let mut v14 : Int32 := default
    let mut v15 : Bool := default
    let mut v16 : UInt32 := default
    let mut v17 : Bool := default
    let mut v18 : UInt32 := default
    let mut v19 : Bool := default
    let mut v20 : UInt32 := default
    let mut v21 : Bool := default
    let v0 : Int32 := (7 : Int32)
    let v1 : Int32 := (2 : Int32)
    let v2 : UInt32 := (4294967295 : UInt32)
    let v3 : Int32 := (-v0)
    let v4 : Int32 := (-3 : Int32)
    let v5 : Int32 := (-12 : Int32)
    let v6 : Int32 := (-4 : Int32)
    let v7 : Int32 := (-1 : Int32)
    let v8 : Int32 := (v3 / v1)
    let v9 : Bool := (v8 == v4)
    if v9 then
        v10 := (v3 % v1)
        v11 := (v10 == v7)
        if v11 then
            v12 := (v3 >>> (1 : Int32))
            v13 := (v12 == v6)
            if v13 then
                v14 := (v4 <<< (2 : Int32))
                v15 := (v14 == v5)
                if v15 then
                    v16 := (v2 + (1 : UInt32))
                    v17 := (v16 == (0 : UInt32))
                    if v17 then
                        v18 := (v2 * v2)
                        v19 := (v18 == (1 : UInt32))
                        if v19 then
                            v20 := (v2 >>> (UInt32.ofInt (SpiralToInt.toI (28 : Int32))))
                            v21 := (v20 == (15 : UInt32))
                            if v21 then
                                return (0 : Int32)
                            else
                                return (7 : Int32)
                        else
                            return (6 : Int32)
                    else
                        return (5 : Int32)
                else
                    return (4 : Int32)
            else
                return (3 : Int32)
        else
            return (2 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
