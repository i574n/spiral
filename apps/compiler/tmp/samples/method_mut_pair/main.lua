local Mut0, method0
Mut0 = function(l0, l1) return { __tag = "Mut0", l0 = l0, l1 = l1 } end

function method0(v0, v1)
    return { __tag = "Mut0", l0 = v0, l1 = v1 }
end

local v0 = 3
local v1 = "no"
local v2 = method0(v0, v1)
local v3 = 7
local v4 = "hi"
v2.l0 = v3
v2.l1 = v4
local v5, v6 = v2 ~= nil and v2.l0, v2 ~= nil and v2.l1
local v7 = v5 == 7
local getv9 = function()
    if v7 then
        local v8 = v6 == "hi"
        return v8
    else
        return false
    end
end
local v9 = getv9()
if v9 then
    return 0
else
    return 1
end
