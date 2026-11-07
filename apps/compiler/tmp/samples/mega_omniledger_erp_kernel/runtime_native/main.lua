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
function Us0_TypedFxHashedStatementChecksumValidationAccepted(v0, v1, v2, v3, v4, v5) return { tag = "Us0_TypedFxHashedStatementChecksumValidationAccepted",  _1 = v0,  _2 = v1,  _3 = v2,  _4 = v3,  _5 = v4,  _6 = v5 } end
function Us0_TypedFxHashedStatementChecksumValidationRejected(v0, v1, v2) return { tag = "Us0_TypedFxHashedStatementChecksumValidationRejected",  _1 = v0,  _2 = v1,  _3 = v2 } end

local spilled = {}
spilled.v0 = 0 + 1
spilled.v1 = spilled.v0 + 1
spilled.v2 = spilled.v1 + 1
spilled.v3 = 0 + 1
spilled.v4 = spilled.v3 + 1
spilled.v5 = spilled.v4 + 1
spilled.v6 = 0 + 1
spilled.v7 = spilled.v6 + 1
spilled.v8 = 0 + 1
spilled.v9 = spilled.v8 + 1
spilled.v10 = spilled.v9 + 1
spilled.v11 = spilled.v10 + 1
spilled.v12 = 0 + 1
spilled.v14 = 0 + 1
spilled.v15 = spilled.v14 + 1
spilled.v16 = spilled.v15 + 1
spilled.v17 = spilled.v16 + 1
spilled.v18 = spilled.v17 + 1
spilled.v19 = 0 + 1
spilled.v20 = spiral_w64.add(spilled.v12, spilled.v12, true)
spilled.v21 = spiral_w64.add(spilled.v7, spilled.v20, true)
spilled.v22 = 0 + 1
spilled.v23 = spilled.v22 + 1
spilled.v24 = spilled.v23 + 1
spilled.v25 = 0 + 1
spilled.v26 = spilled.v25 + 1
spilled.v27 = spilled.v26 + 1
spilled.v28 = 0 + 1
spilled.v29 = spilled.v28 + 1
spilled.v30 = 0 + 1
spilled.v31 = spilled.v30 + 1
spilled.v32 = spilled.v31 + 1
spilled.v33 = spilled.v32 + 1
spilled.v34 = 0 + 1
spilled.v36 = 0 + 1
spilled.v37 = spilled.v36 + 1
spilled.v38 = spilled.v37 + 1
spilled.v39 = spilled.v38 + 1
spilled.v40 = spiral_w64.add(spilled.v34, spilled.v34, true)
spilled.v41 = spiral_w64.add(spilled.v29, spilled.v40, true)
spilled.v42 = spiral_w64.add(spilled.v18, spilled.v39, true)
spilled.v43 = spiral_w64.add(spilled.v21, spilled.v41, true)
spilled.v44 = spiral_w64.eq(spilled.v42, 9)
spilled.v45 = spiral_w64.eq(spilled.v19, 1)
spilled.v46 = spiral_w64.eq(spilled.v43, 8)
spilled.v47 = (spilled.v44) and (spilled.v45)
spilled.v48 = (spilled.v47) and (spilled.v46)
if spilled.v48 then
else
    _G.error("typed-usd-eur-determined-tie-rounding-runtime-mismatch")
end
spilled.v49 = 0 + 1
spilled.v50 = spilled.v49 + 1
spilled.v51 = spilled.v50 + 1
spilled.v52 = spilled.v51 + 1
spilled.v53 = 0 + 1
spilled.v54 = spilled.v53 + 1
spilled.v55 = spilled.v54 + 1
spilled.v56 = spilled.v55 + 1
spilled.v57 = spiral_w64.eq(spilled.v52, spilled.v56)
spilled.getv58 = function()
    if spilled.v57 then
        return 0
    else
        return 1
    end
end
spilled.v58 = spilled.getv58()
spilled.v59 = 0 + 1
spilled.v60 = 0 + 1
spilled.v61 = spiral_w64.eq(spilled.v59, spilled.v60)
spilled.getv62 = function()
    if spilled.v61 then
        return 0
    else
        return 1
    end
end
spilled.v62 = spilled.getv62()
spilled.v63 = 0 + 1
spilled.v64 = spilled.v63 + 1
spilled.v65 = spilled.v64 + 1
spilled.v66 = spilled.v65 + 1
spilled.v67 = spilled.v66 + 1
spilled.v68 = 0 + 1
spilled.v69 = spilled.v68 + 1
spilled.v70 = spilled.v69 + 1
spilled.v71 = spilled.v70 + 1
spilled.v72 = spilled.v71 + 1
spilled.v73 = spiral_w64.eq(spilled.v67, spilled.v72)
spilled.getv74 = function()
    if spilled.v73 then
        return 0
    else
        return 1
    end
end
spilled.v74 = spilled.getv74()
spilled.v75 = spiral_w64.add(spilled.v59, spilled.v67, true)
spilled.v76 = spiral_w64.add(spilled.v60, spilled.v72, true)
spilled.v77 = spiral_w64.add(spilled.v62, spilled.v74, true)
spilled.v78 = spiral_w64.add(spilled.v52, spilled.v75, true)
spilled.v79 = spiral_w64.add(spilled.v56, spilled.v76, true)
spilled.v80 = spiral_w64.add(spilled.v58, spilled.v77, true)
spilled.v81 = spiral_w64.eq(spilled.v78, 10)
spilled.v82 = spiral_w64.eq(spilled.v79, 10)
spilled.v83 = spiral_w64.eq(spilled.v80, 0)
spilled.v84 = (spilled.v81) and (spilled.v82)
spilled.v85 = (spilled.v84) and (spilled.v83)
if spilled.v85 then
else
    _G.error("typed-FX-statement-expected-raw-append-runtime-mismatch")
end
spilled.v86 = 0 + 1
spilled.v87 = spilled.v86 + 1
spilled.v88 = spilled.v87 + 1
spilled.v89 = spilled.v88 + 1
spilled.v90 = 0 + 1
spilled.v91 = spilled.v90 + 1
spilled.v92 = spilled.v91 + 1
spilled.v93 = spilled.v92 + 1
spilled.v94 = spiral_w64.eq(spilled.v89, spilled.v93)
spilled.getv95 = function()
    if spilled.v94 then
        return 0
    else
        return 1
    end
end
spilled.v95 = spilled.getv95()
spilled.v96 = 0 + 1
spilled.v97 = 0 + 1
spilled.v98 = spiral_w64.eq(spilled.v96, spilled.v97)
spilled.getv99 = function()
    if spilled.v98 then
        return 0
    else
        return 1
    end
end
spilled.v99 = spilled.getv99()
spilled.v100 = 0 + 1
spilled.v101 = spilled.v100 + 1
spilled.v102 = spilled.v101 + 1
spilled.v103 = spilled.v102 + 1
spilled.v104 = spilled.v103 + 1
spilled.v105 = 0 + 1
spilled.v106 = spilled.v105 + 1
spilled.v107 = spilled.v106 + 1
spilled.v108 = spilled.v107 + 1
spilled.v109 = spilled.v108 + 1
spilled.v110 = spiral_w64.eq(spilled.v104, spilled.v109)
spilled.getv111 = function()
    if spilled.v110 then
        return 0
    else
        return 1
    end
end
spilled.v111 = spilled.getv111()
spilled.v114 = spiral_w64.add(spilled.v99, spilled.v111, true)
spilled.v117 = spiral_w64.add(spilled.v95, spilled.v114, true)
spilled.v118 = 0 + 1
spilled.v119 = spilled.v118 + 1
spilled.v120 = spilled.v119 + 1
spilled.v121 = spilled.v120 + 1
spilled.v122 = 0 + 1
spilled.v123 = spilled.v122 + 1
spilled.v124 = spilled.v123 + 1
spilled.v125 = spilled.v124 + 1
spilled.v126 = spiral_w64.eq(spilled.v121, spilled.v125)
spilled.getv127 = function()
    if spilled.v126 then
        return 0
    else
        return 1
    end
end
spilled.v127 = spilled.getv127()
spilled.v128 = 0 + 1
spilled.v129 = 0 + 1
spilled.v130 = spiral_w64.eq(spilled.v128, spilled.v129)
spilled.getv131 = function()
    if spilled.v130 then
        return 0
    else
        return 1
    end
end
spilled.v131 = spilled.getv131()
spilled.v132 = 0 + 1
spilled.v133 = spilled.v132 + 1
spilled.v134 = spilled.v133 + 1
spilled.v135 = spilled.v134 + 1
spilled.v136 = spilled.v135 + 1
spilled.v137 = 0 + 1
spilled.v138 = spilled.v137 + 1
spilled.v139 = spilled.v138 + 1
spilled.v140 = spilled.v139 + 1
spilled.v141 = spilled.v140 + 1
spilled.v142 = spiral_w64.eq(spilled.v136, spilled.v141)
spilled.getv143 = function()
    if spilled.v142 then
        return 0
    else
        return 1
    end
end
spilled.v143 = spilled.getv143()
spilled.v146 = spiral_w64.add(spilled.v131, spilled.v143, true)
spilled.v149 = spiral_w64.add(spilled.v127, spilled.v146, true)
spilled.v150 = spiral_w64.add(spilled.v117, spilled.v149, true)
spilled.v151 = spiral_w64.eq(spilled.v150, 0)
if spilled.v151 then
else
    _G.error("typed-FX-statement-two-writer-raw-CAS-runtime-mismatch")
end
spilled.v152 = 0 + 1
spilled.v153 = spilled.v152 + 1
spilled.v154 = spilled.v153 + 1
spilled.v155 = spilled.v154 + 1
spilled.v156 = 0 + 1
spilled.v157 = spilled.v156 + 1
spilled.v158 = spilled.v157 + 1
spilled.v159 = spilled.v158 + 1
spilled.v160 = spiral_w64.eq(spilled.v155, spilled.v159)
spilled.getv161 = function()
    if spilled.v160 then
        return 0
    else
        return 1
    end
end
spilled.v161 = spilled.getv161()
spilled.v162 = 0 + 1
spilled.v163 = 0 + 1
spilled.v164 = spiral_w64.eq(spilled.v162, spilled.v163)
spilled.getv165 = function()
    if spilled.v164 then
        return 0
    else
        return 1
    end
end
spilled.v165 = spilled.getv165()
spilled.v166 = 0 + 1
spilled.v167 = spilled.v166 + 1
spilled.v168 = spilled.v167 + 1
spilled.v169 = spilled.v168 + 1
spilled.v170 = spilled.v169 + 1
spilled.v171 = 0 + 1
spilled.v172 = spilled.v171 + 1
spilled.v173 = spilled.v172 + 1
spilled.v174 = spilled.v173 + 1
spilled.v175 = spilled.v174 + 1
spilled.v176 = spiral_w64.eq(spilled.v170, spilled.v175)
spilled.getv177 = function()
    if spilled.v176 then
        return 0
    else
        return 1
    end
end
spilled.v177 = spilled.getv177()
spilled.v180 = spiral_w64.add(spilled.v165, spilled.v177, true)
spilled.v183 = spiral_w64.add(spilled.v161, spilled.v180, true)
spilled.v184 = 0 + 1
spilled.v185 = spilled.v184 + 1
spilled.v186 = spilled.v185 + 1
spilled.v187 = spilled.v186 + 1
spilled.v188 = 0 + 1
spilled.v189 = spilled.v188 + 1
spilled.v190 = spilled.v189 + 1
spilled.v191 = spilled.v190 + 1
spilled.v192 = spiral_w64.eq(spilled.v187, spilled.v191)
spilled.getv193 = function()
    if spilled.v192 then
        return 0
    else
        return 1
    end
end
spilled.v193 = spilled.getv193()
spilled.v194 = 0 + 1
spilled.v195 = 0 + 1
spilled.v196 = spiral_w64.eq(spilled.v194, spilled.v195)
spilled.getv197 = function()
    if spilled.v196 then
        return 0
    else
        return 1
    end
end
spilled.v197 = spilled.getv197()
spilled.v198 = 0 + 1
spilled.v199 = spilled.v198 + 1
spilled.v200 = spilled.v199 + 1
spilled.v201 = spilled.v200 + 1
spilled.v202 = spilled.v201 + 1
spilled.v203 = 0 + 1
spilled.v204 = spilled.v203 + 1
spilled.v205 = spilled.v204 + 1
spilled.v206 = spilled.v205 + 1
spilled.v207 = spilled.v206 + 1
spilled.v208 = spiral_w64.eq(spilled.v202, spilled.v207)
spilled.getv209 = function()
    if spilled.v208 then
        return 0
    else
        return 1
    end
end
spilled.v209 = spilled.getv209()
spilled.v212 = spiral_w64.add(spilled.v197, spilled.v209, true)
spilled.v215 = spiral_w64.add(spilled.v193, spilled.v212, true)
spilled.v216 = spiral_w64.add(spilled.v183, spilled.v215, true)
spilled.v217 = 0 + 1
spilled.v218 = spilled.v217 + 1
spilled.v219 = spilled.v218 + 1
spilled.v220 = spilled.v219 + 1
spilled.v221 = 0 + 1
spilled.v222 = spilled.v221 + 1
spilled.v223 = spilled.v222 + 1
spilled.v224 = spilled.v223 + 1
spilled.v225 = spiral_w64.eq(spilled.v220, spilled.v224)
spilled.getv226 = function()
    if spilled.v225 then
        return 0
    else
        return 1
    end
end
spilled.v226 = spilled.getv226()
spilled.v227 = 0 + 1
spilled.v228 = 0 + 1
spilled.v229 = spiral_w64.eq(spilled.v227, spilled.v228)
spilled.getv230 = function()
    if spilled.v229 then
        return 0
    else
        return 1
    end
end
spilled.v230 = spilled.getv230()
spilled.v231 = 0 + 1
spilled.v232 = spilled.v231 + 1
spilled.v233 = spilled.v232 + 1
spilled.v234 = spilled.v233 + 1
spilled.v235 = spilled.v234 + 1
spilled.v236 = 0 + 1
spilled.v237 = spilled.v236 + 1
spilled.v238 = spilled.v237 + 1
spilled.v239 = spilled.v238 + 1
spilled.v240 = spilled.v239 + 1
spilled.v241 = spiral_w64.eq(spilled.v235, spilled.v240)
spilled.getv242 = function()
    if spilled.v241 then
        return 0
    else
        return 1
    end
end
spilled.v242 = spilled.getv242()
spilled.v245 = spiral_w64.add(spilled.v230, spilled.v242, true)
spilled.v248 = spiral_w64.add(spilled.v226, spilled.v245, true)
spilled.v249 = spiral_w64.add(spilled.v216, spilled.v248, true)
spilled.v250 = spiral_w64.eq(spilled.v249, 0)
if spilled.v250 then
else
    _G.error("typed-FX-statement-three-writer-raw-CAS-runtime-mismatch")
end
spilled.v251 = 0 + 1
spilled.v252 = spilled.v251 + 1
spilled.v253 = spilled.v252 + 1
spilled.v254 = spilled.v253 + 1
spilled.v255 = 0 + 1
spilled.v256 = spilled.v255 + 1
spilled.v257 = spilled.v256 + 1
spilled.v258 = spilled.v257 + 1
spilled.v259 = spiral_w64.eq(spilled.v254, spilled.v258)
spilled.getv260 = function()
    if spilled.v259 then
        return 0
    else
        return 1
    end
end
spilled.v260 = spilled.getv260()
spilled.v261 = 0 + 1
spilled.v262 = 0 + 1
spilled.v263 = spiral_w64.eq(spilled.v261, spilled.v262)
spilled.getv264 = function()
    if spilled.v263 then
        return 0
    else
        return 1
    end
end
spilled.v264 = spilled.getv264()
spilled.v265 = 0 + 1
spilled.v266 = spilled.v265 + 1
spilled.v267 = spilled.v266 + 1
spilled.v268 = spilled.v267 + 1
spilled.v269 = spilled.v268 + 1
spilled.v270 = 0 + 1
spilled.v271 = spilled.v270 + 1
spilled.v272 = spilled.v271 + 1
spilled.v273 = spilled.v272 + 1
spilled.v274 = spilled.v273 + 1
spilled.v275 = spiral_w64.eq(spilled.v269, spilled.v274)
spilled.getv276 = function()
    if spilled.v275 then
        return 0
    else
        return 1
    end
end
spilled.v276 = spilled.getv276()
spilled.v279 = spiral_w64.add(spilled.v264, spilled.v276, true)
spilled.v282 = spiral_w64.add(spilled.v260, spilled.v279, true)
spilled.v283 = 0 + 1
spilled.v284 = spilled.v283 + 1
spilled.v285 = spilled.v284 + 1
spilled.v286 = spilled.v285 + 1
spilled.v287 = 0 + 1
spilled.v288 = spilled.v287 + 1
spilled.v289 = spilled.v288 + 1
spilled.v290 = spilled.v289 + 1
spilled.v291 = spiral_w64.eq(spilled.v286, spilled.v290)
spilled.getv292 = function()
    if spilled.v291 then
        return 0
    else
        return 1
    end
end
spilled.v292 = spilled.getv292()
spilled.v293 = 0 + 1
spilled.v294 = 0 + 1
spilled.v295 = spiral_w64.eq(spilled.v293, spilled.v294)
spilled.getv296 = function()
    if spilled.v295 then
        return 0
    else
        return 1
    end
end
spilled.v296 = spilled.getv296()
spilled.v297 = 0 + 1
spilled.v298 = spilled.v297 + 1
spilled.v299 = spilled.v298 + 1
spilled.v300 = spilled.v299 + 1
spilled.v301 = spilled.v300 + 1
spilled.v302 = 0 + 1
spilled.v303 = spilled.v302 + 1
spilled.v304 = spilled.v303 + 1
spilled.v305 = spilled.v304 + 1
spilled.v306 = spilled.v305 + 1
spilled.v307 = spiral_w64.eq(spilled.v301, spilled.v306)
spilled.getv308 = function()
    if spilled.v307 then
        return 0
    else
        return 1
    end
end
spilled.v308 = spilled.getv308()
spilled.v311 = spiral_w64.add(spilled.v296, spilled.v308, true)
spilled.v314 = spiral_w64.add(spilled.v292, spilled.v311, true)
spilled.v315 = spiral_w64.add(spilled.v282, spilled.v314, true)
spilled.v316 = 0 + 1
spilled.v317 = spilled.v316 + 1
spilled.v318 = spilled.v317 + 1
spilled.v319 = spilled.v318 + 1
spilled.v320 = 0 + 1
spilled.v321 = spilled.v320 + 1
spilled.v322 = spilled.v321 + 1
spilled.v323 = spilled.v322 + 1
spilled.v324 = spiral_w64.eq(spilled.v319, spilled.v323)
spilled.getv325 = function()
    if spilled.v324 then
        return 0
    else
        return 1
    end
end
spilled.v325 = spilled.getv325()
spilled.v326 = 0 + 1
spilled.v327 = 0 + 1
spilled.v328 = spiral_w64.eq(spilled.v326, spilled.v327)
spilled.getv329 = function()
    if spilled.v328 then
        return 0
    else
        return 1
    end
end
spilled.v329 = spilled.getv329()
spilled.v330 = 0 + 1
spilled.v331 = spilled.v330 + 1
spilled.v332 = spilled.v331 + 1
spilled.v333 = spilled.v332 + 1
spilled.v334 = spilled.v333 + 1
spilled.v335 = 0 + 1
spilled.v336 = spilled.v335 + 1
spilled.v337 = spilled.v336 + 1
spilled.v338 = spilled.v337 + 1
spilled.v339 = spilled.v338 + 1
spilled.v340 = spiral_w64.eq(spilled.v334, spilled.v339)
spilled.getv341 = function()
    if spilled.v340 then
        return 0
    else
        return 1
    end
end
spilled.v341 = spilled.getv341()
spilled.v344 = spiral_w64.add(spilled.v329, spilled.v341, true)
spilled.v347 = spiral_w64.add(spilled.v325, spilled.v344, true)
spilled.v348 = 0 + 1
spilled.v349 = spilled.v348 + 1
spilled.v350 = spilled.v349 + 1
spilled.v351 = spilled.v350 + 1
spilled.v352 = 0 + 1
spilled.v353 = spilled.v352 + 1
spilled.v354 = spilled.v353 + 1
spilled.v355 = spilled.v354 + 1
spilled.v356 = spiral_w64.eq(spilled.v351, spilled.v355)
spilled.getv357 = function()
    if spilled.v356 then
        return 0
    else
        return 1
    end
end
spilled.v357 = spilled.getv357()
spilled.v358 = 0 + 1
spilled.v359 = 0 + 1
spilled.v360 = spiral_w64.eq(spilled.v358, spilled.v359)
spilled.getv361 = function()
    if spilled.v360 then
        return 0
    else
        return 1
    end
end
spilled.v361 = spilled.getv361()
spilled.v362 = 0 + 1
spilled.v363 = spilled.v362 + 1
spilled.v364 = spilled.v363 + 1
spilled.v365 = spilled.v364 + 1
spilled.v366 = spilled.v365 + 1
spilled.v367 = 0 + 1
spilled.v368 = spilled.v367 + 1
spilled.v369 = spilled.v368 + 1
spilled.v370 = spilled.v369 + 1
spilled.v371 = spilled.v370 + 1
spilled.v372 = spiral_w64.eq(spilled.v366, spilled.v371)
spilled.getv373 = function()
    if spilled.v372 then
        return 0
    else
        return 1
    end
end
spilled.v373 = spilled.getv373()
spilled.v376 = spiral_w64.add(spilled.v361, spilled.v373, true)
spilled.v379 = spiral_w64.add(spilled.v357, spilled.v376, true)
spilled.v380 = spiral_w64.add(spilled.v347, spilled.v379, true)
spilled.v381 = spiral_w64.add(spilled.v315, spilled.v380, true)
spilled.v382 = spiral_w64.eq(spilled.v381, 0)
if spilled.v382 then
else
    _G.error("typed-FX-statement-recursive-writer-raw-CAS-runtime-mismatch")
end
spilled.v383 = 0 + 1
spilled.v384 = spilled.v383 + 1
spilled.v385 = spilled.v384 + 1
spilled.v386 = spilled.v385 + 1
spilled.v387 = 0 + 1
spilled.v388 = spilled.v387 + 1
spilled.v389 = spilled.v388 + 1
spilled.v390 = spilled.v389 + 1
spilled.v391 = spiral_w64.eq(spilled.v386, spilled.v390)
spilled.getv392 = function()
    if spilled.v391 then
        return 0
    else
        return 1
    end
end
spilled.v392 = spilled.getv392()
spilled.v393 = 0 + 1
spilled.v394 = 0 + 1
spilled.v395 = spiral_w64.eq(spilled.v393, spilled.v394)
spilled.getv396 = function()
    if spilled.v395 then
        return 0
    else
        return 1
    end
end
spilled.v396 = spilled.getv396()
spilled.v397 = 0 + 1
spilled.v398 = spilled.v397 + 1
spilled.v399 = spilled.v398 + 1
spilled.v400 = spilled.v399 + 1
spilled.v401 = spilled.v400 + 1
spilled.v402 = 0 + 1
spilled.v403 = spilled.v402 + 1
spilled.v404 = spilled.v403 + 1
spilled.v405 = spilled.v404 + 1
spilled.v406 = spilled.v405 + 1
spilled.v407 = spiral_w64.eq(spilled.v401, spilled.v406)
spilled.getv408 = function()
    if spilled.v407 then
        return 0
    else
        return 1
    end
end
spilled.v408 = spilled.getv408()
spilled.v411 = spiral_w64.add(spilled.v396, spilled.v408, true)
spilled.v414 = spiral_w64.add(spilled.v392, spilled.v411, true)
spilled.v415 = 0 + 1
spilled.v416 = spilled.v415 + 1
spilled.v417 = spilled.v416 + 1
spilled.v418 = spilled.v417 + 1
spilled.v419 = 0 + 1
spilled.v420 = spilled.v419 + 1
spilled.v421 = spilled.v420 + 1
spilled.v422 = spilled.v421 + 1
spilled.v423 = spiral_w64.eq(spilled.v418, spilled.v422)
spilled.getv424 = function()
    if spilled.v423 then
        return 0
    else
        return 1
    end
end
spilled.v424 = spilled.getv424()
spilled.v425 = 0 + 1
spilled.v426 = 0 + 1
spilled.v427 = spiral_w64.eq(spilled.v425, spilled.v426)
spilled.getv428 = function()
    if spilled.v427 then
        return 0
    else
        return 1
    end
end
spilled.v428 = spilled.getv428()
spilled.v429 = 0 + 1
spilled.v430 = spilled.v429 + 1
spilled.v431 = spilled.v430 + 1
spilled.v432 = spilled.v431 + 1
spilled.v433 = spilled.v432 + 1
spilled.v434 = 0 + 1
spilled.v435 = spilled.v434 + 1
spilled.v436 = spilled.v435 + 1
spilled.v437 = spilled.v436 + 1
spilled.v438 = spilled.v437 + 1
spilled.v439 = spiral_w64.eq(spilled.v433, spilled.v438)
spilled.getv440 = function()
    if spilled.v439 then
        return 0
    else
        return 1
    end
end
spilled.v440 = spilled.getv440()
spilled.v443 = spiral_w64.add(spilled.v428, spilled.v440, true)
spilled.v446 = spiral_w64.add(spilled.v424, spilled.v443, true)
spilled.v447 = spiral_w64.add(spilled.v414, spilled.v446, true)
spilled.v448 = 0 + 1
spilled.v449 = spilled.v448 + 1
spilled.v450 = spilled.v449 + 1
spilled.v451 = spilled.v450 + 1
spilled.v452 = 0 + 1
spilled.v453 = spilled.v452 + 1
spilled.v454 = spilled.v453 + 1
spilled.v455 = spilled.v454 + 1
spilled.v456 = spiral_w64.eq(spilled.v451, spilled.v455)
spilled.getv457 = function()
    if spilled.v456 then
        return 0
    else
        return 1
    end
end
spilled.v457 = spilled.getv457()
spilled.v458 = 0 + 1
spilled.v459 = 0 + 1
spilled.v460 = spiral_w64.eq(spilled.v458, spilled.v459)
spilled.getv461 = function()
    if spilled.v460 then
        return 0
    else
        return 1
    end
end
spilled.v461 = spilled.getv461()
spilled.v462 = 0 + 1
spilled.v463 = spilled.v462 + 1
spilled.v464 = spilled.v463 + 1
spilled.v465 = spilled.v464 + 1
spilled.v466 = spilled.v465 + 1
spilled.v467 = 0 + 1
spilled.v468 = spilled.v467 + 1
spilled.v469 = spilled.v468 + 1
spilled.v470 = spilled.v469 + 1
spilled.v471 = spilled.v470 + 1
spilled.v472 = spiral_w64.eq(spilled.v466, spilled.v471)
spilled.getv473 = function()
    if spilled.v472 then
        return 0
    else
        return 1
    end
end
spilled.v473 = spilled.getv473()
spilled.v476 = spiral_w64.add(spilled.v461, spilled.v473, true)
spilled.v479 = spiral_w64.add(spilled.v457, spilled.v476, true)
spilled.v480 = 0 + 1
spilled.v481 = spilled.v480 + 1
spilled.v482 = spilled.v481 + 1
spilled.v483 = spilled.v482 + 1
spilled.v484 = 0 + 1
spilled.v485 = spilled.v484 + 1
spilled.v486 = spilled.v485 + 1
spilled.v487 = spilled.v486 + 1
spilled.v488 = spiral_w64.eq(spilled.v483, spilled.v487)
spilled.getv489 = function()
    if spilled.v488 then
        return 0
    else
        return 1
    end
