#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v1;
            UH0 * v2;
            int32_t v0;
        } case1; // Node
    };
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v1); UHDecref0(x->case1.v2);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_Leaf() { // Leaf
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_Node(int32_t v0, UH0 * v1, UH0 * v2) { // Node
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1; x->case1.v2 = v2;
    return x;
}
int32_t sum0(UH0 * v0){
    
    
    switch (v0->tag) {
        case 0: { // Leaf
            
            
            UHDecref0(v0);
            return 0l;
            break;
        }
        case 1: { // Node
            int32_t v1 = v0->case1.v0; UH0 * v2 = v0->case1.v1; UH0 * v3 = v0->case1.v2;
            v2->refc += 2; v3->refc++;
            UHDecref0(v0);
            int32_t v4;
            v4 = sum0(v2);
            v3->refc++;
            UHDecref0(v2);
            int32_t v5;
            v5 = sum0(v3);
            
            UHDecref0(v3);
            int32_t v6;
            v6 = v4 + v5;
            
            
            int32_t v7;
            v7 = v1 + v6;
            
            
            return v7;
            break;
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    int32_t v1;
    v1 = 2l;
    
    
    UH0 * v2;
    v2 = UH0_Leaf();
    v2->refc += 2;
    
    UH0 * v3;
    v3 = UH0_Node(v1, v2, v2);
    v3->refc += 2;
    UHDecref0(v2);
    UH0 * v4;
    v4 = UH0_Node(v0, v3, v3);
    v4->refc++;
    UHDecref0(v3);
    int32_t v5;
    v5 = sum0(v4);
    
    UHDecref0(v4);
    int32_t v6;
    v6 = v5 - 5l;
    
    
    return v6;
}
