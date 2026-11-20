local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local closure0, method0
function closure0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(dom)
        local v1, v2 = (table.unpack or unpack)(dom)
        local v3 = spiral_wrap_signed((v1 - 8), 32)
        local v4 = spiral_wrap_signed((v3 + v0), 32)
        local v5 = spiral_wrap_signed((v2 - 18), 32)
        return { [1]=v4, [2]=v5 }
    end
end

function method0(v0)
    return v0({ [1]=10, [2]=20 })
end

local v0 = 1
local v1 = closure0({ v0 })
local v2, v3 = (table.unpack or unpack)(method0(v1))
local v4 = spiral_wrap_signed((10 + v2), 32)
local v5 = spiral_wrap_signed((20 + v3), 32)
local v6 = spiral_wrap_signed((v4 + v5), 32)
local v7 = spiral_wrap_signed((v6 + 7), 32)
return v7
