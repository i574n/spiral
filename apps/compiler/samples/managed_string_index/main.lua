local v0 = "qwe"
local v1 = string.sub(v0, (1)+1, (1)+1)
local v2 = v1 == "w"
if v2 then
    return 0
else
    return 1
end
