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
    let mut v23 : Bool := default
    let mut v22 : Bool := default
    let mut v26 : Bool := default
    let mut v24 : Bool := default
    let mut v25 : Bool := default
    let mut v27 : Bool := default
    let mut v29 : Bool := default
    let mut v28 : Bool := default
    let mut v31 : Bool := default
    let mut v30 : Bool := default
    let mut v33 : Bool := default
    let mut v32 : Bool := default
    let mut v34 : Bool := default
    let mut v36 : Bool := default
    let mut v35 : Bool := default
    let mut v37 : Bool := default
    let mut v39 : Bool := default
    let mut v38 : Bool := default
    let mut v41 : Bool := default
    let mut v40 : Bool := default
    let mut v42 : Bool := default
    let mut v44 : Bool := default
    let mut v43 : Bool := default
    let v0 : Int32 := (-2147483648 : Int32)
    let v1 : UInt32 := (4294967295 : UInt32)
    let v2 : Int32 := (-1 : Int32)
    let v3 : Float32 := (0.0 : Float32)
    let v4 : Float32 := (1.9 : Float32)
    let v5 : Float32 := (2.9 : Float32)
    let v6 : UInt32 := (4294967294 : UInt32)
    let v7 : UInt32 := (5 : UInt32)
    let v8 : UInt32 := (0 : UInt32)
    let v9 : Float32 := (v3 - v4)
    let v10 : UInt32 := (UInt32.ofInt (SpiralToInt.toI v0))
    let v11 : Int32 := (Int32.ofInt (SpiralToInt.toI v10))
    let v12 : Int32 := (Int32.ofInt (SpiralToInt.toI v1))
    let v13 : UInt32 := (UInt32.ofInt (SpiralToInt.toI v2))
    let v14 : Int32 := (Int32.ofInt (SpiralToInt.toI v9))
    let v15 : Int32 := (Int32.ofInt (SpiralToInt.toI v5))
    let v16 : UInt32 := (v10 / (2 : UInt32))
    let v17 : UInt32 := (v6 / (2 : UInt32))
    let v18 : UInt32 := (v7 % (3 : UInt32))
    let v19 : UInt32 := (~~~v8)
    let v20 : UInt32 := (v1 >>> (UInt32.ofInt (SpiralToInt.toI (31 : Int32))))
    let v21 : Bool := (decide (v0 < (-1 : Int32)))
    if v21 then
        v22 := (decide (v0 <= v0))
        v23 := v22
    else
        v23 := false
    if v23 then
        v24 := (decide (v0 > (0 : Int32)))
        v25 := (v24 == false)
        v26 := v25
    else
        v26 := false
    if v26 then
        v27 := (decide (v10 > (1 : UInt32)))
        if v27 then
            v28 := (v11 == v0)
            v29 := v28
        else
            v29 := false
        if v29 then
            v30 := (v12 == v2)
            v31 := v30
        else
            v31 := false
        if v31 then
            v32 := (v13 == v1)
            v33 := v32
        else
            v33 := false
        if v33 then
            v34 := (v14 == v2)
            if v34 then
                v35 := (v15 == (2 : Int32))
                v36 := v35
            else
                v36 := false
            if v36 then
                v37 := (v16 == (1073741824 : UInt32))
                if v37 then
                    v38 := (v17 == (2147483647 : UInt32))
                    v39 := v38
                else
                    v39 := false
                if v39 then
                    v40 := (v18 == (2 : UInt32))
                    v41 := v40
                else
                    v41 := false
                if v41 then
                    v42 := (v19 == v1)
                    if v42 then
                        v43 := (v20 == (1 : UInt32))
                        v44 := v43
                    else
                        v44 := false
                    if v44 then
                        return (0 : Int32)
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
