local Us0i0, Us0i1
function Us0i0(v0) return { tag = "Us0i0",  _1 = v0 } end
function Us0i1() return { tag = "Us0i1" } end

local v0 = "ff"
local v11 = tonumber( v0, 16 )
print(v11)
local v67 = "1011"
local v78 = tonumber( v67, 2 )
print(v78)
local v91 = "-42"
local v125 = tonumber( v91, 10 )
print(v125)
local v138 = " 123 "
local v162 = (string.match(v138, "^%s*[+-]?%d+%s*$") ~= nil)
local v163 = (tonumber(v138) or 0)
local v164 = v163
local getv168 = function()
    if v162 then
        local v165 = v163 >= -2147483648
        if v165 then
            local v166 = v163 <= 2147483647
            return v166
        else
            return false
        end
    else
        return false
    end
end
local v168 = getv168()
local getv171 = function()
    if v168 then
        return Us0i0(v164)
    else
        return Us0i1()
    end
end
local v171 = getv171()
local __v = { v171 }
if __v[1] ~= nil and __v[1].tag == "Us0i1" then
    local v702 = "none"
    print(v702)
elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
    local v700 = __v[1]._1
    print(v700)
end
local v706 = "12x"
local v707 = (string.match(v706, "^%s*[+-]?%d+%s*$") ~= nil)
local v708 = (tonumber(v706) or 0)
local v709 = v708
local getv713 = function()
    if v707 then
        local v710 = v708 >= -2147483648
        if v710 then
            local v711 = v708 <= 2147483647
            return v711
        else
            return false
        end
    else
        return false
    end
end
local v713 = getv713()
local getv716 = function()
    if v713 then
        return Us0i0(v709)
    else
        return Us0i1()
    end
end
local v716 = getv716()
local __v = { v716 }
if __v[1] ~= nil and __v[1].tag == "Us0i1" then
    local v718 = "none"
    print(v718)
elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
    local v717 = __v[1]._1
    print(v717)
end
local v719 = ""
local v720 = (string.match(v719, "^%s*[+-]?%d+%s*$") ~= nil)
local v721 = (tonumber(v719) or 0)
local v722 = v721
local getv726 = function()
    if v720 then
        local v723 = v721 >= -2147483648
        if v723 then
            local v724 = v721 <= 2147483647
            return v724
        else
            return false
        end
    else
        return false
    end
end
local v726 = getv726()
local getv729 = function()
    if v726 then
        return Us0i0(v722)
    else
        return Us0i1()
    end
end
local v729 = getv729()
local __v = { v729 }
if __v[1] ~= nil and __v[1].tag == "Us0i1" then
    local v731 = "none"
    print(v731)
elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
    local v730 = __v[1]._1
    print(v730)
end
local v732 = "+7"
local v733 = (string.match(v732, "^%s*[+-]?%d+%s*$") ~= nil)
local v734 = (tonumber(v732) or 0)
local v735 = v734
local getv739 = function()
    if v733 then
        local v736 = v734 >= -2147483648
        if v736 then
            local v737 = v734 <= 2147483647
            return v737
        else
            return false
        end
    else
        return false
    end
end
local v739 = getv739()
local getv742 = function()
    if v739 then
        return Us0i0(v735)
    else
        return Us0i1()
    end
end
local v742 = getv742()
local __v = { v742 }
if __v[1] ~= nil and __v[1].tag == "Us0i1" then
    local v744 = "none"
    print(v744)
elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
    local v743 = __v[1]._1
    print(v743)
end
return 0
