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
local Us0_Idle, Us0_Text, closure0, method0
function Us0_Idle() return { tag = "Us0_Idle" } end
function Us0_Text(v0) return { tag = "Us0_Text",  _1 = v0 } end

function closure0(capt)
    return function(v0)
        local v1 = "managed"
        return Us0_Text(v1)
    end
end

function method0(v0)
    return v0(2)
end

local v0 = closure0(nil)
local v1 = method0(v0)
local getv4 = function()
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Idle" then
        return 3
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Text" then
        local v2 = __v[1]._1
        return 11
    end
end
local v4 = getv4()
local v5 = spiral_wrap_signed((v4 + 31), 32)
return v5
