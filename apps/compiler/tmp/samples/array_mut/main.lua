local Mut0
Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

local v0 = {}
local v1 = { __tag = "Mut0", l0 = 1 }
v0[(0)+1] = v1
local v2 = (v0)[(0)+1]
v2.l0 = 7
local v3 = v2 ~= nil and v2.l0
local v4 = v3 == 7
if v4 then
    return 0
else
    return 1
end
