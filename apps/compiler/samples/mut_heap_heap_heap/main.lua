local Heap0, Heap1, Heap2, Mut0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

local v0 = 3
local v1 = "no"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 1
local v4 = { __tag = "Heap1", l0 = v2, l1 = v3 }
local v5 = 2
local v6 = { __tag = "Heap2", l0 = v4, l1 = v5 }
local v7 = { __tag = "Mut0", l0 = v6 }
local v8 = 7
local v9 = "hi"
local v10 = { __tag = "Heap0", l0 = v8, l1 = v9 }
local v11 = 4
local v12 = { __tag = "Heap1", l0 = v10, l1 = v11 }
local v13 = 5
local v14 = { __tag = "Heap2", l0 = v12, l1 = v13 }
v7.l0 = v14
local v15 = v7 ~= nil and v7.l0
local v16, v17 = v15 ~= nil and v15.l0, v15 ~= nil and v15.l1
local v18, v19 = v16 ~= nil and v16.l0, v16 ~= nil and v16.l1
local v20, v21 = v18 ~= nil and v18.l0, v18 ~= nil and v18.l1
local v22 = v20 == 7
local getv24 = function()
    if v22 then
        local v23 = v21 == "hi"
        return v23
    else
        return false
    end
end
local v24 = getv24()
local getv26 = function()
    if v24 then
        local v25 = v19 == 4
        return v25
    else
        return false
    end
end
local v26 = getv26()
local getv28 = function()
    if v26 then
        local v27 = v17 == 5
        return v27
    else
        return false
    end
end
local v28 = getv28()
if v28 then
    return 0
else
    return 1
end
