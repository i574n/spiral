local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v1[(0)+1] = 11
v1[(1)+1] = 13
local v2 = 2
local v3 = (v1)[(v2)+1]
return v3
