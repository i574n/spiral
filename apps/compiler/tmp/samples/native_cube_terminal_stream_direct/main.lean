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
  | Hidden : U0
  | Visible : Float → Float → Float → U0
end
deriving instance Inhabited for U0
def U0.spiralTag : U0 → Int32
  | .Hidden .. => 0
  | .Visible .. => 1
mutual
partial def method0 (p0 : Int32) : IO Bool := do
    let mut v0 : Int32 := p0
    let v1 : Bool := (decide (v0 < (3 : Int32)))
    return v1
partial def method1 (p0 : Int32) : IO Bool := do
    let mut v0 : Int32 := p0
    let v1 : Bool := (decide (v0 < (7040 : Int32)))
    return v1
partial def method2 (p0 : (IO.Ref (Array Int32))) (p1 : Float) (p2 : Float) (p3 : Float) : IO Int32 := do
    let mut v0 : (IO.Ref (Array Int32)) := p0
    let mut v1 : Float := p1
    let mut v2 : Float := p2
    let mut v3 : Float := p3
    let mut v50 : Bool := default
    let mut v49 : Bool := default
    let mut v52 : Bool := default
    let mut v51 : Bool := default
    let mut v54 : Bool := default
    let mut v53 : Bool := default
    let mut v57 : U0 := default
    let mut v58 : Float := default
    let mut v59 : Float := default
    let mut v60 : Float := default
    let mut v61 : Bool := default
    let mut v63 : Bool := default
    let mut v62 : Bool := default
    let mut v65 : Bool := default
    let mut v64 : Bool := default
    let mut v66 : Int32 := default
    let mut v67 : Int32 := default
    let mut v68 : Int32 := default
    let mut v69 : Int32 := default
    let v4 : Float := (Float.sin v1)
    let v5 : Float := ((20.0 : Float) * v4)
    let v6 : Float := (Float.sin v2)
    let v7 : Float := (v5 * v6)
    let v8 : Float := (Float.cos v3)
    let v9 : Float := (v7 * v8)
    let v10 : Float := (Float.cos v1)
    let v11 : Float := ((-20.0 : Float) * v10)
    let v12 : Float := (v11 * v6)
    let v13 : Float := (v12 * v8)
    let v14 : Float := (v9 - v13)
    let v15 : Float := ((20.0 : Float) * v10)
    let v16 : Float := (Float.sin v3)
    let v17 : Float := (v15 * v16)
    let v18 : Float := (v14 + v17)
    let v19 : Float := ((-20.0 : Float) * v4)
    let v20 : Float := (v19 * v16)
    let v21 : Float := (v18 + v20)
    let v22 : Float := (Float.cos v2)
    let v23 : Float := ((20.0 : Float) * v22)
    let v24 : Float := (v23 * v8)
    let v25 : Float := (v21 + v24)
    let v26 : Float := (v15 * v8)
    let v27 : Float := (v19 * v8)
    let v28 : Float := (v26 + v27)
    let v29 : Float := (v7 * v16)
    let v30 : Float := (v28 - v29)
    let v31 : Float := (v12 * v16)
    let v32 : Float := (v30 + v31)
    let v33 : Float := (v23 * v16)
    let v34 : Float := (v32 - v33)
    let v35 : Float := (v11 * v22)
    let v36 : Float := (v5 * v22)
    let v37 : Float := (v35 - v36)
    let v38 : Float := ((20.0 : Float) * v6)
    let v39 : Float := (v37 + v38)
    let v40 : Float := (v39 + (100.0 : Float))
    let v41 : Float := ((1.0 : Float) / v40)
    let v42 : Float := ((40.0 : Float) * v41)
    let v43 : Float := (v42 * v25)
    let v44 : Float := (v43 * (2.0 : Float))
    let v45 : Float := ((40.0 : Float) + v44)
    let v46 : Float := (v42 * v34)
    let v47 : Float := ((22.0 : Float) + v46)
    let v48 : Bool := (decide (v45 >= (0.0 : Float)))
    if v48 then
        v49 := (decide (v45 < (160.0 : Float)))
        v50 := v49
    else
        v50 := false
    if v50 then
        v51 := (decide (v47 >= (0.0 : Float)))
        v52 := v51
    else
        v52 := false
    if v52 then
        v53 := (decide (v47 < (44.0 : Float)))
        v54 := v53
    else
        v54 := false
    if v54 then
        v57 := (U0.Visible v45 v47 v41)
    else
        v57 := U0.Hidden
    match v57 with
    | U0.Visible f58 f59 f60 =>
        v58 := f58
        v59 := f59
        v60 := f60
        v61 := (decide (v58 >= (0.0 : Float)))
        if v61 then
            v62 := (decide (v59 >= (0.0 : Float)))
            v63 := v62
        else
            v63 := false
        if v63 then
            v64 := (decide (v60 > (0.0 : Float)))
            v65 := v64
        else
            v65 := false
        if v65 then
            v66 := (Int32.ofInt (SpiralToInt.toI v58))
            v67 := (Int32.ofInt (SpiralToInt.toI v59))
            v68 := (v67 * (160 : Int32))
            v69 := (v66 + v68)
            v0.modify (fun xs => xs.set! (spiralIdx v69) (35 : Int32))
            return v69
        else
            return (0 : Int32)
    | _ =>
        return (0 : Int32)
