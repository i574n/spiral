local Heap0, Heap1, Heap2, Us0_None, Us0_Held, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Held" then
        local v1 = v0._1
        local v2, v3 = v1 ~= nil and v1.l0, v1 ~= nil and v1.l1
        local v4, v5 = v2 ~= nil and v2.l0, v2 ~= nil and v2.l1
        local v6, v7 = v4 ~= nil and v4.l0, v4 ~= nil and v4.l1
        local v8, v9 = v5 ~= nil and v5.l0, v5 ~= nil and v5.l1
        local v10 = v6 == 7
        local getv12 = function()
            if v10 then
                local v11 = v7 == "hi"
                return v11
            else
                return false
            end
        end
        local v12 = getv12()
        local getv14 = function()
            if v12 then
                local v13 = v8 == 4
                return v13
            else
                return false
            end
        end
        local v14 = getv14()
        local getv16 = function()
            if v14 then
                local v15 = v9 == "yo"
                return v15
            else
                return false
            end
        end
        local v16 = getv16()
        local getv18 = function()
            if v16 then
                local v17 = v3 == 2
                return v17
            else
                return false
            end
        end
        local v18 = getv18()
        if v18 then
            return 0
        else
            return 1
        end
    elseif v0 ~= nil and v0.tag == "Us0_None" then
        return 1
    end
end

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 4
local v4 = "yo"
local v5 = { __tag = "Heap0", l0 = v3, l1 = v4 }
local v6 = { __tag = "Heap1", l0 = v2, l1 = v5 }
local v7 = 2
local v8 = { __tag = "Heap2", l0 = v6, l1 = v7 }
local v9 = true
local getv12 = function()
    if v9 then
        return Us0_Held(v8)
    else
        return Us0_None()
    end
end
local v12 = getv12()
return score_0(v12)
