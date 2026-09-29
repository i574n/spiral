#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
String * choose0(bool v0){
    
    
    if (v0){
        
        
        String * v1;
        v1 = StringLit(6, "alpha");
        
        
        return v1;
    } else {
        
        
        String * v2;
        v2 = StringLit(5, "beta");
        
        
        return v2;
    }
}
int32_t measure1(String * v0){
    
    
    int32_t v1;
    v1 = v0->len-1;
    
    StringDecref(v0);
    return v1;
}
int32_t main(){
    
    
    bool v0;
    v0 = false;
    
    
    String * v1;
    v1 = choose0(v0);
    
    StringDecref(v1);
    bool v2;
    v2 = true;
    
    
    String * v3;
    v3 = choose0(v2);
    
    StringDecref(v3);
    bool v4;
    v4 = true;
    
    
    String * v5;
    v5 = choose0(v4);
    
    StringDecref(v5);
    bool v6;
    v6 = false;
    
    
    String * v7;
    v7 = choose0(v6);
    
    StringDecref(v7);
    bool v8;
    v8 = false;
    
    
    String * v9;
    v9 = choose0(v8);
    
    StringDecref(v9);
    bool v10;
    v10 = true;
    
    
    String * v11;
    v11 = choose0(v10);
    
    
    bool v12;
    v12 = false;
    
    
    String * v13;
    v13 = choose0(v12);
    v11->refc++;
    
    int32_t v14;
    v14 = measure1(v11);
    v11->refc++;
    
    int32_t v15;
    v15 = measure1(v11);
    
    StringDecref(v11);
    int32_t v16;
    v16 = v14 + v15;
    v13->refc++;
    
    int32_t v17;
    v17 = measure1(v13);
    
    StringDecref(v13);
    int32_t v18;
    v18 = v16 + v17;
    
    
    int32_t v19;
    v19 = v18 - 14l;
    
    
    return v19;
}
