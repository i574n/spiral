local Heap0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

local v0 = "hi"
local v1 = { __tag = "Heap0", l0 = v0, l1 = v0 }
local v2, v3 = v1 ~= nil and v1.l0, v1 ~= nil and v1.l1
local v4 = v2 == v3
if v4 then
    return 0
else
    return 1
end
