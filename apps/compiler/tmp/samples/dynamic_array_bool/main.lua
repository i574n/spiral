local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = false end return t end)(v0)
v1[(0)+1] = true
v1[(1)+1] = false
local v2 = 0
local v3 = (v1)[(v2)+1]
if v3 then
    return 0
else
    return 1
end
