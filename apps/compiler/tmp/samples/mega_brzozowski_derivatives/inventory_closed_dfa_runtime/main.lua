local Us0_BitZero, Us0_BitOne, Uh0_SymbolListNil, Uh0_SymbolListCons, Uh1_InputEmpty, Uh1_InputCons, Uh2_InputListNil, Uh2_InputListCons, Us1_TriA, Us1_TriB, Us1_TriC, Uh3_SymbolListNil, Uh3_SymbolListCons, Uh4_InputEmpty, Uh4_InputCons, Uh5_InputListNil, Uh5_InputListCons, Us2_ModelA, Us2_ModelB, Us2_ModelC, Uh6_InputEmpty, Uh6_InputCons, Uh7_RegexEmpty, Uh7_RegexEpsilon, Uh7_RegexChar, Uh7_RegexAlt, Uh7_RegexCat, Uh7_RegexStar, Us3_SymbolLess, Us3_SymbolSame, Us3_SymbolGreater, Us4_InventoryDfaAccepted, Us4_InventoryDfaRejected, Us4_InventoryDfaInputOutsideInventory, Us5_Nullable, Us5_NonNullable, Uh8_RegexEmpty, Uh8_RegexEpsilon, Uh8_RegexChar, Uh8_RegexAlt, Uh8_RegexCat, Uh8_RegexStar, input_singletons_from_symbols_0, input_prepend_symbol_to_corpus_2, input_list_append_3, input_prepend_symbols_to_corpus_1, input_singletons_from_symbols_4, input_prepend_symbol_to_corpus_6, input_list_append_7, input_prepend_symbols_to_corpus_5, loop_9, regex_compare_15, alt_insert_sorted_14, make_alt_13, regex_equal_17, make_cat_16, make_star_18, normalize_12, nullable_20, derivative_19, canonical_derivative_11, accepts_10, loop_8, loop_22, regex_compare_28, alt_insert_sorted_27, make_alt_26, regex_equal_30, make_cat_29, make_star_31, normalize_25, nullable_33, derivative_32, canonical_derivative_24, accepts_23, loop_21, loop_34
function Us0_BitZero() return { tag = "Us0_BitZero" } end
function Us0_BitOne() return { tag = "Us0_BitOne" } end

function Uh0_SymbolListNil() return { tag = "Uh0_SymbolListNil" } end
function Uh0_SymbolListCons(v0, v1) return { tag = "Uh0_SymbolListCons",  _1 = v0,  _2 = v1 } end

function Uh1_InputEmpty() return { tag = "Uh1_InputEmpty" } end
function Uh1_InputCons(v0, v1) return { tag = "Uh1_InputCons",  _1 = v0,  _2 = v1 } end

function Uh2_InputListNil() return { tag = "Uh2_InputListNil" } end
function Uh2_InputListCons(v0, v1) return { tag = "Uh2_InputListCons",  _1 = v0,  _2 = v1 } end

function Us1_TriA() return { tag = "Us1_TriA" } end
function Us1_TriB() return { tag = "Us1_TriB" } end
function Us1_TriC() return { tag = "Us1_TriC" } end

function Uh3_SymbolListNil() return { tag = "Uh3_SymbolListNil" } end
function Uh3_SymbolListCons(v0, v1) return { tag = "Uh3_SymbolListCons",  _1 = v0,  _2 = v1 } end

function Uh4_InputEmpty() return { tag = "Uh4_InputEmpty" } end
function Uh4_InputCons(v0, v1) return { tag = "Uh4_InputCons",  _1 = v0,  _2 = v1 } end

function Uh5_InputListNil() return { tag = "Uh5_InputListNil" } end
function Uh5_InputListCons(v0, v1) return { tag = "Uh5_InputListCons",  _1 = v0,  _2 = v1 } end

function Us2_ModelA() return { tag = "Us2_ModelA" } end
function Us2_ModelB() return { tag = "Us2_ModelB" } end
function Us2_ModelC() return { tag = "Us2_ModelC" } end

function Uh6_InputEmpty() return { tag = "Uh6_InputEmpty" } end
function Uh6_InputCons(v0, v1) return { tag = "Uh6_InputCons",  _1 = v0,  _2 = v1 } end

function Uh7_RegexEmpty() return { tag = "Uh7_RegexEmpty" } end
function Uh7_RegexEpsilon() return { tag = "Uh7_RegexEpsilon" } end
function Uh7_RegexChar(v0) return { tag = "Uh7_RegexChar",  _1 = v0 } end
function Uh7_RegexAlt(v0, v1) return { tag = "Uh7_RegexAlt",  _1 = v0,  _2 = v1 } end
function Uh7_RegexCat(v0, v1) return { tag = "Uh7_RegexCat",  _1 = v0,  _2 = v1 } end
function Uh7_RegexStar(v0) return { tag = "Uh7_RegexStar",  _1 = v0 } end

