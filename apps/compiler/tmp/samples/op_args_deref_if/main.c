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
    String * v0;
} Mut0;
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
static inline void MutDecrefBody0(Mut0 * x){
    StringDecref(x->v0);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(String * v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void AssignMut0(String * * a0, String * b0){
    b0->refc++;
    StringDecref(*a0);
    *a0 = b0;
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(6, "deref");
    v0->refc++;
    
    Mut0 * v1;
    v1 = MutCreate0(v0);
    
    StringDecref(v0);
    int32_t v2;
    v2 = 3l;
    
    
    String * v3;
    v3 = StringLit(7, "deref!");
    
    
    
    AssignMut0(&(v1->v0), v3);
    
    StringDecref(v3);
    String * v4;
    v4 = v1->v0;
    v4->refc++;
    MutDecref0(v1);
    bool v5;
    v5 = v2 == 3l;
    
    
    int32_t v7;
    if (v5){
        
        
        int32_t v6;
        v6 = v2 + 1l;
        
        
        v7 = v6;
    } else {
        
        
        v7 = 0l;
    }
    
    
    
    printf("%s %d\n", v4->ptr, (int)v7);
    
    StringDecref(v4);
    int32_t v8;
    v8 = v2 * 2l;
    
    
    bool v9;
    v9 = v2 > 0l;
    
    
    int32_t v10;
    if (v9){
        
        
        v10 = 6l;
    } else {
        
        
        v10 = 0l;
    }
    
    
    bool v11;
    v11 = v8 == v10;
    
    
    if (v11){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
