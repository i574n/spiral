local Heap0, Us0_Missing, Us0_Box
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function Us0_Missing() return { tag = "Us0_Missing" } end
function Us0_Box(v0) return { tag = "Us0_Box",  _1 = v0 } end

local v0 = 7
local v1 = { __tag = "Heap0", l0 = v0 }
local v2 = true
local getv5 = function()
    if v2 then
        return Us0_Box(v1)
    else
        return Us0_Missing()
    end
end
local v5 = getv5()
local __v = { v5 }
if __v[1] ~= nil and __v[1].tag == "Us0_Box" then
    local v6 = __v[1]._1
    local v7 = v6 ~= nil and v6.l0
    local v8 = v7 == 7
    if v8 then
        return 0
    else
        return 1
    end
elseif __v[1] ~= nil and __v[1].tag == "Us0_Missing" then
    return 1
end