function Us3_SymbolLess() return { tag = "Us3_SymbolLess" } end
function Us3_SymbolSame() return { tag = "Us3_SymbolSame" } end
function Us3_SymbolGreater() return { tag = "Us3_SymbolGreater" } end

function Us4_InventoryDfaAccepted() return { tag = "Us4_InventoryDfaAccepted" } end
function Us4_InventoryDfaRejected() return { tag = "Us4_InventoryDfaRejected" } end
function Us4_InventoryDfaInputOutsideInventory() return { tag = "Us4_InventoryDfaInputOutsideInventory" } end

function Us5_Nullable() return { tag = "Us5_Nullable" } end
function Us5_NonNullable() return { tag = "Us5_NonNullable" } end

function Uh8_RegexEmpty() return { tag = "Uh8_RegexEmpty" } end
function Uh8_RegexEpsilon() return { tag = "Uh8_RegexEpsilon" } end
function Uh8_RegexChar(v0) return { tag = "Uh8_RegexChar",  _1 = v0 } end
function Uh8_RegexAlt(v0, v1) return { tag = "Uh8_RegexAlt",  _1 = v0,  _2 = v1 } end
function Uh8_RegexCat(v0, v1) return { tag = "Uh8_RegexCat",  _1 = v0,  _2 = v1 } end
function Uh8_RegexStar(v0) return { tag = "Uh8_RegexStar",  _1 = v0 } end

