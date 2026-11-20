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
static inline String * StringFromI64(int64_t value){
    char buffer[24];
    int length = snprintf(buffer, sizeof buffer, "%lld", (long long)value);
    String * result = ArrayCreate0((uint32_t)length + 1, false);
    memcpy(result->ptr, buffer, (size_t)length + 1);
    return result;
}
static inline String * StringFromU64(uint64_t value){
    char buffer[24];
    int length = snprintf(buffer, sizeof buffer, "%llu", (unsigned long long)value);
    String * result = ArrayCreate0((uint32_t)length + 1, false);
    memcpy(result->ptr, buffer, (size_t)length + 1);
    return result;
}
static inline String * StringFromBool(bool value){
    return value ? StringLit(5, "true") : StringLit(6, "false");
}
static inline String * StringFromChar(char value){
    String * result = ArrayCreate0(2, false);
    result->ptr[0] = value;
    result->ptr[1] = '\0';
    return result;
}
int32_t main(){
    int8_t v0 = -128;
    int16_t v1 = -32768;
    int32_t v2 = -5l;
    int64_t v3 = -1234567890123ll;
    uint8_t v4 = 255u;
    uint16_t v5 = 65535u;
    uint32_t v6 = 4294967295ul;
    uint64_t v7 = 18446744073709551615ull;
    bool v8 = true;
    bool v9 = false;
    char v10 = 'a';
    String * v11 = StringFromI64((int64_t)v0);
    bool v12 = strcmp(v11->ptr, "-128") == 0;
    StringDecref(v11);
    int32_t v13;
    if (v12){
        v13 = 0l;
    } else {
        v13 = 1l;
    }
    String * v14 = StringFromI64((int64_t)v1);
    bool v15 = strcmp(v14->ptr, "-32768") == 0;
    StringDecref(v14);
    int32_t v16;
    if (v15){
        v16 = 0l;
    } else {
        v16 = 1l;
    }
    int32_t v17 = v13 + v16;
    String * v18 = StringFromI64((int64_t)v2);
    bool v19 = strcmp(v18->ptr, "-5") == 0;
    StringDecref(v18);
    int32_t v20;
    if (v19){
        v20 = 0l;
    } else {
        v20 = 1l;
    }
    int32_t v21 = v17 + v20;
    String * v22 = StringFromI64((int64_t)v3);
    bool v23 = strcmp(v22->ptr, "-1234567890123") == 0;
    StringDecref(v22);
    int32_t v24;
    if (v23){
        v24 = 0l;
    } else {
        v24 = 1l;
    }
    int32_t v25 = v21 + v24;
    String * v26 = StringFromU64((uint64_t)v4);
    bool v27 = strcmp(v26->ptr, "255") == 0;
    StringDecref(v26);
    int32_t v28;
    if (v27){
        v28 = 0l;
    } else {
        v28 = 1l;
    }
    int32_t v29 = v25 + v28;
    String * v30 = StringFromU64((uint64_t)v5);
    bool v31 = strcmp(v30->ptr, "65535") == 0;
    StringDecref(v30);
    int32_t v32;
    if (v31){
        v32 = 0l;
    } else {
        v32 = 1l;
    }
    int32_t v33 = v29 + v32;
    String * v34 = StringFromU64((uint64_t)v6);
    bool v35 = strcmp(v34->ptr, "4294967295") == 0;
    StringDecref(v34);
    int32_t v36;
    if (v35){
        v36 = 0l;
    } else {
        v36 = 1l;
    }
    int32_t v37 = v33 + v36;
    String * v38 = StringFromU64((uint64_t)v7);
    bool v39 = strcmp(v38->ptr, "18446744073709551615") == 0;
    StringDecref(v38);
    int32_t v40;
    if (v39){
        v40 = 0l;
    } else {
        v40 = 1l;
    }
    int32_t v41 = v37 + v40;
    String * v42 = StringFromBool(v8);
    bool v43 = strcmp(v42->ptr, "true") == 0;
    StringDecref(v42);
    int32_t v44;
    if (v43){
        v44 = 0l;
    } else {
        v44 = 1l;
    }
    int32_t v45 = v41 + v44;
    String * v46 = StringFromBool(v9);
    bool v47 = strcmp(v46->ptr, "false") == 0;
    StringDecref(v46);
    int32_t v48;
    if (v47){
        v48 = 0l;
    } else {
        v48 = 1l;
    }
    int32_t v49 = v45 + v48;
    String * v50 = StringFromChar(v10);
    bool v51 = strcmp(v50->ptr, "a") == 0;
    StringDecref(v50);
    int32_t v52;
    if (v51){
        v52 = 0l;
    } else {
        v52 = 1l;
    }
    int32_t v53 = v49 + v52;
    String * v54 = StringFromU64((uint64_t)7u);
    bool v55 = strcmp(v54->ptr, "7") == 0;
    StringDecref(v54);
    int32_t v56;
    if (v55){
        v56 = 0l;
    } else {
        v56 = 1l;
    }
    int32_t v57 = v53 + v56;
    String * v58 = StringFromBool(false);
    bool v59 = strcmp(v58->ptr, "false") == 0;
    StringDecref(v58);
    int32_t v60;
    if (v59){
        v60 = 0l;
    } else {
        v60 = 1l;
    }
    int32_t v61 = v57 + v60;
    String * v62 = StringFromChar('z');
    bool v63 = strcmp(v62->ptr, "z") == 0;
    StringDecref(v62);
    int32_t v64;
    if (v63){
        v64 = 0l;
    } else {
        v64 = 1l;
    }
    int32_t v65 = v61 + v64;
    String * v66 = StringFromI64((int64_t)-3ll);
    bool v67 = strcmp(v66->ptr, "-3") == 0;
    StringDecref(v66);
    int32_t v68;
    if (v67){
        v68 = 0l;
    } else {
        v68 = 1l;
    }
    int32_t v69 = v65 + v68;
    return v69;
}
