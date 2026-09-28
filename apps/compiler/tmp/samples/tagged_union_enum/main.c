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
US0 US0_0() { // Cold
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1() { // Warm
    US0 x;
    x.tag = 1;
    return x;
}
US0 US0_2() { // Hot
    US0 x;
    x.tag = 2;
    return x;
}
US0 US0_3() { // Done
    US0 x;
    x.tag = 3;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 0: { // Cold
            
            
            USDecref0(&(v0));
            return 1l;
            break;
        }
        case 3: { // Done
            
            
            USDecref0(&(v0));
            return 4l;
            break;
        }
        case 2: { // Hot
            
            
            USDecref0(&(v0));
            return 3l;
            break;
        }
        case 1: { // Warm
            
            
            USDecref0(&(v0));
            return 2l;
            break;
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    bool v1;
    v1 = v0 == 0l ;
    
    
    US0 v10;
    if (v1){
        
        
        v10 = US0_0();
    } else {
        
        
        bool v3;
        v3 = v0 == 1l ;
        
        
        if (v3){
            
            
            v10 = US0_1();
        } else {
            
            
            bool v5;
            v5 = v0 == 2l ;
            
            
            if (v5){
                
                
                v10 = US0_2();
            } else {
                
                
                v10 = US0_3();
            }
        }
    }
    USIncref0(&(v10));
    
    int32_t v11;
    v11 = score0(v10);
    
    USDecref0(&(v10));
    int32_t v12;
    v12 = v11 - 4l ;
    
    
    return v12;
}
