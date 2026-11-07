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
US0 US0_Northward() { // Northward
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Eastward() { // Eastward
    US0 x;
    x.tag = 1;
    return x;
}
US0 US0_Southward() { // Southward
    US0 x;
    x.tag = 2;
    return x;
}
US0 US0_Westward() { // Westward
    US0 x;
    x.tag = 3;
    return x;
}
int32_t main(){
    US0 v0 = US0_Southward();
    int32_t v1 = v0.tag;
    bool v2 = v1 == 2l;
    if (v2){
        return 0l;
    } else {
        return 1l;
    }
}
