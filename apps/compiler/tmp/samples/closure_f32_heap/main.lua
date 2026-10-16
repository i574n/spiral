local Heap0, f_c0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return v0
    end
end

local v0 = 1.5
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = f_c0({ v2 })
local v4 = v3(1)
local v5, v6 = v4 ~= nil and v4.l0, v4 ~= nil and v4.l1
local v7 = v5 == 1.5
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
