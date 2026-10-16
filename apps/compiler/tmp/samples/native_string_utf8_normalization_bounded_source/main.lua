local function spiral_wrap_unsigned(value, bits)
    return value % (2 ^ bits)
end
local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local function spiral_mul_mod32(a, b)
    a = a % 4294967296
    b = b % 4294967296
    local a_low = a % 65536
    local a_high = (a - a_low) / 65536
    return (a_low * b + ((a_high * b) % 65536) * 65536) % 4294967296
end
local runtime_byte_1, utf8_scalar_at_byte_offset_0
function runtime_byte_1(v0, v1)
    local v2 = string.sub(v0, (v1)+1, (v1)+1)
    return v2
end

function utf8_scalar_at_byte_offset_0(v0, v1)
    local v2 = string.len(v0)
    local v3 = v1 < 0
    if v3 then
        return _G.error("UTF-8 byte offset is negative.")
    else
        local v5 = v1 >= v2
        if v5 then
            return _G.error("UTF-8 byte offset is outside the string.")
        else
            local v7 = runtime_byte_1(v0, v1)
            local v8 = string.byte(v7)
            local v9 = v8 < 128
            if v9 then
                return v8
            else
                local v10 = v8 < 194
                if v10 then
                    return _G.error("UTF-8 scalar starts with an invalid lead byte.")
                else
                    local v12 = v8 < 224
                    if v12 then
                        local v13 = spiral_wrap_signed((v1 + 1), 32)
                        local v14 = v13 >= v2
                        if v14 then
                            return _G.error("UTF-8 sequence is truncated.")
                        else
                            local v16 = runtime_byte_1(v0, v13)
                            local v17 = string.byte(v16)
                            local v18 = v17 < 128
                            local getv20 = function()
                                if v18 then
                                    return false
                                else
                                    local v19 = v17 < 192
                                    return v19
                                end
                            end
                            local v20 = getv20()
                            if v20 then
                                local v21 = spiral_wrap_signed((v8 - 192), 32)
                                local v22 = spiral_wrap_signed(spiral_mul_mod32(v21, 64), 32)
                                local v23 = spiral_wrap_signed((v17 - 128), 32)
                                local v24 = spiral_wrap_signed((v22 + v23), 32)
                                return v24
                            else
                                return _G.error("UTF-8 sequence has an invalid continuation byte.")
                            end
                        end
                    else
                        local v28 = v8 < 240
                        if v28 then
                            local v29 = spiral_wrap_signed((v1 + 2), 32)
                            local v30 = v29 >= v2
                            if v30 then
                                return _G.error("UTF-8 sequence is truncated.")
                            else
                                local v32 = spiral_wrap_signed((v1 + 1), 32)
                                local v33 = runtime_byte_1(v0, v32)
                                local v34 = string.byte(v33)
                                local v35 = runtime_byte_1(v0, v29)
                                local v36 = string.byte(v35)
                                local v37 = v34 < 128
                                local getv39 = function()
                                    if v37 then
                                        return false
                                    else
                                        local v38 = v34 < 192
                                        return v38
                                    end
                                end
                                local v39 = getv39()
                                if v39 then
                                    local v40 = v36 < 128
                                    local getv42 = function()
                                        if v40 then
                                            return false
                                        else
                                            local v41 = v36 < 192
                                            return v41
                                        end
                                    end
                                    local v42 = getv42()
                                    if v42 then
                                        local v43 = spiral_wrap_signed((v8 - 224), 32)
                                        local v44 = spiral_wrap_signed(spiral_mul_mod32(v43, 4096), 32)
                                        local v45 = spiral_wrap_signed((v34 - 128), 32)
                                        local v46 = spiral_wrap_signed(spiral_mul_mod32(v45, 64), 32)
                                        local v47 = spiral_wrap_signed((v44 + v46), 32)
                                        local v48 = spiral_wrap_signed((v36 - 128), 32)
                                        local v49 = spiral_wrap_signed((v47 + v48), 32)
                                        local v50 = v49 < 2048
                                        if v50 then
                                            return _G.error("UTF-8 sequence is overlong.")
                                        else
                                            local v52 = v49 >= 55296
                                            if v52 then
                                                local v53 = v49 <= 57343
                                                if v53 then
                                                    return _G.error("UTF-8 sequence encodes a surrogate.")
                                                else
                                                    return v49
                                                end
                                            else
                                                return v49
                                            end
                                        end
                                    else
                                        return _G.error("UTF-8 sequence has an invalid continuation byte.")
                                    end
                                else
                                    return _G.error("UTF-8 sequence has an invalid continuation byte.")
                                end
                            end
                        else
                            local v63 = v8 < 245
                            if v63 then
                                local v64 = spiral_wrap_signed((v1 + 3), 32)
                                local v65 = v64 >= v2
                                if v65 then
                                    return _G.error("UTF-8 sequence is truncated.")
                                else
                                    local v67 = spiral_wrap_signed((v1 + 1), 32)
                                    local v68 = runtime_byte_1(v0, v67)
                                    local v69 = string.byte(v68)
                                    local v70 = spiral_wrap_signed((v1 + 2), 32)
                                    local v71 = runtime_byte_1(v0, v70)
                                    local v72 = string.byte(v71)
                                    local v73 = runtime_byte_1(v0, v64)
                                    local v74 = string.byte(v73)
                                    local v75 = v69 < 128
                                    local getv77 = function()
                                        if v75 then
                                            return false
                                        else
                                            local v76 = v69 < 192
                                            return v76
                                        end
                                    end
                                    local v77 = getv77()
                                    if v77 then
                                        local v78 = v72 < 128
                                        local getv80 = function()
                                            if v78 then
                                                return false
                                            else
                                                local v79 = v72 < 192
                                                return v79
                                            end
                                        end
                                        local v80 = getv80()
                                        if v80 then
                                            local v81 = v74 < 128
                                            local getv83 = function()
                                                if v81 then
                                                    return false
                                                else
                                                    local v82 = v74 < 192
                                                    return v82
                                                end
                                            end
                                            local v83 = getv83()
                                            if v83 then
                                                local v84 = spiral_wrap_signed((v8 - 240), 32)
                                                local v85 = spiral_wrap_signed(spiral_mul_mod32(v84, 262144), 32)
                                                local v86 = spiral_wrap_signed((v69 - 128), 32)
                                                local v87 = spiral_wrap_signed(spiral_mul_mod32(v86, 4096), 32)
                                                local v88 = spiral_wrap_signed((v85 + v87), 32)
                                                local v89 = spiral_wrap_signed((v72 - 128), 32)
                                                local v90 = spiral_wrap_signed(spiral_mul_mod32(v89, 64), 32)
                                                local v91 = spiral_wrap_signed((v88 + v90), 32)
                                                local v92 = spiral_wrap_signed((v74 - 128), 32)
                                                local v93 = spiral_wrap_signed((v91 + v92), 32)
                                                local v94 = v93 < 65536
                                                if v94 then
                                                    return _G.error("UTF-8 sequence is overlong.")
                                                else
                                                    local v96 = v93 > 1114111
                                                    if v96 then
                                                        return _G.error("UTF-8 scalar is above U+10FFFF.")
                                                    else
                                                        return v93
                                                    end
                                                end
                                            else
                                                return _G.error("UTF-8 sequence has an invalid continuation byte.")
                                            end
                                        else
                                            return _G.error("UTF-8 sequence has an invalid continuation byte.")
                                        end
                                    else
                                        return _G.error("UTF-8 sequence has an invalid continuation byte.")
                                    end
                                end
                            else
                                return _G.error("UTF-8 scalar starts with an invalid lead byte.")
                            end
                        end
                    end
                end
            end
        end
    end
