local v0 = "a"
local v1 = "b"
local v2 = "é"
local v3 = "éx"
local v4 = ""
local v5 = v0 < v0
if v5 then
    return 1
else
    local v6 = v0 < v1
    local getv8 = function()
        if v6 then
            local v7 = v1 < v2
            return v7
        else
            return false
        end
    end
    local v8 = getv8()
    local getv10 = function()
        if v8 then
            local v9 = v2 < v3
            return v9
        else
            return false
        end
    end
    local v10 = getv10()
    local getv12 = function()
        if v10 then
            local v11 = v4 < v0
            return v11
        else
            return false
        end
    end
    local v12 = getv12()
    local getv14 = function()
        if v12 then
            local v13 = v0 <= v0
            return v13
        else
            return false
        end
    end
    local v14 = getv14()
    local getv16 = function()
        if v14 then
            local v15 = v0 >= v0
            return v15
        else
            return false
        end
    end
    local v16 = getv16()
    local getv18 = function()
        if v16 then
            local v17 = v3 > v2
            return v17
        else
            return false
        end
    end
    local v18 = getv18()
    local getv20 = function()
        if v18 then
            local v19 = v1 >= v0
            return v19
        else
            return false
        end
    end
    local v20 = getv20()
    if v20 then
        return 0
    else
        return 1
    end
end
