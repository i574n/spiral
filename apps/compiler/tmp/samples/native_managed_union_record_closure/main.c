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
    int tag;
    union {
        struct {
            String * v0;
            int32_t v1;
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
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            x->case1.v0->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            StringDecref(x->case1.v0);
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
US0 US0_1(String * v0, int32_t v1) { // Item
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
US0 ClosureMethod0(Closure0 * x, int32_t v0){
    bool v1;
    v1 = v0 == 0l;
    if (v1){
        ClosureDecref0(x);
        return US0_0();
    } else {
        String * v3;
        v3 = StringLit(8, "managed");
        ClosureDecref0(x);
        return US0_1(v3, 32l);
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
    return v0->fptr(v0, 1l);
}
int32_t main(){
    Fun0 * v0;
    v0 = ClosureCreate0();
    v0->refc++;
    US0 v1;
    v1 = method0(v0);
    int32_t v7;
    switch (v1.tag) {
        case 0: { // Empty
            v7 = 3l;
            break;
        }
        case 1: { // Item
            String * v2 = v1.case1.v0; int32_t v3 = v1.case1.v1;
            v2->refc++;
            int32_t v4;
            v4 = v2->len-1;
            StringDecref(v2);
            int32_t v5;
            v5 = v4 + v3;
            v7 = v5;
            break;
        }
    }
    v0->refc++;
    USDecref0(&(v1));
    US0 v8;
    v8 = method1(v0);
    v0->decref_fptr(v0);
    int32_t v14;
    switch (v8.tag) {
        case 0: { // Empty
            v14 = 3l;
            break;
        }
        case 1: { // Item
            String * v9 = v8.case1.v0; int32_t v10 = v8.case1.v1;
            v9->refc++;
            int32_t v11;
            v11 = v9->len-1;
            StringDecref(v9);
            int32_t v12;
            v12 = v11 + v10;
            v14 = v12;
            break;
        }
    }
    USDecref0(&(v8));
    int32_t v15;
    v15 = v7 + v14;
    return v15;
}
