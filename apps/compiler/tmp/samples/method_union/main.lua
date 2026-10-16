local Us0_None, Us0_Some, method0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

function method0(v0)
    local v1 = v0 == 0
    if v1 then
        return Us0_None()
    else
        return Us0_Some(v0)
    end
end

local v0 = 7
local v1 = method0(v0)
local __v = { v1 }
if __v[1] ~= nil and __v[1].tag == "Us0_None" then
    return 1
elseif __v[1] ~= nil and __v[1].tag == "Us0_Some" then
    local v2 = __v[1]._1
    local v3 = v2 == 7
    if v3 then
        return 0
    else
        return 1
    end
end
