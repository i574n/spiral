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
        } case0; // A
        struct {
            int32_t v0;
        } case1; // B
    };
} US1;
typedef struct {
    int tag;
    union {
        struct {
            US1 v0;
        } case0; // Wrap
        struct {
            int32_t v0;
        } case1; // Other
    };
} US0;
static inline void USIncrefBody1(US1 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody1(US1 * x){
    switch (x->tag) {
    }
}
void USIncref1(US1 * x){ USIncrefBody1(x); }
void USDecref1(US1 * x){ USDecrefBody1(x); }
US1 US1_A(int32_t v0) { // A
    US1 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US1 US1_B(int32_t v0) { // B
    US1 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            USIncref1(&(x->case0.v0));
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            USDecref1(&(x->case0.v0));
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Wrap(US1 v0) { // Wrap
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Other(int32_t v0) { // Other
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t score_inner1(US1 v0){
    
    
    switch (v0.tag) {
        case 0: { // A
            int32_t v1 = v0.case0.v0;
            
            USDecref1(&(v0));
            return v1;
            break;
        }
        case 1: { // B
            int32_t v2 = v0.case1.v0;
            
            USDecref1(&(v0));
            int32_t v3;
            v3 = -v2;
            
            
            return v3;
            break;
        }
    }
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Other
            int32_t v3 = v0.case1.v0;
            
            USDecref0(&(v0));
            return v3;
            break;
        }
        case 0: { // Wrap
            US1 v1 = v0.case0.v0;
            USIncref1(&(v1));
            USDecref0(&(v0));
            return score_inner1(v1);
            break;
        }
    }
}
int32_t main(){
    
    
    bool v0;
    v0 = true;
    
    
    US0 v4;
    if (v0){
        
        
        US1 v1;
        v1 = US1_A(7l);
        
        
        v4 = US0_Wrap(v1);
    } else {
        
        
        v4 = US0_Other(1l);
    }
    
    
    US0 v8;
    if (v0){
        
        
        v8 = US0_Other(4l);
    } else {
        
        
        US1 v6;
        v6 = US1_B(2l);
        
        
        v8 = US0_Wrap(v6);
    }
    USIncref0(&(v4));
    
    int32_t v9;
    v9 = score0(v4);
    
    USDecref0(&(v4));
    bool v10;
    v10 = v9 == 7l;
    
    
    bool v13;
    if (v10){
        USIncref0(&(v8));
        
        int32_t v11;
        v11 = score0(v8);
        
        
        bool v12;
        v12 = v11 == 4l;
        
        
        v13 = v12;
    } else {
        
        
        v13 = false;
    }
    
    USDecref0(&(v8));
    if (v13){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
