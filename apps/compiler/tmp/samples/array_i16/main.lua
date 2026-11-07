local v0 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(1)
local v1 = 20000
v0[(0)+1] = v1
local v2 = (v0)[(0)+1]
local v3 = v2 == 20000
if v3 then
    return 0
else
    return 1
end
