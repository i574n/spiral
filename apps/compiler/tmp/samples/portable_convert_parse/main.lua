local Us0_Some, Us0_None
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end
function Us0_None() return { tag = "Us0_None" } end

local v0 = "ff"
local v1 = tonumber( v0, 16 )
print(v1)
local v2 = "1011"
local v3 = tonumber( v2, 2 )
print(v3)
local v4 = "-42"
local v5 = tonumber( v4, 10 )
print(v5)
local v6 = " 123 "
local v7 = (string.match(v6, "^%s*[+-]?%d+%s*$") ~= nil)
local v8 = (tonumber(v6) or 0)
local v9 = (math.modf(v8))
local getv11 = function()
    if v7 then
        local v10 = v8 >= -2147483648.0
        return v10
    else
        return false
    end
end
local v11 = getv11()
local getv13 = function()
    if v11 then
        local v12 = v8 <= 2147483647.0
        return v12
    else
        return false
    end
end
local v13 = getv13()
local getv16 = function()
    if v13 then
        return Us0_Some(v9)
    else
        return Us0_None()
    end
end
local v16 = getv16()
if v16 ~= nil and v16.tag == "Us0_None" then
    local v18 = "none"
    print(v18)
elseif v16 ~= nil and v16.tag == "Us0_Some" then
    local v17 = v16._1
    print(v17)
end
local v19 = "12x"
local v20 = (string.match(v19, "^%s*[+-]?%d+%s*$") ~= nil)
local v21 = (tonumber(v19) or 0)
local v22 = (math.modf(v21))
local getv24 = function()
    if v20 then
        local v23 = v21 >= -2147483648.0
        return v23
    else
        return false
    end
end
local v24 = getv24()
local getv26 = function()
    if v24 then
        local v25 = v21 <= 2147483647.0
        return v25
    else
        return false
    end
end
local v26 = getv26()
local getv29 = function()
    if v26 then
        return Us0_Some(v22)
    else
        return Us0_None()
    end
end
local v29 = getv29()
if v29 ~= nil and v29.tag == "Us0_None" then
    local v31 = "none"
    print(v31)
elseif v29 ~= nil and v29.tag == "Us0_Some" then
    local v30 = v29._1
    print(v30)
end
local v32 = ""
local v33 = (string.match(v32, "^%s*[+-]?%d+%s*$") ~= nil)
local v34 = (tonumber(v32) or 0)
local v35 = (math.modf(v34))
local getv37 = function()
    if v33 then
        local v36 = v34 >= -2147483648.0
        return v36
    else
        return false
    end
end
local v37 = getv37()
local getv39 = function()
    if v37 then
        local v38 = v34 <= 2147483647.0
        return v38
    else
        return false
    end
end
local v39 = getv39()
local getv42 = function()
    if v39 then
        return Us0_Some(v35)
    else
        return Us0_None()
    end
end
local v42 = getv42()
if v42 ~= nil and v42.tag == "Us0_None" then
    local v44 = "none"
    print(v44)
elseif v42 ~= nil and v42.tag == "Us0_Some" then
    local v43 = v42._1
    print(v43)
end
local v45 = "+7"
local v46 = (string.match(v45, "^%s*[+-]?%d+%s*$") ~= nil)
local v47 = (tonumber(v45) or 0)
local v48 = (math.modf(v47))
local getv50 = function()
    if v46 then
        local v49 = v47 >= -2147483648.0
        return v49
    else
        return false
    end
end
local v50 = getv50()
local getv52 = function()
    if v50 then
        local v51 = v47 <= 2147483647.0
        return v51
    else
        return false
    end
end
local v52 = getv52()
local getv55 = function()
    if v52 then
        return Us0_Some(v48)
    else
        return Us0_None()
    end
end
local v55 = getv55()
if v55 ~= nil and v55.tag == "Us0_None" then
    local v57 = "none"
    print(v57)
elseif v55 ~= nil and v55.tag == "Us0_Some" then
    local v56 = v55._1
    print(v56)
end
return 0