end

local v0 = "é"
local v1 = 0
local v2 = utf8_scalar_at_byte_offset_0(v0, v1)
local v3 = "õ"
local v4 = 0
local v5 = utf8_scalar_at_byte_offset_0(v3, v4)
local v6 = "ç"
local v7 = 0
local v8 = utf8_scalar_at_byte_offset_0(v6, v7)
local v9 = "́"
local v10 = 0
local v11 = utf8_scalar_at_byte_offset_0(v9, v10)
local v12 = "̃"
local v13 = 0
local v14 = utf8_scalar_at_byte_offset_0(v12, v13)
local v15 = "̧"
local v16 = 0
local v17 = utf8_scalar_at_byte_offset_0(v15, v16)
local v18 = v2 == 192
local getv64 = function()
    if v18 then
        return { [1]=65, [2]=768 }
    else
        local v19 = v2 == 193
        if v19 then
            return { [1]=65, [2]=769 }
        else
            local v20 = v2 == 195
            if v20 then
                return { [1]=65, [2]=771 }
            else
                local v21 = v2 == 196
                if v21 then
                    return { [1]=65, [2]=776 }
                else
                    local v22 = v2 == 199
                    if v22 then
                        return { [1]=67, [2]=807 }
                    else
                        local v23 = v2 == 201
                        if v23 then
                            return { [1]=69, [2]=769 }
                        else
                            local v24 = v2 == 211
                            if v24 then
                                return { [1]=79, [2]=769 }
                            else
                                local v25 = v2 == 213
                                if v25 then
                                    return { [1]=79, [2]=771 }
                                else
                                    local v26 = v2 == 224
                                    if v26 then
                                        return { [1]=97, [2]=768 }
                                    else
                                        local v27 = v2 == 225
                                        if v27 then
                                            return { [1]=97, [2]=769 }
                                        else
                                            local v28 = v2 == 227
                                            if v28 then
                                                return { [1]=97, [2]=771 }
                                            else
                                                local v29 = v2 == 228
                                                if v29 then
                                                    return { [1]=97, [2]=776 }
                                                else
                                                    local v30 = v2 == 231
                                                    if v30 then
                                                        return { [1]=99, [2]=807 }
                                                    else
                                                        local v31 = v2 == 233
                                                        if v31 then
                                                            return { [1]=101, [2]=769 }
                                                        else
                                                            local v32 = v2 == 243
                                                            if v32 then
                                                                return { [1]=111, [2]=769 }
                                                            else
                                                                local v33 = v2 == 245
                                                                if v33 then
                                                                    return { [1]=111, [2]=771 }
                                                                else
                                                                    return { [1]=v2, [2]=-1 }
                                                                end
                                                            end
                                                        end
                                                    end
                                                end
                                            end
                                        end
                                    end
                                end
                            end
                        end
                    end
                end
            end
        end
    end
