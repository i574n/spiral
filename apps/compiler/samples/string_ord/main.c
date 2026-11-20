#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
int32_t main(){
    String * v0 = StringLit(2, "a");
    String * v1 = StringLit(2, "b");
    String * v2 = StringLit(3, "é");
    String * v3 = StringLit(4, "éx");
    String * v4 = StringLit(1, "");
    bool v5 = strcmp(v0->ptr, v0->ptr) < 0;
    if (v5){
        StringDecref(v0); StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4);
        return 1l;
    } else {
        bool v6 = strcmp(v0->ptr, v1->ptr) < 0;
        bool v8;
        if (v6){
            bool v7 = strcmp(v1->ptr, v2->ptr) < 0;
            v8 = v7;
        } else {
            v8 = false;
        }
        bool v10;
        if (v8){
            bool v9 = strcmp(v2->ptr, v3->ptr) < 0;
            v10 = v9;
        } else {
            v10 = false;
        }
        bool v12;
        if (v10){
            bool v11 = strcmp(v4->ptr, v0->ptr) < 0;
            v12 = v11;
        } else {
            v12 = false;
        }
        StringDecref(v4);
        bool v14;
        if (v12){
            bool v13 = strcmp(v0->ptr, v0->ptr) <= 0;
            v14 = v13;
        } else {
            v14 = false;
        }
        bool v16;
        if (v14){
            bool v15 = strcmp(v0->ptr, v0->ptr) >= 0;
            v16 = v15;
        } else {
            v16 = false;
        }
        bool v18;
        if (v16){
            bool v17 = strcmp(v3->ptr, v2->ptr) > 0;
            v18 = v17;
        } else {
            v18 = false;
        }
        StringDecref(v2); StringDecref(v3);
        bool v20;
        if (v18){
            bool v19 = strcmp(v1->ptr, v0->ptr) >= 0;
            v20 = v19;
        } else {
            v20 = false;
        }
        StringDecref(v0); StringDecref(v1);
        if (v20){
            return 0l;
        } else {
            return 1l;
        }
    }
}
