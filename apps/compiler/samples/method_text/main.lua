local method0
function method0(v0)
    local v1 = v0 == 0
    if v1 then
        local v2 = "no"
        return v2
    else
        local v3 = "hi"
        return v3
    end
end

local v0 = 7
local v1 = method0(v0)
local v2 = v1 == "hi"
if v2 then
    return 0
else
    return 1
end