end
spilled.v489 = spilled.getv489()
spilled.v490 = 0 + 1
spilled.v491 = 0 + 1
spilled.v492 = spiral_w64.eq(spilled.v490, spilled.v491)
spilled.getv493 = function()
    if spilled.v492 then
        return 0
    else
        return 1
    end
end
spilled.v493 = spilled.getv493()
spilled.v494 = 0 + 1
spilled.v495 = spilled.v494 + 1
spilled.v496 = spilled.v495 + 1
spilled.v497 = spilled.v496 + 1
spilled.v498 = spilled.v497 + 1
spilled.v499 = 0 + 1
spilled.v500 = spilled.v499 + 1
spilled.v501 = spilled.v500 + 1
spilled.v502 = spilled.v501 + 1
spilled.v503 = spilled.v502 + 1
spilled.v504 = spiral_w64.eq(spilled.v498, spilled.v503)
spilled.getv505 = function()
    if spilled.v504 then
        return 0
    else
        return 1
    end
end
spilled.v505 = spilled.getv505()
spilled.v508 = spiral_w64.add(spilled.v493, spilled.v505, true)
spilled.v511 = spiral_w64.add(spilled.v489, spilled.v508, true)
spilled.v512 = spiral_w64.add(spilled.v479, spilled.v511, true)
spilled.v513 = spiral_w64.add(spilled.v447, spilled.v512, true)
spilled.v514 = 0 + 1
spilled.v515 = spilled.v514 + 1
spilled.v516 = spilled.v515 + 1
spilled.v517 = spilled.v516 + 1
spilled.v518 = 0 + 1
spilled.v519 = spilled.v518 + 1
spilled.v520 = spilled.v519 + 1
spilled.v521 = spilled.v520 + 1
spilled.v522 = spiral_w64.eq(spilled.v517, spilled.v521)
spilled.getv523 = function()
    if spilled.v522 then
        return 0
    else
        return 1
    end
end
spilled.v523 = spilled.getv523()
spilled.v524 = 0 + 1
spilled.v525 = 0 + 1
spilled.v526 = spiral_w64.eq(spilled.v524, spilled.v525)
spilled.getv527 = function()
    if spilled.v526 then
        return 0
    else
        return 1
    end
end
spilled.v527 = spilled.getv527()
spilled.v528 = 0 + 1
spilled.v529 = spilled.v528 + 1
spilled.v530 = spilled.v529 + 1
spilled.v531 = spilled.v530 + 1
spilled.v532 = spilled.v531 + 1
spilled.v533 = 0 + 1
spilled.v534 = spilled.v533 + 1
spilled.v535 = spilled.v534 + 1
spilled.v536 = spilled.v535 + 1
spilled.v537 = spilled.v536 + 1
spilled.v538 = spiral_w64.eq(spilled.v532, spilled.v537)
spilled.getv539 = function()
    if spilled.v538 then
        return 0
    else
        return 1
    end
end
spilled.v539 = spilled.getv539()
spilled.v540 = spiral_w64.add(spilled.v524, spilled.v532, true)
spilled.v541 = spiral_w64.add(spilled.v525, spilled.v537, true)
spilled.v542 = spiral_w64.add(spilled.v527, spilled.v539, true)
spilled.v543 = spiral_w64.add(spilled.v517, spilled.v540, true)
spilled.v544 = spiral_w64.add(spilled.v521, spilled.v541, true)
spilled.v545 = spiral_w64.add(spilled.v523, spilled.v542, true)
spilled.v546 = spiral_w64.add(spilled.v544, spilled.v545, true)
spilled.v547 = spiral_w64.add(spilled.v543, spilled.v546, true)
spilled.v548 = spiral_w64.add(3, spilled.v547, true)
spilled.v549 = 0 + 1
spilled.v550 = spilled.v549 + 1
spilled.v551 = spilled.v550 + 1
spilled.v552 = spilled.v551 + 1
spilled.v553 = 0 + 1
spilled.v554 = spilled.v553 + 1
spilled.v555 = spilled.v554 + 1
spilled.v556 = spilled.v555 + 1
spilled.v557 = spiral_w64.eq(spilled.v552, spilled.v556)
spilled.getv558 = function()
    if spilled.v557 then
        return 0
    else
        return 1
    end
end
spilled.v558 = spilled.getv558()
spilled.v559 = 0 + 1
spilled.v560 = 0 + 1
spilled.v561 = spiral_w64.eq(spilled.v559, spilled.v560)
spilled.getv562 = function()
    if spilled.v561 then
        return 0
    else
        return 1
    end
end
spilled.v562 = spilled.getv562()
spilled.v563 = 0 + 1
spilled.v564 = spilled.v563 + 1
spilled.v565 = spilled.v564 + 1
spilled.v566 = spilled.v565 + 1
spilled.v567 = spilled.v566 + 1
spilled.v568 = 0 + 1
spilled.v569 = spilled.v568 + 1
spilled.v570 = spilled.v569 + 1
spilled.v571 = spilled.v570 + 1
spilled.v572 = spilled.v571 + 1
spilled.v573 = spiral_w64.eq(spilled.v567, spilled.v572)
spilled.getv574 = function()
    if spilled.v573 then
        return 0
    else
        return 1
    end
end
spilled.v574 = spilled.getv574()
spilled.v575 = spiral_w64.add(spilled.v559, spilled.v567, true)
spilled.v576 = spiral_w64.add(spilled.v560, spilled.v572, true)
spilled.v577 = spiral_w64.add(spilled.v562, spilled.v574, true)
spilled.v578 = spiral_w64.add(spilled.v552, spilled.v575, true)
spilled.v579 = spiral_w64.add(spilled.v556, spilled.v576, true)
spilled.v580 = spiral_w64.add(spilled.v558, spilled.v577, true)
spilled.v581 = spiral_w64.add(spilled.v579, spilled.v580, true)
spilled.v582 = spiral_w64.add(spilled.v578, spilled.v581, true)
spilled.v583 = spiral_w64.add(3, spilled.v582, true)
spilled.v584 = spiral_w64.eq(spilled.v548, spilled.v583)
spilled.getv621 = function()
    if spilled.v584 then
        local v585 = 0 + 1
        local v586 = v585 + 1
        local v587 = v586 + 1
        local v588 = v587 + 1
        local v589 = 0 + 1
        local v590 = v589 + 1
        local v591 = v590 + 1
        local v592 = v591 + 1
        local v593 = spiral_w64.eq(v588, v592)
        local getv594 = function()
            if v593 then
                return 0
            else
                return 1
            end
        end
        local v594 = getv594()
        local v595 = 0 + 1
        local v596 = 0 + 1
        local v597 = spiral_w64.eq(v595, v596)
        local getv598 = function()
            if v597 then
                return 0
            else
                return 1
            end
        end
        local v598 = getv598()
        local v599 = 0 + 1
        local v600 = v599 + 1
        local v601 = v600 + 1
        local v602 = v601 + 1
        local v603 = v602 + 1
        local v604 = 0 + 1
        local v605 = v604 + 1
        local v606 = v605 + 1
        local v607 = v606 + 1
        local v608 = v607 + 1
        local v609 = spiral_w64.eq(v603, v608)
        local getv610 = function()
            if v609 then
                return 0
            else
                return 1
            end
        end
        local v610 = getv610()
        local v611 = spiral_w64.add(v595, v603, true)
        local v612 = spiral_w64.add(v596, v608, true)
        local v613 = spiral_w64.add(v598, v610, true)
        local v614 = spiral_w64.add(v588, v611, true)
        local v615 = spiral_w64.add(v592, v612, true)
        local v616 = spiral_w64.add(v594, v613, true)
        local v617 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        return Us0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v614, v615, v616, v617)
    else
        local v619 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        return Us0_TypedFxHashedStatementChecksumValidationRejected(spilled.v548, spilled.v583, v619)
    end
end
spilled.v621 = spilled.getv621()
spilled.getv640 = function()
    if spilled.v621 ~= nil and spilled.v621.tag == "Us0_TypedFxHashedStatementChecksumValidationAccepted" then
        local v625 = spilled.v621._1
        local v626 = spilled.v621._2
        local v627 = spilled.v621._3
        local v628 = spilled.v621._4
        local v629 = spilled.v621._5
        local v630 = spilled.v621._6
        return { [1]=1, [2]=0, [3]=v625, [4]=v626, [5]=v627, [6]=v628, [7]=v629 }
    elseif spilled.v621 ~= nil and spilled.v621.tag == "Us0_TypedFxHashedStatementChecksumValidationRejected" then
        local v622 = spilled.v621._1
        local v623 = spilled.v621._2
        local v624 = spilled.v621._3
        return { [1]=0, [2]=1, [3]=0, [4]=0, [5]=0, [6]=0, [7]=0 }
    end
end
spilled.v640, spilled.v641, spilled.v644, spilled.v645, spilled.v646, spilled.v647, spilled.v648 = (table.unpack or unpack)(spilled.getv640())
spilled.v649 = spiral_w64.eq(spilled.v513, 0)
spilled.v650 = spiral_w64.eq(spilled.v548, 23)
spilled.v651 = spiral_w64.eq(spilled.v640, 1)
spilled.v652 = spiral_w64.eq(spilled.v641, 0)
spilled.v653 = spiral_w64.eq(spilled.v644, 1)
spilled.v654 = spiral_w64.eq(spilled.v645, 3)
spilled.v655 = spiral_w64.eq(spilled.v646, 10)
spilled.v656 = spiral_w64.eq(spilled.v647, 10)
spilled.v657 = spiral_w64.eq(spilled.v648, 0)
spilled.v658 = (spilled.v649) and (spilled.v650)
spilled.v659 = (spilled.v658) and (spilled.v651)
spilled.v660 = (spilled.v659) and (spilled.v652)
spilled.v661 = (spilled.v660) and (spilled.v653)
spilled.v662 = (spilled.v661) and (spilled.v654)
spilled.v663 = (spilled.v662) and (spilled.v655)
spilled.v664 = (spilled.v663) and (spilled.v656)
spilled.v665 = (spilled.v664) and (spilled.v657)
if spilled.v665 then
else
    _G.error("typed-FX-statement-recursive-writer-checksummed-restart-runtime-mismatch")
end
spilled.v666 = 0 + 1
spilled.v667 = spilled.v666 + 1
spilled.v668 = spilled.v667 + 1
spilled.v669 = spilled.v668 + 1
spilled.v670 = 0 + 1
spilled.v671 = spilled.v670 + 1
spilled.v672 = spilled.v671 + 1
spilled.v673 = spilled.v672 + 1
spilled.v674 = spiral_w64.eq(spilled.v669, spilled.v673)
spilled.getv675 = function()
    if spilled.v674 then
        return 0
    else
        return 1
    end
end
spilled.v675 = spilled.getv675()
spilled.v676 = 0 + 1
spilled.v677 = 0 + 1
spilled.v678 = spiral_w64.eq(spilled.v676, spilled.v677)
spilled.getv679 = function()
    if spilled.v678 then
        return 0
    else
        return 1
    end
end
spilled.v679 = spilled.getv679()
spilled.v680 = 0 + 1
spilled.v681 = spilled.v680 + 1
spilled.v682 = spilled.v681 + 1
spilled.v683 = spilled.v682 + 1
spilled.v684 = spilled.v683 + 1
spilled.v685 = 0 + 1
spilled.v686 = spilled.v685 + 1
spilled.v687 = spilled.v686 + 1
spilled.v688 = spilled.v687 + 1
spilled.v689 = spilled.v688 + 1
spilled.v690 = spiral_w64.eq(spilled.v684, spilled.v689)
spilled.getv691 = function()
    if spilled.v690 then
        return 0
    else
        return 1
    end
end
spilled.v691 = spilled.getv691()
spilled.v694 = spiral_w64.add(spilled.v679, spilled.v691, true)
spilled.v697 = spiral_w64.add(spilled.v675, spilled.v694, true)
spilled.v698 = 0 + 1
spilled.v699 = spilled.v698 + 1
spilled.v700 = spilled.v699 + 1
spilled.v701 = spilled.v700 + 1
spilled.v702 = 0 + 1
spilled.v703 = spilled.v702 + 1
spilled.v704 = spilled.v703 + 1
spilled.v705 = spilled.v704 + 1
spilled.v706 = spiral_w64.eq(spilled.v701, spilled.v705)
spilled.getv707 = function()
    if spilled.v706 then
        return 0
    else
        return 1
    end
end
spilled.v707 = spilled.getv707()
spilled.v708 = 0 + 1
spilled.v709 = 0 + 1
spilled.v710 = spiral_w64.eq(spilled.v708, spilled.v709)
spilled.getv711 = function()
    if spilled.v710 then
        return 0
    else
        return 1
    end
end
spilled.v711 = spilled.getv711()
spilled.v712 = 0 + 1
spilled.v713 = spilled.v712 + 1
spilled.v714 = spilled.v713 + 1
spilled.v715 = spilled.v714 + 1
spilled.v716 = spilled.v715 + 1
spilled.v717 = 0 + 1
spilled.v718 = spilled.v717 + 1
spilled.v719 = spilled.v718 + 1
spilled.v720 = spilled.v719 + 1
spilled.v721 = spilled.v720 + 1
spilled.v722 = spiral_w64.eq(spilled.v716, spilled.v721)
spilled.getv723 = function()
    if spilled.v722 then
        return 0
    else
        return 1
    end
end
spilled.v723 = spilled.getv723()
spilled.v726 = spiral_w64.add(spilled.v711, spilled.v723, true)
spilled.v729 = spiral_w64.add(spilled.v707, spilled.v726, true)
spilled.v730 = spiral_w64.add(spilled.v697, spilled.v729, true)
spilled.v731 = 0 + 1
spilled.v732 = spilled.v731 + 1
spilled.v733 = spilled.v732 + 1
spilled.v734 = spilled.v733 + 1
spilled.v735 = 0 + 1
spilled.v736 = spilled.v735 + 1
spilled.v737 = spilled.v736 + 1
spilled.v738 = spilled.v737 + 1
spilled.v739 = spiral_w64.eq(spilled.v734, spilled.v738)
spilled.getv740 = function()
    if spilled.v739 then
        return 0
    else
        return 1
    end
end
spilled.v740 = spilled.getv740()
spilled.v741 = 0 + 1
spilled.v742 = 0 + 1
spilled.v743 = spiral_w64.eq(spilled.v741, spilled.v742)
spilled.getv744 = function()
    if spilled.v743 then
        return 0
    else
        return 1
    end
end
spilled.v744 = spilled.getv744()
spilled.v745 = 0 + 1
spilled.v746 = spilled.v745 + 1
spilled.v747 = spilled.v746 + 1
spilled.v748 = spilled.v747 + 1
spilled.v749 = spilled.v748 + 1
spilled.v750 = 0 + 1
spilled.v751 = spilled.v750 + 1
spilled.v752 = spilled.v751 + 1
spilled.v753 = spilled.v752 + 1
spilled.v754 = spilled.v753 + 1
spilled.v755 = spiral_w64.eq(spilled.v749, spilled.v754)
spilled.getv756 = function()
    if spilled.v755 then
        return 0
    else
        return 1
    end
end
spilled.v756 = spilled.getv756()
spilled.v759 = spiral_w64.add(spilled.v744, spilled.v756, true)
spilled.v762 = spiral_w64.add(spilled.v740, spilled.v759, true)
spilled.v763 = 0 + 1
spilled.v764 = spilled.v763 + 1
spilled.v765 = spilled.v764 + 1
spilled.v766 = spilled.v765 + 1
spilled.v767 = 0 + 1
spilled.v768 = spilled.v767 + 1
spilled.v769 = spilled.v768 + 1
spilled.v770 = spilled.v769 + 1
spilled.v771 = spiral_w64.eq(spilled.v766, spilled.v770)
spilled.getv772 = function()
    if spilled.v771 then
        return 0
    else
        return 1
    end
end
spilled.v772 = spilled.getv772()
spilled.v773 = 0 + 1
spilled.v774 = 0 + 1
spilled.v775 = spiral_w64.eq(spilled.v773, spilled.v774)
spilled.getv776 = function()
    if spilled.v775 then
        return 0
    else
        return 1
    end
end
spilled.v776 = spilled.getv776()
spilled.v777 = 0 + 1
spilled.v778 = spilled.v777 + 1
spilled.v779 = spilled.v778 + 1
spilled.v780 = spilled.v779 + 1
spilled.v781 = spilled.v780 + 1
spilled.v782 = 0 + 1
spilled.v783 = spilled.v782 + 1
spilled.v784 = spilled.v783 + 1
spilled.v785 = spilled.v784 + 1
spilled.v786 = spilled.v785 + 1
spilled.v787 = spiral_w64.eq(spilled.v781, spilled.v786)
spilled.getv788 = function()
    if spilled.v787 then
        return 0
    else
        return 1
    end
end
spilled.v788 = spilled.getv788()
spilled.v791 = spiral_w64.add(spilled.v776, spilled.v788, true)
spilled.v794 = spiral_w64.add(spilled.v772, spilled.v791, true)
spilled.v795 = spiral_w64.add(spilled.v762, spilled.v794, true)
spilled.v796 = spiral_w64.add(spilled.v730, spilled.v795, true)
spilled.v797 = 0 + 1
spilled.v798 = spilled.v797 + 1
spilled.v799 = spilled.v798 + 1
spilled.v800 = spilled.v799 + 1
spilled.v801 = 0 + 1
spilled.v802 = spilled.v801 + 1
spilled.v803 = spilled.v802 + 1
spilled.v804 = spilled.v803 + 1
spilled.v805 = spiral_w64.eq(spilled.v800, spilled.v804)
spilled.getv806 = function()
    if spilled.v805 then
        return 0
    else
        return 1
    end
end
spilled.v806 = spilled.getv806()
spilled.v807 = 0 + 1
spilled.v808 = 0 + 1
spilled.v809 = spiral_w64.eq(spilled.v807, spilled.v808)
spilled.getv810 = function()
    if spilled.v809 then
        return 0
    else
        return 1
    end
end
spilled.v810 = spilled.getv810()
spilled.v811 = 0 + 1
spilled.v812 = spilled.v811 + 1
spilled.v813 = spilled.v812 + 1
spilled.v814 = spilled.v813 + 1
spilled.v815 = spilled.v814 + 1
spilled.v816 = 0 + 1
spilled.v817 = spilled.v816 + 1
spilled.v818 = spilled.v817 + 1
spilled.v819 = spilled.v818 + 1
spilled.v820 = spilled.v819 + 1
spilled.v821 = spiral_w64.eq(spilled.v815, spilled.v820)
spilled.getv822 = function()
    if spilled.v821 then
        return 0
    else
        return 1
    end
end
spilled.v822 = spilled.getv822()
spilled.v823 = spiral_w64.add(spilled.v807, spilled.v815, true)
spilled.v824 = spiral_w64.add(spilled.v808, spilled.v820, true)
spilled.v825 = spiral_w64.add(spilled.v810, spilled.v822, true)
spilled.v826 = spiral_w64.add(spilled.v800, spilled.v823, true)
spilled.v827 = spiral_w64.add(spilled.v804, spilled.v824, true)
spilled.v828 = spiral_w64.add(spilled.v806, spilled.v825, true)
spilled.v829 = spiral_w64.add(spilled.v827, spilled.v828, true)
spilled.v830 = spiral_w64.add(spilled.v826, spilled.v829, true)
spilled.v831 = spiral_w64.add(3, spilled.v830, true)
spilled.v832 = 0 + 1
spilled.v833 = spilled.v832 + 1
spilled.v834 = spilled.v833 + 1
spilled.v835 = spilled.v834 + 1
spilled.v836 = 0 + 1
spilled.v837 = spilled.v836 + 1
spilled.v838 = spilled.v837 + 1
spilled.v839 = spilled.v838 + 1
spilled.v840 = spiral_w64.eq(spilled.v835, spilled.v839)
spilled.getv841 = function()
    if spilled.v840 then
        return 0
    else
        return 1
    end
end
spilled.v841 = spilled.getv841()
spilled.v842 = 0 + 1
spilled.v843 = 0 + 1
spilled.v844 = spiral_w64.eq(spilled.v842, spilled.v843)
spilled.getv845 = function()
    if spilled.v844 then
        return 0
    else
        return 1
    end
end
spilled.v845 = spilled.getv845()
spilled.v846 = 0 + 1
spilled.v847 = spilled.v846 + 1
spilled.v848 = spilled.v847 + 1
spilled.v849 = spilled.v848 + 1
spilled.v850 = spilled.v849 + 1
spilled.v851 = 0 + 1
spilled.v852 = spilled.v851 + 1
spilled.v853 = spilled.v852 + 1
spilled.v854 = spilled.v853 + 1
spilled.v855 = spilled.v854 + 1
spilled.v856 = spiral_w64.eq(spilled.v850, spilled.v855)
spilled.getv857 = function()
    if spilled.v856 then
        return 0
    else
        return 1
    end
end
spilled.v857 = spilled.getv857()
spilled.v858 = spiral_w64.add(spilled.v842, spilled.v850, true)
spilled.v859 = spiral_w64.add(spilled.v843, spilled.v855, true)
spilled.v860 = spiral_w64.add(spilled.v845, spilled.v857, true)
spilled.v861 = spiral_w64.add(spilled.v835, spilled.v858, true)
spilled.v862 = spiral_w64.add(spilled.v839, spilled.v859, true)
spilled.v863 = spiral_w64.add(spilled.v841, spilled.v860, true)
spilled.v864 = spiral_w64.add(spilled.v862, spilled.v863, true)
spilled.v865 = spiral_w64.add(spilled.v861, spilled.v864, true)
spilled.v866 = spiral_w64.add(3, spilled.v865, true)
spilled.v867 = spiral_w64.eq(spilled.v831, spilled.v866)
spilled.getv904 = function()
    if spilled.v867 then
        local v868 = 0 + 1
        local v869 = v868 + 1
        local v870 = v869 + 1
        local v871 = v870 + 1
        local v872 = 0 + 1
        local v873 = v872 + 1
        local v874 = v873 + 1
        local v875 = v874 + 1
        local v876 = spiral_w64.eq(v871, v875)
        local getv877 = function()
            if v876 then
                return 0
            else
                return 1
            end
        end
        local v877 = getv877()
        local v878 = 0 + 1
        local v879 = 0 + 1
        local v880 = spiral_w64.eq(v878, v879)
        local getv881 = function()
            if v880 then
                return 0
            else
                return 1
            end
        end
        local v881 = getv881()
        local v882 = 0 + 1
        local v883 = v882 + 1
        local v884 = v883 + 1
        local v885 = v884 + 1
        local v886 = v885 + 1
        local v887 = 0 + 1
        local v888 = v887 + 1
        local v889 = v888 + 1
        local v890 = v889 + 1
        local v891 = v890 + 1
        local v892 = spiral_w64.eq(v886, v891)
        local getv893 = function()
            if v892 then
                return 0
            else
                return 1
            end
        end
        local v893 = getv893()
        local v894 = spiral_w64.add(v878, v886, true)
        local v895 = spiral_w64.add(v879, v891, true)
        local v896 = spiral_w64.add(v881, v893, true)
        local v897 = spiral_w64.add(v871, v894, true)
        local v898 = spiral_w64.add(v875, v895, true)
        local v899 = spiral_w64.add(v877, v896, true)
        local v900 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        return Us0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v897, v898, v899, v900)
    else
        local v902 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        return Us0_TypedFxHashedStatementChecksumValidationRejected(spilled.v831, spilled.v866, v902)
    end
end
spilled.v904 = spilled.getv904()
spilled.getv923 = function()
    if spilled.v904 ~= nil and spilled.v904.tag == "Us0_TypedFxHashedStatementChecksumValidationAccepted" then
        local v908 = spilled.v904._1
        local v909 = spilled.v904._2
        local v910 = spilled.v904._3
        local v911 = spilled.v904._4
        local v912 = spilled.v904._5
        local v913 = spilled.v904._6
        return { [1]=1, [2]=0, [3]=v908, [4]=v912 }
    elseif spilled.v904 ~= nil and spilled.v904.tag == "Us0_TypedFxHashedStatementChecksumValidationRejected" then
        local v905 = spilled.v904._1
        local v906 = spilled.v904._2
        local v907 = spilled.v904._3
        return { [1]=0, [2]=1, [3]=0, [4]=0 }
    end
end
spilled.v923, spilled.v924, spilled.v927, spilled.v931 = (table.unpack or unpack)(spilled.getv923())
spilled.v932 = 0 + 1
spilled.v933 = spilled.v932 + 1
spilled.v934 = spilled.v933 + 1
spilled.v935 = spilled.v934 + 1
spilled.v936 = 0 + 1
spilled.v937 = spilled.v936 + 1
spilled.v938 = spilled.v937 + 1
spilled.v939 = spilled.v938 + 1
spilled.v940 = spiral_w64.eq(spilled.v935, spilled.v939)
spilled.getv941 = function()
    if spilled.v940 then
        return 0
    else
        return 1
    end
end
spilled.v941 = spilled.getv941()
spilled.v942 = 0 + 1
spilled.v943 = 0 + 1
spilled.v944 = spiral_w64.eq(spilled.v942, spilled.v943)
spilled.getv945 = function()
    if spilled.v944 then
        return 0
    else
        return 1
    end
end
spilled.v945 = spilled.getv945()
spilled.v946 = 0 + 1
spilled.v947 = spilled.v946 + 1
spilled.v948 = spilled.v947 + 1
spilled.v949 = spilled.v948 + 1
spilled.v950 = spilled.v949 + 1
spilled.v951 = 0 + 1
spilled.v952 = spilled.v951 + 1
spilled.v953 = spilled.v952 + 1
spilled.v954 = spilled.v953 + 1
spilled.v955 = spilled.v954 + 1
spilled.v956 = spiral_w64.eq(spilled.v950, spilled.v955)
spilled.getv957 = function()
    if spilled.v956 then
        return 0
    else
        return 1
    end
end
spilled.v957 = spilled.getv957()
spilled.v960 = spiral_w64.add(spilled.v945, spilled.v957, true)
spilled.v963 = spiral_w64.add(spilled.v941, spilled.v960, true)
spilled.v964 = 0 + 1
spilled.v965 = spilled.v964 + 1
spilled.v966 = spilled.v965 + 1
spilled.v967 = spilled.v966 + 1
spilled.v968 = 0 + 1
spilled.v969 = spilled.v968 + 1
spilled.v970 = spilled.v969 + 1
spilled.v971 = spilled.v970 + 1
spilled.v972 = spiral_w64.eq(spilled.v967, spilled.v971)
spilled.getv973 = function()
    if spilled.v972 then
        return 0
    else
        return 1
    end
end
spilled.v973 = spilled.getv973()
spilled.v974 = 0 + 1
spilled.v975 = 0 + 1
spilled.v976 = spiral_w64.eq(spilled.v974, spilled.v975)
spilled.getv977 = function()
    if spilled.v976 then
        return 0
    else
        return 1
    end
