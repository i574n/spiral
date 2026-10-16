local Us0_Missing, Us0_Held
function Us0_Missing() return { tag = "Us0_Missing" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

local v0 = (function(n) local t = {} for i = 1, n do t[i] = 0.0 end return t end)(1)
local v1 = 1.5
v0[(0)+1] = v1
local v2 = true
local getv5 = function()
    if v2 then
        return Us0_Held(v0)
    else
        return Us0_Missing()
    end
end
local v5 = getv5()
local __v = { v5 }
if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
    local v6 = __v[1]._1
    local v7 = (v6)[(0)+1]
    local v8 = v7 == 1.5
    if v8 then
        return 0
    else
        return 1
    end
elseif __v[1] ~= nil and __v[1].tag == "Us0_Missing" then
    return 1
end
