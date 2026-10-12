export function main(): number {
    let v0: number = 2.7;
    let v1: number = 3.2;
    let v2: number = (-2.5);
    let v3: number = 3.5;
    let v4: number = 0.5;
    let v5: number = 1;
    let v6: number = 2.700000047683716;
    let v7: number = Math.floor(v0);
    let v8: boolean = v7 === 2;
    let v9: boolean = v8 !== true;
    if (v9) {
        return 1;
    } else {
        let v10: number = Math.ceil(v0);
        let v11: boolean = v10 === 3;
        let v12: boolean = v11 !== true;
        if (v12) {
            return 2;
        } else {
            let v13: number = Math.floor(v0);
            let v14: number = v0 - v13;
            let v15: boolean = v14 > 0.5;
            let v25: number;
            if (v15) {
                let v16: number = v13 + 1;
                v25 = v16;
            } else {
                let v17: boolean = v14 < 0.5;
                if (v17) {
                    v25 = v13;
                } else {
                    let v18: number = v13 / 2;
                    let v19: number = Math.floor(v18);
                    let v20: number = v19 * 2;
                    let v21: boolean = v20 === v13;
                    if (v21) {
                        v25 = v13;
                    } else {
                        let v22: number = v13 + 1;
                        v25 = v22;
                    }
                }
            }
            let v26: boolean = v25 === 3;
            let v27: boolean = v26 !== true;
            if (v27) {
                return 3;
            } else {
                let v28: number = Math.floor(v1);
                let v29: number = v1 - v28;
                let v30: boolean = v29 > 0.5;
                let v40: number;
                if (v30) {
                    let v31: number = v28 + 1;
                    v40 = v31;
                } else {
                    let v32: boolean = v29 < 0.5;
                    if (v32) {
                        v40 = v28;
                    } else {
                        let v33: number = v28 / 2;
                        let v34: number = Math.floor(v33);
                        let v35: number = v34 * 2;
                        let v36: boolean = v35 === v28;
                        if (v36) {
                            v40 = v28;
                        } else {
                            let v37: number = v28 + 1;
                            v40 = v37;
                        }
                    }
                }
                let v41: boolean = v40 === 3;
                let v42: boolean = v41 !== true;
                if (v42) {
                    return 4;
                } else {
                    let v43: number = Math.floor(v2);
                    let v44: number = v2 - v43;
                    let v45: boolean = v44 > 0.5;
                    let v55: number;
                    if (v45) {
                        let v46: number = v43 + 1;
                        v55 = v46;
                    } else {
                        let v47: boolean = v44 < 0.5;
                        if (v47) {
                            v55 = v43;
                        } else {
                            let v48: number = v43 / 2;
                            let v49: number = Math.floor(v48);
                            let v50: number = v49 * 2;
                            let v51: boolean = v50 === v43;
                            if (v51) {
                                v55 = v43;
                            } else {
                                let v52: number = v43 + 1;
                                v55 = v52;
                            }
                        }
                    }
                    let v56: boolean = v55 === (-2);
                    let v57: boolean = v56 !== true;
                    if (v57) {
                        return 5;
                    } else {
                        let v58: number = Math.floor(v3);
                        let v59: number = v3 - v58;
                        let v60: boolean = v59 > 0.5;
                        let v70: number;
                        if (v60) {
                            let v61: number = v58 + 1;
                            v70 = v61;
                        } else {
                            let v62: boolean = v59 < 0.5;
                            if (v62) {
                                v70 = v58;
                            } else {
                                let v63: number = v58 / 2;
                                let v64: number = Math.floor(v63);
                                let v65: number = v64 * 2;
                                let v66: boolean = v65 === v58;
                                if (v66) {
                                    v70 = v58;
                                } else {
                                    let v67: number = v58 + 1;
                                    v70 = v67;
                                }
                            }
                        }
                        let v71: boolean = v70 === 4;
                        let v72: boolean = v71 !== true;
                        if (v72) {
                            return 6;
                        } else {
                            let v73: number = Math.floor(v4);
                            let v74: number = v4 - v73;
                            let v75: boolean = v74 > 0.5;
                            let v85: number;
                            if (v75) {
                                let v76: number = v73 + 1;
                                v85 = v76;
                            } else {
                                let v77: boolean = v74 < 0.5;
                                if (v77) {
                                    v85 = v73;
                                } else {
                                    let v78: number = v73 / 2;
                                    let v79: number = Math.floor(v78);
                                    let v80: number = v79 * 2;
                                    let v81: boolean = v80 === v73;
                                    if (v81) {
                                        v85 = v73;
                                    } else {
                                        let v82: number = v73 + 1;
                                        v85 = v82;
                                    }
                                }
                            }
                            let v86: boolean = v85 === 0;
                            let v87: boolean = v86 !== true;
                            if (v87) {
                                return 7;
                            } else {
                                let v88: number = Math.atan2(v5, v5);
                                let v89: number = v88 * 1000;
                                let v90: number = Math.floor(v89);
                                let v91: boolean = v90 === 785;
                                let v92: boolean = v91 !== true;
                                if (v92) {
                                    return 8;
                                } else {
                                    let v93: number = Math.floor(v6);
                                    let v94: boolean = v93 === 2;
                                    let v95: boolean = v94 !== true;
                                    if (v95) {
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