function input_singletons_from_symbols_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0_SymbolListCons" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = input_singletons_from_symbols_0(v3)
        local v5 = Uh1_InputEmpty()
        local v6 = Uh1_InputCons(v2, v5)
        return Uh2_InputListCons(v6, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh0_SymbolListNil" then
        return Uh2_InputListNil()
    end
end

function input_prepend_symbol_to_corpus_2(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh2_InputListCons" then
        local v3 = __v[1]._1
        local v4 = __v[1]._2
        local v5 = input_prepend_symbol_to_corpus_2(v0, v4)
        local v6 = Uh1_InputCons(v0, v3)
        return Uh2_InputListCons(v6, v5)
    elseif __v[1] ~= nil and __v[1].tag == "Uh2_InputListNil" then
        return Uh2_InputListNil()
    end
end

function input_list_append_3(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh2_InputListCons" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = input_list_append_3(v3, v1)
        return Uh2_InputListCons(v2, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh2_InputListNil" then
        return v1
    end
end

function input_prepend_symbols_to_corpus_1(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0_SymbolListCons" then
        local v3 = __v[1]._1
        local v4 = __v[1]._2
        local v5 = input_prepend_symbol_to_corpus_2(v3, v1)
        local v6 = input_prepend_symbols_to_corpus_1(v4, v1)
        return input_list_append_3(v5, v6)
    elseif __v[1] ~= nil and __v[1].tag == "Uh0_SymbolListNil" then
        return Uh2_InputListNil()
    end
end

function input_singletons_from_symbols_4(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh3_SymbolListCons" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = input_singletons_from_symbols_4(v3)
        local v5 = Uh4_InputEmpty()
        local v6 = Uh4_InputCons(v2, v5)
        return Uh5_InputListCons(v6, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh3_SymbolListNil" then
        return Uh5_InputListNil()
    end
end

function input_prepend_symbol_to_corpus_6(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh5_InputListCons" then
        local v3 = __v[1]._1
        local v4 = __v[1]._2
        local v5 = input_prepend_symbol_to_corpus_6(v0, v4)
        local v6 = Uh4_InputCons(v0, v3)
        return Uh5_InputListCons(v6, v5)
    elseif __v[1] ~= nil and __v[1].tag == "Uh5_InputListNil" then
        return Uh5_InputListNil()
    end
end

function input_list_append_7(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh5_InputListCons" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = input_list_append_7(v3, v1)
        return Uh5_InputListCons(v2, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh5_InputListNil" then
        return v1
    end
end

function input_prepend_symbols_to_corpus_5(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh3_SymbolListCons" then
        local v3 = __v[1]._1
        local v4 = __v[1]._2
        local v5 = input_prepend_symbol_to_corpus_6(v3, v1)
        local v6 = input_prepend_symbols_to_corpus_5(v4, v1)
        return input_list_append_7(v5, v6)
    elseif __v[1] ~= nil and __v[1].tag == "Uh3_SymbolListNil" then
        return Uh5_InputListNil()
    end
end

function loop_9(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh1_InputCons" then
        local v6 = __v[1]._1
        local v7 = __v[1]._2
        local getv11 = function()
            local __v = { v6 }
            if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                return Us3_SymbolGreater()
            elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                return Us3_SymbolSame()
            end
        end
        local v11 = getv11()
        local getv12 = function()
            local __v = { v11 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
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
                    if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                        return Us3_SymbolSame()
                    elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                        return Us3_SymbolLess()
                    end
                end
                local v16 = getv16()
                local getv17 = function()
                    local __v = { v16 }
                    if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
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
            return Us4_InventoryDfaInputOutsideInventory()
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
    elseif __v[1] ~= nil and __v[1].tag == "Uh1_InputEmpty" then
        local v2 = v0 == 0
        if v2 then
            return Us4_InventoryDfaAccepted()
        else
            return Us4_InventoryDfaRejected()
        end
    end
end

function regex_compare_15(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
        local v53 = __v[1]._1
        local v54 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
            local v55 = __v[1]._1
            local v56 = __v[1]._2
            local v57 = regex_compare_15(v53, v55)
            local __v = { v57 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
                return regex_compare_15(v54, v56)
            else
                return v57
            end
        else
            return Us3_SymbolGreater()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexCat" then
        local v28 = __v[1]._1
        local v29 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexCat" then
            local v34 = __v[1]._1
            local v35 = __v[1]._2
            local v36 = regex_compare_15(v28, v34)
            local __v = { v36 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
                return regex_compare_15(v29, v35)
            else
                return v36
            end
        elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexChar" then
            local v32 = __v[1]._1
            return Us3_SymbolGreater()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
            return Us3_SymbolGreater()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
            return Us3_SymbolGreater()
        else
            return Us3_SymbolLess()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexChar" then
        local v10 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexChar" then
            local v13 = __v[1]._1
            local __v = { v10 }
            if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                local __v = { v13 }
                if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                    return Us3_SymbolSame()
                elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                    return Us3_SymbolGreater()
                end
            elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                local __v = { v13 }
                if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                    return Us3_SymbolLess()
                elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                    return Us3_SymbolSame()
                end
            end
        elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
            return Us3_SymbolGreater()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
            return Us3_SymbolGreater()
        else
            return Us3_SymbolLess()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
            return Us3_SymbolSame()
        else
            return Us3_SymbolLess()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
            return Us3_SymbolGreater()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
            return Us3_SymbolSame()
        else
            return Us3_SymbolLess()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
        local v44 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
            local v45 = __v[1]._1
            local v46 = __v[1]._2
            return Us3_SymbolLess()
        elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
            local v48 = __v[1]._1
            return regex_compare_15(v44, v48)
        else
            return Us3_SymbolGreater()
        end
    end
end

function alt_insert_sorted_14(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = regex_compare_15(v0, v2)
        local __v = { v4 }
        if __v[1] ~= nil and __v[1].tag == "Us3_SymbolGreater" then
            local v6 = alt_insert_sorted_14(v0, v3)
            return Uh7_RegexAlt(v2, v6)
        elseif __v[1] ~= nil and __v[1].tag == "Us3_SymbolLess" then
            return Uh7_RegexAlt(v0, v1)
        elseif __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
            return v1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
        return v0
    else
        local v11 = regex_compare_15(v0, v1)
        local __v = { v11 }
        if __v[1] ~= nil and __v[1].tag == "Us3_SymbolGreater" then
            return Uh7_RegexAlt(v1, v0)
        elseif __v[1] ~= nil and __v[1].tag == "Us3_SymbolLess" then
            return Uh7_RegexAlt(v0, v1)
        elseif __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
            return v1
        end
    end
end

function make_alt_13(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = alt_insert_sorted_14(v2, v1)
        return make_alt_13(v3, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
        return v1
    else
        return alt_insert_sorted_14(v0, v1)
    end
end

function regex_equal_17(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
        local v18 = __v[1]._1
        local v19 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
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
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexCat" then
        local v26 = __v[1]._1
        local v27 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexCat" then
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
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexChar" then
        local v4 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexChar" then
            local v5 = __v[1]._1
            local getv15 = function()
                local __v = { v4 }
                if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                    local __v = { v5 }
                    if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                        return Us3_SymbolSame()
                    elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                        return Us3_SymbolGreater()
                    end
                elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                    local __v = { v5 }
                    if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                        return Us3_SymbolLess()
                    elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                        return Us3_SymbolSame()
                    end
                end
            end
            local v15 = getv15()
            local __v = { v15 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
                return true
            else
                return false
            end
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
            return true
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
            return true
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
        local v34 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
            local v35 = __v[1]._1
            return regex_equal_17(v34, v35)
        else
            return false
        end
    end
end

function make_cat_16(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
        return Uh7_RegexEmpty()
    else
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
            return Uh7_RegexEmpty()
        else
            local __v = { v0 }
            if __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
                return v1
            else
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
                    return v0
                else
                    local __v = { v0 }
                    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexCat" then
                        local v12 = __v[1]._1
                        local v13 = __v[1]._2
                        local v14 = make_cat_16(v13, v1)
                        return Uh7_RegexCat(v12, v14)
                    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
                        local v4 = __v[1]._1
                        local __v = { v1 }
                        if __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
                            local v5 = __v[1]._1
                            local v6 = regex_equal_17(v4, v5)
                            if v6 then
                                return Uh7_RegexStar(v4)
                            else
                                return Uh7_RegexCat(v0, v1)
                            end
                        else
                            return Uh7_RegexCat(v0, v1)
                        end
                    else
                        return Uh7_RegexCat(v0, v1)
                    end
                end
            end
        end
    end
end

function make_star_18(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
        return Uh7_RegexEpsilon()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
        return Uh7_RegexEpsilon()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
        local v3 = __v[1]._1
        return Uh7_RegexStar(v3)
    else
        return Uh7_RegexStar(v0)
    end
end

function normalize_12(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
        local v5 = __v[1]._1
        local v6 = __v[1]._2
        local v7 = normalize_12(v5)
        local v8 = normalize_12(v6)
        return make_alt_13(v7, v8)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexCat" then
        local v10 = __v[1]._1
        local v11 = __v[1]._2
        local v12 = normalize_12(v10)
        local v13 = normalize_12(v11)
        return make_cat_16(v12, v13)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexChar" then
        local v3 = __v[1]._1
        return Uh7_RegexChar(v3)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
        return Uh7_RegexEmpty()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
        return Uh7_RegexEpsilon()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
        local v15 = __v[1]._1
        local v16 = normalize_12(v15)
        return make_star_18(v16)
    end
end

function nullable_20(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
        local v5 = __v[1]._1
        local v6 = __v[1]._2
        local v7 = nullable_20(v5)
        local v8 = nullable_20(v6)
        local __v = { v7 }
        if __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
            return Us5_Nullable()
        else
            local __v = { v8 }
            if __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
                return Us5_Nullable()
            else
                local __v = { v7 }
                if __v[1] ~= nil and __v[1].tag == "Us5_NonNullable" then
                    local __v = { v8 }
                    if __v[1] ~= nil and __v[1].tag == "Us5_NonNullable" then
                        return Us5_NonNullable()
                    end
                end
            end
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexCat" then
        local v16 = __v[1]._1
        local v17 = __v[1]._2
        local v18 = nullable_20(v16)
        local v19 = nullable_20(v17)
        local __v = { v18 }
        if __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
            local __v = { v19 }
            if __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
                return Us5_Nullable()
            else
                return Us5_NonNullable()
            end
        else
            return Us5_NonNullable()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexChar" then
        local v3 = __v[1]._1
        return Us5_NonNullable()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
        return Us5_NonNullable()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
        return Us5_Nullable()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
        local v25 = __v[1]._1
        return Us5_Nullable()
    end
end

function derivative_19(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh7_RegexAlt" then
        local v19 = __v[1]._1
        local v20 = __v[1]._2
        local v21 = derivative_19(v19, v1)
        local v22 = derivative_19(v20, v1)
        return make_alt_13(v21, v22)
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexCat" then
        local v24 = __v[1]._1
        local v25 = __v[1]._2
        local v26 = nullable_20(v24)
        local __v = { v26 }
        if __v[1] ~= nil and __v[1].tag == "Us5_NonNullable" then
            local v31 = derivative_19(v24, v1)
            return make_cat_16(v31, v25)
        elseif __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
            local v27 = derivative_19(v24, v1)
            local v28 = make_cat_16(v27, v25)
            local v29 = derivative_19(v25, v1)
            return make_alt_13(v28, v29)
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexChar" then
        local v4 = __v[1]._1
        local getv14 = function()
            local __v = { v4 }
            if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                    return Us3_SymbolSame()
                elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                    return Us3_SymbolGreater()
                end
            elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Us0_BitOne" then
                    return Us3_SymbolLess()
                elseif __v[1] ~= nil and __v[1].tag == "Us0_BitZero" then
                    return Us3_SymbolSame()
                end
            end
        end
        local v14 = getv14()
        local getv15 = function()
            local __v = { v14 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
                return true
            else
                return false
            end
        end
        local v15 = getv15()
        if v15 then
            return Uh7_RegexEpsilon()
        else
            return Uh7_RegexEmpty()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEmpty" then
        return Uh7_RegexEmpty()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexEpsilon" then
        return Uh7_RegexEmpty()
    elseif __v[1] ~= nil and __v[1].tag == "Uh7_RegexStar" then
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
    if __v[1] ~= nil and __v[1].tag == "Uh1_InputCons" then
        local v6 = __v[1]._1
        local v7 = __v[1]._2
        local v8 = canonical_derivative_11(v0, v6)
        return accepts_10(v8, v7)
    elseif __v[1] ~= nil and __v[1].tag == "Uh1_InputEmpty" then
        local v2 = normalize_12(v0)
        local v3 = nullable_20(v2)
        local __v = { v3 }
        if __v[1] ~= nil and __v[1].tag == "Us5_NonNullable" then
            return false
        elseif __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
            return true
        end
    end
end

function loop_8(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh2_InputListCons" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = 1
        local v5 = loop_9(v4, v2)
        local getv11 = function()
            local __v = { v5 }
            if __v[1] ~= nil and __v[1].tag == "Us4_InventoryDfaAccepted" then
                return accepts_10(v0, v2)
            elseif __v[1] ~= nil and __v[1].tag == "Us4_InventoryDfaInputOutsideInventory" then
                return false
            elseif __v[1] ~= nil and __v[1].tag == "Us4_InventoryDfaRejected" then
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
    elseif __v[1] ~= nil and __v[1].tag == "Uh2_InputListNil" then
        return true
    end
end

function loop_22(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh4_InputCons" then
        local v8 = __v[1]._1
        local v9 = __v[1]._2
        local getv12 = function()
            local __v = { v8 }
            if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                return Us3_SymbolSame()
            else
                return Us3_SymbolGreater()
            end
        end
        local v12 = getv12()
        local getv13 = function()
            local __v = { v12 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
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
                    if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                        return Us3_SymbolLess()
                    elseif __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                        return Us3_SymbolSame()
                    elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                        return Us3_SymbolGreater()
                    end
                end
                local v19 = getv19()
                local getv20 = function()
                    local __v = { v19 }
                    if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
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
                        if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                            return Us3_SymbolLess()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                            return Us3_SymbolLess()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                            return Us3_SymbolSame()
                        end
                    end
                    local v26 = getv26()
                    local getv27 = function()
                        local __v = { v26 }
                        if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
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
            return Us4_InventoryDfaInputOutsideInventory()
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
    elseif __v[1] ~= nil and __v[1].tag == "Uh4_InputEmpty" then
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
            return Us4_InventoryDfaAccepted()
        else
            return Us4_InventoryDfaRejected()
        end
    end
end

function regex_compare_28(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
        local v59 = __v[1]._1
        local v60 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
            local v61 = __v[1]._1
            local v62 = __v[1]._2
            local v63 = regex_compare_28(v59, v61)
            local __v = { v63 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
                return regex_compare_28(v60, v62)
            else
                return v63
            end
        else
            return Us3_SymbolGreater()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexCat" then
        local v34 = __v[1]._1
        local v35 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexCat" then
            local v40 = __v[1]._1
            local v41 = __v[1]._2
            local v42 = regex_compare_28(v34, v40)
            local __v = { v42 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
                return regex_compare_28(v35, v41)
            else
                return v42
            end
        elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexChar" then
            local v38 = __v[1]._1
            return Us3_SymbolGreater()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
            return Us3_SymbolGreater()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
            return Us3_SymbolGreater()
        else
            return Us3_SymbolLess()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexChar" then
        local v10 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexChar" then
            local v13 = __v[1]._1
            local __v = { v10 }
            if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                local __v = { v13 }
                if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                    return Us3_SymbolSame()
                else
                    return Us3_SymbolLess()
                end
            else
                local __v = { v13 }
                if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                    return Us3_SymbolGreater()
                else
                    local __v = { v10 }
                    if __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                        local __v = { v13 }
                        if __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                            return Us3_SymbolSame()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                            return Us3_SymbolLess()
                        end
                    elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                        local __v = { v13 }
                        if __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                            return Us3_SymbolGreater()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                            return Us3_SymbolSame()
                        end
                    end
                end
            end
        elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
            return Us3_SymbolGreater()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
            return Us3_SymbolGreater()
        else
            return Us3_SymbolLess()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
            return Us3_SymbolSame()
        else
            return Us3_SymbolLess()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
            return Us3_SymbolGreater()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
            return Us3_SymbolSame()
        else
            return Us3_SymbolLess()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
        local v50 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
            local v51 = __v[1]._1
            local v52 = __v[1]._2
            return Us3_SymbolLess()
        elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
            local v54 = __v[1]._1
            return regex_compare_28(v50, v54)
        else
            return Us3_SymbolGreater()
        end
    end
end

function alt_insert_sorted_27(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = regex_compare_28(v0, v2)
        local __v = { v4 }
        if __v[1] ~= nil and __v[1].tag == "Us3_SymbolGreater" then
            local v6 = alt_insert_sorted_27(v0, v3)
            return Uh8_RegexAlt(v2, v6)
        elseif __v[1] ~= nil and __v[1].tag == "Us3_SymbolLess" then
            return Uh8_RegexAlt(v0, v1)
        elseif __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
            return v1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
        return v0
    else
        local v11 = regex_compare_28(v0, v1)
        local __v = { v11 }
        if __v[1] ~= nil and __v[1].tag == "Us3_SymbolGreater" then
            return Uh8_RegexAlt(v1, v0)
        elseif __v[1] ~= nil and __v[1].tag == "Us3_SymbolLess" then
            return Uh8_RegexAlt(v0, v1)
        elseif __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
            return v1
        end
    end
end

function make_alt_26(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = alt_insert_sorted_27(v2, v1)
        return make_alt_26(v3, v4)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
        return v1
    else
        return alt_insert_sorted_27(v0, v1)
    end
end

function regex_equal_30(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
        local v24 = __v[1]._1
        local v25 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
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
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexCat" then
        local v32 = __v[1]._1
        local v33 = __v[1]._2
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexCat" then
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
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexChar" then
        local v4 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexChar" then
            local v5 = __v[1]._1
            local getv21 = function()
                local __v = { v4 }
                if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                    local __v = { v5 }
                    if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                        return Us3_SymbolSame()
                    else
                        return Us3_SymbolLess()
                    end
                else
                    local __v = { v5 }
                    if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                        return Us3_SymbolGreater()
                    else
                        local __v = { v4 }
                        if __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                            local __v = { v5 }
                            if __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                                return Us3_SymbolSame()
                            elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                                return Us3_SymbolLess()
                            end
                        elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                            local __v = { v5 }
                            if __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                                return Us3_SymbolGreater()
                            elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                                return Us3_SymbolSame()
                            end
                        end
                    end
                end
            end
            local v21 = getv21()
            local __v = { v21 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
                return true
            else
                return false
            end
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
            return true
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
            return true
        else
            return false
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
        local v40 = __v[1]._1
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
            local v41 = __v[1]._1
            return regex_equal_30(v40, v41)
        else
            return false
        end
    end
end

function make_cat_29(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
        return Uh8_RegexEmpty()
    else
        local __v = { v1 }
        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
            return Uh8_RegexEmpty()
        else
            local __v = { v0 }
            if __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
                return v1
            else
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
                    return v0
                else
                    local __v = { v0 }
                    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexCat" then
                        local v12 = __v[1]._1
                        local v13 = __v[1]._2
                        local v14 = make_cat_29(v13, v1)
                        return Uh8_RegexCat(v12, v14)
                    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
                        local v4 = __v[1]._1
                        local __v = { v1 }
                        if __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
                            local v5 = __v[1]._1
                            local v6 = regex_equal_30(v4, v5)
                            if v6 then
                                return Uh8_RegexStar(v4)
                            else
                                return Uh8_RegexCat(v0, v1)
                            end
                        else
                            return Uh8_RegexCat(v0, v1)
                        end
                    else
                        return Uh8_RegexCat(v0, v1)
                    end
                end
            end
        end
    end
end

function make_star_31(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
        return Uh8_RegexEpsilon()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
        return Uh8_RegexEpsilon()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
        local v3 = __v[1]._1
        return Uh8_RegexStar(v3)
    else
        return Uh8_RegexStar(v0)
    end
end

function normalize_25(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
        local v5 = __v[1]._1
        local v6 = __v[1]._2
        local v7 = normalize_25(v5)
        local v8 = normalize_25(v6)
        return make_alt_26(v7, v8)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexCat" then
        local v10 = __v[1]._1
        local v11 = __v[1]._2
        local v12 = normalize_25(v10)
        local v13 = normalize_25(v11)
        return make_cat_29(v12, v13)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexChar" then
        local v3 = __v[1]._1
        return Uh8_RegexChar(v3)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
        return Uh8_RegexEmpty()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
        return Uh8_RegexEpsilon()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
        local v15 = __v[1]._1
        local v16 = normalize_25(v15)
        return make_star_31(v16)
    end
end

function nullable_33(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
        local v5 = __v[1]._1
        local v6 = __v[1]._2
        local v7 = nullable_33(v5)
        local v8 = nullable_33(v6)
        local __v = { v7 }
        if __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
            return Us5_Nullable()
        else
            local __v = { v8 }
            if __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
                return Us5_Nullable()
            else
                local __v = { v7 }
                if __v[1] ~= nil and __v[1].tag == "Us5_NonNullable" then
                    local __v = { v8 }
                    if __v[1] ~= nil and __v[1].tag == "Us5_NonNullable" then
                        return Us5_NonNullable()
                    end
                end
            end
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexCat" then
        local v16 = __v[1]._1
        local v17 = __v[1]._2
        local v18 = nullable_33(v16)
        local v19 = nullable_33(v17)
        local __v = { v18 }
        if __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
            local __v = { v19 }
            if __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
                return Us5_Nullable()
            else
                return Us5_NonNullable()
            end
        else
            return Us5_NonNullable()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexChar" then
        local v3 = __v[1]._1
        return Us5_NonNullable()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
        return Us5_NonNullable()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
        return Us5_Nullable()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
        local v25 = __v[1]._1
        return Us5_Nullable()
    end
end

function derivative_32(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh8_RegexAlt" then
        local v25 = __v[1]._1
        local v26 = __v[1]._2
        local v27 = derivative_32(v25, v1)
        local v28 = derivative_32(v26, v1)
        return make_alt_26(v27, v28)
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexCat" then
        local v30 = __v[1]._1
        local v31 = __v[1]._2
        local v32 = nullable_33(v30)
        local __v = { v32 }
        if __v[1] ~= nil and __v[1].tag == "Us5_NonNullable" then
            local v37 = derivative_32(v30, v1)
            return make_cat_29(v37, v31)
        elseif __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
            local v33 = derivative_32(v30, v1)
            local v34 = make_cat_29(v33, v31)
            local v35 = derivative_32(v31, v1)
            return make_alt_26(v34, v35)
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexChar" then
        local v4 = __v[1]._1
        local getv20 = function()
            local __v = { v4 }
            if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                    return Us3_SymbolSame()
                else
                    return Us3_SymbolLess()
                end
            else
                local __v = { v1 }
                if __v[1] ~= nil and __v[1].tag == "Us1_TriA" then
                    return Us3_SymbolGreater()
                else
                    local __v = { v4 }
                    if __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                        local __v = { v1 }
                        if __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                            return Us3_SymbolSame()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                            return Us3_SymbolLess()
                        end
                    elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                        local __v = { v1 }
                        if __v[1] ~= nil and __v[1].tag == "Us1_TriB" then
                            return Us3_SymbolGreater()
                        elseif __v[1] ~= nil and __v[1].tag == "Us1_TriC" then
                            return Us3_SymbolSame()
                        end
                    end
                end
            end
        end
        local v20 = getv20()
        local getv21 = function()
            local __v = { v20 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
                return true
            else
                return false
            end
        end
        local v21 = getv21()
        if v21 then
            return Uh8_RegexEpsilon()
        else
            return Uh8_RegexEmpty()
        end
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEmpty" then
        return Uh8_RegexEmpty()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexEpsilon" then
        return Uh8_RegexEmpty()
    elseif __v[1] ~= nil and __v[1].tag == "Uh8_RegexStar" then
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
    if __v[1] ~= nil and __v[1].tag == "Uh4_InputCons" then
        local v6 = __v[1]._1
        local v7 = __v[1]._2
        local v8 = canonical_derivative_24(v0, v6)
        return accepts_23(v8, v7)
    elseif __v[1] ~= nil and __v[1].tag == "Uh4_InputEmpty" then
        local v2 = normalize_25(v0)
        local v3 = nullable_33(v2)
        local __v = { v3 }
        if __v[1] ~= nil and __v[1].tag == "Us5_NonNullable" then
            return false
        elseif __v[1] ~= nil and __v[1].tag == "Us5_Nullable" then
            return true
        end
    end
end

function loop_21(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh5_InputListCons" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = 2
        local v5 = loop_22(v4, v2)
        local getv11 = function()
            local __v = { v5 }
            if __v[1] ~= nil and __v[1].tag == "Us4_InventoryDfaAccepted" then
                return accepts_23(v0, v2)
            elseif __v[1] ~= nil and __v[1].tag == "Us4_InventoryDfaInputOutsideInventory" then
                return false
            elseif __v[1] ~= nil and __v[1].tag == "Us4_InventoryDfaRejected" then
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
    elseif __v[1] ~= nil and __v[1].tag == "Uh5_InputListNil" then
        return true
    end
end

function loop_34(v0, v1)
    local __v = { v1 }
    if __v[1] ~= nil and __v[1].tag == "Uh6_InputCons" then
        local v7 = __v[1]._1
        local v8 = __v[1]._2
        local getv11 = function()
            local __v = { v7 }
            if __v[1] ~= nil and __v[1].tag == "Us2_ModelA" then
                return Us3_SymbolSame()
            else
                return Us3_SymbolGreater()
            end
        end
        local v11 = getv11()
        local getv12 = function()
            local __v = { v11 }
            if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
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
                    if __v[1] ~= nil and __v[1].tag == "Us2_ModelA" then
                        return Us3_SymbolLess()
                    elseif __v[1] ~= nil and __v[1].tag == "Us2_ModelB" then
                        return Us3_SymbolSame()
                    elseif __v[1] ~= nil and __v[1].tag == "Us2_ModelC" then
                        return Us3_SymbolGreater()
                    end
                end
                local v18 = getv18()
                local getv19 = function()
                    local __v = { v18 }
                    if __v[1] ~= nil and __v[1].tag == "Us3_SymbolSame" then
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
            return Us4_InventoryDfaInputOutsideInventory()
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
    elseif __v[1] ~= nil and __v[1].tag == "Uh6_InputEmpty" then
        local v2 = v0 == 0
        local v3 = v2 == false
        if v3 then
            return Us4_InventoryDfaAccepted()
        else
            return Us4_InventoryDfaRejected()
        end
    end
end

local v0 = Us0_BitZero()
local v1 = Us0_BitOne()
local v2 = Uh0_SymbolListNil()
local v3 = Uh0_SymbolListCons(v1, v2)
local v4 = Uh0_SymbolListCons(v0, v3)
local v5 = input_singletons_from_symbols_0(v4)
local v6 = Uh1_InputEmpty()
local v7 = Uh2_InputListCons(v6, v5)
local v8 = Us0_BitZero()
local v9 = Us0_BitOne()
local v10 = Uh0_SymbolListNil()
local v11 = Uh0_SymbolListCons(v9, v10)
local v12 = Uh0_SymbolListCons(v8, v11)
local v13 = Us0_BitZero()
local v14 = Us0_BitOne()
local v15 = Uh0_SymbolListNil()
local v16 = Uh0_SymbolListCons(v14, v15)
local v17 = Uh0_SymbolListCons(v13, v16)
local v18 = input_singletons_from_symbols_0(v17)
local v19 = input_prepend_symbols_to_corpus_1(v12, v18)
local v20 = input_list_append_3(v7, v19)
local v21 = Us1_TriA()
local v22 = Us1_TriB()
local v23 = Us1_TriC()
local v24 = Uh3_SymbolListNil()
local v25 = Uh3_SymbolListCons(v23, v24)
local v26 = Uh3_SymbolListCons(v22, v25)
local v27 = Uh3_SymbolListCons(v21, v26)
local v28 = input_singletons_from_symbols_4(v27)
local v29 = Uh4_InputEmpty()
local v30 = Uh5_InputListCons(v29, v28)
local v31 = Us1_TriA()
local v32 = Us1_TriB()
local v33 = Us1_TriC()
local v34 = Uh3_SymbolListNil()
local v35 = Uh3_SymbolListCons(v33, v34)
local v36 = Uh3_SymbolListCons(v32, v35)
local v37 = Uh3_SymbolListCons(v31, v36)
local v38 = Us1_TriA()
local v39 = Us1_TriB()
local v40 = Us1_TriC()
local v41 = Uh3_SymbolListNil()
local v42 = Uh3_SymbolListCons(v40, v41)
local v43 = Uh3_SymbolListCons(v39, v42)
local v44 = Uh3_SymbolListCons(v38, v43)
local v45 = input_singletons_from_symbols_4(v44)
local v46 = input_prepend_symbols_to_corpus_5(v37, v45)
local v47 = input_list_append_7(v30, v46)
local v48 = Us2_ModelC()
local v49 = Uh6_InputEmpty()
local v50 = Uh6_InputCons(v48, v49)
local v51 = Us0_BitZero()
local v52 = Uh7_RegexChar(v51)
local v53 = Us0_BitOne()
local v54 = Uh7_RegexChar(v53)
local v55 = Uh7_RegexAlt(v52, v54)
local v56 = Uh7_RegexStar(v55)
local v57 = Us0_BitZero()
local v58 = Uh7_RegexChar(v57)
local v59 = Uh7_RegexCat(v56, v58)
local v60 = loop_8(v59, v20)
local getv75 = function()
    if v60 then
        local v61 = Us1_TriA()
        local v62 = Uh8_RegexChar(v61)
        local v63 = Us1_TriB()
        local v64 = Uh8_RegexChar(v63)
        local v65 = Uh8_RegexAlt(v62, v64)
        local v66 = Uh8_RegexStar(v65)
        local v67 = Us1_TriC()
        local v68 = Uh8_RegexChar(v67)
        local v69 = Uh8_RegexCat(v66, v68)
        local v70 = loop_21(v69, v47)
        if v70 then
            local v71 = 1
            local v72 = loop_34(v71, v50)
            local __v = { v72 }
            if __v[1] ~= nil and __v[1].tag == "Us4_InventoryDfaInputOutsideInventory" then
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
