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
local Us0_Circle, Us0_Square, Us0_Tri, Us0_Dot, pick_0, measure_1, measure_tri_2
function Us0_Circle(v0) return { tag = "Us0_Circle",  _1 = v0 } end
function Us0_Square(v0) return { tag = "Us0_Square",  _1 = v0 } end
function Us0_Tri(v0) return { tag = "Us0_Tri",  _1 = v0 } end
function Us0_Dot() return { tag = "Us0_Dot" } end

function pick_0(v0)
    local v1 = v0 == 0
    if v1 then
        return Us0_Circle(5)
    else
        local v3 = v0 == 1
        if v3 then
            return Us0_Square(4)
        else
            local v5 = v0 == 2
            if v5 then
                return Us0_Tri(7)
            else
                return Us0_Dot()
            end
        end
    end
end

function measure_1(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Circle" then
        local v2 = __v[1]._1
        local v3 = spiral_wrap_signed(spiral_mul_mod32(v2, 3), 32)
        return v3
    else
        local v4 = spiral_wrap_signed(spiral_mul_mod32(v1, v1), 32)
        local v5 = v4 > 3
        local __v = { v0 }
        if __v[1] ~= nil and __v[1].tag == "Us0_Dot" then
            return v4
        elseif __v[1] ~= nil and __v[1].tag == "Us0_Square" then
            local v6 = __v[1]._1
            if v5 then
                local v7 = spiral_wrap_signed(spiral_mul_mod32(v6, v6), 32)
                return v7
            else
                return v6
            end
        elseif __v[1] ~= nil and __v[1].tag == "Us0_Tri" then
            local v9 = __v[1]._1
            if v5 then
                local v10 = spiral_wrap_signed(spiral_mul_mod32(v9, 2), 32)
                return v10
            else
                return v9
            end
        end
    end
end

function measure_tri_2(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Circle" then
        local v2 = __v[1]._1
        return v2
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Dot" then
        return 0
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Square" then
        local v3 = __v[1]._1
        return v3
    else
        local v4 = spiral_wrap_signed((v1 + 2), 32)
        local __v = { v0 }
        if __v[1] ~= nil and __v[1].tag == "Us0_Tri" then
            local v5 = __v[1]._1
            local v6 = spiral_wrap_signed(spiral_mul_mod32(v5, v4), 32)
            return v6
        end
    end
end

local v0 = 0
local v1 = pick_0(v0)
local v2 = measure_1(v1, v0)
local v3 = spiral_wrap_signed((v0 + 1), 32)
local v4 = pick_0(v3)
local v5 = measure_1(v4, v3)
local v6 = spiral_wrap_signed((v2 + v5), 32)
local v7 = spiral_wrap_signed((v0 + 2), 32)
local v8 = pick_0(v7)
local v9 = measure_1(v8, v7)
local v10 = spiral_wrap_signed((v6 + v9), 32)
local v11 = spiral_wrap_signed((v0 + 3), 32)
local v12 = pick_0(v11)
local v13 = measure_1(v12, v11)
local v14 = spiral_wrap_signed((v10 + v13), 32)
local v15 = pick_0(v7)
local v16 = measure_tri_2(v15, v0)
local v17 = spiral_wrap_signed((v14 + v16), 32)
local v18 = pick_0(v0)
local v19 = measure_tri_2(v18, v0)
local v20 = spiral_wrap_signed((v17 + v19), 32)
return v20
