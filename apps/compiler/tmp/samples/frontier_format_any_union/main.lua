local Mut0, format_real_1, method0
Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

function format_real_1(v0)
    local v1 = ""
    local v2 = { __tag = "Mut0", l0 = v1 }
    local v3 = tostring(v0)       
    local v4 = v2 ~= nil and v2.l0
    local v5 = v4 .. v3 
    v2.l0 = v5
    local v6 = v2 ~= nil and v2.l0
    return v6
end

function method0()
    local v0 = "Some"
    local v1 = "("
    local v2 = v0 .. v1 
    local v3 = 1
    local v4 = format_real_1(v3)
    local v5 = v2 .. v4 
    local v6 = ")"
    local v7 = v5 .. v6 
    return v7
end

local v0 = method0()
local v1 = "x: "
local v2 = v1 .. v0 
local v3 = v2 == ""
if v3 then
    return 1
else
    return 0
end
