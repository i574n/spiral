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
partial def fill_0 (p0 : Int32) (p1 : (IO.Ref (Array Int32))) (p2 : Int32) : IO Unit := do
    let mut v0 : Int32 := p0
    let mut v1 : (IO.Ref (Array Int32)) := p1
    let mut v2 : Int32 := p2
    let mut v3 : Bool := default
    let mut v4 : Int32 := default
    repeat
        v3 := (decide (v2 < v0))
        if v3 then
            v1.modify (fun xs => xs.set! (spiralIdx v2) v2)
            v4 := (v2 + (1 : Int32))
            v2 := v4
            continue
        else
            return ()
partial def spiralMain : IO Int32 := do
    let mut v1 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let v0 : Int32 := (6 : Int32)
    v1 := (← IO.mkRef (Array.replicate (spiralIdx (6 : Int32)) (default : Int32)))
    let v2 : Int32 := (0 : Int32)
    let _ := (← fill_0 v0 v1 v2)
    let v3 : Int32 := (← spiralIndex (← v1.get) (spiralIdx (5 : Int32)))
    let v4 : Int32 := (v3 + (2 : Int32))
    return v4
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
