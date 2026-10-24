#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static int8_t method0(int8_t v0){
    bool v1 = v0 == 0;
    if (v1){
        return 1;
    } else {
        return v0;
    }
}
int32_t main(){
    int8_t v0 = 100;
    int8_t v1 = method0(v0);
    bool v2 = v1 == 100;
    if (v2){
        return 0l;
    } else {
        return 1l;
    }
}
