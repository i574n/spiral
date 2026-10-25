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
  | InputEmpty : U1
  | InputCons : U0 → U1 → U1
end
deriving instance Inhabited for U1
mutual
inductive U2 where
  | TriA : U2
  | TriB : U2
  | TriC : U2
end
deriving instance Inhabited for U2
mutual
inductive U3 where
  | InputEmpty : U3
  | InputCons : U2 → U3 → U3
end
deriving instance Inhabited for U3
mutual
inductive U4 where
  | RegexEmpty : U4
  | RegexEpsilon : U4
  | RegexChar : U0 → U4
  | RegexAlt : U4 → U4 → U4
  | RegexCat : U4 → U4 → U4
  | RegexStar : U4 → U4
end
deriving instance Inhabited for U4
mutual
inductive U5 where
  | SymbolLess : U5
  | SymbolSame : U5
  | SymbolGreater : U5
end
deriving instance Inhabited for U5
mutual
inductive U6 where
  | Nullable : U6
  | NonNullable : U6
end
deriving instance Inhabited for U6
mutual
inductive U7 where
  | RegexEmpty : U7
  | RegexEpsilon : U7
  | RegexChar : U2 → U7
  | RegexAlt : U7 → U7 → U7
  | RegexCat : U7 → U7 → U7
  | RegexStar : U7 → U7
end
deriving instance Inhabited for U7
mutual
inductive U8 where
  | BitMatcherRaw : U4 → U1 → U8
end
deriving instance Inhabited for U8
mutual
inductive U9 where
  | BitMatcherDecided : U4 → U1 → Bool → U9
end
deriving instance Inhabited for U9
def U0.spiralTag : U0 → Int32
  | .BitZero .. => 0
  | .BitOne .. => 1
def U1.spiralTag : U1 → Int32
  | .InputEmpty .. => 0
  | .InputCons .. => 1
def U2.spiralTag : U2 → Int32
  | .TriA .. => 0
  | .TriB .. => 1
  | .TriC .. => 2
def U3.spiralTag : U3 → Int32
  | .InputEmpty .. => 0
  | .InputCons .. => 1
def U4.spiralTag : U4 → Int32
  | .RegexEmpty .. => 0
  | .RegexEpsilon .. => 1
  | .RegexChar .. => 2
  | .RegexAlt .. => 3
  | .RegexCat .. => 4
  | .RegexStar .. => 5
def U5.spiralTag : U5 → Int32
  | .SymbolLess .. => 0
  | .SymbolSame .. => 1
  | .SymbolGreater .. => 2
def U6.spiralTag : U6 → Int32
  | .Nullable .. => 0
  | .NonNullable .. => 1
def U7.spiralTag : U7 → Int32
  | .RegexEmpty .. => 0
  | .RegexEpsilon .. => 1
  | .RegexChar .. => 2
  | .RegexAlt .. => 3
  | .RegexCat .. => 4
  | .RegexStar .. => 5
def U8.spiralTag : U8 → Int32
  | .BitMatcherRaw .. => 0
def U9.spiralTag : U9 → Int32
  | .BitMatcherDecided .. => 0
mutual
partial def regex_compare_5 (p0 : U4) (p1 : U4) : IO U5 := do
    let mut v0 : U4 := p0
    let mut v1 : U4 := p1
    let mut v53 : U4 := default
    let mut v54 : U4 := default
    let mut v55 : U4 := default
    let mut v56 : U4 := default
    let mut v57 : U5 := default
    let mut v28 : U4 := default
    let mut v29 : U4 := default
    let mut v34 : U4 := default
    let mut v35 : U4 := default
    let mut v36 : U5 := default
    let mut v32 : U0 := default
    let mut v10 : U0 := default
    let mut v13 : U0 := default
    let mut v44 : U4 := default
    let mut v45 : U4 := default
    let mut v46 : U4 := default
    let mut v48 : U4 := default
    match v0 with
    | U4.RegexAlt f53 f54 =>
        v53 := f53
        v54 := f54
        match v1 with
        | U4.RegexAlt f55 f56 =>
            v55 := f55
            v56 := f56
            v57 := (← regex_compare_5 v53 v55)
            match v57 with
            | U5.SymbolSame =>
                return (← regex_compare_5 v54 v56)
            | _ =>
                return v57
        | _ =>
            return U5.SymbolGreater
    | U4.RegexCat f28 f29 =>
        v28 := f28
        v29 := f29
        match v1 with
        | U4.RegexCat f34 f35 =>
            v34 := f34
            v35 := f35
            v36 := (← regex_compare_5 v28 v34)
            match v36 with
            | U5.SymbolSame =>
                return (← regex_compare_5 v29 v35)
            | _ =>
                return v36
        | U4.RegexChar f32 =>
            v32 := f32
            return U5.SymbolGreater
        | U4.RegexEmpty =>
            return U5.SymbolGreater
        | U4.RegexEpsilon =>
            return U5.SymbolGreater
        | _ =>
            return U5.SymbolLess
    | U4.RegexChar f10 =>
        v10 := f10
        match v1 with
        | U4.RegexChar f13 =>
            v13 := f13
            match v10 with
            | U0.BitOne =>
                match v13 with
                | U0.BitOne =>
                    return U5.SymbolSame
                | U0.BitZero =>
                    return U5.SymbolGreater
            | U0.BitZero =>
                match v13 with
                | U0.BitOne =>
                    return U5.SymbolLess
                | U0.BitZero =>
                    return U5.SymbolSame
        | U4.RegexEmpty =>
            return U5.SymbolGreater
        | U4.RegexEpsilon =>
            return U5.SymbolGreater
        | _ =>
            return U5.SymbolLess
    | U4.RegexEmpty =>
        match v1 with
        | U4.RegexEmpty =>
            return U5.SymbolSame
        | _ =>
            return U5.SymbolLess
    | U4.RegexEpsilon =>
        match v1 with
        | U4.RegexEmpty =>
            return U5.SymbolGreater
        | U4.RegexEpsilon =>
            return U5.SymbolSame
        | _ =>
            return U5.SymbolLess
    | U4.RegexStar f44 =>
        v44 := f44
        match v1 with
        | U4.RegexAlt f45 f46 =>
            v45 := f45
            v46 := f46
            return U5.SymbolLess
        | U4.RegexStar f48 =>
            v48 := f48
            return (← regex_compare_5 v44 v48)
        | _ =>
            return U5.SymbolGreater
