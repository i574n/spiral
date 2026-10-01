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
        } case0; // Hit
        struct {
            bool v0;
        } case1; // Flag
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
US0 US0_0(int32_t v0) { // Hit
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_1(bool v0) { // Flag
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Flag
            bool v2 = v0.case1.v0;
            
            USDecref0(&(v0));
            if (v2){
                
                
                return 9l;
            } else {
                
                
                return 4l;
            }
            break;
        }
        case 0: { // Hit
            int32_t v1 = v0.case0.v0;
            
            USDecref0(&(v0));
            return v1;
            break;
        }
    }
}
int32_t main(){
    
    
    bool v0;
    v0 = false;
    
    
    US0 v3;
    if (v0){
        
        
        v3 = US0_0(7l);
    } else {
        
        
        v3 = US0_1(true);
    }
    USIncref0(&(v3));
    
    int32_t v4;
    v4 = score0(v3);
    
    USDecref0(&(v3));
    int32_t v5;
    v5 = v4 - 9l;
    
    
    return v5;
}
