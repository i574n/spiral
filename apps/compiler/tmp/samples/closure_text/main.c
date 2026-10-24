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
    String * (*fptr)(Fun0 *, int32_t);
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
static inline void ClosureDecrefBody0(Closure0 * x){
    StringDecref(x->v0);
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static String * f_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    String * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(self);
    bool v2 = v1 == 0l;
    if (v2){
        StringDecref(v0);
        String * v3 = StringLit(3, "no");
        return v3;
    } else {
        return v0;
    }
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
    String * v2 = v1->fptr(v1, 1l);
    (v1)->decref_fptr(v1);
    bool v3 = strcmp(v2->ptr, "hi") == 0;
    StringDecref(v2);
    if (v3){
        return 0l;
    } else {
        return 1l;
    }
}