partial def alt_insert_sorted_4 (p0 : U4) (p1 : U4) : IO U4 := do
    let mut v0 : U4 := p0
    let mut v1 : U4 := p1
    let mut v2 : U4 := default
    let mut v3 : U4 := default
    let mut v4 : U5 := default
    let mut v6 : U4 := default
    let mut v11 : U5 := default
    match v1 with
    | U4.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← regex_compare_5 v0 v2)
        match v4 with
        | U5.SymbolGreater =>
            v6 := (← alt_insert_sorted_4 v0 v3)
            return (U4.RegexAlt v2 v6)
        | U5.SymbolLess =>
            return (U4.RegexAlt v0 v1)
        | U5.SymbolSame =>
            return v1
    | U4.RegexEmpty =>
        return v0
    | _ =>
        v11 := (← regex_compare_5 v0 v1)
        match v11 with
        | U5.SymbolGreater =>
            return (U4.RegexAlt v1 v0)
        | U5.SymbolLess =>
            return (U4.RegexAlt v0 v1)
        | U5.SymbolSame =>
            return v1
partial def make_alt_3 (p0 : U4) (p1 : U4) : IO U4 := do
    let mut v0 : U4 := p0
    let mut v1 : U4 := p1
    let mut v2 : U4 := default
    let mut v3 : U4 := default
    let mut v4 : U4 := default
    match v0 with
    | U4.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← alt_insert_sorted_4 v2 v1)
        return (← make_alt_3 v3 v4)
    | U4.RegexEmpty =>
        return v1
    | _ =>
        return (← alt_insert_sorted_4 v0 v1)
partial def regex_equal_7 (p0 : U4) (p1 : U4) : IO Bool := do
    let mut v0 : U4 := p0
    let mut v1 : U4 := p1
    let mut v18 : U4 := default
    let mut v19 : U4 := default
    let mut v20 : U4 := default
    let mut v21 : U4 := default
    let mut v22 : Bool := default
    let mut v26 : U4 := default
    let mut v27 : U4 := default
    let mut v28 : U4 := default
    let mut v29 : U4 := default
    let mut v30 : Bool := default
    let mut v4 : U0 := default
    let mut v5 : U0 := default
    let mut v15 : U5 := default
    let mut v34 : U4 := default
    let mut v35 : U4 := default
    match v0 with
    | U4.RegexAlt f18 f19 =>
        v18 := f18
        v19 := f19
        match v1 with
        | U4.RegexAlt f20 f21 =>
            v20 := f20
            v21 := f21
            v22 := (← regex_equal_7 v18 v20)
            if v22 then
                return (← regex_equal_7 v19 v21)
            else
                return false
        | _ =>
            return false
    | U4.RegexCat f26 f27 =>
        v26 := f26
        v27 := f27
        match v1 with
        | U4.RegexCat f28 f29 =>
            v28 := f28
            v29 := f29
            v30 := (← regex_equal_7 v26 v28)
            if v30 then
                return (← regex_equal_7 v27 v29)
            else
                return false
        | _ =>
            return false
    | U4.RegexChar f4 =>
        v4 := f4
        match v1 with
        | U4.RegexChar f5 =>
            v5 := f5
            match v4 with
            | U0.BitOne =>
                match v5 with
                | U0.BitOne =>
                    v15 := U5.SymbolSame
                | U0.BitZero =>
                    v15 := U5.SymbolGreater
            | U0.BitZero =>
                match v5 with
                | U0.BitOne =>
                    v15 := U5.SymbolLess
                | U0.BitZero =>
                    v15 := U5.SymbolSame
            match v15 with
            | U5.SymbolSame =>
                return true
            | _ =>
                return false
        | _ =>
            return false
    | U4.RegexEmpty =>
        match v1 with
        | U4.RegexEmpty =>
            return true
        | _ =>
            return false
    | U4.RegexEpsilon =>
        match v1 with
        | U4.RegexEpsilon =>
            return true
        | _ =>
            return false
    | U4.RegexStar f34 =>
        v34 := f34
        match v1 with
        | U4.RegexStar f35 =>
            v35 := f35
            return (← regex_equal_7 v34 v35)
        | _ =>
            return false
