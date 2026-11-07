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
  | Circle : Int32 → U0
  | Square : Int32 → U0
  | Tri : Int32 → U0
  | Dot : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Circle .. => 0
  | .Square .. => 1
  | .Tri .. => 2
  | .Dot .. => 3
mutual
partial def pick_0 (p0 : Int32) : IO U0 := do
    let mut v0 : Int32 := p0
    let mut v3 : Bool := default
    let mut v5 : Bool := default
    let v1 : Bool := (v0 == (0 : Int32))
    if v1 then
        return (U0.Circle (5 : Int32))
    else
        v3 := (v0 == (1 : Int32))
        if v3 then
            return (U0.Square (4 : Int32))
        else
            v5 := (v0 == (2 : Int32))
            if v5 then
                return (U0.Tri (7 : Int32))
            else
                return U0.Dot
partial def measure_1 (p0 : U0) (p1 : Int32) : IO Int32 := do
    let mut v0 : U0 := p0
    let mut v1 : Int32 := p1
    let mut v2 : Int32 := default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : Bool := default
    let mut v6 : Int32 := default
    let mut v7 : Int32 := default
    let mut v9 : Int32 := default
    let mut v10 : Int32 := default
    match v0 with
    | U0.Circle f2 =>
        v2 := f2
        v3 := (v2 * (3 : Int32))
        return v3
    | _ =>
        v4 := (v1 * v1)
        v5 := (decide (v4 > (3 : Int32)))
        match v0 with
        | U0.Dot =>
            return v4
        | U0.Square f6 =>
            v6 := f6
            if v5 then
                v7 := (v6 * v6)
                return v7
            else
                return v6
        | U0.Tri f9 =>
            v9 := f9
            if v5 then
                v10 := (v9 * (2 : Int32))
                return v10
            else
                return v9
        | _ =>
            spiralFail "union unbox: unreachable case"
partial def measure_tri_2 (p0 : U0) (p1 : Int32) : IO Int32 := do
    let mut v0 : U0 := p0
    let mut v1 : Int32 := p1
    let mut v2 : Int32 := default
    let mut v3 : Int32 := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    let mut v6 : Int32 := default
    match v0 with
    | U0.Circle f2 =>
        v2 := f2
        return v2
    | U0.Dot =>
        return (0 : Int32)
    | U0.Square f3 =>
        v3 := f3
        return v3
    | _ =>
        v4 := (v1 + (2 : Int32))
        match v0 with
        | U0.Tri f5 =>
            v5 := f5
            v6 := (v5 * v4)
            return v6
        | _ =>
            spiralFail "union unbox: unreachable case"
partial def spiralMain : IO Int32 := do
    let v0 : Int32 := (0 : Int32)
    let v1 : U0 := (← pick_0 v0)
    let v2 : Int32 := (← measure_1 v1 v0)
    let v3 : Int32 := (v0 + (1 : Int32))
    let v4 : U0 := (← pick_0 v3)
    let v5 : Int32 := (← measure_1 v4 v3)
    let v6 : Int32 := (v2 + v5)
    let v7 : Int32 := (v0 + (2 : Int32))
    let v8 : U0 := (← pick_0 v7)
    let v9 : Int32 := (← measure_1 v8 v7)
    let v10 : Int32 := (v6 + v9)
    let v11 : Int32 := (v0 + (3 : Int32))
    let v12 : U0 := (← pick_0 v11)
    let v13 : Int32 := (← measure_1 v12 v11)
    let v14 : Int32 := (v10 + v13)
    let v15 : U0 := (← pick_0 v7)
    let v16 : Int32 := (← measure_tri_2 v15 v0)
    let v17 : Int32 := (v14 + v16)
    let v18 : U0 := (← pick_0 v0)
    let v19 : Int32 := (← measure_tri_2 v18 v0)
    let v20 : Int32 := (v17 + v19)
    return v20
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
