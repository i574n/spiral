local method0
function method0(v0)
    local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(1)
    v1[(0)+1] = v0
    return v1
end

local v0 = 7
local v1 = method0(v0)
local v2 = (v1)[(0)+1]
local v3 = v2 == 7
if v3 then
    return 0
else
    return 1
end