partial def method3 (p0 : (IO.Ref (Array Int32))) (p1 : Float) (p2 : Float) (p3 : Float) : IO Int32 := do
    let mut v0 : (IO.Ref (Array Int32)) := p0
    let mut v1 : Float := p1
    let mut v2 : Float := p2
    let mut v3 : Float := p3
    let mut v50 : Bool := default
    let mut v49 : Bool := default
    let mut v52 : Bool := default
    let mut v51 : Bool := default
    let mut v54 : Bool := default
    let mut v53 : Bool := default
    let mut v57 : U0 := default
    let mut v58 : Float := default
    let mut v59 : Float := default
    let mut v60 : Float := default
    let mut v61 : Bool := default
    let mut v63 : Bool := default
    let mut v62 : Bool := default
    let mut v65 : Bool := default
    let mut v64 : Bool := default
    let mut v66 : Int32 := default
    let mut v67 : Int32 := default
    let mut v68 : Int32 := default
    let mut v69 : Int32 := default
    let v4 : Float := (Float.sin v1)
    let v5 : Float := ((10.0 : Float) * v4)
    let v6 : Float := (Float.sin v2)
    let v7 : Float := (v5 * v6)
    let v8 : Float := (Float.cos v3)
    let v9 : Float := (v7 * v8)
    let v10 : Float := (Float.cos v1)
    let v11 : Float := ((-10.0 : Float) * v10)
    let v12 : Float := (v11 * v6)
    let v13 : Float := (v12 * v8)
    let v14 : Float := (v9 - v13)
    let v15 : Float := ((10.0 : Float) * v10)
    let v16 : Float := (Float.sin v3)
    let v17 : Float := (v15 * v16)
    let v18 : Float := (v14 + v17)
    let v19 : Float := ((-10.0 : Float) * v4)
    let v20 : Float := (v19 * v16)
    let v21 : Float := (v18 + v20)
    let v22 : Float := (Float.cos v2)
    let v23 : Float := ((10.0 : Float) * v22)
    let v24 : Float := (v23 * v8)
    let v25 : Float := (v21 + v24)
    let v26 : Float := (v15 * v8)
    let v27 : Float := (v19 * v8)
    let v28 : Float := (v26 + v27)
    let v29 : Float := (v7 * v16)
    let v30 : Float := (v28 - v29)
    let v31 : Float := (v12 * v16)
    let v32 : Float := (v30 + v31)
    let v33 : Float := (v23 * v16)
    let v34 : Float := (v32 - v33)
    let v35 : Float := (v11 * v22)
    let v36 : Float := (v5 * v22)
    let v37 : Float := (v35 - v36)
    let v38 : Float := ((10.0 : Float) * v6)
    let v39 : Float := (v37 + v38)
    let v40 : Float := (v39 + (100.0 : Float))
    let v41 : Float := ((1.0 : Float) / v40)
    let v42 : Float := ((40.0 : Float) * v41)
    let v43 : Float := (v42 * v25)
    let v44 : Float := (v43 * (2.0 : Float))
    let v45 : Float := ((90.0 : Float) + v44)
    let v46 : Float := (v42 * v34)
    let v47 : Float := ((22.0 : Float) + v46)
    let v48 : Bool := (decide (v45 >= (0.0 : Float)))
    if v48 then
        v49 := (decide (v45 < (160.0 : Float)))
        v50 := v49
    else
        v50 := false
    if v50 then
        v51 := (decide (v47 >= (0.0 : Float)))
        v52 := v51
    else
        v52 := false
    if v52 then
        v53 := (decide (v47 < (44.0 : Float)))
        v54 := v53
    else
        v54 := false
    if v54 then
        v57 := (U0.Visible v45 v47 v41)
    else
        v57 := U0.Hidden
    match v57 with
    | U0.Visible f58 f59 f60 =>
        v58 := f58
        v59 := f59
        v60 := f60
        v61 := (decide (v58 >= (0.0 : Float)))
        if v61 then
            v62 := (decide (v59 >= (0.0 : Float)))
            v63 := v62
        else
            v63 := false
        if v63 then
            v64 := (decide (v60 > (0.0 : Float)))
            v65 := v64
        else
            v65 := false
        if v65 then
            v66 := (Int32.ofInt (SpiralToInt.toI v58))
            v67 := (Int32.ofInt (SpiralToInt.toI v59))
            v68 := (v67 * (160 : Int32))
            v69 := (v66 + v68)
            v0.modify (fun xs => xs.set! (spiralIdx v69) (64 : Int32))
            return v69
        else
            return (0 : Int32)
    | _ =>
        return (0 : Int32)
