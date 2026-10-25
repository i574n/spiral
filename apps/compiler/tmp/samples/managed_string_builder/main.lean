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
partial def method2 (p0 : Int32) (p1 : String) (p2 : String) : IO String := do
    let mut v0 : Int32 := p0
    let mut v1 : String := p1
    let mut v2 : String := p2
    let mut v3 : Int32 := default
    let mut v4 : String := default
    let mut v5 : Bool := default
    let mut v6 : Int32 := default
    let mut v7 : Bool := default
    let mut v10 : String := default
    let mut v8 : String := default
    let mut v9 : String := default
    repeat
        v3 := (v0 - (1 : Int32))
        v4 := (v1 ++ v2)
        v5 := (v3 == (0 : Int32))
        if v5 then
            return v4
        else
            v6 := (v3 % (2 : Int32))
            v7 := (v6 == (0 : Int32))
            if v7 then
                v8 := "ab"
                v10 := v8
            else
                v9 := "c"
                v10 := v9
            let t3 := v3
            let t4 := v4
            let t10 := v10
            v0 := t3
            v1 := t4
            v2 := t10
            continue
partial def method1 (p0 : Int32) (p1 : String) : IO String := do
    let mut v0 : Int32 := p0
    let mut v1 : String := p1
    let mut v2 : Int32 := default
    let mut v3 : String := default
    let mut v4 : Bool := default
    let mut v5 : Int32 := default
    let mut v6 : Bool := default
    let mut v9 : String := default
    let mut v7 : String := default
    let mut v8 : String := default
    v2 := (v0 - (1 : Int32))
    v3 := ("" ++ v1)
    v4 := (v2 == (0 : Int32))
    if v4 then
        return v3
    else
        v5 := (v2 % (2 : Int32))
        v6 := (v5 == (0 : Int32))
        if v6 then
            v7 := "ab"
            v9 := v7
        else
            v8 := "c"
            v9 := v8
        return (← method2 v2 v3 v9)
partial def method0 : IO String := do
    let mut v0 : Int32 := default
    let mut v1 : Bool := default
    let mut v2 : String := default
    let mut v3 : Int32 := default
    let mut v4 : Bool := default
    let mut v7 : String := default
    let mut v5 : String := default
    let mut v6 : String := default
    v0 := (4 : Int32)
    v1 := (v0 == (0 : Int32))
    if v1 then
        v2 := ""
        return v2
    else
        v3 := (v0 % (2 : Int32))
        v4 := (v3 == (0 : Int32))
        if v4 then
            v5 := "ab"
            v7 := v5
        else
            v6 := "c"
            v7 := v6
        return (← method1 v0 v7)
partial def spiralMain : IO Int32 := do
    let mut v0 : String := default
    let mut v1 : Int32 := default
    let mut v2 : Bool := default
    let mut v3 : Char := default
    let mut v4 : Bool := default
    let mut v5 : Char := default
    let mut v6 : Bool := default
    v0 := (← method0)
    v1 := (Int32.ofNat v0.utf8ByteSize)
    v2 := (v1 == (6 : Int32))
    if v2 then
        v3 := (Char.ofNat (v0.toUTF8.get! (spiralIdx (0 : Int32))).toNat)
        v4 := (v3 == 'a')
        if v4 then
            v5 := (Char.ofNat (v0.toUTF8.get! (spiralIdx (5 : Int32))).toNat)
            v6 := (v5 == 'c')
            if v6 then
                return (0 : Int32)
            else
                return (1 : Int32)
        else
            return (2 : Int32)
    else
        return (3 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
