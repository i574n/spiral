#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static int32_t count_even0(int32_t v0, int32_t v1);
static int32_t count_odd2(int32_t v0, int32_t v1){
    bool v2 = v0 == 0l;
    if (v2){
        return v1;
    } else {
        int32_t v3 = v0 - 1l;
        return count_even0(v3, v1);
    }
}
static int32_t bump1(int32_t v0){
    bool v1 = v0 == 4l;
    if (v1){
        int32_t v2 = 0l;
        int32_t v3 = 1l;
        return count_odd2(v2, v3);
    } else {
        return 0l;
    }
}
static int32_t count_even0(int32_t v0, int32_t v1){
    bool v2 = v0 == 0l;
    if (v2){
        return v1;
    } else {
        int32_t v3 = v0 - 1l;
        int32_t v4 = bump1(v0);
        int32_t v5 = v1 + v4;
        return count_odd2(v3, v5);
    }
}
int32_t main(){
    int32_t v0 = 10l;
    int32_t v1 = 0l;
    int32_t v2 = count_even0(v0, v1);
    int32_t v3 = v2 - 1l;
    return v3;
}
