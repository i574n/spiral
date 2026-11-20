local method0
function method0(v0)
    local v1 = v0 == 0
    if v1 then
        return 1
    else
        return v0
    end
end

local v0 = 100
local v1 = method0(v0)
local v2 = v1 == 100
if v2 then
    return 0
else
    return 1
end
