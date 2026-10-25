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
    let mut v13 : Char := default
    let mut v14 : Bool := default
    let mut v15 : Int32 := default
    let mut v16 : Bool := default
    let mut v17 : Int32 := default
    let mut v18 : Bool := default
    let mut v19 : Char := default
    let mut v20 : Bool := default
    let mut v21 : Int32 := default
    let mut v22 : Bool := default
    let mut v23 : Char := default
    let mut v24 : Bool := default
    let mut v25 : Char := default
    let mut v26 : Bool := default
    let mut v27 : Char := default
    let mut v28 : Bool := default
    let mut v29 : Char := default
    let mut v30 : Bool := default
    let mut v31 : Char := default
    let mut v32 : Bool := default
    let mut v33 : Char := default
    let mut v34 : Bool := default
    let mut v35 : Int32 := default
    let mut v36 : Bool := default
    let mut v37 : Char := default
    let mut v38 : Bool := default
    let mut v39 : Char := default
    let mut v40 : Bool := default
    let mut v41 : Bool := default
    let mut v42 : Int32 := default
    let mut v43 : Bool := default
    let mut v44 : Int32 := default
    let mut v45 : Bool := default
    let mut v46 : Char := default
    let mut v47 : Bool := default
    let mut v48 : Int32 := default
    let mut v49 : Bool := default
    let mut v50 : Char := default
    let mut v51 : Bool := default
    let mut v52 : Int32 := default
    let mut v53 : Bool := default
    let mut v54 : Char := default
    let mut v55 : Bool := default
    let mut v56 : Char := default
    let mut v57 : Bool := default
    let mut v58 : Char := default
    let mut v59 : Bool := default
    let mut v60 : Char := default
    let mut v61 : Bool := default
    let mut v62 : Int32 := default
    let mut v63 : Bool := default
    let mut v64 : Char := default
    let mut v65 : Bool := default
    let v0 : Int32 := (16 : Int32)
    let v1 : String := "x\ny"
    let v2 : String := "say \"hi\""
    let v3 : String := "a \"\"\" b"
    let v4 : String := "first\n    second\n\nthird"
    let v5 : String := "ab\ncd"
    let v6 : String := "a \"b\" c"
    let v7 : String := ""
    let v8 : String := "a\\nb"
    let v9 : String := "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
    let v10 : String := "\ntop\n\nlevel"
    let v11 : Int32 := (Int32.ofNat v6.utf8ByteSize)
    let v12 : Bool := (v11 != (7 : Int32))
    if v12 then
        return (1 : Int32)
    else
        v13 := (Char.ofNat (v6.toUTF8.get! (spiralIdx (2 : Int32))).toNat)
        v14 := (v13 != '"')
        if v14 then
            return (2 : Int32)
        else
            v15 := (Int32.ofNat v7.utf8ByteSize)
            v16 := (v15 != (0 : Int32))
            if v16 then
                return (3 : Int32)
            else
                v17 := (Int32.ofNat v8.utf8ByteSize)
                v18 := (v17 != (4 : Int32))
                if v18 then
                    return (4 : Int32)
                else
                    v19 := (Char.ofNat (v8.toUTF8.get! (spiralIdx (1 : Int32))).toNat)
                    v20 := (v19 != '\\')
                    if v20 then
                        return (5 : Int32)
                    else
                        v21 := (Int32.ofNat v9.utf8ByteSize)
                        v22 := (v21 != (83 : Int32))
                        if v22 then
                            return (6 : Int32)
                        else
                            v23 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (5 : Int32))).toNat)
                            v24 := (v23 != '\n')
                            if v24 then
                                return (7 : Int32)
                            else
                                v25 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (37 : Int32))).toNat)
                                v26 := (v25 != '\n')
                                if v26 then
                                    return (8 : Int32)
                                else
                                    v27 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (38 : Int32))).toNat)
                                    v28 := (v27 != '\n')
                                    if v28 then
                                        return (9 : Int32)
                                    else
                                        v29 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (39 : Int32))).toNat)
                                        v30 := (v29 != '$')
                                        if v30 then
                                            return (10 : Int32)
                                        else
                                            v31 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (57 : Int32))).toNat)
                                            v32 := (v31 != 'i')
                                            if v32 then
                                                return (11 : Int32)
                                            else
                                                v33 := (Char.ofNat (v9.toUTF8.get! (spiralIdx (82 : Int32))).toNat)
                                                v34 := (v33 != 'd')
                                                if v34 then
                                                    return (12 : Int32)
                                                else
                                                    v35 := (Int32.ofNat v10.utf8ByteSize)
                                                    v36 := (v35 != (11 : Int32))
                                                    if v36 then
                                                        return (13 : Int32)
                                                    else
                                                        v37 := (Char.ofNat (v10.toUTF8.get! (spiralIdx (0 : Int32))).toNat)
                                                        v38 := (v37 != '\n')
                                                        if v38 then
                                                            return (14 : Int32)
                                                        else
                                                            v39 := (Char.ofNat (v10.toUTF8.get! (spiralIdx (5 : Int32))).toNat)
                                                            v40 := (v39 != '\n')
                                                            if v40 then
                                                                return (15 : Int32)
                                                            else
                                                                v41 := (v0 != (16 : Int32))
                                                                if v41 then
                                                                    return (16 : Int32)
                                                                else
                                                                    v42 := (Int32.ofNat v1.utf8ByteSize)
                                                                    v43 := (v42 != (3 : Int32))
                                                                    if v43 then
                                                                        return (17 : Int32)
                                                                    else
                                                                        v44 := (Int32.ofNat v2.utf8ByteSize)
                                                                        v45 := (v44 != (8 : Int32))
                                                                        if v45 then
                                                                            return (18 : Int32)
                                                                        else
                                                                            v46 := (Char.ofNat (v2.toUTF8.get! (spiralIdx (7 : Int32))).toNat)
                                                                            v47 := (v46 != '"')
                                                                            if v47 then
                                                                                return (19 : Int32)
                                                                            else
                                                                                v48 := (Int32.ofNat v3.utf8ByteSize)
                                                                                v49 := (v48 != (7 : Int32))
                                                                                if v49 then
                                                                                    return (20 : Int32)
                                                                                else
                                                                                    v50 := (Char.ofNat (v3.toUTF8.get! (spiralIdx (4 : Int32))).toNat)
                                                                                    v51 := (v50 != '"')
                                                                                    if v51 then
                                                                                        return (21 : Int32)
                                                                                    else
                                                                                        v52 := (Int32.ofNat v4.utf8ByteSize)
                                                                                        v53 := (v52 != (23 : Int32))
                                                                                        if v53 then
                                                                                            return (22 : Int32)
                                                                                        else
                                                                                            v54 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (6 : Int32))).toNat)
                                                                                            v55 := (v54 != ' ')
                                                                                            if v55 then
                                                                                                return (23 : Int32)
                                                                                            else
                                                                                                v56 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (10 : Int32))).toNat)
                                                                                                v57 := (v56 != 's')
                                                                                                if v57 then
                                                                                                    return (24 : Int32)
                                                                                                else
                                                                                                    v58 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (17 : Int32))).toNat)
                                                                                                    v59 := (v58 != '\n')
                                                                                                    if v59 then
                                                                                                        return (25 : Int32)
                                                                                                    else
                                                                                                        v60 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (22 : Int32))).toNat)
                                                                                                        v61 := (v60 != 'd')
                                                                                                        if v61 then
                                                                                                            return (26 : Int32)
                                                                                                        else
                                                                                                            v62 := (Int32.ofNat v5.utf8ByteSize)
                                                                                                            v63 := (v62 != (5 : Int32))
                                                                                                            if v63 then
                                                                                                                return (27 : Int32)
                                                                                                            else
                                                                                                                v64 := (Char.ofNat (v5.toUTF8.get! (spiralIdx (3 : Int32))).toNat)
                                                                                                                v65 := (v64 != 'c')
                                                                                                                if v65 then
                                                                                                                    return (28 : Int32)
                                                                                                                else
                                                                                                                    return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
