local Us0_One, Us0_Both, f_c0
function Us0_One(v0) return { tag = "Us0_One",  _1 = v0 } end
function Us0_Both(v0, v1) return { tag = "Us0_Both",  _1 = v0,  _2 = v1 } end

function f_c0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 == 0
        if v3 then
            return Us0_One(0)
        else
            return Us0_Both(v0, v1)
        end
    end
end

local v0 = 3
local v1 = "hi"
local v2 = f_c0({ v0, v1 })
local v3 = v2(1)
if v3 ~= nil and v3.tag == "Us0_Both" then
    local v5 = v3._1
    local v6 = v3._2
    local v7 = v5 == 3
    local getv9 = function()
        if v7 then
            local v8 = v6 == "hi"
            return v8
        else
            return false
        end
    end
    local v9 = getv9()
    if v9 then
        return 0
    else
        return 1
    end
elseif v3 ~= nil and v3.tag == "Us0_One" then
    local v4 = v3._1
    return 1
end
