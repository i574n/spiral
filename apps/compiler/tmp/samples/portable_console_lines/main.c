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
int32_t main(){
    
    
    String * v15;
    v15 = StringLit(6, "hello");
    
    
    
    printf("%s\n", (v15)->ptr);
    
    StringDecref(v15);
    int32_t v16;
    v16 = 42l;
    
    
    
    printf("%d\n", v16);
    
    
    String * v30;
    v30 = StringLit(2, "a");
    
    
    
    printf("%s", (v30)->ptr);
    
    StringDecref(v30);
    String * v41;
    v41 = StringLit(2, "b");
    
    
    
    printf("%s", (v41)->ptr);
    
    StringDecref(v41);
    String * v53;
    v53 = StringLit(1, "");
    
    
    
    printf("%s\n", (v53)->ptr);
    
    StringDecref(v53);
    int64_t v54;
    v54 = -7ll;
    
    
    
    printf("%lld\n", (long long)(v54));
    
    
    return 0l;
}
