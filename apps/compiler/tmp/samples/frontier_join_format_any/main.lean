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
structure M0 where
  l0 : String
end
deriving instance Inhabited for M0
mutual
partial def method3 (p0 : (IO.Ref M0)) (p1 : String) : IO Unit := do
    let mut v0 : (IO.Ref M0) := p0
    let mut v1 : String := p1
    let mut v2 : String := default
    let mut v3 : String := default
    v2 := (← v0.get).l0
    v3 := (v2 ++ v1)
    v0.modify (fun r => { r with l0 := v3 })
    return ()
partial def format_real_2 (p0 : Int32) : IO String := do
    let mut v0 : Int32 := p0
    let mut v1 : String := default
    let mut v2 : (IO.Ref M0) ← IO.mkRef default
    let mut v3 : String := default
    let mut v4 : String := default
    v1 := ""
    v2 := (← IO.mkRef (M0.mk v1))
    v3 := toString v0 
    let _ := (← method3 v2 v3)
    v4 := (← v2.get).l0
    return v4
partial def method1 : IO String := do
    let mut v0 : String := default
    let mut v1 : String := default
    let mut v2 : String := default
    let mut v3 : Int32 := default
    let mut v4 : String := default
    let mut v5 : String := default
    let mut v6 : String := default
    let mut v7 : String := default
    v0 := "Some"
    v1 := "("
    v2 := (v0 ++ v1)
    v3 := (1 : Int32)
    v4 := (← format_real_2 v3)
    v5 := (v2 ++ v4)
    v6 := ")"
    v7 := (v5 ++ v6)
    return v7
partial def method0 : IO String := do
    let mut v0 : String := default
    let mut v1 : String := default
    let mut v2 : String := default
    v0 := (← method1)
    v1 := "x: "
    v2 := (v1 ++ v0)
    return v2
partial def spiralMain : IO Int32 := do
    let mut v0 : String := default
    let mut v1 : Bool := default
    v0 := (← method0)
    v1 := (v0 == "")
    if v1 then
        return (1 : Int32)
    else
        return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
