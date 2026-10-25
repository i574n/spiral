local Heap0, Heap1, Us0_None, Us0_Held, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
        local v1 = __v[1]._1
        local v2, v3 = v1 ~= nil and v1.l0, v1 ~= nil and v1.l1
        local v4, v5 = v2 ~= nil and v2.l0, v2 ~= nil and v2.l1
        local v6 = v4 == 7
        local getv8 = function()
            if v6 then
                local v7 = v5 == "hi"
                return v7
            else
                return false
            end
        end
        local v8 = getv8()
        local getv10 = function()
            if v8 then
                local v9 = v3 == 1
                return v9
            else
                return false
            end
        end
        local v10 = getv10()
        if v10 then
            return 0
        else
            return 1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0_None" then
        return 1
    end
end

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 1
local v4 = { __tag = "Heap1", l0 = v2, l1 = v3 }
local v5 = {}
local v6 = true
local getv9 = function()
    if v6 then
        return Us0_Held(v4)
    else
        return Us0_None()
    end
end
local v9 = getv9()
v5[(0)+1] = v9
local v10 = (v5)[(0)+1]
return score_0(v10)