end
spilled.v977 = spilled.getv977()
spilled.v978 = 0 + 1
spilled.v979 = spilled.v978 + 1
spilled.v980 = spilled.v979 + 1
spilled.v981 = spilled.v980 + 1
spilled.v982 = spilled.v981 + 1
spilled.v983 = 0 + 1
spilled.v984 = spilled.v983 + 1
spilled.v985 = spilled.v984 + 1
spilled.v986 = spilled.v985 + 1
spilled.v987 = spilled.v986 + 1
spilled.v988 = spiral_w64.eq(spilled.v982, spilled.v987)
spilled.getv989 = function()
    if spilled.v988 then
        return 0
    else
        return 1
    end
end
spilled.v989 = spilled.getv989()
spilled.v992 = spiral_w64.add(spilled.v977, spilled.v989, true)
spilled.v995 = spiral_w64.add(spilled.v973, spilled.v992, true)
spilled.v996 = spiral_w64.add(spilled.v963, spilled.v995, true)
spilled.v997 = spiral_w64.add(spilled.v931, spilled.v924, true)
spilled.v998 = spiral_w64.add(spilled.v996, spilled.v997, true)
spilled.v999 = spiral_w64.add(spilled.v796, spilled.v998, true)
spilled.v1000 = spiral_w64.eq(spilled.v927, 1)
spilled.v1001 = spiral_w64.eq(spilled.v923, 1)
spilled.v1002 = spiral_w64.eq(spilled.v999, 0)
spilled.v1003 = (spilled.v1000) and (spilled.v1001)
spilled.v1004 = (spilled.v1003) and (spilled.v1002)
if spilled.v1004 then
else
    _G.error("typed-FX-statement-recursive-writer-restart-invariant-runtime-mismatch")
end
spilled.v1005 = 0 + 1
spilled.v1006 = spilled.v1005 + 1
spilled.v1007 = spilled.v1006 + 1
spilled.v1008 = spilled.v1007 + 1
spilled.v1009 = 0 + 1
spilled.v1010 = spilled.v1009 + 1
spilled.v1011 = spilled.v1010 + 1
spilled.v1012 = spilled.v1011 + 1
spilled.v1013 = spiral_w64.eq(spilled.v1008, spilled.v1012)
spilled.getv1014 = function()
    if spilled.v1013 then
        return 0
    else
        return 1
    end
end
spilled.v1014 = spilled.getv1014()
spilled.v1015 = 0 + 1
spilled.v1016 = 0 + 1
spilled.v1017 = spiral_w64.eq(spilled.v1015, spilled.v1016)
spilled.getv1018 = function()
    if spilled.v1017 then
        return 0
    else
        return 1
    end
end
spilled.v1018 = spilled.getv1018()
spilled.v1019 = 0 + 1
spilled.v1020 = spilled.v1019 + 1
spilled.v1021 = spilled.v1020 + 1
spilled.v1022 = spilled.v1021 + 1
spilled.v1023 = spilled.v1022 + 1
spilled.v1024 = 0 + 1
spilled.v1025 = spilled.v1024 + 1
spilled.v1026 = spilled.v1025 + 1
spilled.v1027 = spilled.v1026 + 1
spilled.v1028 = spilled.v1027 + 1
spilled.v1029 = spiral_w64.eq(spilled.v1023, spilled.v1028)
spilled.getv1030 = function()
    if spilled.v1029 then
        return 0
    else
        return 1
    end
end
spilled.v1030 = spilled.getv1030()
spilled.v1033 = spiral_w64.add(spilled.v1018, spilled.v1030, true)
spilled.v1036 = spiral_w64.add(spilled.v1014, spilled.v1033, true)
spilled.v1037 = 0 + 1
spilled.v1038 = spilled.v1037 + 1
spilled.v1039 = spilled.v1038 + 1
spilled.v1040 = spilled.v1039 + 1
spilled.v1041 = 0 + 1
spilled.v1042 = spilled.v1041 + 1
spilled.v1043 = spilled.v1042 + 1
spilled.v1044 = spilled.v1043 + 1
spilled.v1045 = spiral_w64.eq(spilled.v1040, spilled.v1044)
spilled.getv1046 = function()
    if spilled.v1045 then
        return 0
    else
        return 1
    end
end
spilled.v1046 = spilled.getv1046()
spilled.v1047 = 0 + 1
spilled.v1048 = 0 + 1
spilled.v1049 = spiral_w64.eq(spilled.v1047, spilled.v1048)
spilled.getv1050 = function()
    if spilled.v1049 then
        return 0
    else
        return 1
    end
end
spilled.v1050 = spilled.getv1050()
spilled.v1051 = 0 + 1
spilled.v1052 = spilled.v1051 + 1
spilled.v1053 = spilled.v1052 + 1
spilled.v1054 = spilled.v1053 + 1
spilled.v1055 = spilled.v1054 + 1
spilled.v1056 = 0 + 1
spilled.v1057 = spilled.v1056 + 1
spilled.v1058 = spilled.v1057 + 1
spilled.v1059 = spilled.v1058 + 1
spilled.v1060 = spilled.v1059 + 1
spilled.v1061 = spiral_w64.eq(spilled.v1055, spilled.v1060)
spilled.getv1062 = function()
    if spilled.v1061 then
        return 0
    else
        return 1
    end
end
spilled.v1062 = spilled.getv1062()
spilled.v1065 = spiral_w64.add(spilled.v1050, spilled.v1062, true)
spilled.v1068 = spiral_w64.add(spilled.v1046, spilled.v1065, true)
spilled.v1069 = spiral_w64.add(spilled.v1036, spilled.v1068, true)
spilled.v1070 = 0 + 1
spilled.v1071 = spilled.v1070 + 1
spilled.v1072 = spilled.v1071 + 1
spilled.v1073 = spilled.v1072 + 1
spilled.v1074 = 0 + 1
spilled.v1075 = spilled.v1074 + 1
spilled.v1076 = spilled.v1075 + 1
spilled.v1077 = spilled.v1076 + 1
spilled.v1078 = spiral_w64.eq(spilled.v1073, spilled.v1077)
spilled.getv1079 = function()
    if spilled.v1078 then
        return 0
    else
        return 1
    end
end
spilled.v1079 = spilled.getv1079()
spilled.v1080 = 0 + 1
spilled.v1081 = 0 + 1
spilled.v1082 = spiral_w64.eq(spilled.v1080, spilled.v1081)
spilled.getv1083 = function()
    if spilled.v1082 then
        return 0
    else
        return 1
    end
end
spilled.v1083 = spilled.getv1083()
spilled.v1084 = 0 + 1
spilled.v1085 = spilled.v1084 + 1
spilled.v1086 = spilled.v1085 + 1
spilled.v1087 = spilled.v1086 + 1
spilled.v1088 = spilled.v1087 + 1
spilled.v1089 = 0 + 1
spilled.v1090 = spilled.v1089 + 1
spilled.v1091 = spilled.v1090 + 1
spilled.v1092 = spilled.v1091 + 1
spilled.v1093 = spilled.v1092 + 1
spilled.v1094 = spiral_w64.eq(spilled.v1088, spilled.v1093)
spilled.getv1095 = function()
    if spilled.v1094 then
        return 0
    else
        return 1
    end
end
spilled.v1095 = spilled.getv1095()
spilled.v1098 = spiral_w64.add(spilled.v1083, spilled.v1095, true)
spilled.v1101 = spiral_w64.add(spilled.v1079, spilled.v1098, true)
spilled.v1102 = 0 + 1
spilled.v1103 = spilled.v1102 + 1
spilled.v1104 = spilled.v1103 + 1
spilled.v1105 = spilled.v1104 + 1
spilled.v1106 = 0 + 1
spilled.v1107 = spilled.v1106 + 1
spilled.v1108 = spilled.v1107 + 1
spilled.v1109 = spilled.v1108 + 1
spilled.v1110 = spiral_w64.eq(spilled.v1105, spilled.v1109)
spilled.getv1111 = function()
    if spilled.v1110 then
        return 0
    else
        return 1
    end
end
spilled.v1111 = spilled.getv1111()
spilled.v1112 = 0 + 1
spilled.v1113 = 0 + 1
spilled.v1114 = spiral_w64.eq(spilled.v1112, spilled.v1113)
spilled.getv1115 = function()
    if spilled.v1114 then
        return 0
    else
        return 1
    end
end
spilled.v1115 = spilled.getv1115()
spilled.v1116 = 0 + 1
spilled.v1117 = spilled.v1116 + 1
spilled.v1118 = spilled.v1117 + 1
spilled.v1119 = spilled.v1118 + 1
spilled.v1120 = spilled.v1119 + 1
spilled.v1121 = 0 + 1
spilled.v1122 = spilled.v1121 + 1
spilled.v1123 = spilled.v1122 + 1
spilled.v1124 = spilled.v1123 + 1
spilled.v1125 = spilled.v1124 + 1
spilled.v1126 = spiral_w64.eq(spilled.v1120, spilled.v1125)
spilled.getv1127 = function()
    if spilled.v1126 then
        return 0
    else
        return 1
    end
end
spilled.v1127 = spilled.getv1127()
spilled.v1130 = spiral_w64.add(spilled.v1115, spilled.v1127, true)
spilled.v1133 = spiral_w64.add(spilled.v1111, spilled.v1130, true)
spilled.v1134 = spiral_w64.add(spilled.v1101, spilled.v1133, true)
spilled.v1135 = 0 + 1
spilled.v1136 = spilled.v1135 + 1
spilled.v1137 = spilled.v1136 + 1
spilled.v1138 = spilled.v1137 + 1
spilled.v1139 = 0 + 1
spilled.v1140 = spilled.v1139 + 1
spilled.v1141 = spilled.v1140 + 1
spilled.v1142 = spilled.v1141 + 1
spilled.v1143 = spiral_w64.eq(spilled.v1138, spilled.v1142)
spilled.getv1144 = function()
    if spilled.v1143 then
        return 0
    else
        return 1
    end
end
spilled.v1144 = spilled.getv1144()
spilled.v1145 = 0 + 1
spilled.v1146 = 0 + 1
spilled.v1147 = spiral_w64.eq(spilled.v1145, spilled.v1146)
spilled.getv1148 = function()
    if spilled.v1147 then
        return 0
    else
        return 1
    end
end
spilled.v1148 = spilled.getv1148()
spilled.v1149 = 0 + 1
spilled.v1150 = spilled.v1149 + 1
spilled.v1151 = spilled.v1150 + 1
spilled.v1152 = spilled.v1151 + 1
spilled.v1153 = spilled.v1152 + 1
spilled.v1154 = 0 + 1
spilled.v1155 = spilled.v1154 + 1
spilled.v1156 = spilled.v1155 + 1
spilled.v1157 = spilled.v1156 + 1
spilled.v1158 = spilled.v1157 + 1
spilled.v1159 = spiral_w64.eq(spilled.v1153, spilled.v1158)
spilled.getv1160 = function()
    if spilled.v1159 then
        return 0
    else
        return 1
    end
end
spilled.v1160 = spilled.getv1160()
spilled.v1163 = spiral_w64.add(spilled.v1148, spilled.v1160, true)
spilled.v1166 = spiral_w64.add(spilled.v1144, spilled.v1163, true)
spilled.v1167 = 0 + 1
spilled.v1168 = spilled.v1167 + 1
spilled.v1169 = spilled.v1168 + 1
spilled.v1170 = spilled.v1169 + 1
spilled.v1171 = 0 + 1
spilled.v1172 = spilled.v1171 + 1
spilled.v1173 = spilled.v1172 + 1
spilled.v1174 = spilled.v1173 + 1
spilled.v1175 = spiral_w64.eq(spilled.v1170, spilled.v1174)
spilled.getv1176 = function()
    if spilled.v1175 then
        return 0
    else
        return 1
    end
end
spilled.v1176 = spilled.getv1176()
spilled.v1177 = 0 + 1
spilled.v1178 = 0 + 1
spilled.v1179 = spiral_w64.eq(spilled.v1177, spilled.v1178)
spilled.getv1180 = function()
    if spilled.v1179 then
        return 0
    else
        return 1
    end
end
spilled.v1180 = spilled.getv1180()
spilled.v1181 = 0 + 1
spilled.v1182 = spilled.v1181 + 1
spilled.v1183 = spilled.v1182 + 1
spilled.v1184 = spilled.v1183 + 1
spilled.v1185 = spilled.v1184 + 1
spilled.v1186 = 0 + 1
spilled.v1187 = spilled.v1186 + 1
spilled.v1188 = spilled.v1187 + 1
spilled.v1189 = spilled.v1188 + 1
spilled.v1190 = spilled.v1189 + 1
spilled.v1191 = spiral_w64.eq(spilled.v1185, spilled.v1190)
spilled.getv1192 = function()
    if spilled.v1191 then
        return 0
    else
        return 1
    end
end
spilled.v1192 = spilled.getv1192()
spilled.v1195 = spiral_w64.add(spilled.v1180, spilled.v1192, true)
spilled.v1198 = spiral_w64.add(spilled.v1176, spilled.v1195, true)
spilled.v1199 = 0 + 1
spilled.v1200 = spilled.v1199 + 1
spilled.v1201 = spilled.v1200 + 1
spilled.v1202 = spilled.v1201 + 1
spilled.v1203 = 0 + 1
spilled.v1204 = spilled.v1203 + 1
spilled.v1205 = spilled.v1204 + 1
spilled.v1206 = spilled.v1205 + 1
spilled.v1207 = spiral_w64.eq(spilled.v1202, spilled.v1206)
spilled.getv1208 = function()
    if spilled.v1207 then
        return 0
    else
        return 1
    end
end
spilled.v1208 = spilled.getv1208()
spilled.v1209 = 0 + 1
spilled.v1210 = 0 + 1
spilled.v1211 = spiral_w64.eq(spilled.v1209, spilled.v1210)
spilled.getv1212 = function()
    if spilled.v1211 then
        return 0
    else
        return 1
    end
end
spilled.v1212 = spilled.getv1212()
spilled.v1213 = 0 + 1
spilled.v1214 = spilled.v1213 + 1
spilled.v1215 = spilled.v1214 + 1
spilled.v1216 = spilled.v1215 + 1
spilled.v1217 = spilled.v1216 + 1
spilled.v1218 = 0 + 1
spilled.v1219 = spilled.v1218 + 1
spilled.v1220 = spilled.v1219 + 1
spilled.v1221 = spilled.v1220 + 1
spilled.v1222 = spilled.v1221 + 1
spilled.v1223 = spiral_w64.eq(spilled.v1217, spilled.v1222)
spilled.getv1224 = function()
    if spilled.v1223 then
        return 0
    else
        return 1
    end
end
spilled.v1224 = spilled.getv1224()
spilled.v1227 = spiral_w64.add(spilled.v1212, spilled.v1224, true)
spilled.v1230 = spiral_w64.add(spilled.v1208, spilled.v1227, true)
spilled.v1231 = 0 + 1
spilled.v1232 = spilled.v1231 + 1
spilled.v1233 = spilled.v1232 + 1
spilled.v1234 = spilled.v1233 + 1
spilled.v1235 = 0 + 1
spilled.v1236 = spilled.v1235 + 1
spilled.v1237 = spilled.v1236 + 1
spilled.v1238 = spilled.v1237 + 1
spilled.v1239 = spiral_w64.eq(spilled.v1234, spilled.v1238)
spilled.getv1240 = function()
    if spilled.v1239 then
        return 0
    else
        return 1
    end
end
spilled.v1240 = spilled.getv1240()
spilled.v1241 = 0 + 1
spilled.v1242 = 0 + 1
spilled.v1243 = spiral_w64.eq(spilled.v1241, spilled.v1242)
spilled.getv1244 = function()
    if spilled.v1243 then
        return 0
    else
        return 1
    end
end
spilled.v1244 = spilled.getv1244()
spilled.v1245 = 0 + 1
spilled.v1246 = spilled.v1245 + 1
spilled.v1247 = spilled.v1246 + 1
spilled.v1248 = spilled.v1247 + 1
spilled.v1249 = spilled.v1248 + 1
spilled.v1250 = 0 + 1
spilled.v1251 = spilled.v1250 + 1
spilled.v1252 = spilled.v1251 + 1
spilled.v1253 = spilled.v1252 + 1
spilled.v1254 = spilled.v1253 + 1
spilled.v1255 = spiral_w64.eq(spilled.v1249, spilled.v1254)
spilled.getv1256 = function()
    if spilled.v1255 then
        return 0
    else
        return 1
    end
end
spilled.v1256 = spilled.getv1256()
spilled.v1259 = spiral_w64.add(spilled.v1244, spilled.v1256, true)
spilled.v1262 = spiral_w64.add(spilled.v1240, spilled.v1259, true)
spilled.v1263 = spiral_w64.add(spilled.v1230, spilled.v1262, true)
spilled.v1264 = spiral_w64.add(spilled.v1198, spilled.v1263, true)
spilled.v1265 = spiral_w64.add(spilled.v1166, spilled.v1264, true)
spilled.v1266 = spiral_w64.eq(spilled.v1069, 0)
spilled.v1267 = spiral_w64.eq(spilled.v1134, spilled.v1069)
spilled.v1268 = spiral_w64.eq(spilled.v1265, 0)
spilled.v1269 = (spilled.v1266) and (spilled.v1267)
spilled.v1270 = (spilled.v1269) and (spilled.v1268)
if spilled.v1270 then
else
    _G.error("typed-FX-statement-stale-writer-conflict-program-append-runtime-mismatch")
end
spilled.v1271 = 0 + 1
spilled.v1272 = spilled.v1271 + 1
spilled.v1273 = spilled.v1272 + 1
spilled.v1274 = spilled.v1273 + 1
spilled.v1275 = 0 + 1
spilled.v1276 = spilled.v1275 + 1
spilled.v1277 = spilled.v1276 + 1
spilled.v1278 = spilled.v1277 + 1
spilled.v1279 = spiral_w64.eq(spilled.v1274, spilled.v1278)
spilled.getv1280 = function()
    if spilled.v1279 then
        return 0
    else
        return 1
    end
end
spilled.v1280 = spilled.getv1280()
spilled.v1281 = 0 + 1
spilled.v1282 = 0 + 1
spilled.v1283 = spiral_w64.eq(spilled.v1281, spilled.v1282)
spilled.getv1284 = function()
    if spilled.v1283 then
        return 0
    else
        return 1
    end
end
spilled.v1284 = spilled.getv1284()
spilled.v1285 = 0 + 1
spilled.v1286 = spilled.v1285 + 1
spilled.v1287 = spilled.v1286 + 1
spilled.v1288 = spilled.v1287 + 1
spilled.v1289 = spilled.v1288 + 1
spilled.v1290 = 0 + 1
spilled.v1291 = spilled.v1290 + 1
spilled.v1292 = spilled.v1291 + 1
spilled.v1293 = spilled.v1292 + 1
spilled.v1294 = spilled.v1293 + 1
spilled.v1295 = spiral_w64.eq(spilled.v1289, spilled.v1294)
spilled.getv1296 = function()
    if spilled.v1295 then
        return 0
    else
        return 1
    end
end
spilled.v1296 = spilled.getv1296()
spilled.v1299 = spiral_w64.add(spilled.v1284, spilled.v1296, true)
spilled.v1302 = spiral_w64.add(spilled.v1280, spilled.v1299, true)
spilled.v1303 = 0 + 1
spilled.v1304 = spilled.v1303 + 1
spilled.v1305 = spilled.v1304 + 1
spilled.v1306 = spilled.v1305 + 1
spilled.v1307 = 0 + 1
spilled.v1308 = spilled.v1307 + 1
spilled.v1309 = spilled.v1308 + 1
spilled.v1310 = spilled.v1309 + 1
spilled.v1311 = spiral_w64.eq(spilled.v1306, spilled.v1310)
spilled.getv1312 = function()
    if spilled.v1311 then
        return 0
    else
        return 1
    end
end
spilled.v1312 = spilled.getv1312()
spilled.v1313 = 0 + 1
spilled.v1314 = 0 + 1
spilled.v1315 = spiral_w64.eq(spilled.v1313, spilled.v1314)
spilled.getv1316 = function()
    if spilled.v1315 then
        return 0
    else
        return 1
    end
end
spilled.v1316 = spilled.getv1316()
spilled.v1317 = 0 + 1
spilled.v1318 = spilled.v1317 + 1
spilled.v1319 = spilled.v1318 + 1
spilled.v1320 = spilled.v1319 + 1
spilled.v1321 = spilled.v1320 + 1
spilled.v1322 = 0 + 1
spilled.v1323 = spilled.v1322 + 1
spilled.v1324 = spilled.v1323 + 1
spilled.v1325 = spilled.v1324 + 1
spilled.v1326 = spilled.v1325 + 1
spilled.v1327 = spiral_w64.eq(spilled.v1321, spilled.v1326)
spilled.getv1328 = function()
    if spilled.v1327 then
        return 0
    else
        return 1
    end
end
spilled.v1328 = spilled.getv1328()
spilled.v1331 = spiral_w64.add(spilled.v1316, spilled.v1328, true)
spilled.v1334 = spiral_w64.add(spilled.v1312, spilled.v1331, true)
spilled.v1335 = 0 + 1
spilled.v1336 = spilled.v1335 + 1
spilled.v1337 = spilled.v1336 + 1
spilled.v1338 = spilled.v1337 + 1
spilled.v1339 = 0 + 1
spilled.v1340 = spilled.v1339 + 1
spilled.v1341 = spilled.v1340 + 1
spilled.v1342 = spilled.v1341 + 1
spilled.v1343 = spiral_w64.eq(spilled.v1338, spilled.v1342)
spilled.getv1344 = function()
    if spilled.v1343 then
        return 0
    else
        return 1
    end
end
spilled.v1344 = spilled.getv1344()
spilled.v1345 = 0 + 1
spilled.v1346 = 0 + 1
spilled.v1347 = spiral_w64.eq(spilled.v1345, spilled.v1346)
spilled.getv1348 = function()
    if spilled.v1347 then
        return 0
    else
        return 1
    end
end
spilled.v1348 = spilled.getv1348()
spilled.v1349 = 0 + 1
spilled.v1350 = spilled.v1349 + 1
spilled.v1351 = spilled.v1350 + 1
spilled.v1352 = spilled.v1351 + 1
spilled.v1353 = spilled.v1352 + 1
spilled.v1354 = 0 + 1
spilled.v1355 = spilled.v1354 + 1
spilled.v1356 = spilled.v1355 + 1
spilled.v1357 = spilled.v1356 + 1
spilled.v1358 = spilled.v1357 + 1
spilled.v1359 = spiral_w64.eq(spilled.v1353, spilled.v1358)
spilled.getv1360 = function()
    if spilled.v1359 then
        return 0
    else
        return 1
    end
end
spilled.v1360 = spilled.getv1360()
spilled.v1363 = spiral_w64.add(spilled.v1348, spilled.v1360, true)
spilled.v1366 = spiral_w64.add(spilled.v1344, spilled.v1363, true)
spilled.v1367 = 0 + 1
spilled.v1368 = spilled.v1367 + 1
spilled.v1369 = spilled.v1368 + 1
spilled.v1370 = spilled.v1369 + 1
spilled.v1371 = 0 + 1
spilled.v1372 = spilled.v1371 + 1
spilled.v1373 = spilled.v1372 + 1
spilled.v1374 = spilled.v1373 + 1
spilled.v1375 = spiral_w64.eq(spilled.v1370, spilled.v1374)
spilled.getv1376 = function()
    if spilled.v1375 then
        return 0
    else
        return 1
    end
end
spilled.v1376 = spilled.getv1376()
spilled.v1377 = 0 + 1
spilled.v1378 = 0 + 1
spilled.v1379 = spiral_w64.eq(spilled.v1377, spilled.v1378)
spilled.getv1380 = function()
    if spilled.v1379 then
        return 0
    else
        return 1
    end
end
spilled.v1380 = spilled.getv1380()
spilled.v1381 = 0 + 1
spilled.v1382 = spilled.v1381 + 1
spilled.v1383 = spilled.v1382 + 1
spilled.v1384 = spilled.v1383 + 1
spilled.v1385 = spilled.v1384 + 1
spilled.v1386 = 0 + 1
spilled.v1387 = spilled.v1386 + 1
spilled.v1388 = spilled.v1387 + 1
spilled.v1389 = spilled.v1388 + 1
spilled.v1390 = spilled.v1389 + 1
spilled.v1391 = spiral_w64.eq(spilled.v1385, spilled.v1390)
spilled.getv1392 = function()
    if spilled.v1391 then
        return 0
    else
        return 1
    end
end
spilled.v1392 = spilled.getv1392()
spilled.v1395 = spiral_w64.add(spilled.v1380, spilled.v1392, true)
spilled.v1398 = spiral_w64.add(spilled.v1376, spilled.v1395, true)
spilled.v1399 = 0 + 1
spilled.v1400 = spilled.v1399 + 1
spilled.v1401 = spilled.v1400 + 1
spilled.v1402 = spilled.v1401 + 1
spilled.v1403 = 0 + 1
spilled.v1404 = spilled.v1403 + 1
spilled.v1405 = spilled.v1404 + 1
spilled.v1406 = spilled.v1405 + 1
spilled.v1407 = spiral_w64.eq(spilled.v1402, spilled.v1406)
spilled.getv1408 = function()
    if spilled.v1407 then
        return 0
    else
        return 1
    end
end
spilled.v1408 = spilled.getv1408()
spilled.v1409 = 0 + 1
spilled.v1410 = 0 + 1
spilled.v1411 = spiral_w64.eq(spilled.v1409, spilled.v1410)
spilled.getv1412 = function()
    if spilled.v1411 then
        return 0
    else
        return 1
    end
end
spilled.v1412 = spilled.getv1412()
spilled.v1413 = 0 + 1
spilled.v1414 = spilled.v1413 + 1
spilled.v1415 = spilled.v1414 + 1
spilled.v1416 = spilled.v1415 + 1
spilled.v1417 = spilled.v1416 + 1
spilled.v1418 = 0 + 1
spilled.v1419 = spilled.v1418 + 1
spilled.v1420 = spilled.v1419 + 1
spilled.v1421 = spilled.v1420 + 1
spilled.v1422 = spilled.v1421 + 1
spilled.v1423 = spiral_w64.eq(spilled.v1417, spilled.v1422)
spilled.getv1424 = function()
    if spilled.v1423 then
        return 0
    else
        return 1
    end
end
spilled.v1424 = spilled.getv1424()
spilled.v1427 = spiral_w64.add(spilled.v1412, spilled.v1424, true)
spilled.v1430 = spiral_w64.add(spilled.v1408, spilled.v1427, true)
spilled.v1431 = 0 + 1
spilled.v1432 = spilled.v1431 + 1
spilled.v1433 = spilled.v1432 + 1
spilled.v1434 = spilled.v1433 + 1
spilled.v1435 = 0 + 1
spilled.v1436 = spilled.v1435 + 1
spilled.v1437 = spilled.v1436 + 1
spilled.v1438 = spilled.v1437 + 1
spilled.v1439 = spiral_w64.eq(spilled.v1434, spilled.v1438)
spilled.getv1440 = function()
    if spilled.v1439 then
        return 0
    else
        return 1
    end
end
spilled.v1440 = spilled.getv1440()
spilled.v1441 = 0 + 1
spilled.v1442 = 0 + 1
spilled.v1443 = spiral_w64.eq(spilled.v1441, spilled.v1442)
spilled.getv1444 = function()
    if spilled.v1443 then
        return 0
    else
        return 1
    end
