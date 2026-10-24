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
  | SymbolListNil : U1
  | SymbolListCons : U0 → U1 → U1
end
deriving instance Inhabited for U1
mutual
inductive U3 where
  | InputEmpty : U3
  | InputCons : U0 → U3 → U3
end
deriving instance Inhabited for U3
mutual
inductive U2 where
  | InputListNil : U2
  | InputListCons : U3 → U2 → U2
end
deriving instance Inhabited for U2
mutual
inductive U4 where
  | TriA : U4
  | TriB : U4
  | TriC : U4
end
deriving instance Inhabited for U4
mutual
inductive U5 where
  | SymbolListNil : U5
  | SymbolListCons : U4 → U5 → U5
end
deriving instance Inhabited for U5
mutual
inductive U7 where
  | InputEmpty : U7
  | InputCons : U4 → U7 → U7
end
deriving instance Inhabited for U7
mutual
inductive U6 where
  | InputListNil : U6
  | InputListCons : U7 → U6 → U6
end
deriving instance Inhabited for U6
mutual
inductive U8 where
  | ModelA : U8
  | ModelB : U8
  | ModelC : U8
end
deriving instance Inhabited for U8
mutual
inductive U9 where
  | InputEmpty : U9
  | InputCons : U8 → U9 → U9
end
deriving instance Inhabited for U9
mutual
inductive U10 where
  | RegexEmpty : U10
  | RegexEpsilon : U10
  | RegexChar : U0 → U10
  | RegexAlt : U10 → U10 → U10
  | RegexCat : U10 → U10 → U10
  | RegexStar : U10 → U10
end
deriving instance Inhabited for U10
mutual
inductive U11 where
  | InventoryDfaAccepted : U11
  | InventoryDfaRejected : U11
  | InventoryDfaInputOutsideInventory : U11
end
deriving instance Inhabited for U11
mutual
inductive U12 where
  | SymbolLess : U12
  | SymbolSame : U12
  | SymbolGreater : U12
end
deriving instance Inhabited for U12
mutual
inductive U13 where
  | Nullable : U13
  | NonNullable : U13
end
deriving instance Inhabited for U13
mutual
inductive U14 where
  | RegexEmpty : U14
  | RegexEpsilon : U14
  | RegexChar : U4 → U14
  | RegexAlt : U14 → U14 → U14
  | RegexCat : U14 → U14 → U14
  | RegexStar : U14 → U14
end
deriving instance Inhabited for U14
def U0.spiralTag : U0 → Int32
  | .BitZero .. => 0
  | .BitOne .. => 1
def U1.spiralTag : U1 → Int32
  | .SymbolListNil .. => 0
  | .SymbolListCons .. => 1
def U3.spiralTag : U3 → Int32
  | .InputEmpty .. => 0
  | .InputCons .. => 1
def U2.spiralTag : U2 → Int32
  | .InputListNil .. => 0
  | .InputListCons .. => 1
def U4.spiralTag : U4 → Int32
  | .TriA .. => 0
  | .TriB .. => 1
  | .TriC .. => 2
def U5.spiralTag : U5 → Int32
  | .SymbolListNil .. => 0
  | .SymbolListCons .. => 1
def U7.spiralTag : U7 → Int32
  | .InputEmpty .. => 0
  | .InputCons .. => 1
def U6.spiralTag : U6 → Int32
  | .InputListNil .. => 0
  | .InputListCons .. => 1
def U8.spiralTag : U8 → Int32
  | .ModelA .. => 0
  | .ModelB .. => 1
  | .ModelC .. => 2
def U9.spiralTag : U9 → Int32
  | .InputEmpty .. => 0
  | .InputCons .. => 1
def U10.spiralTag : U10 → Int32
  | .RegexEmpty .. => 0
  | .RegexEpsilon .. => 1
  | .RegexChar .. => 2
  | .RegexAlt .. => 3
  | .RegexCat .. => 4
  | .RegexStar .. => 5
def U11.spiralTag : U11 → Int32
  | .InventoryDfaAccepted .. => 0
  | .InventoryDfaRejected .. => 1
  | .InventoryDfaInputOutsideInventory .. => 2
def U12.spiralTag : U12 → Int32
  | .SymbolLess .. => 0
  | .SymbolSame .. => 1
  | .SymbolGreater .. => 2
def U13.spiralTag : U13 → Int32
  | .Nullable .. => 0
  | .NonNullable .. => 1
def U14.spiralTag : U14 → Int32
  | .RegexEmpty .. => 0
  | .RegexEpsilon .. => 1
  | .RegexChar .. => 2
  | .RegexAlt .. => 3
  | .RegexCat .. => 4
  | .RegexStar .. => 5
mutual
partial def input_singletons_from_symbols_0 (p0 : U1) : IO U2 := do
    let mut v0 : U1 := p0
    let mut v2 : U0 := default
    let mut v3 : U1 := default
    let mut v4 : U2 := default
    let mut v5 : U3 := default
    let mut v6 : U3 := default
    match v0 with
    | U1.SymbolListCons f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← input_singletons_from_symbols_0 v3)
        v5 := U3.InputEmpty
        v6 := (U3.InputCons v2 v5)
        return (U2.InputListCons v6 v4)
    | U1.SymbolListNil =>
        return U2.InputListNil
partial def input_prepend_symbol_to_corpus_2 (p0 : U0) (p1 : U2) : IO U2 := do
    let mut v0 : U0 := p0
    let mut v1 : U2 := p1
    let mut v3 : U3 := default
    let mut v4 : U2 := default
    let mut v5 : U2 := default
    let mut v6 : U3 := default
    match v1 with
    | U2.InputListCons f3 f4 =>
        v3 := f3
        v4 := f4
        v5 := (← input_prepend_symbol_to_corpus_2 v0 v4)
        v6 := (U3.InputCons v0 v3)
        return (U2.InputListCons v6 v5)
    | U2.InputListNil =>
        return U2.InputListNil
partial def input_list_append_3 (p0 : U2) (p1 : U2) : IO U2 := do
    let mut v0 : U2 := p0
    let mut v1 : U2 := p1
    let mut v2 : U3 := default
    let mut v3 : U2 := default
    let mut v4 : U2 := default
    match v0 with
    | U2.InputListCons f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← input_list_append_3 v3 v1)
        return (U2.InputListCons v2 v4)
    | U2.InputListNil =>
        return v1
partial def input_prepend_symbols_to_corpus_1 (p0 : U1) (p1 : U2) : IO U2 := do
    let mut v0 : U1 := p0
    let mut v1 : U2 := p1
    let mut v3 : U0 := default
    let mut v4 : U1 := default
    let mut v5 : U2 := default
    let mut v6 : U2 := default
    match v0 with
    | U1.SymbolListCons f3 f4 =>
        v3 := f3
        v4 := f4
        v5 := (← input_prepend_symbol_to_corpus_2 v3 v1)
        v6 := (← input_prepend_symbols_to_corpus_1 v4 v1)
        return (← input_list_append_3 v5 v6)
    | U1.SymbolListNil =>
        return U2.InputListNil
