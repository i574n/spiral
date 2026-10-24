#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    uint32_t v0 = 0ul;
    uint32_t v1 = v0 * v0;
    uint32_t v2 = v1 + 7ul;
    uint32_t v3 = v2 % 251ul;
    int32_t v4 = (int32_t)v3;
    return v4;
}
