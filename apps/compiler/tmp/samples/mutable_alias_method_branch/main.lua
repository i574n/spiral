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
local Mut0, method0, method1, method2
Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

function method0(v0)
    local v1 = v0 ~= nil and v0.l0
    local v2 = spiral_wrap_signed((v1 + 5), 32)
    v0.l0 = v2
    return nil
end

function method1(v0)
    return nil
end

function method2(v0)
    local v1 = v0 ~= nil and v0.l0
    local v2 = spiral_wrap_signed((v1 + 7), 32)
    v0.l0 = v2
    return nil
end

local v0 = { __tag = "Mut0", l0 = 0 }
method0(v0)
method1(v0)
method2(v0)
local v1 = v0 ~= nil and v0.l0
local v2 = spiral_wrap_signed((v1 - 12), 32)
return v2
