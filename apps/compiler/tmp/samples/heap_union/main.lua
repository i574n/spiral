local Us0_None, Us0_Some, Heap0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

Heap0 = function(l0) return { __tag = "Heap0", l0 } end

local v0 = 7
local v1 = true
local getv4 = function()
    if v1 then
        return Us0_Some(v0)
    else
        return Us0_None()
    end
end
local v4 = getv4()
local v5 = { __tag = "Heap0", l0 = v4 }
local v6 = v5 ~= nil and v5.l0
local __v = { v6 }
if __v[1] ~= nil and __v[1].tag == "Us0_None" then
    return 1
elseif __v[1] ~= nil and __v[1].tag == "Us0_Some" then
    local v7 = __v[1]._1
    local v8 = v7 == 7
    if v8 then
        return 0
    else
        return 1
    end
end
