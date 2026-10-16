local Mut0, method0
Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

function method0(v0)
    return v0
end

local v0 = { __tag = "Mut0", l0 = 1 }
local v1 = method0(v0)
v1.l0 = 7
local v2 = v1 ~= nil and v1.l0
local v3 = v2 == 7
if v3 then
    return 0
else
    return 1
end
