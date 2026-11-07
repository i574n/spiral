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
    let mut v1 : (IO.Ref (Array (Int32 × Bool))) ← IO.mkRef #[]
    let mut v10 : Int32 := default
    let mut v11 : Int32 := default
    let mut v12 : Int32 := default
    let v0 : Int32 := (3 : Int32)
    v1 := (← IO.mkRef (Array.replicate (spiralIdx v0) (default : (Int32 × Bool))))
    let v2 : Int32 := (4 : Int32)
    v1.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) (v2, true))
    v1.modify (fun xs => xs.set! (spiralIdx (1 : Int32)) ((7 : Int32), false))
    v1.modify (fun xs => xs.set! (spiralIdx (2 : Int32)) ((9 : Int32), true))
    let (r1_0, r1_1) := (← spiralIndex (← v1.get) (spiralIdx (0 : Int32)))
    let v3 : Int32 := r1_0
    let v4 : Bool := r1_1
    let (r2_0, r2_1) := (← spiralIndex (← v1.get) (spiralIdx (1 : Int32)))
    let v5 : Int32 := r2_0
    let v6 : Bool := r2_1
    let v7 : Int32 := (2 : Int32)
    let (r3_0, r3_1) := (← spiralIndex (← v1.get) (spiralIdx v7))
    let v8 : Int32 := r3_0
    let v9 : Bool := r3_1
    if v4 then
        v10 := (1 : Int32)
    else
        v10 := (0 : Int32)
    if v6 then
        v11 := (10 : Int32)
    else
        v11 := (0 : Int32)
    if v9 then
        v12 := (100 : Int32)
    else
        v12 := (0 : Int32)
    let v13 : Int32 := (v3 + v5)
    let v14 : Int32 := (v13 + v8)
    let v15 : Int32 := (v14 + v10)
    let v16 : Int32 := (v15 + v11)
    let v17 : Int32 := (v16 + v12)
    return v17
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
