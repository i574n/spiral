type US0_TypedFxHashedStatementChecksumValidationAccepted = { readonly tag: 0, readonly f0: bigint, readonly f1: bigint, readonly f2: bigint, readonly f3: bigint, readonly f4: bigint, readonly f5: string };
type US0_TypedFxHashedStatementChecksumValidationRejected = { readonly tag: 1, readonly f0: bigint, readonly f1: bigint, readonly f2: string };
type US0 = US0_TypedFxHashedStatementChecksumValidationAccepted | US0_TypedFxHashedStatementChecksumValidationRejected;
function US0_TypedFxHashedStatementChecksumValidationAccepted(f0: bigint, f1: bigint, f2: bigint, f3: bigint, f4: bigint, f5: string): US0 { return { tag: 0, f0: f0, f1: f1, f2: f2, f3: f3, f4: f4, f5: f5 }; }
function US0_TypedFxHashedStatementChecksumValidationRejected(f0: bigint, f1: bigint, f2: string): US0 { return { tag: 1, f0: f0, f1: f1, f2: f2 }; }
export function main(): number {
    const v0: bigint = 0n + 1n;
    const v1: bigint = v0 + 1n;
    const v2: bigint = v1 + 1n;
    const v3: bigint = 0n + 1n;
    const v4: bigint = v3 + 1n;
    const v5: bigint = v4 + 1n;
    const v6: bigint = 0n + 1n;
    const v7: bigint = v6 + 1n;
    const v8: bigint = 0n + 1n;
    const v9: bigint = v8 + 1n;
    const v10: bigint = v9 + 1n;
    const v11: bigint = v10 + 1n;
    const v12: bigint = 0n + 1n;
    const v14: bigint = 0n + 1n;
    const v15: bigint = v14 + 1n;
    const v16: bigint = v15 + 1n;
    const v17: bigint = v16 + 1n;
    const v18: bigint = v17 + 1n;
    const v19: bigint = 0n + 1n;
    const v20: bigint = BigInt.asIntN(64, v12 + v12);
    const v21: bigint = BigInt.asIntN(64, v7 + v20);
    const v22: bigint = 0n + 1n;
    const v23: bigint = v22 + 1n;
    const v24: bigint = v23 + 1n;
    const v25: bigint = 0n + 1n;
    const v26: bigint = v25 + 1n;
    const v27: bigint = v26 + 1n;
    const v28: bigint = 0n + 1n;
    const v29: bigint = v28 + 1n;
    const v30: bigint = 0n + 1n;
    const v31: bigint = v30 + 1n;
    const v32: bigint = v31 + 1n;
    const v33: bigint = v32 + 1n;
    const v34: bigint = 0n + 1n;
    const v36: bigint = 0n + 1n;
    const v37: bigint = v36 + 1n;
    const v38: bigint = v37 + 1n;
    const v39: bigint = v38 + 1n;
    const v40: bigint = BigInt.asIntN(64, v34 + v34);
    const v41: bigint = BigInt.asIntN(64, v29 + v40);
    const v42: bigint = BigInt.asIntN(64, v18 + v39);
    const v43: bigint = BigInt.asIntN(64, v21 + v41);
    const v44: boolean = v42 === 9n;
    const v45: boolean = v19 === 1n;
    const v46: boolean = v43 === 8n;
    const v47: boolean = v44 && v45;
    const v48: boolean = v47 && v46;
    if (v48) {
    } else {
        throw new Error("typed-usd-eur-determined-tie-rounding-runtime-mismatch");
    }
    const v49: bigint = 0n + 1n;
    const v50: bigint = v49 + 1n;
    const v51: bigint = v50 + 1n;
    const v52: bigint = v51 + 1n;
    const v53: bigint = 0n + 1n;
    const v54: bigint = v53 + 1n;
    const v55: bigint = v54 + 1n;
    const v56: bigint = v55 + 1n;
    const v57: boolean = v52 === v56;
    let v58: bigint;
    if (v57) {
        v58 = 0n;
    } else {
        v58 = 1n;
    }
    const v59: bigint = 0n + 1n;
    const v60: bigint = 0n + 1n;
    const v61: boolean = v59 === v60;
    let v62: bigint;
    if (v61) {
        v62 = 0n;
    } else {
        v62 = 1n;
    }
    const v63: bigint = 0n + 1n;
    const v64: bigint = v63 + 1n;
    const v65: bigint = v64 + 1n;
    const v66: bigint = v65 + 1n;
    const v67: bigint = v66 + 1n;
    const v68: bigint = 0n + 1n;
    const v69: bigint = v68 + 1n;
    const v70: bigint = v69 + 1n;
    const v71: bigint = v70 + 1n;
    const v72: bigint = v71 + 1n;
    const v73: boolean = v67 === v72;
    let v74: bigint;
    if (v73) {
        v74 = 0n;
    } else {
        v74 = 1n;
    }
    const v75: bigint = BigInt.asIntN(64, v59 + v67);
    const v76: bigint = BigInt.asIntN(64, v60 + v72);
    const v77: bigint = BigInt.asIntN(64, v62 + v74);
    const v78: bigint = BigInt.asIntN(64, v52 + v75);
    const v79: bigint = BigInt.asIntN(64, v56 + v76);
    const v80: bigint = BigInt.asIntN(64, v58 + v77);
    const v81: boolean = v78 === 10n;
    const v82: boolean = v79 === 10n;
    const v83: boolean = v80 === 0n;
    const v84: boolean = v81 && v82;
    const v85: boolean = v84 && v83;
    if (v85) {
    } else {
        throw new Error("typed-FX-statement-expected-raw-append-runtime-mismatch");
    }
    const v86: bigint = 0n + 1n;
    const v87: bigint = v86 + 1n;
    const v88: bigint = v87 + 1n;
    const v89: bigint = v88 + 1n;
    const v90: bigint = 0n + 1n;
    const v91: bigint = v90 + 1n;
    const v92: bigint = v91 + 1n;
    const v93: bigint = v92 + 1n;
    const v94: boolean = v89 === v93;
    let v95: bigint;
    if (v94) {
        v95 = 0n;
    } else {
        v95 = 1n;
    }
    const v96: bigint = 0n + 1n;
    const v97: bigint = 0n + 1n;
    const v98: boolean = v96 === v97;
    let v99: bigint;
    if (v98) {
        v99 = 0n;
    } else {
        v99 = 1n;
    }
    const v100: bigint = 0n + 1n;
    const v101: bigint = v100 + 1n;
    const v102: bigint = v101 + 1n;
    const v103: bigint = v102 + 1n;
    const v104: bigint = v103 + 1n;
    const v105: bigint = 0n + 1n;
    const v106: bigint = v105 + 1n;
    const v107: bigint = v106 + 1n;
    const v108: bigint = v107 + 1n;
    const v109: bigint = v108 + 1n;
    const v110: boolean = v104 === v109;
    let v111: bigint;
    if (v110) {
        v111 = 0n;
    } else {
        v111 = 1n;
    }
    const v114: bigint = BigInt.asIntN(64, v99 + v111);
    const v117: bigint = BigInt.asIntN(64, v95 + v114);
    const v118: bigint = 0n + 1n;
    const v119: bigint = v118 + 1n;
    const v120: bigint = v119 + 1n;
    const v121: bigint = v120 + 1n;
    const v122: bigint = 0n + 1n;
    const v123: bigint = v122 + 1n;
    const v124: bigint = v123 + 1n;
    const v125: bigint = v124 + 1n;
    const v126: boolean = v121 === v125;
    let v127: bigint;
    if (v126) {
        v127 = 0n;
    } else {
        v127 = 1n;
    }
    const v128: bigint = 0n + 1n;
    const v129: bigint = 0n + 1n;
    const v130: boolean = v128 === v129;
    let v131: bigint;
    if (v130) {
        v131 = 0n;
    } else {
        v131 = 1n;
    }
    const v132: bigint = 0n + 1n;
    const v133: bigint = v132 + 1n;
    const v134: bigint = v133 + 1n;
    const v135: bigint = v134 + 1n;
    const v136: bigint = v135 + 1n;
    const v137: bigint = 0n + 1n;
    const v138: bigint = v137 + 1n;
    const v139: bigint = v138 + 1n;
    const v140: bigint = v139 + 1n;
    const v141: bigint = v140 + 1n;
    const v142: boolean = v136 === v141;
    let v143: bigint;
    if (v142) {
        v143 = 0n;
    } else {
        v143 = 1n;
    }
    const v146: bigint = BigInt.asIntN(64, v131 + v143);
    const v149: bigint = BigInt.asIntN(64, v127 + v146);
    const v150: bigint = BigInt.asIntN(64, v117 + v149);
    const v151: boolean = v150 === 0n;
    if (v151) {
    } else {
        throw new Error("typed-FX-statement-two-writer-raw-CAS-runtime-mismatch");
    }
    const v152: bigint = 0n + 1n;
    const v153: bigint = v152 + 1n;
    const v154: bigint = v153 + 1n;
    const v155: bigint = v154 + 1n;
    const v156: bigint = 0n + 1n;
    const v157: bigint = v156 + 1n;
    const v158: bigint = v157 + 1n;
    const v159: bigint = v158 + 1n;
    const v160: boolean = v155 === v159;
    let v161: bigint;
    if (v160) {
        v161 = 0n;
    } else {
        v161 = 1n;
    }
    const v162: bigint = 0n + 1n;
    const v163: bigint = 0n + 1n;
    const v164: boolean = v162 === v163;
    let v165: bigint;
    if (v164) {
        v165 = 0n;
    } else {
        v165 = 1n;
    }
    const v166: bigint = 0n + 1n;
    const v167: bigint = v166 + 1n;
    const v168: bigint = v167 + 1n;
    const v169: bigint = v168 + 1n;
    const v170: bigint = v169 + 1n;
    const v171: bigint = 0n + 1n;
    const v172: bigint = v171 + 1n;
    const v173: bigint = v172 + 1n;
    const v174: bigint = v173 + 1n;
    const v175: bigint = v174 + 1n;
    const v176: boolean = v170 === v175;
    let v177: bigint;
    if (v176) {
        v177 = 0n;
    } else {
        v177 = 1n;
    }
    const v180: bigint = BigInt.asIntN(64, v165 + v177);
    const v183: bigint = BigInt.asIntN(64, v161 + v180);
    const v184: bigint = 0n + 1n;
    const v185: bigint = v184 + 1n;
    const v186: bigint = v185 + 1n;
    const v187: bigint = v186 + 1n;
    const v188: bigint = 0n + 1n;
    const v189: bigint = v188 + 1n;
    const v190: bigint = v189 + 1n;
    const v191: bigint = v190 + 1n;
    const v192: boolean = v187 === v191;
    let v193: bigint;
    if (v192) {
        v193 = 0n;
    } else {
        v193 = 1n;
    }
    const v194: bigint = 0n + 1n;
    const v195: bigint = 0n + 1n;
    const v196: boolean = v194 === v195;
    let v197: bigint;
    if (v196) {
        v197 = 0n;
    } else {
        v197 = 1n;
    }
    const v198: bigint = 0n + 1n;
    const v199: bigint = v198 + 1n;
    const v200: bigint = v199 + 1n;
    const v201: bigint = v200 + 1n;
    const v202: bigint = v201 + 1n;
    const v203: bigint = 0n + 1n;
    const v204: bigint = v203 + 1n;
    const v205: bigint = v204 + 1n;
    const v206: bigint = v205 + 1n;
    const v207: bigint = v206 + 1n;
    const v208: boolean = v202 === v207;
    let v209: bigint;
    if (v208) {
        v209 = 0n;
    } else {
        v209 = 1n;
    }
    const v212: bigint = BigInt.asIntN(64, v197 + v209);
    const v215: bigint = BigInt.asIntN(64, v193 + v212);
    const v216: bigint = BigInt.asIntN(64, v183 + v215);
    const v217: bigint = 0n + 1n;
    const v218: bigint = v217 + 1n;
    const v219: bigint = v218 + 1n;
    const v220: bigint = v219 + 1n;
    const v221: bigint = 0n + 1n;
    const v222: bigint = v221 + 1n;
    const v223: bigint = v222 + 1n;
    const v224: bigint = v223 + 1n;
    const v225: boolean = v220 === v224;
    let v226: bigint;
    if (v225) {
        v226 = 0n;
    } else {
        v226 = 1n;
    }
    const v227: bigint = 0n + 1n;
    const v228: bigint = 0n + 1n;
    const v229: boolean = v227 === v228;
    let v230: bigint;
    if (v229) {
        v230 = 0n;
    } else {
        v230 = 1n;
    }
    const v231: bigint = 0n + 1n;
    const v232: bigint = v231 + 1n;
    const v233: bigint = v232 + 1n;
    const v234: bigint = v233 + 1n;
    const v235: bigint = v234 + 1n;
    const v236: bigint = 0n + 1n;
    const v237: bigint = v236 + 1n;
    const v238: bigint = v237 + 1n;
    const v239: bigint = v238 + 1n;
    const v240: bigint = v239 + 1n;
    const v241: boolean = v235 === v240;
    let v242: bigint;
    if (v241) {
        v242 = 0n;
    } else {
        v242 = 1n;
    }
    const v245: bigint = BigInt.asIntN(64, v230 + v242);
    const v248: bigint = BigInt.asIntN(64, v226 + v245);
    const v249: bigint = BigInt.asIntN(64, v216 + v248);
    const v250: boolean = v249 === 0n;
    if (v250) {
    } else {
        throw new Error("typed-FX-statement-three-writer-raw-CAS-runtime-mismatch");
    }
    const v251: bigint = 0n + 1n;
    const v252: bigint = v251 + 1n;
    const v253: bigint = v252 + 1n;
    const v254: bigint = v253 + 1n;
    const v255: bigint = 0n + 1n;
    const v256: bigint = v255 + 1n;
    const v257: bigint = v256 + 1n;
    const v258: bigint = v257 + 1n;
    const v259: boolean = v254 === v258;
    let v260: bigint;
    if (v259) {
        v260 = 0n;
    } else {
        v260 = 1n;
    }
    const v261: bigint = 0n + 1n;
    const v262: bigint = 0n + 1n;
    const v263: boolean = v261 === v262;
    let v264: bigint;
    if (v263) {
        v264 = 0n;
    } else {
        v264 = 1n;
    }
    const v265: bigint = 0n + 1n;
    const v266: bigint = v265 + 1n;
    const v267: bigint = v266 + 1n;
    const v268: bigint = v267 + 1n;
    const v269: bigint = v268 + 1n;
    const v270: bigint = 0n + 1n;
    const v271: bigint = v270 + 1n;
    const v272: bigint = v271 + 1n;
    const v273: bigint = v272 + 1n;
    const v274: bigint = v273 + 1n;
    const v275: boolean = v269 === v274;
    let v276: bigint;
    if (v275) {
        v276 = 0n;
    } else {
        v276 = 1n;
    }
    const v279: bigint = BigInt.asIntN(64, v264 + v276);
    const v282: bigint = BigInt.asIntN(64, v260 + v279);
    const v283: bigint = 0n + 1n;
    const v284: bigint = v283 + 1n;
    const v285: bigint = v284 + 1n;
    const v286: bigint = v285 + 1n;
    const v287: bigint = 0n + 1n;
    const v288: bigint = v287 + 1n;
    const v289: bigint = v288 + 1n;
    const v290: bigint = v289 + 1n;
    const v291: boolean = v286 === v290;
    let v292: bigint;
    if (v291) {
        v292 = 0n;
    } else {
        v292 = 1n;
    }
    const v293: bigint = 0n + 1n;
    const v294: bigint = 0n + 1n;
    const v295: boolean = v293 === v294;
    let v296: bigint;
    if (v295) {
        v296 = 0n;
    } else {
        v296 = 1n;
    }
    const v297: bigint = 0n + 1n;
    const v298: bigint = v297 + 1n;
    const v299: bigint = v298 + 1n;
    const v300: bigint = v299 + 1n;
    const v301: bigint = v300 + 1n;
    const v302: bigint = 0n + 1n;
    const v303: bigint = v302 + 1n;
    const v304: bigint = v303 + 1n;
    const v305: bigint = v304 + 1n;
    const v306: bigint = v305 + 1n;
    const v307: boolean = v301 === v306;
    let v308: bigint;
    if (v307) {
        v308 = 0n;
    } else {
        v308 = 1n;
    }
    const v311: bigint = BigInt.asIntN(64, v296 + v308);
    const v314: bigint = BigInt.asIntN(64, v292 + v311);
    const v315: bigint = BigInt.asIntN(64, v282 + v314);
    const v316: bigint = 0n + 1n;
    const v317: bigint = v316 + 1n;
    const v318: bigint = v317 + 1n;
    const v319: bigint = v318 + 1n;
    const v320: bigint = 0n + 1n;
    const v321: bigint = v320 + 1n;
    const v322: bigint = v321 + 1n;
    const v323: bigint = v322 + 1n;
    const v324: boolean = v319 === v323;
    let v325: bigint;
    if (v324) {
        v325 = 0n;
    } else {
        v325 = 1n;
    }
    const v326: bigint = 0n + 1n;
    const v327: bigint = 0n + 1n;
    const v328: boolean = v326 === v327;
    let v329: bigint;
    if (v328) {
        v329 = 0n;
    } else {
        v329 = 1n;
    }
    const v330: bigint = 0n + 1n;
    const v331: bigint = v330 + 1n;
    const v332: bigint = v331 + 1n;
    const v333: bigint = v332 + 1n;
    const v334: bigint = v333 + 1n;
    const v335: bigint = 0n + 1n;
    const v336: bigint = v335 + 1n;
    const v337: bigint = v336 + 1n;
    const v338: bigint = v337 + 1n;
    const v339: bigint = v338 + 1n;
    const v340: boolean = v334 === v339;
    let v341: bigint;
    if (v340) {
        v341 = 0n;
    } else {
        v341 = 1n;
    }
    const v344: bigint = BigInt.asIntN(64, v329 + v341);
    const v347: bigint = BigInt.asIntN(64, v325 + v344);
    const v348: bigint = 0n + 1n;
    const v349: bigint = v348 + 1n;
    const v350: bigint = v349 + 1n;
    const v351: bigint = v350 + 1n;
    const v352: bigint = 0n + 1n;
    const v353: bigint = v352 + 1n;
    const v354: bigint = v353 + 1n;
    const v355: bigint = v354 + 1n;
    const v356: boolean = v351 === v355;
    let v357: bigint;
    if (v356) {
        v357 = 0n;
    } else {
        v357 = 1n;
    }
    const v358: bigint = 0n + 1n;
    const v359: bigint = 0n + 1n;
    const v360: boolean = v358 === v359;
    let v361: bigint;
    if (v360) {
        v361 = 0n;
    } else {
        v361 = 1n;
    }
    const v362: bigint = 0n + 1n;
    const v363: bigint = v362 + 1n;
    const v364: bigint = v363 + 1n;
    const v365: bigint = v364 + 1n;
    const v366: bigint = v365 + 1n;
    const v367: bigint = 0n + 1n;
    const v368: bigint = v367 + 1n;
    const v369: bigint = v368 + 1n;
    const v370: bigint = v369 + 1n;
    const v371: bigint = v370 + 1n;
    const v372: boolean = v366 === v371;
    let v373: bigint;
    if (v372) {
        v373 = 0n;
    } else {
        v373 = 1n;
    }
    const v376: bigint = BigInt.asIntN(64, v361 + v373);
    const v379: bigint = BigInt.asIntN(64, v357 + v376);
    const v380: bigint = BigInt.asIntN(64, v347 + v379);
    const v381: bigint = BigInt.asIntN(64, v315 + v380);
    const v382: boolean = v381 === 0n;
    if (v382) {
    } else {
        throw new Error("typed-FX-statement-recursive-writer-raw-CAS-runtime-mismatch");
    }
    const v383: bigint = 0n + 1n;
    const v384: bigint = v383 + 1n;
    const v385: bigint = v384 + 1n;
    const v386: bigint = v385 + 1n;
    const v387: bigint = 0n + 1n;
    const v388: bigint = v387 + 1n;
    const v389: bigint = v388 + 1n;
    const v390: bigint = v389 + 1n;
    const v391: boolean = v386 === v390;
    let v392: bigint;
    if (v391) {
        v392 = 0n;
    } else {
        v392 = 1n;
    }
    const v393: bigint = 0n + 1n;
    const v394: bigint = 0n + 1n;
    const v395: boolean = v393 === v394;
    let v396: bigint;
    if (v395) {
        v396 = 0n;
    } else {
        v396 = 1n;
    }
    const v397: bigint = 0n + 1n;
    const v398: bigint = v397 + 1n;
    const v399: bigint = v398 + 1n;
    const v400: bigint = v399 + 1n;
    const v401: bigint = v400 + 1n;
    const v402: bigint = 0n + 1n;
    const v403: bigint = v402 + 1n;
    const v404: bigint = v403 + 1n;
    const v405: bigint = v404 + 1n;
    const v406: bigint = v405 + 1n;
    const v407: boolean = v401 === v406;
    let v408: bigint;
    if (v407) {
        v408 = 0n;
    } else {
        v408 = 1n;
    }
    const v411: bigint = BigInt.asIntN(64, v396 + v408);
    const v414: bigint = BigInt.asIntN(64, v392 + v411);
    const v415: bigint = 0n + 1n;
    const v416: bigint = v415 + 1n;
    const v417: bigint = v416 + 1n;
    const v418: bigint = v417 + 1n;
    const v419: bigint = 0n + 1n;
    const v420: bigint = v419 + 1n;
    const v421: bigint = v420 + 1n;
    const v422: bigint = v421 + 1n;
    const v423: boolean = v418 === v422;
    let v424: bigint;
    if (v423) {
        v424 = 0n;
    } else {
        v424 = 1n;
    }
    const v425: bigint = 0n + 1n;
    const v426: bigint = 0n + 1n;
    const v427: boolean = v425 === v426;
    let v428: bigint;
    if (v427) {
        v428 = 0n;
    } else {
        v428 = 1n;
    }
    const v429: bigint = 0n + 1n;
    const v430: bigint = v429 + 1n;
    const v431: bigint = v430 + 1n;
    const v432: bigint = v431 + 1n;
    const v433: bigint = v432 + 1n;
    const v434: bigint = 0n + 1n;
    const v435: bigint = v434 + 1n;
    const v436: bigint = v435 + 1n;
    const v437: bigint = v436 + 1n;
    const v438: bigint = v437 + 1n;
    const v439: boolean = v433 === v438;
    let v440: bigint;
    if (v439) {
        v440 = 0n;
    } else {
        v440 = 1n;
    }
    const v443: bigint = BigInt.asIntN(64, v428 + v440);
    const v446: bigint = BigInt.asIntN(64, v424 + v443);
    const v447: bigint = BigInt.asIntN(64, v414 + v446);
    const v448: bigint = 0n + 1n;
    const v449: bigint = v448 + 1n;
    const v450: bigint = v449 + 1n;
    const v451: bigint = v450 + 1n;
    const v452: bigint = 0n + 1n;
    const v453: bigint = v452 + 1n;
    const v454: bigint = v453 + 1n;
    const v455: bigint = v454 + 1n;
    const v456: boolean = v451 === v455;
    let v457: bigint;
    if (v456) {
        v457 = 0n;
    } else {
        v457 = 1n;
    }
    const v458: bigint = 0n + 1n;
    const v459: bigint = 0n + 1n;
    const v460: boolean = v458 === v459;
    let v461: bigint;
    if (v460) {
        v461 = 0n;
    } else {
        v461 = 1n;
    }
    const v462: bigint = 0n + 1n;
    const v463: bigint = v462 + 1n;
    const v464: bigint = v463 + 1n;
    const v465: bigint = v464 + 1n;
    const v466: bigint = v465 + 1n;
    const v467: bigint = 0n + 1n;
    const v468: bigint = v467 + 1n;
    const v469: bigint = v468 + 1n;
    const v470: bigint = v469 + 1n;
    const v471: bigint = v470 + 1n;
    const v472: boolean = v466 === v471;
    let v473: bigint;
    if (v472) {
        v473 = 0n;
    } else {
        v473 = 1n;
    }
    const v476: bigint = BigInt.asIntN(64, v461 + v473);
    const v479: bigint = BigInt.asIntN(64, v457 + v476);
    const v480: bigint = 0n + 1n;
    const v481: bigint = v480 + 1n;
    const v482: bigint = v481 + 1n;
    const v483: bigint = v482 + 1n;
    const v484: bigint = 0n + 1n;
    const v485: bigint = v484 + 1n;
    const v486: bigint = v485 + 1n;
    const v487: bigint = v486 + 1n;
    const v488: boolean = v483 === v487;
    let v489: bigint;
    if (v488) {
        v489 = 0n;
    } else {
        v489 = 1n;
    }
    const v490: bigint = 0n + 1n;
    const v491: bigint = 0n + 1n;
    const v492: boolean = v490 === v491;
    let v493: bigint;
    if (v492) {
        v493 = 0n;
    } else {
        v493 = 1n;
    }
    const v494: bigint = 0n + 1n;
    const v495: bigint = v494 + 1n;
    const v496: bigint = v495 + 1n;
    const v497: bigint = v496 + 1n;
    const v498: bigint = v497 + 1n;
    const v499: bigint = 0n + 1n;
    const v500: bigint = v499 + 1n;
    const v501: bigint = v500 + 1n;
    const v502: bigint = v501 + 1n;
    const v503: bigint = v502 + 1n;
    const v504: boolean = v498 === v503;
    let v505: bigint;
    if (v504) {
        v505 = 0n;
    } else {
        v505 = 1n;
    }
    const v508: bigint = BigInt.asIntN(64, v493 + v505);
    const v511: bigint = BigInt.asIntN(64, v489 + v508);
    const v512: bigint = BigInt.asIntN(64, v479 + v511);
    const v513: bigint = BigInt.asIntN(64, v447 + v512);
    const v514: bigint = 0n + 1n;
    const v515: bigint = v514 + 1n;
    const v516: bigint = v515 + 1n;
    const v517: bigint = v516 + 1n;
    const v518: bigint = 0n + 1n;
    const v519: bigint = v518 + 1n;
    const v520: bigint = v519 + 1n;
    const v521: bigint = v520 + 1n;
    const v522: boolean = v517 === v521;
    let v523: bigint;
    if (v522) {
        v523 = 0n;
    } else {
        v523 = 1n;
    }
    const v524: bigint = 0n + 1n;
    const v525: bigint = 0n + 1n;
    const v526: boolean = v524 === v525;
    let v527: bigint;
    if (v526) {
        v527 = 0n;
    } else {
        v527 = 1n;
    }
    const v528: bigint = 0n + 1n;
    const v529: bigint = v528 + 1n;
    const v530: bigint = v529 + 1n;
    const v531: bigint = v530 + 1n;
    const v532: bigint = v531 + 1n;
    const v533: bigint = 0n + 1n;
    const v534: bigint = v533 + 1n;
    const v535: bigint = v534 + 1n;
    const v536: bigint = v535 + 1n;
    const v537: bigint = v536 + 1n;
    const v538: boolean = v532 === v537;
    let v539: bigint;
    if (v538) {
        v539 = 0n;
    } else {
        v539 = 1n;
    }
    const v540: bigint = BigInt.asIntN(64, v524 + v532);
    const v541: bigint = BigInt.asIntN(64, v525 + v537);
    const v542: bigint = BigInt.asIntN(64, v527 + v539);
    const v543: bigint = BigInt.asIntN(64, v517 + v540);
    const v544: bigint = BigInt.asIntN(64, v521 + v541);
    const v545: bigint = BigInt.asIntN(64, v523 + v542);
    const v546: bigint = BigInt.asIntN(64, v544 + v545);
    const v547: bigint = BigInt.asIntN(64, v543 + v546);
    const v548: bigint = BigInt.asIntN(64, 3n + v547);
    const v549: bigint = 0n + 1n;
    const v550: bigint = v549 + 1n;
    const v551: bigint = v550 + 1n;
    const v552: bigint = v551 + 1n;
    const v553: bigint = 0n + 1n;
    const v554: bigint = v553 + 1n;
    const v555: bigint = v554 + 1n;
    const v556: bigint = v555 + 1n;
    const v557: boolean = v552 === v556;
    let v558: bigint;
    if (v557) {
        v558 = 0n;
    } else {
        v558 = 1n;
    }
    const v559: bigint = 0n + 1n;
    const v560: bigint = 0n + 1n;
    const v561: boolean = v559 === v560;
    let v562: bigint;
    if (v561) {
        v562 = 0n;
    } else {
        v562 = 1n;
    }
    const v563: bigint = 0n + 1n;
    const v564: bigint = v563 + 1n;
    const v565: bigint = v564 + 1n;
    const v566: bigint = v565 + 1n;
    const v567: bigint = v566 + 1n;
    const v568: bigint = 0n + 1n;
    const v569: bigint = v568 + 1n;
    const v570: bigint = v569 + 1n;
    const v571: bigint = v570 + 1n;
    const v572: bigint = v571 + 1n;
    const v573: boolean = v567 === v572;
    let v574: bigint;
    if (v573) {
        v574 = 0n;
    } else {
        v574 = 1n;
    }
    const v575: bigint = BigInt.asIntN(64, v559 + v567);
    const v576: bigint = BigInt.asIntN(64, v560 + v572);
    const v577: bigint = BigInt.asIntN(64, v562 + v574);
    const v578: bigint = BigInt.asIntN(64, v552 + v575);
    const v579: bigint = BigInt.asIntN(64, v556 + v576);
    const v580: bigint = BigInt.asIntN(64, v558 + v577);
    const v581: bigint = BigInt.asIntN(64, v579 + v580);
    const v582: bigint = BigInt.asIntN(64, v578 + v581);
    const v583: bigint = BigInt.asIntN(64, 3n + v582);
    const v584: boolean = v548 === v583;
    let v621: US0;
    if (v584) {
        const v585: bigint = 0n + 1n;
        const v586: bigint = v585 + 1n;
        const v587: bigint = v586 + 1n;
        const v588: bigint = v587 + 1n;
        const v589: bigint = 0n + 1n;
        const v590: bigint = v589 + 1n;
        const v591: bigint = v590 + 1n;
        const v592: bigint = v591 + 1n;
        const v593: boolean = v588 === v592;
        let v594: bigint;
        if (v593) {
            v594 = 0n;
        } else {
            v594 = 1n;
        }
        const v595: bigint = 0n + 1n;
        const v596: bigint = 0n + 1n;
        const v597: boolean = v595 === v596;
        let v598: bigint;
        if (v597) {
            v598 = 0n;
        } else {
            v598 = 1n;
        }
        const v599: bigint = 0n + 1n;
        const v600: bigint = v599 + 1n;
        const v601: bigint = v600 + 1n;
        const v602: bigint = v601 + 1n;
        const v603: bigint = v602 + 1n;
        const v604: bigint = 0n + 1n;
        const v605: bigint = v604 + 1n;
        const v606: bigint = v605 + 1n;
        const v607: bigint = v606 + 1n;
        const v608: bigint = v607 + 1n;
        const v609: boolean = v603 === v608;
        let v610: bigint;
        if (v609) {
            v610 = 0n;
        } else {
            v610 = 1n;
        }
        const v611: bigint = BigInt.asIntN(64, v595 + v603);
        const v612: bigint = BigInt.asIntN(64, v596 + v608);
        const v613: bigint = BigInt.asIntN(64, v598 + v610);
        const v614: bigint = BigInt.asIntN(64, v588 + v611);
        const v615: bigint = BigInt.asIntN(64, v592 + v612);
        const v616: bigint = BigInt.asIntN(64, v594 + v613);
        const v617: string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v621 = US0_TypedFxHashedStatementChecksumValidationAccepted(1n, 3n, v614, v615, v616, v617);
    } else {
        const v619: string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v621 = US0_TypedFxHashedStatementChecksumValidationRejected(v548, v583, v619);
    }
    let v640: bigint;
    let v641: bigint;
    let v644: bigint;
    let v645: bigint;
    let v646: bigint;
    let v647: bigint;
    let v648: bigint;
    switch (v621.tag) {
        case 0: {
            const v625: bigint = v621.f0;
            const v626: bigint = v621.f1;
            const v627: bigint = v621.f2;
            const v628: bigint = v621.f3;
            const v629: bigint = v621.f4;
            const v630: string = v621.f5;
            v640 = 1n;
            v641 = 0n;
            v644 = v625;
            v645 = v626;
            v646 = v627;
            v647 = v628;
            v648 = v629;
            break;
        }
        case 1: {
            const v622: bigint = v621.f0;
            const v623: bigint = v621.f1;
            const v624: string = v621.f2;
            v640 = 0n;
            v641 = 1n;
            v644 = 0n;
            v645 = 0n;
            v646 = 0n;
            v647 = 0n;
            v648 = 0n;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v649: boolean = v513 === 0n;
    const v650: boolean = v548 === 23n;
    const v651: boolean = v640 === 1n;
    const v652: boolean = v641 === 0n;
    const v653: boolean = v644 === 1n;
    const v654: boolean = v645 === 3n;
    const v655: boolean = v646 === 10n;
    const v656: boolean = v647 === 10n;
    const v657: boolean = v648 === 0n;
    const v658: boolean = v649 && v650;
    const v659: boolean = v658 && v651;
    const v660: boolean = v659 && v652;
    const v661: boolean = v660 && v653;
    const v662: boolean = v661 && v654;
    const v663: boolean = v662 && v655;
    const v664: boolean = v663 && v656;
    const v665: boolean = v664 && v657;
    if (v665) {
    } else {
        throw new Error("typed-FX-statement-recursive-writer-checksummed-restart-runtime-mismatch");
    }
    const v666: bigint = 0n + 1n;
    const v667: bigint = v666 + 1n;
    const v668: bigint = v667 + 1n;
    const v669: bigint = v668 + 1n;
    const v670: bigint = 0n + 1n;
    const v671: bigint = v670 + 1n;
    const v672: bigint = v671 + 1n;
    const v673: bigint = v672 + 1n;
    const v674: boolean = v669 === v673;
    let v675: bigint;
    if (v674) {
        v675 = 0n;
    } else {
        v675 = 1n;
    }
    const v676: bigint = 0n + 1n;
    const v677: bigint = 0n + 1n;
    const v678: boolean = v676 === v677;
    let v679: bigint;
    if (v678) {
        v679 = 0n;
    } else {
        v679 = 1n;
    }
    const v680: bigint = 0n + 1n;
    const v681: bigint = v680 + 1n;
    const v682: bigint = v681 + 1n;
    const v683: bigint = v682 + 1n;
    const v684: bigint = v683 + 1n;
    const v685: bigint = 0n + 1n;
    const v686: bigint = v685 + 1n;
    const v687: bigint = v686 + 1n;
    const v688: bigint = v687 + 1n;
    const v689: bigint = v688 + 1n;
    const v690: boolean = v684 === v689;
    let v691: bigint;
    if (v690) {
        v691 = 0n;
    } else {
        v691 = 1n;
    }
    const v694: bigint = BigInt.asIntN(64, v679 + v691);
    const v697: bigint = BigInt.asIntN(64, v675 + v694);
    const v698: bigint = 0n + 1n;
    const v699: bigint = v698 + 1n;
    const v700: bigint = v699 + 1n;
    const v701: bigint = v700 + 1n;
    const v702: bigint = 0n + 1n;
    const v703: bigint = v702 + 1n;
    const v704: bigint = v703 + 1n;
    const v705: bigint = v704 + 1n;
    const v706: boolean = v701 === v705;
    let v707: bigint;
    if (v706) {
        v707 = 0n;
    } else {
        v707 = 1n;
    }
    const v708: bigint = 0n + 1n;
    const v709: bigint = 0n + 1n;
    const v710: boolean = v708 === v709;
    let v711: bigint;
    if (v710) {
        v711 = 0n;
    } else {
        v711 = 1n;
    }
    const v712: bigint = 0n + 1n;
    const v713: bigint = v712 + 1n;
    const v714: bigint = v713 + 1n;
    const v715: bigint = v714 + 1n;
    const v716: bigint = v715 + 1n;
    const v717: bigint = 0n + 1n;
    const v718: bigint = v717 + 1n;
    const v719: bigint = v718 + 1n;
    const v720: bigint = v719 + 1n;
    const v721: bigint = v720 + 1n;
    const v722: boolean = v716 === v721;
    let v723: bigint;
    if (v722) {
        v723 = 0n;
    } else {
        v723 = 1n;
    }
    const v726: bigint = BigInt.asIntN(64, v711 + v723);
    const v729: bigint = BigInt.asIntN(64, v707 + v726);
    const v730: bigint = BigInt.asIntN(64, v697 + v729);
    const v731: bigint = 0n + 1n;
    const v732: bigint = v731 + 1n;
    const v733: bigint = v732 + 1n;
    const v734: bigint = v733 + 1n;
    const v735: bigint = 0n + 1n;
    const v736: bigint = v735 + 1n;
    const v737: bigint = v736 + 1n;
    const v738: bigint = v737 + 1n;
    const v739: boolean = v734 === v738;
    let v740: bigint;
    if (v739) {
        v740 = 0n;
    } else {
        v740 = 1n;
    }
    const v741: bigint = 0n + 1n;
    const v742: bigint = 0n + 1n;
    const v743: boolean = v741 === v742;
    let v744: bigint;
    if (v743) {
        v744 = 0n;
    } else {
        v744 = 1n;
    }
    const v745: bigint = 0n + 1n;
    const v746: bigint = v745 + 1n;
    const v747: bigint = v746 + 1n;
    const v748: bigint = v747 + 1n;
    const v749: bigint = v748 + 1n;
    const v750: bigint = 0n + 1n;
    const v751: bigint = v750 + 1n;
    const v752: bigint = v751 + 1n;
    const v753: bigint = v752 + 1n;
    const v754: bigint = v753 + 1n;
    const v755: boolean = v749 === v754;
    let v756: bigint;
    if (v755) {
        v756 = 0n;
    } else {
        v756 = 1n;
    }
    const v759: bigint = BigInt.asIntN(64, v744 + v756);
    const v762: bigint = BigInt.asIntN(64, v740 + v759);
    const v763: bigint = 0n + 1n;
    const v764: bigint = v763 + 1n;
    const v765: bigint = v764 + 1n;
    const v766: bigint = v765 + 1n;
    const v767: bigint = 0n + 1n;
    const v768: bigint = v767 + 1n;
    const v769: bigint = v768 + 1n;
    const v770: bigint = v769 + 1n;
    const v771: boolean = v766 === v770;
    let v772: bigint;
    if (v771) {
        v772 = 0n;
    } else {
        v772 = 1n;
    }
    const v773: bigint = 0n + 1n;
    const v774: bigint = 0n + 1n;
    const v775: boolean = v773 === v774;
    let v776: bigint;
    if (v775) {
        v776 = 0n;
    } else {
        v776 = 1n;
    }
    const v777: bigint = 0n + 1n;
    const v778: bigint = v777 + 1n;
    const v779: bigint = v778 + 1n;
    const v780: bigint = v779 + 1n;
    const v781: bigint = v780 + 1n;
    const v782: bigint = 0n + 1n;
    const v783: bigint = v782 + 1n;
    const v784: bigint = v783 + 1n;
    const v785: bigint = v784 + 1n;
    const v786: bigint = v785 + 1n;
    const v787: boolean = v781 === v786;
    let v788: bigint;
    if (v787) {
        v788 = 0n;
    } else {
        v788 = 1n;
    }
    const v791: bigint = BigInt.asIntN(64, v776 + v788);
    const v794: bigint = BigInt.asIntN(64, v772 + v791);
    const v795: bigint = BigInt.asIntN(64, v762 + v794);
    const v796: bigint = BigInt.asIntN(64, v730 + v795);
    const v797: bigint = 0n + 1n;
    const v798: bigint = v797 + 1n;
    const v799: bigint = v798 + 1n;
    const v800: bigint = v799 + 1n;
    const v801: bigint = 0n + 1n;
    const v802: bigint = v801 + 1n;
    const v803: bigint = v802 + 1n;
    const v804: bigint = v803 + 1n;
    const v805: boolean = v800 === v804;
    let v806: bigint;
    if (v805) {
        v806 = 0n;
    } else {
        v806 = 1n;
    }
    const v807: bigint = 0n + 1n;
    const v808: bigint = 0n + 1n;
    const v809: boolean = v807 === v808;
    let v810: bigint;
    if (v809) {
        v810 = 0n;
    } else {
        v810 = 1n;
    }
    const v811: bigint = 0n + 1n;
    const v812: bigint = v811 + 1n;
    const v813: bigint = v812 + 1n;
    const v814: bigint = v813 + 1n;
    const v815: bigint = v814 + 1n;
    const v816: bigint = 0n + 1n;
    const v817: bigint = v816 + 1n;
    const v818: bigint = v817 + 1n;
    const v819: bigint = v818 + 1n;
    const v820: bigint = v819 + 1n;
    const v821: boolean = v815 === v820;
    let v822: bigint;
    if (v821) {
        v822 = 0n;
    } else {
        v822 = 1n;
    }
    const v823: bigint = BigInt.asIntN(64, v807 + v815);
    const v824: bigint = BigInt.asIntN(64, v808 + v820);
    const v825: bigint = BigInt.asIntN(64, v810 + v822);
    const v826: bigint = BigInt.asIntN(64, v800 + v823);
    const v827: bigint = BigInt.asIntN(64, v804 + v824);
    const v828: bigint = BigInt.asIntN(64, v806 + v825);
    const v829: bigint = BigInt.asIntN(64, v827 + v828);
    const v830: bigint = BigInt.asIntN(64, v826 + v829);
    const v831: bigint = BigInt.asIntN(64, 3n + v830);
    const v832: bigint = 0n + 1n;
    const v833: bigint = v832 + 1n;
    const v834: bigint = v833 + 1n;
    const v835: bigint = v834 + 1n;
    const v836: bigint = 0n + 1n;
    const v837: bigint = v836 + 1n;
    const v838: bigint = v837 + 1n;
    const v839: bigint = v838 + 1n;
    const v840: boolean = v835 === v839;
    let v841: bigint;
    if (v840) {
        v841 = 0n;
    } else {
        v841 = 1n;
    }
    const v842: bigint = 0n + 1n;
    const v843: bigint = 0n + 1n;
    const v844: boolean = v842 === v843;
    let v845: bigint;
    if (v844) {
        v845 = 0n;
    } else {
        v845 = 1n;
    }
    const v846: bigint = 0n + 1n;
    const v847: bigint = v846 + 1n;
    const v848: bigint = v847 + 1n;
    const v849: bigint = v848 + 1n;
    const v850: bigint = v849 + 1n;
    const v851: bigint = 0n + 1n;
    const v852: bigint = v851 + 1n;
    const v853: bigint = v852 + 1n;
    const v854: bigint = v853 + 1n;
    const v855: bigint = v854 + 1n;
    const v856: boolean = v850 === v855;
    let v857: bigint;
    if (v856) {
        v857 = 0n;
    } else {
        v857 = 1n;
    }
    const v858: bigint = BigInt.asIntN(64, v842 + v850);
    const v859: bigint = BigInt.asIntN(64, v843 + v855);
    const v860: bigint = BigInt.asIntN(64, v845 + v857);
    const v861: bigint = BigInt.asIntN(64, v835 + v858);
    const v862: bigint = BigInt.asIntN(64, v839 + v859);
    const v863: bigint = BigInt.asIntN(64, v841 + v860);
    const v864: bigint = BigInt.asIntN(64, v862 + v863);
    const v865: bigint = BigInt.asIntN(64, v861 + v864);
    const v866: bigint = BigInt.asIntN(64, 3n + v865);
    const v867: boolean = v831 === v866;
    let v904: US0;
    if (v867) {
        const v868: bigint = 0n + 1n;
        const v869: bigint = v868 + 1n;
        const v870: bigint = v869 + 1n;
        const v871: bigint = v870 + 1n;
        const v872: bigint = 0n + 1n;
        const v873: bigint = v872 + 1n;
        const v874: bigint = v873 + 1n;
        const v875: bigint = v874 + 1n;
        const v876: boolean = v871 === v875;
        let v877: bigint;
        if (v876) {
            v877 = 0n;
        } else {
            v877 = 1n;
        }
        const v878: bigint = 0n + 1n;
        const v879: bigint = 0n + 1n;
        const v880: boolean = v878 === v879;
        let v881: bigint;
        if (v880) {
            v881 = 0n;
        } else {
            v881 = 1n;
        }
        const v882: bigint = 0n + 1n;
        const v883: bigint = v882 + 1n;
        const v884: bigint = v883 + 1n;
        const v885: bigint = v884 + 1n;
        const v886: bigint = v885 + 1n;
        const v887: bigint = 0n + 1n;
        const v888: bigint = v887 + 1n;
        const v889: bigint = v888 + 1n;
        const v890: bigint = v889 + 1n;
        const v891: bigint = v890 + 1n;
        const v892: boolean = v886 === v891;
        let v893: bigint;
        if (v892) {
            v893 = 0n;
        } else {
            v893 = 1n;
        }
        const v894: bigint = BigInt.asIntN(64, v878 + v886);
        const v895: bigint = BigInt.asIntN(64, v879 + v891);
        const v896: bigint = BigInt.asIntN(64, v881 + v893);
        const v897: bigint = BigInt.asIntN(64, v871 + v894);
        const v898: bigint = BigInt.asIntN(64, v875 + v895);
        const v899: bigint = BigInt.asIntN(64, v877 + v896);
        const v900: string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v904 = US0_TypedFxHashedStatementChecksumValidationAccepted(1n, 3n, v897, v898, v899, v900);
    } else {
        const v902: string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v904 = US0_TypedFxHashedStatementChecksumValidationRejected(v831, v866, v902);
    }
    let v923: bigint;
    let v924: bigint;
    let v927: bigint;
    let v931: bigint;
    switch (v904.tag) {
        case 0: {
            const v908: bigint = v904.f0;
            const v909: bigint = v904.f1;
            const v910: bigint = v904.f2;
            const v911: bigint = v904.f3;
            const v912: bigint = v904.f4;
            const v913: string = v904.f5;
            v923 = 1n;
            v924 = 0n;
            v927 = v908;
            v931 = v912;
            break;
        }
        case 1: {
            const v905: bigint = v904.f0;
            const v906: bigint = v904.f1;
            const v907: string = v904.f2;
            v923 = 0n;
            v924 = 1n;
            v927 = 0n;
            v931 = 0n;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v932: bigint = 0n + 1n;
    const v933: bigint = v932 + 1n;
    const v934: bigint = v933 + 1n;
    const v935: bigint = v934 + 1n;
    const v936: bigint = 0n + 1n;
    const v937: bigint = v936 + 1n;
    const v938: bigint = v937 + 1n;
    const v939: bigint = v938 + 1n;
    const v940: boolean = v935 === v939;
    let v941: bigint;
    if (v940) {
        v941 = 0n;
    } else {
        v941 = 1n;
    }
    const v942: bigint = 0n + 1n;
    const v943: bigint = 0n + 1n;
    const v944: boolean = v942 === v943;
    let v945: bigint;
    if (v944) {
        v945 = 0n;
    } else {
        v945 = 1n;
    }
    const v946: bigint = 0n + 1n;
    const v947: bigint = v946 + 1n;
    const v948: bigint = v947 + 1n;
    const v949: bigint = v948 + 1n;
    const v950: bigint = v949 + 1n;
    const v951: bigint = 0n + 1n;
    const v952: bigint = v951 + 1n;
    const v953: bigint = v952 + 1n;
    const v954: bigint = v953 + 1n;
    const v955: bigint = v954 + 1n;
    const v956: boolean = v950 === v955;
    let v957: bigint;
    if (v956) {
        v957 = 0n;
    } else {
        v957 = 1n;
    }
    const v960: bigint = BigInt.asIntN(64, v945 + v957);
    const v963: bigint = BigInt.asIntN(64, v941 + v960);
    const v964: bigint = 0n + 1n;
    const v965: bigint = v964 + 1n;
    const v966: bigint = v965 + 1n;
    const v967: bigint = v966 + 1n;
    const v968: bigint = 0n + 1n;
    const v969: bigint = v968 + 1n;
    const v970: bigint = v969 + 1n;
    const v971: bigint = v970 + 1n;
    const v972: boolean = v967 === v971;
    let v973: bigint;
    if (v972) {
        v973 = 0n;
    } else {
        v973 = 1n;
    }
    const v974: bigint = 0n + 1n;
    const v975: bigint = 0n + 1n;
    const v976: boolean = v974 === v975;
    let v977: bigint;
    if (v976) {
        v977 = 0n;
    } else {
        v977 = 1n;
    }
    const v978: bigint = 0n + 1n;
    const v979: bigint = v978 + 1n;
    const v980: bigint = v979 + 1n;
    const v981: bigint = v980 + 1n;
    const v982: bigint = v981 + 1n;
    const v983: bigint = 0n + 1n;
    const v984: bigint = v983 + 1n;
    const v985: bigint = v984 + 1n;
    const v986: bigint = v985 + 1n;
    const v987: bigint = v986 + 1n;
    const v988: boolean = v982 === v987;
    let v989: bigint;
    if (v988) {
        v989 = 0n;
    } else {
        v989 = 1n;
    }
    const v992: bigint = BigInt.asIntN(64, v977 + v989);
    const v995: bigint = BigInt.asIntN(64, v973 + v992);
    const v996: bigint = BigInt.asIntN(64, v963 + v995);
    const v997: bigint = BigInt.asIntN(64, v931 + v924);
    const v998: bigint = BigInt.asIntN(64, v996 + v997);
    const v999: bigint = BigInt.asIntN(64, v796 + v998);
    const v1000: boolean = v927 === 1n;
    const v1001: boolean = v923 === 1n;
    const v1002: boolean = v999 === 0n;
    const v1003: boolean = v1000 && v1001;
    const v1004: boolean = v1003 && v1002;
    if (v1004) {
    } else {
        throw new Error("typed-FX-statement-recursive-writer-restart-invariant-runtime-mismatch");
    }
    const v1005: bigint = 0n + 1n;
    const v1006: bigint = v1005 + 1n;
    const v1007: bigint = v1006 + 1n;
    const v1008: bigint = v1007 + 1n;
    const v1009: bigint = 0n + 1n;
    const v1010: bigint = v1009 + 1n;
    const v1011: bigint = v1010 + 1n;
    const v1012: bigint = v1011 + 1n;
    const v1013: boolean = v1008 === v1012;
    let v1014: bigint;
    if (v1013) {
        v1014 = 0n;
    } else {
        v1014 = 1n;
    }
    const v1015: bigint = 0n + 1n;
    const v1016: bigint = 0n + 1n;
    const v1017: boolean = v1015 === v1016;
    let v1018: bigint;
    if (v1017) {
        v1018 = 0n;
    } else {
        v1018 = 1n;
    }
    const v1019: bigint = 0n + 1n;
    const v1020: bigint = v1019 + 1n;
    const v1021: bigint = v1020 + 1n;
    const v1022: bigint = v1021 + 1n;
    const v1023: bigint = v1022 + 1n;
    const v1024: bigint = 0n + 1n;
    const v1025: bigint = v1024 + 1n;
    const v1026: bigint = v1025 + 1n;
    const v1027: bigint = v1026 + 1n;
    const v1028: bigint = v1027 + 1n;
    const v1029: boolean = v1023 === v1028;
    let v1030: bigint;
    if (v1029) {
        v1030 = 0n;
    } else {
        v1030 = 1n;
    }
    const v1033: bigint = BigInt.asIntN(64, v1018 + v1030);
    const v1036: bigint = BigInt.asIntN(64, v1014 + v1033);
    const v1037: bigint = 0n + 1n;
    const v1038: bigint = v1037 + 1n;
    const v1039: bigint = v1038 + 1n;
    const v1040: bigint = v1039 + 1n;
    const v1041: bigint = 0n + 1n;
    const v1042: bigint = v1041 + 1n;
    const v1043: bigint = v1042 + 1n;
    const v1044: bigint = v1043 + 1n;
    const v1045: boolean = v1040 === v1044;
    let v1046: bigint;
    if (v1045) {
        v1046 = 0n;
    } else {
        v1046 = 1n;
    }
    const v1047: bigint = 0n + 1n;
    const v1048: bigint = 0n + 1n;
    const v1049: boolean = v1047 === v1048;
    let v1050: bigint;
    if (v1049) {
        v1050 = 0n;
    } else {
        v1050 = 1n;
    }
    const v1051: bigint = 0n + 1n;
    const v1052: bigint = v1051 + 1n;
    const v1053: bigint = v1052 + 1n;
    const v1054: bigint = v1053 + 1n;
    const v1055: bigint = v1054 + 1n;
    const v1056: bigint = 0n + 1n;
    const v1057: bigint = v1056 + 1n;
    const v1058: bigint = v1057 + 1n;
    const v1059: bigint = v1058 + 1n;
    const v1060: bigint = v1059 + 1n;
    const v1061: boolean = v1055 === v1060;
    let v1062: bigint;
    if (v1061) {
        v1062 = 0n;
    } else {
        v1062 = 1n;
    }
    const v1065: bigint = BigInt.asIntN(64, v1050 + v1062);
    const v1068: bigint = BigInt.asIntN(64, v1046 + v1065);
    const v1069: bigint = BigInt.asIntN(64, v1036 + v1068);
    const v1070: bigint = 0n + 1n;
    const v1071: bigint = v1070 + 1n;
    const v1072: bigint = v1071 + 1n;
    const v1073: bigint = v1072 + 1n;
    const v1074: bigint = 0n + 1n;
    const v1075: bigint = v1074 + 1n;
    const v1076: bigint = v1075 + 1n;
    const v1077: bigint = v1076 + 1n;
    const v1078: boolean = v1073 === v1077;
    let v1079: bigint;
    if (v1078) {
        v1079 = 0n;
    } else {
        v1079 = 1n;
    }
    const v1080: bigint = 0n + 1n;
    const v1081: bigint = 0n + 1n;
    const v1082: boolean = v1080 === v1081;
    let v1083: bigint;
    if (v1082) {
        v1083 = 0n;
    } else {
        v1083 = 1n;
    }
    const v1084: bigint = 0n + 1n;
    const v1085: bigint = v1084 + 1n;
    const v1086: bigint = v1085 + 1n;
    const v1087: bigint = v1086 + 1n;
    const v1088: bigint = v1087 + 1n;
    const v1089: bigint = 0n + 1n;
    const v1090: bigint = v1089 + 1n;
    const v1091: bigint = v1090 + 1n;
    const v1092: bigint = v1091 + 1n;
    const v1093: bigint = v1092 + 1n;
    const v1094: boolean = v1088 === v1093;
    let v1095: bigint;
    if (v1094) {
        v1095 = 0n;
    } else {
        v1095 = 1n;
    }
    const v1098: bigint = BigInt.asIntN(64, v1083 + v1095);
    const v1101: bigint = BigInt.asIntN(64, v1079 + v1098);
    const v1102: bigint = 0n + 1n;
    const v1103: bigint = v1102 + 1n;
    const v1104: bigint = v1103 + 1n;
    const v1105: bigint = v1104 + 1n;
    const v1106: bigint = 0n + 1n;
    const v1107: bigint = v1106 + 1n;
    const v1108: bigint = v1107 + 1n;
    const v1109: bigint = v1108 + 1n;
    const v1110: boolean = v1105 === v1109;
    let v1111: bigint;
    if (v1110) {
        v1111 = 0n;
    } else {
        v1111 = 1n;
    }
    const v1112: bigint = 0n + 1n;
    const v1113: bigint = 0n + 1n;
    const v1114: boolean = v1112 === v1113;
    let v1115: bigint;
    if (v1114) {
        v1115 = 0n;
    } else {
        v1115 = 1n;
    }
    const v1116: bigint = 0n + 1n;
    const v1117: bigint = v1116 + 1n;
    const v1118: bigint = v1117 + 1n;
    const v1119: bigint = v1118 + 1n;
    const v1120: bigint = v1119 + 1n;
    const v1121: bigint = 0n + 1n;
    const v1122: bigint = v1121 + 1n;
    const v1123: bigint = v1122 + 1n;
    const v1124: bigint = v1123 + 1n;
    const v1125: bigint = v1124 + 1n;
    const v1126: boolean = v1120 === v1125;
    let v1127: bigint;
    if (v1126) {
        v1127 = 0n;
    } else {
        v1127 = 1n;
    }
    const v1130: bigint = BigInt.asIntN(64, v1115 + v1127);
    const v1133: bigint = BigInt.asIntN(64, v1111 + v1130);
    const v1134: bigint = BigInt.asIntN(64, v1101 + v1133);
    const v1135: bigint = 0n + 1n;
    const v1136: bigint = v1135 + 1n;
    const v1137: bigint = v1136 + 1n;
    const v1138: bigint = v1137 + 1n;
    const v1139: bigint = 0n + 1n;
    const v1140: bigint = v1139 + 1n;
    const v1141: bigint = v1140 + 1n;
    const v1142: bigint = v1141 + 1n;
    const v1143: boolean = v1138 === v1142;
    let v1144: bigint;
    if (v1143) {
        v1144 = 0n;
    } else {
        v1144 = 1n;
    }
    const v1145: bigint = 0n + 1n;
    const v1146: bigint = 0n + 1n;
    const v1147: boolean = v1145 === v1146;
    let v1148: bigint;
    if (v1147) {
        v1148 = 0n;
    } else {
        v1148 = 1n;
    }
    const v1149: bigint = 0n + 1n;
    const v1150: bigint = v1149 + 1n;
    const v1151: bigint = v1150 + 1n;
    const v1152: bigint = v1151 + 1n;
    const v1153: bigint = v1152 + 1n;
    const v1154: bigint = 0n + 1n;
    const v1155: bigint = v1154 + 1n;
    const v1156: bigint = v1155 + 1n;
    const v1157: bigint = v1156 + 1n;
    const v1158: bigint = v1157 + 1n;
    const v1159: boolean = v1153 === v1158;
    let v1160: bigint;
    if (v1159) {
        v1160 = 0n;
    } else {
        v1160 = 1n;
    }
    const v1163: bigint = BigInt.asIntN(64, v1148 + v1160);
    const v1166: bigint = BigInt.asIntN(64, v1144 + v1163);
    const v1167: bigint = 0n + 1n;
    const v1168: bigint = v1167 + 1n;
    const v1169: bigint = v1168 + 1n;
    const v1170: bigint = v1169 + 1n;
    const v1171: bigint = 0n + 1n;
    const v1172: bigint = v1171 + 1n;
    const v1173: bigint = v1172 + 1n;
    const v1174: bigint = v1173 + 1n;
    const v1175: boolean = v1170 === v1174;
    let v1176: bigint;
    if (v1175) {
        v1176 = 0n;
    } else {
        v1176 = 1n;
    }
    const v1177: bigint = 0n + 1n;
    const v1178: bigint = 0n + 1n;
    const v1179: boolean = v1177 === v1178;
    let v1180: bigint;
    if (v1179) {
        v1180 = 0n;
    } else {
        v1180 = 1n;
    }
    const v1181: bigint = 0n + 1n;
    const v1182: bigint = v1181 + 1n;
    const v1183: bigint = v1182 + 1n;
    const v1184: bigint = v1183 + 1n;
    const v1185: bigint = v1184 + 1n;
    const v1186: bigint = 0n + 1n;
    const v1187: bigint = v1186 + 1n;
    const v1188: bigint = v1187 + 1n;
    const v1189: bigint = v1188 + 1n;
    const v1190: bigint = v1189 + 1n;
    const v1191: boolean = v1185 === v1190;
    let v1192: bigint;
    if (v1191) {
        v1192 = 0n;
    } else {
        v1192 = 1n;
    }
    const v1195: bigint = BigInt.asIntN(64, v1180 + v1192);
    const v1198: bigint = BigInt.asIntN(64, v1176 + v1195);
    const v1199: bigint = 0n + 1n;
    const v1200: bigint = v1199 + 1n;
    const v1201: bigint = v1200 + 1n;
    const v1202: bigint = v1201 + 1n;
    const v1203: bigint = 0n + 1n;
    const v1204: bigint = v1203 + 1n;
    const v1205: bigint = v1204 + 1n;
    const v1206: bigint = v1205 + 1n;
    const v1207: boolean = v1202 === v1206;
    let v1208: bigint;
    if (v1207) {
        v1208 = 0n;
    } else {
        v1208 = 1n;
    }
    const v1209: bigint = 0n + 1n;
    const v1210: bigint = 0n + 1n;
    const v1211: boolean = v1209 === v1210;
    let v1212: bigint;
    if (v1211) {
        v1212 = 0n;
    } else {
        v1212 = 1n;
    }
    const v1213: bigint = 0n + 1n;
    const v1214: bigint = v1213 + 1n;
    const v1215: bigint = v1214 + 1n;
    const v1216: bigint = v1215 + 1n;
    const v1217: bigint = v1216 + 1n;
    const v1218: bigint = 0n + 1n;
    const v1219: bigint = v1218 + 1n;
    const v1220: bigint = v1219 + 1n;
    const v1221: bigint = v1220 + 1n;
    const v1222: bigint = v1221 + 1n;
    const v1223: boolean = v1217 === v1222;
    let v1224: bigint;
    if (v1223) {
        v1224 = 0n;
    } else {
        v1224 = 1n;
    }
    const v1227: bigint = BigInt.asIntN(64, v1212 + v1224);
    const v1230: bigint = BigInt.asIntN(64, v1208 + v1227);
    const v1231: bigint = 0n + 1n;
    const v1232: bigint = v1231 + 1n;
    const v1233: bigint = v1232 + 1n;
    const v1234: bigint = v1233 + 1n;
    const v1235: bigint = 0n + 1n;
    const v1236: bigint = v1235 + 1n;
    const v1237: bigint = v1236 + 1n;
    const v1238: bigint = v1237 + 1n;
    const v1239: boolean = v1234 === v1238;
    let v1240: bigint;
    if (v1239) {
        v1240 = 0n;
    } else {
        v1240 = 1n;
    }
    const v1241: bigint = 0n + 1n;
    const v1242: bigint = 0n + 1n;
    const v1243: boolean = v1241 === v1242;
    let v1244: bigint;
    if (v1243) {
        v1244 = 0n;
    } else {
        v1244 = 1n;
    }
    const v1245: bigint = 0n + 1n;
    const v1246: bigint = v1245 + 1n;
    const v1247: bigint = v1246 + 1n;
    const v1248: bigint = v1247 + 1n;
    const v1249: bigint = v1248 + 1n;
    const v1250: bigint = 0n + 1n;
    const v1251: bigint = v1250 + 1n;
    const v1252: bigint = v1251 + 1n;
    const v1253: bigint = v1252 + 1n;
    const v1254: bigint = v1253 + 1n;
    const v1255: boolean = v1249 === v1254;
    let v1256: bigint;
    if (v1255) {
        v1256 = 0n;
    } else {
        v1256 = 1n;
    }
    const v1259: bigint = BigInt.asIntN(64, v1244 + v1256);
    const v1262: bigint = BigInt.asIntN(64, v1240 + v1259);
    const v1263: bigint = BigInt.asIntN(64, v1230 + v1262);
    const v1264: bigint = BigInt.asIntN(64, v1198 + v1263);
    const v1265: bigint = BigInt.asIntN(64, v1166 + v1264);
    const v1266: boolean = v1069 === 0n;
    const v1267: boolean = v1134 === v1069;
    const v1268: boolean = v1265 === 0n;
    const v1269: boolean = v1266 && v1267;
    const v1270: boolean = v1269 && v1268;
    if (v1270) {
    } else {
        throw new Error("typed-FX-statement-stale-writer-conflict-program-append-runtime-mismatch");
    }
    const v1271: bigint = 0n + 1n;
    const v1272: bigint = v1271 + 1n;
    const v1273: bigint = v1272 + 1n;
    const v1274: bigint = v1273 + 1n;
    const v1275: bigint = 0n + 1n;
    const v1276: bigint = v1275 + 1n;
    const v1277: bigint = v1276 + 1n;
    const v1278: bigint = v1277 + 1n;
    const v1279: boolean = v1274 === v1278;
    let v1280: bigint;
    if (v1279) {
        v1280 = 0n;
    } else {
        v1280 = 1n;
    }
    const v1281: bigint = 0n + 1n;
    const v1282: bigint = 0n + 1n;
    const v1283: boolean = v1281 === v1282;
    let v1284: bigint;
    if (v1283) {
        v1284 = 0n;
    } else {
        v1284 = 1n;
    }
    const v1285: bigint = 0n + 1n;
    const v1286: bigint = v1285 + 1n;
    const v1287: bigint = v1286 + 1n;
    const v1288: bigint = v1287 + 1n;
    const v1289: bigint = v1288 + 1n;
    const v1290: bigint = 0n + 1n;
    const v1291: bigint = v1290 + 1n;
    const v1292: bigint = v1291 + 1n;
    const v1293: bigint = v1292 + 1n;
    const v1294: bigint = v1293 + 1n;
    const v1295: boolean = v1289 === v1294;
    let v1296: bigint;
    if (v1295) {
        v1296 = 0n;
    } else {
        v1296 = 1n;
    }
    const v1299: bigint = BigInt.asIntN(64, v1284 + v1296);
    const v1302: bigint = BigInt.asIntN(64, v1280 + v1299);
    const v1303: bigint = 0n + 1n;
    const v1304: bigint = v1303 + 1n;
    const v1305: bigint = v1304 + 1n;
    const v1306: bigint = v1305 + 1n;
    const v1307: bigint = 0n + 1n;
    const v1308: bigint = v1307 + 1n;
    const v1309: bigint = v1308 + 1n;
    const v1310: bigint = v1309 + 1n;
    const v1311: boolean = v1306 === v1310;
    let v1312: bigint;
    if (v1311) {
        v1312 = 0n;
    } else {
        v1312 = 1n;
    }
    const v1313: bigint = 0n + 1n;
    const v1314: bigint = 0n + 1n;
    const v1315: boolean = v1313 === v1314;
    let v1316: bigint;
    if (v1315) {
        v1316 = 0n;
    } else {
        v1316 = 1n;
    }
    const v1317: bigint = 0n + 1n;
    const v1318: bigint = v1317 + 1n;
    const v1319: bigint = v1318 + 1n;
    const v1320: bigint = v1319 + 1n;
    const v1321: bigint = v1320 + 1n;
    const v1322: bigint = 0n + 1n;
    const v1323: bigint = v1322 + 1n;
    const v1324: bigint = v1323 + 1n;
    const v1325: bigint = v1324 + 1n;
    const v1326: bigint = v1325 + 1n;
    const v1327: boolean = v1321 === v1326;
    let v1328: bigint;
    if (v1327) {
        v1328 = 0n;
    } else {
        v1328 = 1n;
    }
    const v1331: bigint = BigInt.asIntN(64, v1316 + v1328);
    const v1334: bigint = BigInt.asIntN(64, v1312 + v1331);
    const v1335: bigint = 0n + 1n;
    const v1336: bigint = v1335 + 1n;
    const v1337: bigint = v1336 + 1n;
    const v1338: bigint = v1337 + 1n;
    const v1339: bigint = 0n + 1n;
    const v1340: bigint = v1339 + 1n;
    const v1341: bigint = v1340 + 1n;
    const v1342: bigint = v1341 + 1n;
    const v1343: boolean = v1338 === v1342;
    let v1344: bigint;
    if (v1343) {
        v1344 = 0n;
    } else {
        v1344 = 1n;
    }
    const v1345: bigint = 0n + 1n;
    const v1346: bigint = 0n + 1n;
    const v1347: boolean = v1345 === v1346;
    let v1348: bigint;
    if (v1347) {
        v1348 = 0n;
    } else {
        v1348 = 1n;
    }
    const v1349: bigint = 0n + 1n;
    const v1350: bigint = v1349 + 1n;
    const v1351: bigint = v1350 + 1n;
    const v1352: bigint = v1351 + 1n;
    const v1353: bigint = v1352 + 1n;
    const v1354: bigint = 0n + 1n;
    const v1355: bigint = v1354 + 1n;
    const v1356: bigint = v1355 + 1n;
    const v1357: bigint = v1356 + 1n;
    const v1358: bigint = v1357 + 1n;
    const v1359: boolean = v1353 === v1358;
    let v1360: bigint;
    if (v1359) {
        v1360 = 0n;
    } else {
        v1360 = 1n;
    }
    const v1363: bigint = BigInt.asIntN(64, v1348 + v1360);
    const v1366: bigint = BigInt.asIntN(64, v1344 + v1363);
    const v1367: bigint = 0n + 1n;
    const v1368: bigint = v1367 + 1n;
    const v1369: bigint = v1368 + 1n;
    const v1370: bigint = v1369 + 1n;
    const v1371: bigint = 0n + 1n;
    const v1372: bigint = v1371 + 1n;
    const v1373: bigint = v1372 + 1n;
    const v1374: bigint = v1373 + 1n;
    const v1375: boolean = v1370 === v1374;
    let v1376: bigint;
    if (v1375) {
        v1376 = 0n;
    } else {
        v1376 = 1n;
    }
    const v1377: bigint = 0n + 1n;
    const v1378: bigint = 0n + 1n;
    const v1379: boolean = v1377 === v1378;
    let v1380: bigint;
    if (v1379) {
        v1380 = 0n;
    } else {
        v1380 = 1n;
    }
    const v1381: bigint = 0n + 1n;
    const v1382: bigint = v1381 + 1n;
    const v1383: bigint = v1382 + 1n;
    const v1384: bigint = v1383 + 1n;
    const v1385: bigint = v1384 + 1n;
    const v1386: bigint = 0n + 1n;
    const v1387: bigint = v1386 + 1n;
    const v1388: bigint = v1387 + 1n;
    const v1389: bigint = v1388 + 1n;
    const v1390: bigint = v1389 + 1n;
    const v1391: boolean = v1385 === v1390;
    let v1392: bigint;
    if (v1391) {
        v1392 = 0n;
    } else {
        v1392 = 1n;
    }
    const v1395: bigint = BigInt.asIntN(64, v1380 + v1392);
    const v1398: bigint = BigInt.asIntN(64, v1376 + v1395);
    const v1399: bigint = 0n + 1n;
    const v1400: bigint = v1399 + 1n;
    const v1401: bigint = v1400 + 1n;
    const v1402: bigint = v1401 + 1n;
    const v1403: bigint = 0n + 1n;
    const v1404: bigint = v1403 + 1n;
    const v1405: bigint = v1404 + 1n;
    const v1406: bigint = v1405 + 1n;
    const v1407: boolean = v1402 === v1406;
    let v1408: bigint;
    if (v1407) {
        v1408 = 0n;
    } else {
        v1408 = 1n;
    }
    const v1409: bigint = 0n + 1n;
    const v1410: bigint = 0n + 1n;
    const v1411: boolean = v1409 === v1410;
    let v1412: bigint;
    if (v1411) {
        v1412 = 0n;
    } else {
        v1412 = 1n;
    }
    const v1413: bigint = 0n + 1n;
    const v1414: bigint = v1413 + 1n;
    const v1415: bigint = v1414 + 1n;
    const v1416: bigint = v1415 + 1n;
    const v1417: bigint = v1416 + 1n;
    const v1418: bigint = 0n + 1n;
    const v1419: bigint = v1418 + 1n;
    const v1420: bigint = v1419 + 1n;
    const v1421: bigint = v1420 + 1n;
    const v1422: bigint = v1421 + 1n;
    const v1423: boolean = v1417 === v1422;
    let v1424: bigint;
    if (v1423) {
        v1424 = 0n;
    } else {
        v1424 = 1n;
    }
    const v1427: bigint = BigInt.asIntN(64, v1412 + v1424);
    const v1430: bigint = BigInt.asIntN(64, v1408 + v1427);
    const v1431: bigint = 0n + 1n;
    const v1432: bigint = v1431 + 1n;
    const v1433: bigint = v1432 + 1n;
    const v1434: bigint = v1433 + 1n;
    const v1435: bigint = 0n + 1n;
    const v1436: bigint = v1435 + 1n;
    const v1437: bigint = v1436 + 1n;
    const v1438: bigint = v1437 + 1n;
    const v1439: boolean = v1434 === v1438;
    let v1440: bigint;
    if (v1439) {
        v1440 = 0n;
    } else {
        v1440 = 1n;
    }
    const v1441: bigint = 0n + 1n;
    const v1442: bigint = 0n + 1n;
    const v1443: boolean = v1441 === v1442;
    let v1444: bigint;
    if (v1443) {
        v1444 = 0n;
    } else {
        v1444 = 1n;
    }
    const v1445: bigint = 0n + 1n;
    const v1446: bigint = v1445 + 1n;
    const v1447: bigint = v1446 + 1n;
    const v1448: bigint = v1447 + 1n;
    const v1449: bigint = v1448 + 1n;
    const v1450: bigint = 0n + 1n;
    const v1451: bigint = v1450 + 1n;
    const v1452: bigint = v1451 + 1n;
    const v1453: bigint = v1452 + 1n;
    const v1454: bigint = v1453 + 1n;
    const v1455: boolean = v1449 === v1454;
    let v1456: bigint;
    if (v1455) {
        v1456 = 0n;
    } else {
        v1456 = 1n;
    }
    const v1459: bigint = BigInt.asIntN(64, v1444 + v1456);
    const v1462: bigint = BigInt.asIntN(64, v1440 + v1459);
    const v1463: bigint = BigInt.asIntN(64, v1430 + v1462);
    const v1464: bigint = BigInt.asIntN(64, v1398 + v1463);
    const v1465: bigint = BigInt.asIntN(64, v1366 + v1464);
    const v1466: bigint = BigInt.asIntN(64, v1334 + v1465);
    const v1467: bigint = BigInt.asIntN(64, v1302 + v1466);
    const v1468: bigint = 0n + 1n;
    const v1469: bigint = v1468 + 1n;
    const v1470: bigint = v1469 + 1n;
    const v1471: bigint = v1470 + 1n;
    const v1472: bigint = 0n + 1n;
    const v1473: bigint = v1472 + 1n;
    const v1474: bigint = v1473 + 1n;
    const v1475: bigint = v1474 + 1n;
    const v1476: boolean = v1471 === v1475;
    let v1477: bigint;
    if (v1476) {
        v1477 = 0n;
    } else {
        v1477 = 1n;
    }
    const v1478: bigint = 0n + 1n;
    const v1479: bigint = 0n + 1n;
    const v1480: boolean = v1478 === v1479;
    let v1481: bigint;
    if (v1480) {
        v1481 = 0n;
    } else {
        v1481 = 1n;
    }
    const v1482: bigint = 0n + 1n;
    const v1483: bigint = v1482 + 1n;
    const v1484: bigint = v1483 + 1n;
    const v1485: bigint = v1484 + 1n;
    const v1486: bigint = v1485 + 1n;
    const v1487: bigint = 0n + 1n;
    const v1488: bigint = v1487 + 1n;
    const v1489: bigint = v1488 + 1n;
    const v1490: bigint = v1489 + 1n;
    const v1491: bigint = v1490 + 1n;
    const v1492: boolean = v1486 === v1491;
    let v1493: bigint;
    if (v1492) {
        v1493 = 0n;
    } else {
        v1493 = 1n;
    }
    const v1496: bigint = BigInt.asIntN(64, v1481 + v1493);
    const v1499: bigint = BigInt.asIntN(64, v1477 + v1496);
    const v1500: bigint = 0n + 1n;
    const v1501: bigint = v1500 + 1n;
    const v1502: bigint = v1501 + 1n;
    const v1503: bigint = v1502 + 1n;
    const v1504: bigint = 0n + 1n;
    const v1505: bigint = v1504 + 1n;
    const v1506: bigint = v1505 + 1n;
    const v1507: bigint = v1506 + 1n;
    const v1508: boolean = v1503 === v1507;
    let v1509: bigint;
    if (v1508) {
        v1509 = 0n;
    } else {
        v1509 = 1n;
    }
    const v1510: bigint = 0n + 1n;
    const v1511: bigint = 0n + 1n;
    const v1512: boolean = v1510 === v1511;
    let v1513: bigint;
    if (v1512) {
        v1513 = 0n;
    } else {
        v1513 = 1n;
    }
    const v1514: bigint = 0n + 1n;
    const v1515: bigint = v1514 + 1n;
    const v1516: bigint = v1515 + 1n;
    const v1517: bigint = v1516 + 1n;
    const v1518: bigint = v1517 + 1n;
    const v1519: bigint = 0n + 1n;
    const v1520: bigint = v1519 + 1n;
    const v1521: bigint = v1520 + 1n;
    const v1522: bigint = v1521 + 1n;
    const v1523: bigint = v1522 + 1n;
    const v1524: boolean = v1518 === v1523;
    let v1525: bigint;
    if (v1524) {
        v1525 = 0n;
    } else {
        v1525 = 1n;
    }
    const v1528: bigint = BigInt.asIntN(64, v1513 + v1525);
    const v1531: bigint = BigInt.asIntN(64, v1509 + v1528);
    const v1532: bigint = 0n + 1n;
    const v1533: bigint = v1532 + 1n;
    const v1534: bigint = v1533 + 1n;
    const v1535: bigint = v1534 + 1n;
    const v1536: bigint = 0n + 1n;
    const v1537: bigint = v1536 + 1n;
    const v1538: bigint = v1537 + 1n;
    const v1539: bigint = v1538 + 1n;
    const v1540: boolean = v1535 === v1539;
    let v1541: bigint;
    if (v1540) {
        v1541 = 0n;
    } else {
        v1541 = 1n;
    }
    const v1542: bigint = 0n + 1n;
    const v1543: bigint = 0n + 1n;
    const v1544: boolean = v1542 === v1543;
    let v1545: bigint;
    if (v1544) {
        v1545 = 0n;
    } else {
        v1545 = 1n;
    }
    const v1546: bigint = 0n + 1n;
    const v1547: bigint = v1546 + 1n;
    const v1548: bigint = v1547 + 1n;
    const v1549: bigint = v1548 + 1n;
    const v1550: bigint = v1549 + 1n;
    const v1551: bigint = 0n + 1n;
    const v1552: bigint = v1551 + 1n;
    const v1553: bigint = v1552 + 1n;
    const v1554: bigint = v1553 + 1n;
    const v1555: bigint = v1554 + 1n;
    const v1556: boolean = v1550 === v1555;
    let v1557: bigint;
    if (v1556) {
        v1557 = 0n;
    } else {
        v1557 = 1n;
    }
    const v1560: bigint = BigInt.asIntN(64, v1545 + v1557);
    const v1563: bigint = BigInt.asIntN(64, v1541 + v1560);
    const v1564: bigint = 0n + 1n;
    const v1565: bigint = v1564 + 1n;
    const v1566: bigint = v1565 + 1n;
    const v1567: bigint = v1566 + 1n;
    const v1568: bigint = 0n + 1n;
    const v1569: bigint = v1568 + 1n;
    const v1570: bigint = v1569 + 1n;
    const v1571: bigint = v1570 + 1n;
    const v1572: boolean = v1567 === v1571;
    let v1573: bigint;
    if (v1572) {
        v1573 = 0n;
    } else {
        v1573 = 1n;
    }
    const v1574: bigint = 0n + 1n;
    const v1575: bigint = 0n + 1n;
    const v1576: boolean = v1574 === v1575;
    let v1577: bigint;
    if (v1576) {
        v1577 = 0n;
    } else {
        v1577 = 1n;
    }
    const v1578: bigint = 0n + 1n;
    const v1579: bigint = v1578 + 1n;
    const v1580: bigint = v1579 + 1n;
    const v1581: bigint = v1580 + 1n;
    const v1582: bigint = v1581 + 1n;
    const v1583: bigint = 0n + 1n;
    const v1584: bigint = v1583 + 1n;
    const v1585: bigint = v1584 + 1n;
    const v1586: bigint = v1585 + 1n;
    const v1587: bigint = v1586 + 1n;
    const v1588: boolean = v1582 === v1587;
    let v1589: bigint;
    if (v1588) {
        v1589 = 0n;
    } else {
        v1589 = 1n;
    }
    const v1592: bigint = BigInt.asIntN(64, v1577 + v1589);
    const v1595: bigint = BigInt.asIntN(64, v1573 + v1592);
    const v1596: bigint = 0n + 1n;
    const v1597: bigint = v1596 + 1n;
    const v1598: bigint = v1597 + 1n;
    const v1599: bigint = v1598 + 1n;
    const v1600: bigint = 0n + 1n;
    const v1601: bigint = v1600 + 1n;
    const v1602: bigint = v1601 + 1n;
    const v1603: bigint = v1602 + 1n;
    const v1604: boolean = v1599 === v1603;
    let v1605: bigint;
    if (v1604) {
        v1605 = 0n;
    } else {
        v1605 = 1n;
    }
    const v1606: bigint = 0n + 1n;
    const v1607: bigint = 0n + 1n;
    const v1608: boolean = v1606 === v1607;
    let v1609: bigint;
    if (v1608) {
        v1609 = 0n;
    } else {
        v1609 = 1n;
    }
    const v1610: bigint = 0n + 1n;
    const v1611: bigint = v1610 + 1n;
    const v1612: bigint = v1611 + 1n;
    const v1613: bigint = v1612 + 1n;
    const v1614: bigint = v1613 + 1n;
    const v1615: bigint = 0n + 1n;
    const v1616: bigint = v1615 + 1n;
    const v1617: bigint = v1616 + 1n;
    const v1618: bigint = v1617 + 1n;
    const v1619: bigint = v1618 + 1n;
    const v1620: boolean = v1614 === v1619;
    let v1621: bigint;
    if (v1620) {
        v1621 = 0n;
    } else {
        v1621 = 1n;
    }
    const v1624: bigint = BigInt.asIntN(64, v1609 + v1621);
    const v1627: bigint = BigInt.asIntN(64, v1605 + v1624);
    const v1628: bigint = 0n + 1n;
    const v1629: bigint = v1628 + 1n;
    const v1630: bigint = v1629 + 1n;
    const v1631: bigint = v1630 + 1n;
    const v1632: bigint = 0n + 1n;
    const v1633: bigint = v1632 + 1n;
    const v1634: bigint = v1633 + 1n;
    const v1635: bigint = v1634 + 1n;
    const v1636: boolean = v1631 === v1635;
    let v1637: bigint;
    if (v1636) {
        v1637 = 0n;
    } else {
        v1637 = 1n;
    }
    const v1638: bigint = 0n + 1n;
    const v1639: bigint = 0n + 1n;
    const v1640: boolean = v1638 === v1639;
    let v1641: bigint;
    if (v1640) {
        v1641 = 0n;
    } else {
        v1641 = 1n;
    }
    const v1642: bigint = 0n + 1n;
    const v1643: bigint = v1642 + 1n;
    const v1644: bigint = v1643 + 1n;
    const v1645: bigint = v1644 + 1n;
    const v1646: bigint = v1645 + 1n;
    const v1647: bigint = 0n + 1n;
    const v1648: bigint = v1647 + 1n;
    const v1649: bigint = v1648 + 1n;
    const v1650: bigint = v1649 + 1n;
    const v1651: bigint = v1650 + 1n;
    const v1652: boolean = v1646 === v1651;
    let v1653: bigint;
    if (v1652) {
        v1653 = 0n;
    } else {
        v1653 = 1n;
    }
    const v1656: bigint = BigInt.asIntN(64, v1641 + v1653);
    const v1659: bigint = BigInt.asIntN(64, v1637 + v1656);
    const v1660: bigint = BigInt.asIntN(64, v1627 + v1659);
    const v1661: bigint = BigInt.asIntN(64, v1595 + v1660);
    const v1662: bigint = BigInt.asIntN(64, v1563 + v1661);
    const v1663: bigint = BigInt.asIntN(64, v1531 + v1662);
    const v1664: bigint = BigInt.asIntN(64, v1499 + v1663);
    const v1665: boolean = v1467 === 0n;
    const v1666: boolean = v1664 === v1467;
    const v1667: boolean = v1665 && v1666;
    if (v1667) {
    } else {
        throw new Error("typed-FX-statement-stale-writer-conflict-program-append-associativity-runtime-mismatch");
    }
    const v1668: bigint = 0n + 1n;
    const v1669: bigint = v1668 + 1n;
    const v1670: bigint = v1669 + 1n;
    const v1671: bigint = v1670 + 1n;
    const v1672: bigint = 0n + 1n;
    const v1673: bigint = v1672 + 1n;
    const v1674: bigint = v1673 + 1n;
    const v1675: bigint = v1674 + 1n;
    const v1676: boolean = v1671 === v1675;
    let v1677: bigint;
    if (v1676) {
        v1677 = 0n;
    } else {
        v1677 = 1n;
    }
    const v1678: bigint = 0n + 1n;
    const v1679: bigint = 0n + 1n;
    const v1680: boolean = v1678 === v1679;
    let v1681: bigint;
    if (v1680) {
        v1681 = 0n;
    } else {
        v1681 = 1n;
    }
    const v1682: bigint = 0n + 1n;
    const v1683: bigint = v1682 + 1n;
    const v1684: bigint = v1683 + 1n;
    const v1685: bigint = v1684 + 1n;
    const v1686: bigint = v1685 + 1n;
    const v1687: bigint = 0n + 1n;
    const v1688: bigint = v1687 + 1n;
    const v1689: bigint = v1688 + 1n;
    const v1690: bigint = v1689 + 1n;
    const v1691: bigint = v1690 + 1n;
    const v1692: boolean = v1686 === v1691;
    let v1693: bigint;
    if (v1692) {
        v1693 = 0n;
    } else {
        v1693 = 1n;
    }
    const v1696: bigint = BigInt.asIntN(64, v1681 + v1693);
    const v1699: bigint = BigInt.asIntN(64, v1677 + v1696);
    const v1700: bigint = 0n + 1n;
    const v1701: bigint = v1700 + 1n;
    const v1702: bigint = v1701 + 1n;
    const v1703: bigint = v1702 + 1n;
    const v1704: bigint = 0n + 1n;
    const v1705: bigint = v1704 + 1n;
    const v1706: bigint = v1705 + 1n;
    const v1707: bigint = v1706 + 1n;
    const v1708: boolean = v1703 === v1707;
    let v1709: bigint;
    if (v1708) {
        v1709 = 0n;
    } else {
        v1709 = 1n;
    }
    const v1710: bigint = 0n + 1n;
    const v1711: bigint = 0n + 1n;
    const v1712: boolean = v1710 === v1711;
    let v1713: bigint;
    if (v1712) {
        v1713 = 0n;
    } else {
        v1713 = 1n;
    }
    const v1714: bigint = 0n + 1n;
    const v1715: bigint = v1714 + 1n;
    const v1716: bigint = v1715 + 1n;
    const v1717: bigint = v1716 + 1n;
    const v1718: bigint = v1717 + 1n;
    const v1719: bigint = 0n + 1n;
    const v1720: bigint = v1719 + 1n;
    const v1721: bigint = v1720 + 1n;
    const v1722: bigint = v1721 + 1n;
    const v1723: bigint = v1722 + 1n;
    const v1724: boolean = v1718 === v1723;
    let v1725: bigint;
    if (v1724) {
        v1725 = 0n;
    } else {
        v1725 = 1n;
    }
    const v1728: bigint = BigInt.asIntN(64, v1713 + v1725);
    const v1731: bigint = BigInt.asIntN(64, v1709 + v1728);
    const v1732: bigint = BigInt.asIntN(64, v1699 + v1731);
    const v1733: bigint = 0n + 1n;
    const v1734: bigint = v1733 + 1n;
    const v1735: bigint = v1734 + 1n;
    const v1736: bigint = v1735 + 1n;
    const v1737: bigint = 0n + 1n;
    const v1738: bigint = v1737 + 1n;
    const v1739: bigint = v1738 + 1n;
    const v1740: bigint = v1739 + 1n;
    const v1741: boolean = v1736 === v1740;
    let v1742: bigint;
    if (v1741) {
        v1742 = 0n;
    } else {
        v1742 = 1n;
    }
    const v1743: bigint = 0n + 1n;
    const v1744: bigint = 0n + 1n;
    const v1745: boolean = v1743 === v1744;
    let v1746: bigint;
    if (v1745) {
        v1746 = 0n;
    } else {
        v1746 = 1n;
    }
    const v1747: bigint = 0n + 1n;
    const v1748: bigint = v1747 + 1n;
    const v1749: bigint = v1748 + 1n;
    const v1750: bigint = v1749 + 1n;
    const v1751: bigint = v1750 + 1n;
    const v1752: bigint = 0n + 1n;
    const v1753: bigint = v1752 + 1n;
    const v1754: bigint = v1753 + 1n;
    const v1755: bigint = v1754 + 1n;
    const v1756: bigint = v1755 + 1n;
    const v1757: boolean = v1751 === v1756;
    let v1758: bigint;
    if (v1757) {
        v1758 = 0n;
    } else {
        v1758 = 1n;
    }
    const v1761: bigint = BigInt.asIntN(64, v1746 + v1758);
    const v1764: bigint = BigInt.asIntN(64, v1742 + v1761);
    const v1765: bigint = 0n + 1n;
    const v1766: bigint = v1765 + 1n;
    const v1767: bigint = v1766 + 1n;
    const v1768: bigint = v1767 + 1n;
    const v1769: bigint = 0n + 1n;
    const v1770: bigint = v1769 + 1n;
    const v1771: bigint = v1770 + 1n;
    const v1772: bigint = v1771 + 1n;
    const v1773: boolean = v1768 === v1772;
    let v1774: bigint;
    if (v1773) {
        v1774 = 0n;
    } else {
        v1774 = 1n;
    }
    const v1775: bigint = 0n + 1n;
    const v1776: bigint = 0n + 1n;
    const v1777: boolean = v1775 === v1776;
    let v1778: bigint;
    if (v1777) {
        v1778 = 0n;
    } else {
        v1778 = 1n;
    }
    const v1779: bigint = 0n + 1n;
    const v1780: bigint = v1779 + 1n;
    const v1781: bigint = v1780 + 1n;
    const v1782: bigint = v1781 + 1n;
    const v1783: bigint = v1782 + 1n;
    const v1784: bigint = 0n + 1n;
    const v1785: bigint = v1784 + 1n;
    const v1786: bigint = v1785 + 1n;
    const v1787: bigint = v1786 + 1n;
    const v1788: bigint = v1787 + 1n;
    const v1789: boolean = v1783 === v1788;
    let v1790: bigint;
    if (v1789) {
        v1790 = 0n;
    } else {
        v1790 = 1n;
    }
    const v1793: bigint = BigInt.asIntN(64, v1778 + v1790);
    const v1796: bigint = BigInt.asIntN(64, v1774 + v1793);
    const v1797: bigint = 0n + 1n;
    const v1798: bigint = v1797 + 1n;
    const v1799: bigint = v1798 + 1n;
    const v1800: bigint = v1799 + 1n;
    const v1801: bigint = 0n + 1n;
    const v1802: bigint = v1801 + 1n;
    const v1803: bigint = v1802 + 1n;
    const v1804: bigint = v1803 + 1n;
    const v1805: boolean = v1800 === v1804;
    let v1806: bigint;
    if (v1805) {
        v1806 = 0n;
    } else {
        v1806 = 1n;
    }
    const v1807: bigint = 0n + 1n;
    const v1808: bigint = 0n + 1n;
    const v1809: boolean = v1807 === v1808;
    let v1810: bigint;
    if (v1809) {
        v1810 = 0n;
    } else {
        v1810 = 1n;
    }
    const v1811: bigint = 0n + 1n;
    const v1812: bigint = v1811 + 1n;
    const v1813: bigint = v1812 + 1n;
    const v1814: bigint = v1813 + 1n;
    const v1815: bigint = v1814 + 1n;
    const v1816: bigint = 0n + 1n;
    const v1817: bigint = v1816 + 1n;
    const v1818: bigint = v1817 + 1n;
    const v1819: bigint = v1818 + 1n;
    const v1820: bigint = v1819 + 1n;
    const v1821: boolean = v1815 === v1820;
    let v1822: bigint;
    if (v1821) {
        v1822 = 0n;
    } else {
        v1822 = 1n;
    }
    const v1825: bigint = BigInt.asIntN(64, v1810 + v1822);
    const v1828: bigint = BigInt.asIntN(64, v1806 + v1825);
    const v1829: bigint = 0n + 1n;
    const v1830: bigint = v1829 + 1n;
    const v1831: bigint = v1830 + 1n;
    const v1832: bigint = v1831 + 1n;
    const v1833: bigint = 0n + 1n;
    const v1834: bigint = v1833 + 1n;
    const v1835: bigint = v1834 + 1n;
    const v1836: bigint = v1835 + 1n;
    const v1837: boolean = v1832 === v1836;
    let v1838: bigint;
    if (v1837) {
        v1838 = 0n;
    } else {
        v1838 = 1n;
    }
    const v1839: bigint = 0n + 1n;
    const v1840: bigint = 0n + 1n;
    const v1841: boolean = v1839 === v1840;
    let v1842: bigint;
    if (v1841) {
        v1842 = 0n;
    } else {
        v1842 = 1n;
    }
    const v1843: bigint = 0n + 1n;
    const v1844: bigint = v1843 + 1n;
    const v1845: bigint = v1844 + 1n;
    const v1846: bigint = v1845 + 1n;
    const v1847: bigint = v1846 + 1n;
    const v1848: bigint = 0n + 1n;
    const v1849: bigint = v1848 + 1n;
    const v1850: bigint = v1849 + 1n;
    const v1851: bigint = v1850 + 1n;
    const v1852: bigint = v1851 + 1n;
    const v1853: boolean = v1847 === v1852;
    let v1854: bigint;
    if (v1853) {
        v1854 = 0n;
    } else {
        v1854 = 1n;
    }
    const v1857: bigint = BigInt.asIntN(64, v1842 + v1854);
    const v1860: bigint = BigInt.asIntN(64, v1838 + v1857);
    const v1861: bigint = BigInt.asIntN(64, v1828 + v1860);
    const v1862: bigint = BigInt.asIntN(64, v1796 + v1861);
    const v1863: bigint = BigInt.asIntN(64, v1764 + v1862);
    const v1864: bigint = BigInt.asIntN(64, v1732 + v1863);
    const v1865: bigint = 0n + 1n;
    const v1866: bigint = v1865 + 1n;
    const v1867: bigint = v1866 + 1n;
    const v1868: bigint = v1867 + 1n;
    const v1869: bigint = 0n + 1n;
    const v1870: bigint = v1869 + 1n;
    const v1871: bigint = v1870 + 1n;
    const v1872: bigint = v1871 + 1n;
    const v1873: boolean = v1868 === v1872;
    let v1874: bigint;
    if (v1873) {
        v1874 = 0n;
    } else {
        v1874 = 1n;
    }
    const v1875: bigint = 0n + 1n;
    const v1876: bigint = 0n + 1n;
    const v1877: boolean = v1875 === v1876;
    let v1878: bigint;
    if (v1877) {
        v1878 = 0n;
    } else {
        v1878 = 1n;
    }
    const v1879: bigint = 0n + 1n;
    const v1880: bigint = v1879 + 1n;
    const v1881: bigint = v1880 + 1n;
    const v1882: bigint = v1881 + 1n;
    const v1883: bigint = v1882 + 1n;
    const v1884: bigint = 0n + 1n;
    const v1885: bigint = v1884 + 1n;
    const v1886: bigint = v1885 + 1n;
    const v1887: bigint = v1886 + 1n;
    const v1888: bigint = v1887 + 1n;
    const v1889: boolean = v1883 === v1888;
    let v1890: bigint;
    if (v1889) {
        v1890 = 0n;
    } else {
        v1890 = 1n;
    }
    const v1891: bigint = BigInt.asIntN(64, v1875 + v1883);
    const v1892: bigint = BigInt.asIntN(64, v1876 + v1888);
    const v1893: bigint = BigInt.asIntN(64, v1878 + v1890);
    const v1894: bigint = BigInt.asIntN(64, v1868 + v1891);
    const v1895: bigint = BigInt.asIntN(64, v1872 + v1892);
    const v1896: bigint = BigInt.asIntN(64, v1874 + v1893);
    const v1897: bigint = BigInt.asIntN(64, v1895 + v1896);
    const v1898: bigint = BigInt.asIntN(64, v1894 + v1897);
    const v1899: bigint = BigInt.asIntN(64, 3n + v1898);
    const v1900: bigint = 0n + 1n;
    const v1901: bigint = v1900 + 1n;
    const v1902: bigint = v1901 + 1n;
    const v1903: bigint = v1902 + 1n;
    const v1904: bigint = 0n + 1n;
    const v1905: bigint = v1904 + 1n;
    const v1906: bigint = v1905 + 1n;
    const v1907: bigint = v1906 + 1n;
    const v1908: boolean = v1903 === v1907;
    let v1909: bigint;
    if (v1908) {
        v1909 = 0n;
    } else {
        v1909 = 1n;
    }
    const v1910: bigint = 0n + 1n;
    const v1911: bigint = 0n + 1n;
    const v1912: boolean = v1910 === v1911;
    let v1913: bigint;
    if (v1912) {
        v1913 = 0n;
    } else {
        v1913 = 1n;
    }
    const v1914: bigint = 0n + 1n;
    const v1915: bigint = v1914 + 1n;
    const v1916: bigint = v1915 + 1n;
    const v1917: bigint = v1916 + 1n;
    const v1918: bigint = v1917 + 1n;
    const v1919: bigint = 0n + 1n;
    const v1920: bigint = v1919 + 1n;
    const v1921: bigint = v1920 + 1n;
    const v1922: bigint = v1921 + 1n;
    const v1923: bigint = v1922 + 1n;
    const v1924: boolean = v1918 === v1923;
    let v1925: bigint;
    if (v1924) {
        v1925 = 0n;
    } else {
        v1925 = 1n;
    }
    const v1926: bigint = BigInt.asIntN(64, v1910 + v1918);
    const v1927: bigint = BigInt.asIntN(64, v1911 + v1923);
    const v1928: bigint = BigInt.asIntN(64, v1913 + v1925);
    const v1929: bigint = BigInt.asIntN(64, v1903 + v1926);
    const v1930: bigint = BigInt.asIntN(64, v1907 + v1927);
    const v1931: bigint = BigInt.asIntN(64, v1909 + v1928);
    const v1932: bigint = BigInt.asIntN(64, v1930 + v1931);
    const v1933: bigint = BigInt.asIntN(64, v1929 + v1932);
    const v1934: bigint = BigInt.asIntN(64, 3n + v1933);
    const v1935: boolean = v1899 === v1934;
    let v1972: US0;
    if (v1935) {
        const v1936: bigint = 0n + 1n;
        const v1937: bigint = v1936 + 1n;
        const v1938: bigint = v1937 + 1n;
        const v1939: bigint = v1938 + 1n;
        const v1940: bigint = 0n + 1n;
        const v1941: bigint = v1940 + 1n;
        const v1942: bigint = v1941 + 1n;
        const v1943: bigint = v1942 + 1n;
        const v1944: boolean = v1939 === v1943;
        let v1945: bigint;
        if (v1944) {
            v1945 = 0n;
        } else {
            v1945 = 1n;
        }
        const v1946: bigint = 0n + 1n;
        const v1947: bigint = 0n + 1n;
        const v1948: boolean = v1946 === v1947;
        let v1949: bigint;
        if (v1948) {
            v1949 = 0n;
        } else {
            v1949 = 1n;
        }
        const v1950: bigint = 0n + 1n;
        const v1951: bigint = v1950 + 1n;
        const v1952: bigint = v1951 + 1n;
        const v1953: bigint = v1952 + 1n;
        const v1954: bigint = v1953 + 1n;
        const v1955: bigint = 0n + 1n;
        const v1956: bigint = v1955 + 1n;
        const v1957: bigint = v1956 + 1n;
        const v1958: bigint = v1957 + 1n;
        const v1959: bigint = v1958 + 1n;
        const v1960: boolean = v1954 === v1959;
        let v1961: bigint;
        if (v1960) {
            v1961 = 0n;
        } else {
            v1961 = 1n;
        }
        const v1962: bigint = BigInt.asIntN(64, v1946 + v1954);
        const v1963: bigint = BigInt.asIntN(64, v1947 + v1959);
        const v1964: bigint = BigInt.asIntN(64, v1949 + v1961);
        const v1965: bigint = BigInt.asIntN(64, v1939 + v1962);
        const v1966: bigint = BigInt.asIntN(64, v1943 + v1963);
        const v1967: bigint = BigInt.asIntN(64, v1945 + v1964);
        const v1968: string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v1972 = US0_TypedFxHashedStatementChecksumValidationAccepted(1n, 3n, v1965, v1966, v1967, v1968);
    } else {
        const v1970: string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v1972 = US0_TypedFxHashedStatementChecksumValidationRejected(v1899, v1934, v1970);
    }
    let v1991: bigint;
    let v1992: bigint;
    let v1995: bigint;
    let v1999: bigint;
    switch (v1972.tag) {
        case 0: {
            const v1976: bigint = v1972.f0;
            const v1977: bigint = v1972.f1;
            const v1978: bigint = v1972.f2;
            const v1979: bigint = v1972.f3;
            const v1980: bigint = v1972.f4;
            const v1981: string = v1972.f5;
            v1991 = 1n;
            v1992 = 0n;
            v1995 = v1976;
            v1999 = v1980;
            break;
        }
        case 1: {
            const v1973: bigint = v1972.f0;
            const v1974: bigint = v1972.f1;
            const v1975: string = v1972.f2;
            v1991 = 0n;
            v1992 = 1n;
            v1995 = 0n;
            v1999 = 0n;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v2000: bigint = 0n + 1n;
    const v2001: bigint = v2000 + 1n;
    const v2002: bigint = v2001 + 1n;
    const v2003: bigint = v2002 + 1n;
    const v2004: bigint = 0n + 1n;
    const v2005: bigint = v2004 + 1n;
    const v2006: bigint = v2005 + 1n;
    const v2007: bigint = v2006 + 1n;
    const v2008: boolean = v2003 === v2007;
    let v2009: bigint;
    if (v2008) {
        v2009 = 0n;
    } else {
        v2009 = 1n;
    }
    const v2010: bigint = 0n + 1n;
    const v2011: bigint = 0n + 1n;
    const v2012: boolean = v2010 === v2011;
    let v2013: bigint;
    if (v2012) {
        v2013 = 0n;
    } else {
        v2013 = 1n;
    }
    const v2014: bigint = 0n + 1n;
    const v2015: bigint = v2014 + 1n;
    const v2016: bigint = v2015 + 1n;
    const v2017: bigint = v2016 + 1n;
    const v2018: bigint = v2017 + 1n;
    const v2019: bigint = 0n + 1n;
    const v2020: bigint = v2019 + 1n;
    const v2021: bigint = v2020 + 1n;
    const v2022: bigint = v2021 + 1n;
    const v2023: bigint = v2022 + 1n;
    const v2024: boolean = v2018 === v2023;
    let v2025: bigint;
    if (v2024) {
        v2025 = 0n;
    } else {
        v2025 = 1n;
    }
    const v2028: bigint = BigInt.asIntN(64, v2013 + v2025);
    const v2031: bigint = BigInt.asIntN(64, v2009 + v2028);
    const v2032: bigint = 0n + 1n;
    const v2033: bigint = v2032 + 1n;
    const v2034: bigint = v2033 + 1n;
    const v2035: bigint = v2034 + 1n;
    const v2036: bigint = 0n + 1n;
    const v2037: bigint = v2036 + 1n;
    const v2038: bigint = v2037 + 1n;
    const v2039: bigint = v2038 + 1n;
    const v2040: boolean = v2035 === v2039;
    let v2041: bigint;
    if (v2040) {
        v2041 = 0n;
    } else {
        v2041 = 1n;
    }
    const v2042: bigint = 0n + 1n;
    const v2043: bigint = 0n + 1n;
    const v2044: boolean = v2042 === v2043;
    let v2045: bigint;
    if (v2044) {
        v2045 = 0n;
    } else {
        v2045 = 1n;
    }
    const v2046: bigint = 0n + 1n;
    const v2047: bigint = v2046 + 1n;
    const v2048: bigint = v2047 + 1n;
    const v2049: bigint = v2048 + 1n;
    const v2050: bigint = v2049 + 1n;
    const v2051: bigint = 0n + 1n;
    const v2052: bigint = v2051 + 1n;
    const v2053: bigint = v2052 + 1n;
    const v2054: bigint = v2053 + 1n;
    const v2055: bigint = v2054 + 1n;
    const v2056: boolean = v2050 === v2055;
    let v2057: bigint;
    if (v2056) {
        v2057 = 0n;
    } else {
        v2057 = 1n;
    }
    const v2060: bigint = BigInt.asIntN(64, v2045 + v2057);
    const v2063: bigint = BigInt.asIntN(64, v2041 + v2060);
    const v2064: bigint = 0n + 1n;
    const v2065: bigint = v2064 + 1n;
    const v2066: bigint = v2065 + 1n;
    const v2067: bigint = v2066 + 1n;
    const v2068: bigint = 0n + 1n;
    const v2069: bigint = v2068 + 1n;
    const v2070: bigint = v2069 + 1n;
    const v2071: bigint = v2070 + 1n;
    const v2072: boolean = v2067 === v2071;
    let v2073: bigint;
    if (v2072) {
        v2073 = 0n;
    } else {
        v2073 = 1n;
    }
    const v2074: bigint = 0n + 1n;
    const v2075: bigint = 0n + 1n;
    const v2076: boolean = v2074 === v2075;
    let v2077: bigint;
    if (v2076) {
        v2077 = 0n;
    } else {
        v2077 = 1n;
    }
    const v2078: bigint = 0n + 1n;
    const v2079: bigint = v2078 + 1n;
    const v2080: bigint = v2079 + 1n;
    const v2081: bigint = v2080 + 1n;
    const v2082: bigint = v2081 + 1n;
    const v2083: bigint = 0n + 1n;
    const v2084: bigint = v2083 + 1n;
    const v2085: bigint = v2084 + 1n;
    const v2086: bigint = v2085 + 1n;
    const v2087: bigint = v2086 + 1n;
    const v2088: boolean = v2082 === v2087;
    let v2089: bigint;
    if (v2088) {
        v2089 = 0n;
    } else {
        v2089 = 1n;
    }
    const v2092: bigint = BigInt.asIntN(64, v2077 + v2089);
    const v2095: bigint = BigInt.asIntN(64, v2073 + v2092);
    const v2096: bigint = 0n + 1n;
    const v2097: bigint = v2096 + 1n;
    const v2098: bigint = v2097 + 1n;
    const v2099: bigint = v2098 + 1n;
    const v2100: bigint = 0n + 1n;
    const v2101: bigint = v2100 + 1n;
    const v2102: bigint = v2101 + 1n;
    const v2103: bigint = v2102 + 1n;
    const v2104: boolean = v2099 === v2103;
    let v2105: bigint;
    if (v2104) {
        v2105 = 0n;
    } else {
        v2105 = 1n;
    }
    const v2106: bigint = 0n + 1n;
    const v2107: bigint = 0n + 1n;
    const v2108: boolean = v2106 === v2107;
    let v2109: bigint;
    if (v2108) {
        v2109 = 0n;
    } else {
        v2109 = 1n;
    }
    const v2110: bigint = 0n + 1n;
    const v2111: bigint = v2110 + 1n;
    const v2112: bigint = v2111 + 1n;
    const v2113: bigint = v2112 + 1n;
    const v2114: bigint = v2113 + 1n;
    const v2115: bigint = 0n + 1n;
    const v2116: bigint = v2115 + 1n;
    const v2117: bigint = v2116 + 1n;
    const v2118: bigint = v2117 + 1n;
    const v2119: bigint = v2118 + 1n;
    const v2120: boolean = v2114 === v2119;
    let v2121: bigint;
    if (v2120) {
        v2121 = 0n;
    } else {
        v2121 = 1n;
    }
    const v2124: bigint = BigInt.asIntN(64, v2109 + v2121);
    const v2127: bigint = BigInt.asIntN(64, v2105 + v2124);
    const v2128: bigint = BigInt.asIntN(64, v2095 + v2127);
    const v2129: bigint = BigInt.asIntN(64, v2063 + v2128);
    const v2130: bigint = BigInt.asIntN(64, v2031 + v2129);
    const v2131: bigint = BigInt.asIntN(64, v1999 + v1992);
    const v2132: bigint = BigInt.asIntN(64, v2130 + v2131);
    const v2133: bigint = BigInt.asIntN(64, v1864 + v2132);
    const v2134: boolean = v1995 === 1n;
    const v2135: boolean = v1991 === 1n;
    const v2136: boolean = v2133 === 0n;
    const v2137: boolean = v2134 && v2135;
    const v2138: boolean = v2137 && v2136;
    if (v2138) {
    } else {
        throw new Error("typed-FX-statement-recursive-writer-appended-tail-restart-runtime-mismatch");
    }
    const v2139: bigint = 0n + 1n;
    const v2140: bigint = v2139 + 1n;
    const v2141: bigint = v2140 + 1n;
    const v2142: bigint = v2141 + 1n;
    const v2143: bigint = 0n + 1n;
    const v2144: bigint = v2143 + 1n;
    const v2145: bigint = v2144 + 1n;
    const v2146: bigint = v2145 + 1n;
    const v2147: boolean = v2142 === v2146;
    let v2148: bigint;
    if (v2147) {
        v2148 = 0n;
    } else {
        v2148 = 1n;
    }
    const v2149: bigint = 0n + 1n;
    const v2150: bigint = 0n + 1n;
    const v2151: boolean = v2149 === v2150;
    let v2152: bigint;
    if (v2151) {
        v2152 = 0n;
    } else {
        v2152 = 1n;
    }
    const v2153: bigint = 0n + 1n;
    const v2154: bigint = v2153 + 1n;
    const v2155: bigint = v2154 + 1n;
    const v2156: bigint = v2155 + 1n;
    const v2157: bigint = v2156 + 1n;
    const v2158: bigint = 0n + 1n;
    const v2159: bigint = v2158 + 1n;
    const v2160: bigint = v2159 + 1n;
    const v2161: bigint = v2160 + 1n;
    const v2162: bigint = v2161 + 1n;
    const v2163: boolean = v2157 === v2162;
    let v2164: bigint;
    if (v2163) {
        v2164 = 0n;
    } else {
        v2164 = 1n;
    }
    const v2167: bigint = BigInt.asIntN(64, v2152 + v2164);
    const v2170: bigint = BigInt.asIntN(64, v2148 + v2167);
    const v2171: bigint = 0n + 1n;
    const v2172: bigint = v2171 + 1n;
    const v2173: bigint = v2172 + 1n;
    const v2174: bigint = v2173 + 1n;
    const v2175: bigint = 0n + 1n;
    const v2176: bigint = v2175 + 1n;
    const v2177: bigint = v2176 + 1n;
    const v2178: bigint = v2177 + 1n;
    const v2179: boolean = v2174 === v2178;
    let v2180: bigint;
    if (v2179) {
        v2180 = 0n;
    } else {
        v2180 = 1n;
    }
    const v2181: bigint = 0n + 1n;
    const v2182: bigint = 0n + 1n;
    const v2183: boolean = v2181 === v2182;
    let v2184: bigint;
    if (v2183) {
        v2184 = 0n;
    } else {
        v2184 = 1n;
    }
    const v2185: bigint = 0n + 1n;
    const v2186: bigint = v2185 + 1n;
    const v2187: bigint = v2186 + 1n;
    const v2188: bigint = v2187 + 1n;
    const v2189: bigint = v2188 + 1n;
    const v2190: bigint = 0n + 1n;
    const v2191: bigint = v2190 + 1n;
    const v2192: bigint = v2191 + 1n;
    const v2193: bigint = v2192 + 1n;
    const v2194: bigint = v2193 + 1n;
    const v2195: boolean = v2189 === v2194;
    let v2196: bigint;
    if (v2195) {
        v2196 = 0n;
    } else {
        v2196 = 1n;
    }
    const v2199: bigint = BigInt.asIntN(64, v2184 + v2196);
    const v2202: bigint = BigInt.asIntN(64, v2180 + v2199);
    const v2203: bigint = BigInt.asIntN(64, v2170 + v2202);
    const v2204: bigint = 0n + 1n;
    const v2205: bigint = v2204 + 1n;
    const v2206: bigint = v2205 + 1n;
    const v2207: bigint = v2206 + 1n;
    const v2208: bigint = 0n + 1n;
    const v2209: bigint = v2208 + 1n;
    const v2210: bigint = v2209 + 1n;
    const v2211: bigint = v2210 + 1n;
    const v2212: boolean = v2207 === v2211;
    let v2213: bigint;
    if (v2212) {
        v2213 = 0n;
    } else {
        v2213 = 1n;
    }
    const v2214: bigint = 0n + 1n;
    const v2215: bigint = 0n + 1n;
    const v2216: boolean = v2214 === v2215;
    let v2217: bigint;
    if (v2216) {
        v2217 = 0n;
    } else {
        v2217 = 1n;
    }
    const v2218: bigint = 0n + 1n;
    const v2219: bigint = v2218 + 1n;
    const v2220: bigint = v2219 + 1n;
    const v2221: bigint = v2220 + 1n;
    const v2222: bigint = v2221 + 1n;
    const v2223: bigint = 0n + 1n;
    const v2224: bigint = v2223 + 1n;
    const v2225: bigint = v2224 + 1n;
    const v2226: bigint = v2225 + 1n;
    const v2227: bigint = v2226 + 1n;
    const v2228: boolean = v2222 === v2227;
    let v2229: bigint;
    if (v2228) {
        v2229 = 0n;
    } else {
        v2229 = 1n;
    }
    const v2232: bigint = BigInt.asIntN(64, v2217 + v2229);
    const v2235: bigint = BigInt.asIntN(64, v2213 + v2232);
    const v2236: bigint = 0n + 1n;
    const v2237: bigint = v2236 + 1n;
    const v2238: bigint = v2237 + 1n;
    const v2239: bigint = v2238 + 1n;
    const v2240: bigint = 0n + 1n;
    const v2241: bigint = v2240 + 1n;
    const v2242: bigint = v2241 + 1n;
    const v2243: bigint = v2242 + 1n;
    const v2244: boolean = v2239 === v2243;
    let v2245: bigint;
    if (v2244) {
        v2245 = 0n;
    } else {
        v2245 = 1n;
    }
    const v2246: bigint = 0n + 1n;
    const v2247: bigint = 0n + 1n;
    const v2248: boolean = v2246 === v2247;
    let v2249: bigint;
    if (v2248) {
        v2249 = 0n;
    } else {
        v2249 = 1n;
    }
    const v2250: bigint = 0n + 1n;
    const v2251: bigint = v2250 + 1n;
    const v2252: bigint = v2251 + 1n;
    const v2253: bigint = v2252 + 1n;
    const v2254: bigint = v2253 + 1n;
    const v2255: bigint = 0n + 1n;
    const v2256: bigint = v2255 + 1n;
    const v2257: bigint = v2256 + 1n;
    const v2258: bigint = v2257 + 1n;
    const v2259: bigint = v2258 + 1n;
    const v2260: boolean = v2254 === v2259;
    let v2261: bigint;
    if (v2260) {
        v2261 = 0n;
    } else {
        v2261 = 1n;
    }
    const v2264: bigint = BigInt.asIntN(64, v2249 + v2261);
    const v2267: bigint = BigInt.asIntN(64, v2245 + v2264);
    const v2268: bigint = BigInt.asIntN(64, v2235 + v2267);
    const v2269: bigint = BigInt.asIntN(64, v2203 + v2268);
    const v2270: bigint = 0n + 1n;
    const v2271: bigint = v2270 + 1n;
    const v2272: bigint = v2271 + 1n;
    const v2273: bigint = v2272 + 1n;
    const v2274: bigint = 0n + 1n;
    const v2275: bigint = v2274 + 1n;
    const v2276: bigint = v2275 + 1n;
    const v2277: bigint = v2276 + 1n;
    const v2278: boolean = v2273 === v2277;
    let v2279: bigint;
    if (v2278) {
        v2279 = 0n;
    } else {
        v2279 = 1n;
    }
    const v2280: bigint = 0n + 1n;
    const v2281: bigint = 0n + 1n;
    const v2282: boolean = v2280 === v2281;
    let v2283: bigint;
    if (v2282) {
        v2283 = 0n;
    } else {
        v2283 = 1n;
    }
    const v2284: bigint = 0n + 1n;
    const v2285: bigint = v2284 + 1n;
    const v2286: bigint = v2285 + 1n;
    const v2287: bigint = v2286 + 1n;
    const v2288: bigint = v2287 + 1n;
    const v2289: bigint = 0n + 1n;
    const v2290: bigint = v2289 + 1n;
    const v2291: bigint = v2290 + 1n;
    const v2292: bigint = v2291 + 1n;
    const v2293: bigint = v2292 + 1n;
    const v2294: boolean = v2288 === v2293;
    let v2295: bigint;
    if (v2294) {
        v2295 = 0n;
    } else {
        v2295 = 1n;
    }
    const v2296: bigint = BigInt.asIntN(64, v2280 + v2288);
    const v2297: bigint = BigInt.asIntN(64, v2281 + v2293);
    const v2298: bigint = BigInt.asIntN(64, v2283 + v2295);
    const v2299: bigint = BigInt.asIntN(64, v2273 + v2296);
    const v2300: bigint = BigInt.asIntN(64, v2277 + v2297);
    const v2301: bigint = BigInt.asIntN(64, v2279 + v2298);
    const v2302: bigint = BigInt.asIntN(64, v2300 + v2301);
    const v2303: bigint = BigInt.asIntN(64, v2299 + v2302);
    const v2304: bigint = BigInt.asIntN(64, 3n + v2303);
    const v2305: bigint = 0n + 1n;
    const v2306: bigint = v2305 + 1n;
    const v2307: bigint = v2306 + 1n;
    const v2308: bigint = v2307 + 1n;
    const v2309: bigint = 0n + 1n;
    const v2310: bigint = v2309 + 1n;
    const v2311: bigint = v2310 + 1n;
    const v2312: bigint = v2311 + 1n;
    const v2313: boolean = v2308 === v2312;
    let v2314: bigint;
    if (v2313) {
        v2314 = 0n;
    } else {
        v2314 = 1n;
    }
    const v2315: bigint = 0n + 1n;
    const v2316: bigint = 0n + 1n;
    const v2317: boolean = v2315 === v2316;
    let v2318: bigint;
    if (v2317) {
        v2318 = 0n;
    } else {
        v2318 = 1n;
    }
    const v2319: bigint = 0n + 1n;
    const v2320: bigint = v2319 + 1n;
    const v2321: bigint = v2320 + 1n;
    const v2322: bigint = v2321 + 1n;
    const v2323: bigint = v2322 + 1n;
    const v2324: bigint = 0n + 1n;
    const v2325: bigint = v2324 + 1n;
    const v2326: bigint = v2325 + 1n;
    const v2327: bigint = v2326 + 1n;
    const v2328: bigint = v2327 + 1n;
    const v2329: boolean = v2323 === v2328;
    let v2330: bigint;
    if (v2329) {
        v2330 = 0n;
    } else {
        v2330 = 1n;
    }
    const v2331: bigint = BigInt.asIntN(64, v2315 + v2323);
    const v2332: bigint = BigInt.asIntN(64, v2316 + v2328);
    const v2333: bigint = BigInt.asIntN(64, v2318 + v2330);
    const v2334: bigint = BigInt.asIntN(64, v2308 + v2331);
    const v2335: bigint = BigInt.asIntN(64, v2312 + v2332);
    const v2336: bigint = BigInt.asIntN(64, v2314 + v2333);
    const v2337: bigint = BigInt.asIntN(64, v2335 + v2336);
    const v2338: bigint = BigInt.asIntN(64, v2334 + v2337);
    const v2339: bigint = BigInt.asIntN(64, 3n + v2338);
    const v2340: boolean = v2304 === v2339;
    let v2377: US0;
    if (v2340) {
        const v2341: bigint = 0n + 1n;
        const v2342: bigint = v2341 + 1n;
        const v2343: bigint = v2342 + 1n;
        const v2344: bigint = v2343 + 1n;
        const v2345: bigint = 0n + 1n;
        const v2346: bigint = v2345 + 1n;
        const v2347: bigint = v2346 + 1n;
        const v2348: bigint = v2347 + 1n;
        const v2349: boolean = v2344 === v2348;
        let v2350: bigint;
        if (v2349) {
            v2350 = 0n;
        } else {
            v2350 = 1n;
        }
        const v2351: bigint = 0n + 1n;
        const v2352: bigint = 0n + 1n;
        const v2353: boolean = v2351 === v2352;
        let v2354: bigint;
        if (v2353) {
            v2354 = 0n;
        } else {
            v2354 = 1n;
        }
        const v2355: bigint = 0n + 1n;
        const v2356: bigint = v2355 + 1n;
        const v2357: bigint = v2356 + 1n;
        const v2358: bigint = v2357 + 1n;
        const v2359: bigint = v2358 + 1n;
        const v2360: bigint = 0n + 1n;
        const v2361: bigint = v2360 + 1n;
        const v2362: bigint = v2361 + 1n;
        const v2363: bigint = v2362 + 1n;
        const v2364: bigint = v2363 + 1n;
        const v2365: boolean = v2359 === v2364;
        let v2366: bigint;
        if (v2365) {
            v2366 = 0n;
        } else {
            v2366 = 1n;
        }
        const v2367: bigint = BigInt.asIntN(64, v2351 + v2359);
        const v2368: bigint = BigInt.asIntN(64, v2352 + v2364);
        const v2369: bigint = BigInt.asIntN(64, v2354 + v2366);
        const v2370: bigint = BigInt.asIntN(64, v2344 + v2367);
        const v2371: bigint = BigInt.asIntN(64, v2348 + v2368);
        const v2372: bigint = BigInt.asIntN(64, v2350 + v2369);
        const v2373: string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v2377 = US0_TypedFxHashedStatementChecksumValidationAccepted(1n, 3n, v2370, v2371, v2372, v2373);
    } else {
        const v2375: string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v2377 = US0_TypedFxHashedStatementChecksumValidationRejected(v2304, v2339, v2375);
    }
    let v2396: bigint;
    let v2397: bigint;
    let v2404: bigint;
    switch (v2377.tag) {
        case 0: {
            const v2381: bigint = v2377.f0;
            const v2382: bigint = v2377.f1;
            const v2383: bigint = v2377.f2;
            const v2384: bigint = v2377.f3;
            const v2385: bigint = v2377.f4;
            const v2386: string = v2377.f5;
            v2396 = 1n;
            v2397 = 0n;
            v2404 = v2385;
            break;
        }
        case 1: {
            const v2378: bigint = v2377.f0;
            const v2379: bigint = v2377.f1;
            const v2380: string = v2377.f2;
            v2396 = 0n;
            v2397 = 1n;
            v2404 = 0n;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v2405: bigint = 0n + 1n;
    const v2406: bigint = v2405 + 1n;
    const v2407: bigint = v2406 + 1n;
    const v2408: bigint = v2407 + 1n;
    const v2409: bigint = 0n + 1n;
    const v2410: bigint = v2409 + 1n;
    const v2411: bigint = v2410 + 1n;
    const v2412: bigint = v2411 + 1n;
    const v2413: boolean = v2408 === v2412;
    let v2414: bigint;
    if (v2413) {
        v2414 = 0n;
    } else {
        v2414 = 1n;
    }
    const v2415: bigint = 0n + 1n;
    const v2416: bigint = 0n + 1n;
    const v2417: boolean = v2415 === v2416;
    let v2418: bigint;
    if (v2417) {
        v2418 = 0n;
    } else {
        v2418 = 1n;
    }
    const v2419: bigint = 0n + 1n;
    const v2420: bigint = v2419 + 1n;
    const v2421: bigint = v2420 + 1n;
    const v2422: bigint = v2421 + 1n;
    const v2423: bigint = v2422 + 1n;
    const v2424: bigint = 0n + 1n;
    const v2425: bigint = v2424 + 1n;
    const v2426: bigint = v2425 + 1n;
    const v2427: bigint = v2426 + 1n;
    const v2428: bigint = v2427 + 1n;
    const v2429: boolean = v2423 === v2428;
    let v2430: bigint;
    if (v2429) {
        v2430 = 0n;
    } else {
        v2430 = 1n;
    }
    const v2433: bigint = BigInt.asIntN(64, v2418 + v2430);
    const v2436: bigint = BigInt.asIntN(64, v2414 + v2433);
    const v2437: bigint = 0n + 1n;
    const v2438: bigint = v2437 + 1n;
    const v2439: bigint = v2438 + 1n;
    const v2440: bigint = v2439 + 1n;
    const v2441: bigint = 0n + 1n;
    const v2442: bigint = v2441 + 1n;
    const v2443: bigint = v2442 + 1n;
    const v2444: bigint = v2443 + 1n;
    const v2445: boolean = v2440 === v2444;
    let v2446: bigint;
    if (v2445) {
        v2446 = 0n;
    } else {
        v2446 = 1n;
    }
    const v2447: bigint = 0n + 1n;
    const v2448: bigint = 0n + 1n;
    const v2449: boolean = v2447 === v2448;
    let v2450: bigint;
    if (v2449) {
        v2450 = 0n;
    } else {
        v2450 = 1n;
    }
    const v2451: bigint = 0n + 1n;
    const v2452: bigint = v2451 + 1n;
    const v2453: bigint = v2452 + 1n;
    const v2454: bigint = v2453 + 1n;
    const v2455: bigint = v2454 + 1n;
    const v2456: bigint = 0n + 1n;
    const v2457: bigint = v2456 + 1n;
    const v2458: bigint = v2457 + 1n;
    const v2459: bigint = v2458 + 1n;
    const v2460: bigint = v2459 + 1n;
    const v2461: boolean = v2455 === v2460;
    let v2462: bigint;
    if (v2461) {
        v2462 = 0n;
    } else {
        v2462 = 1n;
    }
    const v2465: bigint = BigInt.asIntN(64, v2450 + v2462);
    const v2468: bigint = BigInt.asIntN(64, v2446 + v2465);
    const v2469: bigint = BigInt.asIntN(64, v2436 + v2468);
    const v2470: bigint = BigInt.asIntN(64, v2404 + v2397);
    const v2471: bigint = BigInt.asIntN(64, v2469 + v2470);
    const v2472: bigint = BigInt.asIntN(64, v2269 + v2471);
    const v2473: boolean = v2396 === 1n;
    const v2474: boolean = v2472 === 0n;
    const v2475: boolean = v2473 && v2474;
    if (v2475) {
    } else {
        throw new Error("typed-FX-statement-recursive-writer-crash-phase-runtime-mismatch");
    }
    const v2476: bigint = 0n + 1n;
    const v2477: bigint = v2476 + 1n;
    const v2478: bigint = v2477 + 1n;
    const v2479: bigint = v2478 + 1n;
    const v2480: bigint = 0n + 1n;
    const v2481: bigint = v2480 + 1n;
    const v2482: bigint = v2481 + 1n;
    const v2483: bigint = v2482 + 1n;
    const v2484: boolean = v2479 === v2483;
    let v2485: bigint;
    if (v2484) {
        v2485 = 0n;
    } else {
        v2485 = 1n;
    }
    const v2486: bigint = 0n + 1n;
    const v2487: bigint = 0n + 1n;
    const v2488: boolean = v2486 === v2487;
    let v2489: bigint;
    if (v2488) {
        v2489 = 0n;
    } else {
        v2489 = 1n;
    }
    const v2490: bigint = 0n + 1n;
    const v2491: bigint = v2490 + 1n;
    const v2492: bigint = v2491 + 1n;
    const v2493: bigint = v2492 + 1n;
    const v2494: bigint = v2493 + 1n;
    const v2495: bigint = 0n + 1n;
    const v2496: bigint = v2495 + 1n;
    const v2497: bigint = v2496 + 1n;
    const v2498: bigint = v2497 + 1n;
    const v2499: bigint = v2498 + 1n;
    const v2500: boolean = v2494 === v2499;
    let v2501: bigint;
    if (v2500) {
        v2501 = 0n;
    } else {
        v2501 = 1n;
    }
    const v2504: bigint = BigInt.asIntN(64, v2489 + v2501);
    const v2507: bigint = BigInt.asIntN(64, v2485 + v2504);
    const v2508: bigint = 0n + 1n;
    const v2509: bigint = v2508 + 1n;
    const v2510: bigint = v2509 + 1n;
    const v2511: bigint = v2510 + 1n;
    const v2512: bigint = 0n + 1n;
    const v2513: bigint = v2512 + 1n;
    const v2514: bigint = v2513 + 1n;
    const v2515: bigint = v2514 + 1n;
    const v2516: boolean = v2511 === v2515;
    let v2517: bigint;
    if (v2516) {
        v2517 = 0n;
    } else {
        v2517 = 1n;
    }
    const v2518: bigint = 0n + 1n;
    const v2519: bigint = 0n + 1n;
    const v2520: boolean = v2518 === v2519;
    let v2521: bigint;
    if (v2520) {
        v2521 = 0n;
    } else {
        v2521 = 1n;
    }
    const v2522: bigint = 0n + 1n;
    const v2523: bigint = v2522 + 1n;
    const v2524: bigint = v2523 + 1n;
    const v2525: bigint = v2524 + 1n;
    const v2526: bigint = v2525 + 1n;
    const v2527: bigint = 0n + 1n;
    const v2528: bigint = v2527 + 1n;
    const v2529: bigint = v2528 + 1n;
    const v2530: bigint = v2529 + 1n;
    const v2531: bigint = v2530 + 1n;
    const v2532: boolean = v2526 === v2531;
    let v2533: bigint;
    if (v2532) {
        v2533 = 0n;
    } else {
        v2533 = 1n;
    }
    const v2536: bigint = BigInt.asIntN(64, v2521 + v2533);
    const v2539: bigint = BigInt.asIntN(64, v2517 + v2536);
    const v2540: bigint = BigInt.asIntN(64, v2507 + v2539);
    const v2541: bigint = 0n + 1n;
    const v2542: bigint = v2541 + 1n;
    const v2543: bigint = v2542 + 1n;
    const v2544: bigint = v2543 + 1n;
    const v2545: bigint = 0n + 1n;
    const v2546: bigint = v2545 + 1n;
    const v2547: bigint = v2546 + 1n;
    const v2548: bigint = v2547 + 1n;
    const v2549: boolean = v2544 === v2548;
    let v2550: bigint;
    if (v2549) {
        v2550 = 0n;
    } else {
        v2550 = 1n;
    }
    const v2551: bigint = 0n + 1n;
    const v2552: bigint = 0n + 1n;
    const v2553: boolean = v2551 === v2552;
    let v2554: bigint;
    if (v2553) {
        v2554 = 0n;
    } else {
        v2554 = 1n;
    }
    const v2555: bigint = 0n + 1n;
    const v2556: bigint = v2555 + 1n;
    const v2557: bigint = v2556 + 1n;
    const v2558: bigint = v2557 + 1n;
    const v2559: bigint = v2558 + 1n;
    const v2560: bigint = 0n + 1n;
    const v2561: bigint = v2560 + 1n;
    const v2562: bigint = v2561 + 1n;
    const v2563: bigint = v2562 + 1n;
    const v2564: bigint = v2563 + 1n;
    const v2565: boolean = v2559 === v2564;
    let v2566: bigint;
    if (v2565) {
        v2566 = 0n;
    } else {
        v2566 = 1n;
    }
    const v2569: bigint = BigInt.asIntN(64, v2554 + v2566);
    const v2572: bigint = BigInt.asIntN(64, v2550 + v2569);
    const v2573: bigint = 0n + 1n;
    const v2574: bigint = v2573 + 1n;
    const v2575: bigint = v2574 + 1n;
    const v2576: bigint = v2575 + 1n;
    const v2577: bigint = 0n + 1n;
    const v2578: bigint = v2577 + 1n;
    const v2579: bigint = v2578 + 1n;
    const v2580: bigint = v2579 + 1n;
    const v2581: boolean = v2576 === v2580;
    let v2582: bigint;
    if (v2581) {
        v2582 = 0n;
    } else {
        v2582 = 1n;
    }
    const v2583: bigint = 0n + 1n;
    const v2584: bigint = 0n + 1n;
    const v2585: boolean = v2583 === v2584;
    let v2586: bigint;
    if (v2585) {
        v2586 = 0n;
    } else {
        v2586 = 1n;
    }
    const v2587: bigint = 0n + 1n;
    const v2588: bigint = v2587 + 1n;
    const v2589: bigint = v2588 + 1n;
    const v2590: bigint = v2589 + 1n;
    const v2591: bigint = v2590 + 1n;
    const v2592: bigint = 0n + 1n;
    const v2593: bigint = v2592 + 1n;
    const v2594: bigint = v2593 + 1n;
    const v2595: bigint = v2594 + 1n;
    const v2596: bigint = v2595 + 1n;
    const v2597: boolean = v2591 === v2596;
    let v2598: bigint;
    if (v2597) {
        v2598 = 0n;
    } else {
        v2598 = 1n;
    }
    const v2601: bigint = BigInt.asIntN(64, v2586 + v2598);
    const v2604: bigint = BigInt.asIntN(64, v2582 + v2601);
    const v2605: bigint = BigInt.asIntN(64, v2572 + v2604);
    const v2606: bigint = BigInt.asIntN(64, v2540 + v2605);
    const v2607: bigint = 0n + 1n;
    const v2608: bigint = v2607 + 1n;
    const v2609: bigint = v2608 + 1n;
    const v2610: bigint = v2609 + 1n;
    const v2611: bigint = 0n + 1n;
    const v2612: bigint = v2611 + 1n;
    const v2613: bigint = v2612 + 1n;
    const v2614: bigint = v2613 + 1n;
    const v2615: boolean = v2610 === v2614;
    let v2616: bigint;
    if (v2615) {
        v2616 = 0n;
    } else {
        v2616 = 1n;
    }
    const v2617: bigint = 0n + 1n;
    const v2618: bigint = 0n + 1n;
    const v2619: boolean = v2617 === v2618;
    let v2620: bigint;
    if (v2619) {
        v2620 = 0n;
    } else {
        v2620 = 1n;
    }
    const v2621: bigint = 0n + 1n;
    const v2622: bigint = v2621 + 1n;
    const v2623: bigint = v2622 + 1n;
    const v2624: bigint = v2623 + 1n;
    const v2625: bigint = v2624 + 1n;
    const v2626: bigint = 0n + 1n;
    const v2627: bigint = v2626 + 1n;
    const v2628: bigint = v2627 + 1n;
    const v2629: bigint = v2628 + 1n;
    const v2630: bigint = v2629 + 1n;
    const v2631: boolean = v2625 === v2630;
    let v2632: bigint;
    if (v2631) {
        v2632 = 0n;
    } else {
        v2632 = 1n;
    }
    const v2633: bigint = BigInt.asIntN(64, v2617 + v2625);
    const v2634: bigint = BigInt.asIntN(64, v2618 + v2630);
    const v2635: bigint = BigInt.asIntN(64, v2620 + v2632);
    const v2636: bigint = BigInt.asIntN(64, v2610 + v2633);
    const v2637: bigint = BigInt.asIntN(64, v2614 + v2634);
    const v2638: bigint = BigInt.asIntN(64, v2616 + v2635);
    const v2639: bigint = BigInt.asIntN(64, v2637 + v2638);
    const v2640: bigint = BigInt.asIntN(64, v2636 + v2639);
    const v2641: bigint = BigInt.asIntN(64, 3n + v2640);
    const v2642: bigint = 0n + 1n;
    const v2643: bigint = v2642 + 1n;
    const v2644: bigint = v2643 + 1n;
    const v2645: bigint = v2644 + 1n;
    const v2646: bigint = 0n + 1n;
    const v2647: bigint = v2646 + 1n;
    const v2648: bigint = v2647 + 1n;
    const v2649: bigint = v2648 + 1n;
    const v2650: boolean = v2645 === v2649;
    let v2651: bigint;
    if (v2650) {
        v2651 = 0n;
    } else {
        v2651 = 1n;
    }
    const v2652: bigint = 0n + 1n;
    const v2653: bigint = 0n + 1n;
    const v2654: boolean = v2652 === v2653;
    let v2655: bigint;
    if (v2654) {
        v2655 = 0n;
    } else {
        v2655 = 1n;
    }
    const v2656: bigint = 0n + 1n;
    const v2657: bigint = v2656 + 1n;
    const v2658: bigint = v2657 + 1n;
    const v2659: bigint = v2658 + 1n;
    const v2660: bigint = v2659 + 1n;
    const v2661: bigint = 0n + 1n;
    const v2662: bigint = v2661 + 1n;
    const v2663: bigint = v2662 + 1n;
    const v2664: bigint = v2663 + 1n;
    const v2665: bigint = v2664 + 1n;
    const v2666: boolean = v2660 === v2665;
    let v2667: bigint;
    if (v2666) {
        v2667 = 0n;
    } else {
        v2667 = 1n;
    }
    const v2668: bigint = BigInt.asIntN(64, v2652 + v2660);
    const v2669: bigint = BigInt.asIntN(64, v2653 + v2665);
    const v2670: bigint = BigInt.asIntN(64, v2655 + v2667);
    const v2671: bigint = BigInt.asIntN(64, v2645 + v2668);
    const v2672: bigint = BigInt.asIntN(64, v2649 + v2669);
    const v2673: bigint = BigInt.asIntN(64, v2651 + v2670);
    const v2674: bigint = BigInt.asIntN(64, v2672 + v2673);
    const v2675: bigint = BigInt.asIntN(64, v2671 + v2674);
    const v2676: bigint = BigInt.asIntN(64, 3n + v2675);
    const v2677: boolean = v2641 === v2676;
    let v2714: US0;
    if (v2677) {
        const v2678: bigint = 0n + 1n;
        const v2679: bigint = v2678 + 1n;
        const v2680: bigint = v2679 + 1n;
        const v2681: bigint = v2680 + 1n;
        const v2682: bigint = 0n + 1n;
        const v2683: bigint = v2682 + 1n;
        const v2684: bigint = v2683 + 1n;
        const v2685: bigint = v2684 + 1n;
        const v2686: boolean = v2681 === v2685;
        let v2687: bigint;
        if (v2686) {
            v2687 = 0n;
        } else {
            v2687 = 1n;
        }
        const v2688: bigint = 0n + 1n;
        const v2689: bigint = 0n + 1n;
        const v2690: boolean = v2688 === v2689;
        let v2691: bigint;
        if (v2690) {
            v2691 = 0n;
        } else {
            v2691 = 1n;
        }
        const v2692: bigint = 0n + 1n;
        const v2693: bigint = v2692 + 1n;
        const v2694: bigint = v2693 + 1n;
        const v2695: bigint = v2694 + 1n;
        const v2696: bigint = v2695 + 1n;
        const v2697: bigint = 0n + 1n;
        const v2698: bigint = v2697 + 1n;
        const v2699: bigint = v2698 + 1n;
        const v2700: bigint = v2699 + 1n;
        const v2701: bigint = v2700 + 1n;
        const v2702: boolean = v2696 === v2701;
        let v2703: bigint;
        if (v2702) {
            v2703 = 0n;
        } else {
            v2703 = 1n;
        }
        const v2704: bigint = BigInt.asIntN(64, v2688 + v2696);
        const v2705: bigint = BigInt.asIntN(64, v2689 + v2701);
        const v2706: bigint = BigInt.asIntN(64, v2691 + v2703);
        const v2707: bigint = BigInt.asIntN(64, v2681 + v2704);
        const v2708: bigint = BigInt.asIntN(64, v2685 + v2705);
        const v2709: bigint = BigInt.asIntN(64, v2687 + v2706);
        const v2710: string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v2714 = US0_TypedFxHashedStatementChecksumValidationAccepted(1n, 3n, v2707, v2708, v2709, v2710);
    } else {
        const v2712: string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v2714 = US0_TypedFxHashedStatementChecksumValidationRejected(v2641, v2676, v2712);
    }
    let v2733: bigint;
    let v2734: bigint;
    let v2741: bigint;
    switch (v2714.tag) {
        case 0: {
            const v2718: bigint = v2714.f0;
            const v2719: bigint = v2714.f1;
            const v2720: bigint = v2714.f2;
            const v2721: bigint = v2714.f3;
            const v2722: bigint = v2714.f4;
            const v2723: string = v2714.f5;
            v2733 = 1n;
            v2734 = 0n;
            v2741 = v2722;
            break;
        }
        case 1: {
            const v2715: bigint = v2714.f0;
            const v2716: bigint = v2714.f1;
            const v2717: string = v2714.f2;
            v2733 = 0n;
            v2734 = 1n;
            v2741 = 0n;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v2742: bigint = 0n + 1n;
    const v2743: bigint = v2742 + 1n;
    const v2744: bigint = v2743 + 1n;
    const v2745: bigint = v2744 + 1n;
    const v2746: bigint = 0n + 1n;
    const v2747: bigint = v2746 + 1n;
    const v2748: bigint = v2747 + 1n;
    const v2749: bigint = v2748 + 1n;
    const v2750: boolean = v2745 === v2749;
    let v2751: bigint;
    if (v2750) {
        v2751 = 0n;
    } else {
        v2751 = 1n;
    }
    const v2752: bigint = 0n + 1n;
    const v2753: bigint = 0n + 1n;
    const v2754: boolean = v2752 === v2753;
    let v2755: bigint;
    if (v2754) {
        v2755 = 0n;
    } else {
        v2755 = 1n;
    }
    const v2756: bigint = 0n + 1n;
    const v2757: bigint = v2756 + 1n;
    const v2758: bigint = v2757 + 1n;
    const v2759: bigint = v2758 + 1n;
    const v2760: bigint = v2759 + 1n;
    const v2761: bigint = 0n + 1n;
    const v2762: bigint = v2761 + 1n;
    const v2763: bigint = v2762 + 1n;
    const v2764: bigint = v2763 + 1n;
    const v2765: bigint = v2764 + 1n;
    const v2766: boolean = v2760 === v2765;
    let v2767: bigint;
    if (v2766) {
        v2767 = 0n;
    } else {
        v2767 = 1n;
    }
    const v2770: bigint = BigInt.asIntN(64, v2755 + v2767);
    const v2773: bigint = BigInt.asIntN(64, v2751 + v2770);
    const v2774: bigint = 0n + 1n;
    const v2775: bigint = v2774 + 1n;
    const v2776: bigint = v2775 + 1n;
    const v2777: bigint = v2776 + 1n;
    const v2778: bigint = 0n + 1n;
    const v2779: bigint = v2778 + 1n;
    const v2780: bigint = v2779 + 1n;
    const v2781: bigint = v2780 + 1n;
    const v2782: boolean = v2777 === v2781;
    let v2783: bigint;
    if (v2782) {
        v2783 = 0n;
    } else {
        v2783 = 1n;
    }
    const v2784: bigint = 0n + 1n;
    const v2785: bigint = 0n + 1n;
    const v2786: boolean = v2784 === v2785;
    let v2787: bigint;
    if (v2786) {
        v2787 = 0n;
    } else {
        v2787 = 1n;
    }
    const v2788: bigint = 0n + 1n;
    const v2789: bigint = v2788 + 1n;
    const v2790: bigint = v2789 + 1n;
    const v2791: bigint = v2790 + 1n;
    const v2792: bigint = v2791 + 1n;
    const v2793: bigint = 0n + 1n;
    const v2794: bigint = v2793 + 1n;
    const v2795: bigint = v2794 + 1n;
    const v2796: bigint = v2795 + 1n;
    const v2797: bigint = v2796 + 1n;
    const v2798: boolean = v2792 === v2797;
    let v2799: bigint;
    if (v2798) {
        v2799 = 0n;
    } else {
        v2799 = 1n;
    }
    const v2802: bigint = BigInt.asIntN(64, v2787 + v2799);
    const v2805: bigint = BigInt.asIntN(64, v2783 + v2802);
    const v2806: bigint = BigInt.asIntN(64, v2773 + v2805);
    const v2807: bigint = BigInt.asIntN(64, v2741 + v2734);
    const v2808: bigint = BigInt.asIntN(64, v2806 + v2807);
    const v2809: bigint = BigInt.asIntN(64, v2606 + v2808);
    const v2810: boolean = v2733 === 1n;
    const v2811: boolean = v2809 === 0n;
    const v2812: boolean = v2810 && v2811;
    if (v2812) {
    } else {
        throw new Error("typed-FX-statement-indexed-durable-commit-runtime-mismatch");
    }
    const v2813: bigint = 0n + 1n;
    const v2814: bigint = v2813 + 1n;
    const v2815: bigint = v2814 + 1n;
    const v2816: bigint = v2815 + 1n;
    const v2817: bigint = 0n + 1n;
    const v2818: bigint = v2817 + 1n;
    const v2819: bigint = v2818 + 1n;
    const v2820: bigint = v2819 + 1n;
    const v2821: boolean = v2816 === v2820;
    let v2822: bigint;
    if (v2821) {
        v2822 = 0n;
    } else {
        v2822 = 1n;
    }
    const v2823: bigint = 0n + 1n;
    const v2824: bigint = 0n + 1n;
    const v2825: boolean = v2823 === v2824;
    let v2826: bigint;
    if (v2825) {
        v2826 = 0n;
    } else {
        v2826 = 1n;
    }
    const v2827: bigint = 0n + 1n;
    const v2828: bigint = v2827 + 1n;
    const v2829: bigint = v2828 + 1n;
    const v2830: bigint = v2829 + 1n;
    const v2831: bigint = v2830 + 1n;
    const v2832: bigint = 0n + 1n;
    const v2833: bigint = v2832 + 1n;
    const v2834: bigint = v2833 + 1n;
    const v2835: bigint = v2834 + 1n;
    const v2836: bigint = v2835 + 1n;
    const v2837: boolean = v2831 === v2836;
    let v2838: bigint;
    if (v2837) {
        v2838 = 0n;
    } else {
        v2838 = 1n;
    }
    const v2839: bigint = BigInt.asIntN(64, v2823 + v2831);
    const v2840: bigint = BigInt.asIntN(64, v2824 + v2836);
    const v2841: bigint = BigInt.asIntN(64, v2826 + v2838);
    const v2842: bigint = BigInt.asIntN(64, v2816 + v2839);
    const v2843: bigint = BigInt.asIntN(64, v2820 + v2840);
    const v2844: bigint = BigInt.asIntN(64, v2822 + v2841);
    const v2845: bigint = 0n + 1n;
    const v2846: bigint = v2845 + 1n;
    const v2847: bigint = v2846 + 1n;
    const v2848: bigint = v2847 + 1n;
    const v2849: bigint = 0n + 1n;
    const v2850: bigint = v2849 + 1n;
    const v2851: bigint = v2850 + 1n;
    const v2852: bigint = v2851 + 1n;
    const v2853: boolean = v2848 === v2852;
    let v2854: bigint;
    if (v2853) {
        v2854 = 0n;
    } else {
        v2854 = 1n;
    }
    const v2855: bigint = 0n + 1n;
    const v2856: bigint = 0n + 1n;
    const v2857: boolean = v2855 === v2856;
    let v2858: bigint;
    if (v2857) {
        v2858 = 0n;
    } else {
        v2858 = 1n;
    }
    const v2859: bigint = 0n + 1n;
    const v2860: bigint = v2859 + 1n;
    const v2861: bigint = v2860 + 1n;
    const v2862: bigint = v2861 + 1n;
    const v2863: bigint = v2862 + 1n;
    const v2864: bigint = 0n + 1n;
    const v2865: bigint = v2864 + 1n;
    const v2866: bigint = v2865 + 1n;
    const v2867: bigint = v2866 + 1n;
    const v2868: bigint = v2867 + 1n;
    const v2869: boolean = v2863 === v2868;
    let v2870: bigint;
    if (v2869) {
        v2870 = 0n;
    } else {
        v2870 = 1n;
    }
    const v2871: bigint = BigInt.asIntN(64, v2855 + v2863);
    const v2872: bigint = BigInt.asIntN(64, v2856 + v2868);
    const v2873: bigint = BigInt.asIntN(64, v2858 + v2870);
    const v2874: bigint = BigInt.asIntN(64, v2848 + v2871);
    const v2875: bigint = BigInt.asIntN(64, v2852 + v2872);
    const v2876: bigint = BigInt.asIntN(64, v2854 + v2873);
    const v2877: bigint = 0n + 1n;
    const v2878: bigint = v2877 + 1n;
    const v2879: bigint = v2878 + 1n;
    const v2880: bigint = v2879 + 1n;
    const v2881: bigint = 0n + 1n;
    const v2882: bigint = v2881 + 1n;
    const v2883: bigint = v2882 + 1n;
    const v2884: bigint = v2883 + 1n;
    const v2885: boolean = v2880 === v2884;
    let v2886: bigint;
    if (v2885) {
        v2886 = 0n;
    } else {
        v2886 = 1n;
    }
    const v2887: bigint = 0n + 1n;
    const v2888: bigint = 0n + 1n;
    const v2889: boolean = v2887 === v2888;
    let v2890: bigint;
    if (v2889) {
        v2890 = 0n;
    } else {
        v2890 = 1n;
    }
    const v2891: bigint = 0n + 1n;
    const v2892: bigint = v2891 + 1n;
    const v2893: bigint = v2892 + 1n;
    const v2894: bigint = v2893 + 1n;
    const v2895: bigint = v2894 + 1n;
    const v2896: bigint = 0n + 1n;
    const v2897: bigint = v2896 + 1n;
    const v2898: bigint = v2897 + 1n;
    const v2899: bigint = v2898 + 1n;
    const v2900: bigint = v2899 + 1n;
    const v2901: boolean = v2895 === v2900;
    let v2902: bigint;
    if (v2901) {
        v2902 = 0n;
    } else {
        v2902 = 1n;
    }
    const v2903: bigint = BigInt.asIntN(64, v2887 + v2895);
    const v2904: bigint = BigInt.asIntN(64, v2888 + v2900);
    const v2905: bigint = BigInt.asIntN(64, v2890 + v2902);
    const v2906: bigint = BigInt.asIntN(64, v2880 + v2903);
    const v2907: bigint = BigInt.asIntN(64, v2884 + v2904);
    const v2908: bigint = BigInt.asIntN(64, v2886 + v2905);
    const v2909: bigint = 0n + 1n;
    const v2910: bigint = v2909 + 1n;
    const v2911: bigint = v2910 + 1n;
    const v2912: bigint = v2911 + 1n;
    const v2913: bigint = 0n + 1n;
    const v2914: bigint = v2913 + 1n;
    const v2915: bigint = v2914 + 1n;
    const v2916: bigint = v2915 + 1n;
    const v2917: boolean = v2912 === v2916;
    let v2918: bigint;
    if (v2917) {
        v2918 = 0n;
    } else {
        v2918 = 1n;
    }
    const v2919: bigint = 0n + 1n;
    const v2920: bigint = 0n + 1n;
    const v2921: boolean = v2919 === v2920;
    let v2922: bigint;
    if (v2921) {
        v2922 = 0n;
    } else {
        v2922 = 1n;
    }
    const v2923: bigint = 0n + 1n;
    const v2924: bigint = v2923 + 1n;
    const v2925: bigint = v2924 + 1n;
    const v2926: bigint = v2925 + 1n;
    const v2927: bigint = v2926 + 1n;
    const v2928: bigint = 0n + 1n;
    const v2929: bigint = v2928 + 1n;
    const v2930: bigint = v2929 + 1n;
    const v2931: bigint = v2930 + 1n;
    const v2932: bigint = v2931 + 1n;
    const v2933: boolean = v2927 === v2932;
    let v2934: bigint;
    if (v2933) {
        v2934 = 0n;
    } else {
        v2934 = 1n;
    }
    const v2935: bigint = BigInt.asIntN(64, v2919 + v2927);
    const v2936: bigint = BigInt.asIntN(64, v2920 + v2932);
    const v2937: bigint = BigInt.asIntN(64, v2922 + v2934);
    const v2938: bigint = BigInt.asIntN(64, v2912 + v2935);
    const v2939: bigint = BigInt.asIntN(64, v2916 + v2936);
    const v2940: bigint = BigInt.asIntN(64, v2918 + v2937);
    const v2941: bigint = BigInt.asIntN(64, v2906 + v2938);
    const v2942: bigint = BigInt.asIntN(64, v2907 + v2939);
    const v2943: bigint = BigInt.asIntN(64, v2908 + v2940);
    const v2944: bigint = BigInt.asIntN(64, v2874 + v2941);
    const v2945: bigint = BigInt.asIntN(64, v2875 + v2942);
    const v2946: bigint = BigInt.asIntN(64, v2876 + v2943);
    const v2947: bigint = BigInt.asIntN(64, v2842 + v2944);
    const v2948: bigint = BigInt.asIntN(64, v2843 + v2945);
    const v2949: bigint = BigInt.asIntN(64, v2844 + v2946);
    const v2950: boolean = v2947 === 40n;
    const v2951: boolean = v2948 === 40n;
    const v2952: boolean = v2949 === 0n;
    const v2953: boolean = v2950 && v2951;
    const v2954: boolean = v2953 && v2952;
    if (v2954) {
    } else {
        throw new Error("typed-FX-hashed-statement-event-store-decision-runtime-mismatch");
    }
    const v2955: bigint = 0n + 1n;
    const v2956: bigint = v2955 + 1n;
    const v2957: bigint = v2956 + 1n;
    const v2958: bigint = v2957 + 1n;
    const v2959: bigint = 0n + 1n;
    const v2960: bigint = v2959 + 1n;
    const v2961: bigint = v2960 + 1n;
    const v2962: bigint = v2961 + 1n;
    const v2963: boolean = v2958 === v2962;
    let v2964: bigint;
    if (v2963) {
        v2964 = 0n;
    } else {
        v2964 = 1n;
    }
    const v2965: bigint = 0n + 1n;
    const v2966: bigint = 0n + 1n;
    const v2967: boolean = v2965 === v2966;
    let v2968: bigint;
    if (v2967) {
        v2968 = 0n;
    } else {
        v2968 = 1n;
    }
    const v2969: bigint = 0n + 1n;
    const v2970: bigint = v2969 + 1n;
    const v2971: bigint = v2970 + 1n;
    const v2972: bigint = v2971 + 1n;
    const v2973: bigint = v2972 + 1n;
    const v2974: bigint = 0n + 1n;
    const v2975: bigint = v2974 + 1n;
    const v2976: bigint = v2975 + 1n;
    const v2977: bigint = v2976 + 1n;
    const v2978: bigint = v2977 + 1n;
    const v2979: boolean = v2973 === v2978;
    let v2980: bigint;
    if (v2979) {
        v2980 = 0n;
    } else {
        v2980 = 1n;
    }
    const v2983: bigint = BigInt.asIntN(64, v2968 + v2980);
    const v2986: bigint = BigInt.asIntN(64, v2964 + v2983);
    const v2987: bigint = 0n + 1n;
    const v2988: bigint = v2987 + 1n;
    const v2989: bigint = v2988 + 1n;
    const v2990: bigint = v2989 + 1n;
    const v2991: bigint = 0n + 1n;
    const v2992: bigint = v2991 + 1n;
    const v2993: bigint = v2992 + 1n;
    const v2994: bigint = v2993 + 1n;
    const v2995: boolean = v2990 === v2994;
    let v2996: bigint;
    if (v2995) {
        v2996 = 0n;
    } else {
        v2996 = 1n;
    }
    const v2997: bigint = 0n + 1n;
    const v2998: bigint = 0n + 1n;
    const v2999: boolean = v2997 === v2998;
    let v3000: bigint;
    if (v2999) {
        v3000 = 0n;
    } else {
        v3000 = 1n;
    }
    const v3001: bigint = 0n + 1n;
    const v3002: bigint = v3001 + 1n;
    const v3003: bigint = v3002 + 1n;
    const v3004: bigint = v3003 + 1n;
    const v3005: bigint = v3004 + 1n;
    const v3006: bigint = 0n + 1n;
    const v3007: bigint = v3006 + 1n;
    const v3008: bigint = v3007 + 1n;
    const v3009: bigint = v3008 + 1n;
    const v3010: bigint = v3009 + 1n;
    const v3011: boolean = v3005 === v3010;
    let v3012: bigint;
    if (v3011) {
        v3012 = 0n;
    } else {
        v3012 = 1n;
    }
    const v3015: bigint = BigInt.asIntN(64, v3000 + v3012);
    const v3018: bigint = BigInt.asIntN(64, v2996 + v3015);
    const v3021: bigint = BigInt.asIntN(64, v3018 + v2986);
    const v3022: bigint = 0n + 1n;
    const v3023: bigint = v3022 + 1n;
    const v3024: bigint = v3023 + 1n;
    const v3025: bigint = v3024 + 1n;
    const v3026: bigint = 0n + 1n;
    const v3027: bigint = v3026 + 1n;
    const v3028: bigint = v3027 + 1n;
    const v3029: bigint = v3028 + 1n;
    const v3030: boolean = v3025 === v3029;
    let v3031: bigint;
    if (v3030) {
        v3031 = 0n;
    } else {
        v3031 = 1n;
    }
    const v3032: bigint = 0n + 1n;
    const v3033: bigint = 0n + 1n;
    const v3034: boolean = v3032 === v3033;
    let v3035: bigint;
    if (v3034) {
        v3035 = 0n;
    } else {
        v3035 = 1n;
    }
    const v3036: bigint = 0n + 1n;
    const v3037: bigint = v3036 + 1n;
    const v3038: bigint = v3037 + 1n;
    const v3039: bigint = v3038 + 1n;
    const v3040: bigint = v3039 + 1n;
    const v3041: bigint = 0n + 1n;
    const v3042: bigint = v3041 + 1n;
    const v3043: bigint = v3042 + 1n;
    const v3044: bigint = v3043 + 1n;
    const v3045: bigint = v3044 + 1n;
    const v3046: boolean = v3040 === v3045;
    let v3047: bigint;
    if (v3046) {
        v3047 = 0n;
    } else {
        v3047 = 1n;
    }
    const v3050: bigint = BigInt.asIntN(64, v3035 + v3047);
    const v3053: bigint = BigInt.asIntN(64, v3031 + v3050);
    const v3054: bigint = 0n + 1n;
    const v3055: bigint = v3054 + 1n;
    const v3056: bigint = v3055 + 1n;
    const v3057: bigint = v3056 + 1n;
    const v3058: bigint = 0n + 1n;
    const v3059: bigint = v3058 + 1n;
    const v3060: bigint = v3059 + 1n;
    const v3061: bigint = v3060 + 1n;
    const v3062: boolean = v3057 === v3061;
    let v3063: bigint;
    if (v3062) {
        v3063 = 0n;
    } else {
        v3063 = 1n;
    }
    const v3064: bigint = 0n + 1n;
    const v3065: bigint = 0n + 1n;
    const v3066: boolean = v3064 === v3065;
    let v3067: bigint;
    if (v3066) {
        v3067 = 0n;
    } else {
        v3067 = 1n;
    }
    const v3068: bigint = 0n + 1n;
    const v3069: bigint = v3068 + 1n;
    const v3070: bigint = v3069 + 1n;
    const v3071: bigint = v3070 + 1n;
    const v3072: bigint = v3071 + 1n;
    const v3073: bigint = 0n + 1n;
    const v3074: bigint = v3073 + 1n;
    const v3075: bigint = v3074 + 1n;
    const v3076: bigint = v3075 + 1n;
    const v3077: bigint = v3076 + 1n;
    const v3078: boolean = v3072 === v3077;
    let v3079: bigint;
    if (v3078) {
        v3079 = 0n;
    } else {
        v3079 = 1n;
    }
    const v3082: bigint = BigInt.asIntN(64, v3067 + v3079);
    const v3085: bigint = BigInt.asIntN(64, v3063 + v3082);
    const v3088: bigint = BigInt.asIntN(64, v3085 + v3053);
    const v3089: bigint = BigInt.asIntN(64, v3021 + v3088);
    const v3090: boolean = v3089 === 0n;
    if (v3090) {
    } else {
        throw new Error("typed-FX-hashed-statement-proven-retry-runtime-mismatch");
    }
    const v3091: bigint = 0n + 1n;
    const v3092: bigint = v3091 + 1n;
    const v3093: bigint = v3092 + 1n;
    const v3094: bigint = v3093 + 1n;
    const v3095: bigint = 0n + 1n;
    const v3096: bigint = v3095 + 1n;
    const v3097: bigint = v3096 + 1n;
    const v3098: bigint = v3097 + 1n;
    const v3099: boolean = v3094 === v3098;
    let v3100: bigint;
    if (v3099) {
        v3100 = 0n;
    } else {
        v3100 = 1n;
    }
    const v3101: bigint = 0n + 1n;
    const v3102: bigint = 0n + 1n;
    const v3103: boolean = v3101 === v3102;
    let v3104: bigint;
    if (v3103) {
        v3104 = 0n;
    } else {
        v3104 = 1n;
    }
    const v3105: bigint = 0n + 1n;
    const v3106: bigint = v3105 + 1n;
    const v3107: bigint = v3106 + 1n;
    const v3108: bigint = v3107 + 1n;
    const v3109: bigint = v3108 + 1n;
    const v3110: bigint = 0n + 1n;
    const v3111: bigint = v3110 + 1n;
    const v3112: bigint = v3111 + 1n;
    const v3113: bigint = v3112 + 1n;
    const v3114: bigint = v3113 + 1n;
    const v3115: boolean = v3109 === v3114;
    let v3116: bigint;
    if (v3115) {
        v3116 = 0n;
    } else {
        v3116 = 1n;
    }
    const v3117: bigint = BigInt.asIntN(64, v3101 + v3109);
    const v3118: bigint = BigInt.asIntN(64, v3102 + v3114);
    const v3119: bigint = BigInt.asIntN(64, v3104 + v3116);
    const v3120: bigint = BigInt.asIntN(64, v3094 + v3117);
    const v3121: bigint = BigInt.asIntN(64, v3098 + v3118);
    const v3122: bigint = BigInt.asIntN(64, v3100 + v3119);
    const v3123: bigint = 0n + 1n;
    const v3124: bigint = v3123 + 1n;
    const v3125: bigint = v3124 + 1n;
    const v3126: bigint = v3125 + 1n;
    const v3127: bigint = 0n + 1n;
    const v3128: bigint = v3127 + 1n;
    const v3129: bigint = v3128 + 1n;
    const v3130: bigint = v3129 + 1n;
    const v3131: boolean = v3126 === v3130;
    let v3132: bigint;
    if (v3131) {
        v3132 = 0n;
    } else {
        v3132 = 1n;
    }
    const v3133: bigint = 0n + 1n;
    const v3134: bigint = 0n + 1n;
    const v3135: boolean = v3133 === v3134;
    let v3136: bigint;
    if (v3135) {
        v3136 = 0n;
    } else {
        v3136 = 1n;
    }
    const v3137: bigint = 0n + 1n;
    const v3138: bigint = v3137 + 1n;
    const v3139: bigint = v3138 + 1n;
    const v3140: bigint = v3139 + 1n;
    const v3141: bigint = v3140 + 1n;
    const v3142: bigint = 0n + 1n;
    const v3143: bigint = v3142 + 1n;
    const v3144: bigint = v3143 + 1n;
    const v3145: bigint = v3144 + 1n;
    const v3146: bigint = v3145 + 1n;
    const v3147: boolean = v3141 === v3146;
    let v3148: bigint;
    if (v3147) {
        v3148 = 0n;
    } else {
        v3148 = 1n;
    }
    const v3149: bigint = BigInt.asIntN(64, v3133 + v3141);
    const v3150: bigint = BigInt.asIntN(64, v3134 + v3146);
    const v3151: bigint = BigInt.asIntN(64, v3136 + v3148);
    const v3152: bigint = BigInt.asIntN(64, v3126 + v3149);
    const v3153: bigint = BigInt.asIntN(64, v3130 + v3150);
    const v3154: bigint = BigInt.asIntN(64, v3132 + v3151);
    const v3155: bigint = BigInt.asIntN(64, v3152 + v3120);
    const v3156: bigint = BigInt.asIntN(64, v3153 + v3121);
    const v3157: bigint = BigInt.asIntN(64, v3154 + v3122);
    const v3158: boolean = v3155 === 20n;
    const v3159: boolean = v3156 === 20n;
    const v3160: boolean = v3157 === 0n;
    const v3161: boolean = v3158 && v3159;
    const v3162: boolean = v3161 && v3160;
    if (v3162) {
    } else {
        throw new Error("typed-FX-hashed-statement-history-enumeration-runtime-mismatch");
    }
    const v3163: bigint = 0n + 1n;
    const v3164: bigint = v3163 + 1n;
    const v3165: bigint = v3164 + 1n;
    const v3166: bigint = v3165 + 1n;
    const v3167: bigint = 0n + 1n;
    const v3168: bigint = v3167 + 1n;
    const v3169: bigint = v3168 + 1n;
    const v3170: bigint = v3169 + 1n;
    const v3171: boolean = v3166 === v3170;
    let v3172: bigint;
    if (v3171) {
        v3172 = 0n;
    } else {
        v3172 = 1n;
    }
    const v3173: bigint = 0n + 1n;
    const v3174: bigint = 0n + 1n;
    const v3175: boolean = v3173 === v3174;
    let v3176: bigint;
    if (v3175) {
        v3176 = 0n;
    } else {
        v3176 = 1n;
    }
    const v3177: bigint = 0n + 1n;
    const v3178: bigint = v3177 + 1n;
    const v3179: bigint = v3178 + 1n;
    const v3180: bigint = v3179 + 1n;
    const v3181: bigint = v3180 + 1n;
    const v3182: bigint = 0n + 1n;
    const v3183: bigint = v3182 + 1n;
    const v3184: bigint = v3183 + 1n;
    const v3185: bigint = v3184 + 1n;
    const v3186: bigint = v3185 + 1n;
    const v3187: boolean = v3181 === v3186;
    let v3188: bigint;
    if (v3187) {
        v3188 = 0n;
    } else {
        v3188 = 1n;
    }
    const v3189: bigint = BigInt.asIntN(64, v3173 + v3181);
    const v3190: bigint = BigInt.asIntN(64, v3174 + v3186);
    const v3191: bigint = BigInt.asIntN(64, v3176 + v3188);
    const v3192: bigint = BigInt.asIntN(64, v3166 + v3189);
    const v3193: bigint = BigInt.asIntN(64, v3170 + v3190);
    const v3194: bigint = BigInt.asIntN(64, v3172 + v3191);
    const v3195: boolean = v3192 === 10n;
    const v3196: boolean = v3193 === 10n;
    const v3197: boolean = v3194 === 0n;
    const v3198: boolean = v3195 && v3196;
    const v3199: boolean = v3198 && v3197;
    if (v3199) {
    } else {
        throw new Error("typed-FX-hashed-statement-history-index-lookup-runtime-mismatch");
    }
    const v3200: bigint = 0n + 1n;
    const v3201: bigint = v3200 + 1n;
    const v3202: bigint = v3201 + 1n;
    const v3203: bigint = v3202 + 1n;
    const v3204: bigint = 0n + 1n;
    const v3205: bigint = v3204 + 1n;
    const v3206: bigint = v3205 + 1n;
    const v3207: bigint = v3206 + 1n;
    const v3208: boolean = v3203 === v3207;
    let v3209: bigint;
    if (v3208) {
        v3209 = 0n;
    } else {
        v3209 = 1n;
    }
    const v3210: bigint = 0n + 1n;
    const v3211: bigint = 0n + 1n;
    const v3212: boolean = v3210 === v3211;
    let v3213: bigint;
    if (v3212) {
        v3213 = 0n;
    } else {
        v3213 = 1n;
    }
    const v3214: bigint = 0n + 1n;
    const v3215: bigint = v3214 + 1n;
    const v3216: bigint = v3215 + 1n;
    const v3217: bigint = v3216 + 1n;
    const v3218: bigint = v3217 + 1n;
    const v3219: bigint = 0n + 1n;
    const v3220: bigint = v3219 + 1n;
    const v3221: bigint = v3220 + 1n;
    const v3222: bigint = v3221 + 1n;
    const v3223: bigint = v3222 + 1n;
    const v3224: boolean = v3218 === v3223;
    let v3225: bigint;
    if (v3224) {
        v3225 = 0n;
    } else {
        v3225 = 1n;
    }
    const v3226: bigint = BigInt.asIntN(64, v3210 + v3218);
    const v3227: bigint = BigInt.asIntN(64, v3211 + v3223);
    const v3228: bigint = BigInt.asIntN(64, v3213 + v3225);
    const v3229: bigint = BigInt.asIntN(64, v3203 + v3226);
    const v3230: bigint = BigInt.asIntN(64, v3207 + v3227);
    const v3231: bigint = BigInt.asIntN(64, v3209 + v3228);
    const v3232: bigint = 0n + 1n;
    const v3233: bigint = v3232 + 1n;
    const v3234: bigint = v3233 + 1n;
    const v3235: bigint = v3234 + 1n;
    const v3236: bigint = 0n + 1n;
    const v3237: bigint = v3236 + 1n;
    const v3238: bigint = v3237 + 1n;
    const v3239: bigint = v3238 + 1n;
    const v3240: boolean = v3235 === v3239;
    let v3241: bigint;
    if (v3240) {
        v3241 = 0n;
    } else {
        v3241 = 1n;
    }
    const v3242: bigint = 0n + 1n;
    const v3243: bigint = 0n + 1n;
    const v3244: boolean = v3242 === v3243;
    let v3245: bigint;
    if (v3244) {
        v3245 = 0n;
    } else {
        v3245 = 1n;
    }
    const v3246: bigint = 0n + 1n;
    const v3247: bigint = v3246 + 1n;
    const v3248: bigint = v3247 + 1n;
    const v3249: bigint = v3248 + 1n;
    const v3250: bigint = v3249 + 1n;
    const v3251: bigint = 0n + 1n;
    const v3252: bigint = v3251 + 1n;
    const v3253: bigint = v3252 + 1n;
    const v3254: bigint = v3253 + 1n;
    const v3255: bigint = v3254 + 1n;
    const v3256: boolean = v3250 === v3255;
    let v3257: bigint;
    if (v3256) {
        v3257 = 0n;
    } else {
        v3257 = 1n;
    }
    const v3258: bigint = BigInt.asIntN(64, v3242 + v3250);
    const v3259: bigint = BigInt.asIntN(64, v3243 + v3255);
    const v3260: bigint = BigInt.asIntN(64, v3245 + v3257);
    const v3261: bigint = BigInt.asIntN(64, v3235 + v3258);
    const v3262: bigint = BigInt.asIntN(64, v3239 + v3259);
    const v3263: bigint = BigInt.asIntN(64, v3241 + v3260);
    const v3264: boolean = v3229 === 10n;
    const v3265: boolean = v3230 === 10n;
    const v3266: boolean = v3231 === 0n;
    const v3267: boolean = v3261 === 10n;
    const v3268: boolean = v3262 === 10n;
    const v3269: boolean = v3263 === 0n;
    const v3270: boolean = v3264 && v3265;
    const v3271: boolean = v3270 && v3266;
    const v3272: boolean = v3271 && v3267;
    const v3273: boolean = v3272 && v3268;
    const v3274: boolean = v3273 && v3269;
    if (v3274) {
    } else {
        throw new Error("typed-FX-hashed-statement-identity-lookup-runtime-mismatch");
    }
    const v3275: bigint = 0n + 1n;
    const v3276: bigint = v3275 + 1n;
    const v3277: bigint = v3276 + 1n;
    const v3278: bigint = v3277 + 1n;
    const v3279: bigint = 0n + 1n;
    const v3280: bigint = v3279 + 1n;
    const v3281: bigint = v3280 + 1n;
    const v3282: bigint = v3281 + 1n;
    const v3283: boolean = v3278 === v3282;
    let v3284: bigint;
    if (v3283) {
        v3284 = 0n;
    } else {
        v3284 = 1n;
    }
    const v3285: bigint = 0n + 1n;
    const v3286: bigint = 0n + 1n;
    const v3287: boolean = v3285 === v3286;
    let v3288: bigint;
    if (v3287) {
        v3288 = 0n;
    } else {
        v3288 = 1n;
    }
    const v3289: bigint = 0n + 1n;
    const v3290: bigint = v3289 + 1n;
    const v3291: bigint = v3290 + 1n;
    const v3292: bigint = v3291 + 1n;
    const v3293: bigint = v3292 + 1n;
    const v3294: bigint = 0n + 1n;
    const v3295: bigint = v3294 + 1n;
    const v3296: bigint = v3295 + 1n;
    const v3297: bigint = v3296 + 1n;
    const v3298: bigint = v3297 + 1n;
    const v3299: boolean = v3293 === v3298;
    let v3300: bigint;
    if (v3299) {
        v3300 = 0n;
    } else {
        v3300 = 1n;
    }
    const v3301: bigint = BigInt.asIntN(64, v3285 + v3293);
    const v3302: bigint = BigInt.asIntN(64, v3286 + v3298);
    const v3303: bigint = BigInt.asIntN(64, v3288 + v3300);
    const v3304: bigint = BigInt.asIntN(64, v3278 + v3301);
    const v3305: bigint = BigInt.asIntN(64, v3282 + v3302);
    const v3306: bigint = BigInt.asIntN(64, v3284 + v3303);
    const v3307: bigint = 0n + 1n;
    const v3308: bigint = v3307 + 1n;
    const v3309: bigint = v3308 + 1n;
    const v3310: bigint = v3309 + 1n;
    const v3311: bigint = 0n + 1n;
    const v3312: bigint = v3311 + 1n;
    const v3313: bigint = v3312 + 1n;
    const v3314: bigint = v3313 + 1n;
    const v3315: boolean = v3310 === v3314;
    let v3316: bigint;
    if (v3315) {
        v3316 = 0n;
    } else {
        v3316 = 1n;
    }
    const v3317: bigint = 0n + 1n;
    const v3318: bigint = 0n + 1n;
    const v3319: boolean = v3317 === v3318;
    let v3320: bigint;
    if (v3319) {
        v3320 = 0n;
    } else {
        v3320 = 1n;
    }
    const v3321: bigint = 0n + 1n;
    const v3322: bigint = v3321 + 1n;
    const v3323: bigint = v3322 + 1n;
    const v3324: bigint = v3323 + 1n;
    const v3325: bigint = v3324 + 1n;
    const v3326: bigint = 0n + 1n;
    const v3327: bigint = v3326 + 1n;
    const v3328: bigint = v3327 + 1n;
    const v3329: bigint = v3328 + 1n;
    const v3330: bigint = v3329 + 1n;
    const v3331: boolean = v3325 === v3330;
    let v3332: bigint;
    if (v3331) {
        v3332 = 0n;
    } else {
        v3332 = 1n;
    }
    const v3333: bigint = BigInt.asIntN(64, v3317 + v3325);
    const v3334: bigint = BigInt.asIntN(64, v3318 + v3330);
    const v3335: bigint = BigInt.asIntN(64, v3320 + v3332);
    const v3336: bigint = BigInt.asIntN(64, v3310 + v3333);
    const v3337: bigint = BigInt.asIntN(64, v3314 + v3334);
    const v3338: bigint = BigInt.asIntN(64, v3316 + v3335);
    const v3339: bigint = BigInt.asIntN(64, v3304 + v3336);
    const v3340: bigint = BigInt.asIntN(64, v3305 + v3337);
    const v3341: bigint = BigInt.asIntN(64, v3306 + v3338);
    const v3342: boolean = v3339 === 20n;
    const v3343: boolean = v3340 === 20n;
    const v3344: boolean = v3341 === 0n;
    const v3345: boolean = v3342 && v3343;
    const v3346: boolean = v3345 && v3344;
    if (v3346) {
    } else {
        throw new Error("typed-FX-hashed-statement-membership-lookup-program-runtime-mismatch");
    }
    const v3347: bigint = 0n + 1n;
    const v3348: bigint = v3347 + 1n;
    const v3349: bigint = v3348 + 1n;
    const v3350: bigint = v3349 + 1n;
    const v3351: bigint = 0n + 1n;
    const v3352: bigint = v3351 + 1n;
    const v3353: bigint = v3352 + 1n;
    const v3354: bigint = v3353 + 1n;
    const v3355: boolean = v3350 === v3354;
    let v3356: bigint;
    if (v3355) {
        v3356 = 0n;
    } else {
        v3356 = 1n;
    }
    const v3357: bigint = 0n + 1n;
    const v3358: bigint = 0n + 1n;
    const v3359: boolean = v3357 === v3358;
    let v3360: bigint;
    if (v3359) {
        v3360 = 0n;
    } else {
        v3360 = 1n;
    }
    const v3361: bigint = 0n + 1n;
    const v3362: bigint = v3361 + 1n;
    const v3363: bigint = v3362 + 1n;
    const v3364: bigint = v3363 + 1n;
    const v3365: bigint = v3364 + 1n;
    const v3366: bigint = 0n + 1n;
    const v3367: bigint = v3366 + 1n;
    const v3368: bigint = v3367 + 1n;
    const v3369: bigint = v3368 + 1n;
    const v3370: bigint = v3369 + 1n;
    const v3371: boolean = v3365 === v3370;
    let v3372: bigint;
    if (v3371) {
        v3372 = 0n;
    } else {
        v3372 = 1n;
    }
    const v3373: bigint = BigInt.asIntN(64, v3357 + v3365);
    const v3374: bigint = BigInt.asIntN(64, v3358 + v3370);
    const v3375: bigint = BigInt.asIntN(64, v3360 + v3372);
    const v3376: bigint = BigInt.asIntN(64, v3350 + v3373);
    const v3377: bigint = BigInt.asIntN(64, v3354 + v3374);
    const v3378: bigint = BigInt.asIntN(64, v3356 + v3375);
    const v3379: bigint = 0n + 1n;
    const v3380: bigint = v3379 + 1n;
    const v3381: bigint = v3380 + 1n;
    const v3382: bigint = v3381 + 1n;
    const v3383: bigint = 0n + 1n;
    const v3384: bigint = v3383 + 1n;
    const v3385: bigint = v3384 + 1n;
    const v3386: bigint = v3385 + 1n;
    const v3387: boolean = v3382 === v3386;
    let v3388: bigint;
    if (v3387) {
        v3388 = 0n;
    } else {
        v3388 = 1n;
    }
    const v3389: bigint = 0n + 1n;
    const v3390: bigint = 0n + 1n;
    const v3391: boolean = v3389 === v3390;
    let v3392: bigint;
    if (v3391) {
        v3392 = 0n;
    } else {
        v3392 = 1n;
    }
    const v3393: bigint = 0n + 1n;
    const v3394: bigint = v3393 + 1n;
    const v3395: bigint = v3394 + 1n;
    const v3396: bigint = v3395 + 1n;
    const v3397: bigint = v3396 + 1n;
    const v3398: bigint = 0n + 1n;
    const v3399: bigint = v3398 + 1n;
    const v3400: bigint = v3399 + 1n;
    const v3401: bigint = v3400 + 1n;
    const v3402: bigint = v3401 + 1n;
    const v3403: boolean = v3397 === v3402;
    let v3404: bigint;
    if (v3403) {
        v3404 = 0n;
    } else {
        v3404 = 1n;
    }
    const v3405: bigint = BigInt.asIntN(64, v3389 + v3397);
    const v3406: bigint = BigInt.asIntN(64, v3390 + v3402);
    const v3407: bigint = BigInt.asIntN(64, v3392 + v3404);
    const v3408: bigint = BigInt.asIntN(64, v3382 + v3405);
    const v3409: bigint = BigInt.asIntN(64, v3386 + v3406);
    const v3410: bigint = BigInt.asIntN(64, v3388 + v3407);
    const v3411: bigint = BigInt.asIntN(64, v3376 + v3408);
    const v3412: bigint = BigInt.asIntN(64, v3377 + v3409);
    const v3413: bigint = BigInt.asIntN(64, v3378 + v3410);
    const v3414: bigint = 0n + 1n;
    const v3415: bigint = v3414 + 1n;
    const v3416: bigint = v3415 + 1n;
    const v3417: bigint = v3416 + 1n;
    const v3418: bigint = 0n + 1n;
    const v3419: bigint = v3418 + 1n;
    const v3420: bigint = v3419 + 1n;
    const v3421: bigint = v3420 + 1n;
    const v3422: boolean = v3417 === v3421;
    let v3423: bigint;
    if (v3422) {
        v3423 = 0n;
    } else {
        v3423 = 1n;
    }
    const v3424: bigint = 0n + 1n;
    const v3425: bigint = 0n + 1n;
    const v3426: boolean = v3424 === v3425;
    let v3427: bigint;
    if (v3426) {
        v3427 = 0n;
    } else {
        v3427 = 1n;
    }
    const v3428: bigint = 0n + 1n;
    const v3429: bigint = v3428 + 1n;
    const v3430: bigint = v3429 + 1n;
    const v3431: bigint = v3430 + 1n;
    const v3432: bigint = v3431 + 1n;
    const v3433: bigint = 0n + 1n;
    const v3434: bigint = v3433 + 1n;
    const v3435: bigint = v3434 + 1n;
    const v3436: bigint = v3435 + 1n;
    const v3437: bigint = v3436 + 1n;
    const v3438: boolean = v3432 === v3437;
    let v3439: bigint;
    if (v3438) {
        v3439 = 0n;
    } else {
        v3439 = 1n;
    }
    const v3440: bigint = BigInt.asIntN(64, v3424 + v3432);
    const v3441: bigint = BigInt.asIntN(64, v3425 + v3437);
    const v3442: bigint = BigInt.asIntN(64, v3427 + v3439);
    const v3443: bigint = BigInt.asIntN(64, v3417 + v3440);
    const v3444: bigint = BigInt.asIntN(64, v3421 + v3441);
    const v3445: bigint = BigInt.asIntN(64, v3423 + v3442);
    const v3446: bigint = 0n + 1n;
    const v3447: bigint = v3446 + 1n;
    const v3448: bigint = v3447 + 1n;
    const v3449: bigint = v3448 + 1n;
    const v3450: bigint = 0n + 1n;
    const v3451: bigint = v3450 + 1n;
    const v3452: bigint = v3451 + 1n;
    const v3453: bigint = v3452 + 1n;
    const v3454: boolean = v3449 === v3453;
    let v3455: bigint;
    if (v3454) {
        v3455 = 0n;
    } else {
        v3455 = 1n;
    }
    const v3456: bigint = 0n + 1n;
    const v3457: bigint = 0n + 1n;
    const v3458: boolean = v3456 === v3457;
    let v3459: bigint;
    if (v3458) {
        v3459 = 0n;
    } else {
        v3459 = 1n;
    }
    const v3460: bigint = 0n + 1n;
    const v3461: bigint = v3460 + 1n;
    const v3462: bigint = v3461 + 1n;
    const v3463: bigint = v3462 + 1n;
    const v3464: bigint = v3463 + 1n;
    const v3465: bigint = 0n + 1n;
    const v3466: bigint = v3465 + 1n;
    const v3467: bigint = v3466 + 1n;
    const v3468: bigint = v3467 + 1n;
    const v3469: bigint = v3468 + 1n;
    const v3470: boolean = v3464 === v3469;
    let v3471: bigint;
    if (v3470) {
        v3471 = 0n;
    } else {
        v3471 = 1n;
    }
    const v3472: bigint = BigInt.asIntN(64, v3456 + v3464);
    const v3473: bigint = BigInt.asIntN(64, v3457 + v3469);
    const v3474: bigint = BigInt.asIntN(64, v3459 + v3471);
    const v3475: bigint = BigInt.asIntN(64, v3449 + v3472);
    const v3476: bigint = BigInt.asIntN(64, v3453 + v3473);
    const v3477: bigint = BigInt.asIntN(64, v3455 + v3474);
    const v3478: bigint = BigInt.asIntN(64, v3443 + v3475);
    const v3479: boolean = v3411 === v3478;
    const v3480: bigint = BigInt.asIntN(64, v3444 + v3476);
    const v3481: boolean = v3412 === v3480;
    const v3482: bigint = BigInt.asIntN(64, v3445 + v3477);
    const v3483: boolean = v3413 === v3482;
    const v3484: boolean = v3479 && v3481;
    const v3485: boolean = v3484 && v3483;
    if (v3485) {
    } else {
        throw new Error("typed-FX-hashed-statement-membership-lookup-program-append-runtime-mismatch");
    }
    const v3486: bigint = 0n + 1n;
    const v3487: bigint = v3486 + 1n;
    const v3488: bigint = v3487 + 1n;
    const v3489: bigint = v3488 + 1n;
    const v3490: bigint = 0n + 1n;
    const v3491: bigint = v3490 + 1n;
    const v3492: bigint = v3491 + 1n;
    const v3493: bigint = v3492 + 1n;
    const v3494: boolean = v3489 === v3493;
    let v3495: bigint;
    if (v3494) {
        v3495 = 0n;
    } else {
        v3495 = 1n;
    }
    const v3496: bigint = 0n + 1n;
    const v3497: bigint = 0n + 1n;
    const v3498: boolean = v3496 === v3497;
    let v3499: bigint;
    if (v3498) {
        v3499 = 0n;
    } else {
        v3499 = 1n;
    }
    const v3500: bigint = 0n + 1n;
    const v3501: bigint = v3500 + 1n;
    const v3502: bigint = v3501 + 1n;
    const v3503: bigint = v3502 + 1n;
    const v3504: bigint = v3503 + 1n;
    const v3505: bigint = 0n + 1n;
    const v3506: bigint = v3505 + 1n;
    const v3507: bigint = v3506 + 1n;
    const v3508: bigint = v3507 + 1n;
    const v3509: bigint = v3508 + 1n;
    const v3510: boolean = v3504 === v3509;
    let v3511: bigint;
    if (v3510) {
        v3511 = 0n;
    } else {
        v3511 = 1n;
    }
    const v3512: bigint = BigInt.asIntN(64, v3496 + v3504);
    const v3513: bigint = BigInt.asIntN(64, v3497 + v3509);
    const v3514: bigint = BigInt.asIntN(64, v3499 + v3511);
    const v3515: bigint = BigInt.asIntN(64, v3489 + v3512);
    const v3516: bigint = BigInt.asIntN(64, v3493 + v3513);
    const v3517: bigint = BigInt.asIntN(64, v3495 + v3514);
    const v3518: bigint = 0n + 1n;
    const v3519: bigint = v3518 + 1n;
    const v3520: bigint = v3519 + 1n;
    const v3521: bigint = v3520 + 1n;
    const v3522: bigint = 0n + 1n;
    const v3523: bigint = v3522 + 1n;
    const v3524: bigint = v3523 + 1n;
    const v3525: bigint = v3524 + 1n;
    const v3526: boolean = v3521 === v3525;
    let v3527: bigint;
    if (v3526) {
        v3527 = 0n;
    } else {
        v3527 = 1n;
    }
    const v3528: bigint = 0n + 1n;
    const v3529: bigint = 0n + 1n;
    const v3530: boolean = v3528 === v3529;
    let v3531: bigint;
    if (v3530) {
        v3531 = 0n;
    } else {
        v3531 = 1n;
    }
    const v3532: bigint = 0n + 1n;
    const v3533: bigint = v3532 + 1n;
    const v3534: bigint = v3533 + 1n;
    const v3535: bigint = v3534 + 1n;
    const v3536: bigint = v3535 + 1n;
    const v3537: bigint = 0n + 1n;
    const v3538: bigint = v3537 + 1n;
    const v3539: bigint = v3538 + 1n;
    const v3540: bigint = v3539 + 1n;
    const v3541: bigint = v3540 + 1n;
    const v3542: boolean = v3536 === v3541;
    let v3543: bigint;
    if (v3542) {
        v3543 = 0n;
    } else {
        v3543 = 1n;
    }
    const v3544: bigint = BigInt.asIntN(64, v3528 + v3536);
    const v3545: bigint = BigInt.asIntN(64, v3529 + v3541);
    const v3546: bigint = BigInt.asIntN(64, v3531 + v3543);
    const v3547: bigint = BigInt.asIntN(64, v3521 + v3544);
    const v3548: bigint = BigInt.asIntN(64, v3525 + v3545);
    const v3549: bigint = BigInt.asIntN(64, v3527 + v3546);
    const v3550: bigint = 0n + 1n;
    const v3551: bigint = v3550 + 1n;
    const v3552: bigint = v3551 + 1n;
    const v3553: bigint = v3552 + 1n;
    const v3554: bigint = 0n + 1n;
    const v3555: bigint = v3554 + 1n;
    const v3556: bigint = v3555 + 1n;
    const v3557: bigint = v3556 + 1n;
    const v3558: boolean = v3553 === v3557;
    let v3559: bigint;
    if (v3558) {
        v3559 = 0n;
    } else {
        v3559 = 1n;
    }
    const v3560: bigint = 0n + 1n;
    const v3561: bigint = 0n + 1n;
    const v3562: boolean = v3560 === v3561;
    let v3563: bigint;
    if (v3562) {
        v3563 = 0n;
    } else {
        v3563 = 1n;
    }
    const v3564: bigint = 0n + 1n;
    const v3565: bigint = v3564 + 1n;
    const v3566: bigint = v3565 + 1n;
    const v3567: bigint = v3566 + 1n;
    const v3568: bigint = v3567 + 1n;
    const v3569: bigint = 0n + 1n;
    const v3570: bigint = v3569 + 1n;
    const v3571: bigint = v3570 + 1n;
    const v3572: bigint = v3571 + 1n;
    const v3573: bigint = v3572 + 1n;
    const v3574: boolean = v3568 === v3573;
    let v3575: bigint;
    if (v3574) {
        v3575 = 0n;
    } else {
        v3575 = 1n;
    }
    const v3576: bigint = BigInt.asIntN(64, v3560 + v3568);
    const v3577: bigint = BigInt.asIntN(64, v3561 + v3573);
    const v3578: bigint = BigInt.asIntN(64, v3563 + v3575);
    const v3579: bigint = BigInt.asIntN(64, v3553 + v3576);
    const v3580: bigint = BigInt.asIntN(64, v3557 + v3577);
    const v3581: bigint = BigInt.asIntN(64, v3559 + v3578);
    const v3582: bigint = 0n + 1n;
    const v3583: bigint = v3582 + 1n;
    const v3584: bigint = v3583 + 1n;
    const v3585: bigint = v3584 + 1n;
    const v3586: bigint = 0n + 1n;
    const v3587: bigint = v3586 + 1n;
    const v3588: bigint = v3587 + 1n;
    const v3589: bigint = v3588 + 1n;
    const v3590: boolean = v3585 === v3589;
    let v3591: bigint;
    if (v3590) {
        v3591 = 0n;
    } else {
        v3591 = 1n;
    }
    const v3592: bigint = 0n + 1n;
    const v3593: bigint = 0n + 1n;
    const v3594: boolean = v3592 === v3593;
    let v3595: bigint;
    if (v3594) {
        v3595 = 0n;
    } else {
        v3595 = 1n;
    }
    const v3596: bigint = 0n + 1n;
    const v3597: bigint = v3596 + 1n;
    const v3598: bigint = v3597 + 1n;
    const v3599: bigint = v3598 + 1n;
    const v3600: bigint = v3599 + 1n;
    const v3601: bigint = 0n + 1n;
    const v3602: bigint = v3601 + 1n;
    const v3603: bigint = v3602 + 1n;
    const v3604: bigint = v3603 + 1n;
    const v3605: bigint = v3604 + 1n;
    const v3606: boolean = v3600 === v3605;
    let v3607: bigint;
    if (v3606) {
        v3607 = 0n;
    } else {
        v3607 = 1n;
    }
    const v3608: bigint = BigInt.asIntN(64, v3592 + v3600);
    const v3609: bigint = BigInt.asIntN(64, v3593 + v3605);
    const v3610: bigint = BigInt.asIntN(64, v3595 + v3607);
    const v3611: bigint = BigInt.asIntN(64, v3585 + v3608);
    const v3612: bigint = BigInt.asIntN(64, v3589 + v3609);
    const v3613: bigint = BigInt.asIntN(64, v3591 + v3610);
    const v3614: boolean = v3515 === v3547;
    const v3615: boolean = v3516 === v3548;
    const v3616: boolean = v3517 === v3549;
    const v3617: boolean = v3614 && v3615;
    const v3618: boolean = v3617 && v3616;
    if (v3618) {
    } else {
        throw new Error("typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch");
    }
    const v3619: boolean = v3579 === v3611;
    const v3620: boolean = v3580 === v3612;
    const v3621: boolean = v3581 === v3613;
    const v3622: boolean = v3619 && v3620;
    const v3623: boolean = v3622 && v3621;
    if (v3623) {
    } else {
        throw new Error("typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch");
    }
    return 0;
}
process.exitCode = main();
