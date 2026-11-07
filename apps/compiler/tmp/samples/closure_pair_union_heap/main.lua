local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Heap0, Us0_None, Us0_Some, f_c0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

function f_c0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 == 0
        if v3 then
            local v4 = Us0_None()
            return { [1]=v4, [2]=v1 }
        else
            local v5 = Us0_Some(v0)
            return { [1]=v5, [2]=v1 }
        end
    end
end

local v0 = 3
local v1 = 4
local v2 = { __tag = "Heap0", l0 = v1 }
local v3 = f_c0({ v0, v2 })
local v4, v5 = (table.unpack or unpack)(v3(1))
if v4 ~= nil and v4.tag == "Us0_None" then
    return 1
elseif v4 ~= nil and v4.tag == "Us0_Some" then
    local v6 = v4._1
    local v7 = v5 ~= nil and v5.l0
    local v8 = spiral_wrap_signed((v6 + v7), 32)
    local v9 = v8 == 7
    if v9 then
        return 0
    else
        return 1
    end
end
