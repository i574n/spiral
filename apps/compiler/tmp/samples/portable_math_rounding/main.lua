local v0 = 2.7
local v1 = 3.2
local v2 = -2.5
local v3 = 3.5
local v4 = 0.5
local v5 = 1.0
local v6 = 2.7
local v7 = math.floor
local v8 = v7(v0)
local v9 = v8 == 2.0
local v10 = v9 ~= true
if v10 then
    return 1
else
    local v11 = math.ceil
    local v12 = v11(v0)
    local v13 = v12 == 3.0
    local v14 = v13 ~= true
    if v14 then
        return 2
    else
        local v15 = math.floor
        local v16 = v15(v0)
        local v17 = (v0 - v16)
        local v18 = v17 > 0.5
        local getv29 = function()
            if v18 then
                local v19 = (v16 + 1.0)
                return v19
            else
                local v20 = v17 < 0.5
                if v20 then
                    return v16
                else
                    local v21 = v16 / 2.0
                    local v22 = math.floor
                    local v23 = v22(v21)
                    local v24 = (v23 * 2.0)
                    local v25 = v24 == v16
                    if v25 then
                        return v16
                    else
                        local v26 = (v16 + 1.0)
                        return v26
                    end
                end
            end
        end
        local v29 = getv29()
        local v30 = v29 == 3.0
        local v31 = v30 ~= true
        if v31 then
            return 3
        else
            local v32 = math.floor
            local v33 = v32(v1)
            local v34 = (v1 - v33)
            local v35 = v34 > 0.5
            local getv46 = function()
                if v35 then
                    local v36 = (v33 + 1.0)
                    return v36
                else
                    local v37 = v34 < 0.5
                    if v37 then
                        return v33
                    else
                        local v38 = v33 / 2.0
                        local v39 = math.floor
                        local v40 = v39(v38)
                        local v41 = (v40 * 2.0)
                        local v42 = v41 == v33
                        if v42 then
                            return v33
                        else
                            local v43 = (v33 + 1.0)
                            return v43
                        end
                    end
                end
            end
            local v46 = getv46()
            local v47 = v46 == 3.0
            local v48 = v47 ~= true
            if v48 then
                return 4
            else
                local v49 = math.floor
                local v50 = v49(v2)
                local v51 = (v2 - v50)
                local v52 = v51 > 0.5
                local getv63 = function()
                    if v52 then
                        local v53 = (v50 + 1.0)
                        return v53
                    else
                        local v54 = v51 < 0.5
                        if v54 then
                            return v50
                        else
                            local v55 = v50 / 2.0
                            local v56 = math.floor
                            local v57 = v56(v55)
                            local v58 = (v57 * 2.0)
                            local v59 = v58 == v50
                            if v59 then
                                return v50
                            else
                                local v60 = (v50 + 1.0)
                                return v60
                            end
                        end
                    end
                end
                local v63 = getv63()
                local v64 = v63 == -2.0
                local v65 = v64 ~= true
                if v65 then
                    return 5
                else
                    local v66 = math.floor
                    local v67 = v66(v3)
                    local v68 = (v3 - v67)
                    local v69 = v68 > 0.5
                    local getv80 = function()
                        if v69 then
                            local v70 = (v67 + 1.0)
                            return v70
                        else
                            local v71 = v68 < 0.5
                            if v71 then
                                return v67
                            else
                                local v72 = v67 / 2.0
                                local v73 = math.floor
                                local v74 = v73(v72)
                                local v75 = (v74 * 2.0)
                                local v76 = v75 == v67
                                if v76 then
                                    return v67
                                else
                                    local v77 = (v67 + 1.0)
                                    return v77
                                end
                            end
                        end
                    end
                    local v80 = getv80()
                    local v81 = v80 == 4.0
                    local v82 = v81 ~= true
                    if v82 then
                        return 6
                    else
                        local v83 = math.floor
                        local v84 = v83(v4)
                        local v85 = (v4 - v84)
                        local v86 = v85 > 0.5
                        local getv97 = function()
                            if v86 then
                                local v87 = (v84 + 1.0)
                                return v87
                            else
                                local v88 = v85 < 0.5
                                if v88 then
                                    return v84
                                else
                                    local v89 = v84 / 2.0
                                    local v90 = math.floor
                                    local v91 = v90(v89)
                                    local v92 = (v91 * 2.0)
                                    local v93 = v92 == v84
                                    if v93 then
                                        return v84
                                    else
                                        local v94 = (v84 + 1.0)
                                        return v94
                                    end
                                end
                            end
                        end
                        local v97 = getv97()
                        local v98 = v97 == 0.0
                        local v99 = v98 ~= true
                        if v99 then
                            return 7
                        else
                            local v100 = math.atan2(v5, v5)
                            local v101 = (v100 * 1000.0)
                            local v102 = math.floor
                            local v103 = v102(v101)
                            local v104 = v103 == 785.0
                            local v105 = v104 ~= true
                            if v105 then
                                return 8
                            else
                                local v106 = math.floor
                                local v107 = v106(v6)
                                local v108 = v107 == 2.0
                                local v109 = v108 ~= true
                                if v109 then
                                    return 9
                                else
                                    return 0
                                end
                            end
                        end
                    end
                end
            end
        end
    end
end
