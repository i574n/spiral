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
local Us0_First, Us0_Second
function Us0_First() return { tag = "Us0_First" } end
function Us0_Second() return { tag = "Us0_Second" } end

local v0 = Us0_Second()
local v1 = (function () local __tag
if v0.tag == "Us0_First" then __tag = 1
elseif v0.tag == "Us0_Second" then __tag = 2
else __tag = 0 end
return __tag end)()
local v2 = spiral_wrap_signed(spiral_mul_mod32(v1, 10), 32)
local v3 = spiral_wrap_signed((v2 + 2), 32)
return v3
