#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    int32_t v0 = -2147483648l;
    uint32_t v1 = 4294967295ul;
    int32_t v2 = -1l;
    float v3 = 0.0f;
    float v4 = 1.9f;
    float v5 = 2.9f;
    uint32_t v6 = 4294967294ul;
    uint32_t v7 = 5ul;
    uint32_t v8 = 0ul;
    float v9 = v3 - v4;
    uint32_t v10 = (uint32_t)v0;
    int32_t v11 = (int32_t)v10;
    int32_t v12 = (int32_t)v1;
    uint32_t v13 = (uint32_t)v2;
    int32_t v14 = (int32_t)v9;
    int32_t v15 = (int32_t)v5;
    uint32_t v16 = v10 / 2ul;
    uint32_t v17 = v6 / 2ul;
    uint32_t v18 = v7 % 3ul;
    uint32_t v19 = ~v8;
    uint32_t v20 = v1 >> 31l;
    bool v21 = v0 < -1l;
    bool v23;
    if (v21){
        bool v22 = v0 <= v0;
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v26;
    if (v23){
        bool v24 = v0 > 0l;
        bool v25 = v24 == false;
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26){
        bool v27 = v10 > 1ul;
        bool v29;
        if (v27){
            bool v28 = v11 == v0;
            v29 = v28;
        } else {
            v29 = false;
        }
        bool v31;
        if (v29){
            bool v30 = v12 == v2;
            v31 = v30;
        } else {
            v31 = false;
        }
        bool v33;
        if (v31){
            bool v32 = v13 == v1;
            v33 = v32;
        } else {
            v33 = false;
        }
        if (v33){
            bool v34 = v14 == v2;
            bool v36;
            if (v34){
                bool v35 = v15 == 2l;
                v36 = v35;
            } else {
                v36 = false;
            }
            if (v36){
                bool v37 = v16 == 1073741824ul;
                bool v39;
                if (v37){
                    bool v38 = v17 == 2147483647ul;
                    v39 = v38;
                } else {
                    v39 = false;
                }
                bool v41;
                if (v39){
                    bool v40 = v18 == 2ul;
                    v41 = v40;
                } else {
                    v41 = false;
                }
                if (v41){
                    bool v42 = v19 == v1;
                    bool v44;
                    if (v42){
                        bool v43 = v20 == 1ul;
                        v44 = v43;
                    } else {
                        v44 = false;
                    }
                    if (v44){
                        return 0l;
                    } else {
                        return 5l;
                    }
                } else {
                    return 4l;
                }
            } else {
                return 3l;
            }
        } else {
            return 2l;
        }
    } else {
        return 1l;
    }
}
