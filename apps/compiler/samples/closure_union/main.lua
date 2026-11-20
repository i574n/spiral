local Us0_None, Us0_Some, f_c0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v1 == 0
        if v2 then
            return Us0_None()
        else
            return Us0_Some(v0)
        end
    end
end

local v0 = 7
local v1 = f_c0({ v0 })
local v2 = v1(1)
if v2 ~= nil and v2.tag == "Us0_None" then
    return 1
elseif v2 ~= nil and v2.tag == "Us0_Some" then
    local v3 = v2._1
    local v4 = v3 == 7
    if v4 then
        return 0
    else
        return 1
    end
end
