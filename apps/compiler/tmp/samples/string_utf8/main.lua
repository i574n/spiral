local v0 = "é"
local v1 = string.len(v0)
local v2 = string.sub(v0, (0)+1, (0)+1)
local v3 = string.sub(v0, (1)+1, (1)+1)
local v4 = "x"
local v5 = (v0 .. v4)
local v6 = string.len(v5)
local v7 = "ab"
local v8 = string.sub(v7, (0)+1, (0)+1)
local v9 = string.sub(v7, (0)+1, (0)+1)
local v10 = string.len(v9)
local v11 = string.sub(v7, (1)+1, (0)+1)
local v12 = string.len(v11)
local v13 = string.sub(v0, (0)+1, (1)+1)
local v14 = string.len(v13)
local v15 = v2 == v3
if v15 then
    return 1
else
    local v16 = v1 == 2
    local getv18 = function()
        if v16 then
            local v17 = v8 == "a"
            return v17
        else
            return false
        end
    end
    local v18 = getv18()
    local getv20 = function()
        if v18 then
            local v19 = v6 == 3
            return v19
        else
            return false
        end
    end
    local v20 = getv20()
    local getv22 = function()
        if v20 then
            local v21 = v10 == 1
            return v21
        else
            return false
        end
    end
    local v22 = getv22()
    local getv24 = function()
        if v22 then
            local v23 = v12 == 0
            return v23
        else
            return false
        end
    end
    local v24 = getv24()
    local getv26 = function()
        if v24 then
            local v25 = v14 == 2
            return v25
        else
            return false
        end
    end
    local v26 = getv26()
    if v26 then
        return 0
    else
        return 1
    end
end
