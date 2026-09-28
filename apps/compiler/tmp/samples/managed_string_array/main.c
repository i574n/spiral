#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array1;
typedef Array1 String;
typedef struct {
    int refc;
    uint32_t len;
    String * ptr[];
} Array0;
static inline void ArrayDecrefBody1(Array1 * x){
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(char) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, char * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref1(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit1(len, ptr);
}
static inline void ArrayDecrefBody0(Array0 * x){
    uint32_t len = x->len;
    String * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        String * v = ptr[i];
        StringDecref(v);
    }
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(String *) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, String * * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(String *) * len);
        for (uint32_t i=0; i < len; i++){
            String * v = ptr[i];
            v->refc++;
        }
    return x;
}
static inline void AssignArray0(String * * a, String * b){
    b->refc++;
    StringDecref(*a);
    *a = b;
}
int32_t main(){
    
    
    Array0 * v0;
    v0 = ArrayCreate0(2l, true);
    
    
    String * v1;
    v1 = StringLit(3, "ab");
    
    
    
    AssignArray0(&(v0->ptr[0l]), v1);
    
    StringDecref(v1);
    String * v2;
    v2 = StringLit(4, "cde");
    
    
    
    AssignArray0(&(v0->ptr[1l]), v2);
    
    StringDecref(v2);
    String * v3;
    v3 = v0->ptr[0l];
    v3->refc++;
    
    String * v4;
    v4 = v0->ptr[1l];
    v4->refc++;
    ArrayDecref0(v0);
    int32_t v5;
    v5 = v3->len-1;
    
    StringDecref(v3);
    int32_t v6;
    v6 = v4->len-1;
    
    StringDecref(v4);
    int32_t v7;
    v7 = v5 + v6 ;
    
    
    int32_t v8;
    v8 = v7 - 5l ;
    
    
    return v8;
}
