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
  l0 : Int32
structure M1 where
  l0 : Int32
inductive U0 where
  | c0 : U0
  | c1 : Int32 → U0 → U0
structure M2 where
  l0 : U0
end
deriving instance Inhabited for U0
deriving instance Inhabited for M0
deriving instance Inhabited for M1
deriving instance Inhabited for M2
def U0.spiralTag : U0 → Int32
  | .c0 .. => 0
  | .c1 .. => 1
mutual
partial def method0 (p0 : (IO.Ref M0)) : IO Bool := do
    let mut v0 : (IO.Ref M0) := p0
    let mut v1 : Int32 := default
    let mut v2 : Bool := default
    v1 := (← v0.get).l0
    v2 := (decide (v1 < (3 : Int32)))
    return v2
partial def method1 (p0 : (IO.Ref M1)) : IO Bool := do
    let mut v0 : (IO.Ref M1) := p0
    let mut v1 : Int32 := default
    let mut v2 : Bool := default
    v1 := (← v0.get).l0
    v2 := (decide (v1 < (4 : Int32)))
    return v2
partial def spiralMain : IO Int32 := do
    let mut v0 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v1 : (IO.Ref M0) ← IO.mkRef default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    let mut v6 : (IO.Ref M1) ← IO.mkRef default
    let mut v7 : (IO.Ref M1) ← IO.mkRef default
    let mut v8 : U0 := default
    let mut v9 : (IO.Ref M2) ← IO.mkRef default
    let mut v11 : Int32 := default
    let mut v12 : Int32 := default
    let mut v13 : Bool := default
    let mut v14 : Int32 := default
    let mut v15 : Int32 := default
    let mut v16 : U0 := default
    let mut v17 : U0 := default
    let mut v18 : Int32 := default
    let mut v19 : U0 := default
    let mut v38 : Int32 := default
    let mut v20 : Int32 := default
    let mut v21 : U0 := default
    let mut v22 : Int32 := default
    let mut v23 : U0 := default
    let mut v24 : Int32 := default
    let mut v25 : U0 := default
    let mut v26 : Int32 := default
    let mut v27 : U0 := default
    let mut v28 : Int32 := default
    let mut v29 : Int32 := default
    let mut v30 : Int32 := default
    let mut v31 : Int32 := default
    let mut v32 : Int32 := default
    let mut v33 : Int32 := default
    let mut v39 : Int32 := default
    let mut v40 : Int32 := default
    let mut v41 : Int32 := default
    let mut v42 : Int32 := default
    let mut v43 : Int32 := default
    let mut v44 : Int32 := default
    v0 := (← IO.mkRef (Array.replicate (spiralIdx (3 : Int32)) (default : Int32)))
    v1 := (← IO.mkRef (M0.mk (0 : Int32)))
    repeat
        if !(← method0 v1) then break
        v3 := (← v1.get).l0
        v4 := (v3 * (5 : Int32))
        v0.modify (fun xs => xs.set! (spiralIdx v3) v4)
        v5 := (v3 + (1 : Int32))
        v1.modify (fun r => { r with l0 := v5 })
    v6 := (← IO.mkRef (M1.mk (0 : Int32)))
    v7 := (← IO.mkRef (M1.mk (0 : Int32)))
    v8 := U0.c0
    v9 := (← IO.mkRef (M2.mk v8))
    repeat
        if !(← method1 v6) then break
        v11 := (← v6.get).l0
        v12 := (v11 % (2 : Int32))
        v13 := (v12 == (1 : Int32))
        if v13 then
            v14 := (← v7.get).l0
            v15 := (v14 + (1 : Int32))
            v7.modify (fun r => { r with l0 := v15 })
        else
            pure ()
        v16 := (← v9.get).l0
        v17 := (U0.c1 v11 v16)
        v9.modify (fun r => { r with l0 := v17 })
        v18 := (v11 + (1 : Int32))
        v6.modify (fun r => { r with l0 := v18 })
    v19 := (← v9.get).l0
    match v19 with
    | U0.c1 f20 f21 =>
        v20 := f20
        v21 := f21
        match v21 with
        | U0.c1 f22 f23 =>
            v22 := f22
            v23 := f23
            match v23 with
            | U0.c1 f24 f25 =>
                v24 := f24
                v25 := f25
                match v25 with
                | U0.c1 f26 f27 =>
                    v26 := f26
                    v27 := f27
                    match v27 with
                    | U0.c0 =>
                        v28 := (v20 * (64 : Int32))
                        v29 := (v22 * (16 : Int32))
                        v30 := (v28 + v29)
                        v31 := (v24 * (4 : Int32))
                        v32 := (v30 + v31)
                        v33 := (v32 + v26)
                        v38 := v33
                    | _ =>
                        v38 := (-1 : Int32)
                | _ =>
                    v38 := (-1 : Int32)
            | _ =>
                v38 := (-1 : Int32)
        | _ =>
            v38 := (-1 : Int32)
    | _ =>
        v38 := (-1 : Int32)
    v39 := (← v7.get).l0
    v40 := (v38 + v39)
    v41 := (← spiralIndex (← v0.get) (spiralIdx (2 : Int32)))
    v42 := (v40 + v41)
    v43 := (← spiralIndex (← v0.get) (spiralIdx (1 : Int32)))
    v44 := (v42 - v43)
    return v44
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
