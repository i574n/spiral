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
partial def spiralMain : IO Int32 := do
    let mut v0 : Float := default
    let mut v1 : Float := default
    let mut v2 : Float := default
    let mut v3 : Float := default
    let mut v4 : Float := default
    let mut v5 : Float := default
    let mut v6 : Float32 := default
    let mut v7 : Float := default
    let mut v8 : Bool := default
    let mut v9 : Bool := default
    let mut v10 : Float := default
    let mut v11 : Bool := default
    let mut v12 : Bool := default
    let mut v13 : Float := default
    let mut v14 : Float := default
    let mut v15 : Bool := default
    let mut v25 : Float := default
    let mut v16 : Float := default
    let mut v17 : Bool := default
    let mut v18 : Float := default
    let mut v19 : Float := default
    let mut v20 : Float := default
    let mut v21 : Bool := default
    let mut v22 : Float := default
    let mut v26 : Bool := default
    let mut v27 : Bool := default
    let mut v28 : Float := default
    let mut v29 : Float := default
    let mut v30 : Bool := default
    let mut v40 : Float := default
    let mut v31 : Float := default
    let mut v32 : Bool := default
    let mut v33 : Float := default
    let mut v34 : Float := default
    let mut v35 : Float := default
    let mut v36 : Bool := default
    let mut v37 : Float := default
    let mut v41 : Bool := default
    let mut v42 : Bool := default
    let mut v43 : Float := default
    let mut v44 : Float := default
    let mut v45 : Bool := default
    let mut v55 : Float := default
    let mut v46 : Float := default
    let mut v47 : Bool := default
    let mut v48 : Float := default
    let mut v49 : Float := default
    let mut v50 : Float := default
    let mut v51 : Bool := default
    let mut v52 : Float := default
    let mut v56 : Bool := default
    let mut v57 : Bool := default
    let mut v58 : Float := default
    let mut v59 : Float := default
    let mut v60 : Bool := default
    let mut v70 : Float := default
    let mut v61 : Float := default
    let mut v62 : Bool := default
    let mut v63 : Float := default
    let mut v64 : Float := default
    let mut v65 : Float := default
    let mut v66 : Bool := default
    let mut v67 : Float := default
    let mut v71 : Bool := default
    let mut v72 : Bool := default
    let mut v73 : Float := default
    let mut v74 : Float := default
    let mut v75 : Bool := default
    let mut v85 : Float := default
    let mut v76 : Float := default
    let mut v77 : Bool := default
    let mut v78 : Float := default
    let mut v79 : Float := default
    let mut v80 : Float := default
    let mut v81 : Bool := default
    let mut v82 : Float := default
    let mut v86 : Bool := default
    let mut v87 : Bool := default
    let mut v88 : Float := default
    let mut v89 : Float := default
    let mut v90 : Float := default
    let mut v91 : Bool := default
    let mut v92 : Bool := default
    let mut v93 : Float32 := default
    let mut v94 : Bool := default
    let mut v95 : Bool := default
    v0 := (2.7 : Float)
    v1 := (3.2 : Float)
    v2 := (-2.5 : Float)
    v3 := (3.5 : Float)
    v4 := (0.5 : Float)
    v5 := (1.0 : Float)
    v6 := (2.7 : Float32)
    v7 := (v0).floor
    v8 := (v7 == (2.0 : Float))
    v9 := (v8 != true)
    if v9 then
        return (1 : Int32)
    else
        v10 := (v0).ceil
        v11 := (v10 == (3.0 : Float))
        v12 := (v11 != true)
        if v12 then
            return (2 : Int32)
        else
            v13 := (v0).floor
            v14 := (v0 - v13)
            v15 := (decide (v14 > (0.5 : Float)))
            if v15 then
                v16 := (v13 + (1.0 : Float))
                v25 := v16
            else
                v17 := (decide (v14 < (0.5 : Float)))
                if v17 then
                    v25 := v13
                else
                    v18 := (v13 / (2.0 : Float))
                    v19 := (v18).floor
                    v20 := (v19 * (2.0 : Float))
                    v21 := (v20 == v13)
                    if v21 then
                        v25 := v13
                    else
                        v22 := (v13 + (1.0 : Float))
                        v25 := v22
            v26 := (v25 == (3.0 : Float))
            v27 := (v26 != true)
            if v27 then
                return (3 : Int32)
            else
                v28 := (v1).floor
                v29 := (v1 - v28)
                v30 := (decide (v29 > (0.5 : Float)))
                if v30 then
                    v31 := (v28 + (1.0 : Float))
                    v40 := v31
                else
                    v32 := (decide (v29 < (0.5 : Float)))
                    if v32 then
                        v40 := v28
                    else
                        v33 := (v28 / (2.0 : Float))
                        v34 := (v33).floor
                        v35 := (v34 * (2.0 : Float))
                        v36 := (v35 == v28)
                        if v36 then
                            v40 := v28
                        else
                            v37 := (v28 + (1.0 : Float))
                            v40 := v37
                v41 := (v40 == (3.0 : Float))
                v42 := (v41 != true)
                if v42 then
                    return (4 : Int32)
                else
                    v43 := (v2).floor
                    v44 := (v2 - v43)
                    v45 := (decide (v44 > (0.5 : Float)))
                    if v45 then
                        v46 := (v43 + (1.0 : Float))
                        v55 := v46
                    else
                        v47 := (decide (v44 < (0.5 : Float)))
                        if v47 then
                            v55 := v43
                        else
                            v48 := (v43 / (2.0 : Float))
                            v49 := (v48).floor
                            v50 := (v49 * (2.0 : Float))
                            v51 := (v50 == v43)
                            if v51 then
                                v55 := v43
                            else
                                v52 := (v43 + (1.0 : Float))
                                v55 := v52
                    v56 := (v55 == (-2.0 : Float))
                    v57 := (v56 != true)
                    if v57 then
                        return (5 : Int32)
                    else
                        v58 := (v3).floor
                        v59 := (v3 - v58)
                        v60 := (decide (v59 > (0.5 : Float)))
                        if v60 then
                            v61 := (v58 + (1.0 : Float))
                            v70 := v61
                        else
                            v62 := (decide (v59 < (0.5 : Float)))
                            if v62 then
                                v70 := v58
                            else
                                v63 := (v58 / (2.0 : Float))
                                v64 := (v63).floor
                                v65 := (v64 * (2.0 : Float))
                                v66 := (v65 == v58)
                                if v66 then
                                    v70 := v58
                                else
                                    v67 := (v58 + (1.0 : Float))
                                    v70 := v67
                        v71 := (v70 == (4.0 : Float))
                        v72 := (v71 != true)
                        if v72 then
                            return (6 : Int32)
                        else
                            v73 := (v4).floor
                            v74 := (v4 - v73)
                            v75 := (decide (v74 > (0.5 : Float)))
                            if v75 then
                                v76 := (v73 + (1.0 : Float))
                                v85 := v76
                            else
                                v77 := (decide (v74 < (0.5 : Float)))
                                if v77 then
                                    v85 := v73
                                else
                                    v78 := (v73 / (2.0 : Float))
                                    v79 := (v78).floor
                                    v80 := (v79 * (2.0 : Float))
                                    v81 := (v80 == v73)
                                    if v81 then
                                        v85 := v73
                                    else
                                        v82 := (v73 + (1.0 : Float))
                                        v85 := v82
                            v86 := (v85 == (0.0 : Float))
                            v87 := (v86 != true)
                            if v87 then
                                return (7 : Int32)
                            else
                                v88 := Float.atan2 v5 v5 
                                v89 := (v88 * (1000.0 : Float))
                                v90 := (v89).floor
                                v91 := (v90 == (785.0 : Float))
                                v92 := (v91 != true)
                                if v92 then
                                    return (8 : Int32)
                                else
                                    v93 := (v6).floor
                                    v94 := (v93 == (2.0 : Float32))
                                    v95 := (v94 != true)
                                    if v95 then
                                        return (9 : Int32)
                                    else
                                        return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
