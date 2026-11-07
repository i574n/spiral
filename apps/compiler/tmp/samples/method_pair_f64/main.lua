local method0
function method0(v0)
    local v1 = v0 == 0
    if v1 then
        return { [1]=0.0, [2]=0.0 }
    else
        return { [1]=1.5, [2]=2.5 }
    end
end

local v0 = 7
local v1, v2 = (table.unpack or unpack)(method0(v0))
local v3 = v1 == 1.5
local getv5 = function()
    if v3 then
        local v4 = v2 == 2.5
        return v4
    else
        return false
    end
end
local v5 = getv5()
if v5 then
    return 0
else
    return 1
end