end
spilled.v1444 = spilled.getv1444()
spilled.v1445 = 0 + 1
spilled.v1446 = spilled.v1445 + 1
spilled.v1447 = spilled.v1446 + 1
spilled.v1448 = spilled.v1447 + 1
spilled.v1449 = spilled.v1448 + 1
spilled.v1450 = 0 + 1
spilled.v1451 = spilled.v1450 + 1
spilled.v1452 = spilled.v1451 + 1
spilled.v1453 = spilled.v1452 + 1
spilled.v1454 = spilled.v1453 + 1
spilled.v1455 = spiral_w64.eq(spilled.v1449, spilled.v1454)
spilled.getv1456 = function()
    if spilled.v1455 then
        return 0
    else
        return 1
    end
end
spilled.v1456 = spilled.getv1456()
spilled.v1459 = spiral_w64.add(spilled.v1444, spilled.v1456, true)
spilled.v1462 = spiral_w64.add(spilled.v1440, spilled.v1459, true)
spilled.v1463 = spiral_w64.add(spilled.v1430, spilled.v1462, true)
spilled.v1464 = spiral_w64.add(spilled.v1398, spilled.v1463, true)
spilled.v1465 = spiral_w64.add(spilled.v1366, spilled.v1464, true)
spilled.v1466 = spiral_w64.add(spilled.v1334, spilled.v1465, true)
spilled.v1467 = spiral_w64.add(spilled.v1302, spilled.v1466, true)
spilled.v1468 = 0 + 1
spilled.v1469 = spilled.v1468 + 1
spilled.v1470 = spilled.v1469 + 1
spilled.v1471 = spilled.v1470 + 1
spilled.v1472 = 0 + 1
spilled.v1473 = spilled.v1472 + 1
spilled.v1474 = spilled.v1473 + 1
spilled.v1475 = spilled.v1474 + 1
spilled.v1476 = spiral_w64.eq(spilled.v1471, spilled.v1475)
spilled.getv1477 = function()
    if spilled.v1476 then
        return 0
    else
        return 1
    end
end
spilled.v1477 = spilled.getv1477()
spilled.v1478 = 0 + 1
spilled.v1479 = 0 + 1
spilled.v1480 = spiral_w64.eq(spilled.v1478, spilled.v1479)
spilled.getv1481 = function()
    if spilled.v1480 then
        return 0
    else
        return 1
    end
end
spilled.v1481 = spilled.getv1481()
spilled.v1482 = 0 + 1
spilled.v1483 = spilled.v1482 + 1
spilled.v1484 = spilled.v1483 + 1
spilled.v1485 = spilled.v1484 + 1
spilled.v1486 = spilled.v1485 + 1
spilled.v1487 = 0 + 1
spilled.v1488 = spilled.v1487 + 1
spilled.v1489 = spilled.v1488 + 1
spilled.v1490 = spilled.v1489 + 1
spilled.v1491 = spilled.v1490 + 1
spilled.v1492 = spiral_w64.eq(spilled.v1486, spilled.v1491)
spilled.getv1493 = function()
    if spilled.v1492 then
        return 0
    else
        return 1
    end
end
spilled.v1493 = spilled.getv1493()
spilled.v1496 = spiral_w64.add(spilled.v1481, spilled.v1493, true)
spilled.v1499 = spiral_w64.add(spilled.v1477, spilled.v1496, true)
spilled.v1500 = 0 + 1
spilled.v1501 = spilled.v1500 + 1
spilled.v1502 = spilled.v1501 + 1
spilled.v1503 = spilled.v1502 + 1
spilled.v1504 = 0 + 1
spilled.v1505 = spilled.v1504 + 1
spilled.v1506 = spilled.v1505 + 1
spilled.v1507 = spilled.v1506 + 1
spilled.v1508 = spiral_w64.eq(spilled.v1503, spilled.v1507)
spilled.getv1509 = function()
    if spilled.v1508 then
        return 0
    else
        return 1
    end
end
spilled.v1509 = spilled.getv1509()
spilled.v1510 = 0 + 1
spilled.v1511 = 0 + 1
spilled.v1512 = spiral_w64.eq(spilled.v1510, spilled.v1511)
spilled.getv1513 = function()
    if spilled.v1512 then
        return 0
    else
        return 1
    end
end
spilled.v1513 = spilled.getv1513()
spilled.v1514 = 0 + 1
spilled.v1515 = spilled.v1514 + 1
spilled.v1516 = spilled.v1515 + 1
spilled.v1517 = spilled.v1516 + 1
spilled.v1518 = spilled.v1517 + 1
spilled.v1519 = 0 + 1
spilled.v1520 = spilled.v1519 + 1
spilled.v1521 = spilled.v1520 + 1
spilled.v1522 = spilled.v1521 + 1
spilled.v1523 = spilled.v1522 + 1
spilled.v1524 = spiral_w64.eq(spilled.v1518, spilled.v1523)
spilled.getv1525 = function()
    if spilled.v1524 then
        return 0
    else
        return 1
    end
end
spilled.v1525 = spilled.getv1525()
spilled.v1528 = spiral_w64.add(spilled.v1513, spilled.v1525, true)
spilled.v1531 = spiral_w64.add(spilled.v1509, spilled.v1528, true)
spilled.v1532 = 0 + 1
spilled.v1533 = spilled.v1532 + 1
spilled.v1534 = spilled.v1533 + 1
spilled.v1535 = spilled.v1534 + 1
spilled.v1536 = 0 + 1
spilled.v1537 = spilled.v1536 + 1
spilled.v1538 = spilled.v1537 + 1
spilled.v1539 = spilled.v1538 + 1
spilled.v1540 = spiral_w64.eq(spilled.v1535, spilled.v1539)
spilled.getv1541 = function()
    if spilled.v1540 then
        return 0
    else
        return 1
    end
end
spilled.v1541 = spilled.getv1541()
spilled.v1542 = 0 + 1
spilled.v1543 = 0 + 1
spilled.v1544 = spiral_w64.eq(spilled.v1542, spilled.v1543)
spilled.getv1545 = function()
    if spilled.v1544 then
        return 0
    else
        return 1
    end
end
spilled.v1545 = spilled.getv1545()
spilled.v1546 = 0 + 1
spilled.v1547 = spilled.v1546 + 1
spilled.v1548 = spilled.v1547 + 1
spilled.v1549 = spilled.v1548 + 1
spilled.v1550 = spilled.v1549 + 1
spilled.v1551 = 0 + 1
spilled.v1552 = spilled.v1551 + 1
spilled.v1553 = spilled.v1552 + 1
spilled.v1554 = spilled.v1553 + 1
spilled.v1555 = spilled.v1554 + 1
spilled.v1556 = spiral_w64.eq(spilled.v1550, spilled.v1555)
spilled.getv1557 = function()
    if spilled.v1556 then
        return 0
    else
        return 1
    end
end
spilled.v1557 = spilled.getv1557()
spilled.v1560 = spiral_w64.add(spilled.v1545, spilled.v1557, true)
spilled.v1563 = spiral_w64.add(spilled.v1541, spilled.v1560, true)
spilled.v1564 = 0 + 1
spilled.v1565 = spilled.v1564 + 1
spilled.v1566 = spilled.v1565 + 1
spilled.v1567 = spilled.v1566 + 1
spilled.v1568 = 0 + 1
spilled.v1569 = spilled.v1568 + 1
spilled.v1570 = spilled.v1569 + 1
spilled.v1571 = spilled.v1570 + 1
spilled.v1572 = spiral_w64.eq(spilled.v1567, spilled.v1571)
spilled.getv1573 = function()
    if spilled.v1572 then
        return 0
    else
        return 1
    end
end
spilled.v1573 = spilled.getv1573()
spilled.v1574 = 0 + 1
spilled.v1575 = 0 + 1
spilled.v1576 = spiral_w64.eq(spilled.v1574, spilled.v1575)
spilled.getv1577 = function()
    if spilled.v1576 then
        return 0
    else
        return 1
    end
end
spilled.v1577 = spilled.getv1577()
spilled.v1578 = 0 + 1
spilled.v1579 = spilled.v1578 + 1
spilled.v1580 = spilled.v1579 + 1
spilled.v1581 = spilled.v1580 + 1
spilled.v1582 = spilled.v1581 + 1
spilled.v1583 = 0 + 1
spilled.v1584 = spilled.v1583 + 1
spilled.v1585 = spilled.v1584 + 1
spilled.v1586 = spilled.v1585 + 1
spilled.v1587 = spilled.v1586 + 1
spilled.v1588 = spiral_w64.eq(spilled.v1582, spilled.v1587)
spilled.getv1589 = function()
    if spilled.v1588 then
        return 0
    else
        return 1
    end
end
spilled.v1589 = spilled.getv1589()
spilled.v1592 = spiral_w64.add(spilled.v1577, spilled.v1589, true)
spilled.v1595 = spiral_w64.add(spilled.v1573, spilled.v1592, true)
spilled.v1596 = 0 + 1
spilled.v1597 = spilled.v1596 + 1
spilled.v1598 = spilled.v1597 + 1
spilled.v1599 = spilled.v1598 + 1
spilled.v1600 = 0 + 1
spilled.v1601 = spilled.v1600 + 1
spilled.v1602 = spilled.v1601 + 1
spilled.v1603 = spilled.v1602 + 1
spilled.v1604 = spiral_w64.eq(spilled.v1599, spilled.v1603)
spilled.getv1605 = function()
    if spilled.v1604 then
        return 0
    else
        return 1
    end
end
spilled.v1605 = spilled.getv1605()
spilled.v1606 = 0 + 1
spilled.v1607 = 0 + 1
spilled.v1608 = spiral_w64.eq(spilled.v1606, spilled.v1607)
spilled.getv1609 = function()
    if spilled.v1608 then
        return 0
    else
        return 1
    end
end
spilled.v1609 = spilled.getv1609()
spilled.v1610 = 0 + 1
spilled.v1611 = spilled.v1610 + 1
spilled.v1612 = spilled.v1611 + 1
spilled.v1613 = spilled.v1612 + 1
spilled.v1614 = spilled.v1613 + 1
spilled.v1615 = 0 + 1
spilled.v1616 = spilled.v1615 + 1
spilled.v1617 = spilled.v1616 + 1
spilled.v1618 = spilled.v1617 + 1
spilled.v1619 = spilled.v1618 + 1
spilled.v1620 = spiral_w64.eq(spilled.v1614, spilled.v1619)
spilled.getv1621 = function()
    if spilled.v1620 then
        return 0
    else
        return 1
    end
end
spilled.v1621 = spilled.getv1621()
spilled.v1624 = spiral_w64.add(spilled.v1609, spilled.v1621, true)
spilled.v1627 = spiral_w64.add(spilled.v1605, spilled.v1624, true)
spilled.v1628 = 0 + 1
spilled.v1629 = spilled.v1628 + 1
spilled.v1630 = spilled.v1629 + 1
spilled.v1631 = spilled.v1630 + 1
spilled.v1632 = 0 + 1
spilled.v1633 = spilled.v1632 + 1
spilled.v1634 = spilled.v1633 + 1
spilled.v1635 = spilled.v1634 + 1
spilled.v1636 = spiral_w64.eq(spilled.v1631, spilled.v1635)
spilled.getv1637 = function()
    if spilled.v1636 then
        return 0
    else
        return 1
    end
end
spilled.v1637 = spilled.getv1637()
spilled.v1638 = 0 + 1
spilled.v1639 = 0 + 1
spilled.v1640 = spiral_w64.eq(spilled.v1638, spilled.v1639)
spilled.getv1641 = function()
    if spilled.v1640 then
        return 0
    else
        return 1
    end
end
spilled.v1641 = spilled.getv1641()
spilled.v1642 = 0 + 1
spilled.v1643 = spilled.v1642 + 1
spilled.v1644 = spilled.v1643 + 1
spilled.v1645 = spilled.v1644 + 1
spilled.v1646 = spilled.v1645 + 1
spilled.v1647 = 0 + 1
spilled.v1648 = spilled.v1647 + 1
spilled.v1649 = spilled.v1648 + 1
spilled.v1650 = spilled.v1649 + 1
spilled.v1651 = spilled.v1650 + 1
spilled.v1652 = spiral_w64.eq(spilled.v1646, spilled.v1651)
spilled.getv1653 = function()
    if spilled.v1652 then
        return 0
    else
        return 1
    end
end
spilled.v1653 = spilled.getv1653()
spilled.v1656 = spiral_w64.add(spilled.v1641, spilled.v1653, true)
spilled.v1659 = spiral_w64.add(spilled.v1637, spilled.v1656, true)
spilled.v1660 = spiral_w64.add(spilled.v1627, spilled.v1659, true)
spilled.v1661 = spiral_w64.add(spilled.v1595, spilled.v1660, true)
spilled.v1662 = spiral_w64.add(spilled.v1563, spilled.v1661, true)
spilled.v1663 = spiral_w64.add(spilled.v1531, spilled.v1662, true)
spilled.v1664 = spiral_w64.add(spilled.v1499, spilled.v1663, true)
spilled.v1665 = spiral_w64.eq(spilled.v1467, 0)
spilled.v1666 = spiral_w64.eq(spilled.v1664, spilled.v1467)
spilled.v1667 = (spilled.v1665) and (spilled.v1666)
if spilled.v1667 then
else
    _G.error("typed-FX-statement-stale-writer-conflict-program-append-associativity-runtime-mismatch")
end
spilled.v1668 = 0 + 1
spilled.v1669 = spilled.v1668 + 1
spilled.v1670 = spilled.v1669 + 1
spilled.v1671 = spilled.v1670 + 1
spilled.v1672 = 0 + 1
spilled.v1673 = spilled.v1672 + 1
spilled.v1674 = spilled.v1673 + 1
spilled.v1675 = spilled.v1674 + 1
spilled.v1676 = spiral_w64.eq(spilled.v1671, spilled.v1675)
spilled.getv1677 = function()
    if spilled.v1676 then
        return 0
    else
        return 1
    end
end
spilled.v1677 = spilled.getv1677()
spilled.v1678 = 0 + 1
spilled.v1679 = 0 + 1
spilled.v1680 = spiral_w64.eq(spilled.v1678, spilled.v1679)
spilled.getv1681 = function()
    if spilled.v1680 then
        return 0
    else
        return 1
    end
end
spilled.v1681 = spilled.getv1681()
spilled.v1682 = 0 + 1
spilled.v1683 = spilled.v1682 + 1
spilled.v1684 = spilled.v1683 + 1
spilled.v1685 = spilled.v1684 + 1
spilled.v1686 = spilled.v1685 + 1
spilled.v1687 = 0 + 1
spilled.v1688 = spilled.v1687 + 1
spilled.v1689 = spilled.v1688 + 1
spilled.v1690 = spilled.v1689 + 1
spilled.v1691 = spilled.v1690 + 1
spilled.v1692 = spiral_w64.eq(spilled.v1686, spilled.v1691)
spilled.getv1693 = function()
    if spilled.v1692 then
        return 0
    else
        return 1
    end
end
spilled.v1693 = spilled.getv1693()
spilled.v1696 = spiral_w64.add(spilled.v1681, spilled.v1693, true)
spilled.v1699 = spiral_w64.add(spilled.v1677, spilled.v1696, true)
spilled.v1700 = 0 + 1
spilled.v1701 = spilled.v1700 + 1
spilled.v1702 = spilled.v1701 + 1
spilled.v1703 = spilled.v1702 + 1
spilled.v1704 = 0 + 1
spilled.v1705 = spilled.v1704 + 1
spilled.v1706 = spilled.v1705 + 1
spilled.v1707 = spilled.v1706 + 1
spilled.v1708 = spiral_w64.eq(spilled.v1703, spilled.v1707)
spilled.getv1709 = function()
    if spilled.v1708 then
        return 0
    else
        return 1
    end
end
spilled.v1709 = spilled.getv1709()
spilled.v1710 = 0 + 1
spilled.v1711 = 0 + 1
spilled.v1712 = spiral_w64.eq(spilled.v1710, spilled.v1711)
spilled.getv1713 = function()
    if spilled.v1712 then
        return 0
    else
        return 1
    end
end
spilled.v1713 = spilled.getv1713()
spilled.v1714 = 0 + 1
spilled.v1715 = spilled.v1714 + 1
spilled.v1716 = spilled.v1715 + 1
spilled.v1717 = spilled.v1716 + 1
spilled.v1718 = spilled.v1717 + 1
spilled.v1719 = 0 + 1
spilled.v1720 = spilled.v1719 + 1
spilled.v1721 = spilled.v1720 + 1
spilled.v1722 = spilled.v1721 + 1
spilled.v1723 = spilled.v1722 + 1
spilled.v1724 = spiral_w64.eq(spilled.v1718, spilled.v1723)
spilled.getv1725 = function()
    if spilled.v1724 then
        return 0
    else
        return 1
    end
end
spilled.v1725 = spilled.getv1725()
spilled.v1728 = spiral_w64.add(spilled.v1713, spilled.v1725, true)
spilled.v1731 = spiral_w64.add(spilled.v1709, spilled.v1728, true)
spilled.v1732 = spiral_w64.add(spilled.v1699, spilled.v1731, true)
spilled.v1733 = 0 + 1
spilled.v1734 = spilled.v1733 + 1
spilled.v1735 = spilled.v1734 + 1
spilled.v1736 = spilled.v1735 + 1
spilled.v1737 = 0 + 1
spilled.v1738 = spilled.v1737 + 1
spilled.v1739 = spilled.v1738 + 1
spilled.v1740 = spilled.v1739 + 1
spilled.v1741 = spiral_w64.eq(spilled.v1736, spilled.v1740)
spilled.getv1742 = function()
    if spilled.v1741 then
        return 0
    else
        return 1
    end
end
spilled.v1742 = spilled.getv1742()
spilled.v1743 = 0 + 1
spilled.v1744 = 0 + 1
spilled.v1745 = spiral_w64.eq(spilled.v1743, spilled.v1744)
spilled.getv1746 = function()
    if spilled.v1745 then
        return 0
    else
        return 1
    end
end
spilled.v1746 = spilled.getv1746()
spilled.v1747 = 0 + 1
spilled.v1748 = spilled.v1747 + 1
spilled.v1749 = spilled.v1748 + 1
spilled.v1750 = spilled.v1749 + 1
spilled.v1751 = spilled.v1750 + 1
spilled.v1752 = 0 + 1
spilled.v1753 = spilled.v1752 + 1
spilled.v1754 = spilled.v1753 + 1
spilled.v1755 = spilled.v1754 + 1
spilled.v1756 = spilled.v1755 + 1
spilled.v1757 = spiral_w64.eq(spilled.v1751, spilled.v1756)
spilled.getv1758 = function()
    if spilled.v1757 then
        return 0
    else
        return 1
    end
end
spilled.v1758 = spilled.getv1758()
spilled.v1761 = spiral_w64.add(spilled.v1746, spilled.v1758, true)
spilled.v1764 = spiral_w64.add(spilled.v1742, spilled.v1761, true)
spilled.v1765 = 0 + 1
spilled.v1766 = spilled.v1765 + 1
spilled.v1767 = spilled.v1766 + 1
spilled.v1768 = spilled.v1767 + 1
spilled.v1769 = 0 + 1
spilled.v1770 = spilled.v1769 + 1
spilled.v1771 = spilled.v1770 + 1
spilled.v1772 = spilled.v1771 + 1
spilled.v1773 = spiral_w64.eq(spilled.v1768, spilled.v1772)
spilled.getv1774 = function()
    if spilled.v1773 then
        return 0
    else
        return 1
    end
end
spilled.v1774 = spilled.getv1774()
spilled.v1775 = 0 + 1
spilled.v1776 = 0 + 1
spilled.v1777 = spiral_w64.eq(spilled.v1775, spilled.v1776)
spilled.getv1778 = function()
    if spilled.v1777 then
        return 0
    else
        return 1
    end
end
spilled.v1778 = spilled.getv1778()
spilled.v1779 = 0 + 1
spilled.v1780 = spilled.v1779 + 1
spilled.v1781 = spilled.v1780 + 1
spilled.v1782 = spilled.v1781 + 1
spilled.v1783 = spilled.v1782 + 1
spilled.v1784 = 0 + 1
spilled.v1785 = spilled.v1784 + 1
spilled.v1786 = spilled.v1785 + 1
spilled.v1787 = spilled.v1786 + 1
spilled.v1788 = spilled.v1787 + 1
spilled.v1789 = spiral_w64.eq(spilled.v1783, spilled.v1788)
spilled.getv1790 = function()
    if spilled.v1789 then
        return 0
    else
        return 1
    end
end
spilled.v1790 = spilled.getv1790()
spilled.v1793 = spiral_w64.add(spilled.v1778, spilled.v1790, true)
spilled.v1796 = spiral_w64.add(spilled.v1774, spilled.v1793, true)
spilled.v1797 = 0 + 1
spilled.v1798 = spilled.v1797 + 1
spilled.v1799 = spilled.v1798 + 1
spilled.v1800 = spilled.v1799 + 1
spilled.v1801 = 0 + 1
spilled.v1802 = spilled.v1801 + 1
spilled.v1803 = spilled.v1802 + 1
spilled.v1804 = spilled.v1803 + 1
spilled.v1805 = spiral_w64.eq(spilled.v1800, spilled.v1804)
spilled.getv1806 = function()
    if spilled.v1805 then
        return 0
    else
        return 1
    end
end
spilled.v1806 = spilled.getv1806()
spilled.v1807 = 0 + 1
spilled.v1808 = 0 + 1
spilled.v1809 = spiral_w64.eq(spilled.v1807, spilled.v1808)
spilled.getv1810 = function()
    if spilled.v1809 then
        return 0
    else
        return 1
    end
end
spilled.v1810 = spilled.getv1810()
spilled.v1811 = 0 + 1
spilled.v1812 = spilled.v1811 + 1
spilled.v1813 = spilled.v1812 + 1
spilled.v1814 = spilled.v1813 + 1
spilled.v1815 = spilled.v1814 + 1
spilled.v1816 = 0 + 1
spilled.v1817 = spilled.v1816 + 1
spilled.v1818 = spilled.v1817 + 1
spilled.v1819 = spilled.v1818 + 1
spilled.v1820 = spilled.v1819 + 1
spilled.v1821 = spiral_w64.eq(spilled.v1815, spilled.v1820)
spilled.getv1822 = function()
    if spilled.v1821 then
        return 0
    else
        return 1
    end
end
spilled.v1822 = spilled.getv1822()
spilled.v1825 = spiral_w64.add(spilled.v1810, spilled.v1822, true)
spilled.v1828 = spiral_w64.add(spilled.v1806, spilled.v1825, true)
spilled.v1829 = 0 + 1
spilled.v1830 = spilled.v1829 + 1
spilled.v1831 = spilled.v1830 + 1
spilled.v1832 = spilled.v1831 + 1
spilled.v1833 = 0 + 1
spilled.v1834 = spilled.v1833 + 1
spilled.v1835 = spilled.v1834 + 1
spilled.v1836 = spilled.v1835 + 1
spilled.v1837 = spiral_w64.eq(spilled.v1832, spilled.v1836)
spilled.getv1838 = function()
    if spilled.v1837 then
        return 0
    else
        return 1
    end
end
spilled.v1838 = spilled.getv1838()
spilled.v1839 = 0 + 1
spilled.v1840 = 0 + 1
spilled.v1841 = spiral_w64.eq(spilled.v1839, spilled.v1840)
spilled.getv1842 = function()
    if spilled.v1841 then
        return 0
    else
        return 1
    end
end
spilled.v1842 = spilled.getv1842()
spilled.v1843 = 0 + 1
spilled.v1844 = spilled.v1843 + 1
spilled.v1845 = spilled.v1844 + 1
spilled.v1846 = spilled.v1845 + 1
spilled.v1847 = spilled.v1846 + 1
spilled.v1848 = 0 + 1
spilled.v1849 = spilled.v1848 + 1
spilled.v1850 = spilled.v1849 + 1
spilled.v1851 = spilled.v1850 + 1
spilled.v1852 = spilled.v1851 + 1
spilled.v1853 = spiral_w64.eq(spilled.v1847, spilled.v1852)
spilled.getv1854 = function()
    if spilled.v1853 then
        return 0
    else
        return 1
    end
end
spilled.v1854 = spilled.getv1854()
spilled.v1857 = spiral_w64.add(spilled.v1842, spilled.v1854, true)
spilled.v1860 = spiral_w64.add(spilled.v1838, spilled.v1857, true)
spilled.v1861 = spiral_w64.add(spilled.v1828, spilled.v1860, true)
spilled.v1862 = spiral_w64.add(spilled.v1796, spilled.v1861, true)
spilled.v1863 = spiral_w64.add(spilled.v1764, spilled.v1862, true)
spilled.v1864 = spiral_w64.add(spilled.v1732, spilled.v1863, true)
spilled.v1865 = 0 + 1
spilled.v1866 = spilled.v1865 + 1
spilled.v1867 = spilled.v1866 + 1
spilled.v1868 = spilled.v1867 + 1
spilled.v1869 = 0 + 1
spilled.v1870 = spilled.v1869 + 1
spilled.v1871 = spilled.v1870 + 1
spilled.v1872 = spilled.v1871 + 1
spilled.v1873 = spiral_w64.eq(spilled.v1868, spilled.v1872)
spilled.getv1874 = function()
    if spilled.v1873 then
        return 0
    else
        return 1
    end
end
spilled.v1874 = spilled.getv1874()
spilled.v1875 = 0 + 1
spilled.v1876 = 0 + 1
spilled.v1877 = spiral_w64.eq(spilled.v1875, spilled.v1876)
spilled.getv1878 = function()
    if spilled.v1877 then
        return 0
    else
        return 1
    end
end
spilled.v1878 = spilled.getv1878()
spilled.v1879 = 0 + 1
spilled.v1880 = spilled.v1879 + 1
spilled.v1881 = spilled.v1880 + 1
spilled.v1882 = spilled.v1881 + 1
spilled.v1883 = spilled.v1882 + 1
spilled.v1884 = 0 + 1
spilled.v1885 = spilled.v1884 + 1
spilled.v1886 = spilled.v1885 + 1
spilled.v1887 = spilled.v1886 + 1
spilled.v1888 = spilled.v1887 + 1
spilled.v1889 = spiral_w64.eq(spilled.v1883, spilled.v1888)
spilled.getv1890 = function()
    if spilled.v1889 then
        return 0
    else
        return 1
    end
end
spilled.v1890 = spilled.getv1890()
spilled.v1891 = spiral_w64.add(spilled.v1875, spilled.v1883, true)
spilled.v1892 = spiral_w64.add(spilled.v1876, spilled.v1888, true)
spilled.v1893 = spiral_w64.add(spilled.v1878, spilled.v1890, true)
spilled.v1894 = spiral_w64.add(spilled.v1868, spilled.v1891, true)
spilled.v1895 = spiral_w64.add(spilled.v1872, spilled.v1892, true)
spilled.v1896 = spiral_w64.add(spilled.v1874, spilled.v1893, true)
spilled.v1897 = spiral_w64.add(spilled.v1895, spilled.v1896, true)
spilled.v1898 = spiral_w64.add(spilled.v1894, spilled.v1897, true)
spilled.v1899 = spiral_w64.add(3, spilled.v1898, true)
spilled.v1900 = 0 + 1
spilled.v1901 = spilled.v1900 + 1
spilled.v1902 = spilled.v1901 + 1
spilled.v1903 = spilled.v1902 + 1
spilled.v1904 = 0 + 1
spilled.v1905 = spilled.v1904 + 1
spilled.v1906 = spilled.v1905 + 1
spilled.v1907 = spilled.v1906 + 1
spilled.v1908 = spiral_w64.eq(spilled.v1903, spilled.v1907)
spilled.getv1909 = function()
    if spilled.v1908 then
        return 0
    else
        return 1
    end
