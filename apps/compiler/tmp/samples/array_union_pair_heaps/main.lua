local Heap0, Us0_None, Us0_Held, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0, v1) return { tag = "Us0_Held",  _1 = v0,  _2 = v1 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
        local v1 = __v[1]._1
        local v2 = __v[1]._2
        local v3, v4 = v1 ~= nil and v1.l0, v1 ~= nil and v1.l1
        local v5, v6 = v2 ~= nil and v2.l0, v2 ~= nil and v2.l1
        local v7 = v3 == 7
        local getv9 = function()
            if v7 then
                local v8 = v4 == "hi"
                return v8
            else
                return false
            end
        end
        local v9 = getv9()
        local getv11 = function()
            if v9 then
                local v10 = v5 == 4
                return v10
            else
                return false
            end
        end
        local v11 = getv11()
        local getv13 = function()
            if v11 then
                local v12 = v6 == "yo"
                return v12
            else
                return false
            end
        end
        local v13 = getv13()
        if v13 then
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
local v3 = 4
local v4 = "yo"
local v5 = { __tag = "Heap0", l0 = v3, l1 = v4 }
local v6 = {}
local v7 = true
local getv10 = function()
    if v7 then
        return Us0_Held(v2, v5)
    else
        return Us0_None()
    end
end
local v10 = getv10()
v6[(0)+1] = v10
local v11 = (v6)[(0)+1]
return score_0(v11)
