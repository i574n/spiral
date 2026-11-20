local Heap0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
local v2 = 7
v1[(0)+1] = v2
local v3 = { __tag = "Heap0", l0 = v1 }
local v4 = v3 ~= nil and v3.l0
local v5 = (v4)[(0)+1]
local v6 = v5 == 7
if v6 then
    return 0
else
    return 1
end
