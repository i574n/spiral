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
private unsafe def spiralBoxUnsafe {α : Type} (x : α) : NonScalar := unsafeCast x
@[implemented_by spiralBoxUnsafe] opaque spiralBox {α : Type} (x : α) : NonScalar
private unsafe def spiralUnboxUnsafe {α : Type} [Inhabited α] (x : NonScalar) : α := unsafeCast x
@[implemented_by spiralUnboxUnsafe] opaque spiralUnbox {α : Type} [Inhabited α] (x : NonScalar) : α
mutual
inductive U0 where
  | Cons : UInt64 → NonScalar → U0
  | Nil : U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Cons .. => 0
  | .Nil .. => 1
mutual
partial def closure79 (_ : Unit) : IO U0 := do
    return U0.Nil
partial def closure78 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure79
    return (U0.Cons (1 : UInt64) (spiralBox v0))
partial def closure77 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure78
    return (U0.Cons (2 : UInt64) (spiralBox v0))
partial def closure76 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure77
    return (U0.Cons (3 : UInt64) (spiralBox v0))
partial def closure75 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure76
    return (U0.Cons (4 : UInt64) (spiralBox v0))
partial def closure74 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure75
    return (U0.Cons (5 : UInt64) (spiralBox v0))
partial def closure73 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure74
    return (U0.Cons (6 : UInt64) (spiralBox v0))
partial def closure72 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure73
    return (U0.Cons (7 : UInt64) (spiralBox v0))
partial def closure71 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure72
    return (U0.Cons (8 : UInt64) (spiralBox v0))
partial def closure70 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure71
    return (U0.Cons (9 : UInt64) (spiralBox v0))
partial def closure69 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure70
    return (U0.Cons (10 : UInt64) (spiralBox v0))
partial def closure68 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure69
    return (U0.Cons (11 : UInt64) (spiralBox v0))
partial def closure67 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure68
    return (U0.Cons (12 : UInt64) (spiralBox v0))
partial def closure66 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure67
    return (U0.Cons (13 : UInt64) (spiralBox v0))
partial def closure65 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure66
    return (U0.Cons (14 : UInt64) (spiralBox v0))
partial def closure64 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure65
    return (U0.Cons (15 : UInt64) (spiralBox v0))
partial def closure63 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure64
    return (U0.Cons (16 : UInt64) (spiralBox v0))
partial def closure62 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure63
    return (U0.Cons (17 : UInt64) (spiralBox v0))
partial def closure61 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure62
    return (U0.Cons (18 : UInt64) (spiralBox v0))
partial def closure60 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure61
    return (U0.Cons (19 : UInt64) (spiralBox v0))
partial def closure59 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure60
    return (U0.Cons (20 : UInt64) (spiralBox v0))
partial def closure58 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure59
    return (U0.Cons (21 : UInt64) (spiralBox v0))
partial def closure57 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure58
    return (U0.Cons (22 : UInt64) (spiralBox v0))
partial def closure56 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure57
    return (U0.Cons (23 : UInt64) (spiralBox v0))
partial def closure55 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure56
    return (U0.Cons (24 : UInt64) (spiralBox v0))
partial def closure54 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure55
    return (U0.Cons (25 : UInt64) (spiralBox v0))
partial def closure53 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure54
    return (U0.Cons (26 : UInt64) (spiralBox v0))
partial def closure52 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure53
    return (U0.Cons (27 : UInt64) (spiralBox v0))
partial def closure51 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure52
    return (U0.Cons (28 : UInt64) (spiralBox v0))
partial def closure50 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure51
    return (U0.Cons (29 : UInt64) (spiralBox v0))
partial def closure49 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure50
    return (U0.Cons (30 : UInt64) (spiralBox v0))
partial def closure48 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure49
    return (U0.Cons (31 : UInt64) (spiralBox v0))
partial def closure47 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure48
    return (U0.Cons (32 : UInt64) (spiralBox v0))
partial def closure46 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure47
    return (U0.Cons (33 : UInt64) (spiralBox v0))
partial def closure45 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure46
    return (U0.Cons (34 : UInt64) (spiralBox v0))
partial def closure44 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure45
    return (U0.Cons (35 : UInt64) (spiralBox v0))
partial def closure43 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure44
    return (U0.Cons (36 : UInt64) (spiralBox v0))
partial def closure42 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure43
    return (U0.Cons (37 : UInt64) (spiralBox v0))
partial def closure41 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure42
    return (U0.Cons (38 : UInt64) (spiralBox v0))
partial def closure40 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure41
    return (U0.Cons (39 : UInt64) (spiralBox v0))
partial def closure39 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure40
    return (U0.Cons (40 : UInt64) (spiralBox v0))
partial def closure38 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure39
    return (U0.Cons (41 : UInt64) (spiralBox v0))
partial def closure37 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure38
    return (U0.Cons (42 : UInt64) (spiralBox v0))
