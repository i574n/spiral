#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            char v0;
        } case0; // Some
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
US0 US0_0(char v0) { // Some
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_1() { // None
    US0 x;
    x.tag = 1;
    return x;
}
bool 루프0(char v0, int64_t v1){
    
    
    bool v2;
    v2 = v1 >= 2ll;
    
    
    if (v2){
        
        
        return false;
    } else {
        
        
        bool v3;
        v3 = v1 == 0ll;
        
        
        US0 v11;
        if (v3){
            
            
            v11 = US0_0(' ');
        } else {
            
            
            int64_t v5;
            v5 = v1 - 1ll;
            
            
            bool v6;
            v6 = v5 == 0ll;
            
            
            if (v6){
                
                
                v11 = US0_0('/');
            } else {
                
                
                int64_t v8;
                v8 = v5 - 1ll;
                
                
                v11 = US0_1();
            }
        }
        
        
        char v15;
        switch (v11.tag) {
            case 1: { // None
                
                
                
                fprintf(stderr, "%s\n", "Option does not have a value.");
                exit(EXIT_FAILURE);
                break;
            }
            case 0: { // Some
                char v12 = v11.case0.v0;
                
                
                v15 = v12;
                break;
            }
        }
        
        USDecref0(&(v11));
        bool v16;
        v16 = v0 == v15;
        
        
        if (v16){
            
            
            return true;
        } else {
            
            
            int64_t v17;
            v17 = v1 + 1ll;
            
            
            return 루프0(v0, v17);
        }
    }
}
int32_t main(){
    
    
    char v0;
    v0 = 'x';
    
    
    int64_t v1;
    v1 = 0ll;
    
    
    bool v2;
    v2 = 루프0(v0, v1);
    
    
    if (v2){
        
        
        return 1l;
    } else {
        
        
        return 0l;
    }
}
