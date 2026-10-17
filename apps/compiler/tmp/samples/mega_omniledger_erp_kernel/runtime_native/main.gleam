import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Us0 {
    Us0TypedFxHashedStatementChecksumValidationAccepted(f0i0 : Int, f0i1 : Int, f0i2 : Int, f0i3 : Int, f0i4 : Int, f0i5 : String)
    Us0TypedFxHashedStatementChecksumValidationRejected(f1i0 : Int, f1i1 : Int, f1i2 : String)
}
pub fn main() {
let v0 = 0 + 1
let v1 = v0 + 1
let _v2 = v1 + 1
let v3 = 0 + 1
let v4 = v3 + 1
let _v5 = v4 + 1
let v6 = 0 + 1
let v7 = v6 + 1
let v8 = 0 + 1
let v9 = v8 + 1
let v10 = v9 + 1
let _v11 = v10 + 1
let v12 = 0 + 1
let v14 = 0 + 1
let v15 = v14 + 1
let v16 = v15 + 1
let v17 = v16 + 1
let v18 = v17 + 1
let v19 = 0 + 1
let v20 = spiral_wrap_signed(v12 + v12, 64)
let v21 = spiral_wrap_signed(v7 + v20, 64)
let v22 = 0 + 1
let v23 = v22 + 1
let _v24 = v23 + 1
let v25 = 0 + 1
let v26 = v25 + 1
let _v27 = v26 + 1
let v28 = 0 + 1
let v29 = v28 + 1
let v30 = 0 + 1
let v31 = v30 + 1
let v32 = v31 + 1
let _v33 = v32 + 1
let v34 = 0 + 1
let v36 = 0 + 1
let v37 = v36 + 1
let v38 = v37 + 1
let v39 = v38 + 1
let v40 = spiral_wrap_signed(v34 + v34, 64)
let v41 = spiral_wrap_signed(v29 + v40, 64)
let v42 = spiral_wrap_signed(v18 + v39, 64)
let v43 = spiral_wrap_signed(v21 + v41, 64)
let v44 = v42 == 9
let v45 = v19 == 1
let v46 = v43 == 8
let v47 = v44 && v45
let v48 = v47 && v46
case v48 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-usd-eur-determined-tie-rounding-runtime-mismatch"
    }
}
let v49 = 0 + 1
let v50 = v49 + 1
let v51 = v50 + 1
let v52 = v51 + 1
let v53 = 0 + 1
let v54 = v53 + 1
let v55 = v54 + 1
let v56 = v55 + 1
let v57 = v52 == v56
let v58 =
    case v57 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v59 = 0 + 1
let v60 = 0 + 1
let v61 = v59 == v60
let v62 =
    case v61 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v63 = 0 + 1
let v64 = v63 + 1
let v65 = v64 + 1
let v66 = v65 + 1
let v67 = v66 + 1
let v68 = 0 + 1
let v69 = v68 + 1
let v70 = v69 + 1
let v71 = v70 + 1
let v72 = v71 + 1
let v73 = v67 == v72
let v74 =
    case v73 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v75 = spiral_wrap_signed(v59 + v67, 64)
let v76 = spiral_wrap_signed(v60 + v72, 64)
let v77 = spiral_wrap_signed(v62 + v74, 64)
let v78 = spiral_wrap_signed(v52 + v75, 64)
let v79 = spiral_wrap_signed(v56 + v76, 64)
let v80 = spiral_wrap_signed(v58 + v77, 64)
let v81 = v78 == 10
let v82 = v79 == 10
let v83 = v80 == 0
let v84 = v81 && v82
let v85 = v84 && v83
case v85 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-expected-raw-append-runtime-mismatch"
    }
}
let v86 = 0 + 1
let v87 = v86 + 1
let v88 = v87 + 1
let v89 = v88 + 1
let v90 = 0 + 1
let v91 = v90 + 1
let v92 = v91 + 1
let v93 = v92 + 1
let v94 = v89 == v93
let v95 =
    case v94 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v96 = 0 + 1
let v97 = 0 + 1
let v98 = v96 == v97
let v99 =
    case v98 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v100 = 0 + 1
let v101 = v100 + 1
let v102 = v101 + 1
let v103 = v102 + 1
let v104 = v103 + 1
let v105 = 0 + 1
let v106 = v105 + 1
let v107 = v106 + 1
let v108 = v107 + 1
let v109 = v108 + 1
let v110 = v104 == v109
let v111 =
    case v110 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v114 = spiral_wrap_signed(v99 + v111, 64)
let v117 = spiral_wrap_signed(v95 + v114, 64)
let v118 = 0 + 1
let v119 = v118 + 1
let v120 = v119 + 1
let v121 = v120 + 1
let v122 = 0 + 1
let v123 = v122 + 1
let v124 = v123 + 1
let v125 = v124 + 1
let v126 = v121 == v125
let v127 =
    case v126 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v128 = 0 + 1
let v129 = 0 + 1
let v130 = v128 == v129
let v131 =
    case v130 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v132 = 0 + 1
let v133 = v132 + 1
let v134 = v133 + 1
let v135 = v134 + 1
let v136 = v135 + 1
let v137 = 0 + 1
let v138 = v137 + 1
let v139 = v138 + 1
let v140 = v139 + 1
let v141 = v140 + 1
let v142 = v136 == v141
let v143 =
    case v142 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v146 = spiral_wrap_signed(v131 + v143, 64)
let v149 = spiral_wrap_signed(v127 + v146, 64)
let v150 = spiral_wrap_signed(v117 + v149, 64)
let v151 = v150 == 0
case v151 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-two-writer-raw-CAS-runtime-mismatch"
    }
}
let v152 = 0 + 1
let v153 = v152 + 1
let v154 = v153 + 1
let v155 = v154 + 1
let v156 = 0 + 1
let v157 = v156 + 1
let v158 = v157 + 1
let v159 = v158 + 1
let v160 = v155 == v159
let v161 =
    case v160 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v162 = 0 + 1
let v163 = 0 + 1
let v164 = v162 == v163
let v165 =
    case v164 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v166 = 0 + 1
let v167 = v166 + 1
let v168 = v167 + 1
let v169 = v168 + 1
let v170 = v169 + 1
let v171 = 0 + 1
let v172 = v171 + 1
let v173 = v172 + 1
let v174 = v173 + 1
let v175 = v174 + 1
let v176 = v170 == v175
let v177 =
    case v176 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v180 = spiral_wrap_signed(v165 + v177, 64)
let v183 = spiral_wrap_signed(v161 + v180, 64)
let v184 = 0 + 1
let v185 = v184 + 1
let v186 = v185 + 1
let v187 = v186 + 1
let v188 = 0 + 1
let v189 = v188 + 1
let v190 = v189 + 1
let v191 = v190 + 1
let v192 = v187 == v191
let v193 =
    case v192 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v194 = 0 + 1
let v195 = 0 + 1
let v196 = v194 == v195
let v197 =
    case v196 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v198 = 0 + 1
let v199 = v198 + 1
let v200 = v199 + 1
let v201 = v200 + 1
let v202 = v201 + 1
let v203 = 0 + 1
let v204 = v203 + 1
let v205 = v204 + 1
let v206 = v205 + 1
let v207 = v206 + 1
let v208 = v202 == v207
let v209 =
    case v208 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v212 = spiral_wrap_signed(v197 + v209, 64)
let v215 = spiral_wrap_signed(v193 + v212, 64)
let v216 = spiral_wrap_signed(v183 + v215, 64)
let v217 = 0 + 1
let v218 = v217 + 1
let v219 = v218 + 1
let v220 = v219 + 1
let v221 = 0 + 1
let v222 = v221 + 1
let v223 = v222 + 1
let v224 = v223 + 1
let v225 = v220 == v224
let v226 =
    case v225 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v227 = 0 + 1
let v228 = 0 + 1
let v229 = v227 == v228
let v230 =
    case v229 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v231 = 0 + 1
let v232 = v231 + 1
let v233 = v232 + 1
let v234 = v233 + 1
let v235 = v234 + 1
let v236 = 0 + 1
let v237 = v236 + 1
let v238 = v237 + 1
let v239 = v238 + 1
let v240 = v239 + 1
let v241 = v235 == v240
let v242 =
    case v241 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v245 = spiral_wrap_signed(v230 + v242, 64)
let v248 = spiral_wrap_signed(v226 + v245, 64)
let v249 = spiral_wrap_signed(v216 + v248, 64)
let v250 = v249 == 0
case v250 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-three-writer-raw-CAS-runtime-mismatch"
    }
}
let v251 = 0 + 1
let v252 = v251 + 1
let v253 = v252 + 1
let v254 = v253 + 1
let v255 = 0 + 1
let v256 = v255 + 1
let v257 = v256 + 1
let v258 = v257 + 1
let v259 = v254 == v258
let v260 =
    case v259 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v261 = 0 + 1
let v262 = 0 + 1
let v263 = v261 == v262
let v264 =
    case v263 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v265 = 0 + 1
let v266 = v265 + 1
let v267 = v266 + 1
let v268 = v267 + 1
let v269 = v268 + 1
let v270 = 0 + 1
let v271 = v270 + 1
let v272 = v271 + 1
let v273 = v272 + 1
let v274 = v273 + 1
let v275 = v269 == v274
let v276 =
    case v275 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v279 = spiral_wrap_signed(v264 + v276, 64)
let v282 = spiral_wrap_signed(v260 + v279, 64)
let v283 = 0 + 1
let v284 = v283 + 1
let v285 = v284 + 1
let v286 = v285 + 1
let v287 = 0 + 1
let v288 = v287 + 1
let v289 = v288 + 1
let v290 = v289 + 1
let v291 = v286 == v290
let v292 =
    case v291 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v293 = 0 + 1
let v294 = 0 + 1
let v295 = v293 == v294
let v296 =
    case v295 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v297 = 0 + 1
let v298 = v297 + 1
let v299 = v298 + 1
let v300 = v299 + 1
let v301 = v300 + 1
let v302 = 0 + 1
let v303 = v302 + 1
let v304 = v303 + 1
let v305 = v304 + 1
let v306 = v305 + 1
let v307 = v301 == v306
let v308 =
    case v307 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v311 = spiral_wrap_signed(v296 + v308, 64)
let v314 = spiral_wrap_signed(v292 + v311, 64)
let v315 = spiral_wrap_signed(v282 + v314, 64)
let v316 = 0 + 1
let v317 = v316 + 1
let v318 = v317 + 1
let v319 = v318 + 1
let v320 = 0 + 1
let v321 = v320 + 1
let v322 = v321 + 1
let v323 = v322 + 1
let v324 = v319 == v323
let v325 =
    case v324 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v326 = 0 + 1
let v327 = 0 + 1
let v328 = v326 == v327
let v329 =
    case v328 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v330 = 0 + 1
let v331 = v330 + 1
let v332 = v331 + 1
let v333 = v332 + 1
let v334 = v333 + 1
let v335 = 0 + 1
let v336 = v335 + 1
let v337 = v336 + 1
let v338 = v337 + 1
let v339 = v338 + 1
let v340 = v334 == v339
let v341 =
    case v340 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v344 = spiral_wrap_signed(v329 + v341, 64)
let v347 = spiral_wrap_signed(v325 + v344, 64)
let v348 = 0 + 1
let v349 = v348 + 1
let v350 = v349 + 1
let v351 = v350 + 1
let v352 = 0 + 1
let v353 = v352 + 1
let v354 = v353 + 1
let v355 = v354 + 1
let v356 = v351 == v355
let v357 =
    case v356 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v358 = 0 + 1
let v359 = 0 + 1
let v360 = v358 == v359
let v361 =
    case v360 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v362 = 0 + 1
let v363 = v362 + 1
let v364 = v363 + 1
let v365 = v364 + 1
let v366 = v365 + 1
let v367 = 0 + 1
let v368 = v367 + 1
let v369 = v368 + 1
let v370 = v369 + 1
let v371 = v370 + 1
let v372 = v366 == v371
let v373 =
    case v372 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v376 = spiral_wrap_signed(v361 + v373, 64)
let v379 = spiral_wrap_signed(v357 + v376, 64)
let v380 = spiral_wrap_signed(v347 + v379, 64)
let v381 = spiral_wrap_signed(v315 + v380, 64)
let v382 = v381 == 0
case v382 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-recursive-writer-raw-CAS-runtime-mismatch"
    }
}
let v383 = 0 + 1
let v384 = v383 + 1
let v385 = v384 + 1
let v386 = v385 + 1
let v387 = 0 + 1
let v388 = v387 + 1
let v389 = v388 + 1
let v390 = v389 + 1
let v391 = v386 == v390
let v392 =
    case v391 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v393 = 0 + 1
let v394 = 0 + 1
let v395 = v393 == v394
let v396 =
    case v395 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v397 = 0 + 1
let v398 = v397 + 1
let v399 = v398 + 1
let v400 = v399 + 1
let v401 = v400 + 1
let v402 = 0 + 1
let v403 = v402 + 1
let v404 = v403 + 1
let v405 = v404 + 1
let v406 = v405 + 1
let v407 = v401 == v406
let v408 =
    case v407 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v411 = spiral_wrap_signed(v396 + v408, 64)
let v414 = spiral_wrap_signed(v392 + v411, 64)
let v415 = 0 + 1
let v416 = v415 + 1
let v417 = v416 + 1
let v418 = v417 + 1
let v419 = 0 + 1
let v420 = v419 + 1
let v421 = v420 + 1
let v422 = v421 + 1
let v423 = v418 == v422
let v424 =
    case v423 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v425 = 0 + 1
let v426 = 0 + 1
let v427 = v425 == v426
let v428 =
    case v427 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v429 = 0 + 1
let v430 = v429 + 1
let v431 = v430 + 1
let v432 = v431 + 1
let v433 = v432 + 1
let v434 = 0 + 1
let v435 = v434 + 1
let v436 = v435 + 1
let v437 = v436 + 1
let v438 = v437 + 1
let v439 = v433 == v438
let v440 =
    case v439 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v443 = spiral_wrap_signed(v428 + v440, 64)
let v446 = spiral_wrap_signed(v424 + v443, 64)
let v447 = spiral_wrap_signed(v414 + v446, 64)
let v448 = 0 + 1
let v449 = v448 + 1
let v450 = v449 + 1
let v451 = v450 + 1
let v452 = 0 + 1
let v453 = v452 + 1
let v454 = v453 + 1
let v455 = v454 + 1
let v456 = v451 == v455
let v457 =
    case v456 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v458 = 0 + 1
let v459 = 0 + 1
let v460 = v458 == v459
let v461 =
    case v460 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v462 = 0 + 1
let v463 = v462 + 1
let v464 = v463 + 1
let v465 = v464 + 1
let v466 = v465 + 1
let v467 = 0 + 1
let v468 = v467 + 1
let v469 = v468 + 1
let v470 = v469 + 1
let v471 = v470 + 1
let v472 = v466 == v471
let v473 =
    case v472 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v476 = spiral_wrap_signed(v461 + v473, 64)
let v479 = spiral_wrap_signed(v457 + v476, 64)
let v480 = 0 + 1
let v481 = v480 + 1
let v482 = v481 + 1
let v483 = v482 + 1
let v484 = 0 + 1
let v485 = v484 + 1
let v486 = v485 + 1
let v487 = v486 + 1
let v488 = v483 == v487
let v489 =
    case v488 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v490 = 0 + 1
let v491 = 0 + 1
let v492 = v490 == v491
let v493 =
    case v492 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v494 = 0 + 1
let v495 = v494 + 1
let v496 = v495 + 1
let v497 = v496 + 1
let v498 = v497 + 1
let v499 = 0 + 1
let v500 = v499 + 1
let v501 = v500 + 1
let v502 = v501 + 1
let v503 = v502 + 1
let v504 = v498 == v503
let v505 =
    case v504 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v508 = spiral_wrap_signed(v493 + v505, 64)
