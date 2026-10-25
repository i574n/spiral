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
local Us0_Done, Us0_More, layers_0
function Us0_Done(v0) return { tag = "Us0_Done",  _1 = v0 } end
function Us0_More(v0) return { tag = "Us0_More",  _1 = v0 } end

function layers_0(v0)
    local v1 = v0 >= 5
    local getv4 = function()
        if v1 then
            return Us0_Done(v0)
        else
            return Us0_More(v0)
        end
    end
    local v4 = getv4()
    local __v = { v4 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Done" then
        local v8 = __v[1]._1
        local v9 = spiral_wrap_signed(spiral_mul_mod32(v8, 2), 32)
        return v9
    elseif __v[1] ~= nil and __v[1].tag == "Us0_More" then
        local v5 = __v[1]._1
        local v6 = spiral_wrap_signed((v5 + 1), 32)
        return layers_0(v6)
    end
end

local v0 = 0
return layers_0(v0)
