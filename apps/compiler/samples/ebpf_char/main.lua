local v0 = "A"
local v1 = "B"
local v2 = v0 == "A"
if v2 then
    local v3 = v1 == "B"
    if v3 then
        local v4 = v0 == v1
        if v4 then
            return 2
        else
            return 0
        end
    else
        return 3
    end
else
    return 1
end