let v511 = spiral_wrap_signed(v489 + v508, 64)
let v512 = spiral_wrap_signed(v479 + v511, 64)
let v513 = spiral_wrap_signed(v447 + v512, 64)
let v514 = 0 + 1
let v515 = v514 + 1
let v516 = v515 + 1
let v517 = v516 + 1
let v518 = 0 + 1
let v519 = v518 + 1
let v520 = v519 + 1
let v521 = v520 + 1
let v522 = v517 == v521
let v523 =
    case v522 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v524 = 0 + 1
let v525 = 0 + 1
let v526 = v524 == v525
let v527 =
    case v526 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v528 = 0 + 1
let v529 = v528 + 1
let v530 = v529 + 1
let v531 = v530 + 1
let v532 = v531 + 1
let v533 = 0 + 1
let v534 = v533 + 1
let v535 = v534 + 1
let v536 = v535 + 1
let v537 = v536 + 1
let v538 = v532 == v537
let v539 =
    case v538 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v540 = spiral_wrap_signed(v524 + v532, 64)
let v541 = spiral_wrap_signed(v525 + v537, 64)
let v542 = spiral_wrap_signed(v527 + v539, 64)
let v543 = spiral_wrap_signed(v517 + v540, 64)
let v544 = spiral_wrap_signed(v521 + v541, 64)
let v545 = spiral_wrap_signed(v523 + v542, 64)
let v546 = spiral_wrap_signed(v544 + v545, 64)
let v547 = spiral_wrap_signed(v543 + v546, 64)
let v548 = spiral_wrap_signed(3 + v547, 64)
let v549 = 0 + 1
let v550 = v549 + 1
let v551 = v550 + 1
let v552 = v551 + 1
let v553 = 0 + 1
let v554 = v553 + 1
let v555 = v554 + 1
let v556 = v555 + 1
let v557 = v552 == v556
let v558 =
    case v557 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v559 = 0 + 1
let v560 = 0 + 1
let v561 = v559 == v560
let v562 =
    case v561 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v563 = 0 + 1
let v564 = v563 + 1
let v565 = v564 + 1
let v566 = v565 + 1
let v567 = v566 + 1
let v568 = 0 + 1
let v569 = v568 + 1
let v570 = v569 + 1
let v571 = v570 + 1
let v572 = v571 + 1
let v573 = v567 == v572
let v574 =
    case v573 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v575 = spiral_wrap_signed(v559 + v567, 64)
let v576 = spiral_wrap_signed(v560 + v572, 64)
let v577 = spiral_wrap_signed(v562 + v574, 64)
let v578 = spiral_wrap_signed(v552 + v575, 64)
let v579 = spiral_wrap_signed(v556 + v576, 64)
let v580 = spiral_wrap_signed(v558 + v577, 64)
let v581 = spiral_wrap_signed(v579 + v580, 64)
let v582 = spiral_wrap_signed(v578 + v581, 64)
let v583 = spiral_wrap_signed(3 + v582, 64)
let v584 = v548 == v583
let v621 =
    case v584 {
        True -> {
            let v585 = 0 + 1
            let v586 = v585 + 1
            let v587 = v586 + 1
            let v588 = v587 + 1
            let v589 = 0 + 1
            let v590 = v589 + 1
            let v591 = v590 + 1
            let v592 = v591 + 1
            let v593 = v588 == v592
            let v594 =
                case v593 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v595 = 0 + 1
            let v596 = 0 + 1
            let v597 = v595 == v596
            let v598 =
                case v597 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v599 = 0 + 1
            let v600 = v599 + 1
            let v601 = v600 + 1
            let v602 = v601 + 1
            let v603 = v602 + 1
            let v604 = 0 + 1
            let v605 = v604 + 1
            let v606 = v605 + 1
            let v607 = v606 + 1
            let v608 = v607 + 1
            let v609 = v603 == v608
            let v610 =
                case v609 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v611 = spiral_wrap_signed(v595 + v603, 64)
            let v612 = spiral_wrap_signed(v596 + v608, 64)
            let v613 = spiral_wrap_signed(v598 + v610, 64)
            let v614 = spiral_wrap_signed(v588 + v611, 64)
            let v615 = spiral_wrap_signed(v592 + v612, 64)
            let v616 = spiral_wrap_signed(v594 + v613, 64)
            let v617 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
            Us0TypedFxHashedStatementChecksumValidationAccepted(1, 3, v614, v615, v616, v617)
        }
        False -> {
            let v619 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
            Us0TypedFxHashedStatementChecksumValidationRejected(v548, v583, v619)
        }
    }
let #(v640, v641, v644, v645, v646, v647, v648) =
    case v621  {
        Us0TypedFxHashedStatementChecksumValidationAccepted(v625, v626, v627, v628, v629, v630) -> {
            #(1, 0, v625, v626, v627, v628, v629)
        }
        Us0TypedFxHashedStatementChecksumValidationRejected(v622, v623, v624) -> {
            #(0, 1, 0, 0, 0, 0, 0)
        }
    }
let v649 = v513 == 0
let v650 = v548 == 23
let v651 = v640 == 1
let v652 = v641 == 0
let v653 = v644 == 1
let v654 = v645 == 3
let v655 = v646 == 10
let v656 = v647 == 10
let v657 = v648 == 0
let v658 = v649 && v650
let v659 = v658 && v651
let v660 = v659 && v652
let v661 = v660 && v653
let v662 = v661 && v654
let v663 = v662 && v655
let v664 = v663 && v656
let v665 = v664 && v657
case v665 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-recursive-writer-checksummed-restart-runtime-mismatch"
    }
}
let v666 = 0 + 1
let v667 = v666 + 1
let v668 = v667 + 1
let v669 = v668 + 1
let v670 = 0 + 1
let v671 = v670 + 1
let v672 = v671 + 1
let v673 = v672 + 1
let v674 = v669 == v673
let v675 =
    case v674 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v676 = 0 + 1
let v677 = 0 + 1
let v678 = v676 == v677
let v679 =
    case v678 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v680 = 0 + 1
let v681 = v680 + 1
let v682 = v681 + 1
let v683 = v682 + 1
let v684 = v683 + 1
let v685 = 0 + 1
let v686 = v685 + 1
let v687 = v686 + 1
let v688 = v687 + 1
let v689 = v688 + 1
let v690 = v684 == v689
let v691 =
    case v690 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v694 = spiral_wrap_signed(v679 + v691, 64)
let v697 = spiral_wrap_signed(v675 + v694, 64)
let v698 = 0 + 1
let v699 = v698 + 1
let v700 = v699 + 1
let v701 = v700 + 1
let v702 = 0 + 1
let v703 = v702 + 1
let v704 = v703 + 1
let v705 = v704 + 1
let v706 = v701 == v705
let v707 =
    case v706 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v708 = 0 + 1
let v709 = 0 + 1
let v710 = v708 == v709
let v711 =
    case v710 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v712 = 0 + 1
let v713 = v712 + 1
let v714 = v713 + 1
let v715 = v714 + 1
let v716 = v715 + 1
let v717 = 0 + 1
let v718 = v717 + 1
let v719 = v718 + 1
let v720 = v719 + 1
let v721 = v720 + 1
let v722 = v716 == v721
let v723 =
    case v722 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v726 = spiral_wrap_signed(v711 + v723, 64)
let v729 = spiral_wrap_signed(v707 + v726, 64)
let v730 = spiral_wrap_signed(v697 + v729, 64)
let v731 = 0 + 1
let v732 = v731 + 1
let v733 = v732 + 1
let v734 = v733 + 1
let v735 = 0 + 1
let v736 = v735 + 1
let v737 = v736 + 1
let v738 = v737 + 1
let v739 = v734 == v738
let v740 =
    case v739 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v741 = 0 + 1
let v742 = 0 + 1
let v743 = v741 == v742
let v744 =
    case v743 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v745 = 0 + 1
let v746 = v745 + 1
let v747 = v746 + 1
let v748 = v747 + 1
let v749 = v748 + 1
let v750 = 0 + 1
let v751 = v750 + 1
let v752 = v751 + 1
let v753 = v752 + 1
let v754 = v753 + 1
let v755 = v749 == v754
let v756 =
    case v755 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v759 = spiral_wrap_signed(v744 + v756, 64)
let v762 = spiral_wrap_signed(v740 + v759, 64)
let v763 = 0 + 1
let v764 = v763 + 1
let v765 = v764 + 1
let v766 = v765 + 1
let v767 = 0 + 1
let v768 = v767 + 1
let v769 = v768 + 1
let v770 = v769 + 1
let v771 = v766 == v770
let v772 =
    case v771 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v773 = 0 + 1
let v774 = 0 + 1
let v775 = v773 == v774
let v776 =
    case v775 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v777 = 0 + 1
let v778 = v777 + 1
let v779 = v778 + 1
let v780 = v779 + 1
let v781 = v780 + 1
let v782 = 0 + 1
let v783 = v782 + 1
let v784 = v783 + 1
let v785 = v784 + 1
let v786 = v785 + 1
let v787 = v781 == v786
let v788 =
    case v787 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v791 = spiral_wrap_signed(v776 + v788, 64)
let v794 = spiral_wrap_signed(v772 + v791, 64)
let v795 = spiral_wrap_signed(v762 + v794, 64)
let v796 = spiral_wrap_signed(v730 + v795, 64)
let v797 = 0 + 1
let v798 = v797 + 1
let v799 = v798 + 1
let v800 = v799 + 1
let v801 = 0 + 1
let v802 = v801 + 1
let v803 = v802 + 1
let v804 = v803 + 1
let v805 = v800 == v804
let v806 =
    case v805 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v807 = 0 + 1
let v808 = 0 + 1
let v809 = v807 == v808
let v810 =
    case v809 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v811 = 0 + 1
let v812 = v811 + 1
let v813 = v812 + 1
let v814 = v813 + 1
let v815 = v814 + 1
let v816 = 0 + 1
let v817 = v816 + 1
let v818 = v817 + 1
let v819 = v818 + 1
let v820 = v819 + 1
let v821 = v815 == v820
let v822 =
    case v821 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v823 = spiral_wrap_signed(v807 + v815, 64)
let v824 = spiral_wrap_signed(v808 + v820, 64)
let v825 = spiral_wrap_signed(v810 + v822, 64)
let v826 = spiral_wrap_signed(v800 + v823, 64)
let v827 = spiral_wrap_signed(v804 + v824, 64)
let v828 = spiral_wrap_signed(v806 + v825, 64)
let v829 = spiral_wrap_signed(v827 + v828, 64)
let v830 = spiral_wrap_signed(v826 + v829, 64)
let v831 = spiral_wrap_signed(3 + v830, 64)
let v832 = 0 + 1
let v833 = v832 + 1
let v834 = v833 + 1
let v835 = v834 + 1
let v836 = 0 + 1
let v837 = v836 + 1
let v838 = v837 + 1
let v839 = v838 + 1
let v840 = v835 == v839
let v841 =
    case v840 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v842 = 0 + 1
let v843 = 0 + 1
let v844 = v842 == v843
let v845 =
    case v844 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v846 = 0 + 1
let v847 = v846 + 1
let v848 = v847 + 1
let v849 = v848 + 1
let v850 = v849 + 1
let v851 = 0 + 1
let v852 = v851 + 1
let v853 = v852 + 1
let v854 = v853 + 1
let v855 = v854 + 1
let v856 = v850 == v855
let v857 =
    case v856 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v858 = spiral_wrap_signed(v842 + v850, 64)
let v859 = spiral_wrap_signed(v843 + v855, 64)
let v860 = spiral_wrap_signed(v845 + v857, 64)
let v861 = spiral_wrap_signed(v835 + v858, 64)
let v862 = spiral_wrap_signed(v839 + v859, 64)
let v863 = spiral_wrap_signed(v841 + v860, 64)
let v864 = spiral_wrap_signed(v862 + v863, 64)
let v865 = spiral_wrap_signed(v861 + v864, 64)
let v866 = spiral_wrap_signed(3 + v865, 64)
let v867 = v831 == v866
let v904 =
    case v867 {
        True -> {
            let v868 = 0 + 1
            let v869 = v868 + 1
            let v870 = v869 + 1
            let v871 = v870 + 1
            let v872 = 0 + 1
            let v873 = v872 + 1
            let v874 = v873 + 1
            let v875 = v874 + 1
            let v876 = v871 == v875
            let v877 =
                case v876 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v878 = 0 + 1
            let v879 = 0 + 1
            let v880 = v878 == v879
            let v881 =
                case v880 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v882 = 0 + 1
            let v883 = v882 + 1
            let v884 = v883 + 1
            let v885 = v884 + 1
            let v886 = v885 + 1
            let v887 = 0 + 1
            let v888 = v887 + 1
            let v889 = v888 + 1
            let v890 = v889 + 1
            let v891 = v890 + 1
            let v892 = v886 == v891
            let v893 =
                case v892 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v894 = spiral_wrap_signed(v878 + v886, 64)
            let v895 = spiral_wrap_signed(v879 + v891, 64)
            let v896 = spiral_wrap_signed(v881 + v893, 64)
            let v897 = spiral_wrap_signed(v871 + v894, 64)
            let v898 = spiral_wrap_signed(v875 + v895, 64)
            let v899 = spiral_wrap_signed(v877 + v896, 64)
            let v900 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
            Us0TypedFxHashedStatementChecksumValidationAccepted(1, 3, v897, v898, v899, v900)
        }
        False -> {
            let v902 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
            Us0TypedFxHashedStatementChecksumValidationRejected(v831, v866, v902)
        }
    }
let #(v923, v924, v927, v931) =
    case v904  {
        Us0TypedFxHashedStatementChecksumValidationAccepted(v908, v909, v910, v911, v912, v913) -> {
            #(1, 0, v908, v912)
        }
        Us0TypedFxHashedStatementChecksumValidationRejected(v905, v906, v907) -> {
            #(0, 1, 0, 0)
        }
    }
let v932 = 0 + 1
let v933 = v932 + 1
let v934 = v933 + 1
let v935 = v934 + 1
let v936 = 0 + 1
let v937 = v936 + 1
let v938 = v937 + 1
let v939 = v938 + 1
let v940 = v935 == v939
let v941 =
    case v940 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v942 = 0 + 1
let v943 = 0 + 1
let v944 = v942 == v943
let v945 =
    case v944 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v946 = 0 + 1
let v947 = v946 + 1
let v948 = v947 + 1
let v949 = v948 + 1
let v950 = v949 + 1
let v951 = 0 + 1
let v952 = v951 + 1
let v953 = v952 + 1
let v954 = v953 + 1
let v955 = v954 + 1
let v956 = v950 == v955
let v957 =
    case v956 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v960 = spiral_wrap_signed(v945 + v957, 64)
let v963 = spiral_wrap_signed(v941 + v960, 64)
let v964 = 0 + 1
let v965 = v964 + 1
let v966 = v965 + 1
let v967 = v966 + 1
let v968 = 0 + 1
let v969 = v968 + 1
let v970 = v969 + 1
let v971 = v970 + 1
let v972 = v967 == v971
let v973 =
    case v972 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v974 = 0 + 1
let v975 = 0 + 1
let v976 = v974 == v975
let v977 =
    case v976 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v978 = 0 + 1
let v979 = v978 + 1
let v980 = v979 + 1
let v981 = v980 + 1
let v982 = v981 + 1
let v983 = 0 + 1
let v984 = v983 + 1
let v985 = v984 + 1
let v986 = v985 + 1
let v987 = v986 + 1
let v988 = v982 == v987
let v989 =
    case v988 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v992 = spiral_wrap_signed(v977 + v989, 64)
