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
  | BitZero : U0
  | BitOne : U0
end
deriving instance Inhabited for U0
mutual
inductive U1 where
  | RegexEmpty : U1
  | RegexEpsilon : U1
  | RegexChar : U0 → U1
  | RegexAlt : U1 → U1 → U1
  | RegexCat : U1 → U1 → U1
  | RegexStar : U1 → U1
end
deriving instance Inhabited for U1
mutual
inductive U2 where
  | InputEmpty : U2
  | InputCons : U0 → U2 → U2
end
deriving instance Inhabited for U2
mutual
inductive U3 where
  | SymbolLess : U3
  | SymbolSame : U3
  | SymbolGreater : U3
end
deriving instance Inhabited for U3
mutual
inductive U4 where
  | Nullable : U4
  | NonNullable : U4
end
deriving instance Inhabited for U4
mutual
inductive U5 where
  | TriA : U5
  | TriB : U5
  | TriC : U5
end
deriving instance Inhabited for U5
mutual
inductive U6 where
  | RegexEmpty : U6
  | RegexEpsilon : U6
  | RegexChar : U5 → U6
  | RegexAlt : U6 → U6 → U6
  | RegexCat : U6 → U6 → U6
  | RegexStar : U6 → U6
end
deriving instance Inhabited for U6
mutual
inductive U7 where
  | InputEmpty : U7
  | InputCons : U5 → U7 → U7
end
deriving instance Inhabited for U7
def U0.spiralTag : U0 → Int32
  | .BitZero .. => 0
  | .BitOne .. => 1
def U1.spiralTag : U1 → Int32
  | .RegexEmpty .. => 0
  | .RegexEpsilon .. => 1
  | .RegexChar .. => 2
  | .RegexAlt .. => 3
  | .RegexCat .. => 4
  | .RegexStar .. => 5
def U2.spiralTag : U2 → Int32
  | .InputEmpty .. => 0
  | .InputCons .. => 1
def U3.spiralTag : U3 → Int32
  | .SymbolLess .. => 0
  | .SymbolSame .. => 1
  | .SymbolGreater .. => 2
def U4.spiralTag : U4 → Int32
  | .Nullable .. => 0
  | .NonNullable .. => 1
def U5.spiralTag : U5 → Int32
  | .TriA .. => 0
  | .TriB .. => 1
  | .TriC .. => 2
def U6.spiralTag : U6 → Int32
  | .RegexEmpty .. => 0
  | .RegexEpsilon .. => 1
  | .RegexChar .. => 2
  | .RegexAlt .. => 3
  | .RegexCat .. => 4
  | .RegexStar .. => 5
def U7.spiralTag : U7 → Int32
  | .InputEmpty .. => 0
  | .InputCons .. => 1
mutual
partial def random_bit_input_1 (p0 : UInt64) (p1 : Int32) (p2 : U2) : IO (U2 × UInt64) := do
    let mut v0 : UInt64 := p0
    let mut v1 : Int32 := p1
    let mut v2 : U2 := p2
    let mut v3 : Bool := default
    let mut v4 : UInt64 := default
    let mut v5 : UInt64 := default
    let mut v6 : UInt64 := default
    let mut v7 : Int32 := default
    let mut v8 : UInt64 := default
    let mut v9 : UInt64 := default
    let mut v10 : Bool := default
    let mut v13 : U0 := default
    let mut v11 : U0 := default
    let mut v12 : U0 := default
    let mut v14 : U2 := default
    repeat
        v3 := (decide ((0 : Int32) < v1))
        if v3 then
            v4 := (v0 * (1103515245 : UInt64))
            v5 := (v4 + (12345 : UInt64))
            v6 := (v5 &&& (2147483647 : UInt64))
            v7 := (v1 - (1 : Int32))
            v8 := (v6 >>> (UInt64.ofInt (SpiralToInt.toI (16 : Int32))))
            v9 := (v8 &&& (1 : UInt64))
            v10 := (v9 == (0 : UInt64))
            if v10 then
                v11 := U0.BitZero
                v13 := v11
            else
                v12 := U0.BitOne
                v13 := v12
            v14 := (U2.InputCons v13 v2)
            v0 := v6
            v1 := v7
            v2 := v14
            continue
        else
            return (v2, v0)
partial def run_2 (p0 : Int32) (p1 : U2) : IO Bool := do
    let mut v0 : Int32 := p0
    let mut v1 : U2 := p1
    let mut v4 : U0 := default
    let mut v5 : U2 := default
    let mut v6 : Bool := default
    let mut v19 : Int32 := default
    let mut v10 : U3 := default
    let mut v11 : Bool := default
    let mut v16 : U3 := default
    let mut v17 : Bool := default
    let mut v2 : Bool := default
    let mut v3 : Bool := default
    match v1 with
    | U2.InputCons f4 f5 =>
        v4 := f4
        v5 := f5
        v6 := (v0 == (0 : Int32))
        if v6 then
            match v4 with
            | U0.BitOne =>
                v10 := U3.SymbolGreater
            | U0.BitZero =>
                v10 := U3.SymbolSame
            match v10 with
            | U3.SymbolSame =>
                v11 := true
            | _ =>
                v11 := false
            if v11 then
                v19 := (1 : Int32)
            else
                v19 := (0 : Int32)
        else
            match v4 with
            | U0.BitOne =>
                v16 := U3.SymbolGreater
            | U0.BitZero =>
                v16 := U3.SymbolSame
            match v16 with
            | U3.SymbolSame =>
                v17 := true
            | _ =>
                v17 := false
            if v17 then
                v19 := (1 : Int32)
            else
                v19 := (0 : Int32)
        return (← run_2 v19 v5)
    | U2.InputEmpty =>
        v2 := (v0 == (0 : Int32))
        v3 := (v2 == false)
        return v3
