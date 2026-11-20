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
partial def runtime_byte_2 (p0 : String) (p1 : Int32) : IO Char := do
    let mut v0 : String := p0
    let mut v1 : Int32 := p1
    let v2 : Char := (Char.ofNat (v0.toUTF8.get! (spiralIdx v1)).toNat)
    return v2
partial def utf8_scalar_at_byte_offset_1 (p0 : String) (p1 : Int32) : IO Int32 := do
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
            v7 := (← runtime_byte_2 v0 v1)
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
                            v16 := (← runtime_byte_2 v0 v13)
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
                                v33 := (← runtime_byte_2 v0 v32)
                                v34 := (Int32.ofNat (v33).toNat)
                                v35 := (← runtime_byte_2 v0 v29)
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
                                    v68 := (← runtime_byte_2 v0 v67)
                                    v69 := (Int32.ofNat (v68).toNat)
                                    v70 := (v1 + (2 : Int32))
                                    v71 := (← runtime_byte_2 v0 v70)
                                    v72 := (Int32.ofNat (v71).toNat)
                                    v73 := (← runtime_byte_2 v0 v64)
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
partial def utf8_canonical_equal_bounded_loop_0 (p0 : String) (p1 : String) (p2 : Int32) (p3 : Int32) (p4 : Int32) (p5 : Int32) (p6 : Int32) (p7 : Int32) : IO Bool := do
    let mut v0 : String := p0
    let mut v1 : String := p1
    let mut v2 : Int32 := p2
    let mut v3 : Int32 := p3
    let mut v4 : Int32 := p4
    let mut v5 : Int32 := p5
    let mut v6 : Int32 := p6
    let mut v7 : Int32 := p7
    let mut v8 : Bool := default
    let mut v76 : Int32 := default
    let mut v77 : Int32 := default
    let mut v78 : Int32 := default
    let mut v9 : Bool := default
    let mut v10 : Bool := default
    let mut v14 : Int32 := default
    let mut v15 : Bool := default
    let mut v20 : Int32 := default
    let mut v16 : Bool := default
    let mut v17 : Bool := default
    let mut v21 : Bool := default
    let mut v67 : Int32 := default
    let mut v68 : Int32 := default
    let mut v22 : Bool := default
    let mut v23 : Bool := default
    let mut v24 : Bool := default
    let mut v25 : Bool := default
    let mut v26 : Bool := default
    let mut v27 : Bool := default
    let mut v28 : Bool := default
    let mut v29 : Bool := default
    let mut v30 : Bool := default
    let mut v31 : Bool := default
    let mut v32 : Bool := default
    let mut v33 : Bool := default
    let mut v34 : Bool := default
    let mut v35 : Bool := default
    let mut v36 : Bool := default
    let mut v69 : Int32 := default
    let mut v79 : Bool := default
    let mut v147 : Int32 := default
    let mut v148 : Int32 := default
    let mut v149 : Int32 := default
    let mut v80 : Bool := default
    let mut v81 : Bool := default
    let mut v85 : Int32 := default
    let mut v86 : Bool := default
    let mut v91 : Int32 := default
    let mut v87 : Bool := default
    let mut v88 : Bool := default
    let mut v92 : Bool := default
    let mut v138 : Int32 := default
    let mut v139 : Int32 := default
    let mut v93 : Bool := default
    let mut v94 : Bool := default
    let mut v95 : Bool := default
    let mut v96 : Bool := default
    let mut v97 : Bool := default
    let mut v98 : Bool := default
    let mut v99 : Bool := default
    let mut v100 : Bool := default
    let mut v101 : Bool := default
    let mut v102 : Bool := default
    let mut v103 : Bool := default
    let mut v104 : Bool := default
    let mut v105 : Bool := default
    let mut v106 : Bool := default
    let mut v107 : Bool := default
    let mut v140 : Int32 := default
    let mut v150 : Bool := default
    let mut v151 : Bool := default
    let mut v152 : Bool := default
    let mut v153 : Bool := default
    repeat
        v8 := (decide (v4 >= (0 : Int32)))
        if v8 then
            v76 := v4
            v77 := v2
            v78 := (-1 : Int32)
        else
            v9 := (v2 == v6)
            if v9 then
                v76 := (-1 : Int32)
                v77 := v2
                v78 := (-1 : Int32)
            else
                v10 := (decide (v2 > v6))
                if v10 then
                    spiralFail "UTF-8 canonical stream offset exceeds the string."
                else
                    v14 := (← utf8_scalar_at_byte_offset_1 v0 v2)
                    v15 := (decide (v14 < (128 : Int32)))
                    if v15 then
                        v20 := (1 : Int32)
                    else
                        v16 := (decide (v14 < (2048 : Int32)))
                        if v16 then
                            v20 := (2 : Int32)
                        else
                            v17 := (decide (v14 < (65536 : Int32)))
                            if v17 then
                                v20 := (3 : Int32)
                            else
                                v20 := (4 : Int32)
                    v21 := (v14 == (192 : Int32))
                    if v21 then
                        v67 := (65 : Int32)
                        v68 := (768 : Int32)
                    else
                        v22 := (v14 == (193 : Int32))
                        if v22 then
                            v67 := (65 : Int32)
                            v68 := (769 : Int32)
                        else
                            v23 := (v14 == (195 : Int32))
                            if v23 then
                                v67 := (65 : Int32)
                                v68 := (771 : Int32)
                            else
                                v24 := (v14 == (196 : Int32))
                                if v24 then
                                    v67 := (65 : Int32)
                                    v68 := (776 : Int32)
                                else
                                    v25 := (v14 == (199 : Int32))
                                    if v25 then
                                        v67 := (67 : Int32)
                                        v68 := (807 : Int32)
                                    else
                                        v26 := (v14 == (201 : Int32))
                                        if v26 then
                                            v67 := (69 : Int32)
                                            v68 := (769 : Int32)
                                        else
                                            v27 := (v14 == (211 : Int32))
                                            if v27 then
                                                v67 := (79 : Int32)
                                                v68 := (769 : Int32)
                                            else
                                                v28 := (v14 == (213 : Int32))
                                                if v28 then
                                                    v67 := (79 : Int32)
                                                    v68 := (771 : Int32)
                                                else
                                                    v29 := (v14 == (224 : Int32))
                                                    if v29 then
                                                        v67 := (97 : Int32)
                                                        v68 := (768 : Int32)
                                                    else
                                                        v30 := (v14 == (225 : Int32))
                                                        if v30 then
                                                            v67 := (97 : Int32)
                                                            v68 := (769 : Int32)
                                                        else
                                                            v31 := (v14 == (227 : Int32))
                                                            if v31 then
                                                                v67 := (97 : Int32)
                                                                v68 := (771 : Int32)
                                                            else
                                                                v32 := (v14 == (228 : Int32))
                                                                if v32 then
                                                                    v67 := (97 : Int32)
                                                                    v68 := (776 : Int32)
                                                                else
                                                                    v33 := (v14 == (231 : Int32))
                                                                    if v33 then
                                                                        v67 := (99 : Int32)
                                                                        v68 := (807 : Int32)
                                                                    else
                                                                        v34 := (v14 == (233 : Int32))
                                                                        if v34 then
                                                                            v67 := (101 : Int32)
                                                                            v68 := (769 : Int32)
                                                                        else
                                                                            v35 := (v14 == (243 : Int32))
                                                                            if v35 then
                                                                                v67 := (111 : Int32)
                                                                                v68 := (769 : Int32)
                                                                            else
                                                                                v36 := (v14 == (245 : Int32))
                                                                                if v36 then
                                                                                    v67 := (111 : Int32)
                                                                                    v68 := (771 : Int32)
                                                                                else
                                                                                    v67 := v14
                                                                                    v68 := (-1 : Int32)
                    v69 := (v2 + v20)
                    v76 := v67
                    v77 := v69
                    v78 := v68
        v79 := (decide (v5 >= (0 : Int32)))
        if v79 then
            v147 := v5
            v148 := v3
            v149 := (-1 : Int32)
        else
            v80 := (v3 == v7)
            if v80 then
                v147 := (-1 : Int32)
                v148 := v3
                v149 := (-1 : Int32)
            else
                v81 := (decide (v3 > v7))
                if v81 then
                    spiralFail "UTF-8 canonical stream offset exceeds the string."
                else
                    v85 := (← utf8_scalar_at_byte_offset_1 v1 v3)
                    v86 := (decide (v85 < (128 : Int32)))
                    if v86 then
                        v91 := (1 : Int32)
                    else
                        v87 := (decide (v85 < (2048 : Int32)))
                        if v87 then
                            v91 := (2 : Int32)
                        else
                            v88 := (decide (v85 < (65536 : Int32)))
                            if v88 then
                                v91 := (3 : Int32)
                            else
                                v91 := (4 : Int32)
                    v92 := (v85 == (192 : Int32))
                    if v92 then
                        v138 := (65 : Int32)
                        v139 := (768 : Int32)
                    else
                        v93 := (v85 == (193 : Int32))
                        if v93 then
                            v138 := (65 : Int32)
                            v139 := (769 : Int32)
                        else
                            v94 := (v85 == (195 : Int32))
                            if v94 then
                                v138 := (65 : Int32)
                                v139 := (771 : Int32)
                            else
                                v95 := (v85 == (196 : Int32))
                                if v95 then
                                    v138 := (65 : Int32)
                                    v139 := (776 : Int32)
                                else
                                    v96 := (v85 == (199 : Int32))
                                    if v96 then
                                        v138 := (67 : Int32)
                                        v139 := (807 : Int32)
                                    else
                                        v97 := (v85 == (201 : Int32))
                                        if v97 then
                                            v138 := (69 : Int32)
                                            v139 := (769 : Int32)
                                        else
                                            v98 := (v85 == (211 : Int32))
                                            if v98 then
                                                v138 := (79 : Int32)
                                                v139 := (769 : Int32)
                                            else
                                                v99 := (v85 == (213 : Int32))
                                                if v99 then
                                                    v138 := (79 : Int32)
                                                    v139 := (771 : Int32)
                                                else
                                                    v100 := (v85 == (224 : Int32))
                                                    if v100 then
                                                        v138 := (97 : Int32)
                                                        v139 := (768 : Int32)
                                                    else
                                                        v101 := (v85 == (225 : Int32))
                                                        if v101 then
                                                            v138 := (97 : Int32)
                                                            v139 := (769 : Int32)
                                                        else
                                                            v102 := (v85 == (227 : Int32))
                                                            if v102 then
                                                                v138 := (97 : Int32)
                                                                v139 := (771 : Int32)
                                                            else
                                                                v103 := (v85 == (228 : Int32))
                                                                if v103 then
                                                                    v138 := (97 : Int32)
                                                                    v139 := (776 : Int32)
                                                                else
                                                                    v104 := (v85 == (231 : Int32))
                                                                    if v104 then
                                                                        v138 := (99 : Int32)
                                                                        v139 := (807 : Int32)
                                                                    else
                                                                        v105 := (v85 == (233 : Int32))
                                                                        if v105 then
                                                                            v138 := (101 : Int32)
                                                                            v139 := (769 : Int32)
                                                                        else
                                                                            v106 := (v85 == (243 : Int32))
                                                                            if v106 then
                                                                                v138 := (111 : Int32)
                                                                                v139 := (769 : Int32)
                                                                            else
                                                                                v107 := (v85 == (245 : Int32))
                                                                                if v107 then
                                                                                    v138 := (111 : Int32)
                                                                                    v139 := (771 : Int32)
                                                                                else
                                                                                    v138 := v85
                                                                                    v139 := (-1 : Int32)
                    v140 := (v3 + v91)
                    v147 := v138
                    v148 := v140
                    v149 := v139
        v150 := (decide (v76 < (0 : Int32)))
        if v150 then
            v151 := (v147 == (-1 : Int32))
            return v151
        else
            v152 := (decide (v147 < (0 : Int32)))
            if v152 then
                return false
            else
                v153 := (v76 == v147)
                if v153 then
                    v2 := v77
                    v3 := v148
                    v4 := v78
                    v5 := v149
                    continue
                else
                    return false
