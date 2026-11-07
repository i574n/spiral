local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_Empty, Us0_Values, closure0, method0, score_1, method2
function Us0_Empty() return { tag = "Us0_Empty" } end
function Us0_Values(v0) return { tag = "Us0_Values",  _1 = v0 } end

function closure0(capt)
    return function(v0)
        local v1 = v0 == 0
        if v1 then
            return Us0_Empty()
        else
            local v3 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(2)
            v3[(0)+1] = v0
            local v4 = spiral_wrap_signed((v0 + 1), 32)
            v3[(1)+1] = v4
            return Us0_Values(v3)
        end
    end
end

function method0(v0)
    return v0(0)
end

function score_1(v0)
    if v0 ~= nil and v0.tag == "Us0_Empty" then
        return 3
    elseif v0 ~= nil and v0.tag == "Us0_Values" then
        local v1 = v0._1
        local v2 = #(v1)
        local v3 = (v1)[(0)+1]
        local v4 = spiral_wrap_signed((v2 + v3), 32)
        local v5 = (v1)[(1)+1]
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        return v6
    end
end

function method2(v0)
    return v0(4)
end

local v0 = closure0(nil)
local v1 = method0(v0)
local v2 = score_1(v1)
local v3 = method2(v0)
local v4 = score_1(v3)
local v5 = spiral_wrap_signed((v2 + v4), 32)
local v6 = spiral_wrap_signed((v5 + 28), 32)
return v6
