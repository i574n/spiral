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
} Heap0;
typedef struct {
    int refc;
    Heap0 * v0;
    Heap0 * v1;
} Heap1;
typedef struct {
    int refc;
    Heap1 * v0;
    int32_t v1;
} Heap2;
typedef struct {
    int tag;
    union {
        struct {
            Heap2 * v0;
        } case1; // Held
    };
} US0;
typedef struct {
    int refc;
    US0 v0;
} Heap3;
typedef struct {
    int tag;
    union {
        struct {
            Heap3 * v0;
        } case1; // Box
    };
} US1;
typedef struct {
    int refc;
    US1 v0;
} Heap4;
typedef struct {
    int refc;
    uint32_t len;
    Heap4 * ptr[];
} Array1;
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
static inline void HeapDecrefBody0(Heap0 * x){
    StringDecref(x->v1);
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(int32_t v0, String * v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void HeapDecrefBody1(Heap1 * x){
    HeapDecref0(x->v0); HeapDecref0(x->v1);
}
void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
Heap1 * HeapCreate1(Heap0 * v0, Heap0 * v1){
    Heap1 * x = malloc(sizeof(Heap1));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void HeapDecrefBody2(Heap2 * x){
    HeapDecref1(x->v0);
}
void HeapDecref2(Heap2 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody2(x); free(x); }
}
Heap2 * HeapCreate2(Heap1 * v0, int32_t v1){
    Heap2 * x = malloc(sizeof(Heap2));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            HeapDecref2(x->case1.v0);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_None() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Held(Heap2 * v0) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void HeapDecrefBody3(Heap3 * x){
    USDecref0(&(x->v0));
}
void HeapDecref3(Heap3 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody3(x); free(x); }
}
Heap3 * HeapCreate3(US0 v0){
    Heap3 * x = malloc(sizeof(Heap3));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void USIncrefBody1(US1 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody1(US1 * x){
    switch (x->tag) {
        case 1: {
            HeapDecref3(x->case1.v0);
            break;
        }
    }
}
void USIncref1(US1 * x){ USIncrefBody1(x); }
void USDecref1(US1 * x){ USDecrefBody1(x); }
US1 US1_Absent() { // Absent
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_Box(Heap3 * v0) { // Box
    US1 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void HeapDecrefBody4(Heap4 * x){
    USDecref1(&(x->v0));
}
void HeapDecref4(Heap4 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody4(x); free(x); }
}
Heap4 * HeapCreate4(US1 v0){
    Heap4 * x = malloc(sizeof(Heap4));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    Heap4 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Heap4 * v = ptr[i];
        HeapDecref4(v);
    }
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(Heap4 *) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, Heap4 * * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(Heap4 *) * len);
        for (uint32_t i=0; i < len; i++){
            Heap4 * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(Heap4 * * a, Heap4 * b){
    (b)->refc++;
    HeapDecref4(*a);
    *a = b;
}
int32_t score0(US1 v0){
    
    
    switch (v0.tag) {
        case 0: { // Absent
            
            
            USDecref1(&(v0));
            return 1l;
            break;
        }
        case 1: { // Box
            Heap3 * v1 = v0.case1.v0;
            (v1)->refc++;
            USDecref1(&(v0));
            US0 v2;
            v2 = v1->v0;
            USIncref0(&(v2));
            HeapDecref3(v1);
            switch (v2.tag) {
                case 1: { // Held
                    Heap2 * v3 = v2.case1.v0;
                    (v3)->refc++;
                    USDecref0(&(v2));
                    Heap1 * v4; int32_t v5;
                    v4 = v3->v0; v5 = v3->v1;
                    (v4)->refc++;
                    HeapDecref2(v3);
                    Heap0 * v6; Heap0 * v7;
                    v6 = v4->v0; v7 = v4->v1;
                    (v6)->refc++; (v7)->refc++;
                    HeapDecref1(v4);
                    int32_t v8; String * v9;
                    v8 = v6->v0; v9 = v6->v1;
                    (v9)->refc++;
                    HeapDecref0(v6);
                    int32_t v10; String * v11;
                    v10 = v7->v0; v11 = v7->v1;
                    (v11)->refc++;
                    HeapDecref0(v7);
                    bool v12;
                    v12 = v8 == 7l;
                    
                    
                    bool v14;
                    if (v12){
                        
                        
                        bool v13;
                        v13 = strcmp(v9->ptr, "hi") == 0;
                        
                        
                        v14 = v13;
                    } else {
                        
                        
                        v14 = false;
                    }
                    
                    StringDecref(v9);
                    bool v16;
                    if (v14){
                        
                        
                        bool v15;
                        v15 = v10 == 4l;
                        
                        
                        v16 = v15;
                    } else {
                        
                        
                        v16 = false;
                    }
                    
                    
                    bool v18;
                    if (v16){
                        
                        
                        bool v17;
                        v17 = strcmp(v11->ptr, "yo") == 0;
                        
                        
                        v18 = v17;
                    } else {
                        
                        
                        v18 = false;
                    }
                    
                    StringDecref(v11);
                    bool v20;
                    if (v18){
                        
                        
                        bool v19;
                        v19 = v5 == 2l;
                        
                        
                        v20 = v19;
                    } else {
                        
                        
                        v20 = false;
                    }
                    
                    
                    if (v20){
                        
                        
                        return 0l;
                    } else {
                        
                        
                        return 1l;
                    }
                    break;
                }
                case 0: { // None
                    
                    
                    USDecref0(&(v2));
                    return 1l;
                    break;
                }
            }
            break;
        }
    }
}
int32_t score_b1(US1 v0){
    
    
    switch (v0.tag) {
        case 0: { // Absent
            
            
            USDecref1(&(v0));
            return 1l;
            break;
        }
        case 1: { // Box
            Heap3 * v1 = v0.case1.v0;
            (v1)->refc++;
            USDecref1(&(v0));
            US0 v2;
            v2 = v1->v0;
            USIncref0(&(v2));
            HeapDecref3(v1);
            switch (v2.tag) {
                case 1: { // Held
                    Heap2 * v3 = v2.case1.v0;
                    (v3)->refc++;
                    USDecref0(&(v2));
                    Heap1 * v4; int32_t v5;
                    v4 = v3->v0; v5 = v3->v1;
                    (v4)->refc++;
                    HeapDecref2(v3);
                    Heap0 * v6; Heap0 * v7;
                    v6 = v4->v0; v7 = v4->v1;
                    (v6)->refc++; (v7)->refc++;
                    HeapDecref1(v4);
                    int32_t v8; String * v9;
                    v8 = v6->v0; v9 = v6->v1;
                    (v9)->refc++;
                    HeapDecref0(v6);
                    int32_t v10; String * v11;
                    v10 = v7->v0; v11 = v7->v1;
                    (v11)->refc++;
                    HeapDecref0(v7);
                    bool v12;
                    v12 = v8 == 8l;
                    
                    
                    bool v14;
                    if (v12){
                        
                        
                        bool v13;
                        v13 = strcmp(v9->ptr, "ok") == 0;
                        
                        
                        v14 = v13;
                    } else {
                        
                        
                        v14 = false;
                    }
                    
                    StringDecref(v9);
                    bool v16;
                    if (v14){
                        
                        
                        bool v15;
                        v15 = v10 == 5l;
                        
                        
                        v16 = v15;
                    } else {
                        
                        
                        v16 = false;
                    }
                    
                    
                    bool v18;
                    if (v16){
                        
                        
                        bool v17;
                        v17 = strcmp(v11->ptr, "no") == 0;
                        
                        
                        v18 = v17;
                    } else {
                        
                        
                        v18 = false;
                    }
                    
                    StringDecref(v11);
                    bool v20;
                    if (v18){
                        
                        
                        bool v19;
                        v19 = v5 == 9l;
                        
                        
                        v20 = v19;
                    } else {
                        
                        
                        v20 = false;
                    }
                    
                    
                    if (v20){
                        
                        
                        return 0l;
                    } else {
                        
                        
                        return 1l;
                    }
                    break;
                }
                case 0: { // None
                    
                    
                    USDecref0(&(v2));
                    return 1l;
                    break;
                }
            }
            break;
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    (v1)->refc++;
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    
    StringDecref(v1);
    int32_t v3;
    v3 = 4l;
    
    
    String * v4;
    v4 = StringLit(3, "yo");
    (v4)->refc++;
    
    Heap0 * v5;
    v5 = HeapCreate0(v3, v4);
    (v2)->refc++; (v5)->refc++;
    StringDecref(v4);
    Heap1 * v6;
    v6 = HeapCreate1(v2, v5);
    
    HeapDecref0(v2); HeapDecref0(v5);
    int32_t v7;
    v7 = 2l;
    (v6)->refc++;
    
    Heap2 * v8;
    v8 = HeapCreate2(v6, v7);
    (v8)->refc++;
    HeapDecref1(v6);
    US0 v9;
    v9 = US0_Held(v8);
    USIncref0(&(v9));
    HeapDecref2(v8);
    Heap3 * v10;
    v10 = HeapCreate3(v9);
    (v10)->refc++;
    USDecref0(&(v9));
    US1 v11;
    v11 = US1_Box(v10);
    USIncref1(&(v11));
    HeapDecref3(v10);
    Heap4 * v12;
    v12 = HeapCreate4(v11);
    
    USDecref1(&(v11));
    int32_t v13;
    v13 = 8l;
    
    
    String * v14;
    v14 = StringLit(3, "ok");
    (v14)->refc++;
    
    Heap0 * v15;
    v15 = HeapCreate0(v13, v14);
    
    StringDecref(v14);
    int32_t v16;
    v16 = 5l;
    
    
    String * v17;
    v17 = StringLit(3, "no");
    (v17)->refc++;
    
    Heap0 * v18;
    v18 = HeapCreate0(v16, v17);
    (v15)->refc++; (v18)->refc++;
    StringDecref(v17);
    Heap1 * v19;
    v19 = HeapCreate1(v15, v18);
    
    HeapDecref0(v15); HeapDecref0(v18);
    int32_t v20;
    v20 = 9l;
    (v19)->refc++;
    
    Heap2 * v21;
    v21 = HeapCreate2(v19, v20);
    (v21)->refc++;
    HeapDecref1(v19);
    US0 v22;
    v22 = US0_Held(v21);
    USIncref0(&(v22));
    HeapDecref2(v21);
    Heap3 * v23;
    v23 = HeapCreate3(v22);
    (v23)->refc++;
    USDecref0(&(v22));
    US1 v24;
    v24 = US1_Box(v23);
    USIncref1(&(v24));
    HeapDecref3(v23);
    Heap4 * v25;
    v25 = HeapCreate4(v24);
    
    USDecref1(&(v24));
    Array1 * v26;
    v26 = ArrayCreate1(2l, true);
    
    
    
    AssignArray0(&(v26->ptr[0l]), v12);
    
    HeapDecref4(v12);
    
    AssignArray0(&(v26->ptr[1l]), v25);
    
    HeapDecref4(v25);
    Heap4 * v27;
    v27 = v26->ptr[0l];
    (v27)->refc++;
    
    Heap4 * v28;
    v28 = v26->ptr[1l];
    (v28)->refc++;
    ArrayDecref1(v26);
    US1 v29;
    v29 = v27->v0;
    USIncref1(&(v29));
    HeapDecref4(v27);
    US1 v30;
    v30 = v28->v0;
    USIncref1(&(v29)); USIncref1(&(v30));
    HeapDecref4(v28);
    int32_t v31;
    v31 = score0(v29);
    USIncref1(&(v30));
    USDecref1(&(v29));
    int32_t v32;
    v32 = score_b1(v30);
    
    USDecref1(&(v30));
    bool v33;
    v33 = v31 == 0l;
    
    
    bool v35;
    if (v33){
        
        
        bool v34;
        v34 = v32 == 0l;
        
        
        v35 = v34;
    } else {
        
        
        v35 = false;
    }
    
    
    if (v35){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
