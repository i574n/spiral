#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
static void UHDecref0(UH0 * x);
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // Cell
    };
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
    }
}
static void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_Cell(int32_t v0) { // Cell
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0;
    return x;
}
static bool is_even0(int32_t v0);
static bool is_odd1(int32_t v0){
    UH0 * v1 = UH0_Cell(v0);
    switch (v1->tag) {
        default: { // Cell
            int32_t v2 = v1->case0.v0;
            UHDecref0(v1);
            bool v3 = v2 == 0l;
            if (v3){
                return false;
            } else {
                int32_t v4 = v2 - 1l;
                return is_even0(v4);
            }
            break;
        }
    }
}
static bool is_even0(int32_t v0){
    UH0 * v1 = UH0_Cell(v0);
    switch (v1->tag) {
        default: { // Cell
            int32_t v2 = v1->case0.v0;
            UHDecref0(v1);
            bool v3 = v2 == 0l;
            if (v3){
                return true;
            } else {
                int32_t v4 = v2 - 1l;
                return is_odd1(v4);
            }
            break;
        }
    }
}
int32_t main(){
    int32_t v0 = 1000l;
    bool v1 = is_even0(v0);
    if (v1){
        return 0l;
    } else {
        return 1l;
    }
}
