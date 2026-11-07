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
partial def method5 (p0 : Int32) (p1 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : Int32 := p1
    let v2 : Int32 := (v0 * v1)
    let v3 : Int32 := (v2 + (5 : Int32))
    let v4 : Int32 := (v3 / (3 : Int32))
    return v4
partial def method4 (p0 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let v1 : Int32 := (4 : Int32)
    let v2 : Int32 := (4 : Int32)
    let v3 : Int32 := (← method5 v1 v2)
    let v4 : Int32 := (v0 + v3)
    let v5 : Int32 := (v4 - (7 : Int32))
    return v5
partial def method6 (p0 : UInt32) : IO Bool := do
    let mut v0 : UInt32 := p0
    let v1 : UInt32 := (v0 + (5 : UInt32))
    let v2 : UInt32 := (v1 % (4 : UInt32))
    let v3 : Bool := (v2 == (0 : UInt32))
    return v3
partial def method3 (p0 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let v1 : UInt32 := (7 : UInt32)
    let v2 : Bool := (← method6 v1)
    if v2 then
        return (← method4 v0)
    else
        return (1 : Int32)
partial def method7 (p0 : String) (p1 : String) : IO Bool := do
    let mut v0 : String := p0
    let mut v1 : String := p1
    let v2 : Bool := (v0 == v1)
    return v2
partial def method2 (p0 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let v1 : String := "spiral"
    let v2 : Bool := (← method7 v1 v1)
    if v2 then
        return (← method3 v0)
    else
        return (1 : Int32)
partial def method8 (p0 : Float32) : IO (Bool × Float32 × Int32) := do
    let mut v0 : Float32 := p0
    let v1 : Bool := (decide (v0 >= (3.5 : Float32)))
    return (v1, v0, (7 : Int32))
partial def method9 (p0 : Bool) (p1 : Float32) (p2 : Int32) : IO Int32 := do
    let mut v0 : Bool := p0
    let mut v1 : Float32 := p1
    let mut v2 : Int32 := p2
    let mut v3 : Bool := default
    let mut v4 : Int32 := default
    if v0 then
        v3 := (decide (v1 >= (3.5 : Float32)))
        if v3 then
            v4 := (v2 - (7 : Int32))
            return v4
        else
            return (1 : Int32)
    else
        return (2 : Int32)
partial def method1 (p0 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let v1 : Float32 := (4.0 : Float32)
    let (r1_0, r1_1, r1_2) := (← method8 v1)
    let v2 : Bool := r1_0
    let v3 : Float32 := r1_1
    let v4 : Int32 := r1_2
    let v5 : Int32 := (← method9 v2 v3 v4)
    let v6 : Int32 := (v0 + v5)
    return (← method2 v6)
partial def method10 (p0 : Int32) : IO (Int32 × Int32 × Bool) := do
    let mut v0 : Int32 := p0
    let v1 : Int32 := (v0 + (2 : Int32))
    let v2 : Bool := (decide (v0 > (0 : Int32)))
    return (v0, v1, v2)
partial def method11 (p0 : Int32) (p1 : Int32) (p2 : Bool) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : Int32 := p1
    let mut v2 : Bool := p2
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    if v2 then
        v3 := (v0 + v1)
        v4 := (v3 - (4 : Int32))
        return v4
    else
        return (1 : Int32)
partial def method0 (p0 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let v1 : Int32 := (1 : Int32)
    let (r2_0, r2_1, r2_2) := (← method10 v1)
    let v2 : Int32 := r2_0
    let v3 : Int32 := r2_1
    let v4 : Bool := r2_2
    let v5 : Int32 := (← method11 v2 v3 v4)
    let v6 : Int32 := (v0 + v5)
    return (← method1 v6)
partial def spiralMain : IO Int32 := do
    let v0 : Int32 := (0 : Int32)
    return (← method0 v0)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
