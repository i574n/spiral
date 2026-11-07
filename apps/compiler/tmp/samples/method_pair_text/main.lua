local method0
function method0(v0)
    local v1 = v0 == 0
    if v1 then
        local v2 = "no"
        return { [1]=v2, [2]=v2 }
    else
        local v3 = "hi"
        local v4 = "yo"
        return { [1]=v3, [2]=v4 }
    end
end

local v0 = 7
local v1, v2 = (table.unpack or unpack)(method0(v0))
local v3 = v1 == "hi"
local getv5 = function()
    if v3 then
        local v4 = v2 == "yo"
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
