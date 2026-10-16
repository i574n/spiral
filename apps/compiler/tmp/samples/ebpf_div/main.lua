local v0 = 7
local v1 = -2
local v2 = -7
local v3 = 100
local v4 = 7
local v5 = (math.modf(v0 / v1))
local v6 = math.fmod(v0, v1)
local v7 = (math.modf(v2 / v1))
local v8 = math.fmod(v2, v1)
local v9 = (math.modf(v3 / v4))
local v10 = math.fmod(v3, v4)
local v11 = v5 == -3
local getv13 = function()
    if v11 then
        local v12 = v6 == 1
        return v12
    else
        return false
    end
end
local v13 = getv13()
local getv15 = function()
    if v13 then
        local v14 = v7 == 3
        return v14
    else
        return false
    end
end
local v15 = getv15()
local getv17 = function()
    if v15 then
        local v16 = v8 == -1
        return v16
    else
        return false
    end
end
local v17 = getv17()
local getv19 = function()
    if v17 then
        local v18 = v9 == 14
        return v18
    else
        return false
    end
end
local v19 = getv19()
local getv21 = function()
    if v19 then
        local v20 = v10 == 2
        return v20
    else
        return false
    end
end
local v21 = getv21()
if v21 then
    return 0
else
    return 1
end