partial def make_cat_6 (p0 : U4) (p1 : U4) : IO U4 := do
    let mut v0 : U4 := p0
    let mut v1 : U4 := p1
    let mut v12 : U4 := default
    let mut v13 : U4 := default
    let mut v14 : U4 := default
    let mut v4 : U4 := default
    let mut v5 : U4 := default
    let mut v6 : Bool := default
    match v0 with
    | U4.RegexEmpty =>
        return U4.RegexEmpty
    | _ =>
        match v1 with
        | U4.RegexEmpty =>
            return U4.RegexEmpty
        | _ =>
            match v0 with
            | U4.RegexEpsilon =>
                return v1
            | _ =>
                match v1 with
                | U4.RegexEpsilon =>
                    return v0
                | _ =>
                    match v0 with
                    | U4.RegexCat f12 f13 =>
                        v12 := f12
                        v13 := f13
                        v14 := (← make_cat_6 v13 v1)
                        return (U4.RegexCat v12 v14)
                    | U4.RegexStar f4 =>
                        v4 := f4
                        match v1 with
                        | U4.RegexStar f5 =>
                            v5 := f5
                            v6 := (← regex_equal_7 v4 v5)
                            if v6 then
                                return (U4.RegexStar v4)
                            else
                                return (U4.RegexCat v0 v1)
                        | _ =>
                            return (U4.RegexCat v0 v1)
                    | _ =>
                        return (U4.RegexCat v0 v1)
partial def make_star_8 (p0 : U4) : IO U4 := do
    let mut v0 : U4 := p0
    let mut v3 : U4 := default
    match v0 with
    | U4.RegexEmpty =>
        return U4.RegexEpsilon
    | U4.RegexEpsilon =>
        return U4.RegexEpsilon
    | U4.RegexStar f3 =>
        v3 := f3
        return (U4.RegexStar v3)
    | _ =>
        return (U4.RegexStar v0)
partial def normalize_2 (p0 : U4) : IO U4 := do
    let mut v0 : U4 := p0
    let mut v5 : U4 := default
    let mut v6 : U4 := default
    let mut v7 : U4 := default
    let mut v8 : U4 := default
    let mut v10 : U4 := default
    let mut v11 : U4 := default
    let mut v12 : U4 := default
    let mut v13 : U4 := default
    let mut v3 : U0 := default
    let mut v15 : U4 := default
    let mut v16 : U4 := default
    match v0 with
    | U4.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← normalize_2 v5)
        v8 := (← normalize_2 v6)
        return (← make_alt_3 v7 v8)
    | U4.RegexCat f10 f11 =>
        v10 := f10
        v11 := f11
        v12 := (← normalize_2 v10)
        v13 := (← normalize_2 v11)
        return (← make_cat_6 v12 v13)
    | U4.RegexChar f3 =>
        v3 := f3
        return (U4.RegexChar v3)
    | U4.RegexEmpty =>
        return U4.RegexEmpty
    | U4.RegexEpsilon =>
        return U4.RegexEpsilon
    | U4.RegexStar f15 =>
        v15 := f15
        v16 := (← normalize_2 v15)
        return (← make_star_8 v16)
partial def nullable_10 (p0 : U4) : IO U6 := do
    let mut v0 : U4 := p0
    let mut v5 : U4 := default
    let mut v6 : U4 := default
    let mut v7 : U6 := default
    let mut v8 : U6 := default
    let mut v16 : U4 := default
    let mut v17 : U4 := default
    let mut v18 : U6 := default
    let mut v19 : U6 := default
    let mut v3 : U0 := default
    let mut v25 : U4 := default
    match v0 with
    | U4.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← nullable_10 v5)
        v8 := (← nullable_10 v6)
        match v7 with
        | U6.Nullable =>
            return U6.Nullable
        | _ =>
            match v8 with
            | U6.Nullable =>
                return U6.Nullable
            | _ =>
                match v7 with
                | U6.NonNullable =>
                    match v8 with
                    | U6.NonNullable =>
                        return U6.NonNullable
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | _ =>
                    spiralFail "union unbox: unreachable case"
    | U4.RegexCat f16 f17 =>
        v16 := f16
        v17 := f17
        v18 := (← nullable_10 v16)
        v19 := (← nullable_10 v17)
        match v18 with
        | U6.Nullable =>
            match v19 with
            | U6.Nullable =>
                return U6.Nullable
            | _ =>
                return U6.NonNullable
        | _ =>
            return U6.NonNullable
    | U4.RegexChar f3 =>
        v3 := f3
        return U6.NonNullable
    | U4.RegexEmpty =>
        return U6.NonNullable
    | U4.RegexEpsilon =>
        return U6.Nullable
    | U4.RegexStar f25 =>
        v25 := f25
        return U6.Nullable
