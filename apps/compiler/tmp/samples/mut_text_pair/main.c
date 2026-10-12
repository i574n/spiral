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
    String * v1;
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
    StringDecref(x->v0); StringDecref(x->v1);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(String * v0, String * v1){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void AssignMut0(String * * a0, String * b0, String * * a1, String * b1){
    (b0)->refc++; (b1)->refc++;
    StringDecref(*a0); StringDecref(*a1);
    *a0 = b0; *a1 = b1;
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(3, "no");
    
    
    String * v1;
    v1 = StringLit(4, "nay");
    (v0)->refc++; (v1)->refc++;
    
    Mut0 * v2;
    v2 = MutCreate0(v0, v1);
    
    StringDecref(v0); StringDecref(v1);
    String * v3;
    v3 = StringLit(3, "hi");
    
    
    String * v4;
    v4 = StringLit(3, "yo");
    
    
    
    AssignMut0(&(v2->v0), v3, &(v2->v1), v4);
    
    StringDecref(v3); StringDecref(v4);
    String * v5; String * v6;
    v5 = v2->v0; v6 = v2->v1;
    (v5)->refc++; (v6)->refc++;
    MutDecref0(v2);
    bool v7;
    v7 = strcmp(v5->ptr, "hi") == 0;
    
    StringDecref(v5);
    bool v9;
    if (v7){
        
        
        bool v8;
        v8 = strcmp(v6->ptr, "yo") == 0;
        
        
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