partial def method4 (p0 : (IO.Ref (Array Int32))) (p1 : Float) (p2 : Float) (p3 : Float) : IO Int32 := do
    let mut v0 : (IO.Ref (Array Int32)) := p0
    let mut v1 : Float := p1
    let mut v2 : Float := p2
    let mut v3 : Float := p3
    let mut v50 : Bool := default
    let mut v49 : Bool := default
    let mut v52 : Bool := default
    let mut v51 : Bool := default
    let mut v54 : Bool := default
    let mut v53 : Bool := default
    let mut v57 : U0 := default
    let mut v58 : Float := default
    let mut v59 : Float := default
    let mut v60 : Float := default
    let mut v61 : Bool := default
    let mut v63 : Bool := default
    let mut v62 : Bool := default
    let mut v65 : Bool := default
    let mut v64 : Bool := default
    let mut v66 : Int32 := default
    let mut v67 : Int32 := default
    let mut v68 : Int32 := default
    let mut v69 : Int32 := default
    let v4 : Float := (Float.sin v1)
    let v5 : Float := ((5.0 : Float) * v4)
    let v6 : Float := (Float.sin v2)
    let v7 : Float := (v5 * v6)
    let v8 : Float := (Float.cos v3)
    let v9 : Float := (v7 * v8)
    let v10 : Float := (Float.cos v1)
    let v11 : Float := ((-5.0 : Float) * v10)
    let v12 : Float := (v11 * v6)
    let v13 : Float := (v12 * v8)
    let v14 : Float := (v9 - v13)
    let v15 : Float := ((5.0 : Float) * v10)
    let v16 : Float := (Float.sin v3)
    let v17 : Float := (v15 * v16)
    let v18 : Float := (v14 + v17)
    let v19 : Float := ((-5.0 : Float) * v4)
    let v20 : Float := (v19 * v16)
    let v21 : Float := (v18 + v20)
    let v22 : Float := (Float.cos v2)
    let v23 : Float := ((5.0 : Float) * v22)
    let v24 : Float := (v23 * v8)
    let v25 : Float := (v21 + v24)
    let v26 : Float := (v15 * v8)
    let v27 : Float := (v19 * v8)
    let v28 : Float := (v26 + v27)
    let v29 : Float := (v7 * v16)
    let v30 : Float := (v28 - v29)
    let v31 : Float := (v12 * v16)
    let v32 : Float := (v30 + v31)
    let v33 : Float := (v23 * v16)
    let v34 : Float := (v32 - v33)
    let v35 : Float := (v11 * v22)
    let v36 : Float := (v5 * v22)
    let v37 : Float := (v35 - v36)
    let v38 : Float := ((5.0 : Float) * v6)
    let v39 : Float := (v37 + v38)
    let v40 : Float := (v39 + (100.0 : Float))
    let v41 : Float := ((1.0 : Float) / v40)
    let v42 : Float := ((40.0 : Float) * v41)
    let v43 : Float := (v42 * v25)
    let v44 : Float := (v43 * (2.0 : Float))
    let v45 : Float := ((120.0 : Float) + v44)
    let v46 : Float := (v42 * v34)
    let v47 : Float := ((22.0 : Float) + v46)
    let v48 : Bool := (decide (v45 >= (0.0 : Float)))
    if v48 then
        v49 := (decide (v45 < (160.0 : Float)))
        v50 := v49
    else
        v50 := false
    if v50 then
        v51 := (decide (v47 >= (0.0 : Float)))
        v52 := v51
    else
        v52 := false
    if v52 then
        v53 := (decide (v47 < (44.0 : Float)))
        v54 := v53
    else
        v54 := false
    if v54 then
        v57 := (U0.Visible v45 v47 v41)
    else
        v57 := U0.Hidden
    match v57 with
    | U0.Visible f58 f59 f60 =>
        v58 := f58
        v59 := f59
        v60 := f60
        v61 := (decide (v58 >= (0.0 : Float)))
        if v61 then
            v62 := (decide (v59 >= (0.0 : Float)))
            v63 := v62
        else
            v63 := false
        if v63 then
            v64 := (decide (v60 > (0.0 : Float)))
            v65 := v64
        else
            v65 := false
        if v65 then
            v66 := (Int32.ofInt (SpiralToInt.toI v58))
            v67 := (Int32.ofInt (SpiralToInt.toI v59))
            v68 := (v67 * (160 : Int32))
            v69 := (v66 + v68)
            v0.modify (fun xs => xs.set! (spiralIdx v69) (43 : Int32))
            return v69
        else
            return (0 : Int32)
    | _ =>
        return (0 : Int32)
