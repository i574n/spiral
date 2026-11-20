local Heap0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

local v0 = 100
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3, v4 = v2 ~= nil and v2.l0, v2 ~= nil and v2.l1
local v5 = v3 == 100
local getv7 = function()
    if v5 then
        local v6 = v4 == "hi"
        return v6
    else
        return false
    end
end
local v7 = getv7()
if v7 then
    return 0
else
    return 1
end
