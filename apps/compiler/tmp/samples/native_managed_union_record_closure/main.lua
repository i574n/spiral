local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_Empty, Us0_Item, closure0, method0, method1
function Us0_Empty() return { tag = "Us0_Empty" } end
function Us0_Item(v0, v1) return { tag = "Us0_Item",  _1 = v0,  _2 = v1 } end

function closure0(capt)
    return function(v0)
        local v1 = v0 == 0
        if v1 then
            return Us0_Empty()
        else
            local v3 = "managed"
            return Us0_Item(v3, 32)
        end
    end
end

function method0(v0)
    return v0(0)
end

function method1(v0)
    return v0(1)
end

local v0 = closure0(nil)
local v1 = method0(v0)
local getv7 = function()
    if v1 ~= nil and v1.tag == "Us0_Empty" then
        return 3
    elseif v1 ~= nil and v1.tag == "Us0_Item" then
        local v2 = v1._1
        local v3 = v1._2
        local v4 = string.len(v2)
        local v5 = spiral_wrap_signed((v4 + v3), 32)
        return v5
    end
end
local v7 = getv7()
local v8 = method1(v0)
local getv14 = function()
    if v8 ~= nil and v8.tag == "Us0_Empty" then
        return 3
    elseif v8 ~= nil and v8.tag == "Us0_Item" then
        local v9 = v8._1
        local v10 = v8._2
        local v11 = string.len(v9)
        local v12 = spiral_wrap_signed((v11 + v10), 32)
        return v12
    end
end
local v14 = getv14()
local v15 = spiral_wrap_signed((v7 + v14), 32)
return v15
