#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    int64_t v0 = 5000000000ll;
    int64_t v1 = -4ll;
    int64_t v2 = v0 / v1;
    int64_t v3 = 1000000ll;
    int64_t v4 = v3 * v3;
    int64_t v5 = -8ll;
    int64_t v6 = v5 >> 1l;
    int32_t v7 = 7l;
    int64_t v8 = (int64_t)v7;
    int64_t v9 = 9ll;
    int32_t v10 = (int32_t)v9;
    uint64_t v11 = 4294967296ull;
    uint64_t v12 = v11 + 1ull;
    uint64_t v13 = v11 >> 1l;
    uint64_t v14 = (uint64_t)v7;
    bool v15 = v2 == -1250000000ll;
    bool v17;
    if (v15){
        bool v16 = v4 == 1000000000000ll;
        v17 = v16;
    } else {
        v17 = false;
    }
    bool v19;
    if (v17){
        bool v18 = v6 == -4ll;
        v19 = v18;
    } else {
        v19 = false;
    }
    bool v21;
    if (v19){
        bool v20 = v8 == 7ll;
        v21 = v20;
    } else {
        v21 = false;
    }
    bool v23;
    if (v21){
        bool v22 = v10 == 9l;
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v25;
    if (v23){
        bool v24 = v12 == 4294967297ull;
        v25 = v24;
    } else {
        v25 = false;
    }
    bool v27;
    if (v25){
        bool v26 = v13 == 2147483648ull;
        v27 = v26;
    } else {
        v27 = false;
    }
    bool v29;
    if (v27){
        bool v28 = v14 == 7ull;
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29){
        return 0l;
    } else {
        return 1l;
    }
}
