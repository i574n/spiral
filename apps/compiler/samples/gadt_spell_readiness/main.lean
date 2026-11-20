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
inductive U1 where
  | AttackReady : Int32 → U1
end
deriving instance Inhabited for U1
mutual
inductive U0 where
  | Open : U1 → U0
  | ClosedUntil : Int32 → U0
end
deriving instance Inhabited for U0
mutual
inductive U3 where
  | HealingReady : Int32 → U3
end
deriving instance Inhabited for U3
mutual
inductive U2 where
  | Open : U3 → U2
  | ClosedUntil : Int32 → U2
end
deriving instance Inhabited for U2
mutual
inductive U5 where
  | ActionReady : Int32 → U5
end
deriving instance Inhabited for U5
mutual
inductive U4 where
  | Open : U5 → U4
  | ClosedUntil : Int32 → U4
end
deriving instance Inhabited for U4
mutual
inductive U6 where
  | Strike : U1 → U6
  | Heal : U3 → U6
  | Hold : U6
end
deriving instance Inhabited for U6
def U1.spiralTag : U1 → Int32
  | .AttackReady .. => 0
def U0.spiralTag : U0 → Int32
  | .Open .. => 0
  | .ClosedUntil .. => 1
def U3.spiralTag : U3 → Int32
  | .HealingReady .. => 1
def U2.spiralTag : U2 → Int32
  | .Open .. => 0
  | .ClosedUntil .. => 1
def U5.spiralTag : U5 → Int32
  | .ActionReady .. => 2
def U4.spiralTag : U4 → Int32
  | .Open .. => 0
  | .ClosedUntil .. => 1
def U6.spiralTag : U6 → Int32
  | .Strike .. => 0
  | .Heal .. => 1
  | .Hold .. => 2
