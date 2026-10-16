local Us0_No, Us0_Yes, score_0
function Us0_No(v0) return { tag = "Us0_No",  _1 = v0 } end
function Us0_Yes(v0) return { tag = "Us0_Yes",  _1 = v0 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_No" then
        local v1 = __v[1]._1
        if v1 then
            return 1
        else
            return 2
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Yes" then
        local v3 = __v[1]._1
        return v3
    end
end

local v0 = true
local getv3 = function()
    if v0 then
        return Us0_Yes(7)
    else
        return Us0_No(false)
    end
end
local v3 = getv3()
local getv6 = function()
    if v0 then
        return Us0_No(true)
    else
        return Us0_Yes(1)
    end
end
local v6 = getv6()
local v7 = score_0(v3)
local v8 = v7 == 7
local getv11 = function()
    if v8 then
        local v9 = score_0(v6)
        local v10 = v9 == 1
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
