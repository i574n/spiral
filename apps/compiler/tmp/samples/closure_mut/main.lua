local Mut0, f_c0
Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return v0
    end
end

local v0 = { __tag = "Mut0", l0 = 1 }
local v1 = f_c0({ v0 })
local v2 = v1(1)
v2.l0 = 7
local v3 = v2 ~= nil and v2.l0
local v4 = v3 == 7
if v4 then
    return 0
else
    return 1
end
