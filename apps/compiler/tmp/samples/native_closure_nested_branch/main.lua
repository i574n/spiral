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
local closure0, closure1, method0
function closure0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 > 0
        if v3 then
            local v4 = string.len(v0)
            local v5 = spiral_wrap_signed((v4 + v1), 32)
            local v6 = spiral_wrap_signed((v5 + v2), 32)
            return v6
        else
            return 0
        end
    end
end

function closure1(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 > 0
        if v3 then
            local v4 = string.len(v0)
            local v5 = spiral_wrap_signed((v4 + v1), 32)
            local v6 = spiral_wrap_signed((v5 + v2), 32)
            local v7 = spiral_wrap_signed((v6 - 1), 32)
            return v7
        else
            return -1
        end
    end
end

function method0(v0)
    return v0(37)
end

local v0 = "abc"
local v1 = "wxyz"
local v2 = 2
local v3 = 2
local v4 = true
local getv7 = function()
    if v4 then
        return closure0({ v0, v2 })
    else
        return closure1({ v1, v3 })
    end
end
local v7 = getv7()
return method0(v7)
