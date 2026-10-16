local Heap0, Heap1
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 1
local v4 = { __tag = "Heap1", l0 = v2, l1 = v3 }
local v5, v6 = v4 ~= nil and v4.l0, v4 ~= nil and v4.l1
local v7, v8 = v5 ~= nil and v5.l0, v5 ~= nil and v5.l1
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
local getv13 = function()
    if v11 then
        local v12 = v6 == 1
        return v12
    else
        return false
    end
end
local v13 = getv13()
if v13 then
    return 0
else
    return 1
end
