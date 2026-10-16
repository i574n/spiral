local Us0_None, Us0_Some, f_c0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v1 == 0
        if v2 then
            local v3 = Us0_None()
            return { [1]=v3, [2]=0 }
        else
            local v4 = Us0_Some(v0)
            return { [1]=v4, [2]=v0 }
        end
    end
end

local v0 = 7
local v1 = f_c0({ v0 })
local v2, v3 = (table.unpack or unpack)(v1(1))
local __v = { v2 }
if __v[1] ~= nil and __v[1].tag == "Us0_None" then
    return 1
elseif __v[1] ~= nil and __v[1].tag == "Us0_Some" then
    local v4 = __v[1]._1
    local v5 = v4 == 7
    local getv7 = function()
        if v5 then
            local v6 = v3 == 7
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
end
