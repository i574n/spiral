export function main(): number {
    const v0: number = 2.7;
    const v1: number = 3.2;
    const v2: number = (-2.5);
    const v3: number = 3.5;
    const v4: number = 0.5;
    const v5: number = 1;
    const v6: number = 2.700000047683716;
    const v7: number = Math.floor(v0);
    const v8: boolean = v7 !== 2;
    if (v8) {
        return 1;
    } else {
        const v9: number = Math.ceil(v0);
        const v10: boolean = v9 !== 3;
        if (v10) {
            return 2;
        } else {
            const v11: number = Math.floor(v0);
            const v12: number = v0 - v11;
            const v13: boolean = v12 > 0.5;
            let v23: number;
            if (v13) {
                const v14: number = v11 + 1;
                v23 = v14;
            } else {
                const v15: boolean = v12 < 0.5;
                if (v15) {
                    v23 = v11;
                } else {
                    const v16: number = v11 / 2;
                    const v17: number = Math.floor(v16);
                    const v18: number = v17 * 2;
                    const v19: boolean = v18 === v11;
                    if (v19) {
                        v23 = v11;
                    } else {
                        const v20: number = v11 + 1;
                        v23 = v20;
                    }
                }
            }
            const v24: boolean = v23 !== 3;
            if (v24) {
                return 3;
            } else {
                const v25: number = Math.floor(v1);
                const v26: number = v1 - v25;
                const v27: boolean = v26 > 0.5;
                let v37: number;
                if (v27) {
                    const v28: number = v25 + 1;
                    v37 = v28;
                } else {
                    const v29: boolean = v26 < 0.5;
                    if (v29) {
                        v37 = v25;
                    } else {
                        const v30: number = v25 / 2;
                        const v31: number = Math.floor(v30);
                        const v32: number = v31 * 2;
                        const v33: boolean = v32 === v25;
                        if (v33) {
                            v37 = v25;
                        } else {
                            const v34: number = v25 + 1;
                            v37 = v34;
                        }
                    }
                }
                const v38: boolean = v37 !== 3;
                if (v38) {
                    return 4;
                } else {
                    const v39: number = Math.floor(v2);
                    const v40: number = v2 - v39;
                    const v41: boolean = v40 > 0.5;
                    let v51: number;
                    if (v41) {
                        const v42: number = v39 + 1;
                        v51 = v42;
                    } else {
                        const v43: boolean = v40 < 0.5;
                        if (v43) {
                            v51 = v39;
                        } else {
                            const v44: number = v39 / 2;
                            const v45: number = Math.floor(v44);
                            const v46: number = v45 * 2;
                            const v47: boolean = v46 === v39;
                            if (v47) {
                                v51 = v39;
                            } else {
                                const v48: number = v39 + 1;
                                v51 = v48;
                            }
                        }
                    }
                    const v52: boolean = v51 !== (-2);
                    if (v52) {
                        return 5;
                    } else {
                        const v53: number = Math.floor(v3);
                        const v54: number = v3 - v53;
                        const v55: boolean = v54 > 0.5;
                        let v65: number;
                        if (v55) {
                            const v56: number = v53 + 1;
                            v65 = v56;
                        } else {
                            const v57: boolean = v54 < 0.5;
                            if (v57) {
                                v65 = v53;
                            } else {
                                const v58: number = v53 / 2;
                                const v59: number = Math.floor(v58);
                                const v60: number = v59 * 2;
                                const v61: boolean = v60 === v53;
                                if (v61) {
                                    v65 = v53;
                                } else {
                                    const v62: number = v53 + 1;
                                    v65 = v62;
                                }
                            }
                        }
                        const v66: boolean = v65 !== 4;
                        if (v66) {
                            return 6;
                        } else {
                            const v67: number = Math.floor(v4);
                            const v68: number = v4 - v67;
                            const v69: boolean = v68 > 0.5;
                            let v79: number;
                            if (v69) {
                                const v70: number = v67 + 1;
                                v79 = v70;
                            } else {
                                const v71: boolean = v68 < 0.5;
                                if (v71) {
                                    v79 = v67;
                                } else {
                                    const v72: number = v67 / 2;
                                    const v73: number = Math.floor(v72);
                                    const v74: number = v73 * 2;
                                    const v75: boolean = v74 === v67;
                                    if (v75) {
                                        v79 = v67;
                                    } else {
                                        const v76: number = v67 + 1;
                                        v79 = v76;
                                    }
                                }
                            }
                            const v80: boolean = v79 !== 0;
                            if (v80) {
                                return 7;
                            } else {
                                const v81: number = Math.atan2(v5, v5);
                                const v82: number = v81 * 1000;
                                const v83: number = Math.floor(v82);
                                const v84: boolean = v83 !== 785;
                                if (v84) {
                                    return 8;
                                } else {
                                    const v85: number = Math.floor(v6);
                                    const v86: boolean = v85 !== 2;
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
