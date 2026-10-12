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
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array1;
typedef struct {
    int tag;
    union {
        struct {
            String * v0;
            Array1 * v1;
        } case1; // Item
    };
} US0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    US0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    US0 (*fptr)(Closure0 *, int32_t);
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
static inline void ArrayDecrefBody1(Array1 * x){
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(int32_t) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, int32_t * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            x->case1.v0->refc++; x->case1.v1->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            StringDecref(x->case1.v0); ArrayDecref1(x->case1.v1);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_0() { // Empty
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(String * v0, Array1 * v1) { // Item
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    *a = b;
}
static inline void ClosureDecrefBody0(Closure0 * x){
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
US0 ClosureMethod0(Closure0 * x, int32_t v0){
    bool v1;
    v1 = v0 == 0l ;
    if (v1){
        ClosureDecref0(x);
        return US0_0();
    } else {
        Array1 * v3;
        v3 = ArrayCreate1(2l, false);
        AssignArray0(&(v3->ptr[0l]), v0);
        int32_t v4;
        v4 = v0 + 1l ;
        AssignArray0(&(v3->ptr[1l]), v4);
        String * v5;
        v5 = StringLit(3, "hi");
        ClosureDecref0(x);
        return US0_1(v5, v3);
    }
}
Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    return (Fun0 *) x;
}
US0 method0(Fun0 * v0){
    return v0->fptr(v0, 0l);
}
US0 method1(Fun0 * v0){
    return v0->fptr(v0, 4l);
}
int32_t main(){
    Fun0 * v0;
    v0 = ClosureCreate0();
    US0 v1;
    v1 = method1(v0);
    USIncref0(&(v1));
    USDecref0(&(v1));
    return 42l;
}
