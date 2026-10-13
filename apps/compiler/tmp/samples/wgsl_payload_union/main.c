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
        } case0; // Circle
        struct {
            int32_t v0;
            int32_t v1;
        } case1; // Rect
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
US0 US0_Circle(int32_t v0) { // Circle
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Rect(int32_t v0, int32_t v1) { // Rect
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
US0 US0_Empty() { // Empty
    US0 x;
    x.tag = 2;
    return x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 2l;
    
    
    US0 v1;
    v1 = US0_Circle(v0);
    
    
    int32_t v2;
    v2 = 3l;
    
    
    int32_t v3;
    v3 = 4l;
    
    
    US0 v4;
    v4 = US0_Rect(v2, v3);
    
    
    US0 v5;
    v5 = US0_Empty();
    
    
    int32_t v6;
    v6 = 2l;
    
    
    US0 v7;
    v7 = US0_Circle(v6);
    
    
    bool v18;
    switch (v1.tag == v7.tag ? v1.tag : -1) {
        case 0: { // Circle
            int32_t v8 = v1.case0.v0;
            int32_t v9 = v7.case0.v0;
            
            
            bool v10;
            v10 = v8 == v9;
            
            
            v18 = v10;
            break;
        }
        case 2: { // Empty
            
            
            
            
            v18 = true;
            break;
        }
        case 1: { // Rect
            int32_t v11 = v1.case1.v0; int32_t v12 = v1.case1.v1;
            int32_t v13 = v7.case1.v0; int32_t v14 = v7.case1.v1;
            
            
            bool v15;
            v15 = v11 == v13;
            
            
            if (v15){
                
                
                bool v16;
                v16 = v12 == v14;
                
                
                v18 = v16;
            } else {
                
                
                v18 = false;
            }
            break;
        }
        default: {
            
            
            v18 = false;
        }
    }
    
    USDecref0(&(v7));
    int32_t v19;
    if (v18){
        
        
        v19 = 100l;
    } else {
        
        
        v19 = 0l;
    }
    
    
    int32_t v28;
    switch (v1.tag) {
        case 0: { // Circle
            int32_t v20 = v1.case0.v0;
            
            
            int32_t v21;
            v21 = 3l * v20;
            
            
            int32_t v22;
            v22 = v21 * v20;
            
            
            v28 = v22;
            break;
        }
        case 2: { // Empty
            
            
            
            v28 = 0l;
            break;
        }
        default: { // Rect
            int32_t v23 = v1.case1.v0; int32_t v24 = v1.case1.v1;
            
            
            int32_t v25;
            v25 = v23 * v24;
            
            
            v28 = v25;
            break;
        }
    }
    
    USDecref0(&(v1));
    int32_t v37;
    switch (v4.tag) {
        case 0: { // Circle
            int32_t v29 = v4.case0.v0;
            
            
            int32_t v30;
            v30 = 3l * v29;
            
            
            int32_t v31;
            v31 = v30 * v29;
            
            
            v37 = v31;
            break;
        }
        case 2: { // Empty
            
            
            
            v37 = 0l;
            break;
        }
        default: { // Rect
            int32_t v32 = v4.case1.v0; int32_t v33 = v4.case1.v1;
            
            
            int32_t v34;
            v34 = v32 * v33;
            
            
            v37 = v34;
            break;
        }
    }
    
    USDecref0(&(v4));
    int32_t v38;
    v38 = v28 + v37;
    
    
    int32_t v47;
    switch (v5.tag) {
        case 0: { // Circle
            int32_t v39 = v5.case0.v0;
            
            
            int32_t v40;
            v40 = 3l * v39;
            
            
            int32_t v41;
            v41 = v40 * v39;
            
            
            v47 = v41;
            break;
        }
        case 2: { // Empty
            
            
            
            v47 = 0l;
            break;
        }
        default: { // Rect
            int32_t v42 = v5.case1.v0; int32_t v43 = v5.case1.v1;
            
            
            int32_t v44;
            v44 = v42 * v43;
            
            
            v47 = v44;
            break;
        }
    }
    
    USDecref0(&(v5));
    int32_t v48;
    v48 = v38 + v47;
    
    
    int32_t v49;
    v49 = v48 + v19;
    
    
    return v49;
}
