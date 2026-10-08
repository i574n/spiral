local is_answer_1, method0
function is_answer_1(v0)
    local v1 = v0 == 42
    return v1
end

function method0(v0)
    return is_answer_1(v0)
end

local v0 = 42
local v1 = method0(v0)
if v1 then
    return 0
else
    return 1
end
