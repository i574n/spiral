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
    int tag;
    union {
        struct {
            Heap0 * v0;
            Heap0 * v1;
            Heap0 * v2;
        } case1; // Held
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    US0 ptr[];
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
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++; (x->case1.v1)->refc++; (x->case1.v2)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            HeapDecref0(x->case1.v0); HeapDecref0(x->case1.v1); HeapDecref0(x->case1.v2);
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
US0 US0_Held(Heap0 * v0, Heap0 * v1, Heap0 * v2) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2;
    return x;
}
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    US0 * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        US0 v = ptr[i];
        USDecref0(&(v));
    }
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(US0) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, US0 * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(US0) * len);
        for (uint32_t i=0; i < len; i++){
            US0 v = ptr[i];
            USIncref0(&(v));
        }
    return x;
}
static inline void AssignArray0(US0 * a, US0 b){
    USIncref0(&(b));
    USDecref0(&(*a));
    *a = b;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Held
            Heap0 * v1 = v0.case1.v0; Heap0 * v2 = v0.case1.v1; Heap0 * v3 = v0.case1.v2;
            (v1)->refc++; (v2)->refc++; (v3)->refc++;
            USDecref0(&(v0));
            int32_t v4; String * v5;
            v4 = v1->v0; v5 = v1->v1;
            (v5)->refc++;
            HeapDecref0(v1);
            int32_t v6; String * v7;
            v6 = v2->v0; v7 = v2->v1;
            (v7)->refc++;
            HeapDecref0(v2);
            int32_t v8; String * v9;
            v8 = v3->v0; v9 = v3->v1;
            (v9)->refc++;
            HeapDecref0(v3);
            bool v10;
            v10 = v4 == 7l;
            
            
            bool v12;
            if (v10){
                
                
                bool v11;
                v11 = strcmp(v5->ptr, "hi") == 0;
                
                
                v12 = v11;
            } else {
                
                
                v12 = false;
            }
            
            StringDecref(v5);
            bool v14;
            if (v12){
                
                
                bool v13;
                v13 = v6 == 4l;
                
                
                v14 = v13;
            } else {
                
                
                v14 = false;
            }
            
            
            bool v16;
            if (v14){
                
                
                bool v15;
                v15 = strcmp(v7->ptr, "yo") == 0;
                
                
                v16 = v15;
            } else {
                
                
                v16 = false;
            }
            
            StringDecref(v7);
            bool v18;
            if (v16){
                
                
                bool v17;
                v17 = v8 == 9l;
                
                
                v18 = v17;
            } else {
                
                
                v18 = false;
            }
            
            
            bool v20;
            if (v18){
                
                
                bool v19;
                v19 = strcmp(v9->ptr, "ok") == 0;
                
                
                v20 = v19;
            } else {
                
                
                v20 = false;
            }
            
            StringDecref(v9);
            if (v20){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
        default: { // None
            
            
            USDecref0(&(v0));
            return 1l;
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
    
    StringDecref(v4);
    int32_t v6;
    v6 = 9l;
    
    
    String * v7;
    v7 = StringLit(3, "ok");
    (v7)->refc++;
    
    Heap0 * v8;
    v8 = HeapCreate0(v6, v7);
    
    StringDecref(v7);
    Array1 * v9;
    v9 = ArrayCreate1(1l, true);
    
    
    bool v10;
    v10 = true;
    
    
    US0 v13;
    if (v10){
        (v2)->refc++; (v5)->refc++; (v8)->refc++;
        
        v13 = US0_Held(v2, v5, v8);
    } else {
        
        
        v13 = US0_None();
    }
    
    HeapDecref0(v2); HeapDecref0(v5); HeapDecref0(v8);
    
    AssignArray0(&(v9->ptr[0l]), v13);
    
    USDecref0(&(v13));
    US0 v14;
    v14 = v9->ptr[0l];
    USIncref0(&(v14));
    ArrayDecref1(v9);
    return score0(v14);
}
