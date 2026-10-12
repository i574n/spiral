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
            int32_t v1;
            int32_t v2;
        } case0; // Step
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
US0 US0_Step(int32_t v0, int32_t v1, int32_t v2) { // Step
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1; x.case0.v2 = v2;
    return x;
}
int32_t walk0(int32_t v0){
    
    
    bool v1;
    v1 = v0 > 2l;
    
    
    US0 v6;
    if (v1){
        
        
        int32_t v2;
        v2 = v0 + 1l;
        
        
        int32_t v3;
        v3 = v0 + 2l;
        
        
        v6 = US0_Step(v0, v2, v3);
    } else {
        
        
        v6 = US0_Step(0l, 1l, 2l);
    }
    
    
    switch (v6.tag) {
        default: { // Step
            int32_t v7 = v6.case0.v0; int32_t v8 = v6.case0.v1; int32_t v9 = v6.case0.v2;
            
            USDecref0(&(v6));
            int32_t v10;
            v10 = v8 * v9;
            
            
            int32_t v11;
            v11 = v7 + v10;
            
            
            return v11;
            break;
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 5l;
    
    
    int32_t v1;
    v1 = walk0(v0);
    
    
    int32_t v2;
    v2 = v0 - 4l;
    
    
    int32_t v3;
    v3 = walk0(v2);
    
    
    int32_t v4;
    v4 = v1 + v3;
    
    
    return v4;
}
