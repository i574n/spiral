local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local f_c0, apply_1, method0, method2
function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = string.len(v0)
        local v3 = spiral_wrap_signed((v2 + v1), 32)
        return v3
    end
end

function apply_1(v0, v1)
    return v0(v1)
end

function method0(v0, v1)
    local v2 = apply_1(v0, v1)
    local v3 = spiral_wrap_signed((v2 + 1), 32)
    return v3
end

function method2(v0, v1)
    local v2 = apply_1(v0, v1)
    local v3 = spiral_wrap_signed((v2 + 2), 32)
    return v3
end

local v0 = "abc"
local v1 = f_c0({ v0 })
local v2 = 16
local v3 = method0(v1, v2)
local v4 = 17
local v5 = method2(v1, v4)
local v6 = spiral_wrap_signed((v3 + v5), 32)
return v6
