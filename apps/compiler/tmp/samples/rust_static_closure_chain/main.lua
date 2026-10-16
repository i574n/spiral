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
local Uh0_Cons, Uh0_Nil, closure79, closure78, closure77, closure76, closure75, closure74, closure73, closure72, closure71, closure70, closure69, closure68, closure67, closure66, closure65, closure64, closure63, closure62, closure61, closure60, closure59, closure58, closure57, closure56, closure55, closure54, closure53, closure52, closure51, closure50, closure49, closure48, closure47, closure46, closure45, closure44, closure43, closure42, closure41, closure40, closure39, closure38, closure37, closure36, closure35, closure34, closure33, closure32, closure31, closure30, closure29, closure28, closure27, closure26, closure25, closure24, closure23, closure22, closure21, closure20, closure19, closure18, closure17, closure16, closure15, closure14, closure13, closure12, closure11, closure10, closure9, closure8, closure7, closure6, closure5, closure4, closure3, closure2, closure1, closure0, loop_0
function Uh0_Cons(v0, v1) return { tag = "Uh0_Cons",  _1 = v0,  _2 = v1 } end
function Uh0_Nil() return { tag = "Uh0_Nil" } end

function closure79(capt)
    return function(dom)
        return Uh0_Nil()
    end
end

function closure78(capt)
    return function(dom)
        local v0 = closure79(nil)
        return Uh0_Cons(1, v0)
    end
end

function closure77(capt)
    return function(dom)
        local v0 = closure78(nil)
        return Uh0_Cons(2, v0)
    end
end

function closure76(capt)
    return function(dom)
        local v0 = closure77(nil)
        return Uh0_Cons(3, v0)
    end
end

function closure75(capt)
    return function(dom)
        local v0 = closure76(nil)
        return Uh0_Cons(4, v0)
    end
end

function closure74(capt)
    return function(dom)
        local v0 = closure75(nil)
        return Uh0_Cons(5, v0)
    end
end

function closure73(capt)
    return function(dom)
        local v0 = closure74(nil)
        return Uh0_Cons(6, v0)
    end
end

function closure72(capt)
    return function(dom)
        local v0 = closure73(nil)
        return Uh0_Cons(7, v0)
    end
end

function closure71(capt)
    return function(dom)
        local v0 = closure72(nil)
        return Uh0_Cons(8, v0)
    end
end

function closure70(capt)
    return function(dom)
        local v0 = closure71(nil)
        return Uh0_Cons(9, v0)
    end
end

function closure69(capt)
    return function(dom)
        local v0 = closure70(nil)
        return Uh0_Cons(10, v0)
    end
end

function closure68(capt)
    return function(dom)
        local v0 = closure69(nil)
        return Uh0_Cons(11, v0)
    end
end

function closure67(capt)
    return function(dom)
        local v0 = closure68(nil)
        return Uh0_Cons(12, v0)
    end
end

function closure66(capt)
    return function(dom)
        local v0 = closure67(nil)
        return Uh0_Cons(13, v0)
    end
end

function closure65(capt)
    return function(dom)
        local v0 = closure66(nil)
        return Uh0_Cons(14, v0)
    end
end

function closure64(capt)
    return function(dom)
        local v0 = closure65(nil)
        return Uh0_Cons(15, v0)
    end
end

function closure63(capt)
    return function(dom)
        local v0 = closure64(nil)
        return Uh0_Cons(16, v0)
    end
end

function closure62(capt)
    return function(dom)
        local v0 = closure63(nil)
        return Uh0_Cons(17, v0)
    end
end

function closure61(capt)
    return function(dom)
        local v0 = closure62(nil)
        return Uh0_Cons(18, v0)
    end
end

function closure60(capt)
    return function(dom)
        local v0 = closure61(nil)
        return Uh0_Cons(19, v0)
    end
end

function closure59(capt)
    return function(dom)
        local v0 = closure60(nil)
        return Uh0_Cons(20, v0)
    end
end

function closure58(capt)
    return function(dom)
        local v0 = closure59(nil)
        return Uh0_Cons(21, v0)
    end
end

