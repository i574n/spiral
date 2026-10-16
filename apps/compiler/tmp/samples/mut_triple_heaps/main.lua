local Heap0, Mut0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Mut0 = function(l0, l1, l2) return { __tag = "Mut0", l0 = l0, l1 = l1, l2 = l2 } end

local v0 = 1
local v1 = "no"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 2
local v4 = "zz"
local v5 = { __tag = "Heap0", l0 = v3, l1 = v4 }
local v6 = 3
local v7 = "aa"
local v8 = { __tag = "Heap0", l0 = v6, l1 = v7 }
local v9 = { __tag = "Mut0", l0 = v2, l1 = v5, l2 = v8 }
local v10 = 7
local v11 = "hi"
local v12 = { __tag = "Heap0", l0 = v10, l1 = v11 }
local v13 = 4
local v14 = "yo"
local v15 = { __tag = "Heap0", l0 = v13, l1 = v14 }
local v16 = 9
local v17 = "ok"
local v18 = { __tag = "Heap0", l0 = v16, l1 = v17 }
v9.l0 = v12
v9.l1 = v15
v9.l2 = v18
local v19, v20, v21 = v9 ~= nil and v9.l0, v9 ~= nil and v9.l1, v9 ~= nil and v9.l2
local v22, v23 = v19 ~= nil and v19.l0, v19 ~= nil and v19.l1
local v24, v25 = v20 ~= nil and v20.l0, v20 ~= nil and v20.l1
local v26, v27 = v21 ~= nil and v21.l0, v21 ~= nil and v21.l1
local v28 = v22 == 7
local getv30 = function()
    if v28 then
        local v29 = v23 == "hi"
        return v29
    else
        return false
    end
end
local v30 = getv30()
local getv32 = function()
    if v30 then
        local v31 = v24 == 4
        return v31
    else
        return false
    end
end
local v32 = getv32()
local getv34 = function()
    if v32 then
        local v33 = v25 == "yo"
        return v33
    else
        return false
    end
end
local v34 = getv34()
local getv36 = function()
    if v34 then
        local v35 = v26 == 9
        return v35
    else
        return false
    end
end
local v36 = getv36()
local getv38 = function()
    if v36 then
        local v37 = v27 == "ok"
        return v37
    else
        return false
    end
end
local v38 = getv38()
if v38 then
    return 0
else
    return 1
end
