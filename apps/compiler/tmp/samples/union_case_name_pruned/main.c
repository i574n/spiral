#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    int refc;
    uint32_t len;
    String * ptr[];
} Array1;
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_First() { // First
    US0 x;
    x.tag = 1;
    return x;
}
US0 US0_Second() { // Second
    US0 x;
    x.tag = 2;
    return x;
}
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
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    String * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        String * v = ptr[i];
        StringDecref(v);
    }
}
static void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
static Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(String *) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array1 * ArrayLit1(uint32_t len, String * * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(String *) * len);
        for (uint32_t i=0; i < len; i++){
            String * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
int32_t main(){
    US0 v0 = US0_First();
    US0 v1 = US0_Second();
    String * v3 = StringLit(1, "");
    String * v4 = StringLit(6, "First");
    String * v5 = StringLit(7, "Second");
    (v3)->refc++; (v4)->refc++; (v5)->refc++;
    Array1 * v6 = ArrayLit1(3, (String * []){v3,v4,v5});
    int32_t v7 = v0.tag;
    String * v8 = v6->ptr[v7];
    (v8)->refc++;
    ArrayDecref1(v6);
    bool v9 = strcmp(v8->ptr, "First") == 0;
    StringDecref(v8);
    bool v14;
    if (v9){
        (v3)->refc++; (v4)->refc++; (v5)->refc++;
        Array1 * v10 = ArrayLit1(3, (String * []){v3,v4,v5});
        int32_t v11 = v1.tag;
        String * v12 = v10->ptr[v11];
        (v12)->refc++;
        ArrayDecref1(v10);
        bool v13 = strcmp(v12->ptr, "Second") == 0;
        StringDecref(v12);
        v14 = v13;
    } else {
        v14 = false;
    }
    StringDecref(v3); StringDecref(v4); StringDecref(v5);
    if (v14){
        return 42l;
    } else {
        return 1l;
    }
}
