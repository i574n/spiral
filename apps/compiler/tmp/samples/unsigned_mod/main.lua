local function spiral_wrap_unsigned(value, bits)
    return value % (2 ^ bits)
end
local method0
function method0(v0)
    local v1 = spiral_wrap_unsigned((v0 + 5), 32)
    local v2 = math.fmod(v1, 4)
    local v3 = v2 == 0
    return v3
end

local v0 = 7
local v1 = method0(v0)
if v1 then
    return 0
else
    return 1
end
