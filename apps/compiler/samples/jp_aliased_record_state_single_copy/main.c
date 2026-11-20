#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static int32_t walk0(int32_t v0, int32_t v1, int32_t v2){
    while (1) {
        bool v3 = v0 < 1l;
        if (v3){
            int32_t v4 = v1 + v2;
            return v4;
        } else {
            int32_t v5 = v0 - 1l;
            int32_t v6 = v1 + v0;
            int32_t v7 = v2 * 2l;
            {
                int32_t tmp0 = v5;
                int32_t tmp1 = v6;
                int32_t tmp2 = v7;
                v0 = tmp0;
                v1 = tmp1;
                v2 = tmp2;
            }
            continue;
        }
    }
}
static int32_t spiral_int_main(void){
    int32_t x_v0 = 1l;
    int32_t k_v1 = 10l;
    int32_t v2 = walk0(k_v1, x_v0, x_v0);
    int32_t v3 = v2 - 1080l;
    return v3;
}
int32_t main(){
    int32_t spiral_result = spiral_int_main();
    if (fflush(stdout) != 0 || ferror(stdout)) { return 1; }
    return spiral_result;
}
