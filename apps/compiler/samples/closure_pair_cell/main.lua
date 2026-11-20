local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Heap0, f_c0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function f_c0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 == 0
        if v3 then
            return { [1]=v1, [2]=0 }
        else
            return { [1]=v1, [2]=v0 }
        end
    end
end

local v0 = 3
local v1 = 4
local v2 = { __tag = "Heap0", l0 = v0 }
local v3 = f_c0({ v1, v2 })
local v4, v5 = (table.unpack or unpack)(v3(1))
local v6 = v4 ~= nil and v4.l0
local v7 = spiral_wrap_signed((v6 + v5), 32)
local v8 = v7 == 7
if v8 then
    return 0
else
    return 1
end
