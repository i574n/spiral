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
    bool v22;
    v22 = v16 == 2.0;
    bool v23;
    v23 = v22 != true;
    if (v23){
        return 1;
    } else {
        double v34;
        v34 = std::ceil(v0);
        bool v40;
        v40 = v34 == 3.0;
        bool v41;
        v41 = v40 != true;
        if (v41){
            return 2;
        } else {
            double v91;
            v91 = std::floor(v0);
            double v92;
            v92 = v0 - v91;
            bool v93;
            v93 = v92 > 0.5;
            double v103;
            if (v93){
                double v94;
                v94 = v91 + 1.0;
                v103 = v94;
            } else {
                bool v95;
                v95 = v92 < 0.5;
                if (v95){
                    v103 = v91;
                } else {
                    double v96;
                    v96 = v91 / 2.0;
                    double v97;
                    v97 = std::floor(v96);
                    double v98;
                    v98 = v97 * 2.0;
                    bool v99;
                    v99 = v98 == v91;
                    if (v99){
                        v103 = v91;
                    } else {
                        double v100;
                        v100 = v91 + 1.0;
                        v103 = v100;
                    }
                }
            }
            bool v169;
            v169 = v103 == 3.0;
            bool v170;
            v170 = v169 != true;
            if (v170){
                return 3;
            } else {
                double v171;
                v171 = std::floor(v1);
                double v172;
                v172 = v1 - v171;
                bool v173;
                v173 = v172 > 0.5;
                double v183;
                if (v173){
                    double v174;
                    v174 = v171 + 1.0;
                    v183 = v174;
                } else {
                    bool v175;
                    v175 = v172 < 0.5;
                    if (v175){
                        v183 = v171;
                    } else {
                        double v176;
                        v176 = v171 / 2.0;
                        double v177;
                        v177 = std::floor(v176);
                        double v178;
                        v178 = v177 * 2.0;
                        bool v179;
                        v179 = v178 == v171;
                        if (v179){
                            v183 = v171;
                        } else {
                            double v180;
                            v180 = v171 + 1.0;
                            v183 = v180;
                        }
                    }
                }
                bool v184;
                v184 = v183 == 3.0;
                bool v185;
                v185 = v184 != true;
                if (v185){
                    return 4;
                } else {
                    double v186;
                    v186 = std::floor(v2);
                    double v187;
                    v187 = v2 - v186;
                    bool v188;
                    v188 = v187 > 0.5;
                    double v198;
                    if (v188){
                        double v189;
                        v189 = v186 + 1.0;
                        v198 = v189;
                    } else {
                        bool v190;
                        v190 = v187 < 0.5;
                        if (v190){
                            v198 = v186;
                        } else {
                            double v191;
                            v191 = v186 / 2.0;
                            double v192;
                            v192 = std::floor(v191);
                            double v193;
                            v193 = v192 * 2.0;
                            bool v194;
                            v194 = v193 == v186;
                            if (v194){
                                v198 = v186;
                            } else {
                                double v195;
                                v195 = v186 + 1.0;
                                v198 = v195;
                            }
                        }
                    }
                    bool v199;
                    v199 = v198 == -2.0;
                    bool v200;
                    v200 = v199 != true;
                    if (v200){
                        return 5;
                    } else {
                        double v201;
                        v201 = std::floor(v3);
                        double v202;
                        v202 = v3 - v201;
                        bool v203;
                        v203 = v202 > 0.5;
                        double v213;
                        if (v203){
                            double v204;
                            v204 = v201 + 1.0;
                            v213 = v204;
                        } else {
                            bool v205;
                            v205 = v202 < 0.5;
                            if (v205){
                                v213 = v201;
                            } else {
                                double v206;
                                v206 = v201 / 2.0;
                                double v207;
                                v207 = std::floor(v206);
                                double v208;
                                v208 = v207 * 2.0;
                                bool v209;
                                v209 = v208 == v201;
                                if (v209){
                                    v213 = v201;
                                } else {
                                    double v210;
                                    v210 = v201 + 1.0;
                                    v213 = v210;
                                }
                            }
                        }
                        bool v214;
                        v214 = v213 == 4.0;
                        bool v215;
                        v215 = v214 != true;
                        if (v215){
                            return 6;
                        } else {
                            double v216;
                            v216 = std::floor(v4);
                            double v217;
                            v217 = v4 - v216;
                            bool v218;
                            v218 = v217 > 0.5;
                            double v228;
                            if (v218){
                                double v219;
                                v219 = v216 + 1.0;
                                v228 = v219;
                            } else {
                                bool v220;
                                v220 = v217 < 0.5;
                                if (v220){
                                    v228 = v216;
                                } else {
                                    double v221;
                                    v221 = v216 / 2.0;
                                    double v222;
                                    v222 = std::floor(v221);
                                    double v223;
                                    v223 = v222 * 2.0;
                                    bool v224;
                                    v224 = v223 == v216;
                                    if (v224){
                                        v228 = v216;
                                    } else {
                                        double v225;
                                        v225 = v216 + 1.0;
                                        v228 = v225;
                                    }
                                }
                            }
                            bool v229;
                            v229 = v228 == 0.0;
                            bool v230;
                            v230 = v229 != true;
                            if (v230){
                                return 7;
                            } else {
                                double v237;
                                v237 = std::atan2(v5, v5);
                                double v243;
                                v243 = v237 * 1000.0;
                                double v244;
                                v244 = std::floor(v243);
                                bool v245;
                                v245 = v244 == 785.0;
                                bool v246;
                                v246 = v245 != true;
                                if (v246){
                                    return 8;
                                } else {
                                    float v256;
                                    v256 = std::floor(v6);
                                    bool v262;
                                    v262 = v256 == 2.0f;
                                    bool v263;
                                    v263 = v262 != true;
                                    if (v263){
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
