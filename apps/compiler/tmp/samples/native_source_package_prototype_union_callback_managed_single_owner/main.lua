local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_Idle, Us0_Text, closure0, method0
function Us0_Idle() return { tag = "Us0_Idle" } end
function Us0_Text(v0) return { tag = "Us0_Text",  _1 = v0 } end

function closure0(capt)
    return function(v0)
        local v1 = "managed"
        return Us0_Text(v1)
    end
end

function method0(v0)
    return v0(2)
end

local v0 = closure0(nil)
local v1 = method0(v0)
local getv4 = function()
    if v1 ~= nil and v1.tag == "Us0_Idle" then
        return 3
    elseif v1 ~= nil and v1.tag == "Us0_Text" then
        local v2 = v1._1
        return 11
    end
end
local v4 = getv4()
local v5 = spiral_wrap_signed((v4 + 31), 32)
return v5
