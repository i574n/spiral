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
local Us0_Idle, Us0_Hit, Us0_Flag, closure0, method0
function Us0_Idle() return { tag = "Us0_Idle" } end
function Us0_Hit(v0) return { tag = "Us0_Hit",  _1 = v0 } end
function Us0_Flag(v0) return { tag = "Us0_Flag",  _1 = v0 } end

function closure0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v1 == v0
        return Us0_Flag(v2)
    end
end

function method0(v0, v1)
    return v0(v1)
end

local v0 = 2
local v1 = closure0({ v0 })
local v2 = method0(v1, v0)
local getv8 = function()
    local __v = { v2 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Flag" then
        local v4 = __v[1]._1
        if v4 then
            return 11
        else
            return 5
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Hit" then
        local v3 = __v[1]._1
        return v3
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Idle" then
        return 3
    end
end
local v8 = getv8()
local v9 = spiral_wrap_signed((v8 + 31), 32)
return v9