partial def input_singletons_from_symbols_4 (p0 : U5) : IO U6 := do
    let mut v0 : U5 := p0
    let mut v2 : U4 := default
    let mut v3 : U5 := default
    let mut v4 : U6 := default
    let mut v5 : U7 := default
    let mut v6 : U7 := default
    match v0 with
    | U5.SymbolListCons f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← input_singletons_from_symbols_4 v3)
        v5 := U7.InputEmpty
        v6 := (U7.InputCons v2 v5)
        return (U6.InputListCons v6 v4)
    | U5.SymbolListNil =>
        return U6.InputListNil
partial def input_prepend_symbol_to_corpus_6 (p0 : U4) (p1 : U6) : IO U6 := do
    let mut v0 : U4 := p0
    let mut v1 : U6 := p1
    let mut v3 : U7 := default
    let mut v4 : U6 := default
    let mut v5 : U6 := default
    let mut v6 : U7 := default
    match v1 with
    | U6.InputListCons f3 f4 =>
        v3 := f3
        v4 := f4
        v5 := (← input_prepend_symbol_to_corpus_6 v0 v4)
        v6 := (U7.InputCons v0 v3)
        return (U6.InputListCons v6 v5)
    | U6.InputListNil =>
        return U6.InputListNil
partial def input_list_append_7 (p0 : U6) (p1 : U6) : IO U6 := do
    let mut v0 : U6 := p0
    let mut v1 : U6 := p1
    let mut v2 : U7 := default
    let mut v3 : U6 := default
    let mut v4 : U6 := default
    match v0 with
    | U6.InputListCons f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← input_list_append_7 v3 v1)
        return (U6.InputListCons v2 v4)
    | U6.InputListNil =>
        return v1
partial def input_prepend_symbols_to_corpus_5 (p0 : U5) (p1 : U6) : IO U6 := do
    let mut v0 : U5 := p0
    let mut v1 : U6 := p1
    let mut v3 : U4 := default
    let mut v4 : U5 := default
    let mut v5 : U6 := default
    let mut v6 : U6 := default
    match v0 with
    | U5.SymbolListCons f3 f4 =>
        v3 := f3
        v4 := f4
        v5 := (← input_prepend_symbol_to_corpus_6 v3 v1)
        v6 := (← input_prepend_symbols_to_corpus_5 v4 v1)
        return (← input_list_append_7 v5 v6)
    | U5.SymbolListNil =>
        return U6.InputListNil
partial def loop_9 (p0 : Int32) (p1 : U3) : IO U11 := do
    let mut v0 : Int32 := p0
    let mut v1 : U3 := p1
    let mut v6 : U0 := default
    let mut v7 : U3 := default
    let mut v11 : U12 := default
    let mut v12 : Bool := default
    let mut v19 : Int32 := default
    let mut v16 : U12 := default
    let mut v17 : Bool := default
    let mut v20 : Bool := default
    let mut v22 : Bool := default
    let mut v27 : Int32 := default
    let mut v23 : Bool := default
    let mut v25 : Bool := default
    let mut v2 : Bool := default
    match v1 with
    | U3.InputCons f6 f7 =>
        v6 := f6
        v7 := f7
        match v6 with
        | U0.BitOne =>
            v11 := U12.SymbolGreater
        | U0.BitZero =>
            v11 := U12.SymbolSame
        match v11 with
        | U12.SymbolSame =>
            v12 := true
        | _ =>
            v12 := false
        if v12 then
            v19 := (0 : Int32)
        else
            match v6 with
            | U0.BitOne =>
                v16 := U12.SymbolSame
            | U0.BitZero =>
                v16 := U12.SymbolLess
            match v16 with
            | U12.SymbolSame =>
                v17 := true
            | _ =>
                v17 := false
            if v17 then
                v19 := (1 : Int32)
            else
                v19 := (-1 : Int32)
        v20 := (decide (v19 < (0 : Int32)))
        if v20 then
            return U11.InventoryDfaInputOutsideInventory
        else
            v22 := (v0 == (0 : Int32))
            if v22 then
                v23 := (v19 == (0 : Int32))
                if v23 then
                    v27 := (0 : Int32)
                else
                    v27 := (1 : Int32)
            else
                v25 := (v19 == (0 : Int32))
                if v25 then
                    v27 := (0 : Int32)
                else
                    v27 := (1 : Int32)
            return (← loop_9 v27 v7)
    | U3.InputEmpty =>
        v2 := (v0 == (0 : Int32))
        if v2 then
            return U11.InventoryDfaAccepted
        else
            return U11.InventoryDfaRejected
partial def regex_compare_15 (p0 : U10) (p1 : U10) : IO U12 := do
    let mut v0 : U10 := p0
    let mut v1 : U10 := p1
    let mut v53 : U10 := default
    let mut v54 : U10 := default
    let mut v55 : U10 := default
    let mut v56 : U10 := default
    let mut v57 : U12 := default
    let mut v28 : U10 := default
    let mut v29 : U10 := default
    let mut v34 : U10 := default
    let mut v35 : U10 := default
    let mut v36 : U12 := default
    let mut v32 : U0 := default
    let mut v10 : U0 := default
    let mut v13 : U0 := default
    let mut v44 : U10 := default
    let mut v45 : U10 := default
    let mut v46 : U10 := default
    let mut v48 : U10 := default
    match v0 with
    | U10.RegexAlt f53 f54 =>
        v53 := f53
        v54 := f54
        match v1 with
        | U10.RegexAlt f55 f56 =>
            v55 := f55
            v56 := f56
            v57 := (← regex_compare_15 v53 v55)
            match v57 with
            | U12.SymbolSame =>
                return (← regex_compare_15 v54 v56)
            | _ =>
                return v57
        | _ =>
            return U12.SymbolGreater
    | U10.RegexCat f28 f29 =>
        v28 := f28
        v29 := f29
        match v1 with
        | U10.RegexCat f34 f35 =>
            v34 := f34
            v35 := f35
            v36 := (← regex_compare_15 v28 v34)
            match v36 with
            | U12.SymbolSame =>
                return (← regex_compare_15 v29 v35)
            | _ =>
                return v36
        | U10.RegexChar f32 =>
            v32 := f32
            return U12.SymbolGreater
        | U10.RegexEmpty =>
            return U12.SymbolGreater
        | U10.RegexEpsilon =>
            return U12.SymbolGreater
        | _ =>
            return U12.SymbolLess
    | U10.RegexChar f10 =>
        v10 := f10
        match v1 with
        | U10.RegexChar f13 =>
            v13 := f13
            match v10 with
            | U0.BitOne =>
                match v13 with
                | U0.BitOne =>
                    return U12.SymbolSame
                | U0.BitZero =>
                    return U12.SymbolGreater
            | U0.BitZero =>
                match v13 with
                | U0.BitOne =>
                    return U12.SymbolLess
                | U0.BitZero =>
                    return U12.SymbolSame
        | U10.RegexEmpty =>
            return U12.SymbolGreater
        | U10.RegexEpsilon =>
            return U12.SymbolGreater
        | _ =>
            return U12.SymbolLess
    | U10.RegexEmpty =>
        match v1 with
        | U10.RegexEmpty =>
            return U12.SymbolSame
        | _ =>
            return U12.SymbolLess
    | U10.RegexEpsilon =>
        match v1 with
        | U10.RegexEmpty =>
            return U12.SymbolGreater
        | U10.RegexEpsilon =>
            return U12.SymbolSame
        | _ =>
            return U12.SymbolLess
    | U10.RegexStar f44 =>
        v44 := f44
        match v1 with
        | U10.RegexAlt f45 f46 =>
            v45 := f45
            v46 := f46
            return U12.SymbolLess
        | U10.RegexStar f48 =>
            v48 := f48
            return (← regex_compare_15 v44 v48)
        | _ =>
            return U12.SymbolGreater
