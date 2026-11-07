local Heap0, Heap1, Heap2, Us0_None, Us0_Held, Heap3, Us1_Absent, Us1_Box, Us1_Mark, Heap4, Mut0, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

Heap3 = function(l0) return { __tag = "Heap3", l0 } end

function Us1_Absent() return { tag = "Us1_Absent" } end
function Us1_Box(v0) return { tag = "Us1_Box",  _1 = v0 } end
function Us1_Mark(v0) return { tag = "Us1_Mark",  _1 = v0 } end

Heap4 = function(l0) return { __tag = "Heap4", l0 } end

Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

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
local v19 = { __tag = "Heap4", l0 = v17 }
local v20 = Us1_Mark(v18)
local v21 = { __tag = "Heap4", l0 = v20 }
local v22 = { __tag = "Mut0", l0 = v19 }
local v23 = {}
v23[(0)+1] = v22
local v24 = (v23)[(0)+1]
local v25 = v24 ~= nil and v24.l0
local v26 = v25 ~= nil and v25.l0
local v27 = score_0(v26)
v24.l0 = v21
local v28 = v24 ~= nil and v24.l0
local v29 = v28 ~= nil and v28.l0
local v30 = score_0(v29)
local v31 = v27 == 0
local getv33 = function()
    if v31 then
        local v32 = v30 == 1
        return v32
    else
        return false
    end
end
local v33 = getv33()
if v33 then
    return 0
else
    return 1
end
