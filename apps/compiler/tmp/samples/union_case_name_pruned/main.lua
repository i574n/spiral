local Us0_First, Us0_Second
function Us0_First() return { tag = "Us0_First" } end
function Us0_Second() return { tag = "Us0_Second" } end

local v0 = Us0_First()
local v1 = Us0_Second()
local v3 = ""
local v4 = "First"
local v5 = "Second"
local v6 = { v3, v4, v5 }
local v7 = (function () local __tag
if v0.tag == "Us0_First" then __tag = 1
elseif v0.tag == "Us0_Second" then __tag = 2
else __tag = 0 end
return __tag end)()
local v8 = (v6)[(v7)+1]
local v9 = v8 == "First"
local getv14 = function()
    if v9 then
        local v10 = { v3, v4, v5 }
        local v11 = (function () local __tag
if v1.tag == "Us0_First" then __tag = 1
elseif v1.tag == "Us0_Second" then __tag = 2
else __tag = 0 end
return __tag end)()
        local v12 = (v10)[(v11)+1]
        local v13 = v12 == "Second"
        return v13
    else
        return false
    end
end
local v14 = getv14()
if v14 then
    return 42
else
    return 1
end
