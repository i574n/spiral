local v0 = 3
local v1 = 4
local v2 = 1
local v3 = 1
local v4 = 1.5
local v5 = -(v4)
local v6 = v0 == v1
local v7 = v6 ~= true
if v7 then
    local v8 = v2 == v3
    local v9 = v8 ~= true
    if v9 then
        return 2
    else
        local v10 = v5 == -1.5
        if v10 then
            return 0
        else
            return 3
        end
    end
else
    return 1
end
