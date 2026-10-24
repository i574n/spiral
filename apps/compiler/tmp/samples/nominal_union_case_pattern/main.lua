local Us0_Zero, Us0_One
function Us0_Zero() return { tag = "Us0_Zero" } end
function Us0_One() return { tag = "Us0_One" } end

local v0 = Us0_Zero()
local getv2 = function()
    if v0 ~= nil and v0.tag == "Us0_One" then
        return false
    elseif v0 ~= nil and v0.tag == "Us0_Zero" then
        return true
    end
end
local v2 = getv2()
if v2 then
    return 0
else
    return 1
end