let v995 = spiral_wrap_signed(v973 + v992, 64)
let v996 = spiral_wrap_signed(v963 + v995, 64)
let v997 = spiral_wrap_signed(v931 + v924, 64)
let v998 = spiral_wrap_signed(v996 + v997, 64)
let v999 = spiral_wrap_signed(v796 + v998, 64)
let v1000 = v927 == 1
let v1001 = v923 == 1
let v1002 = v999 == 0
let v1003 = v1000 && v1001
let v1004 = v1003 && v1002
case v1004 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-recursive-writer-restart-invariant-runtime-mismatch"
    }
}
let v1005 = 0 + 1
let v1006 = v1005 + 1
let v1007 = v1006 + 1
let v1008 = v1007 + 1
let v1009 = 0 + 1
let v1010 = v1009 + 1
let v1011 = v1010 + 1
let v1012 = v1011 + 1
let v1013 = v1008 == v1012
let v1014 =
    case v1013 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1015 = 0 + 1
let v1016 = 0 + 1
let v1017 = v1015 == v1016
let v1018 =
    case v1017 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1019 = 0 + 1
let v1020 = v1019 + 1
let v1021 = v1020 + 1
let v1022 = v1021 + 1
let v1023 = v1022 + 1
let v1024 = 0 + 1
let v1025 = v1024 + 1
let v1026 = v1025 + 1
let v1027 = v1026 + 1
let v1028 = v1027 + 1
let v1029 = v1023 == v1028
let v1030 =
    case v1029 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1033 = spiral_wrap_signed(v1018 + v1030, 64)
let v1036 = spiral_wrap_signed(v1014 + v1033, 64)
let v1037 = 0 + 1
let v1038 = v1037 + 1
let v1039 = v1038 + 1
let v1040 = v1039 + 1
let v1041 = 0 + 1
let v1042 = v1041 + 1
let v1043 = v1042 + 1
let v1044 = v1043 + 1
let v1045 = v1040 == v1044
let v1046 =
    case v1045 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1047 = 0 + 1
let v1048 = 0 + 1
let v1049 = v1047 == v1048
let v1050 =
    case v1049 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1051 = 0 + 1
let v1052 = v1051 + 1
let v1053 = v1052 + 1
let v1054 = v1053 + 1
let v1055 = v1054 + 1
let v1056 = 0 + 1
let v1057 = v1056 + 1
let v1058 = v1057 + 1
let v1059 = v1058 + 1
let v1060 = v1059 + 1
let v1061 = v1055 == v1060
let v1062 =
    case v1061 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1065 = spiral_wrap_signed(v1050 + v1062, 64)
let v1068 = spiral_wrap_signed(v1046 + v1065, 64)
let v1069 = spiral_wrap_signed(v1036 + v1068, 64)
let v1070 = 0 + 1
let v1071 = v1070 + 1
let v1072 = v1071 + 1
let v1073 = v1072 + 1
let v1074 = 0 + 1
let v1075 = v1074 + 1
let v1076 = v1075 + 1
let v1077 = v1076 + 1
let v1078 = v1073 == v1077
let v1079 =
    case v1078 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1080 = 0 + 1
let v1081 = 0 + 1
let v1082 = v1080 == v1081
let v1083 =
    case v1082 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1084 = 0 + 1
let v1085 = v1084 + 1
let v1086 = v1085 + 1
let v1087 = v1086 + 1
let v1088 = v1087 + 1
let v1089 = 0 + 1
let v1090 = v1089 + 1
let v1091 = v1090 + 1
let v1092 = v1091 + 1
let v1093 = v1092 + 1
let v1094 = v1088 == v1093
let v1095 =
    case v1094 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1098 = spiral_wrap_signed(v1083 + v1095, 64)
let v1101 = spiral_wrap_signed(v1079 + v1098, 64)
let v1102 = 0 + 1
let v1103 = v1102 + 1
let v1104 = v1103 + 1
let v1105 = v1104 + 1
let v1106 = 0 + 1
let v1107 = v1106 + 1
let v1108 = v1107 + 1
let v1109 = v1108 + 1
let v1110 = v1105 == v1109
let v1111 =
    case v1110 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1112 = 0 + 1
let v1113 = 0 + 1
let v1114 = v1112 == v1113
let v1115 =
    case v1114 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1116 = 0 + 1
let v1117 = v1116 + 1
let v1118 = v1117 + 1
let v1119 = v1118 + 1
let v1120 = v1119 + 1
let v1121 = 0 + 1
let v1122 = v1121 + 1
let v1123 = v1122 + 1
let v1124 = v1123 + 1
let v1125 = v1124 + 1
let v1126 = v1120 == v1125
let v1127 =
    case v1126 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1130 = spiral_wrap_signed(v1115 + v1127, 64)
let v1133 = spiral_wrap_signed(v1111 + v1130, 64)
let v1134 = spiral_wrap_signed(v1101 + v1133, 64)
let v1135 = 0 + 1
let v1136 = v1135 + 1
let v1137 = v1136 + 1
let v1138 = v1137 + 1
let v1139 = 0 + 1
let v1140 = v1139 + 1
let v1141 = v1140 + 1
let v1142 = v1141 + 1
let v1143 = v1138 == v1142
let v1144 =
    case v1143 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1145 = 0 + 1
let v1146 = 0 + 1
let v1147 = v1145 == v1146
let v1148 =
    case v1147 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1149 = 0 + 1
let v1150 = v1149 + 1
let v1151 = v1150 + 1
let v1152 = v1151 + 1
let v1153 = v1152 + 1
let v1154 = 0 + 1
let v1155 = v1154 + 1
let v1156 = v1155 + 1
let v1157 = v1156 + 1
let v1158 = v1157 + 1
let v1159 = v1153 == v1158
let v1160 =
    case v1159 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1163 = spiral_wrap_signed(v1148 + v1160, 64)
let v1166 = spiral_wrap_signed(v1144 + v1163, 64)
let v1167 = 0 + 1
let v1168 = v1167 + 1
let v1169 = v1168 + 1
let v1170 = v1169 + 1
let v1171 = 0 + 1
let v1172 = v1171 + 1
let v1173 = v1172 + 1
let v1174 = v1173 + 1
let v1175 = v1170 == v1174
let v1176 =
    case v1175 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1177 = 0 + 1
let v1178 = 0 + 1
let v1179 = v1177 == v1178
let v1180 =
    case v1179 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1181 = 0 + 1
let v1182 = v1181 + 1
let v1183 = v1182 + 1
let v1184 = v1183 + 1
let v1185 = v1184 + 1
let v1186 = 0 + 1
let v1187 = v1186 + 1
let v1188 = v1187 + 1
let v1189 = v1188 + 1
let v1190 = v1189 + 1
let v1191 = v1185 == v1190
let v1192 =
    case v1191 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1195 = spiral_wrap_signed(v1180 + v1192, 64)
let v1198 = spiral_wrap_signed(v1176 + v1195, 64)
let v1199 = 0 + 1
let v1200 = v1199 + 1
let v1201 = v1200 + 1
let v1202 = v1201 + 1
let v1203 = 0 + 1
let v1204 = v1203 + 1
let v1205 = v1204 + 1
let v1206 = v1205 + 1
let v1207 = v1202 == v1206
let v1208 =
    case v1207 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1209 = 0 + 1
let v1210 = 0 + 1
let v1211 = v1209 == v1210
let v1212 =
    case v1211 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1213 = 0 + 1
let v1214 = v1213 + 1
let v1215 = v1214 + 1
let v1216 = v1215 + 1
let v1217 = v1216 + 1
let v1218 = 0 + 1
let v1219 = v1218 + 1
let v1220 = v1219 + 1
let v1221 = v1220 + 1
let v1222 = v1221 + 1
let v1223 = v1217 == v1222
let v1224 =
    case v1223 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1227 = spiral_wrap_signed(v1212 + v1224, 64)
let v1230 = spiral_wrap_signed(v1208 + v1227, 64)
let v1231 = 0 + 1
let v1232 = v1231 + 1
let v1233 = v1232 + 1
let v1234 = v1233 + 1
let v1235 = 0 + 1
let v1236 = v1235 + 1
let v1237 = v1236 + 1
let v1238 = v1237 + 1
let v1239 = v1234 == v1238
let v1240 =
    case v1239 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1241 = 0 + 1
let v1242 = 0 + 1
let v1243 = v1241 == v1242
let v1244 =
    case v1243 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1245 = 0 + 1
let v1246 = v1245 + 1
let v1247 = v1246 + 1
let v1248 = v1247 + 1
let v1249 = v1248 + 1
let v1250 = 0 + 1
let v1251 = v1250 + 1
let v1252 = v1251 + 1
let v1253 = v1252 + 1
let v1254 = v1253 + 1
let v1255 = v1249 == v1254
let v1256 =
    case v1255 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1259 = spiral_wrap_signed(v1244 + v1256, 64)
let v1262 = spiral_wrap_signed(v1240 + v1259, 64)
let v1263 = spiral_wrap_signed(v1230 + v1262, 64)
let v1264 = spiral_wrap_signed(v1198 + v1263, 64)
let v1265 = spiral_wrap_signed(v1166 + v1264, 64)
let v1266 = v1069 == 0
let v1267 = v1134 == v1069
let v1268 = v1265 == 0
let v1269 = v1266 && v1267
let v1270 = v1269 && v1268
case v1270 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-stale-writer-conflict-program-append-runtime-mismatch"
    }
}
let v1271 = 0 + 1
let v1272 = v1271 + 1
let v1273 = v1272 + 1
let v1274 = v1273 + 1
let v1275 = 0 + 1
let v1276 = v1275 + 1
let v1277 = v1276 + 1
let v1278 = v1277 + 1
let v1279 = v1274 == v1278
let v1280 =
    case v1279 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1281 = 0 + 1
let v1282 = 0 + 1
let v1283 = v1281 == v1282
let v1284 =
    case v1283 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1285 = 0 + 1
let v1286 = v1285 + 1
let v1287 = v1286 + 1
let v1288 = v1287 + 1
let v1289 = v1288 + 1
let v1290 = 0 + 1
let v1291 = v1290 + 1
let v1292 = v1291 + 1
let v1293 = v1292 + 1
let v1294 = v1293 + 1
let v1295 = v1289 == v1294
let v1296 =
    case v1295 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1299 = spiral_wrap_signed(v1284 + v1296, 64)
let v1302 = spiral_wrap_signed(v1280 + v1299, 64)
let v1303 = 0 + 1
let v1304 = v1303 + 1
let v1305 = v1304 + 1
let v1306 = v1305 + 1
let v1307 = 0 + 1
let v1308 = v1307 + 1
let v1309 = v1308 + 1
let v1310 = v1309 + 1
let v1311 = v1306 == v1310
let v1312 =
    case v1311 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1313 = 0 + 1
let v1314 = 0 + 1
let v1315 = v1313 == v1314
let v1316 =
    case v1315 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1317 = 0 + 1
let v1318 = v1317 + 1
let v1319 = v1318 + 1
let v1320 = v1319 + 1
let v1321 = v1320 + 1
let v1322 = 0 + 1
let v1323 = v1322 + 1
let v1324 = v1323 + 1
let v1325 = v1324 + 1
let v1326 = v1325 + 1
let v1327 = v1321 == v1326
let v1328 =
    case v1327 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1331 = spiral_wrap_signed(v1316 + v1328, 64)
let v1334 = spiral_wrap_signed(v1312 + v1331, 64)
let v1335 = 0 + 1
let v1336 = v1335 + 1
let v1337 = v1336 + 1
let v1338 = v1337 + 1
let v1339 = 0 + 1
let v1340 = v1339 + 1
let v1341 = v1340 + 1
let v1342 = v1341 + 1
let v1343 = v1338 == v1342
let v1344 =
    case v1343 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1345 = 0 + 1
let v1346 = 0 + 1
let v1347 = v1345 == v1346
let v1348 =
    case v1347 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1349 = 0 + 1
let v1350 = v1349 + 1
let v1351 = v1350 + 1
let v1352 = v1351 + 1
let v1353 = v1352 + 1
let v1354 = 0 + 1
let v1355 = v1354 + 1
let v1356 = v1355 + 1
let v1357 = v1356 + 1
let v1358 = v1357 + 1
let v1359 = v1353 == v1358
let v1360 =
    case v1359 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1363 = spiral_wrap_signed(v1348 + v1360, 64)
let v1366 = spiral_wrap_signed(v1344 + v1363, 64)
let v1367 = 0 + 1
let v1368 = v1367 + 1
let v1369 = v1368 + 1
let v1370 = v1369 + 1
let v1371 = 0 + 1
let v1372 = v1371 + 1
let v1373 = v1372 + 1
let v1374 = v1373 + 1
let v1375 = v1370 == v1374
let v1376 =
    case v1375 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1377 = 0 + 1
let v1378 = 0 + 1
let v1379 = v1377 == v1378
let v1380 =
    case v1379 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1381 = 0 + 1
let v1382 = v1381 + 1
let v1383 = v1382 + 1
let v1384 = v1383 + 1
let v1385 = v1384 + 1
let v1386 = 0 + 1
let v1387 = v1386 + 1
let v1388 = v1387 + 1
let v1389 = v1388 + 1
let v1390 = v1389 + 1
let v1391 = v1385 == v1390
let v1392 =
    case v1391 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1395 = spiral_wrap_signed(v1380 + v1392, 64)
let v1398 = spiral_wrap_signed(v1376 + v1395, 64)
let v1399 = 0 + 1
let v1400 = v1399 + 1
let v1401 = v1400 + 1
let v1402 = v1401 + 1
let v1403 = 0 + 1
let v1404 = v1403 + 1
let v1405 = v1404 + 1
let v1406 = v1405 + 1
let v1407 = v1402 == v1406
let v1408 =
    case v1407 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1409 = 0 + 1
let v1410 = 0 + 1
let v1411 = v1409 == v1410
let v1412 =
    case v1411 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1413 = 0 + 1
let v1414 = v1413 + 1
let v1415 = v1414 + 1
let v1416 = v1415 + 1
let v1417 = v1416 + 1
let v1418 = 0 + 1
let v1419 = v1418 + 1
let v1420 = v1419 + 1
let v1421 = v1420 + 1
let v1422 = v1421 + 1
let v1423 = v1417 == v1422
let v1424 =
    case v1423 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1427 = spiral_wrap_signed(v1412 + v1424, 64)
let v1430 = spiral_wrap_signed(v1408 + v1427, 64)
let v1431 = 0 + 1
let v1432 = v1431 + 1
let v1433 = v1432 + 1
let v1434 = v1433 + 1
let v1435 = 0 + 1
let v1436 = v1435 + 1
let v1437 = v1436 + 1
let v1438 = v1437 + 1
let v1439 = v1434 == v1438
let v1440 =
    case v1439 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1441 = 0 + 1
let v1442 = 0 + 1
let v1443 = v1441 == v1442
let v1444 =
    case v1443 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1445 = 0 + 1
let v1446 = v1445 + 1
let v1447 = v1446 + 1
let v1448 = v1447 + 1
let v1449 = v1448 + 1
let v1450 = 0 + 1
let v1451 = v1450 + 1
let v1452 = v1451 + 1
let v1453 = v1452 + 1
let v1454 = v1453 + 1
let v1455 = v1449 == v1454
let v1456 =
    case v1455 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1459 = spiral_wrap_signed(v1444 + v1456, 64)
let v1462 = spiral_wrap_signed(v1440 + v1459, 64)
let v1463 = spiral_wrap_signed(v1430 + v1462, 64)
let v1464 = spiral_wrap_signed(v1398 + v1463, 64)
let v1465 = spiral_wrap_signed(v1366 + v1464, 64)
let v1466 = spiral_wrap_signed(v1334 + v1465, 64)
let v1467 = spiral_wrap_signed(v1302 + v1466, 64)
let v1468 = 0 + 1
let v1469 = v1468 + 1
let v1470 = v1469 + 1
let v1471 = v1470 + 1
let v1472 = 0 + 1
let v1473 = v1472 + 1
let v1474 = v1473 + 1
let v1475 = v1474 + 1
let v1476 = v1471 == v1475
let v1477 =
    case v1476 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1478 = 0 + 1
let v1479 = 0 + 1
let v1480 = v1478 == v1479
let v1481 =
    case v1480 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1482 = 0 + 1
