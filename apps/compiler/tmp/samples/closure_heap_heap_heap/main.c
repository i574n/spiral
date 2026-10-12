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
    int refc;
    Heap0 * v0;
    int32_t v1;
} Heap1;
typedef struct {
    int refc;
    Heap1 * v0;
    int32_t v1;
} Heap2;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Heap2 * (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Heap2 * (*fptr)(Closure0 *, int32_t);
    Heap2 * v0;
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
static inline void HeapDecrefBody1(Heap1 * x){
    HeapDecref0(x->v0);
}
void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
Heap1 * HeapCreate1(Heap0 * v0, int32_t v1){
    Heap1 * x = malloc(sizeof(Heap1));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void HeapDecrefBody2(Heap2 * x){
    HeapDecref1(x->v0);
}
void HeapDecref2(Heap2 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody2(x); free(x); }
}
Heap2 * HeapCreate2(Heap1 * v0, int32_t v1){
    Heap2 * x = malloc(sizeof(Heap2));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    HeapDecref2(x->v0);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Heap2 * f_c0(Closure0 * x, int32_t v1){
    Heap2 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(x);
    
    
    bool v2;
    v2 = v1 == 0l;
    
    
    return v0;
}
Fun0 * ClosureCreate0(Heap2 * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    x->v0 = v0;
    return (Fun0 *) x;
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
    v3 = 1l;
    (v2)->refc++;
    
    Heap1 * v4;
    v4 = HeapCreate1(v2, v3);
    
    HeapDecref0(v2);
    int32_t v5;
    v5 = 2l;
    (v4)->refc++;
    
    Heap2 * v6;
    v6 = HeapCreate2(v4, v5);
    (v6)->refc++;
    HeapDecref1(v4);
    Fun0 * v7;
    v7 = ClosureCreate0(v6);
    (v7)->refc++;
    HeapDecref2(v6);
    Heap2 * v8;
    v8 = v7->fptr(v7, 1l);
    
    (v7)->decref_fptr(v7);
    Heap1 * v9; int32_t v10;
    v9 = v8->v0; v10 = v8->v1;
    (v9)->refc++;
    HeapDecref2(v8);
    Heap0 * v11; int32_t v12;
    v11 = v9->v0; v12 = v9->v1;
    (v11)->refc++;
    HeapDecref1(v9);
    int32_t v13; String * v14;
    v13 = v11->v0; v14 = v11->v1;
    (v14)->refc++;
    HeapDecref0(v11);
    bool v15;
    v15 = v13 == 7l;
    
    
    bool v17;
    if (v15){
        
        
        bool v16;
        v16 = strcmp(v14->ptr, "hi") == 0;
        
        
        v17 = v16;
    } else {
        
        
        v17 = false;
    }
    
    StringDecref(v14);
    bool v19;
    if (v17){
        
        
        bool v18;
        v18 = v12 == 1l;
        
        
        v19 = v18;
    } else {
        
        
        v19 = false;
    }
    
    
    bool v21;
    if (v19){
        
        
        bool v20;
        v20 = v10 == 2l;
        
        
        v21 = v20;
    } else {
        
        
        v21 = false;
    }
    
    
    if (v21){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
