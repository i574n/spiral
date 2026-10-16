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
partial def runtime_byte_1 (p0 : String) (p1 : Int32) : IO Char := do
    let mut v0 : String := p0
    let mut v1 : Int32 := p1
    let mut v2 : Char := default
    v2 := (Char.ofNat (v0.toUTF8.get! (spiralIdx v1)).toNat)
    return v2
partial def utf8_scalar_at_byte_offset_0 (p0 : String) (p1 : Int32) : IO Int32 := do
    let mut v0 : String := p0
    let mut v1 : Int32 := p1
    let mut v2 : Int32 := default
    let mut v3 : Bool := default
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
    v2 := (Int32.ofNat v0.utf8ByteSize)
    v3 := (decide (v1 < (0 : Int32)))
    if v3 then
        spiralFail "UTF-8 byte offset is negative."
    else
        v5 := (decide (v1 >= v2))
        if v5 then
            spiralFail "UTF-8 byte offset is outside the string."
        else
            v7 := (← runtime_byte_1 v0 v1)
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
                            v16 := (← runtime_byte_1 v0 v13)
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
                                v33 := (← runtime_byte_1 v0 v32)
                                v34 := (Int32.ofNat (v33).toNat)
                                v35 := (← runtime_byte_1 v0 v29)
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
                                    v68 := (← runtime_byte_1 v0 v67)
                                    v69 := (Int32.ofNat (v68).toNat)
                                    v70 := (v1 + (2 : Int32))
                                    v71 := (← runtime_byte_1 v0 v70)
                                    v72 := (Int32.ofNat (v71).toNat)
                                    v73 := (← runtime_byte_1 v0 v64)
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
partial def spiralMain : IO Int32 := do
    let mut v0 : String := default
    let mut v1 : Int32 := default
    let mut v2 : Int32 := default
    let mut v3 : String := default
    let mut v4 : Int32 := default
    let mut v5 : Int32 := default
    let mut v6 : String := default
    let mut v7 : Int32 := default
    let mut v8 : Int32 := default
    let mut v9 : String := default
    let mut v10 : Int32 := default
    let mut v11 : Int32 := default
    let mut v12 : String := default
    let mut v13 : Int32 := default
    let mut v14 : Int32 := default
    let mut v15 : String := default
    let mut v16 : Int32 := default
    let mut v17 : Int32 := default
    let mut v18 : Bool := default
    let mut v64 : Int32 := default
    let mut v65 : Int32 := default
    let mut v19 : Bool := default
    let mut v20 : Bool := default
    let mut v21 : Bool := default
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
    let mut v66 : Bool := default
    let mut v112 : Int32 := default
    let mut v113 : Int32 := default
    let mut v67 : Bool := default
    let mut v68 : Bool := default
    let mut v69 : Bool := default
    let mut v70 : Bool := default
    let mut v71 : Bool := default
    let mut v72 : Bool := default
    let mut v73 : Bool := default
    let mut v74 : Bool := default
    let mut v75 : Bool := default
    let mut v76 : Bool := default
    let mut v77 : Bool := default
    let mut v78 : Bool := default
    let mut v79 : Bool := default
    let mut v80 : Bool := default
    let mut v81 : Bool := default
    let mut v114 : Bool := default
    let mut v160 : Int32 := default
    let mut v161 : Int32 := default
    let mut v115 : Bool := default
    let mut v116 : Bool := default
    let mut v117 : Bool := default
    let mut v118 : Bool := default
    let mut v119 : Bool := default
    let mut v120 : Bool := default
    let mut v121 : Bool := default
    let mut v122 : Bool := default
    let mut v123 : Bool := default
    let mut v124 : Bool := default
    let mut v125 : Bool := default
    let mut v126 : Bool := default
    let mut v127 : Bool := default
    let mut v128 : Bool := default
    let mut v129 : Bool := default
    let mut v162 : Bool := default
    let mut v163 : Int32 := default
    let mut v164 : Bool := default
    let mut v165 : Int32 := default
    let mut v166 : Int32 := default
    let mut v167 : Bool := default
    let mut v170 : Int32 := default
    let mut v168 : Bool := default
    let mut v171 : Bool := default
    let mut v172 : Int32 := default
    let mut v173 : Int32 := default
    let mut v174 : Bool := default
    let mut v175 : Int32 := default
    let mut v176 : Bool := default
    let mut v177 : Int32 := default
    let mut v178 : Int32 := default
    let mut v179 : Bool := default
    let mut v181 : Bool := default
    let mut v180 : Bool := default
    let mut v182 : Bool := default
    let mut v184 : Bool := default
    let mut v183 : Bool := default
    let mut v185 : Bool := default
    let mut v187 : Bool := default
    let mut v186 : Bool := default
    let mut v188 : Bool := default
    let mut v190 : Bool := default
    let mut v189 : Bool := default
    let mut v191 : Bool := default
    let mut v193 : Bool := default
    let mut v192 : Bool := default
    let mut v194 : Bool := default
    let mut v196 : Bool := default
    let mut v195 : Bool := default
    v0 := "é"
    v1 := (0 : Int32)
    v2 := (← utf8_scalar_at_byte_offset_0 v0 v1)
    v3 := "õ"
    v4 := (0 : Int32)
    v5 := (← utf8_scalar_at_byte_offset_0 v3 v4)
    v6 := "ç"
    v7 := (0 : Int32)
    v8 := (← utf8_scalar_at_byte_offset_0 v6 v7)
    v9 := "́"
    v10 := (0 : Int32)
    v11 := (← utf8_scalar_at_byte_offset_0 v9 v10)
    v12 := "̃"
    v13 := (0 : Int32)
    v14 := (← utf8_scalar_at_byte_offset_0 v12 v13)
    v15 := "̧"
    v16 := (0 : Int32)
    v17 := (← utf8_scalar_at_byte_offset_0 v15 v16)
    v18 := (v2 == (192 : Int32))
    if v18 then
        v64 := (65 : Int32)
        v65 := (768 : Int32)
    else
        v19 := (v2 == (193 : Int32))
        if v19 then
            v64 := (65 : Int32)
            v65 := (769 : Int32)
        else
            v20 := (v2 == (195 : Int32))
            if v20 then
                v64 := (65 : Int32)
                v65 := (771 : Int32)
            else
                v21 := (v2 == (196 : Int32))
                if v21 then
                    v64 := (65 : Int32)
                    v65 := (776 : Int32)
                else
                    v22 := (v2 == (199 : Int32))
                    if v22 then
                        v64 := (67 : Int32)
                        v65 := (807 : Int32)
                    else
                        v23 := (v2 == (201 : Int32))
                        if v23 then
                            v64 := (69 : Int32)
                            v65 := (769 : Int32)
                        else
                            v24 := (v2 == (211 : Int32))
                            if v24 then
                                v64 := (79 : Int32)
                                v65 := (769 : Int32)
                            else
                                v25 := (v2 == (213 : Int32))
                                if v25 then
                                    v64 := (79 : Int32)
                                    v65 := (771 : Int32)
                                else
                                    v26 := (v2 == (224 : Int32))
                                    if v26 then
                                        v64 := (97 : Int32)
                                        v65 := (768 : Int32)
                                    else
                                        v27 := (v2 == (225 : Int32))
                                        if v27 then
                                            v64 := (97 : Int32)
                                            v65 := (769 : Int32)
                                        else
                                            v28 := (v2 == (227 : Int32))
                                            if v28 then
                                                v64 := (97 : Int32)
                                                v65 := (771 : Int32)
                                            else
                                                v29 := (v2 == (228 : Int32))
                                                if v29 then
                                                    v64 := (97 : Int32)
                                                    v65 := (776 : Int32)
                                                else
                                                    v30 := (v2 == (231 : Int32))
                                                    if v30 then
                                                        v64 := (99 : Int32)
                                                        v65 := (807 : Int32)
                                                    else
                                                        v31 := (v2 == (233 : Int32))
                                                        if v31 then
                                                            v64 := (101 : Int32)
                                                            v65 := (769 : Int32)
                                                        else
                                                            v32 := (v2 == (243 : Int32))
                                                            if v32 then
                                                                v64 := (111 : Int32)
                                                                v65 := (769 : Int32)
                                                            else
                                                                v33 := (v2 == (245 : Int32))
                                                                if v33 then
                                                                    v64 := (111 : Int32)
                                                                    v65 := (771 : Int32)
                                                                else
                                                                    v64 := v2
                                                                    v65 := (-1 : Int32)
    v66 := (v5 == (192 : Int32))
    if v66 then
        v112 := (65 : Int32)
        v113 := (768 : Int32)
    else
        v67 := (v5 == (193 : Int32))
        if v67 then
            v112 := (65 : Int32)
            v113 := (769 : Int32)
        else
            v68 := (v5 == (195 : Int32))
            if v68 then
                v112 := (65 : Int32)
                v113 := (771 : Int32)
            else
                v69 := (v5 == (196 : Int32))
                if v69 then
                    v112 := (65 : Int32)
                    v113 := (776 : Int32)
                else
                    v70 := (v5 == (199 : Int32))
                    if v70 then
                        v112 := (67 : Int32)
                        v113 := (807 : Int32)
                    else
                        v71 := (v5 == (201 : Int32))
                        if v71 then
                            v112 := (69 : Int32)
                            v113 := (769 : Int32)
                        else
                            v72 := (v5 == (211 : Int32))
                            if v72 then
                                v112 := (79 : Int32)
                                v113 := (769 : Int32)
                            else
                                v73 := (v5 == (213 : Int32))
                                if v73 then
                                    v112 := (79 : Int32)
                                    v113 := (771 : Int32)
                                else
                                    v74 := (v5 == (224 : Int32))
                                    if v74 then
                                        v112 := (97 : Int32)
                                        v113 := (768 : Int32)
                                    else
                                        v75 := (v5 == (225 : Int32))
                                        if v75 then
                                            v112 := (97 : Int32)
                                            v113 := (769 : Int32)
                                        else
                                            v76 := (v5 == (227 : Int32))
                                            if v76 then
                                                v112 := (97 : Int32)
                                                v113 := (771 : Int32)
                                            else
                                                v77 := (v5 == (228 : Int32))
                                                if v77 then
                                                    v112 := (97 : Int32)
                                                    v113 := (776 : Int32)
                                                else
                                                    v78 := (v5 == (231 : Int32))
                                                    if v78 then
                                                        v112 := (99 : Int32)
                                                        v113 := (807 : Int32)
                                                    else
                                                        v79 := (v5 == (233 : Int32))
                                                        if v79 then
                                                            v112 := (101 : Int32)
                                                            v113 := (769 : Int32)
                                                        else
                                                            v80 := (v5 == (243 : Int32))
                                                            if v80 then
                                                                v112 := (111 : Int32)
                                                                v113 := (769 : Int32)
                                                            else
                                                                v81 := (v5 == (245 : Int32))
                                                                if v81 then
                                                                    v112 := (111 : Int32)
                                                                    v113 := (771 : Int32)
                                                                else
                                                                    v112 := v5
                                                                    v113 := (-1 : Int32)
    v114 := (v8 == (192 : Int32))
    if v114 then
        v160 := (65 : Int32)
        v161 := (768 : Int32)
    else
        v115 := (v8 == (193 : Int32))
        if v115 then
            v160 := (65 : Int32)
            v161 := (769 : Int32)
        else
            v116 := (v8 == (195 : Int32))
            if v116 then
                v160 := (65 : Int32)
                v161 := (771 : Int32)
            else
                v117 := (v8 == (196 : Int32))
                if v117 then
                    v160 := (65 : Int32)
                    v161 := (776 : Int32)
                else
                    v118 := (v8 == (199 : Int32))
                    if v118 then
                        v160 := (67 : Int32)
                        v161 := (807 : Int32)
                    else
                        v119 := (v8 == (201 : Int32))
                        if v119 then
                            v160 := (69 : Int32)
                            v161 := (769 : Int32)
                        else
                            v120 := (v8 == (211 : Int32))
                            if v120 then
                                v160 := (79 : Int32)
                                v161 := (769 : Int32)
                            else
                                v121 := (v8 == (213 : Int32))
                                if v121 then
                                    v160 := (79 : Int32)
                                    v161 := (771 : Int32)
                                else
                                    v122 := (v8 == (224 : Int32))
                                    if v122 then
                                        v160 := (97 : Int32)
                                        v161 := (768 : Int32)
                                    else
                                        v123 := (v8 == (225 : Int32))
                                        if v123 then
                                            v160 := (97 : Int32)
                                            v161 := (769 : Int32)
                                        else
                                            v124 := (v8 == (227 : Int32))
                                            if v124 then
                                                v160 := (97 : Int32)
                                                v161 := (771 : Int32)
                                            else
                                                v125 := (v8 == (228 : Int32))
                                                if v125 then
                                                    v160 := (97 : Int32)
                                                    v161 := (776 : Int32)
                                                else
                                                    v126 := (v8 == (231 : Int32))
                                                    if v126 then
                                                        v160 := (99 : Int32)
                                                        v161 := (807 : Int32)
                                                    else
                                                        v127 := (v8 == (233 : Int32))
                                                        if v127 then
                                                            v160 := (101 : Int32)
                                                            v161 := (769 : Int32)
                                                        else
                                                            v128 := (v8 == (243 : Int32))
                                                            if v128 then
                                                                v160 := (111 : Int32)
                                                                v161 := (769 : Int32)
                                                            else
                                                                v129 := (v8 == (245 : Int32))
                                                                if v129 then
                                                                    v160 := (111 : Int32)
                                                                    v161 := (771 : Int32)
                                                                else
                                                                    v160 := v8
                                                                    v161 := (-1 : Int32)
    v162 := (v11 == (769 : Int32))
    if v162 then
        v163 := (233 : Int32)
    else
        v163 := (-1 : Int32)
    v164 := (decide (v163 < (0 : Int32)))
    if v164 then
        v165 := (101 : Int32)
        v166 := v11
    else
        v165 := v163
        v166 := (-1 : Int32)
    v167 := (v14 == (769 : Int32))
    if v167 then
        v170 := (243 : Int32)
    else
        v168 := (v14 == (771 : Int32))
        if v168 then
            v170 := (245 : Int32)
        else
            v170 := (-1 : Int32)
    v171 := (decide (v170 < (0 : Int32)))
    if v171 then
        v172 := (111 : Int32)
        v173 := v14
    else
        v172 := v170
        v173 := (-1 : Int32)
    v174 := (v17 == (807 : Int32))
    if v174 then
        v175 := (231 : Int32)
    else
        v175 := (-1 : Int32)
    v176 := (decide (v175 < (0 : Int32)))
    if v176 then
        v177 := (99 : Int32)
        v178 := v17
    else
        v177 := v175
        v178 := (-1 : Int32)
    v179 := (v64 == (101 : Int32))
    if v179 then
        v180 := (v65 == v11)
        v181 := v180
    else
        v181 := false
    if v181 then
        v182 := (v112 == (111 : Int32))
        if v182 then
            v183 := (v113 == v14)
            v184 := v183
        else
            v184 := false
        if v184 then
            v185 := (v160 == (99 : Int32))
            if v185 then
                v186 := (v161 == v17)
                v187 := v186
            else
                v187 := false
            if v187 then
                v188 := (v165 == v2)
                if v188 then
                    v189 := (v166 == (-1 : Int32))
                    v190 := v189
                else
                    v190 := false
                if v190 then
                    v191 := (v172 == v5)
                    if v191 then
                        v192 := (v173 == (-1 : Int32))
                        v193 := v192
                    else
                        v193 := false
                    if v193 then
                        v194 := (v177 == v8)
                        if v194 then
                            v195 := (v178 == (-1 : Int32))
                            v196 := v195
                        else
                            v196 := false
                        if v196 then
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
