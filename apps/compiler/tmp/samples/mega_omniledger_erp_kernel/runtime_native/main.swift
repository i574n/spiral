import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_TypedFxHashedStatementChecksumValidationAccepted: US0 { var f0: Int64; var f1: Int64; var f2: Int64; var f3: Int64; var f4: Int64; var f5: String; var tag: Int32 { 0 } }
struct US0_TypedFxHashedStatementChecksumValidationRejected: US0 { var f0: Int64; var f1: Int64; var f2: String; var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    let v0: Int64 = (0 as Int64) + (1 as Int64)
    let v1: Int64 = v0 + (1 as Int64)
    let v2: Int64 = v1 + (1 as Int64)
    let v3: Int64 = (0 as Int64) + (1 as Int64)
    let v4: Int64 = v3 + (1 as Int64)
    let v5: Int64 = v4 + (1 as Int64)
    let v6: Int64 = (0 as Int64) + (1 as Int64)
    let v7: Int64 = v6 + (1 as Int64)
    let v8: Int64 = (0 as Int64) + (1 as Int64)
    let v9: Int64 = v8 + (1 as Int64)
    let v10: Int64 = v9 + (1 as Int64)
    let v11: Int64 = v10 + (1 as Int64)
    let v12: Int64 = (0 as Int64) + (1 as Int64)
    let v14: Int64 = (0 as Int64) + (1 as Int64)
    let v15: Int64 = v14 + (1 as Int64)
    let v16: Int64 = v15 + (1 as Int64)
    let v17: Int64 = v16 + (1 as Int64)
    let v18: Int64 = v17 + (1 as Int64)
    let v19: Int64 = (0 as Int64) + (1 as Int64)
    let v20: Int64 = (v12 &+ v12)
    let v21: Int64 = (v7 &+ v20)
    let v22: Int64 = (0 as Int64) + (1 as Int64)
    let v23: Int64 = v22 + (1 as Int64)
    let v24: Int64 = v23 + (1 as Int64)
    let v25: Int64 = (0 as Int64) + (1 as Int64)
    let v26: Int64 = v25 + (1 as Int64)
    let v27: Int64 = v26 + (1 as Int64)
    let v28: Int64 = (0 as Int64) + (1 as Int64)
    let v29: Int64 = v28 + (1 as Int64)
    let v30: Int64 = (0 as Int64) + (1 as Int64)
    let v31: Int64 = v30 + (1 as Int64)
    let v32: Int64 = v31 + (1 as Int64)
    let v33: Int64 = v32 + (1 as Int64)
    let v34: Int64 = (0 as Int64) + (1 as Int64)
    let v36: Int64 = (0 as Int64) + (1 as Int64)
    let v37: Int64 = v36 + (1 as Int64)
    let v38: Int64 = v37 + (1 as Int64)
    let v39: Int64 = v38 + (1 as Int64)
    let v40: Int64 = (v34 &+ v34)
    let v41: Int64 = (v29 &+ v40)
    let v42: Int64 = (v18 &+ v39)
    let v43: Int64 = (v21 &+ v41)
    let v44: Bool = (v42 == (9 as Int64))
    let v45: Bool = (v19 == (1 as Int64))
    let v46: Bool = (v43 == (8 as Int64))
    let v47: Bool = (v44 && v45)
    let v48: Bool = (v47 && v46)
    if (v48) {
    } else {
        "typed-usd-eur-determined-tie-rounding-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v49: Int64 = (0 as Int64) + (1 as Int64)
    let v50: Int64 = v49 + (1 as Int64)
    let v51: Int64 = v50 + (1 as Int64)
    let v52: Int64 = v51 + (1 as Int64)
    let v53: Int64 = (0 as Int64) + (1 as Int64)
    let v54: Int64 = v53 + (1 as Int64)
    let v55: Int64 = v54 + (1 as Int64)
    let v56: Int64 = v55 + (1 as Int64)
    let v57: Bool = (v52 == v56)
    var v58: Int64 = (0 as Int64)
    if (v57) {
        v58 = (0 as Int64)
    } else {
        v58 = (1 as Int64)
    }
    let v59: Int64 = (0 as Int64) + (1 as Int64)
    let v60: Int64 = (0 as Int64) + (1 as Int64)
    let v61: Bool = (v59 == v60)
    var v62: Int64 = (0 as Int64)
    if (v61) {
        v62 = (0 as Int64)
    } else {
        v62 = (1 as Int64)
    }
    let v63: Int64 = (0 as Int64) + (1 as Int64)
    let v64: Int64 = v63 + (1 as Int64)
    let v65: Int64 = v64 + (1 as Int64)
    let v66: Int64 = v65 + (1 as Int64)
    let v67: Int64 = v66 + (1 as Int64)
    let v68: Int64 = (0 as Int64) + (1 as Int64)
    let v69: Int64 = v68 + (1 as Int64)
    let v70: Int64 = v69 + (1 as Int64)
    let v71: Int64 = v70 + (1 as Int64)
    let v72: Int64 = v71 + (1 as Int64)
    let v73: Bool = (v67 == v72)
    var v74: Int64 = (0 as Int64)
    if (v73) {
        v74 = (0 as Int64)
    } else {
        v74 = (1 as Int64)
    }
    let v75: Int64 = (v59 &+ v67)
    let v76: Int64 = (v60 &+ v72)
    let v77: Int64 = (v62 &+ v74)
    let v78: Int64 = (v52 &+ v75)
    let v79: Int64 = (v56 &+ v76)
    let v80: Int64 = (v58 &+ v77)
    let v81: Bool = (v78 == (10 as Int64))
    let v82: Bool = (v79 == (10 as Int64))
    let v83: Bool = (v80 == (0 as Int64))
    let v84: Bool = (v81 && v82)
    let v85: Bool = (v84 && v83)
    if (v85) {
    } else {
        "typed-FX-statement-expected-raw-append-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v86: Int64 = (0 as Int64) + (1 as Int64)
    let v87: Int64 = v86 + (1 as Int64)
    let v88: Int64 = v87 + (1 as Int64)
    let v89: Int64 = v88 + (1 as Int64)
    let v90: Int64 = (0 as Int64) + (1 as Int64)
    let v91: Int64 = v90 + (1 as Int64)
    let v92: Int64 = v91 + (1 as Int64)
    let v93: Int64 = v92 + (1 as Int64)
    let v94: Bool = (v89 == v93)
    var v95: Int64 = (0 as Int64)
    if (v94) {
        v95 = (0 as Int64)
    } else {
        v95 = (1 as Int64)
    }
    let v96: Int64 = (0 as Int64) + (1 as Int64)
    let v97: Int64 = (0 as Int64) + (1 as Int64)
    let v98: Bool = (v96 == v97)
    var v99: Int64 = (0 as Int64)
    if (v98) {
        v99 = (0 as Int64)
    } else {
        v99 = (1 as Int64)
    }
    let v100: Int64 = (0 as Int64) + (1 as Int64)
    let v101: Int64 = v100 + (1 as Int64)
    let v102: Int64 = v101 + (1 as Int64)
    let v103: Int64 = v102 + (1 as Int64)
    let v104: Int64 = v103 + (1 as Int64)
    let v105: Int64 = (0 as Int64) + (1 as Int64)
    let v106: Int64 = v105 + (1 as Int64)
    let v107: Int64 = v106 + (1 as Int64)
    let v108: Int64 = v107 + (1 as Int64)
    let v109: Int64 = v108 + (1 as Int64)
    let v110: Bool = (v104 == v109)
    var v111: Int64 = (0 as Int64)
    if (v110) {
        v111 = (0 as Int64)
    } else {
        v111 = (1 as Int64)
    }
    let v114: Int64 = (v99 &+ v111)
    let v117: Int64 = (v95 &+ v114)
    let v118: Int64 = (0 as Int64) + (1 as Int64)
    let v119: Int64 = v118 + (1 as Int64)
    let v120: Int64 = v119 + (1 as Int64)
    let v121: Int64 = v120 + (1 as Int64)
    let v122: Int64 = (0 as Int64) + (1 as Int64)
    let v123: Int64 = v122 + (1 as Int64)
    let v124: Int64 = v123 + (1 as Int64)
    let v125: Int64 = v124 + (1 as Int64)
    let v126: Bool = (v121 == v125)
    var v127: Int64 = (0 as Int64)
    if (v126) {
        v127 = (0 as Int64)
    } else {
        v127 = (1 as Int64)
    }
    let v128: Int64 = (0 as Int64) + (1 as Int64)
    let v129: Int64 = (0 as Int64) + (1 as Int64)
    let v130: Bool = (v128 == v129)
    var v131: Int64 = (0 as Int64)
    if (v130) {
        v131 = (0 as Int64)
    } else {
        v131 = (1 as Int64)
    }
    let v132: Int64 = (0 as Int64) + (1 as Int64)
    let v133: Int64 = v132 + (1 as Int64)
    let v134: Int64 = v133 + (1 as Int64)
    let v135: Int64 = v134 + (1 as Int64)
    let v136: Int64 = v135 + (1 as Int64)
    let v137: Int64 = (0 as Int64) + (1 as Int64)
    let v138: Int64 = v137 + (1 as Int64)
    let v139: Int64 = v138 + (1 as Int64)
    let v140: Int64 = v139 + (1 as Int64)
    let v141: Int64 = v140 + (1 as Int64)
    let v142: Bool = (v136 == v141)
    var v143: Int64 = (0 as Int64)
    if (v142) {
        v143 = (0 as Int64)
    } else {
        v143 = (1 as Int64)
    }
    let v146: Int64 = (v131 &+ v143)
    let v149: Int64 = (v127 &+ v146)
    let v150: Int64 = (v117 &+ v149)
    let v151: Bool = (v150 == (0 as Int64))
    if (v151) {
    } else {
        "typed-FX-statement-two-writer-raw-CAS-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v152: Int64 = (0 as Int64) + (1 as Int64)
    let v153: Int64 = v152 + (1 as Int64)
    let v154: Int64 = v153 + (1 as Int64)
    let v155: Int64 = v154 + (1 as Int64)
    let v156: Int64 = (0 as Int64) + (1 as Int64)
    let v157: Int64 = v156 + (1 as Int64)
    let v158: Int64 = v157 + (1 as Int64)
    let v159: Int64 = v158 + (1 as Int64)
    let v160: Bool = (v155 == v159)
    var v161: Int64 = (0 as Int64)
    if (v160) {
        v161 = (0 as Int64)
    } else {
        v161 = (1 as Int64)
    }
    let v162: Int64 = (0 as Int64) + (1 as Int64)
    let v163: Int64 = (0 as Int64) + (1 as Int64)
    let v164: Bool = (v162 == v163)
    var v165: Int64 = (0 as Int64)
    if (v164) {
        v165 = (0 as Int64)
    } else {
        v165 = (1 as Int64)
    }
    let v166: Int64 = (0 as Int64) + (1 as Int64)
    let v167: Int64 = v166 + (1 as Int64)
    let v168: Int64 = v167 + (1 as Int64)
    let v169: Int64 = v168 + (1 as Int64)
    let v170: Int64 = v169 + (1 as Int64)
    let v171: Int64 = (0 as Int64) + (1 as Int64)
    let v172: Int64 = v171 + (1 as Int64)
    let v173: Int64 = v172 + (1 as Int64)
    let v174: Int64 = v173 + (1 as Int64)
    let v175: Int64 = v174 + (1 as Int64)
    let v176: Bool = (v170 == v175)
    var v177: Int64 = (0 as Int64)
    if (v176) {
        v177 = (0 as Int64)
    } else {
        v177 = (1 as Int64)
    }
    let v180: Int64 = (v165 &+ v177)
    let v183: Int64 = (v161 &+ v180)
    let v184: Int64 = (0 as Int64) + (1 as Int64)
    let v185: Int64 = v184 + (1 as Int64)
    let v186: Int64 = v185 + (1 as Int64)
    let v187: Int64 = v186 + (1 as Int64)
    let v188: Int64 = (0 as Int64) + (1 as Int64)
    let v189: Int64 = v188 + (1 as Int64)
    let v190: Int64 = v189 + (1 as Int64)
    let v191: Int64 = v190 + (1 as Int64)
    let v192: Bool = (v187 == v191)
    var v193: Int64 = (0 as Int64)
    if (v192) {
        v193 = (0 as Int64)
    } else {
        v193 = (1 as Int64)
    }
    let v194: Int64 = (0 as Int64) + (1 as Int64)
    let v195: Int64 = (0 as Int64) + (1 as Int64)
    let v196: Bool = (v194 == v195)
    var v197: Int64 = (0 as Int64)
    if (v196) {
        v197 = (0 as Int64)
    } else {
        v197 = (1 as Int64)
    }
    let v198: Int64 = (0 as Int64) + (1 as Int64)
    let v199: Int64 = v198 + (1 as Int64)
    let v200: Int64 = v199 + (1 as Int64)
    let v201: Int64 = v200 + (1 as Int64)
    let v202: Int64 = v201 + (1 as Int64)
    let v203: Int64 = (0 as Int64) + (1 as Int64)
    let v204: Int64 = v203 + (1 as Int64)
    let v205: Int64 = v204 + (1 as Int64)
    let v206: Int64 = v205 + (1 as Int64)
    let v207: Int64 = v206 + (1 as Int64)
    let v208: Bool = (v202 == v207)
    var v209: Int64 = (0 as Int64)
    if (v208) {
        v209 = (0 as Int64)
    } else {
        v209 = (1 as Int64)
    }
    let v212: Int64 = (v197 &+ v209)
    let v215: Int64 = (v193 &+ v212)
    let v216: Int64 = (v183 &+ v215)
    let v217: Int64 = (0 as Int64) + (1 as Int64)
    let v218: Int64 = v217 + (1 as Int64)
    let v219: Int64 = v218 + (1 as Int64)
    let v220: Int64 = v219 + (1 as Int64)
    let v221: Int64 = (0 as Int64) + (1 as Int64)
    let v222: Int64 = v221 + (1 as Int64)
    let v223: Int64 = v222 + (1 as Int64)
    let v224: Int64 = v223 + (1 as Int64)
    let v225: Bool = (v220 == v224)
    var v226: Int64 = (0 as Int64)
    if (v225) {
        v226 = (0 as Int64)
    } else {
        v226 = (1 as Int64)
    }
    let v227: Int64 = (0 as Int64) + (1 as Int64)
    let v228: Int64 = (0 as Int64) + (1 as Int64)
    let v229: Bool = (v227 == v228)
    var v230: Int64 = (0 as Int64)
    if (v229) {
        v230 = (0 as Int64)
    } else {
        v230 = (1 as Int64)
    }
    let v231: Int64 = (0 as Int64) + (1 as Int64)
    let v232: Int64 = v231 + (1 as Int64)
    let v233: Int64 = v232 + (1 as Int64)
    let v234: Int64 = v233 + (1 as Int64)
    let v235: Int64 = v234 + (1 as Int64)
    let v236: Int64 = (0 as Int64) + (1 as Int64)
    let v237: Int64 = v236 + (1 as Int64)
    let v238: Int64 = v237 + (1 as Int64)
    let v239: Int64 = v238 + (1 as Int64)
    let v240: Int64 = v239 + (1 as Int64)
    let v241: Bool = (v235 == v240)
    var v242: Int64 = (0 as Int64)
    if (v241) {
        v242 = (0 as Int64)
    } else {
        v242 = (1 as Int64)
    }
    let v245: Int64 = (v230 &+ v242)
    let v248: Int64 = (v226 &+ v245)
    let v249: Int64 = (v216 &+ v248)
    let v250: Bool = (v249 == (0 as Int64))
    if (v250) {
    } else {
        "typed-FX-statement-three-writer-raw-CAS-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v251: Int64 = (0 as Int64) + (1 as Int64)
    let v252: Int64 = v251 + (1 as Int64)
    let v253: Int64 = v252 + (1 as Int64)
    let v254: Int64 = v253 + (1 as Int64)
    let v255: Int64 = (0 as Int64) + (1 as Int64)
    let v256: Int64 = v255 + (1 as Int64)
    let v257: Int64 = v256 + (1 as Int64)
    let v258: Int64 = v257 + (1 as Int64)
    let v259: Bool = (v254 == v258)
    var v260: Int64 = (0 as Int64)
    if (v259) {
        v260 = (0 as Int64)
    } else {
        v260 = (1 as Int64)
    }
    let v261: Int64 = (0 as Int64) + (1 as Int64)
    let v262: Int64 = (0 as Int64) + (1 as Int64)
    let v263: Bool = (v261 == v262)
    var v264: Int64 = (0 as Int64)
    if (v263) {
        v264 = (0 as Int64)
    } else {
        v264 = (1 as Int64)
    }
    let v265: Int64 = (0 as Int64) + (1 as Int64)
    let v266: Int64 = v265 + (1 as Int64)
    let v267: Int64 = v266 + (1 as Int64)
    let v268: Int64 = v267 + (1 as Int64)
    let v269: Int64 = v268 + (1 as Int64)
    let v270: Int64 = (0 as Int64) + (1 as Int64)
    let v271: Int64 = v270 + (1 as Int64)
    let v272: Int64 = v271 + (1 as Int64)
    let v273: Int64 = v272 + (1 as Int64)
    let v274: Int64 = v273 + (1 as Int64)
    let v275: Bool = (v269 == v274)
    var v276: Int64 = (0 as Int64)
    if (v275) {
        v276 = (0 as Int64)
    } else {
        v276 = (1 as Int64)
    }
    let v279: Int64 = (v264 &+ v276)
    let v282: Int64 = (v260 &+ v279)
    let v283: Int64 = (0 as Int64) + (1 as Int64)
    let v284: Int64 = v283 + (1 as Int64)
    let v285: Int64 = v284 + (1 as Int64)
    let v286: Int64 = v285 + (1 as Int64)
    let v287: Int64 = (0 as Int64) + (1 as Int64)
    let v288: Int64 = v287 + (1 as Int64)
    let v289: Int64 = v288 + (1 as Int64)
    let v290: Int64 = v289 + (1 as Int64)
    let v291: Bool = (v286 == v290)
    var v292: Int64 = (0 as Int64)
    if (v291) {
        v292 = (0 as Int64)
    } else {
        v292 = (1 as Int64)
    }
    let v293: Int64 = (0 as Int64) + (1 as Int64)
    let v294: Int64 = (0 as Int64) + (1 as Int64)
    let v295: Bool = (v293 == v294)
    var v296: Int64 = (0 as Int64)
    if (v295) {
        v296 = (0 as Int64)
    } else {
        v296 = (1 as Int64)
    }
    let v297: Int64 = (0 as Int64) + (1 as Int64)
    let v298: Int64 = v297 + (1 as Int64)
    let v299: Int64 = v298 + (1 as Int64)
    let v300: Int64 = v299 + (1 as Int64)
    let v301: Int64 = v300 + (1 as Int64)
    let v302: Int64 = (0 as Int64) + (1 as Int64)
    let v303: Int64 = v302 + (1 as Int64)
    let v304: Int64 = v303 + (1 as Int64)
    let v305: Int64 = v304 + (1 as Int64)
    let v306: Int64 = v305 + (1 as Int64)
    let v307: Bool = (v301 == v306)
    var v308: Int64 = (0 as Int64)
    if (v307) {
        v308 = (0 as Int64)
    } else {
        v308 = (1 as Int64)
    }
    let v311: Int64 = (v296 &+ v308)
    let v314: Int64 = (v292 &+ v311)
    let v315: Int64 = (v282 &+ v314)
    let v316: Int64 = (0 as Int64) + (1 as Int64)
    let v317: Int64 = v316 + (1 as Int64)
    let v318: Int64 = v317 + (1 as Int64)
    let v319: Int64 = v318 + (1 as Int64)
    let v320: Int64 = (0 as Int64) + (1 as Int64)
    let v321: Int64 = v320 + (1 as Int64)
    let v322: Int64 = v321 + (1 as Int64)
    let v323: Int64 = v322 + (1 as Int64)
    let v324: Bool = (v319 == v323)
    var v325: Int64 = (0 as Int64)
    if (v324) {
        v325 = (0 as Int64)
    } else {
        v325 = (1 as Int64)
    }
    let v326: Int64 = (0 as Int64) + (1 as Int64)
    let v327: Int64 = (0 as Int64) + (1 as Int64)
    let v328: Bool = (v326 == v327)
    var v329: Int64 = (0 as Int64)
    if (v328) {
        v329 = (0 as Int64)
    } else {
        v329 = (1 as Int64)
    }
    let v330: Int64 = (0 as Int64) + (1 as Int64)
    let v331: Int64 = v330 + (1 as Int64)
    let v332: Int64 = v331 + (1 as Int64)
    let v333: Int64 = v332 + (1 as Int64)
    let v334: Int64 = v333 + (1 as Int64)
    let v335: Int64 = (0 as Int64) + (1 as Int64)
    let v336: Int64 = v335 + (1 as Int64)
    let v337: Int64 = v336 + (1 as Int64)
    let v338: Int64 = v337 + (1 as Int64)
    let v339: Int64 = v338 + (1 as Int64)
    let v340: Bool = (v334 == v339)
    var v341: Int64 = (0 as Int64)
    if (v340) {
        v341 = (0 as Int64)
    } else {
        v341 = (1 as Int64)
    }
    let v344: Int64 = (v329 &+ v341)
    let v347: Int64 = (v325 &+ v344)
    let v348: Int64 = (0 as Int64) + (1 as Int64)
    let v349: Int64 = v348 + (1 as Int64)
    let v350: Int64 = v349 + (1 as Int64)
    let v351: Int64 = v350 + (1 as Int64)
    let v352: Int64 = (0 as Int64) + (1 as Int64)
    let v353: Int64 = v352 + (1 as Int64)
    let v354: Int64 = v353 + (1 as Int64)
    let v355: Int64 = v354 + (1 as Int64)
    let v356: Bool = (v351 == v355)
    var v357: Int64 = (0 as Int64)
    if (v356) {
        v357 = (0 as Int64)
    } else {
        v357 = (1 as Int64)
    }
    let v358: Int64 = (0 as Int64) + (1 as Int64)
    let v359: Int64 = (0 as Int64) + (1 as Int64)
    let v360: Bool = (v358 == v359)
    var v361: Int64 = (0 as Int64)
    if (v360) {
        v361 = (0 as Int64)
    } else {
        v361 = (1 as Int64)
    }
    let v362: Int64 = (0 as Int64) + (1 as Int64)
    let v363: Int64 = v362 + (1 as Int64)
    let v364: Int64 = v363 + (1 as Int64)
    let v365: Int64 = v364 + (1 as Int64)
    let v366: Int64 = v365 + (1 as Int64)
    let v367: Int64 = (0 as Int64) + (1 as Int64)
    let v368: Int64 = v367 + (1 as Int64)
    let v369: Int64 = v368 + (1 as Int64)
    let v370: Int64 = v369 + (1 as Int64)
    let v371: Int64 = v370 + (1 as Int64)
    let v372: Bool = (v366 == v371)
    var v373: Int64 = (0 as Int64)
    if (v372) {
        v373 = (0 as Int64)
    } else {
        v373 = (1 as Int64)
    }
    let v376: Int64 = (v361 &+ v373)
    let v379: Int64 = (v357 &+ v376)
    let v380: Int64 = (v347 &+ v379)
    let v381: Int64 = (v315 &+ v380)
    let v382: Bool = (v381 == (0 as Int64))
    if (v382) {
    } else {
        "typed-FX-statement-recursive-writer-raw-CAS-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v383: Int64 = (0 as Int64) + (1 as Int64)
    let v384: Int64 = v383 + (1 as Int64)
    let v385: Int64 = v384 + (1 as Int64)
    let v386: Int64 = v385 + (1 as Int64)
    let v387: Int64 = (0 as Int64) + (1 as Int64)
    let v388: Int64 = v387 + (1 as Int64)
    let v389: Int64 = v388 + (1 as Int64)
    let v390: Int64 = v389 + (1 as Int64)
    let v391: Bool = (v386 == v390)
    var v392: Int64 = (0 as Int64)
    if (v391) {
        v392 = (0 as Int64)
    } else {
        v392 = (1 as Int64)
    }
    let v393: Int64 = (0 as Int64) + (1 as Int64)
    let v394: Int64 = (0 as Int64) + (1 as Int64)
    let v395: Bool = (v393 == v394)
    var v396: Int64 = (0 as Int64)
    if (v395) {
        v396 = (0 as Int64)
    } else {
        v396 = (1 as Int64)
    }
    let v397: Int64 = (0 as Int64) + (1 as Int64)
    let v398: Int64 = v397 + (1 as Int64)
    let v399: Int64 = v398 + (1 as Int64)
    let v400: Int64 = v399 + (1 as Int64)
    let v401: Int64 = v400 + (1 as Int64)
    let v402: Int64 = (0 as Int64) + (1 as Int64)
    let v403: Int64 = v402 + (1 as Int64)
    let v404: Int64 = v403 + (1 as Int64)
    let v405: Int64 = v404 + (1 as Int64)
    let v406: Int64 = v405 + (1 as Int64)
    let v407: Bool = (v401 == v406)
    var v408: Int64 = (0 as Int64)
    if (v407) {
        v408 = (0 as Int64)
    } else {
        v408 = (1 as Int64)
    }
    let v411: Int64 = (v396 &+ v408)
    let v414: Int64 = (v392 &+ v411)
    let v415: Int64 = (0 as Int64) + (1 as Int64)
    let v416: Int64 = v415 + (1 as Int64)
    let v417: Int64 = v416 + (1 as Int64)
    let v418: Int64 = v417 + (1 as Int64)
    let v419: Int64 = (0 as Int64) + (1 as Int64)
    let v420: Int64 = v419 + (1 as Int64)
    let v421: Int64 = v420 + (1 as Int64)
    let v422: Int64 = v421 + (1 as Int64)
    let v423: Bool = (v418 == v422)
    var v424: Int64 = (0 as Int64)
    if (v423) {
        v424 = (0 as Int64)
    } else {
        v424 = (1 as Int64)
    }
    let v425: Int64 = (0 as Int64) + (1 as Int64)
    let v426: Int64 = (0 as Int64) + (1 as Int64)
    let v427: Bool = (v425 == v426)
    var v428: Int64 = (0 as Int64)
    if (v427) {
        v428 = (0 as Int64)
    } else {
        v428 = (1 as Int64)
    }
    let v429: Int64 = (0 as Int64) + (1 as Int64)
    let v430: Int64 = v429 + (1 as Int64)
    let v431: Int64 = v430 + (1 as Int64)
    let v432: Int64 = v431 + (1 as Int64)
    let v433: Int64 = v432 + (1 as Int64)
    let v434: Int64 = (0 as Int64) + (1 as Int64)
    let v435: Int64 = v434 + (1 as Int64)
    let v436: Int64 = v435 + (1 as Int64)
    let v437: Int64 = v436 + (1 as Int64)
    let v438: Int64 = v437 + (1 as Int64)
    let v439: Bool = (v433 == v438)
    var v440: Int64 = (0 as Int64)
    if (v439) {
        v440 = (0 as Int64)
    } else {
        v440 = (1 as Int64)
    }
    let v443: Int64 = (v428 &+ v440)
    let v446: Int64 = (v424 &+ v443)
    let v447: Int64 = (v414 &+ v446)
    let v448: Int64 = (0 as Int64) + (1 as Int64)
    let v449: Int64 = v448 + (1 as Int64)
    let v450: Int64 = v449 + (1 as Int64)
    let v451: Int64 = v450 + (1 as Int64)
    let v452: Int64 = (0 as Int64) + (1 as Int64)
    let v453: Int64 = v452 + (1 as Int64)
    let v454: Int64 = v453 + (1 as Int64)
    let v455: Int64 = v454 + (1 as Int64)
    let v456: Bool = (v451 == v455)
    var v457: Int64 = (0 as Int64)
    if (v456) {
        v457 = (0 as Int64)
    } else {
        v457 = (1 as Int64)
    }
    let v458: Int64 = (0 as Int64) + (1 as Int64)
    let v459: Int64 = (0 as Int64) + (1 as Int64)
    let v460: Bool = (v458 == v459)
    var v461: Int64 = (0 as Int64)
    if (v460) {
        v461 = (0 as Int64)
    } else {
        v461 = (1 as Int64)
    }
    let v462: Int64 = (0 as Int64) + (1 as Int64)
    let v463: Int64 = v462 + (1 as Int64)
    let v464: Int64 = v463 + (1 as Int64)
    let v465: Int64 = v464 + (1 as Int64)
    let v466: Int64 = v465 + (1 as Int64)
    let v467: Int64 = (0 as Int64) + (1 as Int64)
    let v468: Int64 = v467 + (1 as Int64)
    let v469: Int64 = v468 + (1 as Int64)
    let v470: Int64 = v469 + (1 as Int64)
    let v471: Int64 = v470 + (1 as Int64)
    let v472: Bool = (v466 == v471)
    var v473: Int64 = (0 as Int64)
    if (v472) {
        v473 = (0 as Int64)
    } else {
        v473 = (1 as Int64)
    }
    let v476: Int64 = (v461 &+ v473)
    let v479: Int64 = (v457 &+ v476)
    let v480: Int64 = (0 as Int64) + (1 as Int64)
    let v481: Int64 = v480 + (1 as Int64)
    let v482: Int64 = v481 + (1 as Int64)
    let v483: Int64 = v482 + (1 as Int64)
    let v484: Int64 = (0 as Int64) + (1 as Int64)
    let v485: Int64 = v484 + (1 as Int64)
    let v486: Int64 = v485 + (1 as Int64)
    let v487: Int64 = v486 + (1 as Int64)
    let v488: Bool = (v483 == v487)
    var v489: Int64 = (0 as Int64)
    if (v488) {
        v489 = (0 as Int64)
    } else {
        v489 = (1 as Int64)
    }
    let v490: Int64 = (0 as Int64) + (1 as Int64)
    let v491: Int64 = (0 as Int64) + (1 as Int64)
    let v492: Bool = (v490 == v491)
    var v493: Int64 = (0 as Int64)
    if (v492) {
        v493 = (0 as Int64)
    } else {
        v493 = (1 as Int64)
    }
    let v494: Int64 = (0 as Int64) + (1 as Int64)
    let v495: Int64 = v494 + (1 as Int64)
    let v496: Int64 = v495 + (1 as Int64)
    let v497: Int64 = v496 + (1 as Int64)
    let v498: Int64 = v497 + (1 as Int64)
    let v499: Int64 = (0 as Int64) + (1 as Int64)
    let v500: Int64 = v499 + (1 as Int64)
    let v501: Int64 = v500 + (1 as Int64)
    let v502: Int64 = v501 + (1 as Int64)
    let v503: Int64 = v502 + (1 as Int64)
    let v504: Bool = (v498 == v503)
    var v505: Int64 = (0 as Int64)
    if (v504) {
        v505 = (0 as Int64)
    } else {
        v505 = (1 as Int64)
    }
    let v508: Int64 = (v493 &+ v505)
    let v511: Int64 = (v489 &+ v508)
    let v512: Int64 = (v479 &+ v511)
    let v513: Int64 = (v447 &+ v512)
    let v514: Int64 = (0 as Int64) + (1 as Int64)
    let v515: Int64 = v514 + (1 as Int64)
    let v516: Int64 = v515 + (1 as Int64)
    let v517: Int64 = v516 + (1 as Int64)
    let v518: Int64 = (0 as Int64) + (1 as Int64)
    let v519: Int64 = v518 + (1 as Int64)
    let v520: Int64 = v519 + (1 as Int64)
    let v521: Int64 = v520 + (1 as Int64)
    let v522: Bool = (v517 == v521)
    var v523: Int64 = (0 as Int64)
    if (v522) {
        v523 = (0 as Int64)
    } else {
        v523 = (1 as Int64)
    }
    let v524: Int64 = (0 as Int64) + (1 as Int64)
    let v525: Int64 = (0 as Int64) + (1 as Int64)
    let v526: Bool = (v524 == v525)
    var v527: Int64 = (0 as Int64)
    if (v526) {
        v527 = (0 as Int64)
    } else {
        v527 = (1 as Int64)
    }
    let v528: Int64 = (0 as Int64) + (1 as Int64)
    let v529: Int64 = v528 + (1 as Int64)
    let v530: Int64 = v529 + (1 as Int64)
    let v531: Int64 = v530 + (1 as Int64)
    let v532: Int64 = v531 + (1 as Int64)
    let v533: Int64 = (0 as Int64) + (1 as Int64)
    let v534: Int64 = v533 + (1 as Int64)
    let v535: Int64 = v534 + (1 as Int64)
    let v536: Int64 = v535 + (1 as Int64)
    let v537: Int64 = v536 + (1 as Int64)
    let v538: Bool = (v532 == v537)
    var v539: Int64 = (0 as Int64)
    if (v538) {
        v539 = (0 as Int64)
    } else {
        v539 = (1 as Int64)
    }
    let v540: Int64 = (v524 &+ v532)
    let v541: Int64 = (v525 &+ v537)
    let v542: Int64 = (v527 &+ v539)
    let v543: Int64 = (v517 &+ v540)
    let v544: Int64 = (v521 &+ v541)
    let v545: Int64 = (v523 &+ v542)
    let v546: Int64 = (v544 &+ v545)
    let v547: Int64 = (v543 &+ v546)
    let v548: Int64 = ((3 as Int64) &+ v547)
    let v549: Int64 = (0 as Int64) + (1 as Int64)
    let v550: Int64 = v549 + (1 as Int64)
    let v551: Int64 = v550 + (1 as Int64)
    let v552: Int64 = v551 + (1 as Int64)
    let v553: Int64 = (0 as Int64) + (1 as Int64)
    let v554: Int64 = v553 + (1 as Int64)
    let v555: Int64 = v554 + (1 as Int64)
    let v556: Int64 = v555 + (1 as Int64)
    let v557: Bool = (v552 == v556)
    var v558: Int64 = (0 as Int64)
    if (v557) {
        v558 = (0 as Int64)
    } else {
        v558 = (1 as Int64)
    }
    let v559: Int64 = (0 as Int64) + (1 as Int64)
    let v560: Int64 = (0 as Int64) + (1 as Int64)
    let v561: Bool = (v559 == v560)
    var v562: Int64 = (0 as Int64)
    if (v561) {
        v562 = (0 as Int64)
    } else {
        v562 = (1 as Int64)
    }
    let v563: Int64 = (0 as Int64) + (1 as Int64)
    let v564: Int64 = v563 + (1 as Int64)
    let v565: Int64 = v564 + (1 as Int64)
    let v566: Int64 = v565 + (1 as Int64)
    let v567: Int64 = v566 + (1 as Int64)
    let v568: Int64 = (0 as Int64) + (1 as Int64)
    let v569: Int64 = v568 + (1 as Int64)
    let v570: Int64 = v569 + (1 as Int64)
    let v571: Int64 = v570 + (1 as Int64)
    let v572: Int64 = v571 + (1 as Int64)
    let v573: Bool = (v567 == v572)
    var v574: Int64 = (0 as Int64)
    if (v573) {
        v574 = (0 as Int64)
    } else {
        v574 = (1 as Int64)
    }
    let v575: Int64 = (v559 &+ v567)
    let v576: Int64 = (v560 &+ v572)
    let v577: Int64 = (v562 &+ v574)
    let v578: Int64 = (v552 &+ v575)
    let v579: Int64 = (v556 &+ v576)
    let v580: Int64 = (v558 &+ v577)
    let v581: Int64 = (v579 &+ v580)
    let v582: Int64 = (v578 &+ v581)
    let v583: Int64 = ((3 as Int64) &+ v582)
    let v584: Bool = (v548 == v583)
    var v621: US0 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (0 as Int64), f1: (0 as Int64), f2: (0 as Int64), f3: (0 as Int64), f4: (0 as Int64), f5: "")
    if (v584) {
        let v585: Int64 = (0 as Int64) + (1 as Int64)
        let v586: Int64 = v585 + (1 as Int64)
        let v587: Int64 = v586 + (1 as Int64)
        let v588: Int64 = v587 + (1 as Int64)
        let v589: Int64 = (0 as Int64) + (1 as Int64)
        let v590: Int64 = v589 + (1 as Int64)
        let v591: Int64 = v590 + (1 as Int64)
        let v592: Int64 = v591 + (1 as Int64)
        let v593: Bool = (v588 == v592)
        var v594: Int64 = (0 as Int64)
        if (v593) {
            v594 = (0 as Int64)
        } else {
            v594 = (1 as Int64)
        }
        let v595: Int64 = (0 as Int64) + (1 as Int64)
        let v596: Int64 = (0 as Int64) + (1 as Int64)
        let v597: Bool = (v595 == v596)
        var v598: Int64 = (0 as Int64)
        if (v597) {
            v598 = (0 as Int64)
        } else {
            v598 = (1 as Int64)
        }
        let v599: Int64 = (0 as Int64) + (1 as Int64)
        let v600: Int64 = v599 + (1 as Int64)
        let v601: Int64 = v600 + (1 as Int64)
        let v602: Int64 = v601 + (1 as Int64)
        let v603: Int64 = v602 + (1 as Int64)
        let v604: Int64 = (0 as Int64) + (1 as Int64)
        let v605: Int64 = v604 + (1 as Int64)
        let v606: Int64 = v605 + (1 as Int64)
        let v607: Int64 = v606 + (1 as Int64)
        let v608: Int64 = v607 + (1 as Int64)
        let v609: Bool = (v603 == v608)
        var v610: Int64 = (0 as Int64)
        if (v609) {
            v610 = (0 as Int64)
        } else {
            v610 = (1 as Int64)
        }
        let v611: Int64 = (v595 &+ v603)
        let v612: Int64 = (v596 &+ v608)
        let v613: Int64 = (v598 &+ v610)
        let v614: Int64 = (v588 &+ v611)
        let v615: Int64 = (v592 &+ v612)
        let v616: Int64 = (v594 &+ v613)
        let v617: String = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v621 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (1 as Int64), f1: (3 as Int64), f2: v614, f3: v615, f4: v616, f5: v617)
    } else {
        let v619: String = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v621 = US0_TypedFxHashedStatementChecksumValidationRejected(f0: v548, f1: v583, f2: v619)
    }
    var v640: Int64 = (0 as Int64)
    var v641: Int64 = (0 as Int64)
    var v644: Int64 = (0 as Int64)
    var v645: Int64 = (0 as Int64)
    var v646: Int64 = (0 as Int64)
    var v647: Int64 = (0 as Int64)
    var v648: Int64 = (0 as Int64)
    switch v621.tag {
        case 0:
            var v625: Int64 = (v621 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f0
            var v626: Int64 = (v621 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f1
            var v627: Int64 = (v621 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f2
            var v628: Int64 = (v621 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f3
            var v629: Int64 = (v621 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f4
            var v630: String = (v621 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f5
            v640 = (1 as Int64)
            v641 = (0 as Int64)
            v644 = v625
            v645 = v626
            v646 = v627
            v647 = v628
            v648 = v629
        case 1:
            var v622: Int64 = (v621 as! US0_TypedFxHashedStatementChecksumValidationRejected).f0
            var v623: Int64 = (v621 as! US0_TypedFxHashedStatementChecksumValidationRejected).f1
            var v624: String = (v621 as! US0_TypedFxHashedStatementChecksumValidationRejected).f2
            v640 = (0 as Int64)
            v641 = (1 as Int64)
            v644 = (0 as Int64)
            v645 = (0 as Int64)
            v646 = (0 as Int64)
            v647 = (0 as Int64)
            v648 = (0 as Int64)
        default:
            fatalError("unreachable union case")
    }
    let v649: Bool = (v513 == (0 as Int64))
    let v650: Bool = (v548 == (23 as Int64))
    let v651: Bool = (v640 == (1 as Int64))
    let v652: Bool = (v641 == (0 as Int64))
    let v653: Bool = (v644 == (1 as Int64))
    let v654: Bool = (v645 == (3 as Int64))
    let v655: Bool = (v646 == (10 as Int64))
    let v656: Bool = (v647 == (10 as Int64))
    let v657: Bool = (v648 == (0 as Int64))
    let v658: Bool = (v649 && v650)
    let v659: Bool = (v658 && v651)
    let v660: Bool = (v659 && v652)
    let v661: Bool = (v660 && v653)
    let v662: Bool = (v661 && v654)
    let v663: Bool = (v662 && v655)
    let v664: Bool = (v663 && v656)
    let v665: Bool = (v664 && v657)
    if (v665) {
    } else {
        "typed-FX-statement-recursive-writer-checksummed-restart-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v666: Int64 = (0 as Int64) + (1 as Int64)
    let v667: Int64 = v666 + (1 as Int64)
    let v668: Int64 = v667 + (1 as Int64)
    let v669: Int64 = v668 + (1 as Int64)
    let v670: Int64 = (0 as Int64) + (1 as Int64)
    let v671: Int64 = v670 + (1 as Int64)
    let v672: Int64 = v671 + (1 as Int64)
    let v673: Int64 = v672 + (1 as Int64)
    let v674: Bool = (v669 == v673)
    var v675: Int64 = (0 as Int64)
    if (v674) {
        v675 = (0 as Int64)
    } else {
        v675 = (1 as Int64)
    }
    let v676: Int64 = (0 as Int64) + (1 as Int64)
    let v677: Int64 = (0 as Int64) + (1 as Int64)
    let v678: Bool = (v676 == v677)
    var v679: Int64 = (0 as Int64)
    if (v678) {
        v679 = (0 as Int64)
    } else {
        v679 = (1 as Int64)
    }
    let v680: Int64 = (0 as Int64) + (1 as Int64)
    let v681: Int64 = v680 + (1 as Int64)
    let v682: Int64 = v681 + (1 as Int64)
    let v683: Int64 = v682 + (1 as Int64)
    let v684: Int64 = v683 + (1 as Int64)
    let v685: Int64 = (0 as Int64) + (1 as Int64)
    let v686: Int64 = v685 + (1 as Int64)
    let v687: Int64 = v686 + (1 as Int64)
    let v688: Int64 = v687 + (1 as Int64)
    let v689: Int64 = v688 + (1 as Int64)
    let v690: Bool = (v684 == v689)
    var v691: Int64 = (0 as Int64)
    if (v690) {
        v691 = (0 as Int64)
    } else {
        v691 = (1 as Int64)
    }
    let v694: Int64 = (v679 &+ v691)
    let v697: Int64 = (v675 &+ v694)
    let v698: Int64 = (0 as Int64) + (1 as Int64)
    let v699: Int64 = v698 + (1 as Int64)
    let v700: Int64 = v699 + (1 as Int64)
    let v701: Int64 = v700 + (1 as Int64)
    let v702: Int64 = (0 as Int64) + (1 as Int64)
    let v703: Int64 = v702 + (1 as Int64)
    let v704: Int64 = v703 + (1 as Int64)
    let v705: Int64 = v704 + (1 as Int64)
    let v706: Bool = (v701 == v705)
    var v707: Int64 = (0 as Int64)
    if (v706) {
        v707 = (0 as Int64)
    } else {
        v707 = (1 as Int64)
    }
    let v708: Int64 = (0 as Int64) + (1 as Int64)
    let v709: Int64 = (0 as Int64) + (1 as Int64)
    let v710: Bool = (v708 == v709)
    var v711: Int64 = (0 as Int64)
    if (v710) {
        v711 = (0 as Int64)
    } else {
        v711 = (1 as Int64)
    }
    let v712: Int64 = (0 as Int64) + (1 as Int64)
    let v713: Int64 = v712 + (1 as Int64)
    let v714: Int64 = v713 + (1 as Int64)
    let v715: Int64 = v714 + (1 as Int64)
    let v716: Int64 = v715 + (1 as Int64)
    let v717: Int64 = (0 as Int64) + (1 as Int64)
    let v718: Int64 = v717 + (1 as Int64)
    let v719: Int64 = v718 + (1 as Int64)
    let v720: Int64 = v719 + (1 as Int64)
    let v721: Int64 = v720 + (1 as Int64)
    let v722: Bool = (v716 == v721)
    var v723: Int64 = (0 as Int64)
    if (v722) {
        v723 = (0 as Int64)
    } else {
        v723 = (1 as Int64)
    }
    let v726: Int64 = (v711 &+ v723)
    let v729: Int64 = (v707 &+ v726)
    let v730: Int64 = (v697 &+ v729)
    let v731: Int64 = (0 as Int64) + (1 as Int64)
    let v732: Int64 = v731 + (1 as Int64)
    let v733: Int64 = v732 + (1 as Int64)
    let v734: Int64 = v733 + (1 as Int64)
    let v735: Int64 = (0 as Int64) + (1 as Int64)
    let v736: Int64 = v735 + (1 as Int64)
    let v737: Int64 = v736 + (1 as Int64)
    let v738: Int64 = v737 + (1 as Int64)
    let v739: Bool = (v734 == v738)
    var v740: Int64 = (0 as Int64)
    if (v739) {
        v740 = (0 as Int64)
    } else {
        v740 = (1 as Int64)
    }
    let v741: Int64 = (0 as Int64) + (1 as Int64)
    let v742: Int64 = (0 as Int64) + (1 as Int64)
    let v743: Bool = (v741 == v742)
    var v744: Int64 = (0 as Int64)
    if (v743) {
        v744 = (0 as Int64)
    } else {
        v744 = (1 as Int64)
    }
    let v745: Int64 = (0 as Int64) + (1 as Int64)
    let v746: Int64 = v745 + (1 as Int64)
    let v747: Int64 = v746 + (1 as Int64)
    let v748: Int64 = v747 + (1 as Int64)
    let v749: Int64 = v748 + (1 as Int64)
    let v750: Int64 = (0 as Int64) + (1 as Int64)
    let v751: Int64 = v750 + (1 as Int64)
    let v752: Int64 = v751 + (1 as Int64)
    let v753: Int64 = v752 + (1 as Int64)
    let v754: Int64 = v753 + (1 as Int64)
    let v755: Bool = (v749 == v754)
    var v756: Int64 = (0 as Int64)
    if (v755) {
        v756 = (0 as Int64)
    } else {
        v756 = (1 as Int64)
    }
    let v759: Int64 = (v744 &+ v756)
    let v762: Int64 = (v740 &+ v759)
    let v763: Int64 = (0 as Int64) + (1 as Int64)
    let v764: Int64 = v763 + (1 as Int64)
    let v765: Int64 = v764 + (1 as Int64)
    let v766: Int64 = v765 + (1 as Int64)
    let v767: Int64 = (0 as Int64) + (1 as Int64)
    let v768: Int64 = v767 + (1 as Int64)
    let v769: Int64 = v768 + (1 as Int64)
    let v770: Int64 = v769 + (1 as Int64)
    let v771: Bool = (v766 == v770)
    var v772: Int64 = (0 as Int64)
    if (v771) {
        v772 = (0 as Int64)
    } else {
        v772 = (1 as Int64)
    }
    let v773: Int64 = (0 as Int64) + (1 as Int64)
    let v774: Int64 = (0 as Int64) + (1 as Int64)
    let v775: Bool = (v773 == v774)
    var v776: Int64 = (0 as Int64)
    if (v775) {
        v776 = (0 as Int64)
    } else {
        v776 = (1 as Int64)
    }
    let v777: Int64 = (0 as Int64) + (1 as Int64)
    let v778: Int64 = v777 + (1 as Int64)
    let v779: Int64 = v778 + (1 as Int64)
    let v780: Int64 = v779 + (1 as Int64)
    let v781: Int64 = v780 + (1 as Int64)
    let v782: Int64 = (0 as Int64) + (1 as Int64)
    let v783: Int64 = v782 + (1 as Int64)
    let v784: Int64 = v783 + (1 as Int64)
    let v785: Int64 = v784 + (1 as Int64)
    let v786: Int64 = v785 + (1 as Int64)
    let v787: Bool = (v781 == v786)
    var v788: Int64 = (0 as Int64)
    if (v787) {
        v788 = (0 as Int64)
    } else {
        v788 = (1 as Int64)
    }
    let v791: Int64 = (v776 &+ v788)
    let v794: Int64 = (v772 &+ v791)
    let v795: Int64 = (v762 &+ v794)
    let v796: Int64 = (v730 &+ v795)
    let v797: Int64 = (0 as Int64) + (1 as Int64)
    let v798: Int64 = v797 + (1 as Int64)
    let v799: Int64 = v798 + (1 as Int64)
    let v800: Int64 = v799 + (1 as Int64)
    let v801: Int64 = (0 as Int64) + (1 as Int64)
    let v802: Int64 = v801 + (1 as Int64)
    let v803: Int64 = v802 + (1 as Int64)
    let v804: Int64 = v803 + (1 as Int64)
    let v805: Bool = (v800 == v804)
    var v806: Int64 = (0 as Int64)
    if (v805) {
        v806 = (0 as Int64)
    } else {
        v806 = (1 as Int64)
    }
    let v807: Int64 = (0 as Int64) + (1 as Int64)
    let v808: Int64 = (0 as Int64) + (1 as Int64)
    let v809: Bool = (v807 == v808)
    var v810: Int64 = (0 as Int64)
    if (v809) {
        v810 = (0 as Int64)
    } else {
        v810 = (1 as Int64)
    }
    let v811: Int64 = (0 as Int64) + (1 as Int64)
    let v812: Int64 = v811 + (1 as Int64)
    let v813: Int64 = v812 + (1 as Int64)
    let v814: Int64 = v813 + (1 as Int64)
    let v815: Int64 = v814 + (1 as Int64)
    let v816: Int64 = (0 as Int64) + (1 as Int64)
    let v817: Int64 = v816 + (1 as Int64)
    let v818: Int64 = v817 + (1 as Int64)
    let v819: Int64 = v818 + (1 as Int64)
    let v820: Int64 = v819 + (1 as Int64)
    let v821: Bool = (v815 == v820)
    var v822: Int64 = (0 as Int64)
    if (v821) {
        v822 = (0 as Int64)
    } else {
        v822 = (1 as Int64)
    }
    let v823: Int64 = (v807 &+ v815)
    let v824: Int64 = (v808 &+ v820)
    let v825: Int64 = (v810 &+ v822)
    let v826: Int64 = (v800 &+ v823)
    let v827: Int64 = (v804 &+ v824)
    let v828: Int64 = (v806 &+ v825)
    let v829: Int64 = (v827 &+ v828)
    let v830: Int64 = (v826 &+ v829)
    let v831: Int64 = ((3 as Int64) &+ v830)
    let v832: Int64 = (0 as Int64) + (1 as Int64)
    let v833: Int64 = v832 + (1 as Int64)
    let v834: Int64 = v833 + (1 as Int64)
    let v835: Int64 = v834 + (1 as Int64)
    let v836: Int64 = (0 as Int64) + (1 as Int64)
    let v837: Int64 = v836 + (1 as Int64)
    let v838: Int64 = v837 + (1 as Int64)
    let v839: Int64 = v838 + (1 as Int64)
    let v840: Bool = (v835 == v839)
    var v841: Int64 = (0 as Int64)
    if (v840) {
        v841 = (0 as Int64)
    } else {
        v841 = (1 as Int64)
    }
    let v842: Int64 = (0 as Int64) + (1 as Int64)
    let v843: Int64 = (0 as Int64) + (1 as Int64)
    let v844: Bool = (v842 == v843)
    var v845: Int64 = (0 as Int64)
    if (v844) {
        v845 = (0 as Int64)
    } else {
        v845 = (1 as Int64)
    }
    let v846: Int64 = (0 as Int64) + (1 as Int64)
    let v847: Int64 = v846 + (1 as Int64)
    let v848: Int64 = v847 + (1 as Int64)
    let v849: Int64 = v848 + (1 as Int64)
    let v850: Int64 = v849 + (1 as Int64)
    let v851: Int64 = (0 as Int64) + (1 as Int64)
    let v852: Int64 = v851 + (1 as Int64)
    let v853: Int64 = v852 + (1 as Int64)
    let v854: Int64 = v853 + (1 as Int64)
    let v855: Int64 = v854 + (1 as Int64)
    let v856: Bool = (v850 == v855)
    var v857: Int64 = (0 as Int64)
    if (v856) {
        v857 = (0 as Int64)
    } else {
        v857 = (1 as Int64)
    }
    let v858: Int64 = (v842 &+ v850)
    let v859: Int64 = (v843 &+ v855)
    let v860: Int64 = (v845 &+ v857)
    let v861: Int64 = (v835 &+ v858)
    let v862: Int64 = (v839 &+ v859)
    let v863: Int64 = (v841 &+ v860)
    let v864: Int64 = (v862 &+ v863)
    let v865: Int64 = (v861 &+ v864)
    let v866: Int64 = ((3 as Int64) &+ v865)
    let v867: Bool = (v831 == v866)
    var v904: US0 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (0 as Int64), f1: (0 as Int64), f2: (0 as Int64), f3: (0 as Int64), f4: (0 as Int64), f5: "")
    if (v867) {
        let v868: Int64 = (0 as Int64) + (1 as Int64)
        let v869: Int64 = v868 + (1 as Int64)
        let v870: Int64 = v869 + (1 as Int64)
        let v871: Int64 = v870 + (1 as Int64)
        let v872: Int64 = (0 as Int64) + (1 as Int64)
        let v873: Int64 = v872 + (1 as Int64)
        let v874: Int64 = v873 + (1 as Int64)
        let v875: Int64 = v874 + (1 as Int64)
        let v876: Bool = (v871 == v875)
        var v877: Int64 = (0 as Int64)
        if (v876) {
            v877 = (0 as Int64)
        } else {
            v877 = (1 as Int64)
        }
        let v878: Int64 = (0 as Int64) + (1 as Int64)
        let v879: Int64 = (0 as Int64) + (1 as Int64)
        let v880: Bool = (v878 == v879)
        var v881: Int64 = (0 as Int64)
        if (v880) {
            v881 = (0 as Int64)
        } else {
            v881 = (1 as Int64)
        }
        let v882: Int64 = (0 as Int64) + (1 as Int64)
        let v883: Int64 = v882 + (1 as Int64)
        let v884: Int64 = v883 + (1 as Int64)
        let v885: Int64 = v884 + (1 as Int64)
        let v886: Int64 = v885 + (1 as Int64)
        let v887: Int64 = (0 as Int64) + (1 as Int64)
        let v888: Int64 = v887 + (1 as Int64)
        let v889: Int64 = v888 + (1 as Int64)
        let v890: Int64 = v889 + (1 as Int64)
        let v891: Int64 = v890 + (1 as Int64)
        let v892: Bool = (v886 == v891)
        var v893: Int64 = (0 as Int64)
        if (v892) {
            v893 = (0 as Int64)
        } else {
            v893 = (1 as Int64)
        }
        let v894: Int64 = (v878 &+ v886)
        let v895: Int64 = (v879 &+ v891)
        let v896: Int64 = (v881 &+ v893)
        let v897: Int64 = (v871 &+ v894)
        let v898: Int64 = (v875 &+ v895)
        let v899: Int64 = (v877 &+ v896)
        let v900: String = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v904 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (1 as Int64), f1: (3 as Int64), f2: v897, f3: v898, f4: v899, f5: v900)
    } else {
        let v902: String = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v904 = US0_TypedFxHashedStatementChecksumValidationRejected(f0: v831, f1: v866, f2: v902)
    }
    var v923: Int64 = (0 as Int64)
    var v924: Int64 = (0 as Int64)
    var v927: Int64 = (0 as Int64)
    var v931: Int64 = (0 as Int64)
    switch v904.tag {
        case 0:
            var v908: Int64 = (v904 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f0
            var v909: Int64 = (v904 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f1
            var v910: Int64 = (v904 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f2
            var v911: Int64 = (v904 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f3
            var v912: Int64 = (v904 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f4
            var v913: String = (v904 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f5
            v923 = (1 as Int64)
            v924 = (0 as Int64)
            v927 = v908
            v931 = v912
        case 1:
            var v905: Int64 = (v904 as! US0_TypedFxHashedStatementChecksumValidationRejected).f0
            var v906: Int64 = (v904 as! US0_TypedFxHashedStatementChecksumValidationRejected).f1
            var v907: String = (v904 as! US0_TypedFxHashedStatementChecksumValidationRejected).f2
            v923 = (0 as Int64)
            v924 = (1 as Int64)
            v927 = (0 as Int64)
            v931 = (0 as Int64)
        default:
            fatalError("unreachable union case")
    }
    let v932: Int64 = (0 as Int64) + (1 as Int64)
    let v933: Int64 = v932 + (1 as Int64)
    let v934: Int64 = v933 + (1 as Int64)
    let v935: Int64 = v934 + (1 as Int64)
    let v936: Int64 = (0 as Int64) + (1 as Int64)
    let v937: Int64 = v936 + (1 as Int64)
    let v938: Int64 = v937 + (1 as Int64)
    let v939: Int64 = v938 + (1 as Int64)
    let v940: Bool = (v935 == v939)
    var v941: Int64 = (0 as Int64)
    if (v940) {
        v941 = (0 as Int64)
    } else {
        v941 = (1 as Int64)
    }
    let v942: Int64 = (0 as Int64) + (1 as Int64)
    let v943: Int64 = (0 as Int64) + (1 as Int64)
    let v944: Bool = (v942 == v943)
    var v945: Int64 = (0 as Int64)
    if (v944) {
        v945 = (0 as Int64)
    } else {
        v945 = (1 as Int64)
    }
    let v946: Int64 = (0 as Int64) + (1 as Int64)
    let v947: Int64 = v946 + (1 as Int64)
    let v948: Int64 = v947 + (1 as Int64)
    let v949: Int64 = v948 + (1 as Int64)
    let v950: Int64 = v949 + (1 as Int64)
    let v951: Int64 = (0 as Int64) + (1 as Int64)
    let v952: Int64 = v951 + (1 as Int64)
    let v953: Int64 = v952 + (1 as Int64)
    let v954: Int64 = v953 + (1 as Int64)
    let v955: Int64 = v954 + (1 as Int64)
    let v956: Bool = (v950 == v955)
    var v957: Int64 = (0 as Int64)
    if (v956) {
        v957 = (0 as Int64)
    } else {
        v957 = (1 as Int64)
    }
    let v960: Int64 = (v945 &+ v957)
    let v963: Int64 = (v941 &+ v960)
    let v964: Int64 = (0 as Int64) + (1 as Int64)
    let v965: Int64 = v964 + (1 as Int64)
    let v966: Int64 = v965 + (1 as Int64)
    let v967: Int64 = v966 + (1 as Int64)
    let v968: Int64 = (0 as Int64) + (1 as Int64)
    let v969: Int64 = v968 + (1 as Int64)
    let v970: Int64 = v969 + (1 as Int64)
    let v971: Int64 = v970 + (1 as Int64)
    let v972: Bool = (v967 == v971)
    var v973: Int64 = (0 as Int64)
    if (v972) {
        v973 = (0 as Int64)
    } else {
        v973 = (1 as Int64)
    }
    let v974: Int64 = (0 as Int64) + (1 as Int64)
    let v975: Int64 = (0 as Int64) + (1 as Int64)
    let v976: Bool = (v974 == v975)
    var v977: Int64 = (0 as Int64)
    if (v976) {
        v977 = (0 as Int64)
    } else {
        v977 = (1 as Int64)
    }
    let v978: Int64 = (0 as Int64) + (1 as Int64)
    let v979: Int64 = v978 + (1 as Int64)
    let v980: Int64 = v979 + (1 as Int64)
    let v981: Int64 = v980 + (1 as Int64)
    let v982: Int64 = v981 + (1 as Int64)
    let v983: Int64 = (0 as Int64) + (1 as Int64)
    let v984: Int64 = v983 + (1 as Int64)
    let v985: Int64 = v984 + (1 as Int64)
    let v986: Int64 = v985 + (1 as Int64)
    let v987: Int64 = v986 + (1 as Int64)
    let v988: Bool = (v982 == v987)
    var v989: Int64 = (0 as Int64)
    if (v988) {
        v989 = (0 as Int64)
    } else {
        v989 = (1 as Int64)
    }
    let v992: Int64 = (v977 &+ v989)
    let v995: Int64 = (v973 &+ v992)
    let v996: Int64 = (v963 &+ v995)
    let v997: Int64 = (v931 &+ v924)
    let v998: Int64 = (v996 &+ v997)
    let v999: Int64 = (v796 &+ v998)
    let v1000: Bool = (v927 == (1 as Int64))
    let v1001: Bool = (v923 == (1 as Int64))
    let v1002: Bool = (v999 == (0 as Int64))
    let v1003: Bool = (v1000 && v1001)
    let v1004: Bool = (v1003 && v1002)
    if (v1004) {
    } else {
        "typed-FX-statement-recursive-writer-restart-invariant-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v1005: Int64 = (0 as Int64) + (1 as Int64)
    let v1006: Int64 = v1005 + (1 as Int64)
    let v1007: Int64 = v1006 + (1 as Int64)
    let v1008: Int64 = v1007 + (1 as Int64)
    let v1009: Int64 = (0 as Int64) + (1 as Int64)
    let v1010: Int64 = v1009 + (1 as Int64)
    let v1011: Int64 = v1010 + (1 as Int64)
    let v1012: Int64 = v1011 + (1 as Int64)
    let v1013: Bool = (v1008 == v1012)
    var v1014: Int64 = (0 as Int64)
    if (v1013) {
        v1014 = (0 as Int64)
    } else {
        v1014 = (1 as Int64)
    }
    let v1015: Int64 = (0 as Int64) + (1 as Int64)
    let v1016: Int64 = (0 as Int64) + (1 as Int64)
    let v1017: Bool = (v1015 == v1016)
    var v1018: Int64 = (0 as Int64)
    if (v1017) {
        v1018 = (0 as Int64)
    } else {
        v1018 = (1 as Int64)
    }
    let v1019: Int64 = (0 as Int64) + (1 as Int64)
    let v1020: Int64 = v1019 + (1 as Int64)
    let v1021: Int64 = v1020 + (1 as Int64)
    let v1022: Int64 = v1021 + (1 as Int64)
    let v1023: Int64 = v1022 + (1 as Int64)
    let v1024: Int64 = (0 as Int64) + (1 as Int64)
    let v1025: Int64 = v1024 + (1 as Int64)
    let v1026: Int64 = v1025 + (1 as Int64)
    let v1027: Int64 = v1026 + (1 as Int64)
    let v1028: Int64 = v1027 + (1 as Int64)
    let v1029: Bool = (v1023 == v1028)
    var v1030: Int64 = (0 as Int64)
    if (v1029) {
        v1030 = (0 as Int64)
    } else {
        v1030 = (1 as Int64)
    }
    let v1033: Int64 = (v1018 &+ v1030)
    let v1036: Int64 = (v1014 &+ v1033)
    let v1037: Int64 = (0 as Int64) + (1 as Int64)
    let v1038: Int64 = v1037 + (1 as Int64)
    let v1039: Int64 = v1038 + (1 as Int64)
    let v1040: Int64 = v1039 + (1 as Int64)
    let v1041: Int64 = (0 as Int64) + (1 as Int64)
    let v1042: Int64 = v1041 + (1 as Int64)
    let v1043: Int64 = v1042 + (1 as Int64)
    let v1044: Int64 = v1043 + (1 as Int64)
    let v1045: Bool = (v1040 == v1044)
    var v1046: Int64 = (0 as Int64)
    if (v1045) {
        v1046 = (0 as Int64)
    } else {
        v1046 = (1 as Int64)
    }
    let v1047: Int64 = (0 as Int64) + (1 as Int64)
    let v1048: Int64 = (0 as Int64) + (1 as Int64)
    let v1049: Bool = (v1047 == v1048)
    var v1050: Int64 = (0 as Int64)
    if (v1049) {
        v1050 = (0 as Int64)
    } else {
        v1050 = (1 as Int64)
    }
    let v1051: Int64 = (0 as Int64) + (1 as Int64)
    let v1052: Int64 = v1051 + (1 as Int64)
    let v1053: Int64 = v1052 + (1 as Int64)
    let v1054: Int64 = v1053 + (1 as Int64)
    let v1055: Int64 = v1054 + (1 as Int64)
    let v1056: Int64 = (0 as Int64) + (1 as Int64)
    let v1057: Int64 = v1056 + (1 as Int64)
    let v1058: Int64 = v1057 + (1 as Int64)
    let v1059: Int64 = v1058 + (1 as Int64)
    let v1060: Int64 = v1059 + (1 as Int64)
    let v1061: Bool = (v1055 == v1060)
    var v1062: Int64 = (0 as Int64)
    if (v1061) {
        v1062 = (0 as Int64)
    } else {
        v1062 = (1 as Int64)
    }
    let v1065: Int64 = (v1050 &+ v1062)
    let v1068: Int64 = (v1046 &+ v1065)
    let v1069: Int64 = (v1036 &+ v1068)
    let v1070: Int64 = (0 as Int64) + (1 as Int64)
    let v1071: Int64 = v1070 + (1 as Int64)
    let v1072: Int64 = v1071 + (1 as Int64)
    let v1073: Int64 = v1072 + (1 as Int64)
    let v1074: Int64 = (0 as Int64) + (1 as Int64)
    let v1075: Int64 = v1074 + (1 as Int64)
    let v1076: Int64 = v1075 + (1 as Int64)
    let v1077: Int64 = v1076 + (1 as Int64)
    let v1078: Bool = (v1073 == v1077)
    var v1079: Int64 = (0 as Int64)
    if (v1078) {
        v1079 = (0 as Int64)
    } else {
        v1079 = (1 as Int64)
    }
    let v1080: Int64 = (0 as Int64) + (1 as Int64)
    let v1081: Int64 = (0 as Int64) + (1 as Int64)
    let v1082: Bool = (v1080 == v1081)
    var v1083: Int64 = (0 as Int64)
    if (v1082) {
        v1083 = (0 as Int64)
    } else {
        v1083 = (1 as Int64)
    }
    let v1084: Int64 = (0 as Int64) + (1 as Int64)
    let v1085: Int64 = v1084 + (1 as Int64)
    let v1086: Int64 = v1085 + (1 as Int64)
    let v1087: Int64 = v1086 + (1 as Int64)
    let v1088: Int64 = v1087 + (1 as Int64)
    let v1089: Int64 = (0 as Int64) + (1 as Int64)
    let v1090: Int64 = v1089 + (1 as Int64)
    let v1091: Int64 = v1090 + (1 as Int64)
    let v1092: Int64 = v1091 + (1 as Int64)
    let v1093: Int64 = v1092 + (1 as Int64)
    let v1094: Bool = (v1088 == v1093)
    var v1095: Int64 = (0 as Int64)
    if (v1094) {
        v1095 = (0 as Int64)
    } else {
        v1095 = (1 as Int64)
    }
    let v1098: Int64 = (v1083 &+ v1095)
    let v1101: Int64 = (v1079 &+ v1098)
    let v1102: Int64 = (0 as Int64) + (1 as Int64)
    let v1103: Int64 = v1102 + (1 as Int64)
    let v1104: Int64 = v1103 + (1 as Int64)
    let v1105: Int64 = v1104 + (1 as Int64)
    let v1106: Int64 = (0 as Int64) + (1 as Int64)
    let v1107: Int64 = v1106 + (1 as Int64)
    let v1108: Int64 = v1107 + (1 as Int64)
    let v1109: Int64 = v1108 + (1 as Int64)
    let v1110: Bool = (v1105 == v1109)
    var v1111: Int64 = (0 as Int64)
    if (v1110) {
        v1111 = (0 as Int64)
    } else {
        v1111 = (1 as Int64)
    }
    let v1112: Int64 = (0 as Int64) + (1 as Int64)
    let v1113: Int64 = (0 as Int64) + (1 as Int64)
    let v1114: Bool = (v1112 == v1113)
    var v1115: Int64 = (0 as Int64)
    if (v1114) {
        v1115 = (0 as Int64)
    } else {
        v1115 = (1 as Int64)
    }
    let v1116: Int64 = (0 as Int64) + (1 as Int64)
    let v1117: Int64 = v1116 + (1 as Int64)
    let v1118: Int64 = v1117 + (1 as Int64)
    let v1119: Int64 = v1118 + (1 as Int64)
    let v1120: Int64 = v1119 + (1 as Int64)
    let v1121: Int64 = (0 as Int64) + (1 as Int64)
    let v1122: Int64 = v1121 + (1 as Int64)
    let v1123: Int64 = v1122 + (1 as Int64)
    let v1124: Int64 = v1123 + (1 as Int64)
    let v1125: Int64 = v1124 + (1 as Int64)
    let v1126: Bool = (v1120 == v1125)
    var v1127: Int64 = (0 as Int64)
    if (v1126) {
        v1127 = (0 as Int64)
    } else {
        v1127 = (1 as Int64)
    }
    let v1130: Int64 = (v1115 &+ v1127)
    let v1133: Int64 = (v1111 &+ v1130)
    let v1134: Int64 = (v1101 &+ v1133)
    let v1135: Int64 = (0 as Int64) + (1 as Int64)
    let v1136: Int64 = v1135 + (1 as Int64)
    let v1137: Int64 = v1136 + (1 as Int64)
    let v1138: Int64 = v1137 + (1 as Int64)
    let v1139: Int64 = (0 as Int64) + (1 as Int64)
    let v1140: Int64 = v1139 + (1 as Int64)
    let v1141: Int64 = v1140 + (1 as Int64)
    let v1142: Int64 = v1141 + (1 as Int64)
    let v1143: Bool = (v1138 == v1142)
    var v1144: Int64 = (0 as Int64)
    if (v1143) {
        v1144 = (0 as Int64)
    } else {
        v1144 = (1 as Int64)
    }
    let v1145: Int64 = (0 as Int64) + (1 as Int64)
    let v1146: Int64 = (0 as Int64) + (1 as Int64)
    let v1147: Bool = (v1145 == v1146)
    var v1148: Int64 = (0 as Int64)
    if (v1147) {
        v1148 = (0 as Int64)
    } else {
        v1148 = (1 as Int64)
    }
    let v1149: Int64 = (0 as Int64) + (1 as Int64)
    let v1150: Int64 = v1149 + (1 as Int64)
    let v1151: Int64 = v1150 + (1 as Int64)
    let v1152: Int64 = v1151 + (1 as Int64)
    let v1153: Int64 = v1152 + (1 as Int64)
    let v1154: Int64 = (0 as Int64) + (1 as Int64)
    let v1155: Int64 = v1154 + (1 as Int64)
    let v1156: Int64 = v1155 + (1 as Int64)
    let v1157: Int64 = v1156 + (1 as Int64)
    let v1158: Int64 = v1157 + (1 as Int64)
    let v1159: Bool = (v1153 == v1158)
    var v1160: Int64 = (0 as Int64)
    if (v1159) {
        v1160 = (0 as Int64)
    } else {
        v1160 = (1 as Int64)
    }
    let v1163: Int64 = (v1148 &+ v1160)
    let v1166: Int64 = (v1144 &+ v1163)
    let v1167: Int64 = (0 as Int64) + (1 as Int64)
    let v1168: Int64 = v1167 + (1 as Int64)
    let v1169: Int64 = v1168 + (1 as Int64)
    let v1170: Int64 = v1169 + (1 as Int64)
    let v1171: Int64 = (0 as Int64) + (1 as Int64)
    let v1172: Int64 = v1171 + (1 as Int64)
    let v1173: Int64 = v1172 + (1 as Int64)
    let v1174: Int64 = v1173 + (1 as Int64)
    let v1175: Bool = (v1170 == v1174)
    var v1176: Int64 = (0 as Int64)
    if (v1175) {
        v1176 = (0 as Int64)
    } else {
        v1176 = (1 as Int64)
    }
    let v1177: Int64 = (0 as Int64) + (1 as Int64)
    let v1178: Int64 = (0 as Int64) + (1 as Int64)
    let v1179: Bool = (v1177 == v1178)
    var v1180: Int64 = (0 as Int64)
    if (v1179) {
        v1180 = (0 as Int64)
    } else {
        v1180 = (1 as Int64)
    }
    let v1181: Int64 = (0 as Int64) + (1 as Int64)
    let v1182: Int64 = v1181 + (1 as Int64)
    let v1183: Int64 = v1182 + (1 as Int64)
    let v1184: Int64 = v1183 + (1 as Int64)
    let v1185: Int64 = v1184 + (1 as Int64)
    let v1186: Int64 = (0 as Int64) + (1 as Int64)
    let v1187: Int64 = v1186 + (1 as Int64)
    let v1188: Int64 = v1187 + (1 as Int64)
    let v1189: Int64 = v1188 + (1 as Int64)
    let v1190: Int64 = v1189 + (1 as Int64)
    let v1191: Bool = (v1185 == v1190)
    var v1192: Int64 = (0 as Int64)
    if (v1191) {
        v1192 = (0 as Int64)
    } else {
        v1192 = (1 as Int64)
    }
    let v1195: Int64 = (v1180 &+ v1192)
    let v1198: Int64 = (v1176 &+ v1195)
    let v1199: Int64 = (0 as Int64) + (1 as Int64)
    let v1200: Int64 = v1199 + (1 as Int64)
    let v1201: Int64 = v1200 + (1 as Int64)
    let v1202: Int64 = v1201 + (1 as Int64)
    let v1203: Int64 = (0 as Int64) + (1 as Int64)
    let v1204: Int64 = v1203 + (1 as Int64)
    let v1205: Int64 = v1204 + (1 as Int64)
    let v1206: Int64 = v1205 + (1 as Int64)
    let v1207: Bool = (v1202 == v1206)
    var v1208: Int64 = (0 as Int64)
    if (v1207) {
        v1208 = (0 as Int64)
    } else {
        v1208 = (1 as Int64)
    }
    let v1209: Int64 = (0 as Int64) + (1 as Int64)
    let v1210: Int64 = (0 as Int64) + (1 as Int64)
    let v1211: Bool = (v1209 == v1210)
    var v1212: Int64 = (0 as Int64)
    if (v1211) {
        v1212 = (0 as Int64)
    } else {
        v1212 = (1 as Int64)
    }
    let v1213: Int64 = (0 as Int64) + (1 as Int64)
    let v1214: Int64 = v1213 + (1 as Int64)
    let v1215: Int64 = v1214 + (1 as Int64)
    let v1216: Int64 = v1215 + (1 as Int64)
    let v1217: Int64 = v1216 + (1 as Int64)
    let v1218: Int64 = (0 as Int64) + (1 as Int64)
    let v1219: Int64 = v1218 + (1 as Int64)
    let v1220: Int64 = v1219 + (1 as Int64)
    let v1221: Int64 = v1220 + (1 as Int64)
    let v1222: Int64 = v1221 + (1 as Int64)
    let v1223: Bool = (v1217 == v1222)
    var v1224: Int64 = (0 as Int64)
    if (v1223) {
        v1224 = (0 as Int64)
    } else {
        v1224 = (1 as Int64)
    }
    let v1227: Int64 = (v1212 &+ v1224)
    let v1230: Int64 = (v1208 &+ v1227)
    let v1231: Int64 = (0 as Int64) + (1 as Int64)
    let v1232: Int64 = v1231 + (1 as Int64)
    let v1233: Int64 = v1232 + (1 as Int64)
    let v1234: Int64 = v1233 + (1 as Int64)
    let v1235: Int64 = (0 as Int64) + (1 as Int64)
    let v1236: Int64 = v1235 + (1 as Int64)
    let v1237: Int64 = v1236 + (1 as Int64)
    let v1238: Int64 = v1237 + (1 as Int64)
    let v1239: Bool = (v1234 == v1238)
    var v1240: Int64 = (0 as Int64)
    if (v1239) {
        v1240 = (0 as Int64)
    } else {
        v1240 = (1 as Int64)
    }
    let v1241: Int64 = (0 as Int64) + (1 as Int64)
    let v1242: Int64 = (0 as Int64) + (1 as Int64)
    let v1243: Bool = (v1241 == v1242)
    var v1244: Int64 = (0 as Int64)
    if (v1243) {
        v1244 = (0 as Int64)
    } else {
        v1244 = (1 as Int64)
    }
    let v1245: Int64 = (0 as Int64) + (1 as Int64)
    let v1246: Int64 = v1245 + (1 as Int64)
    let v1247: Int64 = v1246 + (1 as Int64)
    let v1248: Int64 = v1247 + (1 as Int64)
    let v1249: Int64 = v1248 + (1 as Int64)
    let v1250: Int64 = (0 as Int64) + (1 as Int64)
    let v1251: Int64 = v1250 + (1 as Int64)
    let v1252: Int64 = v1251 + (1 as Int64)
    let v1253: Int64 = v1252 + (1 as Int64)
    let v1254: Int64 = v1253 + (1 as Int64)
    let v1255: Bool = (v1249 == v1254)
    var v1256: Int64 = (0 as Int64)
    if (v1255) {
        v1256 = (0 as Int64)
    } else {
        v1256 = (1 as Int64)
    }
    let v1259: Int64 = (v1244 &+ v1256)
    let v1262: Int64 = (v1240 &+ v1259)
    let v1263: Int64 = (v1230 &+ v1262)
    let v1264: Int64 = (v1198 &+ v1263)
    let v1265: Int64 = (v1166 &+ v1264)
    let v1266: Bool = (v1069 == (0 as Int64))
    let v1267: Bool = (v1134 == v1069)
    let v1268: Bool = (v1265 == (0 as Int64))
    let v1269: Bool = (v1266 && v1267)
    let v1270: Bool = (v1269 && v1268)
    if (v1270) {
    } else {
        "typed-FX-statement-stale-writer-conflict-program-append-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v1271: Int64 = (0 as Int64) + (1 as Int64)
    let v1272: Int64 = v1271 + (1 as Int64)
    let v1273: Int64 = v1272 + (1 as Int64)
    let v1274: Int64 = v1273 + (1 as Int64)
    let v1275: Int64 = (0 as Int64) + (1 as Int64)
    let v1276: Int64 = v1275 + (1 as Int64)
    let v1277: Int64 = v1276 + (1 as Int64)
    let v1278: Int64 = v1277 + (1 as Int64)
    let v1279: Bool = (v1274 == v1278)
    var v1280: Int64 = (0 as Int64)
    if (v1279) {
        v1280 = (0 as Int64)
    } else {
        v1280 = (1 as Int64)
    }
    let v1281: Int64 = (0 as Int64) + (1 as Int64)
    let v1282: Int64 = (0 as Int64) + (1 as Int64)
    let v1283: Bool = (v1281 == v1282)
    var v1284: Int64 = (0 as Int64)
    if (v1283) {
        v1284 = (0 as Int64)
    } else {
        v1284 = (1 as Int64)
    }
    let v1285: Int64 = (0 as Int64) + (1 as Int64)
    let v1286: Int64 = v1285 + (1 as Int64)
    let v1287: Int64 = v1286 + (1 as Int64)
    let v1288: Int64 = v1287 + (1 as Int64)
    let v1289: Int64 = v1288 + (1 as Int64)
    let v1290: Int64 = (0 as Int64) + (1 as Int64)
    let v1291: Int64 = v1290 + (1 as Int64)
    let v1292: Int64 = v1291 + (1 as Int64)
    let v1293: Int64 = v1292 + (1 as Int64)
    let v1294: Int64 = v1293 + (1 as Int64)
    let v1295: Bool = (v1289 == v1294)
    var v1296: Int64 = (0 as Int64)
    if (v1295) {
        v1296 = (0 as Int64)
    } else {
        v1296 = (1 as Int64)
    }
    let v1299: Int64 = (v1284 &+ v1296)
    let v1302: Int64 = (v1280 &+ v1299)
    let v1303: Int64 = (0 as Int64) + (1 as Int64)
    let v1304: Int64 = v1303 + (1 as Int64)
    let v1305: Int64 = v1304 + (1 as Int64)
    let v1306: Int64 = v1305 + (1 as Int64)
    let v1307: Int64 = (0 as Int64) + (1 as Int64)
    let v1308: Int64 = v1307 + (1 as Int64)
    let v1309: Int64 = v1308 + (1 as Int64)
    let v1310: Int64 = v1309 + (1 as Int64)
    let v1311: Bool = (v1306 == v1310)
    var v1312: Int64 = (0 as Int64)
    if (v1311) {
        v1312 = (0 as Int64)
    } else {
        v1312 = (1 as Int64)
    }
    let v1313: Int64 = (0 as Int64) + (1 as Int64)
    let v1314: Int64 = (0 as Int64) + (1 as Int64)
    let v1315: Bool = (v1313 == v1314)
    var v1316: Int64 = (0 as Int64)
    if (v1315) {
        v1316 = (0 as Int64)
    } else {
        v1316 = (1 as Int64)
    }
    let v1317: Int64 = (0 as Int64) + (1 as Int64)
    let v1318: Int64 = v1317 + (1 as Int64)
    let v1319: Int64 = v1318 + (1 as Int64)
    let v1320: Int64 = v1319 + (1 as Int64)
    let v1321: Int64 = v1320 + (1 as Int64)
    let v1322: Int64 = (0 as Int64) + (1 as Int64)
    let v1323: Int64 = v1322 + (1 as Int64)
    let v1324: Int64 = v1323 + (1 as Int64)
    let v1325: Int64 = v1324 + (1 as Int64)
    let v1326: Int64 = v1325 + (1 as Int64)
    let v1327: Bool = (v1321 == v1326)
    var v1328: Int64 = (0 as Int64)
    if (v1327) {
        v1328 = (0 as Int64)
    } else {
        v1328 = (1 as Int64)
    }
    let v1331: Int64 = (v1316 &+ v1328)
    let v1334: Int64 = (v1312 &+ v1331)
    let v1335: Int64 = (0 as Int64) + (1 as Int64)
    let v1336: Int64 = v1335 + (1 as Int64)
    let v1337: Int64 = v1336 + (1 as Int64)
    let v1338: Int64 = v1337 + (1 as Int64)
    let v1339: Int64 = (0 as Int64) + (1 as Int64)
    let v1340: Int64 = v1339 + (1 as Int64)
    let v1341: Int64 = v1340 + (1 as Int64)
    let v1342: Int64 = v1341 + (1 as Int64)
    let v1343: Bool = (v1338 == v1342)
    var v1344: Int64 = (0 as Int64)
    if (v1343) {
        v1344 = (0 as Int64)
    } else {
        v1344 = (1 as Int64)
    }
    let v1345: Int64 = (0 as Int64) + (1 as Int64)
    let v1346: Int64 = (0 as Int64) + (1 as Int64)
    let v1347: Bool = (v1345 == v1346)
    var v1348: Int64 = (0 as Int64)
    if (v1347) {
        v1348 = (0 as Int64)
    } else {
        v1348 = (1 as Int64)
    }
    let v1349: Int64 = (0 as Int64) + (1 as Int64)
    let v1350: Int64 = v1349 + (1 as Int64)
    let v1351: Int64 = v1350 + (1 as Int64)
    let v1352: Int64 = v1351 + (1 as Int64)
    let v1353: Int64 = v1352 + (1 as Int64)
    let v1354: Int64 = (0 as Int64) + (1 as Int64)
    let v1355: Int64 = v1354 + (1 as Int64)
    let v1356: Int64 = v1355 + (1 as Int64)
    let v1357: Int64 = v1356 + (1 as Int64)
    let v1358: Int64 = v1357 + (1 as Int64)
    let v1359: Bool = (v1353 == v1358)
    var v1360: Int64 = (0 as Int64)
    if (v1359) {
        v1360 = (0 as Int64)
    } else {
        v1360 = (1 as Int64)
    }
    let v1363: Int64 = (v1348 &+ v1360)
    let v1366: Int64 = (v1344 &+ v1363)
    let v1367: Int64 = (0 as Int64) + (1 as Int64)
    let v1368: Int64 = v1367 + (1 as Int64)
    let v1369: Int64 = v1368 + (1 as Int64)
    let v1370: Int64 = v1369 + (1 as Int64)
    let v1371: Int64 = (0 as Int64) + (1 as Int64)
    let v1372: Int64 = v1371 + (1 as Int64)
    let v1373: Int64 = v1372 + (1 as Int64)
    let v1374: Int64 = v1373 + (1 as Int64)
    let v1375: Bool = (v1370 == v1374)
    var v1376: Int64 = (0 as Int64)
    if (v1375) {
        v1376 = (0 as Int64)
    } else {
        v1376 = (1 as Int64)
    }
    let v1377: Int64 = (0 as Int64) + (1 as Int64)
    let v1378: Int64 = (0 as Int64) + (1 as Int64)
    let v1379: Bool = (v1377 == v1378)
    var v1380: Int64 = (0 as Int64)
    if (v1379) {
        v1380 = (0 as Int64)
    } else {
        v1380 = (1 as Int64)
    }
    let v1381: Int64 = (0 as Int64) + (1 as Int64)
    let v1382: Int64 = v1381 + (1 as Int64)
    let v1383: Int64 = v1382 + (1 as Int64)
    let v1384: Int64 = v1383 + (1 as Int64)
    let v1385: Int64 = v1384 + (1 as Int64)
    let v1386: Int64 = (0 as Int64) + (1 as Int64)
    let v1387: Int64 = v1386 + (1 as Int64)
    let v1388: Int64 = v1387 + (1 as Int64)
    let v1389: Int64 = v1388 + (1 as Int64)
    let v1390: Int64 = v1389 + (1 as Int64)
    let v1391: Bool = (v1385 == v1390)
    var v1392: Int64 = (0 as Int64)
    if (v1391) {
        v1392 = (0 as Int64)
    } else {
        v1392 = (1 as Int64)
    }
    let v1395: Int64 = (v1380 &+ v1392)
    let v1398: Int64 = (v1376 &+ v1395)
    let v1399: Int64 = (0 as Int64) + (1 as Int64)
    let v1400: Int64 = v1399 + (1 as Int64)
    let v1401: Int64 = v1400 + (1 as Int64)
    let v1402: Int64 = v1401 + (1 as Int64)
    let v1403: Int64 = (0 as Int64) + (1 as Int64)
    let v1404: Int64 = v1403 + (1 as Int64)
    let v1405: Int64 = v1404 + (1 as Int64)
    let v1406: Int64 = v1405 + (1 as Int64)
    let v1407: Bool = (v1402 == v1406)
    var v1408: Int64 = (0 as Int64)
    if (v1407) {
        v1408 = (0 as Int64)
    } else {
        v1408 = (1 as Int64)
    }
    let v1409: Int64 = (0 as Int64) + (1 as Int64)
    let v1410: Int64 = (0 as Int64) + (1 as Int64)
    let v1411: Bool = (v1409 == v1410)
    var v1412: Int64 = (0 as Int64)
    if (v1411) {
        v1412 = (0 as Int64)
    } else {
        v1412 = (1 as Int64)
    }
    let v1413: Int64 = (0 as Int64) + (1 as Int64)
    let v1414: Int64 = v1413 + (1 as Int64)
    let v1415: Int64 = v1414 + (1 as Int64)
    let v1416: Int64 = v1415 + (1 as Int64)
    let v1417: Int64 = v1416 + (1 as Int64)
    let v1418: Int64 = (0 as Int64) + (1 as Int64)
    let v1419: Int64 = v1418 + (1 as Int64)
    let v1420: Int64 = v1419 + (1 as Int64)
    let v1421: Int64 = v1420 + (1 as Int64)
    let v1422: Int64 = v1421 + (1 as Int64)
    let v1423: Bool = (v1417 == v1422)
    var v1424: Int64 = (0 as Int64)
    if (v1423) {
        v1424 = (0 as Int64)
    } else {
        v1424 = (1 as Int64)
    }
    let v1427: Int64 = (v1412 &+ v1424)
    let v1430: Int64 = (v1408 &+ v1427)
    let v1431: Int64 = (0 as Int64) + (1 as Int64)
    let v1432: Int64 = v1431 + (1 as Int64)
    let v1433: Int64 = v1432 + (1 as Int64)
    let v1434: Int64 = v1433 + (1 as Int64)
    let v1435: Int64 = (0 as Int64) + (1 as Int64)
    let v1436: Int64 = v1435 + (1 as Int64)
    let v1437: Int64 = v1436 + (1 as Int64)
    let v1438: Int64 = v1437 + (1 as Int64)
    let v1439: Bool = (v1434 == v1438)
    var v1440: Int64 = (0 as Int64)
    if (v1439) {
        v1440 = (0 as Int64)
    } else {
        v1440 = (1 as Int64)
    }
    let v1441: Int64 = (0 as Int64) + (1 as Int64)
    let v1442: Int64 = (0 as Int64) + (1 as Int64)
    let v1443: Bool = (v1441 == v1442)
    var v1444: Int64 = (0 as Int64)
    if (v1443) {
        v1444 = (0 as Int64)
    } else {
        v1444 = (1 as Int64)
    }
    let v1445: Int64 = (0 as Int64) + (1 as Int64)
    let v1446: Int64 = v1445 + (1 as Int64)
    let v1447: Int64 = v1446 + (1 as Int64)
    let v1448: Int64 = v1447 + (1 as Int64)
    let v1449: Int64 = v1448 + (1 as Int64)
    let v1450: Int64 = (0 as Int64) + (1 as Int64)
    let v1451: Int64 = v1450 + (1 as Int64)
    let v1452: Int64 = v1451 + (1 as Int64)
    let v1453: Int64 = v1452 + (1 as Int64)
    let v1454: Int64 = v1453 + (1 as Int64)
    let v1455: Bool = (v1449 == v1454)
    var v1456: Int64 = (0 as Int64)
    if (v1455) {
        v1456 = (0 as Int64)
    } else {
        v1456 = (1 as Int64)
    }
    let v1459: Int64 = (v1444 &+ v1456)
    let v1462: Int64 = (v1440 &+ v1459)
    let v1463: Int64 = (v1430 &+ v1462)
    let v1464: Int64 = (v1398 &+ v1463)
    let v1465: Int64 = (v1366 &+ v1464)
    let v1466: Int64 = (v1334 &+ v1465)
    let v1467: Int64 = (v1302 &+ v1466)
    let v1468: Int64 = (0 as Int64) + (1 as Int64)
    let v1469: Int64 = v1468 + (1 as Int64)
    let v1470: Int64 = v1469 + (1 as Int64)
    let v1471: Int64 = v1470 + (1 as Int64)
    let v1472: Int64 = (0 as Int64) + (1 as Int64)
    let v1473: Int64 = v1472 + (1 as Int64)
    let v1474: Int64 = v1473 + (1 as Int64)
    let v1475: Int64 = v1474 + (1 as Int64)
    let v1476: Bool = (v1471 == v1475)
    var v1477: Int64 = (0 as Int64)
    if (v1476) {
        v1477 = (0 as Int64)
    } else {
        v1477 = (1 as Int64)
    }
    let v1478: Int64 = (0 as Int64) + (1 as Int64)
    let v1479: Int64 = (0 as Int64) + (1 as Int64)
    let v1480: Bool = (v1478 == v1479)
    var v1481: Int64 = (0 as Int64)
    if (v1480) {
        v1481 = (0 as Int64)
    } else {
        v1481 = (1 as Int64)
    }
    let v1482: Int64 = (0 as Int64) + (1 as Int64)
    let v1483: Int64 = v1482 + (1 as Int64)
    let v1484: Int64 = v1483 + (1 as Int64)
    let v1485: Int64 = v1484 + (1 as Int64)
    let v1486: Int64 = v1485 + (1 as Int64)
    let v1487: Int64 = (0 as Int64) + (1 as Int64)
    let v1488: Int64 = v1487 + (1 as Int64)
    let v1489: Int64 = v1488 + (1 as Int64)
    let v1490: Int64 = v1489 + (1 as Int64)
    let v1491: Int64 = v1490 + (1 as Int64)
    let v1492: Bool = (v1486 == v1491)
    var v1493: Int64 = (0 as Int64)
    if (v1492) {
        v1493 = (0 as Int64)
    } else {
        v1493 = (1 as Int64)
    }
    let v1496: Int64 = (v1481 &+ v1493)
    let v1499: Int64 = (v1477 &+ v1496)
    let v1500: Int64 = (0 as Int64) + (1 as Int64)
    let v1501: Int64 = v1500 + (1 as Int64)
    let v1502: Int64 = v1501 + (1 as Int64)
    let v1503: Int64 = v1502 + (1 as Int64)
    let v1504: Int64 = (0 as Int64) + (1 as Int64)
    let v1505: Int64 = v1504 + (1 as Int64)
    let v1506: Int64 = v1505 + (1 as Int64)
    let v1507: Int64 = v1506 + (1 as Int64)
    let v1508: Bool = (v1503 == v1507)
    var v1509: Int64 = (0 as Int64)
    if (v1508) {
        v1509 = (0 as Int64)
    } else {
        v1509 = (1 as Int64)
    }
    let v1510: Int64 = (0 as Int64) + (1 as Int64)
    let v1511: Int64 = (0 as Int64) + (1 as Int64)
    let v1512: Bool = (v1510 == v1511)
    var v1513: Int64 = (0 as Int64)
    if (v1512) {
        v1513 = (0 as Int64)
    } else {
        v1513 = (1 as Int64)
    }
    let v1514: Int64 = (0 as Int64) + (1 as Int64)
    let v1515: Int64 = v1514 + (1 as Int64)
    let v1516: Int64 = v1515 + (1 as Int64)
    let v1517: Int64 = v1516 + (1 as Int64)
    let v1518: Int64 = v1517 + (1 as Int64)
    let v1519: Int64 = (0 as Int64) + (1 as Int64)
    let v1520: Int64 = v1519 + (1 as Int64)
    let v1521: Int64 = v1520 + (1 as Int64)
    let v1522: Int64 = v1521 + (1 as Int64)
    let v1523: Int64 = v1522 + (1 as Int64)
    let v1524: Bool = (v1518 == v1523)
    var v1525: Int64 = (0 as Int64)
    if (v1524) {
        v1525 = (0 as Int64)
    } else {
        v1525 = (1 as Int64)
    }
    let v1528: Int64 = (v1513 &+ v1525)
    let v1531: Int64 = (v1509 &+ v1528)
    let v1532: Int64 = (0 as Int64) + (1 as Int64)
    let v1533: Int64 = v1532 + (1 as Int64)
    let v1534: Int64 = v1533 + (1 as Int64)
    let v1535: Int64 = v1534 + (1 as Int64)
    let v1536: Int64 = (0 as Int64) + (1 as Int64)
    let v1537: Int64 = v1536 + (1 as Int64)
    let v1538: Int64 = v1537 + (1 as Int64)
    let v1539: Int64 = v1538 + (1 as Int64)
    let v1540: Bool = (v1535 == v1539)
    var v1541: Int64 = (0 as Int64)
    if (v1540) {
        v1541 = (0 as Int64)
    } else {
        v1541 = (1 as Int64)
    }
    let v1542: Int64 = (0 as Int64) + (1 as Int64)
    let v1543: Int64 = (0 as Int64) + (1 as Int64)
    let v1544: Bool = (v1542 == v1543)
    var v1545: Int64 = (0 as Int64)
    if (v1544) {
        v1545 = (0 as Int64)
    } else {
        v1545 = (1 as Int64)
    }
    let v1546: Int64 = (0 as Int64) + (1 as Int64)
    let v1547: Int64 = v1546 + (1 as Int64)
    let v1548: Int64 = v1547 + (1 as Int64)
    let v1549: Int64 = v1548 + (1 as Int64)
    let v1550: Int64 = v1549 + (1 as Int64)
    let v1551: Int64 = (0 as Int64) + (1 as Int64)
    let v1552: Int64 = v1551 + (1 as Int64)
    let v1553: Int64 = v1552 + (1 as Int64)
    let v1554: Int64 = v1553 + (1 as Int64)
    let v1555: Int64 = v1554 + (1 as Int64)
    let v1556: Bool = (v1550 == v1555)
    var v1557: Int64 = (0 as Int64)
    if (v1556) {
        v1557 = (0 as Int64)
    } else {
        v1557 = (1 as Int64)
    }
    let v1560: Int64 = (v1545 &+ v1557)
    let v1563: Int64 = (v1541 &+ v1560)
    let v1564: Int64 = (0 as Int64) + (1 as Int64)
    let v1565: Int64 = v1564 + (1 as Int64)
    let v1566: Int64 = v1565 + (1 as Int64)
    let v1567: Int64 = v1566 + (1 as Int64)
    let v1568: Int64 = (0 as Int64) + (1 as Int64)
    let v1569: Int64 = v1568 + (1 as Int64)
    let v1570: Int64 = v1569 + (1 as Int64)
    let v1571: Int64 = v1570 + (1 as Int64)
    let v1572: Bool = (v1567 == v1571)
    var v1573: Int64 = (0 as Int64)
    if (v1572) {
        v1573 = (0 as Int64)
    } else {
        v1573 = (1 as Int64)
    }
    let v1574: Int64 = (0 as Int64) + (1 as Int64)
    let v1575: Int64 = (0 as Int64) + (1 as Int64)
    let v1576: Bool = (v1574 == v1575)
    var v1577: Int64 = (0 as Int64)
    if (v1576) {
        v1577 = (0 as Int64)
    } else {
        v1577 = (1 as Int64)
    }
    let v1578: Int64 = (0 as Int64) + (1 as Int64)
    let v1579: Int64 = v1578 + (1 as Int64)
    let v1580: Int64 = v1579 + (1 as Int64)
    let v1581: Int64 = v1580 + (1 as Int64)
    let v1582: Int64 = v1581 + (1 as Int64)
    let v1583: Int64 = (0 as Int64) + (1 as Int64)
    let v1584: Int64 = v1583 + (1 as Int64)
    let v1585: Int64 = v1584 + (1 as Int64)
    let v1586: Int64 = v1585 + (1 as Int64)
    let v1587: Int64 = v1586 + (1 as Int64)
    let v1588: Bool = (v1582 == v1587)
    var v1589: Int64 = (0 as Int64)
    if (v1588) {
        v1589 = (0 as Int64)
    } else {
        v1589 = (1 as Int64)
    }
    let v1592: Int64 = (v1577 &+ v1589)
    let v1595: Int64 = (v1573 &+ v1592)
    let v1596: Int64 = (0 as Int64) + (1 as Int64)
    let v1597: Int64 = v1596 + (1 as Int64)
    let v1598: Int64 = v1597 + (1 as Int64)
    let v1599: Int64 = v1598 + (1 as Int64)
    let v1600: Int64 = (0 as Int64) + (1 as Int64)
    let v1601: Int64 = v1600 + (1 as Int64)
    let v1602: Int64 = v1601 + (1 as Int64)
    let v1603: Int64 = v1602 + (1 as Int64)
    let v1604: Bool = (v1599 == v1603)
    var v1605: Int64 = (0 as Int64)
    if (v1604) {
        v1605 = (0 as Int64)
    } else {
        v1605 = (1 as Int64)
    }
    let v1606: Int64 = (0 as Int64) + (1 as Int64)
    let v1607: Int64 = (0 as Int64) + (1 as Int64)
    let v1608: Bool = (v1606 == v1607)
    var v1609: Int64 = (0 as Int64)
    if (v1608) {
        v1609 = (0 as Int64)
    } else {
        v1609 = (1 as Int64)
    }
    let v1610: Int64 = (0 as Int64) + (1 as Int64)
    let v1611: Int64 = v1610 + (1 as Int64)
    let v1612: Int64 = v1611 + (1 as Int64)
    let v1613: Int64 = v1612 + (1 as Int64)
    let v1614: Int64 = v1613 + (1 as Int64)
    let v1615: Int64 = (0 as Int64) + (1 as Int64)
    let v1616: Int64 = v1615 + (1 as Int64)
    let v1617: Int64 = v1616 + (1 as Int64)
    let v1618: Int64 = v1617 + (1 as Int64)
    let v1619: Int64 = v1618 + (1 as Int64)
    let v1620: Bool = (v1614 == v1619)
    var v1621: Int64 = (0 as Int64)
    if (v1620) {
        v1621 = (0 as Int64)
    } else {
        v1621 = (1 as Int64)
    }
    let v1624: Int64 = (v1609 &+ v1621)
    let v1627: Int64 = (v1605 &+ v1624)
    let v1628: Int64 = (0 as Int64) + (1 as Int64)
    let v1629: Int64 = v1628 + (1 as Int64)
    let v1630: Int64 = v1629 + (1 as Int64)
    let v1631: Int64 = v1630 + (1 as Int64)
    let v1632: Int64 = (0 as Int64) + (1 as Int64)
    let v1633: Int64 = v1632 + (1 as Int64)
    let v1634: Int64 = v1633 + (1 as Int64)
    let v1635: Int64 = v1634 + (1 as Int64)
    let v1636: Bool = (v1631 == v1635)
    var v1637: Int64 = (0 as Int64)
    if (v1636) {
        v1637 = (0 as Int64)
    } else {
        v1637 = (1 as Int64)
    }
    let v1638: Int64 = (0 as Int64) + (1 as Int64)
    let v1639: Int64 = (0 as Int64) + (1 as Int64)
    let v1640: Bool = (v1638 == v1639)
    var v1641: Int64 = (0 as Int64)
    if (v1640) {
        v1641 = (0 as Int64)
    } else {
        v1641 = (1 as Int64)
    }
    let v1642: Int64 = (0 as Int64) + (1 as Int64)
    let v1643: Int64 = v1642 + (1 as Int64)
    let v1644: Int64 = v1643 + (1 as Int64)
    let v1645: Int64 = v1644 + (1 as Int64)
    let v1646: Int64 = v1645 + (1 as Int64)
    let v1647: Int64 = (0 as Int64) + (1 as Int64)
    let v1648: Int64 = v1647 + (1 as Int64)
    let v1649: Int64 = v1648 + (1 as Int64)
    let v1650: Int64 = v1649 + (1 as Int64)
    let v1651: Int64 = v1650 + (1 as Int64)
    let v1652: Bool = (v1646 == v1651)
    var v1653: Int64 = (0 as Int64)
    if (v1652) {
        v1653 = (0 as Int64)
    } else {
        v1653 = (1 as Int64)
    }
    let v1656: Int64 = (v1641 &+ v1653)
    let v1659: Int64 = (v1637 &+ v1656)
    let v1660: Int64 = (v1627 &+ v1659)
    let v1661: Int64 = (v1595 &+ v1660)
    let v1662: Int64 = (v1563 &+ v1661)
    let v1663: Int64 = (v1531 &+ v1662)
    let v1664: Int64 = (v1499 &+ v1663)
    let v1665: Bool = (v1467 == (0 as Int64))
    let v1666: Bool = (v1664 == v1467)
    let v1667: Bool = (v1665 && v1666)
    if (v1667) {
    } else {
        "typed-FX-statement-stale-writer-conflict-program-append-associativity-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v1668: Int64 = (0 as Int64) + (1 as Int64)
    let v1669: Int64 = v1668 + (1 as Int64)
    let v1670: Int64 = v1669 + (1 as Int64)
    let v1671: Int64 = v1670 + (1 as Int64)
    let v1672: Int64 = (0 as Int64) + (1 as Int64)
    let v1673: Int64 = v1672 + (1 as Int64)
    let v1674: Int64 = v1673 + (1 as Int64)
    let v1675: Int64 = v1674 + (1 as Int64)
    let v1676: Bool = (v1671 == v1675)
    var v1677: Int64 = (0 as Int64)
    if (v1676) {
        v1677 = (0 as Int64)
    } else {
        v1677 = (1 as Int64)
    }
    let v1678: Int64 = (0 as Int64) + (1 as Int64)
    let v1679: Int64 = (0 as Int64) + (1 as Int64)
    let v1680: Bool = (v1678 == v1679)
    var v1681: Int64 = (0 as Int64)
    if (v1680) {
        v1681 = (0 as Int64)
    } else {
        v1681 = (1 as Int64)
    }
    let v1682: Int64 = (0 as Int64) + (1 as Int64)
    let v1683: Int64 = v1682 + (1 as Int64)
    let v1684: Int64 = v1683 + (1 as Int64)
    let v1685: Int64 = v1684 + (1 as Int64)
    let v1686: Int64 = v1685 + (1 as Int64)
    let v1687: Int64 = (0 as Int64) + (1 as Int64)
    let v1688: Int64 = v1687 + (1 as Int64)
    let v1689: Int64 = v1688 + (1 as Int64)
    let v1690: Int64 = v1689 + (1 as Int64)
    let v1691: Int64 = v1690 + (1 as Int64)
    let v1692: Bool = (v1686 == v1691)
    var v1693: Int64 = (0 as Int64)
    if (v1692) {
        v1693 = (0 as Int64)
    } else {
        v1693 = (1 as Int64)
    }
    let v1696: Int64 = (v1681 &+ v1693)
    let v1699: Int64 = (v1677 &+ v1696)
    let v1700: Int64 = (0 as Int64) + (1 as Int64)
    let v1701: Int64 = v1700 + (1 as Int64)
    let v1702: Int64 = v1701 + (1 as Int64)
    let v1703: Int64 = v1702 + (1 as Int64)
    let v1704: Int64 = (0 as Int64) + (1 as Int64)
    let v1705: Int64 = v1704 + (1 as Int64)
    let v1706: Int64 = v1705 + (1 as Int64)
    let v1707: Int64 = v1706 + (1 as Int64)
    let v1708: Bool = (v1703 == v1707)
    var v1709: Int64 = (0 as Int64)
    if (v1708) {
        v1709 = (0 as Int64)
    } else {
        v1709 = (1 as Int64)
    }
    let v1710: Int64 = (0 as Int64) + (1 as Int64)
    let v1711: Int64 = (0 as Int64) + (1 as Int64)
    let v1712: Bool = (v1710 == v1711)
    var v1713: Int64 = (0 as Int64)
    if (v1712) {
        v1713 = (0 as Int64)
    } else {
        v1713 = (1 as Int64)
    }
    let v1714: Int64 = (0 as Int64) + (1 as Int64)
    let v1715: Int64 = v1714 + (1 as Int64)
    let v1716: Int64 = v1715 + (1 as Int64)
    let v1717: Int64 = v1716 + (1 as Int64)
    let v1718: Int64 = v1717 + (1 as Int64)
    let v1719: Int64 = (0 as Int64) + (1 as Int64)
    let v1720: Int64 = v1719 + (1 as Int64)
    let v1721: Int64 = v1720 + (1 as Int64)
    let v1722: Int64 = v1721 + (1 as Int64)
    let v1723: Int64 = v1722 + (1 as Int64)
    let v1724: Bool = (v1718 == v1723)
    var v1725: Int64 = (0 as Int64)
    if (v1724) {
        v1725 = (0 as Int64)
    } else {
        v1725 = (1 as Int64)
    }
    let v1728: Int64 = (v1713 &+ v1725)
    let v1731: Int64 = (v1709 &+ v1728)
    let v1732: Int64 = (v1699 &+ v1731)
    let v1733: Int64 = (0 as Int64) + (1 as Int64)
    let v1734: Int64 = v1733 + (1 as Int64)
    let v1735: Int64 = v1734 + (1 as Int64)
    let v1736: Int64 = v1735 + (1 as Int64)
    let v1737: Int64 = (0 as Int64) + (1 as Int64)
    let v1738: Int64 = v1737 + (1 as Int64)
    let v1739: Int64 = v1738 + (1 as Int64)
    let v1740: Int64 = v1739 + (1 as Int64)
    let v1741: Bool = (v1736 == v1740)
    var v1742: Int64 = (0 as Int64)
    if (v1741) {
        v1742 = (0 as Int64)
    } else {
        v1742 = (1 as Int64)
    }
    let v1743: Int64 = (0 as Int64) + (1 as Int64)
    let v1744: Int64 = (0 as Int64) + (1 as Int64)
    let v1745: Bool = (v1743 == v1744)
    var v1746: Int64 = (0 as Int64)
    if (v1745) {
        v1746 = (0 as Int64)
    } else {
        v1746 = (1 as Int64)
    }
    let v1747: Int64 = (0 as Int64) + (1 as Int64)
    let v1748: Int64 = v1747 + (1 as Int64)
    let v1749: Int64 = v1748 + (1 as Int64)
    let v1750: Int64 = v1749 + (1 as Int64)
    let v1751: Int64 = v1750 + (1 as Int64)
    let v1752: Int64 = (0 as Int64) + (1 as Int64)
    let v1753: Int64 = v1752 + (1 as Int64)
    let v1754: Int64 = v1753 + (1 as Int64)
    let v1755: Int64 = v1754 + (1 as Int64)
    let v1756: Int64 = v1755 + (1 as Int64)
    let v1757: Bool = (v1751 == v1756)
    var v1758: Int64 = (0 as Int64)
    if (v1757) {
        v1758 = (0 as Int64)
    } else {
        v1758 = (1 as Int64)
    }
    let v1761: Int64 = (v1746 &+ v1758)
    let v1764: Int64 = (v1742 &+ v1761)
    let v1765: Int64 = (0 as Int64) + (1 as Int64)
    let v1766: Int64 = v1765 + (1 as Int64)
    let v1767: Int64 = v1766 + (1 as Int64)
    let v1768: Int64 = v1767 + (1 as Int64)
    let v1769: Int64 = (0 as Int64) + (1 as Int64)
    let v1770: Int64 = v1769 + (1 as Int64)
    let v1771: Int64 = v1770 + (1 as Int64)
    let v1772: Int64 = v1771 + (1 as Int64)
    let v1773: Bool = (v1768 == v1772)
    var v1774: Int64 = (0 as Int64)
    if (v1773) {
        v1774 = (0 as Int64)
    } else {
        v1774 = (1 as Int64)
    }
    let v1775: Int64 = (0 as Int64) + (1 as Int64)
    let v1776: Int64 = (0 as Int64) + (1 as Int64)
    let v1777: Bool = (v1775 == v1776)
    var v1778: Int64 = (0 as Int64)
    if (v1777) {
        v1778 = (0 as Int64)
    } else {
        v1778 = (1 as Int64)
    }
    let v1779: Int64 = (0 as Int64) + (1 as Int64)
    let v1780: Int64 = v1779 + (1 as Int64)
    let v1781: Int64 = v1780 + (1 as Int64)
    let v1782: Int64 = v1781 + (1 as Int64)
    let v1783: Int64 = v1782 + (1 as Int64)
    let v1784: Int64 = (0 as Int64) + (1 as Int64)
    let v1785: Int64 = v1784 + (1 as Int64)
    let v1786: Int64 = v1785 + (1 as Int64)
    let v1787: Int64 = v1786 + (1 as Int64)
    let v1788: Int64 = v1787 + (1 as Int64)
    let v1789: Bool = (v1783 == v1788)
    var v1790: Int64 = (0 as Int64)
    if (v1789) {
        v1790 = (0 as Int64)
    } else {
        v1790 = (1 as Int64)
    }
    let v1793: Int64 = (v1778 &+ v1790)
    let v1796: Int64 = (v1774 &+ v1793)
    let v1797: Int64 = (0 as Int64) + (1 as Int64)
    let v1798: Int64 = v1797 + (1 as Int64)
    let v1799: Int64 = v1798 + (1 as Int64)
    let v1800: Int64 = v1799 + (1 as Int64)
    let v1801: Int64 = (0 as Int64) + (1 as Int64)
    let v1802: Int64 = v1801 + (1 as Int64)
    let v1803: Int64 = v1802 + (1 as Int64)
    let v1804: Int64 = v1803 + (1 as Int64)
    let v1805: Bool = (v1800 == v1804)
    var v1806: Int64 = (0 as Int64)
    if (v1805) {
        v1806 = (0 as Int64)
    } else {
        v1806 = (1 as Int64)
    }
    let v1807: Int64 = (0 as Int64) + (1 as Int64)
    let v1808: Int64 = (0 as Int64) + (1 as Int64)
    let v1809: Bool = (v1807 == v1808)
    var v1810: Int64 = (0 as Int64)
    if (v1809) {
        v1810 = (0 as Int64)
    } else {
        v1810 = (1 as Int64)
    }
    let v1811: Int64 = (0 as Int64) + (1 as Int64)
    let v1812: Int64 = v1811 + (1 as Int64)
    let v1813: Int64 = v1812 + (1 as Int64)
    let v1814: Int64 = v1813 + (1 as Int64)
    let v1815: Int64 = v1814 + (1 as Int64)
    let v1816: Int64 = (0 as Int64) + (1 as Int64)
    let v1817: Int64 = v1816 + (1 as Int64)
    let v1818: Int64 = v1817 + (1 as Int64)
    let v1819: Int64 = v1818 + (1 as Int64)
    let v1820: Int64 = v1819 + (1 as Int64)
    let v1821: Bool = (v1815 == v1820)
    var v1822: Int64 = (0 as Int64)
    if (v1821) {
        v1822 = (0 as Int64)
    } else {
        v1822 = (1 as Int64)
    }
    let v1825: Int64 = (v1810 &+ v1822)
    let v1828: Int64 = (v1806 &+ v1825)
    let v1829: Int64 = (0 as Int64) + (1 as Int64)
    let v1830: Int64 = v1829 + (1 as Int64)
    let v1831: Int64 = v1830 + (1 as Int64)
    let v1832: Int64 = v1831 + (1 as Int64)
    let v1833: Int64 = (0 as Int64) + (1 as Int64)
    let v1834: Int64 = v1833 + (1 as Int64)
    let v1835: Int64 = v1834 + (1 as Int64)
    let v1836: Int64 = v1835 + (1 as Int64)
    let v1837: Bool = (v1832 == v1836)
    var v1838: Int64 = (0 as Int64)
    if (v1837) {
        v1838 = (0 as Int64)
    } else {
        v1838 = (1 as Int64)
    }
    let v1839: Int64 = (0 as Int64) + (1 as Int64)
    let v1840: Int64 = (0 as Int64) + (1 as Int64)
    let v1841: Bool = (v1839 == v1840)
    var v1842: Int64 = (0 as Int64)
    if (v1841) {
        v1842 = (0 as Int64)
    } else {
        v1842 = (1 as Int64)
    }
    let v1843: Int64 = (0 as Int64) + (1 as Int64)
    let v1844: Int64 = v1843 + (1 as Int64)
    let v1845: Int64 = v1844 + (1 as Int64)
    let v1846: Int64 = v1845 + (1 as Int64)
    let v1847: Int64 = v1846 + (1 as Int64)
    let v1848: Int64 = (0 as Int64) + (1 as Int64)
    let v1849: Int64 = v1848 + (1 as Int64)
    let v1850: Int64 = v1849 + (1 as Int64)
    let v1851: Int64 = v1850 + (1 as Int64)
    let v1852: Int64 = v1851 + (1 as Int64)
    let v1853: Bool = (v1847 == v1852)
    var v1854: Int64 = (0 as Int64)
    if (v1853) {
        v1854 = (0 as Int64)
    } else {
        v1854 = (1 as Int64)
    }
    let v1857: Int64 = (v1842 &+ v1854)
    let v1860: Int64 = (v1838 &+ v1857)
    let v1861: Int64 = (v1828 &+ v1860)
    let v1862: Int64 = (v1796 &+ v1861)
    let v1863: Int64 = (v1764 &+ v1862)
    let v1864: Int64 = (v1732 &+ v1863)
    let v1865: Int64 = (0 as Int64) + (1 as Int64)
    let v1866: Int64 = v1865 + (1 as Int64)
    let v1867: Int64 = v1866 + (1 as Int64)
    let v1868: Int64 = v1867 + (1 as Int64)
    let v1869: Int64 = (0 as Int64) + (1 as Int64)
    let v1870: Int64 = v1869 + (1 as Int64)
    let v1871: Int64 = v1870 + (1 as Int64)
    let v1872: Int64 = v1871 + (1 as Int64)
    let v1873: Bool = (v1868 == v1872)
    var v1874: Int64 = (0 as Int64)
    if (v1873) {
        v1874 = (0 as Int64)
    } else {
        v1874 = (1 as Int64)
    }
    let v1875: Int64 = (0 as Int64) + (1 as Int64)
    let v1876: Int64 = (0 as Int64) + (1 as Int64)
    let v1877: Bool = (v1875 == v1876)
    var v1878: Int64 = (0 as Int64)
    if (v1877) {
        v1878 = (0 as Int64)
    } else {
        v1878 = (1 as Int64)
    }
    let v1879: Int64 = (0 as Int64) + (1 as Int64)
    let v1880: Int64 = v1879 + (1 as Int64)
    let v1881: Int64 = v1880 + (1 as Int64)
    let v1882: Int64 = v1881 + (1 as Int64)
    let v1883: Int64 = v1882 + (1 as Int64)
    let v1884: Int64 = (0 as Int64) + (1 as Int64)
    let v1885: Int64 = v1884 + (1 as Int64)
    let v1886: Int64 = v1885 + (1 as Int64)
    let v1887: Int64 = v1886 + (1 as Int64)
    let v1888: Int64 = v1887 + (1 as Int64)
    let v1889: Bool = (v1883 == v1888)
    var v1890: Int64 = (0 as Int64)
    if (v1889) {
        v1890 = (0 as Int64)
    } else {
        v1890 = (1 as Int64)
    }
    let v1891: Int64 = (v1875 &+ v1883)
    let v1892: Int64 = (v1876 &+ v1888)
    let v1893: Int64 = (v1878 &+ v1890)
    let v1894: Int64 = (v1868 &+ v1891)
    let v1895: Int64 = (v1872 &+ v1892)
    let v1896: Int64 = (v1874 &+ v1893)
    let v1897: Int64 = (v1895 &+ v1896)
    let v1898: Int64 = (v1894 &+ v1897)
    let v1899: Int64 = ((3 as Int64) &+ v1898)
    let v1900: Int64 = (0 as Int64) + (1 as Int64)
    let v1901: Int64 = v1900 + (1 as Int64)
    let v1902: Int64 = v1901 + (1 as Int64)
    let v1903: Int64 = v1902 + (1 as Int64)
    let v1904: Int64 = (0 as Int64) + (1 as Int64)
    let v1905: Int64 = v1904 + (1 as Int64)
    let v1906: Int64 = v1905 + (1 as Int64)
    let v1907: Int64 = v1906 + (1 as Int64)
    let v1908: Bool = (v1903 == v1907)
    var v1909: Int64 = (0 as Int64)
    if (v1908) {
        v1909 = (0 as Int64)
    } else {
        v1909 = (1 as Int64)
    }
    let v1910: Int64 = (0 as Int64) + (1 as Int64)
    let v1911: Int64 = (0 as Int64) + (1 as Int64)
    let v1912: Bool = (v1910 == v1911)
    var v1913: Int64 = (0 as Int64)
    if (v1912) {
        v1913 = (0 as Int64)
    } else {
        v1913 = (1 as Int64)
    }
    let v1914: Int64 = (0 as Int64) + (1 as Int64)
    let v1915: Int64 = v1914 + (1 as Int64)
    let v1916: Int64 = v1915 + (1 as Int64)
    let v1917: Int64 = v1916 + (1 as Int64)
    let v1918: Int64 = v1917 + (1 as Int64)
    let v1919: Int64 = (0 as Int64) + (1 as Int64)
    let v1920: Int64 = v1919 + (1 as Int64)
    let v1921: Int64 = v1920 + (1 as Int64)
    let v1922: Int64 = v1921 + (1 as Int64)
    let v1923: Int64 = v1922 + (1 as Int64)
    let v1924: Bool = (v1918 == v1923)
    var v1925: Int64 = (0 as Int64)
    if (v1924) {
        v1925 = (0 as Int64)
    } else {
        v1925 = (1 as Int64)
    }
    let v1926: Int64 = (v1910 &+ v1918)
    let v1927: Int64 = (v1911 &+ v1923)
    let v1928: Int64 = (v1913 &+ v1925)
    let v1929: Int64 = (v1903 &+ v1926)
    let v1930: Int64 = (v1907 &+ v1927)
    let v1931: Int64 = (v1909 &+ v1928)
    let v1932: Int64 = (v1930 &+ v1931)
    let v1933: Int64 = (v1929 &+ v1932)
    let v1934: Int64 = ((3 as Int64) &+ v1933)
    let v1935: Bool = (v1899 == v1934)
    var v1972: US0 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (0 as Int64), f1: (0 as Int64), f2: (0 as Int64), f3: (0 as Int64), f4: (0 as Int64), f5: "")
    if (v1935) {
        let v1936: Int64 = (0 as Int64) + (1 as Int64)
        let v1937: Int64 = v1936 + (1 as Int64)
        let v1938: Int64 = v1937 + (1 as Int64)
        let v1939: Int64 = v1938 + (1 as Int64)
        let v1940: Int64 = (0 as Int64) + (1 as Int64)
        let v1941: Int64 = v1940 + (1 as Int64)
        let v1942: Int64 = v1941 + (1 as Int64)
        let v1943: Int64 = v1942 + (1 as Int64)
        let v1944: Bool = (v1939 == v1943)
        var v1945: Int64 = (0 as Int64)
        if (v1944) {
            v1945 = (0 as Int64)
        } else {
            v1945 = (1 as Int64)
        }
        let v1946: Int64 = (0 as Int64) + (1 as Int64)
        let v1947: Int64 = (0 as Int64) + (1 as Int64)
        let v1948: Bool = (v1946 == v1947)
        var v1949: Int64 = (0 as Int64)
        if (v1948) {
            v1949 = (0 as Int64)
        } else {
            v1949 = (1 as Int64)
        }
        let v1950: Int64 = (0 as Int64) + (1 as Int64)
        let v1951: Int64 = v1950 + (1 as Int64)
        let v1952: Int64 = v1951 + (1 as Int64)
        let v1953: Int64 = v1952 + (1 as Int64)
        let v1954: Int64 = v1953 + (1 as Int64)
        let v1955: Int64 = (0 as Int64) + (1 as Int64)
        let v1956: Int64 = v1955 + (1 as Int64)
        let v1957: Int64 = v1956 + (1 as Int64)
        let v1958: Int64 = v1957 + (1 as Int64)
        let v1959: Int64 = v1958 + (1 as Int64)
        let v1960: Bool = (v1954 == v1959)
        var v1961: Int64 = (0 as Int64)
        if (v1960) {
            v1961 = (0 as Int64)
        } else {
            v1961 = (1 as Int64)
        }
        let v1962: Int64 = (v1946 &+ v1954)
        let v1963: Int64 = (v1947 &+ v1959)
        let v1964: Int64 = (v1949 &+ v1961)
        let v1965: Int64 = (v1939 &+ v1962)
        let v1966: Int64 = (v1943 &+ v1963)
        let v1967: Int64 = (v1945 &+ v1964)
        let v1968: String = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v1972 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (1 as Int64), f1: (3 as Int64), f2: v1965, f3: v1966, f4: v1967, f5: v1968)
    } else {
        let v1970: String = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v1972 = US0_TypedFxHashedStatementChecksumValidationRejected(f0: v1899, f1: v1934, f2: v1970)
    }
    var v1991: Int64 = (0 as Int64)
    var v1992: Int64 = (0 as Int64)
    var v1995: Int64 = (0 as Int64)
    var v1999: Int64 = (0 as Int64)
    switch v1972.tag {
        case 0:
            var v1976: Int64 = (v1972 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f0
            var v1977: Int64 = (v1972 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f1
            var v1978: Int64 = (v1972 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f2
            var v1979: Int64 = (v1972 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f3
            var v1980: Int64 = (v1972 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f4
            var v1981: String = (v1972 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f5
            v1991 = (1 as Int64)
            v1992 = (0 as Int64)
            v1995 = v1976
            v1999 = v1980
        case 1:
            var v1973: Int64 = (v1972 as! US0_TypedFxHashedStatementChecksumValidationRejected).f0
            var v1974: Int64 = (v1972 as! US0_TypedFxHashedStatementChecksumValidationRejected).f1
            var v1975: String = (v1972 as! US0_TypedFxHashedStatementChecksumValidationRejected).f2
            v1991 = (0 as Int64)
            v1992 = (1 as Int64)
            v1995 = (0 as Int64)
            v1999 = (0 as Int64)
        default:
            fatalError("unreachable union case")
    }
    let v2000: Int64 = (0 as Int64) + (1 as Int64)
    let v2001: Int64 = v2000 + (1 as Int64)
    let v2002: Int64 = v2001 + (1 as Int64)
    let v2003: Int64 = v2002 + (1 as Int64)
    let v2004: Int64 = (0 as Int64) + (1 as Int64)
    let v2005: Int64 = v2004 + (1 as Int64)
    let v2006: Int64 = v2005 + (1 as Int64)
    let v2007: Int64 = v2006 + (1 as Int64)
    let v2008: Bool = (v2003 == v2007)
    var v2009: Int64 = (0 as Int64)
    if (v2008) {
        v2009 = (0 as Int64)
    } else {
        v2009 = (1 as Int64)
    }
    let v2010: Int64 = (0 as Int64) + (1 as Int64)
    let v2011: Int64 = (0 as Int64) + (1 as Int64)
    let v2012: Bool = (v2010 == v2011)
    var v2013: Int64 = (0 as Int64)
    if (v2012) {
        v2013 = (0 as Int64)
    } else {
        v2013 = (1 as Int64)
    }
    let v2014: Int64 = (0 as Int64) + (1 as Int64)
    let v2015: Int64 = v2014 + (1 as Int64)
    let v2016: Int64 = v2015 + (1 as Int64)
    let v2017: Int64 = v2016 + (1 as Int64)
    let v2018: Int64 = v2017 + (1 as Int64)
    let v2019: Int64 = (0 as Int64) + (1 as Int64)
    let v2020: Int64 = v2019 + (1 as Int64)
    let v2021: Int64 = v2020 + (1 as Int64)
    let v2022: Int64 = v2021 + (1 as Int64)
    let v2023: Int64 = v2022 + (1 as Int64)
    let v2024: Bool = (v2018 == v2023)
    var v2025: Int64 = (0 as Int64)
    if (v2024) {
        v2025 = (0 as Int64)
    } else {
        v2025 = (1 as Int64)
    }
    let v2028: Int64 = (v2013 &+ v2025)
    let v2031: Int64 = (v2009 &+ v2028)
    let v2032: Int64 = (0 as Int64) + (1 as Int64)
    let v2033: Int64 = v2032 + (1 as Int64)
    let v2034: Int64 = v2033 + (1 as Int64)
    let v2035: Int64 = v2034 + (1 as Int64)
    let v2036: Int64 = (0 as Int64) + (1 as Int64)
    let v2037: Int64 = v2036 + (1 as Int64)
    let v2038: Int64 = v2037 + (1 as Int64)
    let v2039: Int64 = v2038 + (1 as Int64)
    let v2040: Bool = (v2035 == v2039)
    var v2041: Int64 = (0 as Int64)
    if (v2040) {
        v2041 = (0 as Int64)
    } else {
        v2041 = (1 as Int64)
    }
    let v2042: Int64 = (0 as Int64) + (1 as Int64)
    let v2043: Int64 = (0 as Int64) + (1 as Int64)
    let v2044: Bool = (v2042 == v2043)
    var v2045: Int64 = (0 as Int64)
    if (v2044) {
        v2045 = (0 as Int64)
    } else {
        v2045 = (1 as Int64)
    }
    let v2046: Int64 = (0 as Int64) + (1 as Int64)
    let v2047: Int64 = v2046 + (1 as Int64)
    let v2048: Int64 = v2047 + (1 as Int64)
    let v2049: Int64 = v2048 + (1 as Int64)
    let v2050: Int64 = v2049 + (1 as Int64)
    let v2051: Int64 = (0 as Int64) + (1 as Int64)
    let v2052: Int64 = v2051 + (1 as Int64)
    let v2053: Int64 = v2052 + (1 as Int64)
    let v2054: Int64 = v2053 + (1 as Int64)
    let v2055: Int64 = v2054 + (1 as Int64)
    let v2056: Bool = (v2050 == v2055)
    var v2057: Int64 = (0 as Int64)
    if (v2056) {
        v2057 = (0 as Int64)
    } else {
        v2057 = (1 as Int64)
    }
    let v2060: Int64 = (v2045 &+ v2057)
    let v2063: Int64 = (v2041 &+ v2060)
    let v2064: Int64 = (0 as Int64) + (1 as Int64)
    let v2065: Int64 = v2064 + (1 as Int64)
    let v2066: Int64 = v2065 + (1 as Int64)
    let v2067: Int64 = v2066 + (1 as Int64)
    let v2068: Int64 = (0 as Int64) + (1 as Int64)
    let v2069: Int64 = v2068 + (1 as Int64)
    let v2070: Int64 = v2069 + (1 as Int64)
    let v2071: Int64 = v2070 + (1 as Int64)
    let v2072: Bool = (v2067 == v2071)
    var v2073: Int64 = (0 as Int64)
    if (v2072) {
        v2073 = (0 as Int64)
    } else {
        v2073 = (1 as Int64)
    }
    let v2074: Int64 = (0 as Int64) + (1 as Int64)
    let v2075: Int64 = (0 as Int64) + (1 as Int64)
    let v2076: Bool = (v2074 == v2075)
    var v2077: Int64 = (0 as Int64)
    if (v2076) {
        v2077 = (0 as Int64)
    } else {
        v2077 = (1 as Int64)
    }
    let v2078: Int64 = (0 as Int64) + (1 as Int64)
    let v2079: Int64 = v2078 + (1 as Int64)
    let v2080: Int64 = v2079 + (1 as Int64)
    let v2081: Int64 = v2080 + (1 as Int64)
    let v2082: Int64 = v2081 + (1 as Int64)
    let v2083: Int64 = (0 as Int64) + (1 as Int64)
    let v2084: Int64 = v2083 + (1 as Int64)
    let v2085: Int64 = v2084 + (1 as Int64)
    let v2086: Int64 = v2085 + (1 as Int64)
    let v2087: Int64 = v2086 + (1 as Int64)
    let v2088: Bool = (v2082 == v2087)
    var v2089: Int64 = (0 as Int64)
    if (v2088) {
        v2089 = (0 as Int64)
    } else {
        v2089 = (1 as Int64)
    }
    let v2092: Int64 = (v2077 &+ v2089)
    let v2095: Int64 = (v2073 &+ v2092)
    let v2096: Int64 = (0 as Int64) + (1 as Int64)
    let v2097: Int64 = v2096 + (1 as Int64)
    let v2098: Int64 = v2097 + (1 as Int64)
    let v2099: Int64 = v2098 + (1 as Int64)
    let v2100: Int64 = (0 as Int64) + (1 as Int64)
    let v2101: Int64 = v2100 + (1 as Int64)
    let v2102: Int64 = v2101 + (1 as Int64)
    let v2103: Int64 = v2102 + (1 as Int64)
    let v2104: Bool = (v2099 == v2103)
    var v2105: Int64 = (0 as Int64)
    if (v2104) {
        v2105 = (0 as Int64)
    } else {
        v2105 = (1 as Int64)
    }
    let v2106: Int64 = (0 as Int64) + (1 as Int64)
    let v2107: Int64 = (0 as Int64) + (1 as Int64)
    let v2108: Bool = (v2106 == v2107)
    var v2109: Int64 = (0 as Int64)
    if (v2108) {
        v2109 = (0 as Int64)
    } else {
        v2109 = (1 as Int64)
    }
    let v2110: Int64 = (0 as Int64) + (1 as Int64)
    let v2111: Int64 = v2110 + (1 as Int64)
    let v2112: Int64 = v2111 + (1 as Int64)
    let v2113: Int64 = v2112 + (1 as Int64)
    let v2114: Int64 = v2113 + (1 as Int64)
    let v2115: Int64 = (0 as Int64) + (1 as Int64)
    let v2116: Int64 = v2115 + (1 as Int64)
    let v2117: Int64 = v2116 + (1 as Int64)
    let v2118: Int64 = v2117 + (1 as Int64)
    let v2119: Int64 = v2118 + (1 as Int64)
    let v2120: Bool = (v2114 == v2119)
    var v2121: Int64 = (0 as Int64)
    if (v2120) {
        v2121 = (0 as Int64)
    } else {
        v2121 = (1 as Int64)
    }
    let v2124: Int64 = (v2109 &+ v2121)
    let v2127: Int64 = (v2105 &+ v2124)
    let v2128: Int64 = (v2095 &+ v2127)
    let v2129: Int64 = (v2063 &+ v2128)
    let v2130: Int64 = (v2031 &+ v2129)
    let v2131: Int64 = (v1999 &+ v1992)
    let v2132: Int64 = (v2130 &+ v2131)
    let v2133: Int64 = (v1864 &+ v2132)
    let v2134: Bool = (v1995 == (1 as Int64))
    let v2135: Bool = (v1991 == (1 as Int64))
    let v2136: Bool = (v2133 == (0 as Int64))
    let v2137: Bool = (v2134 && v2135)
    let v2138: Bool = (v2137 && v2136)
    if (v2138) {
    } else {
        "typed-FX-statement-recursive-writer-appended-tail-restart-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v2139: Int64 = (0 as Int64) + (1 as Int64)
    let v2140: Int64 = v2139 + (1 as Int64)
    let v2141: Int64 = v2140 + (1 as Int64)
    let v2142: Int64 = v2141 + (1 as Int64)
    let v2143: Int64 = (0 as Int64) + (1 as Int64)
    let v2144: Int64 = v2143 + (1 as Int64)
    let v2145: Int64 = v2144 + (1 as Int64)
    let v2146: Int64 = v2145 + (1 as Int64)
    let v2147: Bool = (v2142 == v2146)
    var v2148: Int64 = (0 as Int64)
    if (v2147) {
        v2148 = (0 as Int64)
    } else {
        v2148 = (1 as Int64)
    }
    let v2149: Int64 = (0 as Int64) + (1 as Int64)
    let v2150: Int64 = (0 as Int64) + (1 as Int64)
    let v2151: Bool = (v2149 == v2150)
    var v2152: Int64 = (0 as Int64)
    if (v2151) {
        v2152 = (0 as Int64)
    } else {
        v2152 = (1 as Int64)
    }
    let v2153: Int64 = (0 as Int64) + (1 as Int64)
    let v2154: Int64 = v2153 + (1 as Int64)
    let v2155: Int64 = v2154 + (1 as Int64)
    let v2156: Int64 = v2155 + (1 as Int64)
    let v2157: Int64 = v2156 + (1 as Int64)
    let v2158: Int64 = (0 as Int64) + (1 as Int64)
    let v2159: Int64 = v2158 + (1 as Int64)
    let v2160: Int64 = v2159 + (1 as Int64)
    let v2161: Int64 = v2160 + (1 as Int64)
    let v2162: Int64 = v2161 + (1 as Int64)
    let v2163: Bool = (v2157 == v2162)
    var v2164: Int64 = (0 as Int64)
    if (v2163) {
        v2164 = (0 as Int64)
    } else {
        v2164 = (1 as Int64)
    }
    let v2167: Int64 = (v2152 &+ v2164)
    let v2170: Int64 = (v2148 &+ v2167)
    let v2171: Int64 = (0 as Int64) + (1 as Int64)
    let v2172: Int64 = v2171 + (1 as Int64)
    let v2173: Int64 = v2172 + (1 as Int64)
    let v2174: Int64 = v2173 + (1 as Int64)
    let v2175: Int64 = (0 as Int64) + (1 as Int64)
    let v2176: Int64 = v2175 + (1 as Int64)
    let v2177: Int64 = v2176 + (1 as Int64)
    let v2178: Int64 = v2177 + (1 as Int64)
    let v2179: Bool = (v2174 == v2178)
    var v2180: Int64 = (0 as Int64)
    if (v2179) {
        v2180 = (0 as Int64)
    } else {
        v2180 = (1 as Int64)
    }
    let v2181: Int64 = (0 as Int64) + (1 as Int64)
    let v2182: Int64 = (0 as Int64) + (1 as Int64)
    let v2183: Bool = (v2181 == v2182)
    var v2184: Int64 = (0 as Int64)
    if (v2183) {
        v2184 = (0 as Int64)
    } else {
        v2184 = (1 as Int64)
    }
    let v2185: Int64 = (0 as Int64) + (1 as Int64)
    let v2186: Int64 = v2185 + (1 as Int64)
    let v2187: Int64 = v2186 + (1 as Int64)
    let v2188: Int64 = v2187 + (1 as Int64)
    let v2189: Int64 = v2188 + (1 as Int64)
    let v2190: Int64 = (0 as Int64) + (1 as Int64)
    let v2191: Int64 = v2190 + (1 as Int64)
    let v2192: Int64 = v2191 + (1 as Int64)
    let v2193: Int64 = v2192 + (1 as Int64)
    let v2194: Int64 = v2193 + (1 as Int64)
    let v2195: Bool = (v2189 == v2194)
    var v2196: Int64 = (0 as Int64)
    if (v2195) {
        v2196 = (0 as Int64)
    } else {
        v2196 = (1 as Int64)
    }
    let v2199: Int64 = (v2184 &+ v2196)
    let v2202: Int64 = (v2180 &+ v2199)
    let v2203: Int64 = (v2170 &+ v2202)
    let v2204: Int64 = (0 as Int64) + (1 as Int64)
    let v2205: Int64 = v2204 + (1 as Int64)
    let v2206: Int64 = v2205 + (1 as Int64)
    let v2207: Int64 = v2206 + (1 as Int64)
    let v2208: Int64 = (0 as Int64) + (1 as Int64)
    let v2209: Int64 = v2208 + (1 as Int64)
    let v2210: Int64 = v2209 + (1 as Int64)
    let v2211: Int64 = v2210 + (1 as Int64)
    let v2212: Bool = (v2207 == v2211)
    var v2213: Int64 = (0 as Int64)
    if (v2212) {
        v2213 = (0 as Int64)
    } else {
        v2213 = (1 as Int64)
    }
    let v2214: Int64 = (0 as Int64) + (1 as Int64)
    let v2215: Int64 = (0 as Int64) + (1 as Int64)
    let v2216: Bool = (v2214 == v2215)
    var v2217: Int64 = (0 as Int64)
    if (v2216) {
        v2217 = (0 as Int64)
    } else {
        v2217 = (1 as Int64)
    }
    let v2218: Int64 = (0 as Int64) + (1 as Int64)
    let v2219: Int64 = v2218 + (1 as Int64)
    let v2220: Int64 = v2219 + (1 as Int64)
    let v2221: Int64 = v2220 + (1 as Int64)
    let v2222: Int64 = v2221 + (1 as Int64)
    let v2223: Int64 = (0 as Int64) + (1 as Int64)
    let v2224: Int64 = v2223 + (1 as Int64)
    let v2225: Int64 = v2224 + (1 as Int64)
    let v2226: Int64 = v2225 + (1 as Int64)
    let v2227: Int64 = v2226 + (1 as Int64)
    let v2228: Bool = (v2222 == v2227)
    var v2229: Int64 = (0 as Int64)
    if (v2228) {
        v2229 = (0 as Int64)
    } else {
        v2229 = (1 as Int64)
    }
    let v2232: Int64 = (v2217 &+ v2229)
    let v2235: Int64 = (v2213 &+ v2232)
    let v2236: Int64 = (0 as Int64) + (1 as Int64)
    let v2237: Int64 = v2236 + (1 as Int64)
    let v2238: Int64 = v2237 + (1 as Int64)
    let v2239: Int64 = v2238 + (1 as Int64)
    let v2240: Int64 = (0 as Int64) + (1 as Int64)
    let v2241: Int64 = v2240 + (1 as Int64)
    let v2242: Int64 = v2241 + (1 as Int64)
    let v2243: Int64 = v2242 + (1 as Int64)
    let v2244: Bool = (v2239 == v2243)
    var v2245: Int64 = (0 as Int64)
    if (v2244) {
        v2245 = (0 as Int64)
    } else {
        v2245 = (1 as Int64)
    }
    let v2246: Int64 = (0 as Int64) + (1 as Int64)
    let v2247: Int64 = (0 as Int64) + (1 as Int64)
    let v2248: Bool = (v2246 == v2247)
    var v2249: Int64 = (0 as Int64)
    if (v2248) {
        v2249 = (0 as Int64)
    } else {
        v2249 = (1 as Int64)
    }
    let v2250: Int64 = (0 as Int64) + (1 as Int64)
    let v2251: Int64 = v2250 + (1 as Int64)
    let v2252: Int64 = v2251 + (1 as Int64)
    let v2253: Int64 = v2252 + (1 as Int64)
    let v2254: Int64 = v2253 + (1 as Int64)
    let v2255: Int64 = (0 as Int64) + (1 as Int64)
    let v2256: Int64 = v2255 + (1 as Int64)
    let v2257: Int64 = v2256 + (1 as Int64)
    let v2258: Int64 = v2257 + (1 as Int64)
    let v2259: Int64 = v2258 + (1 as Int64)
    let v2260: Bool = (v2254 == v2259)
    var v2261: Int64 = (0 as Int64)
    if (v2260) {
        v2261 = (0 as Int64)
    } else {
        v2261 = (1 as Int64)
    }
    let v2264: Int64 = (v2249 &+ v2261)
    let v2267: Int64 = (v2245 &+ v2264)
    let v2268: Int64 = (v2235 &+ v2267)
    let v2269: Int64 = (v2203 &+ v2268)
    let v2270: Int64 = (0 as Int64) + (1 as Int64)
    let v2271: Int64 = v2270 + (1 as Int64)
    let v2272: Int64 = v2271 + (1 as Int64)
    let v2273: Int64 = v2272 + (1 as Int64)
    let v2274: Int64 = (0 as Int64) + (1 as Int64)
    let v2275: Int64 = v2274 + (1 as Int64)
    let v2276: Int64 = v2275 + (1 as Int64)
    let v2277: Int64 = v2276 + (1 as Int64)
    let v2278: Bool = (v2273 == v2277)
    var v2279: Int64 = (0 as Int64)
    if (v2278) {
        v2279 = (0 as Int64)
    } else {
        v2279 = (1 as Int64)
    }
    let v2280: Int64 = (0 as Int64) + (1 as Int64)
    let v2281: Int64 = (0 as Int64) + (1 as Int64)
    let v2282: Bool = (v2280 == v2281)
    var v2283: Int64 = (0 as Int64)
    if (v2282) {
        v2283 = (0 as Int64)
    } else {
        v2283 = (1 as Int64)
    }
    let v2284: Int64 = (0 as Int64) + (1 as Int64)
    let v2285: Int64 = v2284 + (1 as Int64)
    let v2286: Int64 = v2285 + (1 as Int64)
    let v2287: Int64 = v2286 + (1 as Int64)
    let v2288: Int64 = v2287 + (1 as Int64)
    let v2289: Int64 = (0 as Int64) + (1 as Int64)
    let v2290: Int64 = v2289 + (1 as Int64)
    let v2291: Int64 = v2290 + (1 as Int64)
    let v2292: Int64 = v2291 + (1 as Int64)
    let v2293: Int64 = v2292 + (1 as Int64)
    let v2294: Bool = (v2288 == v2293)
    var v2295: Int64 = (0 as Int64)
    if (v2294) {
        v2295 = (0 as Int64)
    } else {
        v2295 = (1 as Int64)
    }
    let v2296: Int64 = (v2280 &+ v2288)
    let v2297: Int64 = (v2281 &+ v2293)
    let v2298: Int64 = (v2283 &+ v2295)
    let v2299: Int64 = (v2273 &+ v2296)
    let v2300: Int64 = (v2277 &+ v2297)
    let v2301: Int64 = (v2279 &+ v2298)
    let v2302: Int64 = (v2300 &+ v2301)
    let v2303: Int64 = (v2299 &+ v2302)
    let v2304: Int64 = ((3 as Int64) &+ v2303)
    let v2305: Int64 = (0 as Int64) + (1 as Int64)
    let v2306: Int64 = v2305 + (1 as Int64)
    let v2307: Int64 = v2306 + (1 as Int64)
    let v2308: Int64 = v2307 + (1 as Int64)
    let v2309: Int64 = (0 as Int64) + (1 as Int64)
    let v2310: Int64 = v2309 + (1 as Int64)
    let v2311: Int64 = v2310 + (1 as Int64)
    let v2312: Int64 = v2311 + (1 as Int64)
    let v2313: Bool = (v2308 == v2312)
    var v2314: Int64 = (0 as Int64)
    if (v2313) {
        v2314 = (0 as Int64)
    } else {
        v2314 = (1 as Int64)
    }
    let v2315: Int64 = (0 as Int64) + (1 as Int64)
    let v2316: Int64 = (0 as Int64) + (1 as Int64)
    let v2317: Bool = (v2315 == v2316)
    var v2318: Int64 = (0 as Int64)
    if (v2317) {
        v2318 = (0 as Int64)
    } else {
        v2318 = (1 as Int64)
    }
    let v2319: Int64 = (0 as Int64) + (1 as Int64)
    let v2320: Int64 = v2319 + (1 as Int64)
    let v2321: Int64 = v2320 + (1 as Int64)
    let v2322: Int64 = v2321 + (1 as Int64)
    let v2323: Int64 = v2322 + (1 as Int64)
    let v2324: Int64 = (0 as Int64) + (1 as Int64)
    let v2325: Int64 = v2324 + (1 as Int64)
    let v2326: Int64 = v2325 + (1 as Int64)
    let v2327: Int64 = v2326 + (1 as Int64)
    let v2328: Int64 = v2327 + (1 as Int64)
    let v2329: Bool = (v2323 == v2328)
    var v2330: Int64 = (0 as Int64)
    if (v2329) {
        v2330 = (0 as Int64)
    } else {
        v2330 = (1 as Int64)
    }
    let v2331: Int64 = (v2315 &+ v2323)
    let v2332: Int64 = (v2316 &+ v2328)
    let v2333: Int64 = (v2318 &+ v2330)
    let v2334: Int64 = (v2308 &+ v2331)
    let v2335: Int64 = (v2312 &+ v2332)
    let v2336: Int64 = (v2314 &+ v2333)
    let v2337: Int64 = (v2335 &+ v2336)
    let v2338: Int64 = (v2334 &+ v2337)
    let v2339: Int64 = ((3 as Int64) &+ v2338)
    let v2340: Bool = (v2304 == v2339)
    var v2377: US0 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (0 as Int64), f1: (0 as Int64), f2: (0 as Int64), f3: (0 as Int64), f4: (0 as Int64), f5: "")
    if (v2340) {
        let v2341: Int64 = (0 as Int64) + (1 as Int64)
        let v2342: Int64 = v2341 + (1 as Int64)
        let v2343: Int64 = v2342 + (1 as Int64)
        let v2344: Int64 = v2343 + (1 as Int64)
        let v2345: Int64 = (0 as Int64) + (1 as Int64)
        let v2346: Int64 = v2345 + (1 as Int64)
        let v2347: Int64 = v2346 + (1 as Int64)
        let v2348: Int64 = v2347 + (1 as Int64)
        let v2349: Bool = (v2344 == v2348)
        var v2350: Int64 = (0 as Int64)
        if (v2349) {
            v2350 = (0 as Int64)
        } else {
            v2350 = (1 as Int64)
        }
        let v2351: Int64 = (0 as Int64) + (1 as Int64)
        let v2352: Int64 = (0 as Int64) + (1 as Int64)
        let v2353: Bool = (v2351 == v2352)
        var v2354: Int64 = (0 as Int64)
        if (v2353) {
            v2354 = (0 as Int64)
        } else {
            v2354 = (1 as Int64)
        }
        let v2355: Int64 = (0 as Int64) + (1 as Int64)
        let v2356: Int64 = v2355 + (1 as Int64)
        let v2357: Int64 = v2356 + (1 as Int64)
        let v2358: Int64 = v2357 + (1 as Int64)
        let v2359: Int64 = v2358 + (1 as Int64)
        let v2360: Int64 = (0 as Int64) + (1 as Int64)
        let v2361: Int64 = v2360 + (1 as Int64)
        let v2362: Int64 = v2361 + (1 as Int64)
        let v2363: Int64 = v2362 + (1 as Int64)
        let v2364: Int64 = v2363 + (1 as Int64)
        let v2365: Bool = (v2359 == v2364)
        var v2366: Int64 = (0 as Int64)
        if (v2365) {
            v2366 = (0 as Int64)
        } else {
            v2366 = (1 as Int64)
        }
        let v2367: Int64 = (v2351 &+ v2359)
        let v2368: Int64 = (v2352 &+ v2364)
        let v2369: Int64 = (v2354 &+ v2366)
        let v2370: Int64 = (v2344 &+ v2367)
        let v2371: Int64 = (v2348 &+ v2368)
        let v2372: Int64 = (v2350 &+ v2369)
        let v2373: String = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v2377 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (1 as Int64), f1: (3 as Int64), f2: v2370, f3: v2371, f4: v2372, f5: v2373)
    } else {
        let v2375: String = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v2377 = US0_TypedFxHashedStatementChecksumValidationRejected(f0: v2304, f1: v2339, f2: v2375)
    }
    var v2396: Int64 = (0 as Int64)
    var v2397: Int64 = (0 as Int64)
    var v2404: Int64 = (0 as Int64)
    switch v2377.tag {
        case 0:
            var v2381: Int64 = (v2377 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f0
            var v2382: Int64 = (v2377 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f1
            var v2383: Int64 = (v2377 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f2
            var v2384: Int64 = (v2377 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f3
            var v2385: Int64 = (v2377 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f4
            var v2386: String = (v2377 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f5
            v2396 = (1 as Int64)
            v2397 = (0 as Int64)
            v2404 = v2385
        case 1:
            var v2378: Int64 = (v2377 as! US0_TypedFxHashedStatementChecksumValidationRejected).f0
            var v2379: Int64 = (v2377 as! US0_TypedFxHashedStatementChecksumValidationRejected).f1
            var v2380: String = (v2377 as! US0_TypedFxHashedStatementChecksumValidationRejected).f2
            v2396 = (0 as Int64)
            v2397 = (1 as Int64)
            v2404 = (0 as Int64)
        default:
            fatalError("unreachable union case")
    }
    let v2405: Int64 = (0 as Int64) + (1 as Int64)
    let v2406: Int64 = v2405 + (1 as Int64)
    let v2407: Int64 = v2406 + (1 as Int64)
    let v2408: Int64 = v2407 + (1 as Int64)
    let v2409: Int64 = (0 as Int64) + (1 as Int64)
    let v2410: Int64 = v2409 + (1 as Int64)
    let v2411: Int64 = v2410 + (1 as Int64)
    let v2412: Int64 = v2411 + (1 as Int64)
    let v2413: Bool = (v2408 == v2412)
    var v2414: Int64 = (0 as Int64)
    if (v2413) {
        v2414 = (0 as Int64)
    } else {
        v2414 = (1 as Int64)
    }
    let v2415: Int64 = (0 as Int64) + (1 as Int64)
    let v2416: Int64 = (0 as Int64) + (1 as Int64)
    let v2417: Bool = (v2415 == v2416)
    var v2418: Int64 = (0 as Int64)
    if (v2417) {
        v2418 = (0 as Int64)
    } else {
        v2418 = (1 as Int64)
    }
    let v2419: Int64 = (0 as Int64) + (1 as Int64)
    let v2420: Int64 = v2419 + (1 as Int64)
    let v2421: Int64 = v2420 + (1 as Int64)
    let v2422: Int64 = v2421 + (1 as Int64)
    let v2423: Int64 = v2422 + (1 as Int64)
    let v2424: Int64 = (0 as Int64) + (1 as Int64)
    let v2425: Int64 = v2424 + (1 as Int64)
    let v2426: Int64 = v2425 + (1 as Int64)
    let v2427: Int64 = v2426 + (1 as Int64)
    let v2428: Int64 = v2427 + (1 as Int64)
    let v2429: Bool = (v2423 == v2428)
    var v2430: Int64 = (0 as Int64)
    if (v2429) {
        v2430 = (0 as Int64)
    } else {
        v2430 = (1 as Int64)
    }
    let v2433: Int64 = (v2418 &+ v2430)
    let v2436: Int64 = (v2414 &+ v2433)
    let v2437: Int64 = (0 as Int64) + (1 as Int64)
    let v2438: Int64 = v2437 + (1 as Int64)
    let v2439: Int64 = v2438 + (1 as Int64)
    let v2440: Int64 = v2439 + (1 as Int64)
    let v2441: Int64 = (0 as Int64) + (1 as Int64)
    let v2442: Int64 = v2441 + (1 as Int64)
    let v2443: Int64 = v2442 + (1 as Int64)
    let v2444: Int64 = v2443 + (1 as Int64)
    let v2445: Bool = (v2440 == v2444)
    var v2446: Int64 = (0 as Int64)
    if (v2445) {
        v2446 = (0 as Int64)
    } else {
        v2446 = (1 as Int64)
    }
    let v2447: Int64 = (0 as Int64) + (1 as Int64)
    let v2448: Int64 = (0 as Int64) + (1 as Int64)
    let v2449: Bool = (v2447 == v2448)
    var v2450: Int64 = (0 as Int64)
    if (v2449) {
        v2450 = (0 as Int64)
    } else {
        v2450 = (1 as Int64)
    }
    let v2451: Int64 = (0 as Int64) + (1 as Int64)
    let v2452: Int64 = v2451 + (1 as Int64)
    let v2453: Int64 = v2452 + (1 as Int64)
    let v2454: Int64 = v2453 + (1 as Int64)
    let v2455: Int64 = v2454 + (1 as Int64)
    let v2456: Int64 = (0 as Int64) + (1 as Int64)
    let v2457: Int64 = v2456 + (1 as Int64)
    let v2458: Int64 = v2457 + (1 as Int64)
    let v2459: Int64 = v2458 + (1 as Int64)
    let v2460: Int64 = v2459 + (1 as Int64)
    let v2461: Bool = (v2455 == v2460)
    var v2462: Int64 = (0 as Int64)
    if (v2461) {
        v2462 = (0 as Int64)
    } else {
        v2462 = (1 as Int64)
    }
    let v2465: Int64 = (v2450 &+ v2462)
    let v2468: Int64 = (v2446 &+ v2465)
    let v2469: Int64 = (v2436 &+ v2468)
    let v2470: Int64 = (v2404 &+ v2397)
    let v2471: Int64 = (v2469 &+ v2470)
    let v2472: Int64 = (v2269 &+ v2471)
    let v2473: Bool = (v2396 == (1 as Int64))
    let v2474: Bool = (v2472 == (0 as Int64))
    let v2475: Bool = (v2473 && v2474)
    if (v2475) {
    } else {
        "typed-FX-statement-recursive-writer-crash-phase-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v2476: Int64 = (0 as Int64) + (1 as Int64)
    let v2477: Int64 = v2476 + (1 as Int64)
    let v2478: Int64 = v2477 + (1 as Int64)
    let v2479: Int64 = v2478 + (1 as Int64)
    let v2480: Int64 = (0 as Int64) + (1 as Int64)
    let v2481: Int64 = v2480 + (1 as Int64)
    let v2482: Int64 = v2481 + (1 as Int64)
    let v2483: Int64 = v2482 + (1 as Int64)
    let v2484: Bool = (v2479 == v2483)
    var v2485: Int64 = (0 as Int64)
    if (v2484) {
        v2485 = (0 as Int64)
    } else {
        v2485 = (1 as Int64)
    }
    let v2486: Int64 = (0 as Int64) + (1 as Int64)
    let v2487: Int64 = (0 as Int64) + (1 as Int64)
    let v2488: Bool = (v2486 == v2487)
    var v2489: Int64 = (0 as Int64)
    if (v2488) {
        v2489 = (0 as Int64)
    } else {
        v2489 = (1 as Int64)
    }
    let v2490: Int64 = (0 as Int64) + (1 as Int64)
    let v2491: Int64 = v2490 + (1 as Int64)
    let v2492: Int64 = v2491 + (1 as Int64)
    let v2493: Int64 = v2492 + (1 as Int64)
    let v2494: Int64 = v2493 + (1 as Int64)
    let v2495: Int64 = (0 as Int64) + (1 as Int64)
    let v2496: Int64 = v2495 + (1 as Int64)
    let v2497: Int64 = v2496 + (1 as Int64)
    let v2498: Int64 = v2497 + (1 as Int64)
    let v2499: Int64 = v2498 + (1 as Int64)
    let v2500: Bool = (v2494 == v2499)
    var v2501: Int64 = (0 as Int64)
    if (v2500) {
        v2501 = (0 as Int64)
    } else {
        v2501 = (1 as Int64)
    }
    let v2504: Int64 = (v2489 &+ v2501)
    let v2507: Int64 = (v2485 &+ v2504)
    let v2508: Int64 = (0 as Int64) + (1 as Int64)
    let v2509: Int64 = v2508 + (1 as Int64)
    let v2510: Int64 = v2509 + (1 as Int64)
    let v2511: Int64 = v2510 + (1 as Int64)
    let v2512: Int64 = (0 as Int64) + (1 as Int64)
    let v2513: Int64 = v2512 + (1 as Int64)
    let v2514: Int64 = v2513 + (1 as Int64)
    let v2515: Int64 = v2514 + (1 as Int64)
    let v2516: Bool = (v2511 == v2515)
    var v2517: Int64 = (0 as Int64)
    if (v2516) {
        v2517 = (0 as Int64)
    } else {
        v2517 = (1 as Int64)
    }
    let v2518: Int64 = (0 as Int64) + (1 as Int64)
    let v2519: Int64 = (0 as Int64) + (1 as Int64)
    let v2520: Bool = (v2518 == v2519)
    var v2521: Int64 = (0 as Int64)
    if (v2520) {
        v2521 = (0 as Int64)
    } else {
        v2521 = (1 as Int64)
    }
    let v2522: Int64 = (0 as Int64) + (1 as Int64)
    let v2523: Int64 = v2522 + (1 as Int64)
    let v2524: Int64 = v2523 + (1 as Int64)
    let v2525: Int64 = v2524 + (1 as Int64)
    let v2526: Int64 = v2525 + (1 as Int64)
    let v2527: Int64 = (0 as Int64) + (1 as Int64)
    let v2528: Int64 = v2527 + (1 as Int64)
    let v2529: Int64 = v2528 + (1 as Int64)
    let v2530: Int64 = v2529 + (1 as Int64)
    let v2531: Int64 = v2530 + (1 as Int64)
    let v2532: Bool = (v2526 == v2531)
    var v2533: Int64 = (0 as Int64)
    if (v2532) {
        v2533 = (0 as Int64)
    } else {
        v2533 = (1 as Int64)
    }
    let v2536: Int64 = (v2521 &+ v2533)
    let v2539: Int64 = (v2517 &+ v2536)
    let v2540: Int64 = (v2507 &+ v2539)
    let v2541: Int64 = (0 as Int64) + (1 as Int64)
    let v2542: Int64 = v2541 + (1 as Int64)
    let v2543: Int64 = v2542 + (1 as Int64)
    let v2544: Int64 = v2543 + (1 as Int64)
    let v2545: Int64 = (0 as Int64) + (1 as Int64)
    let v2546: Int64 = v2545 + (1 as Int64)
    let v2547: Int64 = v2546 + (1 as Int64)
    let v2548: Int64 = v2547 + (1 as Int64)
    let v2549: Bool = (v2544 == v2548)
    var v2550: Int64 = (0 as Int64)
    if (v2549) {
        v2550 = (0 as Int64)
    } else {
        v2550 = (1 as Int64)
    }
    let v2551: Int64 = (0 as Int64) + (1 as Int64)
    let v2552: Int64 = (0 as Int64) + (1 as Int64)
    let v2553: Bool = (v2551 == v2552)
    var v2554: Int64 = (0 as Int64)
    if (v2553) {
        v2554 = (0 as Int64)
    } else {
        v2554 = (1 as Int64)
    }
    let v2555: Int64 = (0 as Int64) + (1 as Int64)
    let v2556: Int64 = v2555 + (1 as Int64)
    let v2557: Int64 = v2556 + (1 as Int64)
    let v2558: Int64 = v2557 + (1 as Int64)
    let v2559: Int64 = v2558 + (1 as Int64)
    let v2560: Int64 = (0 as Int64) + (1 as Int64)
    let v2561: Int64 = v2560 + (1 as Int64)
    let v2562: Int64 = v2561 + (1 as Int64)
    let v2563: Int64 = v2562 + (1 as Int64)
    let v2564: Int64 = v2563 + (1 as Int64)
    let v2565: Bool = (v2559 == v2564)
    var v2566: Int64 = (0 as Int64)
    if (v2565) {
        v2566 = (0 as Int64)
    } else {
        v2566 = (1 as Int64)
    }
    let v2569: Int64 = (v2554 &+ v2566)
    let v2572: Int64 = (v2550 &+ v2569)
    let v2573: Int64 = (0 as Int64) + (1 as Int64)
    let v2574: Int64 = v2573 + (1 as Int64)
    let v2575: Int64 = v2574 + (1 as Int64)
    let v2576: Int64 = v2575 + (1 as Int64)
    let v2577: Int64 = (0 as Int64) + (1 as Int64)
    let v2578: Int64 = v2577 + (1 as Int64)
    let v2579: Int64 = v2578 + (1 as Int64)
    let v2580: Int64 = v2579 + (1 as Int64)
    let v2581: Bool = (v2576 == v2580)
    var v2582: Int64 = (0 as Int64)
    if (v2581) {
        v2582 = (0 as Int64)
    } else {
        v2582 = (1 as Int64)
    }
    let v2583: Int64 = (0 as Int64) + (1 as Int64)
    let v2584: Int64 = (0 as Int64) + (1 as Int64)
    let v2585: Bool = (v2583 == v2584)
    var v2586: Int64 = (0 as Int64)
    if (v2585) {
        v2586 = (0 as Int64)
    } else {
        v2586 = (1 as Int64)
    }
    let v2587: Int64 = (0 as Int64) + (1 as Int64)
    let v2588: Int64 = v2587 + (1 as Int64)
    let v2589: Int64 = v2588 + (1 as Int64)
    let v2590: Int64 = v2589 + (1 as Int64)
    let v2591: Int64 = v2590 + (1 as Int64)
    let v2592: Int64 = (0 as Int64) + (1 as Int64)
    let v2593: Int64 = v2592 + (1 as Int64)
    let v2594: Int64 = v2593 + (1 as Int64)
    let v2595: Int64 = v2594 + (1 as Int64)
    let v2596: Int64 = v2595 + (1 as Int64)
    let v2597: Bool = (v2591 == v2596)
    var v2598: Int64 = (0 as Int64)
    if (v2597) {
        v2598 = (0 as Int64)
    } else {
        v2598 = (1 as Int64)
    }
    let v2601: Int64 = (v2586 &+ v2598)
    let v2604: Int64 = (v2582 &+ v2601)
    let v2605: Int64 = (v2572 &+ v2604)
    let v2606: Int64 = (v2540 &+ v2605)
    let v2607: Int64 = (0 as Int64) + (1 as Int64)
    let v2608: Int64 = v2607 + (1 as Int64)
    let v2609: Int64 = v2608 + (1 as Int64)
    let v2610: Int64 = v2609 + (1 as Int64)
    let v2611: Int64 = (0 as Int64) + (1 as Int64)
    let v2612: Int64 = v2611 + (1 as Int64)
    let v2613: Int64 = v2612 + (1 as Int64)
    let v2614: Int64 = v2613 + (1 as Int64)
    let v2615: Bool = (v2610 == v2614)
    var v2616: Int64 = (0 as Int64)
    if (v2615) {
        v2616 = (0 as Int64)
    } else {
        v2616 = (1 as Int64)
    }
    let v2617: Int64 = (0 as Int64) + (1 as Int64)
    let v2618: Int64 = (0 as Int64) + (1 as Int64)
    let v2619: Bool = (v2617 == v2618)
    var v2620: Int64 = (0 as Int64)
    if (v2619) {
        v2620 = (0 as Int64)
    } else {
        v2620 = (1 as Int64)
    }
    let v2621: Int64 = (0 as Int64) + (1 as Int64)
    let v2622: Int64 = v2621 + (1 as Int64)
    let v2623: Int64 = v2622 + (1 as Int64)
    let v2624: Int64 = v2623 + (1 as Int64)
    let v2625: Int64 = v2624 + (1 as Int64)
    let v2626: Int64 = (0 as Int64) + (1 as Int64)
    let v2627: Int64 = v2626 + (1 as Int64)
    let v2628: Int64 = v2627 + (1 as Int64)
    let v2629: Int64 = v2628 + (1 as Int64)
    let v2630: Int64 = v2629 + (1 as Int64)
    let v2631: Bool = (v2625 == v2630)
    var v2632: Int64 = (0 as Int64)
    if (v2631) {
        v2632 = (0 as Int64)
    } else {
        v2632 = (1 as Int64)
    }
    let v2633: Int64 = (v2617 &+ v2625)
    let v2634: Int64 = (v2618 &+ v2630)
    let v2635: Int64 = (v2620 &+ v2632)
    let v2636: Int64 = (v2610 &+ v2633)
    let v2637: Int64 = (v2614 &+ v2634)
    let v2638: Int64 = (v2616 &+ v2635)
    let v2639: Int64 = (v2637 &+ v2638)
    let v2640: Int64 = (v2636 &+ v2639)
    let v2641: Int64 = ((3 as Int64) &+ v2640)
    let v2642: Int64 = (0 as Int64) + (1 as Int64)
    let v2643: Int64 = v2642 + (1 as Int64)
    let v2644: Int64 = v2643 + (1 as Int64)
    let v2645: Int64 = v2644 + (1 as Int64)
    let v2646: Int64 = (0 as Int64) + (1 as Int64)
    let v2647: Int64 = v2646 + (1 as Int64)
    let v2648: Int64 = v2647 + (1 as Int64)
    let v2649: Int64 = v2648 + (1 as Int64)
    let v2650: Bool = (v2645 == v2649)
    var v2651: Int64 = (0 as Int64)
    if (v2650) {
        v2651 = (0 as Int64)
    } else {
        v2651 = (1 as Int64)
    }
    let v2652: Int64 = (0 as Int64) + (1 as Int64)
    let v2653: Int64 = (0 as Int64) + (1 as Int64)
    let v2654: Bool = (v2652 == v2653)
    var v2655: Int64 = (0 as Int64)
    if (v2654) {
        v2655 = (0 as Int64)
    } else {
        v2655 = (1 as Int64)
    }
    let v2656: Int64 = (0 as Int64) + (1 as Int64)
    let v2657: Int64 = v2656 + (1 as Int64)
    let v2658: Int64 = v2657 + (1 as Int64)
    let v2659: Int64 = v2658 + (1 as Int64)
    let v2660: Int64 = v2659 + (1 as Int64)
    let v2661: Int64 = (0 as Int64) + (1 as Int64)
    let v2662: Int64 = v2661 + (1 as Int64)
    let v2663: Int64 = v2662 + (1 as Int64)
    let v2664: Int64 = v2663 + (1 as Int64)
    let v2665: Int64 = v2664 + (1 as Int64)
    let v2666: Bool = (v2660 == v2665)
    var v2667: Int64 = (0 as Int64)
    if (v2666) {
        v2667 = (0 as Int64)
    } else {
        v2667 = (1 as Int64)
    }
    let v2668: Int64 = (v2652 &+ v2660)
    let v2669: Int64 = (v2653 &+ v2665)
    let v2670: Int64 = (v2655 &+ v2667)
    let v2671: Int64 = (v2645 &+ v2668)
    let v2672: Int64 = (v2649 &+ v2669)
    let v2673: Int64 = (v2651 &+ v2670)
    let v2674: Int64 = (v2672 &+ v2673)
    let v2675: Int64 = (v2671 &+ v2674)
    let v2676: Int64 = ((3 as Int64) &+ v2675)
    let v2677: Bool = (v2641 == v2676)
    var v2714: US0 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (0 as Int64), f1: (0 as Int64), f2: (0 as Int64), f3: (0 as Int64), f4: (0 as Int64), f5: "")
    if (v2677) {
        let v2678: Int64 = (0 as Int64) + (1 as Int64)
        let v2679: Int64 = v2678 + (1 as Int64)
        let v2680: Int64 = v2679 + (1 as Int64)
        let v2681: Int64 = v2680 + (1 as Int64)
        let v2682: Int64 = (0 as Int64) + (1 as Int64)
        let v2683: Int64 = v2682 + (1 as Int64)
        let v2684: Int64 = v2683 + (1 as Int64)
        let v2685: Int64 = v2684 + (1 as Int64)
        let v2686: Bool = (v2681 == v2685)
        var v2687: Int64 = (0 as Int64)
        if (v2686) {
            v2687 = (0 as Int64)
        } else {
            v2687 = (1 as Int64)
        }
        let v2688: Int64 = (0 as Int64) + (1 as Int64)
        let v2689: Int64 = (0 as Int64) + (1 as Int64)
        let v2690: Bool = (v2688 == v2689)
        var v2691: Int64 = (0 as Int64)
        if (v2690) {
            v2691 = (0 as Int64)
        } else {
            v2691 = (1 as Int64)
        }
        let v2692: Int64 = (0 as Int64) + (1 as Int64)
        let v2693: Int64 = v2692 + (1 as Int64)
        let v2694: Int64 = v2693 + (1 as Int64)
        let v2695: Int64 = v2694 + (1 as Int64)
        let v2696: Int64 = v2695 + (1 as Int64)
        let v2697: Int64 = (0 as Int64) + (1 as Int64)
        let v2698: Int64 = v2697 + (1 as Int64)
        let v2699: Int64 = v2698 + (1 as Int64)
        let v2700: Int64 = v2699 + (1 as Int64)
        let v2701: Int64 = v2700 + (1 as Int64)
        let v2702: Bool = (v2696 == v2701)
        var v2703: Int64 = (0 as Int64)
        if (v2702) {
            v2703 = (0 as Int64)
        } else {
            v2703 = (1 as Int64)
        }
        let v2704: Int64 = (v2688 &+ v2696)
        let v2705: Int64 = (v2689 &+ v2701)
        let v2706: Int64 = (v2691 &+ v2703)
        let v2707: Int64 = (v2681 &+ v2704)
        let v2708: Int64 = (v2685 &+ v2705)
        let v2709: Int64 = (v2687 &+ v2706)
        let v2710: String = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v2714 = US0_TypedFxHashedStatementChecksumValidationAccepted(f0: (1 as Int64), f1: (3 as Int64), f2: v2707, f3: v2708, f4: v2709, f5: v2710)
    } else {
        let v2712: String = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v2714 = US0_TypedFxHashedStatementChecksumValidationRejected(f0: v2641, f1: v2676, f2: v2712)
    }
    var v2733: Int64 = (0 as Int64)
    var v2734: Int64 = (0 as Int64)
    var v2741: Int64 = (0 as Int64)
    switch v2714.tag {
        case 0:
            var v2718: Int64 = (v2714 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f0
            var v2719: Int64 = (v2714 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f1
            var v2720: Int64 = (v2714 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f2
            var v2721: Int64 = (v2714 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f3
            var v2722: Int64 = (v2714 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f4
            var v2723: String = (v2714 as! US0_TypedFxHashedStatementChecksumValidationAccepted).f5
            v2733 = (1 as Int64)
            v2734 = (0 as Int64)
            v2741 = v2722
        case 1:
            var v2715: Int64 = (v2714 as! US0_TypedFxHashedStatementChecksumValidationRejected).f0
            var v2716: Int64 = (v2714 as! US0_TypedFxHashedStatementChecksumValidationRejected).f1
            var v2717: String = (v2714 as! US0_TypedFxHashedStatementChecksumValidationRejected).f2
            v2733 = (0 as Int64)
            v2734 = (1 as Int64)
            v2741 = (0 as Int64)
        default:
            fatalError("unreachable union case")
    }
    let v2742: Int64 = (0 as Int64) + (1 as Int64)
    let v2743: Int64 = v2742 + (1 as Int64)
    let v2744: Int64 = v2743 + (1 as Int64)
    let v2745: Int64 = v2744 + (1 as Int64)
    let v2746: Int64 = (0 as Int64) + (1 as Int64)
    let v2747: Int64 = v2746 + (1 as Int64)
    let v2748: Int64 = v2747 + (1 as Int64)
    let v2749: Int64 = v2748 + (1 as Int64)
    let v2750: Bool = (v2745 == v2749)
    var v2751: Int64 = (0 as Int64)
    if (v2750) {
        v2751 = (0 as Int64)
    } else {
        v2751 = (1 as Int64)
    }
    let v2752: Int64 = (0 as Int64) + (1 as Int64)
    let v2753: Int64 = (0 as Int64) + (1 as Int64)
    let v2754: Bool = (v2752 == v2753)
    var v2755: Int64 = (0 as Int64)
    if (v2754) {
        v2755 = (0 as Int64)
    } else {
        v2755 = (1 as Int64)
    }
    let v2756: Int64 = (0 as Int64) + (1 as Int64)
    let v2757: Int64 = v2756 + (1 as Int64)
    let v2758: Int64 = v2757 + (1 as Int64)
    let v2759: Int64 = v2758 + (1 as Int64)
    let v2760: Int64 = v2759 + (1 as Int64)
    let v2761: Int64 = (0 as Int64) + (1 as Int64)
    let v2762: Int64 = v2761 + (1 as Int64)
    let v2763: Int64 = v2762 + (1 as Int64)
    let v2764: Int64 = v2763 + (1 as Int64)
    let v2765: Int64 = v2764 + (1 as Int64)
    let v2766: Bool = (v2760 == v2765)
    var v2767: Int64 = (0 as Int64)
    if (v2766) {
        v2767 = (0 as Int64)
    } else {
        v2767 = (1 as Int64)
    }
    let v2770: Int64 = (v2755 &+ v2767)
    let v2773: Int64 = (v2751 &+ v2770)
    let v2774: Int64 = (0 as Int64) + (1 as Int64)
    let v2775: Int64 = v2774 + (1 as Int64)
    let v2776: Int64 = v2775 + (1 as Int64)
    let v2777: Int64 = v2776 + (1 as Int64)
    let v2778: Int64 = (0 as Int64) + (1 as Int64)
    let v2779: Int64 = v2778 + (1 as Int64)
    let v2780: Int64 = v2779 + (1 as Int64)
    let v2781: Int64 = v2780 + (1 as Int64)
    let v2782: Bool = (v2777 == v2781)
    var v2783: Int64 = (0 as Int64)
    if (v2782) {
        v2783 = (0 as Int64)
    } else {
        v2783 = (1 as Int64)
    }
    let v2784: Int64 = (0 as Int64) + (1 as Int64)
    let v2785: Int64 = (0 as Int64) + (1 as Int64)
    let v2786: Bool = (v2784 == v2785)
    var v2787: Int64 = (0 as Int64)
    if (v2786) {
        v2787 = (0 as Int64)
    } else {
        v2787 = (1 as Int64)
    }
    let v2788: Int64 = (0 as Int64) + (1 as Int64)
    let v2789: Int64 = v2788 + (1 as Int64)
    let v2790: Int64 = v2789 + (1 as Int64)
    let v2791: Int64 = v2790 + (1 as Int64)
    let v2792: Int64 = v2791 + (1 as Int64)
    let v2793: Int64 = (0 as Int64) + (1 as Int64)
    let v2794: Int64 = v2793 + (1 as Int64)
    let v2795: Int64 = v2794 + (1 as Int64)
    let v2796: Int64 = v2795 + (1 as Int64)
    let v2797: Int64 = v2796 + (1 as Int64)
    let v2798: Bool = (v2792 == v2797)
    var v2799: Int64 = (0 as Int64)
    if (v2798) {
        v2799 = (0 as Int64)
    } else {
        v2799 = (1 as Int64)
    }
    let v2802: Int64 = (v2787 &+ v2799)
    let v2805: Int64 = (v2783 &+ v2802)
    let v2806: Int64 = (v2773 &+ v2805)
    let v2807: Int64 = (v2741 &+ v2734)
    let v2808: Int64 = (v2806 &+ v2807)
    let v2809: Int64 = (v2606 &+ v2808)
    let v2810: Bool = (v2733 == (1 as Int64))
    let v2811: Bool = (v2809 == (0 as Int64))
    let v2812: Bool = (v2810 && v2811)
    if (v2812) {
    } else {
        "typed-FX-statement-indexed-durable-commit-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v2813: Int64 = (0 as Int64) + (1 as Int64)
    let v2814: Int64 = v2813 + (1 as Int64)
    let v2815: Int64 = v2814 + (1 as Int64)
    let v2816: Int64 = v2815 + (1 as Int64)
    let v2817: Int64 = (0 as Int64) + (1 as Int64)
    let v2818: Int64 = v2817 + (1 as Int64)
    let v2819: Int64 = v2818 + (1 as Int64)
    let v2820: Int64 = v2819 + (1 as Int64)
    let v2821: Bool = (v2816 == v2820)
    var v2822: Int64 = (0 as Int64)
    if (v2821) {
        v2822 = (0 as Int64)
    } else {
        v2822 = (1 as Int64)
    }
    let v2823: Int64 = (0 as Int64) + (1 as Int64)
    let v2824: Int64 = (0 as Int64) + (1 as Int64)
    let v2825: Bool = (v2823 == v2824)
    var v2826: Int64 = (0 as Int64)
    if (v2825) {
        v2826 = (0 as Int64)
    } else {
        v2826 = (1 as Int64)
    }
    let v2827: Int64 = (0 as Int64) + (1 as Int64)
    let v2828: Int64 = v2827 + (1 as Int64)
    let v2829: Int64 = v2828 + (1 as Int64)
    let v2830: Int64 = v2829 + (1 as Int64)
    let v2831: Int64 = v2830 + (1 as Int64)
    let v2832: Int64 = (0 as Int64) + (1 as Int64)
    let v2833: Int64 = v2832 + (1 as Int64)
    let v2834: Int64 = v2833 + (1 as Int64)
    let v2835: Int64 = v2834 + (1 as Int64)
    let v2836: Int64 = v2835 + (1 as Int64)
    let v2837: Bool = (v2831 == v2836)
    var v2838: Int64 = (0 as Int64)
    if (v2837) {
        v2838 = (0 as Int64)
    } else {
        v2838 = (1 as Int64)
    }
    let v2839: Int64 = (v2823 &+ v2831)
    let v2840: Int64 = (v2824 &+ v2836)
    let v2841: Int64 = (v2826 &+ v2838)
    let v2842: Int64 = (v2816 &+ v2839)
    let v2843: Int64 = (v2820 &+ v2840)
    let v2844: Int64 = (v2822 &+ v2841)
    let v2845: Int64 = (0 as Int64) + (1 as Int64)
    let v2846: Int64 = v2845 + (1 as Int64)
    let v2847: Int64 = v2846 + (1 as Int64)
    let v2848: Int64 = v2847 + (1 as Int64)
    let v2849: Int64 = (0 as Int64) + (1 as Int64)
    let v2850: Int64 = v2849 + (1 as Int64)
    let v2851: Int64 = v2850 + (1 as Int64)
    let v2852: Int64 = v2851 + (1 as Int64)
    let v2853: Bool = (v2848 == v2852)
    var v2854: Int64 = (0 as Int64)
    if (v2853) {
        v2854 = (0 as Int64)
    } else {
        v2854 = (1 as Int64)
    }
    let v2855: Int64 = (0 as Int64) + (1 as Int64)
    let v2856: Int64 = (0 as Int64) + (1 as Int64)
    let v2857: Bool = (v2855 == v2856)
    var v2858: Int64 = (0 as Int64)
    if (v2857) {
        v2858 = (0 as Int64)
    } else {
        v2858 = (1 as Int64)
    }
    let v2859: Int64 = (0 as Int64) + (1 as Int64)
    let v2860: Int64 = v2859 + (1 as Int64)
    let v2861: Int64 = v2860 + (1 as Int64)
    let v2862: Int64 = v2861 + (1 as Int64)
    let v2863: Int64 = v2862 + (1 as Int64)
    let v2864: Int64 = (0 as Int64) + (1 as Int64)
    let v2865: Int64 = v2864 + (1 as Int64)
    let v2866: Int64 = v2865 + (1 as Int64)
    let v2867: Int64 = v2866 + (1 as Int64)
    let v2868: Int64 = v2867 + (1 as Int64)
    let v2869: Bool = (v2863 == v2868)
    var v2870: Int64 = (0 as Int64)
    if (v2869) {
        v2870 = (0 as Int64)
    } else {
        v2870 = (1 as Int64)
    }
    let v2871: Int64 = (v2855 &+ v2863)
    let v2872: Int64 = (v2856 &+ v2868)
    let v2873: Int64 = (v2858 &+ v2870)
    let v2874: Int64 = (v2848 &+ v2871)
    let v2875: Int64 = (v2852 &+ v2872)
    let v2876: Int64 = (v2854 &+ v2873)
    let v2877: Int64 = (0 as Int64) + (1 as Int64)
    let v2878: Int64 = v2877 + (1 as Int64)
    let v2879: Int64 = v2878 + (1 as Int64)
    let v2880: Int64 = v2879 + (1 as Int64)
    let v2881: Int64 = (0 as Int64) + (1 as Int64)
    let v2882: Int64 = v2881 + (1 as Int64)
    let v2883: Int64 = v2882 + (1 as Int64)
    let v2884: Int64 = v2883 + (1 as Int64)
    let v2885: Bool = (v2880 == v2884)
    var v2886: Int64 = (0 as Int64)
    if (v2885) {
        v2886 = (0 as Int64)
    } else {
        v2886 = (1 as Int64)
    }
    let v2887: Int64 = (0 as Int64) + (1 as Int64)
    let v2888: Int64 = (0 as Int64) + (1 as Int64)
    let v2889: Bool = (v2887 == v2888)
    var v2890: Int64 = (0 as Int64)
    if (v2889) {
        v2890 = (0 as Int64)
    } else {
        v2890 = (1 as Int64)
    }
    let v2891: Int64 = (0 as Int64) + (1 as Int64)
    let v2892: Int64 = v2891 + (1 as Int64)
    let v2893: Int64 = v2892 + (1 as Int64)
    let v2894: Int64 = v2893 + (1 as Int64)
    let v2895: Int64 = v2894 + (1 as Int64)
    let v2896: Int64 = (0 as Int64) + (1 as Int64)
    let v2897: Int64 = v2896 + (1 as Int64)
    let v2898: Int64 = v2897 + (1 as Int64)
    let v2899: Int64 = v2898 + (1 as Int64)
    let v2900: Int64 = v2899 + (1 as Int64)
    let v2901: Bool = (v2895 == v2900)
    var v2902: Int64 = (0 as Int64)
    if (v2901) {
        v2902 = (0 as Int64)
    } else {
        v2902 = (1 as Int64)
    }
    let v2903: Int64 = (v2887 &+ v2895)
    let v2904: Int64 = (v2888 &+ v2900)
    let v2905: Int64 = (v2890 &+ v2902)
    let v2906: Int64 = (v2880 &+ v2903)
    let v2907: Int64 = (v2884 &+ v2904)
    let v2908: Int64 = (v2886 &+ v2905)
    let v2909: Int64 = (0 as Int64) + (1 as Int64)
    let v2910: Int64 = v2909 + (1 as Int64)
    let v2911: Int64 = v2910 + (1 as Int64)
    let v2912: Int64 = v2911 + (1 as Int64)
    let v2913: Int64 = (0 as Int64) + (1 as Int64)
    let v2914: Int64 = v2913 + (1 as Int64)
    let v2915: Int64 = v2914 + (1 as Int64)
    let v2916: Int64 = v2915 + (1 as Int64)
    let v2917: Bool = (v2912 == v2916)
    var v2918: Int64 = (0 as Int64)
    if (v2917) {
        v2918 = (0 as Int64)
    } else {
        v2918 = (1 as Int64)
    }
    let v2919: Int64 = (0 as Int64) + (1 as Int64)
    let v2920: Int64 = (0 as Int64) + (1 as Int64)
    let v2921: Bool = (v2919 == v2920)
    var v2922: Int64 = (0 as Int64)
    if (v2921) {
        v2922 = (0 as Int64)
    } else {
        v2922 = (1 as Int64)
    }
    let v2923: Int64 = (0 as Int64) + (1 as Int64)
    let v2924: Int64 = v2923 + (1 as Int64)
    let v2925: Int64 = v2924 + (1 as Int64)
    let v2926: Int64 = v2925 + (1 as Int64)
    let v2927: Int64 = v2926 + (1 as Int64)
    let v2928: Int64 = (0 as Int64) + (1 as Int64)
    let v2929: Int64 = v2928 + (1 as Int64)
    let v2930: Int64 = v2929 + (1 as Int64)
    let v2931: Int64 = v2930 + (1 as Int64)
    let v2932: Int64 = v2931 + (1 as Int64)
    let v2933: Bool = (v2927 == v2932)
    var v2934: Int64 = (0 as Int64)
    if (v2933) {
        v2934 = (0 as Int64)
    } else {
        v2934 = (1 as Int64)
    }
    let v2935: Int64 = (v2919 &+ v2927)
    let v2936: Int64 = (v2920 &+ v2932)
    let v2937: Int64 = (v2922 &+ v2934)
    let v2938: Int64 = (v2912 &+ v2935)
    let v2939: Int64 = (v2916 &+ v2936)
    let v2940: Int64 = (v2918 &+ v2937)
    let v2941: Int64 = (v2906 &+ v2938)
    let v2942: Int64 = (v2907 &+ v2939)
    let v2943: Int64 = (v2908 &+ v2940)
    let v2944: Int64 = (v2874 &+ v2941)
    let v2945: Int64 = (v2875 &+ v2942)
    let v2946: Int64 = (v2876 &+ v2943)
    let v2947: Int64 = (v2842 &+ v2944)
    let v2948: Int64 = (v2843 &+ v2945)
    let v2949: Int64 = (v2844 &+ v2946)
    let v2950: Bool = (v2947 == (40 as Int64))
    let v2951: Bool = (v2948 == (40 as Int64))
    let v2952: Bool = (v2949 == (0 as Int64))
    let v2953: Bool = (v2950 && v2951)
    let v2954: Bool = (v2953 && v2952)
    if (v2954) {
    } else {
        "typed-FX-hashed-statement-event-store-decision-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v2955: Int64 = (0 as Int64) + (1 as Int64)
    let v2956: Int64 = v2955 + (1 as Int64)
    let v2957: Int64 = v2956 + (1 as Int64)
    let v2958: Int64 = v2957 + (1 as Int64)
    let v2959: Int64 = (0 as Int64) + (1 as Int64)
    let v2960: Int64 = v2959 + (1 as Int64)
    let v2961: Int64 = v2960 + (1 as Int64)
    let v2962: Int64 = v2961 + (1 as Int64)
    let v2963: Bool = (v2958 == v2962)
    var v2964: Int64 = (0 as Int64)
    if (v2963) {
        v2964 = (0 as Int64)
    } else {
        v2964 = (1 as Int64)
    }
    let v2965: Int64 = (0 as Int64) + (1 as Int64)
    let v2966: Int64 = (0 as Int64) + (1 as Int64)
    let v2967: Bool = (v2965 == v2966)
    var v2968: Int64 = (0 as Int64)
    if (v2967) {
        v2968 = (0 as Int64)
    } else {
        v2968 = (1 as Int64)
    }
    let v2969: Int64 = (0 as Int64) + (1 as Int64)
    let v2970: Int64 = v2969 + (1 as Int64)
    let v2971: Int64 = v2970 + (1 as Int64)
    let v2972: Int64 = v2971 + (1 as Int64)
    let v2973: Int64 = v2972 + (1 as Int64)
    let v2974: Int64 = (0 as Int64) + (1 as Int64)
    let v2975: Int64 = v2974 + (1 as Int64)
    let v2976: Int64 = v2975 + (1 as Int64)
    let v2977: Int64 = v2976 + (1 as Int64)
    let v2978: Int64 = v2977 + (1 as Int64)
    let v2979: Bool = (v2973 == v2978)
    var v2980: Int64 = (0 as Int64)
    if (v2979) {
        v2980 = (0 as Int64)
    } else {
        v2980 = (1 as Int64)
    }
    let v2983: Int64 = (v2968 &+ v2980)
    let v2986: Int64 = (v2964 &+ v2983)
    let v2987: Int64 = (0 as Int64) + (1 as Int64)
    let v2988: Int64 = v2987 + (1 as Int64)
    let v2989: Int64 = v2988 + (1 as Int64)
    let v2990: Int64 = v2989 + (1 as Int64)
    let v2991: Int64 = (0 as Int64) + (1 as Int64)
    let v2992: Int64 = v2991 + (1 as Int64)
    let v2993: Int64 = v2992 + (1 as Int64)
    let v2994: Int64 = v2993 + (1 as Int64)
    let v2995: Bool = (v2990 == v2994)
    var v2996: Int64 = (0 as Int64)
    if (v2995) {
        v2996 = (0 as Int64)
    } else {
        v2996 = (1 as Int64)
    }
    let v2997: Int64 = (0 as Int64) + (1 as Int64)
    let v2998: Int64 = (0 as Int64) + (1 as Int64)
    let v2999: Bool = (v2997 == v2998)
    var v3000: Int64 = (0 as Int64)
    if (v2999) {
        v3000 = (0 as Int64)
    } else {
        v3000 = (1 as Int64)
    }
    let v3001: Int64 = (0 as Int64) + (1 as Int64)
    let v3002: Int64 = v3001 + (1 as Int64)
    let v3003: Int64 = v3002 + (1 as Int64)
    let v3004: Int64 = v3003 + (1 as Int64)
    let v3005: Int64 = v3004 + (1 as Int64)
    let v3006: Int64 = (0 as Int64) + (1 as Int64)
    let v3007: Int64 = v3006 + (1 as Int64)
    let v3008: Int64 = v3007 + (1 as Int64)
    let v3009: Int64 = v3008 + (1 as Int64)
    let v3010: Int64 = v3009 + (1 as Int64)
    let v3011: Bool = (v3005 == v3010)
    var v3012: Int64 = (0 as Int64)
    if (v3011) {
        v3012 = (0 as Int64)
    } else {
        v3012 = (1 as Int64)
    }
    let v3015: Int64 = (v3000 &+ v3012)
    let v3018: Int64 = (v2996 &+ v3015)
    let v3021: Int64 = (v3018 &+ v2986)
    let v3022: Int64 = (0 as Int64) + (1 as Int64)
    let v3023: Int64 = v3022 + (1 as Int64)
    let v3024: Int64 = v3023 + (1 as Int64)
    let v3025: Int64 = v3024 + (1 as Int64)
    let v3026: Int64 = (0 as Int64) + (1 as Int64)
    let v3027: Int64 = v3026 + (1 as Int64)
    let v3028: Int64 = v3027 + (1 as Int64)
    let v3029: Int64 = v3028 + (1 as Int64)
    let v3030: Bool = (v3025 == v3029)
    var v3031: Int64 = (0 as Int64)
    if (v3030) {
        v3031 = (0 as Int64)
    } else {
        v3031 = (1 as Int64)
    }
    let v3032: Int64 = (0 as Int64) + (1 as Int64)
    let v3033: Int64 = (0 as Int64) + (1 as Int64)
    let v3034: Bool = (v3032 == v3033)
    var v3035: Int64 = (0 as Int64)
    if (v3034) {
        v3035 = (0 as Int64)
    } else {
        v3035 = (1 as Int64)
    }
    let v3036: Int64 = (0 as Int64) + (1 as Int64)
    let v3037: Int64 = v3036 + (1 as Int64)
    let v3038: Int64 = v3037 + (1 as Int64)
    let v3039: Int64 = v3038 + (1 as Int64)
    let v3040: Int64 = v3039 + (1 as Int64)
    let v3041: Int64 = (0 as Int64) + (1 as Int64)
    let v3042: Int64 = v3041 + (1 as Int64)
    let v3043: Int64 = v3042 + (1 as Int64)
    let v3044: Int64 = v3043 + (1 as Int64)
    let v3045: Int64 = v3044 + (1 as Int64)
    let v3046: Bool = (v3040 == v3045)
    var v3047: Int64 = (0 as Int64)
    if (v3046) {
        v3047 = (0 as Int64)
    } else {
        v3047 = (1 as Int64)
    }
    let v3050: Int64 = (v3035 &+ v3047)
    let v3053: Int64 = (v3031 &+ v3050)
    let v3054: Int64 = (0 as Int64) + (1 as Int64)
    let v3055: Int64 = v3054 + (1 as Int64)
    let v3056: Int64 = v3055 + (1 as Int64)
    let v3057: Int64 = v3056 + (1 as Int64)
    let v3058: Int64 = (0 as Int64) + (1 as Int64)
    let v3059: Int64 = v3058 + (1 as Int64)
    let v3060: Int64 = v3059 + (1 as Int64)
    let v3061: Int64 = v3060 + (1 as Int64)
    let v3062: Bool = (v3057 == v3061)
    var v3063: Int64 = (0 as Int64)
    if (v3062) {
        v3063 = (0 as Int64)
    } else {
        v3063 = (1 as Int64)
    }
    let v3064: Int64 = (0 as Int64) + (1 as Int64)
    let v3065: Int64 = (0 as Int64) + (1 as Int64)
    let v3066: Bool = (v3064 == v3065)
    var v3067: Int64 = (0 as Int64)
    if (v3066) {
        v3067 = (0 as Int64)
    } else {
        v3067 = (1 as Int64)
    }
    let v3068: Int64 = (0 as Int64) + (1 as Int64)
    let v3069: Int64 = v3068 + (1 as Int64)
    let v3070: Int64 = v3069 + (1 as Int64)
    let v3071: Int64 = v3070 + (1 as Int64)
    let v3072: Int64 = v3071 + (1 as Int64)
    let v3073: Int64 = (0 as Int64) + (1 as Int64)
    let v3074: Int64 = v3073 + (1 as Int64)
    let v3075: Int64 = v3074 + (1 as Int64)
    let v3076: Int64 = v3075 + (1 as Int64)
    let v3077: Int64 = v3076 + (1 as Int64)
    let v3078: Bool = (v3072 == v3077)
    var v3079: Int64 = (0 as Int64)
    if (v3078) {
        v3079 = (0 as Int64)
    } else {
        v3079 = (1 as Int64)
    }
    let v3082: Int64 = (v3067 &+ v3079)
    let v3085: Int64 = (v3063 &+ v3082)
    let v3088: Int64 = (v3085 &+ v3053)
    let v3089: Int64 = (v3021 &+ v3088)
    let v3090: Bool = (v3089 == (0 as Int64))
    if (v3090) {
    } else {
        "typed-FX-hashed-statement-proven-retry-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v3091: Int64 = (0 as Int64) + (1 as Int64)
    let v3092: Int64 = v3091 + (1 as Int64)
    let v3093: Int64 = v3092 + (1 as Int64)
    let v3094: Int64 = v3093 + (1 as Int64)
    let v3095: Int64 = (0 as Int64) + (1 as Int64)
    let v3096: Int64 = v3095 + (1 as Int64)
    let v3097: Int64 = v3096 + (1 as Int64)
    let v3098: Int64 = v3097 + (1 as Int64)
    let v3099: Bool = (v3094 == v3098)
    var v3100: Int64 = (0 as Int64)
    if (v3099) {
        v3100 = (0 as Int64)
    } else {
        v3100 = (1 as Int64)
    }
    let v3101: Int64 = (0 as Int64) + (1 as Int64)
    let v3102: Int64 = (0 as Int64) + (1 as Int64)
    let v3103: Bool = (v3101 == v3102)
    var v3104: Int64 = (0 as Int64)
    if (v3103) {
        v3104 = (0 as Int64)
    } else {
        v3104 = (1 as Int64)
    }
    let v3105: Int64 = (0 as Int64) + (1 as Int64)
    let v3106: Int64 = v3105 + (1 as Int64)
    let v3107: Int64 = v3106 + (1 as Int64)
    let v3108: Int64 = v3107 + (1 as Int64)
    let v3109: Int64 = v3108 + (1 as Int64)
    let v3110: Int64 = (0 as Int64) + (1 as Int64)
    let v3111: Int64 = v3110 + (1 as Int64)
    let v3112: Int64 = v3111 + (1 as Int64)
    let v3113: Int64 = v3112 + (1 as Int64)
    let v3114: Int64 = v3113 + (1 as Int64)
    let v3115: Bool = (v3109 == v3114)
    var v3116: Int64 = (0 as Int64)
    if (v3115) {
        v3116 = (0 as Int64)
    } else {
        v3116 = (1 as Int64)
    }
    let v3117: Int64 = (v3101 &+ v3109)
    let v3118: Int64 = (v3102 &+ v3114)
    let v3119: Int64 = (v3104 &+ v3116)
    let v3120: Int64 = (v3094 &+ v3117)
    let v3121: Int64 = (v3098 &+ v3118)
    let v3122: Int64 = (v3100 &+ v3119)
    let v3123: Int64 = (0 as Int64) + (1 as Int64)
    let v3124: Int64 = v3123 + (1 as Int64)
    let v3125: Int64 = v3124 + (1 as Int64)
    let v3126: Int64 = v3125 + (1 as Int64)
    let v3127: Int64 = (0 as Int64) + (1 as Int64)
    let v3128: Int64 = v3127 + (1 as Int64)
    let v3129: Int64 = v3128 + (1 as Int64)
    let v3130: Int64 = v3129 + (1 as Int64)
    let v3131: Bool = (v3126 == v3130)
    var v3132: Int64 = (0 as Int64)
    if (v3131) {
        v3132 = (0 as Int64)
    } else {
        v3132 = (1 as Int64)
    }
    let v3133: Int64 = (0 as Int64) + (1 as Int64)
    let v3134: Int64 = (0 as Int64) + (1 as Int64)
    let v3135: Bool = (v3133 == v3134)
    var v3136: Int64 = (0 as Int64)
    if (v3135) {
        v3136 = (0 as Int64)
    } else {
        v3136 = (1 as Int64)
    }
    let v3137: Int64 = (0 as Int64) + (1 as Int64)
    let v3138: Int64 = v3137 + (1 as Int64)
    let v3139: Int64 = v3138 + (1 as Int64)
    let v3140: Int64 = v3139 + (1 as Int64)
    let v3141: Int64 = v3140 + (1 as Int64)
    let v3142: Int64 = (0 as Int64) + (1 as Int64)
    let v3143: Int64 = v3142 + (1 as Int64)
    let v3144: Int64 = v3143 + (1 as Int64)
    let v3145: Int64 = v3144 + (1 as Int64)
    let v3146: Int64 = v3145 + (1 as Int64)
    let v3147: Bool = (v3141 == v3146)
    var v3148: Int64 = (0 as Int64)
    if (v3147) {
        v3148 = (0 as Int64)
    } else {
        v3148 = (1 as Int64)
    }
    let v3149: Int64 = (v3133 &+ v3141)
    let v3150: Int64 = (v3134 &+ v3146)
    let v3151: Int64 = (v3136 &+ v3148)
    let v3152: Int64 = (v3126 &+ v3149)
    let v3153: Int64 = (v3130 &+ v3150)
    let v3154: Int64 = (v3132 &+ v3151)
    let v3155: Int64 = (v3152 &+ v3120)
    let v3156: Int64 = (v3153 &+ v3121)
    let v3157: Int64 = (v3154 &+ v3122)
    let v3158: Bool = (v3155 == (20 as Int64))
    let v3159: Bool = (v3156 == (20 as Int64))
    let v3160: Bool = (v3157 == (0 as Int64))
    let v3161: Bool = (v3158 && v3159)
    let v3162: Bool = (v3161 && v3160)
    if (v3162) {
    } else {
        "typed-FX-hashed-statement-history-enumeration-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v3163: Int64 = (0 as Int64) + (1 as Int64)
    let v3164: Int64 = v3163 + (1 as Int64)
    let v3165: Int64 = v3164 + (1 as Int64)
    let v3166: Int64 = v3165 + (1 as Int64)
    let v3167: Int64 = (0 as Int64) + (1 as Int64)
    let v3168: Int64 = v3167 + (1 as Int64)
    let v3169: Int64 = v3168 + (1 as Int64)
    let v3170: Int64 = v3169 + (1 as Int64)
    let v3171: Bool = (v3166 == v3170)
    var v3172: Int64 = (0 as Int64)
    if (v3171) {
        v3172 = (0 as Int64)
    } else {
        v3172 = (1 as Int64)
    }
    let v3173: Int64 = (0 as Int64) + (1 as Int64)
    let v3174: Int64 = (0 as Int64) + (1 as Int64)
    let v3175: Bool = (v3173 == v3174)
    var v3176: Int64 = (0 as Int64)
    if (v3175) {
        v3176 = (0 as Int64)
    } else {
        v3176 = (1 as Int64)
    }
    let v3177: Int64 = (0 as Int64) + (1 as Int64)
    let v3178: Int64 = v3177 + (1 as Int64)
    let v3179: Int64 = v3178 + (1 as Int64)
    let v3180: Int64 = v3179 + (1 as Int64)
    let v3181: Int64 = v3180 + (1 as Int64)
    let v3182: Int64 = (0 as Int64) + (1 as Int64)
    let v3183: Int64 = v3182 + (1 as Int64)
    let v3184: Int64 = v3183 + (1 as Int64)
    let v3185: Int64 = v3184 + (1 as Int64)
    let v3186: Int64 = v3185 + (1 as Int64)
    let v3187: Bool = (v3181 == v3186)
    var v3188: Int64 = (0 as Int64)
    if (v3187) {
        v3188 = (0 as Int64)
    } else {
        v3188 = (1 as Int64)
    }
    let v3189: Int64 = (v3173 &+ v3181)
    let v3190: Int64 = (v3174 &+ v3186)
    let v3191: Int64 = (v3176 &+ v3188)
    let v3192: Int64 = (v3166 &+ v3189)
    let v3193: Int64 = (v3170 &+ v3190)
    let v3194: Int64 = (v3172 &+ v3191)
    let v3195: Bool = (v3192 == (10 as Int64))
    let v3196: Bool = (v3193 == (10 as Int64))
    let v3197: Bool = (v3194 == (0 as Int64))
    let v3198: Bool = (v3195 && v3196)
    let v3199: Bool = (v3198 && v3197)
    if (v3199) {
    } else {
        "typed-FX-hashed-statement-history-index-lookup-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v3200: Int64 = (0 as Int64) + (1 as Int64)
    let v3201: Int64 = v3200 + (1 as Int64)
    let v3202: Int64 = v3201 + (1 as Int64)
    let v3203: Int64 = v3202 + (1 as Int64)
    let v3204: Int64 = (0 as Int64) + (1 as Int64)
    let v3205: Int64 = v3204 + (1 as Int64)
    let v3206: Int64 = v3205 + (1 as Int64)
    let v3207: Int64 = v3206 + (1 as Int64)
    let v3208: Bool = (v3203 == v3207)
    var v3209: Int64 = (0 as Int64)
    if (v3208) {
        v3209 = (0 as Int64)
    } else {
        v3209 = (1 as Int64)
    }
    let v3210: Int64 = (0 as Int64) + (1 as Int64)
    let v3211: Int64 = (0 as Int64) + (1 as Int64)
    let v3212: Bool = (v3210 == v3211)
    var v3213: Int64 = (0 as Int64)
    if (v3212) {
        v3213 = (0 as Int64)
    } else {
        v3213 = (1 as Int64)
    }
    let v3214: Int64 = (0 as Int64) + (1 as Int64)
    let v3215: Int64 = v3214 + (1 as Int64)
    let v3216: Int64 = v3215 + (1 as Int64)
    let v3217: Int64 = v3216 + (1 as Int64)
    let v3218: Int64 = v3217 + (1 as Int64)
    let v3219: Int64 = (0 as Int64) + (1 as Int64)
    let v3220: Int64 = v3219 + (1 as Int64)
    let v3221: Int64 = v3220 + (1 as Int64)
    let v3222: Int64 = v3221 + (1 as Int64)
    let v3223: Int64 = v3222 + (1 as Int64)
    let v3224: Bool = (v3218 == v3223)
    var v3225: Int64 = (0 as Int64)
    if (v3224) {
        v3225 = (0 as Int64)
    } else {
        v3225 = (1 as Int64)
    }
    let v3226: Int64 = (v3210 &+ v3218)
    let v3227: Int64 = (v3211 &+ v3223)
    let v3228: Int64 = (v3213 &+ v3225)
    let v3229: Int64 = (v3203 &+ v3226)
    let v3230: Int64 = (v3207 &+ v3227)
    let v3231: Int64 = (v3209 &+ v3228)
    let v3232: Int64 = (0 as Int64) + (1 as Int64)
    let v3233: Int64 = v3232 + (1 as Int64)
    let v3234: Int64 = v3233 + (1 as Int64)
    let v3235: Int64 = v3234 + (1 as Int64)
    let v3236: Int64 = (0 as Int64) + (1 as Int64)
    let v3237: Int64 = v3236 + (1 as Int64)
    let v3238: Int64 = v3237 + (1 as Int64)
    let v3239: Int64 = v3238 + (1 as Int64)
    let v3240: Bool = (v3235 == v3239)
    var v3241: Int64 = (0 as Int64)
    if (v3240) {
        v3241 = (0 as Int64)
    } else {
        v3241 = (1 as Int64)
    }
    let v3242: Int64 = (0 as Int64) + (1 as Int64)
    let v3243: Int64 = (0 as Int64) + (1 as Int64)
    let v3244: Bool = (v3242 == v3243)
    var v3245: Int64 = (0 as Int64)
    if (v3244) {
        v3245 = (0 as Int64)
    } else {
        v3245 = (1 as Int64)
    }
    let v3246: Int64 = (0 as Int64) + (1 as Int64)
    let v3247: Int64 = v3246 + (1 as Int64)
    let v3248: Int64 = v3247 + (1 as Int64)
    let v3249: Int64 = v3248 + (1 as Int64)
    let v3250: Int64 = v3249 + (1 as Int64)
    let v3251: Int64 = (0 as Int64) + (1 as Int64)
    let v3252: Int64 = v3251 + (1 as Int64)
    let v3253: Int64 = v3252 + (1 as Int64)
    let v3254: Int64 = v3253 + (1 as Int64)
    let v3255: Int64 = v3254 + (1 as Int64)
    let v3256: Bool = (v3250 == v3255)
    var v3257: Int64 = (0 as Int64)
    if (v3256) {
        v3257 = (0 as Int64)
    } else {
        v3257 = (1 as Int64)
    }
    let v3258: Int64 = (v3242 &+ v3250)
    let v3259: Int64 = (v3243 &+ v3255)
    let v3260: Int64 = (v3245 &+ v3257)
    let v3261: Int64 = (v3235 &+ v3258)
    let v3262: Int64 = (v3239 &+ v3259)
    let v3263: Int64 = (v3241 &+ v3260)
    let v3264: Bool = (v3229 == (10 as Int64))
    let v3265: Bool = (v3230 == (10 as Int64))
    let v3266: Bool = (v3231 == (0 as Int64))
    let v3267: Bool = (v3261 == (10 as Int64))
    let v3268: Bool = (v3262 == (10 as Int64))
    let v3269: Bool = (v3263 == (0 as Int64))
    let v3270: Bool = (v3264 && v3265)
    let v3271: Bool = (v3270 && v3266)
    let v3272: Bool = (v3271 && v3267)
    let v3273: Bool = (v3272 && v3268)
    let v3274: Bool = (v3273 && v3269)
    if (v3274) {
    } else {
        "typed-FX-hashed-statement-identity-lookup-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v3275: Int64 = (0 as Int64) + (1 as Int64)
    let v3276: Int64 = v3275 + (1 as Int64)
    let v3277: Int64 = v3276 + (1 as Int64)
    let v3278: Int64 = v3277 + (1 as Int64)
    let v3279: Int64 = (0 as Int64) + (1 as Int64)
    let v3280: Int64 = v3279 + (1 as Int64)
    let v3281: Int64 = v3280 + (1 as Int64)
    let v3282: Int64 = v3281 + (1 as Int64)
    let v3283: Bool = (v3278 == v3282)
    var v3284: Int64 = (0 as Int64)
    if (v3283) {
        v3284 = (0 as Int64)
    } else {
        v3284 = (1 as Int64)
    }
    let v3285: Int64 = (0 as Int64) + (1 as Int64)
    let v3286: Int64 = (0 as Int64) + (1 as Int64)
    let v3287: Bool = (v3285 == v3286)
    var v3288: Int64 = (0 as Int64)
    if (v3287) {
        v3288 = (0 as Int64)
    } else {
        v3288 = (1 as Int64)
    }
    let v3289: Int64 = (0 as Int64) + (1 as Int64)
    let v3290: Int64 = v3289 + (1 as Int64)
    let v3291: Int64 = v3290 + (1 as Int64)
    let v3292: Int64 = v3291 + (1 as Int64)
    let v3293: Int64 = v3292 + (1 as Int64)
    let v3294: Int64 = (0 as Int64) + (1 as Int64)
    let v3295: Int64 = v3294 + (1 as Int64)
    let v3296: Int64 = v3295 + (1 as Int64)
    let v3297: Int64 = v3296 + (1 as Int64)
    let v3298: Int64 = v3297 + (1 as Int64)
    let v3299: Bool = (v3293 == v3298)
    var v3300: Int64 = (0 as Int64)
    if (v3299) {
        v3300 = (0 as Int64)
    } else {
        v3300 = (1 as Int64)
    }
    let v3301: Int64 = (v3285 &+ v3293)
    let v3302: Int64 = (v3286 &+ v3298)
    let v3303: Int64 = (v3288 &+ v3300)
    let v3304: Int64 = (v3278 &+ v3301)
    let v3305: Int64 = (v3282 &+ v3302)
    let v3306: Int64 = (v3284 &+ v3303)
    let v3307: Int64 = (0 as Int64) + (1 as Int64)
    let v3308: Int64 = v3307 + (1 as Int64)
    let v3309: Int64 = v3308 + (1 as Int64)
    let v3310: Int64 = v3309 + (1 as Int64)
    let v3311: Int64 = (0 as Int64) + (1 as Int64)
    let v3312: Int64 = v3311 + (1 as Int64)
    let v3313: Int64 = v3312 + (1 as Int64)
    let v3314: Int64 = v3313 + (1 as Int64)
    let v3315: Bool = (v3310 == v3314)
    var v3316: Int64 = (0 as Int64)
    if (v3315) {
        v3316 = (0 as Int64)
    } else {
        v3316 = (1 as Int64)
    }
    let v3317: Int64 = (0 as Int64) + (1 as Int64)
    let v3318: Int64 = (0 as Int64) + (1 as Int64)
    let v3319: Bool = (v3317 == v3318)
    var v3320: Int64 = (0 as Int64)
    if (v3319) {
        v3320 = (0 as Int64)
    } else {
        v3320 = (1 as Int64)
    }
    let v3321: Int64 = (0 as Int64) + (1 as Int64)
    let v3322: Int64 = v3321 + (1 as Int64)
    let v3323: Int64 = v3322 + (1 as Int64)
    let v3324: Int64 = v3323 + (1 as Int64)
    let v3325: Int64 = v3324 + (1 as Int64)
    let v3326: Int64 = (0 as Int64) + (1 as Int64)
    let v3327: Int64 = v3326 + (1 as Int64)
    let v3328: Int64 = v3327 + (1 as Int64)
    let v3329: Int64 = v3328 + (1 as Int64)
    let v3330: Int64 = v3329 + (1 as Int64)
    let v3331: Bool = (v3325 == v3330)
    var v3332: Int64 = (0 as Int64)
    if (v3331) {
        v3332 = (0 as Int64)
    } else {
        v3332 = (1 as Int64)
    }
    let v3333: Int64 = (v3317 &+ v3325)
    let v3334: Int64 = (v3318 &+ v3330)
    let v3335: Int64 = (v3320 &+ v3332)
    let v3336: Int64 = (v3310 &+ v3333)
    let v3337: Int64 = (v3314 &+ v3334)
    let v3338: Int64 = (v3316 &+ v3335)
    let v3339: Int64 = (v3304 &+ v3336)
    let v3340: Int64 = (v3305 &+ v3337)
    let v3341: Int64 = (v3306 &+ v3338)
    let v3342: Bool = (v3339 == (20 as Int64))
    let v3343: Bool = (v3340 == (20 as Int64))
    let v3344: Bool = (v3341 == (0 as Int64))
    let v3345: Bool = (v3342 && v3343)
    let v3346: Bool = (v3345 && v3344)
    if (v3346) {
    } else {
        "typed-FX-hashed-statement-membership-lookup-program-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v3347: Int64 = (0 as Int64) + (1 as Int64)
    let v3348: Int64 = v3347 + (1 as Int64)
    let v3349: Int64 = v3348 + (1 as Int64)
    let v3350: Int64 = v3349 + (1 as Int64)
    let v3351: Int64 = (0 as Int64) + (1 as Int64)
    let v3352: Int64 = v3351 + (1 as Int64)
    let v3353: Int64 = v3352 + (1 as Int64)
    let v3354: Int64 = v3353 + (1 as Int64)
    let v3355: Bool = (v3350 == v3354)
    var v3356: Int64 = (0 as Int64)
    if (v3355) {
        v3356 = (0 as Int64)
    } else {
        v3356 = (1 as Int64)
    }
    let v3357: Int64 = (0 as Int64) + (1 as Int64)
    let v3358: Int64 = (0 as Int64) + (1 as Int64)
    let v3359: Bool = (v3357 == v3358)
    var v3360: Int64 = (0 as Int64)
    if (v3359) {
        v3360 = (0 as Int64)
    } else {
        v3360 = (1 as Int64)
    }
    let v3361: Int64 = (0 as Int64) + (1 as Int64)
    let v3362: Int64 = v3361 + (1 as Int64)
    let v3363: Int64 = v3362 + (1 as Int64)
    let v3364: Int64 = v3363 + (1 as Int64)
    let v3365: Int64 = v3364 + (1 as Int64)
    let v3366: Int64 = (0 as Int64) + (1 as Int64)
    let v3367: Int64 = v3366 + (1 as Int64)
    let v3368: Int64 = v3367 + (1 as Int64)
    let v3369: Int64 = v3368 + (1 as Int64)
    let v3370: Int64 = v3369 + (1 as Int64)
    let v3371: Bool = (v3365 == v3370)
    var v3372: Int64 = (0 as Int64)
    if (v3371) {
        v3372 = (0 as Int64)
    } else {
        v3372 = (1 as Int64)
    }
    let v3373: Int64 = (v3357 &+ v3365)
    let v3374: Int64 = (v3358 &+ v3370)
    let v3375: Int64 = (v3360 &+ v3372)
    let v3376: Int64 = (v3350 &+ v3373)
    let v3377: Int64 = (v3354 &+ v3374)
    let v3378: Int64 = (v3356 &+ v3375)
    let v3379: Int64 = (0 as Int64) + (1 as Int64)
    let v3380: Int64 = v3379 + (1 as Int64)
    let v3381: Int64 = v3380 + (1 as Int64)
    let v3382: Int64 = v3381 + (1 as Int64)
    let v3383: Int64 = (0 as Int64) + (1 as Int64)
    let v3384: Int64 = v3383 + (1 as Int64)
    let v3385: Int64 = v3384 + (1 as Int64)
    let v3386: Int64 = v3385 + (1 as Int64)
    let v3387: Bool = (v3382 == v3386)
    var v3388: Int64 = (0 as Int64)
    if (v3387) {
        v3388 = (0 as Int64)
    } else {
        v3388 = (1 as Int64)
    }
    let v3389: Int64 = (0 as Int64) + (1 as Int64)
    let v3390: Int64 = (0 as Int64) + (1 as Int64)
    let v3391: Bool = (v3389 == v3390)
    var v3392: Int64 = (0 as Int64)
    if (v3391) {
        v3392 = (0 as Int64)
    } else {
        v3392 = (1 as Int64)
    }
    let v3393: Int64 = (0 as Int64) + (1 as Int64)
    let v3394: Int64 = v3393 + (1 as Int64)
    let v3395: Int64 = v3394 + (1 as Int64)
    let v3396: Int64 = v3395 + (1 as Int64)
    let v3397: Int64 = v3396 + (1 as Int64)
    let v3398: Int64 = (0 as Int64) + (1 as Int64)
    let v3399: Int64 = v3398 + (1 as Int64)
    let v3400: Int64 = v3399 + (1 as Int64)
    let v3401: Int64 = v3400 + (1 as Int64)
    let v3402: Int64 = v3401 + (1 as Int64)
    let v3403: Bool = (v3397 == v3402)
    var v3404: Int64 = (0 as Int64)
    if (v3403) {
        v3404 = (0 as Int64)
    } else {
        v3404 = (1 as Int64)
    }
    let v3405: Int64 = (v3389 &+ v3397)
    let v3406: Int64 = (v3390 &+ v3402)
    let v3407: Int64 = (v3392 &+ v3404)
    let v3408: Int64 = (v3382 &+ v3405)
    let v3409: Int64 = (v3386 &+ v3406)
    let v3410: Int64 = (v3388 &+ v3407)
    let v3411: Int64 = (v3376 &+ v3408)
    let v3412: Int64 = (v3377 &+ v3409)
    let v3413: Int64 = (v3378 &+ v3410)
    let v3414: Int64 = (0 as Int64) + (1 as Int64)
    let v3415: Int64 = v3414 + (1 as Int64)
    let v3416: Int64 = v3415 + (1 as Int64)
    let v3417: Int64 = v3416 + (1 as Int64)
    let v3418: Int64 = (0 as Int64) + (1 as Int64)
    let v3419: Int64 = v3418 + (1 as Int64)
    let v3420: Int64 = v3419 + (1 as Int64)
    let v3421: Int64 = v3420 + (1 as Int64)
    let v3422: Bool = (v3417 == v3421)
    var v3423: Int64 = (0 as Int64)
    if (v3422) {
        v3423 = (0 as Int64)
    } else {
        v3423 = (1 as Int64)
    }
    let v3424: Int64 = (0 as Int64) + (1 as Int64)
    let v3425: Int64 = (0 as Int64) + (1 as Int64)
    let v3426: Bool = (v3424 == v3425)
    var v3427: Int64 = (0 as Int64)
    if (v3426) {
        v3427 = (0 as Int64)
    } else {
        v3427 = (1 as Int64)
    }
    let v3428: Int64 = (0 as Int64) + (1 as Int64)
    let v3429: Int64 = v3428 + (1 as Int64)
    let v3430: Int64 = v3429 + (1 as Int64)
    let v3431: Int64 = v3430 + (1 as Int64)
    let v3432: Int64 = v3431 + (1 as Int64)
    let v3433: Int64 = (0 as Int64) + (1 as Int64)
    let v3434: Int64 = v3433 + (1 as Int64)
    let v3435: Int64 = v3434 + (1 as Int64)
    let v3436: Int64 = v3435 + (1 as Int64)
    let v3437: Int64 = v3436 + (1 as Int64)
    let v3438: Bool = (v3432 == v3437)
    var v3439: Int64 = (0 as Int64)
    if (v3438) {
        v3439 = (0 as Int64)
    } else {
        v3439 = (1 as Int64)
    }
    let v3440: Int64 = (v3424 &+ v3432)
    let v3441: Int64 = (v3425 &+ v3437)
    let v3442: Int64 = (v3427 &+ v3439)
    let v3443: Int64 = (v3417 &+ v3440)
    let v3444: Int64 = (v3421 &+ v3441)
    let v3445: Int64 = (v3423 &+ v3442)
    let v3446: Int64 = (0 as Int64) + (1 as Int64)
    let v3447: Int64 = v3446 + (1 as Int64)
    let v3448: Int64 = v3447 + (1 as Int64)
    let v3449: Int64 = v3448 + (1 as Int64)
    let v3450: Int64 = (0 as Int64) + (1 as Int64)
    let v3451: Int64 = v3450 + (1 as Int64)
    let v3452: Int64 = v3451 + (1 as Int64)
    let v3453: Int64 = v3452 + (1 as Int64)
    let v3454: Bool = (v3449 == v3453)
    var v3455: Int64 = (0 as Int64)
    if (v3454) {
        v3455 = (0 as Int64)
    } else {
        v3455 = (1 as Int64)
    }
    let v3456: Int64 = (0 as Int64) + (1 as Int64)
    let v3457: Int64 = (0 as Int64) + (1 as Int64)
    let v3458: Bool = (v3456 == v3457)
    var v3459: Int64 = (0 as Int64)
    if (v3458) {
        v3459 = (0 as Int64)
    } else {
        v3459 = (1 as Int64)
    }
    let v3460: Int64 = (0 as Int64) + (1 as Int64)
    let v3461: Int64 = v3460 + (1 as Int64)
    let v3462: Int64 = v3461 + (1 as Int64)
    let v3463: Int64 = v3462 + (1 as Int64)
    let v3464: Int64 = v3463 + (1 as Int64)
    let v3465: Int64 = (0 as Int64) + (1 as Int64)
    let v3466: Int64 = v3465 + (1 as Int64)
    let v3467: Int64 = v3466 + (1 as Int64)
    let v3468: Int64 = v3467 + (1 as Int64)
    let v3469: Int64 = v3468 + (1 as Int64)
    let v3470: Bool = (v3464 == v3469)
    var v3471: Int64 = (0 as Int64)
    if (v3470) {
        v3471 = (0 as Int64)
    } else {
        v3471 = (1 as Int64)
    }
    let v3472: Int64 = (v3456 &+ v3464)
    let v3473: Int64 = (v3457 &+ v3469)
    let v3474: Int64 = (v3459 &+ v3471)
    let v3475: Int64 = (v3449 &+ v3472)
    let v3476: Int64 = (v3453 &+ v3473)
    let v3477: Int64 = (v3455 &+ v3474)
    let v3478: Int64 = (v3443 &+ v3475)
    let v3479: Bool = (v3411 == v3478)
    let v3480: Int64 = (v3444 &+ v3476)
    let v3481: Bool = (v3412 == v3480)
    let v3482: Int64 = (v3445 &+ v3477)
    let v3483: Bool = (v3413 == v3482)
    let v3484: Bool = (v3479 && v3481)
    let v3485: Bool = (v3484 && v3483)
    if (v3485) {
    } else {
        "typed-FX-hashed-statement-membership-lookup-program-append-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v3486: Int64 = (0 as Int64) + (1 as Int64)
    let v3487: Int64 = v3486 + (1 as Int64)
    let v3488: Int64 = v3487 + (1 as Int64)
    let v3489: Int64 = v3488 + (1 as Int64)
    let v3490: Int64 = (0 as Int64) + (1 as Int64)
    let v3491: Int64 = v3490 + (1 as Int64)
    let v3492: Int64 = v3491 + (1 as Int64)
    let v3493: Int64 = v3492 + (1 as Int64)
    let v3494: Bool = (v3489 == v3493)
    var v3495: Int64 = (0 as Int64)
    if (v3494) {
        v3495 = (0 as Int64)
    } else {
        v3495 = (1 as Int64)
    }
    let v3496: Int64 = (0 as Int64) + (1 as Int64)
    let v3497: Int64 = (0 as Int64) + (1 as Int64)
    let v3498: Bool = (v3496 == v3497)
    var v3499: Int64 = (0 as Int64)
    if (v3498) {
        v3499 = (0 as Int64)
    } else {
        v3499 = (1 as Int64)
    }
    let v3500: Int64 = (0 as Int64) + (1 as Int64)
    let v3501: Int64 = v3500 + (1 as Int64)
    let v3502: Int64 = v3501 + (1 as Int64)
    let v3503: Int64 = v3502 + (1 as Int64)
    let v3504: Int64 = v3503 + (1 as Int64)
    let v3505: Int64 = (0 as Int64) + (1 as Int64)
    let v3506: Int64 = v3505 + (1 as Int64)
    let v3507: Int64 = v3506 + (1 as Int64)
    let v3508: Int64 = v3507 + (1 as Int64)
    let v3509: Int64 = v3508 + (1 as Int64)
    let v3510: Bool = (v3504 == v3509)
    var v3511: Int64 = (0 as Int64)
    if (v3510) {
        v3511 = (0 as Int64)
    } else {
        v3511 = (1 as Int64)
    }
    let v3512: Int64 = (v3496 &+ v3504)
    let v3513: Int64 = (v3497 &+ v3509)
    let v3514: Int64 = (v3499 &+ v3511)
    let v3515: Int64 = (v3489 &+ v3512)
    let v3516: Int64 = (v3493 &+ v3513)
    let v3517: Int64 = (v3495 &+ v3514)
    let v3518: Int64 = (0 as Int64) + (1 as Int64)
    let v3519: Int64 = v3518 + (1 as Int64)
    let v3520: Int64 = v3519 + (1 as Int64)
    let v3521: Int64 = v3520 + (1 as Int64)
    let v3522: Int64 = (0 as Int64) + (1 as Int64)
    let v3523: Int64 = v3522 + (1 as Int64)
    let v3524: Int64 = v3523 + (1 as Int64)
    let v3525: Int64 = v3524 + (1 as Int64)
    let v3526: Bool = (v3521 == v3525)
    var v3527: Int64 = (0 as Int64)
    if (v3526) {
        v3527 = (0 as Int64)
    } else {
        v3527 = (1 as Int64)
    }
    let v3528: Int64 = (0 as Int64) + (1 as Int64)
    let v3529: Int64 = (0 as Int64) + (1 as Int64)
    let v3530: Bool = (v3528 == v3529)
    var v3531: Int64 = (0 as Int64)
    if (v3530) {
        v3531 = (0 as Int64)
    } else {
        v3531 = (1 as Int64)
    }
    let v3532: Int64 = (0 as Int64) + (1 as Int64)
    let v3533: Int64 = v3532 + (1 as Int64)
    let v3534: Int64 = v3533 + (1 as Int64)
    let v3535: Int64 = v3534 + (1 as Int64)
    let v3536: Int64 = v3535 + (1 as Int64)
    let v3537: Int64 = (0 as Int64) + (1 as Int64)
    let v3538: Int64 = v3537 + (1 as Int64)
    let v3539: Int64 = v3538 + (1 as Int64)
    let v3540: Int64 = v3539 + (1 as Int64)
    let v3541: Int64 = v3540 + (1 as Int64)
    let v3542: Bool = (v3536 == v3541)
    var v3543: Int64 = (0 as Int64)
    if (v3542) {
        v3543 = (0 as Int64)
    } else {
        v3543 = (1 as Int64)
    }
    let v3544: Int64 = (v3528 &+ v3536)
    let v3545: Int64 = (v3529 &+ v3541)
    let v3546: Int64 = (v3531 &+ v3543)
    let v3547: Int64 = (v3521 &+ v3544)
    let v3548: Int64 = (v3525 &+ v3545)
    let v3549: Int64 = (v3527 &+ v3546)
    let v3550: Int64 = (0 as Int64) + (1 as Int64)
    let v3551: Int64 = v3550 + (1 as Int64)
    let v3552: Int64 = v3551 + (1 as Int64)
    let v3553: Int64 = v3552 + (1 as Int64)
    let v3554: Int64 = (0 as Int64) + (1 as Int64)
    let v3555: Int64 = v3554 + (1 as Int64)
    let v3556: Int64 = v3555 + (1 as Int64)
    let v3557: Int64 = v3556 + (1 as Int64)
    let v3558: Bool = (v3553 == v3557)
    var v3559: Int64 = (0 as Int64)
    if (v3558) {
        v3559 = (0 as Int64)
    } else {
        v3559 = (1 as Int64)
    }
    let v3560: Int64 = (0 as Int64) + (1 as Int64)
    let v3561: Int64 = (0 as Int64) + (1 as Int64)
    let v3562: Bool = (v3560 == v3561)
    var v3563: Int64 = (0 as Int64)
    if (v3562) {
        v3563 = (0 as Int64)
    } else {
        v3563 = (1 as Int64)
    }
    let v3564: Int64 = (0 as Int64) + (1 as Int64)
    let v3565: Int64 = v3564 + (1 as Int64)
    let v3566: Int64 = v3565 + (1 as Int64)
    let v3567: Int64 = v3566 + (1 as Int64)
    let v3568: Int64 = v3567 + (1 as Int64)
    let v3569: Int64 = (0 as Int64) + (1 as Int64)
    let v3570: Int64 = v3569 + (1 as Int64)
    let v3571: Int64 = v3570 + (1 as Int64)
    let v3572: Int64 = v3571 + (1 as Int64)
    let v3573: Int64 = v3572 + (1 as Int64)
    let v3574: Bool = (v3568 == v3573)
    var v3575: Int64 = (0 as Int64)
    if (v3574) {
        v3575 = (0 as Int64)
    } else {
        v3575 = (1 as Int64)
    }
    let v3576: Int64 = (v3560 &+ v3568)
    let v3577: Int64 = (v3561 &+ v3573)
    let v3578: Int64 = (v3563 &+ v3575)
    let v3579: Int64 = (v3553 &+ v3576)
    let v3580: Int64 = (v3557 &+ v3577)
    let v3581: Int64 = (v3559 &+ v3578)
    let v3582: Int64 = (0 as Int64) + (1 as Int64)
    let v3583: Int64 = v3582 + (1 as Int64)
    let v3584: Int64 = v3583 + (1 as Int64)
    let v3585: Int64 = v3584 + (1 as Int64)
    let v3586: Int64 = (0 as Int64) + (1 as Int64)
    let v3587: Int64 = v3586 + (1 as Int64)
    let v3588: Int64 = v3587 + (1 as Int64)
    let v3589: Int64 = v3588 + (1 as Int64)
    let v3590: Bool = (v3585 == v3589)
    var v3591: Int64 = (0 as Int64)
    if (v3590) {
        v3591 = (0 as Int64)
    } else {
        v3591 = (1 as Int64)
    }
    let v3592: Int64 = (0 as Int64) + (1 as Int64)
    let v3593: Int64 = (0 as Int64) + (1 as Int64)
    let v3594: Bool = (v3592 == v3593)
    var v3595: Int64 = (0 as Int64)
    if (v3594) {
        v3595 = (0 as Int64)
    } else {
        v3595 = (1 as Int64)
    }
    let v3596: Int64 = (0 as Int64) + (1 as Int64)
    let v3597: Int64 = v3596 + (1 as Int64)
    let v3598: Int64 = v3597 + (1 as Int64)
    let v3599: Int64 = v3598 + (1 as Int64)
    let v3600: Int64 = v3599 + (1 as Int64)
    let v3601: Int64 = (0 as Int64) + (1 as Int64)
    let v3602: Int64 = v3601 + (1 as Int64)
    let v3603: Int64 = v3602 + (1 as Int64)
    let v3604: Int64 = v3603 + (1 as Int64)
    let v3605: Int64 = v3604 + (1 as Int64)
    let v3606: Bool = (v3600 == v3605)
    var v3607: Int64 = (0 as Int64)
    if (v3606) {
        v3607 = (0 as Int64)
    } else {
        v3607 = (1 as Int64)
    }
    let v3608: Int64 = (v3592 &+ v3600)
    let v3609: Int64 = (v3593 &+ v3605)
    let v3610: Int64 = (v3595 &+ v3607)
    let v3611: Int64 = (v3585 &+ v3608)
    let v3612: Int64 = (v3589 &+ v3609)
    let v3613: Int64 = (v3591 &+ v3610)
    let v3614: Bool = (v3515 == v3547)
    let v3615: Bool = (v3516 == v3548)
    let v3616: Bool = (v3517 == v3549)
    let v3617: Bool = (v3614 && v3615)
    let v3618: Bool = (v3617 && v3616)
    if (v3618) {
    } else {
        "typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    let v3619: Bool = (v3579 == v3611)
    let v3620: Bool = (v3580 == v3612)
    let v3621: Bool = (v3581 == v3613)
    let v3622: Bool = (v3619 && v3620)
    let v3623: Bool = (v3622 && v3621)
    if (v3623) {
    } else {
        "typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