partial def frame_text_loop_5 (p0 : (IO.Ref (Array Int32))) (p1 : Int32) (p2 : Int32) (p3 : Int32) (p4 : String) : IO String := do
    let mut v0 : (IO.Ref (Array Int32)) := p0
    let mut v1 : Int32 := p1
    let mut v2 : Int32 := p2
    let mut v3 : Int32 := p3
    let mut v4 : String := p4
    let mut v5 : Bool := default
    let mut v6 : Int32 := default
    let mut v7 : Bool := default
    let mut v16 : String := default
    let mut v8 : String := default
    let mut v9 : Bool := default
    let mut v10 : String := default
    let mut v11 : Bool := default
    let mut v12 : String := default
    let mut v13 : String := default
    let mut v17 : String := default
    let mut v18 : Int32 := default
    let mut v19 : Int32 := default
    let mut v20 : Int32 := default
    let mut v21 : Bool := default
    let mut v23 : Bool := default
    let mut v22 : Bool := default
    let mut v24 : String := default
    repeat
        v5 := (v3 == v2)
        if v5 then
            return v4
        else
            v6 := (← spiralIndex (← v0.get) (spiralIdx v3))
            v7 := (v6 == (35 : Int32))
            if v7 then
                v8 := "#"
                v16 := v8
            else
                v9 := (v6 == (43 : Int32))
                if v9 then
                    v10 := "+"
                    v16 := v10
                else
                    v11 := (v6 == (64 : Int32))
                    if v11 then
                        v12 := "@"
                        v16 := v12
                    else
                        v13 := "."
                        v16 := v13
            v17 := (v4 ++ v16)
            v18 := (v3 + (1 : Int32))
            v19 := (v3 % v1)
            v20 := (v1 - (1 : Int32))
            v21 := (v19 == v20)
            if v21 then
                v22 := (decide (v18 < v2))
                v23 := v22
            else
                v23 := false
            if v23 then
                v24 := (v17 ++ "\n")
                v3 := v18
                v4 := v24
                continue
            else
                v3 := v18
                v4 := v17
                continue
