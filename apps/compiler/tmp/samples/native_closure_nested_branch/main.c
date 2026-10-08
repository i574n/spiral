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
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    int32_t (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    int32_t (*fptr)(Closure0 *, int32_t);
    String * v0;
    int32_t v1;
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    int32_t (*fptr)(Closure1 *, int32_t);
    String * v0;
    int32_t v1;
};
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
static inline void ClosureDecrefBody0(Closure0 * x){
    StringDecref(x->v0);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t ClosureMethod0(Closure0 * x, int32_t v2){
    String * v0 = x->v0; int32_t v1 = x->v1;
    v0->refc++;
    ClosureDecref0(x);
    
    
    bool v3;
    v3 = v2 > 0l;
    
    
    if (v3){
        
        
        int32_t v4;
        v4 = v0->len-1;
        
        StringDecref(v0);
        int32_t v5;
        v5 = v4 + v1;
        
        
        int32_t v6;
        v6 = v5 + v2;
        
        
        return v6;
    } else {
        
        StringDecref(v0);
        return 0l;
    }
}
Fun0 * ClosureCreate0(String * v0, int32_t v1){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0; x->v1 = v1;
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    StringDecref(x->v0);
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
int32_t ClosureMethod1(Closure1 * x, int32_t v2){
    String * v0 = x->v0; int32_t v1 = x->v1;
    v0->refc++;
    ClosureDecref1(x);
    
    
    bool v3;
    v3 = v2 > 0l;
    
    
    if (v3){
        
        
        int32_t v4;
        v4 = v0->len-1;
        
        StringDecref(v0);
        int32_t v5;
        v5 = v4 + v1;
        
        
        int32_t v6;
        v6 = v5 + v2;
        
        
        int32_t v7;
        v7 = v6 - 1l;
        
        
        return v7;
    } else {
        
        StringDecref(v0);
        return -1l;
    }
}
Fun0 * ClosureCreate1(String * v0, int32_t v1){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = ClosureMethod1;
    x->v0 = v0; x->v1 = v1;
    return (Fun0 *) x;
}
int32_t method0(Fun0 * v0){
    
    
    return v0->fptr(v0, 37l);
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(4, "abc");
    
    
    String * v1;
    v1 = StringLit(5, "wxyz");
    
    
    int32_t v2;
    v2 = 2l;
    
    
    int32_t v3;
    v3 = 2l;
    
    
    bool v4;
    v4 = true;
    
    
    Fun0 * v7;
    if (v4){
        v0->refc++;
        
        v7 = ClosureCreate0(v0, v2);
    } else {
        v1->refc++;
        
        v7 = ClosureCreate1(v1, v3);
    }
    
    StringDecref(v0); StringDecref(v1);
    return method0(v7);
}
