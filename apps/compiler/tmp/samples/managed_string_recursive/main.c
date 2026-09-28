#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            String * v0;
            UH0 * v1;
            UH0 * v2;
        } case1; // Node
    };
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
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            StringDecref(x->case1.v0); UHDecref0(x->case1.v1); UHDecref0(x->case1.v2);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0() { // Empty
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_1(String * v0, UH0 * v1, UH0 * v2) { // Node
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1; x->case1.v2 = v2;
    return x;
}
int32_t score0(UH0 * v0){
    
    
    switch (v0->tag) {
        case 0: { // Empty
            
            
            UHDecref0(v0);
            return 0l;
            break;
        }
        case 1: { // Node
            String * v1 = v0->case1.v0; UH0 * v2 = v0->case1.v1; UH0 * v3 = v0->case1.v2;
            v1->refc++; v2->refc++; v3->refc++;
            UHDecref0(v0);
            int32_t v4;
            v4 = v1->len-1;
            v2->refc++;
            StringDecref(v1);
            int32_t v5;
            v5 = score0(v2);
            
            UHDecref0(v2);
            int32_t v6;
            v6 = v4 + v5 ;
            v3->refc++;
            
            int32_t v7;
            v7 = score0(v3);
            
            UHDecref0(v3);
            int32_t v8;
            v8 = v6 + v7 ;
            
            
            return v8;
            break;
        }
    }
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(3, "ab");
    
    
    String * v1;
    v1 = StringLit(4, "qwe");
    
    
    UH0 * v2;
    v2 = UH0_0();
    v1->refc++; v2->refc += 2;
    
    UH0 * v3;
    v3 = UH0_1(v1, v2, v2);
    v0->refc++; v3->refc += 2;
    UHDecref0(v2);
    UH0 * v4;
    v4 = UH0_1(v0, v3, v3);
    v4->refc++;
    UHDecref0(v3);
    int32_t v5;
    v5 = score0(v4);
    
    UHDecref0(v4);
    UH0 * v6;
    v6 = UH0_0();
    v1->refc++; v6->refc += 2;
    
    UH0 * v7;
    v7 = UH0_1(v1, v6, v6);
    v0->refc++; v7->refc += 2;
    StringDecref(v1); UHDecref0(v6);
    UH0 * v8;
    v8 = UH0_1(v0, v7, v7);
    v8->refc++;
    StringDecref(v0); UHDecref0(v7);
    int32_t v9;
    v9 = score0(v8);
    
    UHDecref0(v8);
    int32_t v10;
    v10 = v5 + v9 ;
    
    
    int32_t v11;
    v11 = v10 - 16l ;
    
    
    return v11;
}
