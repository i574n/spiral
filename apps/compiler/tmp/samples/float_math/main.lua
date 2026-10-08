local method0
function method0(v0, v1)
    local v2 = (v0 * v1)
    local v3 = (v2 + 0.5)
    return v3
end

local v0 = 1.5
local v1 = 2.0
local v2 = method0(v0, v1)
local v3 = v2 >= 3.5
if v3 then
    return 0
else
    return 1
end
