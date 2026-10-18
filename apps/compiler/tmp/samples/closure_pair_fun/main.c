#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    int32_t (*fptr)(Fun1 *, int32_t);
};
typedef struct {
    Fun1 * v0;
    Fun1 * v1;
} Tuple0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Tuple0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure1 Closure1;
struct Closure1 {
    Fun1 base;
    int32_t v0;
    int32_t v1;
};
typedef struct Closure2 Closure2;
struct Closure2 {
    Fun1 base;
    int32_t v0;
    int32_t v1;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    int32_t v0;
    int32_t v1;
};
static inline Tuple0 TupleCreate0(Fun1 * v0, Fun1 * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    (void)x;
}
void ClosureDecref1(Fun1 * self){
    Closure1 * x = (Closure1 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
int32_t right_c1(Fun1 * self, int32_t v2){
    Closure1 * x = (Closure1 *) self;
    int32_t v0 = x->v0; int32_t v1 = x->v1;
    
    ClosureDecref1(self);
    
    
    bool v3;
    v3 = v1 == 0l;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        int32_t v4;
        v4 = v2 + v0;
        
        
        return v4;
    }
}
Fun1 * ClosureCreate1(int32_t v0, int32_t v1){
    Closure1 * x = malloc(sizeof(Closure1));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref1;
    x->base.fptr = right_c1;
    x->v0 = v0; x->v1 = v1;
    return &x->base;
}
static inline void ClosureDecrefBody2(Closure2 * x){
    (void)x;
}
void ClosureDecref2(Fun1 * self){
    Closure2 * x = (Closure2 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody2(x); free(x); }
}
int32_t left_c2(Fun1 * self, int32_t v2){
    Closure2 * x = (Closure2 *) self;
    int32_t v0 = x->v0; int32_t v1 = x->v1;
    
    ClosureDecref2(self);
    
    
    bool v3;
    v3 = v1 == 0l;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        int32_t v4;
        v4 = v2 + v0;
        
        
        return v4;
    }
}
Fun1 * ClosureCreate2(int32_t v0, int32_t v1){
    Closure2 * x = malloc(sizeof(Closure2));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref2;
    x->base.fptr = left_c2;
    x->v0 = v0; x->v1 = v1;
    return &x->base;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 f_c0(Fun0 * self, int32_t v2){
    Closure0 * x = (Closure0 *) self;
    int32_t v0 = x->v0; int32_t v1 = x->v1;
    
    ClosureDecref0(self);
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        
        Fun1 * v4;
        v4 = ClosureCreate1(v1, v2);
        
        
        Fun1 * v5;
        v5 = ClosureCreate2(v0, v2);
        
        
        return TupleCreate0(v4, v5);
    } else {
        
        
        Fun1 * v6;
        v6 = ClosureCreate2(v0, v2);
        
        
        Fun1 * v7;
        v7 = ClosureCreate1(v1, v2);
        
        
        return TupleCreate0(v6, v7);
    }
}
Fun0 * ClosureCreate0(int32_t v0, int32_t v1){
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
    
    
    Fun0 * v2;
    v2 = ClosureCreate0(v0, v1);
    (v2)->refc++;
    
    Fun1 * v3; Fun1 * v4;
    Tuple0 tmp0 = v2->fptr(v2, 1l);
    v3 = tmp0.v0; v4 = tmp0.v1;
    (v3)->refc++;
    (v2)->decref_fptr(v2);
    int32_t v5;
    v5 = v3->fptr(v3, 0l);
    (v4)->refc++;
    (v3)->decref_fptr(v3);
    int32_t v6;
    v6 = v4->fptr(v4, 0l);
    
    (v4)->decref_fptr(v4);
    int32_t v7;
    v7 = v5 + v6;
    
    
    bool v8;
    v8 = v7 == 7l;
    
    
    if (v8){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
