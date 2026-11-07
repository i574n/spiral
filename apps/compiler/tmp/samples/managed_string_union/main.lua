local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_Text, Us0_Number, score_0
function Us0_Text(v0) return { tag = "Us0_Text",  _1 = v0 } end
function Us0_Number(v0) return { tag = "Us0_Number",  _1 = v0 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Number" then
        local v3 = v0._1
        return v3
    elseif v0 ~= nil and v0.tag == "Us0_Text" then
        local v1 = v0._1
        local v2 = string.len(v1)
        return v2
    end
end

local v0 = false
local getv4 = function()
    if v0 then
        return Us0_Number(7)
    else
        local v2 = "qwe"
        return Us0_Text(v2)
    end
end
local v4 = getv4()
local v5 = score_0(v4)
local v6 = score_0(v4)
local v7 = spiral_wrap_signed((v5 + v6), 32)
local v8 = spiral_wrap_signed((v7 - 6), 32)
return v8
