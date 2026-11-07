local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local function spiral_bit_combine(a, b, keep)
    a = a % 4294967296
    b = b % 4294967296
    local result, place = 0, 1
    for _ = 1, 32 do
        local a_bit, b_bit = a % 2, b % 2
        if keep(a_bit, b_bit) then result = result + place end
        a = (a - a_bit) / 2
        b = (b - b_bit) / 2
        place = place * 2
    end
    return result
end
local bit = bit32 or bit or {
    band = function(a, b) return spiral_bit_combine(a, b, function(x, y) return x == 1 and y == 1 end) end,
    bor = function(a, b) return spiral_bit_combine(a, b, function(x, y) return x == 1 or y == 1 end) end,
    bxor = function(a, b) return spiral_bit_combine(a, b, function(x, y) return x ~= y end) end,
    bnot = function(a) return 4294967295 - a % 4294967296 end,
    lshift = function(a, n) return (a % 4294967296) * 2 ^ n % 4294967296 end,
    rshift = function(a, n) return math.floor((a % 4294967296) / 2 ^ n) end,
}
local spiral_w64 = {}
function spiral_w64.split(x)
    if type(x) == "table" then return x[1], x[2] end
    local lo = x % 4294967296
    return ((x - lo) / 4294967296) % 4294967296, lo
end
function spiral_w64.make(h, l, s)
    if h < 2097152 then return h * 4294967296 + l end
    if s and h >= 4292870144 then return (h - 4294967296) * 4294967296 + l end
    return { h, l }
end
function spiral_w64.small(r, s)
    return r < 9007199254740992 and r > -9007199254740992 and (s or r >= 0)
end
function spiral_w64.neg_halves(h, l)
    if l == 0 then return (4294967296 - h) % 4294967296, 0 end
    return 4294967295 - h, 4294967296 - l
end
function spiral_w64.add(a, b, s)
    if type(a) == "number" and type(b) == "number" then
        local r = a + b
        if spiral_w64.small(r, s) then return r + 0 end
    end
    local ah, al = spiral_w64.split(a)
    local bh, bl = spiral_w64.split(b)
    local l, c = al + bl, 0
    if l >= 4294967296 then l, c = l - 4294967296, 1 end
    return spiral_w64.make((ah + bh + c) % 4294967296, l, s)
end
function spiral_w64.sub(a, b, s)
    if type(a) == "number" and type(b) == "number" then
        local r = a - b
        if spiral_w64.small(r, s) then return r + 0 end
    end
    local ah, al = spiral_w64.split(a)
    local bh, bl = spiral_w64.split(b)
    local l, c = al - bl, 0
    if l < 0 then l, c = l + 4294967296, 1 end
    return spiral_w64.make((ah - bh - c) % 4294967296, l, s)
end
function spiral_w64.neg(a, s)
    return spiral_w64.sub(0, a, s)
end
function spiral_w64.mul(a, b, s)
    if type(a) == "number" and type(b) == "number" then
        local r = a * b
        if spiral_w64.small(r, s) then return r + 0 end
    end
    local ah, al = spiral_w64.split(a)
    local bh, bl = spiral_w64.split(b)
    local a0, a1, a2, a3 = al % 65536, math.floor(al / 65536), ah % 65536, math.floor(ah / 65536)
    local b0, b1, b2, b3 = bl % 65536, math.floor(bl / 65536), bh % 65536, math.floor(bh / 65536)
    local c = a0 * b0
    local d0 = c % 65536
    c = math.floor(c / 65536) + a1 * b0 + a0 * b1
    local d1 = c % 65536
    c = math.floor(c / 65536) + a2 * b0 + a1 * b1 + a0 * b2
    local d2 = c % 65536
    c = math.floor(c / 65536) + a3 * b0 + a2 * b1 + a1 * b2 + a0 * b3
    local d3 = c % 65536
    return spiral_w64.make(d3 * 65536 + d2, d1 * 65536 + d0, s)
end
function spiral_w64.udivmod(ah, al, bh, bl)
    if bh == 0 and bl == 0 then error("spiral: integer division by zero") end
    if ah == 0 and bh == 0 then
        local r = math.fmod(al, bl)
        return 0, (al - r) / bl, 0, r
    end
    local qh, ql, rh, rl = 0, 0, 0, 0
    for i = 63, 0, -1 do
        local d
        if i >= 32 then d = math.floor(ah / 2 ^ (i - 32)) % 2 else d = math.floor(al / 2 ^ i) % 2 end
        rh = rh * 2 + math.floor(rl / 2147483648)
        rl = (rl % 2147483648) * 2 + d
        qh = (qh * 2 + math.floor(ql / 2147483648)) % 4294967296
        ql = (ql % 2147483648) * 2
        if rh > bh or (rh == bh and rl >= bl) then
            rl, rh = rl - bl, rh - bh
            if rl < 0 then rl, rh = rl + 4294967296, rh - 1 end
            ql = ql + 1
        end
    end
    return qh, ql, rh, rl
end
function spiral_w64.divmod(a, b, s)
    if type(a) == "number" and type(b) == "number" and b ~= 0 then
        local r = math.fmod(a, b)
        return (a - r) / b + 0, r + 0
    end
    local ah, al = spiral_w64.split(a)
    local bh, bl = spiral_w64.split(b)
    local an, bn = false, false
    if s and ah >= 2147483648 then an = true; ah, al = spiral_w64.neg_halves(ah, al) end
    if s and bh >= 2147483648 then bn = true; bh, bl = spiral_w64.neg_halves(bh, bl) end
    local qh, ql, rh, rl = spiral_w64.udivmod(ah, al, bh, bl)
    if an ~= bn then qh, ql = spiral_w64.neg_halves(qh, ql) end
    if an then rh, rl = spiral_w64.neg_halves(rh, rl) end
    return spiral_w64.make(qh, ql, s), spiral_w64.make(rh, rl, s)
end
function spiral_w64.div(a, b, s)
    local q = spiral_w64.divmod(a, b, s)
    return q
end
function spiral_w64.mod(a, b, s)
    local _, r = spiral_w64.divmod(a, b, s)
    return r
end
function spiral_w64.eq(a, b)
    if type(a) == "number" and type(b) == "number" then return a == b end
    local ah, al = spiral_w64.split(a)
    local bh, bl = spiral_w64.split(b)
    return ah == bh and al == bl
end
function spiral_w64.lt(a, b, s)
    if type(a) == "number" and type(b) == "number" then return a < b end
    local ah, al = spiral_w64.split(a)
    local bh, bl = spiral_w64.split(b)
    if s then ah, bh = (ah + 2147483648) % 4294967296, (bh + 2147483648) % 4294967296 end
    return ah < bh or (ah == bh and al < bl)
