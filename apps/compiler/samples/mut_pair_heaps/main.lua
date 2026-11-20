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
local v7 = 7
local v8 = "hi"
local v9 = { __tag = "Heap0", l0 = v7, l1 = v8 }
local v10 = 4
local v11 = "yo"
local v12 = { __tag = "Heap0", l0 = v10, l1 = v11 }
v6.l0 = v9
v6.l1 = v12
local v13, v14 = v6 ~= nil and v6.l0, v6 ~= nil and v6.l1
local v15, v16 = v13 ~= nil and v13.l0, v13 ~= nil and v13.l1
local v17, v18 = v14 ~= nil and v14.l0, v14 ~= nil and v14.l1
local v19 = v15 == 7
local getv21 = function()
    if v19 then
        local v20 = v16 == "hi"
        return v20
    else
        return false
    end
end
local v21 = getv21()
local getv23 = function()
    if v21 then
        local v22 = v17 == 4
        return v22
    else
        return false
    end
end
local v23 = getv23()
local getv25 = function()
    if v23 then
        local v24 = v18 == "yo"
        return v24
    else
        return false
    end
end
local v25 = getv25()
if v25 then
    return 0
else
    return 1
end
