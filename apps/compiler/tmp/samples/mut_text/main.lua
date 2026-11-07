local Mut0
Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

local v0 = "no"
local v1 = { __tag = "Mut0", l0 = v0 }
local v2 = "hi"
v1.l0 = v2
local v3 = v1 ~= nil and v1.l0
local v4 = v3 == "hi"
if v4 then
    return 0
else
    return 1
end
