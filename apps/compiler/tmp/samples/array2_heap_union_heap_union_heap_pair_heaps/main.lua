local Heap0, Heap1, Heap2, Us0_None, Us0_Held, Heap3, Us1_Absent, Us1_Box, Heap4, score_0, score_b_1
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

Heap3 = function(l0) return { __tag = "Heap3", l0 } end

function Us1_Absent() return { tag = "Us1_Absent" } end
function Us1_Box(v0) return { tag = "Us1_Box",  _1 = v0 } end

Heap4 = function(l0) return { __tag = "Heap4", l0 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us1_Absent" then
        return 1
    elseif __v[1] ~= nil and __v[1].tag == "Us1_Box" then
        local v1 = __v[1]._1
        local v2 = v1 ~= nil and v1.l0
        local __v = { v2 }
        if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
            local v3 = __v[1]._1
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
        elseif __v[1] ~= nil and __v[1].tag == "Us0_None" then
            return 1
        end
    end
end

function score_b_1(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us1_Absent" then
        return 1
    elseif __v[1] ~= nil and __v[1].tag == "Us1_Box" then
        local v1 = __v[1]._1
        local v2 = v1 ~= nil and v1.l0
        local __v = { v2 }
        if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
            local v3 = __v[1]._1
            local v4, v5 = v3 ~= nil and v3.l0, v3 ~= nil and v3.l1
            local v6, v7 = v4 ~= nil and v4.l0, v4 ~= nil and v4.l1
            local v8, v9 = v6 ~= nil and v6.l0, v6 ~= nil and v6.l1
            local v10, v11 = v7 ~= nil and v7.l0, v7 ~= nil and v7.l1
            local v12 = v8 == 8
            local getv14 = function()
                if v12 then
                    local v13 = v9 == "ok"
                    return v13
                else
                    return false
                end
            end
            local v14 = getv14()
            local getv16 = function()
                if v14 then
                    local v15 = v10 == 5
                    return v15
                else
                    return false
                end
            end
            local v16 = getv16()
            local getv18 = function()
                if v16 then
                    local v17 = v11 == "no"
                    return v17
                else
                    return false
                end
            end
            local v18 = getv18()
            local getv20 = function()
                if v18 then
                    local v19 = v5 == 9
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
        elseif __v[1] ~= nil and __v[1].tag == "Us0_None" then
            return 1
        end
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
local v9 = Us0_Held(v8)
local v10 = { __tag = "Heap3", l0 = v9 }
local v11 = Us1_Box(v10)
local v12 = { __tag = "Heap4", l0 = v11 }
local v13 = 8
local v14 = "ok"
local v15 = { __tag = "Heap0", l0 = v13, l1 = v14 }
local v16 = 5
local v17 = "no"
local v18 = { __tag = "Heap0", l0 = v16, l1 = v17 }
local v19 = { __tag = "Heap1", l0 = v15, l1 = v18 }
local v20 = 9
local v21 = { __tag = "Heap2", l0 = v19, l1 = v20 }
local v22 = Us0_Held(v21)
local v23 = { __tag = "Heap3", l0 = v22 }
local v24 = Us1_Box(v23)
local v25 = { __tag = "Heap4", l0 = v24 }
local v26 = {}
v26[(0)+1] = v12
v26[(1)+1] = v25
local v27 = (v26)[(0)+1]
local v28 = (v26)[(1)+1]
local v29 = v27 ~= nil and v27.l0
local v30 = v28 ~= nil and v28.l0
local v31 = score_0(v29)
local v32 = score_b_1(v30)
local v33 = v31 == 0
local getv35 = function()
    if v33 then
        local v34 = v32 == 0
        return v34
    else
        return false
    end
end
local v35 = getv35()
if v35 then
    return 0
else
    return 1
end
