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
end
deriving instance Inhabited for H0
mutual
structure H1 where
  l0 : H0
  l1 : H0
end
deriving instance Inhabited for H1
mutual
structure H2 where
  l0 : H1
  l1 : Int32
end
deriving instance Inhabited for H2
mutual
inductive U0 where
  | None : U0
  | Held : H2 → U0
end
deriving instance Inhabited for U0
mutual
structure H3 where
  l0 : U0
end
deriving instance Inhabited for H3
mutual
inductive U1 where
  | Absent : U1
  | Box : H3 → U1
  | Mark : Int32 → U1
end
deriving instance Inhabited for U1
mutual
structure H4 where
  l0 : U1
end
deriving instance Inhabited for H4
mutual
structure M5 where
  l0 : H4
end
deriving instance Inhabited for M5
def U0.spiralTag : U0 → Int32
  | .None .. => 0
  | .Held .. => 1
def U1.spiralTag : U1 → Int32
  | .Absent .. => 0
  | .Box .. => 1
  | .Mark .. => 2
mutual
partial def score_0 (p0 : U1) : IO Int32 := do
    let mut v0 : U1 := p0
    let mut v3 : H3 := default
    let mut v4 : U0 := default
    let mut v5 : H2 := default
    let mut v6 : H1 := default
    let mut v7 : Int32 := default
    let mut v8 : H0 := default
    let mut v9 : H0 := default
    let mut v10 : Int32 := default
    let mut v11 : String := default
    let mut v12 : Int32 := default
    let mut v13 : String := default
    let mut v14 : Bool := default
    let mut v16 : Bool := default
    let mut v15 : Bool := default
    let mut v18 : Bool := default
    let mut v17 : Bool := default
    let mut v20 : Bool := default
    let mut v19 : Bool := default
    let mut v22 : Bool := default
    let mut v21 : Bool := default
    let mut v1 : Int32 := default
    match v0 with
    | U1.Absent =>
        return (1 : Int32)
    | U1.Box f3 =>
        v3 := f3
        v4 := v3.l0
        match v4 with
        | U0.Held f5 =>
            v5 := f5
            v6 := v5.l0
            v7 := v5.l1
            v8 := v6.l0
            v9 := v6.l1
            v10 := v8.l0
            v11 := v8.l1
            v12 := v9.l0
            v13 := v9.l1
            v14 := (v10 == (7 : Int32))
            if v14 then
                v15 := (v11 == "hi")
                v16 := v15
            else
                v16 := false
            if v16 then
                v17 := (v12 == (4 : Int32))
                v18 := v17
            else
                v18 := false
            if v18 then
                v19 := (v13 == "yo")
                v20 := v19
            else
                v20 := false
            if v20 then
                v21 := (v7 == (2 : Int32))
                v22 := v21
            else
                v22 := false
            if v22 then
                return (0 : Int32)
            else
                return (1 : Int32)
        | U0.None =>
            return (1 : Int32)
    | U1.Mark f1 =>
        v1 := f1
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
    let mut v18 : Int32 := default
    let mut v19 : H4 := default
    let mut v20 : U1 := default
    let mut v21 : H4 := default
    let mut v22 : (IO.Ref M5) ← IO.mkRef default
    let mut v23 : (IO.Ref (Array (IO.Ref M5))) ← IO.mkRef #[]
    let mut v24 : (IO.Ref M5) ← IO.mkRef default
    let mut v25 : H4 := default
    let mut v26 : U1 := default
    let mut v27 : Int32 := default
    let mut v28 : H4 := default
    let mut v29 : U1 := default
    let mut v30 : Int32 := default
    let mut v31 : Bool := default
    let mut v33 : Bool := default
    let mut v32 : Bool := default
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
        v17 := (U1.Mark (1 : Int32))
    v18 := (3 : Int32)
    v19 := (H4.mk v17)
    v20 := (U1.Mark v18)
    v21 := (H4.mk v20)
    v22 := (← IO.mkRef (M5.mk v19))
    v23 := (← IO.mkRef (← (Array.replicate (spiralIdx (1 : Int32)) ()).mapM (fun _ => IO.mkRef default)))
    v23.modify (fun xs => xs.set! (spiralIdx (0 : Int32)) v22)
    v24 := (← spiralIndex (← v23.get) (spiralIdx (0 : Int32)))
    v25 := (← v24.get).l0
    v26 := v25.l0
    v27 := (← score_0 v26)
    v24.modify (fun r => { r with l0 := v21 })
    v28 := (← v24.get).l0
    v29 := v28.l0
    v30 := (← score_0 v29)
    v31 := (v27 == (0 : Int32))
    if v31 then
        v32 := (v30 == (1 : Int32))
        v33 := v32
    else
        v33 := false
    if v33 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
