local Us0_BitZero, Us0_BitOne, Uh0_InputCons, Us1_TriA, Us1_TriB, Us1_TriC, Uh1_InputCons, Uh2_RegexChar, Uh2_RegexAlt, Uh2_RegexCat, Uh2_RegexStar, Us2_SymbolLess, Us2_SymbolSame, Us2_SymbolGreater, Us3_Nullable, Us3_NonNullable, Uh3_RegexChar, Uh3_RegexAlt, Uh3_RegexCat, Uh3_RegexStar, Us4_BitMatcherRaw, Us5_BitMatcherDecided, regex_compare_5, alt_insert_sorted_4, make_alt_3, regex_equal_7, make_cat_6, make_star_8, normalize_2, nullable_10, derivative_9, canonical_derivative_1, accepts_0, regex_compare_16, alt_insert_sorted_15, make_alt_14, regex_equal_18, make_cat_17, make_star_19, normalize_13, nullable_21, derivative_20, canonical_derivative_12, accepts_11, decide_bit_match_22, bit_match_value_23
function Us0_BitZero() return { tag = "Us0_BitZero" } end
function Us0_BitOne() return { tag = "Us0_BitOne" } end

Uh0_InputEmpty = (function() local shared = { tag = "Uh0_InputEmpty" } return function() return shared end end)()
function Uh0_InputCons(v0, v1) return { tag = "Uh0_InputCons",  _1 = v0,  _2 = v1 } end

function Us1_TriA() return { tag = "Us1_TriA" } end
function Us1_TriB() return { tag = "Us1_TriB" } end
function Us1_TriC() return { tag = "Us1_TriC" } end

Uh1_InputEmpty = (function() local shared = { tag = "Uh1_InputEmpty" } return function() return shared end end)()
function Uh1_InputCons(v0, v1) return { tag = "Uh1_InputCons",  _1 = v0,  _2 = v1 } end

Uh2_RegexEmpty = (function() local shared = { tag = "Uh2_RegexEmpty" } return function() return shared end end)()
Uh2_RegexEpsilon = (function() local shared = { tag = "Uh2_RegexEpsilon" } return function() return shared end end)()
function Uh2_RegexChar(v0) return { tag = "Uh2_RegexChar",  _1 = v0 } end
function Uh2_RegexAlt(v0, v1) return { tag = "Uh2_RegexAlt",  _1 = v0,  _2 = v1 } end
function Uh2_RegexCat(v0, v1) return { tag = "Uh2_RegexCat",  _1 = v0,  _2 = v1 } end
function Uh2_RegexStar(v0) return { tag = "Uh2_RegexStar",  _1 = v0 } end

function Us2_SymbolLess() return { tag = "Us2_SymbolLess" } end
function Us2_SymbolSame() return { tag = "Us2_SymbolSame" } end
function Us2_SymbolGreater() return { tag = "Us2_SymbolGreater" } end

function Us3_Nullable() return { tag = "Us3_Nullable" } end
function Us3_NonNullable() return { tag = "Us3_NonNullable" } end

Uh3_RegexEmpty = (function() local shared = { tag = "Uh3_RegexEmpty" } return function() return shared end end)()
Uh3_RegexEpsilon = (function() local shared = { tag = "Uh3_RegexEpsilon" } return function() return shared end end)()
function Uh3_RegexChar(v0) return { tag = "Uh3_RegexChar",  _1 = v0 } end
function Uh3_RegexAlt(v0, v1) return { tag = "Uh3_RegexAlt",  _1 = v0,  _2 = v1 } end
function Uh3_RegexCat(v0, v1) return { tag = "Uh3_RegexCat",  _1 = v0,  _2 = v1 } end
function Uh3_RegexStar(v0) return { tag = "Uh3_RegexStar",  _1 = v0 } end

function Us4_BitMatcherRaw(v0, v1) return { tag = "Us4_BitMatcherRaw",  _1 = v0,  _2 = v1 } end

function Us5_BitMatcherDecided(v0, v1, v2) return { tag = "Us5_BitMatcherDecided",  _1 = v0,  _2 = v1,  _3 = v2 } end

