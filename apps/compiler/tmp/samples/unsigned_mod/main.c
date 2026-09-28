#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
bool method0(uint32_t v0){
    uint32_t v1;
    v1 = v0 + 5ul;
    uint32_t v2;
    v2 = v1 % 4ul;
    bool v3;
    v3 = v2 == 0ul;
    return v3;
}
int32_t main(){
    uint32_t v0;
    v0 = 7ul;
    bool v1;
    v1 = method0(v0);
    if (v1){
        return 0l;
    } else {
        return 1l;
    }
}
