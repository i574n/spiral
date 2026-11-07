local Mut0, Us0_Missing, Us0_Held
Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

function Us0_Missing() return { tag = "Us0_Missing" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

local v0 = { __tag = "Mut0", l0 = 1 }
local v1 = true
local getv4 = function()
    if v1 then
        return Us0_Held(v0)
    else
        return Us0_Missing()
    end
end
local v4 = getv4()
if v4 ~= nil and v4.tag == "Us0_Held" then
    local v5 = v4._1
    v5.l0 = 7
    local v6 = v5 ~= nil and v5.l0
    local v7 = v6 == 7
    if v7 then
        return 0
    else
        return 1
    end
elseif v4 ~= nil and v4.tag == "Us0_Missing" then
    return 1
end
