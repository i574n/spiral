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
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    String * (*fptr)(Fun1 *, int32_t);
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Fun1 * (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure1 Closure1;
struct Closure1 {
    Fun1 base;
    String * v0;
    int32_t v1;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    String * v0;
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
static String * g_c1(Fun1 * self, int32_t v2){
    Closure1 * x = (Closure1 *) self;
    String * v0 = x->v0; int32_t v1 = x->v1;
    (v0)->refc++;
    ClosureDecref1(self);
    (void)v2;
    bool v3 = v1 == 0l;
    if (v3){
        StringDecref(v0);
        String * v4 = StringLit(3, "no");
        return v4;
    } else {
        return v0;
    }
}
static Fun1 * ClosureCreate1(String * v0, int32_t v1){
    Closure1 * x = malloc(sizeof(Closure1));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref1;
    x->base.fptr = g_c1;
    x->v0 = v0; x->v1 = v1;
    return &x->base;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    StringDecref(x->v0);
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static Fun1 * f_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    String * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(self);
    return ClosureCreate1(v0, v1);
}
static Fun0 * ClosureCreate0(String * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0;
    return &x->base;
}
int32_t main(){
    String * v0 = StringLit(3, "hi");
    (v0)->refc++;
    Fun0 * v1 = ClosureCreate0(v0);
    (v1)->refc++;
    StringDecref(v0);
    Fun1 * v2 = v1->fptr(v1, 1l);
    (v2)->refc++;
    (v1)->decref_fptr(v1);
    String * v3 = v2->fptr(v2, 0l);
    (v2)->decref_fptr(v2);
    bool v4 = strcmp(v3->ptr, "hi") == 0;
    StringDecref(v3);
    if (v4){
        return 0l;
    } else {
        return 1l;
    }
}