partial def derivative_9 (p0 : U4) (p1 : U0) : IO U4 := do
    let mut v0 : U4 := p0
    let mut v1 : U0 := p1
    let mut v19 : U4 := default
    let mut v20 : U4 := default
    let mut v21 : U4 := default
    let mut v22 : U4 := default
    let mut v24 : U4 := default
    let mut v25 : U4 := default
    let mut v26 : U6 := default
    let mut v31 : U4 := default
    let mut v27 : U4 := default
    let mut v28 : U4 := default
    let mut v29 : U4 := default
    let mut v4 : U0 := default
    let mut v14 : U5 := default
    let mut v15 : Bool := default
    let mut v35 : U4 := default
    let mut v36 : U4 := default
    let mut v37 : U4 := default
    match v0 with
    | U4.RegexAlt f19 f20 =>
        v19 := f19
        v20 := f20
        v21 := (← derivative_9 v19 v1)
        v22 := (← derivative_9 v20 v1)
        return (← make_alt_3 v21 v22)
    | U4.RegexCat f24 f25 =>
        v24 := f24
        v25 := f25
        v26 := (← nullable_10 v24)
        match v26 with
        | U6.NonNullable =>
            v31 := (← derivative_9 v24 v1)
            return (← make_cat_6 v31 v25)
        | U6.Nullable =>
            v27 := (← derivative_9 v24 v1)
            v28 := (← make_cat_6 v27 v25)
            v29 := (← derivative_9 v25 v1)
            return (← make_alt_3 v28 v29)
    | U4.RegexChar f4 =>
        v4 := f4
        match v4 with
        | U0.BitOne =>
            match v1 with
            | U0.BitOne =>
                v14 := U5.SymbolSame
            | U0.BitZero =>
                v14 := U5.SymbolGreater
        | U0.BitZero =>
            match v1 with
            | U0.BitOne =>
                v14 := U5.SymbolLess
            | U0.BitZero =>
                v14 := U5.SymbolSame
        match v14 with
        | U5.SymbolSame =>
            v15 := true
        | _ =>
            v15 := false
        if v15 then
            return U4.RegexEpsilon
        else
            return U4.RegexEmpty
    | U4.RegexEmpty =>
        return U4.RegexEmpty
    | U4.RegexEpsilon =>
        return U4.RegexEmpty
    | U4.RegexStar f35 =>
        v35 := f35
        v36 := (← derivative_9 v35 v1)
        v37 := (← make_star_8 v35)
        return (← make_cat_6 v36 v37)
partial def canonical_derivative_1 (p0 : U4) (p1 : U0) : IO U4 := do
    let mut v0 : U4 := p0
    let mut v1 : U0 := p1
    let v2 : U4 := (← normalize_2 v0)
    let v3 : U4 := (← derivative_9 v2 v1)
    return (← normalize_2 v3)
partial def accepts_0 (p0 : U4) (p1 : U1) : IO Bool := do
    let mut v0 : U4 := p0
    let mut v1 : U1 := p1
    let mut v6 : U0 := default
    let mut v7 : U1 := default
    let mut v8 : U4 := default
    let mut v2 : U4 := default
    let mut v3 : U6 := default
    match v1 with
    | U1.InputCons f6 f7 =>
        v6 := f6
        v7 := f7
        v8 := (← canonical_derivative_1 v0 v6)
        return (← accepts_0 v8 v7)
    | U1.InputEmpty =>
        v2 := (← normalize_2 v0)
        v3 := (← nullable_10 v2)
        match v3 with
        | U6.NonNullable =>
            return false
        | U6.Nullable =>
            return true
partial def regex_compare_16 (p0 : U7) (p1 : U7) : IO U5 := do
    let mut v0 : U7 := p0
    let mut v1 : U7 := p1
    let mut v59 : U7 := default
    let mut v60 : U7 := default
    let mut v61 : U7 := default
    let mut v62 : U7 := default
    let mut v63 : U5 := default
    let mut v34 : U7 := default
    let mut v35 : U7 := default
    let mut v40 : U7 := default
    let mut v41 : U7 := default
    let mut v42 : U5 := default
    let mut v38 : U2 := default
    let mut v10 : U2 := default
    let mut v13 : U2 := default
    let mut v50 : U7 := default
    let mut v51 : U7 := default
    let mut v52 : U7 := default
    let mut v54 : U7 := default
    match v0 with
    | U7.RegexAlt f59 f60 =>
        v59 := f59
        v60 := f60
        match v1 with
        | U7.RegexAlt f61 f62 =>
            v61 := f61
            v62 := f62
            v63 := (← regex_compare_16 v59 v61)
            match v63 with
            | U5.SymbolSame =>
                return (← regex_compare_16 v60 v62)
            | _ =>
                return v63
        | _ =>
            return U5.SymbolGreater
    | U7.RegexCat f34 f35 =>
        v34 := f34
        v35 := f35
        match v1 with
        | U7.RegexCat f40 f41 =>
            v40 := f40
            v41 := f41
            v42 := (← regex_compare_16 v34 v40)
            match v42 with
            | U5.SymbolSame =>
                return (← regex_compare_16 v35 v41)
            | _ =>
                return v42
        | U7.RegexChar f38 =>
            v38 := f38
            return U5.SymbolGreater
        | U7.RegexEmpty =>
            return U5.SymbolGreater
        | U7.RegexEpsilon =>
            return U5.SymbolGreater
        | _ =>
            return U5.SymbolLess
    | U7.RegexChar f10 =>
        v10 := f10
        match v1 with
        | U7.RegexChar f13 =>
            v13 := f13
            match v10 with
            | U2.TriA =>
                match v13 with
                | U2.TriA =>
                    return U5.SymbolSame
                | _ =>
                    return U5.SymbolLess
            | _ =>
                match v13 with
                | U2.TriA =>
                    return U5.SymbolGreater
                | _ =>
                    match v10 with
                    | U2.TriB =>
                        match v13 with
                        | U2.TriB =>
                            return U5.SymbolSame
                        | U2.TriC =>
                            return U5.SymbolLess
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | U2.TriC =>
                        match v13 with
                        | U2.TriB =>
                            return U5.SymbolGreater
                        | U2.TriC =>
                            return U5.SymbolSame
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | _ =>
                        spiralFail "union unbox: unreachable case"
        | U7.RegexEmpty =>
            return U5.SymbolGreater
        | U7.RegexEpsilon =>
            return U5.SymbolGreater
        | _ =>
            return U5.SymbolLess
    | U7.RegexEmpty =>
        match v1 with
        | U7.RegexEmpty =>
            return U5.SymbolSame
        | _ =>
            return U5.SymbolLess
    | U7.RegexEpsilon =>
        match v1 with
        | U7.RegexEmpty =>
            return U5.SymbolGreater
        | U7.RegexEpsilon =>
            return U5.SymbolSame
        | _ =>
            return U5.SymbolLess
    | U7.RegexStar f50 =>
        v50 := f50
        match v1 with
        | U7.RegexAlt f51 f52 =>
            v51 := f51
            v52 := f52
            return U5.SymbolLess
        | U7.RegexStar f54 =>
            v54 := f54
            return (← regex_compare_16 v50 v54)
        | _ =>
            return U5.SymbolGreater
