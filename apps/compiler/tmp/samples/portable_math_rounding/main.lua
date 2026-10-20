local v0 = 2.7
local v1 = 3.2
local v2 = -2.5
local v3 = 3.5
local v4 = 0.5
local v5 = 1.0
local v6 = 2.7
local v7 = math.floor
local v8 = v7(v0)
local v9 = v8 ~= 2.0
if v9 then
    return 1
else
    local v10 = math.ceil
    local v11 = v10(v0)
    local v12 = v11 ~= 3.0
    if v12 then
        return 2
    else
        local v13 = math.floor
        local v14 = v13(v0)
        local v15 = (v0 - v14)
        local v16 = v15 > 0.5
        local getv27 = function()
            if v16 then
                local v17 = (v14 + 1.0)
                return v17
            else
                local v18 = v15 < 0.5
                if v18 then
                    return v14
                else
                    local v19 = v14 / 2.0
                    local v20 = math.floor
                    local v21 = v20(v19)
                    local v22 = (v21 * 2.0)
                    local v23 = v22 == v14
                    if v23 then
                        return v14
                    else
                        local v24 = (v14 + 1.0)
                        return v24
                    end
                end
            end
        end
        local v27 = getv27()
        local v28 = v27 ~= 3.0
        if v28 then
            return 3
        else
            local v29 = math.floor
            local v30 = v29(v1)
            local v31 = (v1 - v30)
            local v32 = v31 > 0.5
            local getv43 = function()
                if v32 then
                    local v33 = (v30 + 1.0)
                    return v33
                else
                    local v34 = v31 < 0.5
                    if v34 then
                        return v30
                    else
                        local v35 = v30 / 2.0
                        local v36 = math.floor
                        local v37 = v36(v35)
                        local v38 = (v37 * 2.0)
                        local v39 = v38 == v30
                        if v39 then
                            return v30
                        else
                            local v40 = (v30 + 1.0)
                            return v40
                        end
                    end
                end
            end
            local v43 = getv43()
            local v44 = v43 ~= 3.0
            if v44 then
                return 4
            else
                local v45 = math.floor
                local v46 = v45(v2)
                local v47 = (v2 - v46)
                local v48 = v47 > 0.5
                local getv59 = function()
                    if v48 then
                        local v49 = (v46 + 1.0)
                        return v49
                    else
                        local v50 = v47 < 0.5
                        if v50 then
                            return v46
                        else
                            local v51 = v46 / 2.0
                            local v52 = math.floor
                            local v53 = v52(v51)
                            local v54 = (v53 * 2.0)
                            local v55 = v54 == v46
                            if v55 then
                                return v46
                            else
                                local v56 = (v46 + 1.0)
                                return v56
                            end
                        end
                    end
                end
                local v59 = getv59()
                local v60 = v59 ~= -2.0
                if v60 then
                    return 5
                else
                    local v61 = math.floor
                    local v62 = v61(v3)
                    local v63 = (v3 - v62)
                    local v64 = v63 > 0.5
                    local getv75 = function()
                        if v64 then
                            local v65 = (v62 + 1.0)
                            return v65
                        else
                            local v66 = v63 < 0.5
                            if v66 then
                                return v62
                            else
                                local v67 = v62 / 2.0
                                local v68 = math.floor
                                local v69 = v68(v67)
                                local v70 = (v69 * 2.0)
                                local v71 = v70 == v62
                                if v71 then
                                    return v62
                                else
                                    local v72 = (v62 + 1.0)
                                    return v72
                                end
                            end
                        end
                    end
                    local v75 = getv75()
                    local v76 = v75 ~= 4.0
                    if v76 then
                        return 6
                    else
                        local v77 = math.floor
                        local v78 = v77(v4)
                        local v79 = (v4 - v78)
                        local v80 = v79 > 0.5
                        local getv91 = function()
                            if v80 then
                                local v81 = (v78 + 1.0)
                                return v81
                            else
                                local v82 = v79 < 0.5
                                if v82 then
                                    return v78
                                else
                                    local v83 = v78 / 2.0
                                    local v84 = math.floor
                                    local v85 = v84(v83)
                                    local v86 = (v85 * 2.0)
                                    local v87 = v86 == v78
                                    if v87 then
                                        return v78
                                    else
                                        local v88 = (v78 + 1.0)
                                        return v88
                                    end
                                end
                            end
                        end
                        local v91 = getv91()
                        local v92 = v91 ~= 0.0
                        if v92 then
                            return 7
                        else
                            local v93 = math.atan2(v5, v5)
                            local v94 = (v93 * 1000.0)
                            local v95 = math.floor
                            local v96 = v95(v94)
                            local v97 = v96 ~= 785.0
                            if v97 then
                                return 8
                            else
                                local v98 = math.floor
                                local v99 = v98(v6)
                                local v100 = v99 ~= 2.0
                                if v100 then
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
