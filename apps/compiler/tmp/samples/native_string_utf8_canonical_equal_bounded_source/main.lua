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
local runtime_byte_2, utf8_scalar_at_byte_offset_1, utf8_canonical_equal_bounded_loop_0
function runtime_byte_2(v0, v1)
    local v2 = string.sub(v0, (v1)+1, (v1)+1)
    return v2
end

function utf8_scalar_at_byte_offset_1(v0, v1)
    local v2 = string.len(v0)
    local v3 = v1 < 0
    if v3 then
        return _G.error("UTF-8 byte offset is negative.")
    else
        local v5 = v1 >= v2
        if v5 then
            return _G.error("UTF-8 byte offset is outside the string.")
        else
            local v7 = runtime_byte_2(v0, v1)
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
                            local v16 = runtime_byte_2(v0, v13)
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
                                local v33 = runtime_byte_2(v0, v32)
                                local v34 = string.byte(v33)
                                local v35 = runtime_byte_2(v0, v29)
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
                                    local v68 = runtime_byte_2(v0, v67)
                                    local v69 = string.byte(v68)
                                    local v70 = spiral_wrap_signed((v1 + 2), 32)
                                    local v71 = runtime_byte_2(v0, v70)
                                    local v72 = string.byte(v71)
                                    local v73 = runtime_byte_2(v0, v64)
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

