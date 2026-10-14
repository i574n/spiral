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
        } case0; // Real
        struct {
            int32_t v0;
        } case1; // Whole
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
US0 US0_Real(double v0) { // Real
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Whole(int32_t v0) { // Whole
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t twice1(double v0){
    
    
    double v1;
    v1 = v0 * 2.0;
    
    
    int32_t v2;
    v2 = (int32_t)v1;
    
    
    return v2;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 0: { // Real
            double v1 = v0.case0.v0;
            
            
            return twice1(v1);
            break;
        }
        default: { // Whole
            int32_t v3 = v0.case1.v0;
            
            
            return v3;
            break;
        }
    }
}
int32_t main(){
    
    
    bool v0;
    v0 = true;
    
    
    double v1;
    v1 = 1.5;
    
    
    US0 v4;
    if (v0){
        
        
        v4 = US0_Real(v1);
    } else {
        
        
        v4 = US0_Whole(1l);
    }
    
    
    US0 v7;
    if (v0){
        
        
        v7 = US0_Whole(5l);
    } else {
        
        
        v7 = US0_Real(v1);
    }
    
    
    int32_t v8;
    v8 = score0(v4);
    
    
    bool v9;
    v9 = v8 == 3l;
    
    
    bool v12;
    if (v9){
        
        
        int32_t v10;
        v10 = score0(v7);
        
        
        bool v11;
        v11 = v10 == 5l;
        
        
        v12 = v11;
    } else {
        
        
        v12 = false;
    }
    
    
    if (v12){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
