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
        } case0; // Living
    };
} US1;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case1; // Fallen
    };
} US2;
typedef struct {
    int tag;
    union {
        struct {
            US1 v0;
        } case0; // Survived
        struct {
            US2 v0;
        } case1; // Slain
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
US1 US1_Living(int32_t v0, int32_t v1) { // Living
    US1 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1;
    return x;
}
static inline void USIncrefBody2(US2 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody2(US2 * x){
    switch (x->tag) {
    }
}
void USIncref2(US2 * x){ USIncrefBody2(x); }
void USDecref2(US2 * x){ USDecrefBody2(x); }
US2 US2_Fallen(int32_t v0) { // Fallen
    US2 x;
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
        case 1: {
            USIncref2(&(x->case1.v0));
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
        case 1: {
            USDecref2(&(x->case1.v0));
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Survived(US1 v0) { // Survived
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Slain(US2 v0) { // Slain
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 60l;
    
    
    bool v1;
    v1 = v0 > 0l;
    
    
    US0 v6;
    if (v1){
        
        
        US1 v2;
        v2 = US1_Living(v0, 100l);
        
        
        v6 = US0_Survived(v2);
    } else {
        
        
        US2 v4;
        v4 = US2_Fallen(100l);
        
        
        v6 = US0_Slain(v4);
    }
    
    
    switch (v6.tag) {
        case 1: { // Slain
            
            
            USDecref0(&(v6));
            return 2l;
            break;
        }
        default: { // Survived
            US1 v7 = v6.case0.v0;
            USIncref1(&(v7));
            USDecref0(&(v6));
            switch (v7.tag) {
                default: { // Living
                    int32_t v8 = v7.case0.v0;
                    
                    USDecref1(&(v7));
                    bool v10;
                    v10 = v8 == 60l;
                    
                    
                    if (v10){
                        
                        
                        return 0l;
                    } else {
                        
                        
                        return 1l;
                    }
                    break;
                }
            }
            break;
        }
    }
}
