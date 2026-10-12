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
    let mut v2 : Char := default
    v2 := (Char.ofNat (v0.toUTF8.get! (spiralIdx v1)).toNat)
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
            let t0 := v0
            let t1 := v1
            let t2 := v2
            let t13 := v13
            let t12 := v12
            let t5 := v5
            v0 := t0
            v1 := t1
            v2 := t2
            v3 := t13
            v4 := t12
            v5 := t5
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
                let t0 := v0
                let t1 := v1
                let t2 := v2
                let t3 := v3
                let t12 := v12
                let t5 := v5
                let t6 := v6
                v0 := t0
                v1 := t1
                v2 := t2
                v3 := t3
                v4 := t12
                v5 := t5
                v6 := t6
                continue
            else
                v14 := (v5 == v3)
                if v14 then
                    return v4
                else
                    v15 := (v4 + (1 : Int32))
                    v16 := (v5 + (1 : Int32))
                    let t0 := v0
                    let t1 := v1
                    let t2 := v2
                    let t3 := v3
                    let t15 := v15
                    let t16 := v16
                    let t6 := v6
                    v0 := t0
                    v1 := t1
                    v2 := t2
                    v3 := t3
                    v4 := t15
                    v5 := t16
                    v6 := t6
                    continue
partial def spiralMain : IO Int32 := do
    let mut v0 : String := default
    let mut v1 : Int32 := default
    let mut v2 : Char := default
    let mut v3 : String := default
    let mut v4 : Int32 := default
    let mut v5 : Char := default
    let mut v6 : String := default
    let mut v7 : Int32 := default
    let mut v8 : Int32 := default
    let mut v9 : Int32 := default
    let mut v10 : Int32 := default
    let mut v11 : Int32 := default
    let mut v12 : Char := default
    let mut v13 : Int32 := default
    let mut v14 : Char := default
    let mut v15 : Int32 := default
    let mut v16 : Int32 := default
    let mut v17 : Int32 := default
    let mut v18 : Int32 := default
    let mut v19 : Int32 := default
    let mut v20 : Int32 := default
    let mut v21 : Char := default
    let mut v22 : Int32 := default
    let mut v23 : Char := default
    let mut v24 : Int32 := default
    let mut v25 : Int32 := default
    let mut v26 : Int32 := default
    let mut v27 : Int32 := default
    let mut v28 : Int32 := default
    let mut v29 : Int32 := default
    let mut v30 : String := default
    let mut v31 : Int32 := default
    let mut v32 : Char := default
    let mut v33 : Int32 := default
    let mut v34 : Char := default
    let mut v35 : Int32 := default
    let mut v36 : Int32 := default
    let mut v37 : Int32 := default
    let mut v38 : Int32 := default
    let mut v39 : Int32 := default
    let mut v40 : Int32 := default
    let mut v41 : Char := default
    let mut v42 : Int32 := default
    let mut v43 : Char := default
    let mut v44 : Int32 := default
    let mut v45 : Int32 := default
    let mut v46 : Int32 := default
    let mut v47 : Int32 := default
    let mut v48 : Int32 := default
    let mut v49 : Int32 := default
    let mut v50 : String := default
    let mut v51 : Int32 := default
    let mut v52 : Char := default
    let mut v53 : Int32 := default
    let mut v54 : Char := default
    let mut v55 : Int32 := default
    let mut v56 : Int32 := default
    let mut v57 : Int32 := default
    let mut v58 : Int32 := default
    let mut v59 : Int32 := default
    let mut v60 : Int32 := default
    let mut v61 : Char := default
    let mut v62 : Int32 := default
    let mut v63 : Char := default
    let mut v64 : Int32 := default
    let mut v65 : Int32 := default
    let mut v66 : Int32 := default
    let mut v67 : Int32 := default
    let mut v68 : Int32 := default
    let mut v69 : Int32 := default
    let mut v70 : String := default
    let mut v71 : Int32 := default
    let mut v72 : Char := default
    let mut v73 : Int32 := default
    let mut v74 : Char := default
    let mut v75 : Int32 := default
    let mut v76 : Int32 := default
    let mut v77 : Int32 := default
    let mut v78 : Int32 := default
    let mut v79 : Int32 := default
    let mut v80 : Int32 := default
    let mut v81 : Char := default
    let mut v82 : String := default
    let mut v83 : Int32 := default
    let mut v84 : Char := default
    let mut v85 : Int32 := default
    let mut v86 : Char := default
    let mut v87 : String := default
    let mut v88 : Int32 := default
    let mut v89 : Char := default
    let mut v90 : Bool := default
    let mut v91 : Int32 := default
    let mut v92 : Bool := default
    let mut v93 : Bool := default
    let mut v94 : Int32 := default
    let mut v95 : Bool := default
    let mut v96 : Bool := default
    let mut v97 : Int32 := default
    let mut v98 : Bool := default
    let mut v99 : Bool := default
    v0 := "À"
    v1 := (1 : Int32)
    v2 := (← runtime_byte_0 v0 v1)
    v3 := "©"
    v4 := (0 : Int32)
    v5 := (← runtime_byte_0 v3 v4)
    v6 := "Aéλ🙂Z"
    v7 := (0 : Int32)
    v8 := (0 : Int32)
    v9 := (10 : Int32)
    v10 := (← codepoint_length_loop_1 v6 v2 v5 v7 v8 v9)
    v11 := (1 : Int32)
    v12 := (← runtime_byte_0 v0 v11)
    v13 := (0 : Int32)
    v14 := (← runtime_byte_0 v3 v13)
    v15 := (1 : Int32)
    v16 := (0 : Int32)
    v17 := (0 : Int32)
    v18 := (10 : Int32)
    v19 := (← codepoint_byte_offset_loop_2 v6 v12 v14 v15 v16 v17 v18)
    v20 := (1 : Int32)
    v21 := (← runtime_byte_0 v0 v20)
    v22 := (0 : Int32)
    v23 := (← runtime_byte_0 v3 v22)
    v24 := (2 : Int32)
    v25 := (0 : Int32)
    v26 := (0 : Int32)
    v27 := (10 : Int32)
    v28 := (← codepoint_byte_offset_loop_2 v6 v21 v23 v24 v25 v26 v27)
    v29 := (v28 - (1 : Int32))
    v30 := (← spiralStringSlice "Aéλ🙂Z" (SpiralToInt.toI v19) (SpiralToInt.toI v29))
    v31 := (1 : Int32)
    v32 := (← runtime_byte_0 v0 v31)
    v33 := (0 : Int32)
    v34 := (← runtime_byte_0 v3 v33)
    v35 := (3 : Int32)
    v36 := (0 : Int32)
    v37 := (0 : Int32)
    v38 := (10 : Int32)
    v39 := (← codepoint_byte_offset_loop_2 v6 v32 v34 v35 v36 v37 v38)
    v40 := (1 : Int32)
    v41 := (← runtime_byte_0 v0 v40)
    v42 := (0 : Int32)
    v43 := (← runtime_byte_0 v3 v42)
    v44 := (4 : Int32)
    v45 := (0 : Int32)
    v46 := (0 : Int32)
    v47 := (10 : Int32)
    v48 := (← codepoint_byte_offset_loop_2 v6 v41 v43 v44 v45 v46 v47)
    v49 := (v48 - (1 : Int32))
    v50 := (← spiralStringSlice "Aéλ🙂Z" (SpiralToInt.toI v39) (SpiralToInt.toI v49))
    v51 := (1 : Int32)
    v52 := (← runtime_byte_0 v0 v51)
    v53 := (0 : Int32)
    v54 := (← runtime_byte_0 v3 v53)
    v55 := (1 : Int32)
    v56 := (0 : Int32)
    v57 := (0 : Int32)
    v58 := (10 : Int32)
    v59 := (← codepoint_byte_offset_loop_2 v6 v52 v54 v55 v56 v57 v58)
    v60 := (1 : Int32)
    v61 := (← runtime_byte_0 v0 v60)
    v62 := (0 : Int32)
    v63 := (← runtime_byte_0 v3 v62)
    v64 := (4 : Int32)
    v65 := (0 : Int32)
    v66 := (0 : Int32)
    v67 := (10 : Int32)
    v68 := (← codepoint_byte_offset_loop_2 v6 v61 v63 v64 v65 v66 v67)
    v69 := (v68 - (1 : Int32))
    v70 := (← spiralStringSlice "Aéλ🙂Z" (SpiralToInt.toI v59) (SpiralToInt.toI v69))
    v71 := (1 : Int32)
    v72 := (← runtime_byte_0 v0 v71)
    v73 := (0 : Int32)
    v74 := (← runtime_byte_0 v3 v73)
    v75 := (3 : Int32)
    v76 := (0 : Int32)
    v77 := (0 : Int32)
    v78 := (10 : Int32)
    v79 := (← codepoint_byte_offset_loop_2 v6 v72 v74 v75 v76 v77 v78)
    v80 := (0 : Int32)
    v81 := (← runtime_byte_0 v30 v80)
    v82 := "é"
    v83 := (0 : Int32)
    v84 := (← runtime_byte_0 v82 v83)
    v85 := (3 : Int32)
    v86 := (← runtime_byte_0 v50 v85)
    v87 := "🙂"
    v88 := (3 : Int32)
    v89 := (← runtime_byte_0 v87 v88)
    v90 := (v10 == (5 : Int32))
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
