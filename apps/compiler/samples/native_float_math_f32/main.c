#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    float v0 = 0.0f;
    float v1 = 1.0f;
    float v2 = 4.0f;
    float v3 = 3.0f;
    float v4 = HUGE_VALF;
    float v5 = v4 - v4;
    float v6 = sqrtf(v2);
    bool v7 = v6 == 2.0f;
    bool v10;
    if (v7){
        float v8 = expf(v0);
        bool v9 = v8 == v1;
        v10 = v9;
    } else {
        v10 = false;
    }
    bool v13;
    if (v10){
        float v11 = logf(v1);
        bool v12 = v11 == v0;
        v13 = v12;
    } else {
        v13 = false;
    }
    bool v16;
    if (v13){
        float v14 = sinf(v0);
        bool v15 = v14 == v0;
        v16 = v15;
    } else {
        v16 = false;
    }
    bool v19;
    if (v16){
        float v17 = cosf(v0);
        bool v18 = v17 == v1;
        v19 = v18;
    } else {
        v19 = false;
    }
    bool v22;
    if (v19){
        float v20 = tanhf(v0);
        bool v21 = v20 == v0;
        v22 = v21;
    } else {
        v22 = false;
    }
    bool v25;
    if (v22){
        float v23 = powf(v3,v1);
        bool v24 = v23 == v3;
        v25 = v24;
    } else {
        v25 = false;
    }
    bool v27;
    if (v25){
        bool v26 = isnan(v5);
        v27 = v26;
    } else {
        v27 = false;
    }
    if (v27){
        bool v28 = isnan(v1);
        if (v28){
            return 2l;
        } else {
            return 0l;
        }
    } else {
        return 1l;
    }
}
