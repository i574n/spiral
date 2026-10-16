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
local Us0_Idle, Us0_Text, Us0_Note, closure0, method0, method1
function Us0_Idle() return { tag = "Us0_Idle" } end
function Us0_Text(v0) return { tag = "Us0_Text",  _1 = v0 } end
function Us0_Note(v0) return { tag = "Us0_Note",  _1 = v0 } end

function closure0(capt)
    return function(v0)
        local v1 = v0 == 1
        if v1 then
            local v2 = "alpha"
            return Us0_Text(v2)
        else
            local v4 = "beta"
            return Us0_Note(v4)
        end
    end
end

function method0(v0)
    return v0(1)
end

function method1(v0)
    return v0(2)
end

local v0 = closure0(nil)
local v1 = method0(v0)
local getv6 = function()
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Idle" then
        return 3
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Note" then
        local v3 = __v[1]._1
        return 6
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Text" then
        local v2 = __v[1]._1
        return 5
    end
end
local v6 = getv6()
local v7 = method1(v0)
local getv12 = function()
    local __v = { v7 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Idle" then
        return 3
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Note" then
        local v9 = __v[1]._1
        return 6
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Text" then
        local v8 = __v[1]._1
        return 5
    end
end
local v12 = getv12()
local v13 = spiral_wrap_signed((v6 + v12), 32)
local v14 = spiral_wrap_signed((v13 + 31), 32)
return v14
