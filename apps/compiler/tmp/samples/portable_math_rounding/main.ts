export function main(): number {
    let v0: number = 2.7;
    let v1: number = 3.2;
    let v2: number = (-2.5);
    let v3: number = 3.5;
    let v4: number = 0.5;
    let v5: number = 1;
    let v6: number = 2.700000047683716;
    let v17: number = Math.floor(v0);
    let v22: boolean = v17 === 2;
    let v23: boolean = v22 !== true;
    if (v23) {
        return 1;
    } else {
        let v35: number = Math.ceil(v0);
        let v40: boolean = v35 === 3;
        let v41: boolean = v40 !== true;
        if (v41) {
            return 2;
        } else {
            let v104: number = Math.floor(v0);
            let v105: number = v0 - v104;
            let v106: boolean = v105 > 0.5;
            let v116: number;
            if (v106) {
                let v107: number = v104 + 1;
                v116 = v107;
            } else {
                let v108: boolean = v105 < 0.5;
                if (v108) {
                    v116 = v104;
                } else {
                    let v109: number = v104 / 2;
                    let v110: number = Math.floor(v109);
                    let v111: number = v110 * 2;
                    let v112: boolean = v111 === v104;
                    if (v112) {
                        v116 = v104;
                    } else {
                        let v113: number = v104 + 1;
                        v116 = v113;
                    }
                }
            }
            let v169: boolean = v116 === 3;
            let v170: boolean = v169 !== true;
            if (v170) {
                return 3;
            } else {
                let v171: number = Math.floor(v1);
                let v172: number = v1 - v171;
                let v173: boolean = v172 > 0.5;
                let v183: number;
                if (v173) {
                    let v174: number = v171 + 1;
                    v183 = v174;
                } else {
                    let v175: boolean = v172 < 0.5;
                    if (v175) {
                        v183 = v171;
                    } else {
                        let v176: number = v171 / 2;
                        let v177: number = Math.floor(v176);
                        let v178: number = v177 * 2;
                        let v179: boolean = v178 === v171;
                        if (v179) {
                            v183 = v171;
                        } else {
                            let v180: number = v171 + 1;
                            v183 = v180;
                        }
                    }
                }
                let v184: boolean = v183 === 3;
                let v185: boolean = v184 !== true;
                if (v185) {
                    return 4;
                } else {
                    let v186: number = Math.floor(v2);
                    let v187: number = v2 - v186;
                    let v188: boolean = v187 > 0.5;
                    let v198: number;
                    if (v188) {
                        let v189: number = v186 + 1;
                        v198 = v189;
                    } else {
                        let v190: boolean = v187 < 0.5;
                        if (v190) {
                            v198 = v186;
                        } else {
                            let v191: number = v186 / 2;
                            let v192: number = Math.floor(v191);
                            let v193: number = v192 * 2;
                            let v194: boolean = v193 === v186;
                            if (v194) {
                                v198 = v186;
                            } else {
                                let v195: number = v186 + 1;
                                v198 = v195;
                            }
                        }
                    }
                    let v199: boolean = v198 === (-2);
                    let v200: boolean = v199 !== true;
                    if (v200) {
                        return 5;
                    } else {
                        let v201: number = Math.floor(v3);
                        let v202: number = v3 - v201;
                        let v203: boolean = v202 > 0.5;
                        let v213: number;
                        if (v203) {
                            let v204: number = v201 + 1;
                            v213 = v204;
                        } else {
                            let v205: boolean = v202 < 0.5;
                            if (v205) {
                                v213 = v201;
                            } else {
                                let v206: number = v201 / 2;
                                let v207: number = Math.floor(v206);
                                let v208: number = v207 * 2;
                                let v209: boolean = v208 === v201;
                                if (v209) {
                                    v213 = v201;
                                } else {
                                    let v210: number = v201 + 1;
                                    v213 = v210;
                                }
                            }
                        }
                        let v214: boolean = v213 === 4;
                        let v215: boolean = v214 !== true;
                        if (v215) {
                            return 6;
                        } else {
                            let v216: number = Math.floor(v4);
                            let v217: number = v4 - v216;
                            let v218: boolean = v217 > 0.5;
                            let v228: number;
                            if (v218) {
                                let v219: number = v216 + 1;
                                v228 = v219;
                            } else {
                                let v220: boolean = v217 < 0.5;
                                if (v220) {
                                    v228 = v216;
                                } else {
                                    let v221: number = v216 / 2;
                                    let v222: number = Math.floor(v221);
                                    let v223: number = v222 * 2;
                                    let v224: boolean = v223 === v216;
                                    if (v224) {
                                        v228 = v216;
                                    } else {
                                        let v225: number = v216 + 1;
                                        v228 = v225;
                                    }
                                }
                            }
                            let v229: boolean = v228 === 0;
                            let v230: boolean = v229 !== true;
                            if (v230) {
                                return 7;
                            } else {
                                let v238: number = Math.atan2(v5, v5);
                                let v243: number = v238 * 1000;
                                let v244: number = Math.floor(v243);
                                let v245: boolean = v244 === 785;
                                let v246: boolean = v245 !== true;
                                if (v246) {
                                    return 8;
                                } else {
                                    let v257: number = Math.floor(v6);
                                    let v262: boolean = v257 === 2;
                                    let v263: boolean = v262 !== true;
                                    if (v263) {
                                        return 9;
                                    } else {
                                        return 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
process.exitCode = main();
