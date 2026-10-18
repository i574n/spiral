local v0 = 16
local v1 = "x\ny"
local v2 = "say \"hi\""
local v3 = "a \"\"\" b"
local v4 = "first\n    second\n\nthird"
local v5 = "ab\ncd"
local v6 = "a \"b\" c"
local v7 = ""
local v8 = "a\\nb"
local v9 = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
local v10 = "\ntop\n\nlevel"
local v11 = string.len(v6)
local v12 = v11 == 7
local v13 = v12 ~= true
if v13 then
    return 1
else
    local v14 = string.sub(v6, (2)+1, (2)+1)
    local v15 = v14 == "\""
    local v16 = v15 ~= true
    if v16 then
        return 2
    else
        local v17 = string.len(v7)
        local v18 = v17 == 0
        local v19 = v18 ~= true
        if v19 then
            return 3
        else
            local v20 = string.len(v8)
            local v21 = v20 == 4
            local v22 = v21 ~= true
            if v22 then
                return 4
            else
                local v23 = string.sub(v8, (1)+1, (1)+1)
                local v24 = v23 == "\\"
                local v25 = v24 ~= true
                if v25 then
                    return 5
                else
                    local v26 = string.len(v9)
                    local v27 = v26 == 83
                    local v28 = v27 ~= true
                    if v28 then
                        return 6
                    else
                        local v29 = string.sub(v9, (5)+1, (5)+1)
                        local v30 = v29 == "\n"
                        local v31 = v30 ~= true
                        if v31 then
                            return 7
                        else
                            local v32 = string.sub(v9, (37)+1, (37)+1)
                            local v33 = v32 == "\n"
                            local v34 = v33 ~= true
                            if v34 then
                                return 8
                            else
                                local v35 = string.sub(v9, (38)+1, (38)+1)
                                local v36 = v35 == "\n"
                                local v37 = v36 ~= true
                                if v37 then
                                    return 9
                                else
                                    local v38 = string.sub(v9, (39)+1, (39)+1)
                                    local v39 = v38 == "$"
                                    local v40 = v39 ~= true
                                    if v40 then
                                        return 10
                                    else
                                        local v41 = string.sub(v9, (57)+1, (57)+1)
                                        local v42 = v41 == "i"
                                        local v43 = v42 ~= true
                                        if v43 then
                                            return 11
                                        else
                                            local v44 = string.sub(v9, (82)+1, (82)+1)
                                            local v45 = v44 == "d"
                                            local v46 = v45 ~= true
                                            if v46 then
                                                return 12
                                            else
                                                local v47 = string.len(v10)
                                                local v48 = v47 == 11
                                                local v49 = v48 ~= true
                                                if v49 then
                                                    return 13
                                                else
                                                    local v50 = string.sub(v10, (0)+1, (0)+1)
                                                    local v51 = v50 == "\n"
                                                    local v52 = v51 ~= true
                                                    if v52 then
                                                        return 14
                                                    else
                                                        local v53 = string.sub(v10, (5)+1, (5)+1)
                                                        local v54 = v53 == "\n"
                                                        local v55 = v54 ~= true
                                                        if v55 then
                                                            return 15
                                                        else
                                                            local v56 = v0 == 16
                                                            local v57 = v56 ~= true
                                                            if v57 then
                                                                return 16
                                                            else
                                                                local v58 = string.len(v1)
                                                                local v59 = v58 == 3
                                                                local v60 = v59 ~= true
                                                                if v60 then
                                                                    return 17
                                                                else
                                                                    local v61 = string.len(v2)
                                                                    local v62 = v61 == 8
                                                                    local v63 = v62 ~= true
                                                                    if v63 then
                                                                        return 18
                                                                    else
                                                                        local v64 = string.sub(v2, (7)+1, (7)+1)
                                                                        local v65 = v64 == "\""
                                                                        local v66 = v65 ~= true
                                                                        if v66 then
                                                                            return 19
                                                                        else
                                                                            local v67 = string.len(v3)
                                                                            local v68 = v67 == 7
                                                                            local v69 = v68 ~= true
                                                                            if v69 then
                                                                                return 20
                                                                            else
                                                                                local v70 = string.sub(v3, (4)+1, (4)+1)
                                                                                local v71 = v70 == "\""
                                                                                local v72 = v71 ~= true
                                                                                if v72 then
                                                                                    return 21
                                                                                else
                                                                                    local v73 = string.len(v4)
                                                                                    local v74 = v73 == 23
                                                                                    local v75 = v74 ~= true
                                                                                    if v75 then
                                                                                        return 22
                                                                                    else
                                                                                        local v76 = string.sub(v4, (6)+1, (6)+1)
                                                                                        local v77 = v76 == " "
                                                                                        local v78 = v77 ~= true
                                                                                        if v78 then
                                                                                            return 23
                                                                                        else
                                                                                            local v79 = string.sub(v4, (10)+1, (10)+1)
                                                                                            local v80 = v79 == "s"
                                                                                            local v81 = v80 ~= true
                                                                                            if v81 then
                                                                                                return 24
                                                                                            else
                                                                                                local v82 = string.sub(v4, (17)+1, (17)+1)
                                                                                                local v83 = v82 == "\n"
                                                                                                local v84 = v83 ~= true
                                                                                                if v84 then
                                                                                                    return 25
                                                                                                else
                                                                                                    local v85 = string.sub(v4, (22)+1, (22)+1)
                                                                                                    local v86 = v85 == "d"
                                                                                                    local v87 = v86 ~= true
                                                                                                    if v87 then
                                                                                                        return 26
                                                                                                    else
                                                                                                        local v88 = string.len(v5)
                                                                                                        local v89 = v88 == 5
                                                                                                        local v90 = v89 ~= true
                                                                                                        if v90 then
                                                                                                            return 27
                                                                                                        else
                                                                                                            local v91 = string.sub(v5, (3)+1, (3)+1)
                                                                                                            local v92 = v91 == "c"
                                                                                                            local v93 = v92 ~= true
                                                                                                            if v93 then
                                                                                                                return 28
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
                                                                        end
                                                                    end
                                                                end
                                                            end
                                                        end
                                                    end
                                                end
                                            end
                                        end
                                    end
                                end
                            end
                        end
                    end
                end
            end
        end
    end
end
