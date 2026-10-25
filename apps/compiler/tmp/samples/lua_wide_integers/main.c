#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
uint64_t lcg0(uint64_t v0, uint64_t v1, int32_t v2, uint64_t v3){
    while (1) {
        
        
        bool v4;
        v4 = v2 == 0l;
        
        
        if (v4){
            
            
            return v3;
        } else {
            
            
            int32_t v5;
            v5 = v2 - 1l;
            
            
            uint64_t v6;
            v6 = v3 * v0;
            
            
            uint64_t v7;
            v7 = v6 + v1;
            
            
            {
                uint64_t tmp0 = v0;
                uint64_t tmp1 = v1;
                int32_t tmp2 = v5;
                uint64_t tmp3 = v7;
                v0 = tmp0;
                v1 = tmp1;
                v2 = tmp2;
                v3 = tmp3;
            }
            continue;
        }
    }
}
int32_t main(){
    
    
    uint64_t v0;
    v0 = 42ull;
    
    
    uint64_t v1;
    v1 = 6364136223846793005ull;
    
    
    uint64_t v2;
    v2 = 1442695040888963407ull;
    
    
    int32_t v3;
    v3 = 1000l;
    
    
    uint64_t v4;
    v4 = lcg0(v1, v2, v3, v0);
    
    
    
    printf("lcg %llu\n", (unsigned long long)v4);
    
    
    int64_t v5;
    v5 = 9223372036854775807ll;
    
    
    int64_t v6;
    v6 = -9223372036854775807ll;
    
    
    uint64_t v7;
    v7 = 18446744073709551615ull;
    
    
    int64_t v8;
    v8 = v6 - 1ll;
    
    
    uint64_t v9;
    v9 = v7 + 2ull;
    
    
    
    printf("max %lld min %lld wrap %llu\n", (long long)v5, (long long)v8, (unsigned long long)v9);
    
    
    int64_t v10;
    v10 = -9007199254740993ll;
    
    
    int64_t v11;
    v11 = 7ll;
    
    
    int64_t v12;
    v12 = v10 / v11;
    
    
    int64_t v13;
    v13 = v10 % v11;
    
    
    
    printf("div %lld mod %lld\n", (long long)v12, (long long)v13);
    
    
    int64_t v14;
    v14 = v10 >> 3l;
    
    
    uint64_t v15;
    v15 = v4 >> 60l;
    
    
    
    printf("shl %lld shr %lld ushr %llu\n", (long long)4611686018427387904ll, (long long)v14, (unsigned long long)v15);
    
    
    uint64_t v16;
    v16 = v4 & 18446744069414584320ull;
    
    
    int64_t v17;
    v17 = v10 | 255ll;
    
    
    uint64_t v18;
    v18 = v4 ^ v1;
    
    
    
    printf("and %llu or %lld xor %llu\n", (unsigned long long)v16, (long long)v17, (unsigned long long)v18);
    
    
    double v19;
    v19 = 1E+18;
    
    
    int64_t v20;
    v20 = (int64_t)v19;
    
    
    uint32_t v21;
    v21 = (uint32_t)v4;
    
    
    double v22;
    v22 = (double)v10;
    
    
    bool v23;
    v23 = v22 < 0.0;
    
    
    int32_t v24;
    if (v23){
        
        
        v24 = 1l;
    } else {
        
        
        v24 = 0l;
    }
    
    
    
    printf("conv %lld %u %d\n", (long long)v20, (unsigned)v21, (int)v24);
    
    
    bool v25;
    v25 = v4 > v1;
    
    
    if (v25){
        
        
        return 1l;
    } else {
        
        
        return 0l;
    }
}
