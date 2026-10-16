local v0 = 1.5
local v1 = -2.0
local v2 = -0.5
local v3 = v0 / v1
local v4 = v2 / v1
local v5 = v3 == -0.75
local getv7 = function()
    if v5 then
        local v6 = v4 == 0.25
        return v6
    else
        return false
    end
end
local v7 = getv7()
if v7 then
    return 0
else
    return 1
end
