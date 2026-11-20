local method1, method0
function method1(v0, v1, v2)
    return { [1]=v0, [2]=v1, [3]=v2 }
end

function method0(v0, v1, v2)
    local v3, v4, v5 = (table.unpack or unpack)(method1(v0, v1, v2))
    local v6 = v3 == 2
    local getv8 = function()
        if v6 then
            local v7 = v4 == 3
            return v7
        else
            return false
        end
    end
    local v8 = getv8()
    local getv10 = function()
        if v8 then
            local v9 = v5 == 1.5
            return v9
        else
            return false
        end
    end
    local v10 = getv10()
    if v10 then
        return 0
    else
        return 1
    end
end

local v0 = 2
local v1 = 3
local v2 = 1.5
return method0(v0, v1, v2)
