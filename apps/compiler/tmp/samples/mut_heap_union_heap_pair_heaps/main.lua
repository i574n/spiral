local Heap0, Heap1, Heap2, Us0_None, Us0_Held, Heap3, Mut0, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

Heap3 = function(l0) return { __tag = "Heap3", l0 } end

Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
        local v1 = __v[1]._1
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
    elseif __v[1] ~= nil and __v[1].tag == "Us0_None" then
        return 1
    end
end

local v0 = 1
local v1 = "no"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 2
local v4 = "zz"
local v5 = { __tag = "Heap0", l0 = v3, l1 = v4 }
local v6 = { __tag = "Heap1", l0 = v2, l1 = v5 }
local v7 = 3
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
local v13 = { __tag = "Heap3", l0 = v12 }
local v14 = { __tag = "Mut0", l0 = v13 }
local v15 = 7
local v16 = "hi"
local v17 = { __tag = "Heap0", l0 = v15, l1 = v16 }
local v18 = 4
local v19 = "yo"
local v20 = { __tag = "Heap0", l0 = v18, l1 = v19 }
local v21 = { __tag = "Heap1", l0 = v17, l1 = v20 }
local v22 = 2
local v23 = { __tag = "Heap2", l0 = v21, l1 = v22 }
local v24 = true
local getv27 = function()
    if v24 then
        return Us0_Held(v23)
    else
        return Us0_None()
    end
end
local v27 = getv27()
local v28 = { __tag = "Heap3", l0 = v27 }
v14.l0 = v28
local v29 = v14 ~= nil and v14.l0
local v30 = v29 ~= nil and v29.l0
return score_0(v30)
