local Us0_Real, Us0_Whole, twice_1, score_0
function Us0_Real(v0) return { tag = "Us0_Real",  _1 = v0 } end
function Us0_Whole(v0) return { tag = "Us0_Whole",  _1 = v0 } end

function twice_1(v0)
    local v1 = (v0 * 2.0)
    local v2 = (math.modf(v1))
    return v2
end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Real" then
        local v1 = v0._1
        return twice_1(v1)
    elseif v0 ~= nil and v0.tag == "Us0_Whole" then
        local v3 = v0._1
        return v3
    end
end

local v0 = true
local v1 = 1.5
local getv4 = function()
    if v0 then
        return Us0_Real(v1)
    else
        return Us0_Whole(1)
    end
end
local v4 = getv4()
local getv7 = function()
    if v0 then
        return Us0_Whole(5)
    else
        return Us0_Real(v1)
    end
end
local v7 = getv7()
local v8 = score_0(v4)
local v9 = v8 == 3
local getv12 = function()
    if v9 then
        local v10 = score_0(v7)
        local v11 = v10 == 5
        return v11
    else
        return false
    end
end
local v12 = getv12()
if v12 then
    return 0
else
    return 1
end
