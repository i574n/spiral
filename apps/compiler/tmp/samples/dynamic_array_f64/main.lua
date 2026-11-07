local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0.0 end return t end)(v0)
v1[(0)+1] = 1.5
v1[(1)+1] = 2.5
local v2 = 1
local v3 = (v1)[(v2)+1]
local v4 = v3 >= 2.0
if v4 then
    return 0
else
    return 1
end