let v1483 = v1482 + 1
let v1484 = v1483 + 1
let v1485 = v1484 + 1
let v1486 = v1485 + 1
let v1487 = 0 + 1
let v1488 = v1487 + 1
let v1489 = v1488 + 1
let v1490 = v1489 + 1
let v1491 = v1490 + 1
let v1492 = v1486 == v1491
let v1493 =
    case v1492 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1496 = spiral_wrap_signed(v1481 + v1493, 64)
let v1499 = spiral_wrap_signed(v1477 + v1496, 64)
let v1500 = 0 + 1
let v1501 = v1500 + 1
let v1502 = v1501 + 1
let v1503 = v1502 + 1
let v1504 = 0 + 1
let v1505 = v1504 + 1
let v1506 = v1505 + 1
let v1507 = v1506 + 1
let v1508 = v1503 == v1507
let v1509 =
    case v1508 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1510 = 0 + 1
let v1511 = 0 + 1
let v1512 = v1510 == v1511
let v1513 =
    case v1512 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1514 = 0 + 1
let v1515 = v1514 + 1
let v1516 = v1515 + 1
let v1517 = v1516 + 1
let v1518 = v1517 + 1
let v1519 = 0 + 1
let v1520 = v1519 + 1
let v1521 = v1520 + 1
let v1522 = v1521 + 1
let v1523 = v1522 + 1
let v1524 = v1518 == v1523
let v1525 =
    case v1524 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1528 = spiral_wrap_signed(v1513 + v1525, 64)
let v1531 = spiral_wrap_signed(v1509 + v1528, 64)
let v1532 = 0 + 1
let v1533 = v1532 + 1
let v1534 = v1533 + 1
let v1535 = v1534 + 1
let v1536 = 0 + 1
let v1537 = v1536 + 1
let v1538 = v1537 + 1
let v1539 = v1538 + 1
let v1540 = v1535 == v1539
let v1541 =
    case v1540 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1542 = 0 + 1
let v1543 = 0 + 1
let v1544 = v1542 == v1543
let v1545 =
    case v1544 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1546 = 0 + 1
let v1547 = v1546 + 1
let v1548 = v1547 + 1
let v1549 = v1548 + 1
let v1550 = v1549 + 1
let v1551 = 0 + 1
let v1552 = v1551 + 1
let v1553 = v1552 + 1
let v1554 = v1553 + 1
let v1555 = v1554 + 1
let v1556 = v1550 == v1555
let v1557 =
    case v1556 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1560 = spiral_wrap_signed(v1545 + v1557, 64)
let v1563 = spiral_wrap_signed(v1541 + v1560, 64)
let v1564 = 0 + 1
let v1565 = v1564 + 1
let v1566 = v1565 + 1
let v1567 = v1566 + 1
let v1568 = 0 + 1
let v1569 = v1568 + 1
let v1570 = v1569 + 1
let v1571 = v1570 + 1
let v1572 = v1567 == v1571
let v1573 =
    case v1572 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1574 = 0 + 1
let v1575 = 0 + 1
let v1576 = v1574 == v1575
let v1577 =
    case v1576 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1578 = 0 + 1
let v1579 = v1578 + 1
let v1580 = v1579 + 1
let v1581 = v1580 + 1
let v1582 = v1581 + 1
let v1583 = 0 + 1
let v1584 = v1583 + 1
let v1585 = v1584 + 1
let v1586 = v1585 + 1
let v1587 = v1586 + 1
let v1588 = v1582 == v1587
let v1589 =
    case v1588 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1592 = spiral_wrap_signed(v1577 + v1589, 64)
let v1595 = spiral_wrap_signed(v1573 + v1592, 64)
let v1596 = 0 + 1
let v1597 = v1596 + 1
let v1598 = v1597 + 1
let v1599 = v1598 + 1
let v1600 = 0 + 1
let v1601 = v1600 + 1
let v1602 = v1601 + 1
let v1603 = v1602 + 1
let v1604 = v1599 == v1603
let v1605 =
    case v1604 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1606 = 0 + 1
let v1607 = 0 + 1
let v1608 = v1606 == v1607
let v1609 =
    case v1608 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1610 = 0 + 1
let v1611 = v1610 + 1
let v1612 = v1611 + 1
let v1613 = v1612 + 1
let v1614 = v1613 + 1
let v1615 = 0 + 1
let v1616 = v1615 + 1
let v1617 = v1616 + 1
let v1618 = v1617 + 1
let v1619 = v1618 + 1
let v1620 = v1614 == v1619
let v1621 =
    case v1620 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1624 = spiral_wrap_signed(v1609 + v1621, 64)
let v1627 = spiral_wrap_signed(v1605 + v1624, 64)
let v1628 = 0 + 1
let v1629 = v1628 + 1
let v1630 = v1629 + 1
let v1631 = v1630 + 1
let v1632 = 0 + 1
let v1633 = v1632 + 1
let v1634 = v1633 + 1
let v1635 = v1634 + 1
let v1636 = v1631 == v1635
let v1637 =
    case v1636 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1638 = 0 + 1
let v1639 = 0 + 1
let v1640 = v1638 == v1639
let v1641 =
    case v1640 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1642 = 0 + 1
let v1643 = v1642 + 1
let v1644 = v1643 + 1
let v1645 = v1644 + 1
let v1646 = v1645 + 1
let v1647 = 0 + 1
let v1648 = v1647 + 1
let v1649 = v1648 + 1
let v1650 = v1649 + 1
let v1651 = v1650 + 1
let v1652 = v1646 == v1651
let v1653 =
    case v1652 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1656 = spiral_wrap_signed(v1641 + v1653, 64)
let v1659 = spiral_wrap_signed(v1637 + v1656, 64)
let v1660 = spiral_wrap_signed(v1627 + v1659, 64)
let v1661 = spiral_wrap_signed(v1595 + v1660, 64)
let v1662 = spiral_wrap_signed(v1563 + v1661, 64)
let v1663 = spiral_wrap_signed(v1531 + v1662, 64)
let v1664 = spiral_wrap_signed(v1499 + v1663, 64)
let v1665 = v1467 == 0
let v1666 = v1664 == v1467
let v1667 = v1665 && v1666
case v1667 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-stale-writer-conflict-program-append-associativity-runtime-mismatch"
    }
}
let v1668 = 0 + 1
let v1669 = v1668 + 1
let v1670 = v1669 + 1
let v1671 = v1670 + 1
let v1672 = 0 + 1
let v1673 = v1672 + 1
let v1674 = v1673 + 1
let v1675 = v1674 + 1
let v1676 = v1671 == v1675
let v1677 =
    case v1676 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1678 = 0 + 1
let v1679 = 0 + 1
let v1680 = v1678 == v1679
let v1681 =
    case v1680 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1682 = 0 + 1
let v1683 = v1682 + 1
let v1684 = v1683 + 1
let v1685 = v1684 + 1
let v1686 = v1685 + 1
let v1687 = 0 + 1
let v1688 = v1687 + 1
let v1689 = v1688 + 1
let v1690 = v1689 + 1
let v1691 = v1690 + 1
let v1692 = v1686 == v1691
let v1693 =
    case v1692 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1696 = spiral_wrap_signed(v1681 + v1693, 64)
let v1699 = spiral_wrap_signed(v1677 + v1696, 64)
let v1700 = 0 + 1
let v1701 = v1700 + 1
let v1702 = v1701 + 1
let v1703 = v1702 + 1
let v1704 = 0 + 1
let v1705 = v1704 + 1
let v1706 = v1705 + 1
let v1707 = v1706 + 1
let v1708 = v1703 == v1707
let v1709 =
    case v1708 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1710 = 0 + 1
let v1711 = 0 + 1
let v1712 = v1710 == v1711
let v1713 =
    case v1712 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1714 = 0 + 1
let v1715 = v1714 + 1
let v1716 = v1715 + 1
let v1717 = v1716 + 1
let v1718 = v1717 + 1
let v1719 = 0 + 1
let v1720 = v1719 + 1
let v1721 = v1720 + 1
let v1722 = v1721 + 1
let v1723 = v1722 + 1
let v1724 = v1718 == v1723
let v1725 =
    case v1724 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1728 = spiral_wrap_signed(v1713 + v1725, 64)
let v1731 = spiral_wrap_signed(v1709 + v1728, 64)
let v1732 = spiral_wrap_signed(v1699 + v1731, 64)
let v1733 = 0 + 1
let v1734 = v1733 + 1
let v1735 = v1734 + 1
let v1736 = v1735 + 1
let v1737 = 0 + 1
let v1738 = v1737 + 1
let v1739 = v1738 + 1
let v1740 = v1739 + 1
let v1741 = v1736 == v1740
let v1742 =
    case v1741 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1743 = 0 + 1
let v1744 = 0 + 1
let v1745 = v1743 == v1744
let v1746 =
    case v1745 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1747 = 0 + 1
let v1748 = v1747 + 1
let v1749 = v1748 + 1
let v1750 = v1749 + 1
let v1751 = v1750 + 1
let v1752 = 0 + 1
let v1753 = v1752 + 1
let v1754 = v1753 + 1
let v1755 = v1754 + 1
let v1756 = v1755 + 1
let v1757 = v1751 == v1756
let v1758 =
    case v1757 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1761 = spiral_wrap_signed(v1746 + v1758, 64)
let v1764 = spiral_wrap_signed(v1742 + v1761, 64)
let v1765 = 0 + 1
let v1766 = v1765 + 1
let v1767 = v1766 + 1
let v1768 = v1767 + 1
let v1769 = 0 + 1
let v1770 = v1769 + 1
let v1771 = v1770 + 1
let v1772 = v1771 + 1
let v1773 = v1768 == v1772
let v1774 =
    case v1773 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1775 = 0 + 1
let v1776 = 0 + 1
let v1777 = v1775 == v1776
let v1778 =
    case v1777 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1779 = 0 + 1
let v1780 = v1779 + 1
let v1781 = v1780 + 1
let v1782 = v1781 + 1
let v1783 = v1782 + 1
let v1784 = 0 + 1
let v1785 = v1784 + 1
let v1786 = v1785 + 1
let v1787 = v1786 + 1
let v1788 = v1787 + 1
let v1789 = v1783 == v1788
let v1790 =
    case v1789 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1793 = spiral_wrap_signed(v1778 + v1790, 64)
let v1796 = spiral_wrap_signed(v1774 + v1793, 64)
let v1797 = 0 + 1
let v1798 = v1797 + 1
let v1799 = v1798 + 1
let v1800 = v1799 + 1
let v1801 = 0 + 1
let v1802 = v1801 + 1
let v1803 = v1802 + 1
let v1804 = v1803 + 1
let v1805 = v1800 == v1804
let v1806 =
    case v1805 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1807 = 0 + 1
let v1808 = 0 + 1
let v1809 = v1807 == v1808
let v1810 =
    case v1809 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1811 = 0 + 1
let v1812 = v1811 + 1
let v1813 = v1812 + 1
let v1814 = v1813 + 1
let v1815 = v1814 + 1
let v1816 = 0 + 1
let v1817 = v1816 + 1
let v1818 = v1817 + 1
let v1819 = v1818 + 1
let v1820 = v1819 + 1
let v1821 = v1815 == v1820
let v1822 =
    case v1821 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1825 = spiral_wrap_signed(v1810 + v1822, 64)
let v1828 = spiral_wrap_signed(v1806 + v1825, 64)
let v1829 = 0 + 1
let v1830 = v1829 + 1
let v1831 = v1830 + 1
let v1832 = v1831 + 1
let v1833 = 0 + 1
let v1834 = v1833 + 1
let v1835 = v1834 + 1
let v1836 = v1835 + 1
let v1837 = v1832 == v1836
let v1838 =
    case v1837 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1839 = 0 + 1
let v1840 = 0 + 1
let v1841 = v1839 == v1840
let v1842 =
    case v1841 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1843 = 0 + 1
let v1844 = v1843 + 1
let v1845 = v1844 + 1
let v1846 = v1845 + 1
let v1847 = v1846 + 1
let v1848 = 0 + 1
let v1849 = v1848 + 1
let v1850 = v1849 + 1
let v1851 = v1850 + 1
let v1852 = v1851 + 1
let v1853 = v1847 == v1852
let v1854 =
    case v1853 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1857 = spiral_wrap_signed(v1842 + v1854, 64)
let v1860 = spiral_wrap_signed(v1838 + v1857, 64)
let v1861 = spiral_wrap_signed(v1828 + v1860, 64)
let v1862 = spiral_wrap_signed(v1796 + v1861, 64)
let v1863 = spiral_wrap_signed(v1764 + v1862, 64)
let v1864 = spiral_wrap_signed(v1732 + v1863, 64)
let v1865 = 0 + 1
let v1866 = v1865 + 1
let v1867 = v1866 + 1
let v1868 = v1867 + 1
let v1869 = 0 + 1
let v1870 = v1869 + 1
let v1871 = v1870 + 1
let v1872 = v1871 + 1
let v1873 = v1868 == v1872
let v1874 =
    case v1873 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1875 = 0 + 1
let v1876 = 0 + 1
let v1877 = v1875 == v1876
let v1878 =
    case v1877 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1879 = 0 + 1
let v1880 = v1879 + 1
let v1881 = v1880 + 1
let v1882 = v1881 + 1
let v1883 = v1882 + 1
let v1884 = 0 + 1
let v1885 = v1884 + 1
let v1886 = v1885 + 1
let v1887 = v1886 + 1
let v1888 = v1887 + 1
let v1889 = v1883 == v1888
let v1890 =
    case v1889 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1891 = spiral_wrap_signed(v1875 + v1883, 64)
let v1892 = spiral_wrap_signed(v1876 + v1888, 64)
let v1893 = spiral_wrap_signed(v1878 + v1890, 64)
let v1894 = spiral_wrap_signed(v1868 + v1891, 64)
let v1895 = spiral_wrap_signed(v1872 + v1892, 64)
let v1896 = spiral_wrap_signed(v1874 + v1893, 64)
let v1897 = spiral_wrap_signed(v1895 + v1896, 64)
let v1898 = spiral_wrap_signed(v1894 + v1897, 64)
let v1899 = spiral_wrap_signed(3 + v1898, 64)
let v1900 = 0 + 1
let v1901 = v1900 + 1
let v1902 = v1901 + 1
let v1903 = v1902 + 1
let v1904 = 0 + 1
let v1905 = v1904 + 1
let v1906 = v1905 + 1
let v1907 = v1906 + 1
let v1908 = v1903 == v1907
let v1909 =
    case v1908 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1910 = 0 + 1
let v1911 = 0 + 1
let v1912 = v1910 == v1911
let v1913 =
    case v1912 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1914 = 0 + 1
let v1915 = v1914 + 1
let v1916 = v1915 + 1
let v1917 = v1916 + 1
let v1918 = v1917 + 1
let v1919 = 0 + 1
let v1920 = v1919 + 1
let v1921 = v1920 + 1
let v1922 = v1921 + 1
let v1923 = v1922 + 1
let v1924 = v1918 == v1923
let v1925 =
    case v1924 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v1926 = spiral_wrap_signed(v1910 + v1918, 64)
