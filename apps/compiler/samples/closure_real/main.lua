local f_c0
function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v1 == 0
        if v2 then
            return 0.0
        else
            return v0
        end
    end
end

local v0 = 1.5
local v1 = f_c0({ v0 })
local v2 = v1(1)
local v3 = v2 == 1.5
if v3 then
    return 0
else
    return 1
end