end
spilled.v1909 = spilled.getv1909()
spilled.v1910 = 0 + 1
spilled.v1911 = 0 + 1
spilled.v1912 = spiral_w64.eq(spilled.v1910, spilled.v1911)
spilled.getv1913 = function()
    if spilled.v1912 then
        return 0
    else
        return 1
    end
end
spilled.v1913 = spilled.getv1913()
spilled.v1914 = 0 + 1
spilled.v1915 = spilled.v1914 + 1
spilled.v1916 = spilled.v1915 + 1
spilled.v1917 = spilled.v1916 + 1
spilled.v1918 = spilled.v1917 + 1
spilled.v1919 = 0 + 1
spilled.v1920 = spilled.v1919 + 1
spilled.v1921 = spilled.v1920 + 1
spilled.v1922 = spilled.v1921 + 1
spilled.v1923 = spilled.v1922 + 1
spilled.v1924 = spiral_w64.eq(spilled.v1918, spilled.v1923)
spilled.getv1925 = function()
    if spilled.v1924 then
        return 0
    else
        return 1
    end
end
spilled.v1925 = spilled.getv1925()
spilled.v1926 = spiral_w64.add(spilled.v1910, spilled.v1918, true)
spilled.v1927 = spiral_w64.add(spilled.v1911, spilled.v1923, true)
spilled.v1928 = spiral_w64.add(spilled.v1913, spilled.v1925, true)
spilled.v1929 = spiral_w64.add(spilled.v1903, spilled.v1926, true)
spilled.v1930 = spiral_w64.add(spilled.v1907, spilled.v1927, true)
spilled.v1931 = spiral_w64.add(spilled.v1909, spilled.v1928, true)
spilled.v1932 = spiral_w64.add(spilled.v1930, spilled.v1931, true)
spilled.v1933 = spiral_w64.add(spilled.v1929, spilled.v1932, true)
spilled.v1934 = spiral_w64.add(3, spilled.v1933, true)
spilled.v1935 = spiral_w64.eq(spilled.v1899, spilled.v1934)
spilled.getv1972 = function()
    if spilled.v1935 then
        local v1936 = 0 + 1
        local v1937 = v1936 + 1
        local v1938 = v1937 + 1
        local v1939 = v1938 + 1
        local v1940 = 0 + 1
        local v1941 = v1940 + 1
        local v1942 = v1941 + 1
        local v1943 = v1942 + 1
        local v1944 = spiral_w64.eq(v1939, v1943)
        local getv1945 = function()
            if v1944 then
                return 0
            else
                return 1
            end
        end
        local v1945 = getv1945()
        local v1946 = 0 + 1
        local v1947 = 0 + 1
        local v1948 = spiral_w64.eq(v1946, v1947)
        local getv1949 = function()
            if v1948 then
                return 0
            else
                return 1
            end
        end
        local v1949 = getv1949()
        local v1950 = 0 + 1
        local v1951 = v1950 + 1
        local v1952 = v1951 + 1
        local v1953 = v1952 + 1
        local v1954 = v1953 + 1
        local v1955 = 0 + 1
        local v1956 = v1955 + 1
        local v1957 = v1956 + 1
        local v1958 = v1957 + 1
        local v1959 = v1958 + 1
        local v1960 = spiral_w64.eq(v1954, v1959)
        local getv1961 = function()
            if v1960 then
                return 0
            else
                return 1
            end
        end
        local v1961 = getv1961()
        local v1962 = spiral_w64.add(v1946, v1954, true)
        local v1963 = spiral_w64.add(v1947, v1959, true)
        local v1964 = spiral_w64.add(v1949, v1961, true)
        local v1965 = spiral_w64.add(v1939, v1962, true)
        local v1966 = spiral_w64.add(v1943, v1963, true)
        local v1967 = spiral_w64.add(v1945, v1964, true)
        local v1968 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        return Us0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v1965, v1966, v1967, v1968)
    else
        local v1970 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        return Us0_TypedFxHashedStatementChecksumValidationRejected(spilled.v1899, spilled.v1934, v1970)
    end
end
spilled.v1972 = spilled.getv1972()
spilled.getv1991 = function()
    if spilled.v1972 ~= nil and spilled.v1972.tag == "Us0_TypedFxHashedStatementChecksumValidationAccepted" then
        local v1976 = spilled.v1972._1
        local v1977 = spilled.v1972._2
        local v1978 = spilled.v1972._3
        local v1979 = spilled.v1972._4
        local v1980 = spilled.v1972._5
        local v1981 = spilled.v1972._6
        return { [1]=1, [2]=0, [3]=v1976, [4]=v1980 }
    elseif spilled.v1972 ~= nil and spilled.v1972.tag == "Us0_TypedFxHashedStatementChecksumValidationRejected" then
        local v1973 = spilled.v1972._1
        local v1974 = spilled.v1972._2
        local v1975 = spilled.v1972._3
        return { [1]=0, [2]=1, [3]=0, [4]=0 }
    end
end
spilled.v1991, spilled.v1992, spilled.v1995, spilled.v1999 = (table.unpack or unpack)(spilled.getv1991())
spilled.v2000 = 0 + 1
spilled.v2001 = spilled.v2000 + 1
spilled.v2002 = spilled.v2001 + 1
spilled.v2003 = spilled.v2002 + 1
spilled.v2004 = 0 + 1
spilled.v2005 = spilled.v2004 + 1
spilled.v2006 = spilled.v2005 + 1
spilled.v2007 = spilled.v2006 + 1
spilled.v2008 = spiral_w64.eq(spilled.v2003, spilled.v2007)
spilled.getv2009 = function()
    if spilled.v2008 then
        return 0
    else
        return 1
    end
end
spilled.v2009 = spilled.getv2009()
spilled.v2010 = 0 + 1
spilled.v2011 = 0 + 1
spilled.v2012 = spiral_w64.eq(spilled.v2010, spilled.v2011)
spilled.getv2013 = function()
    if spilled.v2012 then
        return 0
    else
        return 1
    end
end
spilled.v2013 = spilled.getv2013()
spilled.v2014 = 0 + 1
spilled.v2015 = spilled.v2014 + 1
spilled.v2016 = spilled.v2015 + 1
spilled.v2017 = spilled.v2016 + 1
spilled.v2018 = spilled.v2017 + 1
spilled.v2019 = 0 + 1
spilled.v2020 = spilled.v2019 + 1
spilled.v2021 = spilled.v2020 + 1
spilled.v2022 = spilled.v2021 + 1
spilled.v2023 = spilled.v2022 + 1
spilled.v2024 = spiral_w64.eq(spilled.v2018, spilled.v2023)
spilled.getv2025 = function()
    if spilled.v2024 then
        return 0
    else
        return 1
    end
end
spilled.v2025 = spilled.getv2025()
spilled.v2028 = spiral_w64.add(spilled.v2013, spilled.v2025, true)
spilled.v2031 = spiral_w64.add(spilled.v2009, spilled.v2028, true)
spilled.v2032 = 0 + 1
spilled.v2033 = spilled.v2032 + 1
spilled.v2034 = spilled.v2033 + 1
spilled.v2035 = spilled.v2034 + 1
spilled.v2036 = 0 + 1
spilled.v2037 = spilled.v2036 + 1
spilled.v2038 = spilled.v2037 + 1
spilled.v2039 = spilled.v2038 + 1
spilled.v2040 = spiral_w64.eq(spilled.v2035, spilled.v2039)
spilled.getv2041 = function()
    if spilled.v2040 then
        return 0
    else
        return 1
    end
end
spilled.v2041 = spilled.getv2041()
spilled.v2042 = 0 + 1
spilled.v2043 = 0 + 1
spilled.v2044 = spiral_w64.eq(spilled.v2042, spilled.v2043)
spilled.getv2045 = function()
    if spilled.v2044 then
        return 0
    else
        return 1
    end
end
spilled.v2045 = spilled.getv2045()
spilled.v2046 = 0 + 1
spilled.v2047 = spilled.v2046 + 1
spilled.v2048 = spilled.v2047 + 1
spilled.v2049 = spilled.v2048 + 1
spilled.v2050 = spilled.v2049 + 1
spilled.v2051 = 0 + 1
spilled.v2052 = spilled.v2051 + 1
spilled.v2053 = spilled.v2052 + 1
spilled.v2054 = spilled.v2053 + 1
spilled.v2055 = spilled.v2054 + 1
spilled.v2056 = spiral_w64.eq(spilled.v2050, spilled.v2055)
spilled.getv2057 = function()
    if spilled.v2056 then
        return 0
    else
        return 1
    end
end
spilled.v2057 = spilled.getv2057()
spilled.v2060 = spiral_w64.add(spilled.v2045, spilled.v2057, true)
spilled.v2063 = spiral_w64.add(spilled.v2041, spilled.v2060, true)
spilled.v2064 = 0 + 1
spilled.v2065 = spilled.v2064 + 1
spilled.v2066 = spilled.v2065 + 1
spilled.v2067 = spilled.v2066 + 1
spilled.v2068 = 0 + 1
spilled.v2069 = spilled.v2068 + 1
spilled.v2070 = spilled.v2069 + 1
spilled.v2071 = spilled.v2070 + 1
spilled.v2072 = spiral_w64.eq(spilled.v2067, spilled.v2071)
spilled.getv2073 = function()
    if spilled.v2072 then
        return 0
    else
        return 1
    end
end
spilled.v2073 = spilled.getv2073()
spilled.v2074 = 0 + 1
spilled.v2075 = 0 + 1
spilled.v2076 = spiral_w64.eq(spilled.v2074, spilled.v2075)
spilled.getv2077 = function()
    if spilled.v2076 then
        return 0
    else
        return 1
    end
end
spilled.v2077 = spilled.getv2077()
spilled.v2078 = 0 + 1
spilled.v2079 = spilled.v2078 + 1
spilled.v2080 = spilled.v2079 + 1
spilled.v2081 = spilled.v2080 + 1
spilled.v2082 = spilled.v2081 + 1
spilled.v2083 = 0 + 1
spilled.v2084 = spilled.v2083 + 1
spilled.v2085 = spilled.v2084 + 1
spilled.v2086 = spilled.v2085 + 1
spilled.v2087 = spilled.v2086 + 1
spilled.v2088 = spiral_w64.eq(spilled.v2082, spilled.v2087)
spilled.getv2089 = function()
    if spilled.v2088 then
        return 0
    else
        return 1
    end
end
spilled.v2089 = spilled.getv2089()
spilled.v2092 = spiral_w64.add(spilled.v2077, spilled.v2089, true)
spilled.v2095 = spiral_w64.add(spilled.v2073, spilled.v2092, true)
spilled.v2096 = 0 + 1
spilled.v2097 = spilled.v2096 + 1
spilled.v2098 = spilled.v2097 + 1
spilled.v2099 = spilled.v2098 + 1
spilled.v2100 = 0 + 1
spilled.v2101 = spilled.v2100 + 1
spilled.v2102 = spilled.v2101 + 1
spilled.v2103 = spilled.v2102 + 1
spilled.v2104 = spiral_w64.eq(spilled.v2099, spilled.v2103)
spilled.getv2105 = function()
    if spilled.v2104 then
        return 0
    else
        return 1
    end
end
spilled.v2105 = spilled.getv2105()
spilled.v2106 = 0 + 1
spilled.v2107 = 0 + 1
spilled.v2108 = spiral_w64.eq(spilled.v2106, spilled.v2107)
spilled.getv2109 = function()
    if spilled.v2108 then
        return 0
    else
        return 1
    end
end
spilled.v2109 = spilled.getv2109()
spilled.v2110 = 0 + 1
spilled.v2111 = spilled.v2110 + 1
spilled.v2112 = spilled.v2111 + 1
spilled.v2113 = spilled.v2112 + 1
spilled.v2114 = spilled.v2113 + 1
spilled.v2115 = 0 + 1
spilled.v2116 = spilled.v2115 + 1
spilled.v2117 = spilled.v2116 + 1
spilled.v2118 = spilled.v2117 + 1
spilled.v2119 = spilled.v2118 + 1
spilled.v2120 = spiral_w64.eq(spilled.v2114, spilled.v2119)
spilled.getv2121 = function()
    if spilled.v2120 then
        return 0
    else
        return 1
    end
end
spilled.v2121 = spilled.getv2121()
spilled.v2124 = spiral_w64.add(spilled.v2109, spilled.v2121, true)
spilled.v2127 = spiral_w64.add(spilled.v2105, spilled.v2124, true)
spilled.v2128 = spiral_w64.add(spilled.v2095, spilled.v2127, true)
spilled.v2129 = spiral_w64.add(spilled.v2063, spilled.v2128, true)
spilled.v2130 = spiral_w64.add(spilled.v2031, spilled.v2129, true)
spilled.v2131 = spiral_w64.add(spilled.v1999, spilled.v1992, true)
spilled.v2132 = spiral_w64.add(spilled.v2130, spilled.v2131, true)
spilled.v2133 = spiral_w64.add(spilled.v1864, spilled.v2132, true)
spilled.v2134 = spiral_w64.eq(spilled.v1995, 1)
spilled.v2135 = spiral_w64.eq(spilled.v1991, 1)
spilled.v2136 = spiral_w64.eq(spilled.v2133, 0)
spilled.v2137 = (spilled.v2134) and (spilled.v2135)
spilled.v2138 = (spilled.v2137) and (spilled.v2136)
if spilled.v2138 then
else
    _G.error("typed-FX-statement-recursive-writer-appended-tail-restart-runtime-mismatch")
end
spilled.v2139 = 0 + 1
spilled.v2140 = spilled.v2139 + 1
spilled.v2141 = spilled.v2140 + 1
spilled.v2142 = spilled.v2141 + 1
spilled.v2143 = 0 + 1
spilled.v2144 = spilled.v2143 + 1
spilled.v2145 = spilled.v2144 + 1
spilled.v2146 = spilled.v2145 + 1
spilled.v2147 = spiral_w64.eq(spilled.v2142, spilled.v2146)
spilled.getv2148 = function()
    if spilled.v2147 then
        return 0
    else
        return 1
    end
end
spilled.v2148 = spilled.getv2148()
spilled.v2149 = 0 + 1
spilled.v2150 = 0 + 1
spilled.v2151 = spiral_w64.eq(spilled.v2149, spilled.v2150)
spilled.getv2152 = function()
    if spilled.v2151 then
        return 0
    else
        return 1
    end
end
spilled.v2152 = spilled.getv2152()
spilled.v2153 = 0 + 1
spilled.v2154 = spilled.v2153 + 1
spilled.v2155 = spilled.v2154 + 1
spilled.v2156 = spilled.v2155 + 1
spilled.v2157 = spilled.v2156 + 1
spilled.v2158 = 0 + 1
spilled.v2159 = spilled.v2158 + 1
spilled.v2160 = spilled.v2159 + 1
spilled.v2161 = spilled.v2160 + 1
spilled.v2162 = spilled.v2161 + 1
spilled.v2163 = spiral_w64.eq(spilled.v2157, spilled.v2162)
spilled.getv2164 = function()
    if spilled.v2163 then
        return 0
    else
        return 1
    end
end
spilled.v2164 = spilled.getv2164()
spilled.v2167 = spiral_w64.add(spilled.v2152, spilled.v2164, true)
spilled.v2170 = spiral_w64.add(spilled.v2148, spilled.v2167, true)
spilled.v2171 = 0 + 1
spilled.v2172 = spilled.v2171 + 1
spilled.v2173 = spilled.v2172 + 1
spilled.v2174 = spilled.v2173 + 1
spilled.v2175 = 0 + 1
spilled.v2176 = spilled.v2175 + 1
spilled.v2177 = spilled.v2176 + 1
spilled.v2178 = spilled.v2177 + 1
spilled.v2179 = spiral_w64.eq(spilled.v2174, spilled.v2178)
spilled.getv2180 = function()
    if spilled.v2179 then
        return 0
    else
        return 1
    end
end
spilled.v2180 = spilled.getv2180()
spilled.v2181 = 0 + 1
spilled.v2182 = 0 + 1
spilled.v2183 = spiral_w64.eq(spilled.v2181, spilled.v2182)
spilled.getv2184 = function()
    if spilled.v2183 then
        return 0
    else
        return 1
    end
end
spilled.v2184 = spilled.getv2184()
spilled.v2185 = 0 + 1
spilled.v2186 = spilled.v2185 + 1
spilled.v2187 = spilled.v2186 + 1
spilled.v2188 = spilled.v2187 + 1
spilled.v2189 = spilled.v2188 + 1
spilled.v2190 = 0 + 1
spilled.v2191 = spilled.v2190 + 1
spilled.v2192 = spilled.v2191 + 1
spilled.v2193 = spilled.v2192 + 1
spilled.v2194 = spilled.v2193 + 1
spilled.v2195 = spiral_w64.eq(spilled.v2189, spilled.v2194)
spilled.getv2196 = function()
    if spilled.v2195 then
        return 0
    else
        return 1
    end
end
spilled.v2196 = spilled.getv2196()
spilled.v2199 = spiral_w64.add(spilled.v2184, spilled.v2196, true)
spilled.v2202 = spiral_w64.add(spilled.v2180, spilled.v2199, true)
spilled.v2203 = spiral_w64.add(spilled.v2170, spilled.v2202, true)
spilled.v2204 = 0 + 1
spilled.v2205 = spilled.v2204 + 1
spilled.v2206 = spilled.v2205 + 1
spilled.v2207 = spilled.v2206 + 1
spilled.v2208 = 0 + 1
spilled.v2209 = spilled.v2208 + 1
spilled.v2210 = spilled.v2209 + 1
spilled.v2211 = spilled.v2210 + 1
spilled.v2212 = spiral_w64.eq(spilled.v2207, spilled.v2211)
spilled.getv2213 = function()
    if spilled.v2212 then
        return 0
    else
        return 1
    end
end
spilled.v2213 = spilled.getv2213()
spilled.v2214 = 0 + 1
spilled.v2215 = 0 + 1
spilled.v2216 = spiral_w64.eq(spilled.v2214, spilled.v2215)
spilled.getv2217 = function()
    if spilled.v2216 then
        return 0
    else
        return 1
    end
end
spilled.v2217 = spilled.getv2217()
spilled.v2218 = 0 + 1
spilled.v2219 = spilled.v2218 + 1
spilled.v2220 = spilled.v2219 + 1
spilled.v2221 = spilled.v2220 + 1
spilled.v2222 = spilled.v2221 + 1
spilled.v2223 = 0 + 1
spilled.v2224 = spilled.v2223 + 1
spilled.v2225 = spilled.v2224 + 1
spilled.v2226 = spilled.v2225 + 1
spilled.v2227 = spilled.v2226 + 1
spilled.v2228 = spiral_w64.eq(spilled.v2222, spilled.v2227)
spilled.getv2229 = function()
    if spilled.v2228 then
        return 0
    else
        return 1
    end
end
spilled.v2229 = spilled.getv2229()
spilled.v2232 = spiral_w64.add(spilled.v2217, spilled.v2229, true)
spilled.v2235 = spiral_w64.add(spilled.v2213, spilled.v2232, true)
spilled.v2236 = 0 + 1
spilled.v2237 = spilled.v2236 + 1
spilled.v2238 = spilled.v2237 + 1
spilled.v2239 = spilled.v2238 + 1
spilled.v2240 = 0 + 1
spilled.v2241 = spilled.v2240 + 1
spilled.v2242 = spilled.v2241 + 1
spilled.v2243 = spilled.v2242 + 1
spilled.v2244 = spiral_w64.eq(spilled.v2239, spilled.v2243)
spilled.getv2245 = function()
    if spilled.v2244 then
        return 0
    else
        return 1
    end
end
spilled.v2245 = spilled.getv2245()
spilled.v2246 = 0 + 1
spilled.v2247 = 0 + 1
spilled.v2248 = spiral_w64.eq(spilled.v2246, spilled.v2247)
spilled.getv2249 = function()
    if spilled.v2248 then
        return 0
    else
        return 1
    end
end
spilled.v2249 = spilled.getv2249()
spilled.v2250 = 0 + 1
spilled.v2251 = spilled.v2250 + 1
spilled.v2252 = spilled.v2251 + 1
spilled.v2253 = spilled.v2252 + 1
spilled.v2254 = spilled.v2253 + 1
spilled.v2255 = 0 + 1
spilled.v2256 = spilled.v2255 + 1
spilled.v2257 = spilled.v2256 + 1
spilled.v2258 = spilled.v2257 + 1
spilled.v2259 = spilled.v2258 + 1
spilled.v2260 = spiral_w64.eq(spilled.v2254, spilled.v2259)
spilled.getv2261 = function()
    if spilled.v2260 then
        return 0
    else
        return 1
    end
end
spilled.v2261 = spilled.getv2261()
spilled.v2264 = spiral_w64.add(spilled.v2249, spilled.v2261, true)
spilled.v2267 = spiral_w64.add(spilled.v2245, spilled.v2264, true)
spilled.v2268 = spiral_w64.add(spilled.v2235, spilled.v2267, true)
spilled.v2269 = spiral_w64.add(spilled.v2203, spilled.v2268, true)
spilled.v2270 = 0 + 1
spilled.v2271 = spilled.v2270 + 1
spilled.v2272 = spilled.v2271 + 1
spilled.v2273 = spilled.v2272 + 1
spilled.v2274 = 0 + 1
spilled.v2275 = spilled.v2274 + 1
spilled.v2276 = spilled.v2275 + 1
spilled.v2277 = spilled.v2276 + 1
spilled.v2278 = spiral_w64.eq(spilled.v2273, spilled.v2277)
spilled.getv2279 = function()
    if spilled.v2278 then
        return 0
    else
        return 1
    end
end
spilled.v2279 = spilled.getv2279()
spilled.v2280 = 0 + 1
spilled.v2281 = 0 + 1
spilled.v2282 = spiral_w64.eq(spilled.v2280, spilled.v2281)
spilled.getv2283 = function()
    if spilled.v2282 then
        return 0
    else
        return 1
    end
end
spilled.v2283 = spilled.getv2283()
spilled.v2284 = 0 + 1
spilled.v2285 = spilled.v2284 + 1
spilled.v2286 = spilled.v2285 + 1
spilled.v2287 = spilled.v2286 + 1
spilled.v2288 = spilled.v2287 + 1
spilled.v2289 = 0 + 1
spilled.v2290 = spilled.v2289 + 1
spilled.v2291 = spilled.v2290 + 1
spilled.v2292 = spilled.v2291 + 1
spilled.v2293 = spilled.v2292 + 1
spilled.v2294 = spiral_w64.eq(spilled.v2288, spilled.v2293)
spilled.getv2295 = function()
    if spilled.v2294 then
        return 0
    else
        return 1
    end
end
spilled.v2295 = spilled.getv2295()
spilled.v2296 = spiral_w64.add(spilled.v2280, spilled.v2288, true)
spilled.v2297 = spiral_w64.add(spilled.v2281, spilled.v2293, true)
spilled.v2298 = spiral_w64.add(spilled.v2283, spilled.v2295, true)
spilled.v2299 = spiral_w64.add(spilled.v2273, spilled.v2296, true)
spilled.v2300 = spiral_w64.add(spilled.v2277, spilled.v2297, true)
spilled.v2301 = spiral_w64.add(spilled.v2279, spilled.v2298, true)
spilled.v2302 = spiral_w64.add(spilled.v2300, spilled.v2301, true)
spilled.v2303 = spiral_w64.add(spilled.v2299, spilled.v2302, true)
spilled.v2304 = spiral_w64.add(3, spilled.v2303, true)
spilled.v2305 = 0 + 1
spilled.v2306 = spilled.v2305 + 1
spilled.v2307 = spilled.v2306 + 1
spilled.v2308 = spilled.v2307 + 1
spilled.v2309 = 0 + 1
spilled.v2310 = spilled.v2309 + 1
spilled.v2311 = spilled.v2310 + 1
spilled.v2312 = spilled.v2311 + 1
spilled.v2313 = spiral_w64.eq(spilled.v2308, spilled.v2312)
spilled.getv2314 = function()
    if spilled.v2313 then
        return 0
    else
        return 1
    end
end
spilled.v2314 = spilled.getv2314()
spilled.v2315 = 0 + 1
spilled.v2316 = 0 + 1
spilled.v2317 = spiral_w64.eq(spilled.v2315, spilled.v2316)
spilled.getv2318 = function()
    if spilled.v2317 then
        return 0
    else
        return 1
    end
end
spilled.v2318 = spilled.getv2318()
spilled.v2319 = 0 + 1
spilled.v2320 = spilled.v2319 + 1
spilled.v2321 = spilled.v2320 + 1
spilled.v2322 = spilled.v2321 + 1
spilled.v2323 = spilled.v2322 + 1
spilled.v2324 = 0 + 1
spilled.v2325 = spilled.v2324 + 1
spilled.v2326 = spilled.v2325 + 1
spilled.v2327 = spilled.v2326 + 1
spilled.v2328 = spilled.v2327 + 1
spilled.v2329 = spiral_w64.eq(spilled.v2323, spilled.v2328)
spilled.getv2330 = function()
    if spilled.v2329 then
        return 0
    else
        return 1
    end
end
spilled.v2330 = spilled.getv2330()
spilled.v2331 = spiral_w64.add(spilled.v2315, spilled.v2323, true)
spilled.v2332 = spiral_w64.add(spilled.v2316, spilled.v2328, true)
spilled.v2333 = spiral_w64.add(spilled.v2318, spilled.v2330, true)
spilled.v2334 = spiral_w64.add(spilled.v2308, spilled.v2331, true)
spilled.v2335 = spiral_w64.add(spilled.v2312, spilled.v2332, true)
spilled.v2336 = spiral_w64.add(spilled.v2314, spilled.v2333, true)
spilled.v2337 = spiral_w64.add(spilled.v2335, spilled.v2336, true)
spilled.v2338 = spiral_w64.add(spilled.v2334, spilled.v2337, true)
spilled.v2339 = spiral_w64.add(3, spilled.v2338, true)
spilled.v2340 = spiral_w64.eq(spilled.v2304, spilled.v2339)
spilled.getv2377 = function()
    if spilled.v2340 then
        local v2341 = 0 + 1
        local v2342 = v2341 + 1
        local v2343 = v2342 + 1
        local v2344 = v2343 + 1
        local v2345 = 0 + 1
        local v2346 = v2345 + 1
        local v2347 = v2346 + 1
        local v2348 = v2347 + 1
        local v2349 = spiral_w64.eq(v2344, v2348)
        local getv2350 = function()
            if v2349 then
                return 0
            else
                return 1
            end
        end
        local v2350 = getv2350()
        local v2351 = 0 + 1
        local v2352 = 0 + 1
        local v2353 = spiral_w64.eq(v2351, v2352)
        local getv2354 = function()
            if v2353 then
                return 0
            else
                return 1
            end
        end
        local v2354 = getv2354()
        local v2355 = 0 + 1
        local v2356 = v2355 + 1
        local v2357 = v2356 + 1
        local v2358 = v2357 + 1
        local v2359 = v2358 + 1
        local v2360 = 0 + 1
        local v2361 = v2360 + 1
        local v2362 = v2361 + 1
        local v2363 = v2362 + 1
        local v2364 = v2363 + 1
        local v2365 = spiral_w64.eq(v2359, v2364)
        local getv2366 = function()
            if v2365 then
                return 0
            else
                return 1
            end
        end
        local v2366 = getv2366()
        local v2367 = spiral_w64.add(v2351, v2359, true)
        local v2368 = spiral_w64.add(v2352, v2364, true)
        local v2369 = spiral_w64.add(v2354, v2366, true)
        local v2370 = spiral_w64.add(v2344, v2367, true)
        local v2371 = spiral_w64.add(v2348, v2368, true)
        local v2372 = spiral_w64.add(v2350, v2369, true)
        local v2373 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        return Us0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v2370, v2371, v2372, v2373)
    else
        local v2375 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        return Us0_TypedFxHashedStatementChecksumValidationRejected(spilled.v2304, spilled.v2339, v2375)
    end
