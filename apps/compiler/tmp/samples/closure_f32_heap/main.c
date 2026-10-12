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
    float v0;
} Heap0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Heap0 * (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Heap0 * (*fptr)(Closure0 *, int32_t);
    Heap0 * v0;
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
Heap0 * HeapCreate0(float v0, String * v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    HeapDecref0(x->v0);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Heap0 * f_c0(Closure0 * x, int32_t v1){
    Heap0 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(x);
    (void)v1;
    
    
    return v0;
}
Fun0 * ClosureCreate0(Heap0 * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    x->v0 = v0;
    return (Fun0 *) x;
}
int32_t main(){
    
    
    float v0;
    v0 = 1.5f;
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    (v1)->refc++;
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    (v2)->refc++;
    StringDecref(v1);
    Fun0 * v3;
    v3 = ClosureCreate0(v2);
    (v3)->refc++;
    HeapDecref0(v2);
    Heap0 * v4;
    v4 = v3->fptr(v3, 1l);
    
    (v3)->decref_fptr(v3);
    float v5; String * v6;
    v5 = v4->v0; v6 = v4->v1;
    (v6)->refc++;
    HeapDecref0(v4);
    bool v7;
    v7 = v5 == 1.5f;
    
    
    bool v9;
    if (v7){
        
        
        bool v8;
        v8 = strcmp(v6->ptr, "hi") == 0;
        
        
        v9 = v8;
    } else {
        
        
        v9 = false;
    }
    
    StringDecref(v6);
    if (v9){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