partial def regex_compare_8 (p0 : U1) (p1 : U1) : IO U3 := do
    let mut v0 : U1 := p0
    let mut v1 : U1 := p1
    let mut v53 : U1 := default
    let mut v54 : U1 := default
    let mut v55 : U1 := default
    let mut v56 : U1 := default
    let mut v57 : U3 := default
    let mut v28 : U1 := default
    let mut v29 : U1 := default
    let mut v34 : U1 := default
    let mut v35 : U1 := default
    let mut v36 : U3 := default
    let mut v32 : U0 := default
    let mut v10 : U0 := default
    let mut v13 : U0 := default
    let mut v44 : U1 := default
    let mut v45 : U1 := default
    let mut v46 : U1 := default
    let mut v48 : U1 := default
    match v0 with
    | U1.RegexAlt f53 f54 =>
        v53 := f53
        v54 := f54
        match v1 with
        | U1.RegexAlt f55 f56 =>
            v55 := f55
            v56 := f56
            v57 := (← regex_compare_8 v53 v55)
            match v57 with
            | U3.SymbolSame =>
                return (← regex_compare_8 v54 v56)
            | _ =>
                return v57
        | _ =>
            return U3.SymbolGreater
    | U1.RegexCat f28 f29 =>
        v28 := f28
        v29 := f29
        match v1 with
        | U1.RegexCat f34 f35 =>
            v34 := f34
            v35 := f35
            v36 := (← regex_compare_8 v28 v34)
            match v36 with
            | U3.SymbolSame =>
                return (← regex_compare_8 v29 v35)
            | _ =>
                return v36
        | U1.RegexChar f32 =>
            v32 := f32
            return U3.SymbolGreater
        | U1.RegexEmpty =>
            return U3.SymbolGreater
        | U1.RegexEpsilon =>
            return U3.SymbolGreater
        | _ =>
            return U3.SymbolLess
    | U1.RegexChar f10 =>
        v10 := f10
        match v1 with
        | U1.RegexChar f13 =>
            v13 := f13
            match v10 with
            | U0.BitOne =>
                match v13 with
                | U0.BitOne =>
                    return U3.SymbolSame
                | U0.BitZero =>
                    return U3.SymbolGreater
            | U0.BitZero =>
                match v13 with
                | U0.BitOne =>
                    return U3.SymbolLess
                | U0.BitZero =>
                    return U3.SymbolSame
        | U1.RegexEmpty =>
            return U3.SymbolGreater
        | U1.RegexEpsilon =>
            return U3.SymbolGreater
        | _ =>
            return U3.SymbolLess
    | U1.RegexEmpty =>
        match v1 with
        | U1.RegexEmpty =>
            return U3.SymbolSame
        | _ =>
            return U3.SymbolLess
    | U1.RegexEpsilon =>
        match v1 with
        | U1.RegexEmpty =>
            return U3.SymbolGreater
        | U1.RegexEpsilon =>
            return U3.SymbolSame
        | _ =>
            return U3.SymbolLess
    | U1.RegexStar f44 =>
        v44 := f44
        match v1 with
        | U1.RegexAlt f45 f46 =>
            v45 := f45
            v46 := f46
            return U3.SymbolLess
        | U1.RegexStar f48 =>
            v48 := f48
            return (← regex_compare_8 v44 v48)
        | _ =>
            return U3.SymbolGreater
partial def alt_insert_sorted_7 (p0 : U1) (p1 : U1) : IO U1 := do
    let mut v0 : U1 := p0
    let mut v1 : U1 := p1
    let mut v2 : U1 := default
    let mut v3 : U1 := default
    let mut v4 : U3 := default
    let mut v6 : U1 := default
    let mut v11 : U3 := default
    match v1 with
    | U1.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← regex_compare_8 v0 v2)
        match v4 with
        | U3.SymbolGreater =>
            v6 := (← alt_insert_sorted_7 v0 v3)
            return (U1.RegexAlt v2 v6)
        | U3.SymbolLess =>
            return (U1.RegexAlt v0 v1)
        | U3.SymbolSame =>
            return v1
    | U1.RegexEmpty =>
        return v0
    | _ =>
        v11 := (← regex_compare_8 v0 v1)
        match v11 with
        | U3.SymbolGreater =>
            return (U1.RegexAlt v1 v0)
        | U3.SymbolLess =>
            return (U1.RegexAlt v0 v1)
        | U3.SymbolSame =>
            return v1
partial def make_alt_6 (p0 : U1) (p1 : U1) : IO U1 := do
    let mut v0 : U1 := p0
    let mut v1 : U1 := p1
    let mut v2 : U1 := default
    let mut v3 : U1 := default
    let mut v4 : U1 := default
    match v0 with
    | U1.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← alt_insert_sorted_7 v2 v1)
        return (← make_alt_6 v3 v4)
    | U1.RegexEmpty =>
        return v1
    | _ =>
        return (← alt_insert_sorted_7 v0 v1)
partial def regex_equal_10 (p0 : U1) (p1 : U1) : IO Bool := do
    let mut v0 : U1 := p0
    let mut v1 : U1 := p1
    let mut v18 : U1 := default
    let mut v19 : U1 := default
    let mut v20 : U1 := default
    let mut v21 : U1 := default
    let mut v22 : Bool := default
    let mut v26 : U1 := default
    let mut v27 : U1 := default
    let mut v28 : U1 := default
    let mut v29 : U1 := default
    let mut v30 : Bool := default
    let mut v4 : U0 := default
    let mut v5 : U0 := default
    let mut v15 : U3 := default
    let mut v34 : U1 := default
    let mut v35 : U1 := default
    match v0 with
    | U1.RegexAlt f18 f19 =>
        v18 := f18
        v19 := f19
        match v1 with
        | U1.RegexAlt f20 f21 =>
            v20 := f20
            v21 := f21
            v22 := (← regex_equal_10 v18 v20)
            if v22 then
                return (← regex_equal_10 v19 v21)
            else
                return false
        | _ =>
            return false
    | U1.RegexCat f26 f27 =>
        v26 := f26
        v27 := f27
        match v1 with
        | U1.RegexCat f28 f29 =>
            v28 := f28
            v29 := f29
            v30 := (← regex_equal_10 v26 v28)
            if v30 then
                return (← regex_equal_10 v27 v29)
            else
                return false
        | _ =>
            return false
    | U1.RegexChar f4 =>
        v4 := f4
        match v1 with
        | U1.RegexChar f5 =>
            v5 := f5
            match v4 with
            | U0.BitOne =>
                match v5 with
                | U0.BitOne =>
                    v15 := U3.SymbolSame
                | U0.BitZero =>
                    v15 := U3.SymbolGreater
            | U0.BitZero =>
                match v5 with
                | U0.BitOne =>
                    v15 := U3.SymbolLess
                | U0.BitZero =>
                    v15 := U3.SymbolSame
            match v15 with
            | U3.SymbolSame =>
                return true
            | _ =>
                return false
        | _ =>
            return false
    | U1.RegexEmpty =>
        match v1 with
        | U1.RegexEmpty =>
            return true
        | _ =>
            return false
    | U1.RegexEpsilon =>
        match v1 with
        | U1.RegexEpsilon =>
            return true
        | _ =>
            return false
    | U1.RegexStar f34 =>
        v34 := f34
        match v1 with
        | U1.RegexStar f35 =>
            v35 := f35
            return (← regex_equal_10 v34 v35)
        | _ =>
            return false
