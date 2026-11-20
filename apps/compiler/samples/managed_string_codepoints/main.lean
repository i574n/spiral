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
partial def runtime_byte_0 (p0 : String) (p1 : Int32) : IO Char := do
    let mut v0 : String := p0
    let mut v1 : Int32 := p1
    let v2 : Char := (Char.ofNat (v0.toUTF8.get! (spiralIdx v1)).toNat)
    return v2
partial def codepoint_length_loop_1 (p0 : String) (p1 : Char) (p2 : Char) (p3 : Int32) (p4 : Int32) (p5 : Int32) : IO Int32 := do
    let mut v0 : String := p0
    let mut v1 : Char := p1
    let mut v2 : Char := p2
    let mut v3 : Int32 := p3
    let mut v4 : Int32 := p4
    let mut v5 : Int32 := p5
    let mut v6 : Bool := default
    let mut v7 : Char := default
    let mut v8 : Bool := default
    let mut v10 : Bool := default
    let mut v9 : Bool := default
    let mut v12 : Int32 := default
    let mut v11 : Int32 := default
    let mut v13 : Int32 := default
    repeat
        v6 := (v3 == v5)
        if v6 then
            return v4
        else
            v7 := (Char.ofNat (v0.toUTF8.get! (spiralIdx v3)).toNat)
            v8 := (decide (v7 < v1))
            if v8 then
                v10 := false
            else
                v9 := (decide (v7 < v2))
                v10 := v9
            if v10 then
                v12 := v4
            else
                v11 := (v4 + (1 : Int32))
                v12 := v11
            v13 := (v3 + (1 : Int32))
            v3 := v13
            v4 := v12
            continue
partial def codepoint_byte_offset_loop_2 (p0 : String) (p1 : Char) (p2 : Char) (p3 : Int32) (p4 : Int32) (p5 : Int32) (p6 : Int32) : IO Int32 := do
    let mut v0 : String := p0
    let mut v1 : Char := p1
    let mut v2 : Char := p2
    let mut v3 : Int32 := p3
    let mut v4 : Int32 := p4
    let mut v5 : Int32 := p5
    let mut v6 : Int32 := p6
    let mut v7 : Bool := default
    let mut v8 : Char := default
    let mut v9 : Bool := default
    let mut v11 : Bool := default
    let mut v10 : Bool := default
    let mut v12 : Int32 := default
    let mut v14 : Bool := default
    let mut v15 : Int32 := default
    let mut v16 : Int32 := default
    repeat
        v7 := (v4 == v6)
        if v7 then
            return v6
        else
            v8 := (Char.ofNat (v0.toUTF8.get! (spiralIdx v4)).toNat)
            v9 := (decide (v8 < v1))
            if v9 then
                v11 := false
            else
                v10 := (decide (v8 < v2))
                v11 := v10
            if v11 then
                v12 := (v4 + (1 : Int32))
                v4 := v12
                continue
            else
                v14 := (v5 == v3)
                if v14 then
                    return v4
                else
                    v15 := (v4 + (1 : Int32))
                    v16 := (v5 + (1 : Int32))
                    v4 := v15
                    v5 := v16
                    continue
