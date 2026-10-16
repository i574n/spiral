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
local v10 = {}
v10[(0)+1] = v9
local v11 = (v10)[(0)+1]
local v12, v13, v14 = v11 ~= nil and v11.l0, v11 ~= nil and v11.l1, v11 ~= nil and v11.l2
local v15, v16 = v12 ~= nil and v12.l0, v12 ~= nil and v12.l1
local v17, v18 = v13 ~= nil and v13.l0, v13 ~= nil and v13.l1
local v19, v20 = v14 ~= nil and v14.l0, v14 ~= nil and v14.l1
local v21 = v15 == 7
local getv23 = function()
    if v21 then
        local v22 = v16 == "hi"
        return v22
    else
        return false
    end
end
local v23 = getv23()
local getv25 = function()
    if v23 then
        local v24 = v17 == 4
        return v24
    else
        return false
    end
end
local v25 = getv25()
local getv27 = function()
    if v25 then
        local v26 = v18 == "yo"
        return v26
    else
        return false
    end
end
local v27 = getv27()
local getv29 = function()
    if v27 then
        local v28 = v19 == 9
        return v28
    else
        return false
    end
end
local v29 = getv29()
local getv31 = function()
    if v29 then
        local v30 = v20 == "ok"
        return v30
    else
        return false
    end
end
local v31 = getv31()
if v31 then
    return 0
else
    return 1
end