partial def make_cat_9 (p0 : U1) (p1 : U1) : IO U1 := do
    let mut v0 : U1 := p0
    let mut v1 : U1 := p1
    let mut v12 : U1 := default
    let mut v13 : U1 := default
    let mut v14 : U1 := default
    let mut v4 : U1 := default
    let mut v5 : U1 := default
    let mut v6 : Bool := default
    match v0 with
    | U1.RegexEmpty =>
        return U1.RegexEmpty
    | _ =>
        match v1 with
        | U1.RegexEmpty =>
            return U1.RegexEmpty
        | _ =>
            match v0 with
            | U1.RegexEpsilon =>
                return v1
            | _ =>
                match v1 with
                | U1.RegexEpsilon =>
                    return v0
                | _ =>
                    match v0 with
                    | U1.RegexCat f12 f13 =>
                        v12 := f12
                        v13 := f13
                        v14 := (← make_cat_9 v13 v1)
                        return (U1.RegexCat v12 v14)
                    | U1.RegexStar f4 =>
                        v4 := f4
                        match v1 with
                        | U1.RegexStar f5 =>
                            v5 := f5
                            v6 := (← regex_equal_10 v4 v5)
                            if v6 then
                                return (U1.RegexStar v4)
                            else
                                return (U1.RegexCat v0 v1)
                        | _ =>
                            return (U1.RegexCat v0 v1)
                    | _ =>
                        return (U1.RegexCat v0 v1)
partial def make_star_11 (p0 : U1) : IO U1 := do
    let mut v0 : U1 := p0
    let mut v3 : U1 := default
    match v0 with
    | U1.RegexEmpty =>
        return U1.RegexEpsilon
    | U1.RegexEpsilon =>
        return U1.RegexEpsilon
    | U1.RegexStar f3 =>
        v3 := f3
        return (U1.RegexStar v3)
    | _ =>
        return (U1.RegexStar v0)
partial def normalize_5 (p0 : U1) : IO U1 := do
    let mut v0 : U1 := p0
    let mut v5 : U1 := default
    let mut v6 : U1 := default
    let mut v7 : U1 := default
    let mut v8 : U1 := default
    let mut v10 : U1 := default
    let mut v11 : U1 := default
    let mut v12 : U1 := default
    let mut v13 : U1 := default
    let mut v3 : U0 := default
    let mut v15 : U1 := default
    let mut v16 : U1 := default
    match v0 with
    | U1.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← normalize_5 v5)
        v8 := (← normalize_5 v6)
        return (← make_alt_6 v7 v8)
    | U1.RegexCat f10 f11 =>
        v10 := f10
        v11 := f11
        v12 := (← normalize_5 v10)
        v13 := (← normalize_5 v11)
        return (← make_cat_9 v12 v13)
    | U1.RegexChar f3 =>
        v3 := f3
        return (U1.RegexChar v3)
    | U1.RegexEmpty =>
        return U1.RegexEmpty
    | U1.RegexEpsilon =>
        return U1.RegexEpsilon
    | U1.RegexStar f15 =>
        v15 := f15
        v16 := (← normalize_5 v15)
        return (← make_star_11 v16)
partial def nullable_13 (p0 : U1) : IO U4 := do
    let mut v0 : U1 := p0
    let mut v5 : U1 := default
    let mut v6 : U1 := default
    let mut v7 : U4 := default
    let mut v8 : U4 := default
    let mut v16 : U1 := default
    let mut v17 : U1 := default
    let mut v18 : U4 := default
    let mut v19 : U4 := default
    let mut v3 : U0 := default
    let mut v25 : U1 := default
    match v0 with
    | U1.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← nullable_13 v5)
        v8 := (← nullable_13 v6)
        match v7 with
        | U4.Nullable =>
            return U4.Nullable
        | _ =>
            match v8 with
            | U4.Nullable =>
                return U4.Nullable
            | _ =>
                match v7 with
                | U4.NonNullable =>
                    match v8 with
                    | U4.NonNullable =>
                        return U4.NonNullable
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | _ =>
                    spiralFail "union unbox: unreachable case"
    | U1.RegexCat f16 f17 =>
        v16 := f16
        v17 := f17
        v18 := (← nullable_13 v16)
        v19 := (← nullable_13 v17)
        match v18 with
        | U4.Nullable =>
            match v19 with
            | U4.Nullable =>
                return U4.Nullable
            | _ =>
                return U4.NonNullable
        | _ =>
            return U4.NonNullable
    | U1.RegexChar f3 =>
        v3 := f3
        return U4.NonNullable
    | U1.RegexEmpty =>
        return U4.NonNullable
    | U1.RegexEpsilon =>
        return U4.Nullable
    | U1.RegexStar f25 =>
        v25 := f25
        return U4.Nullable
