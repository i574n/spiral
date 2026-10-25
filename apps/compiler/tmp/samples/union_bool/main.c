#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            bool v0;
        } case0; // No
        struct {
            int32_t v0;
        } case1; // Yes
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
US0 US0_No(bool v0) { // No
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Yes(int32_t v0) { // Yes
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 0: { // No
            bool v1 = v0.case0.v0;
            
            
            if (v1){
                
                
                return 1l;
            } else {
                
                
                return 2l;
            }
            break;
        }
        default: { // Yes
            int32_t v3 = v0.case1.v0;
            
            
            return v3;
            break;
        }
    }
}
int32_t main(){
    
    
    bool v0;
    v0 = true;
    
    
    US0 v3;
    if (v0){
        
        
        v3 = US0_Yes(7l);
    } else {
        
        
        v3 = US0_No(false);
    }
    
    
    US0 v6;
    if (v0){
        
        
        v6 = US0_No(true);
    } else {
        
        
        v6 = US0_Yes(1l);
    }
    
    
    int32_t v7;
    v7 = score0(v3);
    
    
    bool v8;
    v8 = v7 == 7l;
    
    
    bool v11;
    if (v8){
        
        
        int32_t v9;
        v9 = score0(v6);
        
        
        bool v10;
        v10 = v9 == 1l;
        
        
        v11 = v10;
    } else {
        
        
        v11 = false;
    }
    
    
    if (v11){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