function closure57(capt)
    return function(dom)
        local v0 = closure58(nil)
        return Uh0_Cons(22, v0)
    end
end

function closure56(capt)
    return function(dom)
        local v0 = closure57(nil)
        return Uh0_Cons(23, v0)
    end
end

function closure55(capt)
    return function(dom)
        local v0 = closure56(nil)
        return Uh0_Cons(24, v0)
    end
end

function closure54(capt)
    return function(dom)
        local v0 = closure55(nil)
        return Uh0_Cons(25, v0)
    end
end

function closure53(capt)
    return function(dom)
        local v0 = closure54(nil)
        return Uh0_Cons(26, v0)
    end
end

function closure52(capt)
    return function(dom)
        local v0 = closure53(nil)
        return Uh0_Cons(27, v0)
    end
end

function closure51(capt)
    return function(dom)
        local v0 = closure52(nil)
        return Uh0_Cons(28, v0)
    end
end

function closure50(capt)
    return function(dom)
        local v0 = closure51(nil)
        return Uh0_Cons(29, v0)
    end
end

function closure49(capt)
    return function(dom)
        local v0 = closure50(nil)
        return Uh0_Cons(30, v0)
    end
end

function closure48(capt)
    return function(dom)
        local v0 = closure49(nil)
        return Uh0_Cons(31, v0)
    end
end

function closure47(capt)
    return function(dom)
        local v0 = closure48(nil)
        return Uh0_Cons(32, v0)
    end
end

function closure46(capt)
    return function(dom)
        local v0 = closure47(nil)
        return Uh0_Cons(33, v0)
    end
end

function closure45(capt)
    return function(dom)
        local v0 = closure46(nil)
        return Uh0_Cons(34, v0)
    end
end

function closure44(capt)
    return function(dom)
        local v0 = closure45(nil)
        return Uh0_Cons(35, v0)
    end
end

function closure43(capt)
    return function(dom)
        local v0 = closure44(nil)
        return Uh0_Cons(36, v0)
    end
end

function closure42(capt)
    return function(dom)
        local v0 = closure43(nil)
        return Uh0_Cons(37, v0)
    end
end

function closure41(capt)
    return function(dom)
        local v0 = closure42(nil)
        return Uh0_Cons(38, v0)
    end
end

function closure40(capt)
    return function(dom)
        local v0 = closure41(nil)
        return Uh0_Cons(39, v0)
    end
end

function closure39(capt)
    return function(dom)
        local v0 = closure40(nil)
        return Uh0_Cons(40, v0)
    end
end

function closure38(capt)
    return function(dom)
        local v0 = closure39(nil)
        return Uh0_Cons(41, v0)
    end
end

function closure37(capt)
    return function(dom)
        local v0 = closure38(nil)
        return Uh0_Cons(42, v0)
    end
end

function closure36(capt)
    return function(dom)
        local v0 = closure37(nil)
        return Uh0_Cons(43, v0)
    end
end

function closure35(capt)
    return function(dom)
        local v0 = closure36(nil)
        return Uh0_Cons(44, v0)
    end
end

function closure34(capt)
    return function(dom)
        local v0 = closure35(nil)
        return Uh0_Cons(45, v0)
    end
end

function closure33(capt)
    return function(dom)
        local v0 = closure34(nil)
        return Uh0_Cons(46, v0)
    end
end

function closure32(capt)
    return function(dom)
        local v0 = closure33(nil)
        return Uh0_Cons(47, v0)
    end
end

function closure31(capt)
    return function(dom)
        local v0 = closure32(nil)
        return Uh0_Cons(48, v0)
    end
end

function closure30(capt)
    return function(dom)
        local v0 = closure31(nil)
        return Uh0_Cons(49, v0)
    end
end

function closure29(capt)
    return function(dom)
        local v0 = closure30(nil)
        return Uh0_Cons(50, v0)
    end
end

function closure28(capt)
    return function(dom)
        local v0 = closure29(nil)
        return Uh0_Cons(51, v0)
    end
end

function closure27(capt)
    return function(dom)
        local v0 = closure28(nil)
        return Uh0_Cons(52, v0)
    end
end

