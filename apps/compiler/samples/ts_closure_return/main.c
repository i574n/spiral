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
    Fun1 base;
    String * v0;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
};
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, char * ptr){
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
static void ClosureDecref1(Fun1 * self){
    Closure1 * x = (Closure1 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
static int32_t closure1(Fun1 * self, int32_t v1){
    Closure1 * x = (Closure1 *) self;
    String * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref1(self);
    int32_t v2 = v0->len-1;
    StringDecref(v0);
    int32_t v3 = v2 + v1;
    return v3;
}
static Fun1 * ClosureCreate1(String * v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref1;
    x->base.fptr = closure1;
    x->v0 = v0;
    return &x->base;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static Fun1 * make_c0(Fun0 * self, String * v0){
    ClosureDecref0(self);
    return ClosureCreate1(v0);
}
static Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = make_c0;
    return &x->base;
}
static int32_t method0(Fun1 * v0){
    return v0->fptr(v0, 39l);
}
int32_t main(){
    Fun0 * v0 = ClosureCreate0();
    String * v1 = StringLit(4, "abc");
    (v0)->refc++; (v1)->refc++;
    Fun1 * v2 = v0->fptr(v0, v1);
    (v0)->decref_fptr(v0); StringDecref(v1);
    return method0(v2);
}
