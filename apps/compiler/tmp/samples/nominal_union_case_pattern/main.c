#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
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
US0 US0_Zero() { // Zero
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_One() { // One
    US0 x;
    x.tag = 1;
    return x;
}
int32_t main(){
    
    
    US0 v0;
    v0 = US0_Zero();
    
    
    bool v2;
    switch (v0.tag) {
        case 1: { // One
            
            
            
            v2 = false;
            break;
        }
        case 0: { // Zero
            
            
            
            v2 = true;
            break;
        }
    }
    
    USDecref0(&(v0));
    if (v2){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