partial def runtime_byte_8 (p0 : String) (p1 : Int32) : IO Char := do
    let mut v0 : String := p0
    let mut v1 : Int32 := p1
    let v2 : Char := (Char.ofNat (v0.toUTF8.get! (spiralIdx v1)).toNat)
    return v2
partial def utf8_scalar_at_byte_offset_7 (p0 : String) (p1 : Int32) : IO Int32 := do
    let mut v0 : String := p0
    let mut v1 : Int32 := p1
    let mut v5 : Bool := default
    let mut v7 : Char := default
    let mut v8 : Int32 := default
    let mut v9 : Bool := default
    let mut v10 : Bool := default
    let mut v12 : Bool := default
    let mut v13 : Int32 := default
    let mut v14 : Bool := default
    let mut v16 : Char := default
    let mut v17 : Int32 := default
    let mut v18 : Bool := default
    let mut v20 : Bool := default
    let mut v19 : Bool := default
    let mut v21 : Int32 := default
    let mut v22 : Int32 := default
    let mut v23 : Int32 := default
    let mut v24 : Int32 := default
    let mut v28 : Bool := default
    let mut v29 : Int32 := default
    let mut v30 : Bool := default
    let mut v32 : Int32 := default
    let mut v33 : Char := default
    let mut v34 : Int32 := default
    let mut v35 : Char := default
    let mut v36 : Int32 := default
    let mut v37 : Bool := default
    let mut v39 : Bool := default
    let mut v38 : Bool := default
    let mut v40 : Bool := default
    let mut v42 : Bool := default
    let mut v41 : Bool := default
    let mut v43 : Int32 := default
    let mut v44 : Int32 := default
    let mut v45 : Int32 := default
    let mut v46 : Int32 := default
    let mut v47 : Int32 := default
    let mut v48 : Int32 := default
    let mut v49 : Int32 := default
    let mut v50 : Bool := default
    let mut v52 : Bool := default
    let mut v53 : Bool := default
    let mut v63 : Bool := default
    let mut v64 : Int32 := default
    let mut v65 : Bool := default
    let mut v67 : Int32 := default
    let mut v68 : Char := default
    let mut v69 : Int32 := default
    let mut v70 : Int32 := default
    let mut v71 : Char := default
    let mut v72 : Int32 := default
    let mut v73 : Char := default
    let mut v74 : Int32 := default
    let mut v75 : Bool := default
    let mut v77 : Bool := default
    let mut v76 : Bool := default
    let mut v78 : Bool := default
    let mut v80 : Bool := default
    let mut v79 : Bool := default
    let mut v81 : Bool := default
    let mut v83 : Bool := default
    let mut v82 : Bool := default
    let mut v84 : Int32 := default
    let mut v85 : Int32 := default
    let mut v86 : Int32 := default
    let mut v87 : Int32 := default
    let mut v88 : Int32 := default
    let mut v89 : Int32 := default
    let mut v90 : Int32 := default
    let mut v91 : Int32 := default
    let mut v92 : Int32 := default
    let mut v93 : Int32 := default
    let mut v94 : Bool := default
    let mut v96 : Bool := default
    let v2 : Int32 := (Int32.ofNat v0.utf8ByteSize)
    let v3 : Bool := (decide (v1 < (0 : Int32)))
    if v3 then
        spiralFail "UTF-8 byte offset is negative."
    else
        v5 := (decide (v1 >= v2))
        if v5 then
            spiralFail "UTF-8 byte offset is outside the string."
        else
            v7 := (← runtime_byte_8 v0 v1)
            v8 := (Int32.ofNat (v7).toNat)
            v9 := (decide (v8 < (128 : Int32)))
            if v9 then
                return v8
            else
                v10 := (decide (v8 < (194 : Int32)))
                if v10 then
                    spiralFail "UTF-8 scalar starts with an invalid lead byte."
                else
                    v12 := (decide (v8 < (224 : Int32)))
                    if v12 then
                        v13 := (v1 + (1 : Int32))
                        v14 := (decide (v13 >= v2))
                        if v14 then
                            spiralFail "UTF-8 sequence is truncated."
                        else
                            v16 := (← runtime_byte_8 v0 v13)
                            v17 := (Int32.ofNat (v16).toNat)
                            v18 := (decide (v17 < (128 : Int32)))
                            if v18 then
                                v20 := false
                            else
                                v19 := (decide (v17 < (192 : Int32)))
                                v20 := v19
                            if v20 then
                                v21 := (v8 - (192 : Int32))
                                v22 := (v21 * (64 : Int32))
                                v23 := (v17 - (128 : Int32))
                                v24 := (v22 + v23)
                                return v24
                            else
                                spiralFail "UTF-8 sequence has an invalid continuation byte."
                    else
                        v28 := (decide (v8 < (240 : Int32)))
                        if v28 then
                            v29 := (v1 + (2 : Int32))
                            v30 := (decide (v29 >= v2))
                            if v30 then
                                spiralFail "UTF-8 sequence is truncated."
                            else
                                v32 := (v1 + (1 : Int32))
                                v33 := (← runtime_byte_8 v0 v32)
                                v34 := (Int32.ofNat (v33).toNat)
                                v35 := (← runtime_byte_8 v0 v29)
                                v36 := (Int32.ofNat (v35).toNat)
                                v37 := (decide (v34 < (128 : Int32)))
                                if v37 then
                                    v39 := false
                                else
                                    v38 := (decide (v34 < (192 : Int32)))
                                    v39 := v38
                                if v39 then
                                    v40 := (decide (v36 < (128 : Int32)))
                                    if v40 then
                                        v42 := false
                                    else
                                        v41 := (decide (v36 < (192 : Int32)))
                                        v42 := v41
                                    if v42 then
                                        v43 := (v8 - (224 : Int32))
                                        v44 := (v43 * (4096 : Int32))
                                        v45 := (v34 - (128 : Int32))
                                        v46 := (v45 * (64 : Int32))
                                        v47 := (v44 + v46)
                                        v48 := (v36 - (128 : Int32))
                                        v49 := (v47 + v48)
                                        v50 := (decide (v49 < (2048 : Int32)))
                                        if v50 then
                                            spiralFail "UTF-8 sequence is overlong."
                                        else
                                            v52 := (decide (v49 >= (55296 : Int32)))
                                            if v52 then
                                                v53 := (decide (v49 <= (57343 : Int32)))
                                                if v53 then
                                                    spiralFail "UTF-8 sequence encodes a surrogate."
                                                else
                                                    return v49
                                            else
                                                return v49
                                    else
                                        spiralFail "UTF-8 sequence has an invalid continuation byte."
                                else
                                    spiralFail "UTF-8 sequence has an invalid continuation byte."
                        else
                            v63 := (decide (v8 < (245 : Int32)))
                            if v63 then
                                v64 := (v1 + (3 : Int32))
                                v65 := (decide (v64 >= v2))
                                if v65 then
                                    spiralFail "UTF-8 sequence is truncated."
                                else
                                    v67 := (v1 + (1 : Int32))
                                    v68 := (← runtime_byte_8 v0 v67)
                                    v69 := (Int32.ofNat (v68).toNat)
                                    v70 := (v1 + (2 : Int32))
                                    v71 := (← runtime_byte_8 v0 v70)
                                    v72 := (Int32.ofNat (v71).toNat)
                                    v73 := (← runtime_byte_8 v0 v64)
                                    v74 := (Int32.ofNat (v73).toNat)
                                    v75 := (decide (v69 < (128 : Int32)))
                                    if v75 then
                                        v77 := false
                                    else
                                        v76 := (decide (v69 < (192 : Int32)))
                                        v77 := v76
                                    if v77 then
                                        v78 := (decide (v72 < (128 : Int32)))
                                        if v78 then
                                            v80 := false
                                        else
                                            v79 := (decide (v72 < (192 : Int32)))
                                            v80 := v79
                                        if v80 then
                                            v81 := (decide (v74 < (128 : Int32)))
                                            if v81 then
                                                v83 := false
                                            else
                                                v82 := (decide (v74 < (192 : Int32)))
                                                v83 := v82
                                            if v83 then
                                                v84 := (v8 - (240 : Int32))
                                                v85 := (v84 * (262144 : Int32))
                                                v86 := (v69 - (128 : Int32))
                                                v87 := (v86 * (4096 : Int32))
                                                v88 := (v85 + v87)
                                                v89 := (v72 - (128 : Int32))
                                                v90 := (v89 * (64 : Int32))
                                                v91 := (v88 + v90)
                                                v92 := (v74 - (128 : Int32))
                                                v93 := (v91 + v92)
                                                v94 := (decide (v93 < (65536 : Int32)))
                                                if v94 then
                                                    spiralFail "UTF-8 sequence is overlong."
                                                else
                                                    v96 := (decide (v93 > (1114111 : Int32)))
                                                    if v96 then
                                                        spiralFail "UTF-8 scalar is above U+10FFFF."
                                                    else
                                                        return v93
                                            else
                                                spiralFail "UTF-8 sequence has an invalid continuation byte."
                                        else
                                            spiralFail "UTF-8 sequence has an invalid continuation byte."
                                    else
                                        spiralFail "UTF-8 sequence has an invalid continuation byte."
                            else
                                spiralFail "UTF-8 scalar starts with an invalid lead byte."
