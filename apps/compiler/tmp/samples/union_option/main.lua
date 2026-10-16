local Us0_Empty, Us0_Full, pick_0
function Us0_Empty() return { tag = "Us0_Empty" } end
function Us0_Full(v0) return { tag = "Us0_Full",  _1 = v0 } end

function pick_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Empty" then
        return 0
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Full" then
        local v1 = __v[1]._1
        return v1
    end
end

local v0 = true
local getv3 = function()
    if v0 then
        return Us0_Full(7)
    else
        return Us0_Empty()
    end
end
local v3 = getv3()
local getv6 = function()
    if v0 then
        return Us0_Empty()
    else
        return Us0_Full(1)
    end
end
local v6 = getv6()
local v7 = pick_0(v3)
local v8 = v7 == 7
local getv11 = function()
    if v8 then
        local v9 = pick_0(v6)
        local v10 = v9 == 0
        return v10
    else
        return false
    end
end
local v11 = getv11()
if v11 then
    return 0
else
    return 1
end