partial def derivative_12 (p0 : U1) (p1 : U0) : IO U1 := do
    let mut v0 : U1 := p0
    let mut v1 : U0 := p1
    let mut v19 : U1 := default
    let mut v20 : U1 := default
    let mut v21 : U1 := default
    let mut v22 : U1 := default
    let mut v24 : U1 := default
    let mut v25 : U1 := default
    let mut v26 : U4 := default
    let mut v31 : U1 := default
    let mut v27 : U1 := default
    let mut v28 : U1 := default
    let mut v29 : U1 := default
    let mut v4 : U0 := default
    let mut v14 : U3 := default
    let mut v15 : Bool := default
    let mut v35 : U1 := default
    let mut v36 : U1 := default
    let mut v37 : U1 := default
    match v0 with
    | U1.RegexAlt f19 f20 =>
        v19 := f19
        v20 := f20
        v21 := (← derivative_12 v19 v1)
        v22 := (← derivative_12 v20 v1)
        return (← make_alt_6 v21 v22)
    | U1.RegexCat f24 f25 =>
        v24 := f24
        v25 := f25
        v26 := (← nullable_13 v24)
        match v26 with
        | U4.NonNullable =>
            v31 := (← derivative_12 v24 v1)
            return (← make_cat_9 v31 v25)
        | U4.Nullable =>
            v27 := (← derivative_12 v24 v1)
            v28 := (← make_cat_9 v27 v25)
            v29 := (← derivative_12 v25 v1)
            return (← make_alt_6 v28 v29)
    | U1.RegexChar f4 =>
        v4 := f4
        match v4 with
        | U0.BitOne =>
            match v1 with
            | U0.BitOne =>
                v14 := U3.SymbolSame
            | U0.BitZero =>
                v14 := U3.SymbolGreater
        | U0.BitZero =>
            match v1 with
            | U0.BitOne =>
                v14 := U3.SymbolLess
            | U0.BitZero =>
                v14 := U3.SymbolSame
        match v14 with
        | U3.SymbolSame =>
            v15 := true
        | _ =>
            v15 := false
        if v15 then
            return U1.RegexEpsilon
        else
            return U1.RegexEmpty
    | U1.RegexEmpty =>
        return U1.RegexEmpty
    | U1.RegexEpsilon =>
        return U1.RegexEmpty
    | U1.RegexStar f35 =>
        v35 := f35
        v36 := (← derivative_12 v35 v1)
        v37 := (← make_star_11 v35)
        return (← make_cat_9 v36 v37)
partial def canonical_derivative_4 (p0 : U1) (p1 : U0) : IO U1 := do
    let mut v0 : U1 := p0
    let mut v1 : U0 := p1
    let v2 : U1 := (← normalize_5 v0)
    let v3 : U1 := (← derivative_12 v2 v1)
    return (← normalize_5 v3)
partial def accepts_3 (p0 : U1) (p1 : U2) : IO Bool := do
    let mut v0 : U1 := p0
    let mut v1 : U2 := p1
    let mut v6 : U0 := default
    let mut v7 : U2 := default
    let mut v8 : U1 := default
    let mut v2 : U1 := default
    let mut v3 : U4 := default
    match v1 with
    | U2.InputCons f6 f7 =>
        v6 := f6
        v7 := f7
        v8 := (← canonical_derivative_4 v0 v6)
        return (← accepts_3 v8 v7)
    | U2.InputEmpty =>
        v2 := (← normalize_5 v0)
        v3 := (← nullable_13 v2)
        match v3 with
        | U4.NonNullable =>
            return false
        | U4.Nullable =>
            return true
