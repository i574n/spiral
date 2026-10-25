local Heap0, Heap1, Heap2, Us0_None, Us0_Held, Heap3, Us1_Absent, Us1_Box, Heap4, f_c0, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

Heap1 = function(l0, l1) return { __tag = "Heap1", l0, l1 } end

Heap2 = function(l0, l1) return { __tag = "Heap2", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0) return { tag = "Us0_Held",  _1 = v0 } end

Heap3 = function(l0) return { __tag = "Heap3", l0 } end

function Us1_Absent() return { tag = "Us1_Absent" } end
function Us1_Box(v0) return { tag = "Us1_Box",  _1 = v0 } end

Heap4 = function(l0) return { __tag = "Heap4", l0 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        return v0
    end
end

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
        return Us1_Absent()
    end
end
local v17 = getv17()
local v18 = { __tag = "Heap4", l0 = v17 }
local v19 = f_c0({ v18 })
local v20 = v19(1)
local v21 = v20 ~= nil and v20.l0
return score_0(v21)
