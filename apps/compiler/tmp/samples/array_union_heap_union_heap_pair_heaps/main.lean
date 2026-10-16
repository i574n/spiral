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
structure H0 where
  l0 : Int32
  l1 : String
structure H1 where
  l0 : H0
  l1 : H0
structure H2 where
  l0 : H1
  l1 : Int32
inductive U0 where
  | None : U0
  | Held : H2 → U0
structure H3 where
  l0 : U0
inductive U1 where
  | Absent : U1
  | Box : H3 → U1
end
deriving instance Inhabited for U0
deriving instance Inhabited for U1
deriving instance Inhabited for H0
deriving instance Inhabited for H1
deriving instance Inhabited for H2
deriving instance Inhabited for H3
def U0.spiralTag : U0 → Int32
  | .None .. => 0
  | .Held .. => 1
def U1.spiralTag : U1 → Int32
  | .Absent .. => 0
  | .Box .. => 1
mutual
partial def score_0 (p0 : U1) : IO Int32 := do
    let mut v0 : U1 := p0
    let mut v1 : H3 := default
    let mut v2 : U0 := default
    let mut v3 : H2 := default
    let mut v4 : H1 := default
    let mut v5 : Int32 := default
    let mut v6 : H0 := default
    let mut v7 : H0 := default
    let mut v8 : Int32 := default
    let mut v9 : String := default
    let mut v10 : Int32 := default
    let mut v11 : String := default
    let mut v12 : Bool := default
    let mut v14 : Bool := default
    let mut v13 : Bool := default
    let mut v16 : Bool := default
    let mut v15 : Bool := default
    let mut v18 : Bool := default
    let mut v17 : Bool := default
    let mut v20 : Bool := default
    let mut v19 : Bool := default
    match v0 with
    | U1.Absent =>
        return (1 : Int32)
    | U1.Box f1 =>
        v1 := f1
        v2 := v1.l0
        match v2 with
        | U0.Held f3 =>
            v3 := f3
            v4 := v3.l0
            v5 := v3.l1
            v6 := v4.l0
            v7 := v4.l1
            v8 := v6.l0
            v9 := v6.l1
            v10 := v7.l0
            v11 := v7.l1
            v12 := (v8 == (7 : Int32))
            if v12 then
                v13 := (v9 == "hi")
                v14 := v13
            else
                v14 := false
            if v14 then
                v15 := (v10 == (4 : Int32))
                v16 := v15
            else
                v16 := false
            if v16 then
                v17 := (v11 == "yo")
                v18 := v17
            else
                v18 := false
            if v18 then
                v19 := (v5 == (2 : Int32))
                v20 := v19
            else
                v20 := false
            if v20 then
                return (0 : Int32)
            else
                return (1 : Int32)
        | U0.None =>
            return (1 : Int32)
partial def spiralMain : IO Int32 := do
    let mut v0 : Int32 := default
    let mut v1 : String := default
    let mut v2 : H0 := default
    let mut v3 : Int32 := default
    let mut v4 : String := default
    let mut v5 : H0 := default
    let mut v6 : H1 := default
    let mut v7 : Int32 := default
    let mut v8 : H2 := default
    let mut v9 : Bool := default
    let mut v12 : U0 := default
    let mut v13 : H3 := default
    let mut v14 : Bool := default
    let mut v17 : U1 := default
    let mut v18 : (IO.Ref (Array U1)) ← IO.mkRef #[]
    let mut v19 : U1 := default
    v0 := (7 : Int32)
    v1 := "hi"
    v2 := (H0.mk v0 v1)
    v3 := (4 : Int32)
    v4 := "yo"
    v5 := (H0.mk v3 v4)
    v6 := (H1.mk v2 v5)
    v7 := (2 : Int32)
    v8 := (H2.mk v6 v7)
    v9 := true
    if v9 then
        v12 := (U0.Held v8)
    else
        v12 := U0.None
    v13 := (H3.mk v12)
    v14 := true
    if v14 then
        v17 := (U1.Box v13)
    else
        v17 := U1.Absent
    v18 := (← IO.mkRef (Array.replicate (spiralIdx (1 : Int32)) (default : U1)))
    v18.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v17)
    v19 := (← spiralIndex (← v18.get) (spiralIdx (0 : Int32)))
    return (← score_0 v19)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
