local Heap0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

local v0 = (function(n) local t = {} for i = 1, n do t[i] = 0.0 end return t end)(1)
local v1 = 1.5
v0[(0)+1] = v1
local v2 = 7
local v3 = { __tag = "Heap0", l0 = v0, l1 = v2 }
local v4, v5 = v3 ~= nil and v3.l0, v3 ~= nil and v3.l1
local v6 = (v4)[(0)+1]
local v7 = v6 == 1.5
local getv9 = function()
    if v7 then
        local v8 = v5 == 7
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
