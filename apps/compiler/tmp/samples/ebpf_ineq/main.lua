local v0 = -3
local v1 = -4
local v2 = -3
local v3 = 4294967295
local v4 = 0
local v5 = 4294967295
local v6 = -1.5
local v7 = -0.5
local v8 = -1.5
local v9 = v0 ~= v1
local v10 = v0 ~= v2
local v11 = v3 ~= v4
local v12 = v3 ~= v5
local v13 = v6 ~= v7
local v14 = v6 ~= v8
local v15 = (v9) and (v11)
local v16 = (v15) and (v13)
if v16 then
    if v10 then
        return 1
    else
        if v12 then
            return 2
        else
            if v14 then
                return 3
            else
                return 0
            end
        end
    end
else
    return 4
end
