local v0 = -2.0
local v1 = -1.0
local v2 = 0.0
local v3 = v0 < v1
local getv5 = function()
    if v3 then
        local v4 = v1 < v2
        return v4
    else
        return false
    end
end
local v5 = getv5()
local getv8 = function()
    if v5 then
        local v6 = v0 > v1
        local v7 = v6 == false
        return v7
    else
        return false
    end
end
local v8 = getv8()
local getv11 = function()
    if v8 then
        local v9 = v0 >= v1
        local v10 = v9 == false
        return v10
    else
        return false
    end
end
local v11 = getv11()
local getv13 = function()
    if v11 then
        local v12 = v1 <= v2
        return v12
    else
        return false
    end
end
local v13 = getv13()
if v13 then
    return 0
else
    return 1
end
