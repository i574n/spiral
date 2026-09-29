#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    int32_t (*fptr)(Fun1 *, int32_t);
};
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
    Fun1 * (*fptr)(Fun0 *, String *);
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    int32_t (*fptr)(Closure1 *, int32_t);
    String * v0;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Fun1 * (*fptr)(Closure0 *, String *);
};
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
static inline void ClosureDecrefBody1(Closure1 * x){
    StringDecref(x->v0);
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
int32_t ClosureMethod1(Closure1 * x, int32_t v1){
    String * v0 = x->v0;
    v0->refc++;
    ClosureDecref1(x);
    
    
    int32_t v2;
    v2 = v0->len-1;
    
    StringDecref(v0);
    int32_t v3;
    v3 = v2 + v1;
    
    
    return v3;
}
Fun1 * ClosureCreate1(String * v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = ClosureMethod1;
    x->v0 = v0;
    return (Fun1 *) x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Fun1 * ClosureMethod0(Closure0 * x, String * v0){
    
    
    ClosureDecref0(x);
    
    
    return ClosureCreate1(v0);
}
Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    
    return (Fun0 *) x;
}
int32_t method0(Fun1 * v0){
    
    
    return v0->fptr(v0, 39l);
}
int32_t main(){
    
    
    Fun0 * v0;
    v0 = ClosureCreate0();
    
    
    String * v1;
    v1 = StringLit(4, "abc");
    v0->refc++; v1->refc++;
    
    Fun1 * v2;
    v2 = v0->fptr(v0, v1);
    
    v0->decref_fptr(v0); StringDecref(v1);
    return method0(v2);
}
