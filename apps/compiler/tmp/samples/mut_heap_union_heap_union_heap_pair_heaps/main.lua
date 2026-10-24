local Heap0, Heap1, Heap2, Us0_None, Us0_Held, Heap3, Us1_Absent, Us1_Box, Heap4, Mut0, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

Heap3 = function(l0) return { __tag = "Heap3", l0 } end

function Us1_Absent() return { tag = "Us1_Absent" } end
function Us1_Box(v0) return { tag = "Us1_Box",  _1 = v0 } end

Heap4 = function(l0) return { __tag = "Heap4", l0 } end

Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us1_Absent" then
        return 1
    elseif v0 ~= nil and v0.tag == "Us1_Box" then
        local v1 = v0._1
        local v2 = v1 ~= nil and v1.l0
        if v2 ~= nil and v2.tag == "Us0_Held" then
            local v3 = v2._1
            local v4, v5 = v3 ~= nil and v3.l0, v3 ~= nil and v3.l1
            local v6, v7 = v4 ~= nil and v4.l0, v4 ~= nil and v4.l1
            local v8, v9 = v6 ~= nil and v6.l0, v6 ~= nil and v6.l1
            local v10, v11 = v7 ~= nil and v7.l0, v7 ~= nil and v7.l1
            local v12 = v8 == 7
            local getv14 = function()
                if v12 then
                    local v13 = v9 == "hi"
                    return v13
                else
                    return false
                end
            end
            local v14 = getv14()
            local getv16 = function()
                if v14 then
                    local v15 = v10 == 4
                    return v15
                else
                    return false
                end
            end
            local v16 = getv16()
            local getv18 = function()
                if v16 then
                    local v17 = v11 == "yo"
                    return v17
                else
                    return false
                end
            end
            local v18 = getv18()
            local getv20 = function()
                if v18 then
                    local v19 = v5 == 2
                    return v19
                else
                    return false
                end
            end
            local v20 = getv20()
            if v20 then
                return 0
            else
                return 1
            end
        elseif v2 ~= nil and v2.tag == "Us0_None" then
            return 1
        end
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
local v14 = true
local getv17 = function()
    if v14 then
        return Us1_Box(v13)
    else
        return Us1_Absent()
    end
end
local v17 = getv17()
local v18 = { __tag = "Heap4", l0 = v17 }
local v19 = { __tag = "Mut0", l0 = v18 }
local v20 = 7
local v21 = "hi"
local v22 = { __tag = "Heap0", l0 = v20, l1 = v21 }
local v23 = 4
local v24 = "yo"
local v25 = { __tag = "Heap0", l0 = v23, l1 = v24 }
local v26 = { __tag = "Heap1", l0 = v22, l1 = v25 }
local v27 = 2
local v28 = { __tag = "Heap2", l0 = v26, l1 = v27 }
local v29 = true
local getv32 = function()
    if v29 then
        return Us0_Held(v28)
    else
        return Us0_None()
    end
end
local v32 = getv32()
local v33 = { __tag = "Heap3", l0 = v32 }
local v34 = true
local getv37 = function()
    if v34 then
        return Us1_Box(v33)
    else
        return Us1_Absent()
    end
end
local v37 = getv37()
local v38 = { __tag = "Heap4", l0 = v37 }
v19.l0 = v38
local v39 = v19 ~= nil and v19.l0
local v40 = v39 ~= nil and v39.l0
return score_0(v40)
