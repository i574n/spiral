local Mut0, Heap0
Mut0 = function(l0, l1) return { __tag = "Mut0", l0 = l0, l1 = l1 } end

Heap0 = function(l0) return { __tag = "Heap0", l0 } end

local v0 = 3
local v1 = "no"
local v2 = { __tag = "Mut0", l0 = v0, l1 = v1 }
local v3 = { __tag = "Heap0", l0 = v2 }
local v4 = v3 ~= nil and v3.l0
local v5 = 7
local v6 = "hi"
v4.l0 = v5
v4.l1 = v6
local v7, v8 = v4 ~= nil and v4.l0, v4 ~= nil and v4.l1
local v9 = v7 == 7
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