function utf8_canonical_equal_bounded_loop_0(v0, v1, v2, v3, v4, v5, v6, v7)
    local v8 = v4 >= 0
    local getv76 = function()
        if v8 then
            return { [1]=v4, [2]=v2, [3]=-1 }
        else
            local v9 = v2 == v6
            if v9 then
                return { [1]=-1, [2]=v2, [3]=-1 }
            else
                local v10 = v2 > v6
                if v10 then
                    return _G.error("UTF-8 canonical stream offset exceeds the string.")
                else
                    local v14 = utf8_scalar_at_byte_offset_1(v0, v2)
                    local v15 = v14 < 128
                    local getv20 = function()
                        if v15 then
                            return 1
                        else
                            local v16 = v14 < 2048
                            if v16 then
                                return 2
                            else
                                local v17 = v14 < 65536
                                if v17 then
                                    return 3
                                else
                                    return 4
                                end
                            end
                        end
                    end
                    local v20 = getv20()
                    local v21 = v14 == 192
                    local getv67 = function()
                        if v21 then
                            return { [1]=65, [2]=768 }
                        else
                            local v22 = v14 == 193
                            if v22 then
                                return { [1]=65, [2]=769 }
                            else
                                local v23 = v14 == 195
                                if v23 then
                                    return { [1]=65, [2]=771 }
                                else
                                    local v24 = v14 == 196
                                    if v24 then
                                        return { [1]=65, [2]=776 }
                                    else
                                        local v25 = v14 == 199
                                        if v25 then
                                            return { [1]=67, [2]=807 }
                                        else
                                            local v26 = v14 == 201
                                            if v26 then
                                                return { [1]=69, [2]=769 }
                                            else
                                                local v27 = v14 == 211
                                                if v27 then
                                                    return { [1]=79, [2]=769 }
                                                else
                                                    local v28 = v14 == 213
                                                    if v28 then
                                                        return { [1]=79, [2]=771 }
                                                    else
                                                        local v29 = v14 == 224
                                                        if v29 then
                                                            return { [1]=97, [2]=768 }
                                                        else
                                                            local v30 = v14 == 225
                                                            if v30 then
                                                                return { [1]=97, [2]=769 }
                                                            else
                                                                local v31 = v14 == 227
                                                                if v31 then
                                                                    return { [1]=97, [2]=771 }
                                                                else
                                                                    local v32 = v14 == 228
                                                                    if v32 then
                                                                        return { [1]=97, [2]=776 }
                                                                    else
                                                                        local v33 = v14 == 231
                                                                        if v33 then
                                                                            return { [1]=99, [2]=807 }
                                                                        else
                                                                            local v34 = v14 == 233
                                                                            if v34 then
                                                                                return { [1]=101, [2]=769 }
                                                                            else
                                                                                local v35 = v14 == 243
                                                                                if v35 then
                                                                                    return { [1]=111, [2]=769 }
                                                                                else
                                                                                    local v36 = v14 == 245
                                                                                    if v36 then
                                                                                        return { [1]=111, [2]=771 }
                                                                                    else
                                                                                        return { [1]=v14, [2]=-1 }
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
                    local v67, v68 = (table.unpack or unpack)(getv67())
                    local v69 = spiral_wrap_signed((v2 + v20), 32)
                    return { [1]=v67, [2]=v69, [3]=v68 }
                end
            end
        end
    end
    local v76, v77, v78 = (table.unpack or unpack)(getv76())
    local v79 = v5 >= 0
    local getv147 = function()
        if v79 then
            return { [1]=v5, [2]=v3, [3]=-1 }
        else
            local v80 = v3 == v7
            if v80 then
                return { [1]=-1, [2]=v3, [3]=-1 }
            else
                local v81 = v3 > v7
                if v81 then
                    return _G.error("UTF-8 canonical stream offset exceeds the string.")
                else
                    local v85 = utf8_scalar_at_byte_offset_1(v1, v3)
                    local v86 = v85 < 128
                    local getv91 = function()
                        if v86 then
                            return 1
                        else
                            local v87 = v85 < 2048
                            if v87 then
                                return 2
                            else
                                local v88 = v85 < 65536
                                if v88 then
                                    return 3
                                else
                                    return 4
                                end
                            end
                        end
                    end
                    local v91 = getv91()
                    local v92 = v85 == 192
                    local getv138 = function()
                        if v92 then
                            return { [1]=65, [2]=768 }
                        else
                            local v93 = v85 == 193
                            if v93 then
                                return { [1]=65, [2]=769 }
                            else
                                local v94 = v85 == 195
                                if v94 then
                                    return { [1]=65, [2]=771 }
                                else
                                    local v95 = v85 == 196
                                    if v95 then
                                        return { [1]=65, [2]=776 }
                                    else
                                        local v96 = v85 == 199
                                        if v96 then
                                            return { [1]=67, [2]=807 }
                                        else
                                            local v97 = v85 == 201
                                            if v97 then
                                                return { [1]=69, [2]=769 }
                                            else
                                                local v98 = v85 == 211
                                                if v98 then
                                                    return { [1]=79, [2]=769 }
                                                else
                                                    local v99 = v85 == 213
                                                    if v99 then
                                                        return { [1]=79, [2]=771 }
                                                    else
                                                        local v100 = v85 == 224
                                                        if v100 then
                                                            return { [1]=97, [2]=768 }
                                                        else
                                                            local v101 = v85 == 225
                                                            if v101 then
                                                                return { [1]=97, [2]=769 }
                                                            else
                                                                local v102 = v85 == 227
                                                                if v102 then
                                                                    return { [1]=97, [2]=771 }
                                                                else
                                                                    local v103 = v85 == 228
                                                                    if v103 then
                                                                        return { [1]=97, [2]=776 }
                                                                    else
                                                                        local v104 = v85 == 231
                                                                        if v104 then
                                                                            return { [1]=99, [2]=807 }
                                                                        else
                                                                            local v105 = v85 == 233
                                                                            if v105 then
                                                                                return { [1]=101, [2]=769 }
                                                                            else
                                                                                local v106 = v85 == 243
                                                                                if v106 then
                                                                                    return { [1]=111, [2]=769 }
                                                                                else
                                                                                    local v107 = v85 == 245
                                                                                    if v107 then
                                                                                        return { [1]=111, [2]=771 }
                                                                                    else
                                                                                        return { [1]=v85, [2]=-1 }
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
                    local v138, v139 = (table.unpack or unpack)(getv138())
                    local v140 = spiral_wrap_signed((v3 + v91), 32)
                    return { [1]=v138, [2]=v140, [3]=v139 }
                end
            end
        end
    end
    local v147, v148, v149 = (table.unpack or unpack)(getv147())
    local v150 = v76 < 0
    if v150 then
        local v151 = v147 == -1
        return v151
    else
        local v152 = v147 < 0
        if v152 then
            return false
        else
            local v153 = v76 == v147
            if v153 then
                return utf8_canonical_equal_bounded_loop_0(v0, v1, v77, v148, v78, v149, v6, v7)
            else
                return false
            end
        end
    end
