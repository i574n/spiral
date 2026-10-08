local Uh0i0, Uh0i1, Uh1i0, Uh1i1
function Uh0i0(v0) return { tag = "Uh0i0",  _1 = v0 } end
function Uh0i1() return { tag = "Uh0i1" } end

function Uh1i0(v0) return { tag = "Uh1i0",  _1 = v0 } end
function Uh1i1() return { tag = "Uh1i1" } end

local v0 = true
local getv5 = function()
    if v0 then
        local v1 = Uh0i1()
        local v2 = Uh1i0(v1)
        return Uh0i0(v2)
    else
        return Uh0i1()
    end
end
local v5 = getv5()
local __v = { v5 }
if __v[1] ~= nil and __v[1].tag == "Uh0i0" then
    local v6 = __v[1]._1
    return 0
elseif __v[1] ~= nil and __v[1].tag == "Uh0i1" then
    return 0
end
