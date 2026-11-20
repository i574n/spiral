local Heap0, Heap1, Heap2
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 1
local v4 = { __tag = "Heap1", l0 = v2, l1 = v3 }
local v5 = 2
local v6 = { __tag = "Heap2", l0 = v4, l1 = v5 }
local v7, v8 = v6 ~= nil and v6.l0, v6 ~= nil and v6.l1
local v9, v10 = v7 ~= nil and v7.l0, v7 ~= nil and v7.l1
local v11, v12 = v9 ~= nil and v9.l0, v9 ~= nil and v9.l1
local v13 = v11 == 7
local getv15 = function()
    if v13 then
        local v14 = v12 == "hi"
        return v14
    else
        return false
    end
end
local v15 = getv15()
local getv17 = function()
    if v15 then
        local v16 = v10 == 1
        return v16
    else
        return false
    end
end
local v17 = getv17()
local getv19 = function()
    if v17 then
        local v18 = v8 == 2
        return v18
    else
        return false
    end
end
local v19 = getv19()
if v19 then
    return 0
else
    return 1
end
