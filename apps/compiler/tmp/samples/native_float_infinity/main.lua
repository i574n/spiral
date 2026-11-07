local v0 = math.huge
local v1 = math.huge
local v2 = -(v0)
local v3 = -(v1)
local v4 = 1.0
local v5 = 1.0
local v6 = (v4 ~= v4)
local getv8 = function()
    if v6 then
        return true
    else
        local v7 = (v5 ~= v5)
        return v7
    end
end
local v8 = getv8()
if v8 then
    return 3
else
    local v9 = v0 > v4
    local getv11 = function()
        if v9 then
            local v10 = v1 > v5
            return v10
        else
            return false
        end
    end
    local v11 = getv11()
    if v11 then
        local v12 = v2 < 0.0
        local getv14 = function()
            if v12 then
                local v13 = v3 < 0.0
                return v13
            else
                return false
            end
        end
        local v14 = getv14()
        if v14 then
            return 0
        else
            return 2
        end
    else
        return 1
    end
end
