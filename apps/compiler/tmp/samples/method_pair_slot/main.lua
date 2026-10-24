local Us0_None, Us0_Some, method0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

function method0(v0)
    local v1 = v0 == 0
    if v1 then
        local v2 = Us0_None()
        return { [1]=v2, [2]=0 }
    else
        local v3 = Us0_Some(v0)
        return { [1]=v3, [2]=v0 }
    end
end

local v0 = 7
local v1, v2 = (table.unpack or unpack)(method0(v0))
if v1 ~= nil and v1.tag == "Us0_None" then
    return 1
elseif v1 ~= nil and v1.tag == "Us0_Some" then
    local v3 = v1._1
    local v4 = v3 == 7
    local getv6 = function()
        if v4 then
            local v5 = v2 == 7
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
end