partial def alt_insert_sorted_15 (p0 : U7) (p1 : U7) : IO U7 := do
    let mut v0 : U7 := p0
    let mut v1 : U7 := p1
    let mut v2 : U7 := default
    let mut v3 : U7 := default
    let mut v4 : U5 := default
    let mut v6 : U7 := default
    let mut v11 : U5 := default
    match v1 with
    | U7.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← regex_compare_16 v0 v2)
        match v4 with
        | U5.SymbolGreater =>
            v6 := (← alt_insert_sorted_15 v0 v3)
            return (U7.RegexAlt v2 v6)
        | U5.SymbolLess =>
            return (U7.RegexAlt v0 v1)
        | U5.SymbolSame =>
            return v1
    | U7.RegexEmpty =>
        return v0
    | _ =>
        v11 := (← regex_compare_16 v0 v1)
        match v11 with
        | U5.SymbolGreater =>
            return (U7.RegexAlt v1 v0)
        | U5.SymbolLess =>
            return (U7.RegexAlt v0 v1)
        | U5.SymbolSame =>
            return v1
partial def make_alt_14 (p0 : U7) (p1 : U7) : IO U7 := do
    let mut v0 : U7 := p0
    let mut v1 : U7 := p1
    let mut v2 : U7 := default
    let mut v3 : U7 := default
    let mut v4 : U7 := default
    match v0 with
    | U7.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← alt_insert_sorted_15 v2 v1)
        return (← make_alt_14 v3 v4)
    | U7.RegexEmpty =>
        return v1
    | _ =>
        return (← alt_insert_sorted_15 v0 v1)
partial def regex_equal_18 (p0 : U7) (p1 : U7) : IO Bool := do
    let mut v0 : U7 := p0
    let mut v1 : U7 := p1
    let mut v24 : U7 := default
    let mut v25 : U7 := default
    let mut v26 : U7 := default
    let mut v27 : U7 := default
    let mut v28 : Bool := default
    let mut v32 : U7 := default
    let mut v33 : U7 := default
    let mut v34 : U7 := default
    let mut v35 : U7 := default
    let mut v36 : Bool := default
    let mut v4 : U2 := default
    let mut v5 : U2 := default
    let mut v21 : U5 := default
    let mut v40 : U7 := default
    let mut v41 : U7 := default
    match v0 with
    | U7.RegexAlt f24 f25 =>
        v24 := f24
        v25 := f25
        match v1 with
        | U7.RegexAlt f26 f27 =>
            v26 := f26
            v27 := f27
            v28 := (← regex_equal_18 v24 v26)
            if v28 then
                return (← regex_equal_18 v25 v27)
            else
                return false
        | _ =>
            return false
    | U7.RegexCat f32 f33 =>
        v32 := f32
        v33 := f33
        match v1 with
        | U7.RegexCat f34 f35 =>
            v34 := f34
            v35 := f35
            v36 := (← regex_equal_18 v32 v34)
            if v36 then
                return (← regex_equal_18 v33 v35)
            else
                return false
        | _ =>
            return false
    | U7.RegexChar f4 =>
        v4 := f4
        match v1 with
        | U7.RegexChar f5 =>
            v5 := f5
            match v4 with
            | U2.TriA =>
                match v5 with
                | U2.TriA =>
                    v21 := U5.SymbolSame
                | _ =>
                    v21 := U5.SymbolLess
            | _ =>
                match v5 with
                | U2.TriA =>
                    v21 := U5.SymbolGreater
                | _ =>
                    match v4 with
                    | U2.TriB =>
                        match v5 with
                        | U2.TriB =>
                            v21 := U5.SymbolSame
                        | U2.TriC =>
                            v21 := U5.SymbolLess
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | U2.TriC =>
                        match v5 with
                        | U2.TriB =>
                            v21 := U5.SymbolGreater
                        | U2.TriC =>
                            v21 := U5.SymbolSame
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | _ =>
                        spiralFail "union unbox: unreachable case"
            match v21 with
            | U5.SymbolSame =>
                return true
            | _ =>
                return false
        | _ =>
            return false
    | U7.RegexEmpty =>
        match v1 with
        | U7.RegexEmpty =>
            return true
        | _ =>
            return false
    | U7.RegexEpsilon =>
        match v1 with
        | U7.RegexEpsilon =>
            return true
        | _ =>
            return false
    | U7.RegexStar f40 =>
        v40 := f40
        match v1 with
        | U7.RegexStar f41 =>
            v41 := f41
            return (← regex_equal_18 v40 v41)
        | _ =>
            return false
