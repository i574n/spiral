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
inductive U0 where
  | North : U0
  | East : U0
  | South : U0
  | West : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .North .. => 0
  | .East .. => 1
  | .South .. => 2
  | .West .. => 3
mutual
partial def spiralMain : IO Int32 := do
    let mut v8 : U0 := default
    let mut v16 : U0 := default
    let mut v18 : Bool := default
    let mut v19 : Int32 := default
    let mut v21 : Int32 := default
    let mut v23 : Int32 := default
    let mut v27 : Int32 := default
    let v0 : U0 := U0.North
    match v0 with
    | U0.East =>
        v8 := U0.South
    | U0.North =>
        v8 := U0.East
    | U0.South =>
        v8 := U0.West
    | U0.West =>
        v8 := U0.North
    match v8 with
    | U0.East =>
        v16 := U0.South
    | U0.North =>
        v16 := U0.East
    | U0.South =>
        v16 := U0.West
    | U0.West =>
        v16 := U0.North
    let v17 : U0 := U0.South
    match v16, v17 with
    | U0.East, U0.East =>
        v18 := true
    | U0.North, U0.North =>
        v18 := true
    | U0.South, U0.South =>
        v18 := true
    | U0.West, U0.West =>
        v18 := true
    | _, _ =>
        v18 := false
    if v18 then
        v19 := (100 : Int32)
    else
        v19 := (0 : Int32)
    match v0 with
    | U0.East =>
        v21 := (2 : Int32)
    | U0.North =>
        v21 := (1 : Int32)
    | _ =>
        v21 := (7 : Int32)
    match v8 with
    | U0.East =>
        v23 := (2 : Int32)
    | U0.North =>
        v23 := (1 : Int32)
    | _ =>
        v23 := (7 : Int32)
    let v24 : Int32 := (v23 * (3 : Int32))
    let v25 : Int32 := (v21 + v24)
    match v16 with
    | U0.East =>
        v27 := (2 : Int32)
    | U0.North =>
        v27 := (1 : Int32)
    | _ =>
        v27 := (7 : Int32)
    let v28 : Int32 := (v27 * (9 : Int32))
    let v29 : Int32 := (v25 + v28)
    let v30 : Int32 := (v29 + v19)
    return v30
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
