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
local Us0_Missing, Us0_Call, f_c0
function Us0_Missing() return { tag = "Us0_Missing" } end
function Us0_Call(v0) return { tag = "Us0_Call",  _1 = v0 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = spiral_wrap_signed((v1 + v0), 32)
        return v2
    end
end

local v0 = 3
local v1 = f_c0({ v0 })
local v2 = true
local getv5 = function()
    if v2 then
        return Us0_Call(v1)
    else
        return Us0_Missing()
    end
end
local v5 = getv5()
local __v = { v5 }
if __v[1] ~= nil and __v[1].tag == "Us0_Call" then
    local v6 = __v[1]._1
    local v7 = v6(4)
    local v8 = v7 == 7
    if v8 then
        return 0
    else
        return 1
    end
elseif __v[1] ~= nil and __v[1].tag == "Us0_Missing" then
    return 1
end
