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
char runtime_byte0(String * v0, int32_t v1){
    
    
    char v2;
    v2 = v0->ptr[v1];
    
    StringDecref(v0);
    return v2;
}
int32_t codepoint_length_loop1(String * v0, char v1, char v2, int32_t v3, int32_t v4, int32_t v5){
    
    
    bool v6;
    v6 = v3 == v5;
    
    
    if (v6){
        
        StringDecref(v0);
        return v4;
    } else {
        
        
        char v7;
        v7 = v0->ptr[v3];
        
        
        bool v8;
        v8 = v7 < v1;
        
        
        bool v10;
        if (v8){
            
            
            v10 = false;
        } else {
            
            
            bool v9;
            v9 = v7 < v2;
            
            
            v10 = v9;
        }
        
        
        int32_t v12;
        if (v10){
            
            
            v12 = v4;
        } else {
            
            
            int32_t v11;
            v11 = v4 + 1l;
            
            
            v12 = v11;
        }
        
        
        int32_t v13;
        v13 = v3 + 1l;
        
        
        return codepoint_length_loop1(v0, v1, v2, v13, v12, v5);
    }
}
int32_t codepoint_byte_offset_loop2(String * v0, char v1, char v2, int32_t v3, int32_t v4, int32_t v5, int32_t v6){
    
    
    bool v7;
    v7 = v4 == v6;
    
    
    if (v7){
        
        StringDecref(v0);
        return v6;
    } else {
        
        
        char v8;
        v8 = v0->ptr[v4];
        
        
        bool v9;
        v9 = v8 < v1;
        
        
        bool v11;
        if (v9){
            
            
            v11 = false;
        } else {
            
            
            bool v10;
            v10 = v8 < v2;
            
            
            v11 = v10;
        }
        
        
        if (v11){
            
            
            int32_t v12;
            v12 = v4 + 1l;
            
            
            return codepoint_byte_offset_loop2(v0, v1, v2, v3, v12, v5, v6);
        } else {
            
            
            bool v14;
            v14 = v5 == v3;
            
            
            if (v14){
                
                StringDecref(v0);
                return v4;
            } else {
                
                
                int32_t v15;
                v15 = v4 + 1l;
                
                
                int32_t v16;
                v16 = v5 + 1l;
                
                
                return codepoint_byte_offset_loop2(v0, v1, v2, v3, v15, v16, v6);
            }
        }
    }
}
static inline String * StringSlice(String * value, int32_t from, int32_t to){
    int32_t length = (int32_t)value->len - 1;
    if (from < 0 || from > length || to < from - 1 || to >= length) { abort(); }
    uint32_t slice_len = to < from ? 0u : (uint32_t)(to - from + 1);
    if (slice_len != 0u && ((((uint8_t)value->ptr[from] & 0xC0u) == 0x80u) || (to + 1 < length && (((uint8_t)value->ptr[to + 1] & 0xC0u) == 0x80u)))) { abort(); }
    String * result = ArrayCreate0(slice_len + 1, false);
    if (slice_len != 0u) { memcpy(result->ptr, value->ptr + from, slice_len); }
    result->ptr[slice_len] = '\0';
    return result;
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(3, "À");
    
    
    int32_t v1;
    v1 = 1l;
    v0->refc++;
    
    char v2;
    v2 = runtime_byte0(v0, v1);
    
    
    String * v3;
    v3 = StringLit(3, "©");
    
    
    int32_t v4;
    v4 = 0l;
    v3->refc++;
    
    char v5;
    v5 = runtime_byte0(v3, v4);
    
    
    String * v6;
    v6 = StringLit(11, "Aéλ🙂Z");
    
    
    int32_t v7;
    v7 = 0l;
    
    
    int32_t v8;
    v8 = 0l;
    
    
    int32_t v9;
    v9 = 10l;
    v6->refc++;
    
    int32_t v10;
    v10 = codepoint_length_loop1(v6, v2, v5, v7, v8, v9);
    
    
    int32_t v11;
    v11 = 1l;
    v0->refc++;
    
    char v12;
    v12 = runtime_byte0(v0, v11);
    
    
    int32_t v13;
    v13 = 0l;
    v3->refc++;
    
    char v14;
    v14 = runtime_byte0(v3, v13);
    
    
    int32_t v15;
    v15 = 1l;
    
    
    int32_t v16;
    v16 = 0l;
    
    
    int32_t v17;
    v17 = 0l;
    
    
    int32_t v18;
    v18 = 10l;
    v6->refc++;
    
    int32_t v19;
    v19 = codepoint_byte_offset_loop2(v6, v12, v14, v15, v16, v17, v18);
    
    
    int32_t v20;
    v20 = 1l;
    v0->refc++;
    
    char v21;
    v21 = runtime_byte0(v0, v20);
    
    
    int32_t v22;
    v22 = 0l;
    v3->refc++;
    
    char v23;
    v23 = runtime_byte0(v3, v22);
    
    
    int32_t v24;
    v24 = 2l;
    
    
    int32_t v25;
    v25 = 0l;
    
    
    int32_t v26;
    v26 = 0l;
    
    
    int32_t v27;
    v27 = 10l;
    v6->refc++;
    
    int32_t v28;
    v28 = codepoint_byte_offset_loop2(v6, v21, v23, v24, v25, v26, v27);
    
    
    int32_t v29;
    v29 = v28 - 1l;
    
    
    String * v30;
    v30 = StringSlice(StringLit(11, "Aéλ🙂Z"), v19, v29);
    
    
    int32_t v31;
    v31 = 1l;
    v0->refc++;
    
    char v32;
    v32 = runtime_byte0(v0, v31);
    
    
    int32_t v33;
    v33 = 0l;
    v3->refc++;
    
    char v34;
    v34 = runtime_byte0(v3, v33);
    
    
    int32_t v35;
    v35 = 3l;
    
    
    int32_t v36;
    v36 = 0l;
    
    
    int32_t v37;
    v37 = 0l;
    
    
    int32_t v38;
    v38 = 10l;
    v6->refc++;
    
    int32_t v39;
    v39 = codepoint_byte_offset_loop2(v6, v32, v34, v35, v36, v37, v38);
    
    
    int32_t v40;
    v40 = 1l;
    v0->refc++;
    
    char v41;
    v41 = runtime_byte0(v0, v40);
    
    
    int32_t v42;
    v42 = 0l;
    v3->refc++;
    
    char v43;
    v43 = runtime_byte0(v3, v42);
    
    
    int32_t v44;
    v44 = 4l;
    
    
    int32_t v45;
    v45 = 0l;
    
    
    int32_t v46;
    v46 = 0l;
    
    
    int32_t v47;
    v47 = 10l;
    v6->refc++;
    
    int32_t v48;
    v48 = codepoint_byte_offset_loop2(v6, v41, v43, v44, v45, v46, v47);
    
    
    int32_t v49;
    v49 = v48 - 1l;
    
    
    String * v50;
    v50 = StringSlice(StringLit(11, "Aéλ🙂Z"), v39, v49);
    
    
    int32_t v51;
    v51 = 1l;
    v0->refc++;
    
    char v52;
    v52 = runtime_byte0(v0, v51);
    
    
    int32_t v53;
    v53 = 0l;
    v3->refc++;
    
    char v54;
    v54 = runtime_byte0(v3, v53);
    
    
    int32_t v55;
    v55 = 1l;
    
    
    int32_t v56;
    v56 = 0l;
    
    
    int32_t v57;
    v57 = 0l;
    
    
    int32_t v58;
    v58 = 10l;
    v6->refc++;
    
    int32_t v59;
    v59 = codepoint_byte_offset_loop2(v6, v52, v54, v55, v56, v57, v58);
    
    
    int32_t v60;
    v60 = 1l;
    v0->refc++;
    
    char v61;
    v61 = runtime_byte0(v0, v60);
    
    
    int32_t v62;
    v62 = 0l;
    v3->refc++;
    
    char v63;
    v63 = runtime_byte0(v3, v62);
    
    
    int32_t v64;
    v64 = 4l;
    
    
    int32_t v65;
    v65 = 0l;
    
    
    int32_t v66;
    v66 = 0l;
    
    
    int32_t v67;
    v67 = 10l;
    v6->refc++;
    
    int32_t v68;
    v68 = codepoint_byte_offset_loop2(v6, v61, v63, v64, v65, v66, v67);
    
    
    int32_t v69;
    v69 = v68 - 1l;
    
    
    String * v70;
    v70 = StringSlice(StringLit(11, "Aéλ🙂Z"), v59, v69);
    
    
    int32_t v71;
    v71 = 1l;
    v0->refc++;
    
    char v72;
    v72 = runtime_byte0(v0, v71);
    
    StringDecref(v0);
    int32_t v73;
    v73 = 0l;
    v3->refc++;
    
    char v74;
    v74 = runtime_byte0(v3, v73);
    
    StringDecref(v3);
    int32_t v75;
    v75 = 3l;
    
    
    int32_t v76;
    v76 = 0l;
    
    
    int32_t v77;
    v77 = 0l;
    
    
    int32_t v78;
    v78 = 10l;
    v6->refc++;
    
    int32_t v79;
    v79 = codepoint_byte_offset_loop2(v6, v72, v74, v75, v76, v77, v78);
    
    StringDecref(v6);
    int32_t v80;
    v80 = 0l;
    v30->refc++;
    
    char v81;
    v81 = runtime_byte0(v30, v80);
    
    
    String * v82;
    v82 = StringLit(3, "é");
    
    
    int32_t v83;
    v83 = 0l;
    v82->refc++;
    
    char v84;
    v84 = runtime_byte0(v82, v83);
    
    StringDecref(v82);
    int32_t v85;
    v85 = 3l;
    v50->refc++;
    
    char v86;
    v86 = runtime_byte0(v50, v85);
    
    
    String * v87;
    v87 = StringLit(5, "🙂");
    
    
    int32_t v88;
    v88 = 3l;
    v87->refc++;
    
    char v89;
    v89 = runtime_byte0(v87, v88);
    
    StringDecref(v87);
    bool v90;
    v90 = v10 == 5l;
    
    
    if (v90){
        
        
        int32_t v91;
        v91 = v30->len-1;
        
        StringDecref(v30);
        bool v92;
        v92 = v91 == 2l;
        
        
        if (v92){
            
            
            bool v93;
            v93 = v81 == v84;
            
            
            if (v93){
                
                
                int32_t v94;
                v94 = v50->len-1;
                
                StringDecref(v50);
                bool v95;
                v95 = v94 == 4l;
                
                
                if (v95){
                    
                    
                    bool v96;
                    v96 = v86 == v89;
                    
                    
                    if (v96){
                        
                        
                        int32_t v97;
                        v97 = v70->len-1;
                        
                        StringDecref(v70);
                        bool v98;
                        v98 = v97 == 8l;
                        
                        
                        if (v98){
                            
                            
                            bool v99;
                            v99 = v79 == 5l;
                            
                            
                            if (v99){
                                
                                
                                return 0l;
                            } else {
                                
                                
                                return 1l;
                            }
                        } else {
                            
                            
                            return 2l;
                        }
                    } else {
                        
                        StringDecref(v70);
                        return 3l;
                    }
                } else {
                    
                    StringDecref(v70);
                    return 4l;
                }
            } else {
                
                StringDecref(v50); StringDecref(v70);
                return 5l;
            }
        } else {
            
            StringDecref(v50); StringDecref(v70);
            return 6l;
        }
    } else {
        
        StringDecref(v30); StringDecref(v50); StringDecref(v70);
        return 7l;
    }
}