function regex_compare_5(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v53 = v0._1
        local v54 = v0._2
        if v1 ~= nil and v1.tag == "Uh2_RegexAlt" then
            local v55 = v1._1
            local v56 = v1._2
            local v57 = regex_compare_5(v53, v55)
            if v57 ~= nil and v57.tag == "Us2_SymbolSame" then
                return regex_compare_5(v54, v56)
            else
                return v57
            end
        else
            return Us2_SymbolGreater()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v28 = v0._1
        local v29 = v0._2
        if v1 ~= nil and v1.tag == "Uh2_RegexCat" then
            local v34 = v1._1
            local v35 = v1._2
            local v36 = regex_compare_5(v28, v34)
            if v36 ~= nil and v36.tag == "Us2_SymbolSame" then
                return regex_compare_5(v29, v35)
            else
                return v36
            end
        elseif v1 ~= nil and v1.tag == "Uh2_RegexChar" then
            local v32 = v1._1
            return Us2_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Us2_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
            return Us2_SymbolGreater()
        else
            return Us2_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v10 = v0._1
        if v1 ~= nil and v1.tag == "Uh2_RegexChar" then
            local v13 = v1._1
            if v10 ~= nil and v10.tag == "Us0_BitOne" then
                if v13 ~= nil and v13.tag == "Us0_BitOne" then
                    return Us2_SymbolSame()
                elseif v13 ~= nil and v13.tag == "Us0_BitZero" then
                    return Us2_SymbolGreater()
                end
            elseif v10 ~= nil and v10.tag == "Us0_BitZero" then
                if v13 ~= nil and v13.tag == "Us0_BitOne" then
                    return Us2_SymbolLess()
                elseif v13 ~= nil and v13.tag == "Us0_BitZero" then
                    return Us2_SymbolSame()
                end
            end
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Us2_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
            return Us2_SymbolGreater()
        else
            return Us2_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        if v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Us2_SymbolSame()
        else
            return Us2_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        if v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Us2_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
            return Us2_SymbolSame()
        else
            return Us2_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v44 = v0._1
        if v1 ~= nil and v1.tag == "Uh2_RegexAlt" then
            local v45 = v1._1
            local v46 = v1._2
            return Us2_SymbolLess()
        elseif v1 ~= nil and v1.tag == "Uh2_RegexStar" then
            local v48 = v1._1
            return regex_compare_5(v44, v48)
        else
            return Us2_SymbolGreater()
        end
    end
end

function alt_insert_sorted_4(v0, v1)
    if v1 ~= nil and v1.tag == "Uh2_RegexAlt" then
        local v2 = v1._1
        local v3 = v1._2
        local v4 = regex_compare_5(v0, v2)
        if v4 ~= nil and v4.tag == "Us2_SymbolGreater" then
            local v6 = alt_insert_sorted_4(v0, v3)
            return Uh2_RegexAlt(v2, v6)
        elseif v4 ~= nil and v4.tag == "Us2_SymbolLess" then
            return Uh2_RegexAlt(v0, v1)
        elseif v4 ~= nil and v4.tag == "Us2_SymbolSame" then
            return v1
        end
    elseif v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
        return v0
    else
        local v11 = regex_compare_5(v0, v1)
        if v11 ~= nil and v11.tag == "Us2_SymbolGreater" then
            return Uh2_RegexAlt(v1, v0)
        elseif v11 ~= nil and v11.tag == "Us2_SymbolLess" then
            return Uh2_RegexAlt(v0, v1)
        elseif v11 ~= nil and v11.tag == "Us2_SymbolSame" then
            return v1
        end
    end
end

function make_alt_3(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v2 = v0._1
        local v3 = v0._2
        local v4 = alt_insert_sorted_4(v2, v1)
        return make_alt_3(v3, v4)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return v1
    else
        return alt_insert_sorted_4(v0, v1)
    end
end

function regex_equal_7(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v18 = v0._1
        local v19 = v0._2
        if v1 ~= nil and v1.tag == "Uh2_RegexAlt" then
            local v20 = v1._1
            local v21 = v1._2
            local v22 = regex_equal_7(v18, v20)
            if v22 then
                return regex_equal_7(v19, v21)
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v26 = v0._1
        local v27 = v0._2
        if v1 ~= nil and v1.tag == "Uh2_RegexCat" then
            local v28 = v1._1
            local v29 = v1._2
            local v30 = regex_equal_7(v26, v28)
            if v30 then
                return regex_equal_7(v27, v29)
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v4 = v0._1
        if v1 ~= nil and v1.tag == "Uh2_RegexChar" then
            local v5 = v1._1
            local getv15 = function()
                if v4 ~= nil and v4.tag == "Us0_BitOne" then
                    if v5 ~= nil and v5.tag == "Us0_BitOne" then
                        return Us2_SymbolSame()
                    elseif v5 ~= nil and v5.tag == "Us0_BitZero" then
                        return Us2_SymbolGreater()
                    end
                elseif v4 ~= nil and v4.tag == "Us0_BitZero" then
                    if v5 ~= nil and v5.tag == "Us0_BitOne" then
                        return Us2_SymbolLess()
                    elseif v5 ~= nil and v5.tag == "Us0_BitZero" then
                        return Us2_SymbolSame()
                    end
                end
            end
            local v15 = getv15()
            if v15 ~= nil and v15.tag == "Us2_SymbolSame" then
                return true
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        if v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return true
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        if v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
            return true
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v34 = v0._1
        if v1 ~= nil and v1.tag == "Uh2_RegexStar" then
            local v35 = v1._1
            return regex_equal_7(v34, v35)
        else
            return false
        end
    end
end

function make_cat_6(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Uh2_RegexEmpty()
    else
        if v1 ~= nil and v1.tag == "Uh2_RegexEmpty" then
            return Uh2_RegexEmpty()
        else
            if v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
                return v1
            else
                if v1 ~= nil and v1.tag == "Uh2_RegexEpsilon" then
                    return v0
                else
                    if v0 ~= nil and v0.tag == "Uh2_RegexCat" then
                        local v12 = v0._1
                        local v13 = v0._2
                        local v14 = make_cat_6(v13, v1)
                        return Uh2_RegexCat(v12, v14)
                    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
                        local v4 = v0._1
                        if v1 ~= nil and v1.tag == "Uh2_RegexStar" then
                            local v5 = v1._1
                            local v6 = regex_equal_7(v4, v5)
                            if v6 then
                                return Uh2_RegexStar(v4)
                            else
                                return Uh2_RegexCat(v0, v1)
                            end
                        else
                            return Uh2_RegexCat(v0, v1)
                        end
                    else
                        return Uh2_RegexCat(v0, v1)
                    end
                end
            end
        end
    end
end

function make_star_8(v0)
    if v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Uh2_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        return Uh2_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v3 = v0._1
        return Uh2_RegexStar(v3)
    else
        return Uh2_RegexStar(v0)
    end
end

function normalize_2(v0)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v5 = v0._1
        local v6 = v0._2
        local v7 = normalize_2(v5)
        local v8 = normalize_2(v6)
        return make_alt_3(v7, v8)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v10 = v0._1
        local v11 = v0._2
        local v12 = normalize_2(v10)
        local v13 = normalize_2(v11)
        return make_cat_6(v12, v13)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v3 = v0._1
        return Uh2_RegexChar(v3)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Uh2_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        return Uh2_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v15 = v0._1
        local v16 = normalize_2(v15)
        return make_star_8(v16)
    end
end

function nullable_10(v0)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v5 = v0._1
        local v6 = v0._2
        local v7 = nullable_10(v5)
        local v8 = nullable_10(v6)
        if v7 ~= nil and v7.tag == "Us3_Nullable" then
            return Us3_Nullable()
        else
            if v8 ~= nil and v8.tag == "Us3_Nullable" then
                return Us3_Nullable()
            else
                if v7 ~= nil and v7.tag == "Us3_NonNullable" then
                    if v8 ~= nil and v8.tag == "Us3_NonNullable" then
                        return Us3_NonNullable()
                    end
                end
            end
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v16 = v0._1
        local v17 = v0._2
        local v18 = nullable_10(v16)
        local v19 = nullable_10(v17)
        if v18 ~= nil and v18.tag == "Us3_Nullable" then
            if v19 ~= nil and v19.tag == "Us3_Nullable" then
                return Us3_Nullable()
            else
                return Us3_NonNullable()
            end
        else
            return Us3_NonNullable()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v3 = v0._1
        return Us3_NonNullable()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Us3_NonNullable()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        return Us3_Nullable()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v25 = v0._1
        return Us3_Nullable()
    end
end

function derivative_9(v0, v1)
    if v0 ~= nil and v0.tag == "Uh2_RegexAlt" then
        local v19 = v0._1
        local v20 = v0._2
        local v21 = derivative_9(v19, v1)
        local v22 = derivative_9(v20, v1)
        return make_alt_3(v21, v22)
    elseif v0 ~= nil and v0.tag == "Uh2_RegexCat" then
        local v24 = v0._1
        local v25 = v0._2
        local v26 = nullable_10(v24)
        if v26 ~= nil and v26.tag == "Us3_NonNullable" then
            local v31 = derivative_9(v24, v1)
            return make_cat_6(v31, v25)
        elseif v26 ~= nil and v26.tag == "Us3_Nullable" then
            local v27 = derivative_9(v24, v1)
            local v28 = make_cat_6(v27, v25)
            local v29 = derivative_9(v25, v1)
            return make_alt_3(v28, v29)
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexChar" then
        local v4 = v0._1
        local getv14 = function()
            if v4 ~= nil and v4.tag == "Us0_BitOne" then
                if v1 ~= nil and v1.tag == "Us0_BitOne" then
                    return Us2_SymbolSame()
                elseif v1 ~= nil and v1.tag == "Us0_BitZero" then
                    return Us2_SymbolGreater()
                end
            elseif v4 ~= nil and v4.tag == "Us0_BitZero" then
                if v1 ~= nil and v1.tag == "Us0_BitOne" then
                    return Us2_SymbolLess()
                elseif v1 ~= nil and v1.tag == "Us0_BitZero" then
                    return Us2_SymbolSame()
                end
            end
        end
        local v14 = getv14()
        local getv15 = function()
            if v14 ~= nil and v14.tag == "Us2_SymbolSame" then
                return true
            else
                return false
            end
        end
        local v15 = getv15()
        if v15 then
            return Uh2_RegexEpsilon()
        else
            return Uh2_RegexEmpty()
        end
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEmpty" then
        return Uh2_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexEpsilon" then
        return Uh2_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh2_RegexStar" then
        local v35 = v0._1
        local v36 = derivative_9(v35, v1)
        local v37 = make_star_8(v35)
        return make_cat_6(v36, v37)
    end
end

function canonical_derivative_1(v0, v1)
    local v2 = normalize_2(v0)
    local v3 = derivative_9(v2, v1)
    return normalize_2(v3)
end

function accepts_0(v0, v1)
    if v1 ~= nil and v1.tag == "Uh0_InputCons" then
        local v6 = v1._1
        local v7 = v1._2
        local v8 = canonical_derivative_1(v0, v6)
        return accepts_0(v8, v7)
    elseif v1 ~= nil and v1.tag == "Uh0_InputEmpty" then
        local v2 = normalize_2(v0)
        local v3 = nullable_10(v2)
        if v3 ~= nil and v3.tag == "Us3_NonNullable" then
            return false
        elseif v3 ~= nil and v3.tag == "Us3_Nullable" then
            return true
        end
    end
end

function regex_compare_16(v0, v1)
    if v0 ~= nil and v0.tag == "Uh3_RegexAlt" then
        local v59 = v0._1
        local v60 = v0._2
        if v1 ~= nil and v1.tag == "Uh3_RegexAlt" then
            local v61 = v1._1
            local v62 = v1._2
            local v63 = regex_compare_16(v59, v61)
            if v63 ~= nil and v63.tag == "Us2_SymbolSame" then
                return regex_compare_16(v60, v62)
            else
                return v63
            end
        else
            return Us2_SymbolGreater()
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexCat" then
        local v34 = v0._1
        local v35 = v0._2
        if v1 ~= nil and v1.tag == "Uh3_RegexCat" then
            local v40 = v1._1
            local v41 = v1._2
            local v42 = regex_compare_16(v34, v40)
            if v42 ~= nil and v42.tag == "Us2_SymbolSame" then
                return regex_compare_16(v35, v41)
            else
                return v42
            end
        elseif v1 ~= nil and v1.tag == "Uh3_RegexChar" then
            local v38 = v1._1
            return Us2_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh3_RegexEmpty" then
            return Us2_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh3_RegexEpsilon" then
            return Us2_SymbolGreater()
        else
            return Us2_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexChar" then
        local v10 = v0._1
        if v1 ~= nil and v1.tag == "Uh3_RegexChar" then
            local v13 = v1._1
            if v10 ~= nil and v10.tag == "Us1_TriA" then
                if v13 ~= nil and v13.tag == "Us1_TriA" then
                    return Us2_SymbolSame()
                else
                    return Us2_SymbolLess()
                end
            else
                if v13 ~= nil and v13.tag == "Us1_TriA" then
                    return Us2_SymbolGreater()
                else
                    if v10 ~= nil and v10.tag == "Us1_TriB" then
                        if v13 ~= nil and v13.tag == "Us1_TriB" then
                            return Us2_SymbolSame()
                        elseif v13 ~= nil and v13.tag == "Us1_TriC" then
                            return Us2_SymbolLess()
                        end
                    elseif v10 ~= nil and v10.tag == "Us1_TriC" then
                        if v13 ~= nil and v13.tag == "Us1_TriB" then
                            return Us2_SymbolGreater()
                        elseif v13 ~= nil and v13.tag == "Us1_TriC" then
                            return Us2_SymbolSame()
                        end
                    end
                end
            end
        elseif v1 ~= nil and v1.tag == "Uh3_RegexEmpty" then
            return Us2_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh3_RegexEpsilon" then
            return Us2_SymbolGreater()
        else
            return Us2_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEmpty" then
        if v1 ~= nil and v1.tag == "Uh3_RegexEmpty" then
            return Us2_SymbolSame()
        else
            return Us2_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEpsilon" then
        if v1 ~= nil and v1.tag == "Uh3_RegexEmpty" then
            return Us2_SymbolGreater()
        elseif v1 ~= nil and v1.tag == "Uh3_RegexEpsilon" then
            return Us2_SymbolSame()
        else
            return Us2_SymbolLess()
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexStar" then
        local v50 = v0._1
        if v1 ~= nil and v1.tag == "Uh3_RegexAlt" then
            local v51 = v1._1
            local v52 = v1._2
            return Us2_SymbolLess()
        elseif v1 ~= nil and v1.tag == "Uh3_RegexStar" then
            local v54 = v1._1
            return regex_compare_16(v50, v54)
        else
            return Us2_SymbolGreater()
        end
    end
end

function alt_insert_sorted_15(v0, v1)
    if v1 ~= nil and v1.tag == "Uh3_RegexAlt" then
        local v2 = v1._1
        local v3 = v1._2
        local v4 = regex_compare_16(v0, v2)
        if v4 ~= nil and v4.tag == "Us2_SymbolGreater" then
            local v6 = alt_insert_sorted_15(v0, v3)
            return Uh3_RegexAlt(v2, v6)
        elseif v4 ~= nil and v4.tag == "Us2_SymbolLess" then
            return Uh3_RegexAlt(v0, v1)
        elseif v4 ~= nil and v4.tag == "Us2_SymbolSame" then
            return v1
        end
    elseif v1 ~= nil and v1.tag == "Uh3_RegexEmpty" then
        return v0
    else
        local v11 = regex_compare_16(v0, v1)
        if v11 ~= nil and v11.tag == "Us2_SymbolGreater" then
            return Uh3_RegexAlt(v1, v0)
        elseif v11 ~= nil and v11.tag == "Us2_SymbolLess" then
            return Uh3_RegexAlt(v0, v1)
        elseif v11 ~= nil and v11.tag == "Us2_SymbolSame" then
            return v1
        end
    end
end

function make_alt_14(v0, v1)
    if v0 ~= nil and v0.tag == "Uh3_RegexAlt" then
        local v2 = v0._1
        local v3 = v0._2
        local v4 = alt_insert_sorted_15(v2, v1)
        return make_alt_14(v3, v4)
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEmpty" then
        return v1
    else
        return alt_insert_sorted_15(v0, v1)
    end
end

function regex_equal_18(v0, v1)
    if v0 ~= nil and v0.tag == "Uh3_RegexAlt" then
        local v24 = v0._1
        local v25 = v0._2
        if v1 ~= nil and v1.tag == "Uh3_RegexAlt" then
            local v26 = v1._1
            local v27 = v1._2
            local v28 = regex_equal_18(v24, v26)
            if v28 then
                return regex_equal_18(v25, v27)
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexCat" then
        local v32 = v0._1
        local v33 = v0._2
        if v1 ~= nil and v1.tag == "Uh3_RegexCat" then
            local v34 = v1._1
            local v35 = v1._2
            local v36 = regex_equal_18(v32, v34)
            if v36 then
                return regex_equal_18(v33, v35)
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexChar" then
        local v4 = v0._1
        if v1 ~= nil and v1.tag == "Uh3_RegexChar" then
            local v5 = v1._1
            local getv21 = function()
                if v4 ~= nil and v4.tag == "Us1_TriA" then
                    if v5 ~= nil and v5.tag == "Us1_TriA" then
                        return Us2_SymbolSame()
                    else
                        return Us2_SymbolLess()
                    end
                else
                    if v5 ~= nil and v5.tag == "Us1_TriA" then
                        return Us2_SymbolGreater()
                    else
                        if v4 ~= nil and v4.tag == "Us1_TriB" then
                            if v5 ~= nil and v5.tag == "Us1_TriB" then
                                return Us2_SymbolSame()
                            elseif v5 ~= nil and v5.tag == "Us1_TriC" then
                                return Us2_SymbolLess()
                            end
                        elseif v4 ~= nil and v4.tag == "Us1_TriC" then
                            if v5 ~= nil and v5.tag == "Us1_TriB" then
                                return Us2_SymbolGreater()
                            elseif v5 ~= nil and v5.tag == "Us1_TriC" then
                                return Us2_SymbolSame()
                            end
                        end
                    end
                end
            end
            local v21 = getv21()
            if v21 ~= nil and v21.tag == "Us2_SymbolSame" then
                return true
            else
                return false
            end
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEmpty" then
        if v1 ~= nil and v1.tag == "Uh3_RegexEmpty" then
            return true
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEpsilon" then
        if v1 ~= nil and v1.tag == "Uh3_RegexEpsilon" then
            return true
        else
            return false
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexStar" then
        local v40 = v0._1
        if v1 ~= nil and v1.tag == "Uh3_RegexStar" then
            local v41 = v1._1
            return regex_equal_18(v40, v41)
        else
            return false
        end
    end
end

function make_cat_17(v0, v1)
    if v0 ~= nil and v0.tag == "Uh3_RegexEmpty" then
        return Uh3_RegexEmpty()
    else
        if v1 ~= nil and v1.tag == "Uh3_RegexEmpty" then
            return Uh3_RegexEmpty()
        else
            if v0 ~= nil and v0.tag == "Uh3_RegexEpsilon" then
                return v1
            else
                if v1 ~= nil and v1.tag == "Uh3_RegexEpsilon" then
                    return v0
                else
                    if v0 ~= nil and v0.tag == "Uh3_RegexCat" then
                        local v12 = v0._1
                        local v13 = v0._2
                        local v14 = make_cat_17(v13, v1)
                        return Uh3_RegexCat(v12, v14)
                    elseif v0 ~= nil and v0.tag == "Uh3_RegexStar" then
                        local v4 = v0._1
                        if v1 ~= nil and v1.tag == "Uh3_RegexStar" then
                            local v5 = v1._1
                            local v6 = regex_equal_18(v4, v5)
                            if v6 then
                                return Uh3_RegexStar(v4)
                            else
                                return Uh3_RegexCat(v0, v1)
                            end
                        else
                            return Uh3_RegexCat(v0, v1)
                        end
                    else
                        return Uh3_RegexCat(v0, v1)
                    end
                end
            end
        end
    end
end

function make_star_19(v0)
    if v0 ~= nil and v0.tag == "Uh3_RegexEmpty" then
        return Uh3_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEpsilon" then
        return Uh3_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh3_RegexStar" then
        local v3 = v0._1
        return Uh3_RegexStar(v3)
    else
        return Uh3_RegexStar(v0)
    end
end

function normalize_13(v0)
    if v0 ~= nil and v0.tag == "Uh3_RegexAlt" then
        local v5 = v0._1
        local v6 = v0._2
        local v7 = normalize_13(v5)
        local v8 = normalize_13(v6)
        return make_alt_14(v7, v8)
    elseif v0 ~= nil and v0.tag == "Uh3_RegexCat" then
        local v10 = v0._1
        local v11 = v0._2
        local v12 = normalize_13(v10)
        local v13 = normalize_13(v11)
        return make_cat_17(v12, v13)
    elseif v0 ~= nil and v0.tag == "Uh3_RegexChar" then
        local v3 = v0._1
        return Uh3_RegexChar(v3)
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEmpty" then
        return Uh3_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEpsilon" then
        return Uh3_RegexEpsilon()
    elseif v0 ~= nil and v0.tag == "Uh3_RegexStar" then
        local v15 = v0._1
        local v16 = normalize_13(v15)
        return make_star_19(v16)
    end
end

function nullable_21(v0)
    if v0 ~= nil and v0.tag == "Uh3_RegexAlt" then
        local v5 = v0._1
        local v6 = v0._2
        local v7 = nullable_21(v5)
        local v8 = nullable_21(v6)
        if v7 ~= nil and v7.tag == "Us3_Nullable" then
            return Us3_Nullable()
        else
            if v8 ~= nil and v8.tag == "Us3_Nullable" then
                return Us3_Nullable()
            else
                if v7 ~= nil and v7.tag == "Us3_NonNullable" then
                    if v8 ~= nil and v8.tag == "Us3_NonNullable" then
                        return Us3_NonNullable()
                    end
                end
            end
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexCat" then
        local v16 = v0._1
        local v17 = v0._2
        local v18 = nullable_21(v16)
        local v19 = nullable_21(v17)
        if v18 ~= nil and v18.tag == "Us3_Nullable" then
            if v19 ~= nil and v19.tag == "Us3_Nullable" then
                return Us3_Nullable()
            else
                return Us3_NonNullable()
            end
        else
            return Us3_NonNullable()
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexChar" then
        local v3 = v0._1
        return Us3_NonNullable()
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEmpty" then
        return Us3_NonNullable()
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEpsilon" then
        return Us3_Nullable()
    elseif v0 ~= nil and v0.tag == "Uh3_RegexStar" then
        local v25 = v0._1
        return Us3_Nullable()
    end
end

function derivative_20(v0, v1)
    if v0 ~= nil and v0.tag == "Uh3_RegexAlt" then
        local v25 = v0._1
        local v26 = v0._2
        local v27 = derivative_20(v25, v1)
        local v28 = derivative_20(v26, v1)
        return make_alt_14(v27, v28)
    elseif v0 ~= nil and v0.tag == "Uh3_RegexCat" then
        local v30 = v0._1
        local v31 = v0._2
        local v32 = nullable_21(v30)
        if v32 ~= nil and v32.tag == "Us3_NonNullable" then
            local v37 = derivative_20(v30, v1)
            return make_cat_17(v37, v31)
        elseif v32 ~= nil and v32.tag == "Us3_Nullable" then
            local v33 = derivative_20(v30, v1)
            local v34 = make_cat_17(v33, v31)
            local v35 = derivative_20(v31, v1)
            return make_alt_14(v34, v35)
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexChar" then
        local v4 = v0._1
        local getv20 = function()
            if v4 ~= nil and v4.tag == "Us1_TriA" then
                if v1 ~= nil and v1.tag == "Us1_TriA" then
                    return Us2_SymbolSame()
                else
                    return Us2_SymbolLess()
                end
            else
                if v1 ~= nil and v1.tag == "Us1_TriA" then
                    return Us2_SymbolGreater()
                else
                    if v4 ~= nil and v4.tag == "Us1_TriB" then
                        if v1 ~= nil and v1.tag == "Us1_TriB" then
                            return Us2_SymbolSame()
                        elseif v1 ~= nil and v1.tag == "Us1_TriC" then
                            return Us2_SymbolLess()
                        end
                    elseif v4 ~= nil and v4.tag == "Us1_TriC" then
                        if v1 ~= nil and v1.tag == "Us1_TriB" then
                            return Us2_SymbolGreater()
                        elseif v1 ~= nil and v1.tag == "Us1_TriC" then
                            return Us2_SymbolSame()
                        end
                    end
                end
            end
        end
        local v20 = getv20()
        local getv21 = function()
            if v20 ~= nil and v20.tag == "Us2_SymbolSame" then
                return true
            else
                return false
            end
        end
        local v21 = getv21()
        if v21 then
            return Uh3_RegexEpsilon()
        else
            return Uh3_RegexEmpty()
        end
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEmpty" then
        return Uh3_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh3_RegexEpsilon" then
        return Uh3_RegexEmpty()
    elseif v0 ~= nil and v0.tag == "Uh3_RegexStar" then
        local v41 = v0._1
        local v42 = derivative_20(v41, v1)
        local v43 = make_star_19(v41)
        return make_cat_17(v42, v43)
    end
end

function canonical_derivative_12(v0, v1)
    local v2 = normalize_13(v0)
    local v3 = derivative_20(v2, v1)
    return normalize_13(v3)
end

function accepts_11(v0, v1)
    if v1 ~= nil and v1.tag == "Uh1_InputCons" then
        local v6 = v1._1
        local v7 = v1._2
        local v8 = canonical_derivative_12(v0, v6)
        return accepts_11(v8, v7)
    elseif v1 ~= nil and v1.tag == "Uh1_InputEmpty" then
        local v2 = normalize_13(v0)
        local v3 = nullable_21(v2)
        if v3 ~= nil and v3.tag == "Us3_NonNullable" then
            return false
        elseif v3 ~= nil and v3.tag == "Us3_Nullable" then
            return true
        end
    end
end

function decide_bit_match_22(v0)
    if v0 ~= nil and v0.tag == "Us4_BitMatcherRaw" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = accepts_0(v1, v2)
        return Us5_BitMatcherDecided(v1, v2, v3)
    end
end

function bit_match_value_23(v0)
    if v0 ~= nil and v0.tag == "Us5_BitMatcherDecided" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = v0._3
        return v3
    end
end

local v0 = Us0_BitOne()
local v1 = Us0_BitOne()
local v2 = Us0_BitZero()
local v3 = Uh0_InputEmpty()
local v4 = Uh0_InputCons(v2, v3)
local v5 = Uh0_InputCons(v1, v4)
local v6 = Uh0_InputCons(v0, v5)
local v7 = Us0_BitOne()
local v8 = Us0_BitOne()
local v9 = Us0_BitOne()
local v10 = Uh0_InputEmpty()
local v11 = Uh0_InputCons(v9, v10)
local v12 = Uh0_InputCons(v8, v11)
local v13 = Uh0_InputCons(v7, v12)
local v14 = Us1_TriA()
local v15 = Us1_TriA()
local v16 = Us1_TriA()
local v17 = Uh1_InputEmpty()
local v18 = Uh1_InputCons(v16, v17)
local v19 = Uh1_InputCons(v15, v18)
local v20 = Uh1_InputCons(v14, v19)
local v21 = Us1_TriA()
local v22 = Us1_TriA()
local v23 = Us1_TriB()
local v24 = Uh1_InputEmpty()
local v25 = Uh1_InputCons(v23, v24)
local v26 = Uh1_InputCons(v22, v25)
local v27 = Uh1_InputCons(v21, v26)
local v28 = Us0_BitZero()
local v29 = Uh2_RegexChar(v28)
local v30 = Us0_BitOne()
local v31 = Uh2_RegexChar(v30)
local v32 = Uh2_RegexAlt(v29, v31)
local v33 = Uh2_RegexStar(v32)
local v34 = Us0_BitZero()
local v35 = Uh2_RegexChar(v34)
local v36 = Uh2_RegexCat(v33, v35)
local v37 = accepts_0(v36, v6)
if v37 then
else
    _G.error("brzozowski-expected-true")
end
local v38 = Us0_BitZero()
local v39 = Uh2_RegexChar(v38)
local v40 = Us0_BitOne()
local v41 = Uh2_RegexChar(v40)
local v42 = Uh2_RegexAlt(v39, v41)
local v43 = Uh2_RegexStar(v42)
local v44 = Us0_BitZero()
local v45 = Uh2_RegexChar(v44)
local v46 = Uh2_RegexCat(v43, v45)
local v47 = accepts_0(v46, v13)
if v47 then
    _G.error("brzozowski-expected-false")
else
end
local v48 = Us1_TriA()
local v49 = Uh3_RegexChar(v48)
local v50 = Uh3_RegexStar(v49)
local v51 = accepts_11(v50, v20)
if v51 then
else
    _G.error("brzozowski-expected-true")
end
local v52 = Us1_TriA()
local v53 = Uh3_RegexChar(v52)
local v54 = Uh3_RegexStar(v53)
local v55 = accepts_11(v54, v27)
if v55 then
    _G.error("brzozowski-expected-false")
else
end
local v56 = Us0_BitZero()
local v57 = Uh2_RegexChar(v56)
local v58 = Us0_BitOne()
local v59 = Uh2_RegexChar(v58)
local v60 = Uh2_RegexAlt(v57, v59)
local v61 = Uh2_RegexStar(v60)
local v62 = Us0_BitZero()
local v63 = Uh2_RegexChar(v62)
local v64 = Uh2_RegexCat(v61, v63)
local v65 = Us4_BitMatcherRaw(v64, v6)
local v66 = decide_bit_match_22(v65)
local v67 = Us0_BitZero()
local v68 = Uh2_RegexChar(v67)
local v69 = Us0_BitOne()
local v70 = Uh2_RegexChar(v69)
local v71 = Uh2_RegexAlt(v68, v70)
local v72 = Uh2_RegexStar(v71)
local v73 = Us0_BitZero()
local v74 = Uh2_RegexChar(v73)
local v75 = Uh2_RegexCat(v72, v74)
local v76 = Us4_BitMatcherRaw(v75, v13)
local v77 = decide_bit_match_22(v76)
local v78 = bit_match_value_23(v66)
if v78 then
else
    _G.error("brzozowski-expected-true")
end
local v79 = bit_match_value_23(v77)
if v79 then
    _G.error("brzozowski-expected-false")
else
end
return 0
