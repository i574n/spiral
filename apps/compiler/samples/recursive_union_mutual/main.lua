local Uh0_A, Uh1_B
function Uh0_A(v0) return { tag = "Uh0_A",  _1 = v0 } end
Uh0_StopA = (function() local shared = { tag = "Uh0_StopA" } return function() return shared end end)()

function Uh1_B(v0) return { tag = "Uh1_B",  _1 = v0 } end
Uh1_StopB = (function() local shared = { tag = "Uh1_StopB" } return function() return shared end end)()

local v0 = true
local getv5 = function()
    if v0 then
        local v1 = Uh0_StopA()
        local v2 = Uh1_B(v1)
        return Uh0_A(v2)
    else
        return Uh0_StopA()
    end
end
local v5 = getv5()
if v5 ~= nil and v5.tag == "Uh0_A" then
    local v6 = v5._1
    return 0
elseif v5 ~= nil and v5.tag == "Uh0_StopA" then
    return 0
end