end
spilled.v2377 = spilled.getv2377()
spilled.getv2396 = function()
    if spilled.v2377 ~= nil and spilled.v2377.tag == "Us0_TypedFxHashedStatementChecksumValidationAccepted" then
        local v2381 = spilled.v2377._1
        local v2382 = spilled.v2377._2
        local v2383 = spilled.v2377._3
        local v2384 = spilled.v2377._4
        local v2385 = spilled.v2377._5
        local v2386 = spilled.v2377._6
        return { [1]=1, [2]=0, [3]=v2385 }
    elseif spilled.v2377 ~= nil and spilled.v2377.tag == "Us0_TypedFxHashedStatementChecksumValidationRejected" then
        local v2378 = spilled.v2377._1
        local v2379 = spilled.v2377._2
        local v2380 = spilled.v2377._3
        return { [1]=0, [2]=1, [3]=0 }
    end
end
spilled.v2396, spilled.v2397, spilled.v2404 = (table.unpack or unpack)(spilled.getv2396())
spilled.v2405 = 0 + 1
spilled.v2406 = spilled.v2405 + 1
spilled.v2407 = spilled.v2406 + 1
spilled.v2408 = spilled.v2407 + 1
spilled.v2409 = 0 + 1
spilled.v2410 = spilled.v2409 + 1
spilled.v2411 = spilled.v2410 + 1
spilled.v2412 = spilled.v2411 + 1
spilled.v2413 = spiral_w64.eq(spilled.v2408, spilled.v2412)
spilled.getv2414 = function()
    if spilled.v2413 then
        return 0
    else
        return 1
    end
end
spilled.v2414 = spilled.getv2414()
spilled.v2415 = 0 + 1
spilled.v2416 = 0 + 1
spilled.v2417 = spiral_w64.eq(spilled.v2415, spilled.v2416)
spilled.getv2418 = function()
    if spilled.v2417 then
        return 0
    else
        return 1
    end
end
spilled.v2418 = spilled.getv2418()
spilled.v2419 = 0 + 1
spilled.v2420 = spilled.v2419 + 1
spilled.v2421 = spilled.v2420 + 1
spilled.v2422 = spilled.v2421 + 1
spilled.v2423 = spilled.v2422 + 1
spilled.v2424 = 0 + 1
spilled.v2425 = spilled.v2424 + 1
spilled.v2426 = spilled.v2425 + 1
spilled.v2427 = spilled.v2426 + 1
spilled.v2428 = spilled.v2427 + 1
spilled.v2429 = spiral_w64.eq(spilled.v2423, spilled.v2428)
spilled.getv2430 = function()
    if spilled.v2429 then
        return 0
    else
        return 1
    end
end
spilled.v2430 = spilled.getv2430()
spilled.v2433 = spiral_w64.add(spilled.v2418, spilled.v2430, true)
spilled.v2436 = spiral_w64.add(spilled.v2414, spilled.v2433, true)
spilled.v2437 = 0 + 1
spilled.v2438 = spilled.v2437 + 1
spilled.v2439 = spilled.v2438 + 1
spilled.v2440 = spilled.v2439 + 1
spilled.v2441 = 0 + 1
spilled.v2442 = spilled.v2441 + 1
spilled.v2443 = spilled.v2442 + 1
spilled.v2444 = spilled.v2443 + 1
spilled.v2445 = spiral_w64.eq(spilled.v2440, spilled.v2444)
spilled.getv2446 = function()
    if spilled.v2445 then
        return 0
    else
        return 1
    end
end
spilled.v2446 = spilled.getv2446()
spilled.v2447 = 0 + 1
spilled.v2448 = 0 + 1
spilled.v2449 = spiral_w64.eq(spilled.v2447, spilled.v2448)
spilled.getv2450 = function()
    if spilled.v2449 then
        return 0
    else
        return 1
    end
end
spilled.v2450 = spilled.getv2450()
spilled.v2451 = 0 + 1
spilled.v2452 = spilled.v2451 + 1
spilled.v2453 = spilled.v2452 + 1
spilled.v2454 = spilled.v2453 + 1
spilled.v2455 = spilled.v2454 + 1
spilled.v2456 = 0 + 1
spilled.v2457 = spilled.v2456 + 1
spilled.v2458 = spilled.v2457 + 1
spilled.v2459 = spilled.v2458 + 1
spilled.v2460 = spilled.v2459 + 1
spilled.v2461 = spiral_w64.eq(spilled.v2455, spilled.v2460)
spilled.getv2462 = function()
    if spilled.v2461 then
        return 0
    else
        return 1
    end
end
spilled.v2462 = spilled.getv2462()
spilled.v2465 = spiral_w64.add(spilled.v2450, spilled.v2462, true)
spilled.v2468 = spiral_w64.add(spilled.v2446, spilled.v2465, true)
spilled.v2469 = spiral_w64.add(spilled.v2436, spilled.v2468, true)
spilled.v2470 = spiral_w64.add(spilled.v2404, spilled.v2397, true)
spilled.v2471 = spiral_w64.add(spilled.v2469, spilled.v2470, true)
spilled.v2472 = spiral_w64.add(spilled.v2269, spilled.v2471, true)
spilled.v2473 = spiral_w64.eq(spilled.v2396, 1)
spilled.v2474 = spiral_w64.eq(spilled.v2472, 0)
spilled.v2475 = (spilled.v2473) and (spilled.v2474)
if spilled.v2475 then
else
    _G.error("typed-FX-statement-recursive-writer-crash-phase-runtime-mismatch")
end
spilled.v2476 = 0 + 1
spilled.v2477 = spilled.v2476 + 1
spilled.v2478 = spilled.v2477 + 1
spilled.v2479 = spilled.v2478 + 1
spilled.v2480 = 0 + 1
spilled.v2481 = spilled.v2480 + 1
spilled.v2482 = spilled.v2481 + 1
spilled.v2483 = spilled.v2482 + 1
spilled.v2484 = spiral_w64.eq(spilled.v2479, spilled.v2483)
spilled.getv2485 = function()
    if spilled.v2484 then
        return 0
    else
        return 1
    end
end
spilled.v2485 = spilled.getv2485()
spilled.v2486 = 0 + 1
spilled.v2487 = 0 + 1
spilled.v2488 = spiral_w64.eq(spilled.v2486, spilled.v2487)
spilled.getv2489 = function()
    if spilled.v2488 then
        return 0
    else
        return 1
    end
end
spilled.v2489 = spilled.getv2489()
spilled.v2490 = 0 + 1
spilled.v2491 = spilled.v2490 + 1
spilled.v2492 = spilled.v2491 + 1
spilled.v2493 = spilled.v2492 + 1
spilled.v2494 = spilled.v2493 + 1
spilled.v2495 = 0 + 1
spilled.v2496 = spilled.v2495 + 1
spilled.v2497 = spilled.v2496 + 1
spilled.v2498 = spilled.v2497 + 1
spilled.v2499 = spilled.v2498 + 1
spilled.v2500 = spiral_w64.eq(spilled.v2494, spilled.v2499)
spilled.getv2501 = function()
    if spilled.v2500 then
        return 0
    else
        return 1
    end
end
spilled.v2501 = spilled.getv2501()
spilled.v2504 = spiral_w64.add(spilled.v2489, spilled.v2501, true)
spilled.v2507 = spiral_w64.add(spilled.v2485, spilled.v2504, true)
spilled.v2508 = 0 + 1
spilled.v2509 = spilled.v2508 + 1
spilled.v2510 = spilled.v2509 + 1
spilled.v2511 = spilled.v2510 + 1
spilled.v2512 = 0 + 1
spilled.v2513 = spilled.v2512 + 1
spilled.v2514 = spilled.v2513 + 1
spilled.v2515 = spilled.v2514 + 1
spilled.v2516 = spiral_w64.eq(spilled.v2511, spilled.v2515)
spilled.getv2517 = function()
    if spilled.v2516 then
        return 0
    else
        return 1
    end
end
spilled.v2517 = spilled.getv2517()
spilled.v2518 = 0 + 1
spilled.v2519 = 0 + 1
spilled.v2520 = spiral_w64.eq(spilled.v2518, spilled.v2519)
spilled.getv2521 = function()
    if spilled.v2520 then
        return 0
    else
        return 1
    end
end
spilled.v2521 = spilled.getv2521()
spilled.v2522 = 0 + 1
spilled.v2523 = spilled.v2522 + 1
spilled.v2524 = spilled.v2523 + 1
spilled.v2525 = spilled.v2524 + 1
spilled.v2526 = spilled.v2525 + 1
spilled.v2527 = 0 + 1
spilled.v2528 = spilled.v2527 + 1
spilled.v2529 = spilled.v2528 + 1
spilled.v2530 = spilled.v2529 + 1
spilled.v2531 = spilled.v2530 + 1
spilled.v2532 = spiral_w64.eq(spilled.v2526, spilled.v2531)
spilled.getv2533 = function()
    if spilled.v2532 then
        return 0
    else
        return 1
    end
end
spilled.v2533 = spilled.getv2533()
spilled.v2536 = spiral_w64.add(spilled.v2521, spilled.v2533, true)
spilled.v2539 = spiral_w64.add(spilled.v2517, spilled.v2536, true)
spilled.v2540 = spiral_w64.add(spilled.v2507, spilled.v2539, true)
spilled.v2541 = 0 + 1
spilled.v2542 = spilled.v2541 + 1
spilled.v2543 = spilled.v2542 + 1
spilled.v2544 = spilled.v2543 + 1
spilled.v2545 = 0 + 1
spilled.v2546 = spilled.v2545 + 1
spilled.v2547 = spilled.v2546 + 1
spilled.v2548 = spilled.v2547 + 1
spilled.v2549 = spiral_w64.eq(spilled.v2544, spilled.v2548)
spilled.getv2550 = function()
    if spilled.v2549 then
        return 0
    else
        return 1
    end
end
spilled.v2550 = spilled.getv2550()
spilled.v2551 = 0 + 1
spilled.v2552 = 0 + 1
spilled.v2553 = spiral_w64.eq(spilled.v2551, spilled.v2552)
spilled.getv2554 = function()
    if spilled.v2553 then
        return 0
    else
        return 1
    end
end
spilled.v2554 = spilled.getv2554()
spilled.v2555 = 0 + 1
spilled.v2556 = spilled.v2555 + 1
spilled.v2557 = spilled.v2556 + 1
spilled.v2558 = spilled.v2557 + 1
spilled.v2559 = spilled.v2558 + 1
spilled.v2560 = 0 + 1
spilled.v2561 = spilled.v2560 + 1
spilled.v2562 = spilled.v2561 + 1
spilled.v2563 = spilled.v2562 + 1
spilled.v2564 = spilled.v2563 + 1
spilled.v2565 = spiral_w64.eq(spilled.v2559, spilled.v2564)
spilled.getv2566 = function()
    if spilled.v2565 then
        return 0
    else
        return 1
    end
end
spilled.v2566 = spilled.getv2566()
spilled.v2569 = spiral_w64.add(spilled.v2554, spilled.v2566, true)
spilled.v2572 = spiral_w64.add(spilled.v2550, spilled.v2569, true)
spilled.v2573 = 0 + 1
spilled.v2574 = spilled.v2573 + 1
spilled.v2575 = spilled.v2574 + 1
spilled.v2576 = spilled.v2575 + 1
spilled.v2577 = 0 + 1
spilled.v2578 = spilled.v2577 + 1
spilled.v2579 = spilled.v2578 + 1
spilled.v2580 = spilled.v2579 + 1
spilled.v2581 = spiral_w64.eq(spilled.v2576, spilled.v2580)
spilled.getv2582 = function()
    if spilled.v2581 then
        return 0
    else
        return 1
    end
end
spilled.v2582 = spilled.getv2582()
spilled.v2583 = 0 + 1
spilled.v2584 = 0 + 1
spilled.v2585 = spiral_w64.eq(spilled.v2583, spilled.v2584)
spilled.getv2586 = function()
    if spilled.v2585 then
        return 0
    else
        return 1
    end
end
spilled.v2586 = spilled.getv2586()
spilled.v2587 = 0 + 1
spilled.v2588 = spilled.v2587 + 1
spilled.v2589 = spilled.v2588 + 1
spilled.v2590 = spilled.v2589 + 1
spilled.v2591 = spilled.v2590 + 1
spilled.v2592 = 0 + 1
spilled.v2593 = spilled.v2592 + 1
spilled.v2594 = spilled.v2593 + 1
spilled.v2595 = spilled.v2594 + 1
spilled.v2596 = spilled.v2595 + 1
spilled.v2597 = spiral_w64.eq(spilled.v2591, spilled.v2596)
spilled.getv2598 = function()
    if spilled.v2597 then
        return 0
    else
        return 1
    end
end
spilled.v2598 = spilled.getv2598()
spilled.v2601 = spiral_w64.add(spilled.v2586, spilled.v2598, true)
spilled.v2604 = spiral_w64.add(spilled.v2582, spilled.v2601, true)
spilled.v2605 = spiral_w64.add(spilled.v2572, spilled.v2604, true)
spilled.v2606 = spiral_w64.add(spilled.v2540, spilled.v2605, true)
spilled.v2607 = 0 + 1
spilled.v2608 = spilled.v2607 + 1
spilled.v2609 = spilled.v2608 + 1
spilled.v2610 = spilled.v2609 + 1
spilled.v2611 = 0 + 1
spilled.v2612 = spilled.v2611 + 1
spilled.v2613 = spilled.v2612 + 1
spilled.v2614 = spilled.v2613 + 1
spilled.v2615 = spiral_w64.eq(spilled.v2610, spilled.v2614)
spilled.getv2616 = function()
    if spilled.v2615 then
        return 0
    else
        return 1
    end
end
spilled.v2616 = spilled.getv2616()
spilled.v2617 = 0 + 1
spilled.v2618 = 0 + 1
spilled.v2619 = spiral_w64.eq(spilled.v2617, spilled.v2618)
spilled.getv2620 = function()
    if spilled.v2619 then
        return 0
    else
        return 1
    end
end
spilled.v2620 = spilled.getv2620()
spilled.v2621 = 0 + 1
spilled.v2622 = spilled.v2621 + 1
spilled.v2623 = spilled.v2622 + 1
spilled.v2624 = spilled.v2623 + 1
spilled.v2625 = spilled.v2624 + 1
spilled.v2626 = 0 + 1
spilled.v2627 = spilled.v2626 + 1
spilled.v2628 = spilled.v2627 + 1
spilled.v2629 = spilled.v2628 + 1
spilled.v2630 = spilled.v2629 + 1
spilled.v2631 = spiral_w64.eq(spilled.v2625, spilled.v2630)
spilled.getv2632 = function()
    if spilled.v2631 then
        return 0
    else
        return 1
    end
end
spilled.v2632 = spilled.getv2632()
spilled.v2633 = spiral_w64.add(spilled.v2617, spilled.v2625, true)
spilled.v2634 = spiral_w64.add(spilled.v2618, spilled.v2630, true)
spilled.v2635 = spiral_w64.add(spilled.v2620, spilled.v2632, true)
spilled.v2636 = spiral_w64.add(spilled.v2610, spilled.v2633, true)
spilled.v2637 = spiral_w64.add(spilled.v2614, spilled.v2634, true)
spilled.v2638 = spiral_w64.add(spilled.v2616, spilled.v2635, true)
spilled.v2639 = spiral_w64.add(spilled.v2637, spilled.v2638, true)
spilled.v2640 = spiral_w64.add(spilled.v2636, spilled.v2639, true)
spilled.v2641 = spiral_w64.add(3, spilled.v2640, true)
spilled.v2642 = 0 + 1
spilled.v2643 = spilled.v2642 + 1
spilled.v2644 = spilled.v2643 + 1
spilled.v2645 = spilled.v2644 + 1
spilled.v2646 = 0 + 1
spilled.v2647 = spilled.v2646 + 1
spilled.v2648 = spilled.v2647 + 1
spilled.v2649 = spilled.v2648 + 1
spilled.v2650 = spiral_w64.eq(spilled.v2645, spilled.v2649)
spilled.getv2651 = function()
    if spilled.v2650 then
        return 0
    else
        return 1
    end
end
spilled.v2651 = spilled.getv2651()
spilled.v2652 = 0 + 1
spilled.v2653 = 0 + 1
spilled.v2654 = spiral_w64.eq(spilled.v2652, spilled.v2653)
spilled.getv2655 = function()
    if spilled.v2654 then
        return 0
    else
        return 1
    end
end
spilled.v2655 = spilled.getv2655()
spilled.v2656 = 0 + 1
spilled.v2657 = spilled.v2656 + 1
spilled.v2658 = spilled.v2657 + 1
spilled.v2659 = spilled.v2658 + 1
spilled.v2660 = spilled.v2659 + 1
spilled.v2661 = 0 + 1
spilled.v2662 = spilled.v2661 + 1
spilled.v2663 = spilled.v2662 + 1
spilled.v2664 = spilled.v2663 + 1
spilled.v2665 = spilled.v2664 + 1
spilled.v2666 = spiral_w64.eq(spilled.v2660, spilled.v2665)
spilled.getv2667 = function()
    if spilled.v2666 then
        return 0
    else
        return 1
    end
end
spilled.v2667 = spilled.getv2667()
spilled.v2668 = spiral_w64.add(spilled.v2652, spilled.v2660, true)
spilled.v2669 = spiral_w64.add(spilled.v2653, spilled.v2665, true)
spilled.v2670 = spiral_w64.add(spilled.v2655, spilled.v2667, true)
spilled.v2671 = spiral_w64.add(spilled.v2645, spilled.v2668, true)
spilled.v2672 = spiral_w64.add(spilled.v2649, spilled.v2669, true)
spilled.v2673 = spiral_w64.add(spilled.v2651, spilled.v2670, true)
spilled.v2674 = spiral_w64.add(spilled.v2672, spilled.v2673, true)
spilled.v2675 = spiral_w64.add(spilled.v2671, spilled.v2674, true)
spilled.v2676 = spiral_w64.add(3, spilled.v2675, true)
spilled.v2677 = spiral_w64.eq(spilled.v2641, spilled.v2676)
spilled.getv2714 = function()
    if spilled.v2677 then
        local v2678 = 0 + 1
        local v2679 = v2678 + 1
        local v2680 = v2679 + 1
        local v2681 = v2680 + 1
        local v2682 = 0 + 1
        local v2683 = v2682 + 1
        local v2684 = v2683 + 1
        local v2685 = v2684 + 1
        local v2686 = spiral_w64.eq(v2681, v2685)
        local getv2687 = function()
            if v2686 then
                return 0
            else
                return 1
            end
        end
        local v2687 = getv2687()
        local v2688 = 0 + 1
        local v2689 = 0 + 1
        local v2690 = spiral_w64.eq(v2688, v2689)
        local getv2691 = function()
            if v2690 then
                return 0
            else
                return 1
            end
        end
        local v2691 = getv2691()
        local v2692 = 0 + 1
        local v2693 = v2692 + 1
        local v2694 = v2693 + 1
        local v2695 = v2694 + 1
        local v2696 = v2695 + 1
        local v2697 = 0 + 1
        local v2698 = v2697 + 1
        local v2699 = v2698 + 1
        local v2700 = v2699 + 1
        local v2701 = v2700 + 1
        local v2702 = spiral_w64.eq(v2696, v2701)
        local getv2703 = function()
            if v2702 then
                return 0
            else
                return 1
            end
        end
        local v2703 = getv2703()
        local v2704 = spiral_w64.add(v2688, v2696, true)
        local v2705 = spiral_w64.add(v2689, v2701, true)
        local v2706 = spiral_w64.add(v2691, v2703, true)
        local v2707 = spiral_w64.add(v2681, v2704, true)
        local v2708 = spiral_w64.add(v2685, v2705, true)
        local v2709 = spiral_w64.add(v2687, v2706, true)
        local v2710 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        return Us0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v2707, v2708, v2709, v2710)
    else
        local v2712 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        return Us0_TypedFxHashedStatementChecksumValidationRejected(spilled.v2641, spilled.v2676, v2712)
    end
end
spilled.v2714 = spilled.getv2714()
spilled.getv2733 = function()
    if spilled.v2714 ~= nil and spilled.v2714.tag == "Us0_TypedFxHashedStatementChecksumValidationAccepted" then
        local v2718 = spilled.v2714._1
        local v2719 = spilled.v2714._2
        local v2720 = spilled.v2714._3
        local v2721 = spilled.v2714._4
        local v2722 = spilled.v2714._5
        local v2723 = spilled.v2714._6
        return { [1]=1, [2]=0, [3]=v2722 }
    elseif spilled.v2714 ~= nil and spilled.v2714.tag == "Us0_TypedFxHashedStatementChecksumValidationRejected" then
        local v2715 = spilled.v2714._1
        local v2716 = spilled.v2714._2
        local v2717 = spilled.v2714._3
        return { [1]=0, [2]=1, [3]=0 }
    end
end
spilled.v2733, spilled.v2734, spilled.v2741 = (table.unpack or unpack)(spilled.getv2733())
spilled.v2742 = 0 + 1
spilled.v2743 = spilled.v2742 + 1
spilled.v2744 = spilled.v2743 + 1
spilled.v2745 = spilled.v2744 + 1
spilled.v2746 = 0 + 1
spilled.v2747 = spilled.v2746 + 1
spilled.v2748 = spilled.v2747 + 1
spilled.v2749 = spilled.v2748 + 1
spilled.v2750 = spiral_w64.eq(spilled.v2745, spilled.v2749)
spilled.getv2751 = function()
    if spilled.v2750 then
        return 0
    else
        return 1
    end
end
spilled.v2751 = spilled.getv2751()
spilled.v2752 = 0 + 1
spilled.v2753 = 0 + 1
spilled.v2754 = spiral_w64.eq(spilled.v2752, spilled.v2753)
spilled.getv2755 = function()
    if spilled.v2754 then
        return 0
    else
        return 1
    end
end
spilled.v2755 = spilled.getv2755()
spilled.v2756 = 0 + 1
spilled.v2757 = spilled.v2756 + 1
spilled.v2758 = spilled.v2757 + 1
spilled.v2759 = spilled.v2758 + 1
spilled.v2760 = spilled.v2759 + 1
spilled.v2761 = 0 + 1
spilled.v2762 = spilled.v2761 + 1
spilled.v2763 = spilled.v2762 + 1
spilled.v2764 = spilled.v2763 + 1
spilled.v2765 = spilled.v2764 + 1
spilled.v2766 = spiral_w64.eq(spilled.v2760, spilled.v2765)
spilled.getv2767 = function()
    if spilled.v2766 then
        return 0
    else
        return 1
    end
end
spilled.v2767 = spilled.getv2767()
spilled.v2770 = spiral_w64.add(spilled.v2755, spilled.v2767, true)
spilled.v2773 = spiral_w64.add(spilled.v2751, spilled.v2770, true)
spilled.v2774 = 0 + 1
spilled.v2775 = spilled.v2774 + 1
spilled.v2776 = spilled.v2775 + 1
spilled.v2777 = spilled.v2776 + 1
spilled.v2778 = 0 + 1
spilled.v2779 = spilled.v2778 + 1
spilled.v2780 = spilled.v2779 + 1
spilled.v2781 = spilled.v2780 + 1
spilled.v2782 = spiral_w64.eq(spilled.v2777, spilled.v2781)
spilled.getv2783 = function()
    if spilled.v2782 then
        return 0
    else
        return 1
    end
end
spilled.v2783 = spilled.getv2783()
spilled.v2784 = 0 + 1
spilled.v2785 = 0 + 1
spilled.v2786 = spiral_w64.eq(spilled.v2784, spilled.v2785)
spilled.getv2787 = function()
    if spilled.v2786 then
        return 0
    else
        return 1
    end
end
spilled.v2787 = spilled.getv2787()
spilled.v2788 = 0 + 1
spilled.v2789 = spilled.v2788 + 1
spilled.v2790 = spilled.v2789 + 1
spilled.v2791 = spilled.v2790 + 1
spilled.v2792 = spilled.v2791 + 1
spilled.v2793 = 0 + 1
spilled.v2794 = spilled.v2793 + 1
spilled.v2795 = spilled.v2794 + 1
spilled.v2796 = spilled.v2795 + 1
spilled.v2797 = spilled.v2796 + 1
spilled.v2798 = spiral_w64.eq(spilled.v2792, spilled.v2797)
spilled.getv2799 = function()
    if spilled.v2798 then
        return 0
    else
        return 1
    end
end
spilled.v2799 = spilled.getv2799()
spilled.v2802 = spiral_w64.add(spilled.v2787, spilled.v2799, true)
spilled.v2805 = spiral_w64.add(spilled.v2783, spilled.v2802, true)
spilled.v2806 = spiral_w64.add(spilled.v2773, spilled.v2805, true)
spilled.v2807 = spiral_w64.add(spilled.v2741, spilled.v2734, true)
spilled.v2808 = spiral_w64.add(spilled.v2806, spilled.v2807, true)
spilled.v2809 = spiral_w64.add(spilled.v2606, spilled.v2808, true)
spilled.v2810 = spiral_w64.eq(spilled.v2733, 1)
spilled.v2811 = spiral_w64.eq(spilled.v2809, 0)
spilled.v2812 = (spilled.v2810) and (spilled.v2811)
if spilled.v2812 then
else
    _G.error("typed-FX-statement-indexed-durable-commit-runtime-mismatch")
end
spilled.v2813 = 0 + 1
spilled.v2814 = spilled.v2813 + 1
spilled.v2815 = spilled.v2814 + 1
spilled.v2816 = spilled.v2815 + 1
spilled.v2817 = 0 + 1
spilled.v2818 = spilled.v2817 + 1
spilled.v2819 = spilled.v2818 + 1
spilled.v2820 = spilled.v2819 + 1
spilled.v2821 = spiral_w64.eq(spilled.v2816, spilled.v2820)
spilled.getv2822 = function()
    if spilled.v2821 then
        return 0
    else
        return 1
    end
end
spilled.v2822 = spilled.getv2822()
spilled.v2823 = 0 + 1
spilled.v2824 = 0 + 1
spilled.v2825 = spiral_w64.eq(spilled.v2823, spilled.v2824)
spilled.getv2826 = function()
    if spilled.v2825 then
        return 0
    else
        return 1
    end