function closure26(capt)
    return function(dom)
        local v0 = closure27(nil)
        return Uh0_Cons(53, v0)
    end
end

function closure25(capt)
    return function(dom)
        local v0 = closure26(nil)
        return Uh0_Cons(54, v0)
    end
end

function closure24(capt)
    return function(dom)
        local v0 = closure25(nil)
        return Uh0_Cons(55, v0)
    end
end

function closure23(capt)
    return function(dom)
        local v0 = closure24(nil)
        return Uh0_Cons(56, v0)
    end
end

function closure22(capt)
    return function(dom)
        local v0 = closure23(nil)
        return Uh0_Cons(57, v0)
    end
end

function closure21(capt)
    return function(dom)
        local v0 = closure22(nil)
        return Uh0_Cons(58, v0)
    end
end

function closure20(capt)
    return function(dom)
        local v0 = closure21(nil)
        return Uh0_Cons(59, v0)
    end
end

function closure19(capt)
    return function(dom)
        local v0 = closure20(nil)
        return Uh0_Cons(60, v0)
    end
end

function closure18(capt)
    return function(dom)
        local v0 = closure19(nil)
        return Uh0_Cons(61, v0)
    end
end

function closure17(capt)
    return function(dom)
        local v0 = closure18(nil)
        return Uh0_Cons(62, v0)
    end
end

function closure16(capt)
    return function(dom)
        local v0 = closure17(nil)
        return Uh0_Cons(63, v0)
    end
end

function closure15(capt)
    return function(dom)
        local v0 = closure16(nil)
        return Uh0_Cons(64, v0)
    end
end

function closure14(capt)
    return function(dom)
        local v0 = closure15(nil)
        return Uh0_Cons(65, v0)
    end
end

function closure13(capt)
    return function(dom)
        local v0 = closure14(nil)
        return Uh0_Cons(66, v0)
    end
end

function closure12(capt)
    return function(dom)
        local v0 = closure13(nil)
        return Uh0_Cons(67, v0)
    end
end

function closure11(capt)
    return function(dom)
        local v0 = closure12(nil)
        return Uh0_Cons(68, v0)
    end
end

function closure10(capt)
    return function(dom)
        local v0 = closure11(nil)
        return Uh0_Cons(69, v0)
    end
end

function closure9(capt)
    return function(dom)
        local v0 = closure10(nil)
        return Uh0_Cons(70, v0)
    end
end

function closure8(capt)
    return function(dom)
        local v0 = closure9(nil)
        return Uh0_Cons(71, v0)
    end
end

function closure7(capt)
    return function(dom)
        local v0 = closure8(nil)
        return Uh0_Cons(72, v0)
    end
end

function closure6(capt)
    return function(dom)
        local v0 = closure7(nil)
        return Uh0_Cons(73, v0)
    end
end

function closure5(capt)
    return function(dom)
        local v0 = closure6(nil)
        return Uh0_Cons(74, v0)
    end
end

function closure4(capt)
    return function(dom)
        local v0 = closure5(nil)
        return Uh0_Cons(75, v0)
    end
end

function closure3(capt)
    return function(dom)
        local v0 = closure4(nil)
        return Uh0_Cons(76, v0)
    end
end

function closure2(capt)
    return function(dom)
        local v0 = closure3(nil)
        return Uh0_Cons(77, v0)
    end
end

function closure1(capt)
    return function(dom)
        local v0 = closure2(nil)
        return Uh0_Cons(78, v0)
    end
end

function closure0(capt)
    return function(dom)
        local v0 = closure1(nil)
        return Uh0_Cons(79, v0)
    end
end

function loop_0(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0_Cons" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = v3(nil)
        local v5 = spiral_w64.add(v1, v2, false)
        return loop_0(v4, v5)
    elseif __v[1] ~= nil and __v[1].tag == "Uh0_Nil" then
        return v1
    end
end

local v0 = 80
local v1 = closure0(nil)
local v2 = Uh0_Cons(v0, v1)
local v3 = 0
local v4 = loop_0(v2, v3)
local v5 = spiral_w64.mod(v4, 200, false)
local v6 = spiral_wrap_signed(spiral_w64.low(v5), 32)
return v6
