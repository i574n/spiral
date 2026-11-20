local Heap0, Heap1
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 4
local v4 = "yo"
local v5 = { __tag = "Heap0", l0 = v3, l1 = v4 }
local v6 = { __tag = "Heap1", l0 = v2, l1 = v5 }
local v7 = {}
v7[(0)+1] = v6
local v8 = (v7)[(0)+1]
local v9, v10 = v8 ~= nil and v8.l0, v8 ~= nil and v8.l1
local v11, v12 = v9 ~= nil and v9.l0, v9 ~= nil and v9.l1
local v13, v14 = v10 ~= nil and v10.l0, v10 ~= nil and v10.l1
local v15 = v11 == 7
local getv17 = function()
    if v15 then
        local v16 = v12 == "hi"
        return v16
    else
        return false
    end
end
local v17 = getv17()
local getv19 = function()
    if v17 then
        local v18 = v13 == 4
        return v18
    else
        return false
    end
end
local v19 = getv19()
local getv21 = function()
    if v19 then
        local v20 = v14 == "yo"
        return v20
    else
        return false
    end
end
local v21 = getv21()
if v21 then
    return 0
else
    return 1
end
