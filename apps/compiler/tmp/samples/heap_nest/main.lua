local Heap0, Heap1
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

Heap1 = function(l0) return { __tag = "Heap1", l0 } end

local v0 = 7
local v1 = { __tag = "Heap0", l0 = v0 }
local v2 = { __tag = "Heap1", l0 = v1 }
local v3 = v2 ~= nil and v2.l0
local v4 = v3 ~= nil and v3.l0
local v5 = v4 == 7
if v5 then
    return 0
else
    return 1
end
