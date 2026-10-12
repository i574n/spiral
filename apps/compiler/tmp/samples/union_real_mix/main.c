#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            double v0;
            int32_t v1;
        } case1; // Both
    };
} US0;
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
US0 US0_Both(double v0, int32_t v1) { // Both
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Both
            double v1 = v0.case1.v0; int32_t v2 = v0.case1.v1;
            
            USDecref0(&(v0));
            bool v3;
            v3 = v1 == 1.5;
            
            
            bool v5;
            if (v3){
                
                
                bool v4;
                v4 = v2 == 7l;
                
                
                v5 = v4;
            } else {
                
                
                v5 = false;
            }
            
            
            if (v5){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
        case 0: { // None
            
            
            USDecref0(&(v0));
            return 1l;
            break;
        }
    }
}
int32_t main(){
    
    
    double v0;
    v0 = 1.5;
    
    
    int32_t v1;
    v1 = 7l;
    
    
    bool v2;
    v2 = true;
    
    
    US0 v5;
    if (v2){
        
        
        v5 = US0_Both(v0, v1);
    } else {
        
        
        v5 = US0_None();
    }
    
    
    return score0(v5);
}
