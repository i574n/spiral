local Heap0, Heap1, Mut0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

local v0 = 3
local v1 = "no"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 1
local v4 = { __tag = "Heap1", l0 = v2, l1 = v3 }
local v5 = { __tag = "Mut0", l0 = v4 }
local v6 = 7
local v7 = "hi"
local v8 = { __tag = "Heap0", l0 = v6, l1 = v7 }
local v9 = 4
local v10 = { __tag = "Heap1", l0 = v8, l1 = v9 }
v5.l0 = v10
local v11 = v5 ~= nil and v5.l0
local v12, v13 = v11 ~= nil and v11.l0, v11 ~= nil and v11.l1
local v14, v15 = v12 ~= nil and v12.l0, v12 ~= nil and v12.l1
local v16 = v14 == 7
local getv18 = function()
    if v16 then
        local v17 = v15 == "hi"
        return v17
    else
        return false
    end
end
local v18 = getv18()
local getv20 = function()
    if v18 then
        local v19 = v13 == 4
        return v19
    else
        return false
    end
end
local v20 = getv20()
if v20 then
    return 0
else
    return 1
end
