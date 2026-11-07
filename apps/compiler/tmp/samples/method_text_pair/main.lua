local method0
function method0(v0, v1)
    local v2 = v0 == ""
    if v2 then
        local v3 = "no"
        local v4 = "nay"
        return { [1]=v3, [2]=v4 }
    else
        return { [1]=v0, [2]=v1 }
    end
end

local v0 = "hi"
local v1 = "yo"
local v2, v3 = (table.unpack or unpack)(method0(v0, v1))
local v4 = v2 == "hi"
local getv6 = function()
    if v4 then
        local v5 = v3 == "yo"
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
