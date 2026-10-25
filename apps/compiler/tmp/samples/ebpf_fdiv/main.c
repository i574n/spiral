#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    float v0 = 1.5f;
    float v1 = -2.0f;
    float v2 = -0.5f;
    float v3 = v0 / v1;
    float v4 = v2 / v1;
    bool v5 = v3 == -0.75f;
    bool v7;
    if (v5){
        bool v6 = v4 == 0.25f;
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7){
        return 0l;
    } else {
        return 1l;
    }
}
