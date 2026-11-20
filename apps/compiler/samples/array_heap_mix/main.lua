local Heap0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = {}
v3[(0)+1] = v2
local v4 = (v3)[(0)+1]
local v5, v6 = v4 ~= nil and v4.l0, v4 ~= nil and v4.l1
local v7 = v5 == 7
local getv9 = function()
    if v7 then
        local v8 = v6 == "hi"
        return v8
    else
        return false
    end
end
local v9 = getv9()
if v9 then
    return 0
else
    return 1
end
