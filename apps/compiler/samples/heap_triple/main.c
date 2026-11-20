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
typedef struct {
    int refc;
    String * v1;
    int32_t v0;
    bool v2;
} Heap0;
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
static inline void HeapDecrefBody0(Heap0 * x){
    StringDecref(x->v1);
}
static void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
static Heap0 * HeapCreate0(int32_t v0, String * v1, bool v2){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
    return x;
}
int32_t main(){
    int32_t v0 = 7l;
    String * v1 = StringLit(3, "hi");
    bool v2 = true;
    (v1)->refc++;
    Heap0 * v3 = HeapCreate0(v0, v1, v2);
    StringDecref(v1);
    int32_t v4; String * v5; bool v6;
    v4 = v3->v0; v5 = v3->v1; v6 = v3->v2;
    (v5)->refc++;
    HeapDecref0(v3);
    bool v7 = v4 == 7l;
    bool v9;
    if (v7){
        bool v8 = strcmp(v5->ptr, "hi") == 0;
        v9 = v8;
    } else {
        v9 = false;
    }
    StringDecref(v5);
    bool v10 = v9 && v6;
    if (v10){
        return 0l;
    } else {
        return 1l;
    }
}
