#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    double v0 = 1.5;
    double v1 = -2.0;
    double v2 = v0 / v1;
    double v3 = 1000000.0;
    double v4 = v3 * v3;
    double v5 = v4 * v3;
    double v6 = v5 * 10000.0;
    double v7 = v6 * v6;
    int32_t v8 = 3l;
    double v9 = (double)v8;
    double v10 = 2.9;
    double v11 = -1.9;
    int32_t v12 = (int32_t)v10;
    int32_t v13 = (int32_t)v11;
    float v14 = 1.5f;
    double v15 = (double)v14;
    bool v16 = v2 == -0.75;
    bool v18;
    if (v16){
        bool v17 = v7 > v6;
        v18 = v17;
    } else {
        v18 = false;
    }
    bool v21;
    if (v18){
        double v19 = v7 * v6;
        bool v20 = v7 < v19;
        v21 = v20;
    } else {
        v21 = false;
    }
    bool v23;
    if (v21){
        bool v22 = v9 == 3.0;
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v25;
    if (v23){
        bool v24 = v12 == 2l;
        v25 = v24;
    } else {
        v25 = false;
    }
    bool v27;
    if (v25){
        bool v26 = v13 == -1l;
        v27 = v26;
    } else {
        v27 = false;
    }
    bool v29;
    if (v27){
        bool v28 = v15 == 1.5;
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29){
        return 0l;
    } else {
        return 1l;
    }
}
