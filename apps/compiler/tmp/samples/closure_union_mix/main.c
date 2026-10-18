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
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // One
        struct {
            String * v1;
            int32_t v0;
        } case1; // Both
    };
} US0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    US0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    String * v1;
    int32_t v0;
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
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v1)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            StringDecref(x->case1.v1);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_One(int32_t v0) { // One
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Both(int32_t v0, String * v1) { // Both
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    StringDecref(x->v1);
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
US0 f_c0(Fun0 * self, int32_t v2){
    Closure0 * x = (Closure0 *) self;
    int32_t v0 = x->v0; String * v1 = x->v1;
    (v1)->refc++;
    ClosureDecref0(self);
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        StringDecref(v1);
        return US0_One(0l);
    } else {
        
        
        return US0_Both(v0, v1);
    }
}
Fun0 * ClosureCreate0(int32_t v0, String * v1){
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
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    (v1)->refc++;
    
    Fun0 * v2;
    v2 = ClosureCreate0(v0, v1);
    (v2)->refc++;
    StringDecref(v1);
    US0 v3;
    v3 = v2->fptr(v2, 1l);
    
    (v2)->decref_fptr(v2);
    switch (v3.tag) {
        case 1: { // Both
            int32_t v5 = v3.case1.v0; String * v6 = v3.case1.v1;
            (v6)->refc++;
            USDecref0(&(v3));
            bool v7;
            v7 = v5 == 3l;
            
            
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
            break;
        }
        default: { // One
            
            
            USDecref0(&(v3));
            return 1l;
            break;
        }
    }
}