partial def loop_0 (p0 : Int32) (p1 : U1) (p2 : Int32) (p3 : UInt64) (p4 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : U1 := p1
    let mut v2 : Int32 := p2
    let mut v3 : UInt64 := p3
    let mut v4 : Int32 := p4
    let mut v5 : Bool := default
    let mut v6 : U2 := default
    let mut v7 : U2 := default
    let mut v8 : UInt64 := default
    let mut v9 : Int32 := default
    let mut v10 : Bool := default
    let mut v11 : Bool := default
    let mut v13 : Bool := default
    let mut v12 : Bool := default
    let mut v14 : Int32 := default
    let mut v16 : Int32 := default
    let mut v15 : Int32 := default
    repeat
        v5 := (decide ((0 : Int32) < v2))
        if v5 then
            v6 := U2.InputEmpty
            let (r1_0, r1_1) := (← random_bit_input_1 v3 v0 v6)
            v7 := r1_0
            v8 := r1_1
            v9 := (0 : Int32)
            v10 := (← run_2 v9 v7)
            v11 := (← accepts_3 v1 v7)
            if v10 then
                v13 := v11
            else
                v12 := (false == v11)
                v13 := v12
            if v13 then
                v14 := (v2 - (1 : Int32))
                if v10 then
                    v15 := (v4 + (1 : Int32))
                    v16 := v15
                else
                    v16 := v4
                v2 := v14
                v3 := v8
                v4 := v16
                continue
            else
                spiralFail "brzozowski-compiled-core-disagrees-on-random-input"
        else
            return v4
partial def zeros_input_15 (p0 : Int32) (p1 : U2) : IO U2 := do
    let mut v0 : Int32 := p0
    let mut v1 : U2 := p1
    let mut v2 : Bool := default
    let mut v3 : Int32 := default
    let mut v4 : U0 := default
    let mut v5 : U2 := default
    repeat
        v2 := (decide ((0 : Int32) < v0))
        if v2 then
            v3 := (v0 - (1 : Int32))
            v4 := U0.BitZero
            v5 := (U2.InputCons v4 v1)
            v0 := v3
            v1 := v5
            continue
        else
            return v1
partial def run_16 (p0 : Int32) (p1 : U2) : IO Bool := do
    let mut v0 : Int32 := p0
    let mut v1 : U2 := p1
    let mut v5 : U0 := default
    let mut v6 : U2 := default
    let mut v7 : Bool := default
    let mut v26 : Int32 := default
    let mut v13 : Bool := default
    let mut v22 : U3 := default
    let mut v23 : Bool := default
    let mut v2 : Bool := default
    match v1 with
    | U2.InputCons f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (v0 == (0 : Int32))
        if v7 then
            v26 := (1 : Int32)
        else
            v13 := (v0 == (1 : Int32))
            if v13 then
                v26 := (1 : Int32)
            else
                match v5 with
                | U0.BitOne =>
                    v22 := U3.SymbolGreater
                | U0.BitZero =>
                    v22 := U3.SymbolSame
                match v22 with
                | U3.SymbolSame =>
                    v23 := true
                | _ =>
                    v23 := false
                if v23 then
                    v26 := (2 : Int32)
                else
                    v26 := (0 : Int32)
        return (← run_16 v26 v6)
    | U2.InputEmpty =>
        v2 := (v0 == (0 : Int32))
        if v2 then
            return true
        else
            return false
partial def loop_14 (p0 : Int32) (p1 : U1) (p2 : Int32) (p3 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : U1 := p1
    let mut v2 : Int32 := p2
    let mut v3 : Int32 := p3
    let mut v4 : Bool := default
    let mut v5 : U2 := default
    let mut v6 : U2 := default
    let mut v7 : Int32 := default
    let mut v8 : Bool := default
    let mut v9 : Bool := default
    let mut v11 : Bool := default
    let mut v10 : Bool := default
    let mut v15 : Int32 := default
    let mut v12 : Int32 := default
    let mut v16 : U0 := default
    let mut v17 : U2 := default
    let mut v18 : U2 := default
    let mut v19 : U2 := default
    let mut v20 : Int32 := default
    let mut v21 : Bool := default
    let mut v22 : Bool := default
    let mut v24 : Bool := default
    let mut v23 : Bool := default
    let mut v28 : Int32 := default
    let mut v25 : Int32 := default
    let mut v29 : Int32 := default
    repeat
        v4 := (decide (v0 < v2))
        if v4 then
            return v3
        else
            v5 := U2.InputEmpty
            v6 := (← zeros_input_15 v2 v5)
            v7 := (2 : Int32)
            v8 := (← run_16 v7 v6)
            v9 := (← accepts_3 v1 v6)
            if v8 then
                v11 := v9
            else
                v10 := (false == v9)
                v11 := v10
            if v11 then
                if v8 then
                    v12 := (v3 + (1 : Int32))
                    v15 := v12
                else
                    v15 := v3
            else
                spiralFail "brzozowski-compiled-core-disagrees-on-zero-run"
            v16 := U0.BitOne
            v17 := U2.InputEmpty
            v18 := (U2.InputCons v16 v17)
            v19 := (← zeros_input_15 v2 v18)
            v20 := (2 : Int32)
            v21 := (← run_16 v20 v19)
            v22 := (← accepts_3 v1 v19)
            if v21 then
                v24 := v22
            else
                v23 := (false == v22)
                v24 := v23
            if v24 then
                if v21 then
                    v25 := (v15 + (1 : Int32))
                    v28 := v25
                else
                    v28 := v15
            else
                spiralFail "brzozowski-compiled-core-disagrees-on-zero-run"
            v29 := (v2 + (1 : Int32))
            v2 := v29
            v3 := v28
            continue
partial def run_17 (p0 : Int32) (p1 : U7) : IO Bool := do
    let mut v0 : Int32 := p0
    let mut v1 : U7 := p1
    let mut v5 : U5 := default
    let mut v6 : U7 := default
    let mut v7 : Bool := default
    let mut v47 : Int32 := default
    let mut v10 : U3 := default
    let mut v11 : Bool := default
    let mut v17 : U3 := default
    let mut v18 : Bool := default
    let mut v21 : Bool := default
    let mut v24 : U3 := default
    let mut v25 : Bool := default
    let mut v36 : U3 := default
    let mut v37 : Bool := default
    let mut v2 : Bool := default
    let mut v3 : Bool := default
    match v1 with
    | U7.InputCons f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (v0 == (0 : Int32))
        if v7 then
            match v5 with
            | U5.TriA =>
                v10 := U3.SymbolSame
            | _ =>
                v10 := U3.SymbolGreater
            match v10 with
            | U3.SymbolSame =>
                v11 := true
            | _ =>
                v11 := false
            if v11 then
                v47 := (0 : Int32)
            else
                match v5 with
                | U5.TriA =>
                    v17 := U3.SymbolLess
                | U5.TriB =>
                    v17 := U3.SymbolSame
                | U5.TriC =>
                    v17 := U3.SymbolGreater
                match v17 with
                | U3.SymbolSame =>
                    v18 := true
                | _ =>
                    v18 := false
                if v18 then
                    v47 := (0 : Int32)
                else
                    v47 := (1 : Int32)
        else
            v21 := (v0 == (1 : Int32))
            if v21 then
                match v5 with
                | U5.TriA =>
                    v24 := U3.SymbolSame
                | _ =>
                    v24 := U3.SymbolGreater
                match v24 with
                | U3.SymbolSame =>
                    v25 := true
                | _ =>
                    v25 := false
                if v25 then
                    v47 := (2 : Int32)
                else
                    v47 := (2 : Int32)
            else
                match v5 with
                | U5.TriA =>
                    v36 := U3.SymbolSame
                | _ =>
                    v36 := U3.SymbolGreater
                match v36 with
                | U3.SymbolSame =>
                    v37 := true
                | _ =>
                    v37 := false
                if v37 then
                    v47 := (2 : Int32)
                else
                    v47 := (2 : Int32)
        return (← run_17 v47 v6)
    | U7.InputEmpty =>
        v2 := (v0 == (0 : Int32))
        if v2 then
            return false
        else
            v3 := (v0 == (1 : Int32))
            return v3
partial def regex_compare_23 (p0 : U6) (p1 : U6) : IO U3 := do
    let mut v0 : U6 := p0
    let mut v1 : U6 := p1
    let mut v59 : U6 := default
    let mut v60 : U6 := default
    let mut v61 : U6 := default
    let mut v62 : U6 := default
    let mut v63 : U3 := default
    let mut v34 : U6 := default
    let mut v35 : U6 := default
    let mut v40 : U6 := default
    let mut v41 : U6 := default
    let mut v42 : U3 := default
    let mut v38 : U5 := default
    let mut v10 : U5 := default
    let mut v13 : U5 := default
    let mut v50 : U6 := default
    let mut v51 : U6 := default
    let mut v52 : U6 := default
    let mut v54 : U6 := default
    match v0 with
    | U6.RegexAlt f59 f60 =>
        v59 := f59
        v60 := f60
        match v1 with
        | U6.RegexAlt f61 f62 =>
            v61 := f61
            v62 := f62
            v63 := (← regex_compare_23 v59 v61)
            match v63 with
            | U3.SymbolSame =>
                return (← regex_compare_23 v60 v62)
            | _ =>
                return v63
        | _ =>
            return U3.SymbolGreater
    | U6.RegexCat f34 f35 =>
        v34 := f34
        v35 := f35
        match v1 with
        | U6.RegexCat f40 f41 =>
            v40 := f40
            v41 := f41
            v42 := (← regex_compare_23 v34 v40)
            match v42 with
            | U3.SymbolSame =>
                return (← regex_compare_23 v35 v41)
            | _ =>
                return v42
        | U6.RegexChar f38 =>
            v38 := f38
            return U3.SymbolGreater
        | U6.RegexEmpty =>
            return U3.SymbolGreater
        | U6.RegexEpsilon =>
            return U3.SymbolGreater
        | _ =>
            return U3.SymbolLess
    | U6.RegexChar f10 =>
        v10 := f10
        match v1 with
        | U6.RegexChar f13 =>
            v13 := f13
            match v10 with
            | U5.TriA =>
                match v13 with
                | U5.TriA =>
                    return U3.SymbolSame
                | _ =>
                    return U3.SymbolLess
            | _ =>
                match v13 with
                | U5.TriA =>
                    return U3.SymbolGreater
                | _ =>
                    match v10 with
                    | U5.TriB =>
                        match v13 with
                        | U5.TriB =>
                            return U3.SymbolSame
                        | U5.TriC =>
                            return U3.SymbolLess
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | U5.TriC =>
                        match v13 with
                        | U5.TriB =>
                            return U3.SymbolGreater
                        | U5.TriC =>
                            return U3.SymbolSame
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | _ =>
                        spiralFail "union unbox: unreachable case"
        | U6.RegexEmpty =>
            return U3.SymbolGreater
        | U6.RegexEpsilon =>
            return U3.SymbolGreater
        | _ =>
            return U3.SymbolLess
    | U6.RegexEmpty =>
        match v1 with
        | U6.RegexEmpty =>
            return U3.SymbolSame
        | _ =>
            return U3.SymbolLess
    | U6.RegexEpsilon =>
        match v1 with
        | U6.RegexEmpty =>
            return U3.SymbolGreater
        | U6.RegexEpsilon =>
            return U3.SymbolSame
        | _ =>
            return U3.SymbolLess
    | U6.RegexStar f50 =>
        v50 := f50
        match v1 with
        | U6.RegexAlt f51 f52 =>
            v51 := f51
            v52 := f52
            return U3.SymbolLess
        | U6.RegexStar f54 =>
            v54 := f54
            return (← regex_compare_23 v50 v54)
        | _ =>
            return U3.SymbolGreater
partial def alt_insert_sorted_22 (p0 : U6) (p1 : U6) : IO U6 := do
    let mut v0 : U6 := p0
    let mut v1 : U6 := p1
    let mut v2 : U6 := default
    let mut v3 : U6 := default
    let mut v4 : U3 := default
    let mut v6 : U6 := default
    let mut v11 : U3 := default
    match v1 with
    | U6.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← regex_compare_23 v0 v2)
        match v4 with
        | U3.SymbolGreater =>
            v6 := (← alt_insert_sorted_22 v0 v3)
            return (U6.RegexAlt v2 v6)
        | U3.SymbolLess =>
            return (U6.RegexAlt v0 v1)
        | U3.SymbolSame =>
            return v1
    | U6.RegexEmpty =>
        return v0
    | _ =>
        v11 := (← regex_compare_23 v0 v1)
        match v11 with
        | U3.SymbolGreater =>
            return (U6.RegexAlt v1 v0)
        | U3.SymbolLess =>
            return (U6.RegexAlt v0 v1)
        | U3.SymbolSame =>
            return v1
partial def make_alt_21 (p0 : U6) (p1 : U6) : IO U6 := do
    let mut v0 : U6 := p0
    let mut v1 : U6 := p1
    let mut v2 : U6 := default
    let mut v3 : U6 := default
    let mut v4 : U6 := default
    match v0 with
    | U6.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← alt_insert_sorted_22 v2 v1)
        return (← make_alt_21 v3 v4)
    | U6.RegexEmpty =>
        return v1
    | _ =>
        return (← alt_insert_sorted_22 v0 v1)
