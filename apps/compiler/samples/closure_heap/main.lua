local Heap0, f_c0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return v0
    end
end

local v0 = 7
local v1 = { __tag = "Heap0", l0 = v0 }
local v2 = f_c0({ v1 })
local v3 = v2(1)
local v4 = v3 ~= nil and v3.l0
local v5 = v4 == 7
if v5 then
    return 0
else
    return 1
end
