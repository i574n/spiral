#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Mut0;
typedef struct {
    int tag;
    union {
        struct {
            Mut0 * v0;
        } case1; // Held
    };
} US0;
static inline void MutDecrefBody0(Mut0 * x){
    (void)x;
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(int32_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            MutDecref0(x->case1.v0);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Missing() { // Missing
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Held(Mut0 * v0) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void AssignMut0(int32_t * a0, int32_t b0){
    
    
    *a0 = b0;
}
int32_t main(){
    
    
    Mut0 * v0;
    v0 = MutCreate0(1l);
    
    
    bool v1;
    v1 = true;
    
    
    US0 v4;
    if (v1){
        (v0)->refc++;
        
        v4 = US0_Held(v0);
    } else {
        
        
        v4 = US0_Missing();
    }
    
    MutDecref0(v0);
    switch (v4.tag) {
        case 1: { // Held
            Mut0 * v5 = v4.case1.v0;
            (v5)->refc++;
            USDecref0(&(v4));
            
            AssignMut0(&(v5->v0), 7l);
            
            
            int32_t v6;
            v6 = v5->v0;
            
            MutDecref0(v5);
            bool v7;
            v7 = v6 == 7l;
            
            
            if (v7){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
        case 0: { // Missing
            
            
            USDecref0(&(v4));
            return 1l;
            break;
        }
    }
}
