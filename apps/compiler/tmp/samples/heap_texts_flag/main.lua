local Heap0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

local v0 = (function(n) local t = {} for i = 1, n do t[i] = "" end return t end)(1)
local v1 = "hi"
v0[(0)+1] = v1
local v2 = true
local v3 = { __tag = "Heap0", l0 = v0, l1 = v2 }
local v4, v5 = v3 ~= nil and v3.l0, v3 ~= nil and v3.l1
local v6 = (v4)[(0)+1]
local v7 = v6 == "hi"
local v8 = (v7) and (v5)
if v8 then
    return 0
else
    return 1
end
