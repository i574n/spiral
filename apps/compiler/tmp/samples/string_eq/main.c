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
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate0(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
}
static inline String * StringSlice(String * value, int32_t from, int32_t to){
    int32_t length = (int32_t)value->len - 1;
    if (from < 0 || from > length || to < from - 1 || to >= length) { abort(); }
    uint32_t slice_len = to < from ? 0u : (uint32_t)(to - from + 1);
    if (slice_len != 0u && ((((uint8_t)value->ptr[from] & 0xC0u) == 0x80u) || (to + 1 < length && (((uint8_t)value->ptr[to + 1] & 0xC0u) == 0x80u)))) { abort(); }
    String * result = ArrayCreate0(slice_len + 1, false);
    if (slice_len != 0u) { memcpy(result->ptr, value->ptr + from, slice_len); }
    result->ptr[slice_len] = '\0';
    return result;
}
int32_t main(){
    String * v0 = StringLit(3, "é");
    String * v1 = StringLit(2, "x");
    String * v2 = StringConcat(v0, v1);
    StringDecref(v1);
    String * v3 = StringLit(4, "éx");
    String * v4 = StringLit(4, "éy");
    String * v5 = StringLit(1, "");
    String * v6 = StringSlice(v3, 1l, 0l);
    bool v7 = strcmp(v2->ptr, v3->ptr) == 0;
    bool v9;
    if (v7){
        bool v8 = strcmp(v2->ptr, v4->ptr) != 0;
        v9 = v8;
    } else {
        v9 = false;
    }
    StringDecref(v2); StringDecref(v4);
    bool v11;
    if (v9){
        bool v10 = strcmp(v0->ptr, v3->ptr) != 0;
        v11 = v10;
    } else {
        v11 = false;
    }
    StringDecref(v3);
    bool v13;
    if (v11){
        bool v12 = strcmp(v5->ptr, v6->ptr) == 0;
        v13 = v12;
    } else {
        v13 = false;
    }
    StringDecref(v6);
    bool v15;
    if (v13){
        bool v14 = strcmp(v5->ptr, v0->ptr) != 0;
        v15 = v14;
    } else {
        v15 = false;
    }
    StringDecref(v0); StringDecref(v5);
    if (v15){
        return 0l;
    } else {
        return 1l;
    }
}
