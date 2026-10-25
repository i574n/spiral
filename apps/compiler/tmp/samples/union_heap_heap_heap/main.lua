local Heap0, Heap1, Heap2, Us0_None, Us0_Held, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
        local v1 = __v[1]._1
        local v2, v3 = v1 ~= nil and v1.l0, v1 ~= nil and v1.l1
        local v4, v5 = v2 ~= nil and v2.l0, v2 ~= nil and v2.l1
        local v6, v7 = v4 ~= nil and v4.l0, v4 ~= nil and v4.l1
        local v8 = v6 == 7
        local getv10 = function()
            if v8 then
                local v9 = v7 == "hi"
                return v9
            else
                return false
            end
        end
        local v10 = getv10()
        local getv12 = function()
            if v10 then
                local v11 = v5 == 1
                return v11
            else
                return false
            end
        end
        local v12 = getv12()
        local getv14 = function()
            if v12 then
                local v13 = v3 == 2
                return v13
            else
                return false
            end
        end
        local v14 = getv14()
        if v14 then
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
local v5 = 2
local v6 = { __tag = "Heap2", l0 = v4, l1 = v5 }
local v7 = true
local getv10 = function()
    if v7 then
        return Us0_Held(v6)
    else
        return Us0_None()
    end
end
local v10 = getv10()
return score_0(v10)
