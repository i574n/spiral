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
if v5 ~= nil and v5.tag == "Us0_None" then
    return 1
elseif v5 ~= nil and v5.tag == "Us0_Some" then
    local v6 = v5._1
    local v7 = (v1)[(1)+1]
    if v7 ~= nil and v7.tag == "Us0_None" then
        local v8 = v6 == 7
        if v8 then
            return 0
        else
            return 1
        end
    elseif v7 ~= nil and v7.tag == "Us0_Some" then
        local v10 = v7._1
        return 1
    end
end
