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
    let mut v0 : String := default
    let mut v1 : String := default
    let mut v2 : String := default
    let mut v3 : String := default
    let mut v4 : String := default
    let mut v5 : Int32 := default
    let mut v6 : Bool := default
    let mut v7 : Bool := default
    let mut v8 : Char := default
    let mut v9 : Bool := default
    let mut v10 : Bool := default
    let mut v11 : Int32 := default
    let mut v12 : Bool := default
    let mut v13 : Bool := default
    let mut v14 : Int32 := default
    let mut v15 : Bool := default
    let mut v16 : Bool := default
    let mut v17 : Char := default
    let mut v18 : Bool := default
    let mut v19 : Bool := default
    let mut v20 : Int32 := default
    let mut v21 : Bool := default
    let mut v22 : Bool := default
    let mut v23 : Char := default
    let mut v24 : Bool := default
    let mut v25 : Bool := default
    let mut v26 : Char := default
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
    let mut v41 : Int32 := default
    let mut v42 : Bool := default
    let mut v43 : Bool := default
    let mut v44 : Char := default
    let mut v45 : Bool := default
    let mut v46 : Bool := default
    let mut v47 : Char := default
    let mut v48 : Bool := default
    let mut v49 : Bool := default
    v0 := "a \"b\" c"
    v1 := ""
    v2 := "a\\nb"
    v3 := "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
    v4 := "\ntop\n\nlevel"
    v5 := (Int32.ofNat v0.utf8ByteSize)
    v6 := (v5 == (7 : Int32))
    v7 := (v6 != true)
    if v7 then
        return (1 : Int32)
    else
        v8 := (Char.ofNat (v0.toUTF8.get! (spiralIdx (2 : Int32))).toNat)
        v9 := (v8 == '"')
        v10 := (v9 != true)
        if v10 then
            return (2 : Int32)
        else
            v11 := (Int32.ofNat v1.utf8ByteSize)
            v12 := (v11 == (0 : Int32))
            v13 := (v12 != true)
            if v13 then
                return (3 : Int32)
            else
                v14 := (Int32.ofNat v2.utf8ByteSize)
                v15 := (v14 == (4 : Int32))
                v16 := (v15 != true)
                if v16 then
                    return (4 : Int32)
                else
                    v17 := (Char.ofNat (v2.toUTF8.get! (spiralIdx (1 : Int32))).toNat)
                    v18 := (v17 == '\\')
                    v19 := (v18 != true)
                    if v19 then
                        return (5 : Int32)
                    else
                        v20 := (Int32.ofNat v3.utf8ByteSize)
                        v21 := (v20 == (83 : Int32))
                        v22 := (v21 != true)
                        if v22 then
                            return (6 : Int32)
                        else
                            v23 := (Char.ofNat (v3.toUTF8.get! (spiralIdx (5 : Int32))).toNat)
                            v24 := (v23 == '\n')
                            v25 := (v24 != true)
                            if v25 then
                                return (7 : Int32)
                            else
                                v26 := (Char.ofNat (v3.toUTF8.get! (spiralIdx (37 : Int32))).toNat)
                                v27 := (v26 == '\n')
                                v28 := (v27 != true)
                                if v28 then
                                    return (8 : Int32)
                                else
                                    v29 := (Char.ofNat (v3.toUTF8.get! (spiralIdx (38 : Int32))).toNat)
                                    v30 := (v29 == '\n')
                                    v31 := (v30 != true)
                                    if v31 then
                                        return (9 : Int32)
                                    else
                                        v32 := (Char.ofNat (v3.toUTF8.get! (spiralIdx (39 : Int32))).toNat)
                                        v33 := (v32 == '$')
                                        v34 := (v33 != true)
                                        if v34 then
                                            return (10 : Int32)
                                        else
                                            v35 := (Char.ofNat (v3.toUTF8.get! (spiralIdx (57 : Int32))).toNat)
                                            v36 := (v35 == 'i')
                                            v37 := (v36 != true)
                                            if v37 then
                                                return (11 : Int32)
                                            else
                                                v38 := (Char.ofNat (v3.toUTF8.get! (spiralIdx (82 : Int32))).toNat)
                                                v39 := (v38 == 'd')
                                                v40 := (v39 != true)
                                                if v40 then
                                                    return (12 : Int32)
                                                else
                                                    v41 := (Int32.ofNat v4.utf8ByteSize)
                                                    v42 := (v41 == (11 : Int32))
                                                    v43 := (v42 != true)
                                                    if v43 then
                                                        return (13 : Int32)
                                                    else
                                                        v44 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (0 : Int32))).toNat)
                                                        v45 := (v44 == '\n')
                                                        v46 := (v45 != true)
                                                        if v46 then
                                                            return (14 : Int32)
                                                        else
                                                            v47 := (Char.ofNat (v4.toUTF8.get! (spiralIdx (5 : Int32))).toNat)
                                                            v48 := (v47 == '\n')
                                                            v49 := (v48 != true)
                                                            if v49 then
                                                                return (15 : Int32)
                                                            else
                                                                return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
