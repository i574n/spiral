#include <stdbool.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
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
    Array0 * v0;
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    int32_t (*fptr)(Closure1 *, int32_t);
    Array0 * v0;
};
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    *a = b;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    ArrayDecref0(x->v0);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t ClosureMethod0(Closure0 * x, int32_t v1){
    int32_t observed = x->v0->ptr[0];
    if (observed < 0l){
        PortableFail("package-owned managed array closure negative capture");
    }
    if (v1 == 0l){
        PortableFail("package-owned managed array closure zero argument");
    }
    ClosureDecref0(x);
    PortableFail("package-owned managed array closure failure");
    return observed + v1;
}
Fun0 * ClosureCreate0(Array0 * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0;
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    ArrayDecref0(x->v0);
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
int32_t ClosureMethod1(Closure1 * x, int32_t v1){
    int32_t observed = x->v0->ptr[0];
    if (observed < 0l){
        PortableFail("package-owned managed array closure negative capture");
    }
    if (v1 == 0l){
        PortableFail("package-owned managed array closure alternate zero argument");
    }
    ClosureDecref1(x);
    PortableFail("package-owned managed array closure failure");
    return observed + v1;
}
Fun0 * ClosureCreate1(Array0 * v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = ClosureMethod1;
    x->v0 = v0;
    return (Fun0 *) x;
}
Fun0 * select0(bool flag){
    Fun0 * selected;
    Array0 * values = ArrayCreate0(1u, false);
    if (flag){
        AssignArray0(&(values->ptr[0l]), 7l);
    } else {
        AssignArray0(&(values->ptr[0l]), 8l);
    }
    values->refc++;
    if (flag){
        selected = ClosureCreate0(values);
    } else {
        selected = ClosureCreate1(values);
    }
    ArrayDecref0(values);
    return selected;
}
int32_t method0(Fun0 * v0){
    return v0->fptr(v0, 39l);
}
int32_t main(){
    Fun0 * selected = select0(true);
    return method0(selected);
}
