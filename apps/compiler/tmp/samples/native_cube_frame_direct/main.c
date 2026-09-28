#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array1;
typedef Array1 String;
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
bool method_while0(int32_t v0){
    bool v1;
    v1 = v0 < 7040l;
    return v1;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    *a = b;
}
Array0 * method0(){
    Array0 * v0;
    v0 = ArrayCreate0(7040l, false);
    int32_t v1;
    v1 = 0l;
    while (method_while0(v1)){
        AssignArray0(&(v0->ptr[v1]), 46l);
        int32_t v3;
        v3 = v1 + 1l;
        v1 = v3;
    }
    return v0;
}
int32_t method1(Array0 * v0){
    AssignArray0(&(v0->ptr[5180l]), 35l);
    ArrayDecref0(v0);
    return 5180l;
}
int32_t method2(Array0 * v0){
    AssignArray0(&(v0->ptr[4258l]), 64l);
    ArrayDecref0(v0);
    return 4258l;
}
int32_t method3(Array0 * v0){
    AssignArray0(&(v0->ptr[3964l]), 43l);
    ArrayDecref0(v0);
    return 3964l;
}
static inline void ArrayDecrefBody1(Array1 * x){
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(char) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, char * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref1(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit1(len, ptr);
}
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate1(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
}
String * frame_text_loop4(Array0 * v0, int32_t v1, int32_t v2, int32_t v3, String * v4){
    bool v5;
    v5 = v3 == v2;
    if (v5){
        ArrayDecref0(v0);
        return v4;
    } else {
        int32_t v6;
        v6 = v0->ptr[v3];
        bool v7;
        v7 = v6 == 35l;
        String * v16;
        if (v7){
            String * v8;
            v8 = StringLit(2, "#");
            v16 = v8;
        } else {
            bool v9;
            v9 = v6 == 43l;
            if (v9){
                String * v10;
                v10 = StringLit(2, "+");
                v16 = v10;
            } else {
                bool v11;
                v11 = v6 == 64l;
                if (v11){
                    String * v12;
                    v12 = StringLit(2, "@");
                    v16 = v12;
                } else {
                    String * v13;
                    v13 = StringLit(2, ".");
                    v16 = v13;
                }
            }
        }
        String * v17;
        v17 = StringConcat(v4, v16);
        StringDecref(v4); StringDecref(v16);
        int32_t v18;
        v18 = v3 + 1l;
        int32_t v19;
        v19 = v3 % v1;
        int32_t v20;
        v20 = v1 - 1l;
        bool v21;
        v21 = v19 == v20;
        bool v23;
        if (v21){
            bool v22;
            v22 = v18 < v2;
            v23 = v22;
        } else {
            v23 = false;
        }
        if (v23){
            String * v24;
            v24 = StringConcat(v17, StringLit(2, "\n"));
            StringDecref(v17);
            return frame_text_loop4(v0, v1, v2, v18, v24);
        } else {
            return frame_text_loop4(v0, v1, v2, v18, v17);
        }
    }
}
char runtime_byte7(String * v0, int32_t v1){
    char v2;
    v2 = v0->ptr[v1];
    StringDecref(v0);
    return v2;
}
int32_t utf8_scalar_at_byte_offset6(String * v0, int32_t v1){
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
            v7 = runtime_byte7(v0, v1);
            int32_t v8;
            v8 = ((uint8_t)v7);
            bool v9;
            v9 = v8 < 128l;
            if (v9){
                StringDecref(v0);
                return v8;
            } else {
                bool v10;
                v10 = v8 < 194l;
                if (v10){
                    StringDecref(v0);
                    fprintf(stderr, "%s\n", "UTF-8 scalar starts with an invalid lead byte.");
                    exit(EXIT_FAILURE);
                } else {
                    bool v12;
                    v12 = v8 < 224l;
                    if (v12){
                        int32_t v13;
                        v13 = v1 + 1l;
                        bool v14;
                        v14 = v13 >= v2;
                        if (v14){
                            StringDecref(v0);
                            fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                            exit(EXIT_FAILURE);
                        } else {
                            v0->refc++;
                            char v16;
                            v16 = runtime_byte7(v0, v13);
                            StringDecref(v0);
                            int32_t v17;
                            v17 = ((uint8_t)v16);
                            bool v18;
                            v18 = v17 < 128l;
                            bool v20;
                            if (v18){
                                v20 = false;
                            } else {
                                bool v19;
                                v19 = v17 < 192l;
                                v20 = v19;
                            }
                            if (v20){
                                int32_t v21;
                                v21 = v8 - 192l;
                                int32_t v22;
                                v22 = v21 * 64l;
                                int32_t v23;
                                v23 = v17 - 128l;
                                int32_t v24;
                                v24 = v22 + v23;
                                return v24;
                            } else {
                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    } else {
                        bool v28;
                        v28 = v8 < 240l;
                        if (v28){
                            int32_t v29;
                            v29 = v1 + 2l;
                            bool v30;
                            v30 = v29 >= v2;
                            if (v30){
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                exit(EXIT_FAILURE);
                            } else {
                                int32_t v32;
                                v32 = v1 + 1l;
                                v0->refc++;
                                char v33;
                                v33 = runtime_byte7(v0, v32);
                                int32_t v34;
                                v34 = ((uint8_t)v33);
                                v0->refc++;
                                char v35;
                                v35 = runtime_byte7(v0, v29);
                                StringDecref(v0);
                                int32_t v36;
                                v36 = ((uint8_t)v35);
                                bool v37;
                                v37 = v34 < 128l;
                                bool v39;
                                if (v37){
                                    v39 = false;
                                } else {
                                    bool v38;
                                    v38 = v34 < 192l;
                                    v39 = v38;
                                }
                                if (v39){
                                    bool v40;
                                    v40 = v36 < 128l;
                                    bool v42;
                                    if (v40){
                                        v42 = false;
                                    } else {
                                        bool v41;
                                        v41 = v36 < 192l;
                                        v42 = v41;
                                    }
                                    if (v42){
                                        int32_t v43;
                                        v43 = v8 - 224l;
                                        int32_t v44;
                                        v44 = v43 * 4096l;
                                        int32_t v45;
                                        v45 = v34 - 128l;
                                        int32_t v46;
                                        v46 = v45 * 64l;
                                        int32_t v47;
                                        v47 = v44 + v46;
                                        int32_t v48;
                                        v48 = v36 - 128l;
                                        int32_t v49;
                                        v49 = v47 + v48;
                                        bool v50;
                                        v50 = v49 < 2048l;
                                        if (v50){
                                            fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                            exit(EXIT_FAILURE);
                                        } else {
                                            bool v52;
                                            v52 = v49 >= 55296l;
                                            if (v52){
                                                bool v53;
                                                v53 = v49 <= 57343l;
                                                if (v53){
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence encodes a surrogate.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    return v49;
                                                }
                                            } else {
                                                return v49;
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
                            bool v63;
                            v63 = v8 < 245l;
                            if (v63){
                                int32_t v64;
                                v64 = v1 + 3l;
                                bool v65;
                                v65 = v64 >= v2;
                                if (v65){
                                    StringDecref(v0);
                                    fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                    exit(EXIT_FAILURE);
                                } else {
                                    int32_t v67;
                                    v67 = v1 + 1l;
                                    v0->refc++;
                                    char v68;
                                    v68 = runtime_byte7(v0, v67);
                                    int32_t v69;
                                    v69 = ((uint8_t)v68);
                                    int32_t v70;
                                    v70 = v1 + 2l;
                                    v0->refc++;
                                    char v71;
                                    v71 = runtime_byte7(v0, v70);
                                    int32_t v72;
                                    v72 = ((uint8_t)v71);
                                    v0->refc++;
                                    char v73;
                                    v73 = runtime_byte7(v0, v64);
                                    StringDecref(v0);
                                    int32_t v74;
                                    v74 = ((uint8_t)v73);
                                    bool v75;
                                    v75 = v69 < 128l;
                                    bool v77;
                                    if (v75){
                                        v77 = false;
                                    } else {
                                        bool v76;
                                        v76 = v69 < 192l;
                                        v77 = v76;
                                    }
                                    if (v77){
                                        bool v78;
                                        v78 = v72 < 128l;
                                        bool v80;
                                        if (v78){
                                            v80 = false;
                                        } else {
                                            bool v79;
                                            v79 = v72 < 192l;
                                            v80 = v79;
                                        }
                                        if (v80){
                                            bool v81;
                                            v81 = v74 < 128l;
                                            bool v83;
                                            if (v81){
                                                v83 = false;
                                            } else {
                                                bool v82;
                                                v82 = v74 < 192l;
                                                v83 = v82;
                                            }
                                            if (v83){
                                                int32_t v84;
                                                v84 = v8 - 240l;
                                                int32_t v85;
                                                v85 = v84 * 262144l;
                                                int32_t v86;
                                                v86 = v69 - 128l;
                                                int32_t v87;
                                                v87 = v86 * 4096l;
                                                int32_t v88;
                                                v88 = v85 + v87;
                                                int32_t v89;
                                                v89 = v72 - 128l;
                                                int32_t v90;
                                                v90 = v89 * 64l;
                                                int32_t v91;
                                                v91 = v88 + v90;
                                                int32_t v92;
                                                v92 = v74 - 128l;
                                                int32_t v93;
                                                v93 = v91 + v92;
                                                bool v94;
                                                v94 = v93 < 65536l;
                                                if (v94){
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    bool v96;
                                                    v96 = v93 > 1114111l;
                                                    if (v96){
                                                        fprintf(stderr, "%s\n", "UTF-8 scalar is above U+10FFFF.");
                                                        exit(EXIT_FAILURE);
                                                    } else {
                                                        return v93;
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
int32_t loop5(String * v0, int32_t v1, int32_t v2, int32_t v3){
    bool v4;
    v4 = v2 == v1;
    if (v4){
        StringDecref(v0);
        return v3;
    } else {
        bool v5;
        v5 = v2 > v1;
        if (v5){
            StringDecref(v0);
            fprintf(stderr, "%s\n", "UTF-8 scalar width exceeds the string.");
            exit(EXIT_FAILURE);
        } else {
            v0->refc++;
            int32_t v7;
            v7 = utf8_scalar_at_byte_offset6(v0, v2);
            bool v8;
            v8 = v7 < 128l;
            int32_t v13;
            if (v8){
                v13 = 1l;
            } else {
                bool v9;
                v9 = v7 < 2048l;
                if (v9){
                    v13 = 2l;
                } else {
                    bool v10;
                    v10 = v7 < 65536l;
                    if (v10){
                        v13 = 3l;
                    } else {
                        v13 = 4l;
                    }
                }
            }
            int32_t v14;
            v14 = v2 + v13;
            int32_t v15;
            v15 = v3 + v7;
            return loop5(v0, v1, v14, v15);
        }
    }
}
int32_t main(){
    Array0 * v0;
    v0 = method0();
    v0->refc++;
    int32_t v1;
    v1 = method1(v0);
    v0->refc++;
    int32_t v2;
    v2 = method2(v0);
    v0->refc++;
    int32_t v3;
    v3 = method3(v0);
    int32_t v4;
    v4 = v0->ptr[0l];
    int32_t v5;
    v5 = v0->ptr[5180l];
    int32_t v6;
    v6 = v0->ptr[4258l];
    int32_t v7;
    v7 = v0->ptr[3964l];
    int32_t v8;
    v8 = 160l;
    int32_t v9;
    v9 = 7040l;
    int32_t v10;
    v10 = 0l;
    String * v11;
    v11 = StringLit(1, "");
    v0->refc++; v11->refc++;
    String * v12;
    v12 = frame_text_loop4(v0, v8, v9, v10, v11);
    ArrayDecref0(v0); StringDecref(v11);
    int32_t v13;
    v13 = v12->len-1;
    int32_t v14;
    v14 = 0l;
    int32_t v15;
    v15 = 0l;
    v12->refc++;
    int32_t v16;
    v16 = loop5(v12, v13, v14, v15);
    int32_t v17;
    v17 = 0l;
    v12->refc++;
    int32_t v18;
    v18 = utf8_scalar_at_byte_offset6(v12, v17);
    int32_t v19;
    v19 = 160l;
    v12->refc++;
    int32_t v20;
    v20 = utf8_scalar_at_byte_offset6(v12, v19);
    int32_t v21;
    v21 = 3988l;
    v12->refc++;
    int32_t v22;
    v22 = utf8_scalar_at_byte_offset6(v12, v21);
    int32_t v23;
    v23 = 4284l;
    v12->refc++;
    int32_t v24;
    v24 = utf8_scalar_at_byte_offset6(v12, v23);
    int32_t v25;
    v25 = 5212l;
    v12->refc++;
    int32_t v26;
    v26 = utf8_scalar_at_byte_offset6(v12, v25);
    int32_t v27;
    v27 = 7082l;
    v12->refc++;
    int32_t v28;
    v28 = utf8_scalar_at_byte_offset6(v12, v27);
    StringDecref(v12);
    bool v29;
    v29 = v1 == 5180l;
    bool v31;
    if (v29){
        bool v30;
        v30 = v2 == 4258l;
        v31 = v30;
    } else {
        v31 = false;
    }
    bool v33;
    if (v31){
        bool v32;
        v32 = v3 == 3964l;
        v33 = v32;
    } else {
        v33 = false;
    }
    bool v35;
    if (v33){
        bool v34;
        v34 = v4 == 46l;
        v35 = v34;
    } else {
        v35 = false;
    }
    bool v37;
    if (v35){
        bool v36;
        v36 = v5 == 35l;
        v37 = v36;
    } else {
        v37 = false;
    }
    bool v39;
    if (v37){
        bool v38;
        v38 = v6 == 64l;
        v39 = v38;
    } else {
        v39 = false;
    }
    bool v41;
    if (v39){
        bool v40;
        v40 = v7 == 43l;
        v41 = v40;
    } else {
        v41 = false;
    }
    bool v43;
    if (v41){
        bool v42;
        v42 = v13 == 7083l;
        v43 = v42;
    } else {
        v43 = false;
    }
    bool v45;
    if (v43){
        bool v44;
        v44 = v16 == 324274l;
        v45 = v44;
    } else {
        v45 = false;
    }
    bool v47;
    if (v45){
        bool v46;
        v46 = v18 == 46l;
        v47 = v46;
    } else {
        v47 = false;
    }
    bool v49;
    if (v47){
        bool v48;
        v48 = v20 == 10l;
        v49 = v48;
    } else {
        v49 = false;
    }
    bool v51;
    if (v49){
        bool v50;
        v50 = v22 == 43l;
        v51 = v50;
    } else {
        v51 = false;
    }
    bool v53;
    if (v51){
        bool v52;
        v52 = v24 == 64l;
        v53 = v52;
    } else {
        v53 = false;
    }
    bool v55;
    if (v53){
        bool v54;
        v54 = v26 == 35l;
        v55 = v54;
    } else {
        v55 = false;
    }
    bool v57;
    if (v55){
        bool v56;
        v56 = v28 == 46l;
        v57 = v56;
    } else {
        v57 = false;
    }
    if (v57){
        return 42l;
    } else {
        return 1l;
    }
}
