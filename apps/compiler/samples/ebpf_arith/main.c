#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    int32_t v0 = 7l;
    int32_t v1 = 2l;
    uint32_t v2 = 4294967295ul;
    int32_t v3 = -v0;
    int32_t v4 = -3l;
    int32_t v5 = -12l;
    int32_t v6 = -4l;
    int32_t v7 = -1l;
    int32_t v8 = v3 / v1;
    bool v9 = v8 == v4;
    if (v9){
        int32_t v10 = v3 % v1;
        bool v11 = v10 == v7;
        if (v11){
            int32_t v12 = v3 >> 1l;
            bool v13 = v12 == v6;
            if (v13){
                int32_t v14 = v4 << 2l;
                bool v15 = v14 == v5;
                if (v15){
                    uint32_t v16 = v2 + 1ul;
                    bool v17 = v16 == 0ul;
                    if (v17){
                        uint32_t v18 = v2 * v2;
                        bool v19 = v18 == 1ul;
                        if (v19){
                            uint32_t v20 = v2 >> 28l;
                            bool v21 = v20 == 15ul;
                            if (v21){
                                return 0l;
                            } else {
                                return 7l;
                            }
                        } else {
                            return 6l;
                        }
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
