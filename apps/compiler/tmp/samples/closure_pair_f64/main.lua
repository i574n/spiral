local f_c0
function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v1 == 0
        if v2 then
            return { [1]=0.0, [2]=0.0 }
        else
            return { [1]=v0, [2]=2.5 }
        end
    end
end

local v0 = 1.5
local v1 = f_c0({ v0 })
local v2, v3 = (table.unpack or unpack)(v1(1))
local v4 = v2 == 1.5
local getv6 = function()
    if v4 then
        local v5 = v3 == 2.5
        return v5
    else
        return false
    end
end
local v6 = getv6()
if v6 then
    return 0
else
    return 1
end
