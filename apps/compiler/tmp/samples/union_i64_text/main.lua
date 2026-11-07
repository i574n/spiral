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
local Us0_None, Us0_Both, score_0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Both(v0, v1) return { tag = "Us0_Both",  _1 = v0,  _2 = v1 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Both" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = spiral_w64.eq(v1, 5000000000)
        local getv5 = function()
            if v3 then
                local v4 = v2 == "hi"
                return v4
            else
                return false
            end
        end
        local v5 = getv5()
        if v5 then
            return 0
        else
            return 1
        end
    elseif v0 ~= nil and v0.tag == "Us0_None" then
        return 1
    end
end

local v0 = 5000000000
local v1 = "hi"
local v2 = true
local getv5 = function()
    if v2 then
        return Us0_Both(v0, v1)
    else
        return Us0_None()
    end
end
local v5 = getv5()
return score_0(v5)