partial def regex_equal_25 (p0 : U6) (p1 : U6) : IO Bool := do
    let mut v0 : U6 := p0
    let mut v1 : U6 := p1
    let mut v24 : U6 := default
    let mut v25 : U6 := default
    let mut v26 : U6 := default
    let mut v27 : U6 := default
    let mut v28 : Bool := default
    let mut v32 : U6 := default
    let mut v33 : U6 := default
    let mut v34 : U6 := default
    let mut v35 : U6 := default
    let mut v36 : Bool := default
    let mut v4 : U5 := default
    let mut v5 : U5 := default
    let mut v21 : U3 := default
    let mut v40 : U6 := default
    let mut v41 : U6 := default
    match v0 with
    | U6.RegexAlt f24 f25 =>
        v24 := f24
        v25 := f25
        match v1 with
        | U6.RegexAlt f26 f27 =>
            v26 := f26
            v27 := f27
            v28 := (← regex_equal_25 v24 v26)
            if v28 then
                return (← regex_equal_25 v25 v27)
            else
                return false
        | _ =>
            return false
    | U6.RegexCat f32 f33 =>
        v32 := f32
        v33 := f33
        match v1 with
        | U6.RegexCat f34 f35 =>
            v34 := f34
            v35 := f35
            v36 := (← regex_equal_25 v32 v34)
            if v36 then
                return (← regex_equal_25 v33 v35)
            else
                return false
        | _ =>
            return false
    | U6.RegexChar f4 =>
        v4 := f4
        match v1 with
        | U6.RegexChar f5 =>
            v5 := f5
            match v4 with
            | U5.TriA =>
                match v5 with
                | U5.TriA =>
                    v21 := U3.SymbolSame
                | _ =>
                    v21 := U3.SymbolLess
            | _ =>
                match v5 with
                | U5.TriA =>
                    v21 := U3.SymbolGreater
                | _ =>
                    match v4 with
                    | U5.TriB =>
                        match v5 with
                        | U5.TriB =>
                            v21 := U3.SymbolSame
                        | U5.TriC =>
                            v21 := U3.SymbolLess
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | U5.TriC =>
                        match v5 with
                        | U5.TriB =>
                            v21 := U3.SymbolGreater
                        | U5.TriC =>
                            v21 := U3.SymbolSame
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | _ =>
                        spiralFail "union unbox: unreachable case"
            match v21 with
            | U3.SymbolSame =>
                return true
            | _ =>
                return false
        | _ =>
            return false
    | U6.RegexEmpty =>
        match v1 with
        | U6.RegexEmpty =>
            return true
        | _ =>
            return false
    | U6.RegexEpsilon =>
        match v1 with
        | U6.RegexEpsilon =>
            return true
        | _ =>
            return false
    | U6.RegexStar f40 =>
        v40 := f40
        match v1 with
        | U6.RegexStar f41 =>
            v41 := f41
            return (← regex_equal_25 v40 v41)
        | _ =>
            return false
