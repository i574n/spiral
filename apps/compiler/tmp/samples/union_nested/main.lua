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
local Us0_A, Us0_B, Us1_Wrap, Us1_Other, score_inner_1, score_0
function Us0_A(v0) return { tag = "Us0_A",  _1 = v0 } end
function Us0_B(v0) return { tag = "Us0_B",  _1 = v0 } end

function Us1_Wrap(v0) return { tag = "Us1_Wrap",  _1 = v0 } end
function Us1_Other(v0) return { tag = "Us1_Other",  _1 = v0 } end

function score_inner_1(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_A" then
        local v1 = __v[1]._1
        return v1
    elseif __v[1] ~= nil and __v[1].tag == "Us0_B" then
        local v2 = __v[1]._1
        local v3 = spiral_wrap_signed(-(v2), 32)
        return v3
    end
end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us1_Other" then
        local v3 = __v[1]._1
        return v3
    elseif __v[1] ~= nil and __v[1].tag == "Us1_Wrap" then
        local v1 = __v[1]._1
        return score_inner_1(v1)
    end
end

local v0 = true
local getv4 = function()
    if v0 then
        local v1 = Us0_A(7)
        return Us1_Wrap(v1)
    else
        return Us1_Other(1)
    end
end
local v4 = getv4()
local getv8 = function()
    if v0 then
        return Us1_Other(4)
    else
        local v6 = Us0_B(2)
        return Us1_Wrap(v6)
    end
end
local v8 = getv8()
local v9 = score_0(v4)
local v10 = v9 == 7
local getv13 = function()
    if v10 then
        local v11 = score_0(v8)
        local v12 = v11 == 4
        return v12
    else
        return false
    end
end
local v13 = getv13()
if v13 then
    return 0
else
    return 1
end
