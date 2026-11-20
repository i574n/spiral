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
    String * v1;
    int32_t v0;
} Mut0;
typedef struct {
    int refc;
    uint32_t len;
    Mut0 * ptr[];
} Array1;
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
    StringDecref(x->v1);
}
static void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
static Mut0 * MutCreate0(int32_t v0, String * v1){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    Mut0 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Mut0 * v = ptr[i];
        MutDecref0(v);
    }
}
static void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
static Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(Mut0 *) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array1 * ArrayLit1(uint32_t len, Mut0 * * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(Mut0 *) * len);
        for (uint32_t i=0; i < len; i++){
            Mut0 * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(Mut0 * * a, Mut0 * b){
    (b)->refc++;
    MutDecref0(*a);
    *a = b;
}
static inline void AssignMut0(int32_t * a0, int32_t b0, String * * a1, String * b1){
    (b1)->refc++;
    StringDecref(*a1);
    *a0 = b0; *a1 = b1;
}
int32_t main(){
    int32_t v0 = 3l;
    String * v1 = StringLit(3, "no");
    (v1)->refc++;
    Mut0 * v2 = MutCreate0(v0, v1);
    StringDecref(v1);
    Array1 * v3 = ArrayCreate1(1l, true);
    AssignArray0(&(v3->ptr[0l]), v2);
    MutDecref0(v2);
    Mut0 * v4 = v3->ptr[0l];
    (v4)->refc++;
    ArrayDecref1(v3);
    int32_t v5 = 7l;
    String * v6 = StringLit(3, "hi");
    AssignMut0(&(v4->v0), v5, &(v4->v1), v6);
    StringDecref(v6);
    int32_t v7; String * v8;
    v7 = v4->v0; v8 = v4->v1;
    (v8)->refc++;
    MutDecref0(v4);
    bool v9 = v7 == 7l;
    bool v11;
    if (v9){
        bool v10 = strcmp(v8->ptr, "hi") == 0;
        v11 = v10;
    } else {
        v11 = false;
    }
    StringDecref(v8);
    if (v11){
        return 0l;
    } else {
        return 1l;
    }
}
