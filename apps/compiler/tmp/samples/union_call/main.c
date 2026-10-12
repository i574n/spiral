#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    int32_t (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    int32_t (*fptr)(Closure0 *, int32_t);
    int32_t v0;
};
typedef struct {
    int tag;
    union {
        struct {
            Fun0 * v0;
        } case1; // Call
    };
} US0;
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t f_c0(Closure0 * x, int32_t v1){
    int32_t v0 = x->v0;
    
    ClosureDecref0(x);
    
    
    int32_t v2;
    v2 = v1 + v0;
    
    
    return v2;
}
Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    x->v0 = v0;
    return (Fun0 *) x;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->decref_fptr(x->case1.v0);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Missing() { // Missing
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Call(Fun0 * v0) { // Call
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    
    
    bool v2;
    v2 = true;
    
    
    US0 v5;
    if (v2){
        (v1)->refc++;
        
        v5 = US0_Call(v1);
    } else {
        
        
        v5 = US0_Missing();
    }
    
    (v1)->decref_fptr(v1);
    switch (v5.tag) {
        case 1: { // Call
            Fun0 * v6 = v5.case1.v0;
            (v6)->refc += 2;
            USDecref0(&(v5));
            int32_t v7;
            v7 = v6->fptr(v6, 4l);
            
            (v6)->decref_fptr(v6);
            bool v8;
            v8 = v7 == 7l;
            
            
            if (v8){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
        case 0: { // Missing
            
            
            USDecref0(&(v5));
            return 1l;
            break;
        }
    }
}
