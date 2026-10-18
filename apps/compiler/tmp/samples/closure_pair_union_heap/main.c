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
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Tuple0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    Heap0 * v1;
    int32_t v0;
};
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
static inline void ClosureDecrefBody0(Closure0 * x){
    HeapDecref0(x->v1);
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 f_c0(Fun0 * self, int32_t v2){
    Closure0 * x = (Closure0 *) self;
    int32_t v0 = x->v0; Heap0 * v1 = x->v1;
    (v1)->refc++;
    ClosureDecref0(self);
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        
        US0 v4;
        v4 = US0_None();
        
        
        return TupleCreate0(v4, v1);
    } else {
        
        
        US0 v5;
        v5 = US0_Some(v0);
        
        
        return TupleCreate0(v5, v1);
    }
}
Fun0 * ClosureCreate0(int32_t v0, Heap0 * v1){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0; x->v1 = v1;
    return &x->base;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    int32_t v1;
    v1 = 4l;
    
    
    Heap0 * v2;
    v2 = HeapCreate0(v1);
    (v2)->refc++;
    
    Fun0 * v3;
    v3 = ClosureCreate0(v0, v2);
    (v3)->refc++;
    HeapDecref0(v2);
    US0 v4; Heap0 * v5;
    Tuple0 tmp0 = v3->fptr(v3, 1l);
    v4 = tmp0.v0; v5 = tmp0.v1;
    
    (v3)->decref_fptr(v3);
    switch (v4.tag) {
        case 0: { // None
            
            
            HeapDecref0(v5);
            return 1l;
            break;
        }
        default: { // Some
            int32_t v6 = v4.case1.v0;
            
            
            int32_t v7;
            v7 = v5->v0;
            
            HeapDecref0(v5);
            int32_t v8;
            v8 = v6 + v7;
            
            
            bool v9;
            v9 = v8 == 7l;
            
            
            if (v9){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
    }
}
