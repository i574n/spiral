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
partial def method1 (p0 : Int32) (p1 : (IO.Ref (Array Int32))) (p2 : (IO.Ref (Array Int32))) : IO (IO.Ref (Array Int32)) := do
    let mut v0 : Int32 := p0
    let mut v1 : (IO.Ref (Array Int32)) := p1
    let mut v2 : (IO.Ref (Array Int32)) := p2
    let mut v3 : Int32 := default
    let mut v4 : Bool := default
    repeat
        v3 := (v0 - (1 : Int32))
        v4 := (v3 == (0 : Int32))
        if v4 then
            return v2
        else
            let t3 := v3
            let t2 := v2
            let t1 := v1
            v0 := t3
            v1 := t2
            v2 := t1
            continue
partial def method0 (p0 : (IO.Ref (Array Int32))) (p1 : (IO.Ref (Array Int32))) : IO (IO.Ref (Array Int32)) := do
    let mut v0 : (IO.Ref (Array Int32)) := p0
    let mut v1 : (IO.Ref (Array Int32)) := p1
    let mut v2 : Int32 := default
    let mut v3 : Bool := default
    v2 := (1000000 : Int32)
    v3 := (v2 == (0 : Int32))
    if v3 then
        return v0
    else
        return (← method1 v2 v0 v1)
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v2 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v3 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v4 : Int32 := default
    let mut v5 : Bool := default
    let mut v6 : Int32 := default
    let mut v7 : Bool := default
    v0 := (1 : Int32)
    v1 := (← IO.mkRef (Array.replicate (spiralIdx v0) (default : Int32)))
    v2 := (← IO.mkRef (Array.replicate (spiralIdx v0) (default : Int32)))
    v1.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) (7 : Int32))
    v2.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) (11 : Int32))
    v3 := (← method0 v1 v2)
    v3.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) (13 : Int32))
    v4 := (← spiralIndex (← v1.get) (spiralIdx (0 : Int32)))
    v5 := (v4 == (13 : Int32))
    if v5 then
        v6 := (← spiralIndex (← v2.get) (spiralIdx (0 : Int32)))
        v7 := (v6 == (11 : Int32))
        if v7 then
            return (0 : Int32)
        else
            return (2 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