let v1927 = spiral_wrap_signed(v1911 + v1923, 64)
let v1928 = spiral_wrap_signed(v1913 + v1925, 64)
let v1929 = spiral_wrap_signed(v1903 + v1926, 64)
let v1930 = spiral_wrap_signed(v1907 + v1927, 64)
let v1931 = spiral_wrap_signed(v1909 + v1928, 64)
let v1932 = spiral_wrap_signed(v1930 + v1931, 64)
let v1933 = spiral_wrap_signed(v1929 + v1932, 64)
let v1934 = spiral_wrap_signed(3 + v1933, 64)
let v1935 = v1899 == v1934
let v1972 =
    case v1935 {
        True -> {
            let v1936 = 0 + 1
            let v1937 = v1936 + 1
            let v1938 = v1937 + 1
            let v1939 = v1938 + 1
            let v1940 = 0 + 1
            let v1941 = v1940 + 1
            let v1942 = v1941 + 1
            let v1943 = v1942 + 1
            let v1944 = v1939 == v1943
            let v1945 =
                case v1944 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v1946 = 0 + 1
            let v1947 = 0 + 1
            let v1948 = v1946 == v1947
            let v1949 =
                case v1948 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v1950 = 0 + 1
            let v1951 = v1950 + 1
            let v1952 = v1951 + 1
            let v1953 = v1952 + 1
            let v1954 = v1953 + 1
            let v1955 = 0 + 1
            let v1956 = v1955 + 1
            let v1957 = v1956 + 1
            let v1958 = v1957 + 1
            let v1959 = v1958 + 1
            let v1960 = v1954 == v1959
            let v1961 =
                case v1960 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v1962 = spiral_wrap_signed(v1946 + v1954, 64)
            let v1963 = spiral_wrap_signed(v1947 + v1959, 64)
            let v1964 = spiral_wrap_signed(v1949 + v1961, 64)
            let v1965 = spiral_wrap_signed(v1939 + v1962, 64)
            let v1966 = spiral_wrap_signed(v1943 + v1963, 64)
            let v1967 = spiral_wrap_signed(v1945 + v1964, 64)
            let v1968 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
            Us0TypedFxHashedStatementChecksumValidationAccepted(1, 3, v1965, v1966, v1967, v1968)
        }
        False -> {
            let v1970 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
            Us0TypedFxHashedStatementChecksumValidationRejected(v1899, v1934, v1970)
        }
    }
let #(v1991, v1992, v1995, v1999) =
    case v1972  {
        Us0TypedFxHashedStatementChecksumValidationAccepted(v1976, v1977, v1978, v1979, v1980, v1981) -> {
            #(1, 0, v1976, v1980)
        }
        Us0TypedFxHashedStatementChecksumValidationRejected(v1973, v1974, v1975) -> {
            #(0, 1, 0, 0)
        }
    }
let v2000 = 0 + 1
let v2001 = v2000 + 1
let v2002 = v2001 + 1
let v2003 = v2002 + 1
let v2004 = 0 + 1
let v2005 = v2004 + 1
let v2006 = v2005 + 1
let v2007 = v2006 + 1
let v2008 = v2003 == v2007
let v2009 =
    case v2008 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2010 = 0 + 1
let v2011 = 0 + 1
let v2012 = v2010 == v2011
let v2013 =
    case v2012 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2014 = 0 + 1
let v2015 = v2014 + 1
let v2016 = v2015 + 1
let v2017 = v2016 + 1
let v2018 = v2017 + 1
let v2019 = 0 + 1
let v2020 = v2019 + 1
let v2021 = v2020 + 1
let v2022 = v2021 + 1
let v2023 = v2022 + 1
let v2024 = v2018 == v2023
let v2025 =
    case v2024 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2028 = spiral_wrap_signed(v2013 + v2025, 64)
let v2031 = spiral_wrap_signed(v2009 + v2028, 64)
let v2032 = 0 + 1
let v2033 = v2032 + 1
let v2034 = v2033 + 1
let v2035 = v2034 + 1
let v2036 = 0 + 1
let v2037 = v2036 + 1
let v2038 = v2037 + 1
let v2039 = v2038 + 1
let v2040 = v2035 == v2039
let v2041 =
    case v2040 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2042 = 0 + 1
let v2043 = 0 + 1
let v2044 = v2042 == v2043
let v2045 =
    case v2044 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2046 = 0 + 1
let v2047 = v2046 + 1
let v2048 = v2047 + 1
let v2049 = v2048 + 1
let v2050 = v2049 + 1
let v2051 = 0 + 1
let v2052 = v2051 + 1
let v2053 = v2052 + 1
let v2054 = v2053 + 1
let v2055 = v2054 + 1
let v2056 = v2050 == v2055
let v2057 =
    case v2056 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2060 = spiral_wrap_signed(v2045 + v2057, 64)
let v2063 = spiral_wrap_signed(v2041 + v2060, 64)
let v2064 = 0 + 1
let v2065 = v2064 + 1
let v2066 = v2065 + 1
let v2067 = v2066 + 1
let v2068 = 0 + 1
let v2069 = v2068 + 1
let v2070 = v2069 + 1
let v2071 = v2070 + 1
let v2072 = v2067 == v2071
let v2073 =
    case v2072 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2074 = 0 + 1
let v2075 = 0 + 1
let v2076 = v2074 == v2075
let v2077 =
    case v2076 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2078 = 0 + 1
let v2079 = v2078 + 1
let v2080 = v2079 + 1
let v2081 = v2080 + 1
let v2082 = v2081 + 1
let v2083 = 0 + 1
let v2084 = v2083 + 1
let v2085 = v2084 + 1
let v2086 = v2085 + 1
let v2087 = v2086 + 1
let v2088 = v2082 == v2087
let v2089 =
    case v2088 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2092 = spiral_wrap_signed(v2077 + v2089, 64)
let v2095 = spiral_wrap_signed(v2073 + v2092, 64)
let v2096 = 0 + 1
let v2097 = v2096 + 1
let v2098 = v2097 + 1
let v2099 = v2098 + 1
let v2100 = 0 + 1
let v2101 = v2100 + 1
let v2102 = v2101 + 1
let v2103 = v2102 + 1
let v2104 = v2099 == v2103
let v2105 =
    case v2104 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2106 = 0 + 1
let v2107 = 0 + 1
let v2108 = v2106 == v2107
let v2109 =
    case v2108 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2110 = 0 + 1
let v2111 = v2110 + 1
let v2112 = v2111 + 1
let v2113 = v2112 + 1
let v2114 = v2113 + 1
let v2115 = 0 + 1
let v2116 = v2115 + 1
let v2117 = v2116 + 1
let v2118 = v2117 + 1
let v2119 = v2118 + 1
let v2120 = v2114 == v2119
let v2121 =
    case v2120 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2124 = spiral_wrap_signed(v2109 + v2121, 64)
let v2127 = spiral_wrap_signed(v2105 + v2124, 64)
let v2128 = spiral_wrap_signed(v2095 + v2127, 64)
let v2129 = spiral_wrap_signed(v2063 + v2128, 64)
let v2130 = spiral_wrap_signed(v2031 + v2129, 64)
let v2131 = spiral_wrap_signed(v1999 + v1992, 64)
let v2132 = spiral_wrap_signed(v2130 + v2131, 64)
let v2133 = spiral_wrap_signed(v1864 + v2132, 64)
let v2134 = v1995 == 1
let v2135 = v1991 == 1
let v2136 = v2133 == 0
let v2137 = v2134 && v2135
let v2138 = v2137 && v2136
case v2138 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-recursive-writer-appended-tail-restart-runtime-mismatch"
    }
}
let v2139 = 0 + 1
let v2140 = v2139 + 1
let v2141 = v2140 + 1
let v2142 = v2141 + 1
let v2143 = 0 + 1
let v2144 = v2143 + 1
let v2145 = v2144 + 1
let v2146 = v2145 + 1
let v2147 = v2142 == v2146
let v2148 =
    case v2147 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2149 = 0 + 1
let v2150 = 0 + 1
let v2151 = v2149 == v2150
let v2152 =
    case v2151 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2153 = 0 + 1
let v2154 = v2153 + 1
let v2155 = v2154 + 1
let v2156 = v2155 + 1
let v2157 = v2156 + 1
let v2158 = 0 + 1
let v2159 = v2158 + 1
let v2160 = v2159 + 1
let v2161 = v2160 + 1
let v2162 = v2161 + 1
let v2163 = v2157 == v2162
let v2164 =
    case v2163 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2167 = spiral_wrap_signed(v2152 + v2164, 64)
let v2170 = spiral_wrap_signed(v2148 + v2167, 64)
let v2171 = 0 + 1
let v2172 = v2171 + 1
let v2173 = v2172 + 1
let v2174 = v2173 + 1
let v2175 = 0 + 1
let v2176 = v2175 + 1
let v2177 = v2176 + 1
let v2178 = v2177 + 1
let v2179 = v2174 == v2178
let v2180 =
    case v2179 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2181 = 0 + 1
let v2182 = 0 + 1
let v2183 = v2181 == v2182
let v2184 =
    case v2183 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2185 = 0 + 1
let v2186 = v2185 + 1
let v2187 = v2186 + 1
let v2188 = v2187 + 1
let v2189 = v2188 + 1
let v2190 = 0 + 1
let v2191 = v2190 + 1
let v2192 = v2191 + 1
let v2193 = v2192 + 1
let v2194 = v2193 + 1
let v2195 = v2189 == v2194
let v2196 =
    case v2195 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2199 = spiral_wrap_signed(v2184 + v2196, 64)
let v2202 = spiral_wrap_signed(v2180 + v2199, 64)
let v2203 = spiral_wrap_signed(v2170 + v2202, 64)
let v2204 = 0 + 1
let v2205 = v2204 + 1
let v2206 = v2205 + 1
let v2207 = v2206 + 1
let v2208 = 0 + 1
let v2209 = v2208 + 1
let v2210 = v2209 + 1
let v2211 = v2210 + 1
let v2212 = v2207 == v2211
let v2213 =
    case v2212 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2214 = 0 + 1
let v2215 = 0 + 1
let v2216 = v2214 == v2215
let v2217 =
    case v2216 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2218 = 0 + 1
let v2219 = v2218 + 1
let v2220 = v2219 + 1
let v2221 = v2220 + 1
let v2222 = v2221 + 1
let v2223 = 0 + 1
let v2224 = v2223 + 1
let v2225 = v2224 + 1
let v2226 = v2225 + 1
let v2227 = v2226 + 1
let v2228 = v2222 == v2227
let v2229 =
    case v2228 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2232 = spiral_wrap_signed(v2217 + v2229, 64)
let v2235 = spiral_wrap_signed(v2213 + v2232, 64)
let v2236 = 0 + 1
let v2237 = v2236 + 1
let v2238 = v2237 + 1
let v2239 = v2238 + 1
let v2240 = 0 + 1
let v2241 = v2240 + 1
let v2242 = v2241 + 1
let v2243 = v2242 + 1
let v2244 = v2239 == v2243
let v2245 =
    case v2244 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2246 = 0 + 1
let v2247 = 0 + 1
let v2248 = v2246 == v2247
let v2249 =
    case v2248 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2250 = 0 + 1
let v2251 = v2250 + 1
let v2252 = v2251 + 1
let v2253 = v2252 + 1
let v2254 = v2253 + 1
let v2255 = 0 + 1
let v2256 = v2255 + 1
let v2257 = v2256 + 1
let v2258 = v2257 + 1
let v2259 = v2258 + 1
let v2260 = v2254 == v2259
let v2261 =
    case v2260 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2264 = spiral_wrap_signed(v2249 + v2261, 64)
let v2267 = spiral_wrap_signed(v2245 + v2264, 64)
let v2268 = spiral_wrap_signed(v2235 + v2267, 64)
let v2269 = spiral_wrap_signed(v2203 + v2268, 64)
let v2270 = 0 + 1
let v2271 = v2270 + 1
let v2272 = v2271 + 1
let v2273 = v2272 + 1
let v2274 = 0 + 1
let v2275 = v2274 + 1
let v2276 = v2275 + 1
let v2277 = v2276 + 1
let v2278 = v2273 == v2277
let v2279 =
    case v2278 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2280 = 0 + 1
let v2281 = 0 + 1
let v2282 = v2280 == v2281
let v2283 =
    case v2282 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2284 = 0 + 1
let v2285 = v2284 + 1
let v2286 = v2285 + 1
let v2287 = v2286 + 1
let v2288 = v2287 + 1
let v2289 = 0 + 1
let v2290 = v2289 + 1
let v2291 = v2290 + 1
let v2292 = v2291 + 1
let v2293 = v2292 + 1
let v2294 = v2288 == v2293
let v2295 =
    case v2294 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2296 = spiral_wrap_signed(v2280 + v2288, 64)
let v2297 = spiral_wrap_signed(v2281 + v2293, 64)
let v2298 = spiral_wrap_signed(v2283 + v2295, 64)
let v2299 = spiral_wrap_signed(v2273 + v2296, 64)
let v2300 = spiral_wrap_signed(v2277 + v2297, 64)
let v2301 = spiral_wrap_signed(v2279 + v2298, 64)
let v2302 = spiral_wrap_signed(v2300 + v2301, 64)
let v2303 = spiral_wrap_signed(v2299 + v2302, 64)
let v2304 = spiral_wrap_signed(3 + v2303, 64)
let v2305 = 0 + 1
let v2306 = v2305 + 1
let v2307 = v2306 + 1
let v2308 = v2307 + 1
let v2309 = 0 + 1
let v2310 = v2309 + 1
let v2311 = v2310 + 1
let v2312 = v2311 + 1
let v2313 = v2308 == v2312
let v2314 =
    case v2313 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2315 = 0 + 1
let v2316 = 0 + 1
let v2317 = v2315 == v2316
let v2318 =
    case v2317 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2319 = 0 + 1
let v2320 = v2319 + 1
let v2321 = v2320 + 1
let v2322 = v2321 + 1
let v2323 = v2322 + 1
let v2324 = 0 + 1
let v2325 = v2324 + 1
let v2326 = v2325 + 1
let v2327 = v2326 + 1
let v2328 = v2327 + 1
let v2329 = v2323 == v2328
let v2330 =
    case v2329 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2331 = spiral_wrap_signed(v2315 + v2323, 64)
let v2332 = spiral_wrap_signed(v2316 + v2328, 64)
let v2333 = spiral_wrap_signed(v2318 + v2330, 64)
let v2334 = spiral_wrap_signed(v2308 + v2331, 64)
let v2335 = spiral_wrap_signed(v2312 + v2332, 64)
let v2336 = spiral_wrap_signed(v2314 + v2333, 64)
let v2337 = spiral_wrap_signed(v2335 + v2336, 64)
let v2338 = spiral_wrap_signed(v2334 + v2337, 64)
let v2339 = spiral_wrap_signed(3 + v2338, 64)
let v2340 = v2304 == v2339
let v2377 =
    case v2340 {
        True -> {
            let v2341 = 0 + 1
            let v2342 = v2341 + 1
            let v2343 = v2342 + 1
            let v2344 = v2343 + 1
            let v2345 = 0 + 1
            let v2346 = v2345 + 1
            let v2347 = v2346 + 1
            let v2348 = v2347 + 1
            let v2349 = v2344 == v2348
            let v2350 =
                case v2349 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v2351 = 0 + 1
            let v2352 = 0 + 1
            let v2353 = v2351 == v2352
            let v2354 =
                case v2353 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v2355 = 0 + 1
            let v2356 = v2355 + 1
            let v2357 = v2356 + 1
            let v2358 = v2357 + 1
            let v2359 = v2358 + 1
            let v2360 = 0 + 1
            let v2361 = v2360 + 1
            let v2362 = v2361 + 1
            let v2363 = v2362 + 1
            let v2364 = v2363 + 1
            let v2365 = v2359 == v2364
            let v2366 =
                case v2365 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v2367 = spiral_wrap_signed(v2351 + v2359, 64)
            let v2368 = spiral_wrap_signed(v2352 + v2364, 64)
            let v2369 = spiral_wrap_signed(v2354 + v2366, 64)
            let v2370 = spiral_wrap_signed(v2344 + v2367, 64)
            let v2371 = spiral_wrap_signed(v2348 + v2368, 64)
            let v2372 = spiral_wrap_signed(v2350 + v2369, 64)
            let v2373 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
            Us0TypedFxHashedStatementChecksumValidationAccepted(1, 3, v2370, v2371, v2372, v2373)
        }
        False -> {
            let v2375 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
            Us0TypedFxHashedStatementChecksumValidationRejected(v2304, v2339, v2375)
        }
    }
let #(v2396, v2397, v2404) =
    case v2377  {
        Us0TypedFxHashedStatementChecksumValidationAccepted(v2381, v2382, v2383, v2384, v2385, v2386) -> {
            #(1, 0, v2385)
        }
        Us0TypedFxHashedStatementChecksumValidationRejected(v2378, v2379, v2380) -> {
            #(0, 1, 0)
        }
    }
