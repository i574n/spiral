#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    float v0;
    v0 = HUGE_VALF;
    double v1;
    v1 = HUGE_VAL;
    float v2;
    v2 = 0.0f - v0 ;
    double v3;
    v3 = 0.0 - v1 ;
    float v4;
    v4 = 1.0f;
    double v5;
    v5 = 1.0;
    bool v6;
    v6 = isnan(v4);
    bool v8;
    if (v6){
        v8 = true;
    } else {
        bool v7;
        v7 = isnan(v5);
        v8 = v7;
    }
    if (v8){
        return 3l;
    } else {
        bool v9;
        v9 = v0 > v4;
        bool v11;
        if (v9){
            bool v10;
            v10 = v1 > v5;
            v11 = v10;
        } else {
            v11 = false;
        }
        if (v11){
            bool v12;
            v12 = v2 < 0.0f;
            bool v14;
            if (v12){
                bool v13;
                v13 = v3 < 0.0;
                v14 = v13;
            } else {
                v14 = false;
            }
            if (v14){
                return 0l;
            } else {
                return 2l;
            }
        } else {
            return 1l;
        }
    }
}
