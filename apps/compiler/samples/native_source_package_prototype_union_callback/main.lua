local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_Idle, Us0_Hit, Us0_Flag, closure0, method0
function Us0_Idle() return { tag = "Us0_Idle" } end
function Us0_Hit(v0) return { tag = "Us0_Hit",  _1 = v0 } end
function Us0_Flag(v0) return { tag = "Us0_Flag",  _1 = v0 } end

function closure0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v1 == v0
        return Us0_Flag(v2)
    end
end

function method0(v0, v1)
    return v0(v1)
end

local v0 = 2
local v1 = closure0({ v0 })
local v2 = method0(v1, v0)
local getv8 = function()
    if v2 ~= nil and v2.tag == "Us0_Flag" then
        local v4 = v2._1
        if v4 then
            return 11
        else
            return 5
        end
    elseif v2 ~= nil and v2.tag == "Us0_Hit" then
        local v3 = v2._1
        return v3
    elseif v2 ~= nil and v2.tag == "Us0_Idle" then
        return 3
    end
end
local v8 = getv8()
local v9 = spiral_wrap_signed((v8 + 31), 32)
return v9