partial def make_cat_24 (p0 : U6) (p1 : U6) : IO U6 := do
    let mut v0 : U6 := p0
    let mut v1 : U6 := p1
    let mut v12 : U6 := default
    let mut v13 : U6 := default
    let mut v14 : U6 := default
    let mut v4 : U6 := default
    let mut v5 : U6 := default
    let mut v6 : Bool := default
    match v0 with
    | U6.RegexEmpty =>
        return U6.RegexEmpty
    | _ =>
        match v1 with
        | U6.RegexEmpty =>
            return U6.RegexEmpty
        | _ =>
            match v0 with
            | U6.RegexEpsilon =>
                return v1
            | _ =>
                match v1 with
                | U6.RegexEpsilon =>
                    return v0
                | _ =>
                    match v0 with
                    | U6.RegexCat f12 f13 =>
                        v12 := f12
                        v13 := f13
                        v14 := (← make_cat_24 v13 v1)
                        return (U6.RegexCat v12 v14)
                    | U6.RegexStar f4 =>
                        v4 := f4
                        match v1 with
                        | U6.RegexStar f5 =>
                            v5 := f5
                            v6 := (← regex_equal_25 v4 v5)
                            if v6 then
                                return (U6.RegexStar v4)
                            else
                                return (U6.RegexCat v0 v1)
                        | _ =>
                            return (U6.RegexCat v0 v1)
                    | _ =>
                        return (U6.RegexCat v0 v1)
partial def make_star_26 (p0 : U6) : IO U6 := do
    let mut v0 : U6 := p0
    let mut v3 : U6 := default
    match v0 with
    | U6.RegexEmpty =>
        return U6.RegexEpsilon
    | U6.RegexEpsilon =>
        return U6.RegexEpsilon
    | U6.RegexStar f3 =>
        v3 := f3
        return (U6.RegexStar v3)
    | _ =>
        return (U6.RegexStar v0)
partial def normalize_20 (p0 : U6) : IO U6 := do
    let mut v0 : U6 := p0
    let mut v5 : U6 := default
    let mut v6 : U6 := default
    let mut v7 : U6 := default
    let mut v8 : U6 := default
    let mut v10 : U6 := default
    let mut v11 : U6 := default
    let mut v12 : U6 := default
    let mut v13 : U6 := default
    let mut v3 : U5 := default
    let mut v15 : U6 := default
    let mut v16 : U6 := default
    match v0 with
    | U6.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← normalize_20 v5)
        v8 := (← normalize_20 v6)
        return (← make_alt_21 v7 v8)
    | U6.RegexCat f10 f11 =>
        v10 := f10
        v11 := f11
        v12 := (← normalize_20 v10)
        v13 := (← normalize_20 v11)
        return (← make_cat_24 v12 v13)
    | U6.RegexChar f3 =>
        v3 := f3
        return (U6.RegexChar v3)
    | U6.RegexEmpty =>
        return U6.RegexEmpty
    | U6.RegexEpsilon =>
        return U6.RegexEpsilon
    | U6.RegexStar f15 =>
        v15 := f15
        v16 := (← normalize_20 v15)
        return (← make_star_26 v16)
partial def nullable_28 (p0 : U6) : IO U4 := do
    let mut v0 : U6 := p0
    let mut v5 : U6 := default
    let mut v6 : U6 := default
    let mut v7 : U4 := default
    let mut v8 : U4 := default
    let mut v16 : U6 := default
    let mut v17 : U6 := default
    let mut v18 : U4 := default
    let mut v19 : U4 := default
    let mut v3 : U5 := default
    let mut v25 : U6 := default
    match v0 with
    | U6.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← nullable_28 v5)
        v8 := (← nullable_28 v6)
        match v7 with
        | U4.Nullable =>
            return U4.Nullable
        | _ =>
            match v8 with
            | U4.Nullable =>
                return U4.Nullable
            | _ =>
                match v7 with
                | U4.NonNullable =>
                    match v8 with
                    | U4.NonNullable =>
                        return U4.NonNullable
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | _ =>
                    spiralFail "union unbox: unreachable case"
    | U6.RegexCat f16 f17 =>
        v16 := f16
        v17 := f17
        v18 := (← nullable_28 v16)
        v19 := (← nullable_28 v17)
        match v18 with
        | U4.Nullable =>
            match v19 with
            | U4.Nullable =>
                return U4.Nullable
            | _ =>
                return U4.NonNullable
        | _ =>
            return U4.NonNullable
    | U6.RegexChar f3 =>
        v3 := f3
        return U4.NonNullable
    | U6.RegexEmpty =>
        return U4.NonNullable
    | U6.RegexEpsilon =>
        return U4.Nullable
    | U6.RegexStar f25 =>
        v25 := f25
        return U4.Nullable
partial def derivative_27 (p0 : U6) (p1 : U5) : IO U6 := do
    let mut v0 : U6 := p0
    let mut v1 : U5 := p1
    let mut v25 : U6 := default
    let mut v26 : U6 := default
    let mut v27 : U6 := default
    let mut v28 : U6 := default
    let mut v30 : U6 := default
    let mut v31 : U6 := default
    let mut v32 : U4 := default
    let mut v37 : U6 := default
    let mut v33 : U6 := default
    let mut v34 : U6 := default
    let mut v35 : U6 := default
    let mut v4 : U5 := default
    let mut v20 : U3 := default
    let mut v21 : Bool := default
    let mut v41 : U6 := default
    let mut v42 : U6 := default
    let mut v43 : U6 := default
    match v0 with
    | U6.RegexAlt f25 f26 =>
        v25 := f25
        v26 := f26
        v27 := (← derivative_27 v25 v1)
        v28 := (← derivative_27 v26 v1)
        return (← make_alt_21 v27 v28)
    | U6.RegexCat f30 f31 =>
        v30 := f30
        v31 := f31
        v32 := (← nullable_28 v30)
        match v32 with
        | U4.NonNullable =>
            v37 := (← derivative_27 v30 v1)
            return (← make_cat_24 v37 v31)
        | U4.Nullable =>
            v33 := (← derivative_27 v30 v1)
            v34 := (← make_cat_24 v33 v31)
            v35 := (← derivative_27 v31 v1)
            return (← make_alt_21 v34 v35)
    | U6.RegexChar f4 =>
        v4 := f4
        match v4 with
        | U5.TriA =>
            match v1 with
            | U5.TriA =>
                v20 := U3.SymbolSame
            | _ =>
                v20 := U3.SymbolLess
        | _ =>
            match v1 with
            | U5.TriA =>
                v20 := U3.SymbolGreater
            | _ =>
                match v4 with
                | U5.TriB =>
                    match v1 with
                    | U5.TriB =>
                        v20 := U3.SymbolSame
                    | U5.TriC =>
                        v20 := U3.SymbolLess
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | U5.TriC =>
                    match v1 with
                    | U5.TriB =>
                        v20 := U3.SymbolGreater
                    | U5.TriC =>
                        v20 := U3.SymbolSame
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | _ =>
                    spiralFail "union unbox: unreachable case"
        match v20 with
        | U3.SymbolSame =>
            v21 := true
        | _ =>
            v21 := false
        if v21 then
            return U6.RegexEpsilon
        else
            return U6.RegexEmpty
    | U6.RegexEmpty =>
        return U6.RegexEmpty
    | U6.RegexEpsilon =>
        return U6.RegexEmpty
    | U6.RegexStar f41 =>
        v41 := f41
        v42 := (← derivative_27 v41 v1)
        v43 := (← make_star_26 v41)
        return (← make_cat_24 v42 v43)