partial def alt_insert_sorted_14 (p0 : U10) (p1 : U10) : IO U10 := do
    let mut v0 : U10 := p0
    let mut v1 : U10 := p1
    let mut v2 : U10 := default
    let mut v3 : U10 := default
    let mut v4 : U12 := default
    let mut v6 : U10 := default
    let mut v11 : U12 := default
    match v1 with
    | U10.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← regex_compare_15 v0 v2)
        match v4 with
        | U12.SymbolGreater =>
            v6 := (← alt_insert_sorted_14 v0 v3)
            return (U10.RegexAlt v2 v6)
        | U12.SymbolLess =>
            return (U10.RegexAlt v0 v1)
        | U12.SymbolSame =>
            return v1
    | U10.RegexEmpty =>
        return v0
    | _ =>
        v11 := (← regex_compare_15 v0 v1)
        match v11 with
        | U12.SymbolGreater =>
            return (U10.RegexAlt v1 v0)
        | U12.SymbolLess =>
            return (U10.RegexAlt v0 v1)
        | U12.SymbolSame =>
            return v1
partial def make_alt_13 (p0 : U10) (p1 : U10) : IO U10 := do
    let mut v0 : U10 := p0
    let mut v1 : U10 := p1
    let mut v2 : U10 := default
    let mut v3 : U10 := default
    let mut v4 : U10 := default
    match v0 with
    | U10.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← alt_insert_sorted_14 v2 v1)
        return (← make_alt_13 v3 v4)
    | U10.RegexEmpty =>
        return v1
    | _ =>
        return (← alt_insert_sorted_14 v0 v1)
partial def regex_equal_17 (p0 : U10) (p1 : U10) : IO Bool := do
    let mut v0 : U10 := p0
    let mut v1 : U10 := p1
    let mut v18 : U10 := default
    let mut v19 : U10 := default
    let mut v20 : U10 := default
    let mut v21 : U10 := default
    let mut v22 : Bool := default
    let mut v26 : U10 := default
    let mut v27 : U10 := default
    let mut v28 : U10 := default
    let mut v29 : U10 := default
    let mut v30 : Bool := default
    let mut v4 : U0 := default
    let mut v5 : U0 := default
    let mut v15 : U12 := default
    let mut v34 : U10 := default
    let mut v35 : U10 := default
    match v0 with
    | U10.RegexAlt f18 f19 =>
        v18 := f18
        v19 := f19
        match v1 with
        | U10.RegexAlt f20 f21 =>
            v20 := f20
            v21 := f21
            v22 := (← regex_equal_17 v18 v20)
            if v22 then
                return (← regex_equal_17 v19 v21)
            else
                return false
        | _ =>
            return false
    | U10.RegexCat f26 f27 =>
        v26 := f26
        v27 := f27
        match v1 with
        | U10.RegexCat f28 f29 =>
            v28 := f28
            v29 := f29
            v30 := (← regex_equal_17 v26 v28)
            if v30 then
                return (← regex_equal_17 v27 v29)
            else
                return false
        | _ =>
            return false
    | U10.RegexChar f4 =>
        v4 := f4
        match v1 with
        | U10.RegexChar f5 =>
            v5 := f5
            match v4 with
            | U0.BitOne =>
                match v5 with
                | U0.BitOne =>
                    v15 := U12.SymbolSame
                | U0.BitZero =>
                    v15 := U12.SymbolGreater
            | U0.BitZero =>
                match v5 with
                | U0.BitOne =>
                    v15 := U12.SymbolLess
                | U0.BitZero =>
                    v15 := U12.SymbolSame
            match v15 with
            | U12.SymbolSame =>
                return true
            | _ =>
                return false
        | _ =>
            return false
    | U10.RegexEmpty =>
        match v1 with
        | U10.RegexEmpty =>
            return true
        | _ =>
            return false
    | U10.RegexEpsilon =>
        match v1 with
        | U10.RegexEpsilon =>
            return true
        | _ =>
            return false
    | U10.RegexStar f34 =>
        v34 := f34
        match v1 with
        | U10.RegexStar f35 =>
            v35 := f35
            return (← regex_equal_17 v34 v35)
        | _ =>
            return false
partial def make_cat_16 (p0 : U10) (p1 : U10) : IO U10 := do
    let mut v0 : U10 := p0
    let mut v1 : U10 := p1
    let mut v12 : U10 := default
    let mut v13 : U10 := default
    let mut v14 : U10 := default
    let mut v4 : U10 := default
    let mut v5 : U10 := default
    let mut v6 : Bool := default
    match v0 with
    | U10.RegexEmpty =>
        return U10.RegexEmpty
    | _ =>
        match v1 with
        | U10.RegexEmpty =>
            return U10.RegexEmpty
        | _ =>
            match v0 with
            | U10.RegexEpsilon =>
                return v1
            | _ =>
                match v1 with
                | U10.RegexEpsilon =>
                    return v0
                | _ =>
                    match v0 with
                    | U10.RegexCat f12 f13 =>
                        v12 := f12
                        v13 := f13
                        v14 := (← make_cat_16 v13 v1)
                        return (U10.RegexCat v12 v14)
                    | U10.RegexStar f4 =>
                        v4 := f4
                        match v1 with
                        | U10.RegexStar f5 =>
                            v5 := f5
                            v6 := (← regex_equal_17 v4 v5)
                            if v6 then
                                return (U10.RegexStar v4)
                            else
                                return (U10.RegexCat v0 v1)
                        | _ =>
                            return (U10.RegexCat v0 v1)
                    | _ =>
                        return (U10.RegexCat v0 v1)
partial def make_star_18 (p0 : U10) : IO U10 := do
    let mut v0 : U10 := p0
    let mut v3 : U10 := default
    match v0 with
    | U10.RegexEmpty =>
        return U10.RegexEpsilon
    | U10.RegexEpsilon =>
        return U10.RegexEpsilon
    | U10.RegexStar f3 =>
        v3 := f3
        return (U10.RegexStar v3)
    | _ =>
        return (U10.RegexStar v0)
