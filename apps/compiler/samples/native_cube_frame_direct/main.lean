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
partial def method1 (p0 : Int32) : IO Bool := do
    let mut v0 : Int32 := p0
    let v1 : Bool := (decide (v0 < (7040 : Int32)))
    return v1
partial def method0 : IO (IO.Ref (Array Int32)) := do
    let mut v0 : (IO.Ref (Array Int32)) ← IO.mkRef #[]
    let mut v1 : Int32 := default
    let mut v3 : Int32 := default
    v0 := (← IO.mkRef (Array.replicate (spiralIdx (7040 : Int32)) (default : Int32)))
    v1 := (0 : Int32)
    repeat
        if !(← method1 v1) then break
        v0.modify (fun xs => xs.set! (spiralIdx v1) (46 : Int32))
        v3 := (v1 + (1 : Int32))
        v1 := v3
    return v0
partial def method2 (p0 : (IO.Ref (Array Int32))) : IO Int32 := do
    let mut v0 : (IO.Ref (Array Int32)) := p0
    v0.modify (fun xs => xs.set! (spiralIdx (5180 : Int32)) (35 : Int32))
    return (5180 : Int32)
partial def method3 (p0 : (IO.Ref (Array Int32))) : IO Int32 := do
    let mut v0 : (IO.Ref (Array Int32)) := p0
    v0.modify (fun xs => xs.set! (spiralIdx (4258 : Int32)) (64 : Int32))
    return (4258 : Int32)
partial def method4 (p0 : (IO.Ref (Array Int32))) : IO Int32 := do
    let mut v0 : (IO.Ref (Array Int32)) := p0
    v0.modify (fun xs => xs.set! (spiralIdx (3964 : Int32)) (43 : Int32))
    return (3964 : Int32)
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
    let mut v31 : Bool := default
    let mut v30 : Bool := default
    let mut v33 : Bool := default
    let mut v32 : Bool := default
    let mut v35 : Bool := default
    let mut v34 : Bool := default
    let mut v37 : Bool := default
    let mut v36 : Bool := default
    let mut v39 : Bool := default
    let mut v38 : Bool := default
    let mut v41 : Bool := default
    let mut v40 : Bool := default
    let mut v43 : Bool := default
    let mut v42 : Bool := default
    let mut v45 : Bool := default
    let mut v44 : Bool := default
    let mut v47 : Bool := default
    let mut v46 : Bool := default
    let mut v49 : Bool := default
    let mut v48 : Bool := default
    let mut v51 : Bool := default
    let mut v50 : Bool := default
    let mut v53 : Bool := default
    let mut v52 : Bool := default
    let mut v55 : Bool := default
    let mut v54 : Bool := default
    let mut v57 : Bool := default
    let mut v56 : Bool := default
    v0 := (← method0)
    let v1 : Int32 := (← method2 v0)
    let v2 : Int32 := (← method3 v0)
    let v3 : Int32 := (← method4 v0)
    let v4 : Int32 := (← spiralIndex (← v0.get) (spiralIdx (0 : Int32)))
    let v5 : Int32 := (← spiralIndex (← v0.get) (spiralIdx (5180 : Int32)))
    let v6 : Int32 := (← spiralIndex (← v0.get) (spiralIdx (4258 : Int32)))
    let v7 : Int32 := (← spiralIndex (← v0.get) (spiralIdx (3964 : Int32)))
    let v8 : Int32 := (160 : Int32)
    let v9 : Int32 := (7040 : Int32)
    let v10 : Int32 := (0 : Int32)
    let v11 : String := ""
    let v12 : String := (← frame_text_loop_5 v0 v8 v9 v10 v11)
    let v13 : Int32 := (Int32.ofNat v12.utf8ByteSize)
    let v14 : Int32 := (0 : Int32)
    let v15 : Int32 := (0 : Int32)
    let v16 : Int32 := (← loop_6 v12 v13 v14 v15)
    let v17 : Int32 := (0 : Int32)
    let v18 : Int32 := (← utf8_scalar_at_byte_offset_7 v12 v17)
    let v19 : Int32 := (160 : Int32)
    let v20 : Int32 := (← utf8_scalar_at_byte_offset_7 v12 v19)
    let v21 : Int32 := (3988 : Int32)
    let v22 : Int32 := (← utf8_scalar_at_byte_offset_7 v12 v21)
    let v23 : Int32 := (4284 : Int32)
    let v24 : Int32 := (← utf8_scalar_at_byte_offset_7 v12 v23)
    let v25 : Int32 := (5212 : Int32)
    let v26 : Int32 := (← utf8_scalar_at_byte_offset_7 v12 v25)
    let v27 : Int32 := (7082 : Int32)
    let v28 : Int32 := (← utf8_scalar_at_byte_offset_7 v12 v27)
    let v29 : Bool := (v1 == (5180 : Int32))
    if v29 then
        v30 := (v2 == (4258 : Int32))
        v31 := v30
    else
        v31 := false
    if v31 then
        v32 := (v3 == (3964 : Int32))
        v33 := v32
    else
        v33 := false
    if v33 then
        v34 := (v4 == (46 : Int32))
        v35 := v34
    else
        v35 := false
    if v35 then
        v36 := (v5 == (35 : Int32))
        v37 := v36
    else
        v37 := false
    if v37 then
        v38 := (v6 == (64 : Int32))
        v39 := v38
    else
        v39 := false
    if v39 then
        v40 := (v7 == (43 : Int32))
        v41 := v40
    else
        v41 := false
    if v41 then
        v42 := (v13 == (7083 : Int32))
        v43 := v42
    else
        v43 := false
    if v43 then
        v44 := (v16 == (324274 : Int32))
        v45 := v44
    else
        v45 := false
    if v45 then
        v46 := (v18 == (46 : Int32))
        v47 := v46
    else
        v47 := false
    if v47 then
        v48 := (v20 == (10 : Int32))
        v49 := v48
    else
        v49 := false
    if v49 then
        v50 := (v22 == (43 : Int32))
        v51 := v50
    else
        v51 := false
    if v51 then
        v52 := (v24 == (64 : Int32))
        v53 := v52
    else
        v53 := false
    if v53 then
        v54 := (v26 == (35 : Int32))
        v55 := v54
    else
        v55 := false
    if v55 then
        v56 := (v28 == (46 : Int32))
        v57 := v56
    else
        v57 := false
    if v57 then
        return (42 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
