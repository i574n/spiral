local Us0_One, Us0_Both, method0
function Us0_One(v0) return { tag = "Us0_One",  _1 = v0 } end
function Us0_Both(v0, v1) return { tag = "Us0_Both",  _1 = v0,  _2 = v1 } end

function method0(v0, v1)
    local v2 = v0 == 0
    if v2 then
        return Us0_One(0)
    else
        return Us0_Both(v0, v1)
    end
end

local v0 = 3
local v1 = "hi"
local v2 = method0(v0, v1)
if v2 ~= nil and v2.tag == "Us0_Both" then
    local v4 = v2._1
    local v5 = v2._2
    local v6 = v4 == 3
    local getv8 = function()
        if v6 then
            local v7 = v5 == "hi"
            return v7
        else
            return false
        end
    end
    local v8 = getv8()
    if v8 then
        return 0
    else
        return 1
    end
elseif v2 ~= nil and v2.tag == "Us0_One" then
    local v3 = v2._1
    return 1
end
