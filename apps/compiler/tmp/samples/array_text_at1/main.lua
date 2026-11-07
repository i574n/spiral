local v0 = (function(n) local t = {} for i = 1, n do t[i] = "" end return t end)(2)
local v1 = "hi"
v0[(1)+1] = v1
local v2 = (v0)[(1)+1]
local v3 = v2 == "hi"
if v3 then
    return 0
else
    return 1
end
