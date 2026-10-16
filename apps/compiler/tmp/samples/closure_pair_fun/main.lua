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
local right_c1, left_c2, f_c0
function right_c1(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v1 == 0
        if v3 then
            return 0
        else
            local v4 = spiral_wrap_signed((v2 + v0), 32)
            return v4
        end
    end
end

function left_c2(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v1 == 0
        if v3 then
            return 0
        else
            local v4 = spiral_wrap_signed((v2 + v0), 32)
            return v4
        end
    end
end

function f_c0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 == 0
        if v3 then
            local v4 = right_c1({ v1, v2 })
            local v5 = left_c2({ v0, v2 })
            return { [1]=v4, [2]=v5 }
        else
            local v6 = left_c2({ v0, v2 })
            local v7 = right_c1({ v1, v2 })
            return { [1]=v6, [2]=v7 }
        end
    end
end

local v0 = 3
local v1 = 4
local v2 = f_c0({ v0, v1 })
local v3, v4 = (table.unpack or unpack)(v2(1))
local v5 = v3(0)
local v6 = v4(0)
local v7 = spiral_wrap_signed((v5 + v6), 32)
local v8 = v7 == 7
if v8 then
    return 0
else
    return 1
end
