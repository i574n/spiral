local method0
function method0(v0)
    local v1 = string.sub(v0, (1)+1, (3)+1)
    return v1
end

local v0 = "alpha"
local v1 = method0(v0)
local v2 = string.len(v1)
local v3 = v2 == 3
if v3 then
    local v4 = string.sub(v1, (0)+1, (0)+1)
    local v5 = v4 == "l"
    if v5 then
        local v6 = string.sub(v1, (2)+1, (2)+1)
        local v7 = v6 == "h"
        if v7 then
            return 0
        else
            return 1
        end
    else
        return 2
    end
else
    return 3
end
