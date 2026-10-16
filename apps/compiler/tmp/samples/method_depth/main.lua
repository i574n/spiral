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
local h_c1, g_c0, method0
function h_c1(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v0 == 0
        if v2 then
            return 0
        else
            local v3 = spiral_wrap_signed((v1 + v0), 32)
            return v3
        end
    end
end

function g_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return h_c1({ v0 })
    end
end

function method0(v0)
    return g_c0({ v0 })
end

local v0 = 7
local v1 = method0(v0)
local v2 = v1(0)
local v3 = v2(0)
local v4 = v3 == 7
if v4 then
    return 0
else
    return 1
end