partial def canonical_derivative_19 (p0 : U6) (p1 : U5) : IO U6 := do
    let mut v0 : U6 := p0
    let mut v1 : U5 := p1
    let v2 : U6 := (← normalize_20 v0)
    let v3 : U6 := (← derivative_27 v2 v1)
    return (← normalize_20 v3)
partial def accepts_18 (p0 : U6) (p1 : U7) : IO Bool := do
    let mut v0 : U6 := p0
    let mut v1 : U7 := p1
    let mut v6 : U5 := default
    let mut v7 : U7 := default
    let mut v8 : U6 := default
    let mut v2 : U6 := default
    let mut v3 : U4 := default
    match v1 with
    | U7.InputCons f6 f7 =>
        v6 := f6
        v7 := f7
        v8 := (← canonical_derivative_19 v0 v6)
        return (← accepts_18 v8 v7)
    | U7.InputEmpty =>
        v2 := (← normalize_20 v0)
        v3 := (← nullable_28 v2)
        match v3 with
        | U4.NonNullable =>
            return false
        | U4.Nullable =>
            return true
partial def spiralMain : IO Int32 := do
    let mut v62 : Bool := default
    let mut v68 : Bool := default
    let mut v63 : Int32 := default
    let mut v64 : Bool := default
    let mut v65 : Bool := default
    let mut v66 : Bool := default
    let v0 : Int32 := (200 : Int32)
    let v1 : Int32 := (32 : Int32)
    let v2 : Int32 := (16 : Int32)
    let v3 : U0 := U0.BitZero
    let v4 : U1 := (U1.RegexChar v3)
    let v5 : U0 := U0.BitOne
    let v6 : U1 := (U1.RegexChar v5)
    let v7 : U1 := (U1.RegexAlt v4 v6)
    let v8 : U1 := (U1.RegexStar v7)
    let v9 : U0 := U0.BitZero
    let v10 : U1 := (U1.RegexChar v9)
    let v11 : U1 := (U1.RegexCat v8 v10)
    let v12 : UInt64 := (1 : UInt64)
    let v13 : Int32 := (0 : Int32)
    let v14 : Int32 := (← loop_0 v1 v11 v0 v12 v13)
    let v15 : Bool := (v14 == (93 : Int32))
    if v15 then
        pure ()
    else
        spiralFail "brzozowski-compiled-ends-with-zero-count"
    let v16 : U0 := U0.BitZero
    let v17 : U1 := (U1.RegexChar v16)
    let v18 : U0 := U0.BitZero
    let v19 : U1 := (U1.RegexChar v18)
    let v20 : U0 := U0.BitZero
    let v21 : U1 := (U1.RegexChar v20)
    let v22 : U1 := (U1.RegexCat v19 v21)
    let v23 : U1 := (U1.RegexAlt v17 v22)
    let v24 : U1 := (U1.RegexStar v23)
    let v25 : U0 := U0.BitOne
    let v26 : U1 := (U1.RegexChar v25)
    let v27 : U1 := (U1.RegexCat v24 v26)
    let v28 : Int32 := (1 : Int32)
    let v29 : Int32 := (0 : Int32)
    let v30 : Int32 := (← loop_14 v2 v27 v28 v29)
    let v31 : Bool := (v30 == (16 : Int32))
    if v31 then
        pure ()
    else
        spiralFail "brzozowski-compiled-zero-runs-count"
    let v32 : U5 := U5.TriA
    let v33 : U6 := (U6.RegexChar v32)
    let v34 : U5 := U5.TriB
    let v35 : U6 := (U6.RegexChar v34)
    let v36 : U6 := (U6.RegexAlt v33 v35)
    let v37 : U6 := (U6.RegexStar v36)
    let v38 : U5 := U5.TriC
    let v39 : U6 := (U6.RegexChar v38)
    let v40 : U6 := (U6.RegexCat v37 v39)
    let v41 : U5 := U5.TriA
    let v42 : U5 := U5.TriB
    let v43 : U5 := U5.TriA
    let v44 : U5 := U5.TriC
    let v45 : U7 := U7.InputEmpty
    let v46 : U7 := (U7.InputCons v44 v45)
    let v47 : U7 := (U7.InputCons v43 v46)
    let v48 : U7 := (U7.InputCons v42 v47)
    let v49 : U7 := (U7.InputCons v41 v48)
    let v50 : U5 := U5.TriA
    let v51 : U5 := U5.TriB
    let v52 : U5 := U5.TriA
    let v53 : U5 := U5.TriB
    let v54 : U7 := U7.InputEmpty
    let v55 : U7 := (U7.InputCons v53 v54)
    let v56 : U7 := (U7.InputCons v52 v55)
    let v57 : U7 := (U7.InputCons v51 v56)
    let v58 : U7 := (U7.InputCons v50 v57)
    let v59 : Int32 := (0 : Int32)
    let v60 : Bool := (← run_17 v59 v49)
    if v60 then
        v62 := (← accepts_18 v40 v49)
    else
        v62 := false
    if v62 then
        v63 := (0 : Int32)
        v64 := (← run_17 v63 v58)
        if v64 then
            v68 := false
        else
            v65 := (← accepts_18 v40 v58)
            v66 := (v65 == false)
            v68 := v66
    else
        v68 := false
    if v68 then
        return (0 : Int32)
    else
        spiralFail "brzozowski-compiled-ternary-disagrees"
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
