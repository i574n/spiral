local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local function spiral_mul_mod32(a, b)
    a = a % 4294967296
    b = b % 4294967296
    local a_low = a % 65536
    local a_high = (a - a_low) / 65536
    return (a_low * b + ((a_high * b) % 65536) * 65536) % 4294967296
end
local Us0_Circle, Us0_Rect, Us0_Empty
function Us0_Circle(v0) return { tag = "Us0_Circle",  _1 = v0 } end
function Us0_Rect(v0, v1) return { tag = "Us0_Rect",  _1 = v0,  _2 = v1 } end
function Us0_Empty() return { tag = "Us0_Empty" } end

local v0 = 2
local v1 = Us0_Circle(v0)
local v2 = 3
local v3 = 4
local v4 = Us0_Rect(v2, v3)
local v5 = Us0_Empty()
local v6 = 2
local v7 = Us0_Circle(v6)
local getv18 = function()
    local __v = { v1, v7 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Circle" and __v[2] ~= nil and __v[2].tag == "Us0_Circle" then
        local v8 = __v[1]._1
        local v9 = __v[2]._1
        local v10 = v8 == v9
        return v10
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Empty" and __v[2] ~= nil and __v[2].tag == "Us0_Empty" then
        return true
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Rect" and __v[2] ~= nil and __v[2].tag == "Us0_Rect" then
        local v11 = __v[1]._1
        local v12 = __v[1]._2
        local v13 = __v[2]._1
        local v14 = __v[2]._2
        local v15 = v11 == v13
        if v15 then
            local v16 = v12 == v14
            return v16
        else
            return false
        end
    else
        return false
    end
end
local v18 = getv18()
local getv19 = function()
    if v18 then
        return 100
    else
        return 0
    end
end
local v19 = getv19()
local getv28 = function()
    if v1 ~= nil and v1.tag == "Us0_Circle" then
        local v20 = v1._1
        local v21 = spiral_wrap_signed(spiral_mul_mod32(3, v20), 32)
        local v22 = spiral_wrap_signed(spiral_mul_mod32(v21, v20), 32)
        return v22
    elseif v1 ~= nil and v1.tag == "Us0_Empty" then
        return 0
    elseif v1 ~= nil and v1.tag == "Us0_Rect" then
        local v23 = v1._1
        local v24 = v1._2
        local v25 = spiral_wrap_signed(spiral_mul_mod32(v23, v24), 32)
        return v25
    end
end
local v28 = getv28()
local getv37 = function()
    if v4 ~= nil and v4.tag == "Us0_Circle" then
        local v29 = v4._1
        local v30 = spiral_wrap_signed(spiral_mul_mod32(3, v29), 32)
        local v31 = spiral_wrap_signed(spiral_mul_mod32(v30, v29), 32)
        return v31
    elseif v4 ~= nil and v4.tag == "Us0_Empty" then
        return 0
    elseif v4 ~= nil and v4.tag == "Us0_Rect" then
        local v32 = v4._1
        local v33 = v4._2
        local v34 = spiral_wrap_signed(spiral_mul_mod32(v32, v33), 32)
        return v34
    end
end
local v37 = getv37()
local v38 = spiral_wrap_signed((v28 + v37), 32)
local getv47 = function()
    if v5 ~= nil and v5.tag == "Us0_Circle" then
        local v39 = v5._1
        local v40 = spiral_wrap_signed(spiral_mul_mod32(3, v39), 32)
        local v41 = spiral_wrap_signed(spiral_mul_mod32(v40, v39), 32)
        return v41
    elseif v5 ~= nil and v5.tag == "Us0_Empty" then
        return 0
    elseif v5 ~= nil and v5.tag == "Us0_Rect" then
        local v42 = v5._1
        local v43 = v5._2
        local v44 = spiral_wrap_signed(spiral_mul_mod32(v42, v43), 32)
        return v44
    end
end
local v47 = getv47()
local v48 = spiral_wrap_signed((v38 + v47), 32)
local v49 = spiral_wrap_signed((v48 + v19), 32)
return v49
