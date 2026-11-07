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
local v10 = {}
v10[(0)+1] = v9
local v11 = 7
local v12 = "hi"
local v13 = { __tag = "Heap0", l0 = v11, l1 = v12 }
local v14 = 4
local v15 = "yo"
local v16 = { __tag = "Heap0", l0 = v14, l1 = v15 }
local v17 = 9
local v18 = "ok"
local v19 = { __tag = "Heap0", l0 = v17, l1 = v18 }
local v20 = (v10)[(0)+1]
v20.l0 = v13
v20.l1 = v16
v20.l2 = v19
local v21, v22, v23 = v20 ~= nil and v20.l0, v20 ~= nil and v20.l1, v20 ~= nil and v20.l2
local v24, v25 = v21 ~= nil and v21.l0, v21 ~= nil and v21.l1
local v26, v27 = v22 ~= nil and v22.l0, v22 ~= nil and v22.l1
local v28, v29 = v23 ~= nil and v23.l0, v23 ~= nil and v23.l1
local v30 = v24 == 7
local getv32 = function()
    if v30 then
        local v31 = v25 == "hi"
        return v31
    else
        return false
    end
end
local v32 = getv32()
local getv34 = function()
    if v32 then
        local v33 = v26 == 4
        return v33
    else
        return false
    end
end
local v34 = getv34()
local getv36 = function()
    if v34 then
        local v35 = v27 == "yo"
        return v35
    else
        return false
    end
end
local v36 = getv36()
local getv38 = function()
    if v36 then
        local v37 = v28 == 9
        return v37
    else
        return false
    end
end
local v38 = getv38()
local getv40 = function()
    if v38 then
        local v39 = v29 == "ok"
        return v39
    else
        return false
    end
end
local v40 = getv40()
if v40 then
    return 0
else
    return 1
end
