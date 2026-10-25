local Us0_Missing, Us0_Held
function Us0_Missing() return { tag = "Us0_Missing" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
local v2 = 7
v1[(0)+1] = v2
local v3 = true
local getv6 = function()
    if v3 then
        return Us0_Held(v1)
    else
        return Us0_Missing()
    end
end
local v6 = getv6()
local __v = { v6 }
if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
    local v7 = __v[1]._1
    local v8 = (v7)[(0)+1]
    local v9 = v8 == 7
    if v9 then
        return 0
    else
        return 1
    end
elseif __v[1] ~= nil and __v[1].tag == "Us0_Missing" then
    return 1
end