partial def make_cat_17 (p0 : U7) (p1 : U7) : IO U7 := do
    let mut v0 : U7 := p0
    let mut v1 : U7 := p1
    let mut v12 : U7 := default
    let mut v13 : U7 := default
    let mut v14 : U7 := default
    let mut v4 : U7 := default
    let mut v5 : U7 := default
    let mut v6 : Bool := default
    match v0 with
    | U7.RegexEmpty =>
        return U7.RegexEmpty
    | _ =>
        match v1 with
        | U7.RegexEmpty =>
            return U7.RegexEmpty
        | _ =>
            match v0 with
            | U7.RegexEpsilon =>
                return v1
            | _ =>
                match v1 with
                | U7.RegexEpsilon =>
                    return v0
                | _ =>
                    match v0 with
                    | U7.RegexCat f12 f13 =>
                        v12 := f12
                        v13 := f13
                        v14 := (← make_cat_17 v13 v1)
                        return (U7.RegexCat v12 v14)
                    | U7.RegexStar f4 =>
                        v4 := f4
                        match v1 with
                        | U7.RegexStar f5 =>
                            v5 := f5
                            v6 := (← regex_equal_18 v4 v5)
                            if v6 then
                                return (U7.RegexStar v4)
                            else
                                return (U7.RegexCat v0 v1)
                        | _ =>
                            return (U7.RegexCat v0 v1)
                    | _ =>
                        return (U7.RegexCat v0 v1)
partial def make_star_19 (p0 : U7) : IO U7 := do
    let mut v0 : U7 := p0
    let mut v3 : U7 := default
    match v0 with
    | U7.RegexEmpty =>
        return U7.RegexEpsilon
    | U7.RegexEpsilon =>
        return U7.RegexEpsilon
    | U7.RegexStar f3 =>
        v3 := f3
        return (U7.RegexStar v3)
    | _ =>
        return (U7.RegexStar v0)
partial def normalize_13 (p0 : U7) : IO U7 := do
    let mut v0 : U7 := p0
    let mut v5 : U7 := default
    let mut v6 : U7 := default
    let mut v7 : U7 := default
    let mut v8 : U7 := default
    let mut v10 : U7 := default
    let mut v11 : U7 := default
    let mut v12 : U7 := default
    let mut v13 : U7 := default
    let mut v3 : U2 := default
    let mut v15 : U7 := default
    let mut v16 : U7 := default
    match v0 with
    | U7.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← normalize_13 v5)
        v8 := (← normalize_13 v6)
        return (← make_alt_14 v7 v8)
    | U7.RegexCat f10 f11 =>
        v10 := f10
        v11 := f11
        v12 := (← normalize_13 v10)
        v13 := (← normalize_13 v11)
        return (← make_cat_17 v12 v13)
    | U7.RegexChar f3 =>
        v3 := f3
        return (U7.RegexChar v3)
    | U7.RegexEmpty =>
        return U7.RegexEmpty
    | U7.RegexEpsilon =>
        return U7.RegexEpsilon
    | U7.RegexStar f15 =>
        v15 := f15
        v16 := (← normalize_13 v15)
        return (← make_star_19 v16)
partial def nullable_21 (p0 : U7) : IO U6 := do
    let mut v0 : U7 := p0
    let mut v5 : U7 := default
    let mut v6 : U7 := default
    let mut v7 : U6 := default
    let mut v8 : U6 := default
    let mut v16 : U7 := default
    let mut v17 : U7 := default
    let mut v18 : U6 := default
    let mut v19 : U6 := default
    let mut v3 : U2 := default
    let mut v25 : U7 := default
    match v0 with
    | U7.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← nullable_21 v5)
        v8 := (← nullable_21 v6)
        match v7 with
        | U6.Nullable =>
            return U6.Nullable
        | _ =>
            match v8 with
            | U6.Nullable =>
                return U6.Nullable
            | _ =>
                match v7 with
                | U6.NonNullable =>
                    match v8 with
                    | U6.NonNullable =>
                        return U6.NonNullable
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | _ =>
                    spiralFail "union unbox: unreachable case"
    | U7.RegexCat f16 f17 =>
        v16 := f16
        v17 := f17
        v18 := (← nullable_21 v16)
        v19 := (← nullable_21 v17)
        match v18 with
        | U6.Nullable =>
            match v19 with
            | U6.Nullable =>
                return U6.Nullable
            | _ =>
                return U6.NonNullable
        | _ =>
            return U6.NonNullable
    | U7.RegexChar f3 =>
        v3 := f3
        return U6.NonNullable
    | U7.RegexEmpty =>
        return U6.NonNullable
    | U7.RegexEpsilon =>
        return U6.Nullable
    | U7.RegexStar f25 =>
        v25 := f25
        return U6.Nullable