partial def loop_6 (p0 : String) (p1 : Int32) (p2 : Int32) (p3 : Int32) : IO Int32 := do
    let mut v0 : String := p0
    let mut v1 : Int32 := p1
    let mut v2 : Int32 := p2
    let mut v3 : Int32 := p3
    let mut v4 : Bool := default
    let mut v5 : Bool := default
    let mut v7 : Int32 := default
    let mut v8 : Bool := default
    let mut v13 : Int32 := default
    let mut v9 : Bool := default
    let mut v10 : Bool := default
    let mut v14 : Int32 := default
    let mut v15 : Int32 := default
    repeat
        v4 := (v2 == v1)
        if v4 then
            return v3
        else
            v5 := (decide (v2 > v1))
            if v5 then
                spiralFail "UTF-8 scalar width exceeds the string."
            else
                v7 := (← utf8_scalar_at_byte_offset_7 v0 v2)
                v8 := (decide (v7 < (128 : Int32)))
                if v8 then
                    v13 := (1 : Int32)
                else
                    v9 := (decide (v7 < (2048 : Int32)))
                    if v9 then
                        v13 := (2 : Int32)
                    else
                        v10 := (decide (v7 < (65536 : Int32)))
                        if v10 then
                            v13 := (3 : Int32)
                        else
                            v13 := (4 : Int32)
                v14 := (v2 + v13)
                v15 := (v3 + v7)
                v2 := v14
                v3 := v15
                continue
