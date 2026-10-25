local Us0_None, Us0_Some, method0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

function method0(v0)
    local v1 = v0 == 0
    if v1 then
        local v2 = Us0_None()
        local v3 = Us0_None()
        return { [1]=v2, [2]=v3 }
    else
        local v4 = Us0_Some(v0)
        local v5 = Us0_None()
        return { [1]=v4, [2]=v5 }
    end
end

local v0 = 7
local v1, v2 = (table.unpack or unpack)(method0(v0))
if v1 ~= nil and v1.tag == "Us0_None" then
    return 1
elseif v1 ~= nil and v1.tag == "Us0_Some" then
    local v3 = v1._1
    if v2 ~= nil and v2.tag == "Us0_None" then
        local v4 = v3 == 7
        if v4 then
            return 0
        else
            return 1
        end
    elseif v2 ~= nil and v2.tag == "Us0_Some" then
        local v6 = v2._1
        return 1
    end
end
