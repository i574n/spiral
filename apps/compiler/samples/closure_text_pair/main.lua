local f_c0
function f_c0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 == 0
        if v3 then
            local v4 = "no"
            local v5 = "nay"
            return { [1]=v4, [2]=v5 }
        else
            return { [1]=v0, [2]=v1 }
        end
    end
end

local v0 = "hi"
local v1 = "yo"
local v2 = f_c0({ v0, v1 })
local v3, v4 = (table.unpack or unpack)(v2(1))
local v5 = v3 == "hi"
local getv7 = function()
    if v5 then
        local v6 = v4 == "yo"
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
