local Us0i0, Us0i1, Uh0i0, Uh0i1, Uh1i0, Uh1i1, Uh2i0, Uh2i1, Us1i0, Us1i1, Us1i2, Uh3i0, Uh3i1, Uh4i0, Uh4i1, Uh5i0, Uh5i1, Us2i0, Us2i1, Us2i2, Uh6i0, Uh6i1, Uh7i0, Uh7i1, Uh7i2, Uh7i3, Uh7i4, Uh7i5, Us3i0, Us3i1, Us3i2, Us4i0, Us4i1, Us4i2, Us5i0, Us5i1, Uh8i0, Uh8i1, Uh8i2, Uh8i3, Uh8i4, Uh8i5, input_singletons_from_symbols_0, input_prepend_symbol_to_corpus_2, input_list_append_3, input_prepend_symbols_to_corpus_1, input_singletons_from_symbols_4, input_prepend_symbol_to_corpus_6, input_list_append_7, input_prepend_symbols_to_corpus_5, loop_9, regex_compare_15, alt_insert_sorted_14, make_alt_13, regex_equal_17, make_cat_16, make_star_18, normalize_12, nullable_20, derivative_19, canonical_derivative_11, accepts_10, loop_8, loop_22, regex_compare_28, alt_insert_sorted_27, make_alt_26, regex_equal_30, make_cat_29, make_star_31, normalize_25, nullable_33, derivative_32, canonical_derivative_24, accepts_23, loop_21, loop_34
function Us0i0() return { tag = "Us0i0" } end
function Us0i1() return { tag = "Us0i1" } end

function Uh0i0() return { tag = "Uh0i0" } end
function Uh0i1(v0, v1) return { tag = "Uh0i1",  _1 = v0,  _2 = v1 } end

function Uh1i0() return { tag = "Uh1i0" } end
function Uh1i1(v0, v1) return { tag = "Uh1i1",  _1 = v0,  _2 = v1 } end

function Uh2i0() return { tag = "Uh2i0" } end
function Uh2i1(v0, v1) return { tag = "Uh2i1",  _1 = v0,  _2 = v1 } end

function Us1i0() return { tag = "Us1i0" } end
function Us1i1() return { tag = "Us1i1" } end
function Us1i2() return { tag = "Us1i2" } end

function Uh3i0() return { tag = "Uh3i0" } end
function Uh3i1(v0, v1) return { tag = "Uh3i1",  _1 = v0,  _2 = v1 } end

function Uh4i0() return { tag = "Uh4i0" } end
function Uh4i1(v0, v1) return { tag = "Uh4i1",  _1 = v0,  _2 = v1 } end

function Uh5i0() return { tag = "Uh5i0" } end
function Uh5i1(v0, v1) return { tag = "Uh5i1",  _1 = v0,  _2 = v1 } end

function Us2i0() return { tag = "Us2i0" } end
function Us2i1() return { tag = "Us2i1" } end
function Us2i2() return { tag = "Us2i2" } end

function Uh6i0() return { tag = "Uh6i0" } end
function Uh6i1(v0, v1) return { tag = "Uh6i1",  _1 = v0,  _2 = v1 } end

function Uh7i0() return { tag = "Uh7i0" } end
function Uh7i1() return { tag = "Uh7i1" } end
function Uh7i2(v0) return { tag = "Uh7i2",  _1 = v0 } end
function Uh7i3(v0, v1) return { tag = "Uh7i3",  _1 = v0,  _2 = v1 } end
function Uh7i4(v0, v1) return { tag = "Uh7i4",  _1 = v0,  _2 = v1 } end
function Uh7i5(v0) return { tag = "Uh7i5",  _1 = v0 } end

function Us3i0() return { tag = "Us3i0" } end
function Us3i1() return { tag = "Us3i1" } end
function Us3i2() return { tag = "Us3i2" } end

function Us4i0() return { tag = "Us4i0" } end
function Us4i1() return { tag = "Us4i1" } end
function Us4i2() return { tag = "Us4i2" } end

function Us5i0() return { tag = "Us5i0" } end
function Us5i1() return { tag = "Us5i1" } end

function Uh8i0() return { tag = "Uh8i0" } end
function Uh8i1() return { tag = "Uh8i1" } end
function Uh8i2(v0) return { tag = "Uh8i2",  _1 = v0 } end
function Uh8i3(v0, v1) return { tag = "Uh8i3",  _1 = v0,  _2 = v1 } end
function Uh8i4(v0, v1) return { tag = "Uh8i4",  _1 = v0,  _2 = v1 } end
function Uh8i5(v0) return { tag = "Uh8i5",  _1 = v0 } end