end
spilled.v2826 = spilled.getv2826()
spilled.v2827 = 0 + 1
spilled.v2828 = spilled.v2827 + 1
spilled.v2829 = spilled.v2828 + 1
spilled.v2830 = spilled.v2829 + 1
spilled.v2831 = spilled.v2830 + 1
spilled.v2832 = 0 + 1
spilled.v2833 = spilled.v2832 + 1
spilled.v2834 = spilled.v2833 + 1
spilled.v2835 = spilled.v2834 + 1
spilled.v2836 = spilled.v2835 + 1
spilled.v2837 = spiral_w64.eq(spilled.v2831, spilled.v2836)
spilled.getv2838 = function()
    if spilled.v2837 then
        return 0
    else
        return 1
    end
end
spilled.v2838 = spilled.getv2838()
spilled.v2839 = spiral_w64.add(spilled.v2823, spilled.v2831, true)
spilled.v2840 = spiral_w64.add(spilled.v2824, spilled.v2836, true)
spilled.v2841 = spiral_w64.add(spilled.v2826, spilled.v2838, true)
spilled.v2842 = spiral_w64.add(spilled.v2816, spilled.v2839, true)
spilled.v2843 = spiral_w64.add(spilled.v2820, spilled.v2840, true)
spilled.v2844 = spiral_w64.add(spilled.v2822, spilled.v2841, true)
spilled.v2845 = 0 + 1
spilled.v2846 = spilled.v2845 + 1
spilled.v2847 = spilled.v2846 + 1
spilled.v2848 = spilled.v2847 + 1
spilled.v2849 = 0 + 1
spilled.v2850 = spilled.v2849 + 1
spilled.v2851 = spilled.v2850 + 1
spilled.v2852 = spilled.v2851 + 1
spilled.v2853 = spiral_w64.eq(spilled.v2848, spilled.v2852)
spilled.getv2854 = function()
    if spilled.v2853 then
        return 0
    else
        return 1
    end
end
spilled.v2854 = spilled.getv2854()
spilled.v2855 = 0 + 1
spilled.v2856 = 0 + 1
spilled.v2857 = spiral_w64.eq(spilled.v2855, spilled.v2856)
spilled.getv2858 = function()
    if spilled.v2857 then
        return 0
    else
        return 1
    end
end
spilled.v2858 = spilled.getv2858()
spilled.v2859 = 0 + 1
spilled.v2860 = spilled.v2859 + 1
spilled.v2861 = spilled.v2860 + 1
spilled.v2862 = spilled.v2861 + 1
spilled.v2863 = spilled.v2862 + 1
spilled.v2864 = 0 + 1
spilled.v2865 = spilled.v2864 + 1
spilled.v2866 = spilled.v2865 + 1
spilled.v2867 = spilled.v2866 + 1
spilled.v2868 = spilled.v2867 + 1
spilled.v2869 = spiral_w64.eq(spilled.v2863, spilled.v2868)
spilled.getv2870 = function()
    if spilled.v2869 then
        return 0
    else
        return 1
    end
end
spilled.v2870 = spilled.getv2870()
spilled.v2871 = spiral_w64.add(spilled.v2855, spilled.v2863, true)
spilled.v2872 = spiral_w64.add(spilled.v2856, spilled.v2868, true)
spilled.v2873 = spiral_w64.add(spilled.v2858, spilled.v2870, true)
spilled.v2874 = spiral_w64.add(spilled.v2848, spilled.v2871, true)
spilled.v2875 = spiral_w64.add(spilled.v2852, spilled.v2872, true)
spilled.v2876 = spiral_w64.add(spilled.v2854, spilled.v2873, true)
spilled.v2877 = 0 + 1
spilled.v2878 = spilled.v2877 + 1
spilled.v2879 = spilled.v2878 + 1
spilled.v2880 = spilled.v2879 + 1
spilled.v2881 = 0 + 1
spilled.v2882 = spilled.v2881 + 1
spilled.v2883 = spilled.v2882 + 1
spilled.v2884 = spilled.v2883 + 1
spilled.v2885 = spiral_w64.eq(spilled.v2880, spilled.v2884)
spilled.getv2886 = function()
    if spilled.v2885 then
        return 0
    else
        return 1
    end
end
spilled.v2886 = spilled.getv2886()
spilled.v2887 = 0 + 1
spilled.v2888 = 0 + 1
spilled.v2889 = spiral_w64.eq(spilled.v2887, spilled.v2888)
spilled.getv2890 = function()
    if spilled.v2889 then
        return 0
    else
        return 1
    end
end
spilled.v2890 = spilled.getv2890()
spilled.v2891 = 0 + 1
spilled.v2892 = spilled.v2891 + 1
spilled.v2893 = spilled.v2892 + 1
spilled.v2894 = spilled.v2893 + 1
spilled.v2895 = spilled.v2894 + 1
spilled.v2896 = 0 + 1
spilled.v2897 = spilled.v2896 + 1
spilled.v2898 = spilled.v2897 + 1
spilled.v2899 = spilled.v2898 + 1
spilled.v2900 = spilled.v2899 + 1
spilled.v2901 = spiral_w64.eq(spilled.v2895, spilled.v2900)
spilled.getv2902 = function()
    if spilled.v2901 then
        return 0
    else
        return 1
    end
end
spilled.v2902 = spilled.getv2902()
spilled.v2903 = spiral_w64.add(spilled.v2887, spilled.v2895, true)
spilled.v2904 = spiral_w64.add(spilled.v2888, spilled.v2900, true)
spilled.v2905 = spiral_w64.add(spilled.v2890, spilled.v2902, true)
spilled.v2906 = spiral_w64.add(spilled.v2880, spilled.v2903, true)
spilled.v2907 = spiral_w64.add(spilled.v2884, spilled.v2904, true)
spilled.v2908 = spiral_w64.add(spilled.v2886, spilled.v2905, true)
spilled.v2909 = 0 + 1
spilled.v2910 = spilled.v2909 + 1
spilled.v2911 = spilled.v2910 + 1
spilled.v2912 = spilled.v2911 + 1
spilled.v2913 = 0 + 1
spilled.v2914 = spilled.v2913 + 1
spilled.v2915 = spilled.v2914 + 1
spilled.v2916 = spilled.v2915 + 1
spilled.v2917 = spiral_w64.eq(spilled.v2912, spilled.v2916)
spilled.getv2918 = function()
    if spilled.v2917 then
        return 0
    else
        return 1
    end
end
spilled.v2918 = spilled.getv2918()
spilled.v2919 = 0 + 1
spilled.v2920 = 0 + 1
spilled.v2921 = spiral_w64.eq(spilled.v2919, spilled.v2920)
spilled.getv2922 = function()
    if spilled.v2921 then
        return 0
    else
        return 1
    end
end
spilled.v2922 = spilled.getv2922()
spilled.v2923 = 0 + 1
spilled.v2924 = spilled.v2923 + 1
spilled.v2925 = spilled.v2924 + 1
spilled.v2926 = spilled.v2925 + 1
spilled.v2927 = spilled.v2926 + 1
spilled.v2928 = 0 + 1
spilled.v2929 = spilled.v2928 + 1
spilled.v2930 = spilled.v2929 + 1
spilled.v2931 = spilled.v2930 + 1
spilled.v2932 = spilled.v2931 + 1
spilled.v2933 = spiral_w64.eq(spilled.v2927, spilled.v2932)
spilled.getv2934 = function()
    if spilled.v2933 then
        return 0
    else
        return 1
    end
end
spilled.v2934 = spilled.getv2934()
spilled.v2935 = spiral_w64.add(spilled.v2919, spilled.v2927, true)
spilled.v2936 = spiral_w64.add(spilled.v2920, spilled.v2932, true)
spilled.v2937 = spiral_w64.add(spilled.v2922, spilled.v2934, true)
spilled.v2938 = spiral_w64.add(spilled.v2912, spilled.v2935, true)
spilled.v2939 = spiral_w64.add(spilled.v2916, spilled.v2936, true)
spilled.v2940 = spiral_w64.add(spilled.v2918, spilled.v2937, true)
spilled.v2941 = spiral_w64.add(spilled.v2906, spilled.v2938, true)
spilled.v2942 = spiral_w64.add(spilled.v2907, spilled.v2939, true)
spilled.v2943 = spiral_w64.add(spilled.v2908, spilled.v2940, true)
spilled.v2944 = spiral_w64.add(spilled.v2874, spilled.v2941, true)
spilled.v2945 = spiral_w64.add(spilled.v2875, spilled.v2942, true)
spilled.v2946 = spiral_w64.add(spilled.v2876, spilled.v2943, true)
spilled.v2947 = spiral_w64.add(spilled.v2842, spilled.v2944, true)
spilled.v2948 = spiral_w64.add(spilled.v2843, spilled.v2945, true)
spilled.v2949 = spiral_w64.add(spilled.v2844, spilled.v2946, true)
spilled.v2950 = spiral_w64.eq(spilled.v2947, 40)
spilled.v2951 = spiral_w64.eq(spilled.v2948, 40)
spilled.v2952 = spiral_w64.eq(spilled.v2949, 0)
spilled.v2953 = (spilled.v2950) and (spilled.v2951)
spilled.v2954 = (spilled.v2953) and (spilled.v2952)
if spilled.v2954 then
else
    _G.error("typed-FX-hashed-statement-event-store-decision-runtime-mismatch")
end
spilled.v2955 = 0 + 1
spilled.v2956 = spilled.v2955 + 1
spilled.v2957 = spilled.v2956 + 1
spilled.v2958 = spilled.v2957 + 1
spilled.v2959 = 0 + 1
spilled.v2960 = spilled.v2959 + 1
spilled.v2961 = spilled.v2960 + 1
spilled.v2962 = spilled.v2961 + 1
spilled.v2963 = spiral_w64.eq(spilled.v2958, spilled.v2962)
spilled.getv2964 = function()
    if spilled.v2963 then
        return 0
    else
        return 1
    end
end
spilled.v2964 = spilled.getv2964()
spilled.v2965 = 0 + 1
spilled.v2966 = 0 + 1
spilled.v2967 = spiral_w64.eq(spilled.v2965, spilled.v2966)
spilled.getv2968 = function()
    if spilled.v2967 then
        return 0
    else
        return 1
    end
end
spilled.v2968 = spilled.getv2968()
spilled.v2969 = 0 + 1
spilled.v2970 = spilled.v2969 + 1
spilled.v2971 = spilled.v2970 + 1
spilled.v2972 = spilled.v2971 + 1
spilled.v2973 = spilled.v2972 + 1
spilled.v2974 = 0 + 1
spilled.v2975 = spilled.v2974 + 1
spilled.v2976 = spilled.v2975 + 1
spilled.v2977 = spilled.v2976 + 1
spilled.v2978 = spilled.v2977 + 1
spilled.v2979 = spiral_w64.eq(spilled.v2973, spilled.v2978)
spilled.getv2980 = function()
    if spilled.v2979 then
        return 0
    else
        return 1
    end
end
spilled.v2980 = spilled.getv2980()
spilled.v2983 = spiral_w64.add(spilled.v2968, spilled.v2980, true)
spilled.v2986 = spiral_w64.add(spilled.v2964, spilled.v2983, true)
spilled.v2987 = 0 + 1
spilled.v2988 = spilled.v2987 + 1
spilled.v2989 = spilled.v2988 + 1
spilled.v2990 = spilled.v2989 + 1
spilled.v2991 = 0 + 1
spilled.v2992 = spilled.v2991 + 1
spilled.v2993 = spilled.v2992 + 1
spilled.v2994 = spilled.v2993 + 1
spilled.v2995 = spiral_w64.eq(spilled.v2990, spilled.v2994)
spilled.getv2996 = function()
    if spilled.v2995 then
        return 0
    else
        return 1
    end
end
spilled.v2996 = spilled.getv2996()
spilled.v2997 = 0 + 1
spilled.v2998 = 0 + 1
spilled.v2999 = spiral_w64.eq(spilled.v2997, spilled.v2998)
spilled.getv3000 = function()
    if spilled.v2999 then
        return 0
    else
        return 1
    end
end
spilled.v3000 = spilled.getv3000()
spilled.v3001 = 0 + 1
spilled.v3002 = spilled.v3001 + 1
spilled.v3003 = spilled.v3002 + 1
spilled.v3004 = spilled.v3003 + 1
spilled.v3005 = spilled.v3004 + 1
spilled.v3006 = 0 + 1
spilled.v3007 = spilled.v3006 + 1
spilled.v3008 = spilled.v3007 + 1
spilled.v3009 = spilled.v3008 + 1
spilled.v3010 = spilled.v3009 + 1
spilled.v3011 = spiral_w64.eq(spilled.v3005, spilled.v3010)
spilled.getv3012 = function()
    if spilled.v3011 then
        return 0
    else
        return 1
    end
end
spilled.v3012 = spilled.getv3012()
spilled.v3015 = spiral_w64.add(spilled.v3000, spilled.v3012, true)
spilled.v3018 = spiral_w64.add(spilled.v2996, spilled.v3015, true)
spilled.v3021 = spiral_w64.add(spilled.v3018, spilled.v2986, true)
spilled.v3022 = 0 + 1
spilled.v3023 = spilled.v3022 + 1
spilled.v3024 = spilled.v3023 + 1
spilled.v3025 = spilled.v3024 + 1
spilled.v3026 = 0 + 1
spilled.v3027 = spilled.v3026 + 1
spilled.v3028 = spilled.v3027 + 1
spilled.v3029 = spilled.v3028 + 1
spilled.v3030 = spiral_w64.eq(spilled.v3025, spilled.v3029)
spilled.getv3031 = function()
    if spilled.v3030 then
        return 0
    else
        return 1
    end
end
spilled.v3031 = spilled.getv3031()
spilled.v3032 = 0 + 1
spilled.v3033 = 0 + 1
spilled.v3034 = spiral_w64.eq(spilled.v3032, spilled.v3033)
spilled.getv3035 = function()
    if spilled.v3034 then
        return 0
    else
        return 1
    end
end
spilled.v3035 = spilled.getv3035()
spilled.v3036 = 0 + 1
spilled.v3037 = spilled.v3036 + 1
spilled.v3038 = spilled.v3037 + 1
spilled.v3039 = spilled.v3038 + 1
spilled.v3040 = spilled.v3039 + 1
spilled.v3041 = 0 + 1
spilled.v3042 = spilled.v3041 + 1
spilled.v3043 = spilled.v3042 + 1
spilled.v3044 = spilled.v3043 + 1
spilled.v3045 = spilled.v3044 + 1
spilled.v3046 = spiral_w64.eq(spilled.v3040, spilled.v3045)
spilled.getv3047 = function()
    if spilled.v3046 then
        return 0
    else
        return 1
    end
end
spilled.v3047 = spilled.getv3047()
spilled.v3050 = spiral_w64.add(spilled.v3035, spilled.v3047, true)
spilled.v3053 = spiral_w64.add(spilled.v3031, spilled.v3050, true)
spilled.v3054 = 0 + 1
spilled.v3055 = spilled.v3054 + 1
spilled.v3056 = spilled.v3055 + 1
spilled.v3057 = spilled.v3056 + 1
spilled.v3058 = 0 + 1
spilled.v3059 = spilled.v3058 + 1
spilled.v3060 = spilled.v3059 + 1
spilled.v3061 = spilled.v3060 + 1
spilled.v3062 = spiral_w64.eq(spilled.v3057, spilled.v3061)
spilled.getv3063 = function()
    if spilled.v3062 then
        return 0
    else
        return 1
    end
end
spilled.v3063 = spilled.getv3063()
spilled.v3064 = 0 + 1
spilled.v3065 = 0 + 1
spilled.v3066 = spiral_w64.eq(spilled.v3064, spilled.v3065)
spilled.getv3067 = function()
    if spilled.v3066 then
        return 0
    else
        return 1
    end
end
spilled.v3067 = spilled.getv3067()
spilled.v3068 = 0 + 1
spilled.v3069 = spilled.v3068 + 1
spilled.v3070 = spilled.v3069 + 1
spilled.v3071 = spilled.v3070 + 1
spilled.v3072 = spilled.v3071 + 1
spilled.v3073 = 0 + 1
spilled.v3074 = spilled.v3073 + 1
spilled.v3075 = spilled.v3074 + 1
spilled.v3076 = spilled.v3075 + 1
spilled.v3077 = spilled.v3076 + 1
spilled.v3078 = spiral_w64.eq(spilled.v3072, spilled.v3077)
spilled.getv3079 = function()
    if spilled.v3078 then
        return 0
    else
        return 1
    end
end
spilled.v3079 = spilled.getv3079()
spilled.v3082 = spiral_w64.add(spilled.v3067, spilled.v3079, true)
spilled.v3085 = spiral_w64.add(spilled.v3063, spilled.v3082, true)
spilled.v3088 = spiral_w64.add(spilled.v3085, spilled.v3053, true)
spilled.v3089 = spiral_w64.add(spilled.v3021, spilled.v3088, true)
spilled.v3090 = spiral_w64.eq(spilled.v3089, 0)
if spilled.v3090 then
else
    _G.error("typed-FX-hashed-statement-proven-retry-runtime-mismatch")
end
spilled.v3091 = 0 + 1
spilled.v3092 = spilled.v3091 + 1
spilled.v3093 = spilled.v3092 + 1
spilled.v3094 = spilled.v3093 + 1
spilled.v3095 = 0 + 1
spilled.v3096 = spilled.v3095 + 1
spilled.v3097 = spilled.v3096 + 1
spilled.v3098 = spilled.v3097 + 1
spilled.v3099 = spiral_w64.eq(spilled.v3094, spilled.v3098)
spilled.getv3100 = function()
    if spilled.v3099 then
        return 0
    else
        return 1
    end
end
spilled.v3100 = spilled.getv3100()
spilled.v3101 = 0 + 1
spilled.v3102 = 0 + 1
spilled.v3103 = spiral_w64.eq(spilled.v3101, spilled.v3102)
spilled.getv3104 = function()
    if spilled.v3103 then
        return 0
    else
        return 1
    end
end
spilled.v3104 = spilled.getv3104()
spilled.v3105 = 0 + 1
spilled.v3106 = spilled.v3105 + 1
spilled.v3107 = spilled.v3106 + 1
spilled.v3108 = spilled.v3107 + 1
spilled.v3109 = spilled.v3108 + 1
spilled.v3110 = 0 + 1
spilled.v3111 = spilled.v3110 + 1
spilled.v3112 = spilled.v3111 + 1
spilled.v3113 = spilled.v3112 + 1
spilled.v3114 = spilled.v3113 + 1
spilled.v3115 = spiral_w64.eq(spilled.v3109, spilled.v3114)
spilled.getv3116 = function()
    if spilled.v3115 then
        return 0
    else
        return 1
    end
end
spilled.v3116 = spilled.getv3116()
spilled.v3117 = spiral_w64.add(spilled.v3101, spilled.v3109, true)
spilled.v3118 = spiral_w64.add(spilled.v3102, spilled.v3114, true)
spilled.v3119 = spiral_w64.add(spilled.v3104, spilled.v3116, true)
spilled.v3120 = spiral_w64.add(spilled.v3094, spilled.v3117, true)
spilled.v3121 = spiral_w64.add(spilled.v3098, spilled.v3118, true)
spilled.v3122 = spiral_w64.add(spilled.v3100, spilled.v3119, true)
spilled.v3123 = 0 + 1
spilled.v3124 = spilled.v3123 + 1
spilled.v3125 = spilled.v3124 + 1
spilled.v3126 = spilled.v3125 + 1
spilled.v3127 = 0 + 1
spilled.v3128 = spilled.v3127 + 1
spilled.v3129 = spilled.v3128 + 1
spilled.v3130 = spilled.v3129 + 1
spilled.v3131 = spiral_w64.eq(spilled.v3126, spilled.v3130)
spilled.getv3132 = function()
    if spilled.v3131 then
        return 0
    else
        return 1
    end
end
spilled.v3132 = spilled.getv3132()
spilled.v3133 = 0 + 1
spilled.v3134 = 0 + 1
spilled.v3135 = spiral_w64.eq(spilled.v3133, spilled.v3134)
spilled.getv3136 = function()
    if spilled.v3135 then
        return 0
    else
        return 1
    end
end
spilled.v3136 = spilled.getv3136()
spilled.v3137 = 0 + 1
spilled.v3138 = spilled.v3137 + 1
spilled.v3139 = spilled.v3138 + 1
spilled.v3140 = spilled.v3139 + 1
spilled.v3141 = spilled.v3140 + 1
spilled.v3142 = 0 + 1
spilled.v3143 = spilled.v3142 + 1
spilled.v3144 = spilled.v3143 + 1
spilled.v3145 = spilled.v3144 + 1
spilled.v3146 = spilled.v3145 + 1
spilled.v3147 = spiral_w64.eq(spilled.v3141, spilled.v3146)
spilled.getv3148 = function()
    if spilled.v3147 then
        return 0
    else
        return 1
    end
end
spilled.v3148 = spilled.getv3148()
spilled.v3149 = spiral_w64.add(spilled.v3133, spilled.v3141, true)
spilled.v3150 = spiral_w64.add(spilled.v3134, spilled.v3146, true)
spilled.v3151 = spiral_w64.add(spilled.v3136, spilled.v3148, true)
spilled.v3152 = spiral_w64.add(spilled.v3126, spilled.v3149, true)
spilled.v3153 = spiral_w64.add(spilled.v3130, spilled.v3150, true)
spilled.v3154 = spiral_w64.add(spilled.v3132, spilled.v3151, true)
spilled.v3155 = spiral_w64.add(spilled.v3152, spilled.v3120, true)
spilled.v3156 = spiral_w64.add(spilled.v3153, spilled.v3121, true)
spilled.v3157 = spiral_w64.add(spilled.v3154, spilled.v3122, true)
spilled.v3158 = spiral_w64.eq(spilled.v3155, 20)
spilled.v3159 = spiral_w64.eq(spilled.v3156, 20)
spilled.v3160 = spiral_w64.eq(spilled.v3157, 0)
spilled.v3161 = (spilled.v3158) and (spilled.v3159)
spilled.v3162 = (spilled.v3161) and (spilled.v3160)
if spilled.v3162 then
else
    _G.error("typed-FX-hashed-statement-history-enumeration-runtime-mismatch")
end
spilled.v3163 = 0 + 1
spilled.v3164 = spilled.v3163 + 1
spilled.v3165 = spilled.v3164 + 1
spilled.v3166 = spilled.v3165 + 1
spilled.v3167 = 0 + 1
spilled.v3168 = spilled.v3167 + 1
spilled.v3169 = spilled.v3168 + 1
spilled.v3170 = spilled.v3169 + 1
spilled.v3171 = spiral_w64.eq(spilled.v3166, spilled.v3170)
spilled.getv3172 = function()
    if spilled.v3171 then
        return 0
    else
        return 1
    end
end
spilled.v3172 = spilled.getv3172()
spilled.v3173 = 0 + 1
spilled.v3174 = 0 + 1
spilled.v3175 = spiral_w64.eq(spilled.v3173, spilled.v3174)
spilled.getv3176 = function()
    if spilled.v3175 then
        return 0
    else
        return 1
    end
end
spilled.v3176 = spilled.getv3176()
spilled.v3177 = 0 + 1
spilled.v3178 = spilled.v3177 + 1
spilled.v3179 = spilled.v3178 + 1
spilled.v3180 = spilled.v3179 + 1
spilled.v3181 = spilled.v3180 + 1
spilled.v3182 = 0 + 1
spilled.v3183 = spilled.v3182 + 1
spilled.v3184 = spilled.v3183 + 1
spilled.v3185 = spilled.v3184 + 1
spilled.v3186 = spilled.v3185 + 1
spilled.v3187 = spiral_w64.eq(spilled.v3181, spilled.v3186)
spilled.getv3188 = function()
    if spilled.v3187 then
        return 0
    else
        return 1
    end
end
spilled.v3188 = spilled.getv3188()
spilled.v3189 = spiral_w64.add(spilled.v3173, spilled.v3181, true)
spilled.v3190 = spiral_w64.add(spilled.v3174, spilled.v3186, true)
spilled.v3191 = spiral_w64.add(spilled.v3176, spilled.v3188, true)
spilled.v3192 = spiral_w64.add(spilled.v3166, spilled.v3189, true)
spilled.v3193 = spiral_w64.add(spilled.v3170, spilled.v3190, true)
spilled.v3194 = spiral_w64.add(spilled.v3172, spilled.v3191, true)
spilled.v3195 = spiral_w64.eq(spilled.v3192, 10)
spilled.v3196 = spiral_w64.eq(spilled.v3193, 10)
spilled.v3197 = spiral_w64.eq(spilled.v3194, 0)
spilled.v3198 = (spilled.v3195) and (spilled.v3196)
spilled.v3199 = (spilled.v3198) and (spilled.v3197)
if spilled.v3199 then
else
    _G.error("typed-FX-hashed-statement-history-index-lookup-runtime-mismatch")
end
spilled.v3200 = 0 + 1
spilled.v3201 = spilled.v3200 + 1
spilled.v3202 = spilled.v3201 + 1
spilled.v3203 = spilled.v3202 + 1
spilled.v3204 = 0 + 1
spilled.v3205 = spilled.v3204 + 1
spilled.v3206 = spilled.v3205 + 1
spilled.v3207 = spilled.v3206 + 1
spilled.v3208 = spiral_w64.eq(spilled.v3203, spilled.v3207)
spilled.getv3209 = function()
    if spilled.v3208 then
        return 0
    else
        return 1
    end
end
spilled.v3209 = spilled.getv3209()
spilled.v3210 = 0 + 1
spilled.v3211 = 0 + 1
spilled.v3212 = spiral_w64.eq(spilled.v3210, spilled.v3211)
spilled.getv3213 = function()
    if spilled.v3212 then
        return 0
    else
        return 1
    end
end
spilled.v3213 = spilled.getv3213()
spilled.v3214 = 0 + 1
spilled.v3215 = spilled.v3214 + 1
spilled.v3216 = spilled.v3215 + 1
spilled.v3217 = spilled.v3216 + 1
spilled.v3218 = spilled.v3217 + 1
spilled.v3219 = 0 + 1
spilled.v3220 = spilled.v3219 + 1
spilled.v3221 = spilled.v3220 + 1
spilled.v3222 = spilled.v3221 + 1
spilled.v3223 = spilled.v3222 + 1
spilled.v3224 = spiral_w64.eq(spilled.v3218, spilled.v3223)
spilled.getv3225 = function()
    if spilled.v3224 then
        return 0
    else
        return 1
    end
end
spilled.v3225 = spilled.getv3225()
spilled.v3226 = spiral_w64.add(spilled.v3210, spilled.v3218, true)
spilled.v3227 = spiral_w64.add(spilled.v3211, spilled.v3223, true)
spilled.v3228 = spiral_w64.add(spilled.v3213, spilled.v3225, true)
spilled.v3229 = spiral_w64.add(spilled.v3203, spilled.v3226, true)
spilled.v3230 = spiral_w64.add(spilled.v3207, spilled.v3227, true)
spilled.v3231 = spiral_w64.add(spilled.v3209, spilled.v3228, true)
spilled.v3232 = 0 + 1
spilled.v3233 = spilled.v3232 + 1
spilled.v3234 = spilled.v3233 + 1
spilled.v3235 = spilled.v3234 + 1
spilled.v3236 = 0 + 1
spilled.v3237 = spilled.v3236 + 1
spilled.v3238 = spilled.v3237 + 1
spilled.v3239 = spilled.v3238 + 1
spilled.v3240 = spiral_w64.eq(spilled.v3235, spilled.v3239)
spilled.getv3241 = function()
    if spilled.v3240 then
        return 0
    else
        return 1
    end
