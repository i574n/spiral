local f_c0
function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v1 == 0
        if v2 then
            local v3 = "no"
            return { [1]=v3, [2]=v3 }
        else
            local v4 = "yo"
            return { [1]=v0, [2]=v4 }
        end
    end
end

local v0 = "hi"
local v1 = f_c0({ v0 })
local v2, v3 = (table.unpack or unpack)(v1(1))
local v4 = v2 == "hi"
local getv6 = function()
    if v4 then
        local v5 = v3 == "yo"
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
