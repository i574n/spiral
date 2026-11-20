#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            double v0;
        } case0; // Circle
        struct {
            double v0;
        } case1; // Square
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
US0 US0_Circle(double v0) { // Circle
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Square(double v0) { // Square
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US0 US0_Dot() { // Dot
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
    double v0 = 1.5;
    US0 v1 = US0_Circle(v0);
    double v2 = 2.5;
    US0 v3 = US0_Square(v2);
    US0 v4 = US0_Dot();
    String * v8 = StringLit(7, "Circle");
    String * v9 = StringLit(7, "Square");
    String * v10 = StringLit(4, "Dot");
    (v8)->refc++; (v9)->refc++; (v10)->refc++;
    Array1 * v11 = ArrayLit1(3, (String * []){v8,v9,v10});
    int32_t v12 = v1.tag;
    String * v13 = v11->ptr[v12];
    (v13)->refc++;
    ArrayDecref1(v11);
    bool v14 = strcmp(v13->ptr, "Circle") == 0;
    StringDecref(v13);
    bool v19;
    if (v14){
        (v8)->refc++; (v9)->refc++; (v10)->refc++;
        Array1 * v15 = ArrayLit1(3, (String * []){v8,v9,v10});
        int32_t v16 = v3.tag;
        String * v17 = v15->ptr[v16];
        (v17)->refc++;
        ArrayDecref1(v15);
        bool v18 = strcmp(v17->ptr, "Square") == 0;
        StringDecref(v17);
        v19 = v18;
    } else {
        v19 = false;
    }
    bool v24;
    if (v19){
        (v8)->refc++; (v9)->refc++; (v10)->refc++;
        Array1 * v20 = ArrayLit1(3, (String * []){v8,v9,v10});
        int32_t v21 = v4.tag;
        String * v22 = v20->ptr[v21];
        (v22)->refc++;
        ArrayDecref1(v20);
        bool v23 = strcmp(v22->ptr, "Dot") == 0;
        StringDecref(v22);
        v24 = v23;
    } else {
        v24 = false;
    }
    StringDecref(v8); StringDecref(v9); StringDecref(v10);
    if (v24){
        return 42l;
    } else {
        return 1l;
    }
}
