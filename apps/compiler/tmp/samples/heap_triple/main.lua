local Heap0
Heap0 = function(l0, l1, l2) return { __tag = "Heap0", l0, l1, l2 } end

local v0 = 7
local v1 = "hi"
local v2 = true
local v3 = { __tag = "Heap0", l0 = v0, l1 = v1, l2 = v2 }
local v4, v5, v6 = v3 ~= nil and v3.l0, v3 ~= nil and v3.l1, v3 ~= nil and v3.l2
local v7 = v4 == 7
local getv9 = function()
    if v7 then
        local v8 = v5 == "hi"
        return v8
    else
        return false
    end
end
local v9 = getv9()
local v10 = (v9) and (v6)
if v10 then
    return 0
else
    return 1
end
