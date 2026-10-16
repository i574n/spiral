local Heap0, g_c1, f_c0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function g_c1(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v0 ~= nil and v0.l0
        local v4 = v1 == 0
        if v4 then
            return 0
        else
            return v3
        end
    end
end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return g_c1({ v0, v1 })
    end
end

local v0 = 7
local v1 = { __tag = "Heap0", l0 = v0 }
local v2 = f_c0({ v1 })
local v3 = v2(1)
local v4 = v3(0)
local v5 = v4 == 7
if v5 then
    return 0
else
    return 1
end
