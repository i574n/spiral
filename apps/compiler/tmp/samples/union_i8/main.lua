local Us0_Missing, Us0_Held
function Us0_Missing() return { tag = "Us0_Missing" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

local v0 = 100
local v1 = true
local getv4 = function()
    if v1 then
        return Us0_Held(v0)
    else
        return Us0_Missing()
    end
end
local v4 = getv4()
local __v = { v4 }
if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
    local v5 = __v[1]._1
    local v6 = v5 == 100
    if v6 then
        return 0
    else
        return 1
    end
elseif __v[1] ~= nil and __v[1].tag == "Us0_Missing" then
    return 1
end