mutual
partial def spiralMain : IO Int32 := do
    let mut v6 : U0 := default
    let mut v3 : U1 := default
    let mut v13 : Int32 := default
    let mut v10 : Int32 := default
    let mut v11 : Int32 := default
    let mut v7 : U1 := default
    let mut v9 : Int32 := default
    let mut v8 : Int32 := default
    let mut v20 : U0 := default
    let mut v17 : U1 := default
    let mut v27 : Int32 := default
    let mut v24 : Int32 := default
    let mut v25 : Int32 := default
    let mut v21 : U1 := default
    let mut v23 : Int32 := default
    let mut v22 : Int32 := default
    let mut v32 : U2 := default
    let mut v29 : U3 := default
    let mut v39 : Int32 := default
    let mut v36 : Int32 := default
    let mut v37 : Int32 := default
    let mut v33 : U3 := default
    let mut v35 : Int32 := default
    let mut v34 : Int32 := default
    let mut v45 : U4 := default
    let mut v42 : U5 := default
    let mut v52 : Int32 := default
    let mut v49 : Int32 := default
    let mut v50 : Int32 := default
    let mut v46 : U5 := default
    let mut v48 : Int32 := default
    let mut v47 : Int32 := default
    let mut v56 : U0 := default
    let mut v53 : U1 := default
    let mut v60 : U2 := default
    let mut v57 : U3 := default
    let mut v69 : U6 := default
    let mut v61 : U3 := default
    let mut v65 : Int32 := default
    let mut v63 : U1 := default
    let mut v74 : Int32 := default
    let mut v71 : U3 := default
    let mut v70 : U1 := default
    let mut v78 : U0 := default
    let mut v75 : U1 := default
    let mut v82 : U2 := default
    let mut v79 : U3 := default
    let mut v96 : U6 := default
    let mut v83 : U3 := default
    let mut v86 : Int32 := default
    let mut v84 : U1 := default
    let mut v92 : Int32 := default
    let mut v90 : U1 := default
    let mut v101 : Int32 := default
    let mut v98 : U3 := default
    let mut v97 : U1 := default
    let mut v105 : U0 := default
    let mut v102 : U1 := default
    let mut v109 : U2 := default
    let mut v106 : U3 := default
    let mut v123 : U6 := default
    let mut v110 : U3 := default
    let mut v113 : Int32 := default
    let mut v111 : U1 := default
    let mut v119 : Int32 := default
    let mut v117 : U1 := default
    let mut v128 : Int32 := default
    let mut v125 : U3 := default
    let mut v124 : U1 := default
    let v0 : Int32 := (5000 : Int32)
    let v1 : Int32 := (v0 + (2000 : Int32))
    let v2 : Bool := (decide (v0 >= (0 : Int32)))
    if v2 then
        v3 := (U1.AttackReady v0)
        v6 := (U0.Open v3)
    else
        v6 := (U0.ClosedUntil (0 : Int32))
    match v6 with
    | U0.ClosedUntil f10 =>
        v10 := f10
        v11 := (-v10)
        v13 := v11
    | U0.Open f7 =>
        v7 := f7
        match v7 with
        | U1.AttackReady f8 =>
            v8 := f8
            v9 := v8
        v13 := v9
    let v14 : Int32 := (v0 + (100 : Int32))
    let v16 : Bool := (decide (v14 >= v1))
    if v16 then
        v17 := (U1.AttackReady v14)
        v20 := (U0.Open v17)
    else
        v20 := (U0.ClosedUntil v1)
    match v20 with
    | U0.ClosedUntil f24 =>
        v24 := f24
        v25 := (-v24)
        v27 := v25
    | U0.Open f21 =>
        v21 := f21
        match v21 with
        | U1.AttackReady f22 =>
            v22 := f22
            v23 := v22
        v27 := v23
    let v28 : Bool := (decide (v14 >= (0 : Int32)))
    if v28 then
        v29 := (U3.HealingReady v14)
        v32 := (U2.Open v29)
    else
        v32 := (U2.ClosedUntil (0 : Int32))
    match v32 with
    | U2.ClosedUntil f36 =>
        v36 := f36
        v37 := (-v36)
        v39 := v37
    | U2.Open f33 =>
        v33 := f33
        match v33 with
        | U3.HealingReady f34 =>
            v34 := f34
            v35 := v34
        v39 := v35
    let v40 : Int32 := (v0 + (50 : Int32))
    let v41 : Bool := (decide (v0 >= v40))
    if v41 then
        v42 := (U5.ActionReady v0)
        v45 := (U4.Open v42)
    else
        v45 := (U4.ClosedUntil v40)
    match v45 with
    | U4.ClosedUntil f49 =>
        v49 := f49
        v50 := (-v49)
        v52 := v50
    | U4.Open f46 =>
        v46 := f46
        match v46 with
        | U5.ActionReady f47 =>
            v47 := f47
            v48 := v47
        v52 := v48
    if v2 then
        v53 := (U1.AttackReady v0)
        v56 := (U0.Open v53)
    else
        v56 := (U0.ClosedUntil (0 : Int32))
    if v2 then
        v57 := (U3.HealingReady v0)
        v60 := (U2.Open v57)
    else
        v60 := (U2.ClosedUntil (0 : Int32))
    match v60 with
    | U2.Open f61 =>
        v61 := f61
        v69 := (U6.Heal v61)
    | _ =>
        match v56 with
        | U0.ClosedUntil f65 =>
            v65 := f65
            v69 := U6.Hold
        | U0.Open f63 =>
            v63 := f63
            v69 := (U6.Strike v63)
    match v69 with
    | U6.Heal f71 =>
        v71 := f71
        v74 := (2 : Int32)
    | U6.Hold =>
        v74 := (3 : Int32)
    | U6.Strike f70 =>
        v70 := f70
        v74 := (1 : Int32)
    if v16 then
        v75 := (U1.AttackReady v14)
        v78 := (U0.Open v75)
    else
        v78 := (U0.ClosedUntil v1)
    if v28 then
        v79 := (U3.HealingReady v14)
        v82 := (U2.Open v79)
    else
        v82 := (U2.ClosedUntil (0 : Int32))
    match v82 with
    | U2.Open f83 =>
        v83 := f83
        match v78 with
        | U0.ClosedUntil f86 =>
            v86 := f86
            v96 := U6.Hold
        | U0.Open f84 =>
            v84 := f84
            v96 := (U6.Strike v84)
    | _ =>
        match v78 with
        | U0.ClosedUntil f92 =>
            v92 := f92
            v96 := U6.Hold
        | U0.Open f90 =>
            v90 := f90
            v96 := (U6.Strike v90)
    match v96 with
    | U6.Heal f98 =>
        v98 := f98
        v101 := (2 : Int32)
    | U6.Hold =>
        v101 := (3 : Int32)
    | U6.Strike f97 =>
        v97 := f97
        v101 := (1 : Int32)
    if v2 then
        v102 := (U1.AttackReady v0)
        v105 := (U0.Open v102)
    else
        v105 := (U0.ClosedUntil (0 : Int32))
    if v28 then
        v106 := (U3.HealingReady v14)
        v109 := (U2.Open v106)
    else
        v109 := (U2.ClosedUntil (0 : Int32))
    match v109 with
    | U2.Open f110 =>
        v110 := f110
        match v105 with
        | U0.ClosedUntil f113 =>
            v113 := f113
            v123 := U6.Hold
        | U0.Open f111 =>
            v111 := f111
            v123 := (U6.Strike v111)
    | _ =>
        match v105 with
        | U0.ClosedUntil f119 =>
            v119 := f119
            v123 := U6.Hold
        | U0.Open f117 =>
            v117 := f117
            v123 := (U6.Strike v117)
    match v123 with
    | U6.Heal f125 =>
        v125 := f125
        v128 := (2 : Int32)
    | U6.Hold =>
        v128 := (3 : Int32)
    | U6.Strike f124 =>
        v124 := f124
        v128 := (1 : Int32)
    let v129 : Int32 := (v13 + v27)
    let v130 : Int32 := (v129 + v39)
    let v131 : Int32 := (v130 + v52)
    let v132 : Int32 := (v131 / (100 : Int32))
    let v133 : Int32 := (v74 * (10 : Int32))
    let v134 : Int32 := (v132 + v133)
    let v135 : Int32 := (v101 * (3 : Int32))
    let v136 : Int32 := (v134 + v135)
    let v137 : Int32 := (v136 + v128)
    return v137
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