partial def normalize_12 (p0 : U10) : IO U10 := do
    let mut v0 : U10 := p0
    let mut v5 : U10 := default
    let mut v6 : U10 := default
    let mut v7 : U10 := default
    let mut v8 : U10 := default
    let mut v10 : U10 := default
    let mut v11 : U10 := default
    let mut v12 : U10 := default
    let mut v13 : U10 := default
    let mut v3 : U0 := default
    let mut v15 : U10 := default
    let mut v16 : U10 := default
    match v0 with
    | U10.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← normalize_12 v5)
        v8 := (← normalize_12 v6)
        return (← make_alt_13 v7 v8)
    | U10.RegexCat f10 f11 =>
        v10 := f10
        v11 := f11
        v12 := (← normalize_12 v10)
        v13 := (← normalize_12 v11)
        return (← make_cat_16 v12 v13)
    | U10.RegexChar f3 =>
        v3 := f3
        return (U10.RegexChar v3)
    | U10.RegexEmpty =>
        return U10.RegexEmpty
    | U10.RegexEpsilon =>
        return U10.RegexEpsilon
    | U10.RegexStar f15 =>
        v15 := f15
        v16 := (← normalize_12 v15)
        return (← make_star_18 v16)
partial def nullable_20 (p0 : U10) : IO U13 := do
    let mut v0 : U10 := p0
    let mut v5 : U10 := default
    let mut v6 : U10 := default
    let mut v7 : U13 := default
    let mut v8 : U13 := default
    let mut v16 : U10 := default
    let mut v17 : U10 := default
    let mut v18 : U13 := default
    let mut v19 : U13 := default
    let mut v3 : U0 := default
    let mut v25 : U10 := default
    match v0 with
    | U10.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← nullable_20 v5)
        v8 := (← nullable_20 v6)
        match v7 with
        | U13.Nullable =>
            return U13.Nullable
        | _ =>
            match v8 with
            | U13.Nullable =>
                return U13.Nullable
            | _ =>
                match v7 with
                | U13.NonNullable =>
                    match v8 with
                    | U13.NonNullable =>
                        return U13.NonNullable
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | _ =>
                    spiralFail "union unbox: unreachable case"
    | U10.RegexCat f16 f17 =>
        v16 := f16
        v17 := f17
        v18 := (← nullable_20 v16)
        v19 := (← nullable_20 v17)
        match v18 with
        | U13.Nullable =>
            match v19 with
            | U13.Nullable =>
                return U13.Nullable
            | _ =>
                return U13.NonNullable
        | _ =>
            return U13.NonNullable
    | U10.RegexChar f3 =>
        v3 := f3
        return U13.NonNullable
    | U10.RegexEmpty =>
        return U13.NonNullable
    | U10.RegexEpsilon =>
        return U13.Nullable
    | U10.RegexStar f25 =>
        v25 := f25
        return U13.Nullable
partial def derivative_19 (p0 : U10) (p1 : U0) : IO U10 := do
    let mut v0 : U10 := p0
    let mut v1 : U0 := p1
    let mut v19 : U10 := default
    let mut v20 : U10 := default
    let mut v21 : U10 := default
    let mut v22 : U10 := default
    let mut v24 : U10 := default
    let mut v25 : U10 := default
    let mut v26 : U13 := default
    let mut v31 : U10 := default
    let mut v27 : U10 := default
    let mut v28 : U10 := default
    let mut v29 : U10 := default
    let mut v4 : U0 := default
    let mut v14 : U12 := default
    let mut v15 : Bool := default
    let mut v35 : U10 := default
    let mut v36 : U10 := default
    let mut v37 : U10 := default
    match v0 with
    | U10.RegexAlt f19 f20 =>
        v19 := f19
        v20 := f20
        v21 := (← derivative_19 v19 v1)
        v22 := (← derivative_19 v20 v1)
        return (← make_alt_13 v21 v22)
    | U10.RegexCat f24 f25 =>
        v24 := f24
        v25 := f25
        v26 := (← nullable_20 v24)
        match v26 with
        | U13.NonNullable =>
            v31 := (← derivative_19 v24 v1)
            return (← make_cat_16 v31 v25)
        | U13.Nullable =>
            v27 := (← derivative_19 v24 v1)
            v28 := (← make_cat_16 v27 v25)
            v29 := (← derivative_19 v25 v1)
            return (← make_alt_13 v28 v29)
    | U10.RegexChar f4 =>
        v4 := f4
        match v4 with
        | U0.BitOne =>
            match v1 with
            | U0.BitOne =>
                v14 := U12.SymbolSame
            | U0.BitZero =>
                v14 := U12.SymbolGreater
        | U0.BitZero =>
            match v1 with
            | U0.BitOne =>
                v14 := U12.SymbolLess
            | U0.BitZero =>
                v14 := U12.SymbolSame
        match v14 with
        | U12.SymbolSame =>
            v15 := true
        | _ =>
            v15 := false
        if v15 then
            return U10.RegexEpsilon
        else
            return U10.RegexEmpty
    | U10.RegexEmpty =>
        return U10.RegexEmpty
    | U10.RegexEpsilon =>
        return U10.RegexEmpty
    | U10.RegexStar f35 =>
        v35 := f35
        v36 := (← derivative_19 v35 v1)
        v37 := (← make_star_18 v35)
        return (← make_cat_16 v36 v37)
partial def canonical_derivative_11 (p0 : U10) (p1 : U0) : IO U10 := do
    let mut v0 : U10 := p0
    let mut v1 : U0 := p1
    let v2 : U10 := (← normalize_12 v0)
    let v3 : U10 := (← derivative_19 v2 v1)
    return (← normalize_12 v3)
partial def accepts_10 (p0 : U10) (p1 : U3) : IO Bool := do
    let mut v0 : U10 := p0
    let mut v1 : U3 := p1
    let mut v6 : U0 := default
    let mut v7 : U3 := default
    let mut v8 : U10 := default
    let mut v2 : U10 := default
    let mut v3 : U13 := default
    match v1 with
    | U3.InputCons f6 f7 =>
        v6 := f6
        v7 := f7
        v8 := (← canonical_derivative_11 v0 v6)
        return (← accepts_10 v8 v7)
    | U3.InputEmpty =>
        v2 := (← normalize_12 v0)
        v3 := (← nullable_20 v2)
        match v3 with
        | U13.NonNullable =>
            return false
        | U13.Nullable =>
            return true
partial def loop_8 (p0 : U10) (p1 : U2) : IO Bool := do
    let mut v0 : U10 := p0
    let mut v1 : U2 := p1
    let mut v2 : U3 := default
    let mut v3 : U2 := default
    let mut v4 : Int32 := default
    let mut v5 : U11 := default
    let mut v11 : Bool := default
    let mut v7 : Bool := default
    let mut v8 : Bool := default
    match v1 with
    | U2.InputListCons f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (1 : Int32)
        v5 := (← loop_9 v4 v2)
        match v5 with
        | U11.InventoryDfaAccepted =>
            v11 := (← accepts_10 v0 v2)
        | U11.InventoryDfaInputOutsideInventory =>
            v11 := false
        | U11.InventoryDfaRejected =>
            v7 := (← accepts_10 v0 v2)
            v8 := (v7 == false)
            v11 := v8
        if v11 then
            return (← loop_8 v0 v3)
        else
            return false
    | U2.InputListNil =>
        return true
