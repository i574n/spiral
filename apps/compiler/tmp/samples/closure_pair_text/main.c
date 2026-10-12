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
    String * v0;
    String * v1;
} Tuple0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Tuple0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Tuple0 (*fptr)(Closure0 *, int32_t);
    String * v0;
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
static inline Tuple0 TupleCreate0(String * v0, String * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    StringDecref(x->v0);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 f_c0(Closure0 * x, int32_t v1){
    String * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(x);
    
    
    bool v2;
    v2 = v1 == 0l;
    
    
    if (v2){
        
        StringDecref(v0);
        String * v3;
        v3 = StringLit(3, "no");
        (v3)->refc++;
        
        return TupleCreate0(v3, v3);
    } else {
        
        
        String * v4;
        v4 = StringLit(3, "yo");
        
        
        return TupleCreate0(v0, v4);
    }
}
Fun0 * ClosureCreate0(String * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    x->v0 = v0;
    return (Fun0 *) x;
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(3, "hi");
    (v0)->refc++;
    
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    (v1)->refc++;
    StringDecref(v0);
    String * v2; String * v3;
    Tuple0 tmp0 = v1->fptr(v1, 1l);
    v2 = tmp0.v0; v3 = tmp0.v1;
    
    (v1)->decref_fptr(v1);
    bool v4;
    v4 = strcmp(v2->ptr, "hi") == 0;
    
    StringDecref(v2);
    bool v6;
    if (v4){
        
        
        bool v5;
        v5 = strcmp(v3->ptr, "yo") == 0;
        
        
        v6 = v5;
    } else {
        
        
        v6 = false;
    }
    
    StringDecref(v3);
    if (v6){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
