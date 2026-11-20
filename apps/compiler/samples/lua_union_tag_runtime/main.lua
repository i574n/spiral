local Us0_Northward, Us0_Eastward, Us0_Southward, Us0_Westward
function Us0_Northward() return { tag = "Us0_Northward" } end
function Us0_Eastward() return { tag = "Us0_Eastward" } end
function Us0_Southward() return { tag = "Us0_Southward" } end
function Us0_Westward() return { tag = "Us0_Westward" } end

local v0 = Us0_Southward()
local v1 = (function () local __tag
if v0.tag == "Us0_Northward" then __tag = 0
elseif v0.tag == "Us0_Eastward" then __tag = 1
elseif v0.tag == "Us0_Southward" then __tag = 2
elseif v0.tag == "Us0_Westward" then __tag = 3
else __tag = 0 end
return __tag end)()
local v2 = v1 == 2
if v2 then
    return 0
else
    return 1
end
