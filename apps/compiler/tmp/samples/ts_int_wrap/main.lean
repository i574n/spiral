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
    let mut v0 : UInt8 := default
    let mut v1 : UInt8 := default
    let mut v2 : UInt32 := default
    let mut v3 : UInt64 := default
    let mut v4 : Int8 := default
    let mut v5 : Int8 := default
    let mut v6 : Int32 := default
    let mut v7 : Int32 := default
    let mut v8 : Int64 := default
    let mut v9 : Int32 := default
    let mut v10 : Int64 := default
    let mut v11 : UInt8 := default
    let mut v12 : Bool := default
    let mut v13 : UInt32 := default
    let mut v14 : Bool := default
    let mut v15 : UInt32 := default
    let mut v16 : Bool := default
    let mut v17 : UInt64 := default
    let mut v18 : Bool := default
    let mut v19 : UInt64 := default
    let mut v20 : Bool := default
    let mut v21 : UInt64 := default
    let mut v22 : Bool := default
    let mut v23 : Int8 := default
    let mut v24 : Bool := default
    let mut v25 : Int32 := default
    let mut v26 : Bool := default
    let mut v27 : Int32 := default
    let mut v28 : Bool := default
    let mut v29 : Int64 := default
    let mut v30 : Bool := default
    let mut v31 : UInt32 := default
    let mut v32 : Bool := default
    let mut v33 : Int32 := default
    let mut v34 : Bool := default
    v0 := (250 : UInt8)
    v1 := (10 : UInt8)
    v2 := (4294967295 : UInt32)
    v3 := (18446744073709551615 : UInt64)
    v4 := (127 : Int8)
    v5 := (1 : Int8)
    v6 := (7 : Int32)
    v7 := (2 : Int32)
    v8 := (9223372036854775807 : Int64)
    v9 := (-v6)
    v10 := (-v8)
    v11 := (v0 + v1)
    v12 := (v11 == (4 : UInt8))
    if v12 then
        v13 := (v2 + (1 : UInt32))
        v14 := (v13 == (0 : UInt32))
        if v14 then
            v15 := (v2 * v2)
            v16 := (v15 == (1 : UInt32))
            if v16 then
                v17 := (v3 + (1 : UInt64))
                v18 := (v17 == (0 : UInt64))
                if v18 then
                    v19 := (v3 * v3)
                    v20 := (v19 == (1 : UInt64))
                    if v20 then
                        v21 := (v3 / (3 : UInt64))
                        v22 := (v21 == (6148914691236517205 : UInt64))
                        if v22 then
                            v23 := (v4 + v5)
                            v24 := (decide (v23 < (0 : Int8)))
                            if v24 then
                                v25 := (v9 / v7)
                                v26 := (v25 == (-3 : Int32))
                                if v26 then
                                    v27 := (v9 % v7)
                                    v28 := (v27 == (-1 : Int32))
                                    if v28 then
                                        v29 := (v10 % (10 : Int64))
                                        v30 := (v29 == (-7 : Int64))
                                        if v30 then
                                            v31 := (v2 >>> (UInt32.ofInt (SpiralToInt.toI (28 : Int32))))
                                            v32 := (v31 == (15 : UInt32))
                                            if v32 then
                                                v33 := (v9 >>> (1 : Int32))
                                                v34 := (v33 == (-4 : Int32))
                                                if v34 then
                                                    return (0 : Int32)
                                                else
                                                    return (12 : Int32)
                                            else
                                                return (11 : Int32)
                                        else
                                            return (10 : Int32)
                                    else
                                        return (9 : Int32)
                                else
                                    return (8 : Int32)
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
