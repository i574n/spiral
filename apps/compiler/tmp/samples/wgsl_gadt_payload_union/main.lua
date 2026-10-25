local Us0_Living, Us1_Survived, Us1_Slain, Us2_Fallen
function Us0_Living(v0, v1) return { tag = "Us0_Living",  _1 = v0,  _2 = v1 } end

function Us1_Survived(v0) return { tag = "Us1_Survived",  _1 = v0 } end
function Us1_Slain(v0) return { tag = "Us1_Slain",  _1 = v0 } end

function Us2_Fallen(v0) return { tag = "Us2_Fallen",  _1 = v0 } end

local v0 = 60
local v1 = v0 > 0
local getv6 = function()
    if v1 then
        local v2 = Us0_Living(v0, 100)
        return Us1_Survived(v2)
    else
        local v4 = Us2_Fallen(100)
        return Us1_Slain(v4)
    end
end
local v6 = getv6()
local __v = { v6 }
if __v[1] ~= nil and __v[1].tag == "Us1_Slain" then
    local v13 = __v[1]._1
    return 2
elseif __v[1] ~= nil and __v[1].tag == "Us1_Survived" then
    local v7 = __v[1]._1
    local __v = { v7 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Living" then
        local v8 = __v[1]._1
        local v9 = __v[1]._2
        local v10 = v8 == 60
        if v10 then
            return 0
        else
            return 1
        end
    end
end
