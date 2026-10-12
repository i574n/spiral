#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    double ptr[];
} Array0;
typedef struct {
    int tag;
    union {
        struct {
            Array0 * v0;
        } case1; // Held
    };
} US0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(double) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, double * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(double) * len);
    return x;
}
static inline void AssignArray0(double * a, double b){
    
    
    *a = b;
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
            ArrayDecref0(x->case1.v0);
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
US0 US0_Held(Array0 * v0) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t main(){
    
    
    Array0 * v0;
    v0 = ArrayCreate0(1l, false);
    
    
    double v1;
    v1 = 1.5;
    
    
    
    AssignArray0(&(v0->ptr[0l]), v1);
    
    
    bool v2;
    v2 = true;
    
    
    US0 v5;
    if (v2){
        (v0)->refc++;
        
        v5 = US0_Held(v0);
    } else {
        
        
        v5 = US0_Missing();
    }
    
    ArrayDecref0(v0);
    switch (v5.tag) {
        case 1: { // Held
            Array0 * v6 = v5.case1.v0;
            (v6)->refc++;
            USDecref0(&(v5));
            double v7;
            v7 = v6->ptr[0l];
            
            ArrayDecref0(v6);
            bool v8;
            v8 = v7 == 1.5;
            
            
            if (v8){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
        default: { // Missing
            
            
            USDecref0(&(v5));
            return 1l;
            break;
        }
    }
}
