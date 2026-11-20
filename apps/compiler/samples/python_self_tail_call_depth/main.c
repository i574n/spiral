#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static int32_t count_down0(int32_t v0, int32_t v1){
    while (1) {
        bool v2 = 0l < v0;
        if (v2){
            int32_t v3 = v0 - 1l;
            int32_t v4 = v1 + 1l;
            {
                int32_t tmp0 = v3;
                int32_t tmp1 = v4;
                v0 = tmp0;
                v1 = tmp1;
            }
            continue;
        } else {
            return v1;
        }
    }
}
int32_t main(){
    int32_t v0 = 5000l;
    int32_t v1 = 0l;
    int32_t v2 = count_down0(v0, v1);
    bool v3 = v2 == 5000l;
    if (v3){
        return 0l;
    } else {
        return 1l;
    }
}
