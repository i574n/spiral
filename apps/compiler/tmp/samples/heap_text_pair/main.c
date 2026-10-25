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
    String * v0;
    String * v1;
} Heap0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
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
    StringDecref(x->v0); StringDecref(x->v1);
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(String * v0, String * v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(3, "hi");
    
    
    String * v1;
    v1 = StringLit(3, "yo");
    (v0)->refc++; (v1)->refc++;
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    
    StringDecref(v0); StringDecref(v1);
    String * v3; String * v4;
    v3 = v2->v0; v4 = v2->v1;
    (v3)->refc++; (v4)->refc++;
    HeapDecref0(v2);
    bool v5;
    v5 = strcmp(v3->ptr, "hi") == 0;
    
    StringDecref(v3);
    bool v7;
    if (v5){
        
        
        bool v6;
        v6 = strcmp(v4->ptr, "yo") == 0;
        
        
        v7 = v6;
    } else {
        
        
        v7 = false;
    }
    
    StringDecref(v4);
    if (v7){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
