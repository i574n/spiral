import main_types.{Uh0RegexAlt, Uh0RegexCat, Uh0RegexChar, Uh0RegexStar, Us0BitOne, Us0BitZero}
import main_part1.{loop_0, loop_13, loop_15, loop_17, spiral_array_create_filled}
import main_part2.{interned_node_26, interned_of_regex_raw_28, loop_18, loop_20, loop_22, loop_24, loop_25}
import main_part3.{loop_32, loop_36}

pub fn main() {
    let v0 = 200
    let v1 = 32
    let v2 = Us0BitZero
    let v3 = Uh0RegexChar(v2)
    let v4 = Us0BitOne
    let v5 = Uh0RegexChar(v4)
    let v6 = Uh0RegexAlt(v3, v5)
    let v7 = Uh0RegexStar(v6)
    let v8 = Us0BitZero
    let v9 = Uh0RegexChar(v8)
    let v10 = Uh0RegexCat(v7, v9)
    let v11 = Us0BitZero
    let v12 = Uh0RegexChar(v11)
    let v13 = Us0BitOne
    let v14 = Uh0RegexChar(v13)
    let v15 = Uh0RegexAlt(v12, v14)
    let v16 = Uh0RegexStar(v15)
    let v17 = Us0BitOne
    let v18 = Uh0RegexChar(v17)
    let v19 = Us0BitZero
    let v20 = Uh0RegexChar(v19)
    let v21 = Us0BitOne
    let v22 = Uh0RegexChar(v21)
    let v23 = Uh0RegexAlt(v20, v22)
    let v24 = Us0BitZero
    let v25 = Uh0RegexChar(v24)
    let v26 = Us0BitOne
    let v27 = Uh0RegexChar(v26)
    let v28 = Uh0RegexAlt(v25, v27)
    let v29 = Us0BitZero
    let v30 = Uh0RegexChar(v29)
    let v31 = Us0BitOne
    let v32 = Uh0RegexChar(v31)
    let v33 = Uh0RegexAlt(v30, v32)
    let v34 = Uh0RegexCat(v28, v33)
    let v35 = Uh0RegexCat(v23, v34)
    let v36 = Uh0RegexCat(v18, v35)
    let v37 = Uh0RegexCat(v16, v36)
    let v38 = 1
    let v39 = 0
    let v40 = loop_0(v10, v1, v0, v38, v39)
    let v41 = loop_0(v37, v1, v0, v38, v39)
    let v42 = 16
    let v43 = Us0BitZero
    let v44 = Uh0RegexChar(v43)
    let v45 = Us0BitZero
    let v46 = Uh0RegexChar(v45)
    let v47 = Us0BitZero
    let v48 = Uh0RegexChar(v47)
    let v49 = Uh0RegexCat(v46, v48)
    let v50 = Uh0RegexAlt(v44, v49)
    let v51 = Uh0RegexStar(v50)
    let v52 = Us0BitOne
    let v53 = Uh0RegexChar(v52)
    let v54 = Uh0RegexCat(v51, v53)
    let v55 = 0
    let v56 = 1
    let v57 = loop_13(v54, v42, v56, v55)
    let v58 = 200
    let v59 = 32
    let v60 = Us0BitZero
    let v61 = Uh0RegexChar(v60)
    let v62 = Us0BitOne
    let v63 = Uh0RegexChar(v62)
    let v64 = Uh0RegexAlt(v61, v63)
    let v65 = Uh0RegexStar(v64)
    let v66 = Us0BitZero
    let v67 = Uh0RegexChar(v66)
    let v68 = Uh0RegexCat(v65, v67)
    let v69 = Us0BitZero
    let v70 = Uh0RegexChar(v69)
    let v71 = Us0BitOne
    let v72 = Uh0RegexChar(v71)
    let v73 = Uh0RegexAlt(v70, v72)
    let v74 = Uh0RegexStar(v73)
    let v75 = Us0BitOne
    let v76 = Uh0RegexChar(v75)
    let v77 = Us0BitZero
    let v78 = Uh0RegexChar(v77)
    let v79 = Us0BitOne
    let v80 = Uh0RegexChar(v79)
    let v81 = Uh0RegexAlt(v78, v80)
    let v82 = Us0BitZero
    let v83 = Uh0RegexChar(v82)
    let v84 = Us0BitOne
    let v85 = Uh0RegexChar(v84)
    let v86 = Uh0RegexAlt(v83, v85)
    let v87 = Us0BitZero
    let v88 = Uh0RegexChar(v87)
    let v89 = Us0BitOne
    let v90 = Uh0RegexChar(v89)
    let v91 = Uh0RegexAlt(v88, v90)
    let v92 = Uh0RegexCat(v86, v91)
    let v93 = Uh0RegexCat(v81, v92)
    let v94 = Uh0RegexCat(v76, v93)
    let v95 = Uh0RegexCat(v74, v94)
    let v96 = 1
    let v97 = 0
    let v98 = loop_15(v68, v59, v58, v96, v97)
    let v99 = loop_15(v95, v59, v58, v96, v97)
    let v100 = 16
    let v101 = Us0BitZero
    let v102 = Uh0RegexChar(v101)
    let v103 = Us0BitZero
    let v104 = Uh0RegexChar(v103)
    let v105 = Us0BitZero
    let v106 = Uh0RegexChar(v105)
    let v107 = Uh0RegexCat(v104, v106)
    let v108 = Uh0RegexAlt(v102, v107)
    let v109 = Uh0RegexStar(v108)
    let v110 = Us0BitOne
    let v111 = Uh0RegexChar(v110)
    let v112 = Uh0RegexCat(v109, v111)
    let v113 = 0
    let v114 = 1
    let v115 = loop_17(v112, v100, v114, v113)
    let v116 = v40 == v98
    let v118 =
        case v116 {
            True -> {
                let v117 = v41 == v99
                v117
            }
            False -> {
                False
            }
        }
    let v120 =
        case v118 {
            True -> {
                let v119 = v57 == v115
                v119
            }
            False -> {
                False
            }
        }
    case v120 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-bench-engines-disagree"
        }
    }
    let v121 = 200
    let v122 = 32
    let v123 = 1
    let v124 = 0
    let v125 = loop_18(v122, v121, v123, v124)
    let v126 = loop_20(v122, v121, v123, v124)
    let v127 = 16
    let v128 = 0
    let v129 = 1
    let v130 = loop_22(v127, v129, v128)
    let v131 = v40 == v125
    let v133 =
        case v131 {
            True -> {
                let v132 = v41 == v126
                v132
            }
            False -> {
                False
            }
        }
    let v135 =
        case v133 {
            True -> {
                let v134 = v57 == v130
                v134
            }
            False -> {
                False
            }
        }
    case v135 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-bench-engines-disagree"
        }
    }
    let v136 = 200
    let v137 = 32
    let v138 = spiral_array_create_filled(4096, 0)
    let v139 = spiral_array_create_filled(4096, 0)
    let v140 = spiral_array_create_filled(4096, 0)
    let v141 = spiral_array_create_filled(4096, 0)
    let v142 = spiral_array_create_filled(8192, 0)
    let v143 = spiral_array_create_filled(8192, 0)
    let v144 = spiral_array_create_filled(1, 0)
    let v145 = 0
    loop_24(v142, v145)
    let v146 = 0
    loop_24(v143, v146)
    let v147 = 0
    loop_25(v144, v147)
    let v148 = 0
    let v149 = 0
    let v150 = 0
    let v151 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150)
    let v152 = 1
    let v153 = 0
    let v154 = 0
    let v155 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154)
    let v156 = v151 == 0
    let v158 =
        case v156 {
            True -> {
                let v157 = v155 == 1
                v157
            }
            False -> {
                False
            }
        }
    let #(v166, v167, v168, v169, v170, v171, v172) =
        case v158 {
            True -> {
                #(v138, v139, v140, v141, v142, v143, v144)
            }
            False -> {
                panic as "brzozowski-interned-store-init"
            }
        }
    let v173 = Us0BitZero
    let v174 = Uh0RegexChar(v173)
    let v175 = Us0BitOne
    let v176 = Uh0RegexChar(v175)
    let v177 = Uh0RegexAlt(v174, v176)
    let v178 = Uh0RegexStar(v177)
    let v179 = Us0BitZero
    let v180 = Uh0RegexChar(v179)
    let v181 = Uh0RegexCat(v178, v180)
    let v182 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v181)
    let v183 = 1
    let v184 = 0
    let v185 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184)
    let v186 = Us0BitZero
    let v187 = Uh0RegexChar(v186)
    let v188 = Us0BitOne
    let v189 = Uh0RegexChar(v188)
    let v190 = Uh0RegexAlt(v187, v189)
    let v191 = Uh0RegexStar(v190)
    let v192 = Us0BitOne
    let v193 = Uh0RegexChar(v192)
    let v194 = Us0BitZero
    let v195 = Uh0RegexChar(v194)
    let v196 = Us0BitOne
    let v197 = Uh0RegexChar(v196)
    let v198 = Uh0RegexAlt(v195, v197)
    let v199 = Us0BitZero
    let v200 = Uh0RegexChar(v199)
    let v201 = Us0BitOne
    let v202 = Uh0RegexChar(v201)
    let v203 = Uh0RegexAlt(v200, v202)
    let v204 = Us0BitZero
    let v205 = Uh0RegexChar(v204)
    let v206 = Us0BitOne
    let v207 = Uh0RegexChar(v206)
    let v208 = Uh0RegexAlt(v205, v207)
    let v209 = Uh0RegexCat(v203, v208)
    let v210 = Uh0RegexCat(v198, v209)
    let v211 = Uh0RegexCat(v193, v210)
    let v212 = Uh0RegexCat(v191, v211)
    let v213 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v212)
    let v214 = 1
    let v215 = 0
    let v216 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215)
    let v217 = 16
    let v218 = spiral_array_create_filled(4096, 0)
    let v219 = spiral_array_create_filled(4096, 0)
    let v220 = spiral_array_create_filled(4096, 0)
    let v221 = spiral_array_create_filled(4096, 0)
    let v222 = spiral_array_create_filled(8192, 0)
    let v223 = spiral_array_create_filled(8192, 0)
    let v224 = spiral_array_create_filled(1, 0)
    let v225 = 0
    loop_24(v222, v225)
    let v226 = 0
    loop_24(v223, v226)
    let v227 = 0
    loop_25(v224, v227)
    let v228 = 0
    let v229 = 0
    let v230 = 0
    let v231 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230)
    let v232 = 1
    let v233 = 0
    let v234 = 0
    let v235 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234)
    let v236 = v231 == 0
    let v238 =
        case v236 {
            True -> {
                let v237 = v235 == 1
                v237
            }
            False -> {
                False
            }
        }
    let #(v246, v247, v248, v249, v250, v251, v252) =
        case v238 {
            True -> {
                #(v218, v219, v220, v221, v222, v223, v224)
            }
            False -> {
                panic as "brzozowski-interned-store-init"
            }
        }
    let v253 = Us0BitZero
    let v254 = Uh0RegexChar(v253)
    let v255 = Us0BitZero
    let v256 = Uh0RegexChar(v255)
    let v257 = Us0BitZero
    let v258 = Uh0RegexChar(v257)
    let v259 = Uh0RegexCat(v256, v258)
    let v260 = Uh0RegexAlt(v254, v259)
    let v261 = Uh0RegexStar(v260)
    let v262 = Us0BitOne
    let v263 = Uh0RegexChar(v262)
    let v264 = Uh0RegexCat(v261, v263)
    let v265 = interned_of_regex_raw_28(v246, v247, v248, v249, v250, v251, v252, v264)
    let v266 = 1
    let v267 = 0
    let v268 = loop_36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267)
    let v269 = v40 == v185
    let v271 =
        case v269 {
            True -> {
                let v270 = v41 == v216
                v270
            }
            False -> {
                False
            }
        }
    let v273 =
        case v271 {
            True -> {
                let v272 = v57 == v268
                v272
            }
            False -> {
                False
            }
        }
    case v273 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-bench-engines-disagree"
        }
    }
    let v274 = v57 == 16
    case v274 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-bench-zero-runs-count"
        }
    }
    let v275 = v40 == 93
    case v275 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-bench-ends-with-zero-count"
        }
    }
    let v276 = v41 == 97
    case v276 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-bench-fourth-from-end-count"
        }
    }
    0
}
