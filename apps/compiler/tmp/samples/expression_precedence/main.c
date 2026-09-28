#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
bool method0(int32_t v0, int32_t v1){
    int32_t v2;
    v2 = -v0 ;
    bool v3;
    v3 = v2 <= 0l;
    if (v3){
        int32_t v4;
        v4 = v1 * 2l;
        int32_t v5;
        v5 = v0 + v4;
        bool v6;
        v6 = v5 >= 9l;
        if (v6){
            return true;
        } else {
            bool v7;
            v7 = v1 == 0l;
            return v7;
        }
    } else {
        return false;
    }
}
int32_t main(){
    int32_t v0;
    v0 = 3l;
    int32_t v1;
    v1 = 3l;
    bool v2;
    v2 = method0(v0, v1);
    if (v2){
        return 0l;
    } else {
        return 1l;
    }
}
