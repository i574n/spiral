#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
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
    US0 v1;
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
    int32_t v0;
};
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
static inline Tuple0 TupleCreate0(US0 v0, US0 v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 f_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    int32_t v0 = x->v0;
    
    ClosureDecref0(self);
    
    
    bool v2;
    v2 = v1 == 0l;
    
    
    if (v2){
        
        
        US0 v3;
        v3 = US0_None();
        
        
        US0 v4;
        v4 = US0_None();
        
        
        return TupleCreate0(v3, v4);
    } else {
        
        
        US0 v5;
        v5 = US0_Some(v0);
        
        
        US0 v6;
        v6 = US0_None();
        
        
        return TupleCreate0(v5, v6);
    }
}
Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0;
    return &x->base;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    (v1)->refc++;
    
    US0 v2; US0 v3;
    Tuple0 tmp0 = v1->fptr(v1, 1l);
    v2 = tmp0.v0; v3 = tmp0.v1;
    
    (v1)->decref_fptr(v1);
    switch (v2.tag) {
        case 0: { // None
            
            
            
            return 1l;
            break;
        }
        default: { // Some
            int32_t v4 = v2.case1.v0;
            
            
            switch (v3.tag) {
                case 0: { // None
                    
                    
                    
                    bool v5;
                    v5 = v4 == 7l;
                    
                    
                    if (v5){
                        
                        
                        return 0l;
                    } else {
                        
                        
                        return 1l;
                    }
                    break;
                }
                default: { // Some
                    
                    
                    
                    return 1l;
                    break;
                }
            }
            break;
        }
    }
}
