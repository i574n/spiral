#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
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
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    int32_t (*fptr)(Closure1 *, int32_t);
};
static inline void ClosureDecrefBody0(Closure0 * x){
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t ClosureMethod0(Closure0 * x, int32_t v0){
    int32_t v1;
    v1 = v0 + 2l ;
    ClosureDecref0(x);
    return v1;
}
Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody1(Closure1 * x){
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
int32_t ClosureMethod1(Closure1 * x, int32_t v0){
    int32_t v1;
    v1 = v0 + 3l ;
    ClosureDecref1(x);
    return v1;
}
Fun0 * ClosureCreate1(){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = ClosureMethod1;
    return (Fun0 *) x;
}
int32_t method0(Fun0 * v0){
    return v0->fptr(v0, 40l);
}
int32_t main(){
    bool v0;
    v0 = true;
    Fun0 * v3;
    if (v0){
        v3 = ClosureCreate0();
    } else {
        v3 = ClosureCreate1();
    }
    return method0(v3);
}
