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
    String * v1;
    uint32_t v0;
    bool v2;
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
    String * v1;
    uint32_t v0;
    bool v2;
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
static inline Tuple0 TupleCreate0(uint32_t v0, String * v1, bool v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    StringDecref(x->v1);
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 f_c0(Fun0 * self, int32_t v3){
    Closure0 * x = (Closure0 *) self;
    uint32_t v0 = x->v0; String * v1 = x->v1; bool v2 = x->v2;
    (v1)->refc++;
    ClosureDecref0(self);
    
    
    bool v4;
    v4 = v3 == 0l;
    
    
    if (v4){
        
        StringDecref(v1);
        String * v5;
        v5 = StringLit(3, "no");
        
        
        return TupleCreate0(0ul, v5, false);
    } else {
        
        
        return TupleCreate0(v0, v1, v2);
    }
}
Fun0 * ClosureCreate0(uint32_t v0, String * v1, bool v2){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
    return &x->base;
}
int32_t main(){
    
    
    uint32_t v0;
    v0 = 4000000000ul;
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    
    
    bool v2;
    v2 = true;
    (v1)->refc++;
    
    Fun0 * v3;
    v3 = ClosureCreate0(v0, v1, v2);
    (v3)->refc++;
    StringDecref(v1);
    uint32_t v4; String * v5; bool v6;
    Tuple0 tmp0 = v3->fptr(v3, 1l);
    v4 = tmp0.v0; v5 = tmp0.v1; v6 = tmp0.v2;
    
    (v3)->decref_fptr(v3);
    bool v7;
    v7 = v4 == 4000000000ul;
    
    
    bool v9;
    if (v7){
        
        
        bool v8;
        v8 = strcmp(v5->ptr, "hi") == 0;
        
        
        v9 = v8;
    } else {
        
        
        v9 = false;
    }
    
    StringDecref(v5);
    bool v10;
    v10 = v9 && v6;
    
    
    if (v10){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
