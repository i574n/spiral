export function main(): number {
    let v0: number = 2.7;
    let v1: number = 3.2;
    let v2: number = (-2.5);
    let v3: number = 3.5;
    let v4: number = 0.5;
    let v5: number = 1;
    let v6: number = 2.700000047683716;
    let v7: number = Math.floor(v0);
    let v8: boolean = v7 !== 2;
    if (v8) {
        return 1;
    } else {
        let v9: number = Math.ceil(v0);
        let v10: boolean = v9 !== 3;
        if (v10) {
            return 2;
        } else {
            let v11: number = Math.floor(v0);
            let v12: number = v0 - v11;
            let v13: boolean = v12 > 0.5;
            let v23: number;
            if (v13) {
                let v14: number = v11 + 1;
                v23 = v14;
            } else {
                let v15: boolean = v12 < 0.5;
                if (v15) {
                    v23 = v11;
                } else {
                    let v16: number = v11 / 2;
                    let v17: number = Math.floor(v16);
                    let v18: number = v17 * 2;
                    let v19: boolean = v18 === v11;
                    if (v19) {
                        v23 = v11;
                    } else {
                        let v20: number = v11 + 1;
                        v23 = v20;
                    }
                }
            }
            let v24: boolean = v23 !== 3;
            if (v24) {
                return 3;
            } else {
                let v25: number = Math.floor(v1);
                let v26: number = v1 - v25;
                let v27: boolean = v26 > 0.5;
                let v37: number;
                if (v27) {
                    let v28: number = v25 + 1;
                    v37 = v28;
                } else {
                    let v29: boolean = v26 < 0.5;
                    if (v29) {
                        v37 = v25;
                    } else {
                        let v30: number = v25 / 2;
                        let v31: number = Math.floor(v30);
                        let v32: number = v31 * 2;
                        let v33: boolean = v32 === v25;
                        if (v33) {
                            v37 = v25;
                        } else {
                            let v34: number = v25 + 1;
                            v37 = v34;
                        }
                    }
                }
                let v38: boolean = v37 !== 3;
                if (v38) {
                    return 4;
                } else {
                    let v39: number = Math.floor(v2);
                    let v40: number = v2 - v39;
                    let v41: boolean = v40 > 0.5;
                    let v51: number;
                    if (v41) {
                        let v42: number = v39 + 1;
                        v51 = v42;
                    } else {
                        let v43: boolean = v40 < 0.5;
                        if (v43) {
                            v51 = v39;
                        } else {
                            let v44: number = v39 / 2;
                            let v45: number = Math.floor(v44);
                            let v46: number = v45 * 2;
                            let v47: boolean = v46 === v39;
                            if (v47) {
                                v51 = v39;
                            } else {
                                let v48: number = v39 + 1;
                                v51 = v48;
                            }
                        }
                    }
                    let v52: boolean = v51 !== (-2);
                    if (v52) {
                        return 5;
                    } else {
                        let v53: number = Math.floor(v3);
                        let v54: number = v3 - v53;
                        let v55: boolean = v54 > 0.5;
                        let v65: number;
                        if (v55) {
                            let v56: number = v53 + 1;
                            v65 = v56;
                        } else {
                            let v57: boolean = v54 < 0.5;
                            if (v57) {
                                v65 = v53;
                            } else {
                                let v58: number = v53 / 2;
                                let v59: number = Math.floor(v58);
                                let v60: number = v59 * 2;
                                let v61: boolean = v60 === v53;
                                if (v61) {
                                    v65 = v53;
                                } else {
                                    let v62: number = v53 + 1;
                                    v65 = v62;
                                }
                            }
                        }
                        let v66: boolean = v65 !== 4;
                        if (v66) {
                            return 6;
                        } else {
                            let v67: number = Math.floor(v4);
                            let v68: number = v4 - v67;
                            let v69: boolean = v68 > 0.5;
                            let v79: number;
                            if (v69) {
                                let v70: number = v67 + 1;
                                v79 = v70;
                            } else {
                                let v71: boolean = v68 < 0.5;
                                if (v71) {
                                    v79 = v67;
                                } else {
                                    let v72: number = v67 / 2;
                                    let v73: number = Math.floor(v72);
                                    let v74: number = v73 * 2;
                                    let v75: boolean = v74 === v67;
                                    if (v75) {
                                        v79 = v67;
                                    } else {
                                        let v76: number = v67 + 1;
                                        v79 = v76;
                                    }
                                }
                            }
                            let v80: boolean = v79 !== 0;
                            if (v80) {
                                return 7;
                            } else {
                                let v81: number = Math.atan2(v5, v5);
                                let v82: number = v81 * 1000;
                                let v83: number = Math.floor(v82);
                                let v84: boolean = v83 !== 785;
                                if (v84) {
                                    return 8;
                                } else {
                                    let v85: number = Math.floor(v6);
                                    let v86: boolean = v85 !== 2;
                                    if (v86) {
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
