local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local choose_0, measure_1
function choose_0(v0)
    if v0 then
        local v1 = "alpha"
        return v1
    else
        local v2 = "beta"
        return v2
    end
end

function measure_1(v0)
    local v1 = string.len(v0)
    return v1
end

local v0 = true
local v1 = choose_0(v0)
local v2 = false
local v3 = choose_0(v2)
local v4 = measure_1(v1)
local v5 = measure_1(v1)
local v6 = spiral_wrap_signed((v4 + v5), 32)
local v7 = measure_1(v3)
local v8 = spiral_wrap_signed((v6 + v7), 32)
local v9 = spiral_wrap_signed((v8 - 14), 32)
return v9
