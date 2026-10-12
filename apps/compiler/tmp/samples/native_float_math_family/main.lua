local v0 = 0.0
local v1 = 1.0
local v2 = 0.0
local v3 = 1.0
local v4 = math.log(v1)
local v5 = v4 == v0
local getv8 = function()
    if v5 then
        local v6 = math.log(v3)
        local v7 = v6 == v2
        return v7
    else
        return false
    end
end
local v8 = getv8()
local getv11 = function()
    if v8 then
        local v9 = math.exp(v0)
        local v10 = v9 == v1
        return v10
    else
        return false
    end
end
local v11 = getv11()
local getv14 = function()
    if v11 then
        local v12 = math.exp(v2)
        local v13 = v12 == v3
        return v13
    else
        return false
    end
end
local v14 = getv14()
local getv17 = function()
    if v14 then
        local v15 = math.tanh(v0)
        local v16 = v15 == v0
        return v16
    else
        return false
    end
end
local v17 = getv17()
local getv20 = function()
    if v17 then
        local v18 = math.tanh(v2)
        local v19 = v18 == v2
        return v19
    else
        return false
    end
end
local v20 = getv20()
local getv23 = function()
    if v20 then
        local v21 = math.sin(v0)
        local v22 = v21 == v0
        return v22
    else
        return false
    end
end
local v23 = getv23()
local getv26 = function()
    if v23 then
        local v24 = math.sin(v2)
        local v25 = v24 == v2
        return v25
    else
        return false
    end
end
local v26 = getv26()
local getv29 = function()
    if v26 then
        local v27 = math.cos(v0)
        local v28 = v27 == v1
        return v28
    else
        return false
    end
end
local v29 = getv29()
local getv32 = function()
    if v29 then
        local v30 = math.cos(v2)
        local v31 = v30 == v3
        return v31
    else
        return false
    end
end
local v32 = getv32()
if v32 then
    return 0
else
    return 1
end
