#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static int32_t picked0(int32_t v0){
    return v0;
}
int32_t main(){
    int32_t v0 = 5l;
    int32_t v1 = picked0(v0);
    int32_t v2 = v1 + 1l;
    return v2;
}
