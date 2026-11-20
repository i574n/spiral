#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static int32_t count0(int32_t v0){
    while (1) {
        bool v1 = v0 <= 0l;
        if (v1){
            return 0l;
        } else {
            int32_t v2 = v0 - 1l;
            {
                int32_t tmp0 = v2;
                v0 = tmp0;
            }
            continue;
        }
    }
}
int32_t main(){
    int32_t v0 = 5l;
    return count0(v0);
}
