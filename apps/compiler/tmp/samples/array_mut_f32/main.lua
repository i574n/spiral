local Mut0
Mut0 = function(l0, l1) return { __tag = "Mut0", l0 = l0, l1 = l1 } end

local v0 = 1.5
local v1 = "no"
local v2 = { __tag = "Mut0", l0 = v0, l1 = v1 }
local v3 = {}
v3[(0)+1] = v2
local v4 = (v3)[(0)+1]
local v5 = 2.5
local v6 = "hi"
v4.l0 = v5
v4.l1 = v6
local v7, v8 = v4 ~= nil and v4.l0, v4 ~= nil and v4.l1
local v9 = v7 == 2.5
local getv11 = function()
    if v9 then
        local v10 = v8 == "hi"
        return v10
    else
        return false
    end
end
local v11 = getv11()
if v11 then
    return 0
else
    return 1
end
