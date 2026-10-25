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
typedef struct {
    int refc;
    String * v1;
    float v0;
} Mut0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
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
static inline void MutDecrefBody0(Mut0 * x){
    StringDecref(x->v1);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(float v0, String * v1){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void AssignMut0(float * a0, float b0, String * * a1, String * b1){
    (b1)->refc++;
    StringDecref(*a1);
    *a0 = b0; *a1 = b1;
}
int32_t main(){
    
    
    float v0;
    v0 = 1.5f;
    
    
    String * v1;
    v1 = StringLit(3, "no");
    (v1)->refc++;
    
    Mut0 * v2;
    v2 = MutCreate0(v0, v1);
    
    StringDecref(v1);
    float v3;
    v3 = 2.5f;
    
    
    String * v4;
    v4 = StringLit(3, "hi");
    
    
    
    AssignMut0(&(v2->v0), v3, &(v2->v1), v4);
    
    StringDecref(v4);
    float v5; String * v6;
    v5 = v2->v0; v6 = v2->v1;
    (v6)->refc++;
    MutDecref0(v2);
    bool v7;
    v7 = v5 == 2.5f;
    
    
    bool v9;
    if (v7){
        
        
        bool v8;
        v8 = strcmp(v6->ptr, "hi") == 0;
        
        
        v9 = v8;
    } else {
        
        
        v9 = false;
    }
    
    StringDecref(v6);
    if (v9){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
