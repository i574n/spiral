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
US0 US0_Idle() { // Idle
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Hit(int32_t v0) { // Hit
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US0 US0_Flag(bool v0) { // Flag
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
int32_t main(){
    
    
    int32_t v0;
    v0 = 2l;
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    US0 v7;
    if (v1){
        
        
        v7 = US0_Idle();
    } else {
        
        
        bool v3;
        v3 = v0 == 1l;
        
        
        if (v3){
            
            
            v7 = US0_Hit(7l);
        } else {
            
            
            v7 = US0_Flag(true);
        }
    }
    USIncref0(&(v7));
    
    int32_t v8;
    v8 = score0(v7);
    
    USDecref0(&(v7));
    int32_t v9;
    v9 = v8 - 11l;
    
    
    return v9;
}