let v2405 = 0 + 1
let v2406 = v2405 + 1
let v2407 = v2406 + 1
let v2408 = v2407 + 1
let v2409 = 0 + 1
let v2410 = v2409 + 1
let v2411 = v2410 + 1
let v2412 = v2411 + 1
let v2413 = v2408 == v2412
let v2414 =
    case v2413 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2415 = 0 + 1
let v2416 = 0 + 1
let v2417 = v2415 == v2416
let v2418 =
    case v2417 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2419 = 0 + 1
let v2420 = v2419 + 1
let v2421 = v2420 + 1
let v2422 = v2421 + 1
let v2423 = v2422 + 1
let v2424 = 0 + 1
let v2425 = v2424 + 1
let v2426 = v2425 + 1
let v2427 = v2426 + 1
let v2428 = v2427 + 1
let v2429 = v2423 == v2428
let v2430 =
    case v2429 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2433 = spiral_wrap_signed(v2418 + v2430, 64)
let v2436 = spiral_wrap_signed(v2414 + v2433, 64)
let v2437 = 0 + 1
let v2438 = v2437 + 1
let v2439 = v2438 + 1
let v2440 = v2439 + 1
let v2441 = 0 + 1
let v2442 = v2441 + 1
let v2443 = v2442 + 1
let v2444 = v2443 + 1
let v2445 = v2440 == v2444
let v2446 =
    case v2445 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2447 = 0 + 1
let v2448 = 0 + 1
let v2449 = v2447 == v2448
let v2450 =
    case v2449 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2451 = 0 + 1
let v2452 = v2451 + 1
let v2453 = v2452 + 1
let v2454 = v2453 + 1
let v2455 = v2454 + 1
let v2456 = 0 + 1
let v2457 = v2456 + 1
let v2458 = v2457 + 1
let v2459 = v2458 + 1
let v2460 = v2459 + 1
let v2461 = v2455 == v2460
let v2462 =
    case v2461 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2465 = spiral_wrap_signed(v2450 + v2462, 64)
let v2468 = spiral_wrap_signed(v2446 + v2465, 64)
let v2469 = spiral_wrap_signed(v2436 + v2468, 64)
let v2470 = spiral_wrap_signed(v2404 + v2397, 64)
let v2471 = spiral_wrap_signed(v2469 + v2470, 64)
let v2472 = spiral_wrap_signed(v2269 + v2471, 64)
let v2473 = v2396 == 1
let v2474 = v2472 == 0
let v2475 = v2473 && v2474
case v2475 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-recursive-writer-crash-phase-runtime-mismatch"
    }
}
let v2476 = 0 + 1
let v2477 = v2476 + 1
let v2478 = v2477 + 1
let v2479 = v2478 + 1
let v2480 = 0 + 1
let v2481 = v2480 + 1
let v2482 = v2481 + 1
let v2483 = v2482 + 1
let v2484 = v2479 == v2483
let v2485 =
    case v2484 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2486 = 0 + 1
let v2487 = 0 + 1
let v2488 = v2486 == v2487
let v2489 =
    case v2488 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2490 = 0 + 1
let v2491 = v2490 + 1
let v2492 = v2491 + 1
let v2493 = v2492 + 1
let v2494 = v2493 + 1
let v2495 = 0 + 1
let v2496 = v2495 + 1
let v2497 = v2496 + 1
let v2498 = v2497 + 1
let v2499 = v2498 + 1
let v2500 = v2494 == v2499
let v2501 =
    case v2500 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2504 = spiral_wrap_signed(v2489 + v2501, 64)
let v2507 = spiral_wrap_signed(v2485 + v2504, 64)
let v2508 = 0 + 1
let v2509 = v2508 + 1
let v2510 = v2509 + 1
let v2511 = v2510 + 1
let v2512 = 0 + 1
let v2513 = v2512 + 1
let v2514 = v2513 + 1
let v2515 = v2514 + 1
let v2516 = v2511 == v2515
let v2517 =
    case v2516 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2518 = 0 + 1
let v2519 = 0 + 1
let v2520 = v2518 == v2519
let v2521 =
    case v2520 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2522 = 0 + 1
let v2523 = v2522 + 1
let v2524 = v2523 + 1
let v2525 = v2524 + 1
let v2526 = v2525 + 1
let v2527 = 0 + 1
let v2528 = v2527 + 1
let v2529 = v2528 + 1
let v2530 = v2529 + 1
let v2531 = v2530 + 1
let v2532 = v2526 == v2531
let v2533 =
    case v2532 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2536 = spiral_wrap_signed(v2521 + v2533, 64)
let v2539 = spiral_wrap_signed(v2517 + v2536, 64)
let v2540 = spiral_wrap_signed(v2507 + v2539, 64)
let v2541 = 0 + 1
let v2542 = v2541 + 1
let v2543 = v2542 + 1
let v2544 = v2543 + 1
let v2545 = 0 + 1
let v2546 = v2545 + 1
let v2547 = v2546 + 1
let v2548 = v2547 + 1
let v2549 = v2544 == v2548
let v2550 =
    case v2549 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2551 = 0 + 1
let v2552 = 0 + 1
let v2553 = v2551 == v2552
let v2554 =
    case v2553 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2555 = 0 + 1
let v2556 = v2555 + 1
let v2557 = v2556 + 1
let v2558 = v2557 + 1
let v2559 = v2558 + 1
let v2560 = 0 + 1
let v2561 = v2560 + 1
let v2562 = v2561 + 1
let v2563 = v2562 + 1
let v2564 = v2563 + 1
let v2565 = v2559 == v2564
let v2566 =
    case v2565 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2569 = spiral_wrap_signed(v2554 + v2566, 64)
let v2572 = spiral_wrap_signed(v2550 + v2569, 64)
let v2573 = 0 + 1
let v2574 = v2573 + 1
let v2575 = v2574 + 1
let v2576 = v2575 + 1
let v2577 = 0 + 1
let v2578 = v2577 + 1
let v2579 = v2578 + 1
let v2580 = v2579 + 1
let v2581 = v2576 == v2580
let v2582 =
    case v2581 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2583 = 0 + 1
let v2584 = 0 + 1
let v2585 = v2583 == v2584
let v2586 =
    case v2585 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2587 = 0 + 1
let v2588 = v2587 + 1
let v2589 = v2588 + 1
let v2590 = v2589 + 1
let v2591 = v2590 + 1
let v2592 = 0 + 1
let v2593 = v2592 + 1
let v2594 = v2593 + 1
let v2595 = v2594 + 1
let v2596 = v2595 + 1
let v2597 = v2591 == v2596
let v2598 =
    case v2597 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2601 = spiral_wrap_signed(v2586 + v2598, 64)
let v2604 = spiral_wrap_signed(v2582 + v2601, 64)
let v2605 = spiral_wrap_signed(v2572 + v2604, 64)
let v2606 = spiral_wrap_signed(v2540 + v2605, 64)
let v2607 = 0 + 1
let v2608 = v2607 + 1
let v2609 = v2608 + 1
let v2610 = v2609 + 1
let v2611 = 0 + 1
let v2612 = v2611 + 1
let v2613 = v2612 + 1
let v2614 = v2613 + 1
let v2615 = v2610 == v2614
let v2616 =
    case v2615 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2617 = 0 + 1
let v2618 = 0 + 1
let v2619 = v2617 == v2618
let v2620 =
    case v2619 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2621 = 0 + 1
let v2622 = v2621 + 1
let v2623 = v2622 + 1
let v2624 = v2623 + 1
let v2625 = v2624 + 1
let v2626 = 0 + 1
let v2627 = v2626 + 1
let v2628 = v2627 + 1
let v2629 = v2628 + 1
let v2630 = v2629 + 1
let v2631 = v2625 == v2630
let v2632 =
    case v2631 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2633 = spiral_wrap_signed(v2617 + v2625, 64)
let v2634 = spiral_wrap_signed(v2618 + v2630, 64)
let v2635 = spiral_wrap_signed(v2620 + v2632, 64)
let v2636 = spiral_wrap_signed(v2610 + v2633, 64)
let v2637 = spiral_wrap_signed(v2614 + v2634, 64)
let v2638 = spiral_wrap_signed(v2616 + v2635, 64)
let v2639 = spiral_wrap_signed(v2637 + v2638, 64)
let v2640 = spiral_wrap_signed(v2636 + v2639, 64)
let v2641 = spiral_wrap_signed(3 + v2640, 64)
let v2642 = 0 + 1
let v2643 = v2642 + 1
let v2644 = v2643 + 1
let v2645 = v2644 + 1
let v2646 = 0 + 1
let v2647 = v2646 + 1
let v2648 = v2647 + 1
let v2649 = v2648 + 1
let v2650 = v2645 == v2649
let v2651 =
    case v2650 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2652 = 0 + 1
let v2653 = 0 + 1
let v2654 = v2652 == v2653
let v2655 =
    case v2654 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2656 = 0 + 1
let v2657 = v2656 + 1
let v2658 = v2657 + 1
let v2659 = v2658 + 1
let v2660 = v2659 + 1
let v2661 = 0 + 1
let v2662 = v2661 + 1
let v2663 = v2662 + 1
let v2664 = v2663 + 1
let v2665 = v2664 + 1
let v2666 = v2660 == v2665
let v2667 =
    case v2666 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2668 = spiral_wrap_signed(v2652 + v2660, 64)
let v2669 = spiral_wrap_signed(v2653 + v2665, 64)
let v2670 = spiral_wrap_signed(v2655 + v2667, 64)
let v2671 = spiral_wrap_signed(v2645 + v2668, 64)
let v2672 = spiral_wrap_signed(v2649 + v2669, 64)
let v2673 = spiral_wrap_signed(v2651 + v2670, 64)
let v2674 = spiral_wrap_signed(v2672 + v2673, 64)
let v2675 = spiral_wrap_signed(v2671 + v2674, 64)
let v2676 = spiral_wrap_signed(3 + v2675, 64)
let v2677 = v2641 == v2676
let v2714 =
    case v2677 {
        True -> {
            let v2678 = 0 + 1
            let v2679 = v2678 + 1
            let v2680 = v2679 + 1
            let v2681 = v2680 + 1
            let v2682 = 0 + 1
            let v2683 = v2682 + 1
            let v2684 = v2683 + 1
            let v2685 = v2684 + 1
            let v2686 = v2681 == v2685
            let v2687 =
                case v2686 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v2688 = 0 + 1
            let v2689 = 0 + 1
            let v2690 = v2688 == v2689
            let v2691 =
                case v2690 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v2692 = 0 + 1
            let v2693 = v2692 + 1
            let v2694 = v2693 + 1
            let v2695 = v2694 + 1
            let v2696 = v2695 + 1
            let v2697 = 0 + 1
            let v2698 = v2697 + 1
            let v2699 = v2698 + 1
            let v2700 = v2699 + 1
            let v2701 = v2700 + 1
            let v2702 = v2696 == v2701
            let v2703 =
                case v2702 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            let v2704 = spiral_wrap_signed(v2688 + v2696, 64)
            let v2705 = spiral_wrap_signed(v2689 + v2701, 64)
            let v2706 = spiral_wrap_signed(v2691 + v2703, 64)
            let v2707 = spiral_wrap_signed(v2681 + v2704, 64)
            let v2708 = spiral_wrap_signed(v2685 + v2705, 64)
            let v2709 = spiral_wrap_signed(v2687 + v2706, 64)
            let v2710 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
            Us0TypedFxHashedStatementChecksumValidationAccepted(1, 3, v2707, v2708, v2709, v2710)
        }
        False -> {
            let v2712 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
            Us0TypedFxHashedStatementChecksumValidationRejected(v2641, v2676, v2712)
        }
    }
let #(v2733, v2734, v2741) =
    case v2714  {
        Us0TypedFxHashedStatementChecksumValidationAccepted(v2718, v2719, v2720, v2721, v2722, v2723) -> {
            #(1, 0, v2722)
        }
        Us0TypedFxHashedStatementChecksumValidationRejected(v2715, v2716, v2717) -> {
            #(0, 1, 0)
        }
    }
let v2742 = 0 + 1
let v2743 = v2742 + 1
let v2744 = v2743 + 1
let v2745 = v2744 + 1
let v2746 = 0 + 1
let v2747 = v2746 + 1
let v2748 = v2747 + 1
let v2749 = v2748 + 1
let v2750 = v2745 == v2749
let v2751 =
    case v2750 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2752 = 0 + 1
let v2753 = 0 + 1
let v2754 = v2752 == v2753
let v2755 =
    case v2754 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2756 = 0 + 1
let v2757 = v2756 + 1
let v2758 = v2757 + 1
let v2759 = v2758 + 1
let v2760 = v2759 + 1
let v2761 = 0 + 1
let v2762 = v2761 + 1
let v2763 = v2762 + 1
let v2764 = v2763 + 1
let v2765 = v2764 + 1
let v2766 = v2760 == v2765
let v2767 =
    case v2766 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2770 = spiral_wrap_signed(v2755 + v2767, 64)
let v2773 = spiral_wrap_signed(v2751 + v2770, 64)
let v2774 = 0 + 1
let v2775 = v2774 + 1
let v2776 = v2775 + 1
let v2777 = v2776 + 1
let v2778 = 0 + 1
let v2779 = v2778 + 1
let v2780 = v2779 + 1
let v2781 = v2780 + 1
let v2782 = v2777 == v2781
let v2783 =
    case v2782 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2784 = 0 + 1
let v2785 = 0 + 1
let v2786 = v2784 == v2785
let v2787 =
    case v2786 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2788 = 0 + 1
let v2789 = v2788 + 1
let v2790 = v2789 + 1
let v2791 = v2790 + 1
let v2792 = v2791 + 1
let v2793 = 0 + 1
let v2794 = v2793 + 1
let v2795 = v2794 + 1
let v2796 = v2795 + 1
let v2797 = v2796 + 1
let v2798 = v2792 == v2797
let v2799 =
    case v2798 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2802 = spiral_wrap_signed(v2787 + v2799, 64)
let v2805 = spiral_wrap_signed(v2783 + v2802, 64)
let v2806 = spiral_wrap_signed(v2773 + v2805, 64)
let v2807 = spiral_wrap_signed(v2741 + v2734, 64)
let v2808 = spiral_wrap_signed(v2806 + v2807, 64)
let v2809 = spiral_wrap_signed(v2606 + v2808, 64)
let v2810 = v2733 == 1
let v2811 = v2809 == 0
let v2812 = v2810 && v2811
case v2812 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-statement-indexed-durable-commit-runtime-mismatch"
    }
}
let v2813 = 0 + 1
let v2814 = v2813 + 1
let v2815 = v2814 + 1
let v2816 = v2815 + 1
let v2817 = 0 + 1
let v2818 = v2817 + 1
let v2819 = v2818 + 1
let v2820 = v2819 + 1
let v2821 = v2816 == v2820
let v2822 =
    case v2821 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2823 = 0 + 1
let v2824 = 0 + 1
let v2825 = v2823 == v2824
let v2826 =
    case v2825 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2827 = 0 + 1
let v2828 = v2827 + 1
let v2829 = v2828 + 1
let v2830 = v2829 + 1
let v2831 = v2830 + 1
let v2832 = 0 + 1
let v2833 = v2832 + 1
let v2834 = v2833 + 1
let v2835 = v2834 + 1
let v2836 = v2835 + 1
let v2837 = v2831 == v2836
let v2838 =
    case v2837 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2839 = spiral_wrap_signed(v2823 + v2831, 64)
