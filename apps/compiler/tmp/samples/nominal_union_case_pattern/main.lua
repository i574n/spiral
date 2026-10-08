local Us0i0, Us0i1
function Us0i0() return { tag = "Us0i0" } end
function Us0i1() return { tag = "Us0i1" } end

local v0 = Us0i0()
local getv2 = function()
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0i1" then
        return false
    elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
        return true
    end
end
local v2 = getv2()
if v2 then
    return 0
else
    return 1
end