partial def spiralMain : IO Int32 := do
    let mut v0 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v1 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v2 : Int32 := default
    let mut v4 : Bool := default
    let mut v9 : Float := default
    let mut v10 : Float := default
    let mut v11 : Float := default
    let mut v5 : Bool := default
    let mut v12 : Int32 := default
    let mut v14 : Int32 := default
    let mut v15 : Int32 := default
    let mut v16 : Int32 := default
    let mut v17 : Int32 := default
    let mut v18 : Int32 := default
    let mut v19 : Int32 := default
    let mut v20 : Int32 := default
    let mut v21 : String := default
    let mut v22 : String := default
    let mut v23 : Int32 := default
    let mut v24 : Int32 := default
    let mut v25 : Int32 := default
    let mut v26 : Int32 := default
    let mut v27 : String := default
    let mut v28 : Int32 := default
    let mut v29 : Int32 := default
    let mut v30 : Int32 := default
    let mut v31 : Int32 := default
    let mut v32 : Bool := default
    let mut v34 : Bool := default
    let mut v33 : Bool := default
    let mut v35 : Int32 := default
    let mut v36 : Int32 := default
    let mut v42 : Bool := default
    let mut v41 : Bool := default
    let mut v44 : Bool := default
    let mut v43 : Bool := default
    v0 := (← IO.mkRef (Array.replicate (spiralIdx (7040 : Int32)) (default : Int32)))
    v1 := (← IO.mkRef (Array.replicate (spiralIdx (3 : Int32)) (default : Int32)))
    v2 := (0 : Int32)
    repeat
        if !(← method0 v2) then break
        v4 := (v2 == (0 : Int32))
        if v4 then
            v9 := (0.0 : Float)
            v10 := (0.0 : Float)
            v11 := (0.0 : Float)
        else
            v5 := (v2 == (1 : Int32))
            if v5 then
                v9 := (0.1 : Float)
                v10 := (0.05 : Float)
                v11 := (0.02 : Float)
            else
                v9 := (0.2 : Float)
                v10 := (0.1 : Float)
                v11 := (0.04 : Float)
        v12 := (0 : Int32)
        repeat
            if !(← method1 v12) then break
            v0.modify (fun xs => xs.set! (spiralIdx v12) (46 : Int32))
            v14 := (v12 + (1 : Int32))
            v12 := v14
        v15 := (← method2 v0 v9 v10 v11)
        v16 := (← method3 v0 v9 v10 v11)
        v17 := (← method4 v0 v9 v10 v11)
        v18 := (160 : Int32)
        v19 := (7040 : Int32)
        v20 := (0 : Int32)
        v21 := ""
        v22 := (← frame_text_loop_5 v0 v18 v19 v20 v21)
        v23 := (Int32.ofNat v22.utf8ByteSize)
        v24 := (0 : Int32)
        v25 := (0 : Int32)
        v26 := (← loop_6 v22 v23 v24 v25)
        v27 := ("\x1b[H" ++ v22)
        IO.print (toString v27)
        v28 := (v16 * (3 : Int32))
        v29 := (v15 + v28)
        v30 := (v17 * (7 : Int32))
        v31 := (v29 + v30)
        v32 := (v23 == (7083 : Int32))
        if v32 then
            v33 := (v26 == (324274 : Int32))
            v34 := v33
        else
            v34 := false
        if v34 then
            v35 := v31
        else
            v35 := (0 : Int32)
        v1.modify (fun xs => xs.set! (spiralIdx v2) v35)
        v36 := (v2 + (1 : Int32))
        v2 := v36
    let v37 : Int32 := (← spiralIndex (← v1.get) (spiralIdx (0 : Int32)))
    let v38 : Int32 := (← spiralIndex (← v1.get) (spiralIdx (1 : Int32)))
    let v39 : Int32 := (← spiralIndex (← v1.get) (spiralIdx (2 : Int32)))
    let v40 : Bool := (v37 == (45702 : Int32))
    if v40 then
        v41 := (v38 == (43786 : Int32))
        v42 := v41
    else
        v42 := false
    if v42 then
        v43 := (v39 == (43631 : Int32))
        v44 := v43
    else
        v44 := false
    if v44 then
        return (42 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
