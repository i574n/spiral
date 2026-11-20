#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static bool method1(int32_t v0, bool v1){
    while (1) {
        int32_t v2 = v0 - 1l;
        bool v4;
        if (v1){
            bool v3 = v0 > 0l;
            v4 = v3;
        } else {
            v4 = false;
        }
        bool v5 = v2 == 0l;
        if (v5){
            return v4;
        } else {
            {
                int32_t tmp0 = v2;
                bool tmp1 = v4;
                v0 = tmp0;
                v1 = tmp1;
            }
            continue;
        }
    }
}
static bool method0(int32_t v0){
    bool v1 = true;
    bool v2 = v0 == 0l;
    if (v2){
        return v1;
    } else {
        return method1(v0, v1);
    }
}
static bool method2(int32_t v0){
    bool v1 = false;
    bool v2 = v0 == 0l;
    if (v2){
        return v1;
    } else {
        return method1(v0, v1);
    }
}
int32_t main(){
    int32_t v0 = 3l;
    bool v1 = method0(v0);
    bool v2 = method2(v0);
    if (v1){
        if (v2){
            return 1l;
        } else {
            return 0l;
        }
    } else {
        return 2l;
    }
}
