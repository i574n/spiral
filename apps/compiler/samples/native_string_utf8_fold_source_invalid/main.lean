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
partial def loop_0 (p0 : Int32) (p1 : Int32) : IO Int32 := do
    let mut v0 : Int32 := p0
    let mut v1 : Int32 := p1
    let mut v2 : Bool := default
    let mut v3 : Bool := default
    let mut v5 : String := default
    let mut v6 : Int32 := default
    let mut v7 : Bool := default
    let mut v12 : Int32 := default
    let mut v8 : Bool := default
    let mut v9 : Bool := default
    let mut v13 : Int32 := default
    let mut v14 : Int32 := default
    repeat
        v2 := (v0 == (2 : Int32))
        if v2 then
            return v1
        else
            v3 := (decide (v0 > (2 : Int32)))
            if v3 then
                spiralFail "UTF-8 scalar width exceeds the string."
            else
                v5 := "é"
                v6 := (← utf8_scalar_at_byte_offset_1 v5 v0)
                v7 := (decide (v6 < (128 : Int32)))
                if v7 then
                    v12 := (1 : Int32)
                else
                    v8 := (decide (v6 < (2048 : Int32)))
                    if v8 then
                        v12 := (2 : Int32)
                    else
                        v9 := (decide (v6 < (65536 : Int32)))
                        if v9 then
                            v12 := (3 : Int32)
                        else
                            v12 := (4 : Int32)
                v13 := (v0 + v12)
                v14 := (v1 + v6)
                v0 := v13
                v1 := v14
                continue
partial def spiralMain : IO Int32 := do
    let v0 : Int32 := (1 : Int32)
    let v1 : Int32 := (0 : Int32)
    return (← loop_0 v0 v1)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
