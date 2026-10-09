local function spiral_wrap_unsigned(value, bits)
    return value % (2 ^ bits)
end
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
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Empty" then
        return 3
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Item" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = string.len(v2)
        local v5 = spiral_wrap_signed((v4 + v3), 32)
        return v5
    end
end
local v7 = getv7()
local v8 = method1(v0)
local getv14 = function()
    local __v = { v8 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Empty" then
        return 3
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Item" then
        local v9 = __v[1]._1
        local v10 = __v[1]._2
        local v11 = string.len(v9)
        local v12 = spiral_wrap_signed((v11 + v10), 32)
        return v12
    end
end
local v14 = getv14()
local v15 = spiral_wrap_signed((v7 + v14), 32)
return v15