partial def loop_22 (p0 : Int32) (p1 : U7) : IO U11 := do
    let mut v0 : Int32 := p0
    let mut v1 : U7 := p1
    let mut v8 : U4 := default
    let mut v9 : U7 := default
    let mut v12 : U12 := default
    let mut v13 : Bool := default
    let mut v30 : Int32 := default
    let mut v19 : U12 := default
    let mut v20 : Bool := default
    let mut v26 : U12 := default
    let mut v27 : Bool := default
    let mut v31 : Bool := default
    let mut v33 : Bool := default
    let mut v46 : Int32 := default
    let mut v34 : Bool := default
    let mut v37 : Bool := default
    let mut v38 : Bool := default
    let mut v41 : Bool := default
    let mut v42 : Bool := default
    let mut v2 : Bool := default
    let mut v4 : Bool := default
    let mut v3 : Bool := default
    match v1 with
    | U7.InputCons f8 f9 =>
        v8 := f8
        v9 := f9
        match v8 with
        | U4.TriA =>
            v12 := U12.SymbolSame
        | _ =>
            v12 := U12.SymbolGreater
        match v12 with
        | U12.SymbolSame =>
            v13 := true
        | _ =>
            v13 := false
        if v13 then
            v30 := (0 : Int32)
        else
            match v8 with
            | U4.TriA =>
                v19 := U12.SymbolLess
            | U4.TriB =>
                v19 := U12.SymbolSame
            | U4.TriC =>
                v19 := U12.SymbolGreater
            match v19 with
            | U12.SymbolSame =>
                v20 := true
            | _ =>
                v20 := false
            if v20 then
                v30 := (1 : Int32)
            else
                match v8 with
                | U4.TriA =>
                    v26 := U12.SymbolLess
                | U4.TriB =>
                    v26 := U12.SymbolLess
                | U4.TriC =>
                    v26 := U12.SymbolSame
                match v26 with
                | U12.SymbolSame =>
                    v27 := true
                | _ =>
                    v27 := false
                if v27 then
                    v30 := (2 : Int32)
                else
                    v30 := (-1 : Int32)
        v31 := (decide (v30 < (0 : Int32)))
        if v31 then
            return U11.InventoryDfaInputOutsideInventory
        else
            v33 := (v0 == (0 : Int32))
            if v33 then
                v34 := (v30 == (0 : Int32))
                if v34 then
                    v46 := (0 : Int32)
                else
                    v46 := (0 : Int32)
            else
                v37 := (v0 == (1 : Int32))
                if v37 then
                    v38 := (v30 == (0 : Int32))
                    if v38 then
                        v46 := (0 : Int32)
                    else
                        v46 := (0 : Int32)
                else
                    v41 := (v30 == (0 : Int32))
                    if v41 then
                        v46 := (2 : Int32)
                    else
                        v42 := (v30 == (1 : Int32))
                        if v42 then
                            v46 := (2 : Int32)
                        else
                            v46 := (1 : Int32)
            return (← loop_22 v46 v9)
    | U7.InputEmpty =>
        v2 := (v0 == (0 : Int32))
        if v2 then
            v4 := false
        else
            v3 := (v0 == (1 : Int32))
            v4 := v3
        if v4 then
            return U11.InventoryDfaAccepted
        else
            return U11.InventoryDfaRejected
partial def regex_compare_28 (p0 : U14) (p1 : U14) : IO U12 := do
    let mut v0 : U14 := p0
    let mut v1 : U14 := p1
    let mut v59 : U14 := default
    let mut v60 : U14 := default
    let mut v61 : U14 := default
    let mut v62 : U14 := default
    let mut v63 : U12 := default
    let mut v34 : U14 := default
    let mut v35 : U14 := default
    let mut v40 : U14 := default
    let mut v41 : U14 := default
    let mut v42 : U12 := default
    let mut v38 : U4 := default
    let mut v10 : U4 := default
    let mut v13 : U4 := default
    let mut v50 : U14 := default
    let mut v51 : U14 := default
    let mut v52 : U14 := default
    let mut v54 : U14 := default
    match v0 with
    | U14.RegexAlt f59 f60 =>
        v59 := f59
        v60 := f60
        match v1 with
        | U14.RegexAlt f61 f62 =>
            v61 := f61
            v62 := f62
            v63 := (← regex_compare_28 v59 v61)
            match v63 with
            | U12.SymbolSame =>
                return (← regex_compare_28 v60 v62)
            | _ =>
                return v63
        | _ =>
            return U12.SymbolGreater
    | U14.RegexCat f34 f35 =>
        v34 := f34
        v35 := f35
        match v1 with
        | U14.RegexCat f40 f41 =>
            v40 := f40
            v41 := f41
            v42 := (← regex_compare_28 v34 v40)
            match v42 with
            | U12.SymbolSame =>
                return (← regex_compare_28 v35 v41)
            | _ =>
                return v42
        | U14.RegexChar f38 =>
            v38 := f38
            return U12.SymbolGreater
        | U14.RegexEmpty =>
            return U12.SymbolGreater
        | U14.RegexEpsilon =>
            return U12.SymbolGreater
        | _ =>
            return U12.SymbolLess
    | U14.RegexChar f10 =>
        v10 := f10
        match v1 with
        | U14.RegexChar f13 =>
            v13 := f13
            match v10 with
            | U4.TriA =>
                match v13 with
                | U4.TriA =>
                    return U12.SymbolSame
                | _ =>
                    return U12.SymbolLess
            | _ =>
                match v13 with
                | U4.TriA =>
                    return U12.SymbolGreater
                | _ =>
                    match v10 with
                    | U4.TriB =>
                        match v13 with
                        | U4.TriB =>
                            return U12.SymbolSame
                        | U4.TriC =>
                            return U12.SymbolLess
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | U4.TriC =>
                        match v13 with
                        | U4.TriB =>
                            return U12.SymbolGreater
                        | U4.TriC =>
                            return U12.SymbolSame
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | _ =>
                        spiralFail "union unbox: unreachable case"
        | U14.RegexEmpty =>
            return U12.SymbolGreater
        | U14.RegexEpsilon =>
            return U12.SymbolGreater
        | _ =>
            return U12.SymbolLess
    | U14.RegexEmpty =>
        match v1 with
        | U14.RegexEmpty =>
            return U12.SymbolSame
        | _ =>
            return U12.SymbolLess
    | U14.RegexEpsilon =>
        match v1 with
        | U14.RegexEmpty =>
            return U12.SymbolGreater
        | U14.RegexEpsilon =>
            return U12.SymbolSame
        | _ =>
            return U12.SymbolLess
    | U14.RegexStar f50 =>
        v50 := f50
        match v1 with
        | U14.RegexAlt f51 f52 =>
            v51 := f51
            v52 := f52
            return U12.SymbolLess
        | U14.RegexStar f54 =>
            v54 := f54
            return (← regex_compare_28 v50 v54)
        | _ =>
            return U12.SymbolGreater
