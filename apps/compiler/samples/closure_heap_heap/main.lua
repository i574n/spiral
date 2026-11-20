local Heap0, Heap1, f_c0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return v0
    end
end

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 1
local v4 = { __tag = "Heap1", l0 = v2, l1 = v3 }
local v5 = f_c0({ v4 })
local v6 = v5(1)
local v7, v8 = v6 ~= nil and v6.l0, v6 ~= nil and v6.l1
local v9, v10 = v7 ~= nil and v7.l0, v7 ~= nil and v7.l1
local v11 = v9 == 7
local getv13 = function()
    if v11 then
        local v12 = v10 == "hi"
        return v12
    else
        return false
    end
end
local v13 = getv13()
local getv15 = function()
    if v13 then
        local v14 = v8 == 1
        return v14
    else
        return false
    end
end
local v15 = getv15()
if v15 then
    return 0
else
    return 1
end
