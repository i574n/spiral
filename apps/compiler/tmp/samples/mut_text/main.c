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
    String * v0;
} Mut0;
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
static inline void MutDecrefBody0(Mut0 * x){
    StringDecref(x->v0);
}
static void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
static Mut0 * MutCreate0(String * v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void AssignMut0(String * * a0, String * b0){
    (b0)->refc++;
    StringDecref(*a0);
    *a0 = b0;
}
int32_t main(){
    String * v0 = StringLit(3, "no");
    (v0)->refc++;
    Mut0 * v1 = MutCreate0(v0);
    StringDecref(v0);
    String * v2 = StringLit(3, "hi");
    AssignMut0(&(v1->v0), v2);
    StringDecref(v2);
    String * v3 = v1->v0;
    (v3)->refc++;
    MutDecref0(v1);
    bool v4 = strcmp(v3->ptr, "hi") == 0;
    StringDecref(v3);
    if (v4){
        return 0l;
    } else {
        return 1l;
    }
}
