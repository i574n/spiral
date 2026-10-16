local f_c0
function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(1)
        v2[(0)+1] = v0
        return v2
    end
end

local v0 = 7
local v1 = f_c0({ v0 })
local v2 = v1(1)
local v3 = (v2)[(0)+1]
local v4 = v3 == 7
if v4 then
    return 0
else
    return 1
end
