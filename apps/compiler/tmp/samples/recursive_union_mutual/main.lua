local Uh0_A, Uh0_StopA, Uh1_B, Uh1_StopB
function Uh0_A(v0) return { tag = "Uh0_A",  _1 = v0 } end
function Uh0_StopA() return { tag = "Uh0_StopA" } end

function Uh1_B(v0) return { tag = "Uh1_B",  _1 = v0 } end
function Uh1_StopB() return { tag = "Uh1_StopB" } end

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
local __v = { v5 }
if __v[1] ~= nil and __v[1].tag == "Uh0_A" then
    local v6 = __v[1]._1
    return 0
elseif __v[1] ~= nil and __v[1].tag == "Uh0_StopA" then
    return 0
end