end
local v64, v65 = (table.unpack or unpack)(getv64())
local v66 = v5 == 192
local getv112 = function()
    if v66 then
        return { [1]=65, [2]=768 }
    else
        local v67 = v5 == 193
        if v67 then
            return { [1]=65, [2]=769 }
        else
            local v68 = v5 == 195
            if v68 then
                return { [1]=65, [2]=771 }
            else
                local v69 = v5 == 196
                if v69 then
                    return { [1]=65, [2]=776 }
                else
                    local v70 = v5 == 199
                    if v70 then
                        return { [1]=67, [2]=807 }
                    else
                        local v71 = v5 == 201
                        if v71 then
                            return { [1]=69, [2]=769 }
                        else
                            local v72 = v5 == 211
                            if v72 then
                                return { [1]=79, [2]=769 }
                            else
                                local v73 = v5 == 213
                                if v73 then
                                    return { [1]=79, [2]=771 }
                                else
                                    local v74 = v5 == 224
                                    if v74 then
                                        return { [1]=97, [2]=768 }
                                    else
                                        local v75 = v5 == 225
                                        if v75 then
                                            return { [1]=97, [2]=769 }
                                        else
                                            local v76 = v5 == 227
                                            if v76 then
                                                return { [1]=97, [2]=771 }
                                            else
                                                local v77 = v5 == 228
                                                if v77 then
                                                    return { [1]=97, [2]=776 }
                                                else
                                                    local v78 = v5 == 231
                                                    if v78 then
                                                        return { [1]=99, [2]=807 }
                                                    else
                                                        local v79 = v5 == 233
                                                        if v79 then
                                                            return { [1]=101, [2]=769 }
                                                        else
                                                            local v80 = v5 == 243
                                                            if v80 then
                                                                return { [1]=111, [2]=769 }
                                                            else
                                                                local v81 = v5 == 245
                                                                if v81 then
                                                                    return { [1]=111, [2]=771 }
                                                                else
                                                                    return { [1]=v5, [2]=-1 }
                                                                end
                                                            end
                                                        end
                                                    end
                                                end
                                            end
                                        end
                                    end
                                end
                            end
                        end
                    end
                end
            end
        end
    end
