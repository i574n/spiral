local v0 = "a \"b\" c"
local v1 = ""
local v2 = "a\\nb"
local v3 = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
local v4 = "\ntop\n\nlevel"
local v5 = string.len(v0)
local v6 = v5 == 7
local v7 = v6 ~= true
if v7 then
    return 1
else
    local v8 = string.sub(v0, (2)+1, (2)+1)
    local v9 = v8 == "\""
    local v10 = v9 ~= true
    if v10 then
        return 2
    else
        local v11 = string.len(v1)
        local v12 = v11 == 0
        local v13 = v12 ~= true
        if v13 then
            return 3
        else
            local v14 = string.len(v2)
            local v15 = v14 == 4
            local v16 = v15 ~= true
            if v16 then
                return 4
            else
                local v17 = string.sub(v2, (1)+1, (1)+1)
                local v18 = v17 == "\\"
                local v19 = v18 ~= true
                if v19 then
                    return 5
                else
                    local v20 = string.len(v3)
                    local v21 = v20 == 83
                    local v22 = v21 ~= true
                    if v22 then
                        return 6
                    else
                        local v23 = string.sub(v3, (5)+1, (5)+1)
                        local v24 = v23 == "\n"
                        local v25 = v24 ~= true
                        if v25 then
                            return 7
                        else
                            local v26 = string.sub(v3, (37)+1, (37)+1)
                            local v27 = v26 == "\n"
                            local v28 = v27 ~= true
                            if v28 then
                                return 8
                            else
                                local v29 = string.sub(v3, (38)+1, (38)+1)
                                local v30 = v29 == "\n"
                                local v31 = v30 ~= true
                                if v31 then
                                    return 9
                                else
                                    local v32 = string.sub(v3, (39)+1, (39)+1)
                                    local v33 = v32 == "$"
                                    local v34 = v33 ~= true
                                    if v34 then
                                        return 10
                                    else
                                        local v35 = string.sub(v3, (57)+1, (57)+1)
                                        local v36 = v35 == "i"
                                        local v37 = v36 ~= true
                                        if v37 then
                                            return 11
                                        else
                                            local v38 = string.sub(v3, (82)+1, (82)+1)
                                            local v39 = v38 == "d"
                                            local v40 = v39 ~= true
                                            if v40 then
                                                return 12
                                            else
                                                local v41 = string.len(v4)
                                                local v42 = v41 == 11
                                                local v43 = v42 ~= true
                                                if v43 then
                                                    return 13
                                                else
                                                    local v44 = string.sub(v4, (0)+1, (0)+1)
                                                    local v45 = v44 == "\n"
                                                    local v46 = v45 ~= true
                                                    if v46 then
                                                        return 14
                                                    else
                                                        local v47 = string.sub(v4, (5)+1, (5)+1)
                                                        local v48 = v47 == "\n"
                                                        local v49 = v48 ~= true
                                                        if v49 then
                                                            return 15
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
