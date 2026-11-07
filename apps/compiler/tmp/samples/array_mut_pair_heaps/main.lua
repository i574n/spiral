local Heap0, Mut0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Mut0 = function(l0, l1) return { __tag = "Mut0", l0 = l0, l1 = l1 } end

local v0 = 1
local v1 = "no"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 2
local v4 = "zz"
local v5 = { __tag = "Heap0", l0 = v3, l1 = v4 }
local v6 = { __tag = "Mut0", l0 = v2, l1 = v5 }
local v7 = {}
v7[(0)+1] = v6
local v8 = 7
local v9 = "hi"
local v10 = { __tag = "Heap0", l0 = v8, l1 = v9 }
local v11 = 4
local v12 = "yo"
local v13 = { __tag = "Heap0", l0 = v11, l1 = v12 }
local v14 = (v7)[(0)+1]
v14.l0 = v10
v14.l1 = v13
local v15, v16 = v14 ~= nil and v14.l0, v14 ~= nil and v14.l1
local v17, v18 = v15 ~= nil and v15.l0, v15 ~= nil and v15.l1
local v19, v20 = v16 ~= nil and v16.l0, v16 ~= nil and v16.l1
local v21 = v17 == 7
local getv23 = function()
    if v21 then
        local v22 = v18 == "hi"
        return v22
    else
        return false
    end
end
local v23 = getv23()
local getv25 = function()
    if v23 then
        local v24 = v19 == 4
        return v24
    else
        return false
    end
end
local v25 = getv25()
local getv27 = function()
    if v25 then
        local v26 = v20 == "yo"
        return v26
    else
        return false
    end
end
local v27 = getv27()
if v27 then
    return 0
else
    return 1
end
