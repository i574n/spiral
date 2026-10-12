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
    int32_t v1;
} Tuple0;
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
static inline Tuple0 TupleCreate0(US0 v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method0(int32_t v0){
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    if (v1){
        
        
        US0 v2;
        v2 = US0_None();
        
        
        return TupleCreate0(v2, 0l);
    } else {
        
        
        US0 v3;
        v3 = US0_Some(v0);
        
        
        return TupleCreate0(v3, v0);
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    US0 v1; int32_t v2;
    Tuple0 tmp0 = method0(v0);
    v1 = tmp0.v0; v2 = tmp0.v1;
    
    
    switch (v1.tag) {
        case 0: { // None
            
            
            USDecref0(&(v1));
            return 1l;
            break;
        }
        default: { // Some
            int32_t v3 = v1.case1.v0;
            
            USDecref0(&(v1));
            bool v4;
            v4 = v3 == 7l;
            
            
            bool v6;
            if (v4){
                
                
                bool v5;
                v5 = v2 == 7l;
                
                
                v6 = v5;
            } else {
                
                
                v6 = false;
            }
            
            
            if (v6){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
    }
}
