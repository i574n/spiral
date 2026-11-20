local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local closure1, make_c0, method0
function closure1(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = string.len(v0)
        local v3 = spiral_wrap_signed((v2 + v1), 32)
        return v3
    end
end

function make_c0(capt)
    return function(v0)
        return closure1({ v0 })
    end
end

function method0(v0)
    return v0(39)
end

local v0 = make_c0(nil)
local v1 = "abc"
local v2 = v0(v1)
return method0(v2)
