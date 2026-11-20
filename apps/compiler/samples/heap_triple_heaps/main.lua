local Heap0, Heap1
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1, l2) return { __tag = "Heap1", l0, l1, l2 } end

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 4
local v4 = "yo"
local v5 = { __tag = "Heap0", l0 = v3, l1 = v4 }
local v6 = 9
local v7 = "ok"
local v8 = { __tag = "Heap0", l0 = v6, l1 = v7 }
local v9 = { __tag = "Heap1", l0 = v2, l1 = v5, l2 = v8 }
local v10, v11, v12 = v9 ~= nil and v9.l0, v9 ~= nil and v9.l1, v9 ~= nil and v9.l2
local v13, v14 = v10 ~= nil and v10.l0, v10 ~= nil and v10.l1
local v15, v16 = v11 ~= nil and v11.l0, v11 ~= nil and v11.l1
local v17, v18 = v12 ~= nil and v12.l0, v12 ~= nil and v12.l1
local v19 = v13 == 7
local getv21 = function()
    if v19 then
        local v20 = v14 == "hi"
        return v20
    else
        return false
    end
end
local v21 = getv21()
local getv23 = function()
    if v21 then
        local v22 = v15 == 4
        return v22
    else
        return false
    end
end
local v23 = getv23()
local getv25 = function()
    if v23 then
        local v24 = v16 == "yo"
        return v24
    else
        return false
    end
end
local v25 = getv25()
local getv27 = function()
    if v25 then
        local v26 = v17 == 9
        return v26
    else
        return false
    end
end
local v27 = getv27()
local getv29 = function()
    if v27 then
        local v28 = v18 == "ok"
        return v28
    else
        return false
    end
end
local v29 = getv29()
if v29 then
    return 0
else
    return 1
end
