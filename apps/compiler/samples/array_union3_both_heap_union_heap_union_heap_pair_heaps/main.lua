local Heap0, Heap1, Heap2, Us0_None, Us0_Held, Heap3, Us1_Absent, Us1_Box, Us1_Mark, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

Heap3 = function(l0) return { __tag = "Heap3", l0 } end

function Us1_Absent() return { tag = "Us1_Absent" } end
function Us1_Box(v0) return { tag = "Us1_Box",  _1 = v0 } end
function Us1_Mark(v0) return { tag = "Us1_Mark",  _1 = v0 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us1_Absent" then
        return 1
    elseif v0 ~= nil and v0.tag == "Us1_Box" then
        local v3 = v0._1
        local v4 = v3 ~= nil and v3.l0
        if v4 ~= nil and v4.tag == "Us0_Held" then
            local v5 = v4._1
            local v6, v7 = v5 ~= nil and v5.l0, v5 ~= nil and v5.l1
            local v8, v9 = v6 ~= nil and v6.l0, v6 ~= nil and v6.l1
            local v10, v11 = v8 ~= nil and v8.l0, v8 ~= nil and v8.l1
            local v12, v13 = v9 ~= nil and v9.l0, v9 ~= nil and v9.l1
            local v14 = v10 == 7
            local getv16 = function()
                if v14 then
                    local v15 = v11 == "hi"
                    return v15
                else
                    return false
                end
            end
            local v16 = getv16()
            local getv18 = function()
                if v16 then
                    local v17 = v12 == 4
                    return v17
                else
                    return false
                end
            end
            local v18 = getv18()
            local getv20 = function()
                if v18 then
                    local v19 = v13 == "yo"
                    return v19
                else
                    return false
                end
            end
            local v20 = getv20()
            local getv22 = function()
                if v20 then
                    local v21 = v7 == 2
                    return v21
                else
                    return false
                end
            end
            local v22 = getv22()
            if v22 then
                return 0
            else
                return 1
            end
        elseif v4 ~= nil and v4.tag == "Us0_None" then
            return 1
        end
    elseif v0 ~= nil and v0.tag == "Us1_Mark" then
        local v1 = v0._1
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
local v13 = { __tag = "Heap3", l0 = v12 }
local v14 = true
local getv17 = function()
    if v14 then
        return Us1_Box(v13)
    else
        return Us1_Mark(1)
    end
end
local v17 = getv17()
local v18 = 3
local v19 = {}
v19[(0)+1] = v17
local v20 = Us1_Mark(v18)
v19[(1)+1] = v20
local v21 = (v19)[(0)+1]
local v22 = (v19)[(1)+1]
local v23 = score_0(v21)
local v24 = score_0(v22)
local v25 = v23 == 0
local getv27 = function()
    if v25 then
        local v26 = v24 == 1
        return v26
    else
        return false
    end
end
local v27 = getv27()
if v27 then
    return 0
else
    return 1
end
