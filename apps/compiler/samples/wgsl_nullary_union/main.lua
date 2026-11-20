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
local Us0_North, Us0_East, Us0_South, Us0_West
function Us0_North() return { tag = "Us0_North" } end
function Us0_East() return { tag = "Us0_East" } end
function Us0_South() return { tag = "Us0_South" } end
function Us0_West() return { tag = "Us0_West" } end

local v0 = Us0_North()
local getv8 = function()
    if v0 ~= nil and v0.tag == "Us0_East" then
        return Us0_South()
    elseif v0 ~= nil and v0.tag == "Us0_North" then
        return Us0_East()
    elseif v0 ~= nil and v0.tag == "Us0_South" then
        return Us0_West()
    elseif v0 ~= nil and v0.tag == "Us0_West" then
        return Us0_North()
    end
end
local v8 = getv8()
local getv16 = function()
    if v8 ~= nil and v8.tag == "Us0_East" then
        return Us0_South()
    elseif v8 ~= nil and v8.tag == "Us0_North" then
        return Us0_East()
    elseif v8 ~= nil and v8.tag == "Us0_South" then
        return Us0_West()
    elseif v8 ~= nil and v8.tag == "Us0_West" then
        return Us0_North()
    end
end
local v16 = getv16()
local v17 = Us0_South()
local getv18 = function()
    local __v = { v16, v17 }
    if __v[1] ~= nil and __v[1].tag == "Us0_East" and __v[2] ~= nil and __v[2].tag == "Us0_East" then
        return true
    elseif __v[1] ~= nil and __v[1].tag == "Us0_North" and __v[2] ~= nil and __v[2].tag == "Us0_North" then
        return true
    elseif __v[1] ~= nil and __v[1].tag == "Us0_South" and __v[2] ~= nil and __v[2].tag == "Us0_South" then
        return true
    elseif __v[1] ~= nil and __v[1].tag == "Us0_West" and __v[2] ~= nil and __v[2].tag == "Us0_West" then
        return true
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
local getv21 = function()
    if v0 ~= nil and v0.tag == "Us0_East" then
        return 2
    elseif v0 ~= nil and v0.tag == "Us0_North" then
        return 1
    else
        return 7
    end
end
local v21 = getv21()
local getv23 = function()
    if v8 ~= nil and v8.tag == "Us0_East" then
        return 2
    elseif v8 ~= nil and v8.tag == "Us0_North" then
        return 1
    else
        return 7
    end
end
local v23 = getv23()
local v24 = spiral_wrap_signed(spiral_mul_mod32(v23, 3), 32)
local v25 = spiral_wrap_signed((v21 + v24), 32)
local getv27 = function()
    if v16 ~= nil and v16.tag == "Us0_East" then
        return 2
    elseif v16 ~= nil and v16.tag == "Us0_North" then
        return 1
    else
        return 7
    end
end
local v27 = getv27()
local v28 = spiral_wrap_signed(spiral_mul_mod32(v27, 9), 32)
local v29 = spiral_wrap_signed((v25 + v28), 32)
local v30 = spiral_wrap_signed((v29 + v19), 32)
return v30
