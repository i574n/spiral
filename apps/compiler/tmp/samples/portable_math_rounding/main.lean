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
    let mut v22 : Bool := default
    let mut v23 : Bool := default
    let mut v37 : Float := default
    let mut v40 : Bool := default
    let mut v41 : Bool := default
    let mut v130 : Float := default
    let mut v131 : Float := default
    let mut v132 : Bool := default
    let mut v142 : Float := default
    let mut v133 : Float := default
    let mut v134 : Bool := default
    let mut v135 : Float := default
    let mut v136 : Float := default
    let mut v137 : Float := default
    let mut v138 : Bool := default
    let mut v139 : Float := default
    let mut v169 : Bool := default
    let mut v170 : Bool := default
    let mut v171 : Float := default
    let mut v172 : Float := default
    let mut v173 : Bool := default
    let mut v183 : Float := default
    let mut v174 : Float := default
    let mut v175 : Bool := default
    let mut v176 : Float := default
    let mut v177 : Float := default
    let mut v178 : Float := default
    let mut v179 : Bool := default
    let mut v180 : Float := default
    let mut v184 : Bool := default
    let mut v185 : Bool := default
    let mut v186 : Float := default
    let mut v187 : Float := default
    let mut v188 : Bool := default
    let mut v198 : Float := default
    let mut v189 : Float := default
    let mut v190 : Bool := default
    let mut v191 : Float := default
    let mut v192 : Float := default
    let mut v193 : Float := default
    let mut v194 : Bool := default
    let mut v195 : Float := default
    let mut v199 : Bool := default
    let mut v200 : Bool := default
    let mut v201 : Float := default
    let mut v202 : Float := default
    let mut v203 : Bool := default
    let mut v213 : Float := default
    let mut v204 : Float := default
    let mut v205 : Bool := default
    let mut v206 : Float := default
    let mut v207 : Float := default
    let mut v208 : Float := default
    let mut v209 : Bool := default
    let mut v210 : Float := default
    let mut v214 : Bool := default
    let mut v215 : Bool := default
    let mut v216 : Float := default
    let mut v217 : Float := default
    let mut v218 : Bool := default
    let mut v228 : Float := default
    let mut v219 : Float := default
    let mut v220 : Bool := default
    let mut v221 : Float := default
    let mut v222 : Float := default
    let mut v223 : Float := default
    let mut v224 : Bool := default
    let mut v225 : Float := default
    let mut v229 : Bool := default
    let mut v230 : Bool := default
    let mut v240 : Float := default
    let mut v243 : Float := default
    let mut v244 : Float := default
    let mut v245 : Bool := default
    let mut v246 : Bool := default
    let mut v259 : Float32 := default
    let mut v262 : Bool := default
    let mut v263 : Bool := default
    v0 := (2.7 : Float)
    v1 := (3.2 : Float)
    v2 := (-2.5 : Float)
    v3 := (3.5 : Float)
    v4 := (0.5 : Float)
    v5 := (1.0 : Float)
    v6 := (2.7 : Float32)
    v19 := (v0).floor
    v22 := (v19 == (2.0 : Float))
    v23 := (v22 != true)
    if v23 then
        return (1 : Int32)
    else
        v37 := (v0).ceil
        v40 := (v37 == (3.0 : Float))
        v41 := (v40 != true)
        if v41 then
            return (2 : Int32)
        else
            v130 := (v0).floor
            v131 := (v0 - v130)
            v132 := (decide (v131 > (0.5 : Float)))
            if v132 then
                v133 := (v130 + (1.0 : Float))
                v142 := v133
            else
                v134 := (decide (v131 < (0.5 : Float)))
                if v134 then
                    v142 := v130
                else
                    v135 := (v130 / (2.0 : Float))
                    v136 := (v135).floor
                    v137 := (v136 * (2.0 : Float))
                    v138 := (v137 == v130)
                    if v138 then
                        v142 := v130
                    else
                        v139 := (v130 + (1.0 : Float))
                        v142 := v139
            v169 := (v142 == (3.0 : Float))
            v170 := (v169 != true)
            if v170 then
                return (3 : Int32)
            else
                v171 := (v1).floor
                v172 := (v1 - v171)
                v173 := (decide (v172 > (0.5 : Float)))
                if v173 then
                    v174 := (v171 + (1.0 : Float))
                    v183 := v174
                else
                    v175 := (decide (v172 < (0.5 : Float)))
                    if v175 then
                        v183 := v171
                    else
                        v176 := (v171 / (2.0 : Float))
                        v177 := (v176).floor
                        v178 := (v177 * (2.0 : Float))
                        v179 := (v178 == v171)
                        if v179 then
                            v183 := v171
                        else
                            v180 := (v171 + (1.0 : Float))
                            v183 := v180
                v184 := (v183 == (3.0 : Float))
                v185 := (v184 != true)
                if v185 then
                    return (4 : Int32)
                else
                    v186 := (v2).floor
                    v187 := (v2 - v186)
                    v188 := (decide (v187 > (0.5 : Float)))
                    if v188 then
                        v189 := (v186 + (1.0 : Float))
                        v198 := v189
                    else
                        v190 := (decide (v187 < (0.5 : Float)))
                        if v190 then
                            v198 := v186
                        else
                            v191 := (v186 / (2.0 : Float))
                            v192 := (v191).floor
                            v193 := (v192 * (2.0 : Float))
                            v194 := (v193 == v186)
                            if v194 then
                                v198 := v186
                            else
                                v195 := (v186 + (1.0 : Float))
                                v198 := v195
                    v199 := (v198 == (-2.0 : Float))
                    v200 := (v199 != true)
                    if v200 then
                        return (5 : Int32)
                    else
                        v201 := (v3).floor
                        v202 := (v3 - v201)
                        v203 := (decide (v202 > (0.5 : Float)))
                        if v203 then
                            v204 := (v201 + (1.0 : Float))
                            v213 := v204
                        else
                            v205 := (decide (v202 < (0.5 : Float)))
                            if v205 then
                                v213 := v201
                            else
                                v206 := (v201 / (2.0 : Float))
                                v207 := (v206).floor
                                v208 := (v207 * (2.0 : Float))
                                v209 := (v208 == v201)
                                if v209 then
                                    v213 := v201
                                else
                                    v210 := (v201 + (1.0 : Float))
                                    v213 := v210
                        v214 := (v213 == (4.0 : Float))
                        v215 := (v214 != true)
                        if v215 then
                            return (6 : Int32)
                        else
                            v216 := (v4).floor
                            v217 := (v4 - v216)
                            v218 := (decide (v217 > (0.5 : Float)))
                            if v218 then
                                v219 := (v216 + (1.0 : Float))
                                v228 := v219
                            else
                                v220 := (decide (v217 < (0.5 : Float)))
                                if v220 then
                                    v228 := v216
                                else
                                    v221 := (v216 / (2.0 : Float))
                                    v222 := (v221).floor
                                    v223 := (v222 * (2.0 : Float))
                                    v224 := (v223 == v216)
                                    if v224 then
                                        v228 := v216
                                    else
                                        v225 := (v216 + (1.0 : Float))
                                        v228 := v225
                            v229 := (v228 == (0.0 : Float))
                            v230 := (v229 != true)
                            if v230 then
                                return (7 : Int32)
                            else
                                v240 := Float.atan2 v5 v5 
                                v243 := (v240 * (1000.0 : Float))
                                v244 := (v243).floor
                                v245 := (v244 == (785.0 : Float))
                                v246 := (v245 != true)
                                if v246 then
                                    return (8 : Int32)
                                else
                                    v259 := (v6).floor
                                    v262 := (v259 == (2.0 : Float32))
                                    v263 := (v262 != true)
                                    if v263 then
                                        return (9 : Int32)
                                    else
                                        return (0 : Int32)
end
def main : IO UInt32 := do
  let code ← spiralMain
  return code.toUInt32
