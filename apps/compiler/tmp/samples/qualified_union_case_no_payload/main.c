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
US0 US0_Hit(int32_t v0) { // Hit
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Hold() { // Hold
    US0 x;
    x.tag = 1;
    return x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    US0 v1;
    v1 = US0_Hit(v0);
    
    
    US0 v2;
    v2 = US0_Hold();
    
    
    int32_t v5;
    switch (v1.tag) {
        case 0: { // Hit
            int32_t v3 = v1.case0.v0;
            
            
            v5 = v3;
            break;
        }
        default: { // Hold
            
            
            
            v5 = 40l;
            break;
        }
    }
    
    
    int32_t v8;
    switch (v2.tag) {
        case 0: { // Hit
            int32_t v6 = v2.case0.v0;
            
            
            v8 = v6;
            break;
        }
        default: { // Hold
            
            
            
            v8 = 40l;
            break;
        }
    }
    
    
    int32_t v9;
    v9 = v5 + v8;
    
    
    return v9;
}
