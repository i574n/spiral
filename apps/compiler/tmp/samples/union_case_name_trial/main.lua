local Us0_Circle, Us0_Square, Us0_Dot
function Us0_Circle(v0) return { tag = "Us0_Circle",  _1 = v0 } end
function Us0_Square(v0) return { tag = "Us0_Square",  _1 = v0 } end
function Us0_Dot() return { tag = "Us0_Dot" } end

local v0 = 1.5
local v1 = Us0_Circle(v0)
local v2 = 2.5
local v3 = Us0_Square(v2)
local v4 = Us0_Dot()
local v8 = "Circle"
local v9 = "Square"
local v10 = "Dot"
local v11 = { v8, v9, v10 }
local v12 = (function () local __tag
if v1.tag == "Us0_Circle" then __tag = 0
elseif v1.tag == "Us0_Square" then __tag = 1
elseif v1.tag == "Us0_Dot" then __tag = 2
else __tag = 0 end
return __tag end)()
local v13 = (v11)[(v12)+1]
local v14 = v13 == "Circle"
local getv19 = function()
    if v14 then
        local v15 = { v8, v9, v10 }
        local v16 = (function () local __tag
if v3.tag == "Us0_Circle" then __tag = 0
elseif v3.tag == "Us0_Square" then __tag = 1
elseif v3.tag == "Us0_Dot" then __tag = 2
else __tag = 0 end
return __tag end)()
        local v17 = (v15)[(v16)+1]
        local v18 = v17 == "Square"
        return v18
    else
        return false
    end
end
local v19 = getv19()
local getv24 = function()
    if v19 then
        local v20 = { v8, v9, v10 }
        local v21 = (function () local __tag
if v4.tag == "Us0_Circle" then __tag = 0
elseif v4.tag == "Us0_Square" then __tag = 1
elseif v4.tag == "Us0_Dot" then __tag = 2
else __tag = 0 end
return __tag end)()
        local v22 = (v20)[(v21)+1]
        local v23 = v22 == "Dot"
        return v23
    else
        return false
    end
end
local v24 = getv24()
if v24 then
    return 42
else
    return 1
end
