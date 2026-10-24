#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static float method1(int32_t v0, float v1){
    while (1) {
        int32_t v2 = v0 - 1l;
        float v3 = v1 + 1.5f;
        bool v4 = v2 == 0l;
        if (v4){
            return v3;
        } else {
            {
                int32_t tmp0 = v2;
                float tmp1 = v3;
                v0 = tmp0;
                v1 = tmp1;
            }
            continue;
        }
    }
}
static float method0(int32_t v0, float v1){
    bool v2 = v0 == 0l;
    if (v2){
        return v1;
    } else {
        return method1(v0, v1);
    }
}
int32_t main(){
    int32_t v0 = 4l;
    float v1 = 0.0f;
    float v2 = method0(v0, v1);
    bool v3 = v2 == 6.0f;
    if (v3){
        return 0l;
    } else {
        return 1l;
    }
}
