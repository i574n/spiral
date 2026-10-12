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
local Mut0, Mut1, Uh0_Nil, Uh0_Cons, Mut2, method0, method1
Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

Mut1 = function(l0) return { __tag = "Mut1", l0 = l0 } end

function Uh0_Nil() return { tag = "Uh0_Nil" } end
function Uh0_Cons(v0, v1) return { tag = "Uh0_Cons",  _1 = v0,  _2 = v1 } end

Mut2 = function(l0) return { __tag = "Mut2", l0 = l0 } end

function method0(v0)
    local v1 = v0 ~= nil and v0.l0
    local v2 = v1 < 3
    return v2
end

function method1(v0)
    local v1 = v0 ~= nil and v0.l0
    local v2 = v1 < 4
    return v2
end

local v0 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(3)
local v1 = { __tag = "Mut0", l0 = 0 }
while method0(v1) do
    local v3 = v1 ~= nil and v1.l0
    local v4 = spiral_wrap_signed(spiral_mul_mod32(v3, 5), 32)
    v0[(v3)+1] = v4
    local v5 = spiral_wrap_signed((v3 + 1), 32)
    v1.l0 = v5
end
local v6 = { __tag = "Mut1", l0 = 0 }
local v7 = { __tag = "Mut1", l0 = 0 }
local v8 = Uh0_Nil()
local v9 = { __tag = "Mut2", l0 = v8 }
while method1(v6) do
    local v11 = v6 ~= nil and v6.l0
    local v12 = math.fmod(v11, 2)
    local v13 = v12 == 1
    if v13 then
        local v14 = v7 ~= nil and v7.l0
        local v15 = spiral_wrap_signed((v14 + 1), 32)
        v7.l0 = v15
    else
    end
    local v16 = v9 ~= nil and v9.l0
    local v17 = Uh0_Cons(v11, v16)
    v9.l0 = v17
    local v18 = spiral_wrap_signed((v11 + 1), 32)
    v6.l0 = v18
end
local v19 = v9 ~= nil and v9.l0
local getv38 = function()
    local __v = { v19 }
    if __v[1] ~= nil and __v[1].tag == "Uh0_Cons" then
        local v20 = __v[1]._1
        local v21 = __v[1]._2
        local __v = { v21 }
        if __v[1] ~= nil and __v[1].tag == "Uh0_Cons" then
            local v22 = __v[1]._1
            local v23 = __v[1]._2
            local __v = { v23 }
            if __v[1] ~= nil and __v[1].tag == "Uh0_Cons" then
                local v24 = __v[1]._1
                local v25 = __v[1]._2
                local __v = { v25 }
                if __v[1] ~= nil and __v[1].tag == "Uh0_Cons" then
                    local v26 = __v[1]._1
                    local v27 = __v[1]._2
                    local __v = { v27 }
                    if __v[1] ~= nil and __v[1].tag == "Uh0_Nil" then
                        local v28 = spiral_wrap_signed(spiral_mul_mod32(v20, 64), 32)
                        local v29 = spiral_wrap_signed(spiral_mul_mod32(v22, 16), 32)
                        local v30 = spiral_wrap_signed((v28 + v29), 32)
                        local v31 = spiral_wrap_signed(spiral_mul_mod32(v24, 4), 32)
                        local v32 = spiral_wrap_signed((v30 + v31), 32)
                        local v33 = spiral_wrap_signed((v32 + v26), 32)
                        return v33
                    else
                        return -1
                    end
                else
                    return -1
                end
            else
                return -1
            end
        else
            return -1
        end
    else
        return -1
    end
end
local v38 = getv38()
local v39 = v7 ~= nil and v7.l0
local v40 = spiral_wrap_signed((v38 + v39), 32)
local v41 = (v0)[(2)+1]
local v42 = spiral_wrap_signed((v40 + v41), 32)
local v43 = (v0)[(1)+1]
local v44 = spiral_wrap_signed((v42 - v43), 32)
return v44
