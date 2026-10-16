local v0 = "é"
local v1 = "x"
local v2 = (v0 .. v1)
local v3 = "éx"
local v4 = "éy"
local v5 = ""
local v6 = string.sub(v3, (1)+1, (0)+1)
local v7 = v2 == v3
local getv9 = function()
    if v7 then
        local v8 = v2 ~= v4
        return v8
    else
        return false
    end
end
local v9 = getv9()
local getv11 = function()
    if v9 then
        local v10 = v0 ~= v3
        return v10
    else
        return false
    end
end
local v11 = getv11()
local getv13 = function()
    if v11 then
        local v12 = v5 == v6
        return v12
    else
        return false
    end
end
local v13 = getv13()
local getv15 = function()
    if v13 then
        local v14 = v5 ~= v0
        return v14
    else
        return false
    end
end
local v15 = getv15()
if v15 then
    return 0
else
    return 1
end
