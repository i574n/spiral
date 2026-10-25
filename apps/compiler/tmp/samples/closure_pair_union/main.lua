local Us0_None, Us0_Some, f_c0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v1 == 0
        if v2 then
            local v3 = Us0_None()
            local v4 = Us0_None()
            return { [1]=v3, [2]=v4 }
        else
            local v5 = Us0_Some(v0)
            local v6 = Us0_None()
            return { [1]=v5, [2]=v6 }
        end
    end
end

local v0 = 7
local v1 = f_c0({ v0 })
local v2, v3 = (table.unpack or unpack)(v1(1))
if v2 ~= nil and v2.tag == "Us0_None" then
    return 1
elseif v2 ~= nil and v2.tag == "Us0_Some" then
    local v4 = v2._1
    if v3 ~= nil and v3.tag == "Us0_None" then
        local v5 = v4 == 7
        if v5 then
            return 0
        else
            return 1
        end
    elseif v3 ~= nil and v3.tag == "Us0_Some" then
        local v7 = v3._1
        return 1
    end
end
