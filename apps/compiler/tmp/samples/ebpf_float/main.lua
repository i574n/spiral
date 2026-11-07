local v0 = -1.5
local v1 = 2.0
local v2 = v0 / v1
local v3 = -0.75
local v4 = (v0 * v1)
local v5 = (v4 + 0.5)
local v6 = -2.5
local v7 = v2 == v3
if v7 then
    local v8 = v5 == v6
    if v8 then
        return 0
    else
        return 2
    end
else
    return 1
end