partial def alt_insert_sorted_27 (p0 : U14) (p1 : U14) : IO U14 := do
    let mut v0 : U14 := p0
    let mut v1 : U14 := p1
    let mut v2 : U14 := default
    let mut v3 : U14 := default
    let mut v4 : U12 := default
    let mut v6 : U14 := default
    let mut v11 : U12 := default
    match v1 with
    | U14.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← regex_compare_28 v0 v2)
        match v4 with
        | U12.SymbolGreater =>
            v6 := (← alt_insert_sorted_27 v0 v3)
            return (U14.RegexAlt v2 v6)
        | U12.SymbolLess =>
            return (U14.RegexAlt v0 v1)
        | U12.SymbolSame =>
            return v1
    | U14.RegexEmpty =>
        return v0
    | _ =>
        v11 := (← regex_compare_28 v0 v1)
        match v11 with
        | U12.SymbolGreater =>
            return (U14.RegexAlt v1 v0)
        | U12.SymbolLess =>
            return (U14.RegexAlt v0 v1)
        | U12.SymbolSame =>
            return v1
partial def make_alt_26 (p0 : U14) (p1 : U14) : IO U14 := do
    let mut v0 : U14 := p0
    let mut v1 : U14 := p1
    let mut v2 : U14 := default
    let mut v3 : U14 := default
    let mut v4 : U14 := default
    match v0 with
    | U14.RegexAlt f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (← alt_insert_sorted_27 v2 v1)
        return (← make_alt_26 v3 v4)
    | U14.RegexEmpty =>
        return v1
    | _ =>
        return (← alt_insert_sorted_27 v0 v1)
partial def regex_equal_30 (p0 : U14) (p1 : U14) : IO Bool := do
    let mut v0 : U14 := p0
    let mut v1 : U14 := p1
    let mut v24 : U14 := default
    let mut v25 : U14 := default
    let mut v26 : U14 := default
    let mut v27 : U14 := default
    let mut v28 : Bool := default
    let mut v32 : U14 := default
    let mut v33 : U14 := default
    let mut v34 : U14 := default
    let mut v35 : U14 := default
    let mut v36 : Bool := default
    let mut v4 : U4 := default
    let mut v5 : U4 := default
    let mut v21 : U12 := default
    let mut v40 : U14 := default
    let mut v41 : U14 := default
    match v0 with
    | U14.RegexAlt f24 f25 =>
        v24 := f24
        v25 := f25
        match v1 with
        | U14.RegexAlt f26 f27 =>
            v26 := f26
            v27 := f27
            v28 := (← regex_equal_30 v24 v26)
            if v28 then
                return (← regex_equal_30 v25 v27)
            else
                return false
        | _ =>
            return false
    | U14.RegexCat f32 f33 =>
        v32 := f32
        v33 := f33
        match v1 with
        | U14.RegexCat f34 f35 =>
            v34 := f34
            v35 := f35
            v36 := (← regex_equal_30 v32 v34)
            if v36 then
                return (← regex_equal_30 v33 v35)
            else
                return false
        | _ =>
            return false
    | U14.RegexChar f4 =>
        v4 := f4
        match v1 with
        | U14.RegexChar f5 =>
            v5 := f5
            match v4 with
            | U4.TriA =>
                match v5 with
                | U4.TriA =>
                    v21 := U12.SymbolSame
                | _ =>
                    v21 := U12.SymbolLess
            | _ =>
                match v5 with
                | U4.TriA =>
                    v21 := U12.SymbolGreater
                | _ =>
                    match v4 with
                    | U4.TriB =>
                        match v5 with
                        | U4.TriB =>
                            v21 := U12.SymbolSame
                        | U4.TriC =>
                            v21 := U12.SymbolLess
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | U4.TriC =>
                        match v5 with
                        | U4.TriB =>
                            v21 := U12.SymbolGreater
                        | U4.TriC =>
                            v21 := U12.SymbolSame
                        | _ =>
                            spiralFail "union unbox: unreachable case"
                    | _ =>
                        spiralFail "union unbox: unreachable case"
            match v21 with
            | U12.SymbolSame =>
                return true
            | _ =>
                return false
        | _ =>
            return false
    | U14.RegexEmpty =>
        match v1 with
        | U14.RegexEmpty =>
            return true
        | _ =>
            return false
    | U14.RegexEpsilon =>
        match v1 with
        | U14.RegexEpsilon =>
            return true
        | _ =>
            return false
    | U14.RegexStar f40 =>
        v40 := f40
        match v1 with
        | U14.RegexStar f41 =>
            v41 := f41
            return (← regex_equal_30 v40 v41)
        | _ =>
            return false
partial def make_cat_29 (p0 : U14) (p1 : U14) : IO U14 := do
    let mut v0 : U14 := p0
    let mut v1 : U14 := p1
    let mut v12 : U14 := default
    let mut v13 : U14 := default
    let mut v14 : U14 := default
    let mut v4 : U14 := default
    let mut v5 : U14 := default
    let mut v6 : Bool := default
    match v0 with
    | U14.RegexEmpty =>
        return U14.RegexEmpty
    | _ =>
        match v1 with
        | U14.RegexEmpty =>
            return U14.RegexEmpty
        | _ =>
            match v0 with
            | U14.RegexEpsilon =>
                return v1
            | _ =>
                match v1 with
                | U14.RegexEpsilon =>
                    return v0
                | _ =>
                    match v0 with
                    | U14.RegexCat f12 f13 =>
                        v12 := f12
                        v13 := f13
                        v14 := (← make_cat_29 v13 v1)
                        return (U14.RegexCat v12 v14)
                    | U14.RegexStar f4 =>
                        v4 := f4
                        match v1 with
                        | U14.RegexStar f5 =>
                            v5 := f5
                            v6 := (← regex_equal_30 v4 v5)
                            if v6 then
                                return (U14.RegexStar v4)
                            else
                                return (U14.RegexCat v0 v1)
                        | _ =>
                            return (U14.RegexCat v0 v1)
                    | _ =>
                        return (U14.RegexCat v0 v1)
partial def make_star_31 (p0 : U14) : IO U14 := do
    let mut v0 : U14 := p0
    let mut v3 : U14 := default
    match v0 with
    | U14.RegexEmpty =>
        return U14.RegexEpsilon
    | U14.RegexEpsilon =>
        return U14.RegexEpsilon
    | U14.RegexStar f3 =>
        v3 := f3
        return (U14.RegexStar v3)
    | _ =>
        return (U14.RegexStar v0)
partial def normalize_25 (p0 : U14) : IO U14 := do
    let mut v0 : U14 := p0
    let mut v5 : U14 := default
    let mut v6 : U14 := default
    let mut v7 : U14 := default
    let mut v8 : U14 := default
    let mut v10 : U14 := default
    let mut v11 : U14 := default
    let mut v12 : U14 := default
    let mut v13 : U14 := default
    let mut v3 : U4 := default
    let mut v15 : U14 := default
    let mut v16 : U14 := default
    match v0 with
    | U14.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← normalize_25 v5)
        v8 := (← normalize_25 v6)
        return (← make_alt_26 v7 v8)
    | U14.RegexCat f10 f11 =>
        v10 := f10
        v11 := f11
        v12 := (← normalize_25 v10)
        v13 := (← normalize_25 v11)
        return (← make_cat_29 v12 v13)
    | U14.RegexChar f3 =>
        v3 := f3
        return (U14.RegexChar v3)
    | U14.RegexEmpty =>
        return U14.RegexEmpty
    | U14.RegexEpsilon =>
        return U14.RegexEpsilon
    | U14.RegexStar f15 =>
        v15 := f15
        v16 := (← normalize_25 v15)
        return (← make_star_31 v16)
