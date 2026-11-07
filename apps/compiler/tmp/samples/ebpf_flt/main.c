#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    float v0 = -2.0f;
    float v1 = -1.0f;
    float v2 = 0.0f;
    bool v3 = v0 < v1;
    bool v5;
    if (v3){
        bool v4 = v1 < v2;
        v5 = v4;
    } else {
        v5 = false;
    }
    bool v8;
    if (v5){
        bool v6 = v0 > v1;
        bool v7 = v6 == false;
        v8 = v7;
    } else {
        v8 = false;
    }
    bool v11;
    if (v8){
        bool v9 = v0 >= v1;
        bool v10 = v9 == false;
        v11 = v10;
    } else {
        v11 = false;
    }
    bool v13;
    if (v11){
        bool v12 = v1 <= v2;
        v13 = v12;
    } else {
        v13 = false;
    }
    if (v13){
        return 0l;
    } else {
        return 1l;
    }
}
