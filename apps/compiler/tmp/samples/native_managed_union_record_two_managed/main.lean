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
  | Empty : U0
  | Item : String → (IO.Ref (Array Int32)) → U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Empty .. => 0
  | .Item .. => 1
mutual
partial def closure0 (p0 : Int32) : IO U0 := do
    let mut v0 : Int32 := p0
    let mut v1 : Bool := default
    let mut v3 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v4 : Int32 := default
    let mut v5 : String := default
    v1 := (v0 == (0 : Int32))
    if v1 then
        return U0.Empty
    else
        v3 := (← IO.mkRef (Array.replicate (spiralIdx (2 : Int32)) (default : Int32)))
        v3.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v0)
        v4 := (v0 + (1 : Int32))
        v3.modify (fun xs => xs.set! (spiralIdx (1 : Int32)) v4)
        v5 := "hi"
        return (U0.Item v5 v3)
partial def method0 (p0 : (Int32 → IO U0)) : IO U0 := do
    let mut v0 : (Int32 → IO U0) := p0
    return (← v0 (0 : Int32))
partial def method1 (p0 : (Int32 → IO U0)) : IO U0 := do
    let mut v0 : (Int32 → IO U0) := p0
    return (← v0 (4 : Int32))
partial def spiralMain : IO Int32 := do
    let mut v0 : (Int32 → IO U0) := default
    let mut v1 : U0 := default
    let mut v12 : Int32 := default
    let mut v2 : String := default
    let mut v3 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    let mut v6 : Int32 := default
    let mut v7 : Int32 := default
    let mut v8 : Int32 := default
    let mut v9 : Int32 := default
    let mut v10 : Int32 := default
    let mut v13 : U0 := default
    let mut v24 : Int32 := default
    let mut v14 : String := default
    let mut v15 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v16 : Int32 := default
    let mut v17 : Int32 := default
    let mut v18 : Int32 := default
    let mut v19 : Int32 := default
    let mut v20 : Int32 := default
    let mut v21 : Int32 := default
    let mut v22 : Int32 := default
    let mut v25 : Int32 := default
    let mut v26 : Int32 := default
    v0 := closure0
    v1 := (← method0 v0)
    match v1 with
    | U0.Empty =>
        v12 := (3 : Int32)
    | U0.Item f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (Int32.ofNat v2.utf8ByteSize)
        v5 := (Int32.ofNat (← v3.get).size)
        v6 := (v4 + v5)
        v7 := (← spiralIndex (← v3.get) (spiralIdx (0 : Int32)))
        v8 := (v6 + v7)
        v9 := (← spiralIndex (← v3.get) (spiralIdx (1 : Int32)))
        v10 := (v8 + v9)
        v12 := v10
    v13 := (← method1 v0)
    match v13 with
    | U0.Empty =>
        v24 := (3 : Int32)
    | U0.Item f14 f15 =>
        v14 := f14
        v15 := f15
        v16 := (Int32.ofNat v14.utf8ByteSize)
        v17 := (Int32.ofNat (← v15.get).size)
        v18 := (v16 + v17)
        v19 := (← spiralIndex (← v15.get) (spiralIdx (0 : Int32)))
        v20 := (v18 + v19)
        v21 := (← spiralIndex (← v15.get) (spiralIdx (1 : Int32)))
        v22 := (v20 + v21)
        v24 := v22
    v25 := (v12 + v24)
    v26 := (v25 + (26 : Int32))
    return v26
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
