#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    int64_t v0;
    v0 = 5000000007ll;
    int64_t v1;
    v1 = 1000ll;
    int64_t v2;
    v2 = spiral_abi_libc_lldiv_pack(v0,v1);
    bool v3;
    v3 = v2 == 5000000007;
    if (v3){
        return 0l;
    } else {
        return 1l;
    }
}
