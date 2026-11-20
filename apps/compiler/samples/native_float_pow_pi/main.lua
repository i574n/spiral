local v0 = 2.0
local v1 = 3.0
local v2 = 2.0
local v3 = 3.0
local v4 = 3.1415927
local v5 = 3.141592653589793
local v6 = v0 ^ v1
local v7 = v6 == 8.0
local getv10 = function()
    if v7 then
        local v8 = v2 ^ v3
        local v9 = v8 == 8.0
        return v9
    else
        return false
    end
end
local v10 = getv10()
local getv12 = function()
    if v10 then
        local v11 = v4 > 3.0
        return v11
    else
        return false
    end
end
local v12 = getv12()
local getv14 = function()
    if v12 then
        local v13 = v4 < 4.0
        return v13
    else
        return false
    end
end
local v14 = getv14()
local getv16 = function()
    if v14 then
        local v15 = v5 > 3.0
        return v15
    else
        return false
    end
end
local v16 = getv16()
local getv18 = function()
    if v16 then
        local v17 = v5 < 4.0
        return v17
    else
        return false
    end
end
local v18 = getv18()
if v18 then
    return 0
else
    return 1
end
