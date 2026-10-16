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
local v6 = {}
v6[(0)+1] = v5
local v7 = 7
local v8 = "hi"
local v9 = { __tag = "Heap0", l0 = v7, l1 = v8 }
local v10 = 4
local v11 = { __tag = "Heap1", l0 = v9, l1 = v10 }
local v12 = (v6)[(0)+1]
v12.l0 = v11
local v13 = v12 ~= nil and v12.l0
local v14, v15 = v13 ~= nil and v13.l0, v13 ~= nil and v13.l1
local v16, v17 = v14 ~= nil and v14.l0, v14 ~= nil and v14.l1
local v18 = v16 == 7
local getv20 = function()
    if v18 then
        local v19 = v17 == "hi"
        return v19
    else
        return false
    end
end
local v20 = getv20()
local getv22 = function()
    if v20 then
        local v21 = v15 == 4
        return v21
    else
        return false
    end
end
local v22 = getv22()
if v22 then
    return 0
else
    return 1
end