end
local v112, v113 = (table.unpack or unpack)(getv112())
local v114 = v8 == 192
local getv160 = function()
    if v114 then
        return { [1]=65, [2]=768 }
    else
        local v115 = v8 == 193
        if v115 then
            return { [1]=65, [2]=769 }
        else
            local v116 = v8 == 195
            if v116 then
                return { [1]=65, [2]=771 }
            else
                local v117 = v8 == 196
                if v117 then
                    return { [1]=65, [2]=776 }
                else
                    local v118 = v8 == 199
                    if v118 then
                        return { [1]=67, [2]=807 }
                    else
                        local v119 = v8 == 201
                        if v119 then
                            return { [1]=69, [2]=769 }
                        else
                            local v120 = v8 == 211
                            if v120 then
                                return { [1]=79, [2]=769 }
                            else
                                local v121 = v8 == 213
                                if v121 then
                                    return { [1]=79, [2]=771 }
                                else
                                    local v122 = v8 == 224
                                    if v122 then
                                        return { [1]=97, [2]=768 }
                                    else
                                        local v123 = v8 == 225
                                        if v123 then
                                            return { [1]=97, [2]=769 }
                                        else
                                            local v124 = v8 == 227
                                            if v124 then
                                                return { [1]=97, [2]=771 }
                                            else
                                                local v125 = v8 == 228
                                                if v125 then
                                                    return { [1]=97, [2]=776 }
                                                else
                                                    local v126 = v8 == 231
                                                    if v126 then
                                                        return { [1]=99, [2]=807 }
                                                    else
                                                        local v127 = v8 == 233
                                                        if v127 then
                                                            return { [1]=101, [2]=769 }
                                                        else
                                                            local v128 = v8 == 243
                                                            if v128 then
                                                                return { [1]=111, [2]=769 }
                                                            else
                                                                local v129 = v8 == 245
                                                                if v129 then
                                                                    return { [1]=111, [2]=771 }
                                                                else
                                                                    return { [1]=v8, [2]=-1 }
                                                                end
                                                            end
                                                        end
                                                    end
                                                end
                                            end
                                        end
                                    end
                                end
                            end
                        end
                    end
                end
            end
        end
    end
end
local v160, v161 = (table.unpack or unpack)(getv160())
local v162 = v11 == 769
local getv163 = function()
    if v162 then
        return 233
    else
        return -1
    end
end
local v163 = getv163()
local v164 = v163 < 0
local getv165 = function()
    if v164 then
        return { [1]=101, [2]=v11 }
    else
        return { [1]=v163, [2]=-1 }
    end
end
local v165, v166 = (table.unpack or unpack)(getv165())
local v167 = v14 == 769
local getv170 = function()
    if v167 then
        return 243
    else
        local v168 = v14 == 771
        if v168 then
            return 245
        else
            return -1
        end
    end
end
local v170 = getv170()
local v171 = v170 < 0
local getv172 = function()
    if v171 then
        return { [1]=111, [2]=v14 }
    else
        return { [1]=v170, [2]=-1 }
    end
end
local v172, v173 = (table.unpack or unpack)(getv172())
local v174 = v17 == 807
local getv175 = function()
    if v174 then
        return 231
    else
        return -1
    end
end
local v175 = getv175()
local v176 = v175 < 0
local getv177 = function()
    if v176 then
        return { [1]=99, [2]=v17 }
    else
        return { [1]=v175, [2]=-1 }
    end
end
local v177, v178 = (table.unpack or unpack)(getv177())
local v179 = v64 == 101
local getv181 = function()
    if v179 then
        local v180 = v65 == v11
        return v180
    else
        return false
    end
end
local v181 = getv181()
if v181 then
    local v182 = v112 == 111
    local getv184 = function()
        if v182 then
            local v183 = v113 == v14
            return v183
        else
            return false
        end
    end
    local v184 = getv184()
    if v184 then
        local v185 = v160 == 99
        local getv187 = function()
            if v185 then
                local v186 = v161 == v17
                return v186
            else
                return false
            end
        end
        local v187 = getv187()
        if v187 then
            local v188 = v165 == v2
            local getv190 = function()
                if v188 then
                    local v189 = v166 == -1
                    return v189
                else
                    return false
                end
            end
            local v190 = getv190()
            if v190 then
                local v191 = v172 == v5
                local getv193 = function()
                    if v191 then
                        local v192 = v173 == -1
                        return v192
                    else
                        return false
                    end
                end
                local v193 = getv193()
                if v193 then
                    local v194 = v177 == v8
                    local getv196 = function()
                        if v194 then
                            local v195 = v178 == -1
                            return v195
                        else
                            return false
                        end
                    end
                    local v196 = getv196()
                    if v196 then
                        return 0
                    else
                        return 6
                    end
                else
                    return 5
                end
            else
                return 4
            end
        else
            return 3
        end
    else
        return 2
    end
else
    return 1
end
