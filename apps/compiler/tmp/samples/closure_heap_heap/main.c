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
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Heap1 * (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Heap1 * (*fptr)(Closure0 *, int32_t);
    Heap1 * v0;
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
static inline void ClosureDecrefBody0(Closure0 * x){
    HeapDecref1(x->v0);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Heap1 * f_c0(Closure0 * x, int32_t v1){
    Heap1 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(x);
    (void)v1;
    
    
    return v0;
}
Fun0 * ClosureCreate0(Heap1 * v0){
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
    (v4)->refc++;
    HeapDecref0(v2);
    Fun0 * v5;
    v5 = ClosureCreate0(v4);
    (v5)->refc++;
    HeapDecref1(v4);
    Heap1 * v6;
    v6 = v5->fptr(v5, 1l);
    
    (v5)->decref_fptr(v5);
    Heap0 * v7; int32_t v8;
    v7 = v6->v0; v8 = v6->v1;
    (v7)->refc++;
    HeapDecref1(v6);
    int32_t v9; String * v10;
    v9 = v7->v0; v10 = v7->v1;
    (v10)->refc++;
    HeapDecref0(v7);
    bool v11;
    v11 = v9 == 7l;
    
    
    bool v13;
    if (v11){
        
        
        bool v12;
        v12 = strcmp(v10->ptr, "hi") == 0;
        
        
        v13 = v12;
    } else {
        
        
        v13 = false;
    }
    
    StringDecref(v10);
    bool v15;
    if (v13){
        
        
        bool v14;
        v14 = v8 == 1l;
        
        
        v15 = v14;
    } else {
        
        
        v15 = false;
    }
    
    
    if (v15){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
