#include "main.hpp"
int main() {
    unsigned char v0;
    v0 = 250u;
    unsigned char v1;
    v1 = 10u;
    unsigned int v2;
    v2 = 4294967295u;
    unsigned long long v3;
    v3 = 18446744073709551615ull;
    char v4;
    v4 = 127;
    char v5;
    v5 = 1;
    int v6;
    v6 = 7;
    int v7;
    v7 = 2;
    long long v8;
    v8 = 9223372036854775807ll;
    int v9;
    v9 = -v6;
    long long v10;
    v10 = -v8;
    unsigned char v11;
    v11 = v0 + v1;
    bool v12;
    v12 = v11 == 4u;
    if (v12){
        unsigned int v13;
        v13 = v2 + 1u;
        bool v14;
        v14 = v13 == 0u;
        if (v14){
            unsigned int v15;
            v15 = v2 * v2;
            bool v16;
            v16 = v15 == 1u;
            if (v16){
                unsigned long long v17;
                v17 = v3 + 1ull;
                bool v18;
                v18 = v17 == 0ull;
                if (v18){
                    unsigned long long v19;
                    v19 = v3 * v3;
                    bool v20;
                    v20 = v19 == 1ull;
                    if (v20){
                        unsigned long long v21;
                        v21 = v3 / 3ull;
                        bool v22;
                        v22 = v21 == 6148914691236517205ull;
                        if (v22){
                            char v23;
                            v23 = v4 + v5;
                            bool v24;
                            v24 = v23 < 0;
                            if (v24){
                                int v25;
                                v25 = v9 / v7;
                                bool v26;
                                v26 = v25 == -3;
                                if (v26){
                                    int v27;
                                    v27 = v9 % v7;
                                    bool v28;
                                    v28 = v27 == -1;
                                    if (v28){
                                        long long v29;
                                        v29 = v10 % 10ll;
                                        bool v30;
                                        v30 = v29 == -7ll;
                                        if (v30){
                                            unsigned int v31;
                                            v31 = v2 >> 28;
                                            bool v32;
                                            v32 = v31 == 15u;
                                            if (v32){
                                                int v33;
                                                v33 = v9 >> 1;
                                                bool v34;
                                                v34 = v33 == -4;
                                                if (v34){
                                                    return 0;
                                                } else {
                                                    return 12;
                                                }
                                            } else {
                                                return 11;
                                            }
                                        } else {
                                            return 10;
                                        }
                                    } else {
                                        return 9;
                                    }
                                } else {
                                    return 8;
                                }
                            } else {
                                return 7;
                            }
                        } else {
                            return 6;
                        }
                    } else {
                        return 5;
                    }
                } else {
                    return 4;
                }
            } else {
                return 3;
            }
        } else {
            return 2;
        }
    } else {
        return 1;
    }
}