end
function spiral_w64.bits(a, b, s, f)
    local ah, al = spiral_w64.split(a)
    local bh, bl = spiral_w64.split(b)
    return spiral_w64.make(f(ah, bh) % 4294967296, f(al, bl) % 4294967296, s)
end
function spiral_w64.band(a, b, s) return spiral_w64.bits(a, b, s, bit.band) end
function spiral_w64.bor(a, b, s) return spiral_w64.bits(a, b, s, bit.bor) end
function spiral_w64.bxor(a, b, s) return spiral_w64.bits(a, b, s, bit.bxor) end
function spiral_w64.bnot(a, s)
    local h, l = spiral_w64.split(a)
    return spiral_w64.make(4294967295 - h, 4294967295 - l, s)
end
function spiral_w64.count(n)
    if type(n) == "table" then n = n[2] end
    return n % 64
end
function spiral_w64.shl(a, n, s)
    local h, l = spiral_w64.split(a)
    n = spiral_w64.count(n)
    if n >= 32 then
        h, l = (l % 2 ^ (64 - n)) * 2 ^ (n - 32), 0
    elseif n > 0 then
        h, l = (h % 2 ^ (32 - n)) * 2 ^ n + math.floor(l / 2 ^ (32 - n)), (l % 2 ^ (32 - n)) * 2 ^ n
    end
    return spiral_w64.make(h, l, s)
end
function spiral_w64.lshr(h, l, n)
    if n >= 32 then return 0, math.floor(h / 2 ^ (n - 32)) end
    if n == 0 then return h, l end
    return math.floor(h / 2 ^ n), math.floor(l / 2 ^ n) + (h % 2 ^ n) * 2 ^ (32 - n)
end
function spiral_w64.shr(a, n, s)
    local h, l = spiral_w64.split(a)
    n = spiral_w64.count(n)
    if s and h >= 2147483648 then
        h, l = spiral_w64.lshr(4294967295 - h, 4294967295 - l, n)
        return spiral_w64.make(4294967295 - h, 4294967295 - l, s)
    end
    h, l = spiral_w64.lshr(h, l, n)
    return spiral_w64.make(h, l, s)
end
function spiral_w64.cast(a, s)
    local h, l = spiral_w64.split(a)
    return spiral_w64.make(h, l, s)
end
function spiral_w64.of_float(x, s)
    local t = math.modf(x)
    if spiral_w64.small(t, s) then return t + 0 end
    local h, l = spiral_w64.split(t)
    return spiral_w64.make(h, l, s)
end
function spiral_w64.to_float(a, s)
    if type(a) == "number" then return a end
    local h, l = a[1], a[2]
    if s and h >= 2147483648 then
        h, l = spiral_w64.neg_halves(h, l)
        return -(h * 4294967296 + l)
    end
    return h * 4294967296 + l
end
function spiral_w64.low(a)
    if type(a) == "number" then return a % 4294967296 end
    return a[2]
