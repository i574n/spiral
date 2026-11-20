local Heap0, method0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function method0(v0)
    return v0
end

local v0 = 7
local v1 = { __tag = "Heap0", l0 = v0 }
local v2 = method0(v1)
local v3 = v2 ~= nil and v2.l0
local v4 = v3 == 7
if v4 then
    return 0
else
    return 1
end
