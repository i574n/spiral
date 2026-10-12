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
local Us0_Cold, Us0_Warm, Us0_Hot, Us0_Done, score_0
function Us0_Cold() return { tag = "Us0_Cold" } end
function Us0_Warm() return { tag = "Us0_Warm" } end
function Us0_Hot() return { tag = "Us0_Hot" } end
function Us0_Done() return { tag = "Us0_Done" } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Cold" then
        return 1
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Done" then
        return 4
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Hot" then
        return 3
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Warm" then
        return 2
    end
end

local v0 = 3
local v1 = v0 == 0
local getv10 = function()
    if v1 then
        return Us0_Cold()
    else
        local v3 = v0 == 1
        if v3 then
            return Us0_Warm()
        else
            local v5 = v0 == 2
            if v5 then
                return Us0_Hot()
            else
                return Us0_Done()
            end
        end
    end
end
local v10 = getv10()
local v11 = score_0(v10)
local v12 = spiral_wrap_signed((v11 - 4), 32)
return v12
