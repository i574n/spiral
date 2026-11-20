local v0 = 144.0
local v1 = 81.0
local v2 = math.sqrt(v0)
local v3 = math.sqrt(v1)
local v4 = v2 == 12.0
local getv6 = function()
    if v4 then
        local v5 = v3 == 9.0
        return v5
    else
        return false
    end
end
local v6 = getv6()
if v6 then
    return 0
else
    return 1
end
