local f_c0
function f_c0(capt)
    local v0, v1, v2 = (table.unpack or unpack)(capt)
    return function(v3)
        local v4 = v3 == 0
        if v4 then
            local v5 = "no"
            return { [1]=0, [2]=v5, [3]=false }
        else
            return { [1]=v0, [2]=v1, [3]=v2 }
        end
    end
end

local v0 = 4000000000
local v1 = "hi"
local v2 = true
local v3 = f_c0({ v0, v1, v2 })
local v4, v5, v6 = (table.unpack or unpack)(v3(1))
local v7 = v4 == 4000000000
local getv9 = function()
    if v7 then
        local v8 = v5 == "hi"
        return v8
    else
        return false
    end
end
local v9 = getv9()
local v10 = (v9) and (v6)
if v10 then
    return 0
else
    return 1
end
