kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
import os
try: # CuPy when a CUDA device answers, otherwise numpy under the same name (SPIRAL_CUDA=0 forces numpy).
    if os.environ.get('SPIRAL_CUDA', '1') == '0': raise ImportError('SPIRAL_CUDA=0')
    import cupy as cp
    if cp.cuda.runtime.getDeviceCount() < 1: raise RuntimeError('no CUDA device')
    cuda = True
except Exception:
    import numpy as cp
    cuda = False
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str
import sys
sys.setrecursionlimit(1 << 30)

def spiral_wrap(x, bits, signed):
    x &= (1 << bits) - 1
    return x - (1 << bits) if signed and x >> (bits - 1) else x
class US0_TypedFxHashedStatementChecksumValidationAccepted(NamedTuple): # TypedFxHashedStatementChecksumValidationAccepted
    v0 : i64
    v1 : i64
    v2 : i64
    v3 : i64
    v4 : i64
    v5 : string
    tag = 0
class US0_TypedFxHashedStatementChecksumValidationRejected(NamedTuple): # TypedFxHashedStatementChecksumValidationRejected
    v0 : i64
    v1 : i64
    v2 : string
    tag = 1
US0 = Union[US0_TypedFxHashedStatementChecksumValidationAccepted, US0_TypedFxHashedStatementChecksumValidationRejected]
def main():
    v0 = 0 + 1
    v1 = v0 + 1
    del v0
    v2 = v1 + 1
    del v1
    v3 = 0 + 1
    v4 = v3 + 1
    del v3
    v5 = v4 + 1
    del v4
    v6 = 0 + 1
    v7 = v6 + 1
    del v6
    v8 = 0 + 1
    v9 = v8 + 1
    del v8
    v10 = v9 + 1
    del v9
    v11 = v10 + 1
    del v10, v11
    v12 = 0 + 1
    v13 = spiral_wrap(v2 * v5, 64, True)
    del v2, v5, v13
    v14 = 0 + 1
    v15 = v14 + 1
    del v14
    v16 = v15 + 1
    del v15
    v17 = v16 + 1
    del v16
    v18 = v17 + 1
    del v17
    v19 = 0 + 1
    v20 = spiral_wrap(v12 + v12, 64, True)
    del v12
    v21 = spiral_wrap(v7 + v20, 64, True)
    del v7, v20
    v22 = 0 + 1
    v23 = v22 + 1
    del v22
    v24 = v23 + 1
    del v23
    v25 = 0 + 1
    v26 = v25 + 1
    del v25
    v27 = v26 + 1
    del v26
    v28 = 0 + 1
    v29 = v28 + 1
    del v28
    v30 = 0 + 1
    v31 = v30 + 1
    del v30
    v32 = v31 + 1
    del v31
    v33 = v32 + 1
    del v32, v33
    v34 = 0 + 1
    v35 = spiral_wrap(v24 * v27, 64, True)
    del v24, v27, v35
    v36 = 0 + 1
    v37 = v36 + 1
    del v36
    v38 = v37 + 1
    del v37
    v39 = v38 + 1
    del v38
    v40 = spiral_wrap(v34 + v34, 64, True)
    del v34
    v41 = spiral_wrap(v29 + v40, 64, True)
    del v29, v40
    v42 = spiral_wrap(v18 + v39, 64, True)
    del v18, v39
    v43 = spiral_wrap(v21 + v41, 64, True)
    del v21, v41
    v44 = v42 == 9
    del v42
    v45 = v19 == 1
    del v19
    v46 = v43 == 8
    del v43
    v47 = v44 and v45
    del v44, v45
    v48 = v47 and v46
    del v46, v47
    if v48:
        pass
    else:
        raise Exception("typed-usd-eur-determined-tie-rounding-runtime-mismatch")
    del v48
    v49 = 0 + 1
    v50 = v49 + 1
    del v49
    v51 = v50 + 1
    del v50
    v52 = v51 + 1
    del v51
    v53 = 0 + 1
    v54 = v53 + 1
    del v53
    v55 = v54 + 1
    del v54
    v56 = v55 + 1
    del v55
    v57 = v52 == v56
    if v57:
        v58 = 0
    else:
        v58 = 1
    del v57
    v59 = 0 + 1
    v60 = 0 + 1
    v61 = v59 == v60
    if v61:
        v62 = 0
    else:
        v62 = 1
    del v61
    v63 = 0 + 1
    v64 = v63 + 1
    del v63
    v65 = v64 + 1
    del v64
    v66 = v65 + 1
    del v65
    v67 = v66 + 1
    del v66
    v68 = 0 + 1
    v69 = v68 + 1
    del v68
    v70 = v69 + 1
    del v69
    v71 = v70 + 1
    del v70
    v72 = v71 + 1
    del v71
    v73 = v67 == v72
    if v73:
        v74 = 0
    else:
        v74 = 1
    del v73
    v75 = spiral_wrap(v59 + v67, 64, True)
    del v59, v67
    v76 = spiral_wrap(v60 + v72, 64, True)
    del v60, v72
    v77 = spiral_wrap(v62 + v74, 64, True)
    del v62, v74
    v78 = spiral_wrap(v52 + v75, 64, True)
    del v52, v75
    v79 = spiral_wrap(v56 + v76, 64, True)
    del v56, v76
    v80 = spiral_wrap(v58 + v77, 64, True)
    del v58, v77
    v81 = v78 == 10
    del v78
    v82 = v79 == 10
    del v79
    v83 = v80 == 0
    del v80
    v84 = v81 and v82
    del v81, v82
    v85 = v84 and v83
    del v83, v84
    if v85:
        pass
    else:
        raise Exception("typed-FX-statement-expected-raw-append-runtime-mismatch")
    del v85
    v86 = 0 + 1
    v87 = v86 + 1
    del v86
    v88 = v87 + 1
    del v87
    v89 = v88 + 1
    del v88
    v90 = 0 + 1
    v91 = v90 + 1
    del v90
    v92 = v91 + 1
    del v91
    v93 = v92 + 1
    del v92
    v94 = v89 == v93
    if v94:
        v95 = 0
    else:
        v95 = 1
    del v94
    v96 = 0 + 1
    v97 = 0 + 1
    v98 = v96 == v97
    if v98:
        v99 = 0
    else:
        v99 = 1
    del v98
    v100 = 0 + 1
    v101 = v100 + 1
    del v100
    v102 = v101 + 1
    del v101
    v103 = v102 + 1
    del v102
    v104 = v103 + 1
    del v103
    v105 = 0 + 1
    v106 = v105 + 1
    del v105
    v107 = v106 + 1
    del v106
    v108 = v107 + 1
    del v107
    v109 = v108 + 1
    del v108
    v110 = v104 == v109
    if v110:
        v111 = 0
    else:
        v111 = 1
    del v110
    v112 = spiral_wrap(v96 + v104, 64, True)
    del v96, v104
    v113 = spiral_wrap(v97 + v109, 64, True)
    del v97, v109
    v114 = spiral_wrap(v99 + v111, 64, True)
    del v99, v111
    v115 = spiral_wrap(v89 + v112, 64, True)
    del v89, v112, v115
    v116 = spiral_wrap(v93 + v113, 64, True)
    del v93, v113, v116
    v117 = spiral_wrap(v95 + v114, 64, True)
    del v95, v114
    v118 = 0 + 1
    v119 = v118 + 1
    del v118
    v120 = v119 + 1
    del v119
    v121 = v120 + 1
    del v120
    v122 = 0 + 1
    v123 = v122 + 1
    del v122
    v124 = v123 + 1
    del v123
    v125 = v124 + 1
    del v124
    v126 = v121 == v125
    if v126:
        v127 = 0
    else:
        v127 = 1
    del v126
    v128 = 0 + 1
    v129 = 0 + 1
    v130 = v128 == v129
    if v130:
        v131 = 0
    else:
        v131 = 1
    del v130
    v132 = 0 + 1
    v133 = v132 + 1
    del v132
    v134 = v133 + 1
    del v133
    v135 = v134 + 1
    del v134
    v136 = v135 + 1
    del v135
    v137 = 0 + 1
    v138 = v137 + 1
    del v137
    v139 = v138 + 1
    del v138
    v140 = v139 + 1
    del v139
    v141 = v140 + 1
    del v140
    v142 = v136 == v141
    if v142:
        v143 = 0
    else:
        v143 = 1
    del v142
    v144 = spiral_wrap(v128 + v136, 64, True)
    del v128, v136
    v145 = spiral_wrap(v129 + v141, 64, True)
    del v129, v141
    v146 = spiral_wrap(v131 + v143, 64, True)
    del v131, v143
    v147 = spiral_wrap(v121 + v144, 64, True)
    del v121, v144, v147
    v148 = spiral_wrap(v125 + v145, 64, True)
    del v125, v145, v148
    v149 = spiral_wrap(v127 + v146, 64, True)
    del v127, v146
    v150 = spiral_wrap(v117 + v149, 64, True)
    del v117, v149
    v151 = v150 == 0
    del v150
    if v151:
        pass
    else:
        raise Exception("typed-FX-statement-two-writer-raw-CAS-runtime-mismatch")
    del v151
    v152 = 0 + 1
    v153 = v152 + 1
    del v152
    v154 = v153 + 1
    del v153
    v155 = v154 + 1
    del v154
    v156 = 0 + 1
    v157 = v156 + 1
    del v156
    v158 = v157 + 1
    del v157
    v159 = v158 + 1
    del v158
    v160 = v155 == v159
    if v160:
        v161 = 0
    else:
        v161 = 1
    del v160
    v162 = 0 + 1
    v163 = 0 + 1
    v164 = v162 == v163
    if v164:
        v165 = 0
    else:
        v165 = 1
    del v164
    v166 = 0 + 1
    v167 = v166 + 1
    del v166
    v168 = v167 + 1
    del v167
    v169 = v168 + 1
    del v168
    v170 = v169 + 1
    del v169
    v171 = 0 + 1
    v172 = v171 + 1
    del v171
    v173 = v172 + 1
    del v172
    v174 = v173 + 1
    del v173
    v175 = v174 + 1
    del v174
    v176 = v170 == v175
    if v176:
        v177 = 0
    else:
        v177 = 1
    del v176
    v178 = spiral_wrap(v162 + v170, 64, True)
    del v162, v170
    v179 = spiral_wrap(v163 + v175, 64, True)
    del v163, v175
    v180 = spiral_wrap(v165 + v177, 64, True)
    del v165, v177
    v181 = spiral_wrap(v155 + v178, 64, True)
    del v155, v178, v181
    v182 = spiral_wrap(v159 + v179, 64, True)
    del v159, v179, v182
    v183 = spiral_wrap(v161 + v180, 64, True)
    del v161, v180
    v184 = 0 + 1
    v185 = v184 + 1
    del v184
    v186 = v185 + 1
    del v185
    v187 = v186 + 1
    del v186
    v188 = 0 + 1
    v189 = v188 + 1
    del v188
    v190 = v189 + 1
    del v189
    v191 = v190 + 1
    del v190
    v192 = v187 == v191
    if v192:
        v193 = 0
    else:
        v193 = 1
    del v192
    v194 = 0 + 1
    v195 = 0 + 1
    v196 = v194 == v195
    if v196:
        v197 = 0
    else:
        v197 = 1
    del v196
    v198 = 0 + 1
    v199 = v198 + 1
    del v198
    v200 = v199 + 1
    del v199
    v201 = v200 + 1
    del v200
    v202 = v201 + 1
    del v201
    v203 = 0 + 1
    v204 = v203 + 1
    del v203
    v205 = v204 + 1
    del v204
    v206 = v205 + 1
    del v205
    v207 = v206 + 1
    del v206
    v208 = v202 == v207
    if v208:
        v209 = 0
    else:
        v209 = 1
    del v208
    v210 = spiral_wrap(v194 + v202, 64, True)
    del v194, v202
    v211 = spiral_wrap(v195 + v207, 64, True)
    del v195, v207
    v212 = spiral_wrap(v197 + v209, 64, True)
    del v197, v209
    v213 = spiral_wrap(v187 + v210, 64, True)
    del v187, v210, v213
    v214 = spiral_wrap(v191 + v211, 64, True)
    del v191, v211, v214
    v215 = spiral_wrap(v193 + v212, 64, True)
    del v193, v212
    v216 = spiral_wrap(v183 + v215, 64, True)
    del v183, v215
    v217 = 0 + 1
    v218 = v217 + 1
    del v217
    v219 = v218 + 1
    del v218
    v220 = v219 + 1
    del v219
    v221 = 0 + 1
    v222 = v221 + 1
    del v221
    v223 = v222 + 1
    del v222
    v224 = v223 + 1
    del v223
    v225 = v220 == v224
    if v225:
        v226 = 0
    else:
        v226 = 1
    del v225
    v227 = 0 + 1
    v228 = 0 + 1
    v229 = v227 == v228
    if v229:
        v230 = 0
    else:
        v230 = 1
    del v229
    v231 = 0 + 1
    v232 = v231 + 1
    del v231
    v233 = v232 + 1
    del v232
    v234 = v233 + 1
    del v233
    v235 = v234 + 1
    del v234
    v236 = 0 + 1
    v237 = v236 + 1
    del v236
    v238 = v237 + 1
    del v237
    v239 = v238 + 1
    del v238
    v240 = v239 + 1
    del v239
    v241 = v235 == v240
    if v241:
        v242 = 0
    else:
        v242 = 1
    del v241
    v243 = spiral_wrap(v227 + v235, 64, True)
    del v227, v235
    v244 = spiral_wrap(v228 + v240, 64, True)
    del v228, v240
    v245 = spiral_wrap(v230 + v242, 64, True)
    del v230, v242
    v246 = spiral_wrap(v220 + v243, 64, True)
    del v220, v243, v246
    v247 = spiral_wrap(v224 + v244, 64, True)
    del v224, v244, v247
    v248 = spiral_wrap(v226 + v245, 64, True)
    del v226, v245
    v249 = spiral_wrap(v216 + v248, 64, True)
    del v216, v248
    v250 = v249 == 0
    del v249
    if v250:
        pass
    else:
        raise Exception("typed-FX-statement-three-writer-raw-CAS-runtime-mismatch")
    del v250
    v251 = 0 + 1
    v252 = v251 + 1
    del v251
    v253 = v252 + 1
    del v252
    v254 = v253 + 1
    del v253
    v255 = 0 + 1
    v256 = v255 + 1
    del v255
    v257 = v256 + 1
    del v256
    v258 = v257 + 1
    del v257
    v259 = v254 == v258
    if v259:
        v260 = 0
    else:
        v260 = 1
    del v259
    v261 = 0 + 1
    v262 = 0 + 1
    v263 = v261 == v262
    if v263:
        v264 = 0
    else:
        v264 = 1
    del v263
    v265 = 0 + 1
    v266 = v265 + 1
    del v265
    v267 = v266 + 1
    del v266
    v268 = v267 + 1
    del v267
    v269 = v268 + 1
    del v268
    v270 = 0 + 1
    v271 = v270 + 1
    del v270
    v272 = v271 + 1
    del v271
    v273 = v272 + 1
    del v272
    v274 = v273 + 1
    del v273
    v275 = v269 == v274
    if v275:
        v276 = 0
    else:
        v276 = 1
    del v275
    v277 = spiral_wrap(v261 + v269, 64, True)
    del v261, v269
    v278 = spiral_wrap(v262 + v274, 64, True)
    del v262, v274
    v279 = spiral_wrap(v264 + v276, 64, True)
    del v264, v276
    v280 = spiral_wrap(v254 + v277, 64, True)
    del v254, v277, v280
    v281 = spiral_wrap(v258 + v278, 64, True)
    del v258, v278, v281
    v282 = spiral_wrap(v260 + v279, 64, True)
    del v260, v279
    v283 = 0 + 1
    v284 = v283 + 1
    del v283
    v285 = v284 + 1
    del v284
    v286 = v285 + 1
    del v285
    v287 = 0 + 1
    v288 = v287 + 1
    del v287
    v289 = v288 + 1
    del v288
    v290 = v289 + 1
    del v289
    v291 = v286 == v290
    if v291:
        v292 = 0
    else:
        v292 = 1
    del v291
    v293 = 0 + 1
    v294 = 0 + 1
    v295 = v293 == v294
    if v295:
        v296 = 0
    else:
        v296 = 1
    del v295
    v297 = 0 + 1
    v298 = v297 + 1
    del v297
    v299 = v298 + 1
    del v298
    v300 = v299 + 1
    del v299
    v301 = v300 + 1
    del v300
    v302 = 0 + 1
    v303 = v302 + 1
    del v302
    v304 = v303 + 1
    del v303
    v305 = v304 + 1
    del v304
    v306 = v305 + 1
    del v305
    v307 = v301 == v306
    if v307:
        v308 = 0
    else:
        v308 = 1
    del v307
    v309 = spiral_wrap(v293 + v301, 64, True)
    del v293, v301
    v310 = spiral_wrap(v294 + v306, 64, True)
    del v294, v306
    v311 = spiral_wrap(v296 + v308, 64, True)
    del v296, v308
    v312 = spiral_wrap(v286 + v309, 64, True)
    del v286, v309, v312
    v313 = spiral_wrap(v290 + v310, 64, True)
    del v290, v310, v313
    v314 = spiral_wrap(v292 + v311, 64, True)
    del v292, v311
    v315 = spiral_wrap(v282 + v314, 64, True)
    del v282, v314
    v316 = 0 + 1
    v317 = v316 + 1
    del v316
    v318 = v317 + 1
    del v317
    v319 = v318 + 1
    del v318
    v320 = 0 + 1
    v321 = v320 + 1
    del v320
    v322 = v321 + 1
    del v321
    v323 = v322 + 1
    del v322
    v324 = v319 == v323
    if v324:
        v325 = 0
    else:
        v325 = 1
    del v324
    v326 = 0 + 1
    v327 = 0 + 1
    v328 = v326 == v327
    if v328:
        v329 = 0
    else:
        v329 = 1
    del v328
    v330 = 0 + 1
    v331 = v330 + 1
    del v330
    v332 = v331 + 1
    del v331
    v333 = v332 + 1
    del v332
    v334 = v333 + 1
    del v333
    v335 = 0 + 1
    v336 = v335 + 1
    del v335
    v337 = v336 + 1
    del v336
    v338 = v337 + 1
    del v337
    v339 = v338 + 1
    del v338
    v340 = v334 == v339
    if v340:
        v341 = 0
    else:
        v341 = 1
    del v340
    v342 = spiral_wrap(v326 + v334, 64, True)
    del v326, v334
    v343 = spiral_wrap(v327 + v339, 64, True)
    del v327, v339
    v344 = spiral_wrap(v329 + v341, 64, True)
    del v329, v341
    v345 = spiral_wrap(v319 + v342, 64, True)
    del v319, v342, v345
    v346 = spiral_wrap(v323 + v343, 64, True)
    del v323, v343, v346
    v347 = spiral_wrap(v325 + v344, 64, True)
    del v325, v344
    v348 = 0 + 1
    v349 = v348 + 1
    del v348
    v350 = v349 + 1
    del v349
    v351 = v350 + 1
    del v350
    v352 = 0 + 1
    v353 = v352 + 1
    del v352
    v354 = v353 + 1
    del v353
    v355 = v354 + 1
    del v354
    v356 = v351 == v355
    if v356:
        v357 = 0
    else:
        v357 = 1
    del v356
    v358 = 0 + 1
    v359 = 0 + 1
    v360 = v358 == v359
    if v360:
        v361 = 0
    else:
        v361 = 1
    del v360
    v362 = 0 + 1
    v363 = v362 + 1
    del v362
    v364 = v363 + 1
    del v363
    v365 = v364 + 1
    del v364
    v366 = v365 + 1
    del v365
    v367 = 0 + 1
    v368 = v367 + 1
    del v367
    v369 = v368 + 1
    del v368
    v370 = v369 + 1
    del v369
    v371 = v370 + 1
    del v370
    v372 = v366 == v371
    if v372:
        v373 = 0
    else:
        v373 = 1
    del v372
    v374 = spiral_wrap(v358 + v366, 64, True)
    del v358, v366
    v375 = spiral_wrap(v359 + v371, 64, True)
    del v359, v371
    v376 = spiral_wrap(v361 + v373, 64, True)
    del v361, v373
    v377 = spiral_wrap(v351 + v374, 64, True)
    del v351, v374, v377
    v378 = spiral_wrap(v355 + v375, 64, True)
    del v355, v375, v378
    v379 = spiral_wrap(v357 + v376, 64, True)
    del v357, v376
    v380 = spiral_wrap(v347 + v379, 64, True)
    del v347, v379
    v381 = spiral_wrap(v315 + v380, 64, True)
    del v315, v380
    v382 = v381 == 0
    del v381
    if v382:
        pass
    else:
        raise Exception("typed-FX-statement-recursive-writer-raw-CAS-runtime-mismatch")
    del v382
    v383 = 0 + 1
    v384 = v383 + 1
    del v383
    v385 = v384 + 1
    del v384
    v386 = v385 + 1
    del v385
    v387 = 0 + 1
    v388 = v387 + 1
    del v387
    v389 = v388 + 1
    del v388
    v390 = v389 + 1
    del v389
    v391 = v386 == v390
    if v391:
        v392 = 0
    else:
        v392 = 1
    del v391
    v393 = 0 + 1
    v394 = 0 + 1
    v395 = v393 == v394
    if v395:
        v396 = 0
    else:
        v396 = 1
    del v395
    v397 = 0 + 1
    v398 = v397 + 1
    del v397
    v399 = v398 + 1
    del v398
    v400 = v399 + 1
    del v399
    v401 = v400 + 1
    del v400
    v402 = 0 + 1
    v403 = v402 + 1
    del v402
    v404 = v403 + 1
    del v403
    v405 = v404 + 1
    del v404
    v406 = v405 + 1
    del v405
    v407 = v401 == v406
    if v407:
        v408 = 0
    else:
        v408 = 1
    del v407
    v409 = spiral_wrap(v393 + v401, 64, True)
    del v393, v401
    v410 = spiral_wrap(v394 + v406, 64, True)
    del v394, v406
    v411 = spiral_wrap(v396 + v408, 64, True)
    del v396, v408
    v412 = spiral_wrap(v386 + v409, 64, True)
    del v386, v409, v412
    v413 = spiral_wrap(v390 + v410, 64, True)
    del v390, v410, v413
    v414 = spiral_wrap(v392 + v411, 64, True)
    del v392, v411
    v415 = 0 + 1
    v416 = v415 + 1
    del v415
    v417 = v416 + 1
    del v416
    v418 = v417 + 1
    del v417
    v419 = 0 + 1
    v420 = v419 + 1
    del v419
    v421 = v420 + 1
    del v420
    v422 = v421 + 1
    del v421
    v423 = v418 == v422
    if v423:
        v424 = 0
    else:
        v424 = 1
    del v423
    v425 = 0 + 1
    v426 = 0 + 1
    v427 = v425 == v426
    if v427:
        v428 = 0
    else:
        v428 = 1
    del v427
    v429 = 0 + 1
    v430 = v429 + 1
    del v429
    v431 = v430 + 1
    del v430
    v432 = v431 + 1
    del v431
    v433 = v432 + 1
    del v432
    v434 = 0 + 1
    v435 = v434 + 1
    del v434
    v436 = v435 + 1
    del v435
    v437 = v436 + 1
    del v436
    v438 = v437 + 1
    del v437
    v439 = v433 == v438
    if v439:
        v440 = 0
    else:
        v440 = 1
    del v439
    v441 = spiral_wrap(v425 + v433, 64, True)
    del v425, v433
    v442 = spiral_wrap(v426 + v438, 64, True)
    del v426, v438
    v443 = spiral_wrap(v428 + v440, 64, True)
    del v428, v440
    v444 = spiral_wrap(v418 + v441, 64, True)
    del v418, v441, v444
    v445 = spiral_wrap(v422 + v442, 64, True)
    del v422, v442, v445
    v446 = spiral_wrap(v424 + v443, 64, True)
    del v424, v443
    v447 = spiral_wrap(v414 + v446, 64, True)
    del v414, v446
    v448 = 0 + 1
    v449 = v448 + 1
    del v448
    v450 = v449 + 1
    del v449
    v451 = v450 + 1
    del v450
    v452 = 0 + 1
    v453 = v452 + 1
    del v452
    v454 = v453 + 1
    del v453
    v455 = v454 + 1
    del v454
    v456 = v451 == v455
    if v456:
        v457 = 0
    else:
        v457 = 1
    del v456
    v458 = 0 + 1
    v459 = 0 + 1
    v460 = v458 == v459
    if v460:
        v461 = 0
    else:
        v461 = 1
    del v460
    v462 = 0 + 1
    v463 = v462 + 1
    del v462
    v464 = v463 + 1
    del v463
    v465 = v464 + 1
    del v464
    v466 = v465 + 1
    del v465
    v467 = 0 + 1
    v468 = v467 + 1
    del v467
    v469 = v468 + 1
    del v468
    v470 = v469 + 1
    del v469
    v471 = v470 + 1
    del v470
    v472 = v466 == v471
    if v472:
        v473 = 0
    else:
        v473 = 1
    del v472
    v474 = spiral_wrap(v458 + v466, 64, True)
    del v458, v466
    v475 = spiral_wrap(v459 + v471, 64, True)
    del v459, v471
    v476 = spiral_wrap(v461 + v473, 64, True)
    del v461, v473
    v477 = spiral_wrap(v451 + v474, 64, True)
    del v451, v474, v477
    v478 = spiral_wrap(v455 + v475, 64, True)
    del v455, v475, v478
    v479 = spiral_wrap(v457 + v476, 64, True)
    del v457, v476
    v480 = 0 + 1
    v481 = v480 + 1
    del v480
    v482 = v481 + 1
    del v481
    v483 = v482 + 1
    del v482
    v484 = 0 + 1
    v485 = v484 + 1
    del v484
    v486 = v485 + 1
    del v485
    v487 = v486 + 1
    del v486
    v488 = v483 == v487
    if v488:
        v489 = 0
    else:
        v489 = 1
    del v488
    v490 = 0 + 1
    v491 = 0 + 1
    v492 = v490 == v491
    if v492:
        v493 = 0
    else:
        v493 = 1
    del v492
    v494 = 0 + 1
    v495 = v494 + 1
    del v494
    v496 = v495 + 1
    del v495
    v497 = v496 + 1
    del v496
    v498 = v497 + 1
    del v497
    v499 = 0 + 1
    v500 = v499 + 1
    del v499
    v501 = v500 + 1
    del v500
    v502 = v501 + 1
    del v501
    v503 = v502 + 1
    del v502
    v504 = v498 == v503
    if v504:
        v505 = 0
    else:
        v505 = 1
    del v504
    v506 = spiral_wrap(v490 + v498, 64, True)
    del v490, v498
    v507 = spiral_wrap(v491 + v503, 64, True)
    del v491, v503
    v508 = spiral_wrap(v493 + v505, 64, True)
    del v493, v505
    v509 = spiral_wrap(v483 + v506, 64, True)
    del v483, v506, v509
    v510 = spiral_wrap(v487 + v507, 64, True)
    del v487, v507, v510
    v511 = spiral_wrap(v489 + v508, 64, True)
    del v489, v508
    v512 = spiral_wrap(v479 + v511, 64, True)
    del v479, v511
    v513 = spiral_wrap(v447 + v512, 64, True)
    del v447, v512
    v514 = 0 + 1
    v515 = v514 + 1
    del v514
    v516 = v515 + 1
    del v515
    v517 = v516 + 1
    del v516
    v518 = 0 + 1
    v519 = v518 + 1
    del v518
    v520 = v519 + 1
    del v519
    v521 = v520 + 1
    del v520
    v522 = v517 == v521
    if v522:
        v523 = 0
    else:
        v523 = 1
    del v522
    v524 = 0 + 1
    v525 = 0 + 1
    v526 = v524 == v525
    if v526:
        v527 = 0
    else:
        v527 = 1
    del v526
    v528 = 0 + 1
    v529 = v528 + 1
    del v528
    v530 = v529 + 1
    del v529
    v531 = v530 + 1
    del v530
    v532 = v531 + 1
    del v531
    v533 = 0 + 1
    v534 = v533 + 1
    del v533
    v535 = v534 + 1
    del v534
    v536 = v535 + 1
    del v535
    v537 = v536 + 1
    del v536
    v538 = v532 == v537
    if v538:
        v539 = 0
    else:
        v539 = 1
    del v538
    v540 = spiral_wrap(v524 + v532, 64, True)
    del v524, v532
    v541 = spiral_wrap(v525 + v537, 64, True)
    del v525, v537
    v542 = spiral_wrap(v527 + v539, 64, True)
    del v527, v539
    v543 = spiral_wrap(v517 + v540, 64, True)
    del v517, v540
    v544 = spiral_wrap(v521 + v541, 64, True)
    del v521, v541
    v545 = spiral_wrap(v523 + v542, 64, True)
    del v523, v542
    v546 = spiral_wrap(v544 + v545, 64, True)
    del v544, v545
    v547 = spiral_wrap(v543 + v546, 64, True)
    del v543, v546
    v548 = spiral_wrap(3 + v547, 64, True)
    del v547
    v549 = 0 + 1
    v550 = v549 + 1
    del v549
    v551 = v550 + 1
    del v550
    v552 = v551 + 1
    del v551
    v553 = 0 + 1
    v554 = v553 + 1
    del v553
    v555 = v554 + 1
    del v554
    v556 = v555 + 1
    del v555
    v557 = v552 == v556
    if v557:
        v558 = 0
    else:
        v558 = 1
    del v557
    v559 = 0 + 1
    v560 = 0 + 1
    v561 = v559 == v560
    if v561:
        v562 = 0
    else:
        v562 = 1
    del v561
    v563 = 0 + 1
    v564 = v563 + 1
    del v563
    v565 = v564 + 1
    del v564
    v566 = v565 + 1
    del v565
    v567 = v566 + 1
    del v566
    v568 = 0 + 1
    v569 = v568 + 1
    del v568
    v570 = v569 + 1
    del v569
    v571 = v570 + 1
    del v570
    v572 = v571 + 1
    del v571
    v573 = v567 == v572
    if v573:
        v574 = 0
    else:
        v574 = 1
    del v573
    v575 = spiral_wrap(v559 + v567, 64, True)
    del v559, v567
    v576 = spiral_wrap(v560 + v572, 64, True)
    del v560, v572
    v577 = spiral_wrap(v562 + v574, 64, True)
    del v562, v574
    v578 = spiral_wrap(v552 + v575, 64, True)
    del v552, v575
    v579 = spiral_wrap(v556 + v576, 64, True)
    del v556, v576
    v580 = spiral_wrap(v558 + v577, 64, True)
    del v558, v577
    v581 = spiral_wrap(v579 + v580, 64, True)
    del v579, v580
    v582 = spiral_wrap(v578 + v581, 64, True)
    del v578, v581
    v583 = spiral_wrap(3 + v582, 64, True)
    del v582
    v584 = v548 == v583
    if v584:
        v585 = 0 + 1
        v586 = v585 + 1
        del v585
        v587 = v586 + 1
        del v586
        v588 = v587 + 1
        del v587
        v589 = 0 + 1
        v590 = v589 + 1
        del v589
        v591 = v590 + 1
        del v590
        v592 = v591 + 1
        del v591
        v593 = v588 == v592
        if v593:
            v594 = 0
        else:
            v594 = 1
        del v593
        v595 = 0 + 1
        v596 = 0 + 1
        v597 = v595 == v596
        if v597:
            v598 = 0
        else:
            v598 = 1
        del v597
        v599 = 0 + 1
        v600 = v599 + 1
        del v599
        v601 = v600 + 1
        del v600
        v602 = v601 + 1
        del v601
        v603 = v602 + 1
        del v602
        v604 = 0 + 1
        v605 = v604 + 1
        del v604
        v606 = v605 + 1
        del v605
        v607 = v606 + 1
        del v606
        v608 = v607 + 1
        del v607
        v609 = v603 == v608
        if v609:
            v610 = 0
        else:
            v610 = 1
        del v609
        v611 = spiral_wrap(v595 + v603, 64, True)
        del v595, v603
        v612 = spiral_wrap(v596 + v608, 64, True)
        del v596, v608
        v613 = spiral_wrap(v598 + v610, 64, True)
        del v598, v610
        v614 = spiral_wrap(v588 + v611, 64, True)
        del v588, v611
        v615 = spiral_wrap(v592 + v612, 64, True)
        del v592, v612
        v616 = spiral_wrap(v594 + v613, 64, True)
        del v594, v613
        v617 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v621 = US0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v614, v615, v616, v617)
    else:
        v619 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v621 = US0_TypedFxHashedStatementChecksumValidationRejected(v548, v583, v619)
    del v583, v584
    match v621:
        case US0_TypedFxHashedStatementChecksumValidationAccepted(v625, v626, v627, v628, v629, _): # TypedFxHashedStatementChecksumValidationAccepted
            v640, v641, v642, v643, v644, v645, v646, v647, v648 = 1, 0, 0, 0, v625, v626, v627, v628, v629
        case US0_TypedFxHashedStatementChecksumValidationRejected(v622, v623, _): # TypedFxHashedStatementChecksumValidationRejected
            v640, v641, v642, v643, v644, v645, v646, v647, v648 = 0, 1, v622, v623, 0, 0, 0, 0, 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v621, v642, v643
    v649 = v513 == 0
    del v513
    v650 = v548 == 23
    del v548
    v651 = v640 == 1
    del v640
    v652 = v641 == 0
    del v641
    v653 = v644 == 1
    del v644
    v654 = v645 == 3
    del v645
    v655 = v646 == 10
    del v646
    v656 = v647 == 10
    del v647
    v657 = v648 == 0
    del v648
    v658 = v649 and v650
    del v649, v650
    v659 = v658 and v651
    del v651, v658
    v660 = v659 and v652
    del v652, v659
    v661 = v660 and v653
    del v653, v660
    v662 = v661 and v654
    del v654, v661
    v663 = v662 and v655
    del v655, v662
    v664 = v663 and v656
    del v656, v663
    v665 = v664 and v657
    del v657, v664
    if v665:
        pass
    else:
        raise Exception("typed-FX-statement-recursive-writer-checksummed-restart-runtime-mismatch")
    del v665
    v666 = 0 + 1
    v667 = v666 + 1
    del v666
    v668 = v667 + 1
    del v667
    v669 = v668 + 1
    del v668
    v670 = 0 + 1
    v671 = v670 + 1
    del v670
    v672 = v671 + 1
    del v671
    v673 = v672 + 1
    del v672
    v674 = v669 == v673
    if v674:
        v675 = 0
    else:
        v675 = 1
    del v674
    v676 = 0 + 1
    v677 = 0 + 1
    v678 = v676 == v677
    if v678:
        v679 = 0
    else:
        v679 = 1
    del v678
    v680 = 0 + 1
    v681 = v680 + 1
    del v680
    v682 = v681 + 1
    del v681
    v683 = v682 + 1
    del v682
    v684 = v683 + 1
    del v683
    v685 = 0 + 1
    v686 = v685 + 1
    del v685
    v687 = v686 + 1
    del v686
    v688 = v687 + 1
    del v687
    v689 = v688 + 1
    del v688
    v690 = v684 == v689
    if v690:
        v691 = 0
    else:
        v691 = 1
    del v690
    v692 = spiral_wrap(v676 + v684, 64, True)
    del v676, v684
    v693 = spiral_wrap(v677 + v689, 64, True)
    del v677, v689
    v694 = spiral_wrap(v679 + v691, 64, True)
    del v679, v691
    v695 = spiral_wrap(v669 + v692, 64, True)
    del v669, v692, v695
    v696 = spiral_wrap(v673 + v693, 64, True)
    del v673, v693, v696
    v697 = spiral_wrap(v675 + v694, 64, True)
    del v675, v694
    v698 = 0 + 1
    v699 = v698 + 1
    del v698
    v700 = v699 + 1
    del v699
    v701 = v700 + 1
    del v700
    v702 = 0 + 1
    v703 = v702 + 1
    del v702
    v704 = v703 + 1
    del v703
    v705 = v704 + 1
    del v704
    v706 = v701 == v705
    if v706:
        v707 = 0
    else:
        v707 = 1
    del v706
    v708 = 0 + 1
    v709 = 0 + 1
    v710 = v708 == v709
    if v710:
        v711 = 0
    else:
        v711 = 1
    del v710
    v712 = 0 + 1
    v713 = v712 + 1
    del v712
    v714 = v713 + 1
    del v713
    v715 = v714 + 1
    del v714
    v716 = v715 + 1
    del v715
    v717 = 0 + 1
    v718 = v717 + 1
    del v717
    v719 = v718 + 1
    del v718
    v720 = v719 + 1
    del v719
    v721 = v720 + 1
    del v720
    v722 = v716 == v721
    if v722:
        v723 = 0
    else:
        v723 = 1
    del v722
    v724 = spiral_wrap(v708 + v716, 64, True)
    del v708, v716
    v725 = spiral_wrap(v709 + v721, 64, True)
    del v709, v721
    v726 = spiral_wrap(v711 + v723, 64, True)
    del v711, v723
    v727 = spiral_wrap(v701 + v724, 64, True)
    del v701, v724, v727
    v728 = spiral_wrap(v705 + v725, 64, True)
    del v705, v725, v728
    v729 = spiral_wrap(v707 + v726, 64, True)
    del v707, v726
    v730 = spiral_wrap(v697 + v729, 64, True)
    del v697, v729
    v731 = 0 + 1
    v732 = v731 + 1
    del v731
    v733 = v732 + 1
    del v732
    v734 = v733 + 1
    del v733
    v735 = 0 + 1
    v736 = v735 + 1
    del v735
    v737 = v736 + 1
    del v736
    v738 = v737 + 1
    del v737
    v739 = v734 == v738
    if v739:
        v740 = 0
    else:
        v740 = 1
    del v739
    v741 = 0 + 1
    v742 = 0 + 1
    v743 = v741 == v742
    if v743:
        v744 = 0
    else:
        v744 = 1
    del v743
    v745 = 0 + 1
    v746 = v745 + 1
    del v745
    v747 = v746 + 1
    del v746
    v748 = v747 + 1
    del v747
    v749 = v748 + 1
    del v748
    v750 = 0 + 1
    v751 = v750 + 1
    del v750
    v752 = v751 + 1
    del v751
    v753 = v752 + 1
    del v752
    v754 = v753 + 1
    del v753
    v755 = v749 == v754
    if v755:
        v756 = 0
    else:
        v756 = 1
    del v755
    v757 = spiral_wrap(v741 + v749, 64, True)
    del v741, v749
    v758 = spiral_wrap(v742 + v754, 64, True)
    del v742, v754
    v759 = spiral_wrap(v744 + v756, 64, True)
    del v744, v756
    v760 = spiral_wrap(v734 + v757, 64, True)
    del v734, v757, v760
    v761 = spiral_wrap(v738 + v758, 64, True)
    del v738, v758, v761
    v762 = spiral_wrap(v740 + v759, 64, True)
    del v740, v759
    v763 = 0 + 1
    v764 = v763 + 1
    del v763
    v765 = v764 + 1
    del v764
    v766 = v765 + 1
    del v765
    v767 = 0 + 1
    v768 = v767 + 1
    del v767
    v769 = v768 + 1
    del v768
    v770 = v769 + 1
    del v769
    v771 = v766 == v770
    if v771:
        v772 = 0
    else:
        v772 = 1
    del v771
    v773 = 0 + 1
    v774 = 0 + 1
    v775 = v773 == v774
    if v775:
        v776 = 0
    else:
        v776 = 1
    del v775
    v777 = 0 + 1
    v778 = v777 + 1
    del v777
    v779 = v778 + 1
    del v778
    v780 = v779 + 1
    del v779
    v781 = v780 + 1
    del v780
    v782 = 0 + 1
    v783 = v782 + 1
    del v782
    v784 = v783 + 1
    del v783
    v785 = v784 + 1
    del v784
    v786 = v785 + 1
    del v785
    v787 = v781 == v786
    if v787:
        v788 = 0
    else:
        v788 = 1
    del v787
    v789 = spiral_wrap(v773 + v781, 64, True)
    del v773, v781
    v790 = spiral_wrap(v774 + v786, 64, True)
    del v774, v786
    v791 = spiral_wrap(v776 + v788, 64, True)
    del v776, v788
    v792 = spiral_wrap(v766 + v789, 64, True)
    del v766, v789, v792
    v793 = spiral_wrap(v770 + v790, 64, True)
    del v770, v790, v793
    v794 = spiral_wrap(v772 + v791, 64, True)
    del v772, v791
    v795 = spiral_wrap(v762 + v794, 64, True)
    del v762, v794
    v796 = spiral_wrap(v730 + v795, 64, True)
    del v730, v795
    v797 = 0 + 1
    v798 = v797 + 1
    del v797
    v799 = v798 + 1
    del v798
    v800 = v799 + 1
    del v799
    v801 = 0 + 1
    v802 = v801 + 1
    del v801
    v803 = v802 + 1
    del v802
    v804 = v803 + 1
    del v803
    v805 = v800 == v804
    if v805:
        v806 = 0
    else:
        v806 = 1
    del v805
    v807 = 0 + 1
    v808 = 0 + 1
    v809 = v807 == v808
    if v809:
        v810 = 0
    else:
        v810 = 1
    del v809
    v811 = 0 + 1
    v812 = v811 + 1
    del v811
    v813 = v812 + 1
    del v812
    v814 = v813 + 1
    del v813
    v815 = v814 + 1
    del v814
    v816 = 0 + 1
    v817 = v816 + 1
    del v816
    v818 = v817 + 1
    del v817
    v819 = v818 + 1
    del v818
    v820 = v819 + 1
    del v819
    v821 = v815 == v820
    if v821:
        v822 = 0
    else:
        v822 = 1
    del v821
    v823 = spiral_wrap(v807 + v815, 64, True)
    del v807, v815
    v824 = spiral_wrap(v808 + v820, 64, True)
    del v808, v820
    v825 = spiral_wrap(v810 + v822, 64, True)
    del v810, v822
    v826 = spiral_wrap(v800 + v823, 64, True)
    del v800, v823
    v827 = spiral_wrap(v804 + v824, 64, True)
    del v804, v824
    v828 = spiral_wrap(v806 + v825, 64, True)
    del v806, v825
    v829 = spiral_wrap(v827 + v828, 64, True)
    del v827, v828
    v830 = spiral_wrap(v826 + v829, 64, True)
    del v826, v829
    v831 = spiral_wrap(3 + v830, 64, True)
    del v830
    v832 = 0 + 1
    v833 = v832 + 1
    del v832
    v834 = v833 + 1
    del v833
    v835 = v834 + 1
    del v834
    v836 = 0 + 1
    v837 = v836 + 1
    del v836
    v838 = v837 + 1
    del v837
    v839 = v838 + 1
    del v838
    v840 = v835 == v839
    if v840:
        v841 = 0
    else:
        v841 = 1
    del v840
    v842 = 0 + 1
    v843 = 0 + 1
    v844 = v842 == v843
    if v844:
        v845 = 0
    else:
        v845 = 1
    del v844
    v846 = 0 + 1
    v847 = v846 + 1
    del v846
    v848 = v847 + 1
    del v847
    v849 = v848 + 1
    del v848
    v850 = v849 + 1
    del v849
    v851 = 0 + 1
    v852 = v851 + 1
    del v851
    v853 = v852 + 1
    del v852
    v854 = v853 + 1
    del v853
    v855 = v854 + 1
    del v854
    v856 = v850 == v855
    if v856:
        v857 = 0
    else:
        v857 = 1
    del v856
    v858 = spiral_wrap(v842 + v850, 64, True)
    del v842, v850
    v859 = spiral_wrap(v843 + v855, 64, True)
    del v843, v855
    v860 = spiral_wrap(v845 + v857, 64, True)
    del v845, v857
    v861 = spiral_wrap(v835 + v858, 64, True)
    del v835, v858
    v862 = spiral_wrap(v839 + v859, 64, True)
    del v839, v859
    v863 = spiral_wrap(v841 + v860, 64, True)
    del v841, v860
    v864 = spiral_wrap(v862 + v863, 64, True)
    del v862, v863
    v865 = spiral_wrap(v861 + v864, 64, True)
    del v861, v864
    v866 = spiral_wrap(3 + v865, 64, True)
    del v865
    v867 = v831 == v866
    if v867:
        v868 = 0 + 1
        v869 = v868 + 1
        del v868
        v870 = v869 + 1
        del v869
        v871 = v870 + 1
        del v870
        v872 = 0 + 1
        v873 = v872 + 1
        del v872
        v874 = v873 + 1
        del v873
        v875 = v874 + 1
        del v874
        v876 = v871 == v875
        if v876:
            v877 = 0
        else:
            v877 = 1
        del v876
        v878 = 0 + 1
        v879 = 0 + 1
        v880 = v878 == v879
        if v880:
            v881 = 0
        else:
            v881 = 1
        del v880
        v882 = 0 + 1
        v883 = v882 + 1
        del v882
        v884 = v883 + 1
        del v883
        v885 = v884 + 1
        del v884
        v886 = v885 + 1
        del v885
        v887 = 0 + 1
        v888 = v887 + 1
        del v887
        v889 = v888 + 1
        del v888
        v890 = v889 + 1
        del v889
        v891 = v890 + 1
        del v890
        v892 = v886 == v891
        if v892:
            v893 = 0
        else:
            v893 = 1
        del v892
        v894 = spiral_wrap(v878 + v886, 64, True)
        del v878, v886
        v895 = spiral_wrap(v879 + v891, 64, True)
        del v879, v891
        v896 = spiral_wrap(v881 + v893, 64, True)
        del v881, v893
        v897 = spiral_wrap(v871 + v894, 64, True)
        del v871, v894
        v898 = spiral_wrap(v875 + v895, 64, True)
        del v875, v895
        v899 = spiral_wrap(v877 + v896, 64, True)
        del v877, v896
        v900 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v904 = US0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v897, v898, v899, v900)
    else:
        v902 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v904 = US0_TypedFxHashedStatementChecksumValidationRejected(v831, v866, v902)
    del v831, v866, v867
    match v904:
        case US0_TypedFxHashedStatementChecksumValidationAccepted(v908, v909, v910, v911, v912, _): # TypedFxHashedStatementChecksumValidationAccepted
            v923, v924, v925, v926, v927, v928, v929, v930, v931 = 1, 0, 0, 0, v908, v909, v910, v911, v912
        case US0_TypedFxHashedStatementChecksumValidationRejected(v905, v906, _): # TypedFxHashedStatementChecksumValidationRejected
            v923, v924, v925, v926, v927, v928, v929, v930, v931 = 0, 1, v905, v906, 0, 0, 0, 0, 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v904, v925, v926, v928, v929, v930
    v932 = 0 + 1
    v933 = v932 + 1
    del v932
    v934 = v933 + 1
    del v933
    v935 = v934 + 1
    del v934
    v936 = 0 + 1
    v937 = v936 + 1
    del v936
    v938 = v937 + 1
    del v937
    v939 = v938 + 1
    del v938
    v940 = v935 == v939
    if v940:
        v941 = 0
    else:
        v941 = 1
    del v940
    v942 = 0 + 1
    v943 = 0 + 1
    v944 = v942 == v943
    if v944:
        v945 = 0
    else:
        v945 = 1
    del v944
    v946 = 0 + 1
    v947 = v946 + 1
    del v946
    v948 = v947 + 1
    del v947
    v949 = v948 + 1
    del v948
    v950 = v949 + 1
    del v949
    v951 = 0 + 1
    v952 = v951 + 1
    del v951
    v953 = v952 + 1
    del v952
    v954 = v953 + 1
    del v953
    v955 = v954 + 1
    del v954
    v956 = v950 == v955
    if v956:
        v957 = 0
    else:
        v957 = 1
    del v956
    v958 = spiral_wrap(v942 + v950, 64, True)
    del v942, v950
    v959 = spiral_wrap(v943 + v955, 64, True)
    del v943, v955
    v960 = spiral_wrap(v945 + v957, 64, True)
    del v945, v957
    v961 = spiral_wrap(v935 + v958, 64, True)
    del v935, v958, v961
    v962 = spiral_wrap(v939 + v959, 64, True)
    del v939, v959, v962
    v963 = spiral_wrap(v941 + v960, 64, True)
    del v941, v960
    v964 = 0 + 1
    v965 = v964 + 1
    del v964
    v966 = v965 + 1
    del v965
    v967 = v966 + 1
    del v966
    v968 = 0 + 1
    v969 = v968 + 1
    del v968
    v970 = v969 + 1
    del v969
    v971 = v970 + 1
    del v970
    v972 = v967 == v971
    if v972:
        v973 = 0
    else:
        v973 = 1
    del v972
    v974 = 0 + 1
    v975 = 0 + 1
    v976 = v974 == v975
    if v976:
        v977 = 0
    else:
        v977 = 1
    del v976
    v978 = 0 + 1
    v979 = v978 + 1
    del v978
    v980 = v979 + 1
    del v979
    v981 = v980 + 1
    del v980
    v982 = v981 + 1
    del v981
    v983 = 0 + 1
    v984 = v983 + 1
    del v983
    v985 = v984 + 1
    del v984
    v986 = v985 + 1
    del v985
    v987 = v986 + 1
    del v986
    v988 = v982 == v987
    if v988:
        v989 = 0
    else:
        v989 = 1
    del v988
    v990 = spiral_wrap(v974 + v982, 64, True)
    del v974, v982
    v991 = spiral_wrap(v975 + v987, 64, True)
    del v975, v987
    v992 = spiral_wrap(v977 + v989, 64, True)
    del v977, v989
    v993 = spiral_wrap(v967 + v990, 64, True)
    del v967, v990, v993
    v994 = spiral_wrap(v971 + v991, 64, True)
    del v971, v991, v994
    v995 = spiral_wrap(v973 + v992, 64, True)
    del v973, v992
    v996 = spiral_wrap(v963 + v995, 64, True)
    del v963, v995
    v997 = spiral_wrap(v931 + v924, 64, True)
    del v924, v931
    v998 = spiral_wrap(v996 + v997, 64, True)
    del v996, v997
    v999 = spiral_wrap(v796 + v998, 64, True)
    del v796, v998
    v1000 = v927 == 1
    del v927
    v1001 = v923 == 1
    del v923
    v1002 = v999 == 0
    del v999
    v1003 = v1000 and v1001
    del v1000, v1001
    v1004 = v1003 and v1002
    del v1002, v1003
    if v1004:
        pass
    else:
        raise Exception("typed-FX-statement-recursive-writer-restart-invariant-runtime-mismatch")
    del v1004
    v1005 = 0 + 1
    v1006 = v1005 + 1
    del v1005
    v1007 = v1006 + 1
    del v1006
    v1008 = v1007 + 1
    del v1007
    v1009 = 0 + 1
    v1010 = v1009 + 1
    del v1009
    v1011 = v1010 + 1
    del v1010
    v1012 = v1011 + 1
    del v1011
    v1013 = v1008 == v1012
    if v1013:
        v1014 = 0
    else:
        v1014 = 1
    del v1013
    v1015 = 0 + 1
    v1016 = 0 + 1
    v1017 = v1015 == v1016
    if v1017:
        v1018 = 0
    else:
        v1018 = 1
    del v1017
    v1019 = 0 + 1
    v1020 = v1019 + 1
    del v1019
    v1021 = v1020 + 1
    del v1020
    v1022 = v1021 + 1
    del v1021
    v1023 = v1022 + 1
    del v1022
    v1024 = 0 + 1
    v1025 = v1024 + 1
    del v1024
    v1026 = v1025 + 1
    del v1025
    v1027 = v1026 + 1
    del v1026
    v1028 = v1027 + 1
    del v1027
    v1029 = v1023 == v1028
    if v1029:
        v1030 = 0
    else:
        v1030 = 1
    del v1029
    v1031 = spiral_wrap(v1015 + v1023, 64, True)
    del v1015, v1023
    v1032 = spiral_wrap(v1016 + v1028, 64, True)
    del v1016, v1028
    v1033 = spiral_wrap(v1018 + v1030, 64, True)
    del v1018, v1030
    v1034 = spiral_wrap(v1008 + v1031, 64, True)
    del v1008, v1031, v1034
    v1035 = spiral_wrap(v1012 + v1032, 64, True)
    del v1012, v1032, v1035
    v1036 = spiral_wrap(v1014 + v1033, 64, True)
    del v1014, v1033
    v1037 = 0 + 1
    v1038 = v1037 + 1
    del v1037
    v1039 = v1038 + 1
    del v1038
    v1040 = v1039 + 1
    del v1039
    v1041 = 0 + 1
    v1042 = v1041 + 1
    del v1041
    v1043 = v1042 + 1
    del v1042
    v1044 = v1043 + 1
    del v1043
    v1045 = v1040 == v1044
    if v1045:
        v1046 = 0
    else:
        v1046 = 1
    del v1045
    v1047 = 0 + 1
    v1048 = 0 + 1
    v1049 = v1047 == v1048
    if v1049:
        v1050 = 0
    else:
        v1050 = 1
    del v1049
    v1051 = 0 + 1
    v1052 = v1051 + 1
    del v1051
    v1053 = v1052 + 1
    del v1052
    v1054 = v1053 + 1
    del v1053
    v1055 = v1054 + 1
    del v1054
    v1056 = 0 + 1
    v1057 = v1056 + 1
    del v1056
    v1058 = v1057 + 1
    del v1057
    v1059 = v1058 + 1
    del v1058
    v1060 = v1059 + 1
    del v1059
    v1061 = v1055 == v1060
    if v1061:
        v1062 = 0
    else:
        v1062 = 1
    del v1061
    v1063 = spiral_wrap(v1047 + v1055, 64, True)
    del v1047, v1055
    v1064 = spiral_wrap(v1048 + v1060, 64, True)
    del v1048, v1060
    v1065 = spiral_wrap(v1050 + v1062, 64, True)
    del v1050, v1062
    v1066 = spiral_wrap(v1040 + v1063, 64, True)
    del v1040, v1063, v1066
    v1067 = spiral_wrap(v1044 + v1064, 64, True)
    del v1044, v1064, v1067
    v1068 = spiral_wrap(v1046 + v1065, 64, True)
    del v1046, v1065
    v1069 = spiral_wrap(v1036 + v1068, 64, True)
    del v1036, v1068
    v1070 = 0 + 1
    v1071 = v1070 + 1
    del v1070
    v1072 = v1071 + 1
    del v1071
    v1073 = v1072 + 1
    del v1072
    v1074 = 0 + 1
    v1075 = v1074 + 1
    del v1074
    v1076 = v1075 + 1
    del v1075
    v1077 = v1076 + 1
    del v1076
    v1078 = v1073 == v1077
    if v1078:
        v1079 = 0
    else:
        v1079 = 1
    del v1078
    v1080 = 0 + 1
    v1081 = 0 + 1
    v1082 = v1080 == v1081
    if v1082:
        v1083 = 0
    else:
        v1083 = 1
    del v1082
    v1084 = 0 + 1
    v1085 = v1084 + 1
    del v1084
    v1086 = v1085 + 1
    del v1085
    v1087 = v1086 + 1
    del v1086
    v1088 = v1087 + 1
    del v1087
    v1089 = 0 + 1
    v1090 = v1089 + 1
    del v1089
    v1091 = v1090 + 1
    del v1090
    v1092 = v1091 + 1
    del v1091
    v1093 = v1092 + 1
    del v1092
    v1094 = v1088 == v1093
    if v1094:
        v1095 = 0
    else:
        v1095 = 1
    del v1094
    v1096 = spiral_wrap(v1080 + v1088, 64, True)
    del v1080, v1088
    v1097 = spiral_wrap(v1081 + v1093, 64, True)
    del v1081, v1093
    v1098 = spiral_wrap(v1083 + v1095, 64, True)
    del v1083, v1095
    v1099 = spiral_wrap(v1073 + v1096, 64, True)
    del v1073, v1096, v1099
    v1100 = spiral_wrap(v1077 + v1097, 64, True)
    del v1077, v1097, v1100
    v1101 = spiral_wrap(v1079 + v1098, 64, True)
    del v1079, v1098
    v1102 = 0 + 1
    v1103 = v1102 + 1
    del v1102
    v1104 = v1103 + 1
    del v1103
    v1105 = v1104 + 1
    del v1104
    v1106 = 0 + 1
    v1107 = v1106 + 1
    del v1106
    v1108 = v1107 + 1
    del v1107
    v1109 = v1108 + 1
    del v1108
    v1110 = v1105 == v1109
    if v1110:
        v1111 = 0
    else:
        v1111 = 1
    del v1110
    v1112 = 0 + 1
    v1113 = 0 + 1
    v1114 = v1112 == v1113
    if v1114:
        v1115 = 0
    else:
        v1115 = 1
    del v1114
    v1116 = 0 + 1
    v1117 = v1116 + 1
    del v1116
    v1118 = v1117 + 1
    del v1117
    v1119 = v1118 + 1
    del v1118
    v1120 = v1119 + 1
    del v1119
    v1121 = 0 + 1
    v1122 = v1121 + 1
    del v1121
    v1123 = v1122 + 1
    del v1122
    v1124 = v1123 + 1
    del v1123
    v1125 = v1124 + 1
    del v1124
    v1126 = v1120 == v1125
    if v1126:
        v1127 = 0
    else:
        v1127 = 1
    del v1126
    v1128 = spiral_wrap(v1112 + v1120, 64, True)
    del v1112, v1120
    v1129 = spiral_wrap(v1113 + v1125, 64, True)
    del v1113, v1125
    v1130 = spiral_wrap(v1115 + v1127, 64, True)
    del v1115, v1127
    v1131 = spiral_wrap(v1105 + v1128, 64, True)
    del v1105, v1128, v1131
    v1132 = spiral_wrap(v1109 + v1129, 64, True)
    del v1109, v1129, v1132
    v1133 = spiral_wrap(v1111 + v1130, 64, True)
    del v1111, v1130
    v1134 = spiral_wrap(v1101 + v1133, 64, True)
    del v1101, v1133
    v1135 = 0 + 1
    v1136 = v1135 + 1
    del v1135
    v1137 = v1136 + 1
    del v1136
    v1138 = v1137 + 1
    del v1137
    v1139 = 0 + 1
    v1140 = v1139 + 1
    del v1139
    v1141 = v1140 + 1
    del v1140
    v1142 = v1141 + 1
    del v1141
    v1143 = v1138 == v1142
    if v1143:
        v1144 = 0
    else:
        v1144 = 1
    del v1143
    v1145 = 0 + 1
    v1146 = 0 + 1
    v1147 = v1145 == v1146
    if v1147:
        v1148 = 0
    else:
        v1148 = 1
    del v1147
    v1149 = 0 + 1
    v1150 = v1149 + 1
    del v1149
    v1151 = v1150 + 1
    del v1150
    v1152 = v1151 + 1
    del v1151
    v1153 = v1152 + 1
    del v1152
    v1154 = 0 + 1
    v1155 = v1154 + 1
    del v1154
    v1156 = v1155 + 1
    del v1155
    v1157 = v1156 + 1
    del v1156
    v1158 = v1157 + 1
    del v1157
    v1159 = v1153 == v1158
    if v1159:
        v1160 = 0
    else:
        v1160 = 1
    del v1159
    v1161 = spiral_wrap(v1145 + v1153, 64, True)
    del v1145, v1153
    v1162 = spiral_wrap(v1146 + v1158, 64, True)
    del v1146, v1158
    v1163 = spiral_wrap(v1148 + v1160, 64, True)
    del v1148, v1160
    v1164 = spiral_wrap(v1138 + v1161, 64, True)
    del v1138, v1161, v1164
    v1165 = spiral_wrap(v1142 + v1162, 64, True)
    del v1142, v1162, v1165
    v1166 = spiral_wrap(v1144 + v1163, 64, True)
    del v1144, v1163
    v1167 = 0 + 1
    v1168 = v1167 + 1
    del v1167
    v1169 = v1168 + 1
    del v1168
    v1170 = v1169 + 1
    del v1169
    v1171 = 0 + 1
    v1172 = v1171 + 1
    del v1171
    v1173 = v1172 + 1
    del v1172
    v1174 = v1173 + 1
    del v1173
    v1175 = v1170 == v1174
    if v1175:
        v1176 = 0
    else:
        v1176 = 1
    del v1175
    v1177 = 0 + 1
    v1178 = 0 + 1
    v1179 = v1177 == v1178
    if v1179:
        v1180 = 0
    else:
        v1180 = 1
    del v1179
    v1181 = 0 + 1
    v1182 = v1181 + 1
    del v1181
    v1183 = v1182 + 1
    del v1182
    v1184 = v1183 + 1
    del v1183
    v1185 = v1184 + 1
    del v1184
    v1186 = 0 + 1
    v1187 = v1186 + 1
    del v1186
    v1188 = v1187 + 1
    del v1187
    v1189 = v1188 + 1
    del v1188
    v1190 = v1189 + 1
    del v1189
    v1191 = v1185 == v1190
    if v1191:
        v1192 = 0
    else:
        v1192 = 1
    del v1191
    v1193 = spiral_wrap(v1177 + v1185, 64, True)
    del v1177, v1185
    v1194 = spiral_wrap(v1178 + v1190, 64, True)
    del v1178, v1190
    v1195 = spiral_wrap(v1180 + v1192, 64, True)
    del v1180, v1192
    v1196 = spiral_wrap(v1170 + v1193, 64, True)
    del v1170, v1193, v1196
    v1197 = spiral_wrap(v1174 + v1194, 64, True)
    del v1174, v1194, v1197
    v1198 = spiral_wrap(v1176 + v1195, 64, True)
    del v1176, v1195
    v1199 = 0 + 1
    v1200 = v1199 + 1
    del v1199
    v1201 = v1200 + 1
    del v1200
    v1202 = v1201 + 1
    del v1201
    v1203 = 0 + 1
    v1204 = v1203 + 1
    del v1203
    v1205 = v1204 + 1
    del v1204
    v1206 = v1205 + 1
    del v1205
    v1207 = v1202 == v1206
    if v1207:
        v1208 = 0
    else:
        v1208 = 1
    del v1207
    v1209 = 0 + 1
    v1210 = 0 + 1
    v1211 = v1209 == v1210
    if v1211:
        v1212 = 0
    else:
        v1212 = 1
    del v1211
    v1213 = 0 + 1
    v1214 = v1213 + 1
    del v1213
    v1215 = v1214 + 1
    del v1214
    v1216 = v1215 + 1
    del v1215
    v1217 = v1216 + 1
    del v1216
    v1218 = 0 + 1
    v1219 = v1218 + 1
    del v1218
    v1220 = v1219 + 1
    del v1219
    v1221 = v1220 + 1
    del v1220
    v1222 = v1221 + 1
    del v1221
    v1223 = v1217 == v1222
    if v1223:
        v1224 = 0
    else:
        v1224 = 1
    del v1223
    v1225 = spiral_wrap(v1209 + v1217, 64, True)
    del v1209, v1217
    v1226 = spiral_wrap(v1210 + v1222, 64, True)
    del v1210, v1222
    v1227 = spiral_wrap(v1212 + v1224, 64, True)
    del v1212, v1224
    v1228 = spiral_wrap(v1202 + v1225, 64, True)
    del v1202, v1225, v1228
    v1229 = spiral_wrap(v1206 + v1226, 64, True)
    del v1206, v1226, v1229
    v1230 = spiral_wrap(v1208 + v1227, 64, True)
    del v1208, v1227
    v1231 = 0 + 1
    v1232 = v1231 + 1
    del v1231
    v1233 = v1232 + 1
    del v1232
    v1234 = v1233 + 1
    del v1233
    v1235 = 0 + 1
    v1236 = v1235 + 1
    del v1235
    v1237 = v1236 + 1
    del v1236
    v1238 = v1237 + 1
    del v1237
    v1239 = v1234 == v1238
    if v1239:
        v1240 = 0
    else:
        v1240 = 1
    del v1239
    v1241 = 0 + 1
    v1242 = 0 + 1
    v1243 = v1241 == v1242
    if v1243:
        v1244 = 0
    else:
        v1244 = 1
    del v1243
    v1245 = 0 + 1
    v1246 = v1245 + 1
    del v1245
    v1247 = v1246 + 1
    del v1246
    v1248 = v1247 + 1
    del v1247
    v1249 = v1248 + 1
    del v1248
    v1250 = 0 + 1
    v1251 = v1250 + 1
    del v1250
    v1252 = v1251 + 1
    del v1251
    v1253 = v1252 + 1
    del v1252
    v1254 = v1253 + 1
    del v1253
    v1255 = v1249 == v1254
    if v1255:
        v1256 = 0
    else:
        v1256 = 1
    del v1255
    v1257 = spiral_wrap(v1241 + v1249, 64, True)
    del v1241, v1249
    v1258 = spiral_wrap(v1242 + v1254, 64, True)
    del v1242, v1254
    v1259 = spiral_wrap(v1244 + v1256, 64, True)
    del v1244, v1256
    v1260 = spiral_wrap(v1234 + v1257, 64, True)
    del v1234, v1257, v1260
    v1261 = spiral_wrap(v1238 + v1258, 64, True)
    del v1238, v1258, v1261
    v1262 = spiral_wrap(v1240 + v1259, 64, True)
    del v1240, v1259
    v1263 = spiral_wrap(v1230 + v1262, 64, True)
    del v1230, v1262
    v1264 = spiral_wrap(v1198 + v1263, 64, True)
    del v1198, v1263
    v1265 = spiral_wrap(v1166 + v1264, 64, True)
    del v1166, v1264
    v1266 = v1069 == 0
    v1267 = v1134 == v1069
    del v1069, v1134
    v1268 = v1265 == 0
    del v1265
    v1269 = v1266 and v1267
    del v1266, v1267
    v1270 = v1269 and v1268
    del v1268, v1269
    if v1270:
        pass
    else:
        raise Exception("typed-FX-statement-stale-writer-conflict-program-append-runtime-mismatch")
    del v1270
    v1271 = 0 + 1
    v1272 = v1271 + 1
    del v1271
    v1273 = v1272 + 1
    del v1272
    v1274 = v1273 + 1
    del v1273
    v1275 = 0 + 1
    v1276 = v1275 + 1
    del v1275
    v1277 = v1276 + 1
    del v1276
    v1278 = v1277 + 1
    del v1277
    v1279 = v1274 == v1278
    if v1279:
        v1280 = 0
    else:
        v1280 = 1
    del v1279
    v1281 = 0 + 1
    v1282 = 0 + 1
    v1283 = v1281 == v1282
    if v1283:
        v1284 = 0
    else:
        v1284 = 1
    del v1283
    v1285 = 0 + 1
    v1286 = v1285 + 1
    del v1285
    v1287 = v1286 + 1
    del v1286
    v1288 = v1287 + 1
    del v1287
    v1289 = v1288 + 1
    del v1288
    v1290 = 0 + 1
    v1291 = v1290 + 1
    del v1290
    v1292 = v1291 + 1
    del v1291
    v1293 = v1292 + 1
    del v1292
    v1294 = v1293 + 1
    del v1293
    v1295 = v1289 == v1294
    if v1295:
        v1296 = 0
    else:
        v1296 = 1
    del v1295
    v1297 = spiral_wrap(v1281 + v1289, 64, True)
    del v1281, v1289
    v1298 = spiral_wrap(v1282 + v1294, 64, True)
    del v1282, v1294
    v1299 = spiral_wrap(v1284 + v1296, 64, True)
    del v1284, v1296
    v1300 = spiral_wrap(v1274 + v1297, 64, True)
    del v1274, v1297, v1300
    v1301 = spiral_wrap(v1278 + v1298, 64, True)
    del v1278, v1298, v1301
    v1302 = spiral_wrap(v1280 + v1299, 64, True)
    del v1280, v1299
    v1303 = 0 + 1
    v1304 = v1303 + 1
    del v1303
    v1305 = v1304 + 1
    del v1304
    v1306 = v1305 + 1
    del v1305
    v1307 = 0 + 1
    v1308 = v1307 + 1
    del v1307
    v1309 = v1308 + 1
    del v1308
    v1310 = v1309 + 1
    del v1309
    v1311 = v1306 == v1310
    if v1311:
        v1312 = 0
    else:
        v1312 = 1
    del v1311
    v1313 = 0 + 1
    v1314 = 0 + 1
    v1315 = v1313 == v1314
    if v1315:
        v1316 = 0
    else:
        v1316 = 1
    del v1315
    v1317 = 0 + 1
    v1318 = v1317 + 1
    del v1317
    v1319 = v1318 + 1
    del v1318
    v1320 = v1319 + 1
    del v1319
    v1321 = v1320 + 1
    del v1320
    v1322 = 0 + 1
    v1323 = v1322 + 1
    del v1322
    v1324 = v1323 + 1
    del v1323
    v1325 = v1324 + 1
    del v1324
    v1326 = v1325 + 1
    del v1325
    v1327 = v1321 == v1326
    if v1327:
        v1328 = 0
    else:
        v1328 = 1
    del v1327
    v1329 = spiral_wrap(v1313 + v1321, 64, True)
    del v1313, v1321
    v1330 = spiral_wrap(v1314 + v1326, 64, True)
    del v1314, v1326
    v1331 = spiral_wrap(v1316 + v1328, 64, True)
    del v1316, v1328
    v1332 = spiral_wrap(v1306 + v1329, 64, True)
    del v1306, v1329, v1332
    v1333 = spiral_wrap(v1310 + v1330, 64, True)
    del v1310, v1330, v1333
    v1334 = spiral_wrap(v1312 + v1331, 64, True)
    del v1312, v1331
    v1335 = 0 + 1
    v1336 = v1335 + 1
    del v1335
    v1337 = v1336 + 1
    del v1336
    v1338 = v1337 + 1
    del v1337
    v1339 = 0 + 1
    v1340 = v1339 + 1
    del v1339
    v1341 = v1340 + 1
    del v1340
    v1342 = v1341 + 1
    del v1341
    v1343 = v1338 == v1342
    if v1343:
        v1344 = 0
    else:
        v1344 = 1
    del v1343
    v1345 = 0 + 1
    v1346 = 0 + 1
    v1347 = v1345 == v1346
    if v1347:
        v1348 = 0
    else:
        v1348 = 1
    del v1347
    v1349 = 0 + 1
    v1350 = v1349 + 1
    del v1349
    v1351 = v1350 + 1
    del v1350
    v1352 = v1351 + 1
    del v1351
    v1353 = v1352 + 1
    del v1352
    v1354 = 0 + 1
    v1355 = v1354 + 1
    del v1354
    v1356 = v1355 + 1
    del v1355
    v1357 = v1356 + 1
    del v1356
    v1358 = v1357 + 1
    del v1357
    v1359 = v1353 == v1358
    if v1359:
        v1360 = 0
    else:
        v1360 = 1
    del v1359
    v1361 = spiral_wrap(v1345 + v1353, 64, True)
    del v1345, v1353
    v1362 = spiral_wrap(v1346 + v1358, 64, True)
    del v1346, v1358
    v1363 = spiral_wrap(v1348 + v1360, 64, True)
    del v1348, v1360
    v1364 = spiral_wrap(v1338 + v1361, 64, True)
    del v1338, v1361, v1364
    v1365 = spiral_wrap(v1342 + v1362, 64, True)
    del v1342, v1362, v1365
    v1366 = spiral_wrap(v1344 + v1363, 64, True)
    del v1344, v1363
    v1367 = 0 + 1
    v1368 = v1367 + 1
    del v1367
    v1369 = v1368 + 1
    del v1368
    v1370 = v1369 + 1
    del v1369
    v1371 = 0 + 1
    v1372 = v1371 + 1
    del v1371
    v1373 = v1372 + 1
    del v1372
    v1374 = v1373 + 1
    del v1373
    v1375 = v1370 == v1374
    if v1375:
        v1376 = 0
    else:
        v1376 = 1
    del v1375
    v1377 = 0 + 1
    v1378 = 0 + 1
    v1379 = v1377 == v1378
    if v1379:
        v1380 = 0
    else:
        v1380 = 1
    del v1379
    v1381 = 0 + 1
    v1382 = v1381 + 1
    del v1381
    v1383 = v1382 + 1
    del v1382
    v1384 = v1383 + 1
    del v1383
    v1385 = v1384 + 1
    del v1384
    v1386 = 0 + 1
    v1387 = v1386 + 1
    del v1386
    v1388 = v1387 + 1
    del v1387
    v1389 = v1388 + 1
    del v1388
    v1390 = v1389 + 1
    del v1389
    v1391 = v1385 == v1390
    if v1391:
        v1392 = 0
    else:
        v1392 = 1
    del v1391
    v1393 = spiral_wrap(v1377 + v1385, 64, True)
    del v1377, v1385
    v1394 = spiral_wrap(v1378 + v1390, 64, True)
    del v1378, v1390
    v1395 = spiral_wrap(v1380 + v1392, 64, True)
    del v1380, v1392
    v1396 = spiral_wrap(v1370 + v1393, 64, True)
    del v1370, v1393, v1396
    v1397 = spiral_wrap(v1374 + v1394, 64, True)
    del v1374, v1394, v1397
    v1398 = spiral_wrap(v1376 + v1395, 64, True)
    del v1376, v1395
    v1399 = 0 + 1
    v1400 = v1399 + 1
    del v1399
    v1401 = v1400 + 1
    del v1400
    v1402 = v1401 + 1
    del v1401
    v1403 = 0 + 1
    v1404 = v1403 + 1
    del v1403
    v1405 = v1404 + 1
    del v1404
    v1406 = v1405 + 1
    del v1405
    v1407 = v1402 == v1406
    if v1407:
        v1408 = 0
    else:
        v1408 = 1
    del v1407
    v1409 = 0 + 1
    v1410 = 0 + 1
    v1411 = v1409 == v1410
    if v1411:
        v1412 = 0
    else:
        v1412 = 1
    del v1411
    v1413 = 0 + 1
    v1414 = v1413 + 1
    del v1413
    v1415 = v1414 + 1
    del v1414
    v1416 = v1415 + 1
    del v1415
    v1417 = v1416 + 1
    del v1416
    v1418 = 0 + 1
    v1419 = v1418 + 1
    del v1418
    v1420 = v1419 + 1
    del v1419
    v1421 = v1420 + 1
    del v1420
    v1422 = v1421 + 1
    del v1421
    v1423 = v1417 == v1422
    if v1423:
        v1424 = 0
    else:
        v1424 = 1
    del v1423
    v1425 = spiral_wrap(v1409 + v1417, 64, True)
    del v1409, v1417
    v1426 = spiral_wrap(v1410 + v1422, 64, True)
    del v1410, v1422
    v1427 = spiral_wrap(v1412 + v1424, 64, True)
    del v1412, v1424
    v1428 = spiral_wrap(v1402 + v1425, 64, True)
    del v1402, v1425, v1428
    v1429 = spiral_wrap(v1406 + v1426, 64, True)
    del v1406, v1426, v1429
    v1430 = spiral_wrap(v1408 + v1427, 64, True)
    del v1408, v1427
    v1431 = 0 + 1
    v1432 = v1431 + 1
    del v1431
    v1433 = v1432 + 1
    del v1432
    v1434 = v1433 + 1
    del v1433
    v1435 = 0 + 1
    v1436 = v1435 + 1
    del v1435
    v1437 = v1436 + 1
    del v1436
    v1438 = v1437 + 1
    del v1437
    v1439 = v1434 == v1438
    if v1439:
        v1440 = 0
    else:
        v1440 = 1
    del v1439
    v1441 = 0 + 1
    v1442 = 0 + 1
    v1443 = v1441 == v1442
    if v1443:
        v1444 = 0
    else:
        v1444 = 1
    del v1443
    v1445 = 0 + 1
    v1446 = v1445 + 1
    del v1445
    v1447 = v1446 + 1
    del v1446
    v1448 = v1447 + 1
    del v1447
    v1449 = v1448 + 1
    del v1448
    v1450 = 0 + 1
    v1451 = v1450 + 1
    del v1450
    v1452 = v1451 + 1
    del v1451
    v1453 = v1452 + 1
    del v1452
    v1454 = v1453 + 1
    del v1453
    v1455 = v1449 == v1454
    if v1455:
        v1456 = 0
    else:
        v1456 = 1
    del v1455
    v1457 = spiral_wrap(v1441 + v1449, 64, True)
    del v1441, v1449
    v1458 = spiral_wrap(v1442 + v1454, 64, True)
    del v1442, v1454
    v1459 = spiral_wrap(v1444 + v1456, 64, True)
    del v1444, v1456
    v1460 = spiral_wrap(v1434 + v1457, 64, True)
    del v1434, v1457, v1460
    v1461 = spiral_wrap(v1438 + v1458, 64, True)
    del v1438, v1458, v1461
    v1462 = spiral_wrap(v1440 + v1459, 64, True)
    del v1440, v1459
    v1463 = spiral_wrap(v1430 + v1462, 64, True)
    del v1430, v1462
    v1464 = spiral_wrap(v1398 + v1463, 64, True)
    del v1398, v1463
    v1465 = spiral_wrap(v1366 + v1464, 64, True)
    del v1366, v1464
    v1466 = spiral_wrap(v1334 + v1465, 64, True)
    del v1334, v1465
    v1467 = spiral_wrap(v1302 + v1466, 64, True)
    del v1302, v1466
    v1468 = 0 + 1
    v1469 = v1468 + 1
    del v1468
    v1470 = v1469 + 1
    del v1469
    v1471 = v1470 + 1
    del v1470
    v1472 = 0 + 1
    v1473 = v1472 + 1
    del v1472
    v1474 = v1473 + 1
    del v1473
    v1475 = v1474 + 1
    del v1474
    v1476 = v1471 == v1475
    if v1476:
        v1477 = 0
    else:
        v1477 = 1
    del v1476
    v1478 = 0 + 1
    v1479 = 0 + 1
    v1480 = v1478 == v1479
    if v1480:
        v1481 = 0
    else:
        v1481 = 1
    del v1480
    v1482 = 0 + 1
    v1483 = v1482 + 1
    del v1482
    v1484 = v1483 + 1
    del v1483
    v1485 = v1484 + 1
    del v1484
    v1486 = v1485 + 1
    del v1485
    v1487 = 0 + 1
    v1488 = v1487 + 1
    del v1487
    v1489 = v1488 + 1
    del v1488
    v1490 = v1489 + 1
    del v1489
    v1491 = v1490 + 1
    del v1490
    v1492 = v1486 == v1491
    if v1492:
        v1493 = 0
    else:
        v1493 = 1
    del v1492
    v1494 = spiral_wrap(v1478 + v1486, 64, True)
    del v1478, v1486
    v1495 = spiral_wrap(v1479 + v1491, 64, True)
    del v1479, v1491
    v1496 = spiral_wrap(v1481 + v1493, 64, True)
    del v1481, v1493
    v1497 = spiral_wrap(v1471 + v1494, 64, True)
    del v1471, v1494, v1497
    v1498 = spiral_wrap(v1475 + v1495, 64, True)
    del v1475, v1495, v1498
    v1499 = spiral_wrap(v1477 + v1496, 64, True)
    del v1477, v1496
    v1500 = 0 + 1
    v1501 = v1500 + 1
    del v1500
    v1502 = v1501 + 1
    del v1501
    v1503 = v1502 + 1
    del v1502
    v1504 = 0 + 1
    v1505 = v1504 + 1
    del v1504
    v1506 = v1505 + 1
    del v1505
    v1507 = v1506 + 1
    del v1506
    v1508 = v1503 == v1507
    if v1508:
        v1509 = 0
    else:
        v1509 = 1
    del v1508
    v1510 = 0 + 1
    v1511 = 0 + 1
    v1512 = v1510 == v1511
    if v1512:
        v1513 = 0
    else:
        v1513 = 1
    del v1512
    v1514 = 0 + 1
    v1515 = v1514 + 1
    del v1514
    v1516 = v1515 + 1
    del v1515
    v1517 = v1516 + 1
    del v1516
    v1518 = v1517 + 1
    del v1517
    v1519 = 0 + 1
    v1520 = v1519 + 1
    del v1519
    v1521 = v1520 + 1
    del v1520
    v1522 = v1521 + 1
    del v1521
    v1523 = v1522 + 1
    del v1522
    v1524 = v1518 == v1523
    if v1524:
        v1525 = 0
    else:
        v1525 = 1
    del v1524
    v1526 = spiral_wrap(v1510 + v1518, 64, True)
    del v1510, v1518
    v1527 = spiral_wrap(v1511 + v1523, 64, True)
    del v1511, v1523
    v1528 = spiral_wrap(v1513 + v1525, 64, True)
    del v1513, v1525
    v1529 = spiral_wrap(v1503 + v1526, 64, True)
    del v1503, v1526, v1529
    v1530 = spiral_wrap(v1507 + v1527, 64, True)
    del v1507, v1527, v1530
    v1531 = spiral_wrap(v1509 + v1528, 64, True)
    del v1509, v1528
    v1532 = 0 + 1
    v1533 = v1532 + 1
    del v1532
    v1534 = v1533 + 1
    del v1533
    v1535 = v1534 + 1
    del v1534
    v1536 = 0 + 1
    v1537 = v1536 + 1
    del v1536
    v1538 = v1537 + 1
    del v1537
    v1539 = v1538 + 1
    del v1538
    v1540 = v1535 == v1539
    if v1540:
        v1541 = 0
    else:
        v1541 = 1
    del v1540
    v1542 = 0 + 1
    v1543 = 0 + 1
    v1544 = v1542 == v1543
    if v1544:
        v1545 = 0
    else:
        v1545 = 1
    del v1544
    v1546 = 0 + 1
    v1547 = v1546 + 1
    del v1546
    v1548 = v1547 + 1
    del v1547
    v1549 = v1548 + 1
    del v1548
    v1550 = v1549 + 1
    del v1549
    v1551 = 0 + 1
    v1552 = v1551 + 1
    del v1551
    v1553 = v1552 + 1
    del v1552
    v1554 = v1553 + 1
    del v1553
    v1555 = v1554 + 1
    del v1554
    v1556 = v1550 == v1555
    if v1556:
        v1557 = 0
    else:
        v1557 = 1
    del v1556
    v1558 = spiral_wrap(v1542 + v1550, 64, True)
    del v1542, v1550
    v1559 = spiral_wrap(v1543 + v1555, 64, True)
    del v1543, v1555
    v1560 = spiral_wrap(v1545 + v1557, 64, True)
    del v1545, v1557
    v1561 = spiral_wrap(v1535 + v1558, 64, True)
    del v1535, v1558, v1561
    v1562 = spiral_wrap(v1539 + v1559, 64, True)
    del v1539, v1559, v1562
    v1563 = spiral_wrap(v1541 + v1560, 64, True)
    del v1541, v1560
    v1564 = 0 + 1
    v1565 = v1564 + 1
    del v1564
    v1566 = v1565 + 1
    del v1565
    v1567 = v1566 + 1
    del v1566
    v1568 = 0 + 1
    v1569 = v1568 + 1
    del v1568
    v1570 = v1569 + 1
    del v1569
    v1571 = v1570 + 1
    del v1570
    v1572 = v1567 == v1571
    if v1572:
        v1573 = 0
    else:
        v1573 = 1
    del v1572
    v1574 = 0 + 1
    v1575 = 0 + 1
    v1576 = v1574 == v1575
    if v1576:
        v1577 = 0
    else:
        v1577 = 1
    del v1576
    v1578 = 0 + 1
    v1579 = v1578 + 1
    del v1578
    v1580 = v1579 + 1
    del v1579
    v1581 = v1580 + 1
    del v1580
    v1582 = v1581 + 1
    del v1581
    v1583 = 0 + 1
    v1584 = v1583 + 1
    del v1583
    v1585 = v1584 + 1
    del v1584
    v1586 = v1585 + 1
    del v1585
    v1587 = v1586 + 1
    del v1586
    v1588 = v1582 == v1587
    if v1588:
        v1589 = 0
    else:
        v1589 = 1
    del v1588
    v1590 = spiral_wrap(v1574 + v1582, 64, True)
    del v1574, v1582
    v1591 = spiral_wrap(v1575 + v1587, 64, True)
    del v1575, v1587
    v1592 = spiral_wrap(v1577 + v1589, 64, True)
    del v1577, v1589
    v1593 = spiral_wrap(v1567 + v1590, 64, True)
    del v1567, v1590, v1593
    v1594 = spiral_wrap(v1571 + v1591, 64, True)
    del v1571, v1591, v1594
    v1595 = spiral_wrap(v1573 + v1592, 64, True)
    del v1573, v1592
    v1596 = 0 + 1
    v1597 = v1596 + 1
    del v1596
    v1598 = v1597 + 1
    del v1597
    v1599 = v1598 + 1
    del v1598
    v1600 = 0 + 1
    v1601 = v1600 + 1
    del v1600
    v1602 = v1601 + 1
    del v1601
    v1603 = v1602 + 1
    del v1602
    v1604 = v1599 == v1603
    if v1604:
        v1605 = 0
    else:
        v1605 = 1
    del v1604
    v1606 = 0 + 1
    v1607 = 0 + 1
    v1608 = v1606 == v1607
    if v1608:
        v1609 = 0
    else:
        v1609 = 1
    del v1608
    v1610 = 0 + 1
    v1611 = v1610 + 1
    del v1610
    v1612 = v1611 + 1
    del v1611
    v1613 = v1612 + 1
    del v1612
    v1614 = v1613 + 1
    del v1613
    v1615 = 0 + 1
    v1616 = v1615 + 1
    del v1615
    v1617 = v1616 + 1
    del v1616
    v1618 = v1617 + 1
    del v1617
    v1619 = v1618 + 1
    del v1618
    v1620 = v1614 == v1619
    if v1620:
        v1621 = 0
    else:
        v1621 = 1
    del v1620
    v1622 = spiral_wrap(v1606 + v1614, 64, True)
    del v1606, v1614
    v1623 = spiral_wrap(v1607 + v1619, 64, True)
    del v1607, v1619
    v1624 = spiral_wrap(v1609 + v1621, 64, True)
    del v1609, v1621
    v1625 = spiral_wrap(v1599 + v1622, 64, True)
    del v1599, v1622, v1625
    v1626 = spiral_wrap(v1603 + v1623, 64, True)
    del v1603, v1623, v1626
    v1627 = spiral_wrap(v1605 + v1624, 64, True)
    del v1605, v1624
    v1628 = 0 + 1
    v1629 = v1628 + 1
    del v1628
    v1630 = v1629 + 1
    del v1629
    v1631 = v1630 + 1
    del v1630
    v1632 = 0 + 1
    v1633 = v1632 + 1
    del v1632
    v1634 = v1633 + 1
    del v1633
    v1635 = v1634 + 1
    del v1634
    v1636 = v1631 == v1635
    if v1636:
        v1637 = 0
    else:
        v1637 = 1
    del v1636
    v1638 = 0 + 1
    v1639 = 0 + 1
    v1640 = v1638 == v1639
    if v1640:
        v1641 = 0
    else:
        v1641 = 1
    del v1640
    v1642 = 0 + 1
    v1643 = v1642 + 1
    del v1642
    v1644 = v1643 + 1
    del v1643
    v1645 = v1644 + 1
    del v1644
    v1646 = v1645 + 1
    del v1645
    v1647 = 0 + 1
    v1648 = v1647 + 1
    del v1647
    v1649 = v1648 + 1
    del v1648
    v1650 = v1649 + 1
    del v1649
    v1651 = v1650 + 1
    del v1650
    v1652 = v1646 == v1651
    if v1652:
        v1653 = 0
    else:
        v1653 = 1
    del v1652
    v1654 = spiral_wrap(v1638 + v1646, 64, True)
    del v1638, v1646
    v1655 = spiral_wrap(v1639 + v1651, 64, True)
    del v1639, v1651
    v1656 = spiral_wrap(v1641 + v1653, 64, True)
    del v1641, v1653
    v1657 = spiral_wrap(v1631 + v1654, 64, True)
    del v1631, v1654, v1657
    v1658 = spiral_wrap(v1635 + v1655, 64, True)
    del v1635, v1655, v1658
    v1659 = spiral_wrap(v1637 + v1656, 64, True)
    del v1637, v1656
    v1660 = spiral_wrap(v1627 + v1659, 64, True)
    del v1627, v1659
    v1661 = spiral_wrap(v1595 + v1660, 64, True)
    del v1595, v1660
    v1662 = spiral_wrap(v1563 + v1661, 64, True)
    del v1563, v1661
    v1663 = spiral_wrap(v1531 + v1662, 64, True)
    del v1531, v1662
    v1664 = spiral_wrap(v1499 + v1663, 64, True)
    del v1499, v1663
    v1665 = v1467 == 0
    v1666 = v1664 == v1467
    del v1467, v1664
    v1667 = v1665 and v1666
    del v1665, v1666
    if v1667:
        pass
    else:
        raise Exception("typed-FX-statement-stale-writer-conflict-program-append-associativity-runtime-mismatch")
    del v1667
    v1668 = 0 + 1
    v1669 = v1668 + 1
    del v1668
    v1670 = v1669 + 1
    del v1669
    v1671 = v1670 + 1
    del v1670
    v1672 = 0 + 1
    v1673 = v1672 + 1
    del v1672
    v1674 = v1673 + 1
    del v1673
    v1675 = v1674 + 1
    del v1674
    v1676 = v1671 == v1675
    if v1676:
        v1677 = 0
    else:
        v1677 = 1
    del v1676
    v1678 = 0 + 1
    v1679 = 0 + 1
    v1680 = v1678 == v1679
    if v1680:
        v1681 = 0
    else:
        v1681 = 1
    del v1680
    v1682 = 0 + 1
    v1683 = v1682 + 1
    del v1682
    v1684 = v1683 + 1
    del v1683
    v1685 = v1684 + 1
    del v1684
    v1686 = v1685 + 1
    del v1685
    v1687 = 0 + 1
    v1688 = v1687 + 1
    del v1687
    v1689 = v1688 + 1
    del v1688
    v1690 = v1689 + 1
    del v1689
    v1691 = v1690 + 1
    del v1690
    v1692 = v1686 == v1691
    if v1692:
        v1693 = 0
    else:
        v1693 = 1
    del v1692
    v1694 = spiral_wrap(v1678 + v1686, 64, True)
    del v1678, v1686
    v1695 = spiral_wrap(v1679 + v1691, 64, True)
    del v1679, v1691
    v1696 = spiral_wrap(v1681 + v1693, 64, True)
    del v1681, v1693
    v1697 = spiral_wrap(v1671 + v1694, 64, True)
    del v1671, v1694, v1697
    v1698 = spiral_wrap(v1675 + v1695, 64, True)
    del v1675, v1695, v1698
    v1699 = spiral_wrap(v1677 + v1696, 64, True)
    del v1677, v1696
    v1700 = 0 + 1
    v1701 = v1700 + 1
    del v1700
    v1702 = v1701 + 1
    del v1701
    v1703 = v1702 + 1
    del v1702
    v1704 = 0 + 1
    v1705 = v1704 + 1
    del v1704
    v1706 = v1705 + 1
    del v1705
    v1707 = v1706 + 1
    del v1706
    v1708 = v1703 == v1707
    if v1708:
        v1709 = 0
    else:
        v1709 = 1
    del v1708
    v1710 = 0 + 1
    v1711 = 0 + 1
    v1712 = v1710 == v1711
    if v1712:
        v1713 = 0
    else:
        v1713 = 1
    del v1712
    v1714 = 0 + 1
    v1715 = v1714 + 1
    del v1714
    v1716 = v1715 + 1
    del v1715
    v1717 = v1716 + 1
    del v1716
    v1718 = v1717 + 1
    del v1717
    v1719 = 0 + 1
    v1720 = v1719 + 1
    del v1719
    v1721 = v1720 + 1
    del v1720
    v1722 = v1721 + 1
    del v1721
    v1723 = v1722 + 1
    del v1722
    v1724 = v1718 == v1723
    if v1724:
        v1725 = 0
    else:
        v1725 = 1
    del v1724
    v1726 = spiral_wrap(v1710 + v1718, 64, True)
    del v1710, v1718
    v1727 = spiral_wrap(v1711 + v1723, 64, True)
    del v1711, v1723
    v1728 = spiral_wrap(v1713 + v1725, 64, True)
    del v1713, v1725
    v1729 = spiral_wrap(v1703 + v1726, 64, True)
    del v1703, v1726, v1729
    v1730 = spiral_wrap(v1707 + v1727, 64, True)
    del v1707, v1727, v1730
    v1731 = spiral_wrap(v1709 + v1728, 64, True)
    del v1709, v1728
    v1732 = spiral_wrap(v1699 + v1731, 64, True)
    del v1699, v1731
    v1733 = 0 + 1
    v1734 = v1733 + 1
    del v1733
    v1735 = v1734 + 1
    del v1734
    v1736 = v1735 + 1
    del v1735
    v1737 = 0 + 1
    v1738 = v1737 + 1
    del v1737
    v1739 = v1738 + 1
    del v1738
    v1740 = v1739 + 1
    del v1739
    v1741 = v1736 == v1740
    if v1741:
        v1742 = 0
    else:
        v1742 = 1
    del v1741
    v1743 = 0 + 1
    v1744 = 0 + 1
    v1745 = v1743 == v1744
    if v1745:
        v1746 = 0
    else:
        v1746 = 1
    del v1745
    v1747 = 0 + 1
    v1748 = v1747 + 1
    del v1747
    v1749 = v1748 + 1
    del v1748
    v1750 = v1749 + 1
    del v1749
    v1751 = v1750 + 1
    del v1750
    v1752 = 0 + 1
    v1753 = v1752 + 1
    del v1752
    v1754 = v1753 + 1
    del v1753
    v1755 = v1754 + 1
    del v1754
    v1756 = v1755 + 1
    del v1755
    v1757 = v1751 == v1756
    if v1757:
        v1758 = 0
    else:
        v1758 = 1
    del v1757
    v1759 = spiral_wrap(v1743 + v1751, 64, True)
    del v1743, v1751
    v1760 = spiral_wrap(v1744 + v1756, 64, True)
    del v1744, v1756
    v1761 = spiral_wrap(v1746 + v1758, 64, True)
    del v1746, v1758
    v1762 = spiral_wrap(v1736 + v1759, 64, True)
    del v1736, v1759, v1762
    v1763 = spiral_wrap(v1740 + v1760, 64, True)
    del v1740, v1760, v1763
    v1764 = spiral_wrap(v1742 + v1761, 64, True)
    del v1742, v1761
    v1765 = 0 + 1
    v1766 = v1765 + 1
    del v1765
    v1767 = v1766 + 1
    del v1766
    v1768 = v1767 + 1
    del v1767
    v1769 = 0 + 1
    v1770 = v1769 + 1
    del v1769
    v1771 = v1770 + 1
    del v1770
    v1772 = v1771 + 1
    del v1771
    v1773 = v1768 == v1772
    if v1773:
        v1774 = 0
    else:
        v1774 = 1
    del v1773
    v1775 = 0 + 1
    v1776 = 0 + 1
    v1777 = v1775 == v1776
    if v1777:
        v1778 = 0
    else:
        v1778 = 1
    del v1777
    v1779 = 0 + 1
    v1780 = v1779 + 1
    del v1779
    v1781 = v1780 + 1
    del v1780
    v1782 = v1781 + 1
    del v1781
    v1783 = v1782 + 1
    del v1782
    v1784 = 0 + 1
    v1785 = v1784 + 1
    del v1784
    v1786 = v1785 + 1
    del v1785
    v1787 = v1786 + 1
    del v1786
    v1788 = v1787 + 1
    del v1787
    v1789 = v1783 == v1788
    if v1789:
        v1790 = 0
    else:
        v1790 = 1
    del v1789
    v1791 = spiral_wrap(v1775 + v1783, 64, True)
    del v1775, v1783
    v1792 = spiral_wrap(v1776 + v1788, 64, True)
    del v1776, v1788
    v1793 = spiral_wrap(v1778 + v1790, 64, True)
    del v1778, v1790
    v1794 = spiral_wrap(v1768 + v1791, 64, True)
    del v1768, v1791, v1794
    v1795 = spiral_wrap(v1772 + v1792, 64, True)
    del v1772, v1792, v1795
    v1796 = spiral_wrap(v1774 + v1793, 64, True)
    del v1774, v1793
    v1797 = 0 + 1
    v1798 = v1797 + 1
    del v1797
    v1799 = v1798 + 1
    del v1798
    v1800 = v1799 + 1
    del v1799
    v1801 = 0 + 1
    v1802 = v1801 + 1
    del v1801
    v1803 = v1802 + 1
    del v1802
    v1804 = v1803 + 1
    del v1803
    v1805 = v1800 == v1804
    if v1805:
        v1806 = 0
    else:
        v1806 = 1
    del v1805
    v1807 = 0 + 1
    v1808 = 0 + 1
    v1809 = v1807 == v1808
    if v1809:
        v1810 = 0
    else:
        v1810 = 1
    del v1809
    v1811 = 0 + 1
    v1812 = v1811 + 1
    del v1811
    v1813 = v1812 + 1
    del v1812
    v1814 = v1813 + 1
    del v1813
    v1815 = v1814 + 1
    del v1814
    v1816 = 0 + 1
    v1817 = v1816 + 1
    del v1816
    v1818 = v1817 + 1
    del v1817
    v1819 = v1818 + 1
    del v1818
    v1820 = v1819 + 1
    del v1819
    v1821 = v1815 == v1820
    if v1821:
        v1822 = 0
    else:
        v1822 = 1
    del v1821
    v1823 = spiral_wrap(v1807 + v1815, 64, True)
    del v1807, v1815
    v1824 = spiral_wrap(v1808 + v1820, 64, True)
    del v1808, v1820
    v1825 = spiral_wrap(v1810 + v1822, 64, True)
    del v1810, v1822
    v1826 = spiral_wrap(v1800 + v1823, 64, True)
    del v1800, v1823, v1826
    v1827 = spiral_wrap(v1804 + v1824, 64, True)
    del v1804, v1824, v1827
    v1828 = spiral_wrap(v1806 + v1825, 64, True)
    del v1806, v1825
    v1829 = 0 + 1
    v1830 = v1829 + 1
    del v1829
    v1831 = v1830 + 1
    del v1830
    v1832 = v1831 + 1
    del v1831
    v1833 = 0 + 1
    v1834 = v1833 + 1
    del v1833
    v1835 = v1834 + 1
    del v1834
    v1836 = v1835 + 1
    del v1835
    v1837 = v1832 == v1836
    if v1837:
        v1838 = 0
    else:
        v1838 = 1
    del v1837
    v1839 = 0 + 1
    v1840 = 0 + 1
    v1841 = v1839 == v1840
    if v1841:
        v1842 = 0
    else:
        v1842 = 1
    del v1841
    v1843 = 0 + 1
    v1844 = v1843 + 1
    del v1843
    v1845 = v1844 + 1
    del v1844
    v1846 = v1845 + 1
    del v1845
    v1847 = v1846 + 1
    del v1846
    v1848 = 0 + 1
    v1849 = v1848 + 1
    del v1848
    v1850 = v1849 + 1
    del v1849
    v1851 = v1850 + 1
    del v1850
    v1852 = v1851 + 1
    del v1851
    v1853 = v1847 == v1852
    if v1853:
        v1854 = 0
    else:
        v1854 = 1
    del v1853
    v1855 = spiral_wrap(v1839 + v1847, 64, True)
    del v1839, v1847
    v1856 = spiral_wrap(v1840 + v1852, 64, True)
    del v1840, v1852
    v1857 = spiral_wrap(v1842 + v1854, 64, True)
    del v1842, v1854
    v1858 = spiral_wrap(v1832 + v1855, 64, True)
    del v1832, v1855, v1858
    v1859 = spiral_wrap(v1836 + v1856, 64, True)
    del v1836, v1856, v1859
    v1860 = spiral_wrap(v1838 + v1857, 64, True)
    del v1838, v1857
    v1861 = spiral_wrap(v1828 + v1860, 64, True)
    del v1828, v1860
    v1862 = spiral_wrap(v1796 + v1861, 64, True)
    del v1796, v1861
    v1863 = spiral_wrap(v1764 + v1862, 64, True)
    del v1764, v1862
    v1864 = spiral_wrap(v1732 + v1863, 64, True)
    del v1732, v1863
    v1865 = 0 + 1
    v1866 = v1865 + 1
    del v1865
    v1867 = v1866 + 1
    del v1866
    v1868 = v1867 + 1
    del v1867
    v1869 = 0 + 1
    v1870 = v1869 + 1
    del v1869
    v1871 = v1870 + 1
    del v1870
    v1872 = v1871 + 1
    del v1871
    v1873 = v1868 == v1872
    if v1873:
        v1874 = 0
    else:
        v1874 = 1
    del v1873
    v1875 = 0 + 1
    v1876 = 0 + 1
    v1877 = v1875 == v1876
    if v1877:
        v1878 = 0
    else:
        v1878 = 1
    del v1877
    v1879 = 0 + 1
    v1880 = v1879 + 1
    del v1879
    v1881 = v1880 + 1
    del v1880
    v1882 = v1881 + 1
    del v1881
    v1883 = v1882 + 1
    del v1882
    v1884 = 0 + 1
    v1885 = v1884 + 1
    del v1884
    v1886 = v1885 + 1
    del v1885
    v1887 = v1886 + 1
    del v1886
    v1888 = v1887 + 1
    del v1887
    v1889 = v1883 == v1888
    if v1889:
        v1890 = 0
    else:
        v1890 = 1
    del v1889
    v1891 = spiral_wrap(v1875 + v1883, 64, True)
    del v1875, v1883
    v1892 = spiral_wrap(v1876 + v1888, 64, True)
    del v1876, v1888
    v1893 = spiral_wrap(v1878 + v1890, 64, True)
    del v1878, v1890
    v1894 = spiral_wrap(v1868 + v1891, 64, True)
    del v1868, v1891
    v1895 = spiral_wrap(v1872 + v1892, 64, True)
    del v1872, v1892
    v1896 = spiral_wrap(v1874 + v1893, 64, True)
    del v1874, v1893
    v1897 = spiral_wrap(v1895 + v1896, 64, True)
    del v1895, v1896
    v1898 = spiral_wrap(v1894 + v1897, 64, True)
    del v1894, v1897
    v1899 = spiral_wrap(3 + v1898, 64, True)
    del v1898
    v1900 = 0 + 1
    v1901 = v1900 + 1
    del v1900
    v1902 = v1901 + 1
    del v1901
    v1903 = v1902 + 1
    del v1902
    v1904 = 0 + 1
    v1905 = v1904 + 1
    del v1904
    v1906 = v1905 + 1
    del v1905
    v1907 = v1906 + 1
    del v1906
    v1908 = v1903 == v1907
    if v1908:
        v1909 = 0
    else:
        v1909 = 1
    del v1908
    v1910 = 0 + 1
    v1911 = 0 + 1
    v1912 = v1910 == v1911
    if v1912:
        v1913 = 0
    else:
        v1913 = 1
    del v1912
    v1914 = 0 + 1
    v1915 = v1914 + 1
    del v1914
    v1916 = v1915 + 1
    del v1915
    v1917 = v1916 + 1
    del v1916
    v1918 = v1917 + 1
    del v1917
    v1919 = 0 + 1
    v1920 = v1919 + 1
    del v1919
    v1921 = v1920 + 1
    del v1920
    v1922 = v1921 + 1
    del v1921
    v1923 = v1922 + 1
    del v1922
    v1924 = v1918 == v1923
    if v1924:
        v1925 = 0
    else:
        v1925 = 1
    del v1924
    v1926 = spiral_wrap(v1910 + v1918, 64, True)
    del v1910, v1918
    v1927 = spiral_wrap(v1911 + v1923, 64, True)
    del v1911, v1923
    v1928 = spiral_wrap(v1913 + v1925, 64, True)
    del v1913, v1925
    v1929 = spiral_wrap(v1903 + v1926, 64, True)
    del v1903, v1926
    v1930 = spiral_wrap(v1907 + v1927, 64, True)
    del v1907, v1927
    v1931 = spiral_wrap(v1909 + v1928, 64, True)
    del v1909, v1928
    v1932 = spiral_wrap(v1930 + v1931, 64, True)
    del v1930, v1931
    v1933 = spiral_wrap(v1929 + v1932, 64, True)
    del v1929, v1932
    v1934 = spiral_wrap(3 + v1933, 64, True)
    del v1933
    v1935 = v1899 == v1934
    if v1935:
        v1936 = 0 + 1
        v1937 = v1936 + 1
        del v1936
        v1938 = v1937 + 1
        del v1937
        v1939 = v1938 + 1
        del v1938
        v1940 = 0 + 1
        v1941 = v1940 + 1
        del v1940
        v1942 = v1941 + 1
        del v1941
        v1943 = v1942 + 1
        del v1942
        v1944 = v1939 == v1943
        if v1944:
            v1945 = 0
        else:
            v1945 = 1
        del v1944
        v1946 = 0 + 1
        v1947 = 0 + 1
        v1948 = v1946 == v1947
        if v1948:
            v1949 = 0
        else:
            v1949 = 1
        del v1948
        v1950 = 0 + 1
        v1951 = v1950 + 1
        del v1950
        v1952 = v1951 + 1
        del v1951
        v1953 = v1952 + 1
        del v1952
        v1954 = v1953 + 1
        del v1953
        v1955 = 0 + 1
        v1956 = v1955 + 1
        del v1955
        v1957 = v1956 + 1
        del v1956
        v1958 = v1957 + 1
        del v1957
        v1959 = v1958 + 1
        del v1958
        v1960 = v1954 == v1959
        if v1960:
            v1961 = 0
        else:
            v1961 = 1
        del v1960
        v1962 = spiral_wrap(v1946 + v1954, 64, True)
        del v1946, v1954
        v1963 = spiral_wrap(v1947 + v1959, 64, True)
        del v1947, v1959
        v1964 = spiral_wrap(v1949 + v1961, 64, True)
        del v1949, v1961
        v1965 = spiral_wrap(v1939 + v1962, 64, True)
        del v1939, v1962
        v1966 = spiral_wrap(v1943 + v1963, 64, True)
        del v1943, v1963
        v1967 = spiral_wrap(v1945 + v1964, 64, True)
        del v1945, v1964
        v1968 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v1972 = US0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v1965, v1966, v1967, v1968)
    else:
        v1970 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v1972 = US0_TypedFxHashedStatementChecksumValidationRejected(v1899, v1934, v1970)
    del v1899, v1934, v1935
    match v1972:
        case US0_TypedFxHashedStatementChecksumValidationAccepted(v1976, v1977, v1978, v1979, v1980, _): # TypedFxHashedStatementChecksumValidationAccepted
            v1991, v1992, v1993, v1994, v1995, v1996, v1997, v1998, v1999 = 1, 0, 0, 0, v1976, v1977, v1978, v1979, v1980
        case US0_TypedFxHashedStatementChecksumValidationRejected(v1973, v1974, _): # TypedFxHashedStatementChecksumValidationRejected
            v1991, v1992, v1993, v1994, v1995, v1996, v1997, v1998, v1999 = 0, 1, v1973, v1974, 0, 0, 0, 0, 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1972, v1993, v1994, v1996, v1997, v1998
    v2000 = 0 + 1
    v2001 = v2000 + 1
    del v2000
    v2002 = v2001 + 1
    del v2001
    v2003 = v2002 + 1
    del v2002
    v2004 = 0 + 1
    v2005 = v2004 + 1
    del v2004
    v2006 = v2005 + 1
    del v2005
    v2007 = v2006 + 1
    del v2006
    v2008 = v2003 == v2007
    if v2008:
        v2009 = 0
    else:
        v2009 = 1
    del v2008
    v2010 = 0 + 1
    v2011 = 0 + 1
    v2012 = v2010 == v2011
    if v2012:
        v2013 = 0
    else:
        v2013 = 1
    del v2012
    v2014 = 0 + 1
    v2015 = v2014 + 1
    del v2014
    v2016 = v2015 + 1
    del v2015
    v2017 = v2016 + 1
    del v2016
    v2018 = v2017 + 1
    del v2017
    v2019 = 0 + 1
    v2020 = v2019 + 1
    del v2019
    v2021 = v2020 + 1
    del v2020
    v2022 = v2021 + 1
    del v2021
    v2023 = v2022 + 1
    del v2022
    v2024 = v2018 == v2023
    if v2024:
        v2025 = 0
    else:
        v2025 = 1
    del v2024
    v2026 = spiral_wrap(v2010 + v2018, 64, True)
    del v2010, v2018
    v2027 = spiral_wrap(v2011 + v2023, 64, True)
    del v2011, v2023
    v2028 = spiral_wrap(v2013 + v2025, 64, True)
    del v2013, v2025
    v2029 = spiral_wrap(v2003 + v2026, 64, True)
    del v2003, v2026, v2029
    v2030 = spiral_wrap(v2007 + v2027, 64, True)
    del v2007, v2027, v2030
    v2031 = spiral_wrap(v2009 + v2028, 64, True)
    del v2009, v2028
    v2032 = 0 + 1
    v2033 = v2032 + 1
    del v2032
    v2034 = v2033 + 1
    del v2033
    v2035 = v2034 + 1
    del v2034
    v2036 = 0 + 1
    v2037 = v2036 + 1
    del v2036
    v2038 = v2037 + 1
    del v2037
    v2039 = v2038 + 1
    del v2038
    v2040 = v2035 == v2039
    if v2040:
        v2041 = 0
    else:
        v2041 = 1
    del v2040
    v2042 = 0 + 1
    v2043 = 0 + 1
    v2044 = v2042 == v2043
    if v2044:
        v2045 = 0
    else:
        v2045 = 1
    del v2044
    v2046 = 0 + 1
    v2047 = v2046 + 1
    del v2046
    v2048 = v2047 + 1
    del v2047
    v2049 = v2048 + 1
    del v2048
    v2050 = v2049 + 1
    del v2049
    v2051 = 0 + 1
    v2052 = v2051 + 1
    del v2051
    v2053 = v2052 + 1
    del v2052
    v2054 = v2053 + 1
    del v2053
    v2055 = v2054 + 1
    del v2054
    v2056 = v2050 == v2055
    if v2056:
        v2057 = 0
    else:
        v2057 = 1
    del v2056
    v2058 = spiral_wrap(v2042 + v2050, 64, True)
    del v2042, v2050
    v2059 = spiral_wrap(v2043 + v2055, 64, True)
    del v2043, v2055
    v2060 = spiral_wrap(v2045 + v2057, 64, True)
    del v2045, v2057
    v2061 = spiral_wrap(v2035 + v2058, 64, True)
    del v2035, v2058, v2061
    v2062 = spiral_wrap(v2039 + v2059, 64, True)
    del v2039, v2059, v2062
    v2063 = spiral_wrap(v2041 + v2060, 64, True)
    del v2041, v2060
    v2064 = 0 + 1
    v2065 = v2064 + 1
    del v2064
    v2066 = v2065 + 1
    del v2065
    v2067 = v2066 + 1
    del v2066
    v2068 = 0 + 1
    v2069 = v2068 + 1
    del v2068
    v2070 = v2069 + 1
    del v2069
    v2071 = v2070 + 1
    del v2070
    v2072 = v2067 == v2071
    if v2072:
        v2073 = 0
    else:
        v2073 = 1
    del v2072
    v2074 = 0 + 1
    v2075 = 0 + 1
    v2076 = v2074 == v2075
    if v2076:
        v2077 = 0
    else:
        v2077 = 1
    del v2076
    v2078 = 0 + 1
    v2079 = v2078 + 1
    del v2078
    v2080 = v2079 + 1
    del v2079
    v2081 = v2080 + 1
    del v2080
    v2082 = v2081 + 1
    del v2081
    v2083 = 0 + 1
    v2084 = v2083 + 1
    del v2083
    v2085 = v2084 + 1
    del v2084
    v2086 = v2085 + 1
    del v2085
    v2087 = v2086 + 1
    del v2086
    v2088 = v2082 == v2087
    if v2088:
        v2089 = 0
    else:
        v2089 = 1
    del v2088
    v2090 = spiral_wrap(v2074 + v2082, 64, True)
    del v2074, v2082
    v2091 = spiral_wrap(v2075 + v2087, 64, True)
    del v2075, v2087
    v2092 = spiral_wrap(v2077 + v2089, 64, True)
    del v2077, v2089
    v2093 = spiral_wrap(v2067 + v2090, 64, True)
    del v2067, v2090, v2093
    v2094 = spiral_wrap(v2071 + v2091, 64, True)
    del v2071, v2091, v2094
    v2095 = spiral_wrap(v2073 + v2092, 64, True)
    del v2073, v2092
    v2096 = 0 + 1
    v2097 = v2096 + 1
    del v2096
    v2098 = v2097 + 1
    del v2097
    v2099 = v2098 + 1
    del v2098
    v2100 = 0 + 1
    v2101 = v2100 + 1
    del v2100
    v2102 = v2101 + 1
    del v2101
    v2103 = v2102 + 1
    del v2102
    v2104 = v2099 == v2103
    if v2104:
        v2105 = 0
    else:
        v2105 = 1
    del v2104
    v2106 = 0 + 1
    v2107 = 0 + 1
    v2108 = v2106 == v2107
    if v2108:
        v2109 = 0
    else:
        v2109 = 1
    del v2108
    v2110 = 0 + 1
    v2111 = v2110 + 1
    del v2110
    v2112 = v2111 + 1
    del v2111
    v2113 = v2112 + 1
    del v2112
    v2114 = v2113 + 1
    del v2113
    v2115 = 0 + 1
    v2116 = v2115 + 1
    del v2115
    v2117 = v2116 + 1
    del v2116
    v2118 = v2117 + 1
    del v2117
    v2119 = v2118 + 1
    del v2118
    v2120 = v2114 == v2119
    if v2120:
        v2121 = 0
    else:
        v2121 = 1
    del v2120
    v2122 = spiral_wrap(v2106 + v2114, 64, True)
    del v2106, v2114
    v2123 = spiral_wrap(v2107 + v2119, 64, True)
    del v2107, v2119
    v2124 = spiral_wrap(v2109 + v2121, 64, True)
    del v2109, v2121
    v2125 = spiral_wrap(v2099 + v2122, 64, True)
    del v2099, v2122, v2125
    v2126 = spiral_wrap(v2103 + v2123, 64, True)
    del v2103, v2123, v2126
    v2127 = spiral_wrap(v2105 + v2124, 64, True)
    del v2105, v2124
    v2128 = spiral_wrap(v2095 + v2127, 64, True)
    del v2095, v2127
    v2129 = spiral_wrap(v2063 + v2128, 64, True)
    del v2063, v2128
    v2130 = spiral_wrap(v2031 + v2129, 64, True)
    del v2031, v2129
    v2131 = spiral_wrap(v1999 + v1992, 64, True)
    del v1992, v1999
    v2132 = spiral_wrap(v2130 + v2131, 64, True)
    del v2130, v2131
    v2133 = spiral_wrap(v1864 + v2132, 64, True)
    del v1864, v2132
    v2134 = v1995 == 1
    del v1995
    v2135 = v1991 == 1
    del v1991
    v2136 = v2133 == 0
    del v2133
    v2137 = v2134 and v2135
    del v2134, v2135
    v2138 = v2137 and v2136
    del v2136, v2137
    if v2138:
        pass
    else:
        raise Exception("typed-FX-statement-recursive-writer-appended-tail-restart-runtime-mismatch")
    del v2138
    v2139 = 0 + 1
    v2140 = v2139 + 1
    del v2139
    v2141 = v2140 + 1
    del v2140
    v2142 = v2141 + 1
    del v2141
    v2143 = 0 + 1
    v2144 = v2143 + 1
    del v2143
    v2145 = v2144 + 1
    del v2144
    v2146 = v2145 + 1
    del v2145
    v2147 = v2142 == v2146
    if v2147:
        v2148 = 0
    else:
        v2148 = 1
    del v2147
    v2149 = 0 + 1
    v2150 = 0 + 1
    v2151 = v2149 == v2150
    if v2151:
        v2152 = 0
    else:
        v2152 = 1
    del v2151
    v2153 = 0 + 1
    v2154 = v2153 + 1
    del v2153
    v2155 = v2154 + 1
    del v2154
    v2156 = v2155 + 1
    del v2155
    v2157 = v2156 + 1
    del v2156
    v2158 = 0 + 1
    v2159 = v2158 + 1
    del v2158
    v2160 = v2159 + 1
    del v2159
    v2161 = v2160 + 1
    del v2160
    v2162 = v2161 + 1
    del v2161
    v2163 = v2157 == v2162
    if v2163:
        v2164 = 0
    else:
        v2164 = 1
    del v2163
    v2165 = spiral_wrap(v2149 + v2157, 64, True)
    del v2149, v2157
    v2166 = spiral_wrap(v2150 + v2162, 64, True)
    del v2150, v2162
    v2167 = spiral_wrap(v2152 + v2164, 64, True)
    del v2152, v2164
    v2168 = spiral_wrap(v2142 + v2165, 64, True)
    del v2142, v2165, v2168
    v2169 = spiral_wrap(v2146 + v2166, 64, True)
    del v2146, v2166, v2169
    v2170 = spiral_wrap(v2148 + v2167, 64, True)
    del v2148, v2167
    v2171 = 0 + 1
    v2172 = v2171 + 1
    del v2171
    v2173 = v2172 + 1
    del v2172
    v2174 = v2173 + 1
    del v2173
    v2175 = 0 + 1
    v2176 = v2175 + 1
    del v2175
    v2177 = v2176 + 1
    del v2176
    v2178 = v2177 + 1
    del v2177
    v2179 = v2174 == v2178
    if v2179:
        v2180 = 0
    else:
        v2180 = 1
    del v2179
    v2181 = 0 + 1
    v2182 = 0 + 1
    v2183 = v2181 == v2182
    if v2183:
        v2184 = 0
    else:
        v2184 = 1
    del v2183
    v2185 = 0 + 1
    v2186 = v2185 + 1
    del v2185
    v2187 = v2186 + 1
    del v2186
    v2188 = v2187 + 1
    del v2187
    v2189 = v2188 + 1
    del v2188
    v2190 = 0 + 1
    v2191 = v2190 + 1
    del v2190
    v2192 = v2191 + 1
    del v2191
    v2193 = v2192 + 1
    del v2192
    v2194 = v2193 + 1
    del v2193
    v2195 = v2189 == v2194
    if v2195:
        v2196 = 0
    else:
        v2196 = 1
    del v2195
    v2197 = spiral_wrap(v2181 + v2189, 64, True)
    del v2181, v2189
    v2198 = spiral_wrap(v2182 + v2194, 64, True)
    del v2182, v2194
    v2199 = spiral_wrap(v2184 + v2196, 64, True)
    del v2184, v2196
    v2200 = spiral_wrap(v2174 + v2197, 64, True)
    del v2174, v2197, v2200
    v2201 = spiral_wrap(v2178 + v2198, 64, True)
    del v2178, v2198, v2201
    v2202 = spiral_wrap(v2180 + v2199, 64, True)
    del v2180, v2199
    v2203 = spiral_wrap(v2170 + v2202, 64, True)
    del v2170, v2202
    v2204 = 0 + 1
    v2205 = v2204 + 1
    del v2204
    v2206 = v2205 + 1
    del v2205
    v2207 = v2206 + 1
    del v2206
    v2208 = 0 + 1
    v2209 = v2208 + 1
    del v2208
    v2210 = v2209 + 1
    del v2209
    v2211 = v2210 + 1
    del v2210
    v2212 = v2207 == v2211
    if v2212:
        v2213 = 0
    else:
        v2213 = 1
    del v2212
    v2214 = 0 + 1
    v2215 = 0 + 1
    v2216 = v2214 == v2215
    if v2216:
        v2217 = 0
    else:
        v2217 = 1
    del v2216
    v2218 = 0 + 1
    v2219 = v2218 + 1
    del v2218
    v2220 = v2219 + 1
    del v2219
    v2221 = v2220 + 1
    del v2220
    v2222 = v2221 + 1
    del v2221
    v2223 = 0 + 1
    v2224 = v2223 + 1
    del v2223
    v2225 = v2224 + 1
    del v2224
    v2226 = v2225 + 1
    del v2225
    v2227 = v2226 + 1
    del v2226
    v2228 = v2222 == v2227
    if v2228:
        v2229 = 0
    else:
        v2229 = 1
    del v2228
    v2230 = spiral_wrap(v2214 + v2222, 64, True)
    del v2214, v2222
    v2231 = spiral_wrap(v2215 + v2227, 64, True)
    del v2215, v2227
    v2232 = spiral_wrap(v2217 + v2229, 64, True)
    del v2217, v2229
    v2233 = spiral_wrap(v2207 + v2230, 64, True)
    del v2207, v2230, v2233
    v2234 = spiral_wrap(v2211 + v2231, 64, True)
    del v2211, v2231, v2234
    v2235 = spiral_wrap(v2213 + v2232, 64, True)
    del v2213, v2232
    v2236 = 0 + 1
    v2237 = v2236 + 1
    del v2236
    v2238 = v2237 + 1
    del v2237
    v2239 = v2238 + 1
    del v2238
    v2240 = 0 + 1
    v2241 = v2240 + 1
    del v2240
    v2242 = v2241 + 1
    del v2241
    v2243 = v2242 + 1
    del v2242
    v2244 = v2239 == v2243
    if v2244:
        v2245 = 0
    else:
        v2245 = 1
    del v2244
    v2246 = 0 + 1
    v2247 = 0 + 1
    v2248 = v2246 == v2247
    if v2248:
        v2249 = 0
    else:
        v2249 = 1
    del v2248
    v2250 = 0 + 1
    v2251 = v2250 + 1
    del v2250
    v2252 = v2251 + 1
    del v2251
    v2253 = v2252 + 1
    del v2252
    v2254 = v2253 + 1
    del v2253
    v2255 = 0 + 1
    v2256 = v2255 + 1
    del v2255
    v2257 = v2256 + 1
    del v2256
    v2258 = v2257 + 1
    del v2257
    v2259 = v2258 + 1
    del v2258
    v2260 = v2254 == v2259
    if v2260:
        v2261 = 0
    else:
        v2261 = 1
    del v2260
    v2262 = spiral_wrap(v2246 + v2254, 64, True)
    del v2246, v2254
    v2263 = spiral_wrap(v2247 + v2259, 64, True)
    del v2247, v2259
    v2264 = spiral_wrap(v2249 + v2261, 64, True)
    del v2249, v2261
    v2265 = spiral_wrap(v2239 + v2262, 64, True)
    del v2239, v2262, v2265
    v2266 = spiral_wrap(v2243 + v2263, 64, True)
    del v2243, v2263, v2266
    v2267 = spiral_wrap(v2245 + v2264, 64, True)
    del v2245, v2264
    v2268 = spiral_wrap(v2235 + v2267, 64, True)
    del v2235, v2267
    v2269 = spiral_wrap(v2203 + v2268, 64, True)
    del v2203, v2268
    v2270 = 0 + 1
    v2271 = v2270 + 1
    del v2270
    v2272 = v2271 + 1
    del v2271
    v2273 = v2272 + 1
    del v2272
    v2274 = 0 + 1
    v2275 = v2274 + 1
    del v2274
    v2276 = v2275 + 1
    del v2275
    v2277 = v2276 + 1
    del v2276
    v2278 = v2273 == v2277
    if v2278:
        v2279 = 0
    else:
        v2279 = 1
    del v2278
    v2280 = 0 + 1
    v2281 = 0 + 1
    v2282 = v2280 == v2281
    if v2282:
        v2283 = 0
    else:
        v2283 = 1
    del v2282
    v2284 = 0 + 1
    v2285 = v2284 + 1
    del v2284
    v2286 = v2285 + 1
    del v2285
    v2287 = v2286 + 1
    del v2286
    v2288 = v2287 + 1
    del v2287
    v2289 = 0 + 1
    v2290 = v2289 + 1
    del v2289
    v2291 = v2290 + 1
    del v2290
    v2292 = v2291 + 1
    del v2291
    v2293 = v2292 + 1
    del v2292
    v2294 = v2288 == v2293
    if v2294:
        v2295 = 0
    else:
        v2295 = 1
    del v2294
    v2296 = spiral_wrap(v2280 + v2288, 64, True)
    del v2280, v2288
    v2297 = spiral_wrap(v2281 + v2293, 64, True)
    del v2281, v2293
    v2298 = spiral_wrap(v2283 + v2295, 64, True)
    del v2283, v2295
    v2299 = spiral_wrap(v2273 + v2296, 64, True)
    del v2273, v2296
    v2300 = spiral_wrap(v2277 + v2297, 64, True)
    del v2277, v2297
    v2301 = spiral_wrap(v2279 + v2298, 64, True)
    del v2279, v2298
    v2302 = spiral_wrap(v2300 + v2301, 64, True)
    del v2300, v2301
    v2303 = spiral_wrap(v2299 + v2302, 64, True)
    del v2299, v2302
    v2304 = spiral_wrap(3 + v2303, 64, True)
    del v2303
    v2305 = 0 + 1
    v2306 = v2305 + 1
    del v2305
    v2307 = v2306 + 1
    del v2306
    v2308 = v2307 + 1
    del v2307
    v2309 = 0 + 1
    v2310 = v2309 + 1
    del v2309
    v2311 = v2310 + 1
    del v2310
    v2312 = v2311 + 1
    del v2311
    v2313 = v2308 == v2312
    if v2313:
        v2314 = 0
    else:
        v2314 = 1
    del v2313
    v2315 = 0 + 1
    v2316 = 0 + 1
    v2317 = v2315 == v2316
    if v2317:
        v2318 = 0
    else:
        v2318 = 1
    del v2317
    v2319 = 0 + 1
    v2320 = v2319 + 1
    del v2319
    v2321 = v2320 + 1
    del v2320
    v2322 = v2321 + 1
    del v2321
    v2323 = v2322 + 1
    del v2322
    v2324 = 0 + 1
    v2325 = v2324 + 1
    del v2324
    v2326 = v2325 + 1
    del v2325
    v2327 = v2326 + 1
    del v2326
    v2328 = v2327 + 1
    del v2327
    v2329 = v2323 == v2328
    if v2329:
        v2330 = 0
    else:
        v2330 = 1
    del v2329
    v2331 = spiral_wrap(v2315 + v2323, 64, True)
    del v2315, v2323
    v2332 = spiral_wrap(v2316 + v2328, 64, True)
    del v2316, v2328
    v2333 = spiral_wrap(v2318 + v2330, 64, True)
    del v2318, v2330
    v2334 = spiral_wrap(v2308 + v2331, 64, True)
    del v2308, v2331
    v2335 = spiral_wrap(v2312 + v2332, 64, True)
    del v2312, v2332
    v2336 = spiral_wrap(v2314 + v2333, 64, True)
    del v2314, v2333
    v2337 = spiral_wrap(v2335 + v2336, 64, True)
    del v2335, v2336
    v2338 = spiral_wrap(v2334 + v2337, 64, True)
    del v2334, v2337
    v2339 = spiral_wrap(3 + v2338, 64, True)
    del v2338
    v2340 = v2304 == v2339
    if v2340:
        v2341 = 0 + 1
        v2342 = v2341 + 1
        del v2341
        v2343 = v2342 + 1
        del v2342
        v2344 = v2343 + 1
        del v2343
        v2345 = 0 + 1
        v2346 = v2345 + 1
        del v2345
        v2347 = v2346 + 1
        del v2346
        v2348 = v2347 + 1
        del v2347
        v2349 = v2344 == v2348
        if v2349:
            v2350 = 0
        else:
            v2350 = 1
        del v2349
        v2351 = 0 + 1
        v2352 = 0 + 1
        v2353 = v2351 == v2352
        if v2353:
            v2354 = 0
        else:
            v2354 = 1
        del v2353
        v2355 = 0 + 1
        v2356 = v2355 + 1
        del v2355
        v2357 = v2356 + 1
        del v2356
        v2358 = v2357 + 1
        del v2357
        v2359 = v2358 + 1
        del v2358
        v2360 = 0 + 1
        v2361 = v2360 + 1
        del v2360
        v2362 = v2361 + 1
        del v2361
        v2363 = v2362 + 1
        del v2362
        v2364 = v2363 + 1
        del v2363
        v2365 = v2359 == v2364
        if v2365:
            v2366 = 0
        else:
            v2366 = 1
        del v2365
        v2367 = spiral_wrap(v2351 + v2359, 64, True)
        del v2351, v2359
        v2368 = spiral_wrap(v2352 + v2364, 64, True)
        del v2352, v2364
        v2369 = spiral_wrap(v2354 + v2366, 64, True)
        del v2354, v2366
        v2370 = spiral_wrap(v2344 + v2367, 64, True)
        del v2344, v2367
        v2371 = spiral_wrap(v2348 + v2368, 64, True)
        del v2348, v2368
        v2372 = spiral_wrap(v2350 + v2369, 64, True)
        del v2350, v2369
        v2373 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v2377 = US0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v2370, v2371, v2372, v2373)
    else:
        v2375 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v2377 = US0_TypedFxHashedStatementChecksumValidationRejected(v2304, v2339, v2375)
    del v2304, v2339, v2340
    match v2377:
        case US0_TypedFxHashedStatementChecksumValidationAccepted(v2381, v2382, v2383, v2384, v2385, _): # TypedFxHashedStatementChecksumValidationAccepted
            v2396, v2397, v2398, v2399, v2400, v2401, v2402, v2403, v2404 = 1, 0, 0, 0, v2381, v2382, v2383, v2384, v2385
        case US0_TypedFxHashedStatementChecksumValidationRejected(v2378, v2379, _): # TypedFxHashedStatementChecksumValidationRejected
            v2396, v2397, v2398, v2399, v2400, v2401, v2402, v2403, v2404 = 0, 1, v2378, v2379, 0, 0, 0, 0, 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v2377, v2398, v2399, v2400, v2401, v2402, v2403
    v2405 = 0 + 1
    v2406 = v2405 + 1
    del v2405
    v2407 = v2406 + 1
    del v2406
    v2408 = v2407 + 1
    del v2407
    v2409 = 0 + 1
    v2410 = v2409 + 1
    del v2409
    v2411 = v2410 + 1
    del v2410
    v2412 = v2411 + 1
    del v2411
    v2413 = v2408 == v2412
    if v2413:
        v2414 = 0
    else:
        v2414 = 1
    del v2413
    v2415 = 0 + 1
    v2416 = 0 + 1
    v2417 = v2415 == v2416
    if v2417:
        v2418 = 0
    else:
        v2418 = 1
    del v2417
    v2419 = 0 + 1
    v2420 = v2419 + 1
    del v2419
    v2421 = v2420 + 1
    del v2420
    v2422 = v2421 + 1
    del v2421
    v2423 = v2422 + 1
    del v2422
    v2424 = 0 + 1
    v2425 = v2424 + 1
    del v2424
    v2426 = v2425 + 1
    del v2425
    v2427 = v2426 + 1
    del v2426
    v2428 = v2427 + 1
    del v2427
    v2429 = v2423 == v2428
    if v2429:
        v2430 = 0
    else:
        v2430 = 1
    del v2429
    v2431 = spiral_wrap(v2415 + v2423, 64, True)
    del v2415, v2423
    v2432 = spiral_wrap(v2416 + v2428, 64, True)
    del v2416, v2428
    v2433 = spiral_wrap(v2418 + v2430, 64, True)
    del v2418, v2430
    v2434 = spiral_wrap(v2408 + v2431, 64, True)
    del v2408, v2431, v2434
    v2435 = spiral_wrap(v2412 + v2432, 64, True)
    del v2412, v2432, v2435
    v2436 = spiral_wrap(v2414 + v2433, 64, True)
    del v2414, v2433
    v2437 = 0 + 1
    v2438 = v2437 + 1
    del v2437
    v2439 = v2438 + 1
    del v2438
    v2440 = v2439 + 1
    del v2439
    v2441 = 0 + 1
    v2442 = v2441 + 1
    del v2441
    v2443 = v2442 + 1
    del v2442
    v2444 = v2443 + 1
    del v2443
    v2445 = v2440 == v2444
    if v2445:
        v2446 = 0
    else:
        v2446 = 1
    del v2445
    v2447 = 0 + 1
    v2448 = 0 + 1
    v2449 = v2447 == v2448
    if v2449:
        v2450 = 0
    else:
        v2450 = 1
    del v2449
    v2451 = 0 + 1
    v2452 = v2451 + 1
    del v2451
    v2453 = v2452 + 1
    del v2452
    v2454 = v2453 + 1
    del v2453
    v2455 = v2454 + 1
    del v2454
    v2456 = 0 + 1
    v2457 = v2456 + 1
    del v2456
    v2458 = v2457 + 1
    del v2457
    v2459 = v2458 + 1
    del v2458
    v2460 = v2459 + 1
    del v2459
    v2461 = v2455 == v2460
    if v2461:
        v2462 = 0
    else:
        v2462 = 1
    del v2461
    v2463 = spiral_wrap(v2447 + v2455, 64, True)
    del v2447, v2455
    v2464 = spiral_wrap(v2448 + v2460, 64, True)
    del v2448, v2460
    v2465 = spiral_wrap(v2450 + v2462, 64, True)
    del v2450, v2462
    v2466 = spiral_wrap(v2440 + v2463, 64, True)
    del v2440, v2463, v2466
    v2467 = spiral_wrap(v2444 + v2464, 64, True)
    del v2444, v2464, v2467
    v2468 = spiral_wrap(v2446 + v2465, 64, True)
    del v2446, v2465
    v2469 = spiral_wrap(v2436 + v2468, 64, True)
    del v2436, v2468
    v2470 = spiral_wrap(v2404 + v2397, 64, True)
    del v2397, v2404
    v2471 = spiral_wrap(v2469 + v2470, 64, True)
    del v2469, v2470
    v2472 = spiral_wrap(v2269 + v2471, 64, True)
    del v2269, v2471
    v2473 = v2396 == 1
    del v2396
    v2474 = v2472 == 0
    del v2472
    v2475 = v2473 and v2474
    del v2473, v2474
    if v2475:
        pass
    else:
        raise Exception("typed-FX-statement-recursive-writer-crash-phase-runtime-mismatch")
    del v2475
    v2476 = 0 + 1
    v2477 = v2476 + 1
    del v2476
    v2478 = v2477 + 1
    del v2477
    v2479 = v2478 + 1
    del v2478
    v2480 = 0 + 1
    v2481 = v2480 + 1
    del v2480
    v2482 = v2481 + 1
    del v2481
    v2483 = v2482 + 1
    del v2482
    v2484 = v2479 == v2483
    if v2484:
        v2485 = 0
    else:
        v2485 = 1
    del v2484
    v2486 = 0 + 1
    v2487 = 0 + 1
    v2488 = v2486 == v2487
    if v2488:
        v2489 = 0
    else:
        v2489 = 1
    del v2488
    v2490 = 0 + 1
    v2491 = v2490 + 1
    del v2490
    v2492 = v2491 + 1
    del v2491
    v2493 = v2492 + 1
    del v2492
    v2494 = v2493 + 1
    del v2493
    v2495 = 0 + 1
    v2496 = v2495 + 1
    del v2495
    v2497 = v2496 + 1
    del v2496
    v2498 = v2497 + 1
    del v2497
    v2499 = v2498 + 1
    del v2498
    v2500 = v2494 == v2499
    if v2500:
        v2501 = 0
    else:
        v2501 = 1
    del v2500
    v2502 = spiral_wrap(v2486 + v2494, 64, True)
    del v2486, v2494
    v2503 = spiral_wrap(v2487 + v2499, 64, True)
    del v2487, v2499
    v2504 = spiral_wrap(v2489 + v2501, 64, True)
    del v2489, v2501
    v2505 = spiral_wrap(v2479 + v2502, 64, True)
    del v2479, v2502, v2505
    v2506 = spiral_wrap(v2483 + v2503, 64, True)
    del v2483, v2503, v2506
    v2507 = spiral_wrap(v2485 + v2504, 64, True)
    del v2485, v2504
    v2508 = 0 + 1
    v2509 = v2508 + 1
    del v2508
    v2510 = v2509 + 1
    del v2509
    v2511 = v2510 + 1
    del v2510
    v2512 = 0 + 1
    v2513 = v2512 + 1
    del v2512
    v2514 = v2513 + 1
    del v2513
    v2515 = v2514 + 1
    del v2514
    v2516 = v2511 == v2515
    if v2516:
        v2517 = 0
    else:
        v2517 = 1
    del v2516
    v2518 = 0 + 1
    v2519 = 0 + 1
    v2520 = v2518 == v2519
    if v2520:
        v2521 = 0
    else:
        v2521 = 1
    del v2520
    v2522 = 0 + 1
    v2523 = v2522 + 1
    del v2522
    v2524 = v2523 + 1
    del v2523
    v2525 = v2524 + 1
    del v2524
    v2526 = v2525 + 1
    del v2525
    v2527 = 0 + 1
    v2528 = v2527 + 1
    del v2527
    v2529 = v2528 + 1
    del v2528
    v2530 = v2529 + 1
    del v2529
    v2531 = v2530 + 1
    del v2530
    v2532 = v2526 == v2531
    if v2532:
        v2533 = 0
    else:
        v2533 = 1
    del v2532
    v2534 = spiral_wrap(v2518 + v2526, 64, True)
    del v2518, v2526
    v2535 = spiral_wrap(v2519 + v2531, 64, True)
    del v2519, v2531
    v2536 = spiral_wrap(v2521 + v2533, 64, True)
    del v2521, v2533
    v2537 = spiral_wrap(v2511 + v2534, 64, True)
    del v2511, v2534, v2537
    v2538 = spiral_wrap(v2515 + v2535, 64, True)
    del v2515, v2535, v2538
    v2539 = spiral_wrap(v2517 + v2536, 64, True)
    del v2517, v2536
    v2540 = spiral_wrap(v2507 + v2539, 64, True)
    del v2507, v2539
    v2541 = 0 + 1
    v2542 = v2541 + 1
    del v2541
    v2543 = v2542 + 1
    del v2542
    v2544 = v2543 + 1
    del v2543
    v2545 = 0 + 1
    v2546 = v2545 + 1
    del v2545
    v2547 = v2546 + 1
    del v2546
    v2548 = v2547 + 1
    del v2547
    v2549 = v2544 == v2548
    if v2549:
        v2550 = 0
    else:
        v2550 = 1
    del v2549
    v2551 = 0 + 1
    v2552 = 0 + 1
    v2553 = v2551 == v2552
    if v2553:
        v2554 = 0
    else:
        v2554 = 1
    del v2553
    v2555 = 0 + 1
    v2556 = v2555 + 1
    del v2555
    v2557 = v2556 + 1
    del v2556
    v2558 = v2557 + 1
    del v2557
    v2559 = v2558 + 1
    del v2558
    v2560 = 0 + 1
    v2561 = v2560 + 1
    del v2560
    v2562 = v2561 + 1
    del v2561
    v2563 = v2562 + 1
    del v2562
    v2564 = v2563 + 1
    del v2563
    v2565 = v2559 == v2564
    if v2565:
        v2566 = 0
    else:
        v2566 = 1
    del v2565
    v2567 = spiral_wrap(v2551 + v2559, 64, True)
    del v2551, v2559
    v2568 = spiral_wrap(v2552 + v2564, 64, True)
    del v2552, v2564
    v2569 = spiral_wrap(v2554 + v2566, 64, True)
    del v2554, v2566
    v2570 = spiral_wrap(v2544 + v2567, 64, True)
    del v2544, v2567, v2570
    v2571 = spiral_wrap(v2548 + v2568, 64, True)
    del v2548, v2568, v2571
    v2572 = spiral_wrap(v2550 + v2569, 64, True)
    del v2550, v2569
    v2573 = 0 + 1
    v2574 = v2573 + 1
    del v2573
    v2575 = v2574 + 1
    del v2574
    v2576 = v2575 + 1
    del v2575
    v2577 = 0 + 1
    v2578 = v2577 + 1
    del v2577
    v2579 = v2578 + 1
    del v2578
    v2580 = v2579 + 1
    del v2579
    v2581 = v2576 == v2580
    if v2581:
        v2582 = 0
    else:
        v2582 = 1
    del v2581
    v2583 = 0 + 1
    v2584 = 0 + 1
    v2585 = v2583 == v2584
    if v2585:
        v2586 = 0
    else:
        v2586 = 1
    del v2585
    v2587 = 0 + 1
    v2588 = v2587 + 1
    del v2587
    v2589 = v2588 + 1
    del v2588
    v2590 = v2589 + 1
    del v2589
    v2591 = v2590 + 1
    del v2590
    v2592 = 0 + 1
    v2593 = v2592 + 1
    del v2592
    v2594 = v2593 + 1
    del v2593
    v2595 = v2594 + 1
    del v2594
    v2596 = v2595 + 1
    del v2595
    v2597 = v2591 == v2596
    if v2597:
        v2598 = 0
    else:
        v2598 = 1
    del v2597
    v2599 = spiral_wrap(v2583 + v2591, 64, True)
    del v2583, v2591
    v2600 = spiral_wrap(v2584 + v2596, 64, True)
    del v2584, v2596
    v2601 = spiral_wrap(v2586 + v2598, 64, True)
    del v2586, v2598
    v2602 = spiral_wrap(v2576 + v2599, 64, True)
    del v2576, v2599, v2602
    v2603 = spiral_wrap(v2580 + v2600, 64, True)
    del v2580, v2600, v2603
    v2604 = spiral_wrap(v2582 + v2601, 64, True)
    del v2582, v2601
    v2605 = spiral_wrap(v2572 + v2604, 64, True)
    del v2572, v2604
    v2606 = spiral_wrap(v2540 + v2605, 64, True)
    del v2540, v2605
    v2607 = 0 + 1
    v2608 = v2607 + 1
    del v2607
    v2609 = v2608 + 1
    del v2608
    v2610 = v2609 + 1
    del v2609
    v2611 = 0 + 1
    v2612 = v2611 + 1
    del v2611
    v2613 = v2612 + 1
    del v2612
    v2614 = v2613 + 1
    del v2613
    v2615 = v2610 == v2614
    if v2615:
        v2616 = 0
    else:
        v2616 = 1
    del v2615
    v2617 = 0 + 1
    v2618 = 0 + 1
    v2619 = v2617 == v2618
    if v2619:
        v2620 = 0
    else:
        v2620 = 1
    del v2619
    v2621 = 0 + 1
    v2622 = v2621 + 1
    del v2621
    v2623 = v2622 + 1
    del v2622
    v2624 = v2623 + 1
    del v2623
    v2625 = v2624 + 1
    del v2624
    v2626 = 0 + 1
    v2627 = v2626 + 1
    del v2626
    v2628 = v2627 + 1
    del v2627
    v2629 = v2628 + 1
    del v2628
    v2630 = v2629 + 1
    del v2629
    v2631 = v2625 == v2630
    if v2631:
        v2632 = 0
    else:
        v2632 = 1
    del v2631
    v2633 = spiral_wrap(v2617 + v2625, 64, True)
    del v2617, v2625
    v2634 = spiral_wrap(v2618 + v2630, 64, True)
    del v2618, v2630
    v2635 = spiral_wrap(v2620 + v2632, 64, True)
    del v2620, v2632
    v2636 = spiral_wrap(v2610 + v2633, 64, True)
    del v2610, v2633
    v2637 = spiral_wrap(v2614 + v2634, 64, True)
    del v2614, v2634
    v2638 = spiral_wrap(v2616 + v2635, 64, True)
    del v2616, v2635
    v2639 = spiral_wrap(v2637 + v2638, 64, True)
    del v2637, v2638
    v2640 = spiral_wrap(v2636 + v2639, 64, True)
    del v2636, v2639
    v2641 = spiral_wrap(3 + v2640, 64, True)
    del v2640
    v2642 = 0 + 1
    v2643 = v2642 + 1
    del v2642
    v2644 = v2643 + 1
    del v2643
    v2645 = v2644 + 1
    del v2644
    v2646 = 0 + 1
    v2647 = v2646 + 1
    del v2646
    v2648 = v2647 + 1
    del v2647
    v2649 = v2648 + 1
    del v2648
    v2650 = v2645 == v2649
    if v2650:
        v2651 = 0
    else:
        v2651 = 1
    del v2650
    v2652 = 0 + 1
    v2653 = 0 + 1
    v2654 = v2652 == v2653
    if v2654:
        v2655 = 0
    else:
        v2655 = 1
    del v2654
    v2656 = 0 + 1
    v2657 = v2656 + 1
    del v2656
    v2658 = v2657 + 1
    del v2657
    v2659 = v2658 + 1
    del v2658
    v2660 = v2659 + 1
    del v2659
    v2661 = 0 + 1
    v2662 = v2661 + 1
    del v2661
    v2663 = v2662 + 1
    del v2662
    v2664 = v2663 + 1
    del v2663
    v2665 = v2664 + 1
    del v2664
    v2666 = v2660 == v2665
    if v2666:
        v2667 = 0
    else:
        v2667 = 1
    del v2666
    v2668 = spiral_wrap(v2652 + v2660, 64, True)
    del v2652, v2660
    v2669 = spiral_wrap(v2653 + v2665, 64, True)
    del v2653, v2665
    v2670 = spiral_wrap(v2655 + v2667, 64, True)
    del v2655, v2667
    v2671 = spiral_wrap(v2645 + v2668, 64, True)
    del v2645, v2668
    v2672 = spiral_wrap(v2649 + v2669, 64, True)
    del v2649, v2669
    v2673 = spiral_wrap(v2651 + v2670, 64, True)
    del v2651, v2670
    v2674 = spiral_wrap(v2672 + v2673, 64, True)
    del v2672, v2673
    v2675 = spiral_wrap(v2671 + v2674, 64, True)
    del v2671, v2674
    v2676 = spiral_wrap(3 + v2675, 64, True)
    del v2675
    v2677 = v2641 == v2676
    if v2677:
        v2678 = 0 + 1
        v2679 = v2678 + 1
        del v2678
        v2680 = v2679 + 1
        del v2679
        v2681 = v2680 + 1
        del v2680
        v2682 = 0 + 1
        v2683 = v2682 + 1
        del v2682
        v2684 = v2683 + 1
        del v2683
        v2685 = v2684 + 1
        del v2684
        v2686 = v2681 == v2685
        if v2686:
            v2687 = 0
        else:
            v2687 = 1
        del v2686
        v2688 = 0 + 1
        v2689 = 0 + 1
        v2690 = v2688 == v2689
        if v2690:
            v2691 = 0
        else:
            v2691 = 1
        del v2690
        v2692 = 0 + 1
        v2693 = v2692 + 1
        del v2692
        v2694 = v2693 + 1
        del v2693
        v2695 = v2694 + 1
        del v2694
        v2696 = v2695 + 1
        del v2695
        v2697 = 0 + 1
        v2698 = v2697 + 1
        del v2697
        v2699 = v2698 + 1
        del v2698
        v2700 = v2699 + 1
        del v2699
        v2701 = v2700 + 1
        del v2700
        v2702 = v2696 == v2701
        if v2702:
            v2703 = 0
        else:
            v2703 = 1
        del v2702
        v2704 = spiral_wrap(v2688 + v2696, 64, True)
        del v2688, v2696
        v2705 = spiral_wrap(v2689 + v2701, 64, True)
        del v2689, v2701
        v2706 = spiral_wrap(v2691 + v2703, 64, True)
        del v2691, v2703
        v2707 = spiral_wrap(v2681 + v2704, 64, True)
        del v2681, v2704
        v2708 = spiral_wrap(v2685 + v2705, 64, True)
        del v2685, v2705
        v2709 = spiral_wrap(v2687 + v2706, 64, True)
        del v2687, v2706
        v2710 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        v2714 = US0_TypedFxHashedStatementChecksumValidationAccepted(1, 3, v2707, v2708, v2709, v2710)
    else:
        v2712 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        v2714 = US0_TypedFxHashedStatementChecksumValidationRejected(v2641, v2676, v2712)
    del v2641, v2676, v2677
    match v2714:
        case US0_TypedFxHashedStatementChecksumValidationAccepted(v2718, v2719, v2720, v2721, v2722, _): # TypedFxHashedStatementChecksumValidationAccepted
            v2733, v2734, v2735, v2736, v2737, v2738, v2739, v2740, v2741 = 1, 0, 0, 0, v2718, v2719, v2720, v2721, v2722
        case US0_TypedFxHashedStatementChecksumValidationRejected(v2715, v2716, _): # TypedFxHashedStatementChecksumValidationRejected
            v2733, v2734, v2735, v2736, v2737, v2738, v2739, v2740, v2741 = 0, 1, v2715, v2716, 0, 0, 0, 0, 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v2714, v2735, v2736, v2737, v2738, v2739, v2740
    v2742 = 0 + 1
    v2743 = v2742 + 1
    del v2742
    v2744 = v2743 + 1
    del v2743
    v2745 = v2744 + 1
    del v2744
    v2746 = 0 + 1
    v2747 = v2746 + 1
    del v2746
    v2748 = v2747 + 1
    del v2747
    v2749 = v2748 + 1
    del v2748
    v2750 = v2745 == v2749
    if v2750:
        v2751 = 0
    else:
        v2751 = 1
    del v2750
    v2752 = 0 + 1
    v2753 = 0 + 1
    v2754 = v2752 == v2753
    if v2754:
        v2755 = 0
    else:
        v2755 = 1
    del v2754
    v2756 = 0 + 1
    v2757 = v2756 + 1
    del v2756
    v2758 = v2757 + 1
    del v2757
    v2759 = v2758 + 1
    del v2758
    v2760 = v2759 + 1
    del v2759
    v2761 = 0 + 1
    v2762 = v2761 + 1
    del v2761
    v2763 = v2762 + 1
    del v2762
    v2764 = v2763 + 1
    del v2763
    v2765 = v2764 + 1
    del v2764
    v2766 = v2760 == v2765
    if v2766:
        v2767 = 0
    else:
        v2767 = 1
    del v2766
    v2768 = spiral_wrap(v2752 + v2760, 64, True)
    del v2752, v2760
    v2769 = spiral_wrap(v2753 + v2765, 64, True)
    del v2753, v2765
    v2770 = spiral_wrap(v2755 + v2767, 64, True)
    del v2755, v2767
    v2771 = spiral_wrap(v2745 + v2768, 64, True)
    del v2745, v2768, v2771
    v2772 = spiral_wrap(v2749 + v2769, 64, True)
    del v2749, v2769, v2772
    v2773 = spiral_wrap(v2751 + v2770, 64, True)
    del v2751, v2770
    v2774 = 0 + 1
    v2775 = v2774 + 1
    del v2774
    v2776 = v2775 + 1
    del v2775
    v2777 = v2776 + 1
    del v2776
    v2778 = 0 + 1
    v2779 = v2778 + 1
    del v2778
    v2780 = v2779 + 1
    del v2779
    v2781 = v2780 + 1
    del v2780
    v2782 = v2777 == v2781
    if v2782:
        v2783 = 0
    else:
        v2783 = 1
    del v2782
    v2784 = 0 + 1
    v2785 = 0 + 1
    v2786 = v2784 == v2785
    if v2786:
        v2787 = 0
    else:
        v2787 = 1
    del v2786
    v2788 = 0 + 1
    v2789 = v2788 + 1
    del v2788
    v2790 = v2789 + 1
    del v2789
    v2791 = v2790 + 1
    del v2790
    v2792 = v2791 + 1
    del v2791
    v2793 = 0 + 1
    v2794 = v2793 + 1
    del v2793
    v2795 = v2794 + 1
    del v2794
    v2796 = v2795 + 1
    del v2795
    v2797 = v2796 + 1
    del v2796
    v2798 = v2792 == v2797
    if v2798:
        v2799 = 0
    else:
        v2799 = 1
    del v2798
    v2800 = spiral_wrap(v2784 + v2792, 64, True)
    del v2784, v2792
    v2801 = spiral_wrap(v2785 + v2797, 64, True)
    del v2785, v2797
    v2802 = spiral_wrap(v2787 + v2799, 64, True)
    del v2787, v2799
    v2803 = spiral_wrap(v2777 + v2800, 64, True)
    del v2777, v2800, v2803
    v2804 = spiral_wrap(v2781 + v2801, 64, True)
    del v2781, v2801, v2804
    v2805 = spiral_wrap(v2783 + v2802, 64, True)
    del v2783, v2802
    v2806 = spiral_wrap(v2773 + v2805, 64, True)
    del v2773, v2805
    v2807 = spiral_wrap(v2741 + v2734, 64, True)
    del v2734, v2741
    v2808 = spiral_wrap(v2806 + v2807, 64, True)
    del v2806, v2807
    v2809 = spiral_wrap(v2606 + v2808, 64, True)
    del v2606, v2808
    v2810 = v2733 == 1
    del v2733
    v2811 = v2809 == 0
    del v2809
    v2812 = v2810 and v2811
    del v2810, v2811
    if v2812:
        pass
    else:
        raise Exception("typed-FX-statement-indexed-durable-commit-runtime-mismatch")
    del v2812
    v2813 = 0 + 1
    v2814 = v2813 + 1
    del v2813
    v2815 = v2814 + 1
    del v2814
    v2816 = v2815 + 1
    del v2815
    v2817 = 0 + 1
    v2818 = v2817 + 1
    del v2817
    v2819 = v2818 + 1
    del v2818
    v2820 = v2819 + 1
    del v2819
    v2821 = v2816 == v2820
    if v2821:
        v2822 = 0
    else:
        v2822 = 1
    del v2821
    v2823 = 0 + 1
    v2824 = 0 + 1
    v2825 = v2823 == v2824
    if v2825:
        v2826 = 0
    else:
        v2826 = 1
    del v2825
    v2827 = 0 + 1
    v2828 = v2827 + 1
    del v2827
    v2829 = v2828 + 1
    del v2828
    v2830 = v2829 + 1
    del v2829
    v2831 = v2830 + 1
    del v2830
    v2832 = 0 + 1
    v2833 = v2832 + 1
    del v2832
    v2834 = v2833 + 1
    del v2833
    v2835 = v2834 + 1
    del v2834
    v2836 = v2835 + 1
    del v2835
    v2837 = v2831 == v2836
    if v2837:
        v2838 = 0
    else:
        v2838 = 1
    del v2837
    v2839 = spiral_wrap(v2823 + v2831, 64, True)
    del v2823, v2831
    v2840 = spiral_wrap(v2824 + v2836, 64, True)
    del v2824, v2836
    v2841 = spiral_wrap(v2826 + v2838, 64, True)
    del v2826, v2838
    v2842 = spiral_wrap(v2816 + v2839, 64, True)
    del v2816, v2839
    v2843 = spiral_wrap(v2820 + v2840, 64, True)
    del v2820, v2840
    v2844 = spiral_wrap(v2822 + v2841, 64, True)
    del v2822, v2841
    v2845 = 0 + 1
    v2846 = v2845 + 1
    del v2845
    v2847 = v2846 + 1
    del v2846
    v2848 = v2847 + 1
    del v2847
    v2849 = 0 + 1
    v2850 = v2849 + 1
    del v2849
    v2851 = v2850 + 1
    del v2850
    v2852 = v2851 + 1
    del v2851
    v2853 = v2848 == v2852
    if v2853:
        v2854 = 0
    else:
        v2854 = 1
    del v2853
    v2855 = 0 + 1
    v2856 = 0 + 1
    v2857 = v2855 == v2856
    if v2857:
        v2858 = 0
    else:
        v2858 = 1
    del v2857
    v2859 = 0 + 1
    v2860 = v2859 + 1
    del v2859
    v2861 = v2860 + 1
    del v2860
    v2862 = v2861 + 1
    del v2861
    v2863 = v2862 + 1
    del v2862
    v2864 = 0 + 1
    v2865 = v2864 + 1
    del v2864
    v2866 = v2865 + 1
    del v2865
    v2867 = v2866 + 1
    del v2866
    v2868 = v2867 + 1
    del v2867
    v2869 = v2863 == v2868
    if v2869:
        v2870 = 0
    else:
        v2870 = 1
    del v2869
    v2871 = spiral_wrap(v2855 + v2863, 64, True)
    del v2855, v2863
    v2872 = spiral_wrap(v2856 + v2868, 64, True)
    del v2856, v2868
    v2873 = spiral_wrap(v2858 + v2870, 64, True)
    del v2858, v2870
    v2874 = spiral_wrap(v2848 + v2871, 64, True)
    del v2848, v2871
    v2875 = spiral_wrap(v2852 + v2872, 64, True)
    del v2852, v2872
    v2876 = spiral_wrap(v2854 + v2873, 64, True)
    del v2854, v2873
    v2877 = 0 + 1
    v2878 = v2877 + 1
    del v2877
    v2879 = v2878 + 1
    del v2878
    v2880 = v2879 + 1
    del v2879
    v2881 = 0 + 1
    v2882 = v2881 + 1
    del v2881
    v2883 = v2882 + 1
    del v2882
    v2884 = v2883 + 1
    del v2883
    v2885 = v2880 == v2884
    if v2885:
        v2886 = 0
    else:
        v2886 = 1
    del v2885
    v2887 = 0 + 1
    v2888 = 0 + 1
    v2889 = v2887 == v2888
    if v2889:
        v2890 = 0
    else:
        v2890 = 1
    del v2889
    v2891 = 0 + 1
    v2892 = v2891 + 1
    del v2891
    v2893 = v2892 + 1
    del v2892
    v2894 = v2893 + 1
    del v2893
    v2895 = v2894 + 1
    del v2894
    v2896 = 0 + 1
    v2897 = v2896 + 1
    del v2896
    v2898 = v2897 + 1
    del v2897
    v2899 = v2898 + 1
    del v2898
    v2900 = v2899 + 1
    del v2899
    v2901 = v2895 == v2900
    if v2901:
        v2902 = 0
    else:
        v2902 = 1
    del v2901
    v2903 = spiral_wrap(v2887 + v2895, 64, True)
    del v2887, v2895
    v2904 = spiral_wrap(v2888 + v2900, 64, True)
    del v2888, v2900
    v2905 = spiral_wrap(v2890 + v2902, 64, True)
    del v2890, v2902
    v2906 = spiral_wrap(v2880 + v2903, 64, True)
    del v2880, v2903
    v2907 = spiral_wrap(v2884 + v2904, 64, True)
    del v2884, v2904
    v2908 = spiral_wrap(v2886 + v2905, 64, True)
    del v2886, v2905
    v2909 = 0 + 1
    v2910 = v2909 + 1
    del v2909
    v2911 = v2910 + 1
    del v2910
    v2912 = v2911 + 1
    del v2911
    v2913 = 0 + 1
    v2914 = v2913 + 1
    del v2913
    v2915 = v2914 + 1
    del v2914
    v2916 = v2915 + 1
    del v2915
    v2917 = v2912 == v2916
    if v2917:
        v2918 = 0
    else:
        v2918 = 1
    del v2917
    v2919 = 0 + 1
    v2920 = 0 + 1
    v2921 = v2919 == v2920
    if v2921:
        v2922 = 0
    else:
        v2922 = 1
    del v2921
    v2923 = 0 + 1
    v2924 = v2923 + 1
    del v2923
    v2925 = v2924 + 1
    del v2924
    v2926 = v2925 + 1
    del v2925
    v2927 = v2926 + 1
    del v2926
    v2928 = 0 + 1
    v2929 = v2928 + 1
    del v2928
    v2930 = v2929 + 1
    del v2929
    v2931 = v2930 + 1
    del v2930
    v2932 = v2931 + 1
    del v2931
    v2933 = v2927 == v2932
    if v2933:
        v2934 = 0
    else:
        v2934 = 1
    del v2933
    v2935 = spiral_wrap(v2919 + v2927, 64, True)
    del v2919, v2927
    v2936 = spiral_wrap(v2920 + v2932, 64, True)
    del v2920, v2932
    v2937 = spiral_wrap(v2922 + v2934, 64, True)
    del v2922, v2934
    v2938 = spiral_wrap(v2912 + v2935, 64, True)
    del v2912, v2935
    v2939 = spiral_wrap(v2916 + v2936, 64, True)
    del v2916, v2936
    v2940 = spiral_wrap(v2918 + v2937, 64, True)
    del v2918, v2937
    v2941 = spiral_wrap(v2906 + v2938, 64, True)
    del v2906, v2938
    v2942 = spiral_wrap(v2907 + v2939, 64, True)
    del v2907, v2939
    v2943 = spiral_wrap(v2908 + v2940, 64, True)
    del v2908, v2940
    v2944 = spiral_wrap(v2874 + v2941, 64, True)
    del v2874, v2941
    v2945 = spiral_wrap(v2875 + v2942, 64, True)
    del v2875, v2942
    v2946 = spiral_wrap(v2876 + v2943, 64, True)
    del v2876, v2943
    v2947 = spiral_wrap(v2842 + v2944, 64, True)
    del v2842, v2944
    v2948 = spiral_wrap(v2843 + v2945, 64, True)
    del v2843, v2945
    v2949 = spiral_wrap(v2844 + v2946, 64, True)
    del v2844, v2946
    v2950 = v2947 == 40
    del v2947
    v2951 = v2948 == 40
    del v2948
    v2952 = v2949 == 0
    del v2949
    v2953 = v2950 and v2951
    del v2950, v2951
    v2954 = v2953 and v2952
    del v2952, v2953
    if v2954:
        pass
    else:
        raise Exception("typed-FX-hashed-statement-event-store-decision-runtime-mismatch")
    del v2954
    v2955 = 0 + 1
    v2956 = v2955 + 1
    del v2955
    v2957 = v2956 + 1
    del v2956
    v2958 = v2957 + 1
    del v2957
    v2959 = 0 + 1
    v2960 = v2959 + 1
    del v2959
    v2961 = v2960 + 1
    del v2960
    v2962 = v2961 + 1
    del v2961
    v2963 = v2958 == v2962
    if v2963:
        v2964 = 0
    else:
        v2964 = 1
    del v2963
    v2965 = 0 + 1
    v2966 = 0 + 1
    v2967 = v2965 == v2966
    if v2967:
        v2968 = 0
    else:
        v2968 = 1
    del v2967
    v2969 = 0 + 1
    v2970 = v2969 + 1
    del v2969
    v2971 = v2970 + 1
    del v2970
    v2972 = v2971 + 1
    del v2971
    v2973 = v2972 + 1
    del v2972
    v2974 = 0 + 1
    v2975 = v2974 + 1
    del v2974
    v2976 = v2975 + 1
    del v2975
    v2977 = v2976 + 1
    del v2976
    v2978 = v2977 + 1
    del v2977
    v2979 = v2973 == v2978
    if v2979:
        v2980 = 0
    else:
        v2980 = 1
    del v2979
    v2981 = spiral_wrap(v2965 + v2973, 64, True)
    del v2965, v2973
    v2982 = spiral_wrap(v2966 + v2978, 64, True)
    del v2966, v2978
    v2983 = spiral_wrap(v2968 + v2980, 64, True)
    del v2968, v2980
    v2984 = spiral_wrap(v2958 + v2981, 64, True)
    del v2958, v2981
    v2985 = spiral_wrap(v2962 + v2982, 64, True)
    del v2962, v2982
    v2986 = spiral_wrap(v2964 + v2983, 64, True)
    del v2964, v2983
    v2987 = 0 + 1
    v2988 = v2987 + 1
    del v2987
    v2989 = v2988 + 1
    del v2988
    v2990 = v2989 + 1
    del v2989
    v2991 = 0 + 1
    v2992 = v2991 + 1
    del v2991
    v2993 = v2992 + 1
    del v2992
    v2994 = v2993 + 1
    del v2993
    v2995 = v2990 == v2994
    if v2995:
        v2996 = 0
    else:
        v2996 = 1
    del v2995
    v2997 = 0 + 1
    v2998 = 0 + 1
    v2999 = v2997 == v2998
    if v2999:
        v3000 = 0
    else:
        v3000 = 1
    del v2999
    v3001 = 0 + 1
    v3002 = v3001 + 1
    del v3001
    v3003 = v3002 + 1
    del v3002
    v3004 = v3003 + 1
    del v3003
    v3005 = v3004 + 1
    del v3004
    v3006 = 0 + 1
    v3007 = v3006 + 1
    del v3006
    v3008 = v3007 + 1
    del v3007
    v3009 = v3008 + 1
    del v3008
    v3010 = v3009 + 1
    del v3009
    v3011 = v3005 == v3010
    if v3011:
        v3012 = 0
    else:
        v3012 = 1
    del v3011
    v3013 = spiral_wrap(v2997 + v3005, 64, True)
    del v2997, v3005
    v3014 = spiral_wrap(v2998 + v3010, 64, True)
    del v2998, v3010
    v3015 = spiral_wrap(v3000 + v3012, 64, True)
    del v3000, v3012
    v3016 = spiral_wrap(v2990 + v3013, 64, True)
    del v2990, v3013
    v3017 = spiral_wrap(v2994 + v3014, 64, True)
    del v2994, v3014
    v3018 = spiral_wrap(v2996 + v3015, 64, True)
    del v2996, v3015
    v3019 = spiral_wrap(v3016 + v2984, 64, True)
    del v2984, v3016, v3019
    v3020 = spiral_wrap(v3017 + v2985, 64, True)
    del v2985, v3017, v3020
    v3021 = spiral_wrap(v3018 + v2986, 64, True)
    del v2986, v3018
    v3022 = 0 + 1
    v3023 = v3022 + 1
    del v3022
    v3024 = v3023 + 1
    del v3023
    v3025 = v3024 + 1
    del v3024
    v3026 = 0 + 1
    v3027 = v3026 + 1
    del v3026
    v3028 = v3027 + 1
    del v3027
    v3029 = v3028 + 1
    del v3028
    v3030 = v3025 == v3029
    if v3030:
        v3031 = 0
    else:
        v3031 = 1
    del v3030
    v3032 = 0 + 1
    v3033 = 0 + 1
    v3034 = v3032 == v3033
    if v3034:
        v3035 = 0
    else:
        v3035 = 1
    del v3034
    v3036 = 0 + 1
    v3037 = v3036 + 1
    del v3036
    v3038 = v3037 + 1
    del v3037
    v3039 = v3038 + 1
    del v3038
    v3040 = v3039 + 1
    del v3039
    v3041 = 0 + 1
    v3042 = v3041 + 1
    del v3041
    v3043 = v3042 + 1
    del v3042
    v3044 = v3043 + 1
    del v3043
    v3045 = v3044 + 1
    del v3044
    v3046 = v3040 == v3045
    if v3046:
        v3047 = 0
    else:
        v3047 = 1
    del v3046
    v3048 = spiral_wrap(v3032 + v3040, 64, True)
    del v3032, v3040
    v3049 = spiral_wrap(v3033 + v3045, 64, True)
    del v3033, v3045
    v3050 = spiral_wrap(v3035 + v3047, 64, True)
    del v3035, v3047
    v3051 = spiral_wrap(v3025 + v3048, 64, True)
    del v3025, v3048
    v3052 = spiral_wrap(v3029 + v3049, 64, True)
    del v3029, v3049
    v3053 = spiral_wrap(v3031 + v3050, 64, True)
    del v3031, v3050
    v3054 = 0 + 1
    v3055 = v3054 + 1
    del v3054
    v3056 = v3055 + 1
    del v3055
    v3057 = v3056 + 1
    del v3056
    v3058 = 0 + 1
    v3059 = v3058 + 1
    del v3058
    v3060 = v3059 + 1
    del v3059
    v3061 = v3060 + 1
    del v3060
    v3062 = v3057 == v3061
    if v3062:
        v3063 = 0
    else:
        v3063 = 1
    del v3062
    v3064 = 0 + 1
    v3065 = 0 + 1
    v3066 = v3064 == v3065
    if v3066:
        v3067 = 0
    else:
        v3067 = 1
    del v3066
    v3068 = 0 + 1
    v3069 = v3068 + 1
    del v3068
    v3070 = v3069 + 1
    del v3069
    v3071 = v3070 + 1
    del v3070
    v3072 = v3071 + 1
    del v3071
    v3073 = 0 + 1
    v3074 = v3073 + 1
    del v3073
    v3075 = v3074 + 1
    del v3074
    v3076 = v3075 + 1
    del v3075
    v3077 = v3076 + 1
    del v3076
    v3078 = v3072 == v3077
    if v3078:
        v3079 = 0
    else:
        v3079 = 1
    del v3078
    v3080 = spiral_wrap(v3064 + v3072, 64, True)
    del v3064, v3072
    v3081 = spiral_wrap(v3065 + v3077, 64, True)
    del v3065, v3077
    v3082 = spiral_wrap(v3067 + v3079, 64, True)
    del v3067, v3079
    v3083 = spiral_wrap(v3057 + v3080, 64, True)
    del v3057, v3080
    v3084 = spiral_wrap(v3061 + v3081, 64, True)
    del v3061, v3081
    v3085 = spiral_wrap(v3063 + v3082, 64, True)
    del v3063, v3082
    v3086 = spiral_wrap(v3083 + v3051, 64, True)
    del v3051, v3083, v3086
    v3087 = spiral_wrap(v3084 + v3052, 64, True)
    del v3052, v3084, v3087
    v3088 = spiral_wrap(v3085 + v3053, 64, True)
    del v3053, v3085
    v3089 = spiral_wrap(v3021 + v3088, 64, True)
    del v3021, v3088
    v3090 = v3089 == 0
    del v3089
    if v3090:
        pass
    else:
        raise Exception("typed-FX-hashed-statement-proven-retry-runtime-mismatch")
    del v3090
    v3091 = 0 + 1
    v3092 = v3091 + 1
    del v3091
    v3093 = v3092 + 1
    del v3092
    v3094 = v3093 + 1
    del v3093
    v3095 = 0 + 1
    v3096 = v3095 + 1
    del v3095
    v3097 = v3096 + 1
    del v3096
    v3098 = v3097 + 1
    del v3097
    v3099 = v3094 == v3098
    if v3099:
        v3100 = 0
    else:
        v3100 = 1
    del v3099
    v3101 = 0 + 1
    v3102 = 0 + 1
    v3103 = v3101 == v3102
    if v3103:
        v3104 = 0
    else:
        v3104 = 1
    del v3103
    v3105 = 0 + 1
    v3106 = v3105 + 1
    del v3105
    v3107 = v3106 + 1
    del v3106
    v3108 = v3107 + 1
    del v3107
    v3109 = v3108 + 1
    del v3108
    v3110 = 0 + 1
    v3111 = v3110 + 1
    del v3110
    v3112 = v3111 + 1
    del v3111
    v3113 = v3112 + 1
    del v3112
    v3114 = v3113 + 1
    del v3113
    v3115 = v3109 == v3114
    if v3115:
        v3116 = 0
    else:
        v3116 = 1
    del v3115
    v3117 = spiral_wrap(v3101 + v3109, 64, True)
    del v3101, v3109
    v3118 = spiral_wrap(v3102 + v3114, 64, True)
    del v3102, v3114
    v3119 = spiral_wrap(v3104 + v3116, 64, True)
    del v3104, v3116
    v3120 = spiral_wrap(v3094 + v3117, 64, True)
    del v3094, v3117
    v3121 = spiral_wrap(v3098 + v3118, 64, True)
    del v3098, v3118
    v3122 = spiral_wrap(v3100 + v3119, 64, True)
    del v3100, v3119
    v3123 = 0 + 1
    v3124 = v3123 + 1
    del v3123
    v3125 = v3124 + 1
    del v3124
    v3126 = v3125 + 1
    del v3125
    v3127 = 0 + 1
    v3128 = v3127 + 1
    del v3127
    v3129 = v3128 + 1
    del v3128
    v3130 = v3129 + 1
    del v3129
    v3131 = v3126 == v3130
    if v3131:
        v3132 = 0
    else:
        v3132 = 1
    del v3131
    v3133 = 0 + 1
    v3134 = 0 + 1
    v3135 = v3133 == v3134
    if v3135:
        v3136 = 0
    else:
        v3136 = 1
    del v3135
    v3137 = 0 + 1
    v3138 = v3137 + 1
    del v3137
    v3139 = v3138 + 1
    del v3138
    v3140 = v3139 + 1
    del v3139
    v3141 = v3140 + 1
    del v3140
    v3142 = 0 + 1
    v3143 = v3142 + 1
    del v3142
    v3144 = v3143 + 1
    del v3143
    v3145 = v3144 + 1
    del v3144
    v3146 = v3145 + 1
    del v3145
    v3147 = v3141 == v3146
    if v3147:
        v3148 = 0
    else:
        v3148 = 1
    del v3147
    v3149 = spiral_wrap(v3133 + v3141, 64, True)
    del v3133, v3141
    v3150 = spiral_wrap(v3134 + v3146, 64, True)
    del v3134, v3146
    v3151 = spiral_wrap(v3136 + v3148, 64, True)
    del v3136, v3148
    v3152 = spiral_wrap(v3126 + v3149, 64, True)
    del v3126, v3149
    v3153 = spiral_wrap(v3130 + v3150, 64, True)
    del v3130, v3150
    v3154 = spiral_wrap(v3132 + v3151, 64, True)
    del v3132, v3151
    v3155 = spiral_wrap(v3152 + v3120, 64, True)
    del v3120, v3152
    v3156 = spiral_wrap(v3153 + v3121, 64, True)
    del v3121, v3153
    v3157 = spiral_wrap(v3154 + v3122, 64, True)
    del v3122, v3154
    v3158 = v3155 == 20
    del v3155
    v3159 = v3156 == 20
    del v3156
    v3160 = v3157 == 0
    del v3157
    v3161 = v3158 and v3159
    del v3158, v3159
    v3162 = v3161 and v3160
    del v3160, v3161
    if v3162:
        pass
    else:
        raise Exception("typed-FX-hashed-statement-history-enumeration-runtime-mismatch")
    del v3162
    v3163 = 0 + 1
    v3164 = v3163 + 1
    del v3163
    v3165 = v3164 + 1
    del v3164
    v3166 = v3165 + 1
    del v3165
    v3167 = 0 + 1
    v3168 = v3167 + 1
    del v3167
    v3169 = v3168 + 1
    del v3168
    v3170 = v3169 + 1
    del v3169
    v3171 = v3166 == v3170
    if v3171:
        v3172 = 0
    else:
        v3172 = 1
    del v3171
    v3173 = 0 + 1
    v3174 = 0 + 1
    v3175 = v3173 == v3174
    if v3175:
        v3176 = 0
    else:
        v3176 = 1
    del v3175
    v3177 = 0 + 1
    v3178 = v3177 + 1
    del v3177
    v3179 = v3178 + 1
    del v3178
    v3180 = v3179 + 1
    del v3179
    v3181 = v3180 + 1
    del v3180
    v3182 = 0 + 1
    v3183 = v3182 + 1
    del v3182
    v3184 = v3183 + 1
    del v3183
    v3185 = v3184 + 1
    del v3184
    v3186 = v3185 + 1
    del v3185
    v3187 = v3181 == v3186
    if v3187:
        v3188 = 0
    else:
        v3188 = 1
    del v3187
    v3189 = spiral_wrap(v3173 + v3181, 64, True)
    del v3173, v3181
    v3190 = spiral_wrap(v3174 + v3186, 64, True)
    del v3174, v3186
    v3191 = spiral_wrap(v3176 + v3188, 64, True)
    del v3176, v3188
    v3192 = spiral_wrap(v3166 + v3189, 64, True)
    del v3166, v3189
    v3193 = spiral_wrap(v3170 + v3190, 64, True)
    del v3170, v3190
    v3194 = spiral_wrap(v3172 + v3191, 64, True)
    del v3172, v3191
    v3195 = v3192 == 10
    del v3192
    v3196 = v3193 == 10
    del v3193
    v3197 = v3194 == 0
    del v3194
    v3198 = v3195 and v3196
    del v3195, v3196
    v3199 = v3198 and v3197
    del v3197, v3198
    if v3199:
        pass
    else:
        raise Exception("typed-FX-hashed-statement-history-index-lookup-runtime-mismatch")
    del v3199
    v3200 = 0 + 1
    v3201 = v3200 + 1
    del v3200
    v3202 = v3201 + 1
    del v3201
    v3203 = v3202 + 1
    del v3202
    v3204 = 0 + 1
    v3205 = v3204 + 1
    del v3204
    v3206 = v3205 + 1
    del v3205
    v3207 = v3206 + 1
    del v3206
    v3208 = v3203 == v3207
    if v3208:
        v3209 = 0
    else:
        v3209 = 1
    del v3208
    v3210 = 0 + 1
    v3211 = 0 + 1
    v3212 = v3210 == v3211
    if v3212:
        v3213 = 0
    else:
        v3213 = 1
    del v3212
    v3214 = 0 + 1
    v3215 = v3214 + 1
    del v3214
    v3216 = v3215 + 1
    del v3215
    v3217 = v3216 + 1
    del v3216
    v3218 = v3217 + 1
    del v3217
    v3219 = 0 + 1
    v3220 = v3219 + 1
    del v3219
    v3221 = v3220 + 1
    del v3220
    v3222 = v3221 + 1
    del v3221
    v3223 = v3222 + 1
    del v3222
    v3224 = v3218 == v3223
    if v3224:
        v3225 = 0
    else:
        v3225 = 1
    del v3224
    v3226 = spiral_wrap(v3210 + v3218, 64, True)
    del v3210, v3218
    v3227 = spiral_wrap(v3211 + v3223, 64, True)
    del v3211, v3223
    v3228 = spiral_wrap(v3213 + v3225, 64, True)
    del v3213, v3225
    v3229 = spiral_wrap(v3203 + v3226, 64, True)
    del v3203, v3226
    v3230 = spiral_wrap(v3207 + v3227, 64, True)
    del v3207, v3227
    v3231 = spiral_wrap(v3209 + v3228, 64, True)
    del v3209, v3228
    v3232 = 0 + 1
    v3233 = v3232 + 1
    del v3232
    v3234 = v3233 + 1
    del v3233
    v3235 = v3234 + 1
    del v3234
    v3236 = 0 + 1
    v3237 = v3236 + 1
    del v3236
    v3238 = v3237 + 1
    del v3237
    v3239 = v3238 + 1
    del v3238
    v3240 = v3235 == v3239
    if v3240:
        v3241 = 0
    else:
        v3241 = 1
    del v3240
    v3242 = 0 + 1
    v3243 = 0 + 1
    v3244 = v3242 == v3243
    if v3244:
        v3245 = 0
    else:
        v3245 = 1
    del v3244
    v3246 = 0 + 1
    v3247 = v3246 + 1
    del v3246
    v3248 = v3247 + 1
    del v3247
    v3249 = v3248 + 1
    del v3248
    v3250 = v3249 + 1
    del v3249
    v3251 = 0 + 1
    v3252 = v3251 + 1
    del v3251
    v3253 = v3252 + 1
    del v3252
    v3254 = v3253 + 1
    del v3253
    v3255 = v3254 + 1
    del v3254
    v3256 = v3250 == v3255
    if v3256:
        v3257 = 0
    else:
        v3257 = 1
    del v3256
    v3258 = spiral_wrap(v3242 + v3250, 64, True)
    del v3242, v3250
    v3259 = spiral_wrap(v3243 + v3255, 64, True)
    del v3243, v3255
    v3260 = spiral_wrap(v3245 + v3257, 64, True)
    del v3245, v3257
    v3261 = spiral_wrap(v3235 + v3258, 64, True)
    del v3235, v3258
    v3262 = spiral_wrap(v3239 + v3259, 64, True)
    del v3239, v3259
    v3263 = spiral_wrap(v3241 + v3260, 64, True)
    del v3241, v3260
    v3264 = v3229 == 10
    del v3229
    v3265 = v3230 == 10
    del v3230
    v3266 = v3231 == 0
    del v3231
    v3267 = v3261 == 10
    del v3261
    v3268 = v3262 == 10
    del v3262
    v3269 = v3263 == 0
    del v3263
    v3270 = v3264 and v3265
    del v3264, v3265
    v3271 = v3270 and v3266
    del v3266, v3270
    v3272 = v3271 and v3267
    del v3267, v3271
    v3273 = v3272 and v3268
    del v3268, v3272
    v3274 = v3273 and v3269
    del v3269, v3273
    if v3274:
        pass
    else:
        raise Exception("typed-FX-hashed-statement-identity-lookup-runtime-mismatch")
    del v3274
    v3275 = 0 + 1
    v3276 = v3275 + 1
    del v3275
    v3277 = v3276 + 1
    del v3276
    v3278 = v3277 + 1
    del v3277
    v3279 = 0 + 1
    v3280 = v3279 + 1
    del v3279
    v3281 = v3280 + 1
    del v3280
    v3282 = v3281 + 1
    del v3281
    v3283 = v3278 == v3282
    if v3283:
        v3284 = 0
    else:
        v3284 = 1
    del v3283
    v3285 = 0 + 1
    v3286 = 0 + 1
    v3287 = v3285 == v3286
    if v3287:
        v3288 = 0
    else:
        v3288 = 1
    del v3287
    v3289 = 0 + 1
    v3290 = v3289 + 1
    del v3289
    v3291 = v3290 + 1
    del v3290
    v3292 = v3291 + 1
    del v3291
    v3293 = v3292 + 1
    del v3292
    v3294 = 0 + 1
    v3295 = v3294 + 1
    del v3294
    v3296 = v3295 + 1
    del v3295
    v3297 = v3296 + 1
    del v3296
    v3298 = v3297 + 1
    del v3297
    v3299 = v3293 == v3298
    if v3299:
        v3300 = 0
    else:
        v3300 = 1
    del v3299
    v3301 = spiral_wrap(v3285 + v3293, 64, True)
    del v3285, v3293
    v3302 = spiral_wrap(v3286 + v3298, 64, True)
    del v3286, v3298
    v3303 = spiral_wrap(v3288 + v3300, 64, True)
    del v3288, v3300
    v3304 = spiral_wrap(v3278 + v3301, 64, True)
    del v3278, v3301
    v3305 = spiral_wrap(v3282 + v3302, 64, True)
    del v3282, v3302
    v3306 = spiral_wrap(v3284 + v3303, 64, True)
    del v3284, v3303
    v3307 = 0 + 1
    v3308 = v3307 + 1
    del v3307
    v3309 = v3308 + 1
    del v3308
    v3310 = v3309 + 1
    del v3309
    v3311 = 0 + 1
    v3312 = v3311 + 1
    del v3311
    v3313 = v3312 + 1
    del v3312
    v3314 = v3313 + 1
    del v3313
    v3315 = v3310 == v3314
    if v3315:
        v3316 = 0
    else:
        v3316 = 1
    del v3315
    v3317 = 0 + 1
    v3318 = 0 + 1
    v3319 = v3317 == v3318
    if v3319:
        v3320 = 0
    else:
        v3320 = 1
    del v3319
    v3321 = 0 + 1
    v3322 = v3321 + 1
    del v3321
    v3323 = v3322 + 1
    del v3322
    v3324 = v3323 + 1
    del v3323
    v3325 = v3324 + 1
    del v3324
    v3326 = 0 + 1
    v3327 = v3326 + 1
    del v3326
    v3328 = v3327 + 1
    del v3327
    v3329 = v3328 + 1
    del v3328
    v3330 = v3329 + 1
    del v3329
    v3331 = v3325 == v3330
    if v3331:
        v3332 = 0
    else:
        v3332 = 1
    del v3331
    v3333 = spiral_wrap(v3317 + v3325, 64, True)
    del v3317, v3325
    v3334 = spiral_wrap(v3318 + v3330, 64, True)
    del v3318, v3330
    v3335 = spiral_wrap(v3320 + v3332, 64, True)
    del v3320, v3332
    v3336 = spiral_wrap(v3310 + v3333, 64, True)
    del v3310, v3333
    v3337 = spiral_wrap(v3314 + v3334, 64, True)
    del v3314, v3334
    v3338 = spiral_wrap(v3316 + v3335, 64, True)
    del v3316, v3335
    v3339 = spiral_wrap(v3304 + v3336, 64, True)
    del v3304, v3336
    v3340 = spiral_wrap(v3305 + v3337, 64, True)
    del v3305, v3337
    v3341 = spiral_wrap(v3306 + v3338, 64, True)
    del v3306, v3338
    v3342 = v3339 == 20
    del v3339
    v3343 = v3340 == 20
    del v3340
    v3344 = v3341 == 0
    del v3341
    v3345 = v3342 and v3343
    del v3342, v3343
    v3346 = v3345 and v3344
    del v3344, v3345
    if v3346:
        pass
    else:
        raise Exception("typed-FX-hashed-statement-membership-lookup-program-runtime-mismatch")
    del v3346
    v3347 = 0 + 1
    v3348 = v3347 + 1
    del v3347
    v3349 = v3348 + 1
    del v3348
    v3350 = v3349 + 1
    del v3349
    v3351 = 0 + 1
    v3352 = v3351 + 1
    del v3351
    v3353 = v3352 + 1
    del v3352
    v3354 = v3353 + 1
    del v3353
    v3355 = v3350 == v3354
    if v3355:
        v3356 = 0
    else:
        v3356 = 1
    del v3355
    v3357 = 0 + 1
    v3358 = 0 + 1
    v3359 = v3357 == v3358
    if v3359:
        v3360 = 0
    else:
        v3360 = 1
    del v3359
    v3361 = 0 + 1
    v3362 = v3361 + 1
    del v3361
    v3363 = v3362 + 1
    del v3362
    v3364 = v3363 + 1
    del v3363
    v3365 = v3364 + 1
    del v3364
    v3366 = 0 + 1
    v3367 = v3366 + 1
    del v3366
    v3368 = v3367 + 1
    del v3367
    v3369 = v3368 + 1
    del v3368
    v3370 = v3369 + 1
    del v3369
    v3371 = v3365 == v3370
    if v3371:
        v3372 = 0
    else:
        v3372 = 1
    del v3371
    v3373 = spiral_wrap(v3357 + v3365, 64, True)
    del v3357, v3365
    v3374 = spiral_wrap(v3358 + v3370, 64, True)
    del v3358, v3370
    v3375 = spiral_wrap(v3360 + v3372, 64, True)
    del v3360, v3372
    v3376 = spiral_wrap(v3350 + v3373, 64, True)
    del v3350, v3373
    v3377 = spiral_wrap(v3354 + v3374, 64, True)
    del v3354, v3374
    v3378 = spiral_wrap(v3356 + v3375, 64, True)
    del v3356, v3375
    v3379 = 0 + 1
    v3380 = v3379 + 1
    del v3379
    v3381 = v3380 + 1
    del v3380
    v3382 = v3381 + 1
    del v3381
    v3383 = 0 + 1
    v3384 = v3383 + 1
    del v3383
    v3385 = v3384 + 1
    del v3384
    v3386 = v3385 + 1
    del v3385
    v3387 = v3382 == v3386
    if v3387:
        v3388 = 0
    else:
        v3388 = 1
    del v3387
    v3389 = 0 + 1
    v3390 = 0 + 1
    v3391 = v3389 == v3390
    if v3391:
        v3392 = 0
    else:
        v3392 = 1
    del v3391
    v3393 = 0 + 1
    v3394 = v3393 + 1
    del v3393
    v3395 = v3394 + 1
    del v3394
    v3396 = v3395 + 1
    del v3395
    v3397 = v3396 + 1
    del v3396
    v3398 = 0 + 1
    v3399 = v3398 + 1
    del v3398
    v3400 = v3399 + 1
    del v3399
    v3401 = v3400 + 1
    del v3400
    v3402 = v3401 + 1
    del v3401
    v3403 = v3397 == v3402
    if v3403:
        v3404 = 0
    else:
        v3404 = 1
    del v3403
    v3405 = spiral_wrap(v3389 + v3397, 64, True)
    del v3389, v3397
    v3406 = spiral_wrap(v3390 + v3402, 64, True)
    del v3390, v3402
    v3407 = spiral_wrap(v3392 + v3404, 64, True)
    del v3392, v3404
    v3408 = spiral_wrap(v3382 + v3405, 64, True)
    del v3382, v3405
    v3409 = spiral_wrap(v3386 + v3406, 64, True)
    del v3386, v3406
    v3410 = spiral_wrap(v3388 + v3407, 64, True)
    del v3388, v3407
    v3411 = spiral_wrap(v3376 + v3408, 64, True)
    del v3376, v3408
    v3412 = spiral_wrap(v3377 + v3409, 64, True)
    del v3377, v3409
    v3413 = spiral_wrap(v3378 + v3410, 64, True)
    del v3378, v3410
    v3414 = 0 + 1
    v3415 = v3414 + 1
    del v3414
    v3416 = v3415 + 1
    del v3415
    v3417 = v3416 + 1
    del v3416
    v3418 = 0 + 1
    v3419 = v3418 + 1
    del v3418
    v3420 = v3419 + 1
    del v3419
    v3421 = v3420 + 1
    del v3420
    v3422 = v3417 == v3421
    if v3422:
        v3423 = 0
    else:
        v3423 = 1
    del v3422
    v3424 = 0 + 1
    v3425 = 0 + 1
    v3426 = v3424 == v3425
    if v3426:
        v3427 = 0
    else:
        v3427 = 1
    del v3426
    v3428 = 0 + 1
    v3429 = v3428 + 1
    del v3428
    v3430 = v3429 + 1
    del v3429
    v3431 = v3430 + 1
    del v3430
    v3432 = v3431 + 1
    del v3431
    v3433 = 0 + 1
    v3434 = v3433 + 1
    del v3433
    v3435 = v3434 + 1
    del v3434
    v3436 = v3435 + 1
    del v3435
    v3437 = v3436 + 1
    del v3436
    v3438 = v3432 == v3437
    if v3438:
        v3439 = 0
    else:
        v3439 = 1
    del v3438
    v3440 = spiral_wrap(v3424 + v3432, 64, True)
    del v3424, v3432
    v3441 = spiral_wrap(v3425 + v3437, 64, True)
    del v3425, v3437
    v3442 = spiral_wrap(v3427 + v3439, 64, True)
    del v3427, v3439
    v3443 = spiral_wrap(v3417 + v3440, 64, True)
    del v3417, v3440
    v3444 = spiral_wrap(v3421 + v3441, 64, True)
    del v3421, v3441
    v3445 = spiral_wrap(v3423 + v3442, 64, True)
    del v3423, v3442
    v3446 = 0 + 1
    v3447 = v3446 + 1
    del v3446
    v3448 = v3447 + 1
    del v3447
    v3449 = v3448 + 1
    del v3448
    v3450 = 0 + 1
    v3451 = v3450 + 1
    del v3450
    v3452 = v3451 + 1
    del v3451
    v3453 = v3452 + 1
    del v3452
    v3454 = v3449 == v3453
    if v3454:
        v3455 = 0
    else:
        v3455 = 1
    del v3454
    v3456 = 0 + 1
    v3457 = 0 + 1
    v3458 = v3456 == v3457
    if v3458:
        v3459 = 0
    else:
        v3459 = 1
    del v3458
    v3460 = 0 + 1
    v3461 = v3460 + 1
    del v3460
    v3462 = v3461 + 1
    del v3461
    v3463 = v3462 + 1
    del v3462
    v3464 = v3463 + 1
    del v3463
    v3465 = 0 + 1
    v3466 = v3465 + 1
    del v3465
    v3467 = v3466 + 1
    del v3466
    v3468 = v3467 + 1
    del v3467
    v3469 = v3468 + 1
    del v3468
    v3470 = v3464 == v3469
    if v3470:
        v3471 = 0
    else:
        v3471 = 1
    del v3470
    v3472 = spiral_wrap(v3456 + v3464, 64, True)
    del v3456, v3464
    v3473 = spiral_wrap(v3457 + v3469, 64, True)
    del v3457, v3469
    v3474 = spiral_wrap(v3459 + v3471, 64, True)
    del v3459, v3471
    v3475 = spiral_wrap(v3449 + v3472, 64, True)
    del v3449, v3472
    v3476 = spiral_wrap(v3453 + v3473, 64, True)
    del v3453, v3473
    v3477 = spiral_wrap(v3455 + v3474, 64, True)
    del v3455, v3474
    v3478 = spiral_wrap(v3443 + v3475, 64, True)
    del v3443, v3475
    v3479 = v3411 == v3478
    del v3411, v3478
    v3480 = spiral_wrap(v3444 + v3476, 64, True)
    del v3444, v3476
    v3481 = v3412 == v3480
    del v3412, v3480
    v3482 = spiral_wrap(v3445 + v3477, 64, True)
    del v3445, v3477
    v3483 = v3413 == v3482
    del v3413, v3482
    v3484 = v3479 and v3481
    del v3479, v3481
    v3485 = v3484 and v3483
    del v3483, v3484
    if v3485:
        pass
    else:
        raise Exception("typed-FX-hashed-statement-membership-lookup-program-append-runtime-mismatch")
    del v3485
    v3486 = 0 + 1
    v3487 = v3486 + 1
    del v3486
    v3488 = v3487 + 1
    del v3487
    v3489 = v3488 + 1
    del v3488
    v3490 = 0 + 1
    v3491 = v3490 + 1
    del v3490
    v3492 = v3491 + 1
    del v3491
    v3493 = v3492 + 1
    del v3492
    v3494 = v3489 == v3493
    if v3494:
        v3495 = 0
    else:
        v3495 = 1
    del v3494
    v3496 = 0 + 1
    v3497 = 0 + 1
    v3498 = v3496 == v3497
    if v3498:
        v3499 = 0
    else:
        v3499 = 1
    del v3498
    v3500 = 0 + 1
    v3501 = v3500 + 1
    del v3500
    v3502 = v3501 + 1
    del v3501
    v3503 = v3502 + 1
    del v3502
    v3504 = v3503 + 1
    del v3503
    v3505 = 0 + 1
    v3506 = v3505 + 1
    del v3505
    v3507 = v3506 + 1
    del v3506
    v3508 = v3507 + 1
    del v3507
    v3509 = v3508 + 1
    del v3508
    v3510 = v3504 == v3509
    if v3510:
        v3511 = 0
    else:
        v3511 = 1
    del v3510
    v3512 = spiral_wrap(v3496 + v3504, 64, True)
    del v3496, v3504
    v3513 = spiral_wrap(v3497 + v3509, 64, True)
    del v3497, v3509
    v3514 = spiral_wrap(v3499 + v3511, 64, True)
    del v3499, v3511
    v3515 = spiral_wrap(v3489 + v3512, 64, True)
    del v3489, v3512
    v3516 = spiral_wrap(v3493 + v3513, 64, True)
    del v3493, v3513
    v3517 = spiral_wrap(v3495 + v3514, 64, True)
    del v3495, v3514
    v3518 = 0 + 1
    v3519 = v3518 + 1
    del v3518
    v3520 = v3519 + 1
    del v3519
    v3521 = v3520 + 1
    del v3520
    v3522 = 0 + 1
    v3523 = v3522 + 1
    del v3522
    v3524 = v3523 + 1
    del v3523
    v3525 = v3524 + 1
    del v3524
    v3526 = v3521 == v3525
    if v3526:
        v3527 = 0
    else:
        v3527 = 1
    del v3526
    v3528 = 0 + 1
    v3529 = 0 + 1
    v3530 = v3528 == v3529
    if v3530:
        v3531 = 0
    else:
        v3531 = 1
    del v3530
    v3532 = 0 + 1
    v3533 = v3532 + 1
    del v3532
    v3534 = v3533 + 1
    del v3533
    v3535 = v3534 + 1
    del v3534
    v3536 = v3535 + 1
    del v3535
    v3537 = 0 + 1
    v3538 = v3537 + 1
    del v3537
    v3539 = v3538 + 1
    del v3538
    v3540 = v3539 + 1
    del v3539
    v3541 = v3540 + 1
    del v3540
    v3542 = v3536 == v3541
    if v3542:
        v3543 = 0
    else:
        v3543 = 1
    del v3542
    v3544 = spiral_wrap(v3528 + v3536, 64, True)
    del v3528, v3536
    v3545 = spiral_wrap(v3529 + v3541, 64, True)
    del v3529, v3541
    v3546 = spiral_wrap(v3531 + v3543, 64, True)
    del v3531, v3543
    v3547 = spiral_wrap(v3521 + v3544, 64, True)
    del v3521, v3544
    v3548 = spiral_wrap(v3525 + v3545, 64, True)
    del v3525, v3545
    v3549 = spiral_wrap(v3527 + v3546, 64, True)
    del v3527, v3546
    v3550 = 0 + 1
    v3551 = v3550 + 1
    del v3550
    v3552 = v3551 + 1
    del v3551
    v3553 = v3552 + 1
    del v3552
    v3554 = 0 + 1
    v3555 = v3554 + 1
    del v3554
    v3556 = v3555 + 1
    del v3555
    v3557 = v3556 + 1
    del v3556
    v3558 = v3553 == v3557
    if v3558:
        v3559 = 0
    else:
        v3559 = 1
    del v3558
    v3560 = 0 + 1
    v3561 = 0 + 1
    v3562 = v3560 == v3561
    if v3562:
        v3563 = 0
    else:
        v3563 = 1
    del v3562
    v3564 = 0 + 1
    v3565 = v3564 + 1
    del v3564
    v3566 = v3565 + 1
    del v3565
    v3567 = v3566 + 1
    del v3566
    v3568 = v3567 + 1
    del v3567
    v3569 = 0 + 1
    v3570 = v3569 + 1
    del v3569
    v3571 = v3570 + 1
    del v3570
    v3572 = v3571 + 1
    del v3571
    v3573 = v3572 + 1
    del v3572
    v3574 = v3568 == v3573
    if v3574:
        v3575 = 0
    else:
        v3575 = 1
    del v3574
    v3576 = spiral_wrap(v3560 + v3568, 64, True)
    del v3560, v3568
    v3577 = spiral_wrap(v3561 + v3573, 64, True)
    del v3561, v3573
    v3578 = spiral_wrap(v3563 + v3575, 64, True)
    del v3563, v3575
    v3579 = spiral_wrap(v3553 + v3576, 64, True)
    del v3553, v3576
    v3580 = spiral_wrap(v3557 + v3577, 64, True)
    del v3557, v3577
    v3581 = spiral_wrap(v3559 + v3578, 64, True)
    del v3559, v3578
    v3582 = 0 + 1
    v3583 = v3582 + 1
    del v3582
    v3584 = v3583 + 1
    del v3583
    v3585 = v3584 + 1
    del v3584
    v3586 = 0 + 1
    v3587 = v3586 + 1
    del v3586
    v3588 = v3587 + 1
    del v3587
    v3589 = v3588 + 1
    del v3588
    v3590 = v3585 == v3589
    if v3590:
        v3591 = 0
    else:
        v3591 = 1
    del v3590
    v3592 = 0 + 1
    v3593 = 0 + 1
    v3594 = v3592 == v3593
    if v3594:
        v3595 = 0
    else:
        v3595 = 1
    del v3594
    v3596 = 0 + 1
    v3597 = v3596 + 1
    del v3596
    v3598 = v3597 + 1
    del v3597
    v3599 = v3598 + 1
    del v3598
    v3600 = v3599 + 1
    del v3599
    v3601 = 0 + 1
    v3602 = v3601 + 1
    del v3601
    v3603 = v3602 + 1
    del v3602
    v3604 = v3603 + 1
    del v3603
    v3605 = v3604 + 1
    del v3604
    v3606 = v3600 == v3605
    if v3606:
        v3607 = 0
    else:
        v3607 = 1
    del v3606
    v3608 = spiral_wrap(v3592 + v3600, 64, True)
    del v3592, v3600
    v3609 = spiral_wrap(v3593 + v3605, 64, True)
    del v3593, v3605
    v3610 = spiral_wrap(v3595 + v3607, 64, True)
    del v3595, v3607
    v3611 = spiral_wrap(v3585 + v3608, 64, True)
    del v3585, v3608
    v3612 = spiral_wrap(v3589 + v3609, 64, True)
    del v3589, v3609
    v3613 = spiral_wrap(v3591 + v3610, 64, True)
    del v3591, v3610
    v3614 = v3515 == v3547
    del v3515, v3547
    v3615 = v3516 == v3548
    del v3516, v3548
    v3616 = v3517 == v3549
    del v3517, v3549
    v3617 = v3614 and v3615
    del v3614, v3615
    v3618 = v3617 and v3616
    del v3616, v3617
    if v3618:
        pass
    else:
        raise Exception("typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch")
    del v3618
    v3619 = v3579 == v3611
    del v3579, v3611
    v3620 = v3580 == v3612
    del v3580, v3612
    v3621 = v3581 == v3613
    del v3581, v3613
    v3622 = v3619 and v3620
    del v3619, v3620
    v3623 = v3622 and v3621
    del v3621, v3622
    if v3623:
        pass
    else:
        raise Exception("typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch")
    del v3623
    return 0

if __name__ == '__main__': sys.exit(main())