let v2840 = spiral_wrap_signed(v2824 + v2836, 64)
let v2841 = spiral_wrap_signed(v2826 + v2838, 64)
let v2842 = spiral_wrap_signed(v2816 + v2839, 64)
let v2843 = spiral_wrap_signed(v2820 + v2840, 64)
let v2844 = spiral_wrap_signed(v2822 + v2841, 64)
let v2845 = 0 + 1
let v2846 = v2845 + 1
let v2847 = v2846 + 1
let v2848 = v2847 + 1
let v2849 = 0 + 1
let v2850 = v2849 + 1
let v2851 = v2850 + 1
let v2852 = v2851 + 1
let v2853 = v2848 == v2852
let v2854 =
    case v2853 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2855 = 0 + 1
let v2856 = 0 + 1
let v2857 = v2855 == v2856
let v2858 =
    case v2857 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2859 = 0 + 1
let v2860 = v2859 + 1
let v2861 = v2860 + 1
let v2862 = v2861 + 1
let v2863 = v2862 + 1
let v2864 = 0 + 1
let v2865 = v2864 + 1
let v2866 = v2865 + 1
let v2867 = v2866 + 1
let v2868 = v2867 + 1
let v2869 = v2863 == v2868
let v2870 =
    case v2869 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2871 = spiral_wrap_signed(v2855 + v2863, 64)
let v2872 = spiral_wrap_signed(v2856 + v2868, 64)
let v2873 = spiral_wrap_signed(v2858 + v2870, 64)
let v2874 = spiral_wrap_signed(v2848 + v2871, 64)
let v2875 = spiral_wrap_signed(v2852 + v2872, 64)
let v2876 = spiral_wrap_signed(v2854 + v2873, 64)
let v2877 = 0 + 1
let v2878 = v2877 + 1
let v2879 = v2878 + 1
let v2880 = v2879 + 1
let v2881 = 0 + 1
let v2882 = v2881 + 1
let v2883 = v2882 + 1
let v2884 = v2883 + 1
let v2885 = v2880 == v2884
let v2886 =
    case v2885 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2887 = 0 + 1
let v2888 = 0 + 1
let v2889 = v2887 == v2888
let v2890 =
    case v2889 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2891 = 0 + 1
let v2892 = v2891 + 1
let v2893 = v2892 + 1
let v2894 = v2893 + 1
let v2895 = v2894 + 1
let v2896 = 0 + 1
let v2897 = v2896 + 1
let v2898 = v2897 + 1
let v2899 = v2898 + 1
let v2900 = v2899 + 1
let v2901 = v2895 == v2900
let v2902 =
    case v2901 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2903 = spiral_wrap_signed(v2887 + v2895, 64)
let v2904 = spiral_wrap_signed(v2888 + v2900, 64)
let v2905 = spiral_wrap_signed(v2890 + v2902, 64)
let v2906 = spiral_wrap_signed(v2880 + v2903, 64)
let v2907 = spiral_wrap_signed(v2884 + v2904, 64)
let v2908 = spiral_wrap_signed(v2886 + v2905, 64)
let v2909 = 0 + 1
let v2910 = v2909 + 1
let v2911 = v2910 + 1
let v2912 = v2911 + 1
let v2913 = 0 + 1
let v2914 = v2913 + 1
let v2915 = v2914 + 1
let v2916 = v2915 + 1
let v2917 = v2912 == v2916
let v2918 =
    case v2917 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2919 = 0 + 1
let v2920 = 0 + 1
let v2921 = v2919 == v2920
let v2922 =
    case v2921 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2923 = 0 + 1
let v2924 = v2923 + 1
let v2925 = v2924 + 1
let v2926 = v2925 + 1
let v2927 = v2926 + 1
let v2928 = 0 + 1
let v2929 = v2928 + 1
let v2930 = v2929 + 1
let v2931 = v2930 + 1
let v2932 = v2931 + 1
let v2933 = v2927 == v2932
let v2934 =
    case v2933 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2935 = spiral_wrap_signed(v2919 + v2927, 64)
let v2936 = spiral_wrap_signed(v2920 + v2932, 64)
let v2937 = spiral_wrap_signed(v2922 + v2934, 64)
let v2938 = spiral_wrap_signed(v2912 + v2935, 64)
let v2939 = spiral_wrap_signed(v2916 + v2936, 64)
let v2940 = spiral_wrap_signed(v2918 + v2937, 64)
let v2941 = spiral_wrap_signed(v2906 + v2938, 64)
let v2942 = spiral_wrap_signed(v2907 + v2939, 64)
let v2943 = spiral_wrap_signed(v2908 + v2940, 64)
let v2944 = spiral_wrap_signed(v2874 + v2941, 64)
let v2945 = spiral_wrap_signed(v2875 + v2942, 64)
let v2946 = spiral_wrap_signed(v2876 + v2943, 64)
let v2947 = spiral_wrap_signed(v2842 + v2944, 64)
let v2948 = spiral_wrap_signed(v2843 + v2945, 64)
let v2949 = spiral_wrap_signed(v2844 + v2946, 64)
let v2950 = v2947 == 40
let v2951 = v2948 == 40
let v2952 = v2949 == 0
let v2953 = v2950 && v2951
let v2954 = v2953 && v2952
case v2954 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-hashed-statement-event-store-decision-runtime-mismatch"
    }
}
let v2955 = 0 + 1
let v2956 = v2955 + 1
let v2957 = v2956 + 1
let v2958 = v2957 + 1
let v2959 = 0 + 1
let v2960 = v2959 + 1
let v2961 = v2960 + 1
let v2962 = v2961 + 1
let v2963 = v2958 == v2962
let v2964 =
    case v2963 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2965 = 0 + 1
let v2966 = 0 + 1
let v2967 = v2965 == v2966
let v2968 =
    case v2967 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2969 = 0 + 1
let v2970 = v2969 + 1
let v2971 = v2970 + 1
let v2972 = v2971 + 1
let v2973 = v2972 + 1
let v2974 = 0 + 1
let v2975 = v2974 + 1
let v2976 = v2975 + 1
let v2977 = v2976 + 1
let v2978 = v2977 + 1
let v2979 = v2973 == v2978
let v2980 =
    case v2979 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2983 = spiral_wrap_signed(v2968 + v2980, 64)
let v2986 = spiral_wrap_signed(v2964 + v2983, 64)
let v2987 = 0 + 1
let v2988 = v2987 + 1
let v2989 = v2988 + 1
let v2990 = v2989 + 1
let v2991 = 0 + 1
let v2992 = v2991 + 1
let v2993 = v2992 + 1
let v2994 = v2993 + 1
let v2995 = v2990 == v2994
let v2996 =
    case v2995 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v2997 = 0 + 1
let v2998 = 0 + 1
let v2999 = v2997 == v2998
let v3000 =
    case v2999 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3001 = 0 + 1
let v3002 = v3001 + 1
let v3003 = v3002 + 1
let v3004 = v3003 + 1
let v3005 = v3004 + 1
let v3006 = 0 + 1
let v3007 = v3006 + 1
let v3008 = v3007 + 1
let v3009 = v3008 + 1
let v3010 = v3009 + 1
let v3011 = v3005 == v3010
let v3012 =
    case v3011 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3015 = spiral_wrap_signed(v3000 + v3012, 64)
let v3018 = spiral_wrap_signed(v2996 + v3015, 64)
let v3021 = spiral_wrap_signed(v3018 + v2986, 64)
let v3022 = 0 + 1
let v3023 = v3022 + 1
let v3024 = v3023 + 1
let v3025 = v3024 + 1
let v3026 = 0 + 1
let v3027 = v3026 + 1
let v3028 = v3027 + 1
let v3029 = v3028 + 1
let v3030 = v3025 == v3029
let v3031 =
    case v3030 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3032 = 0 + 1
let v3033 = 0 + 1
let v3034 = v3032 == v3033
let v3035 =
    case v3034 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3036 = 0 + 1
let v3037 = v3036 + 1
let v3038 = v3037 + 1
let v3039 = v3038 + 1
let v3040 = v3039 + 1
let v3041 = 0 + 1
let v3042 = v3041 + 1
let v3043 = v3042 + 1
let v3044 = v3043 + 1
let v3045 = v3044 + 1
let v3046 = v3040 == v3045
let v3047 =
    case v3046 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3050 = spiral_wrap_signed(v3035 + v3047, 64)
let v3053 = spiral_wrap_signed(v3031 + v3050, 64)
let v3054 = 0 + 1
let v3055 = v3054 + 1
let v3056 = v3055 + 1
let v3057 = v3056 + 1
let v3058 = 0 + 1
let v3059 = v3058 + 1
let v3060 = v3059 + 1
let v3061 = v3060 + 1
let v3062 = v3057 == v3061
let v3063 =
    case v3062 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3064 = 0 + 1
let v3065 = 0 + 1
let v3066 = v3064 == v3065
let v3067 =
    case v3066 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3068 = 0 + 1
let v3069 = v3068 + 1
let v3070 = v3069 + 1
let v3071 = v3070 + 1
let v3072 = v3071 + 1
let v3073 = 0 + 1
let v3074 = v3073 + 1
let v3075 = v3074 + 1
let v3076 = v3075 + 1
let v3077 = v3076 + 1
let v3078 = v3072 == v3077
let v3079 =
    case v3078 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3082 = spiral_wrap_signed(v3067 + v3079, 64)
let v3085 = spiral_wrap_signed(v3063 + v3082, 64)
let v3088 = spiral_wrap_signed(v3085 + v3053, 64)
let v3089 = spiral_wrap_signed(v3021 + v3088, 64)
let v3090 = v3089 == 0
case v3090 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-hashed-statement-proven-retry-runtime-mismatch"
    }
}
let v3091 = 0 + 1
let v3092 = v3091 + 1
let v3093 = v3092 + 1
let v3094 = v3093 + 1
let v3095 = 0 + 1
let v3096 = v3095 + 1
let v3097 = v3096 + 1
let v3098 = v3097 + 1
let v3099 = v3094 == v3098
let v3100 =
    case v3099 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3101 = 0 + 1
let v3102 = 0 + 1
let v3103 = v3101 == v3102
let v3104 =
    case v3103 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3105 = 0 + 1
let v3106 = v3105 + 1
let v3107 = v3106 + 1
let v3108 = v3107 + 1
let v3109 = v3108 + 1
let v3110 = 0 + 1
let v3111 = v3110 + 1
let v3112 = v3111 + 1
let v3113 = v3112 + 1
let v3114 = v3113 + 1
let v3115 = v3109 == v3114
let v3116 =
    case v3115 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3117 = spiral_wrap_signed(v3101 + v3109, 64)
let v3118 = spiral_wrap_signed(v3102 + v3114, 64)
let v3119 = spiral_wrap_signed(v3104 + v3116, 64)
let v3120 = spiral_wrap_signed(v3094 + v3117, 64)
let v3121 = spiral_wrap_signed(v3098 + v3118, 64)
let v3122 = spiral_wrap_signed(v3100 + v3119, 64)
let v3123 = 0 + 1
let v3124 = v3123 + 1
let v3125 = v3124 + 1
let v3126 = v3125 + 1
let v3127 = 0 + 1
let v3128 = v3127 + 1
let v3129 = v3128 + 1
let v3130 = v3129 + 1
let v3131 = v3126 == v3130
let v3132 =
    case v3131 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3133 = 0 + 1
let v3134 = 0 + 1
let v3135 = v3133 == v3134
let v3136 =
    case v3135 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3137 = 0 + 1
let v3138 = v3137 + 1
let v3139 = v3138 + 1
let v3140 = v3139 + 1
let v3141 = v3140 + 1
let v3142 = 0 + 1
let v3143 = v3142 + 1
let v3144 = v3143 + 1
let v3145 = v3144 + 1
let v3146 = v3145 + 1
let v3147 = v3141 == v3146
let v3148 =
    case v3147 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3149 = spiral_wrap_signed(v3133 + v3141, 64)
let v3150 = spiral_wrap_signed(v3134 + v3146, 64)
let v3151 = spiral_wrap_signed(v3136 + v3148, 64)
let v3152 = spiral_wrap_signed(v3126 + v3149, 64)
let v3153 = spiral_wrap_signed(v3130 + v3150, 64)
let v3154 = spiral_wrap_signed(v3132 + v3151, 64)
let v3155 = spiral_wrap_signed(v3152 + v3120, 64)
let v3156 = spiral_wrap_signed(v3153 + v3121, 64)
let v3157 = spiral_wrap_signed(v3154 + v3122, 64)
let v3158 = v3155 == 20
let v3159 = v3156 == 20
let v3160 = v3157 == 0
let v3161 = v3158 && v3159
let v3162 = v3161 && v3160
case v3162 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-hashed-statement-history-enumeration-runtime-mismatch"
    }
}
let v3163 = 0 + 1
let v3164 = v3163 + 1
let v3165 = v3164 + 1
let v3166 = v3165 + 1
let v3167 = 0 + 1
let v3168 = v3167 + 1
let v3169 = v3168 + 1
let v3170 = v3169 + 1
let v3171 = v3166 == v3170
let v3172 =
    case v3171 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3173 = 0 + 1
let v3174 = 0 + 1
let v3175 = v3173 == v3174
let v3176 =
    case v3175 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3177 = 0 + 1
let v3178 = v3177 + 1
let v3179 = v3178 + 1
let v3180 = v3179 + 1
let v3181 = v3180 + 1
let v3182 = 0 + 1
let v3183 = v3182 + 1
let v3184 = v3183 + 1
let v3185 = v3184 + 1
let v3186 = v3185 + 1
let v3187 = v3181 == v3186
let v3188 =
    case v3187 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3189 = spiral_wrap_signed(v3173 + v3181, 64)
let v3190 = spiral_wrap_signed(v3174 + v3186, 64)
let v3191 = spiral_wrap_signed(v3176 + v3188, 64)
let v3192 = spiral_wrap_signed(v3166 + v3189, 64)
let v3193 = spiral_wrap_signed(v3170 + v3190, 64)
let v3194 = spiral_wrap_signed(v3172 + v3191, 64)
let v3195 = v3192 == 10
let v3196 = v3193 == 10
let v3197 = v3194 == 0
let v3198 = v3195 && v3196
let v3199 = v3198 && v3197
case v3199 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-hashed-statement-history-index-lookup-runtime-mismatch"
    }
}
let v3200 = 0 + 1
let v3201 = v3200 + 1
let v3202 = v3201 + 1
let v3203 = v3202 + 1
let v3204 = 0 + 1
let v3205 = v3204 + 1
let v3206 = v3205 + 1
let v3207 = v3206 + 1
let v3208 = v3203 == v3207
let v3209 =
    case v3208 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3210 = 0 + 1
let v3211 = 0 + 1
let v3212 = v3210 == v3211
let v3213 =
    case v3212 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3214 = 0 + 1
let v3215 = v3214 + 1
let v3216 = v3215 + 1
let v3217 = v3216 + 1
let v3218 = v3217 + 1
let v3219 = 0 + 1
let v3220 = v3219 + 1
let v3221 = v3220 + 1
let v3222 = v3221 + 1
let v3223 = v3222 + 1
let v3224 = v3218 == v3223
let v3225 =
    case v3224 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3226 = spiral_wrap_signed(v3210 + v3218, 64)
let v3227 = spiral_wrap_signed(v3211 + v3223, 64)
let v3228 = spiral_wrap_signed(v3213 + v3225, 64)
let v3229 = spiral_wrap_signed(v3203 + v3226, 64)
let v3230 = spiral_wrap_signed(v3207 + v3227, 64)
let v3231 = spiral_wrap_signed(v3209 + v3228, 64)
let v3232 = 0 + 1
let v3233 = v3232 + 1
let v3234 = v3233 + 1
let v3235 = v3234 + 1
let v3236 = 0 + 1
let v3237 = v3236 + 1
let v3238 = v3237 + 1
let v3239 = v3238 + 1
let v3240 = v3235 == v3239
let v3241 =
    case v3240 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3242 = 0 + 1
let v3243 = 0 + 1
let v3244 = v3242 == v3243
let v3245 =
    case v3244 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3246 = 0 + 1