partial def spiralMain : IO Int32 := do
    let mut v91 : Int32 := default
    let mut v92 : Bool := default
    let mut v93 : Bool := default
    let mut v94 : Int32 := default
    let mut v95 : Bool := default
    let mut v96 : Bool := default
    let mut v97 : Int32 := default
    let mut v98 : Bool := default
    let mut v99 : Bool := default
    let v0 : String := "À"
    let v1 : Int32 := (1 : Int32)
    let v2 : Char := (← runtime_byte_0 v0 v1)
    let v3 : String := "©"
    let v4 : Int32 := (0 : Int32)
    let v5 : Char := (← runtime_byte_0 v3 v4)
    let v6 : String := "Aéλ🙂Z"
    let v7 : Int32 := (0 : Int32)
    let v8 : Int32 := (0 : Int32)
    let v9 : Int32 := (10 : Int32)
    let v10 : Int32 := (← codepoint_length_loop_1 v6 v2 v5 v7 v8 v9)
    let v11 : Int32 := (1 : Int32)
    let v12 : Char := (← runtime_byte_0 v0 v11)
    let v13 : Int32 := (0 : Int32)
    let v14 : Char := (← runtime_byte_0 v3 v13)
    let v15 : Int32 := (1 : Int32)
    let v16 : Int32 := (0 : Int32)
    let v17 : Int32 := (0 : Int32)
    let v18 : Int32 := (10 : Int32)
    let v19 : Int32 := (← codepoint_byte_offset_loop_2 v6 v12 v14 v15 v16 v17 v18)
    let v20 : Int32 := (1 : Int32)
    let v21 : Char := (← runtime_byte_0 v0 v20)
    let v22 : Int32 := (0 : Int32)
    let v23 : Char := (← runtime_byte_0 v3 v22)
    let v24 : Int32 := (2 : Int32)
    let v25 : Int32 := (0 : Int32)
    let v26 : Int32 := (0 : Int32)
    let v27 : Int32 := (10 : Int32)
    let v28 : Int32 := (← codepoint_byte_offset_loop_2 v6 v21 v23 v24 v25 v26 v27)
    let v29 : Int32 := (v28 - (1 : Int32))
    let v30 : String := (← spiralStringSlice "Aéλ🙂Z" (SpiralToInt.toI v19) (SpiralToInt.toI v29))
    let v31 : Int32 := (1 : Int32)
    let v32 : Char := (← runtime_byte_0 v0 v31)
    let v33 : Int32 := (0 : Int32)
    let v34 : Char := (← runtime_byte_0 v3 v33)
    let v35 : Int32 := (3 : Int32)
    let v36 : Int32 := (0 : Int32)
    let v37 : Int32 := (0 : Int32)
    let v38 : Int32 := (10 : Int32)
    let v39 : Int32 := (← codepoint_byte_offset_loop_2 v6 v32 v34 v35 v36 v37 v38)
    let v40 : Int32 := (1 : Int32)
    let v41 : Char := (← runtime_byte_0 v0 v40)
    let v42 : Int32 := (0 : Int32)
    let v43 : Char := (← runtime_byte_0 v3 v42)
    let v44 : Int32 := (4 : Int32)
    let v45 : Int32 := (0 : Int32)
    let v46 : Int32 := (0 : Int32)
    let v47 : Int32 := (10 : Int32)
    let v48 : Int32 := (← codepoint_byte_offset_loop_2 v6 v41 v43 v44 v45 v46 v47)
    let v49 : Int32 := (v48 - (1 : Int32))
    let v50 : String := (← spiralStringSlice "Aéλ🙂Z" (SpiralToInt.toI v39) (SpiralToInt.toI v49))
    let v51 : Int32 := (1 : Int32)
    let v52 : Char := (← runtime_byte_0 v0 v51)
    let v53 : Int32 := (0 : Int32)
    let v54 : Char := (← runtime_byte_0 v3 v53)
    let v55 : Int32 := (1 : Int32)
    let v56 : Int32 := (0 : Int32)
    let v57 : Int32 := (0 : Int32)
    let v58 : Int32 := (10 : Int32)
    let v59 : Int32 := (← codepoint_byte_offset_loop_2 v6 v52 v54 v55 v56 v57 v58)
    let v60 : Int32 := (1 : Int32)
    let v61 : Char := (← runtime_byte_0 v0 v60)
    let v62 : Int32 := (0 : Int32)
    let v63 : Char := (← runtime_byte_0 v3 v62)
    let v64 : Int32 := (4 : Int32)
    let v65 : Int32 := (0 : Int32)
    let v66 : Int32 := (0 : Int32)
    let v67 : Int32 := (10 : Int32)
    let v68 : Int32 := (← codepoint_byte_offset_loop_2 v6 v61 v63 v64 v65 v66 v67)
    let v69 : Int32 := (v68 - (1 : Int32))
    let v70 : String := (← spiralStringSlice "Aéλ🙂Z" (SpiralToInt.toI v59) (SpiralToInt.toI v69))
    let v71 : Int32 := (1 : Int32)
    let v72 : Char := (← runtime_byte_0 v0 v71)
    let v73 : Int32 := (0 : Int32)
    let v74 : Char := (← runtime_byte_0 v3 v73)
    let v75 : Int32 := (3 : Int32)
    let v76 : Int32 := (0 : Int32)
    let v77 : Int32 := (0 : Int32)
    let v78 : Int32 := (10 : Int32)
    let v79 : Int32 := (← codepoint_byte_offset_loop_2 v6 v72 v74 v75 v76 v77 v78)
    let v80 : Int32 := (0 : Int32)
    let v81 : Char := (← runtime_byte_0 v30 v80)
    let v82 : String := "é"
    let v83 : Int32 := (0 : Int32)
    let v84 : Char := (← runtime_byte_0 v82 v83)
    let v85 : Int32 := (3 : Int32)
    let v86 : Char := (← runtime_byte_0 v50 v85)
    let v87 : String := "🙂"
    let v88 : Int32 := (3 : Int32)
    let v89 : Char := (← runtime_byte_0 v87 v88)
    let v90 : Bool := (v10 == (5 : Int32))
    if v90 then
        v91 := (Int32.ofNat v30.utf8ByteSize)
        v92 := (v91 == (2 : Int32))
        if v92 then
            v93 := (v81 == v84)
            if v93 then
                v94 := (Int32.ofNat v50.utf8ByteSize)
                v95 := (v94 == (4 : Int32))
                if v95 then
                    v96 := (v86 == v89)
                    if v96 then
                        v97 := (Int32.ofNat v70.utf8ByteSize)
                        v98 := (v97 == (8 : Int32))
                        if v98 then
                            v99 := (v79 == (5 : Int32))
                            if v99 then
                                return (0 : Int32)
                            else
                                return (1 : Int32)
                        else
                            return (2 : Int32)
                    else
                        return (3 : Int32)
                else
                    return (4 : Int32)
            else
                return (5 : Int32)
        else
            return (6 : Int32)
    else
        return (7 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
