local Us0_DeepBlue, Us0_LightGreen, Us0_Red
function Us0_DeepBlue() return { tag = "Us0_DeepBlue" } end
function Us0_LightGreen(v0) return { tag = "Us0_LightGreen",  _1 = v0 } end
function Us0_Red() return { tag = "Us0_Red" } end

local v0 = 0.5
local v1 = Us0_LightGreen(v0)
local v2 = Us0_DeepBlue()
local v3 = Us0_Red()
local v4 = "deep_blue"
local v5 = "light_green"
local v6 = "red"
local v7 = { v4, v5, v6 }
local v8 = (function () local __tag
if v1.tag == "Us0_DeepBlue" then __tag = 0
elseif v1.tag == "Us0_LightGreen" then __tag = 1
elseif v1.tag == "Us0_Red" then __tag = 2
else __tag = 0 end
return __tag end)()
local v9 = (v7)[(v8)+1]
local v10 = v9 == "light_green"
local getv17 = function()
    if v10 then
        local v11 = "deep-blue"
        local v12 = "light-green"
        local v13 = { v11, v12, v6 }
        local v14 = (function () local __tag
if v2.tag == "Us0_DeepBlue" then __tag = 0
elseif v2.tag == "Us0_LightGreen" then __tag = 1
elseif v2.tag == "Us0_Red" then __tag = 2
else __tag = 0 end
return __tag end)()
        local v15 = (v13)[(v14)+1]
        local v16 = v15 == "deep-blue"
        return v16
    else
        return false
    end
end
local v17 = getv17()
local getv23 = function()
    if v17 then
        local v18 = "deepblue"
        local v19 = "lightgreen"
        local v20 = { v18, v19, v6 }
        local v21 = (v20)[(v8)+1]
        local v22 = v21 == "lightgreen"
        return v22
    else
        return false
    end
end
local v23 = getv23()
local getv28 = function()
    if v23 then
        local v24 = { v4, v5, v6 }
        local v25 = (function () local __tag
if v3.tag == "Us0_DeepBlue" then __tag = 0
elseif v3.tag == "Us0_LightGreen" then __tag = 1
elseif v3.tag == "Us0_Red" then __tag = 2
else __tag = 0 end
return __tag end)()
        local v26 = (v24)[(v25)+1]
        local v27 = v26 == "red"
        return v27
    else
        return false
    end
end
local v28 = getv28()
local getv35 = function()
    if v28 then
        local v29 = "DeepBlue"
        local v30 = "LightGreen"
        local v31 = "Red"
        local v32 = { v29, v30, v31 }
        local v33 = (v32)[(v8)+1]
        local v34 = v33 == "LightGreen"
        return v34
    else
        return false
    end
end
local v35 = getv35()
if v35 then
    return 42
else
    return 1
end
