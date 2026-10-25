#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Heap0;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case1; // Some
    };
} US0;
typedef struct {
    US0 v0;
    Heap0 * v1;
} Tuple0;
static inline void HeapDecrefBody0(Heap0 * x){
    (void)x;
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(int32_t v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_None() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Some(int32_t v0) { // Some
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline Tuple0 TupleCreate0(US0 v0, Heap0 * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method0(int32_t v0, Heap0 * v1){
    
    
    US0 v2;
    v2 = US0_Some(v0);
    
    
    return TupleCreate0(v2, v1);
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    int32_t v1;
    v1 = 4l;
    
    
    Heap0 * v2;
    v2 = HeapCreate0(v1);
    (v2)->refc++;
    
    US0 v3; Heap0 * v4;
    Tuple0 tmp0 = method0(v0, v2);
    v3 = tmp0.v0; v4 = tmp0.v1;
    
    HeapDecref0(v2);
    switch (v3.tag) {
        case 0: { // None
            
            
            HeapDecref0(v4);
            return 1l;
            break;
        }
        default: { // Some
            int32_t v5 = v3.case1.v0;
            
            
            int32_t v6;
            v6 = v4->v0;
            
            HeapDecref0(v4);
            int32_t v7;
            v7 = v5 + v6;
            
            
            bool v8;
            v8 = v7 == 7l;
            
            
            if (v8){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
    }
}
