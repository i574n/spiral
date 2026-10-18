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
    let mut v0 : Int32 := default
    let mut v1 : String := default
    let mut v2 : String := default
    let mut v3 : String := default
    let mut v4 : String := default
    let mut v5 : String := default
    let mut v6 : String := default
    let mut v7 : String := default
    let mut v8 : String := default
    let mut v9 : String := default
    let mut v10 : String := default
    let mut v11 : Int32 := default
    let mut v12 : Bool := default
    let mut v13 : Bool := default
    let mut v14 : Char := default
    let mut v15 : Bool := default
    let mut v16 : Bool := default
    let mut v17 : Int32 := default
    let mut v18 : Bool := default
    let mut v19 : Bool := default
    let mut v20 : Int32 := default
    let mut v21 : Bool := default
    let mut v22 : Bool := default
    let mut v23 : Char := default
    let mut v24 : Bool := default
    let mut v25 : Bool := default
    let mut v26 : Int32 := default
    let mut v27 : Bool := default
    let mut v28 : Bool := default
    let mut v29 : Char := default
    let mut v30 : Bool := default
    let mut v31 : Bool := default
    let mut v32 : Char := default
    let mut v33 : Bool := default
    let mut v34 : Bool := default
    let mut v35 : Char := default
    let mut v36 : Bool := default
    let mut v37 : Bool := default
    let mut v38 : Char := default
    let mut v39 : Bool := default
    let mut v40 : Bool := default
    let mut v41 : Char := default
    let mut v42 : Bool := default
    let mut v43 : Bool := default
    let mut v44 : Char := default
    let mut v45 : Bool := default
    let mut v46 : Bool := default
    let mut v47 : Int32 := default
    let mut v48 : Bool := default
    let mut v49 : Bool := default
    let mut v50 : Char := default
    let mut v51 : Bool := default
    let mut v52 : Bool := default
    let mut v53 : Char := default
    let mut v54 : Bool := default
    let mut v55 : Bool := default
    let mut v56 : Bool := default
    let mut v57 : Bool := default
    let mut v58 : Int32 := default
    let mut v59 : Bool := default
    let mut v60 : Bool := default
    let mut v61 : Int32 := default
    let mut v62 : Bool := default
    let mut v63 : Bool := default
    let mut v64 : Char := default
    let mut v65 : Bool := default
    let mut v66 : Bool := default
    let mut v67 : Int32 := default
    let mut v68 : Bool := default
    let mut v69 : Bool := default
    let mut v70 : Char := default
    let mut v71 : Bool := default
    let mut v72 : Bool := default
    let mut v73 : Int32 := default
    let mut v74 : Bool := default
    let mut v75 : Bool := default
    let mut v76 : Char := default
    let mut v77 : Bool := default
    let mut v78 : Bool := default
    let mut v79 : Char := default
    let mut v80 : Bool := default
    let mut v81 : Bool := default
    let mut v82 : Char := default
    let mut v83 : Bool := default
    let mut v84 : Bool := default
    let mut v85 : Char := default
    let mut v86 : Bool := default
    let mut v87 : Bool := default
    let mut v88 : Int32 := default
    let mut v89 : Bool := default
    let mut v90 : Bool := default
    let mut v91 : Char := default
    let mut v92 : Bool := default
    let mut v93 : Bool := default
    v0 := (16 : Int32)
    v1 := "x\ny"
    v2 := "say \"hi\""
    v3 := "a \"\"\" b"
    v4 := "first\n    second\n\nthird"
    v5 := "ab\ncd"
    v6 := "a \"b\" c"
    v7 := ""
    v8 := "a\\nb"
    v9 := "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
    v10 := "\ntop\n\nlevel"
    v11 := (Int32.ofNat v6.utf8ByteSize)
    v12 := (v11 == (7 : Int32))
    v13 := (v12 != true)
    if v13 then
        return (1 : Int32)
    else
        v14 := (Char.ofNat (v6.toUTF8.get! (spiralIdx (2 : Int32))).toNat)
        v15 := (v14 == '"')
        v16 := (v15 != true)
        if v16 then
            return (2 : Int32)
        else
            v17 := (Int32.ofNat v7.utf8ByteSize)
            v18 := (v17 == (0 : Int32))
            v19 := (v18 != true)
            if v19 then
                return (3 : Int32)
            else
                v20 := (Int32.ofNat v8.utf8ByteSize)
                v21 := (v20 == (4 : Int32))
                v22 := (v21 != true)
                if v22 then
                    return (4 : Int32)
                else
                    v23 := (Char.ofNat (v8.toUTF8.get! (spiralIdx (1 : Int32))).toNat)
                    v24 := (v23 == '\\')
                    v25 := (v24 != true)
                    if v25 then
                        return (5 : Int32)
                    else
                        v26 := (Int32.ofNat v9.utf8ByteSize)
                        v27 := (v26 == (83 : Int32))
                        v28 := (v27 != true)
                        if v28 then
                            return (6 : Int32)
                        else
                            v29 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (5 : Int32))).toNat)
                            v30 := (v29 == '\n')
                            v31 := (v30 != true)
                            if v31 then
                                return (7 : Int32)
                            else
                                v32 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (37 : Int32))).toNat)
                                v33 := (v32 == '\n')
                                v34 := (v33 != true)
                                if v34 then
                                    return (8 : Int32)
                                else
                                    v35 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (38 : Int32))).toNat)
                                    v36 := (v35 == '\n')
                                    v37 := (v36 != true)
                                    if v37 then
                                        return (9 : Int32)
                                    else
                                        v38 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (39 : Int32))).toNat)
                                        v39 := (v38 == '$')
                                        v40 := (v39 != true)
                                        if v40 then
                                            return (10 : Int32)
                                        else
                                            v41 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (57 : Int32))).toNat)
                                            v42 := (v41 == 'i')
                                            v43 := (v42 != true)
                                            if v43 then
                                                return (11 : Int32)
                                            else
                                                v44 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (82 : Int32))).toNat)
                                                v45 := (v44 == 'd')
                                                v46 := (v45 != true)
                                                if v46 then
                                                    return (12 : Int32)
                                                else
                                                    v47 := (Int32.ofNat v10.utf8ByteSize)
                                                    v48 := (v47 == (11 : Int32))
                                                    v49 := (v48 != true)
                                                    if v49 then
                                                        return (13 : Int32)
                                                    else
                                                        v50 := (Char.ofNat (v10.toUTF8.get! (spiralIdx (0 : Int32))).toNat)
                                                        v51 := (v50 == '\n')
                                                        v52 := (v51 != true)
                                                        if v52 then
                                                            return (14 : Int32)
                                                        else
                                                            v53 := (Char.ofNat (v10.toUTF8.get! (spiralIdx (5 : Int32))).toNat)
                                                            v54 := (v53 == '\n')
                                                            v55 := (v54 != true)
                                                            if v55 then
                                                                return (15 : Int32)
                                                            else
                                                                v56 := (v0 == (16 : Int32))
                                                                v57 := (v56 != true)
                                                                if v57 then
                                                                    return (16 : Int32)
                                                                else
                                                                    v58 := (Int32.ofNat v1.utf8ByteSize)
                                                                    v59 := (v58 == (3 : Int32))
                                                                    v60 := (v59 != true)
                                                                    if v60 then
                                                                        return (17 : Int32)
                                                                    else
                                                                        v61 := (Int32.ofNat v2.utf8ByteSize)
                                                                        v62 := (v61 == (8 : Int32))
                                                                        v63 := (v62 != true)
                                                                        if v63 then
                                                                            return (18 : Int32)
                                                                        else
                                                                            v64 := (Char.ofNat (v2.toUTF8.get! (spiralIdx (7 : Int32))).toNat)
                                                                            v65 := (v64 == '"')
                                                                            v66 := (v65 != true)
                                                                            if v66 then
                                                                                return (19 : Int32)
                                                                            else
                                                                                v67 := (Int32.ofNat v3.utf8ByteSize)
                                                                                v68 := (v67 == (7 : Int32))
                                                                                v69 := (v68 != true)
                                                                                if v69 then
                                                                                    return (20 : Int32)
                                                                                else
                                                                                    v70 := (Char.ofNat (v3.toUTF8.get! (spiralIdx (4 : Int32))).toNat)
                                                                                    v71 := (v70 == '"')
                                                                                    v72 := (v71 != true)
                                                                                    if v72 then
                                                                                        return (21 : Int32)
                                                                                    else
                                                                                        v73 := (Int32.ofNat v4.utf8ByteSize)
                                                                                        v74 := (v73 == (23 : Int32))
                                                                                        v75 := (v74 != true)
                                                                                        if v75 then
                                                                                            return (22 : Int32)
                                                                                        else
                                                                                            v76 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (6 : Int32))).toNat)
                                                                                            v77 := (v76 == ' ')
                                                                                            v78 := (v77 != true)
                                                                                            if v78 then
                                                                                                return (23 : Int32)
                                                                                            else
                                                                                                v79 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (10 : Int32))).toNat)
                                                                                                v80 := (v79 == 's')
                                                                                                v81 := (v80 != true)
                                                                                                if v81 then
                                                                                                    return (24 : Int32)
                                                                                                else
                                                                                                    v82 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (17 : Int32))).toNat)
                                                                                                    v83 := (v82 == '\n')
                                                                                                    v84 := (v83 != true)
                                                                                                    if v84 then
                                                                                                        return (25 : Int32)
                                                                                                    else
                                                                                                        v85 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (22 : Int32))).toNat)
                                                                                                        v86 := (v85 == 'd')
                                                                                                        v87 := (v86 != true)
                                                                                                        if v87 then
                                                                                                            return (26 : Int32)
                                                                                                        else
                                                                                                            v88 := (Int32.ofNat v5.utf8ByteSize)
                                                                                                            v89 := (v88 == (5 : Int32))
                                                                                                            v90 := (v89 != true)
                                                                                                            if v90 then
                                                                                                                return (27 : Int32)
                                                                                                            else
                                                                                                                v91 := (Char.ofNat (v5.toUTF8.get! (spiralIdx (3 : Int32))).toNat)
                                                                                                                v92 := (v91 == 'c')
                                                                                                                v93 := (v92 != true)
                                                                                                                if v93 then
                                                                                                                    return (28 : Int32)
                                                                                                                else
                                                                                                                    return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
