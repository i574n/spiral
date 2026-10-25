#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static int32_t method0(bool v0){
    if (v0){
        return 1l;
    } else {
        return 3l;
    }
}
static int32_t method1(bool v0, bool v1){
    bool v2 = v0 && v1;
    if (v2){
        return 1l;
    } else {
        bool v3 = v0 || v1;
        if (v3){
            return 2l;
        } else {
            return 3l;
        }
    }
}
static int32_t method2(bool v0){
    if (v0){
        return 1l;
    } else {
        return 3l;
    }
}
int32_t main(){
    bool v0 = true;
    bool v1 = false;
    int32_t v2 = method0(v0);
    int32_t v3 = method1(v0, v1);
    int32_t v4 = method2(v1);
    bool v5 = v0 == v1;
    bool v6 = v5 == false;
    bool v7 = v2 == 1l;
    bool v9;
    if (v7){
        bool v8 = v3 == 2l;
        v9 = v8;
    } else {
        v9 = false;
    }
    bool v11;
    if (v9){
        bool v10 = v4 == 3l;
        v11 = v10;
    } else {
        v11 = false;
    }
    bool v12 = v11 && v6;
    if (v12){
        return 0l;
    } else {
        return 1l;
    }
}
