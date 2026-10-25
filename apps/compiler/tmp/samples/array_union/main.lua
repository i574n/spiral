local Us0_None, Us0_Some
function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

local v0 = 2
local v1 = {}
local v2 = 7
local v3 = Us0_Some(v2)
v1[(0)+1] = v3
local v4 = Us0_None()
v1[(1)+1] = v4
local v5 = (v1)[(0)+1]
local __v = { v5 }
if __v[1] ~= nil and __v[1].tag == "Us0_None" then
    return 1
elseif __v[1] ~= nil and __v[1].tag == "Us0_Some" then
    local v6 = __v[1]._1
    local v7 = (v1)[(1)+1]
    local __v = { v7 }
    if __v[1] ~= nil and __v[1].tag == "Us0_None" then
        local v8 = v6 == 7
        if v8 then
            return 0
        else
            return 1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Some" then
        local v10 = __v[1]._1
        return 1
    end
end
