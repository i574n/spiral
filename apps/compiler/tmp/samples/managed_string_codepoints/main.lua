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
local runtime_byte_0, codepoint_length_loop_1, codepoint_byte_offset_loop_2
function runtime_byte_0(v0, v1)
    local v2 = string.sub(v0, (v1)+1, (v1)+1)
    return v2
end

function codepoint_length_loop_1(v0, v1, v2, v3, v4, v5)
    local v6 = v3 == v5
    if v6 then
        return v4
    else
        local v7 = string.sub(v0, (v3)+1, (v3)+1)
        local v8 = v7 < v1
        local getv10 = function()
            if v8 then
                return false
            else
                local v9 = v7 < v2
                return v9
            end
        end
        local v10 = getv10()
        local getv12 = function()
            if v10 then
                return v4
            else
                local v11 = spiral_wrap_signed((v4 + 1), 32)
                return v11
            end
        end
        local v12 = getv12()
        local v13 = spiral_wrap_signed((v3 + 1), 32)
        return codepoint_length_loop_1(v0, v1, v2, v13, v12, v5)
    end
end

function codepoint_byte_offset_loop_2(v0, v1, v2, v3, v4, v5, v6)
    local v7 = v4 == v6
    if v7 then
        return v6
    else
        local v8 = string.sub(v0, (v4)+1, (v4)+1)
        local v9 = v8 < v1
        local getv11 = function()
            if v9 then
                return false
            else
                local v10 = v8 < v2
                return v10
            end
        end
        local v11 = getv11()
        if v11 then
            local v12 = spiral_wrap_signed((v4 + 1), 32)
            return codepoint_byte_offset_loop_2(v0, v1, v2, v3, v12, v5, v6)
        else
            local v14 = v5 == v3
            if v14 then
                return v4
            else
                local v15 = spiral_wrap_signed((v4 + 1), 32)
                local v16 = spiral_wrap_signed((v5 + 1), 32)
                return codepoint_byte_offset_loop_2(v0, v1, v2, v3, v15, v16, v6)
            end
        end
    end
end

local v0 = "À"
local v1 = 1
local v2 = runtime_byte_0(v0, v1)
local v3 = "©"
local v4 = 0
local v5 = runtime_byte_0(v3, v4)
local v6 = "Aéλ🙂Z"
local v7 = 0
local v8 = 0
local v9 = 10
local v10 = codepoint_length_loop_1(v6, v2, v5, v7, v8, v9)
local v11 = 1
local v12 = runtime_byte_0(v0, v11)
local v13 = 0
local v14 = runtime_byte_0(v3, v13)
local v15 = 1
local v16 = 0
local v17 = 0
local v18 = 10
local v19 = codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18)
local v20 = 1
local v21 = runtime_byte_0(v0, v20)
local v22 = 0
local v23 = runtime_byte_0(v3, v22)
local v24 = 2
local v25 = 0
local v26 = 0
local v27 = 10
local v28 = codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27)
local v29 = spiral_wrap_signed((v28 - 1), 32)
local v30 = string.sub("Aéλ🙂Z", (v19)+1, (v29)+1)
local v31 = 1
local v32 = runtime_byte_0(v0, v31)
local v33 = 0
local v34 = runtime_byte_0(v3, v33)
local v35 = 3
local v36 = 0
local v37 = 0
local v38 = 10
local v39 = codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38)
local v40 = 1
local v41 = runtime_byte_0(v0, v40)
local v42 = 0
local v43 = runtime_byte_0(v3, v42)
local v44 = 4
local v45 = 0
local v46 = 0
local v47 = 10
local v48 = codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47)
local v49 = spiral_wrap_signed((v48 - 1), 32)
local v50 = string.sub("Aéλ🙂Z", (v39)+1, (v49)+1)
local v51 = 1
local v52 = runtime_byte_0(v0, v51)
local v53 = 0
local v54 = runtime_byte_0(v3, v53)
local v55 = 1
local v56 = 0
local v57 = 0
local v58 = 10
local v59 = codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58)
local v60 = 1
local v61 = runtime_byte_0(v0, v60)
local v62 = 0
local v63 = runtime_byte_0(v3, v62)
local v64 = 4
local v65 = 0
local v66 = 0
local v67 = 10
local v68 = codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67)
local v69 = spiral_wrap_signed((v68 - 1), 32)
local v70 = string.sub("Aéλ🙂Z", (v59)+1, (v69)+1)
local v71 = 1
local v72 = runtime_byte_0(v0, v71)
local v73 = 0
local v74 = runtime_byte_0(v3, v73)
local v75 = 3
local v76 = 0
local v77 = 0
local v78 = 10
local v79 = codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78)
local v80 = 0
local v81 = runtime_byte_0(v30, v80)
local v82 = "é"
local v83 = 0
local v84 = runtime_byte_0(v82, v83)
local v85 = 3
local v86 = runtime_byte_0(v50, v85)
local v87 = "🙂"
local v88 = 3
local v89 = runtime_byte_0(v87, v88)
local v90 = v10 == 5
if v90 then
    local v91 = string.len(v30)
    local v92 = v91 == 2
    if v92 then
        local v93 = v81 == v84
        if v93 then
            local v94 = string.len(v50)
            local v95 = v94 == 4
            if v95 then
                local v96 = v86 == v89
                if v96 then
                    local v97 = string.len(v70)
                    local v98 = v97 == 8
                    if v98 then
                        local v99 = v79 == 5
                        if v99 then
                            return 0
                        else
                            return 1
                        end
                    else
                        return 2
                    end
                else
                    return 3
                end
            else
                return 4
            end
        else
            return 5
        end
    else
        return 6
    end
else
    return 7
end
