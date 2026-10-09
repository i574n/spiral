local Us0i0, Us0i1
function Us0i0(v0) return { tag = "Us0i0",  _1 = v0 } end
function Us0i1() return { tag = "Us0i1" } end

local v0 = "ff"
local v11 = tonumber( v0, 16 )
print(v11)
local v69 = "1011"
local v80 = tonumber( v69, 2 )
print(v80)
local v94 = "-42"
local v129 = tonumber( v94, 10 )
print(v129)
local v143 = " 123 "
local v180 = (string.match(v143, "^%s*[+-]?%d+%s*$") ~= nil)
local v181 = (tonumber(v143) or 0)
local v182 = v181
local getv186 = function()
    if v180 then
        local v183 = v181 >= -2147483648
        if v183 then
            local v184 = v181 <= 2147483647
            return v184
        else
            return false
        end
    else
        return false
    end
end
local v186 = getv186()
local getv189 = function()
    if v186 then
        return Us0i0(v182)
    else
        return Us0i1()
    end
end
local v189 = getv189()
local __v = { v189 }
if __v[1] ~= nil and __v[1].tag == "Us0i1" then
    local v797 = "none"
    print(v797)
elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
    local v795 = __v[1]._1
    print(v795)
end
local v801 = "12x"
local v802 = (string.match(v801, "^%s*[+-]?%d+%s*$") ~= nil)
local v803 = (tonumber(v801) or 0)
local v804 = v803
local getv808 = function()
    if v802 then
        local v805 = v803 >= -2147483648
        if v805 then
            local v806 = v803 <= 2147483647
            return v806
        else
            return false
        end
    else
        return false
    end
end
local v808 = getv808()
local getv811 = function()
    if v808 then
        return Us0i0(v804)
    else
        return Us0i1()
    end
end
local v811 = getv811()
local __v = { v811 }
if __v[1] ~= nil and __v[1].tag == "Us0i1" then
    local v813 = "none"
    print(v813)
elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
    local v812 = __v[1]._1
    print(v812)
end
local v814 = ""
local v815 = (string.match(v814, "^%s*[+-]?%d+%s*$") ~= nil)
local v816 = (tonumber(v814) or 0)
local v817 = v816
local getv821 = function()
    if v815 then
        local v818 = v816 >= -2147483648
        if v818 then
            local v819 = v816 <= 2147483647
            return v819
        else
            return false
        end
    else
        return false
    end
end
local v821 = getv821()
local getv824 = function()
    if v821 then
        return Us0i0(v817)
    else
        return Us0i1()
    end
end
local v824 = getv824()
local __v = { v824 }
if __v[1] ~= nil and __v[1].tag == "Us0i1" then
    local v826 = "none"
    print(v826)
elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
    local v825 = __v[1]._1
    print(v825)
end
local v827 = "+7"
local v828 = (string.match(v827, "^%s*[+-]?%d+%s*$") ~= nil)
local v829 = (tonumber(v827) or 0)
local v830 = v829
local getv834 = function()
    if v828 then
        local v831 = v829 >= -2147483648
        if v831 then
            local v832 = v829 <= 2147483647
            return v832
        else
            return false
        end
    else
        return false
    end
end
local v834 = getv834()
local getv837 = function()
    if v834 then
        return Us0i0(v830)
    else
        return Us0i1()
    end
end
local v837 = getv837()
local __v = { v837 }
if __v[1] ~= nil and __v[1].tag == "Us0i1" then
    local v839 = "none"
    print(v839)
elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
    local v838 = __v[1]._1
    print(v838)
end
return 0
