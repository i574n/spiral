#include <stdint.h>
#include <stdio.h>
#include <string.h>
#include <stdbool.h>
#include <stdlib.h>
#include <ctype.h>
#include <errno.h>
static bool spiral_integer_text_ok(const char *s) { char *end; while (isspace((unsigned char)*s)) s++; if (!*s) return false; errno = 0; strtoll(s, &end, 10); if (errno != 0 || end == s) return false; while (isspace((unsigned char)*end)) end++; return *end == 0; }
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // Some
    };
} US0;
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
US0 US0_Some(int32_t v0) { // Some
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_None() { // None
    US0 x;
    x.tag = 1;
    return x;
}
int32_t main(){
    String * v0 = StringLit(3, "ff");
    int32_t v1 = (int32_t)strtol((v0)->ptr, NULL, 16l);
    StringDecref(v0);
    printf("%d\n", v1);
    String * v2 = StringLit(5, "1011");
    int32_t v3 = (int32_t)strtol((v2)->ptr, NULL, 2l);
    StringDecref(v2);
    printf("%d\n", v3);
    String * v4 = StringLit(4, "-42");
    int32_t v5 = (int32_t)strtol((v4)->ptr, NULL, 10l);
    StringDecref(v4);
    printf("%d\n", v5);
    String * v6 = StringLit(6, " 123 ");
    bool v7 = spiral_integer_text_ok((v6)->ptr);
    int64_t v8 = strtoll((v6)->ptr, NULL, 10);
    StringDecref(v6);
    int32_t v9 = (int32_t)v8;
    bool v13;
    if (v7){
        bool v10 = v8 >= -2147483648ll;
        if (v10){
            bool v11 = v8 <= 2147483647ll;
            v13 = v11;
        } else {
            v13 = false;
        }
    } else {
        v13 = false;
    }
    US0 v16;
    if (v13){
        v16 = US0_Some(v9);
    } else {
        v16 = US0_None();
    }
    switch (v16.tag) {
        case 1: { // None
            String * v18 = StringLit(5, "none");
            printf("%s\n", (v18)->ptr);
            StringDecref(v18);
            break;
        }
        default: { // Some
            int32_t v17 = v16.case0.v0;
            printf("%d\n", v17);
            break;
        }
    }
    String * v19 = StringLit(4, "12x");
    bool v20 = spiral_integer_text_ok((v19)->ptr);
    int64_t v21 = strtoll((v19)->ptr, NULL, 10);
    StringDecref(v19);
    int32_t v22 = (int32_t)v21;
    bool v26;
    if (v20){
        bool v23 = v21 >= -2147483648ll;
        if (v23){
            bool v24 = v21 <= 2147483647ll;
            v26 = v24;
        } else {
            v26 = false;
        }
    } else {
        v26 = false;
    }
    US0 v29;
    if (v26){
        v29 = US0_Some(v22);
    } else {
        v29 = US0_None();
    }
    switch (v29.tag) {
        case 1: { // None
            String * v31 = StringLit(5, "none");
            printf("%s\n", (v31)->ptr);
            StringDecref(v31);
            break;
        }
        default: { // Some
            int32_t v30 = v29.case0.v0;
            printf("%d\n", v30);
            break;
        }
    }
    String * v32 = StringLit(1, "");
    bool v33 = spiral_integer_text_ok((v32)->ptr);
    int64_t v34 = strtoll((v32)->ptr, NULL, 10);
    StringDecref(v32);
    int32_t v35 = (int32_t)v34;
    bool v39;
    if (v33){
        bool v36 = v34 >= -2147483648ll;
        if (v36){
            bool v37 = v34 <= 2147483647ll;
            v39 = v37;
        } else {
            v39 = false;
        }
    } else {
        v39 = false;
    }
    US0 v42;
    if (v39){
        v42 = US0_Some(v35);
    } else {
        v42 = US0_None();
    }
    switch (v42.tag) {
        case 1: { // None
            String * v44 = StringLit(5, "none");
            printf("%s\n", (v44)->ptr);
            StringDecref(v44);
            break;
        }
        default: { // Some
            int32_t v43 = v42.case0.v0;
            printf("%d\n", v43);
            break;
        }
    }
    String * v45 = StringLit(3, "+7");
    bool v46 = spiral_integer_text_ok((v45)->ptr);
    int64_t v47 = strtoll((v45)->ptr, NULL, 10);
    StringDecref(v45);
    int32_t v48 = (int32_t)v47;
    bool v52;
    if (v46){
        bool v49 = v47 >= -2147483648ll;
        if (v49){
            bool v50 = v47 <= 2147483647ll;
            v52 = v50;
        } else {
            v52 = false;
        }
    } else {
        v52 = false;
    }
    US0 v55;
    if (v52){
        v55 = US0_Some(v48);
    } else {
        v55 = US0_None();
    }
    switch (v55.tag) {
        case 1: { // None
            String * v57 = StringLit(5, "none");
            printf("%s\n", (v57)->ptr);
            StringDecref(v57);
            break;
        }
        default: { // Some
            int32_t v56 = v55.case0.v0;
            printf("%d\n", v56);
            break;
        }
    }
    return 0l;
}