partial def closure36 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure37
    return (U0.Cons (43 : UInt64) (spiralBox v0))
partial def closure35 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure36
    return (U0.Cons (44 : UInt64) (spiralBox v0))
partial def closure34 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure35
    return (U0.Cons (45 : UInt64) (spiralBox v0))
partial def closure33 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure34
    return (U0.Cons (46 : UInt64) (spiralBox v0))
partial def closure32 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure33
    return (U0.Cons (47 : UInt64) (spiralBox v0))
partial def closure31 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure32
    return (U0.Cons (48 : UInt64) (spiralBox v0))
partial def closure30 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure31
    return (U0.Cons (49 : UInt64) (spiralBox v0))
partial def closure29 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure30
    return (U0.Cons (50 : UInt64) (spiralBox v0))
partial def closure28 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure29
    return (U0.Cons (51 : UInt64) (spiralBox v0))
partial def closure27 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure28
    return (U0.Cons (52 : UInt64) (spiralBox v0))
partial def closure26 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure27
    return (U0.Cons (53 : UInt64) (spiralBox v0))
partial def closure25 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure26
    return (U0.Cons (54 : UInt64) (spiralBox v0))
partial def closure24 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure25
    return (U0.Cons (55 : UInt64) (spiralBox v0))
partial def closure23 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure24
    return (U0.Cons (56 : UInt64) (spiralBox v0))
partial def closure22 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure23
    return (U0.Cons (57 : UInt64) (spiralBox v0))
partial def closure21 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure22
    return (U0.Cons (58 : UInt64) (spiralBox v0))
partial def closure20 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure21
    return (U0.Cons (59 : UInt64) (spiralBox v0))
partial def closure19 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure20
    return (U0.Cons (60 : UInt64) (spiralBox v0))
partial def closure18 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure19
    return (U0.Cons (61 : UInt64) (spiralBox v0))
partial def closure17 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure18
    return (U0.Cons (62 : UInt64) (spiralBox v0))
partial def closure16 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure17
    return (U0.Cons (63 : UInt64) (spiralBox v0))
partial def closure15 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure16
    return (U0.Cons (64 : UInt64) (spiralBox v0))
partial def closure14 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure15
    return (U0.Cons (65 : UInt64) (spiralBox v0))
partial def closure13 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure14
    return (U0.Cons (66 : UInt64) (spiralBox v0))
partial def closure12 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure13
    return (U0.Cons (67 : UInt64) (spiralBox v0))
partial def closure11 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure12
    return (U0.Cons (68 : UInt64) (spiralBox v0))
partial def closure10 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure11
    return (U0.Cons (69 : UInt64) (spiralBox v0))
partial def closure9 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure10
    return (U0.Cons (70 : UInt64) (spiralBox v0))
partial def closure8 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure9
    return (U0.Cons (71 : UInt64) (spiralBox v0))
partial def closure7 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure8
    return (U0.Cons (72 : UInt64) (spiralBox v0))
partial def closure6 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure7
    return (U0.Cons (73 : UInt64) (spiralBox v0))
partial def closure5 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure6
    return (U0.Cons (74 : UInt64) (spiralBox v0))
partial def closure4 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure5
    return (U0.Cons (75 : UInt64) (spiralBox v0))
partial def closure3 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure4
    return (U0.Cons (76 : UInt64) (spiralBox v0))
partial def closure2 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure3
    return (U0.Cons (77 : UInt64) (spiralBox v0))
partial def closure1 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure2
    return (U0.Cons (78 : UInt64) (spiralBox v0))
partial def closure0 (_ : Unit) : IO U0 := do
    let v0 : (Unit → IO U0) := closure1
    return (U0.Cons (79 : UInt64) (spiralBox v0))
partial def loop_0 (p0 : U0) (p1 : UInt64) : IO UInt64 := do
    let mut v0 : U0 := p0
    let mut v1 : UInt64 := p1
    let mut v2 : UInt64 := default
    let mut v3 : (Unit → IO U0) := default
    let mut v4 : U0 := default
    let mut v5 : UInt64 := default
    match v0 with
    | U0.Cons f2 f3 =>
        v2 := f2
        v3 := spiralUnbox f3
        v4 := (← v3 ())
        v5 := (v1 + v2)
        return (← loop_0 v4 v5)
    | U0.Nil =>
        return v1
partial def spiralMain : IO Int32 := do
    let v0 : UInt64 := (80 : UInt64)
    let v1 : (Unit → IO U0) := closure0
    let v2 : U0 := (U0.Cons v0 (spiralBox v1))
    let v3 : UInt64 := (0 : UInt64)
    let v4 : UInt64 := (← loop_0 v2 v3)
    let v5 : UInt64 := (v4 % (200 : UInt64))
    let v6 : Int32 := (Int32.ofInt (SpiralToInt.toI v5))
    return v6
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
