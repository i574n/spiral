export function main(): number {
    let v0: number = 2.7;
    let v1: number = 3.2;
    let v2: number = (-2.5);
    let v3: number = 3.5;
    let v4: number = 0.5;
    let v5: number = 1;
    let v6: number = 2.700000047683716;
    let v17: number = Math.floor(v0);
    let v23: boolean = v17 === 2;
    let v24: boolean = v23 !== true;
    if (v24) {
        return 1;
    } else {
        let v36: number = Math.ceil(v0);
        let v42: boolean = v36 === 3;
        let v43: boolean = v42 !== true;
        if (v43) {
            return 2;
        } else {
            let v106: number = Math.floor(v0);
            let v107: number = v0 - v106;
            let v108: boolean = v107 > 0.5;
            let v118: number;
            if (v108) {
                let v109: number = v106 + 1;
                v118 = v109;
            } else {
                let v110: boolean = v107 < 0.5;
                if (v110) {
                    v118 = v106;
                } else {
                    let v111: number = v106 / 2;
                    let v112: number = Math.floor(v111);
                    let v113: number = v112 * 2;
                    let v114: boolean = v113 === v106;
                    if (v114) {
                        v118 = v106;
                    } else {
                        let v115: number = v106 + 1;
                        v118 = v115;
                    }
                }
            }
            let v172: boolean = v118 === 3;
            let v173: boolean = v172 !== true;
            if (v173) {
                return 3;
            } else {
                let v174: number = Math.floor(v1);
                let v175: number = v1 - v174;
                let v176: boolean = v175 > 0.5;
                let v186: number;
                if (v176) {
                    let v177: number = v174 + 1;
                    v186 = v177;
                } else {
                    let v178: boolean = v175 < 0.5;
                    if (v178) {
                        v186 = v174;
                    } else {
                        let v179: number = v174 / 2;
                        let v180: number = Math.floor(v179);
                        let v181: number = v180 * 2;
                        let v182: boolean = v181 === v174;
                        if (v182) {
                            v186 = v174;
                        } else {
                            let v183: number = v174 + 1;
                            v186 = v183;
                        }
                    }
                }
                let v187: boolean = v186 === 3;
                let v188: boolean = v187 !== true;
                if (v188) {
                    return 4;
                } else {
                    let v189: number = Math.floor(v2);
                    let v190: number = v2 - v189;
                    let v191: boolean = v190 > 0.5;
                    let v201: number;
                    if (v191) {
                        let v192: number = v189 + 1;
                        v201 = v192;
                    } else {
                        let v193: boolean = v190 < 0.5;
                        if (v193) {
                            v201 = v189;
                        } else {
                            let v194: number = v189 / 2;
                            let v195: number = Math.floor(v194);
                            let v196: number = v195 * 2;
                            let v197: boolean = v196 === v189;
                            if (v197) {
                                v201 = v189;
                            } else {
                                let v198: number = v189 + 1;
                                v201 = v198;
                            }
                        }
                    }
                    let v202: boolean = v201 === (-2);
                    let v203: boolean = v202 !== true;
                    if (v203) {
                        return 5;
                    } else {
                        let v204: number = Math.floor(v3);
                        let v205: number = v3 - v204;
                        let v206: boolean = v205 > 0.5;
                        let v216: number;
                        if (v206) {
                            let v207: number = v204 + 1;
                            v216 = v207;
                        } else {
                            let v208: boolean = v205 < 0.5;
                            if (v208) {
                                v216 = v204;
                            } else {
                                let v209: number = v204 / 2;
                                let v210: number = Math.floor(v209);
                                let v211: number = v210 * 2;
                                let v212: boolean = v211 === v204;
                                if (v212) {
                                    v216 = v204;
                                } else {
                                    let v213: number = v204 + 1;
                                    v216 = v213;
                                }
                            }
                        }
                        let v217: boolean = v216 === 4;
                        let v218: boolean = v217 !== true;
                        if (v218) {
                            return 6;
                        } else {
                            let v219: number = Math.floor(v4);
                            let v220: number = v4 - v219;
                            let v221: boolean = v220 > 0.5;
                            let v231: number;
                            if (v221) {
                                let v222: number = v219 + 1;
                                v231 = v222;
                            } else {
                                let v223: boolean = v220 < 0.5;
                                if (v223) {
                                    v231 = v219;
                                } else {
                                    let v224: number = v219 / 2;
                                    let v225: number = Math.floor(v224);
                                    let v226: number = v225 * 2;
                                    let v227: boolean = v226 === v219;
                                    if (v227) {
                                        v231 = v219;
                                    } else {
                                        let v228: number = v219 + 1;
                                        v231 = v228;
                                    }
                                }
                            }
                            let v232: boolean = v231 === 0;
                            let v233: boolean = v232 !== true;
                            if (v233) {
                                return 7;
                            } else {
                                let v241: number = Math.atan2(v5, v5);
                                let v247: number = v241 * 1000;
                                let v248: number = Math.floor(v247);
                                let v249: boolean = v248 === 785;
                                let v250: boolean = v249 !== true;
                                if (v250) {
                                    return 8;
                                } else {
                                    let v261: number = Math.floor(v6);
                                    let v267: boolean = v261 === 2;
                                    let v268: boolean = v267 !== true;
                                    if (v268) {
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
