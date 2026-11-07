local Heap0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

local v0 = 100
local v1 = { __tag = "Heap0", l0 = v0 }
local v2 = v1 ~= nil and v1.l0
local v3 = v2 == 100
if v3 then
    return 0
else
    return 1
end
