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
        } case1; // Square
        struct {
            int32_t v0;
        } case2; // Tri
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
US0 US0_Square(int32_t v0) { // Square
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US0 US0_Tri(int32_t v0) { // Tri
    US0 x;
    x.tag = 2;
    x.case2.v0 = v0;
    return x;
}
US0 US0_Dot() { // Dot
    US0 x;
    x.tag = 3;
    return x;
}
US0 pick0(int32_t v0){
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    if (v1){
        
        
        return US0_Circle(5l);
    } else {
        
        
        bool v3;
        v3 = v0 == 1l;
        
        
        if (v3){
            
            
            return US0_Square(4l);
        } else {
            
            
            bool v5;
            v5 = v0 == 2l;
            
            
            if (v5){
                
                
                return US0_Tri(7l);
            } else {
                
                
                return US0_Dot();
            }
        }
    }
}
int32_t measure1(US0 v0, int32_t v1){
    
    
    switch (v0.tag) {
        case 0: { // Circle
            int32_t v2 = v0.case0.v0;
            
            
            int32_t v3;
            v3 = v2 * 3l;
            
            
            return v3;
            break;
        }
        default: {
            
            
            int32_t v4;
            v4 = v1 * v1;
            
            
            bool v5;
            v5 = v4 > 3l;
            
            
            switch (v0.tag) {
                case 3: { // Dot
                    
                    
                    
                    return v4;
                    break;
                }
                case 1: { // Square
                    int32_t v6 = v0.case1.v0;
                    
                    
                    if (v5){
                        
                        
                        int32_t v7;
                        v7 = v6 * v6;
                        
                        
                        return v7;
                    } else {
                        
                        
                        return v6;
                    }
                    break;
                }
                default: { // Tri
                    int32_t v9 = v0.case2.v0;
                    
                    
                    if (v5){
                        
                        
                        int32_t v10;
                        v10 = v9 * 2l;
                        
                        
                        return v10;
                    } else {
                        
                        
                        return v9;
                    }
                    break;
                }
            }
        }
    }
}
int32_t measure_tri2(US0 v0, int32_t v1){
    
    
    switch (v0.tag) {
        case 0: { // Circle
            int32_t v2 = v0.case0.v0;
            
            
            return v2;
            break;
        }
        case 3: { // Dot
            
            
            
            return 0l;
            break;
        }
        case 1: { // Square
            int32_t v3 = v0.case1.v0;
            
            
            return v3;
            break;
        }
        default: {
            
            
            int32_t v4;
            v4 = v1 + 2l;
            
            
            switch (v0.tag) {
                default: { // Tri
                    int32_t v5 = v0.case2.v0;
                    
                    
                    int32_t v6;
                    v6 = v5 * v4;
                    
                    
                    return v6;
                    break;
                }
            }
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 0l;
    
    
    US0 v1;
    v1 = pick0(v0);
    
    
    int32_t v2;
    v2 = measure1(v1, v0);
    
    
    int32_t v3;
    v3 = v0 + 1l;
    
    
    US0 v4;
    v4 = pick0(v3);
    
    
    int32_t v5;
    v5 = measure1(v4, v3);
    
    
    int32_t v6;
    v6 = v2 + v5;
    
    
    int32_t v7;
    v7 = v0 + 2l;
    
    
    US0 v8;
    v8 = pick0(v7);
    
    
    int32_t v9;
    v9 = measure1(v8, v7);
    
    
    int32_t v10;
    v10 = v6 + v9;
    
    
    int32_t v11;
    v11 = v0 + 3l;
    
    
    US0 v12;
    v12 = pick0(v11);
    
    
    int32_t v13;
    v13 = measure1(v12, v11);
    
    
    int32_t v14;
    v14 = v10 + v13;
    
    
    US0 v15;
    v15 = pick0(v7);
    
    
    int32_t v16;
    v16 = measure_tri2(v15, v0);
    
    
    int32_t v17;
    v17 = v14 + v16;
    
    
    US0 v18;
    v18 = pick0(v0);
    
    
    int32_t v19;
    v19 = measure_tri2(v18, v0);
    
    
    int32_t v20;
    v20 = v17 + v19;
    
    
    return v20;
}