function input_singletons_from_symbols_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0i1" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = input_singletons_from_symbols_0(v3)
        local v5 = Uh1i0()
        local v6 = Uh1i1(v2, v5)
        return Uh2i1(v6, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh0i0" then
        return Uh2i0()
    end
end

function input_prepend_symbol_to_corpus_2(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh2i1" then
        local v3 = __v[1]._1
        local v4 = __v[1]._2
        local v5 = input_prepend_symbol_to_corpus_2(v0, v4)
        local v6 = Uh1i1(v0, v3)
        return Uh2i1(v6, v5)
    elseif __v[1] ~= nil and __v[1].tag == "Uh2i0" then
        return Uh2i0()
    end
end

function input_list_append_3(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh2i1" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = input_list_append_3(v3, v1)
        return Uh2i1(v2, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh2i0" then
        return v1
    end
end

function input_prepend_symbols_to_corpus_1(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0i1" then
        local v3 = __v[1]._1
        local v4 = __v[1]._2
        local v5 = input_prepend_symbol_to_corpus_2(v3, v1)
        local v6 = input_prepend_symbols_to_corpus_1(v4, v1)
        return input_list_append_3(v5, v6)
    elseif __v[1] ~= nil and __v[1].tag == "Uh0i0" then
        return Uh2i0()
    end
end

function input_singletons_from_symbols_4(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh3i1" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = input_singletons_from_symbols_4(v3)
        local v5 = Uh4i0()
        local v6 = Uh4i1(v2, v5)
        return Uh5i1(v6, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh3i0" then
        return Uh5i0()
    end
end

function input_prepend_symbol_to_corpus_6(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh5i1" then
        local v3 = __v[1]._1
        local v4 = __v[1]._2
        local v5 = input_prepend_symbol_to_corpus_6(v0, v4)
        local v6 = Uh4i1(v0, v3)
        return Uh5i1(v6, v5)
    elseif __v[1] ~= nil and __v[1].tag == "Uh5i0" then
        return Uh5i0()
    end
end

function input_list_append_7(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh5i1" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = input_list_append_7(v3, v1)
        return Uh5i1(v2, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh5i0" then
        return v1
    end
end

function input_prepend_symbols_to_corpus_5(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh3i1" then
        local v3 = __v[1]._1
        local v4 = __v[1]._2
        local v5 = input_prepend_symbol_to_corpus_6(v3, v1)
        local v6 = input_prepend_symbols_to_corpus_5(v4, v1)
        return input_list_append_7(v5, v6)
    elseif __v[1] ~= nil and __v[1].tag == "Uh3i0" then
        return Uh5i0()
    end
end

function loop_9(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh1i1" then
        local v6 = __v[1]._1
        local v7 = __v[1]._2
        local getv11 = function()
            local __v = { v6 }
            if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                return Us3i2()
            elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                return Us3i1()
            end
        end
        local v11 = getv11()
        local getv12 = function()
            local __v = { v11 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return true
            else
                return false
            end
        end
        local v12 = getv12()
        local getv19 = function()
            if v12 then
                return 0
            else
                local getv16 = function()
                    local __v = { v6 }
                    if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                        return Us3i1()
                    elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                        return Us3i0()
                    end
                end
                local v16 = getv16()
                local getv17 = function()
                    local __v = { v16 }
                    if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                        return true
                    else
                        return false
                    end
                end
                local v17 = getv17()
                if v17 then
                    return 1
                else
                    return -1
                end
            end
        end
        local v19 = getv19()
        local v20 = v19 < 0
        if v20 then
            return Us4i2()
        else
            local v22 = v0 == 0
            local getv27 = function()
                if v22 then
                    local v23 = v19 == 0
                    if v23 then
                        return 0
                    else
                        return 1
                    end
                else
                    local v25 = v19 == 0
                    if v25 then
                        return 0
                    else
                        return 1
                    end
                end
            end
            local v27 = getv27()
            return loop_9(v27, v7)
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh1i0" then
        local v2 = v0 == 0
        if v2 then
            return Us4i0()
        else
            return Us4i1()
        end
    end
end

function regex_compare_15(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
        local v53 = __v[1]._1
        local v54 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
            local v55 = __v[1]._1
            local v56 = __v[1]._2
            local v57 = regex_compare_15(v53, v55)
            local __v = { v57 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return regex_compare_15(v54, v56)
            else
                return v57
            end
        else
            return Us3i2()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i4" then
        local v28 = __v[1]._1
        local v29 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i4" then
            local v34 = __v[1]._1
            local v35 = __v[1]._2
            local v36 = regex_compare_15(v28, v34)
            local __v = { v36 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return regex_compare_15(v29, v35)
            else
                return v36
            end
        elseif __v[1] ~= nil and __v[1].tag == "Uh7i2" then
            local v32 = __v[1]._1
            return Us3i2()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7i0" then
            return Us3i2()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7i1" then
            return Us3i2()
        else
            return Us3i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i2" then
        local v10 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i2" then
            local v13 = __v[1]._1
            local __v = { v10 }
            if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                local __v = { v13 }
                if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                    return Us3i1()
                elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                    return Us3i2()
                end
            elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                local __v = { v13 }
                if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                    return Us3i0()
                elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                    return Us3i1()
                end
            end
        elseif __v[1] ~= nil and __v[1].tag == "Uh7i0" then
            return Us3i2()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7i1" then
            return Us3i2()
        else
            return Us3i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i0" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i0" then
            return Us3i1()
        else
            return Us3i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i1" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i0" then
            return Us3i2()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7i1" then
            return Us3i1()
        else
            return Us3i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i5" then
        local v44 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
            local v45 = __v[1]._1
            local v46 = __v[1]._2
            return Us3i0()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7i5" then
            local v48 = __v[1]._1
            return regex_compare_15(v44, v48)
        else
            return Us3i2()
        end
    end
end

function alt_insert_sorted_14(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = regex_compare_15(v0, v2)
        local __v = { v4 }
        if __v[1] ~= nil and __v[1].tag == "Us3i2" then
            local v6 = alt_insert_sorted_14(v0, v3)
            return Uh7i3(v2, v6)
        elseif __v[1] ~= nil and __v[1].tag == "Us3i0" then
            return Uh7i3(v0, v1)
        elseif __v[1] ~= nil and __v[1].tag == "Us3i1" then
            return v1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i0" then
        return v0
    else
        local v11 = regex_compare_15(v0, v1)
        local __v = { v11 }
        if __v[1] ~= nil and __v[1].tag == "Us3i2" then
            return Uh7i3(v1, v0)
        elseif __v[1] ~= nil and __v[1].tag == "Us3i0" then
            return Uh7i3(v0, v1)
        elseif __v[1] ~= nil and __v[1].tag == "Us3i1" then
            return v1
        end
    end
end

function make_alt_13(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = alt_insert_sorted_14(v2, v1)
        return make_alt_13(v3, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i0" then
        return v1
    else
        return alt_insert_sorted_14(v0, v1)
    end
end

function regex_equal_17(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
        local v18 = __v[1]._1
        local v19 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
            local v20 = __v[1]._1
            local v21 = __v[1]._2
            local v22 = regex_equal_17(v18, v20)
            if v22 then
                return regex_equal_17(v19, v21)
            else
                return false
            end
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i4" then
        local v26 = __v[1]._1
        local v27 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i4" then
            local v28 = __v[1]._1
            local v29 = __v[1]._2
            local v30 = regex_equal_17(v26, v28)
            if v30 then
                return regex_equal_17(v27, v29)
            else
                return false
            end
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i2" then
        local v4 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i2" then
            local v5 = __v[1]._1
            local getv15 = function()
                local __v = { v4 }
                if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                    local __v = { v5 }
                    if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                        return Us3i1()
                    elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                        return Us3i2()
                    end
                elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                    local __v = { v5 }
                    if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                        return Us3i0()
                    elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                        return Us3i1()
                    end
                end
            end
            local v15 = getv15()
            local __v = { v15 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return true
            else
                return false
            end
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i0" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i0" then
            return true
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i1" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i1" then
            return true
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i5" then
        local v34 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i5" then
            local v35 = __v[1]._1
            return regex_equal_17(v34, v35)
        else
            return false
        end
    end
end

function make_cat_16(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7i0" then
        return Uh7i0()
    else
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7i0" then
            return Uh7i0()
        else
            local __v = { v0 }
            if __v[1] ~= nil and __v[1].tag == "Uh7i1" then
                return v1
            else
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Uh7i1" then
                    return v0
                else
                    local __v = { v0 }
                    if __v[1] ~= nil and __v[1].tag == "Uh7i4" then
                        local v12 = __v[1]._1
                        local v13 = __v[1]._2
                        local v14 = make_cat_16(v13, v1)
                        return Uh7i4(v12, v14)
                    elseif __v[1] ~= nil and __v[1].tag == "Uh7i5" then
                        local v4 = __v[1]._1
                        local __v = { v1 }
                        if __v[1] ~= nil and __v[1].tag == "Uh7i5" then
                            local v5 = __v[1]._1
                            local v6 = regex_equal_17(v4, v5)
                            if v6 then
                                return Uh7i5(v4)
                            else
                                return Uh7i4(v0, v1)
                            end
                        else
                            return Uh7i4(v0, v1)
                        end
                    else
                        return Uh7i4(v0, v1)
                    end
                end
            end
        end
    end
end

function make_star_18(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7i0" then
        return Uh7i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i1" then
        return Uh7i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i5" then
        local v3 = __v[1]._1
        return Uh7i5(v3)
    else
        return Uh7i5(v0)
    end
end

function normalize_12(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
        local v5 = __v[1]._1
        local v6 = __v[1]._2
        local v7 = normalize_12(v5)
        local v8 = normalize_12(v6)
        return make_alt_13(v7, v8)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i4" then
        local v10 = __v[1]._1
        local v11 = __v[1]._2
        local v12 = normalize_12(v10)
        local v13 = normalize_12(v11)
        return make_cat_16(v12, v13)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i2" then
        local v3 = __v[1]._1
        return Uh7i2(v3)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i0" then
        return Uh7i0()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i1" then
        return Uh7i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i5" then
        local v15 = __v[1]._1
        local v16 = normalize_12(v15)
        return make_star_18(v16)
    end
end

function nullable_20(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
        local v5 = __v[1]._1
        local v6 = __v[1]._2
        local v7 = nullable_20(v5)
        local v8 = nullable_20(v6)
        local __v = { v7 }
        if __v[1] ~= nil and __v[1].tag == "Us5i0" then
            return Us5i0()
        else
            local __v = { v8 }
            if __v[1] ~= nil and __v[1].tag == "Us5i0" then
                return Us5i0()
            else
                local __v = { v7 }
                if __v[1] ~= nil and __v[1].tag == "Us5i1" then
                    local __v = { v8 }
                    if __v[1] ~= nil and __v[1].tag == "Us5i1" then
                        return Us5i1()
                    end
                end
            end
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i4" then
        local v16 = __v[1]._1
        local v17 = __v[1]._2
        local v18 = nullable_20(v16)
        local v19 = nullable_20(v17)
        local __v = { v18 }
        if __v[1] ~= nil and __v[1].tag == "Us5i0" then
            local __v = { v19 }
            if __v[1] ~= nil and __v[1].tag == "Us5i0" then
                return Us5i0()
            else
                return Us5i1()
            end
        else
            return Us5i1()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i2" then
        local v3 = __v[1]._1
        return Us5i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i0" then
        return Us5i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i1" then
        return Us5i0()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i5" then
        local v25 = __v[1]._1
        return Us5i0()
    end
end

function derivative_19(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7i3" then
        local v19 = __v[1]._1
        local v20 = __v[1]._2
        local v21 = derivative_19(v19, v1)
        local v22 = derivative_19(v20, v1)
        return make_alt_13(v21, v22)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i4" then
        local v24 = __v[1]._1
        local v25 = __v[1]._2
        local v26 = nullable_20(v24)
        local __v = { v26 }
        if __v[1] ~= nil and __v[1].tag == "Us5i1" then
            local v31 = derivative_19(v24, v1)
            return make_cat_16(v31, v25)
        elseif __v[1] ~= nil and __v[1].tag == "Us5i0" then
            local v27 = derivative_19(v24, v1)
            local v28 = make_cat_16(v27, v25)
            local v29 = derivative_19(v25, v1)
            return make_alt_13(v28, v29)
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i2" then
        local v4 = __v[1]._1
        local getv14 = function()
            local __v = { v4 }
            if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                    return Us3i1()
                elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                    return Us3i2()
                end
            elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Us0i1" then
                    return Us3i0()
                elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
                    return Us3i1()
                end
            end
        end
        local v14 = getv14()
        local getv15 = function()
            local __v = { v14 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return true
            else
                return false
            end
        end
        local v15 = getv15()
        if v15 then
            return Uh7i1()
        else
            return Uh7i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i0" then
        return Uh7i0()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i1" then
        return Uh7i0()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7i5" then
        local v35 = __v[1]._1
        local v36 = derivative_19(v35, v1)
        local v37 = make_star_18(v35)
        return make_cat_16(v36, v37)
    end
end

function canonical_derivative_11(v0, v1)
    local v2 = normalize_12(v0)
    local v3 = derivative_19(v2, v1)
    return normalize_12(v3)
end

function accepts_10(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh1i1" then
        local v6 = __v[1]._1
        local v7 = __v[1]._2
        local v8 = canonical_derivative_11(v0, v6)
        return accepts_10(v8, v7)
    elseif __v[1] ~= nil and __v[1].tag == "Uh1i0" then
        local v2 = normalize_12(v0)
        local v3 = nullable_20(v2)
        local __v = { v3 }
        if __v[1] ~= nil and __v[1].tag == "Us5i1" then
            return false
        elseif __v[1] ~= nil and __v[1].tag == "Us5i0" then
            return true
        end
    end
end

function loop_8(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh2i1" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = 1
        local v5 = loop_9(v4, v2)
        local getv11 = function()
            local __v = { v5 }
            if __v[1] ~= nil and __v[1].tag == "Us4i0" then
                return accepts_10(v0, v2)
            elseif __v[1] ~= nil and __v[1].tag == "Us4i2" then
                return false
            elseif __v[1] ~= nil and __v[1].tag == "Us4i1" then
                local v7 = accepts_10(v0, v2)
                local v8 = v7 == false
                return v8
            end
        end
        local v11 = getv11()
        if v11 then
            return loop_8(v0, v3)
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh2i0" then
        return true
    end
end

function loop_22(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh4i1" then
        local v8 = __v[1]._1
        local v9 = __v[1]._2
        local getv12 = function()
            local __v = { v8 }
            if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                return Us3i1()
            else
                return Us3i2()
            end
        end
        local v12 = getv12()
        local getv13 = function()
            local __v = { v12 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return true
            else
                return false
            end
        end
        local v13 = getv13()
        local getv30 = function()
            if v13 then
                return 0
            else
                local getv19 = function()
                    local __v = { v8 }
                    if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                        return Us3i0()
                    elseif __v[1] ~= nil and __v[1].tag == "Us1i1" then
                        return Us3i1()
                    elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                        return Us3i2()
                    end
                end
                local v19 = getv19()
                local getv20 = function()
                    local __v = { v19 }
                    if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                        return true
                    else
                        return false
                    end
                end
                local v20 = getv20()
                if v20 then
                    return 1
                else
                    local getv26 = function()
                        local __v = { v8 }
                        if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                            return Us3i0()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1i1" then
                            return Us3i0()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                            return Us3i1()
                        end
                    end
                    local v26 = getv26()
                    local getv27 = function()
                        local __v = { v26 }
                        if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                            return true
                        else
                            return false
                        end
                    end
                    local v27 = getv27()
                    if v27 then
                        return 2
                    else
                        return -1
                    end
                end
            end
        end
        local v30 = getv30()
        local v31 = v30 < 0
        if v31 then
            return Us4i2()
        else
            local v33 = v0 == 0
            local getv46 = function()
                if v33 then
                    local v34 = v30 == 0
                    if v34 then
                        return 0
                    else
                        local v35 = v30 == 1
                        return 0
                    end
                else
                    local v37 = v0 == 1
                    if v37 then
                        local v38 = v30 == 0
                        if v38 then
                            return 0
                        else
                            local v39 = v30 == 1
                            return 0
                        end
                    else
                        local v41 = v30 == 0
                        if v41 then
                            return 2
                        else
                            local v42 = v30 == 1
                            if v42 then
                                return 2
                            else
                                return 1
                            end
                        end
                    end
                end
            end
            local v46 = getv46()
            return loop_22(v46, v9)
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh4i0" then
        local v2 = v0 == 0
        local getv4 = function()
            if v2 then
                return false
            else
                local v3 = v0 == 1
                return v3
            end
        end
        local v4 = getv4()
        if v4 then
            return Us4i0()
        else
            return Us4i1()
        end
    end
end

function regex_compare_28(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
        local v59 = __v[1]._1
        local v60 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
            local v61 = __v[1]._1
            local v62 = __v[1]._2
            local v63 = regex_compare_28(v59, v61)
            local __v = { v63 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return regex_compare_28(v60, v62)
            else
                return v63
            end
        else
            return Us3i2()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i4" then
        local v34 = __v[1]._1
        local v35 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i4" then
            local v40 = __v[1]._1
            local v41 = __v[1]._2
            local v42 = regex_compare_28(v34, v40)
            local __v = { v42 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return regex_compare_28(v35, v41)
            else
                return v42
            end
        elseif __v[1] ~= nil and __v[1].tag == "Uh8i2" then
            local v38 = __v[1]._1
            return Us3i2()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8i0" then
            return Us3i2()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8i1" then
            return Us3i2()
        else
            return Us3i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i2" then
        local v10 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i2" then
            local v13 = __v[1]._1
            local __v = { v10 }
            if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                local __v = { v13 }
                if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                    return Us3i1()
                else
                    return Us3i0()
                end
            else
                local __v = { v13 }
                if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                    return Us3i2()
                else
                    local __v = { v10 }
                    if __v[1] ~= nil and __v[1].tag == "Us1i1" then
                        local __v = { v13 }
                        if __v[1] ~= nil and __v[1].tag == "Us1i1" then
                            return Us3i1()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                            return Us3i0()
                        end
                    elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                        local __v = { v13 }
                        if __v[1] ~= nil and __v[1].tag == "Us1i1" then
                            return Us3i2()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                            return Us3i1()
                        end
                    end
                end
            end
        elseif __v[1] ~= nil and __v[1].tag == "Uh8i0" then
            return Us3i2()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8i1" then
            return Us3i2()
        else
            return Us3i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i0" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i0" then
            return Us3i1()
        else
            return Us3i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i1" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i0" then
            return Us3i2()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8i1" then
            return Us3i1()
        else
            return Us3i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i5" then
        local v50 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
            local v51 = __v[1]._1
            local v52 = __v[1]._2
            return Us3i0()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8i5" then
            local v54 = __v[1]._1
            return regex_compare_28(v50, v54)
        else
            return Us3i2()
        end
    end
end

function alt_insert_sorted_27(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = regex_compare_28(v0, v2)
        local __v = { v4 }
        if __v[1] ~= nil and __v[1].tag == "Us3i2" then
            local v6 = alt_insert_sorted_27(v0, v3)
            return Uh8i3(v2, v6)
        elseif __v[1] ~= nil and __v[1].tag == "Us3i0" then
            return Uh8i3(v0, v1)
        elseif __v[1] ~= nil and __v[1].tag == "Us3i1" then
            return v1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i0" then
        return v0
    else
        local v11 = regex_compare_28(v0, v1)
        local __v = { v11 }
        if __v[1] ~= nil and __v[1].tag == "Us3i2" then
            return Uh8i3(v1, v0)
        elseif __v[1] ~= nil and __v[1].tag == "Us3i0" then
            return Uh8i3(v0, v1)
        elseif __v[1] ~= nil and __v[1].tag == "Us3i1" then
            return v1
        end
    end
end

function make_alt_26(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = alt_insert_sorted_27(v2, v1)
        return make_alt_26(v3, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i0" then
        return v1
    else
        return alt_insert_sorted_27(v0, v1)
    end
end

function regex_equal_30(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
        local v24 = __v[1]._1
        local v25 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
            local v26 = __v[1]._1
            local v27 = __v[1]._2
            local v28 = regex_equal_30(v24, v26)
            if v28 then
                return regex_equal_30(v25, v27)
            else
                return false
            end
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i4" then
        local v32 = __v[1]._1
        local v33 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i4" then
            local v34 = __v[1]._1
            local v35 = __v[1]._2
            local v36 = regex_equal_30(v32, v34)
            if v36 then
                return regex_equal_30(v33, v35)
            else
                return false
            end
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i2" then
        local v4 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i2" then
            local v5 = __v[1]._1
            local getv21 = function()
                local __v = { v4 }
                if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                    local __v = { v5 }
                    if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                        return Us3i1()
                    else
                        return Us3i0()
                    end
                else
                    local __v = { v5 }
                    if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                        return Us3i2()
                    else
                        local __v = { v4 }
                        if __v[1] ~= nil and __v[1].tag == "Us1i1" then
                            local __v = { v5 }
                            if __v[1] ~= nil and __v[1].tag == "Us1i1" then
                                return Us3i1()
                            elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                                return Us3i0()
                            end
                        elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                            local __v = { v5 }
                            if __v[1] ~= nil and __v[1].tag == "Us1i1" then
                                return Us3i2()
                            elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                                return Us3i1()
                            end
                        end
                    end
                end
            end
            local v21 = getv21()
            local __v = { v21 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return true
            else
                return false
            end
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i0" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i0" then
            return true
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i1" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i1" then
            return true
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i5" then
        local v40 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i5" then
            local v41 = __v[1]._1
            return regex_equal_30(v40, v41)
        else
            return false
        end
    end
end

function make_cat_29(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8i0" then
        return Uh8i0()
    else
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8i0" then
            return Uh8i0()
        else
            local __v = { v0 }
            if __v[1] ~= nil and __v[1].tag == "Uh8i1" then
                return v1
            else
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Uh8i1" then
                    return v0
                else
                    local __v = { v0 }
                    if __v[1] ~= nil and __v[1].tag == "Uh8i4" then
                        local v12 = __v[1]._1
                        local v13 = __v[1]._2
                        local v14 = make_cat_29(v13, v1)
                        return Uh8i4(v12, v14)
                    elseif __v[1] ~= nil and __v[1].tag == "Uh8i5" then
                        local v4 = __v[1]._1
                        local __v = { v1 }
                        if __v[1] ~= nil and __v[1].tag == "Uh8i5" then
                            local v5 = __v[1]._1
                            local v6 = regex_equal_30(v4, v5)
                            if v6 then
                                return Uh8i5(v4)
                            else
                                return Uh8i4(v0, v1)
                            end
                        else
                            return Uh8i4(v0, v1)
                        end
                    else
                        return Uh8i4(v0, v1)
                    end
                end
            end
        end
    end
end

function make_star_31(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8i0" then
        return Uh8i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i1" then
        return Uh8i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i5" then
        local v3 = __v[1]._1
        return Uh8i5(v3)
    else
        return Uh8i5(v0)
    end
end

function normalize_25(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
        local v5 = __v[1]._1
        local v6 = __v[1]._2
        local v7 = normalize_25(v5)
        local v8 = normalize_25(v6)
        return make_alt_26(v7, v8)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i4" then
        local v10 = __v[1]._1
        local v11 = __v[1]._2
        local v12 = normalize_25(v10)
        local v13 = normalize_25(v11)
        return make_cat_29(v12, v13)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i2" then
        local v3 = __v[1]._1
        return Uh8i2(v3)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i0" then
        return Uh8i0()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i1" then
        return Uh8i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i5" then
        local v15 = __v[1]._1
        local v16 = normalize_25(v15)
        return make_star_31(v16)
    end
end

function nullable_33(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
        local v5 = __v[1]._1
        local v6 = __v[1]._2
        local v7 = nullable_33(v5)
        local v8 = nullable_33(v6)
        local __v = { v7 }
        if __v[1] ~= nil and __v[1].tag == "Us5i0" then
            return Us5i0()
        else
            local __v = { v8 }
            if __v[1] ~= nil and __v[1].tag == "Us5i0" then
                return Us5i0()
            else
                local __v = { v7 }
                if __v[1] ~= nil and __v[1].tag == "Us5i1" then
                    local __v = { v8 }
                    if __v[1] ~= nil and __v[1].tag == "Us5i1" then
                        return Us5i1()
                    end
                end
            end
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i4" then
        local v16 = __v[1]._1
        local v17 = __v[1]._2
        local v18 = nullable_33(v16)
        local v19 = nullable_33(v17)
        local __v = { v18 }
        if __v[1] ~= nil and __v[1].tag == "Us5i0" then
            local __v = { v19 }
            if __v[1] ~= nil and __v[1].tag == "Us5i0" then
                return Us5i0()
            else
                return Us5i1()
            end
        else
            return Us5i1()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i2" then
        local v3 = __v[1]._1
        return Us5i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i0" then
        return Us5i1()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i1" then
        return Us5i0()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i5" then
        local v25 = __v[1]._1
        return Us5i0()
    end
end

function derivative_32(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8i3" then
        local v25 = __v[1]._1
        local v26 = __v[1]._2
        local v27 = derivative_32(v25, v1)
        local v28 = derivative_32(v26, v1)
        return make_alt_26(v27, v28)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i4" then
        local v30 = __v[1]._1
        local v31 = __v[1]._2
        local v32 = nullable_33(v30)
        local __v = { v32 }
        if __v[1] ~= nil and __v[1].tag == "Us5i1" then
            local v37 = derivative_32(v30, v1)
            return make_cat_29(v37, v31)
        elseif __v[1] ~= nil and __v[1].tag == "Us5i0" then
            local v33 = derivative_32(v30, v1)
            local v34 = make_cat_29(v33, v31)
            local v35 = derivative_32(v31, v1)
            return make_alt_26(v34, v35)
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i2" then
        local v4 = __v[1]._1
        local getv20 = function()
            local __v = { v4 }
            if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                    return Us3i1()
                else
                    return Us3i0()
                end
            else
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Us1i0" then
                    return Us3i2()
                else
                    local __v = { v4 }
                    if __v[1] ~= nil and __v[1].tag == "Us1i1" then
                        local __v = { v1 }
                        if __v[1] ~= nil and __v[1].tag == "Us1i1" then
                            return Us3i1()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                            return Us3i0()
                        end
                    elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                        local __v = { v1 }
                        if __v[1] ~= nil and __v[1].tag == "Us1i1" then
                            return Us3i2()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1i2" then
                            return Us3i1()
                        end
                    end
                end
            end
        end
        local v20 = getv20()
        local getv21 = function()
            local __v = { v20 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return true
            else
                return false
            end
        end
        local v21 = getv21()
        if v21 then
            return Uh8i1()
        else
            return Uh8i0()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i0" then
        return Uh8i0()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i1" then
        return Uh8i0()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8i5" then
        local v41 = __v[1]._1
        local v42 = derivative_32(v41, v1)
        local v43 = make_star_31(v41)
        return make_cat_29(v42, v43)
    end
end

function canonical_derivative_24(v0, v1)
    local v2 = normalize_25(v0)
    local v3 = derivative_32(v2, v1)
    return normalize_25(v3)
end

function accepts_23(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh4i1" then
        local v6 = __v[1]._1
        local v7 = __v[1]._2
        local v8 = canonical_derivative_24(v0, v6)
        return accepts_23(v8, v7)
    elseif __v[1] ~= nil and __v[1].tag == "Uh4i0" then
        local v2 = normalize_25(v0)
        local v3 = nullable_33(v2)
        local __v = { v3 }
        if __v[1] ~= nil and __v[1].tag == "Us5i1" then
            return false
        elseif __v[1] ~= nil and __v[1].tag == "Us5i0" then
            return true
        end
    end
end

function loop_21(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh5i1" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = 2
        local v5 = loop_22(v4, v2)
        local getv11 = function()
            local __v = { v5 }
            if __v[1] ~= nil and __v[1].tag == "Us4i0" then
                return accepts_23(v0, v2)
            elseif __v[1] ~= nil and __v[1].tag == "Us4i2" then
                return false
            elseif __v[1] ~= nil and __v[1].tag == "Us4i1" then
                local v7 = accepts_23(v0, v2)
                local v8 = v7 == false
                return v8
            end
        end
        local v11 = getv11()
        if v11 then
            return loop_21(v0, v3)
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh5i0" then
        return true
    end
end

function loop_34(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh6i1" then
        local v7 = __v[1]._1
        local v8 = __v[1]._2
        local getv11 = function()
            local __v = { v7 }
            if __v[1] ~= nil and __v[1].tag == "Us2i0" then
                return Us3i1()
            else
                return Us3i2()
            end
        end
        local v11 = getv11()
        local getv12 = function()
            local __v = { v11 }
            if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                return true
            else
                return false
            end
        end
        local v12 = getv12()
        local getv21 = function()
            if v12 then
                return 0
            else
                local getv18 = function()
                    local __v = { v7 }
                    if __v[1] ~= nil and __v[1].tag == "Us2i0" then
                        return Us3i0()
                    elseif __v[1] ~= nil and __v[1].tag == "Us2i1" then
                        return Us3i1()
                    elseif __v[1] ~= nil and __v[1].tag == "Us2i2" then
                        return Us3i2()
                    end
                end
                local v18 = getv18()
                local getv19 = function()
                    local __v = { v18 }
                    if __v[1] ~= nil and __v[1].tag == "Us3i1" then
                        return true
                    else
                        return false
                    end
                end
                local v19 = getv19()
                if v19 then
                    return 1
                else
                    return -1
                end
            end
        end
        local v21 = getv21()
        local v22 = v21 < 0
        if v22 then
            return Us4i2()
        else
            local v24 = v0 == 0
            local getv28 = function()
                if v24 then
                    local v25 = v21 == 0
                    return 0
                else
                    local v26 = v21 == 0
                    if v26 then
                        return 1
                    else
                        return 0
                    end
                end
            end
            local v28 = getv28()
            return loop_34(v28, v8)
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh6i0" then
        local v2 = v0 == 0
        local v3 = v2 == false
        if v3 then
            return Us4i0()
        else
            return Us4i1()
        end
    end
end

local v0 = Us0i0()
local v1 = Us0i1()
local v2 = Uh0i0()
local v3 = Uh0i1(v1, v2)
local v4 = Uh0i1(v0, v3)
local v5 = input_singletons_from_symbols_0(v4)
local v6 = Uh1i0()
local v7 = Uh2i1(v6, v5)
local v8 = Us0i0()
local v9 = Us0i1()
local v10 = Uh0i0()
local v11 = Uh0i1(v9, v10)
local v12 = Uh0i1(v8, v11)
local v13 = Us0i0()
local v14 = Us0i1()
local v15 = Uh0i0()
local v16 = Uh0i1(v14, v15)
local v17 = Uh0i1(v13, v16)
local v18 = input_singletons_from_symbols_0(v17)
local v19 = input_prepend_symbols_to_corpus_1(v12, v18)
local v20 = input_list_append_3(v7, v19)
local v21 = Us1i0()
local v22 = Us1i1()
local v23 = Us1i2()
local v24 = Uh3i0()
local v25 = Uh3i1(v23, v24)
local v26 = Uh3i1(v22, v25)
local v27 = Uh3i1(v21, v26)
local v28 = input_singletons_from_symbols_4(v27)
local v29 = Uh4i0()
local v30 = Uh5i1(v29, v28)
local v31 = Us1i0()
local v32 = Us1i1()
local v33 = Us1i2()
local v34 = Uh3i0()
local v35 = Uh3i1(v33, v34)
local v36 = Uh3i1(v32, v35)
local v37 = Uh3i1(v31, v36)
local v38 = Us1i0()
local v39 = Us1i1()
local v40 = Us1i2()
local v41 = Uh3i0()
local v42 = Uh3i1(v40, v41)
local v43 = Uh3i1(v39, v42)
local v44 = Uh3i1(v38, v43)
local v45 = input_singletons_from_symbols_4(v44)
local v46 = input_prepend_symbols_to_corpus_5(v37, v45)
local v47 = input_list_append_7(v30, v46)
local v48 = Us2i2()
local v49 = Uh6i0()
local v50 = Uh6i1(v48, v49)
local v51 = Us0i0()
local v52 = Uh7i2(v51)
local v53 = Us0i1()
local v54 = Uh7i2(v53)
local v55 = Uh7i3(v52, v54)
local v56 = Uh7i5(v55)
local v57 = Us0i0()
local v58 = Uh7i2(v57)
local v59 = Uh7i4(v56, v58)
local v60 = loop_8(v59, v20)
local getv75 = function()
    if v60 then
        local v61 = Us1i0()
        local v62 = Uh8i2(v61)
        local v63 = Us1i1()
        local v64 = Uh8i2(v63)
        local v65 = Uh8i3(v62, v64)
        local v66 = Uh8i5(v65)
        local v67 = Us1i2()
        local v68 = Uh8i2(v67)
        local v69 = Uh8i4(v66, v68)
        local v70 = loop_21(v69, v47)
        if v70 then
            local v71 = 1
            local v72 = loop_34(v71, v50)
            local __v = { v72 }
            if __v[1] ~= nil and __v[1].tag == "Us4i2" then
                return true
            else
                return false
            end
        else
            return false
        end
    else
        return false
    end
end
local v75 = getv75()
if v75 then
    return 0
else
    return 1
end
