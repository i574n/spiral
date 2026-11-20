local Us0_Vowel, Uh0_Cons, method0
function Us0_Vowel(v0) return { tag = "Us0_Vowel",  _1 = v0 } end

Uh0_Nil = (function() local shared = { tag = "Uh0_Nil" } return function() return shared end end)()
function Uh0_Cons(v0, v1) return { tag = "Uh0_Cons",  _1 = v0,  _2 = v1 } end

function method0(v0, v1)
    local __v = { v1, v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0_Cons" and __v[2] ~= nil and __v[2].tag == "Uh0_Cons" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = __v[2]._1
        local v5 = __v[2]._2
        local getv9 = function()
            local __v = { v2, v4 }
            if __v[1] ~= nil and __v[1].tag == "Us0_Vowel" and __v[2] ~= nil and __v[2].tag == "Us0_Vowel" then
                local v6 = __v[1]._1
                local v7 = __v[2]._1
                local v8 = v6 == v7
                return v8
            else
                return false
            end
        end
        local v9 = getv9()
        if v9 then
            return method0(v5, v3)
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh0_Nil" and __v[2] ~= nil and __v[2].tag == "Uh0_Nil" then
        return true
    else
        return false
    end
end

local v0 = 1
local v1 = Us0_Vowel(v0)
local v2 = 1
local v3 = Us0_Vowel(v2)
local v4 = 2
local v5 = Us0_Vowel(v4)
local v6 = Uh0_Nil()
local v7 = Uh0_Cons(v5, v6)
local v8 = Uh0_Cons(v1, v7)
local v9 = Uh0_Nil()
local v10 = Uh0_Cons(v5, v9)
local v11 = Uh0_Cons(v3, v10)
local v12 = Uh0_Nil()
local v13 = Uh0_Cons(v1, v12)
local getv17 = function()
    local __v = { v1, v3 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Vowel" and __v[2] ~= nil and __v[2].tag == "Us0_Vowel" then
        local v14 = __v[1]._1
        local v15 = __v[2]._1
        local v16 = v14 == v15
        return v16
    else
        return false
    end
end
local v17 = getv17()
local getv23 = function()
    if v17 then
        local getv21 = function()
            local __v = { v1, v5 }
            if __v[1] ~= nil and __v[1].tag == "Us0_Vowel" and __v[2] ~= nil and __v[2].tag == "Us0_Vowel" then
                local v18 = __v[1]._1
                local v19 = __v[2]._1
                local v20 = v18 == v19
                return v20
            else
                return false
            end
        end
        local v21 = getv21()
        local v22 = v21 == false
        return v22
    else
        return false
    end
end
local v23 = getv23()
local getv30 = function()
    if v23 then
        local getv27 = function()
            local __v = { v1, v3 }
            if __v[1] ~= nil and __v[1].tag == "Us0_Vowel" and __v[2] ~= nil and __v[2].tag == "Us0_Vowel" then
                local v24 = __v[1]._1
                local v25 = __v[2]._1
                local v26 = v24 == v25
                return v26
            else
                return false
            end
        end
        local v27 = getv27()
        if v27 then
            return method0(v11, v8)
        else
            return false
        end
    else
        return false
    end
end
local v30 = getv30()
local getv38 = function()
    if v30 then
        local getv34 = function()
            local __v = { v1, v5 }
            if __v[1] ~= nil and __v[1].tag == "Us0_Vowel" and __v[2] ~= nil and __v[2].tag == "Us0_Vowel" then
                local v31 = __v[1]._1
                local v32 = __v[2]._1
                local v33 = v31 == v32
                return v33
            else
                return false
            end
        end
        local v34 = getv34()
        local getv36 = function()
            if v34 then
                return method0(v13, v8)
            else
                return false
            end
        end
        local v36 = getv36()
        local v37 = v36 == false
        return v37
    else
        return false
    end
end
local v38 = getv38()
if v38 then
    return 0
else
    return 1
end
