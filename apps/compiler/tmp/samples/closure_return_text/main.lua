local g_c1, f_c0
function g_c1(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v1 == 0
        if v3 then
            local v4 = "no"
            return v4
        else
            return v0
        end
    end
end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return g_c1({ v0, v1 })
    end
end

local v0 = "hi"
local v1 = f_c0({ v0 })
local v2 = v1(1)
local v3 = v2(0)
local v4 = v3 == "hi"
if v4 then
    return 0
else
    return 1
end