end
spilled.v3241 = spilled.getv3241()
spilled.v3242 = 0 + 1
spilled.v3243 = 0 + 1
spilled.v3244 = spiral_w64.eq(spilled.v3242, spilled.v3243)
spilled.getv3245 = function()
    if spilled.v3244 then
        return 0
    else
        return 1
    end
end
spilled.v3245 = spilled.getv3245()
spilled.v3246 = 0 + 1
spilled.v3247 = spilled.v3246 + 1
spilled.v3248 = spilled.v3247 + 1
spilled.v3249 = spilled.v3248 + 1
spilled.v3250 = spilled.v3249 + 1
spilled.v3251 = 0 + 1
spilled.v3252 = spilled.v3251 + 1
spilled.v3253 = spilled.v3252 + 1
spilled.v3254 = spilled.v3253 + 1
spilled.v3255 = spilled.v3254 + 1
spilled.v3256 = spiral_w64.eq(spilled.v3250, spilled.v3255)
spilled.getv3257 = function()
    if spilled.v3256 then
        return 0
    else
        return 1
    end
end
spilled.v3257 = spilled.getv3257()
spilled.v3258 = spiral_w64.add(spilled.v3242, spilled.v3250, true)
spilled.v3259 = spiral_w64.add(spilled.v3243, spilled.v3255, true)
spilled.v3260 = spiral_w64.add(spilled.v3245, spilled.v3257, true)
spilled.v3261 = spiral_w64.add(spilled.v3235, spilled.v3258, true)
spilled.v3262 = spiral_w64.add(spilled.v3239, spilled.v3259, true)
spilled.v3263 = spiral_w64.add(spilled.v3241, spilled.v3260, true)
spilled.v3264 = spiral_w64.eq(spilled.v3229, 10)
spilled.v3265 = spiral_w64.eq(spilled.v3230, 10)
spilled.v3266 = spiral_w64.eq(spilled.v3231, 0)
spilled.v3267 = spiral_w64.eq(spilled.v3261, 10)
spilled.v3268 = spiral_w64.eq(spilled.v3262, 10)
spilled.v3269 = spiral_w64.eq(spilled.v3263, 0)
spilled.v3270 = (spilled.v3264) and (spilled.v3265)
spilled.v3271 = (spilled.v3270) and (spilled.v3266)
spilled.v3272 = (spilled.v3271) and (spilled.v3267)
spilled.v3273 = (spilled.v3272) and (spilled.v3268)
spilled.v3274 = (spilled.v3273) and (spilled.v3269)
if spilled.v3274 then
else
    _G.error("typed-FX-hashed-statement-identity-lookup-runtime-mismatch")
end
spilled.v3275 = 0 + 1
spilled.v3276 = spilled.v3275 + 1
spilled.v3277 = spilled.v3276 + 1
spilled.v3278 = spilled.v3277 + 1
spilled.v3279 = 0 + 1
spilled.v3280 = spilled.v3279 + 1
spilled.v3281 = spilled.v3280 + 1
spilled.v3282 = spilled.v3281 + 1
spilled.v3283 = spiral_w64.eq(spilled.v3278, spilled.v3282)
spilled.getv3284 = function()
    if spilled.v3283 then
        return 0
    else
        return 1
    end
end
spilled.v3284 = spilled.getv3284()
spilled.v3285 = 0 + 1
spilled.v3286 = 0 + 1
spilled.v3287 = spiral_w64.eq(spilled.v3285, spilled.v3286)
spilled.getv3288 = function()
    if spilled.v3287 then
        return 0
    else
        return 1
    end
end
spilled.v3288 = spilled.getv3288()
spilled.v3289 = 0 + 1
spilled.v3290 = spilled.v3289 + 1
spilled.v3291 = spilled.v3290 + 1
spilled.v3292 = spilled.v3291 + 1
spilled.v3293 = spilled.v3292 + 1
spilled.v3294 = 0 + 1
spilled.v3295 = spilled.v3294 + 1
spilled.v3296 = spilled.v3295 + 1
spilled.v3297 = spilled.v3296 + 1
spilled.v3298 = spilled.v3297 + 1
spilled.v3299 = spiral_w64.eq(spilled.v3293, spilled.v3298)
spilled.getv3300 = function()
    if spilled.v3299 then
        return 0
    else
        return 1
    end
end
spilled.v3300 = spilled.getv3300()
spilled.v3301 = spiral_w64.add(spilled.v3285, spilled.v3293, true)
spilled.v3302 = spiral_w64.add(spilled.v3286, spilled.v3298, true)
spilled.v3303 = spiral_w64.add(spilled.v3288, spilled.v3300, true)
spilled.v3304 = spiral_w64.add(spilled.v3278, spilled.v3301, true)
spilled.v3305 = spiral_w64.add(spilled.v3282, spilled.v3302, true)
spilled.v3306 = spiral_w64.add(spilled.v3284, spilled.v3303, true)
spilled.v3307 = 0 + 1
spilled.v3308 = spilled.v3307 + 1
spilled.v3309 = spilled.v3308 + 1
spilled.v3310 = spilled.v3309 + 1
spilled.v3311 = 0 + 1
spilled.v3312 = spilled.v3311 + 1
spilled.v3313 = spilled.v3312 + 1
spilled.v3314 = spilled.v3313 + 1
spilled.v3315 = spiral_w64.eq(spilled.v3310, spilled.v3314)
spilled.getv3316 = function()
    if spilled.v3315 then
        return 0
    else
        return 1
    end
end
spilled.v3316 = spilled.getv3316()
spilled.v3317 = 0 + 1
spilled.v3318 = 0 + 1
spilled.v3319 = spiral_w64.eq(spilled.v3317, spilled.v3318)
spilled.getv3320 = function()
    if spilled.v3319 then
        return 0
    else
        return 1
    end
end
spilled.v3320 = spilled.getv3320()
spilled.v3321 = 0 + 1
spilled.v3322 = spilled.v3321 + 1
spilled.v3323 = spilled.v3322 + 1
spilled.v3324 = spilled.v3323 + 1
spilled.v3325 = spilled.v3324 + 1
spilled.v3326 = 0 + 1
spilled.v3327 = spilled.v3326 + 1
spilled.v3328 = spilled.v3327 + 1
spilled.v3329 = spilled.v3328 + 1
spilled.v3330 = spilled.v3329 + 1
spilled.v3331 = spiral_w64.eq(spilled.v3325, spilled.v3330)
spilled.getv3332 = function()
    if spilled.v3331 then
        return 0
    else
        return 1
    end
end
spilled.v3332 = spilled.getv3332()
spilled.v3333 = spiral_w64.add(spilled.v3317, spilled.v3325, true)
spilled.v3334 = spiral_w64.add(spilled.v3318, spilled.v3330, true)
spilled.v3335 = spiral_w64.add(spilled.v3320, spilled.v3332, true)
spilled.v3336 = spiral_w64.add(spilled.v3310, spilled.v3333, true)
spilled.v3337 = spiral_w64.add(spilled.v3314, spilled.v3334, true)
spilled.v3338 = spiral_w64.add(spilled.v3316, spilled.v3335, true)
spilled.v3339 = spiral_w64.add(spilled.v3304, spilled.v3336, true)
spilled.v3340 = spiral_w64.add(spilled.v3305, spilled.v3337, true)
spilled.v3341 = spiral_w64.add(spilled.v3306, spilled.v3338, true)
spilled.v3342 = spiral_w64.eq(spilled.v3339, 20)
spilled.v3343 = spiral_w64.eq(spilled.v3340, 20)
spilled.v3344 = spiral_w64.eq(spilled.v3341, 0)
spilled.v3345 = (spilled.v3342) and (spilled.v3343)
spilled.v3346 = (spilled.v3345) and (spilled.v3344)
if spilled.v3346 then
else
    _G.error("typed-FX-hashed-statement-membership-lookup-program-runtime-mismatch")
end
spilled.v3347 = 0 + 1
spilled.v3348 = spilled.v3347 + 1
spilled.v3349 = spilled.v3348 + 1
spilled.v3350 = spilled.v3349 + 1
spilled.v3351 = 0 + 1
spilled.v3352 = spilled.v3351 + 1
spilled.v3353 = spilled.v3352 + 1
spilled.v3354 = spilled.v3353 + 1
spilled.v3355 = spiral_w64.eq(spilled.v3350, spilled.v3354)
spilled.getv3356 = function()
    if spilled.v3355 then
        return 0
    else
        return 1
    end
end
spilled.v3356 = spilled.getv3356()
spilled.v3357 = 0 + 1
spilled.v3358 = 0 + 1
spilled.v3359 = spiral_w64.eq(spilled.v3357, spilled.v3358)
spilled.getv3360 = function()
    if spilled.v3359 then
        return 0
    else
        return 1
    end
end
spilled.v3360 = spilled.getv3360()
spilled.v3361 = 0 + 1
spilled.v3362 = spilled.v3361 + 1
spilled.v3363 = spilled.v3362 + 1
spilled.v3364 = spilled.v3363 + 1
spilled.v3365 = spilled.v3364 + 1
spilled.v3366 = 0 + 1
spilled.v3367 = spilled.v3366 + 1
spilled.v3368 = spilled.v3367 + 1
spilled.v3369 = spilled.v3368 + 1
spilled.v3370 = spilled.v3369 + 1
spilled.v3371 = spiral_w64.eq(spilled.v3365, spilled.v3370)
spilled.getv3372 = function()
    if spilled.v3371 then
        return 0
    else
        return 1
    end
end
spilled.v3372 = spilled.getv3372()
spilled.v3373 = spiral_w64.add(spilled.v3357, spilled.v3365, true)
spilled.v3374 = spiral_w64.add(spilled.v3358, spilled.v3370, true)
spilled.v3375 = spiral_w64.add(spilled.v3360, spilled.v3372, true)
spilled.v3376 = spiral_w64.add(spilled.v3350, spilled.v3373, true)
spilled.v3377 = spiral_w64.add(spilled.v3354, spilled.v3374, true)
spilled.v3378 = spiral_w64.add(spilled.v3356, spilled.v3375, true)
spilled.v3379 = 0 + 1
spilled.v3380 = spilled.v3379 + 1
spilled.v3381 = spilled.v3380 + 1
spilled.v3382 = spilled.v3381 + 1
spilled.v3383 = 0 + 1
spilled.v3384 = spilled.v3383 + 1
spilled.v3385 = spilled.v3384 + 1
spilled.v3386 = spilled.v3385 + 1
spilled.v3387 = spiral_w64.eq(spilled.v3382, spilled.v3386)
spilled.getv3388 = function()
    if spilled.v3387 then
        return 0
    else
        return 1
    end
end
spilled.v3388 = spilled.getv3388()
spilled.v3389 = 0 + 1
spilled.v3390 = 0 + 1
spilled.v3391 = spiral_w64.eq(spilled.v3389, spilled.v3390)
spilled.getv3392 = function()
    if spilled.v3391 then
        return 0
    else
        return 1
    end
end
spilled.v3392 = spilled.getv3392()
spilled.v3393 = 0 + 1
spilled.v3394 = spilled.v3393 + 1
spilled.v3395 = spilled.v3394 + 1
spilled.v3396 = spilled.v3395 + 1
spilled.v3397 = spilled.v3396 + 1
spilled.v3398 = 0 + 1
spilled.v3399 = spilled.v3398 + 1
spilled.v3400 = spilled.v3399 + 1
spilled.v3401 = spilled.v3400 + 1
spilled.v3402 = spilled.v3401 + 1
spilled.v3403 = spiral_w64.eq(spilled.v3397, spilled.v3402)
spilled.getv3404 = function()
    if spilled.v3403 then
        return 0
    else
        return 1
    end
end
spilled.v3404 = spilled.getv3404()
spilled.v3405 = spiral_w64.add(spilled.v3389, spilled.v3397, true)
spilled.v3406 = spiral_w64.add(spilled.v3390, spilled.v3402, true)
spilled.v3407 = spiral_w64.add(spilled.v3392, spilled.v3404, true)
spilled.v3408 = spiral_w64.add(spilled.v3382, spilled.v3405, true)
spilled.v3409 = spiral_w64.add(spilled.v3386, spilled.v3406, true)
spilled.v3410 = spiral_w64.add(spilled.v3388, spilled.v3407, true)
spilled.v3411 = spiral_w64.add(spilled.v3376, spilled.v3408, true)
spilled.v3412 = spiral_w64.add(spilled.v3377, spilled.v3409, true)
spilled.v3413 = spiral_w64.add(spilled.v3378, spilled.v3410, true)
spilled.v3414 = 0 + 1
spilled.v3415 = spilled.v3414 + 1
spilled.v3416 = spilled.v3415 + 1
spilled.v3417 = spilled.v3416 + 1
spilled.v3418 = 0 + 1
spilled.v3419 = spilled.v3418 + 1
spilled.v3420 = spilled.v3419 + 1
spilled.v3421 = spilled.v3420 + 1
spilled.v3422 = spiral_w64.eq(spilled.v3417, spilled.v3421)
spilled.getv3423 = function()
    if spilled.v3422 then
        return 0
    else
        return 1
    end
end
spilled.v3423 = spilled.getv3423()
spilled.v3424 = 0 + 1
spilled.v3425 = 0 + 1
spilled.v3426 = spiral_w64.eq(spilled.v3424, spilled.v3425)
spilled.getv3427 = function()
    if spilled.v3426 then
        return 0
    else
        return 1
    end
end
spilled.v3427 = spilled.getv3427()
spilled.v3428 = 0 + 1
spilled.v3429 = spilled.v3428 + 1
spilled.v3430 = spilled.v3429 + 1
spilled.v3431 = spilled.v3430 + 1
spilled.v3432 = spilled.v3431 + 1
spilled.v3433 = 0 + 1
spilled.v3434 = spilled.v3433 + 1
spilled.v3435 = spilled.v3434 + 1
spilled.v3436 = spilled.v3435 + 1
spilled.v3437 = spilled.v3436 + 1
spilled.v3438 = spiral_w64.eq(spilled.v3432, spilled.v3437)
spilled.getv3439 = function()
    if spilled.v3438 then
        return 0
    else
        return 1
    end
end
spilled.v3439 = spilled.getv3439()
spilled.v3440 = spiral_w64.add(spilled.v3424, spilled.v3432, true)
spilled.v3441 = spiral_w64.add(spilled.v3425, spilled.v3437, true)
spilled.v3442 = spiral_w64.add(spilled.v3427, spilled.v3439, true)
spilled.v3443 = spiral_w64.add(spilled.v3417, spilled.v3440, true)
spilled.v3444 = spiral_w64.add(spilled.v3421, spilled.v3441, true)
spilled.v3445 = spiral_w64.add(spilled.v3423, spilled.v3442, true)
spilled.v3446 = 0 + 1
spilled.v3447 = spilled.v3446 + 1
spilled.v3448 = spilled.v3447 + 1
spilled.v3449 = spilled.v3448 + 1
spilled.v3450 = 0 + 1
spilled.v3451 = spilled.v3450 + 1
spilled.v3452 = spilled.v3451 + 1
spilled.v3453 = spilled.v3452 + 1
spilled.v3454 = spiral_w64.eq(spilled.v3449, spilled.v3453)
spilled.getv3455 = function()
    if spilled.v3454 then
        return 0
    else
        return 1
    end
end
spilled.v3455 = spilled.getv3455()
spilled.v3456 = 0 + 1
spilled.v3457 = 0 + 1
spilled.v3458 = spiral_w64.eq(spilled.v3456, spilled.v3457)
spilled.getv3459 = function()
    if spilled.v3458 then
        return 0
    else
        return 1
    end
end
spilled.v3459 = spilled.getv3459()
spilled.v3460 = 0 + 1
spilled.v3461 = spilled.v3460 + 1
spilled.v3462 = spilled.v3461 + 1
spilled.v3463 = spilled.v3462 + 1
spilled.v3464 = spilled.v3463 + 1
spilled.v3465 = 0 + 1
spilled.v3466 = spilled.v3465 + 1
spilled.v3467 = spilled.v3466 + 1
spilled.v3468 = spilled.v3467 + 1
spilled.v3469 = spilled.v3468 + 1
spilled.v3470 = spiral_w64.eq(spilled.v3464, spilled.v3469)
spilled.getv3471 = function()
    if spilled.v3470 then
        return 0
    else
        return 1
    end
end
spilled.v3471 = spilled.getv3471()
spilled.v3472 = spiral_w64.add(spilled.v3456, spilled.v3464, true)
spilled.v3473 = spiral_w64.add(spilled.v3457, spilled.v3469, true)
spilled.v3474 = spiral_w64.add(spilled.v3459, spilled.v3471, true)
spilled.v3475 = spiral_w64.add(spilled.v3449, spilled.v3472, true)
spilled.v3476 = spiral_w64.add(spilled.v3453, spilled.v3473, true)
spilled.v3477 = spiral_w64.add(spilled.v3455, spilled.v3474, true)
spilled.v3478 = spiral_w64.add(spilled.v3443, spilled.v3475, true)
spilled.v3479 = spiral_w64.eq(spilled.v3411, spilled.v3478)
spilled.v3480 = spiral_w64.add(spilled.v3444, spilled.v3476, true)
spilled.v3481 = spiral_w64.eq(spilled.v3412, spilled.v3480)
spilled.v3482 = spiral_w64.add(spilled.v3445, spilled.v3477, true)
spilled.v3483 = spiral_w64.eq(spilled.v3413, spilled.v3482)
spilled.v3484 = (spilled.v3479) and (spilled.v3481)
spilled.v3485 = (spilled.v3484) and (spilled.v3483)
if spilled.v3485 then
else
    _G.error("typed-FX-hashed-statement-membership-lookup-program-append-runtime-mismatch")
end
spilled.v3486 = 0 + 1
spilled.v3487 = spilled.v3486 + 1
spilled.v3488 = spilled.v3487 + 1
spilled.v3489 = spilled.v3488 + 1
spilled.v3490 = 0 + 1
spilled.v3491 = spilled.v3490 + 1
spilled.v3492 = spilled.v3491 + 1
spilled.v3493 = spilled.v3492 + 1
spilled.v3494 = spiral_w64.eq(spilled.v3489, spilled.v3493)
spilled.getv3495 = function()
    if spilled.v3494 then
        return 0
    else
        return 1
    end
end
spilled.v3495 = spilled.getv3495()
spilled.v3496 = 0 + 1
spilled.v3497 = 0 + 1
spilled.v3498 = spiral_w64.eq(spilled.v3496, spilled.v3497)
spilled.getv3499 = function()
    if spilled.v3498 then
        return 0
    else
        return 1
    end
end
spilled.v3499 = spilled.getv3499()
spilled.v3500 = 0 + 1
spilled.v3501 = spilled.v3500 + 1
spilled.v3502 = spilled.v3501 + 1
spilled.v3503 = spilled.v3502 + 1
spilled.v3504 = spilled.v3503 + 1
spilled.v3505 = 0 + 1
spilled.v3506 = spilled.v3505 + 1
spilled.v3507 = spilled.v3506 + 1
spilled.v3508 = spilled.v3507 + 1
spilled.v3509 = spilled.v3508 + 1
spilled.v3510 = spiral_w64.eq(spilled.v3504, spilled.v3509)
spilled.getv3511 = function()
    if spilled.v3510 then
        return 0
    else
        return 1
    end
end
spilled.v3511 = spilled.getv3511()
spilled.v3512 = spiral_w64.add(spilled.v3496, spilled.v3504, true)
spilled.v3513 = spiral_w64.add(spilled.v3497, spilled.v3509, true)
spilled.v3514 = spiral_w64.add(spilled.v3499, spilled.v3511, true)
spilled.v3515 = spiral_w64.add(spilled.v3489, spilled.v3512, true)
spilled.v3516 = spiral_w64.add(spilled.v3493, spilled.v3513, true)
spilled.v3517 = spiral_w64.add(spilled.v3495, spilled.v3514, true)
spilled.v3518 = 0 + 1
spilled.v3519 = spilled.v3518 + 1
spilled.v3520 = spilled.v3519 + 1
spilled.v3521 = spilled.v3520 + 1
spilled.v3522 = 0 + 1
spilled.v3523 = spilled.v3522 + 1
spilled.v3524 = spilled.v3523 + 1
spilled.v3525 = spilled.v3524 + 1
spilled.v3526 = spiral_w64.eq(spilled.v3521, spilled.v3525)
spilled.getv3527 = function()
    if spilled.v3526 then
        return 0
    else
        return 1
    end
end
spilled.v3527 = spilled.getv3527()
spilled.v3528 = 0 + 1
spilled.v3529 = 0 + 1
spilled.v3530 = spiral_w64.eq(spilled.v3528, spilled.v3529)
spilled.getv3531 = function()
    if spilled.v3530 then
        return 0
    else
        return 1
    end
end
spilled.v3531 = spilled.getv3531()
spilled.v3532 = 0 + 1
spilled.v3533 = spilled.v3532 + 1
spilled.v3534 = spilled.v3533 + 1
spilled.v3535 = spilled.v3534 + 1
spilled.v3536 = spilled.v3535 + 1
spilled.v3537 = 0 + 1
spilled.v3538 = spilled.v3537 + 1
spilled.v3539 = spilled.v3538 + 1
spilled.v3540 = spilled.v3539 + 1
spilled.v3541 = spilled.v3540 + 1
spilled.v3542 = spiral_w64.eq(spilled.v3536, spilled.v3541)
spilled.getv3543 = function()
    if spilled.v3542 then
        return 0
    else
        return 1
    end
end
spilled.v3543 = spilled.getv3543()
spilled.v3544 = spiral_w64.add(spilled.v3528, spilled.v3536, true)
spilled.v3545 = spiral_w64.add(spilled.v3529, spilled.v3541, true)
spilled.v3546 = spiral_w64.add(spilled.v3531, spilled.v3543, true)
spilled.v3547 = spiral_w64.add(spilled.v3521, spilled.v3544, true)
spilled.v3548 = spiral_w64.add(spilled.v3525, spilled.v3545, true)
spilled.v3549 = spiral_w64.add(spilled.v3527, spilled.v3546, true)
spilled.v3550 = 0 + 1
spilled.v3551 = spilled.v3550 + 1
spilled.v3552 = spilled.v3551 + 1
spilled.v3553 = spilled.v3552 + 1
spilled.v3554 = 0 + 1
spilled.v3555 = spilled.v3554 + 1
spilled.v3556 = spilled.v3555 + 1
spilled.v3557 = spilled.v3556 + 1
spilled.v3558 = spiral_w64.eq(spilled.v3553, spilled.v3557)
spilled.getv3559 = function()
    if spilled.v3558 then
        return 0
    else
        return 1
    end
end
spilled.v3559 = spilled.getv3559()
spilled.v3560 = 0 + 1
spilled.v3561 = 0 + 1
spilled.v3562 = spiral_w64.eq(spilled.v3560, spilled.v3561)
spilled.getv3563 = function()
    if spilled.v3562 then
        return 0
    else
        return 1
    end
end
spilled.v3563 = spilled.getv3563()
spilled.v3564 = 0 + 1
spilled.v3565 = spilled.v3564 + 1
spilled.v3566 = spilled.v3565 + 1
spilled.v3567 = spilled.v3566 + 1
spilled.v3568 = spilled.v3567 + 1
spilled.v3569 = 0 + 1
spilled.v3570 = spilled.v3569 + 1
spilled.v3571 = spilled.v3570 + 1
spilled.v3572 = spilled.v3571 + 1
spilled.v3573 = spilled.v3572 + 1
spilled.v3574 = spiral_w64.eq(spilled.v3568, spilled.v3573)
spilled.getv3575 = function()
    if spilled.v3574 then
        return 0
    else
        return 1
    end
end
spilled.v3575 = spilled.getv3575()
spilled.v3576 = spiral_w64.add(spilled.v3560, spilled.v3568, true)
spilled.v3577 = spiral_w64.add(spilled.v3561, spilled.v3573, true)
spilled.v3578 = spiral_w64.add(spilled.v3563, spilled.v3575, true)
spilled.v3579 = spiral_w64.add(spilled.v3553, spilled.v3576, true)
spilled.v3580 = spiral_w64.add(spilled.v3557, spilled.v3577, true)
spilled.v3581 = spiral_w64.add(spilled.v3559, spilled.v3578, true)
spilled.v3582 = 0 + 1
spilled.v3583 = spilled.v3582 + 1
spilled.v3584 = spilled.v3583 + 1
spilled.v3585 = spilled.v3584 + 1
spilled.v3586 = 0 + 1
spilled.v3587 = spilled.v3586 + 1
spilled.v3588 = spilled.v3587 + 1
spilled.v3589 = spilled.v3588 + 1
spilled.v3590 = spiral_w64.eq(spilled.v3585, spilled.v3589)
spilled.getv3591 = function()
    if spilled.v3590 then
        return 0
    else
        return 1
    end
end
spilled.v3591 = spilled.getv3591()
spilled.v3592 = 0 + 1
spilled.v3593 = 0 + 1
spilled.v3594 = spiral_w64.eq(spilled.v3592, spilled.v3593)
spilled.getv3595 = function()
    if spilled.v3594 then
        return 0
    else
        return 1
    end
end
spilled.v3595 = spilled.getv3595()
spilled.v3596 = 0 + 1
spilled.v3597 = spilled.v3596 + 1
spilled.v3598 = spilled.v3597 + 1
spilled.v3599 = spilled.v3598 + 1
spilled.v3600 = spilled.v3599 + 1
spilled.v3601 = 0 + 1
spilled.v3602 = spilled.v3601 + 1
spilled.v3603 = spilled.v3602 + 1
spilled.v3604 = spilled.v3603 + 1
spilled.v3605 = spilled.v3604 + 1
spilled.v3606 = spiral_w64.eq(spilled.v3600, spilled.v3605)
spilled.getv3607 = function()
    if spilled.v3606 then
        return 0
    else
        return 1
    end
end
spilled.v3607 = spilled.getv3607()
spilled.v3608 = spiral_w64.add(spilled.v3592, spilled.v3600, true)
spilled.v3609 = spiral_w64.add(spilled.v3593, spilled.v3605, true)
spilled.v3610 = spiral_w64.add(spilled.v3595, spilled.v3607, true)
spilled.v3611 = spiral_w64.add(spilled.v3585, spilled.v3608, true)
spilled.v3612 = spiral_w64.add(spilled.v3589, spilled.v3609, true)
spilled.v3613 = spiral_w64.add(spilled.v3591, spilled.v3610, true)
spilled.v3614 = spiral_w64.eq(spilled.v3515, spilled.v3547)
spilled.v3615 = spiral_w64.eq(spilled.v3516, spilled.v3548)
spilled.v3616 = spiral_w64.eq(spilled.v3517, spilled.v3549)
spilled.v3617 = (spilled.v3614) and (spilled.v3615)
spilled.v3618 = (spilled.v3617) and (spilled.v3616)
if spilled.v3618 then
else
    _G.error("typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch")
end
spilled.v3619 = spiral_w64.eq(spilled.v3579, spilled.v3611)
spilled.v3620 = spiral_w64.eq(spilled.v3580, spilled.v3612)
spilled.v3621 = spiral_w64.eq(spilled.v3581, spilled.v3613)
spilled.v3622 = (spilled.v3619) and (spilled.v3620)
spilled.v3623 = (spilled.v3622) and (spilled.v3621)
if spilled.v3623 then
else
    _G.error("typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch")
end
return 0
