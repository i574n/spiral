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
    double v16;
    v16 = std::floor(v0);
    bool v23;
    v23 = v16 == 2.0;
    bool v24;
    v24 = v23 != true;
    if (v24){
        return 1;
    } else {
        double v35;
        v35 = std::ceil(v0);
        bool v42;
        v42 = v35 == 3.0;
        bool v43;
        v43 = v42 != true;
        if (v43){
            return 2;
        } else {
            double v93;
            v93 = std::floor(v0);
            double v94;
            v94 = v0 - v93;
            bool v95;
            v95 = v94 > 0.5;
            double v105;
            if (v95){
                double v96;
                v96 = v93 + 1.0;
                v105 = v96;
            } else {
                bool v97;
                v97 = v94 < 0.5;
                if (v97){
                    v105 = v93;
                } else {
                    double v98;
                    v98 = v93 / 2.0;
                    double v99;
                    v99 = std::floor(v98);
                    double v100;
                    v100 = v99 * 2.0;
                    bool v101;
                    v101 = v100 == v93;
                    if (v101){
                        v105 = v93;
                    } else {
                        double v102;
                        v102 = v93 + 1.0;
                        v105 = v102;
                    }
                }
            }
            bool v172;
            v172 = v105 == 3.0;
            bool v173;
            v173 = v172 != true;
            if (v173){
                return 3;
            } else {
                double v174;
                v174 = std::floor(v1);
                double v175;
                v175 = v1 - v174;
                bool v176;
                v176 = v175 > 0.5;
                double v186;
                if (v176){
                    double v177;
                    v177 = v174 + 1.0;
                    v186 = v177;
                } else {
                    bool v178;
                    v178 = v175 < 0.5;
                    if (v178){
                        v186 = v174;
                    } else {
                        double v179;
                        v179 = v174 / 2.0;
                        double v180;
                        v180 = std::floor(v179);
                        double v181;
                        v181 = v180 * 2.0;
                        bool v182;
                        v182 = v181 == v174;
                        if (v182){
                            v186 = v174;
                        } else {
                            double v183;
                            v183 = v174 + 1.0;
                            v186 = v183;
                        }
                    }
                }
                bool v187;
                v187 = v186 == 3.0;
                bool v188;
                v188 = v187 != true;
                if (v188){
                    return 4;
                } else {
                    double v189;
                    v189 = std::floor(v2);
                    double v190;
                    v190 = v2 - v189;
                    bool v191;
                    v191 = v190 > 0.5;
                    double v201;
                    if (v191){
                        double v192;
                        v192 = v189 + 1.0;
                        v201 = v192;
                    } else {
                        bool v193;
                        v193 = v190 < 0.5;
                        if (v193){
                            v201 = v189;
                        } else {
                            double v194;
                            v194 = v189 / 2.0;
                            double v195;
                            v195 = std::floor(v194);
                            double v196;
                            v196 = v195 * 2.0;
                            bool v197;
                            v197 = v196 == v189;
                            if (v197){
                                v201 = v189;
                            } else {
                                double v198;
                                v198 = v189 + 1.0;
                                v201 = v198;
                            }
                        }
                    }
                    bool v202;
                    v202 = v201 == -2.0;
                    bool v203;
                    v203 = v202 != true;
                    if (v203){
                        return 5;
                    } else {
                        double v204;
                        v204 = std::floor(v3);
                        double v205;
                        v205 = v3 - v204;
                        bool v206;
                        v206 = v205 > 0.5;
                        double v216;
                        if (v206){
                            double v207;
                            v207 = v204 + 1.0;
                            v216 = v207;
                        } else {
                            bool v208;
                            v208 = v205 < 0.5;
                            if (v208){
                                v216 = v204;
                            } else {
                                double v209;
                                v209 = v204 / 2.0;
                                double v210;
                                v210 = std::floor(v209);
                                double v211;
                                v211 = v210 * 2.0;
                                bool v212;
                                v212 = v211 == v204;
                                if (v212){
                                    v216 = v204;
                                } else {
                                    double v213;
                                    v213 = v204 + 1.0;
                                    v216 = v213;
                                }
                            }
                        }
                        bool v217;
                        v217 = v216 == 4.0;
                        bool v218;
                        v218 = v217 != true;
                        if (v218){
                            return 6;
                        } else {
                            double v219;
                            v219 = std::floor(v4);
                            double v220;
                            v220 = v4 - v219;
                            bool v221;
                            v221 = v220 > 0.5;
                            double v231;
                            if (v221){
                                double v222;
                                v222 = v219 + 1.0;
                                v231 = v222;
                            } else {
                                bool v223;
                                v223 = v220 < 0.5;
                                if (v223){
                                    v231 = v219;
                                } else {
                                    double v224;
                                    v224 = v219 / 2.0;
                                    double v225;
                                    v225 = std::floor(v224);
                                    double v226;
                                    v226 = v225 * 2.0;
                                    bool v227;
                                    v227 = v226 == v219;
                                    if (v227){
                                        v231 = v219;
                                    } else {
                                        double v228;
                                        v228 = v219 + 1.0;
                                        v231 = v228;
                                    }
                                }
                            }
                            bool v232;
                            v232 = v231 == 0.0;
                            bool v233;
                            v233 = v232 != true;
                            if (v233){
                                return 7;
                            } else {
                                double v240;
                                v240 = std::atan2(v5, v5);
                                double v247;
                                v247 = v240 * 1000.0;
                                double v248;
                                v248 = std::floor(v247);
                                bool v249;
                                v249 = v248 == 785.0;
                                bool v250;
                                v250 = v249 != true;
                                if (v250){
                                    return 8;
                                } else {
                                    float v260;
                                    v260 = std::floor(v6);
                                    bool v267;
                                    v267 = v260 == 2.0f;
                                    bool v268;
                                    v268 = v267 != true;
                                    if (v268){
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
