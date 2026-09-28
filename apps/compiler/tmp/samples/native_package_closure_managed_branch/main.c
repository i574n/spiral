#include <stdbool.h>
#include <stdint.h>
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
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    int32_t (*fptr)(Closure1 *, int32_t);
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
static inline void ClosureDecrefBody0(Closure0 * x){
    StringDecref(x->v0);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t ClosureMethod0(Closure0 * x, int32_t v1){
    String * v0 = x->v0;
    int32_t v2;
    v2 = v0->len-1;
    int32_t v3;
    v3 = v2 + v1;
    ClosureDecref0(x);
    return v3;
}
Fun0 * ClosureCreate0(String * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0;
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    StringDecref(x->v0);
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
int32_t ClosureMethod1(Closure1 * x, int32_t v1){
    String * v0 = x->v0;
    int32_t v2;
    v2 = v0->len-1;
    int32_t v3;
    v3 = v2 + v1 - 1;
    ClosureDecref1(x);
    return v3;
}
Fun0 * ClosureCreate1(String * v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = ClosureMethod1;
    x->v0 = v0;
    return (Fun0 *) x;
}
Fun0 * select0(bool flag){
    Fun0 * selected;
    if (flag){
        String * name = StringLit(4, "abc");
        name->refc++;
        selected = ClosureCreate0(name);
        StringDecref(name);
    } else {
        String * name = StringLit(5, "wxyz");
        name->refc++;
        selected = ClosureCreate1(name);
        StringDecref(name);
    }
    return selected;
}
int32_t method0(Fun0 * v0){
    return v0->fptr(v0, 39l);
}
int32_t main(){
    Fun0 * selected = select0(true);
    return method0(selected);
}