partial def derivative_20 (p0 : U7) (p1 : U2) : IO U7 := do
    let mut v0 : U7 := p0
    let mut v1 : U2 := p1
    let mut v25 : U7 := default
    let mut v26 : U7 := default
    let mut v27 : U7 := default
    let mut v28 : U7 := default
    let mut v30 : U7 := default
    let mut v31 : U7 := default
    let mut v32 : U6 := default
    let mut v37 : U7 := default
    let mut v33 : U7 := default
    let mut v34 : U7 := default
    let mut v35 : U7 := default
    let mut v4 : U2 := default
    let mut v20 : U5 := default
    let mut v21 : Bool := default
    let mut v41 : U7 := default
    let mut v42 : U7 := default
    let mut v43 : U7 := default
    match v0 with
    | U7.RegexAlt f25 f26 =>
        v25 := f25
        v26 := f26
        v27 := (← derivative_20 v25 v1)
        v28 := (← derivative_20 v26 v1)
        return (← make_alt_14 v27 v28)
    | U7.RegexCat f30 f31 =>
        v30 := f30
        v31 := f31
        v32 := (← nullable_21 v30)
        match v32 with
        | U6.NonNullable =>
            v37 := (← derivative_20 v30 v1)
            return (← make_cat_17 v37 v31)
        | U6.Nullable =>
            v33 := (← derivative_20 v30 v1)
            v34 := (← make_cat_17 v33 v31)
            v35 := (← derivative_20 v31 v1)
            return (← make_alt_14 v34 v35)
    | U7.RegexChar f4 =>
        v4 := f4
        match v4 with
        | U2.TriA =>
            match v1 with
            | U2.TriA =>
                v20 := U5.SymbolSame
            | _ =>
                v20 := U5.SymbolLess
        | _ =>
            match v1 with
            | U2.TriA =>
                v20 := U5.SymbolGreater
            | _ =>
                match v4 with
                | U2.TriB =>
                    match v1 with
                    | U2.TriB =>
                        v20 := U5.SymbolSame
                    | U2.TriC =>
                        v20 := U5.SymbolLess
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | U2.TriC =>
                    match v1 with
                    | U2.TriB =>
                        v20 := U5.SymbolGreater
                    | U2.TriC =>
                        v20 := U5.SymbolSame
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | _ =>
                    spiralFail "union unbox: unreachable case"
        match v20 with
        | U5.SymbolSame =>
            v21 := true
        | _ =>
            v21 := false
        if v21 then
            return U7.RegexEpsilon
        else
            return U7.RegexEmpty
    | U7.RegexEmpty =>
        return U7.RegexEmpty
    | U7.RegexEpsilon =>
        return U7.RegexEmpty
    | U7.RegexStar f41 =>
        v41 := f41
        v42 := (← derivative_20 v41 v1)
        v43 := (← make_star_19 v41)
        return (← make_cat_17 v42 v43)
partial def canonical_derivative_12 (p0 : U7) (p1 : U2) : IO U7 := do
    let mut v0 : U7 := p0
    let mut v1 : U2 := p1
    let v2 : U7 := (← normalize_13 v0)
    let v3 : U7 := (← derivative_20 v2 v1)
    return (← normalize_13 v3)
partial def accepts_11 (p0 : U7) (p1 : U3) : IO Bool := do
    let mut v0 : U7 := p0
    let mut v1 : U3 := p1
    let mut v6 : U2 := default
    let mut v7 : U3 := default
    let mut v8 : U7 := default
    let mut v2 : U7 := default
    let mut v3 : U6 := default
    match v1 with
    | U3.InputCons f6 f7 =>
        v6 := f6
        v7 := f7
        v8 := (← canonical_derivative_12 v0 v6)
        return (← accepts_11 v8 v7)
    | U3.InputEmpty =>
        v2 := (← normalize_13 v0)
        v3 := (← nullable_21 v2)
        match v3 with
        | U6.NonNullable =>
            return false
        | U6.Nullable =>
            return true
partial def decide_bit_match_22 (p0 : U8) : IO U9 := do
    let mut v0 : U8 := p0
    let mut v1 : U4 := default
    let mut v2 : U1 := default
    let mut v3 : Bool := default
    match v0 with
    | U8.BitMatcherRaw f1 f2 =>
        v1 := f1
        v2 := f2
        v3 := (← accepts_0 v1 v2)
        return (U9.BitMatcherDecided v1 v2 v3)