partial def spiralMain : IO Int32 := do
    let v0 : String := "plain"
    let v1 : Int32 := (0 : Int32)
    let v2 : Int32 := (0 : Int32)
    let v3 : Int32 := (-1 : Int32)
    let v4 : Int32 := (-1 : Int32)
    let v5 : Int32 := (5 : Int32)
    let v6 : Int32 := (5 : Int32)
    let v7 : Bool := (← utf8_canonical_equal_bounded_loop_0 v0 v0 v1 v2 v3 v4 v5 v6)
    let v8 : String := ""
    let v9 : Int32 := (0 : Int32)
    let v10 : Int32 := (0 : Int32)
    let v11 : Int32 := (-1 : Int32)
    let v12 : Int32 := (-1 : Int32)
    let v13 : Int32 := (0 : Int32)
    let v14 : Int32 := (0 : Int32)
    let v15 : Bool := (← utf8_canonical_equal_bounded_loop_0 v8 v8 v9 v10 v11 v12 v13 v14)
    let v16 : String := "éõç"
    let v17 : String := "éõç"
    let v18 : Int32 := (0 : Int32)
    let v19 : Int32 := (0 : Int32)
    let v20 : Int32 := (-1 : Int32)
    let v21 : Int32 := (-1 : Int32)
    let v22 : Int32 := (6 : Int32)
    let v23 : Int32 := (9 : Int32)
    let v24 : Bool := (← utf8_canonical_equal_bounded_loop_0 v16 v17 v18 v19 v20 v21 v22 v23)
    let v25 : String := "é̃"
    let v26 : String := "é̃"
    let v27 : Int32 := (0 : Int32)
    let v28 : Int32 := (0 : Int32)
    let v29 : Int32 := (-1 : Int32)
    let v30 : Int32 := (-1 : Int32)
    let v31 : Int32 := (4 : Int32)
    let v32 : Int32 := (5 : Int32)
    let v33 : Bool := (← utf8_canonical_equal_bounded_loop_0 v25 v26 v27 v28 v29 v30 v31 v32)
    let v34 : String := "À"
    let v35 : String := "À"
    let v36 : Int32 := (0 : Int32)
    let v37 : Int32 := (0 : Int32)
    let v38 : Int32 := (-1 : Int32)
    let v39 : Int32 := (-1 : Int32)
    let v40 : Int32 := (2 : Int32)
    let v41 : Int32 := (3 : Int32)
    let v42 : Bool := (← utf8_canonical_equal_bounded_loop_0 v34 v35 v36 v37 v38 v39 v40 v41)
    let v43 : String := "Ω"
    let v44 : Int32 := (0 : Int32)
    let v45 : Int32 := (0 : Int32)
    let v46 : Int32 := (-1 : Int32)
    let v47 : Int32 := (-1 : Int32)
    let v48 : Int32 := (2 : Int32)
    let v49 : Int32 := (2 : Int32)
    let v50 : Bool := (← utf8_canonical_equal_bounded_loop_0 v43 v43 v44 v45 v46 v47 v48 v49)
    let v51 : String := "ẽ́"
    let v52 : Int32 := (0 : Int32)
    let v53 : Int32 := (0 : Int32)
    let v54 : Int32 := (-1 : Int32)
    let v55 : Int32 := (-1 : Int32)
    let v56 : Int32 := (5 : Int32)
    let v57 : Int32 := (5 : Int32)
    let v58 : Bool := (← utf8_canonical_equal_bounded_loop_0 v26 v51 v52 v53 v54 v55 v56 v57)
    let v59 : String := "é"
    let v60 : String := "á"
    let v61 : Int32 := (0 : Int32)
    let v62 : Int32 := (0 : Int32)
    let v63 : Int32 := (-1 : Int32)
    let v64 : Int32 := (-1 : Int32)
    let v65 : Int32 := (2 : Int32)
    let v66 : Int32 := (2 : Int32)
    let v67 : Bool := (← utf8_canonical_equal_bounded_loop_0 v59 v60 v61 v62 v63 v64 v65 v66)
    let v68 : String := "ω"
    let v69 : Int32 := (0 : Int32)
    let v70 : Int32 := (0 : Int32)
    let v71 : Int32 := (-1 : Int32)
    let v72 : Int32 := (-1 : Int32)
    let v73 : Int32 := (2 : Int32)
    let v74 : Int32 := (2 : Int32)
    let v75 : Bool := (← utf8_canonical_equal_bounded_loop_0 v43 v68 v69 v70 v71 v72 v73 v74)
    let v76 : String := "e"
    let v77 : Int32 := (0 : Int32)
    let v78 : Int32 := (0 : Int32)
    let v79 : Int32 := (-1 : Int32)
    let v80 : Int32 := (-1 : Int32)
    let v81 : Int32 := (2 : Int32)
    let v82 : Int32 := (1 : Int32)
    let v83 : Bool := (← utf8_canonical_equal_bounded_loop_0 v59 v76 v77 v78 v79 v80 v81 v82)
    if v7 then
        if v15 then
            if v24 then
                if v33 then
                    if v42 then
                        if v50 then
                            if v58 then
                                return (7 : Int32)
                            else
                                if v67 then
                                    return (8 : Int32)
                                else
                                    if v75 then
                                        return (9 : Int32)
                                    else
                                        if v83 then
                                            return (10 : Int32)
                                        else
                                            return (0 : Int32)
                        else
                            return (6 : Int32)
                    else
                        return (5 : Int32)
                else
                    return (4 : Int32)
            else
                return (3 : Int32)
        else
            return (2 : Int32)
    else
        return (1 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
