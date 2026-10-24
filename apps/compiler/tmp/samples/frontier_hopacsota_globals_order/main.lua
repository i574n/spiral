local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local leaf_c_1, slow_a_0, fast_b_2
function leaf_c_1()
    return 0
end

function slow_a_0()
    local v0 = leaf_c_1()
    return v0
end

function fast_b_2()
    return 0
end

local v0 = slow_a_0()
local v1 = fast_b_2()
local v2 = spiral_wrap_signed((v0 + v1), 32)
return v2