end

local v0 = "plain"
local v1 = 0
local v2 = 0
local v3 = -1
local v4 = -1
local v5 = 5
local v6 = 5
local v7 = utf8_canonical_equal_bounded_loop_0(v0, v0, v1, v2, v3, v4, v5, v6)
local v8 = ""
local v9 = 0
local v10 = 0
local v11 = -1
local v12 = -1
local v13 = 0
local v14 = 0
local v15 = utf8_canonical_equal_bounded_loop_0(v8, v8, v9, v10, v11, v12, v13, v14)
local v16 = "éõç"
local v17 = "éõç"
local v18 = 0
local v19 = 0
local v20 = -1
local v21 = -1
local v22 = 6
local v23 = 9
local v24 = utf8_canonical_equal_bounded_loop_0(v16, v17, v18, v19, v20, v21, v22, v23)
local v25 = "é̃"
local v26 = "é̃"
local v27 = 0
local v28 = 0
local v29 = -1
local v30 = -1
local v31 = 4
local v32 = 5
local v33 = utf8_canonical_equal_bounded_loop_0(v25, v26, v27, v28, v29, v30, v31, v32)
local v34 = "À"
local v35 = "À"
local v36 = 0
local v37 = 0
local v38 = -1
local v39 = -1
local v40 = 2
local v41 = 3
local v42 = utf8_canonical_equal_bounded_loop_0(v34, v35, v36, v37, v38, v39, v40, v41)
local v43 = "Ω"
local v44 = 0
local v45 = 0
local v46 = -1
local v47 = -1
local v48 = 2
local v49 = 2
local v50 = utf8_canonical_equal_bounded_loop_0(v43, v43, v44, v45, v46, v47, v48, v49)
local v51 = "ẽ́"
local v52 = 0
local v53 = 0
local v54 = -1
local v55 = -1
local v56 = 5
local v57 = 5
local v58 = utf8_canonical_equal_bounded_loop_0(v26, v51, v52, v53, v54, v55, v56, v57)
local v59 = "é"
local v60 = "á"
local v61 = 0
local v62 = 0
local v63 = -1
local v64 = -1
local v65 = 2
local v66 = 2
local v67 = utf8_canonical_equal_bounded_loop_0(v59, v60, v61, v62, v63, v64, v65, v66)
local v68 = "ω"
local v69 = 0
local v70 = 0
local v71 = -1
local v72 = -1
local v73 = 2
local v74 = 2
local v75 = utf8_canonical_equal_bounded_loop_0(v43, v68, v69, v70, v71, v72, v73, v74)
local v76 = "e"
local v77 = 0
local v78 = 0
local v79 = -1
local v80 = -1
local v81 = 2
local v82 = 1
local v83 = utf8_canonical_equal_bounded_loop_0(v59, v76, v77, v78, v79, v80, v81, v82)
if v7 then
    if v15 then
        if v24 then
            if v33 then
                if v42 then
                    if v50 then
                        if v58 then
                            return 7
                        else
                            if v67 then
                                return 8
                            else
                                if v75 then
                                    return 9
                                else
                                    if v83 then
                                        return 10
                                    else
                                        return 0
                                    end
                                end
                            end
                        end
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
