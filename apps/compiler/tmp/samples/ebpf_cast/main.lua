local v0 = 3
local v1 = -2
local v2 = 7
local v3 = 2.9
local v4 = v0
local v5 = v1
local v6 = v2
local v7 = (math.modf(v3))
local v8 = v4 == 3.0
local getv10 = function()
    if v8 then
        local v9 = v5 == -2.0
        return v9
    else
        return false
    end
end
local v10 = getv10()
local getv12 = function()
    if v10 then
        local v11 = v6 == 7.0
        return v11
    else
        return false
    end
end
local v12 = getv12()
local getv14 = function()
    if v12 then
        local v13 = v7 == 2
        return v13
    else
        return false
    end
end
local v14 = getv14()
if v14 then
    return 0
else
    return 1
end
