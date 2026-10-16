local v0 = (function(n) local t = {} for i = 1, n do t[i] = false end return t end)(1)
local v1 = true
v0[(0)+1] = v1
local v2 = (v0)[(0)+1]
if v2 then
    return 0
else
    return 1
end
