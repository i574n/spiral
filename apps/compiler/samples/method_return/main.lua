local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local g_c0, method0
function g_c0(capt)
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

function method0(v0)
    return g_c0({ v0 })
end

local v0 = 7
local v1 = method0(v0)
local v2 = v1(0)
local v3 = v2 == 7
if v3 then
    return 0
else
    return 1
end
