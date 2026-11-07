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
local v12 = v11 ~= 7
if v12 then
    return 1
else
    local v13 = string.sub(v6, (2)+1, (2)+1)
    local v14 = v13 ~= "\""
    if v14 then
        return 2
    else
        local v15 = string.len(v7)
        local v16 = v15 ~= 0
        if v16 then
            return 3
        else
            local v17 = string.len(v8)
            local v18 = v17 ~= 4
            if v18 then
                return 4
            else
                local v19 = string.sub(v8, (1)+1, (1)+1)
                local v20 = v19 ~= "\\"
                if v20 then
                    return 5
                else
                    local v21 = string.len(v9)
                    local v22 = v21 ~= 83
                    if v22 then
                        return 6
                    else
                        local v23 = string.sub(v9, (5)+1, (5)+1)
                        local v24 = v23 ~= "\n"
                        if v24 then
                            return 7
                        else
                            local v25 = string.sub(v9, (37)+1, (37)+1)
                            local v26 = v25 ~= "\n"
                            if v26 then
                                return 8
                            else
                                local v27 = string.sub(v9, (38)+1, (38)+1)
                                local v28 = v27 ~= "\n"
                                if v28 then
                                    return 9
                                else
                                    local v29 = string.sub(v9, (39)+1, (39)+1)
                                    local v30 = v29 ~= "$"
                                    if v30 then
                                        return 10
                                    else
                                        local v31 = string.sub(v9, (57)+1, (57)+1)
                                        local v32 = v31 ~= "i"
                                        if v32 then
                                            return 11
                                        else
                                            local v33 = string.sub(v9, (82)+1, (82)+1)
                                            local v34 = v33 ~= "d"
                                            if v34 then
                                                return 12
                                            else
                                                local v35 = string.len(v10)
                                                local v36 = v35 ~= 11
                                                if v36 then
                                                    return 13
                                                else
                                                    local v37 = string.sub(v10, (0)+1, (0)+1)
                                                    local v38 = v37 ~= "\n"
                                                    if v38 then
                                                        return 14
                                                    else
                                                        local v39 = string.sub(v10, (5)+1, (5)+1)
                                                        local v40 = v39 ~= "\n"
                                                        if v40 then
                                                            return 15
                                                        else
                                                            local v41 = v0 ~= 16
                                                            if v41 then
                                                                return 16
                                                            else
                                                                local v42 = string.len(v1)
                                                                local v43 = v42 ~= 3
                                                                if v43 then
                                                                    return 17
                                                                else
                                                                    local v44 = string.len(v2)
                                                                    local v45 = v44 ~= 8
                                                                    if v45 then
                                                                        return 18
                                                                    else
                                                                        local v46 = string.sub(v2, (7)+1, (7)+1)
                                                                        local v47 = v46 ~= "\""
                                                                        if v47 then
                                                                            return 19
                                                                        else
                                                                            local v48 = string.len(v3)
                                                                            local v49 = v48 ~= 7
                                                                            if v49 then
                                                                                return 20
                                                                            else
                                                                                local v50 = string.sub(v3, (4)+1, (4)+1)
                                                                                local v51 = v50 ~= "\""
                                                                                if v51 then
                                                                                    return 21
                                                                                else
                                                                                    local v52 = string.len(v4)
                                                                                    local v53 = v52 ~= 23
                                                                                    if v53 then
                                                                                        return 22
                                                                                    else
                                                                                        local v54 = string.sub(v4, (6)+1, (6)+1)
                                                                                        local v55 = v54 ~= " "
                                                                                        if v55 then
                                                                                            return 23
                                                                                        else
                                                                                            local v56 = string.sub(v4, (10)+1, (10)+1)
                                                                                            local v57 = v56 ~= "s"
                                                                                            if v57 then
                                                                                                return 24
                                                                                            else
                                                                                                local v58 = string.sub(v4, (17)+1, (17)+1)
                                                                                                local v59 = v58 ~= "\n"
                                                                                                if v59 then
                                                                                                    return 25
                                                                                                else
                                                                                                    local v60 = string.sub(v4, (22)+1, (22)+1)
                                                                                                    local v61 = v60 ~= "d"
                                                                                                    if v61 then
                                                                                                        return 26
                                                                                                    else
                                                                                                        local v62 = string.len(v5)
                                                                                                        local v63 = v62 ~= 5
                                                                                                        if v63 then
                                                                                                            return 27
                                                                                                        else
                                                                                                            local v64 = string.sub(v5, (3)+1, (3)+1)
                                                                                                            local v65 = v64 ~= "c"
                                                                                                            if v65 then
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
