#include "main.hpp"
int main() {
    double v0;
    v0 = 2.7;
    double v1;
    v1 = 3.2;
    double v2;
    v2 = -2.5;
    double v3;
    v3 = 3.5;
    double v4;
    v4 = 0.5;
    double v5;
    v5 = 1.0;
    float v6;
    v6 = 2.7f;
    double v7;
    v7 = std::floor(v0);
    bool v8;
    v8 = v7 != 2.0;
    if (v8){
        return 1;
    } else {
        double v9;
        v9 = std::ceil(v0);
        bool v10;
        v10 = v9 != 3.0;
        if (v10){
            return 2;
        } else {
            double v11;
            v11 = std::floor(v0);
            double v12;
            v12 = v0 - v11;
            bool v13;
            v13 = v12 > 0.5;
            double v23;
            if (v13){
                double v14;
                v14 = v11 + 1.0;
                v23 = v14;
            } else {
                bool v15;
                v15 = v12 < 0.5;
                if (v15){
                    v23 = v11;
                } else {
                    double v16;
                    v16 = v11 / 2.0;
                    double v17;
                    v17 = std::floor(v16);
                    double v18;
                    v18 = v17 * 2.0;
                    bool v19;
                    v19 = v18 == v11;
                    if (v19){
                        v23 = v11;
                    } else {
                        double v20;
                        v20 = v11 + 1.0;
                        v23 = v20;
                    }
                }
            }
            bool v24;
            v24 = v23 != 3.0;
            if (v24){
                return 3;
            } else {
                double v25;
                v25 = std::floor(v1);
                double v26;
                v26 = v1 - v25;
                bool v27;
                v27 = v26 > 0.5;
                double v37;
                if (v27){
                    double v28;
                    v28 = v25 + 1.0;
                    v37 = v28;
                } else {
                    bool v29;
                    v29 = v26 < 0.5;
                    if (v29){
                        v37 = v25;
                    } else {
                        double v30;
                        v30 = v25 / 2.0;
                        double v31;
                        v31 = std::floor(v30);
                        double v32;
                        v32 = v31 * 2.0;
                        bool v33;
                        v33 = v32 == v25;
                        if (v33){
                            v37 = v25;
                        } else {
                            double v34;
                            v34 = v25 + 1.0;
                            v37 = v34;
                        }
                    }
                }
                bool v38;
                v38 = v37 != 3.0;
                if (v38){
                    return 4;
                } else {
                    double v39;
                    v39 = std::floor(v2);
                    double v40;
                    v40 = v2 - v39;
                    bool v41;
                    v41 = v40 > 0.5;
                    double v51;
                    if (v41){
                        double v42;
                        v42 = v39 + 1.0;
                        v51 = v42;
                    } else {
                        bool v43;
                        v43 = v40 < 0.5;
                        if (v43){
                            v51 = v39;
                        } else {
                            double v44;
                            v44 = v39 / 2.0;
                            double v45;
                            v45 = std::floor(v44);
                            double v46;
                            v46 = v45 * 2.0;
                            bool v47;
                            v47 = v46 == v39;
                            if (v47){
                                v51 = v39;
                            } else {
                                double v48;
                                v48 = v39 + 1.0;
                                v51 = v48;
                            }
                        }
                    }
                    bool v52;
                    v52 = v51 != -2.0;
                    if (v52){
                        return 5;
                    } else {
                        double v53;
                        v53 = std::floor(v3);
                        double v54;
                        v54 = v3 - v53;
                        bool v55;
                        v55 = v54 > 0.5;
                        double v65;
                        if (v55){
                            double v56;
                            v56 = v53 + 1.0;
                            v65 = v56;
                        } else {
                            bool v57;
                            v57 = v54 < 0.5;
                            if (v57){
                                v65 = v53;
                            } else {
                                double v58;
                                v58 = v53 / 2.0;
                                double v59;
                                v59 = std::floor(v58);
                                double v60;
                                v60 = v59 * 2.0;
                                bool v61;
                                v61 = v60 == v53;
                                if (v61){
                                    v65 = v53;
                                } else {
                                    double v62;
                                    v62 = v53 + 1.0;
                                    v65 = v62;
                                }
                            }
                        }
                        bool v66;
                        v66 = v65 != 4.0;
                        if (v66){
                            return 6;
                        } else {
                            double v67;
                            v67 = std::floor(v4);
                            double v68;
                            v68 = v4 - v67;
                            bool v69;
                            v69 = v68 > 0.5;
                            double v79;
                            if (v69){
                                double v70;
                                v70 = v67 + 1.0;
                                v79 = v70;
                            } else {
                                bool v71;
                                v71 = v68 < 0.5;
                                if (v71){
                                    v79 = v67;
                                } else {
                                    double v72;
                                    v72 = v67 / 2.0;
                                    double v73;
                                    v73 = std::floor(v72);
                                    double v74;
                                    v74 = v73 * 2.0;
                                    bool v75;
                                    v75 = v74 == v67;
                                    if (v75){
                                        v79 = v67;
                                    } else {
                                        double v76;
                                        v76 = v67 + 1.0;
                                        v79 = v76;
                                    }
                                }
                            }
                            bool v80;
                            v80 = v79 != 0.0;
                            if (v80){
                                return 7;
                            } else {
                                double v81;
                                v81 = std::atan2(v5, v5);
                                double v82;
                                v82 = v81 * 1000.0;
                                double v83;
                                v83 = std::floor(v82);
                                bool v84;
                                v84 = v83 != 785.0;
                                if (v84){
                                    return 8;
                                } else {
                                    float v85;
                                    v85 = std::floor(v6);
                                    bool v86;
                                    v86 = v85 != 2.0f;
                                    if (v86){
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
