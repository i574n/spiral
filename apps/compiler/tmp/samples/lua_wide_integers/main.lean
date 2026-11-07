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
partial def lcg_0 (p0 : UInt64) (p1 : UInt64) (p2 : Int32) (p3 : UInt64) : IO UInt64 := do
    let mut v0 : UInt64 := p0
    let mut v1 : UInt64 := p1
    let mut v2 : Int32 := p2
    let mut v3 : UInt64 := p3
    let mut v4 : Bool := default
    let mut v5 : Int32 := default
    let mut v6 : UInt64 := default
    let mut v7 : UInt64 := default
    repeat
        v4 := (v2 == (0 : Int32))
        if v4 then
            return v3
        else
            v5 := (v2 - (1 : Int32))
            v6 := (v3 * v0)
            v7 := (v6 + v1)
            v2 := v5
            v3 := v7
            continue
partial def spiralMain : IO Int32 := do
    let mut v24 : Int32 := default
    let v0 : UInt64 := (42 : UInt64)
    let v1 : UInt64 := (6364136223846793005 : UInt64)
    let v2 : UInt64 := (1442695040888963407 : UInt64)
    let v3 : Int32 := (1000 : Int32)
    let v4 : UInt64 := (← lcg_0 v1 v2 v3 v0)
    IO.print "lcg "
    IO.print (toString v4)
    IO.print "\n"
    let v5 : Int64 := (9223372036854775807 : Int64)
    let v6 : Int64 := (-9223372036854775807 : Int64)
    let v7 : UInt64 := (18446744073709551615 : UInt64)
    let v8 : Int64 := (v6 - (1 : Int64))
    let v9 : UInt64 := (v7 + (2 : UInt64))
    IO.print "max "
    IO.print (toString v5)
    IO.print " min "
    IO.print (toString v8)
    IO.print " wrap "
    IO.print (toString v9)
    IO.print "\n"
    let v10 : Int64 := (-9007199254740993 : Int64)
    let v11 : Int64 := (7 : Int64)
    let v12 : Int64 := (v10 / v11)
    let v13 : Int64 := (v10 % v11)
    IO.print "div "
    IO.print (toString v12)
    IO.print " mod "
    IO.print (toString v13)
    IO.print "\n"
    let v14 : Int64 := (v10 >>> (Int64.ofInt (SpiralToInt.toI (3 : Int32))))
    let v15 : UInt64 := (v4 >>> (UInt64.ofInt (SpiralToInt.toI (60 : Int32))))
    IO.print "shl "
    IO.print (toString (4611686018427387904 : Int64))
    IO.print " shr "
    IO.print (toString v14)
    IO.print " ushr "
    IO.print (toString v15)
    IO.print "\n"
    let v16 : UInt64 := (v4 &&& (18446744069414584320 : UInt64))
    let v17 : Int64 := (v10 ||| (255 : Int64))
    let v18 : UInt64 := (v4 ^^^ v1)
    IO.print "and "
    IO.print (toString v16)
    IO.print " or "
    IO.print (toString v17)
    IO.print " xor "
    IO.print (toString v18)
    IO.print "\n"
    let v19 : Float := (1E+18 : Float)
    let v20 : Int64 := (Int64.ofInt (SpiralToInt.toI v19))
    let v21 : UInt32 := (UInt32.ofInt (SpiralToInt.toI v4))
    let v22 : Float := (Float.ofInt (SpiralToInt.toI v10))
    let v23 : Bool := (decide (v22 < (0.0 : Float)))
    if v23 then
        v24 := (1 : Int32)
    else
        v24 := (0 : Int32)
    IO.print "conv "
    IO.print (toString v20)
    IO.print " "
    IO.print (toString v21)
    IO.print " "
    IO.print (toString v24)
    IO.print "\n"
    let v25 : Bool := (decide (v4 > v1))
    if v25 then
        return (1 : Int32)
    else
        return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
