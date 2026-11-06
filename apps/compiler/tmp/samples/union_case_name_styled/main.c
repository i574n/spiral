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
        } case1; // LightGreen
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
US0 US0_DeepBlue() { // DeepBlue
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_LightGreen(double v0) { // LightGreen
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US0 US0_Red() { // Red
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
    double v0 = 0.5;
    US0 v1 = US0_LightGreen(v0);
    US0 v2 = US0_DeepBlue();
    US0 v3 = US0_Red();
    String * v4 = StringLit(10, "deep_blue");
    String * v5 = StringLit(12, "light_green");
    String * v6 = StringLit(4, "red");
    (v4)->refc++; (v5)->refc++; (v6)->refc++;
    Array1 * v7 = ArrayLit1(3, (String * []){v4,v5,v6});
    int32_t v8 = v1.tag;
    String * v9 = v7->ptr[v8];
    (v9)->refc++;
    ArrayDecref1(v7);
    bool v10 = strcmp(v9->ptr, "light_green") == 0;
    StringDecref(v9);
    bool v17;
    if (v10){
        String * v11 = StringLit(10, "deep-blue");
        String * v12 = StringLit(12, "light-green");
        (v6)->refc++; (v11)->refc++; (v12)->refc++;
        Array1 * v13 = ArrayLit1(3, (String * []){v11,v12,v6});
        StringDecref(v11); StringDecref(v12);
        int32_t v14 = v2.tag;
        String * v15 = v13->ptr[v14];
        (v15)->refc++;
        ArrayDecref1(v13);
        bool v16 = strcmp(v15->ptr, "deep-blue") == 0;
        StringDecref(v15);
        v17 = v16;
    } else {
        v17 = false;
    }
    bool v23;
    if (v17){
        String * v18 = StringLit(9, "deepblue");
        String * v19 = StringLit(11, "lightgreen");
        (v6)->refc++; (v18)->refc++; (v19)->refc++;
        Array1 * v20 = ArrayLit1(3, (String * []){v18,v19,v6});
        StringDecref(v18); StringDecref(v19);
        String * v21 = v20->ptr[v8];
        (v21)->refc++;
        ArrayDecref1(v20);
        bool v22 = strcmp(v21->ptr, "lightgreen") == 0;
        StringDecref(v21);
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v28;
    if (v23){
        (v4)->refc++; (v5)->refc++; (v6)->refc++;
        Array1 * v24 = ArrayLit1(3, (String * []){v4,v5,v6});
        int32_t v25 = v3.tag;
        String * v26 = v24->ptr[v25];
        (v26)->refc++;
        ArrayDecref1(v24);
        bool v27 = strcmp(v26->ptr, "red") == 0;
        StringDecref(v26);
        v28 = v27;
    } else {
        v28 = false;
    }
    StringDecref(v4); StringDecref(v5); StringDecref(v6);
    bool v35;
    if (v28){
        String * v29 = StringLit(9, "DeepBlue");
        String * v30 = StringLit(11, "LightGreen");
        String * v31 = StringLit(4, "Red");
        (v29)->refc++; (v30)->refc++; (v31)->refc++;
        Array1 * v32 = ArrayLit1(3, (String * []){v29,v30,v31});
        StringDecref(v29); StringDecref(v30); StringDecref(v31);
        String * v33 = v32->ptr[v8];
        (v33)->refc++;
        ArrayDecref1(v32);
        bool v34 = strcmp(v33->ptr, "LightGreen") == 0;
        StringDecref(v33);
        v35 = v34;
    } else {
        v35 = false;
    }
    if (v35){
        return 42l;
    } else {
        return 1l;
    }
}
