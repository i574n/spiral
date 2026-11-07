local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = "" end return t end)(v0)
local v2 = "hi"
v1[(0)+1] = v2
local v3 = "yo"
v1[(1)+1] = v3
local v4 = (v1)[(0)+1]
local v5 = v4 == "hi"
if v5 then
    return 0
else
    return 1
end
