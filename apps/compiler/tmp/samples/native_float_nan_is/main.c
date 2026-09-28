#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    float v1;
    v1 = nanf("");
    double v5;
    v5 = nan("");
    float v8;
    v8 = 1.0f;
    double v9;
    v9 = 1.0;
    bool v10;
    v10 = isnan(v1);
    bool v12;
    if (v10){
        bool v11;
        v11 = isnan(v5);
        v12 = v11;
    } else {
        v12 = false;
    }
    if (v12){
        bool v13;
        v13 = isnan(v8);
        bool v15;
        if (v13){
            v15 = true;
        } else {
            bool v14;
            v14 = isnan(v9);
            v15 = v14;
        }
        if (v15){
            return 2l;
        } else {
            return 0l;
        }
    } else {
        return 1l;
    }
}
