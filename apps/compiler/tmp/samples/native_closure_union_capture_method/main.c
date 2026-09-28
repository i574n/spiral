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
        } case1; // Hit
        struct {
            bool v0;
        } case2; // Flag
    };
} US0;
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
    US0 v0;
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
US0 US0_0() { // Idle
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(int32_t v0) { // Hit
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US0 US0_2(bool v0) { // Flag
    US0 x;
    x.tag = 2;
    x.case2.v0 = v0;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 2: { // Flag
            bool v2 = v0.case2.v0;
            
            USDecref0(&(v0));
            if (v2){
                
                
                return 11l;
            } else {
                
                
                return 5l;
            }
            break;
        }
        case 1: { // Hit
            int32_t v1 = v0.case1.v0;
            
            USDecref0(&(v0));
            return v1;
            break;
        }
        case 0: { // Idle
            
            
            USDecref0(&(v0));
            return 3l;
            break;
        }
    }
}
static inline void ClosureDecrefBody0(Closure0 * x){
    USDecref0(&(x->v0));
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t ClosureMethod0(Closure0 * x, int32_t v1){
    US0 v0 = x->v0;
    ClosureDecref0(x);
    USIncref0(&(v0));
    
    int32_t v2;
    v2 = score0(v0);
    
    
    int32_t v3;
    v3 = v2 + v1;
    
    
    return v3;
}
Fun0 * ClosureCreate0(US0 v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0;
    return (Fun0 *) x;
}
int32_t method1(Fun0 * v0){
    
    
    return v0->fptr(v0, 31l);
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 2l;
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    US0 v7;
    if (v1){
        
        
        v7 = US0_0();
    } else {
        
        
        bool v3;
        v3 = v0 == 1l;
        
        
        if (v3){
            
            
            v7 = US0_1(7l);
        } else {
            
            
            v7 = US0_2(true);
        }
    }
    USIncref0(&(v7));
    
    Fun0 * v8;
    v8 = ClosureCreate0(v7);
    
    USDecref0(&(v7));
    return method1(v8);
}
