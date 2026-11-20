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
int32_t main(){
    int32_t v0 = 16l;
    String * v1 = StringLit(4, "x\ny");
    String * v2 = StringLit(9, "say \"hi\"");
    String * v3 = StringLit(8, "a \"\"\" b");
    String * v4 = StringLit(24, "first\n    second\n\nthird");
    String * v5 = StringLit(6, "ab\ncd");
    String * v6 = StringLit(8, "a \"b\" c");
    String * v7 = StringLit(1, "");
    String * v8 = StringLit(5, "a\\nb");
    String * v9 = StringLit(84, "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented");
    String * v10 = StringLit(12, "\ntop\n\nlevel");
    int32_t v11 = v6->len-1;
    bool v12 = v11 != 7l;
    if (v12){
        StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v6); StringDecref(v7); StringDecref(v8); StringDecref(v9); StringDecref(v10);
        return 1l;
    } else {
        char v13 = v6->ptr[2l];
        StringDecref(v6);
        bool v14 = v13 != '"';
        if (v14){
            StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v7); StringDecref(v8); StringDecref(v9); StringDecref(v10);
            return 2l;
        } else {
            int32_t v15 = v7->len-1;
            StringDecref(v7);
            bool v16 = v15 != 0l;
            if (v16){
                StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v8); StringDecref(v9); StringDecref(v10);
                return 3l;
            } else {
                int32_t v17 = v8->len-1;
                bool v18 = v17 != 4l;
                if (v18){
                    StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v8); StringDecref(v9); StringDecref(v10);
                    return 4l;
                } else {
                    char v19 = v8->ptr[1l];
                    StringDecref(v8);
                    bool v20 = v19 != '\\';
                    if (v20){
                        StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                        return 5l;
                    } else {
                        int32_t v21 = v9->len-1;
                        bool v22 = v21 != 83l;
                        if (v22){
                            StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                            return 6l;
                        } else {
                            char v23 = v9->ptr[5l];
                            bool v24 = v23 != '\n';
                            if (v24){
                                StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                return 7l;
                            } else {
                                char v25 = v9->ptr[37l];
                                bool v26 = v25 != '\n';
                                if (v26){
                                    StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                    return 8l;
                                } else {
                                    char v27 = v9->ptr[38l];
                                    bool v28 = v27 != '\n';
                                    if (v28){
                                        StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                        return 9l;
                                    } else {
                                        char v29 = v9->ptr[39l];
                                        bool v30 = v29 != '$';
                                        if (v30){
                                            StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                            return 10l;
                                        } else {
                                            char v31 = v9->ptr[57l];
                                            bool v32 = v31 != 'i';
                                            if (v32){
                                                StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                                return 11l;
                                            } else {
                                                char v33 = v9->ptr[82l];
                                                StringDecref(v9);
                                                bool v34 = v33 != 'd';
                                                if (v34){
                                                    StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v10);
                                                    return 12l;
                                                } else {
                                                    int32_t v35 = v10->len-1;
                                                    bool v36 = v35 != 11l;
                                                    if (v36){
                                                        StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v10);
                                                        return 13l;
                                                    } else {
                                                        char v37 = v10->ptr[0l];
                                                        bool v38 = v37 != '\n';
                                                        if (v38){
                                                            StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v10);
                                                            return 14l;
                                                        } else {
                                                            char v39 = v10->ptr[5l];
                                                            StringDecref(v10);
                                                            bool v40 = v39 != '\n';
                                                            if (v40){
                                                                StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                return 15l;
                                                            } else {
                                                                bool v41 = v0 != 16l;
                                                                if (v41){
                                                                    StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                    return 16l;
                                                                } else {
                                                                    int32_t v42 = v1->len-1;
                                                                    StringDecref(v1);
                                                                    bool v43 = v42 != 3l;
                                                                    if (v43){
                                                                        StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                        return 17l;
                                                                    } else {
                                                                        int32_t v44 = v2->len-1;
                                                                        bool v45 = v44 != 8l;
                                                                        if (v45){
                                                                            StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                            return 18l;
                                                                        } else {
                                                                            char v46 = v2->ptr[7l];
                                                                            StringDecref(v2);
                                                                            bool v47 = v46 != '"';
                                                                            if (v47){
                                                                                StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                                return 19l;
                                                                            } else {
                                                                                int32_t v48 = v3->len-1;
                                                                                bool v49 = v48 != 7l;
                                                                                if (v49){
                                                                                    StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                                    return 20l;
                                                                                } else {
                                                                                    char v50 = v3->ptr[4l];
                                                                                    StringDecref(v3);
                                                                                    bool v51 = v50 != '"';
                                                                                    if (v51){
                                                                                        StringDecref(v4); StringDecref(v5);
                                                                                        return 21l;
                                                                                    } else {
                                                                                        int32_t v52 = v4->len-1;
                                                                                        bool v53 = v52 != 23l;
                                                                                        if (v53){
                                                                                            StringDecref(v4); StringDecref(v5);
                                                                                            return 22l;
                                                                                        } else {
                                                                                            char v54 = v4->ptr[6l];
                                                                                            bool v55 = v54 != ' ';
                                                                                            if (v55){
                                                                                                StringDecref(v4); StringDecref(v5);
                                                                                                return 23l;
                                                                                            } else {
                                                                                                char v56 = v4->ptr[10l];
                                                                                                bool v57 = v56 != 's';
                                                                                                if (v57){
                                                                                                    StringDecref(v4); StringDecref(v5);
                                                                                                    return 24l;
                                                                                                } else {
                                                                                                    char v58 = v4->ptr[17l];
                                                                                                    bool v59 = v58 != '\n';
                                                                                                    if (v59){
                                                                                                        StringDecref(v4); StringDecref(v5);
                                                                                                        return 25l;
                                                                                                    } else {
                                                                                                        char v60 = v4->ptr[22l];
                                                                                                        StringDecref(v4);
                                                                                                        bool v61 = v60 != 'd';
                                                                                                        if (v61){
                                                                                                            StringDecref(v5);
                                                                                                            return 26l;
                                                                                                        } else {
                                                                                                            int32_t v62 = v5->len-1;
                                                                                                            bool v63 = v62 != 5l;
                                                                                                            if (v63){
                                                                                                                StringDecref(v5);
                                                                                                                return 27l;
                                                                                                            } else {
                                                                                                                char v64 = v5->ptr[3l];
                                                                                                                StringDecref(v5);
                                                                                                                bool v65 = v64 != 'c';
                                                                                                                if (v65){
                                                                                                                    return 28l;
                                                                                                                } else {
                                                                                                                    return 0l;
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
