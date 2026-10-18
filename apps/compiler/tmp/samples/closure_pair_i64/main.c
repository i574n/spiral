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
    int64_t v0;
    String * v1;
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
    int64_t v0;
    String * v1;
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
static inline Tuple0 TupleCreate0(int64_t v0, String * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    StringDecref(x->v1);
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 f_c0(Fun0 * self, int32_t v2){
    Closure0 * x = (Closure0 *) self;
    int64_t v0 = x->v0; String * v1 = x->v1;
    (v1)->refc++;
    ClosureDecref0(self);
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        StringDecref(v1);
        String * v4;
        v4 = StringLit(3, "no");
        
        
        return TupleCreate0(0ll, v4);
    } else {
        
        
        return TupleCreate0(v0, v1);
    }
}
Fun0 * ClosureCreate0(int64_t v0, String * v1){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0; x->v1 = v1;
    return &x->base;
}
int32_t main(){
    
    
    int64_t v0;
    v0 = 5000000000ll;
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    (v1)->refc++;
    
    Fun0 * v2;
    v2 = ClosureCreate0(v0, v1);
    (v2)->refc++;
    StringDecref(v1);
    int64_t v3; String * v4;
    Tuple0 tmp0 = v2->fptr(v2, 1l);
    v3 = tmp0.v0; v4 = tmp0.v1;
    
    (v2)->decref_fptr(v2);
    bool v5;
    v5 = v3 == 5000000000ll;
    
    
    bool v7;
    if (v5){
        
        
        bool v6;
        v6 = strcmp(v4->ptr, "hi") == 0;
        
        
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
