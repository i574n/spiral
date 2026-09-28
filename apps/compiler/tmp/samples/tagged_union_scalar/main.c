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
            int32_t v0;
        } case1; // Miss
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
US0 US0_1(int32_t v0) { // Miss
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 0: { // Hit
            int32_t v1 = v0.case0.v0;
            
            USDecref0(&(v0));
            return v1;
            break;
        }
        case 1: { // Miss
            int32_t v2 = v0.case1.v0;
            
            USDecref0(&(v0));
            int32_t v3;
            v3 = 0l - v2 ;
            
            
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
        
        
        v3 = US0_0(7l);
    } else {
        
        
        v3 = US0_1(3l);
    }
    USIncref0(&(v3));
    
    int32_t v4;
    v4 = score0(v3);
    
    USDecref0(&(v3));
    int32_t v5;
    v5 = v4 - 7l ;
    
    
    return v5;
}
