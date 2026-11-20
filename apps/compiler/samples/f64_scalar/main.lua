local v0 = 1.5
local v1 = -2.0
local v2 = v0 / v1
local v3 = 1000000.0
local v4 = (v3 * v3)
local v5 = (v4 * v3)
local v6 = (v5 * 10000.0)
local v7 = (v6 * v6)
local v8 = 3
local v9 = v8
local v10 = 2.9
local v11 = -1.9
local v12 = (math.modf(v10))
local v13 = (math.modf(v11))
local v14 = 1.5
local v15 = v14
local v16 = v2 == -0.75
local getv18 = function()
    if v16 then
        local v17 = v7 > v6
        return v17
    else
        return false
    end
end
local v18 = getv18()
local getv21 = function()
    if v18 then
        local v19 = (v7 * v6)
        local v20 = v7 < v19
        return v20
    else
        return false
    end
end
local v21 = getv21()
local getv23 = function()
    if v21 then
        local v22 = v9 == 3.0
        return v22
    else
        return false
    end
end
local v23 = getv23()
local getv25 = function()
    if v23 then
        local v24 = v12 == 2
        return v24
    else
        return false
    end
end
local v25 = getv25()
local getv27 = function()
    if v25 then
        local v26 = v13 == -1
        return v26
    else
        return false
    end
end
local v27 = getv27()
local getv29 = function()
    if v27 then
        local v28 = v15 == 1.5
        return v28
    else
        return false
    end
end
local v29 = getv29()
if v29 then
    return 0
else
    return 1
end
