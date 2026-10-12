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
        } case1; // Full
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
US0 US0_Empty() { // Empty
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Full(int32_t v0) { // Full
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t pick0(US0 v0){
    
    
    switch (v0.tag) {
        case 0: { // Empty
            
            
            USDecref0(&(v0));
            return 0l;
            break;
        }
        default: { // Full
            int32_t v1 = v0.case1.v0;
            
            USDecref0(&(v0));
            return v1;
            break;
        }
    }
}
int32_t main(){
    
    
    bool v0;
    v0 = true;
    
    
    US0 v3;
    if (v0){
        
        
        v3 = US0_Full(7l);
    } else {
        
        
        v3 = US0_Empty();
    }
    
    
    US0 v6;
    if (v0){
        
        
        v6 = US0_Empty();
    } else {
        
        
        v6 = US0_Full(1l);
    }
    USIncref0(&(v3));
    
    int32_t v7;
    v7 = pick0(v3);
    
    USDecref0(&(v3));
    bool v8;
    v8 = v7 == 7l;
    
    
    bool v11;
    if (v8){
        USIncref0(&(v6));
        
        int32_t v9;
        v9 = pick0(v6);
        
        
        bool v10;
        v10 = v9 == 0l;
        
        
        v11 = v10;
    } else {
        
        
        v11 = false;
    }
    
    USDecref0(&(v6));
    if (v11){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
