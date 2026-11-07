#include <stdbool.h>
#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>
static char spiral_format_buffer[64];
static inline uint32_t spiral_format_i64(long long x) { return (uint32_t)snprintf(spiral_format_buffer, sizeof spiral_format_buffer, "%lld", x) + 1u; }
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
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate0(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
}
static inline void AssignMut0(String * * a0, String * b0){
    (b0)->refc++;
    StringDecref(*a0);
    *a0 = b0;
}
static void method2(Mut0 * v0, String * v1){
    String * v2 = v0->v0;
    (v2)->refc++;
    String * v3 = StringConcat(v2, v1);
    StringDecref(v1); StringDecref(v2);
    AssignMut0(&(v0->v0), v3);
    MutDecref0(v0); StringDecref(v3);
    return ;
}
static String * format_real1(int32_t v0){
    String * v1 = StringLit(1, "");
    (v1)->refc++;
    Mut0 * v2 = MutCreate0(v1);
    StringDecref(v1);
    String * v3 = StringLit(spiral_format_i64((long long)(v0)), spiral_format_buffer);
    (v2)->refc++; (v3)->refc++;
    method2(v2, v3);
    StringDecref(v3);
    String * v4 = v2->v0;
    (v4)->refc++;
    MutDecref0(v2);
    return v4;
}
static String * method0(){
    int32_t v0 = 1l;
    String * v1 = format_real1(v0);
    String * v2 = StringConcat(StringLit(6, "Some("), v1);
    StringDecref(v1);
    String * v3 = StringConcat(v2, StringLit(2, ")"));
    StringDecref(v2);
    return v3;
}
int32_t main(){
    String * v0 = method0();
    String * v1 = StringConcat(StringLit(4, "x: "), v0);
    StringDecref(v0);
    bool v2 = strcmp(v1->ptr, "") == 0;
    StringDecref(v1);
    if (v2){
        return 1l;
    } else {
        return 0l;
    }
}
