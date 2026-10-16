local empty_middle_0, empty_end_1, empty_source_2
function empty_middle_0(v0)
    local v1 = string.sub(v0, (2)+1, (1)+1)
    return v1
end

function empty_end_1(v0)
    local v1 = string.sub(v0, (5)+1, (4)+1)
    return v1
end

function empty_source_2(v0)
    local v1 = string.sub(v0, (0)+1, (-1)+1)
    return v1
end

local v0 = "alpha"
local v1 = empty_middle_0(v0)
local v2 = empty_end_1(v0)
local v3 = ""
local v4 = empty_source_2(v3)
local v5 = (v1 .. v2)
local v6 = (v4 .. "ok")
local v7 = (v5 .. v6)
local v8 = string.len(v1)
local v9 = v8 == 0
if v9 then
    local v10 = string.len(v2)
    local v11 = v10 == 0
    if v11 then
        local v12 = string.len(v4)
        local v13 = v12 == 0
        if v13 then
            local v14 = string.len(v7)
            local v15 = v14 == 2
            if v15 then
                local v16 = string.sub(v7, (0)+1, (0)+1)
                local v17 = v16 == "o"
                if v17 then
                    local v18 = string.sub(v7, (1)+1, (1)+1)
                    local v19 = v18 == "k"
                    if v19 then
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
        else
            return 4
        end
    else
        return 5
    end
else
    return 6
end