partial def bit_match_value_23 (p0 : U9) : IO Bool := do
    let mut v0 : U9 := p0
    let mut v1 : U4 := default
    let mut v2 : U1 := default
    let mut v3 : Bool := default
    match v0 with
    | U9.BitMatcherDecided f1 f2 f3 =>
        v1 := f1
        v2 := f2
        v3 := f3
        return v3
partial def spiralMain : IO Int32 := do
    let v0 : U0 := U0.BitOne
    let v1 : U0 := U0.BitOne
    let v2 : U0 := U0.BitZero
    let v3 : U1 := U1.InputEmpty
    let v4 : U1 := (U1.InputCons v2 v3)
    let v5 : U1 := (U1.InputCons v1 v4)
    let v6 : U1 := (U1.InputCons v0 v5)
    let v7 : U0 := U0.BitOne
    let v8 : U0 := U0.BitOne
    let v9 : U0 := U0.BitOne
    let v10 : U1 := U1.InputEmpty
    let v11 : U1 := (U1.InputCons v9 v10)
    let v12 : U1 := (U1.InputCons v8 v11)
    let v13 : U1 := (U1.InputCons v7 v12)
    let v14 : U2 := U2.TriA
    let v15 : U2 := U2.TriA
    let v16 : U2 := U2.TriA
    let v17 : U3 := U3.InputEmpty
    let v18 : U3 := (U3.InputCons v16 v17)
    let v19 : U3 := (U3.InputCons v15 v18)
    let v20 : U3 := (U3.InputCons v14 v19)
    let v21 : U2 := U2.TriA
    let v22 : U2 := U2.TriA
    let v23 : U2 := U2.TriB
    let v24 : U3 := U3.InputEmpty
    let v25 : U3 := (U3.InputCons v23 v24)
    let v26 : U3 := (U3.InputCons v22 v25)
    let v27 : U3 := (U3.InputCons v21 v26)
    let v28 : U0 := U0.BitZero
    let v29 : U4 := (U4.RegexChar v28)
    let v30 : U0 := U0.BitOne
    let v31 : U4 := (U4.RegexChar v30)
    let v32 : U4 := (U4.RegexAlt v29 v31)
    let v33 : U4 := (U4.RegexStar v32)
    let v34 : U0 := U0.BitZero
    let v35 : U4 := (U4.RegexChar v34)
    let v36 : U4 := (U4.RegexCat v33 v35)
    let v37 : Bool := (← accepts_0 v36 v6)
    if v37 then
        pure ()
    else
        spiralFail "brzozowski-expected-true"
    let v38 : U0 := U0.BitZero
    let v39 : U4 := (U4.RegexChar v38)
    let v40 : U0 := U0.BitOne
    let v41 : U4 := (U4.RegexChar v40)
    let v42 : U4 := (U4.RegexAlt v39 v41)
    let v43 : U4 := (U4.RegexStar v42)
    let v44 : U0 := U0.BitZero
    let v45 : U4 := (U4.RegexChar v44)
    let v46 : U4 := (U4.RegexCat v43 v45)
    let v47 : Bool := (← accepts_0 v46 v13)
    if v47 then
        spiralFail "brzozowski-expected-false"
    else
        pure ()
    let v48 : U2 := U2.TriA
    let v49 : U7 := (U7.RegexChar v48)
    let v50 : U7 := (U7.RegexStar v49)
    let v51 : Bool := (← accepts_11 v50 v20)
    if v51 then
        pure ()
    else
        spiralFail "brzozowski-expected-true"
    let v52 : U2 := U2.TriA
    let v53 : U7 := (U7.RegexChar v52)
    let v54 : U7 := (U7.RegexStar v53)
    let v55 : Bool := (← accepts_11 v54 v27)
    if v55 then
        spiralFail "brzozowski-expected-false"
    else
        pure ()
    let v56 : U0 := U0.BitZero
    let v57 : U4 := (U4.RegexChar v56)
    let v58 : U0 := U0.BitOne
    let v59 : U4 := (U4.RegexChar v58)
    let v60 : U4 := (U4.RegexAlt v57 v59)
    let v61 : U4 := (U4.RegexStar v60)
    let v62 : U0 := U0.BitZero
    let v63 : U4 := (U4.RegexChar v62)
    let v64 : U4 := (U4.RegexCat v61 v63)
    let v65 : U8 := (U8.BitMatcherRaw v64 v6)
    let v66 : U9 := (← decide_bit_match_22 v65)
    let v67 : U0 := U0.BitZero
    let v68 : U4 := (U4.RegexChar v67)
    let v69 : U0 := U0.BitOne
    let v70 : U4 := (U4.RegexChar v69)
    let v71 : U4 := (U4.RegexAlt v68 v70)
    let v72 : U4 := (U4.RegexStar v71)
    let v73 : U0 := U0.BitZero
    let v74 : U4 := (U4.RegexChar v73)
    let v75 : U4 := (U4.RegexCat v72 v74)
    let v76 : U8 := (U8.BitMatcherRaw v75 v13)
    let v77 : U9 := (← decide_bit_match_22 v76)
    let v78 : Bool := (← bit_match_value_23 v66)
    if v78 then
        pure ()
    else
        spiralFail "brzozowski-expected-true"
    let v79 : Bool := (← bit_match_value_23 v77)
    if v79 then
        spiralFail "brzozowski-expected-false"
    else
        pure ()
    return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
