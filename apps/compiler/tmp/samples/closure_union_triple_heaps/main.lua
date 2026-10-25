local Heap0, Us0_None, Us0_Held, f_c0, score_0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0, v1, v2) return { tag = "Us0_Held",  _1 = v0,  _2 = v1,  _3 = v2 } end

function f_c0(capt)
    local v0, v1, v2 = (table.unpack or unpack)(capt)
    return function(v3)
        local v4 = v3 == 0
        if v4 then
            return Us0_None()
        else
            return Us0_Held(v0, v1, v2)
        end
    end
end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
        local v1 = __v[1]._1
        local v2 = __v[1]._2
        local v3 = __v[1]._3
        local v4, v5 = v1 ~= nil and v1.l0, v1 ~= nil and v1.l1
        local v6, v7 = v2 ~= nil and v2.l0, v2 ~= nil and v2.l1
        local v8, v9 = v3 ~= nil and v3.l0, v3 ~= nil and v3.l1
        local v10 = v4 == 7
        local getv12 = function()
            if v10 then
                local v11 = v5 == "hi"
                return v11
            else
                return false
            end
        end
        local v12 = getv12()
        local getv14 = function()
            if v12 then
                local v13 = v6 == 4
                return v13
            else
                return false
            end
        end
        local v14 = getv14()
        local getv16 = function()
            if v14 then
                local v15 = v7 == "yo"
                return v15
            else
                return false
            end
        end
        local v16 = getv16()
        local getv18 = function()
            if v16 then
                local v17 = v8 == 9
                return v17
            else
                return false
            end
        end
        local v18 = getv18()
        local getv20 = function()
            if v18 then
                local v19 = v9 == "ok"
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

local v0 = 7
local v1 = "hi"
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3 = 4
local v4 = "yo"
local v5 = { __tag = "Heap0", l0 = v3, l1 = v4 }
local v6 = 9
local v7 = "ok"
local v8 = { __tag = "Heap0", l0 = v6, l1 = v7 }
local v9 = f_c0({ v2, v5, v8 })
local v10 = v9(1)
return score_0(v10)
