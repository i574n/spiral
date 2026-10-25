local Us0_Text, Us0_Code, score_0
function Us0_Text(v0) return { tag = "Us0_Text",  _1 = v0 } end
function Us0_Code(v0) return { tag = "Us0_Code",  _1 = v0 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Code" then
        local v4 = v0._1
        return v4
    elseif v0 ~= nil and v0.tag == "Us0_Text" then
        local v1 = v0._1
        local v2 = v1 == "hi"
        if v2 then
            return 2
        else
            return 3
        end
    end
end

local v0 = true
local v1 = "hi"
local getv4 = function()
    if v0 then
        return Us0_Text(v1)
    else
        return Us0_Code(1)
    end
end
local v4 = getv4()
local getv7 = function()
    if v0 then
        return Us0_Code(5)
    else
        return Us0_Text(v1)
    end
end
local v7 = getv7()
local v8 = score_0(v4)
local v9 = v8 == 2
local getv12 = function()
    if v9 then
        local v10 = score_0(v7)
        local v11 = v10 == 5
        return v11
    else
        return false
    end
end
local v12 = getv12()
if v12 then
    return 0
else
    return 1
end
