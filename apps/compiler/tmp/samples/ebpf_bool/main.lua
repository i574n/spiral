local method0, method1, method2
function method0(v0)
    if v0 then
        return 1
    else
        return 3
    end
end

function method1(v0, v1)
    local v2 = (v0) and (v1)
    if v2 then
        return 1
    else
        local v3 = (v0) or (v1)
        if v3 then
            return 2
        else
            return 3
        end
    end
end

function method2(v0)
    if v0 then
        return 1
    else
        return 3
    end
end

local v0 = true
local v1 = false
local v2 = method0(v0)
local v3 = method1(v0, v1)
local v4 = method2(v1)
local v5 = v0 == v1
local v6 = v5 == false
local v7 = v2 == 1
local getv9 = function()
    if v7 then
        local v8 = v3 == 2
        return v8
    else
        return false
    end
end
local v9 = getv9()
local getv11 = function()
    if v9 then
        local v10 = v4 == 3
        return v10
    else
        return false
    end
end
local v11 = getv11()
local v12 = (v11) and (v6)
if v12 then
    return 0
else
    return 1
end
