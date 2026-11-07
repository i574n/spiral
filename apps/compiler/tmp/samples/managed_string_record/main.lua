local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method0, score_1
function method0(v0)
    local v1 = string.len(v0)
    return { [1]=v0, [2]=v1 }
end

function score_1(v0, v1)
    local v2 = string.len(v1)
    local v3 = spiral_wrap_signed((v2 + v0), 32)
    return v3
end

local v0 = "qwe"
local v1, v2 = (table.unpack or unpack)(method0(v0))
local v3 = score_1(v2, v1)
local v4 = score_1(v2, v1)
local v5 = spiral_wrap_signed((v3 + v4), 32)
local v6 = spiral_wrap_signed((v5 - 12), 32)
return v6
