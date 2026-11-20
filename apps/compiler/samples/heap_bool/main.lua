local Heap0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

local v0 = true
local v1 = { __tag = "Heap0", l0 = v0 }
local v2 = v1 ~= nil and v1.l0
if v2 then
    return 0
else
    return 1
end