end
function spiral_w64.tostring(a, s)
    if type(a) == "number" then
        if a == 0 then return "0" end
        return string.format("%.0f", a)
    end
    local h, l = a[1], a[2]
    local sign = ""
    if s and h >= 2147483648 then sign, h, l = "-", spiral_w64.neg_halves(h, l) end
    local limbs = { math.floor(h / 65536), h % 65536, math.floor(l / 65536), l % 65536 }
    local digits = {}
    repeat
        local r, more = 0, false
        for i = 1, 4 do
            local cur = r * 65536 + limbs[i]
            limbs[i] = math.floor(cur / 10)
            r = cur % 10
            if limbs[i] ~= 0 then more = true end
        end
        digits[#digits + 1] = string.char(48 + r)
    until not more
    return sign .. string.reverse(table.concat(digits))
end
local Us0_BitZero, Us0_BitOne, Uh0_RegexChar, Uh0_RegexAlt, Uh0_RegexCat, Uh0_RegexStar, Uh1_InputCons, Us1_SymbolLess, Us1_SymbolSame, Us1_SymbolGreater, Us2_Nullable, Us2_NonNullable, Us3_TriA, Us3_TriB, Us3_TriC, Uh2_RegexChar, Uh2_RegexAlt, Uh2_RegexCat, Uh2_RegexStar, Uh3_InputCons, random_bit_input_1, run_2, regex_compare_8, alt_insert_sorted_7, make_alt_6, regex_equal_10, make_cat_9, make_star_11, normalize_5, nullable_13, derivative_12, canonical_derivative_4, accepts_3, loop_0, zeros_input_15, run_16, loop_14, run_17, regex_compare_23, alt_insert_sorted_22, make_alt_21, regex_equal_25, make_cat_24, make_star_26, normalize_20, nullable_28, derivative_27, canonical_derivative_19, accepts_18
function Us0_BitZero() return { tag = "Us0_BitZero" } end
function Us0_BitOne() return { tag = "Us0_BitOne" } end

Uh0_RegexEmpty = (function() local shared = { tag = "Uh0_RegexEmpty" } return function() return shared end end)()
Uh0_RegexEpsilon = (function() local shared = { tag = "Uh0_RegexEpsilon" } return function() return shared end end)()
function Uh0_RegexChar(v0) return { tag = "Uh0_RegexChar",  _1 = v0 } end
function Uh0_RegexAlt(v0, v1) return { tag = "Uh0_RegexAlt",  _1 = v0,  _2 = v1 } end
function Uh0_RegexCat(v0, v1) return { tag = "Uh0_RegexCat",  _1 = v0,  _2 = v1 } end
function Uh0_RegexStar(v0) return { tag = "Uh0_RegexStar",  _1 = v0 } end

Uh1_InputEmpty = (function() local shared = { tag = "Uh1_InputEmpty" } return function() return shared end end)()
function Uh1_InputCons(v0, v1) return { tag = "Uh1_InputCons",  _1 = v0,  _2 = v1 } end

function Us1_SymbolLess() return { tag = "Us1_SymbolLess" } end
function Us1_SymbolSame() return { tag = "Us1_SymbolSame" } end
function Us1_SymbolGreater() return { tag = "Us1_SymbolGreater" } end

function Us2_Nullable() return { tag = "Us2_Nullable" } end
function Us2_NonNullable() return { tag = "Us2_NonNullable" } end

function Us3_TriA() return { tag = "Us3_TriA" } end
function Us3_TriB() return { tag = "Us3_TriB" } end
function Us3_TriC() return { tag = "Us3_TriC" } end

Uh2_RegexEmpty = (function() local shared = { tag = "Uh2_RegexEmpty" } return function() return shared end end)()
Uh2_RegexEpsilon = (function() local shared = { tag = "Uh2_RegexEpsilon" } return function() return shared end end)()
function Uh2_RegexChar(v0) return { tag = "Uh2_RegexChar",  _1 = v0 } end
function Uh2_RegexAlt(v0, v1) return { tag = "Uh2_RegexAlt",  _1 = v0,  _2 = v1 } end
function Uh2_RegexCat(v0, v1) return { tag = "Uh2_RegexCat",  _1 = v0,  _2 = v1 } end
function Uh2_RegexStar(v0) return { tag = "Uh2_RegexStar",  _1 = v0 } end

Uh3_InputEmpty = (function() local shared = { tag = "Uh3_InputEmpty" } return function() return shared end end)()
function Uh3_InputCons(v0, v1) return { tag = "Uh3_InputCons",  _1 = v0,  _2 = v1 } end

function random_bit_input_1(v0, v1, v2)
    local v3 = 0 < v1
    if v3 then
        local v4 = spiral_w64.mul(v0, 1103515245, false)
        local v5 = spiral_w64.add(v4, 12345, false)
        local v6 = spiral_w64.band(v5, 2147483647, false)
        local v7 = spiral_wrap_signed((v1 - 1), 32)
        local v8 = spiral_w64.shr(v6, 16, false)
        local v9 = spiral_w64.band(v8, 1, false)
        local v10 = spiral_w64.eq(v9, 0)
        local getv13 = function()
            if v10 then
                local v11 = Us0_BitZero()
                return v11
            else
                local v12 = Us0_BitOne()
                return v12
            end
        end
        local v13 = getv13()
        local v14 = Uh1_InputCons(v13, v2)
        return random_bit_input_1(v6, v7, v14)
    else
        return { [1]=v2, [2]=v0 }
    end
end

function run_2(v0, v1)
    if v1 ~= nil and v1.tag == "Uh1_InputCons" then
        local v4 = v1._1
        local v5 = v1._2
        local v6 = v0 == 0
        local getv19 = function()
            if v6 then
                local getv10 = function()
                    if v4 ~= nil and v4.tag == "Us0_BitOne" then
                        return Us1_SymbolGreater()
                    elseif v4 ~= nil and v4.tag == "Us0_BitZero" then
                        return Us1_SymbolSame()
                    end
                end
                local v10 = getv10()
                local getv11 = function()
                    if v10 ~= nil and v10.tag == "Us1_SymbolSame" then
                        return true
                    else
                        return false
                    end
                end
                local v11 = getv11()
                if v11 then
                    return 1
                else
                    return 0
                end
            else
                local getv16 = function()
                    if v4 ~= nil and v4.tag == "Us0_BitOne" then
                        return Us1_SymbolGreater()
                    elseif v4 ~= nil and v4.tag == "Us0_BitZero" then
                        return Us1_SymbolSame()
                    end
                end
                local v16 = getv16()
                local getv17 = function()
                    if v16 ~= nil and v16.tag == "Us1_SymbolSame" then
                        return true
                    else
                        return false
                    end
                end
                local v17 = getv17()
                if v17 then
                    return 1
                else
                    return 0
                end
            end
        end
        local v19 = getv19()
        return run_2(v19, v5)
    elseif v1 ~= nil and v1.tag == "Uh1_InputEmpty" then
        local v2 = v0 == 0
        local v3 = v2 == false
        return v3
    end
end

function regex_compare_8(v0, v1)
    if v0 ~= nil and v0.tag == "Uh0_RegexAlt" then
        local v53 = v0._1
        local v54 = v0._2
        if v1 ~= nil and v1.tag == "Uh0_RegexAlt" then
            local v55 = v1._1
            local v56 = v1._2
            local v57 = regex_compare_8(v53, v55)
            if v57 ~= nil and v57.tag == "Us1_SymbolSame" then
                return regex_compare_8(v54, v56)
            else
                return v57
            end
        else
            return Us1_SymbolGreater()
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexCat" then
        local v28 = v0._1
        local v29 = v0._2
        if v1 ~= nil and v1.tag == "Uh0_RegexCat" then
            local v34 = v1._1
            local v35 = v1._2
            local v36 = regex_compare_8(v28, v34)
            if v36 ~= nil and v36.tag == "Us1_SymbolSame" then
                return regex_compare_8(v29, v35)
            else
                return v36
            end
        elseif v1 ~= nil and v1.tag == "Uh0_RegexChar" then
            local v32 = v1._1
            return Us1_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh0_RegexEmpty" then
            return Us1_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh0_RegexEpsilon" then
            return Us1_SymbolGreater()
        else
            return Us1_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexChar" then
        local v10 = v0._1
        if v1 ~= nil and v1.tag == "Uh0_RegexChar" then
            local v13 = v1._1
            if v10 ~= nil and v10.tag == "Us0_BitOne" then
                if v13 ~= nil and v13.tag == "Us0_BitOne" then
                    return Us1_SymbolSame()
                elseif v13 ~= nil and v13.tag == "Us0_BitZero" then
                    return Us1_SymbolGreater()
                end
            elseif v10 ~= nil and v10.tag == "Us0_BitZero" then
                if v13 ~= nil and v13.tag == "Us0_BitOne" then
                    return Us1_SymbolLess()
                elseif v13 ~= nil and v13.tag == "Us0_BitZero" then
                    return Us1_SymbolSame()
                end
            end
        elseif v1 ~= nil and v1.tag == "Uh0_RegexEmpty" then
            return Us1_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh0_RegexEpsilon" then
            return Us1_SymbolGreater()
        else
            return Us1_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEmpty" then
        if v1 ~= nil and v1.tag == "Uh0_RegexEmpty" then
            return Us1_SymbolSame()
        else
            return Us1_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEpsilon" then
        if v1 ~= nil and v1.tag == "Uh0_RegexEmpty" then
            return Us1_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh0_RegexEpsilon" then
            return Us1_SymbolSame()
        else
            return Us1_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexStar" then
        local v44 = v0._1
        if v1 ~= nil and v1.tag == "Uh0_RegexAlt" then
            local v45 = v1._1
            local v46 = v1._2
            return Us1_SymbolLess()
        elseif v1 ~= nil and v1.tag == "Uh0_RegexStar" then
            local v48 = v1._1
            return regex_compare_8(v44, v48)
        else
            return Us1_SymbolGreater()
        end
    end
end

function alt_insert_sorted_7(v0, v1)
    if v1 ~= nil and v1.tag == "Uh0_RegexAlt" then
        local v2 = v1._1
        local v3 = v1._2
        local v4 = regex_compare_8(v0, v2)
        if v4 ~= nil and v4.tag == "Us1_SymbolGreater" then
            local v6 = alt_insert_sorted_7(v0, v3)
            return Uh0_RegexAlt(v2, v6)
        elseif v4 ~= nil and v4.tag == "Us1_SymbolLess" then
            return Uh0_RegexAlt(v0, v1)
        elseif v4 ~= nil and v4.tag == "Us1_SymbolSame" then
            return v1
        end
    elseif v1 ~= nil and v1.tag == "Uh0_RegexEmpty" then
        return v0
    else
        local v11 = regex_compare_8(v0, v1)
        if v11 ~= nil and v11.tag == "Us1_SymbolGreater" then
            return Uh0_RegexAlt(v1, v0)
        elseif v11 ~= nil and v11.tag == "Us1_SymbolLess" then
            return Uh0_RegexAlt(v0, v1)
        elseif v11 ~= nil and v11.tag == "Us1_SymbolSame" then
            return v1
        end
    end
end

function make_alt_6(v0, v1)
    if v0 ~= nil and v0.tag == "Uh0_RegexAlt" then
        local v2 = v0._1
        local v3 = v0._2
        local v4 = alt_insert_sorted_7(v2, v1)
        return make_alt_6(v3, v4)
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEmpty" then
        return v1
    else
        return alt_insert_sorted_7(v0, v1)
    end
end

function regex_equal_10(v0, v1)
    if v0 ~= nil and v0.tag == "Uh0_RegexAlt" then
        local v18 = v0._1
        local v19 = v0._2
        if v1 ~= nil and v1.tag == "Uh0_RegexAlt" then
            local v20 = v1._1
            local v21 = v1._2
            local v22 = regex_equal_10(v18, v20)
            if v22 then
                return regex_equal_10(v19, v21)
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexCat" then
        local v26 = v0._1
        local v27 = v0._2
        if v1 ~= nil and v1.tag == "Uh0_RegexCat" then
            local v28 = v1._1
            local v29 = v1._2
            local v30 = regex_equal_10(v26, v28)
            if v30 then
                return regex_equal_10(v27, v29)
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexChar" then
        local v4 = v0._1
        if v1 ~= nil and v1.tag == "Uh0_RegexChar" then
            local v5 = v1._1
            local getv15 = function()
                if v4 ~= nil and v4.tag == "Us0_BitOne" then
                    if v5 ~= nil and v5.tag == "Us0_BitOne" then
                        return Us1_SymbolSame()
                    elseif v5 ~= nil and v5.tag == "Us0_BitZero" then
                        return Us1_SymbolGreater()
                    end
                elseif v4 ~= nil and v4.tag == "Us0_BitZero" then
                    if v5 ~= nil and v5.tag == "Us0_BitOne" then
                        return Us1_SymbolLess()
                    elseif v5 ~= nil and v5.tag == "Us0_BitZero" then
                        return Us1_SymbolSame()
                    end
                end
            end
            local v15 = getv15()
            if v15 ~= nil and v15.tag == "Us1_SymbolSame" then
                return true
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEmpty" then
        if v1 ~= nil and v1.tag == "Uh0_RegexEmpty" then
            return true
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEpsilon" then
        if v1 ~= nil and v1.tag == "Uh0_RegexEpsilon" then
            return true
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexStar" then
        local v34 = v0._1
        if v1 ~= nil and v1.tag == "Uh0_RegexStar" then
            local v35 = v1._1
            return regex_equal_10(v34, v35)
        else
            return false
        end
    end
end

function make_cat_9(v0, v1)
    if v0 ~= nil and v0.tag == "Uh0_RegexEmpty" then
        return Uh0_RegexEmpty()
    else
        if v1 ~= nil and v1.tag == "Uh0_RegexEmpty" then
            return Uh0_RegexEmpty()
        else
            if v0 ~= nil and v0.tag == "Uh0_RegexEpsilon" then
                return v1
            else
                if v1 ~= nil and v1.tag == "Uh0_RegexEpsilon" then
                    return v0
                else
                    if v0 ~= nil and v0.tag == "Uh0_RegexCat" then
                        local v12 = v0._1
                        local v13 = v0._2
                        local v14 = make_cat_9(v13, v1)
                        return Uh0_RegexCat(v12, v14)
                    elseif v0 ~= nil and v0.tag == "Uh0_RegexStar" then
                        local v4 = v0._1
                        if v1 ~= nil and v1.tag == "Uh0_RegexStar" then
                            local v5 = v1._1
                            local v6 = regex_equal_10(v4, v5)
                            if v6 then
                                return Uh0_RegexStar(v4)
                            else
                                return Uh0_RegexCat(v0, v1)
                            end
                        else
                            return Uh0_RegexCat(v0, v1)
                        end
                    else
                        return Uh0_RegexCat(v0, v1)
                    end
                end
            end
        end
    end
end

function make_star_11(v0)
    if v0 ~= nil and v0.tag == "Uh0_RegexEmpty" then
        return Uh0_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEpsilon" then
        return Uh0_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh0_RegexStar" then
        local v3 = v0._1
        return Uh0_RegexStar(v3)
    else
        return Uh0_RegexStar(v0)
    end
end

function normalize_5(v0)
    if v0 ~= nil and v0.tag == "Uh0_RegexAlt" then
        local v5 = v0._1
        local v6 = v0._2
        local v7 = normalize_5(v5)
        local v8 = normalize_5(v6)
        return make_alt_6(v7, v8)
    elseif v0 ~= nil and v0.tag == "Uh0_RegexCat" then
        local v10 = v0._1
        local v11 = v0._2
        local v12 = normalize_5(v10)
        local v13 = normalize_5(v11)
        return make_cat_9(v12, v13)
    elseif v0 ~= nil and v0.tag == "Uh0_RegexChar" then
        local v3 = v0._1
        return Uh0_RegexChar(v3)
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEmpty" then
        return Uh0_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEpsilon" then
        return Uh0_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh0_RegexStar" then
        local v15 = v0._1
        local v16 = normalize_5(v15)
        return make_star_11(v16)
    end
end

function nullable_13(v0)
    if v0 ~= nil and v0.tag == "Uh0_RegexAlt" then
        local v5 = v0._1
        local v6 = v0._2
        local v7 = nullable_13(v5)
        local v8 = nullable_13(v6)
        if v7 ~= nil and v7.tag == "Us2_Nullable" then
            return Us2_Nullable()
        else
            if v8 ~= nil and v8.tag == "Us2_Nullable" then
                return Us2_Nullable()
            else
                if v7 ~= nil and v7.tag == "Us2_NonNullable" then
                    if v8 ~= nil and v8.tag == "Us2_NonNullable" then
                        return Us2_NonNullable()
                    end
                end
            end
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexCat" then
        local v16 = v0._1
        local v17 = v0._2
        local v18 = nullable_13(v16)
        local v19 = nullable_13(v17)
        if v18 ~= nil and v18.tag == "Us2_Nullable" then
            if v19 ~= nil and v19.tag == "Us2_Nullable" then
                return Us2_Nullable()
            else
                return Us2_NonNullable()
            end
        else
            return Us2_NonNullable()
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexChar" then
        local v3 = v0._1
        return Us2_NonNullable()
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEmpty" then
        return Us2_NonNullable()
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEpsilon" then
        return Us2_Nullable()
    elseif v0 ~= nil and v0.tag == "Uh0_RegexStar" then
        local v25 = v0._1
        return Us2_Nullable()
    end
end

function derivative_12(v0, v1)
    if v0 ~= nil and v0.tag == "Uh0_RegexAlt" then
        local v19 = v0._1
        local v20 = v0._2
        local v21 = derivative_12(v19, v1)
        local v22 = derivative_12(v20, v1)
        return make_alt_6(v21, v22)
    elseif v0 ~= nil and v0.tag == "Uh0_RegexCat" then
        local v24 = v0._1
        local v25 = v0._2
        local v26 = nullable_13(v24)
        if v26 ~= nil and v26.tag == "Us2_NonNullable" then
            local v31 = derivative_12(v24, v1)
            return make_cat_9(v31, v25)
        elseif v26 ~= nil and v26.tag == "Us2_Nullable" then
            local v27 = derivative_12(v24, v1)
            local v28 = make_cat_9(v27, v25)
            local v29 = derivative_12(v25, v1)
            return make_alt_6(v28, v29)
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexChar" then
        local v4 = v0._1
        local getv14 = function()
            if v4 ~= nil and v4.tag == "Us0_BitOne" then
                if v1 ~= nil and v1.tag == "Us0_BitOne" then
                    return Us1_SymbolSame()
                elseif v1 ~= nil and v1.tag == "Us0_BitZero" then
                    return Us1_SymbolGreater()
                end
            elseif v4 ~= nil and v4.tag == "Us0_BitZero" then
                if v1 ~= nil and v1.tag == "Us0_BitOne" then
                    return Us1_SymbolLess()
                elseif v1 ~= nil and v1.tag == "Us0_BitZero" then
                    return Us1_SymbolSame()
                end
            end
        end
        local v14 = getv14()
        local getv15 = function()
            if v14 ~= nil and v14.tag == "Us1_SymbolSame" then
                return true
            else
                return false
            end
        end
        local v15 = getv15()
        if v15 then
            return Uh0_RegexEpsilon()
        else
            return Uh0_RegexEmpty()
        end
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEmpty" then
        return Uh0_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh0_RegexEpsilon" then
        return Uh0_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh0_RegexStar" then
        local v35 = v0._1
        local v36 = derivative_12(v35, v1)
        local v37 = make_star_11(v35)
        return make_cat_9(v36, v37)
    end
end

function canonical_derivative_4(v0, v1)
    local v2 = normalize_5(v0)
    local v3 = derivative_12(v2, v1)
    return normalize_5(v3)
end

function accepts_3(v0, v1)
    if v1 ~= nil and v1.tag == "Uh1_InputCons" then
        local v6 = v1._1
        local v7 = v1._2
        local v8 = canonical_derivative_4(v0, v6)
        return accepts_3(v8, v7)
    elseif v1 ~= nil and v1.tag == "Uh1_InputEmpty" then
        local v2 = normalize_5(v0)
        local v3 = nullable_13(v2)
        if v3 ~= nil and v3.tag == "Us2_NonNullable" then
            return false
        elseif v3 ~= nil and v3.tag == "Us2_Nullable" then
            return true
        end
    end
end

function loop_0(v0, v1, v2, v3, v4)
    local v5 = 0 < v2
    if v5 then
        local v6 = Uh1_InputEmpty()
        local v7, v8 = (table.unpack or unpack)(random_bit_input_1(v3, v0, v6))
        local v9 = 0
        local v10 = run_2(v9, v7)
        local v11 = accepts_3(v1, v7)
        local getv13 = function()
            if v10 then
                return v11
            else
                local v12 = false == v11
                return v12
            end
        end
        local v13 = getv13()
        if v13 then
            local v14 = spiral_wrap_signed((v2 - 1), 32)
            local getv16 = function()
                if v10 then
                    local v15 = spiral_wrap_signed((v4 + 1), 32)
                    return v15
                else
                    return v4
                end
            end
            local v16 = getv16()
            return loop_0(v0, v1, v14, v8, v16)
        else
            return _G.error("brzozowski-compiled-core-disagrees-on-random-input")
        end
    else
        return v4
    end
end

function zeros_input_15(v0, v1)
    local v2 = 0 < v0
    if v2 then
        local v3 = spiral_wrap_signed((v0 - 1), 32)
        local v4 = Us0_BitZero()
        local v5 = Uh1_InputCons(v4, v1)
        return zeros_input_15(v3, v5)
    else
        return v1
    end
end

function run_16(v0, v1)
    if v1 ~= nil and v1.tag == "Uh1_InputCons" then
        local v5 = v1._1
        local v6 = v1._2
        local v7 = v0 == 0
        local getv26 = function()
            if v7 then
                return 1
            else
                local v13 = v0 == 1
                if v13 then
                    return 1
                else
                    local getv22 = function()
                        if v5 ~= nil and v5.tag == "Us0_BitOne" then
                            return Us1_SymbolGreater()
                        elseif v5 ~= nil and v5.tag == "Us0_BitZero" then
                            return Us1_SymbolSame()
                        end
                    end
                    local v22 = getv22()
                    local getv23 = function()
                        if v22 ~= nil and v22.tag == "Us1_SymbolSame" then
                            return true
                        else
                            return false
                        end
                    end
                    local v23 = getv23()
                    if v23 then
                        return 2
                    else
                        return 0
                    end
                end
            end
        end
        local v26 = getv26()
        return run_16(v26, v6)
    elseif v1 ~= nil and v1.tag == "Uh1_InputEmpty" then
        local v2 = v0 == 0
        if v2 then
            return true
        else
            return false
        end
    end
end

function loop_14(v0, v1, v2, v3)
    local v4 = v0 < v2
    if v4 then
        return v3
    else
        local v5 = Uh1_InputEmpty()
        local v6 = zeros_input_15(v2, v5)
        local v7 = 2
        local v8 = run_16(v7, v6)
        local v9 = accepts_3(v1, v6)
        local getv11 = function()
            if v8 then
                return v9
            else
                local v10 = false == v9
                return v10
            end
        end
        local v11 = getv11()
        local getv15 = function()
            if v11 then
                if v8 then
                    local v12 = spiral_wrap_signed((v3 + 1), 32)
                    return v12
                else
                    return v3
                end
            else
                return _G.error("brzozowski-compiled-core-disagrees-on-zero-run")
            end
        end
        local v15 = getv15()
        local v16 = Us0_BitOne()
        local v17 = Uh1_InputEmpty()
        local v18 = Uh1_InputCons(v16, v17)
        local v19 = zeros_input_15(v2, v18)
        local v20 = 2
        local v21 = run_16(v20, v19)
        local v22 = accepts_3(v1, v19)
        local getv24 = function()
            if v21 then
                return v22
            else
                local v23 = false == v22
                return v23
            end
        end
        local v24 = getv24()
        local getv28 = function()
            if v24 then
                if v21 then
                    local v25 = spiral_wrap_signed((v15 + 1), 32)
                    return v25
                else
                    return v15
                end
            else
                return _G.error("brzozowski-compiled-core-disagrees-on-zero-run")
            end
        end
        local v28 = getv28()
        local v29 = spiral_wrap_signed((v2 + 1), 32)
        return loop_14(v0, v1, v29, v28)
    end
end

function run_17(v0, v1)
    if v1 ~= nil and v1.tag == "Uh3_InputCons" then
        local v5 = v1._1
        local v6 = v1._2
        local v7 = v0 == 0
        local getv47 = function()
            if v7 then
                local getv10 = function()
                    if v5 ~= nil and v5.tag == "Us3_TriA" then
                        return Us1_SymbolSame()
                    else
                        return Us1_SymbolGreater()
                    end
                end
                local v10 = getv10()
                local getv11 = function()
                    if v10 ~= nil and v10.tag == "Us1_SymbolSame" then
                        return true
                    else
                        return false
                    end
                end
                local v11 = getv11()
                if v11 then
                    return 0
                else
                    local getv17 = function()
                        if v5 ~= nil and v5.tag == "Us3_TriA" then
                            return Us1_SymbolLess()
                        elseif v5 ~= nil and v5.tag == "Us3_TriB" then
                            return Us1_SymbolSame()
                        elseif v5 ~= nil and v5.tag == "Us3_TriC" then
                            return Us1_SymbolGreater()
                        end
                    end
                    local v17 = getv17()
                    local getv18 = function()
                        if v17 ~= nil and v17.tag == "Us1_SymbolSame" then
                            return true
                        else
                            return false
                        end
                    end
                    local v18 = getv18()
                    if v18 then
                        return 0
                    else
                        return 1
                    end
                end
            else
                local v21 = v0 == 1
                if v21 then
                    local getv24 = function()
                        if v5 ~= nil and v5.tag == "Us3_TriA" then
                            return Us1_SymbolSame()
                        else
                            return Us1_SymbolGreater()
                        end
                    end
                    local v24 = getv24()
                    local getv25 = function()
                        if v24 ~= nil and v24.tag == "Us1_SymbolSame" then
                            return true
                        else
                            return false
                        end
                    end
                    local v25 = getv25()
                    if v25 then
                        return 2
                    else
                        return 2
                    end
                else
                    local getv36 = function()
                        if v5 ~= nil and v5.tag == "Us3_TriA" then
                            return Us1_SymbolSame()
                        else
                            return Us1_SymbolGreater()
                        end
                    end
                    local v36 = getv36()
                    local getv37 = function()
                        if v36 ~= nil and v36.tag == "Us1_SymbolSame" then
                            return true
                        else
                            return false
                        end
                    end
                    local v37 = getv37()
                    if v37 then
                        return 2
                    else
                        return 2
                    end
                end
            end
        end
        local v47 = getv47()
        return run_17(v47, v6)
    elseif v1 ~= nil and v1.tag == "Uh3_InputEmpty" then
        local v2 = v0 == 0
        if v2 then
            return false
        else
            local v3 = v0 == 1
            return v3
        end
    end
end

function regex_compare_23(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v59 = v0._1
        local v60 = v0._2
        if v1 ~= nil and v1.tag == "Uh2_RegexAlt" then
            local v61 = v1._1
            local v62 = v1._2
            local v63 = regex_compare_23(v59, v61)
            if v63 ~= nil and v63.tag == "Us1_SymbolSame" then
                return regex_compare_23(v60, v62)
            else
                return v63
            end
        else
            return Us1_SymbolGreater()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v34 = v0._1
        local v35 = v0._2
        if v1 ~= nil and v1.tag == "Uh2_RegexCat" then
            local v40 = v1._1
            local v41 = v1._2
            local v42 = regex_compare_23(v34, v40)
            if v42 ~= nil and v42.tag == "Us1_SymbolSame" then
                return regex_compare_23(v35, v41)
            else
                return v42
            end
        elseif v1 ~= nil and v1.tag == "Uh2_RegexChar" then
            local v38 = v1._1
            return Us1_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Us1_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
            return Us1_SymbolGreater()
        else
            return Us1_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v10 = v0._1
        if v1 ~= nil and v1.tag == "Uh2_RegexChar" then
            local v13 = v1._1
            if v10 ~= nil and v10.tag == "Us3_TriA" then
                if v13 ~= nil and v13.tag == "Us3_TriA" then
                    return Us1_SymbolSame()
                else
                    return Us1_SymbolLess()
                end
            else
                if v13 ~= nil and v13.tag == "Us3_TriA" then
                    return Us1_SymbolGreater()
                else
                    if v10 ~= nil and v10.tag == "Us3_TriB" then
                        if v13 ~= nil and v13.tag == "Us3_TriB" then
                            return Us1_SymbolSame()
                        elseif v13 ~= nil and v13.tag == "Us3_TriC" then
                            return Us1_SymbolLess()
                        end
                    elseif v10 ~= nil and v10.tag == "Us3_TriC" then
                        if v13 ~= nil and v13.tag == "Us3_TriB" then
                            return Us1_SymbolGreater()
                        elseif v13 ~= nil and v13.tag == "Us3_TriC" then
                            return Us1_SymbolSame()
                        end
                    end
                end
            end
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Us1_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
            return Us1_SymbolGreater()
        else
            return Us1_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        if v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Us1_SymbolSame()
        else
            return Us1_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        if v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Us1_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
            return Us1_SymbolSame()
        else
            return Us1_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v50 = v0._1
        if v1 ~= nil and v1.tag == "Uh2_RegexAlt" then
            local v51 = v1._1
            local v52 = v1._2
            return Us1_SymbolLess()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexStar" then
            local v54 = v1._1
            return regex_compare_23(v50, v54)
        else
            return Us1_SymbolGreater()
        end
    end
end

function alt_insert_sorted_22(v0, v1)
    if v1 ~= nil and v1.tag == "Uh2_RegexAlt" then
        local v2 = v1._1
        local v3 = v1._2
        local v4 = regex_compare_23(v0, v2)
        if v4 ~= nil and v4.tag == "Us1_SymbolGreater" then
            local v6 = alt_insert_sorted_22(v0, v3)
            return Uh2_RegexAlt(v2, v6)
        elseif v4 ~= nil and v4.tag == "Us1_SymbolLess" then
            return Uh2_RegexAlt(v0, v1)
        elseif v4 ~= nil and v4.tag == "Us1_SymbolSame" then
            return v1
        end
    elseif v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
        return v0
    else
        local v11 = regex_compare_23(v0, v1)
        if v11 ~= nil and v11.tag == "Us1_SymbolGreater" then
            return Uh2_RegexAlt(v1, v0)
        elseif v11 ~= nil and v11.tag == "Us1_SymbolLess" then
            return Uh2_RegexAlt(v0, v1)
        elseif v11 ~= nil and v11.tag == "Us1_SymbolSame" then
            return v1
        end
    end
end

function make_alt_21(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v2 = v0._1
        local v3 = v0._2
        local v4 = alt_insert_sorted_22(v2, v1)
        return make_alt_21(v3, v4)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return v1
    else
        return alt_insert_sorted_22(v0, v1)
    end
end

function regex_equal_25(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v24 = v0._1
        local v25 = v0._2
        if v1 ~= nil and v1.tag == "Uh2_RegexAlt" then
            local v26 = v1._1
            local v27 = v1._2
            local v28 = regex_equal_25(v24, v26)
            if v28 then
                return regex_equal_25(v25, v27)
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v32 = v0._1
        local v33 = v0._2
        if v1 ~= nil and v1.tag == "Uh2_RegexCat" then
            local v34 = v1._1
            local v35 = v1._2
            local v36 = regex_equal_25(v32, v34)
            if v36 then
                return regex_equal_25(v33, v35)
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v4 = v0._1
        if v1 ~= nil and v1.tag == "Uh2_RegexChar" then
            local v5 = v1._1
            local getv21 = function()
                if v4 ~= nil and v4.tag == "Us3_TriA" then
                    if v5 ~= nil and v5.tag == "Us3_TriA" then
                        return Us1_SymbolSame()
                    else
                        return Us1_SymbolLess()
                    end
                else
                    if v5 ~= nil and v5.tag == "Us3_TriA" then
                        return Us1_SymbolGreater()
                    else
                        if v4 ~= nil and v4.tag == "Us3_TriB" then
                            if v5 ~= nil and v5.tag == "Us3_TriB" then
                                return Us1_SymbolSame()
                            elseif v5 ~= nil and v5.tag == "Us3_TriC" then
                                return Us1_SymbolLess()
                            end
                        elseif v4 ~= nil and v4.tag == "Us3_TriC" then
                            if v5 ~= nil and v5.tag == "Us3_TriB" then
                                return Us1_SymbolGreater()
                            elseif v5 ~= nil and v5.tag == "Us3_TriC" then
                                return Us1_SymbolSame()
                            end
                        end
                    end
                end
            end
            local v21 = getv21()
            if v21 ~= nil and v21.tag == "Us1_SymbolSame" then
                return true
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        if v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return true
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        if v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
            return true
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v40 = v0._1
        if v1 ~= nil and v1.tag == "Uh2_RegexStar" then
            local v41 = v1._1
            return regex_equal_25(v40, v41)
        else
            return false
        end
    end
end

function make_cat_24(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Uh2_RegexEmpty()
    else
        if v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Uh2_RegexEmpty()
        else
            if v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
                return v1
            else
                if v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
                    return v0
                else
                    if v0 ~= nil and v0.tag == "Uh2_RegexCat" then
                        local v12 = v0._1
                        local v13 = v0._2
                        local v14 = make_cat_24(v13, v1)
                        return Uh2_RegexCat(v12, v14)
                    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
                        local v4 = v0._1
                        if v1 ~= nil and v1.tag == "Uh2_RegexStar" then
                            local v5 = v1._1
                            local v6 = regex_equal_25(v4, v5)
                            if v6 then
                                return Uh2_RegexStar(v4)
                            else
                                return Uh2_RegexCat(v0, v1)
                            end
                        else
                            return Uh2_RegexCat(v0, v1)
                        end
                    else
                        return Uh2_RegexCat(v0, v1)
                    end
                end
            end
        end
    end
end

function make_star_26(v0)
    if v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Uh2_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        return Uh2_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v3 = v0._1
        return Uh2_RegexStar(v3)
    else
        return Uh2_RegexStar(v0)
    end
end

function normalize_20(v0)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v5 = v0._1
        local v6 = v0._2
        local v7 = normalize_20(v5)
        local v8 = normalize_20(v6)
        return make_alt_21(v7, v8)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v10 = v0._1
        local v11 = v0._2
        local v12 = normalize_20(v10)
        local v13 = normalize_20(v11)
        return make_cat_24(v12, v13)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v3 = v0._1
        return Uh2_RegexChar(v3)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Uh2_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        return Uh2_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v15 = v0._1
        local v16 = normalize_20(v15)
        return make_star_26(v16)
    end
end

function nullable_28(v0)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v5 = v0._1
        local v6 = v0._2
        local v7 = nullable_28(v5)
        local v8 = nullable_28(v6)
        if v7 ~= nil and v7.tag == "Us2_Nullable" then
            return Us2_Nullable()
        else
            if v8 ~= nil and v8.tag == "Us2_Nullable" then
                return Us2_Nullable()
            else
                if v7 ~= nil and v7.tag == "Us2_NonNullable" then
                    if v8 ~= nil and v8.tag == "Us2_NonNullable" then
                        return Us2_NonNullable()
                    end
                end
            end
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v16 = v0._1
        local v17 = v0._2
        local v18 = nullable_28(v16)
        local v19 = nullable_28(v17)
        if v18 ~= nil and v18.tag == "Us2_Nullable" then
            if v19 ~= nil and v19.tag == "Us2_Nullable" then
                return Us2_Nullable()
            else
                return Us2_NonNullable()
            end
        else
            return Us2_NonNullable()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v3 = v0._1
        return Us2_NonNullable()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Us2_NonNullable()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        return Us2_Nullable()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v25 = v0._1
        return Us2_Nullable()
    end
end

function derivative_27(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v25 = v0._1
        local v26 = v0._2
        local v27 = derivative_27(v25, v1)
        local v28 = derivative_27(v26, v1)
        return make_alt_21(v27, v28)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v30 = v0._1
        local v31 = v0._2
        local v32 = nullable_28(v30)
        if v32 ~= nil and v32.tag == "Us2_NonNullable" then
            local v37 = derivative_27(v30, v1)
            return make_cat_24(v37, v31)
        elseif v32 ~= nil and v32.tag == "Us2_Nullable" then
            local v33 = derivative_27(v30, v1)
            local v34 = make_cat_24(v33, v31)
            local v35 = derivative_27(v31, v1)
            return make_alt_21(v34, v35)
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v4 = v0._1
        local getv20 = function()
            if v4 ~= nil and v4.tag == "Us3_TriA" then
                if v1 ~= nil and v1.tag == "Us3_TriA" then
                    return Us1_SymbolSame()
                else
                    return Us1_SymbolLess()
                end
            else
                if v1 ~= nil and v1.tag == "Us3_TriA" then
                    return Us1_SymbolGreater()
                else
                    if v4 ~= nil and v4.tag == "Us3_TriB" then
                        if v1 ~= nil and v1.tag == "Us3_TriB" then
                            return Us1_SymbolSame()
                        elseif v1 ~= nil and v1.tag == "Us3_TriC" then
                            return Us1_SymbolLess()
                        end
                    elseif v4 ~= nil and v4.tag == "Us3_TriC" then
                        if v1 ~= nil and v1.tag == "Us3_TriB" then
                            return Us1_SymbolGreater()
                        elseif v1 ~= nil and v1.tag == "Us3_TriC" then
                            return Us1_SymbolSame()
                        end
                    end
                end
            end
        end
        local v20 = getv20()
        local getv21 = function()
            if v20 ~= nil and v20.tag == "Us1_SymbolSame" then
                return true
            else
                return false
            end
        end
        local v21 = getv21()
        if v21 then
            return Uh2_RegexEpsilon()
        else
            return Uh2_RegexEmpty()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Uh2_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        return Uh2_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v41 = v0._1
        local v42 = derivative_27(v41, v1)
        local v43 = make_star_26(v41)
        return make_cat_24(v42, v43)
    end
end

function canonical_derivative_19(v0, v1)
    local v2 = normalize_20(v0)
    local v3 = derivative_27(v2, v1)
    return normalize_20(v3)
end

function accepts_18(v0, v1)
    if v1 ~= nil and v1.tag == "Uh3_InputCons" then
        local v6 = v1._1
        local v7 = v1._2
        local v8 = canonical_derivative_19(v0, v6)
        return accepts_18(v8, v7)
    elseif v1 ~= nil and v1.tag == "Uh3_InputEmpty" then
        local v2 = normalize_20(v0)
        local v3 = nullable_28(v2)
        if v3 ~= nil and v3.tag == "Us2_NonNullable" then
            return false
        elseif v3 ~= nil and v3.tag == "Us2_Nullable" then
            return true
        end
    end
end

local v0 = 200
local v1 = 32
local v2 = 16
local v3 = Us0_BitZero()
local v4 = Uh0_RegexChar(v3)
local v5 = Us0_BitOne()
local v6 = Uh0_RegexChar(v5)
local v7 = Uh0_RegexAlt(v4, v6)
local v8 = Uh0_RegexStar(v7)
local v9 = Us0_BitZero()
local v10 = Uh0_RegexChar(v9)
local v11 = Uh0_RegexCat(v8, v10)
local v12 = 1
local v13 = 0
local v14 = loop_0(v1, v11, v0, v12, v13)
local v15 = v14 == 93
if v15 then
else
    _G.error("brzozowski-compiled-ends-with-zero-count")
end
local v16 = Us0_BitZero()
local v17 = Uh0_RegexChar(v16)
local v18 = Us0_BitZero()
local v19 = Uh0_RegexChar(v18)
local v20 = Us0_BitZero()
local v21 = Uh0_RegexChar(v20)
local v22 = Uh0_RegexCat(v19, v21)
local v23 = Uh0_RegexAlt(v17, v22)
local v24 = Uh0_RegexStar(v23)
local v25 = Us0_BitOne()
local v26 = Uh0_RegexChar(v25)
local v27 = Uh0_RegexCat(v24, v26)
local v28 = 1
local v29 = 0
local v30 = loop_14(v2, v27, v28, v29)
local v31 = v30 == 16
if v31 then
else
    _G.error("brzozowski-compiled-zero-runs-count")
end
local v32 = Us3_TriA()
local v33 = Uh2_RegexChar(v32)
local v34 = Us3_TriB()
local v35 = Uh2_RegexChar(v34)
local v36 = Uh2_RegexAlt(v33, v35)
local v37 = Uh2_RegexStar(v36)
local v38 = Us3_TriC()
local v39 = Uh2_RegexChar(v38)
local v40 = Uh2_RegexCat(v37, v39)
local v41 = Us3_TriA()
local v42 = Us3_TriB()
local v43 = Us3_TriA()
local v44 = Us3_TriC()
local v45 = Uh3_InputEmpty()
local v46 = Uh3_InputCons(v44, v45)
local v47 = Uh3_InputCons(v43, v46)
local v48 = Uh3_InputCons(v42, v47)
local v49 = Uh3_InputCons(v41, v48)
local v50 = Us3_TriA()
local v51 = Us3_TriB()
local v52 = Us3_TriA()
local v53 = Us3_TriB()
local v54 = Uh3_InputEmpty()
local v55 = Uh3_InputCons(v53, v54)
local v56 = Uh3_InputCons(v52, v55)
local v57 = Uh3_InputCons(v51, v56)
local v58 = Uh3_InputCons(v50, v57)
local v59 = 0
local v60 = run_17(v59, v49)
local getv62 = function()
    if v60 then
        return accepts_18(v40, v49)
    else
        return false
    end
end
local v62 = getv62()
local getv68 = function()
    if v62 then
        local v63 = 0
        local v64 = run_17(v63, v58)
        if v64 then
            return false
        else
            local v65 = accepts_18(v40, v58)
            local v66 = v65 == false
            return v66
        end
    else
        return false
    end
end
local v68 = getv68()
if v68 then
    return 0
else
    return _G.error("brzozowski-compiled-ternary-disagrees")
end
