local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local g_c1, f_c0
function g_c1(capt)
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
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return g_c1({ v0, v1 })
    end
end

local v0 = 7
local v1 = f_c0({ v0 })
local v2 = v1(1)
local v3 = v2(0)
local v4 = v3 == 7
if v4 then
    return 0
else
    return 1
end
