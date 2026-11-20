local Heap0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

local v0 = (function(n) local t = {} for i = 1, n do t[i] = "" end return t end)(1)
local v1 = "hi"
v0[(0)+1] = v1
local v2 = { __tag = "Heap0", l0 = v0 }
local v3 = v2 ~= nil and v2.l0
local v4 = (v3)[(0)+1]
local v5 = v4 == "hi"
if v5 then
    return 0
else
    return 1
end