partial def nullable_33 (p0 : U14) : IO U13 := do
    let mut v0 : U14 := p0
    let mut v5 : U14 := default
    let mut v6 : U14 := default
    let mut v7 : U13 := default
    let mut v8 : U13 := default
    let mut v16 : U14 := default
    let mut v17 : U14 := default
    let mut v18 : U13 := default
    let mut v19 : U13 := default
    let mut v3 : U4 := default
    let mut v25 : U14 := default
    match v0 with
    | U14.RegexAlt f5 f6 =>
        v5 := f5
        v6 := f6
        v7 := (← nullable_33 v5)
        v8 := (← nullable_33 v6)
        match v7 with
        | U13.Nullable =>
            return U13.Nullable
        | _ =>
            match v8 with
            | U13.Nullable =>
                return U13.Nullable
            | _ =>
                match v7 with
                | U13.NonNullable =>
                    match v8 with
                    | U13.NonNullable =>
                        return U13.NonNullable
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | _ =>
                    spiralFail "union unbox: unreachable case"
    | U14.RegexCat f16 f17 =>
        v16 := f16
        v17 := f17
        v18 := (← nullable_33 v16)
        v19 := (← nullable_33 v17)
        match v18 with
        | U13.Nullable =>
            match v19 with
            | U13.Nullable =>
                return U13.Nullable
            | _ =>
                return U13.NonNullable
        | _ =>
            return U13.NonNullable
    | U14.RegexChar f3 =>
        v3 := f3
        return U13.NonNullable
    | U14.RegexEmpty =>
        return U13.NonNullable
    | U14.RegexEpsilon =>
        return U13.Nullable
    | U14.RegexStar f25 =>
        v25 := f25
        return U13.Nullable
partial def derivative_32 (p0 : U14) (p1 : U4) : IO U14 := do
    let mut v0 : U14 := p0
    let mut v1 : U4 := p1
    let mut v25 : U14 := default
    let mut v26 : U14 := default
    let mut v27 : U14 := default
    let mut v28 : U14 := default
    let mut v30 : U14 := default
    let mut v31 : U14 := default
    let mut v32 : U13 := default
    let mut v37 : U14 := default
    let mut v33 : U14 := default
    let mut v34 : U14 := default
    let mut v35 : U14 := default
    let mut v4 : U4 := default
    let mut v20 : U12 := default
    let mut v21 : Bool := default
    let mut v41 : U14 := default
    let mut v42 : U14 := default
    let mut v43 : U14 := default
    match v0 with
    | U14.RegexAlt f25 f26 =>
        v25 := f25
        v26 := f26
        v27 := (← derivative_32 v25 v1)
        v28 := (← derivative_32 v26 v1)
        return (← make_alt_26 v27 v28)
    | U14.RegexCat f30 f31 =>
        v30 := f30
        v31 := f31
        v32 := (← nullable_33 v30)
        match v32 with
        | U13.NonNullable =>
            v37 := (← derivative_32 v30 v1)
            return (← make_cat_29 v37 v31)
        | U13.Nullable =>
            v33 := (← derivative_32 v30 v1)
            v34 := (← make_cat_29 v33 v31)
            v35 := (← derivative_32 v31 v1)
            return (← make_alt_26 v34 v35)
    | U14.RegexChar f4 =>
        v4 := f4
        match v4 with
        | U4.TriA =>
            match v1 with
            | U4.TriA =>
                v20 := U12.SymbolSame
            | _ =>
                v20 := U12.SymbolLess
        | _ =>
            match v1 with
            | U4.TriA =>
                v20 := U12.SymbolGreater
            | _ =>
                match v4 with
                | U4.TriB =>
                    match v1 with
                    | U4.TriB =>
                        v20 := U12.SymbolSame
                    | U4.TriC =>
                        v20 := U12.SymbolLess
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | U4.TriC =>
                    match v1 with
                    | U4.TriB =>
                        v20 := U12.SymbolGreater
                    | U4.TriC =>
                        v20 := U12.SymbolSame
                    | _ =>
                        spiralFail "union unbox: unreachable case"
                | _ =>
                    spiralFail "union unbox: unreachable case"
        match v20 with
        | U12.SymbolSame =>
            v21 := true
        | _ =>
            v21 := false
        if v21 then
            return U14.RegexEpsilon
        else
            return U14.RegexEmpty
    | U14.RegexEmpty =>
        return U14.RegexEmpty
    | U14.RegexEpsilon =>
        return U14.RegexEmpty
    | U14.RegexStar f41 =>
        v41 := f41
        v42 := (← derivative_32 v41 v1)
        v43 := (← make_star_31 v41)
        return (← make_cat_29 v42 v43)
partial def canonical_derivative_24 (p0 : U14) (p1 : U4) : IO U14 := do
    let mut v0 : U14 := p0
    let mut v1 : U4 := p1
    let v2 : U14 := (← normalize_25 v0)
    let v3 : U14 := (← derivative_32 v2 v1)
    return (← normalize_25 v3)
partial def accepts_23 (p0 : U14) (p1 : U7) : IO Bool := do
    let mut v0 : U14 := p0
    let mut v1 : U7 := p1
    let mut v6 : U4 := default
    let mut v7 : U7 := default
    let mut v8 : U14 := default
    let mut v2 : U14 := default
    let mut v3 : U13 := default
    match v1 with
    | U7.InputCons f6 f7 =>
        v6 := f6
        v7 := f7
        v8 := (← canonical_derivative_24 v0 v6)
        return (← accepts_23 v8 v7)
    | U7.InputEmpty =>
        v2 := (← normalize_25 v0)
        v3 := (← nullable_33 v2)
        match v3 with
        | U13.NonNullable =>
            return false
        | U13.Nullable =>
            return true
partial def loop_21 (p0 : U14) (p1 : U6) : IO Bool := do
    let mut v0 : U14 := p0
    let mut v1 : U6 := p1
    let mut v2 : U7 := default
    let mut v3 : U6 := default
    let mut v4 : Int32 := default
    let mut v5 : U11 := default
    let mut v11 : Bool := default
    let mut v7 : Bool := default
    let mut v8 : Bool := default
    match v1 with
    | U6.InputListCons f2 f3 =>
        v2 := f2
        v3 := f3
        v4 := (2 : Int32)
        v5 := (← loop_22 v4 v2)
        match v5 with
        | U11.InventoryDfaAccepted =>
            v11 := (← accepts_23 v0 v2)
        | U11.InventoryDfaInputOutsideInventory =>
            v11 := false
        | U11.InventoryDfaRejected =>
            v7 := (← accepts_23 v0 v2)
            v8 := (v7 == false)
            v11 := v8
        if v11 then
            return (← loop_21 v0 v3)
        else
            return false
    | U6.InputListNil =>
        return true
