#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    int64_t v0;
    v0 = -5000000000ll;
    int64_t v1;
    v1 = spiral_abi_libc_llabs(v0);
    bool v2;
    v2 = v1 == 5000000000;
    if (v2){
        return 0l;
    } else {
        return 1l;
    }
}
