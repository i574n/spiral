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
local runtime_byte_2, utf8_scalar_at_byte_offset_1, utf8_validate_loop_0
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

function utf8_validate_loop_0(v0, v1, v2, v3)
    local v4 = v1 == v3
    if v4 then
        return v2
    else
        local v5 = v1 > v3
        if v5 then
            return _G.error("UTF-8 scalar width exceeds the string.")
        else
            local v7 = utf8_scalar_at_byte_offset_1(v0, v1)
            local v8 = v7 < 128
            local getv13 = function()
                if v8 then
                    return 1
                else
                    local v9 = v7 < 2048
                    if v9 then
                        return 2
                    else
                        local v10 = v7 < 65536
                        if v10 then
                            return 3
                        else
                            return 4
                        end
                    end
                end
            end
            local v13 = getv13()
            local v14 = spiral_wrap_signed((v1 + v13), 32)
            local v15 = spiral_wrap_signed((v2 + 1), 32)
            return utf8_validate_loop_0(v0, v14, v15, v3)
        end
    end
end

local v0 = "abc"
local v1 = 0
local v2 = 0
local v3 = 3
local v4 = utf8_validate_loop_0(v0, v1, v2, v3)
local v5 = v4 == 3
if v5 then
    return 0
else
    return 1
end
