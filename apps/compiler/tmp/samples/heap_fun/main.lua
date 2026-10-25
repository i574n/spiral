local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Heap0, add_c0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

function add_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = spiral_wrap_signed((v1 + v0), 32)
        return v2
    end
end

local v0 = 3
local v1 = 4
local v2 = add_c0({ v0 })
local v3 = { __tag = "Heap0", l0 = v2, l1 = v1 }
local v4, v5 = v3 ~= nil and v3.l0, v3 ~= nil and v3.l1
local v6 = v4(0)
local v7 = spiral_wrap_signed((v6 + v5), 32)
local v8 = v7 == 7
if v8 then
    return 0
else
    return 1
end
