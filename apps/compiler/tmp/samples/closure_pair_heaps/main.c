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
} Heap0;
typedef struct {
    Heap0 * v0;
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
    Heap0 * v0;
    Heap0 * v1;
};
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
    StringDecref(x->v1);
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(int32_t v0, String * v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline Tuple0 TupleCreate0(Heap0 * v0, Heap0 * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    HeapDecref0(x->v0); HeapDecref0(x->v1);
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 f_c0(Fun0 * self, int32_t v2){
    Closure0 * x = (Closure0 *) self;
    Heap0 * v0 = x->v0; Heap0 * v1 = x->v1;
    (v0)->refc++; (v1)->refc++;
    ClosureDecref0(self);
    (void)v2;
    
    
    return TupleCreate0(v0, v1);
}
Fun0 * ClosureCreate0(Heap0 * v0, Heap0 * v1){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0; x->v1 = v1;
    return &x->base;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    (v1)->refc++;
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    
    StringDecref(v1);
    int32_t v3;
    v3 = 4l;
    
    
    String * v4;
    v4 = StringLit(3, "yo");
    (v4)->refc++;
    
    Heap0 * v5;
    v5 = HeapCreate0(v3, v4);
    (v2)->refc++; (v5)->refc++;
    StringDecref(v4);
    Fun0 * v6;
    v6 = ClosureCreate0(v2, v5);
    (v6)->refc++;
    HeapDecref0(v2); HeapDecref0(v5);
    Heap0 * v7; Heap0 * v8;
    Tuple0 tmp0 = v6->fptr(v6, 1l);
    v7 = tmp0.v0; v8 = tmp0.v1;
    
    (v6)->decref_fptr(v6);
    int32_t v9; String * v10;
    v9 = v7->v0; v10 = v7->v1;
    (v10)->refc++;
    HeapDecref0(v7);
    int32_t v11; String * v12;
    v11 = v8->v0; v12 = v8->v1;
    (v12)->refc++;
    HeapDecref0(v8);
    bool v13;
    v13 = v9 == 7l;
    
    
    bool v15;
    if (v13){
        
        
        bool v14;
        v14 = strcmp(v10->ptr, "hi") == 0;
        
        
        v15 = v14;
    } else {
        
        
        v15 = false;
    }
    
    StringDecref(v10);
    bool v17;
    if (v15){
        
        
        bool v16;
        v16 = v11 == 4l;
        
        
        v17 = v16;
    } else {
        
        
        v17 = false;
    }
    
    
    bool v19;
    if (v17){
        
        
        bool v18;
        v18 = strcmp(v12->ptr, "yo") == 0;
        
        
        v19 = v18;
    } else {
        
        
        v19 = false;
    }
    
    StringDecref(v12);
    if (v19){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
