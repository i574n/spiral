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
            local v3 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(2)
            v3[(0)+1] = v0
            local v4 = spiral_wrap_signed((v0 + 1), 32)
            v3[(1)+1] = v4
            local v5 = "hi"
            return Us0_Item(v5, v3)
        end
    end
end

function method0(v0)
    return v0(0)
end

function method1(v0)
    return v0(4)
end

local v0 = closure0(nil)
local v1 = method0(v0)
local getv12 = function()
    if v1 ~= nil and v1.tag == "Us0_Empty" then
        return 3
    elseif v1 ~= nil and v1.tag == "Us0_Item" then
        local v2 = v1._1
        local v3 = v1._2
        local v4 = string.len(v2)
        local v5 = #(v3)
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        local v7 = (v3)[(0)+1]
        local v8 = spiral_wrap_signed((v6 + v7), 32)
        local v9 = (v3)[(1)+1]
        local v10 = spiral_wrap_signed((v8 + v9), 32)
        return v10
    end
end
local v12 = getv12()
local v13 = method1(v0)
local getv24 = function()
    if v13 ~= nil and v13.tag == "Us0_Empty" then
        return 3
    elseif v13 ~= nil and v13.tag == "Us0_Item" then
        local v14 = v13._1
        local v15 = v13._2
        local v16 = string.len(v14)
        local v17 = #(v15)
        local v18 = spiral_wrap_signed((v16 + v17), 32)
        local v19 = (v15)[(0)+1]
        local v20 = spiral_wrap_signed((v18 + v19), 32)
        local v21 = (v15)[(1)+1]
        local v22 = spiral_wrap_signed((v20 + v21), 32)
        return v22
    end
end
local v24 = getv24()
local v25 = spiral_wrap_signed((v12 + v24), 32)
local v26 = spiral_wrap_signed((v25 + 26), 32)
return v26
