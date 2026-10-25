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
    let mut v9 : Float := default
    let mut v10 : Bool := default
    let mut v11 : Float := default
    let mut v12 : Float := default
    let mut v13 : Bool := default
    let mut v23 : Float := default
    let mut v14 : Float := default
    let mut v15 : Bool := default
    let mut v16 : Float := default
    let mut v17 : Float := default
    let mut v18 : Float := default
    let mut v19 : Bool := default
    let mut v20 : Float := default
    let mut v24 : Bool := default
    let mut v25 : Float := default
    let mut v26 : Float := default
    let mut v27 : Bool := default
    let mut v37 : Float := default
    let mut v28 : Float := default
    let mut v29 : Bool := default
    let mut v30 : Float := default
    let mut v31 : Float := default
    let mut v32 : Float := default
    let mut v33 : Bool := default
    let mut v34 : Float := default
    let mut v38 : Bool := default
    let mut v39 : Float := default
    let mut v40 : Float := default
    let mut v41 : Bool := default
    let mut v51 : Float := default
    let mut v42 : Float := default
    let mut v43 : Bool := default
    let mut v44 : Float := default
    let mut v45 : Float := default
    let mut v46 : Float := default
    let mut v47 : Bool := default
    let mut v48 : Float := default
    let mut v52 : Bool := default
    let mut v53 : Float := default
    let mut v54 : Float := default
    let mut v55 : Bool := default
    let mut v65 : Float := default
    let mut v56 : Float := default
    let mut v57 : Bool := default
    let mut v58 : Float := default
    let mut v59 : Float := default
    let mut v60 : Float := default
    let mut v61 : Bool := default
    let mut v62 : Float := default
    let mut v66 : Bool := default
    let mut v67 : Float := default
    let mut v68 : Float := default
    let mut v69 : Bool := default
    let mut v79 : Float := default
    let mut v70 : Float := default
    let mut v71 : Bool := default
    let mut v72 : Float := default
    let mut v73 : Float := default
    let mut v74 : Float := default
    let mut v75 : Bool := default
    let mut v76 : Float := default
    let mut v80 : Bool := default
    let mut v81 : Float := default
    let mut v82 : Float := default
    let mut v83 : Float := default
    let mut v84 : Bool := default
    let mut v85 : Float32 := default
    let mut v86 : Bool := default
    v0 := (2.7 : Float)
    v1 := (3.2 : Float)
    v2 := (-2.5 : Float)
    v3 := (3.5 : Float)
    v4 := (0.5 : Float)
    v5 := (1.0 : Float)
    v6 := (2.7 : Float32)
    v7 := (v0).floor
    v8 := (v7 != (2.0 : Float))
    if v8 then
        return (1 : Int32)
    else
        v9 := (v0).ceil
        v10 := (v9 != (3.0 : Float))
        if v10 then
            return (2 : Int32)
        else
            v11 := (v0).floor
            v12 := (v0 - v11)
            v13 := (decide (v12 > (0.5 : Float)))
            if v13 then
                v14 := (v11 + (1.0 : Float))
                v23 := v14
            else
                v15 := (decide (v12 < (0.5 : Float)))
                if v15 then
                    v23 := v11
                else
                    v16 := (v11 / (2.0 : Float))
                    v17 := (v16).floor
                    v18 := (v17 * (2.0 : Float))
                    v19 := (v18 == v11)
                    if v19 then
                        v23 := v11
                    else
                        v20 := (v11 + (1.0 : Float))
                        v23 := v20
            v24 := (v23 != (3.0 : Float))
            if v24 then
                return (3 : Int32)
            else
                v25 := (v1).floor
                v26 := (v1 - v25)
                v27 := (decide (v26 > (0.5 : Float)))
                if v27 then
                    v28 := (v25 + (1.0 : Float))
                    v37 := v28
                else
                    v29 := (decide (v26 < (0.5 : Float)))
                    if v29 then
                        v37 := v25
                    else
                        v30 := (v25 / (2.0 : Float))
                        v31 := (v30).floor
                        v32 := (v31 * (2.0 : Float))
                        v33 := (v32 == v25)
                        if v33 then
                            v37 := v25
                        else
                            v34 := (v25 + (1.0 : Float))
                            v37 := v34
                v38 := (v37 != (3.0 : Float))
                if v38 then
                    return (4 : Int32)
                else
                    v39 := (v2).floor
                    v40 := (v2 - v39)
                    v41 := (decide (v40 > (0.5 : Float)))
                    if v41 then
                        v42 := (v39 + (1.0 : Float))
                        v51 := v42
                    else
                        v43 := (decide (v40 < (0.5 : Float)))
                        if v43 then
                            v51 := v39
                        else
                            v44 := (v39 / (2.0 : Float))
                            v45 := (v44).floor
                            v46 := (v45 * (2.0 : Float))
                            v47 := (v46 == v39)
                            if v47 then
                                v51 := v39
                            else
                                v48 := (v39 + (1.0 : Float))
                                v51 := v48
                    v52 := (v51 != (-2.0 : Float))
                    if v52 then
                        return (5 : Int32)
                    else
                        v53 := (v3).floor
                        v54 := (v3 - v53)
                        v55 := (decide (v54 > (0.5 : Float)))
                        if v55 then
                            v56 := (v53 + (1.0 : Float))
                            v65 := v56
                        else
                            v57 := (decide (v54 < (0.5 : Float)))
                            if v57 then
                                v65 := v53
                            else
                                v58 := (v53 / (2.0 : Float))
                                v59 := (v58).floor
                                v60 := (v59 * (2.0 : Float))
                                v61 := (v60 == v53)
                                if v61 then
                                    v65 := v53
                                else
                                    v62 := (v53 + (1.0 : Float))
                                    v65 := v62
                        v66 := (v65 != (4.0 : Float))
                        if v66 then
                            return (6 : Int32)
                        else
                            v67 := (v4).floor
                            v68 := (v4 - v67)
                            v69 := (decide (v68 > (0.5 : Float)))
                            if v69 then
                                v70 := (v67 + (1.0 : Float))
                                v79 := v70
                            else
                                v71 := (decide (v68 < (0.5 : Float)))
                                if v71 then
                                    v79 := v67
                                else
                                    v72 := (v67 / (2.0 : Float))
                                    v73 := (v72).floor
                                    v74 := (v73 * (2.0 : Float))
                                    v75 := (v74 == v67)
                                    if v75 then
                                        v79 := v67
                                    else
                                        v76 := (v67 + (1.0 : Float))
                                        v79 := v76
                            v80 := (v79 != (0.0 : Float))
                            if v80 then
                                return (7 : Int32)
                            else
                                v81 := Float.atan2 v5 v5 
                                v82 := (v81 * (1000.0 : Float))
                                v83 := (v82).floor
                                v84 := (v83 != (785.0 : Float))
                                if v84 then
                                    return (8 : Int32)
                                else
                                    v85 := (v6).floor
                                    v86 := (v85 != (2.0 : Float32))
                                    if v86 then
                                        return (9 : Int32)
                                    else
                                        return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
