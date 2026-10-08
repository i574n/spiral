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
char runtime_byte1(String * v0, int32_t v1){
    
    
    char v2;
    v2 = v0->ptr[v1];
    
    StringDecref(v0);
    return v2;
}
int32_t utf8_scalar_at_byte_offset0(String * v0, int32_t v1){
    
    
    int32_t v2;
    v2 = v0->len-1;
    
    
    bool v3;
    v3 = v1 < 0l;
    
    
    if (v3){
        
        StringDecref(v0);
        fprintf(stderr, "%s\n", "UTF-8 byte offset is negative.");
        exit(EXIT_FAILURE);
    } else {
        
        
        bool v5;
        v5 = v1 >= v2;
        
        
        if (v5){
            
            StringDecref(v0);
            fprintf(stderr, "%s\n", "UTF-8 byte offset is outside the string.");
            exit(EXIT_FAILURE);
        } else {
            v0->refc++;
            
            char v7;
            v7 = runtime_byte1(v0, v1);
            
            
            int32_t v8;
            v8 = ((uint8_t)v7);
            
            
            bool v18;
            v18 = v8 < 128l;
            
            
            if (v18){
                
                StringDecref(v0);
                return v8;
            } else {
                
                
                bool v19;
                v19 = v8 < 194l;
                
                
                if (v19){
                    
                    StringDecref(v0);
                    fprintf(stderr, "%s\n", "UTF-8 scalar starts with an invalid lead byte.");
                    exit(EXIT_FAILURE);
                } else {
                    
                    
                    bool v21;
                    v21 = v8 < 224l;
                    
                    
                    if (v21){
                        
                        
                        int32_t v22;
                        v22 = v1 + 1l;
                        
                        
                        bool v23;
                        v23 = v22 >= v2;
                        
                        
                        if (v23){
                            
                            StringDecref(v0);
                            fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                            exit(EXIT_FAILURE);
                        } else {
                            v0->refc++;
                            
                            char v25;
                            v25 = runtime_byte1(v0, v22);
                            
                            StringDecref(v0);
                            int32_t v26;
                            v26 = ((uint8_t)v25);
                            
                            
                            bool v27;
                            v27 = v26 < 128l;
                            
                            
                            bool v29;
                            if (v27){
                                
                                
                                v29 = false;
                            } else {
                                
                                
                                bool v28;
                                v28 = v26 < 192l;
                                
                                
                                v29 = v28;
                            }
                            
                            
                            if (v29){
                                
                                
                                int32_t v30;
                                v30 = v8 - 192l;
                                
                                
                                int32_t v31;
                                v31 = v30 * 64l;
                                
                                
                                int32_t v32;
                                v32 = v26 - 128l;
                                
                                
                                int32_t v33;
                                v33 = v31 + v32;
                                
                                
                                return v33;
                            } else {
                                
                                
                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    } else {
                        
                        
                        bool v37;
                        v37 = v8 < 240l;
                        
                        
                        if (v37){
                            
                            
                            int32_t v38;
                            v38 = v1 + 2l;
                            
                            
                            bool v39;
                            v39 = v38 >= v2;
                            
                            
                            if (v39){
                                
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                exit(EXIT_FAILURE);
                            } else {
                                
                                
                                int32_t v41;
                                v41 = v1 + 1l;
                                v0->refc++;
                                
                                char v42;
                                v42 = runtime_byte1(v0, v41);
                                
                                
                                int32_t v43;
                                v43 = ((uint8_t)v42);
                                v0->refc++;
                                
                                char v44;
                                v44 = runtime_byte1(v0, v38);
                                
                                StringDecref(v0);
                                int32_t v45;
                                v45 = ((uint8_t)v44);
                                
                                
                                bool v46;
                                v46 = v43 < 128l;
                                
                                
                                bool v48;
                                if (v46){
                                    
                                    
                                    v48 = false;
                                } else {
                                    
                                    
                                    bool v47;
                                    v47 = v43 < 192l;
                                    
                                    
                                    v48 = v47;
                                }
                                
                                
                                if (v48){
                                    
                                    
                                    bool v49;
                                    v49 = v45 < 128l;
                                    
                                    
                                    bool v51;
                                    if (v49){
                                        
                                        
                                        v51 = false;
                                    } else {
                                        
                                        
                                        bool v50;
                                        v50 = v45 < 192l;
                                        
                                        
                                        v51 = v50;
                                    }
                                    
                                    
                                    if (v51){
                                        
                                        
                                        int32_t v52;
                                        v52 = v8 - 224l;
                                        
                                        
                                        int32_t v53;
                                        v53 = v52 * 4096l;
                                        
                                        
                                        int32_t v54;
                                        v54 = v43 - 128l;
                                        
                                        
                                        int32_t v55;
                                        v55 = v54 * 64l;
                                        
                                        
                                        int32_t v56;
                                        v56 = v53 + v55;
                                        
                                        
                                        int32_t v57;
                                        v57 = v45 - 128l;
                                        
                                        
                                        int32_t v58;
                                        v58 = v56 + v57;
                                        
                                        
                                        bool v59;
                                        v59 = v58 < 2048l;
                                        
                                        
                                        if (v59){
                                            
                                            
                                            fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                            exit(EXIT_FAILURE);
                                        } else {
                                            
                                            
                                            bool v61;
                                            v61 = v58 >= 55296l;
                                            
                                            
                                            if (v61){
                                                
                                                
                                                bool v62;
                                                v62 = v58 <= 57343l;
                                                
                                                
                                                if (v62){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence encodes a surrogate.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    return v58;
                                                }
                                            } else {
                                                
                                                
                                                return v58;
                                            }
                                        }
                                    } else {
                                        
                                        
                                        fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                        exit(EXIT_FAILURE);
                                    }
                                } else {
                                    
                                    
                                    fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                    exit(EXIT_FAILURE);
                                }
                            }
                        } else {
                            
                            
                            bool v72;
                            v72 = v8 < 245l;
                            
                            
                            if (v72){
                                
                                
                                int32_t v73;
                                v73 = v1 + 3l;
                                
                                
                                bool v74;
                                v74 = v73 >= v2;
                                
                                
                                if (v74){
                                    
                                    StringDecref(v0);
                                    fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                    exit(EXIT_FAILURE);
                                } else {
                                    
                                    
                                    int32_t v76;
                                    v76 = v1 + 1l;
                                    v0->refc++;
                                    
                                    char v77;
                                    v77 = runtime_byte1(v0, v76);
                                    
                                    
                                    int32_t v78;
                                    v78 = ((uint8_t)v77);
                                    
                                    
                                    int32_t v79;
                                    v79 = v1 + 2l;
                                    v0->refc++;
                                    
                                    char v80;
                                    v80 = runtime_byte1(v0, v79);
                                    
                                    
                                    int32_t v81;
                                    v81 = ((uint8_t)v80);
                                    v0->refc++;
                                    
                                    char v82;
                                    v82 = runtime_byte1(v0, v73);
                                    
                                    StringDecref(v0);
                                    int32_t v83;
                                    v83 = ((uint8_t)v82);
                                    
                                    
                                    bool v84;
                                    v84 = v78 < 128l;
                                    
                                    
                                    bool v86;
                                    if (v84){
                                        
                                        
                                        v86 = false;
                                    } else {
                                        
                                        
                                        bool v85;
                                        v85 = v78 < 192l;
                                        
                                        
                                        v86 = v85;
                                    }
                                    
                                    
                                    if (v86){
                                        
                                        
                                        bool v87;
                                        v87 = v81 < 128l;
                                        
                                        
                                        bool v89;
                                        if (v87){
                                            
                                            
                                            v89 = false;
                                        } else {
                                            
                                            
                                            bool v88;
                                            v88 = v81 < 192l;
                                            
                                            
                                            v89 = v88;
                                        }
                                        
                                        
                                        if (v89){
                                            
                                            
                                            bool v90;
                                            v90 = v83 < 128l;
                                            
                                            
                                            bool v92;
                                            if (v90){
                                                
                                                
                                                v92 = false;
                                            } else {
                                                
                                                
                                                bool v91;
                                                v91 = v83 < 192l;
                                                
                                                
                                                v92 = v91;
                                            }
                                            
                                            
                                            if (v92){
                                                
                                                
                                                int32_t v93;
                                                v93 = v8 - 240l;
                                                
                                                
                                                int32_t v94;
                                                v94 = v93 * 262144l;
                                                
                                                
                                                int32_t v95;
                                                v95 = v78 - 128l;
                                                
                                                
                                                int32_t v96;
                                                v96 = v95 * 4096l;
                                                
                                                
                                                int32_t v97;
                                                v97 = v94 + v96;
                                                
                                                
                                                int32_t v98;
                                                v98 = v81 - 128l;
                                                
                                                
                                                int32_t v99;
                                                v99 = v98 * 64l;
                                                
                                                
                                                int32_t v100;
                                                v100 = v97 + v99;
                                                
                                                
                                                int32_t v101;
                                                v101 = v83 - 128l;
                                                
                                                
                                                int32_t v102;
                                                v102 = v100 + v101;
                                                
                                                
                                                bool v103;
                                                v103 = v102 < 65536l;
                                                
                                                
                                                if (v103){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    bool v105;
                                                    v105 = v102 > 1114111l;
                                                    
                                                    
                                                    if (v105){
                                                        
                                                        
                                                        fprintf(stderr, "%s\n", "UTF-8 scalar is above U+10FFFF.");
                                                        exit(EXIT_FAILURE);
                                                    } else {
                                                        
                                                        
                                                        return v102;
                                                    }
                                                }
                                            } else {
                                                
                                                
                                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                                exit(EXIT_FAILURE);
                                            }
                                        } else {
                                            
                                            
                                            fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                            exit(EXIT_FAILURE);
                                        }
                                    } else {
                                        
                                        
                                        fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                        exit(EXIT_FAILURE);
                                    }
                                }
                            } else {
                                
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 scalar starts with an invalid lead byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    }
                }
            }
        }
    }
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(11, "Aéλ🙂Z");
    
    
    int32_t v1;
    v1 = 0l;
    v0->refc++;
    
    int32_t v2;
    v2 = utf8_scalar_at_byte_offset0(v0, v1);
    
    
    int32_t v3;
    v3 = 1l;
    v0->refc++;
    
    int32_t v4;
    v4 = utf8_scalar_at_byte_offset0(v0, v3);
    
    
    int32_t v5;
    v5 = 3l;
    v0->refc++;
    
    int32_t v6;
    v6 = utf8_scalar_at_byte_offset0(v0, v5);
    
    
    int32_t v7;
    v7 = 5l;
    v0->refc++;
    
    int32_t v8;
    v8 = utf8_scalar_at_byte_offset0(v0, v7);
    
    
    int32_t v9;
    v9 = 9l;
    v0->refc++;
    
    int32_t v10;
    v10 = utf8_scalar_at_byte_offset0(v0, v9);
    
    StringDecref(v0);
    bool v11;
    v11 = v2 == 65l;
    
    
    if (v11){
        
        
        bool v12;
        v12 = v4 == 233l;
        
        
        if (v12){
            
            
            bool v13;
            v13 = v6 == 955l;
            
            
            if (v13){
                
                
                bool v14;
                v14 = v8 == 128578l;
                
                
                if (v14){
                    
                    
                    bool v15;
                    v15 = v10 == 90l;
                    
                    
                    if (v15){
                        
                        
                        return 0l;
                    } else {
                        
                        
                        return 5l;
                    }
                } else {
                    
                    
                    return 4l;
                }
            } else {
                
                
                return 3l;
            }
        } else {
            
            
            return 2l;
        }
    } else {
        
        
        return 1l;
    }
}