partial def loop_34 (p0 : Int32) (p1 : U9) : IO U11 := do
    let mut v0 : Int32 := p0
    let mut v1 : U9 := p1
    let mut v7 : U8 := default
    let mut v8 : U9 := default
    let mut v11 : U12 := default
    let mut v12 : Bool := default
    let mut v21 : Int32 := default
    let mut v18 : U12 := default
    let mut v19 : Bool := default
    let mut v22 : Bool := default
    let mut v24 : Bool := default
    let mut v28 : Int32 := default
    let mut v26 : Bool := default
    let mut v2 : Bool := default
    let mut v3 : Bool := default
    match v1 with
    | U9.InputCons f7 f8 =>
        v7 := f7
        v8 := f8
        match v7 with
        | U8.ModelA =>
            v11 := U12.SymbolSame
        | _ =>
            v11 := U12.SymbolGreater
        match v11 with
        | U12.SymbolSame =>
            v12 := true
        | _ =>
            v12 := false
        if v12 then
            v21 := (0 : Int32)
        else
            match v7 with
            | U8.ModelA =>
                v18 := U12.SymbolLess
            | U8.ModelB =>
                v18 := U12.SymbolSame
            | U8.ModelC =>
                v18 := U12.SymbolGreater
            match v18 with
            | U12.SymbolSame =>
                v19 := true
            | _ =>
                v19 := false
            if v19 then
                v21 := (1 : Int32)
            else
                v21 := (-1 : Int32)
        v22 := (decide (v21 < (0 : Int32)))
        if v22 then
            return U11.InventoryDfaInputOutsideInventory
        else
            v24 := (v0 == (0 : Int32))
            if v24 then
                v28 := (0 : Int32)
            else
                v26 := (v21 == (0 : Int32))
                if v26 then
                    v28 := (1 : Int32)
                else
                    v28 := (0 : Int32)
            return (← loop_34 v28 v8)
    | U9.InputEmpty =>
        v2 := (v0 == (0 : Int32))
        v3 := (v2 == false)
        if v3 then
            return U11.InventoryDfaAccepted
        else
            return U11.InventoryDfaRejected
partial def spiralMain : IO Int32 := do
    let mut v75 : Bool := default
    let mut v61 : U4 := default
    let mut v62 : U14 := default
    let mut v63 : U4 := default
    let mut v64 : U14 := default
    let mut v65 : U14 := default
    let mut v66 : U14 := default
    let mut v67 : U4 := default
    let mut v68 : U14 := default
    let mut v69 : U14 := default
    let mut v70 : Bool := default
    let mut v71 : Int32 := default
    let mut v72 : U11 := default
    let v0 : U0 := U0.BitZero
    let v1 : U0 := U0.BitOne
    let v2 : U1 := U1.SymbolListNil
    let v3 : U1 := (U1.SymbolListCons v1 v2)
    let v4 : U1 := (U1.SymbolListCons v0 v3)
    let v5 : U2 := (← input_singletons_from_symbols_0 v4)
    let v6 : U3 := U3.InputEmpty
    let v7 : U2 := (U2.InputListCons v6 v5)
    let v8 : U0 := U0.BitZero
    let v9 : U0 := U0.BitOne
    let v10 : U1 := U1.SymbolListNil
    let v11 : U1 := (U1.SymbolListCons v9 v10)
    let v12 : U1 := (U1.SymbolListCons v8 v11)
    let v13 : U0 := U0.BitZero
    let v14 : U0 := U0.BitOne
    let v15 : U1 := U1.SymbolListNil
    let v16 : U1 := (U1.SymbolListCons v14 v15)
    let v17 : U1 := (U1.SymbolListCons v13 v16)
    let v18 : U2 := (← input_singletons_from_symbols_0 v17)
    let v19 : U2 := (← input_prepend_symbols_to_corpus_1 v12 v18)
    let v20 : U2 := (← input_list_append_3 v7 v19)
    let v21 : U4 := U4.TriA
    let v22 : U4 := U4.TriB
    let v23 : U4 := U4.TriC
    let v24 : U5 := U5.SymbolListNil
    let v25 : U5 := (U5.SymbolListCons v23 v24)
    let v26 : U5 := (U5.SymbolListCons v22 v25)
    let v27 : U5 := (U5.SymbolListCons v21 v26)
    let v28 : U6 := (← input_singletons_from_symbols_4 v27)
    let v29 : U7 := U7.InputEmpty
    let v30 : U6 := (U6.InputListCons v29 v28)
    let v31 : U4 := U4.TriA
    let v32 : U4 := U4.TriB
    let v33 : U4 := U4.TriC
    let v34 : U5 := U5.SymbolListNil
    let v35 : U5 := (U5.SymbolListCons v33 v34)
    let v36 : U5 := (U5.SymbolListCons v32 v35)
    let v37 : U5 := (U5.SymbolListCons v31 v36)
    let v38 : U4 := U4.TriA
    let v39 : U4 := U4.TriB
    let v40 : U4 := U4.TriC
    let v41 : U5 := U5.SymbolListNil
    let v42 : U5 := (U5.SymbolListCons v40 v41)
    let v43 : U5 := (U5.SymbolListCons v39 v42)
    let v44 : U5 := (U5.SymbolListCons v38 v43)
    let v45 : U6 := (← input_singletons_from_symbols_4 v44)
    let v46 : U6 := (← input_prepend_symbols_to_corpus_5 v37 v45)
    let v47 : U6 := (← input_list_append_7 v30 v46)
    let v48 : U8 := U8.ModelC
    let v49 : U9 := U9.InputEmpty
    let v50 : U9 := (U9.InputCons v48 v49)
    let v51 : U0 := U0.BitZero
    let v52 : U10 := (U10.RegexChar v51)
    let v53 : U0 := U0.BitOne
    let v54 : U10 := (U10.RegexChar v53)
    let v55 : U10 := (U10.RegexAlt v52 v54)
    let v56 : U10 := (U10.RegexStar v55)
    let v57 : U0 := U0.BitZero
    let v58 : U10 := (U10.RegexChar v57)
    let v59 : U10 := (U10.RegexCat v56 v58)
    let v60 : Bool := (← loop_8 v59 v20)
    if v60 then
        v61 := U4.TriA
        v62 := (U14.RegexChar v61)
        v63 := U4.TriB
        v64 := (U14.RegexChar v63)
        v65 := (U14.RegexAlt v62 v64)
        v66 := (U14.RegexStar v65)
        v67 := U4.TriC
        v68 := (U14.RegexChar v67)
        v69 := (U14.RegexCat v66 v68)
        v70 := (← loop_21 v69 v47)
        if v70 then
            v71 := (1 : Int32)
            v72 := (← loop_34 v71 v50)
            match v72 with
            | U11.InventoryDfaInputOutsideInventory =>
                v75 := true
            | _ =>
                v75 := false
        else
            v75 := false
    else
        v75 := false
    if v75 then
        return (0 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
