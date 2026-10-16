local method0
function method0(v0)
    local v1 = v0 == 0
    if v1 then
        return 0.0
    else
        return 1.5
    end
end

local v0 = 7
local v1 = method0(v0)
local v2 = v1 == 1.5
if v2 then
    return 0
else
    return 1
end
