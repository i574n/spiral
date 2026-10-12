local v0 = "x"
local v1 = v0 == " "
local getv3 = function()
    if v1 then
        return true
    else
        local v2 = v0 == "/"
        return v2
    end
end
local v3 = getv3()
if v3 then
    return 1
else
    return 0
end
