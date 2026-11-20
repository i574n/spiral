local first_codepoint_0, second_codepoint_1
function first_codepoint_0(v0)
    local v1 = string.sub(v0, (0)+1, (1)+1)
    return v1
end

function second_codepoint_1(v0)
    local v1 = string.sub(v0, (2)+1, (3)+1)
    return v1
end

local v0 = "éλ"
local v1 = first_codepoint_0(v0)
local v2 = second_codepoint_1(v0)
local v3 = (v1 .. v2)
local v4 = string.len(v1)
local v5 = v4 == 2
if v5 then
    local v6 = string.len(v2)
    local v7 = v6 == 2
    if v7 then
        local v8 = string.len(v3)
        local v9 = v8 == 4
        if v9 then
            return 0
        else
            return 1
        end
    else
        return 2
    end
else
    return 3
end
