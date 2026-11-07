local choose_left_0, choose_right_1
function choose_left_0(v0)
    if v0 then
        local v1 = "spi"
        return v1
    else
        local v2 = "bad"
        return v2
    end
end

function choose_right_1(v0)
    if v0 then
        local v1 = "bad"
        return v1
    else
        local v2 = "ral"
        return v2
    end
end

local v0 = true
local v1 = choose_left_0(v0)
local v2 = false
local v3 = choose_right_1(v2)
local v4 = (v1 .. v3)
local v5 = string.len(v4)
local v6 = v5 == 6
if v6 then
    local v7 = string.sub(v4, (0)+1, (0)+1)
    local v8 = v7 == "s"
    if v8 then
        local v9 = string.sub(v4, (5)+1, (5)+1)
        local v10 = v9 == "l"
        if v10 then
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
