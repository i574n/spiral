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
    let mut v19 : Float := default
    let mut v23 : Bool := default
    let mut v24 : Bool := default
    let mut v38 : Float := default
    let mut v42 : Bool := default
    let mut v43 : Bool := default
    let mut v132 : Float := default
    let mut v133 : Float := default
    let mut v134 : Bool := default
    let mut v144 : Float := default
    let mut v135 : Float := default
    let mut v136 : Bool := default
    let mut v137 : Float := default
    let mut v138 : Float := default
    let mut v139 : Float := default
    let mut v140 : Bool := default
    let mut v141 : Float := default
    let mut v172 : Bool := default
    let mut v173 : Bool := default
    let mut v174 : Float := default
    let mut v175 : Float := default
    let mut v176 : Bool := default
    let mut v186 : Float := default
    let mut v177 : Float := default
    let mut v178 : Bool := default
    let mut v179 : Float := default
    let mut v180 : Float := default
    let mut v181 : Float := default
    let mut v182 : Bool := default
    let mut v183 : Float := default
    let mut v187 : Bool := default
    let mut v188 : Bool := default
    let mut v189 : Float := default
    let mut v190 : Float := default
    let mut v191 : Bool := default
    let mut v201 : Float := default
    let mut v192 : Float := default
    let mut v193 : Bool := default
    let mut v194 : Float := default
    let mut v195 : Float := default
    let mut v196 : Float := default
    let mut v197 : Bool := default
    let mut v198 : Float := default
    let mut v202 : Bool := default
    let mut v203 : Bool := default
    let mut v204 : Float := default
    let mut v205 : Float := default
    let mut v206 : Bool := default
    let mut v216 : Float := default
    let mut v207 : Float := default
    let mut v208 : Bool := default
    let mut v209 : Float := default
    let mut v210 : Float := default
    let mut v211 : Float := default
    let mut v212 : Bool := default
    let mut v213 : Float := default
    let mut v217 : Bool := default
    let mut v218 : Bool := default
    let mut v219 : Float := default
    let mut v220 : Float := default
    let mut v221 : Bool := default
    let mut v231 : Float := default
    let mut v222 : Float := default
    let mut v223 : Bool := default
    let mut v224 : Float := default
    let mut v225 : Float := default
    let mut v226 : Float := default
    let mut v227 : Bool := default
    let mut v228 : Float := default
    let mut v232 : Bool := default
    let mut v233 : Bool := default
    let mut v243 : Float := default
    let mut v247 : Float := default
    let mut v248 : Float := default
    let mut v249 : Bool := default
    let mut v250 : Bool := default
    let mut v263 : Float32 := default
    let mut v267 : Bool := default
    let mut v268 : Bool := default
    v0 := (2.7 : Float)
    v1 := (3.2 : Float)
    v2 := (-2.5 : Float)
    v3 := (3.5 : Float)
    v4 := (0.5 : Float)
    v5 := (1.0 : Float)
    v6 := (2.7 : Float32)
    v19 := (v0).floor
    v23 := (v19 == (2.0 : Float))
    v24 := (v23 != true)
    if v24 then
        return (1 : Int32)
    else
        v38 := (v0).ceil
        v42 := (v38 == (3.0 : Float))
        v43 := (v42 != true)
        if v43 then
            return (2 : Int32)
        else
            v132 := (v0).floor
            v133 := (v0 - v132)
            v134 := (decide (v133 > (0.5 : Float)))
            if v134 then
                v135 := (v132 + (1.0 : Float))
                v144 := v135
            else
                v136 := (decide (v133 < (0.5 : Float)))
                if v136 then
                    v144 := v132
                else
                    v137 := (v132 / (2.0 : Float))
                    v138 := (v137).floor
                    v139 := (v138 * (2.0 : Float))
                    v140 := (v139 == v132)
                    if v140 then
                        v144 := v132
                    else
                        v141 := (v132 + (1.0 : Float))
                        v144 := v141
            v172 := (v144 == (3.0 : Float))
            v173 := (v172 != true)
            if v173 then
                return (3 : Int32)
            else
                v174 := (v1).floor
                v175 := (v1 - v174)
                v176 := (decide (v175 > (0.5 : Float)))
                if v176 then
                    v177 := (v174 + (1.0 : Float))
                    v186 := v177
                else
                    v178 := (decide (v175 < (0.5 : Float)))
                    if v178 then
                        v186 := v174
                    else
                        v179 := (v174 / (2.0 : Float))
                        v180 := (v179).floor
                        v181 := (v180 * (2.0 : Float))
                        v182 := (v181 == v174)
                        if v182 then
                            v186 := v174
                        else
                            v183 := (v174 + (1.0 : Float))
                            v186 := v183
                v187 := (v186 == (3.0 : Float))
                v188 := (v187 != true)
                if v188 then
                    return (4 : Int32)
                else
                    v189 := (v2).floor
                    v190 := (v2 - v189)
                    v191 := (decide (v190 > (0.5 : Float)))
                    if v191 then
                        v192 := (v189 + (1.0 : Float))
                        v201 := v192
                    else
                        v193 := (decide (v190 < (0.5 : Float)))
                        if v193 then
                            v201 := v189
                        else
                            v194 := (v189 / (2.0 : Float))
                            v195 := (v194).floor
                            v196 := (v195 * (2.0 : Float))
                            v197 := (v196 == v189)
                            if v197 then
                                v201 := v189
                            else
                                v198 := (v189 + (1.0 : Float))
                                v201 := v198
                    v202 := (v201 == (-2.0 : Float))
                    v203 := (v202 != true)
                    if v203 then
                        return (5 : Int32)
                    else
                        v204 := (v3).floor
                        v205 := (v3 - v204)
                        v206 := (decide (v205 > (0.5 : Float)))
                        if v206 then
                            v207 := (v204 + (1.0 : Float))
                            v216 := v207
                        else
                            v208 := (decide (v205 < (0.5 : Float)))
                            if v208 then
                                v216 := v204
                            else
                                v209 := (v204 / (2.0 : Float))
                                v210 := (v209).floor
                                v211 := (v210 * (2.0 : Float))
                                v212 := (v211 == v204)
                                if v212 then
                                    v216 := v204
                                else
                                    v213 := (v204 + (1.0 : Float))
                                    v216 := v213
                        v217 := (v216 == (4.0 : Float))
                        v218 := (v217 != true)
                        if v218 then
                            return (6 : Int32)
                        else
                            v219 := (v4).floor
                            v220 := (v4 - v219)
                            v221 := (decide (v220 > (0.5 : Float)))
                            if v221 then
                                v222 := (v219 + (1.0 : Float))
                                v231 := v222
                            else
                                v223 := (decide (v220 < (0.5 : Float)))
                                if v223 then
                                    v231 := v219
                                else
                                    v224 := (v219 / (2.0 : Float))
                                    v225 := (v224).floor
                                    v226 := (v225 * (2.0 : Float))
                                    v227 := (v226 == v219)
                                    if v227 then
                                        v231 := v219
                                    else
                                        v228 := (v219 + (1.0 : Float))
                                        v231 := v228
                            v232 := (v231 == (0.0 : Float))
                            v233 := (v232 != true)
                            if v233 then
                                return (7 : Int32)
                            else
                                v243 := Float.atan2 v5 v5 
                                v247 := (v243 * (1000.0 : Float))
                                v248 := (v247).floor
                                v249 := (v248 == (785.0 : Float))
                                v250 := (v249 != true)
                                if v250 then
                                    return (8 : Int32)
                                else
                                    v263 := (v6).floor
                                    v267 := (v263 == (2.0 : Float32))
                                    v268 := (v267 != true)
                                    if v268 then
                                        return (9 : Int32)
                                    else
                                        return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
