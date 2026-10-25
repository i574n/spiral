local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_Idle, Us0_Hit, Us0_Flag, score_0, closure0, method1
function Us0_Idle() return { tag = "Us0_Idle" } end
function Us0_Hit(v0) return { tag = "Us0_Hit",  _1 = v0 } end
function Us0_Flag(v0) return { tag = "Us0_Flag",  _1 = v0 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Flag" then
        local v2 = v0._1
        if v2 then
            return 11
        else
            return 5
        end
    elseif v0 ~= nil and v0.tag == "Us0_Hit" then
        local v1 = v0._1
        return v1
    elseif v0 ~= nil and v0.tag == "Us0_Idle" then
        return 3
    end
end

function closure0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = score_0(v0)
        local v3 = spiral_wrap_signed((v2 + v1), 32)
        return v3
    end
end

function method1(v0)
    return v0(31)
end

local v0 = 2
local v1 = v0 == 0
local getv7 = function()
    if v1 then
        return Us0_Idle()
    else
        local v3 = v0 == 1
        if v3 then
            return Us0_Hit(7)
        else
            return Us0_Flag(true)
        end
    end
end
local v7 = getv7()
local v8 = closure0({ v7 })
return method1(v8)