let v3247 = v3246 + 1
let v3248 = v3247 + 1
let v3249 = v3248 + 1
let v3250 = v3249 + 1
let v3251 = 0 + 1
let v3252 = v3251 + 1
let v3253 = v3252 + 1
let v3254 = v3253 + 1
let v3255 = v3254 + 1
let v3256 = v3250 == v3255
let v3257 =
    case v3256 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3258 = spiral_wrap_signed(v3242 + v3250, 64)
let v3259 = spiral_wrap_signed(v3243 + v3255, 64)
let v3260 = spiral_wrap_signed(v3245 + v3257, 64)
let v3261 = spiral_wrap_signed(v3235 + v3258, 64)
let v3262 = spiral_wrap_signed(v3239 + v3259, 64)
let v3263 = spiral_wrap_signed(v3241 + v3260, 64)
let v3264 = v3229 == 10
let v3265 = v3230 == 10
let v3266 = v3231 == 0
let v3267 = v3261 == 10
let v3268 = v3262 == 10
let v3269 = v3263 == 0
let v3270 = v3264 && v3265
let v3271 = v3270 && v3266
let v3272 = v3271 && v3267
let v3273 = v3272 && v3268
let v3274 = v3273 && v3269
case v3274 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-hashed-statement-identity-lookup-runtime-mismatch"
    }
}
let v3275 = 0 + 1
let v3276 = v3275 + 1
let v3277 = v3276 + 1
let v3278 = v3277 + 1
let v3279 = 0 + 1
let v3280 = v3279 + 1
let v3281 = v3280 + 1
let v3282 = v3281 + 1
let v3283 = v3278 == v3282
let v3284 =
    case v3283 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3285 = 0 + 1
let v3286 = 0 + 1
let v3287 = v3285 == v3286
let v3288 =
    case v3287 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3289 = 0 + 1
let v3290 = v3289 + 1
let v3291 = v3290 + 1
let v3292 = v3291 + 1
let v3293 = v3292 + 1
let v3294 = 0 + 1
let v3295 = v3294 + 1
let v3296 = v3295 + 1
let v3297 = v3296 + 1
let v3298 = v3297 + 1
let v3299 = v3293 == v3298
let v3300 =
    case v3299 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3301 = spiral_wrap_signed(v3285 + v3293, 64)
let v3302 = spiral_wrap_signed(v3286 + v3298, 64)
let v3303 = spiral_wrap_signed(v3288 + v3300, 64)
let v3304 = spiral_wrap_signed(v3278 + v3301, 64)
let v3305 = spiral_wrap_signed(v3282 + v3302, 64)
let v3306 = spiral_wrap_signed(v3284 + v3303, 64)
let v3307 = 0 + 1
let v3308 = v3307 + 1
let v3309 = v3308 + 1
let v3310 = v3309 + 1
let v3311 = 0 + 1
let v3312 = v3311 + 1
let v3313 = v3312 + 1
let v3314 = v3313 + 1
let v3315 = v3310 == v3314
let v3316 =
    case v3315 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3317 = 0 + 1
let v3318 = 0 + 1
let v3319 = v3317 == v3318
let v3320 =
    case v3319 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3321 = 0 + 1
let v3322 = v3321 + 1
let v3323 = v3322 + 1
let v3324 = v3323 + 1
let v3325 = v3324 + 1
let v3326 = 0 + 1
let v3327 = v3326 + 1
let v3328 = v3327 + 1
let v3329 = v3328 + 1
let v3330 = v3329 + 1
let v3331 = v3325 == v3330
let v3332 =
    case v3331 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3333 = spiral_wrap_signed(v3317 + v3325, 64)
let v3334 = spiral_wrap_signed(v3318 + v3330, 64)
let v3335 = spiral_wrap_signed(v3320 + v3332, 64)
let v3336 = spiral_wrap_signed(v3310 + v3333, 64)
let v3337 = spiral_wrap_signed(v3314 + v3334, 64)
let v3338 = spiral_wrap_signed(v3316 + v3335, 64)
let v3339 = spiral_wrap_signed(v3304 + v3336, 64)
let v3340 = spiral_wrap_signed(v3305 + v3337, 64)
let v3341 = spiral_wrap_signed(v3306 + v3338, 64)
let v3342 = v3339 == 20
let v3343 = v3340 == 20
let v3344 = v3341 == 0
let v3345 = v3342 && v3343
let v3346 = v3345 && v3344
case v3346 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-hashed-statement-membership-lookup-program-runtime-mismatch"
    }
}
let v3347 = 0 + 1
let v3348 = v3347 + 1
let v3349 = v3348 + 1
let v3350 = v3349 + 1
let v3351 = 0 + 1
let v3352 = v3351 + 1
let v3353 = v3352 + 1
let v3354 = v3353 + 1
let v3355 = v3350 == v3354
let v3356 =
    case v3355 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3357 = 0 + 1
let v3358 = 0 + 1
let v3359 = v3357 == v3358
let v3360 =
    case v3359 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3361 = 0 + 1
let v3362 = v3361 + 1
let v3363 = v3362 + 1
let v3364 = v3363 + 1
let v3365 = v3364 + 1
let v3366 = 0 + 1
let v3367 = v3366 + 1
let v3368 = v3367 + 1
let v3369 = v3368 + 1
let v3370 = v3369 + 1
let v3371 = v3365 == v3370
let v3372 =
    case v3371 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3373 = spiral_wrap_signed(v3357 + v3365, 64)
let v3374 = spiral_wrap_signed(v3358 + v3370, 64)
let v3375 = spiral_wrap_signed(v3360 + v3372, 64)
let v3376 = spiral_wrap_signed(v3350 + v3373, 64)
let v3377 = spiral_wrap_signed(v3354 + v3374, 64)
let v3378 = spiral_wrap_signed(v3356 + v3375, 64)
let v3379 = 0 + 1
let v3380 = v3379 + 1
let v3381 = v3380 + 1
let v3382 = v3381 + 1
let v3383 = 0 + 1
let v3384 = v3383 + 1
let v3385 = v3384 + 1
let v3386 = v3385 + 1
let v3387 = v3382 == v3386
let v3388 =
    case v3387 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3389 = 0 + 1
let v3390 = 0 + 1
let v3391 = v3389 == v3390
let v3392 =
    case v3391 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3393 = 0 + 1
let v3394 = v3393 + 1
let v3395 = v3394 + 1
let v3396 = v3395 + 1
let v3397 = v3396 + 1
let v3398 = 0 + 1
let v3399 = v3398 + 1
let v3400 = v3399 + 1
let v3401 = v3400 + 1
let v3402 = v3401 + 1
let v3403 = v3397 == v3402
let v3404 =
    case v3403 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3405 = spiral_wrap_signed(v3389 + v3397, 64)
let v3406 = spiral_wrap_signed(v3390 + v3402, 64)
let v3407 = spiral_wrap_signed(v3392 + v3404, 64)
let v3408 = spiral_wrap_signed(v3382 + v3405, 64)
let v3409 = spiral_wrap_signed(v3386 + v3406, 64)
let v3410 = spiral_wrap_signed(v3388 + v3407, 64)
let v3411 = spiral_wrap_signed(v3376 + v3408, 64)
let v3412 = spiral_wrap_signed(v3377 + v3409, 64)
let v3413 = spiral_wrap_signed(v3378 + v3410, 64)
let v3414 = 0 + 1
let v3415 = v3414 + 1
let v3416 = v3415 + 1
let v3417 = v3416 + 1
let v3418 = 0 + 1
let v3419 = v3418 + 1
let v3420 = v3419 + 1
let v3421 = v3420 + 1
let v3422 = v3417 == v3421
let v3423 =
    case v3422 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3424 = 0 + 1
let v3425 = 0 + 1
let v3426 = v3424 == v3425
let v3427 =
    case v3426 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3428 = 0 + 1
let v3429 = v3428 + 1
let v3430 = v3429 + 1
let v3431 = v3430 + 1
let v3432 = v3431 + 1
let v3433 = 0 + 1
let v3434 = v3433 + 1
let v3435 = v3434 + 1
let v3436 = v3435 + 1
let v3437 = v3436 + 1
let v3438 = v3432 == v3437
let v3439 =
    case v3438 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3440 = spiral_wrap_signed(v3424 + v3432, 64)
let v3441 = spiral_wrap_signed(v3425 + v3437, 64)
let v3442 = spiral_wrap_signed(v3427 + v3439, 64)
let v3443 = spiral_wrap_signed(v3417 + v3440, 64)
let v3444 = spiral_wrap_signed(v3421 + v3441, 64)
let v3445 = spiral_wrap_signed(v3423 + v3442, 64)
let v3446 = 0 + 1
let v3447 = v3446 + 1
let v3448 = v3447 + 1
let v3449 = v3448 + 1
let v3450 = 0 + 1
let v3451 = v3450 + 1
let v3452 = v3451 + 1
let v3453 = v3452 + 1
let v3454 = v3449 == v3453
let v3455 =
    case v3454 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3456 = 0 + 1
let v3457 = 0 + 1
let v3458 = v3456 == v3457
let v3459 =
    case v3458 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3460 = 0 + 1
let v3461 = v3460 + 1
let v3462 = v3461 + 1
let v3463 = v3462 + 1
let v3464 = v3463 + 1
let v3465 = 0 + 1
let v3466 = v3465 + 1
let v3467 = v3466 + 1
let v3468 = v3467 + 1
let v3469 = v3468 + 1
let v3470 = v3464 == v3469
let v3471 =
    case v3470 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3472 = spiral_wrap_signed(v3456 + v3464, 64)
let v3473 = spiral_wrap_signed(v3457 + v3469, 64)
let v3474 = spiral_wrap_signed(v3459 + v3471, 64)
let v3475 = spiral_wrap_signed(v3449 + v3472, 64)
let v3476 = spiral_wrap_signed(v3453 + v3473, 64)
let v3477 = spiral_wrap_signed(v3455 + v3474, 64)
let v3478 = spiral_wrap_signed(v3443 + v3475, 64)
let v3479 = v3411 == v3478
let v3480 = spiral_wrap_signed(v3444 + v3476, 64)
let v3481 = v3412 == v3480
let v3482 = spiral_wrap_signed(v3445 + v3477, 64)
let v3483 = v3413 == v3482
let v3484 = v3479 && v3481
let v3485 = v3484 && v3483
case v3485 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-hashed-statement-membership-lookup-program-append-runtime-mismatch"
    }
}
let v3486 = 0 + 1
let v3487 = v3486 + 1
let v3488 = v3487 + 1
let v3489 = v3488 + 1
let v3490 = 0 + 1
let v3491 = v3490 + 1
let v3492 = v3491 + 1
let v3493 = v3492 + 1
let v3494 = v3489 == v3493
let v3495 =
    case v3494 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3496 = 0 + 1
let v3497 = 0 + 1
let v3498 = v3496 == v3497
let v3499 =
    case v3498 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3500 = 0 + 1
let v3501 = v3500 + 1
let v3502 = v3501 + 1
let v3503 = v3502 + 1
let v3504 = v3503 + 1
let v3505 = 0 + 1
let v3506 = v3505 + 1
let v3507 = v3506 + 1
let v3508 = v3507 + 1
let v3509 = v3508 + 1
let v3510 = v3504 == v3509
let v3511 =
    case v3510 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3512 = spiral_wrap_signed(v3496 + v3504, 64)
let v3513 = spiral_wrap_signed(v3497 + v3509, 64)
let v3514 = spiral_wrap_signed(v3499 + v3511, 64)
let v3515 = spiral_wrap_signed(v3489 + v3512, 64)
let v3516 = spiral_wrap_signed(v3493 + v3513, 64)
let v3517 = spiral_wrap_signed(v3495 + v3514, 64)
let v3518 = 0 + 1
let v3519 = v3518 + 1
let v3520 = v3519 + 1
let v3521 = v3520 + 1
let v3522 = 0 + 1
let v3523 = v3522 + 1
let v3524 = v3523 + 1
let v3525 = v3524 + 1
let v3526 = v3521 == v3525
let v3527 =
    case v3526 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3528 = 0 + 1
let v3529 = 0 + 1
let v3530 = v3528 == v3529
let v3531 =
    case v3530 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3532 = 0 + 1
let v3533 = v3532 + 1
let v3534 = v3533 + 1
let v3535 = v3534 + 1
let v3536 = v3535 + 1
let v3537 = 0 + 1
let v3538 = v3537 + 1
let v3539 = v3538 + 1
let v3540 = v3539 + 1
let v3541 = v3540 + 1
let v3542 = v3536 == v3541
let v3543 =
    case v3542 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3544 = spiral_wrap_signed(v3528 + v3536, 64)
let v3545 = spiral_wrap_signed(v3529 + v3541, 64)
let v3546 = spiral_wrap_signed(v3531 + v3543, 64)
let v3547 = spiral_wrap_signed(v3521 + v3544, 64)
let v3548 = spiral_wrap_signed(v3525 + v3545, 64)
let v3549 = spiral_wrap_signed(v3527 + v3546, 64)
let v3550 = 0 + 1
let v3551 = v3550 + 1
let v3552 = v3551 + 1
let v3553 = v3552 + 1
let v3554 = 0 + 1
let v3555 = v3554 + 1
let v3556 = v3555 + 1
let v3557 = v3556 + 1
let v3558 = v3553 == v3557
let v3559 =
    case v3558 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3560 = 0 + 1
let v3561 = 0 + 1
let v3562 = v3560 == v3561
let v3563 =
    case v3562 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3564 = 0 + 1
let v3565 = v3564 + 1
let v3566 = v3565 + 1
let v3567 = v3566 + 1
let v3568 = v3567 + 1
let v3569 = 0 + 1
let v3570 = v3569 + 1
let v3571 = v3570 + 1
let v3572 = v3571 + 1
let v3573 = v3572 + 1
let v3574 = v3568 == v3573
let v3575 =
    case v3574 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3576 = spiral_wrap_signed(v3560 + v3568, 64)
let v3577 = spiral_wrap_signed(v3561 + v3573, 64)
let v3578 = spiral_wrap_signed(v3563 + v3575, 64)
let v3579 = spiral_wrap_signed(v3553 + v3576, 64)
let v3580 = spiral_wrap_signed(v3557 + v3577, 64)
let v3581 = spiral_wrap_signed(v3559 + v3578, 64)
let v3582 = 0 + 1
let v3583 = v3582 + 1
let v3584 = v3583 + 1
let v3585 = v3584 + 1
let v3586 = 0 + 1
let v3587 = v3586 + 1
let v3588 = v3587 + 1
let v3589 = v3588 + 1
let v3590 = v3585 == v3589
let v3591 =
    case v3590 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3592 = 0 + 1
let v3593 = 0 + 1
let v3594 = v3592 == v3593
let v3595 =
    case v3594 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3596 = 0 + 1
let v3597 = v3596 + 1
let v3598 = v3597 + 1
let v3599 = v3598 + 1
let v3600 = v3599 + 1
let v3601 = 0 + 1
let v3602 = v3601 + 1
let v3603 = v3602 + 1
let v3604 = v3603 + 1
let v3605 = v3604 + 1
let v3606 = v3600 == v3605
let v3607 =
    case v3606 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
let v3608 = spiral_wrap_signed(v3592 + v3600, 64)
let v3609 = spiral_wrap_signed(v3593 + v3605, 64)
let v3610 = spiral_wrap_signed(v3595 + v3607, 64)
let v3611 = spiral_wrap_signed(v3585 + v3608, 64)
let v3612 = spiral_wrap_signed(v3589 + v3609, 64)
let v3613 = spiral_wrap_signed(v3591 + v3610, 64)
let v3614 = v3515 == v3547
let v3615 = v3516 == v3548
let v3616 = v3517 == v3549
let v3617 = v3614 && v3615
let v3618 = v3617 && v3616
case v3618 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch"
    }
}
let v3619 = v3579 == v3611
let v3620 = v3580 == v3612
let v3621 = v3581 == v3613
let v3622 = v3619 && v3620
let v3623 = v3622 && v3621
case v3623 {
    True -> {
        Nil
    }
    False -> {
        panic as "typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch"
    }
}
0
}
