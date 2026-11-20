local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local measure_0
function measure_0(v0)
    local v1 = string.len(v0)
    return v1
end

local v0 = "qwe"
local v1 = measure_0(v0)
local v2 = measure_0(v0)
local v3 = spiral_wrap_signed((v1 + v2), 32)
local v4 = spiral_wrap_signed((v3 - 6), 32)
return v4
