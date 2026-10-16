local f_c0
function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v1 == 0
        if v2 then
            return { [1]=false, [2]=false }
        else
            return { [1]=v0, [2]=true }
        end
    end
end

local v0 = true
local v1 = f_c0({ v0 })
local v2, v3 = (table.unpack or unpack)(v1(1))
local v4 = (v2) and (v3)
if v4 then
    return 0
else
    return 1
end
