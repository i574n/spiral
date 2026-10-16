local Heap0, Heap1, Heap2, f_c0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return v0
    end
end

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 4
local v4 = "yo"
local v5 = { __tag = "Heap0", l0 = v3, l1 = v4 }
local v6 = { __tag = "Heap1", l0 = v2, l1 = v5 }
local v7 = 2
local v8 = { __tag = "Heap2", l0 = v6, l1 = v7 }
local v9 = f_c0({ v8 })
local v10 = v9(1)
local v11, v12 = v10 ~= nil and v10.l0, v10 ~= nil and v10.l1
local v13, v14 = v11 ~= nil and v11.l0, v11 ~= nil and v11.l1
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
local getv27 = function()
    if v25 then
        local v26 = v12 == 2
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
